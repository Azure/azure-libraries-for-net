// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Fluent.Tests.Compute
{
    public class ManagedDiskOperations
    {
        private readonly string Location = Region.USWestCentral.Name;

        [Fact]
        public void CanOperateOnEmptyManagedDisk()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var diskName = SdkContext.RandomResourceName("md-empty-", 20);
                var updateTo = DiskSkuTypes.StandardLRS;
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");

                try
                {
                    var resourceGroup = resourceManager
                            .ResourceGroups
                            .Define(rgName)
                            .WithRegion(Location)
                            .Create();

                    // Create an empty managed disk
                    //
                    var disk = computeManager.Disks
                            .Define(diskName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup.Name)
                            .WithData()
                            .WithSizeInGB(100)
                            // Start option
                            .WithSku(DiskSkuTypes.StandardLRS)
                            .WithTag("tkey1", "tval1")
                            // End option
                            .Create();

                    Assert.NotNull(disk.Id);
                    Assert.Equal(disk.Name, diskName, ignoreCase: true);
                    Assert.True(disk.Sku == DiskSkuTypes.StandardLRS);
                    Assert.Equal(DiskCreateOption.Empty, disk.CreationMethod);
                    Assert.False(disk.IsAttachedToVirtualMachine);
                    Assert.Equal(100, disk.SizeInGB);
                    Assert.Null(disk.OSType);
                    Assert.NotNull(disk.Source);
                    Assert.Equal(CreationSourceType.Empty, disk.Source.Type);
                    Assert.Null(disk.Source.SourceId());

                    // Resize and change storage account type
                    //
                    disk = disk.Update()
                            .WithSku(updateTo)
                            .WithSizeInGB(200)
                            .Apply();

                    Assert.Equal(disk.Sku, updateTo);
                    Assert.Equal(200, disk.SizeInGB);

                    disk = computeManager.Disks.GetByResourceGroup(disk.ResourceGroupName, disk.Name);
                    Assert.NotNull(disk);

                    var myDisks = computeManager.Disks.ListByResourceGroup(disk.ResourceGroupName);
                    Assert.NotNull(myDisks);
                    Assert.True(myDisks.Count() > 0);

                    var sasUrl = disk.GrantAccess(100);
                    Assert.True(sasUrl != null && sasUrl != "");

                    // Requires access to be revoked before deleting the disk
                    //
                    disk.RevokeAccess();
                    computeManager.Disks.DeleteById(disk.Id);

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
        public void CanOperateOnManagedDiskFromDisk()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var diskName1 = SdkContext.RandomResourceName("md-1", 20);
                var diskName2 = SdkContext.RandomResourceName("md-2", 20);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");

                try
                {
                    var resourceGroup = resourceManager
                            .ResourceGroups
                            .Define(rgName)
                            .WithRegion(Location)
                            .Create();

                    // Create an empty  managed disk
                    //
                    var emptyDisk = computeManager.Disks
                            .Define(diskName1)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup.Name)
                            .WithData()
                            .WithSizeInGB(100)
                            .Create();

                    // Create a managed disk from existing managed disk
                    //
                    var disk = computeManager.Disks
                            .Define(diskName2)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup.Name)
                            .WithData()
                            .FromDisk(emptyDisk)
                            // Start Option
                            .WithSizeInGB(200)
                            .WithSku(DiskSkuTypes.StandardLRS)
                            .WithHyperVGeneration(HyperVGeneration.V1)
                            // End Option
                            .Create();

                    disk = computeManager.Disks.GetById(disk.Id);
                    Assert.Equal(HyperVGeneration.V1, disk.HyperVGeneration);

                    disk.Update()
                        .WithHyperVGeneration(HyperVGeneration.V2)
                        .Apply();

                    disk.Refresh();

                    Assert.NotNull(disk.Id);
                    Assert.Equal(disk.Name, diskName2, ignoreCase: true);
                    Assert.True(disk.Sku == DiskSkuTypes.StandardLRS);
                    Assert.Equal(DiskCreateOption.Copy, disk.CreationMethod);
                    Assert.False(disk.IsAttachedToVirtualMachine);
                    Assert.Equal(200, disk.SizeInGB);
                    Assert.Null(disk.OSType);
                    Assert.Equal(HyperVGeneration.V2, disk.HyperVGeneration);
                    Assert.NotNull(disk.Source);
                    Assert.Equal(CreationSourceType.CopiedFromDisk, disk.Source.Type);
                    Assert.Equal(disk.Source.SourceId(), emptyDisk.Id, ignoreCase: true);

                    computeManager.Disks.DeleteById(emptyDisk.Id);
                    computeManager.Disks.DeleteById(disk.Id);
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
        public void CanOperateOnManagedDiskFromUpload()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var diskName1 = SdkContext.RandomResourceName("md-1", 20);
                var diskName2 = SdkContext.RandomResourceName("md-2", 20);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");

                try
                {
                    var resourceGroup = resourceManager
                            .ResourceGroups
                            .Define(rgName)
                            .WithRegion(Location)
                            .Create();


                    // Create a managed disk from existing managed disk
                    //
                    var disk = computeManager.Disks
                            .Define(diskName2)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup.Name)
                            .WithData()
                            .WithUploadSizeInMB(1024)
                            // Start Option
                            .WithSku(DiskSkuTypes.StandardLRS)
                            // End Option
                            .Create();

                    disk = computeManager.Disks.GetById(disk.Id);

                    Assert.NotNull(disk.Id);
                    Assert.Equal(disk.Name, diskName2, ignoreCase: true);
                    Assert.True(disk.Sku == DiskSkuTypes.StandardLRS);
                    Assert.Equal(DiskCreateOption.Upload, disk.CreationMethod);
                    Assert.False(disk.IsAttachedToVirtualMachine);
                    Assert.Equal(0, disk.SizeInByte);
                    Assert.Null(disk.OSType);
                    Assert.Equal(CreationSourceType.Unknown, disk.Source.Type);
                    computeManager.Disks.DeleteById(disk.Id);
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
        public void CanOperateOnManagedDiskFromSnapshot()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var emptyDiskName = SdkContext.RandomResourceName("md-empty-", 20);
                var snapshotBasedDiskName = SdkContext.RandomResourceName("md-snp-", 20);
                var snapshotName1 = SdkContext.RandomResourceName("snp-", 20);
                var snapshotName2 = SdkContext.RandomResourceName("snp-", 20);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");

                try
                {
                    var resourceGroup = resourceManager
                            .ResourceGroups
                            .Define(rgName)
                            .WithRegion(Location)
                            .Create();

                    var emptyDisk = computeManager.Disks
                            .Define(emptyDiskName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithData()
                            .WithSizeInGB(100)
                            .Create();

                    var snapshot = computeManager.Snapshots
                            .Define(snapshotName1)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithDataFromDisk(emptyDisk)
                            .WithSizeInGB(200)
                            .WithSku(DiskSkuTypes.StandardLRS)
                            .Create();



                    Assert.NotNull(snapshot.Id);
                    Assert.Equal(snapshotName1, snapshot.Name, true);
                    Assert.Equal(DiskSkuTypes.StandardLRS, snapshot.Sku);
                    Assert.Equal(DiskCreateOption.Copy, snapshot.CreationMethod);
                    Assert.Equal(200, snapshot.SizeInGB);
                    Assert.Equal(false, snapshot.Incremental);
                    Assert.Null(snapshot.OSType);
                    Assert.NotNull(snapshot.Source);
                    Assert.Equal(CreationSourceType.CopiedFromDisk, snapshot.Source.Type);
                    Assert.Equal(emptyDisk.Id, snapshot.Source.SourceId(), true);
                    var fromSnapshotDisk = computeManager.Disks
                            .Define(snapshotBasedDiskName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithData()
                            .FromSnapshot(snapshot)
                            .WithSizeInGB(300)
                            .Create();

                    Assert.NotNull(fromSnapshotDisk.Id);
                    Assert.Equal(snapshotBasedDiskName, fromSnapshotDisk.Name, true);
                    Assert.Equal(DiskSkuTypes.StandardLRS, fromSnapshotDisk.Sku);
                    Assert.Equal(DiskCreateOption.Copy, fromSnapshotDisk.CreationMethod);
                    Assert.Equal(300, fromSnapshotDisk.SizeInGB);
                    Assert.Null(fromSnapshotDisk.OSType);
                    Assert.NotNull(fromSnapshotDisk.Source);
                    Assert.Equal(CreationSourceType.CopiedFromSnapshot, fromSnapshotDisk.Source.Type);
                    Assert.Equal(snapshot.Id, fromSnapshotDisk.Source.SourceId(), true);

                    snapshot = computeManager.Snapshots
                         .Define(snapshotName2)
                         .WithRegion(Location)
                         .WithExistingResourceGroup(resourceGroup)
                         .WithDataFromDisk(emptyDisk)
                         .WithSizeInGB(100)
                         .WithIncremental(true)
                         .Create();

                    Assert.NotNull(snapshot.Id);
                    Assert.Equal(snapshotName2, snapshot.Name, true);
                    Assert.Equal(DiskSkuTypes.StandardLRS, snapshot.Sku);
                    Assert.Equal(DiskCreateOption.Copy, snapshot.CreationMethod);
                    Assert.Equal(100, snapshot.SizeInGB);
                    Assert.Equal(true, snapshot.Incremental);
                    Assert.Null(snapshot.OSType);
                    Assert.NotNull(snapshot.Source);
                    Assert.Equal(CreationSourceType.CopiedFromDisk, snapshot.Source.Type);
                    Assert.Equal(emptyDisk.Id, snapshot.Source.SourceId(), true);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }
    }
}
