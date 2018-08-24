// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Update
{
    /// <summary>
    /// The entirety of a route filter rule update as part of a route filter group update.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Update.IWithBgpCommunities,
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Update.IWithAccessType,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.RouteFilter.Update.IUpdate>
    {

    }

    /// <summary>
    /// The stage of the route filter rule definition allowing access type of the rule.
    /// </summary>
    public interface IWithAccessType 
    {

        /// <summary>
        /// Gets Set 'Allow' acces type of the rule.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the definition.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Update.IUpdate AllowAccess { get; }

        /// <summary>
        /// Gets Set 'Deny' access type of the rule.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the definition.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Update.IUpdate DenyAccess { get; }
    }

    /// <summary>
    /// The stage of the route filter rule description allowing bgp service communities to be specified.
    /// </summary>
    public interface IWithBgpCommunities 
    {

        /// <summary>
        /// The collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020']. Note: this method will overwrite existing communities.
        /// </summary>
        /// <param name="communities">Service communities.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Update.IUpdate WithBgpCommunities(params string[] communities);

        /// <summary>
        /// The bgp community values to filter on. e.g. '12076:5010'. This method has additive effect.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Update.IUpdate WithBgpCommunity(string community);

        /// <summary>
        /// Remove the bgp community value to filter on. e.g. '12076:5010'.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Update.IUpdate WithoutBgpCommunity(string community);
    }
}