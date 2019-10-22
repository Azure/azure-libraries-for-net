// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;

    /// <summary>
    /// Container interface for all the definitions related to an availability set.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IBlank,
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithGroup,
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithCreate
    {

    }

    /// <summary>
    /// The stage of the availability set definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithCreate>
    {

    }

    /// <summary>
    /// The stage of the availability set definition allowing to specify the fault domain count.
    /// </summary>
    public interface IWithFaultDomainCount
    {

        /// <summary>
        /// Specifies the fault domain count for the availability set.
        /// </summary>
        /// <param name="faultDomainCount">The fault domain count.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithCreate WithFaultDomainCount(int faultDomainCount);
    }

    /// <summary>
    /// The first stage of an availability set definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithGroup>
    {

    }

    /// <summary>
    /// The stage of the availability set definition allowing enable or disable for managed disk.
    /// </summary>
    public interface IWithSku
    {

        /// <summary>
        /// Specifies the SKU type for the availability set.
        /// </summary>
        /// <param name="skuType">The sku type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithCreate WithSku(AvailabilitySetSkuTypes skuType);
    }

    /// <summary>
    /// The stage of the availability set definition setting ProximityPlacementGroup.
    /// </summary>
    public interface IWithProximityPlacementGroup
    {
        /// <summary>
        /// Set information about the proximity placement group that the availability set should
        /// be assigned to.
        /// </summary>
        /// <param name="promixityPlacementGroupId">The Id of the proximity placement group subResource.</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithCreate WithProximityPlacementGroup(string promixityPlacementGroupId);


        /// <summary>
        /// Creates a new proximity placement gruup with the specified name and then adds it to the availability set.
        /// </summary>
        /// <param name="proximityPlacementGroupName">the name of the group to be created.</param>
        /// <param name="type">the type of the group</param>
        /// <returns>the next stage of the definition.</returns>
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithCreate WithNewProximityPlacementGroup(string proximityPlacementGroupName, ProximityPlacementGroupType type);
    }

    /// <summary>
    /// The stage of the availability set definition allowing to specify the update domain count.
    /// </summary>
    public interface IWithUpdateDomainCount
    {

        /// <summary>
        /// Specifies the update domain count for the availability set.
        /// </summary>
        /// <param name="updateDomainCount">Update domain count.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithCreate WithUpdateDomainCount(int updateDomainCount);
    }

    /// <summary>
    /// The stage of an availability set definition which contains all the minimum required inputs for
    /// the resource to be created but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithCreate>,
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithUpdateDomainCount,
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithFaultDomainCount,
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithSku,
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithProximityPlacementGroup
    {

    }
}