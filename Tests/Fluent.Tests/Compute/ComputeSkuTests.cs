// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Xunit;

namespace Fluent.Tests.Compute
{
    public class Sku
    {
        [Fact]
        public void CanList()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                var skus = azure.ComputeSkus.List();

                bool atleastOneVirtualMachineResourceSku = false;
                bool atleastOneAvailabilitySetResourceSku = false;
                bool atleastOneDiskResourceSku = false;
                bool atleastOneSnapshotResourceSku = false;
                bool atleastOneRegionWithZones = false;
                foreach (IComputeSku sku in skus)
                {
                    Assert.NotNull(sku.ResourceType);
                    Assert.NotNull(sku.Regions);
                    if (sku.ResourceType.Equals(ComputeResourceType.VirtualMachines))
                    {
                        Assert.NotNull(sku.VirtualMachineSizeType);
                        Assert.Equal(sku.VirtualMachineSizeType.ToString().ToLowerInvariant(), sku.Name.ToString().ToLowerInvariant());
                        Assert.Null(sku.AvailabilitySetSkuType);
                        Assert.Null(sku.DiskSkuType);
                        atleastOneVirtualMachineResourceSku = true;

                        foreach (var zoneMapEntry in sku.Zones)
                        {
                            var region = zoneMapEntry.Key;
                            Assert.NotNull(region);
                            var zones = zoneMapEntry.Value;
                            if (zones.Count > 0)
                            {
                                atleastOneRegionWithZones = true;
                            }
                        }
                    }
                    if (sku.ResourceType.Equals(ComputeResourceType.AvailabilitySets))
                    {
                        Assert.NotNull(sku.AvailabilitySetSkuType);
                        Assert.Equal(sku.AvailabilitySetSkuType.ToString().ToLowerInvariant(), sku.Name.ToString().ToLowerInvariant());
                        Assert.Null(sku.VirtualMachineSizeType);
                        Assert.Null(sku.DiskSkuType);
                        atleastOneAvailabilitySetResourceSku = true;
                    }
                    if (sku.ResourceType.Equals(ComputeResourceType.Disks))
                    {
                        // Below check is disabled explicitly because due to the special permission of test subscription it can
                        // see disk sku types which are not documented in swagger
                        //
                        // Assert.NotNull(sku.DiskSkuType.ToString());
                        if (sku.DiskSkuType != null)
                        {
                            Assert.Equal(sku.DiskSkuType.ToString().ToLowerInvariant(), sku.Name.ToString().ToLowerInvariant());
                        }
                        Assert.Null(sku.VirtualMachineSizeType);
                        Assert.Null(sku.AvailabilitySetSkuType);
                        atleastOneDiskResourceSku = true;
                    }
                    if (sku.ResourceType.Equals(ComputeResourceType.Snapshots))
                    {
                        // Below check is disabled explicitly because due to the special permission of test subscription it can
                        // see sku types which are not documented in swagger
                        //
                        // Assert.NotNull(sku.DiskSkuType);
                        if (sku.DiskSkuType != null)
                        {
                            Assert.Equal(sku.DiskSkuType.ToString().ToLowerInvariant(), sku.Name.ToString().ToLowerInvariant());
                        }
                        Assert.Null(sku.VirtualMachineSizeType);
                        Assert.Null(sku.AvailabilitySetSkuType);
                        atleastOneSnapshotResourceSku = true;
                    }
                }
                Assert.True(atleastOneVirtualMachineResourceSku);
                Assert.True(atleastOneAvailabilitySetResourceSku);
                Assert.True(atleastOneDiskResourceSku);
                Assert.True(atleastOneSnapshotResourceSku);
                Assert.True(atleastOneRegionWithZones);
            }
        }

        [Fact]
        public void CanListByRegion()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                var skus = azure.ComputeSkus.ListByRegion(Region.USEast2);
                foreach (IComputeSku sku in skus)
                {
                    Assert.Contains(Region.USEast2, sku.Regions);
                }

                skus = azure.ComputeSkus.ListByRegion(Region.Create("Unknown"));
                Assert.NotNull(skus);
                Assert.Empty(skus);
            }
        }

        [Fact]
        public void CanListByResourceType()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                var skus = azure.ComputeSkus.ListByResourceType(ComputeResourceType.VirtualMachines);
                foreach (var sku in skus)
                {
                    Assert.True(sku.ResourceType.Equals(ComputeResourceType.VirtualMachines));
                }

                skus = azure.ComputeSkus.ListByResourceType(ComputeResourceType.Parse("Unknown"));
                Assert.NotNull(skus);
                Assert.Empty(skus);
            }
        }

        [Fact]
        public void CanListByRegionAndResourceType()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                var skus = azure.ComputeSkus.ListbyRegionAndResourceType(Region.USEast2, ComputeResourceType.VirtualMachines);
                foreach (var sku in skus)
                {
                    Assert.True(sku.ResourceType.Equals(ComputeResourceType.VirtualMachines));
                    Assert.Contains(Region.USEast2, sku.Regions);
                }

                skus = azure.ComputeSkus.ListbyRegionAndResourceType(Region.USEast2, ComputeResourceType.Parse("unknown"));
                Assert.NotNull(skus);
                Assert.Empty(skus);
            }
        }
    }
}
