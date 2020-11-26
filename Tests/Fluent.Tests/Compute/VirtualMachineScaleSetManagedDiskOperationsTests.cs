// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Fluent.Tests.Compute;
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
    public class ScaleSetManagedDiskOperations
    {
        private readonly Region Location = Region.USEast;

        [Fact]
        public void CanCreateUpdateFromPIRWithManagedDisk()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmssName = SdkContext.RandomResourceName("vmss", 10);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var networkManager = TestHelper.CreateNetworkManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");
                try
                {
                    var resourceGroup = resourceManager.ResourceGroups
                            .Define(rgName)
                            .WithRegion(Location)
                            .Create();

                    var network = networkManager
                            .Networks
                            .Define(SdkContext.RandomResourceName("vmssvnet", 15))
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithSubnet("subnet1", "10.0.0.0/28")
                            .Create();

                    var publicLoadBalancer = ScaleSet.CreateHttpLoadBalancers(resourceManager, resourceGroup, "1", Location);
                    var vmScaleSet = computeManager.VirtualMachineScaleSets
                            .Define(vmssName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithSku(VirtualMachineScaleSetSkuTypes.StandardD5v2)
                            .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                            .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                            .WithoutPrimaryInternalLoadBalancer()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("jvuser")
                            .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                            .WithNewDataDisk(100)
                            .WithNewDataDisk(100, 1, CachingTypes.ReadWrite)
                            .WithNewDataDisk(100, 2, CachingTypes.ReadOnly)
                            .Create();

                    var virtualMachineScaleSetVMs = vmScaleSet.VirtualMachines;
                    var virtualMachines = virtualMachineScaleSetVMs.List();
                    Assert.Equal(virtualMachines.Count(), vmScaleSet.Capacity);
                    foreach (var vm in virtualMachines)
                    {
                        Assert.True(vm.IsOSBasedOnPlatformImage);
                        Assert.False(vm.IsOSBasedOnCustomImage);
                        Assert.False(vm.IsOSBasedOnStoredImage);
                        Assert.True(vm.IsManagedDiskEnabled);
                        Assert.NotNull(vm.UnmanagedDataDisks);
                        Assert.Empty(vm.UnmanagedDataDisks);
                        Assert.NotNull(vm.DataDisks);
                        Assert.Equal(3, vm.DataDisks.Count);
                    }
                    vmScaleSet.Update()
                            .WithoutDataDisk(0)
                            .WithNewDataDisk(50)
                            .Apply();

                    virtualMachineScaleSetVMs = vmScaleSet.VirtualMachines;
                    virtualMachines = virtualMachineScaleSetVMs.List();
                    Assert.Equal(virtualMachines.Count(), vmScaleSet.Capacity);
                    foreach (var vm in virtualMachines)
                    {
                        Assert.NotNull(vm.DataDisks);
                        Assert.Equal(3, vm.DataDisks.Count);
                    }

                    // test attach/detach data disk to single instance
                    string diskName = SdkContext.RandomResourceName("disk", 10);
                    IDisk disk0 = computeManager.Disks
                        .Define(diskName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(rgName)
                        .WithData()
                        .WithSizeInGB(32)
                        .Create();

                    var vmEnumerator = virtualMachines.GetEnumerator();
                    vmEnumerator.MoveNext();
                    IVirtualMachineScaleSetVM vm0 = vmEnumerator.Current;
                    vmEnumerator.MoveNext();
                    IVirtualMachineScaleSetVM vm1 = vmEnumerator.Current;
                    int existDiskLun = 2;
                    int newDiskLun = 10;
                    // cannot detach non-exist disk
                    Assert.Throws<InvalidOperationException>(
                        () => vm0.Update().WithoutDataDisk(newDiskLun)
                    );
                    // cannot detach disk from VMSS model
                    Assert.Throws<InvalidOperationException>(
                        () => vm0.Update().WithoutDataDisk(existDiskLun)
                    );
                    // cannot attach disk with same lun
                    Assert.Throws<InvalidOperationException>(
                        () => vm0.Update().WithExistingDataDisk(disk0, existDiskLun, CachingTypes.None)
                    );
                    // cannot attach disk with same lun
                    Assert.Throws<InvalidOperationException>(
                        () => vm0.Update().WithExistingDataDisk(disk0, newDiskLun, CachingTypes.None).WithExistingDataDisk(disk0, newDiskLun, CachingTypes.None)
                    );

                    // attach disk
                    int vmssModelDiskCount = vm0.DataDisks.Count;
                    vm0.Update()
                        .WithExistingDataDisk(disk0, newDiskLun, CachingTypes.ReadWrite)
                        .Apply();
                    Assert.Equal(vmssModelDiskCount + 1, vm0.DataDisks.Count);

                    // cannot attach disk that already attached
                    disk0.Refresh();
                    Assert.Throws<InvalidOperationException>(
                        () => vm1.Update()
                            .WithExistingDataDisk(disk0, newDiskLun, CachingTypes.None)
                            .Apply()
                    );

                    // detach disk
                    vm0.Update()
                        .WithoutDataDisk(newDiskLun)
                        .Apply();
                    Assert.Equal(vmssModelDiskCount, vm0.DataDisks.Count);
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

        [Fact(Skip = "Service Bug: Disks or snapshot cannot be resized down [Starting from compute-2017-12-01]")]
        public void CanCreateFromCustomImageWithManagedDisk()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var userName = "tirekicker";
                var password = TestUtilities.GenerateName("Pa5$");
                var publicIPDnsLabel = SdkContext.RandomResourceName("pip", 10);
                var customImageName = SdkContext.RandomResourceName("img", 10);
                var vmssName = SdkContext.RandomResourceName("vmss", 10);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var networkManager = TestHelper.CreateNetworkManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");
                try
                {
                    var resourceGroup = resourceManager.ResourceGroups
                            .Define(rgName)
                            .WithRegion(Location)
                            .Create();

                    var vm = computeManager.VirtualMachines.Define(SdkContext.RandomResourceName("vm", 10))
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithNewPrimaryPublicIPAddress(publicIPDnsLabel)
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername(userName)
                            .WithRootPassword(password)
                            .WithUnmanagedDisks()
                            .DefineUnmanagedDataDisk("disk-1")
                                .WithNewVhd(100)
                                .WithLun(1)
                                .Attach()
                            .DefineUnmanagedDataDisk("disk-2")
                                .WithNewVhd(50)
                                .WithLun(2)
                                .Attach()
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                            .Create();

                    Assert.NotNull(vm);

                    TestHelper.DeprovisionAgentInLinuxVM(vm.GetPrimaryPublicIPAddress().Fqdn, 22, userName, password);
                    vm.Deallocate();
                    vm.Generalize();

                    var virtualMachineCustomImage = computeManager.VirtualMachineCustomImages
                            .Define(customImageName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .FromVirtualMachine(vm)
                            .Create();

                    Assert.NotNull(virtualMachineCustomImage);

                    var network = networkManager
                            .Networks
                            .Define(SdkContext.RandomResourceName("vmssvnet", 15))
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithSubnet("subnet1", "10.0.0.0/28")
                            .Create();

                    var publicLoadBalancer = ScaleSet.CreateHttpLoadBalancers(resourceManager, resourceGroup, "1", Location);
                    var vmScaleSet = computeManager.VirtualMachineScaleSets
                            .Define(vmssName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithSku(VirtualMachineScaleSetSkuTypes.StandardD5v2)
                            .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                            .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                            .WithoutPrimaryInternalLoadBalancer()
                            .WithLinuxCustomImage(virtualMachineCustomImage.Id)
                            .WithRootUsername(userName)
                            .WithRootPassword(password)
                            .Create();

                    var virtualMachineScaleSetVMs = vmScaleSet.VirtualMachines;
                    var virtualMachines = virtualMachineScaleSetVMs.List();
                    Assert.Equal(virtualMachines.Count(), vmScaleSet.Capacity);
                    foreach (var vm1 in virtualMachines)
                    {
                        Assert.True(vm1.IsOSBasedOnCustomImage);
                        Assert.False(vm1.IsOSBasedOnPlatformImage);
                        Assert.False(vm1.IsOSBasedOnStoredImage);
                        Assert.True(vm1.IsManagedDiskEnabled);
                        Assert.NotNull(vm1.UnmanagedDataDisks);
                        Assert.Empty(vm1.UnmanagedDataDisks);
                        Assert.NotNull(vm1.DataDisks);
                        Assert.Equal(2, vm1.DataDisks.Count); // Disks from data disk image from custom image
                        Assert.True(vm1.DataDisks.ContainsKey(1));
                        var disk = vm1.DataDisks[1];
                        Assert.Equal(100, disk.Size);
                        Assert.True(vm1.DataDisks.ContainsKey(2));
                        disk = vm1.DataDisks[2];
                        Assert.Equal(50, disk.Size);
                    }

                    vmScaleSet.Deallocate();

                    // Updating and adding disk as part of VMSS Update seems consistency failing, CRP is aware of
                    // this, hence until it is fixed comment-out the test
                    //
                    //        {
                    //            "startTime": "2017-01-25T06:10:55.2243509+00:00",
                    //                "endTime": "2017-01-25T06:11:07.8649525+00:00",
                    //                "status": "Failed",
                    //                "error": {
                    //            "code": "InternalExecutionError",
                    //                    "message": "An internal execution error occurred."
                    //        },
                    //            "name": "6786df83-ed3f-4d7a-bf58-d295b96fef46"
                    //        }
                    //
                    //        vmScaleSet.Update()
                    //                .WithDataDiskUpdated(1, 200) // update not supported
                    //                .WithNewDataDisk(100)
                    //                .Apply();
                    //
                    //        vmScaleSet.Start();
                    //
                    //        virtualMachineScaleSetVMs = vmScaleSet.VirtualMachines;
                    //        virtualMachines = virtualMachineScaleSetVMs.List();
                    //        foreach (VirtualMachineScaleSetVM vm1 in virtualMachines) {
                    //            Assert.True(vm1.IsOSBasedOnCustomImage());
                    //            Assert.False(vm1.IsOSBasedOnPlatformImage());
                    //            Assert.False(vm1.IsOSBasedOnStoredImage());
                    //            Assert.True(vm1.IsManagedDiskEnabled());
                    //            Assert.NotNull(vm1.UnmanagedDataDisks());
                    //            Assert.Equal(vm1.UnmanagedDataDisks().Size(), 0);
                    //            Assert.NotNull(vm1.DataDisks());
                    //            Assert.Equal(vm1.DataDisks().Size(), 3);
                    //            Assert.True(vm1.DataDisks().ContainsKey(1));
                    //            VirtualMachineDataDisk disk = vm1.DataDisks().Get(1);
                    //            Assert.Equal(disk.Size(), 200);
                    //            Assert.True(vm1.DataDisks().ContainsKey(2));
                    //            disk = vm1.DataDisks().Get(2);
                    //            Assert.Equal(disk.Size(), 50);
                    //            Assert.True(vm1.DataDisks().ContainsKey(0));
                    //            disk = vm1.DataDisks().Get(0);
                    //            Assert.Equal(disk.Size(), 100);
                    //        }
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
    }
}
