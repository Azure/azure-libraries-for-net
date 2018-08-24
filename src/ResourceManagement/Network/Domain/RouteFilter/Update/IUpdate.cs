// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.RouteFilter.Update
{
    /// <summary>
    /// The stage of the resource update allowing to add or remove route filter rules.
    /// </summary>
    public interface IWithRule 
    {

        /// <summary>
        /// Begins the definition of a new route filter rule to be added to this route filter.
        /// </summary>
        /// <param name="name">The name of the route filter rule.</param>
        /// <return>The first stage of the new route filter rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.RouteFilter.Update.IUpdate> DefineRule(string name);

        /// <summary>
        /// Begins the description of an update of an existing route filter rule of this route filter.
        /// </summary>
        /// <param name="name">The name of an existing route filter rule.</param>
        /// <return>The first stage of the route filter rule update description.</return>
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Update.IUpdate UpdateRule(string name);

        /// <summary>
        /// Removes an route filter rule.
        /// </summary>
        /// <param name="name">The name of the route filter rule to remove.</param>
        /// <return>The next stage of the route filter update.</return>
        Microsoft.Azure.Management.Network.Fluent.RouteFilter.Update.IUpdate WithoutRule(string name);
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that
    /// can be modified.
    /// Call  Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.IRouteFilter>,
        Microsoft.Azure.Management.Network.Fluent.RouteFilter.Update.IWithRule,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.RouteFilter.Update.IUpdate>
    {

    }
}