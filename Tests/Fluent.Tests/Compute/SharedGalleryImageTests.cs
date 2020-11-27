// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Fluent.Tests.Compute
{
    public class SharedGalleryImage
    {
        [Fact]
        public void CanCreateUpdateListGetDeleteGallery()
        {

            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                Region region = Region.USWestCentral;
                string rgName = TestUtilities.GenerateName("vmexttest");

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    // Create a gallery
                    //
                    IGallery gallery = azure.Galleries.Define("jvaImageGallery")
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithDescription("jv image gallery")
                        .Create();

                    Assert.NotNull(gallery.UniqueName);
                    Assert.Equal("jvaImageGallery", gallery.Name);
                    Assert.Equal("jv image gallery", gallery.Description);
                    Assert.NotNull(gallery.ProvisioningState);
                    //
                    // Update the gallery
                    //
                    gallery.Update()
                        .WithDescription("updated java's image gallery")
                        .WithTag("jdk", "openjdk")
                        .Apply();

                    Assert.Equal("updated java's image gallery", gallery.Description);
                    Assert.NotNull(gallery.Tags);
                    Assert.Equal(1, gallery.Tags.Count);
                    //
                    // List galleries
                    //
                    IEnumerable<IGallery> galleries = azure.Galleries.ListByResourceGroup(rgName);
                    Assert.Single(galleries);
                    galleries = azure.Galleries.List();
                    Assert.True(galleries.Count() > 0);
                    //
                    azure.Galleries.DeleteByResourceGroup(gallery.ResourceGroupName, gallery.Name);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }


        [Fact]
        public void CanCreateUpdateGetDeleteGalleryImage()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                Region region = Region.USWestCentral;
                string rgName = TestUtilities.GenerateName("vmexttest");
                string galleryName = TestUtilities.GenerateName("jsim");
                string galleryImageName = "JavaImages";

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    // Create a gallery
                    //
                    IGallery javaGallery = azure.Galleries.Define(galleryName)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgName)
                            .WithDescription("java's image gallery")
                            .Create();
                    //
                    // Create an image in the gallery
                    //
                    IGalleryImage galleryImage = azure.GalleryImages.Define(galleryImageName)
                            .WithExistingGallery(javaGallery)
                            .WithLocation(region)
                            .WithIdentifier("JavaSDKTeam", "JDK", "Jdk-9")
                            .WithGeneralizedWindows()
                            // Optionals - Start
                            .WithUnsupportedDiskType(DiskSkuTypes.StandardLRS)
                            .WithUnsupportedDiskType(DiskSkuTypes.PremiumLRS)
                            .WithRecommendedMaximumCPUsCountForVirtualMachine(25)
                            .WithRecommendedMaximumMemoryForVirtualMachine(3200)
                            // Options - End
                            .Create();

                    Assert.NotNull(galleryImage);
                    Assert.NotNull(galleryImage.Inner);
                    Assert.Equal(galleryImage.Location, region.ToString(), ignoreCase: true);
                    Assert.True(galleryImage.OSType.Equals(OperatingSystemTypes.Windows));
                    Assert.True(galleryImage.OSState.Equals(OperatingSystemStateTypes.Generalized));
                    Assert.Equal(2, galleryImage.UnsupportedDiskTypes.Count);
                    Assert.NotNull(galleryImage.Identifier);
                    Assert.Equal("JavaSDKTeam", galleryImage.Identifier.Publisher);
                    Assert.Equal("JDK", galleryImage.Identifier.Offer);
                    Assert.Equal("Jdk-9", galleryImage.Identifier.Sku);
                    Assert.NotNull(galleryImage.RecommendedVirtualMachineConfiguration);
                    Assert.NotNull(galleryImage.RecommendedVirtualMachineConfiguration.VCPUs);
                    Assert.NotNull(galleryImage.RecommendedVirtualMachineConfiguration.VCPUs.Max);
                    Assert.Equal(25, galleryImage.RecommendedVirtualMachineConfiguration.VCPUs.Max);
                    Assert.NotNull(galleryImage.RecommendedVirtualMachineConfiguration.Memory);
                    Assert.NotNull(galleryImage.RecommendedVirtualMachineConfiguration.Memory.Max);
                    Assert.Equal(3200, galleryImage.RecommendedVirtualMachineConfiguration.Memory.Max);
                    //
                    // Update an image in the gallery
                    //
                    galleryImage.Update()
                            .WithoutUnsupportedDiskType(DiskSkuTypes.PremiumLRS)
                            .WithRecommendedMinimumCPUsCountForVirtualMachine(15)
                            .WithRecommendedMemoryForVirtualMachine(2200, 3200)
                            .Apply();

                    Assert.Equal(1, galleryImage.UnsupportedDiskTypes.Count);
                    Assert.NotNull(galleryImage.RecommendedVirtualMachineConfiguration);
                    Assert.NotNull(galleryImage.RecommendedVirtualMachineConfiguration.VCPUs);
                    Assert.NotNull(galleryImage.RecommendedVirtualMachineConfiguration.VCPUs.Max);
                    Assert.Equal(25, galleryImage.RecommendedVirtualMachineConfiguration.VCPUs.Max);
                    Assert.NotNull(galleryImage.RecommendedVirtualMachineConfiguration.VCPUs.Min);
                    Assert.Equal(15, galleryImage.RecommendedVirtualMachineConfiguration.VCPUs.Min);
                    Assert.NotNull(galleryImage.RecommendedVirtualMachineConfiguration.Memory);
                    Assert.NotNull(galleryImage.RecommendedVirtualMachineConfiguration.Memory.Max);
                    Assert.Equal(3200, galleryImage.RecommendedVirtualMachineConfiguration.Memory.Max);
                    Assert.NotNull(galleryImage.RecommendedVirtualMachineConfiguration.Memory.Min);
                    Assert.Equal(2200, galleryImage.RecommendedVirtualMachineConfiguration.Memory.Min);
                    //
                    // List images in the gallery
                    //
                    IEnumerable<IGalleryImage> images = azure.GalleryImages.ListByGallery(rgName, galleryName);

                    Assert.Single(images);
                    //
                    // Get image from gallery
                    //
                    galleryImage = azure.GalleryImages.GetByGallery(rgName, galleryName, galleryImageName);

                    Assert.NotNull(galleryImage);
                    Assert.NotNull(galleryImage.Inner);
                    //
                    // Delete an image from gallery
                    //
                    azure.GalleryImages.DeleteByGallery(rgName, galleryName, galleryImageName);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateUpdateGetDeleteGalleryImageVersion()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                Region region = Region.USWestCentral;
                string rgName = TestUtilities.GenerateName("vmexttest");
                string galleryName = TestUtilities.GenerateName("jsim");
                string galleryImageName = "SampleImages";

                var azure = TestHelper.CreateRollupClient();

                try
                {

                    IGallery gallery = azure.Galleries.Define(galleryName)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgName)
                            .WithDescription("java's image gallery")
                            .Create();
                    //
                    // Create an image in the gallery (a container to hold custom linux image)
                    //

                    IGalleryImage galleryImage = azure.GalleryImages.Define(galleryImageName)
                            .WithExistingGallery(gallery)
                            .WithLocation(region)
                            .WithIdentifier("JavaSDKTeam", "JDK", "Jdk-9")
                            .WithGeneralizedLinux()
                            .Create();
                    //
                    // Create a custom image to base the version on
                    //
                    IVirtualMachineCustomImage customImage = PrepareCustomImage(rgName, region, azure);
                    // String customImageId = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/javacsmrg91482/providers/Microsoft.Compute/images/img96429090dee3";
                    //
                    // Create a image version based on the custom image
                    //

                    string versionName = "0.0.4";

                    IGalleryImageVersion imageVersion = azure.GalleryImageVersions.Define(versionName)
                            .WithExistingImage(rgName, gallery.Name, galleryImage.Name)
                            .WithLocation(region.ToString())
                            .WithSourceCustomImage(customImage)
                            // Options - Start
                            .WithRegionAvailability(Region.USEast2, 1)
                            // Options - End
                            .Create();

                    Assert.NotNull(imageVersion);
                    Assert.NotNull(imageVersion.Inner);
                    Assert.NotNull(imageVersion.PublishingProfile.TargetRegions);
                    Assert.Equal(2, imageVersion.PublishingProfile.TargetRegions.Count);
                    Assert.False(imageVersion.IsExcludedFromLatest);

                    imageVersion = azure.GalleryImageVersions.GetByGalleryImage(rgName, gallery.Name, galleryImage.Name, imageVersion.Name);
                    Assert.NotNull(imageVersion);
                    Assert.Null(imageVersion.ReplicationStatus);

                    imageVersion = azure.GalleryImageVersions.GetByGalleryImageWithReplicationStatus(rgName, gallery.Name, galleryImage.Name, imageVersion.Name);
                    Assert.NotNull(imageVersion);
                    Assert.NotNull(imageVersion.ReplicationStatus);
                    Assert.NotNull(imageVersion.ReplicationStatus.AggregatedState);

                    //
                    // Update image version
                    //
                    imageVersion.Update()
                            .WithoutRegionAvailability(Region.USEast2)
                            .Apply();

                    Assert.NotNull(imageVersion.PublishingProfile.TargetRegions);
                    Assert.Equal(1, imageVersion.PublishingProfile.TargetRegions.Count);
                    Assert.False(imageVersion.IsExcludedFromLatest);

                    //
                    // List image versions
                    //
                    IEnumerable<IGalleryImageVersion> versions = galleryImage.ListVersions();

                    Assert.NotNull(versions);
                    Assert.True(versions.Count() > 0);

                    //
                    // Delete the image version
                    //
                    azure.GalleryImageVersions.DeleteByGalleryImage(rgName, galleryName, galleryImageName, versionName);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        private IVirtualMachineCustomImage PrepareCustomImage(string rgName, Region region, IAzure azure)
        {
            string vmName = TestUtilities.GenerateName("muldvm");
            string uname = "javauser";
            string password = TestUtilities.GenerateName("Pa5$");
            KnownLinuxVirtualMachineImage linuxImage = KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts;
            string publicIpDnsLabel = TestUtilities.GenerateName("pip");
            string storageName = TestUtilities.GenerateName("stg");
            IVirtualMachine linuxVM = azure.VirtualMachines
                    .Define(vmName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(publicIpDnsLabel)
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
                        .WithNewStorageAccount(storageName)
                        .WithOSDiskCaching(CachingTypes.ReadWrite)
                        .Create();
            //
            TestHelper.DeprovisionAgentInLinuxVM(linuxVM.GetPrimaryPublicIPAddress().Fqdn, 22, uname, password);
            //
            linuxVM.Deallocate();
            linuxVM.Generalize();
            //
            string vhdBasedImageName = TestUtilities.GenerateName("img");
            //
            var creatableDisk = azure
                    .VirtualMachineCustomImages
                    .Define(vhdBasedImageName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithLinuxFromVhd(linuxVM.OSUnmanagedDiskVhdUri, OperatingSystemStateTypes.Generalized)
                        .WithOSDiskCaching(linuxVM.OSDiskCachingType);
            foreach (IVirtualMachineUnmanagedDataDisk disk in linuxVM.UnmanagedDataDisks.Values)
            {
                creatableDisk.DefineDataDiskImage()
                        .WithLun(disk.Lun)
                        .FromVhd(disk.VhdUri)
                        .WithDiskCaching(disk.CachingType)
                        .WithDiskSizeInGB(disk.Size + 10) // Resize each data disk image by +10GB
                        .Attach();
            }
            //
            IVirtualMachineCustomImage customImage = creatableDisk.Create();
            return customImage;
        }
    }
}
