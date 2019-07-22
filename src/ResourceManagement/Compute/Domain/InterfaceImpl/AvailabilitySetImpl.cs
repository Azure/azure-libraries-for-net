// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class AvailabilitySetImpl
    {
        /// <summary>
        /// Gets the fault domain count of this availability set.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet.FaultDomainCount
        {
            get
            {
                return this.FaultDomainCount();
            }
        }

        /// <summary>
        /// Gets the availability set SKU.
        /// </summary>
        Models.AvailabilitySetSkuTypes Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet.Sku
        {
            get
            {
                return this.Sku();
            }
        }

        /// <summary>
        /// Gets the statuses of the existing virtual machines in the availability set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.InstanceViewStatus> Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet.Statuses
        {
            get
            {
                return this.Statuses();
            }
        }

        /// <summary>
        /// Gets the update domain count of this availability set.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet.UpdateDomainCount
        {
            get
            {
                return this.UpdateDomainCount();
            }
        }

        /// <summary>
        /// Gets the resource IDs of the virtual machines in the availability set.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet.VirtualMachineIds
        {
            get
            {
                return this.VirtualMachineIds();
            }
        }

        /// <return>The virtual machine sizes supported in the availability set.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize> Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet.ListVirtualMachineSizes()
        {
            return this.ListVirtualMachineSizes();
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken);
        }

        /// <summary>
        /// Specifies the fault domain count for the availability set.
        /// </summary>
        /// <param name="faultDomainCount">The fault domain count.</param>
        /// <return>The next stage of the definition.</return>
        AvailabilitySet.Definition.IWithCreate AvailabilitySet.Definition.IWithFaultDomainCount.WithFaultDomainCount(int faultDomainCount)
        {
            return this.WithFaultDomainCount(faultDomainCount);
        }

        /// <summary>
        /// Specifies the SKU type for the availability set.
        /// </summary>
        /// <param name="skuType">The SKU type.</param>
        /// <return>The next stage of the definition.</return>
        AvailabilitySet.Update.IUpdate AvailabilitySet.Update.IWithSku.WithSku(AvailabilitySetSkuTypes skuType)
        {
            return this.WithSku(skuType);
        }

        /// <summary>
        /// Specifies the SKU type for the availability set.
        /// </summary>
        /// <param name="skuType">The sku type.</param>
        /// <return>The next stage of the definition.</return>
        AvailabilitySet.Definition.IWithCreate AvailabilitySet.Definition.IWithSku.WithSku(AvailabilitySetSkuTypes skuType)
        {
            return this.WithSku(skuType);
        }

        /// <summary>
        /// Specifies the update domain count for the availability set.
        /// </summary>
        /// <param name="updateDomainCount">Update domain count.</param>
        /// <return>The next stage of the definition.</return>
        AvailabilitySet.Definition.IWithCreate AvailabilitySet.Definition.IWithUpdateDomainCount.WithUpdateDomainCount(int updateDomainCount)
        {
            return this.WithUpdateDomainCount(updateDomainCount);
        }
    }
}