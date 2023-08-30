// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Fluent.Tests.Compute.VirtualMachine
{
    public class CustomImageOperations
    {
        private readonly Region Location = Region.USEast;

        [Fact]
        public void CanCreateImageFromNativeVhd()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vhdBasedImageName = SdkContext.RandomResourceName("img", 20);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");

                try
                {
                    var linuxVM = PrepareGeneralizedVMWith2EmptyDataDisks(rgName,
                            SdkContext.RandomResourceName("muldvm", 15),
                            Location,
                            computeManager);
                    //
                    var creatableDisk = computeManager.VirtualMachineCustomImages.Define(vhdBasedImageName)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithLinuxFromVhd(linuxVM.OSUnmanagedDiskVhdUri, OperatingSystemStateTypes.Generalized)
                            .WithOSDiskCaching(linuxVM.OSDiskCachingType);
                    foreach (var disk in linuxVM.UnmanagedDataDisks.Values)
                    {
                        creatableDisk.DefineDataDiskImage()
                                .WithLun(disk.Lun)
                                .FromVhd(disk.VhdUri)
                                .WithDiskCaching(disk.CachingType)
                                .WithDiskSizeInGB(disk.Size + 10) // Resize each data disk image by +10GB
                                .Attach();
                    }
                    var customImage = creatableDisk.Create();
                    Assert.NotNull(customImage.Id);
                    Assert.Equal(customImage.Name, vhdBasedImageName);
                    Assert.False(customImage.IsCreatedFromVirtualMachine);
                    Assert.Null(customImage.SourceVirtualMachineId);
                    Assert.NotNull(customImage.OSDiskImage);
                    Assert.NotNull(customImage.OSDiskImage.BlobUri);
                    Assert.Equal(CachingTypes.ReadWrite, customImage.OSDiskImage.Caching);
                    Assert.Equal(OperatingSystemStateTypes.Generalized, customImage.OSDiskImage.OsState);
                    Assert.Equal(OperatingSystemTypes.Linux, customImage.OSDiskImage.OsType);
                    Assert.NotNull(customImage.DataDiskImages);
                    Assert.Equal(customImage.DataDiskImages.Count, linuxVM.UnmanagedDataDisks.Count);
                    Assert.Equal(customImage.HyperVGeneration, HyperVGenerationTypes.V1);
                    foreach (ImageDataDisk diskImage in customImage.DataDiskImages.Values)
                    {
                        IVirtualMachineUnmanagedDataDisk matchedDisk = null;
                        foreach (var vmDisk in linuxVM.UnmanagedDataDisks.Values)
                        {
                            if (vmDisk.Lun == diskImage.Lun)
                            {
                                matchedDisk = vmDisk;
                                break;
                            }
                        }
                        Assert.NotNull(matchedDisk);
                        Assert.Equal(matchedDisk.CachingType, diskImage.Caching);
                        Assert.Equal(matchedDisk.VhdUri, diskImage.BlobUri);
                        Assert.Equal((long)matchedDisk.Size + 10, (long)diskImage.DiskSizeGB);
                    }
                    var image = computeManager
                            .VirtualMachineCustomImages
                            .GetByResourceGroup(rgName, vhdBasedImageName);
                    Assert.NotNull(image);
                    var images = computeManager
                            .VirtualMachineCustomImages
                            .ListByResourceGroup(rgName);
                    Assert.True(images.Count() > 0);

                    // Create virtual machine from custom image
                    //
                    var virtualMachine = computeManager.VirtualMachines
                            .Define(SdkContext.RandomResourceName("cusvm", 15))
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithLinuxCustomImage(image.Id)
                            .WithRootUsername("javauser")
                            .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();

                    var dataDisks = virtualMachine.DataDisks;
                    Assert.NotNull(dataDisks);
                    Assert.Equal(dataDisks.Count, image.DataDiskImages.Count);

                    //Create a hyperv Gen2 image
                    var creatableDiskGen2 = computeManager
                            .VirtualMachineCustomImages
                            .Define(vhdBasedImageName + "Gen2")
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithHyperVGeneration(HyperVGenerationTypes.V2)
                            .WithLinuxFromVhd(linuxVM.OSUnmanagedDiskVhdUri, OperatingSystemStateTypes.Generalized)
                            .WithOSDiskCaching(linuxVM.OSDiskCachingType);
                    foreach (var disk in linuxVM.UnmanagedDataDisks.Values)
                    {
                        creatableDisk.DefineDataDiskImage()
                                .WithLun(disk.Lun)
                                .FromVhd(disk.VhdUri)
                                .WithDiskCaching(disk.CachingType)
                                .WithDiskSizeInGB(disk.Size + 10) // Resize each data disk image by +10GB
                                .Attach();
                    }
                    IVirtualMachineCustomImage customImageGen2 = creatableDiskGen2.Create();
                    Assert.NotNull(customImageGen2.Id);
                    Assert.Equal(customImageGen2.Name, vhdBasedImageName + "Gen2");
                    Assert.False(customImageGen2.IsCreatedFromVirtualMachine);
                    Assert.Null(customImageGen2.SourceVirtualMachineId);
                    Assert.NotNull(customImageGen2.OSDiskImage);
                    Assert.NotNull(customImageGen2.OSDiskImage);
                    Assert.Equal(CachingTypes.ReadWrite, customImageGen2.OSDiskImage.Caching);
                    Assert.Equal(OperatingSystemStateTypes.Generalized, customImageGen2.OSDiskImage.OsState);
                    Assert.Equal(OperatingSystemTypes.Linux, customImageGen2.OSDiskImage.OsType);
                    Assert.NotNull(customImageGen2.DataDiskImages);
                    Assert.Equal(0, customImageGen2.DataDiskImages.Count);
                    Assert.Equal(customImageGen2.HyperVGeneration, HyperVGenerationTypes.V2);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateImageByCapturingVM()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmName = SdkContext.RandomResourceName("vm67-", 20);
                var imageName = SdkContext.RandomResourceName("img", 15);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");
                var vm = PrepareGeneralizedVMWith2EmptyDataDisks(rgName, vmName, Location, computeManager);

                try
                {

                    var customImage = computeManager.VirtualMachineCustomImages
                            .Define(imageName)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithHyperVGeneration(HyperVGenerationTypes.V1)
                            .FromVirtualMachine(vm.Id)
                            .Create();

                    Assert.Equal(customImage.Name, imageName, ignoreCase: true);
                    Assert.NotNull(customImage.OSDiskImage);
                    Assert.Equal(OperatingSystemStateTypes.Generalized, customImage.OSDiskImage.OsState);
                    Assert.Equal(OperatingSystemTypes.Linux, customImage.OSDiskImage.OsType);
                    Assert.NotNull(customImage.DataDiskImages);
                    Assert.Equal(2, customImage.DataDiskImages.Count);
                    Assert.NotNull(customImage.SourceVirtualMachineId);
                    Assert.Equal(customImage.SourceVirtualMachineId, vm.Id, ignoreCase: true);
                    Assert.Equal(customImage.HyperVGeneration, HyperVGenerationTypes.V1);

                    foreach (var vmDisk in vm.UnmanagedDataDisks.Values)
                    {
                        Assert.True(customImage.DataDiskImages.ContainsKey(vmDisk.Lun));
                        var diskImage = customImage.DataDiskImages[vmDisk.Lun];
                        Assert.Equal(diskImage.Caching, vmDisk.CachingType);
                        Assert.Equal((long)diskImage.DiskSizeGB, vmDisk.Size);
                        Assert.NotNull(diskImage.BlobUri);
                        diskImage.BlobUri.Equals(vmDisk.VhdUri, StringComparison.OrdinalIgnoreCase);
                    }

                    customImage = computeManager.VirtualMachineCustomImages.GetByResourceGroup(rgName, imageName);
                    Assert.NotNull(customImage);
                    Assert.NotNull(customImage.Inner);
                    computeManager.VirtualMachineCustomImages.DeleteById(customImage.Id);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateImageFromManagedDisk()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmName = SdkContext.RandomResourceName("vm7-", 20);
                var storageAccountName = SdkContext.RandomResourceName("stg", 17);
                var uname = "juser";
                var password = TestUtilities.GenerateName("Pa5$");
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var storageManager = TestHelper.CreateStorageManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");
                try
                {
                    var nativeVM = computeManager.VirtualMachines
                            .Define(vmName)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithLatestLinuxImage("Canonical", "UbuntuServer", "14.04.2-LTS")
                            .WithRootUsername(uname)
                            .WithRootPassword(password)
                            .WithUnmanagedDisks()                  /* UN-MANAGED OS and DATA DISKS */
                            .DefineUnmanagedDataDisk("disk1")
                                .WithNewVhd(100)
                                .WithCaching(CachingTypes.ReadWrite)
                                .Attach()
                            .WithNewUnmanagedDataDisk(100)
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                            .WithNewStorageAccount(storageAccountName)
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();

                    Assert.False(nativeVM.IsManagedDiskEnabled);
                    var osVhdUri = nativeVM.OSUnmanagedDiskVhdUri;
                    Assert.NotNull(osVhdUri);
                    var dataDisks = nativeVM.UnmanagedDataDisks;
                    Assert.Equal(2, dataDisks.Count);

                    computeManager.VirtualMachines.DeleteById(nativeVM.Id);

                    var osDiskName = SdkContext.RandomResourceName("dsk", 15);
                    // Create managed disk with Os from vm's Os disk
                    //
                    var managedOsDisk = computeManager.Disks.Define(osDiskName)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithLinuxFromVhd(osVhdUri)
                            .WithStorageAccountName(storageAccountName)
                            .Create();

                    // Create managed disk with Data from vm's lun0 data disk
                    //
                    var storageAccount = storageManager.StorageAccounts.GetByResourceGroup(rgName, storageAccountName);

                    var dataDiskName1 = SdkContext.RandomResourceName("dsk", 15);
                    var vmNativeDataDisk1 = dataDisks[0];
                    var managedDataDisk1 = computeManager.Disks.Define(dataDiskName1)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithData()
                            .FromVhd(vmNativeDataDisk1.VhdUri)
                            .WithStorageAccount(storageAccount)
                            .Create();

                    // Create managed disk with Data from vm's lun1 data disk
                    //
                    var dataDiskName2 = SdkContext.RandomResourceName("dsk", 15);
                    var vmNativeDataDisk2 = dataDisks[1];
                    var managedDataDisk2 = computeManager.Disks.Define(dataDiskName2)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithData()
                            .FromVhd(vmNativeDataDisk2.VhdUri)
                            .WithStorageAccountId(storageAccount.Id)
                            .Create();

                    // Create an image from the above managed disks
                    // Note that this is not a direct user scenario, but including this as per CRP team request
                    //
                    var imageName = SdkContext.RandomResourceName("img", 15);
                    var customImage = computeManager.VirtualMachineCustomImages.Define(imageName)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithLinuxFromDisk(managedOsDisk, OperatingSystemStateTypes.Generalized)
                            .DefineDataDiskImage()
                                .WithLun(vmNativeDataDisk1.Lun)
                                .FromManagedDisk(managedDataDisk1)
                                .WithDiskCaching(vmNativeDataDisk1.CachingType)
                                .WithDiskSizeInGB(vmNativeDataDisk1.Size + 10)
                                .Attach()
                            .DefineDataDiskImage()
                                .WithLun(vmNativeDataDisk2.Lun)
                                .FromManagedDisk(managedDataDisk2)
                                .WithDiskSizeInGB(vmNativeDataDisk2.Size + 10)
                                .Attach()
                            .Create();

                    Assert.NotNull(customImage);
                    Assert.Equal(customImage.Name, imageName, ignoreCase: true);
                    Assert.NotNull(customImage.OSDiskImage);
                    Assert.Equal(OperatingSystemStateTypes.Generalized, customImage.OSDiskImage.OsState);
                    Assert.Equal(OperatingSystemTypes.Linux, customImage.OSDiskImage.OsType);
                    Assert.NotNull(customImage.DataDiskImages);
                    Assert.Equal(2, customImage.DataDiskImages.Count);
                    Assert.Equal(customImage.HyperVGeneration, HyperVGenerationTypes.V1);
                    Assert.Null(customImage.SourceVirtualMachineId);

                    Assert.True(customImage.DataDiskImages.ContainsKey(vmNativeDataDisk1.Lun));
                    Assert.Equal(customImage.DataDiskImages[vmNativeDataDisk1.Lun].Caching, vmNativeDataDisk1.CachingType);
                    Assert.True(customImage.DataDiskImages.ContainsKey(vmNativeDataDisk2.Lun));
                    Assert.Equal(CachingTypes.None, customImage.DataDiskImages[vmNativeDataDisk2.Lun].Caching);

                    foreach (var vmDisk in dataDisks.Values)
                    {
                        Assert.True(customImage.DataDiskImages.ContainsKey(vmDisk.Lun));
                        var diskImage = customImage.DataDiskImages[vmDisk.Lun];
                        Assert.Equal((long)diskImage.DiskSizeGB, vmDisk.Size + 10);
                        Assert.Null(diskImage.BlobUri);
                        Assert.NotNull(diskImage.ManagedDisk);
                        Assert.True(diskImage.ManagedDisk.Id.Equals(managedDataDisk1.Id, StringComparison.OrdinalIgnoreCase)
                                || diskImage.ManagedDisk.Id.Equals(managedDataDisk2.Id, StringComparison.OrdinalIgnoreCase));
                    }
                    computeManager.Disks.DeleteById(managedOsDisk.Id);
                    computeManager.Disks.DeleteById(managedDataDisk1.Id);
                    computeManager.Disks.DeleteById(managedDataDisk2.Id);
                    computeManager.VirtualMachineCustomImages.DeleteById(customImage.Id);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        private IVirtualMachine PrepareGeneralizedVMWith2EmptyDataDisks(string rgName,
                                                     string vmName,
                                                     Region Location,
                                                     IComputeManager computeManager)
        {
            var uname = "javauser";
            var password = TestUtilities.GenerateName("Pa5$");
            KnownLinuxVirtualMachineImage linuxImage = KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts;
            var publicIPDnsLabel = SdkContext.RandomResourceName("pip", 20);

            var virtualMachine = computeManager.VirtualMachines
                    .Define(vmName)
                    .WithRegion(Location)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithNewPrimaryPublicIPAddress(publicIPDnsLabel)
                    .WithPopularLinuxImage(linuxImage)
                    .WithRootUsername(uname)
                    .WithRootPassword(password)
                    .WithUnmanagedDisks()
                    .DefineUnmanagedDataDisk("disk-1")
                        .WithNewVhd(30)
                        .WithCaching(CachingTypes.ReadWrite)
                        .Attach()
                    .DefineUnmanagedDataDisk("disk-2")
                        .WithNewVhd(60)
                        .WithCaching(CachingTypes.ReadOnly)
                        .Attach()
                    .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                    .WithNewStorageAccount(SdkContext.RandomResourceName("stg", 17))
                    .WithOSDiskCaching(CachingTypes.ReadWrite)
                    .Create();
            //
            TestHelper.DeprovisionAgentInLinuxVM(virtualMachine.GetPrimaryPublicIPAddress().Fqdn, 22, uname, password);
            virtualMachine.Deallocate();
            virtualMachine.Generalize();
            return virtualMachine;
        }
    }
}
