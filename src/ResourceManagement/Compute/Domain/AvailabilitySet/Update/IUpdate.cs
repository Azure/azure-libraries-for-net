// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;

    /// <summary>
    /// The template for an availability set update operation, containing all the settings that
    /// can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update.IUpdate>,
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update.IWithSku,
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update.IWithProximityPlacementGroup
    {

    }

    /// <summary>
    /// The stage of the availability set definition allowing to specify SKU.
    /// </summary>
    public interface IWithSku
    {

        /// <summary>
        /// Specifies the SKU type for the availability set.
        /// </summary>
        /// <param name="skuType">The SKU type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update.IUpdate WithSku(AvailabilitySetSkuTypes skuType);
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
        /// <returns>the next stage of the definition.</returns>
        IUpdate WithProximityPlacementGroup(string promixityPlacementGroupId);

        /// <summary>
        /// Remove the proximity placement group from the availability set.
        /// </summary>
        /// <returns>the next stage of the definition.</returns>
        IUpdate WithoutProximityPlacementGroup();
    }
}