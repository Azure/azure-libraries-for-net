// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Type representing sku for an Azure compute resource.
    /// </summary>
    public interface IComputeSku :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ResourceSkuInner>
    {

        /// <summary>
        /// Gets the api versions that this sku supports.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> ApiVersions { get; }

        /// <summary>
        /// Gets The availability set sku type if the sku describes sku for availability set resource type.
        /// The sku type can be used for  AvailabilitySet.DefinitionStages.WithSku.withSku(AvailabilitySetSkuTypes)
        /// and  AvailabilitySet.UpdateStages.WithSku.withSku(AvailabilitySetSkuTypes).
        /// </summary>
        /// <summary>
        /// Gets the availability set sku type.
        /// </summary>
        Models.AvailabilitySetSkuTypes AvailabilitySetSkuType { get; }

        /// <summary>
        /// Gets the capabilities of the sku.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ResourceSkuCapabilities> Capabilities { get; }

        /// <summary>
        /// Gets the scaling information of the sku.
        /// </summary>
        Models.ResourceSkuCapacity Capacity { get; }

        /// <summary>
        /// Gets the metadata for querying the sku pricing information.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ResourceSkuCosts> Costs { get; }

        /// <summary>
        /// Gets The managed disk or snapshot sku type if the sku describes sku for disk or snapshot resource type.
        /// The sku type can be used for  Disk.DefinitionStages.WithSku.withSku(DiskSkuTypes),
        /// Disk.UpdateStages.WithSku.withSku(DiskSkuTypes),
        /// Snapshot.DefinitionStages.WithSku.withSku(DiskSkuTypes) and
        /// Snapshot.UpdateStages.WithSku.withSku(DiskSkuTypes).
        /// </summary>
        /// <summary>
        /// Gets the managed disk or snapshot sku type.
        /// </summary>
        Models.DiskSkuTypes DiskSkuType { get; }

        /// <summary>
        /// Gets the sku name.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.ComputeSkuName Name { get; }

        /// <summary>
        /// Gets the regions that the sku is available.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region> Regions { get; }

        /// <summary>
        /// Gets the compute resource type that the sku describes.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.ComputeResourceType ResourceType { get; }

        /// <summary>
        /// Gets the restrictions because of which SKU cannot be used.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ResourceSkuRestrictions> Restrictions { get; }

        /// <summary>
        /// Gets the sku tier.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.ComputeSkuTier Tier { get; }

        /// <summary>
        /// Gets The virtual machine size type if the sku describes sku for virtual machine resource type.
        /// The size can be used for  VirtualMachine.DefinitionStages.WithVMSize.withSize(VirtualMachineSizeTypes)
        /// and  VirtualMachine.Update.withSize(VirtualMachineSizeTypes).
        /// </summary>
        /// <summary>
        /// Gets the virtual machine size type.
        /// </summary>
        Models.VirtualMachineSizeTypes VirtualMachineSizeType { get; }

        /// <summary>
        /// Gets the availability zones supported for this sku, index by region.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region, System.Collections.Generic.ISet<Microsoft.Azure.Management.ResourceManager.Fluent.Core.AvailabilityZoneId>> Zones { get; }
    }
}