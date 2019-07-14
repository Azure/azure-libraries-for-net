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

        IProximityPlacementGroup IAvailabilitySet.ProximityPlacementGroup
        {
            get
            {
                return this.ProximityPlacementGroup();
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

        /// <summary>
        /// Set information about the proximity placement group that the availability set should
        /// be assigned to.
        /// </summary>
        /// <param name="promixityPlacementGroupId">The Id of the proximity placement group subResource.</param>
        /// <returns>the next stage of the definition</returns>

        AvailabilitySet.Definition.IWithCreate AvailabilitySet.Definition.IWithProximityPlacementGroup.WithProximityPlacementGroup(string promixityPlacementGroupId)
        {
            return this.WithProximityPlacementGroup(promixityPlacementGroupId);
        }

        /// <summary>
        /// Creates a new proximity placement gruup with the specified name and then adds it to the availability set.
        /// </summary>
        /// <param name="proximityPlacementGroupName">the name of the group to be created.</param>
        /// <param name="type">the type of the group</param>
        /// <returns>the next stage of the definition.</returns>
        AvailabilitySet.Definition.IWithCreate AvailabilitySet.Definition.IWithProximityPlacementGroup.WithNewProximityPlacementGroup(string proximityPlacementGroupName, ProximityPlacementGroupType type)
        {
            return this.WithNewProximityPlacementGroup(proximityPlacementGroupName, type);
        }

        /// <summary>
        /// Set information about the proximity placement group that the availability set should
        /// be assigned to.
        /// </summary>
        /// <param name="promixityPlacementGroupId">The Id of the proximity placement group subResource.</param>
        /// <returns>the next stage of the definition.</returns>
        AvailabilitySet.Update.IUpdate AvailabilitySet.Update.IWithProximityPlacementGroup.WithProximityPlacementGroup(string promixityPlacementGroupId)
        {
            return this.WithProximityPlacementGroup(promixityPlacementGroupId);
        }

        /// <summary>
        /// Remove the proximity placement group from the availability set.
        /// </summary>
        /// <returns>the next stage of the definition.</returns>
        AvailabilitySet.Update.IUpdate AvailabilitySet.Update.IWithProximityPlacementGroup.WithoutProximityPlacementGroup()
        {
            return this.WithoutProximityPlacementGroup();
        }
    }
}