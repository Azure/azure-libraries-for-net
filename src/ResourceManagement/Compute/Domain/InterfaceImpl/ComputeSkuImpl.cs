// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal sealed partial class ComputeSkuImpl
    {
        /// <summary>
        /// Gets the api versions that this sku supports.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Compute.Fluent.IComputeSku.ApiVersions
        {
            get
            {
                return this.ApiVersions();
            }
        }

        /// <summary>
        /// Gets The availability set sku type if the sku describes sku for availability set resource type.
        /// The sku type can be used for  AvailabilitySet.DefinitionStages.WithSku.withSku(AvailabilitySetSkuTypes)
        /// and  AvailabilitySet.UpdateStages.WithSku.withSku(AvailabilitySetSkuTypes).
        /// </summary>
        /// <summary>
        /// Gets the availability set sku type.
        /// </summary>
        Models.AvailabilitySetSkuTypes Microsoft.Azure.Management.Compute.Fluent.IComputeSku.AvailabilitySetSkuType
        {
            get
            {
                return this.AvailabilitySetSkuType();
            }
        }

        /// <summary>
        /// Gets the capabilities of the sku.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ResourceSkuCapabilities> Microsoft.Azure.Management.Compute.Fluent.IComputeSku.Capabilities
        {
            get
            {
                return this.Capabilities();
            }
        }

        /// <summary>
        /// Gets the scaling information of the sku.
        /// </summary>
        Models.ResourceSkuCapacity Microsoft.Azure.Management.Compute.Fluent.IComputeSku.Capacity
        {
            get
            {
                return this.Capacity();
            }
        }

        /// <summary>
        /// Gets the metadata for querying the sku pricing information.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ResourceSkuCosts> Microsoft.Azure.Management.Compute.Fluent.IComputeSku.Costs
        {
            get
            {
                return this.Costs();
            }
        }

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
        Models.DiskSkuTypes Microsoft.Azure.Management.Compute.Fluent.IComputeSku.DiskSkuType
        {
            get
            {
                return this.DiskSkuType();
            }
        }

        /// <summary>
        /// Gets the sku name.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.ComputeSkuName Microsoft.Azure.Management.Compute.Fluent.IComputeSku.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the regions that the sku is available.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region> Microsoft.Azure.Management.Compute.Fluent.IComputeSku.Regions
        {
            get
            {
                return this.Regions();
            }
        }

        /// <summary>
        /// Gets the compute resource type that the sku describes.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.ComputeResourceType Microsoft.Azure.Management.Compute.Fluent.IComputeSku.ResourceType
        {
            get
            {
                return this.ResourceType();
            }
        }

        /// <summary>
        /// Gets the restrictions because of which SKU cannot be used.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ResourceSkuRestrictions> Microsoft.Azure.Management.Compute.Fluent.IComputeSku.Restrictions
        {
            get
            {
                return this.Restrictions();
            }
        }

        /// <summary>
        /// Gets the sku tier.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.ComputeSkuTier Microsoft.Azure.Management.Compute.Fluent.IComputeSku.Tier
        {
            get
            {
                return this.Tier();
            }
        }

        /// <summary>
        /// Gets The virtual machine size type if the sku describes sku for virtual machine resource type.
        /// The size can be used for  VirtualMachine.DefinitionStages.WithVMSize.withSize(VirtualMachineSizeTypes)
        /// and  VirtualMachine.Update.withSize(VirtualMachineSizeTypes).
        /// </summary>
        /// <summary>
        /// Gets the virtual machine size type.
        /// </summary>
        Models.VirtualMachineSizeTypes Microsoft.Azure.Management.Compute.Fluent.IComputeSku.VirtualMachineSizeType
        {
            get
            {
                return this.VirtualMachineSizeType();
            }
        }

        /// <summary>
        /// Gets the availability zones supported for this sku, index by region.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region, System.Collections.Generic.ISet<Microsoft.Azure.Management.ResourceManager.Fluent.Core.AvailabilityZoneId>> Microsoft.Azure.Management.Compute.Fluent.IComputeSku.Zones
        {
            get
            {
                return this.Zones();
            }
        }
    }
}