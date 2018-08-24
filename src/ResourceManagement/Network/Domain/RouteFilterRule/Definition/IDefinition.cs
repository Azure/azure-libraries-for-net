// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Definition
{
    /// <summary>
    /// The first stage of a route filter rule definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Definition.IWithBgpCommunities<ParentT>
    {

    }

    /// <summary>
    /// The final stage of the route filter rule definition.
    /// At this stage, any remaining optional settings can be specified, or the route filter rule definition
    /// can be attached to the parent route filter group definition using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Definition.IWithAccessType<ParentT>
    {

    }

    /// <summary>
    /// The entirety of a route filter rule definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Definition.IWithBgpCommunities<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Definition.IWithAttach<ParentT>
    {

    }

    /// <summary>
    /// The stage of the route filter rule definition allowing bgp service communities to be specified.
    /// </summary>
    public interface IWithBgpCommunities<ParentT> 
    {

        /// <summary>
        /// Set the collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020'].
        /// </summary>
        /// <param name="communities">Service communities.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Definition.IWithAttach<ParentT> WithBgpCommunities(params string[] communities);

        /// <summary>
        /// Set bgp community value to filter on. e.g. '12076:5020'.
        /// </summary>
        /// <param name="community">Service community.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Definition.IWithAttach<ParentT> WithBgpCommunity(string community);

        /// <summary>
        /// Remove the bgp community value to filter on. e.g. '12076:5010'.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Update.IUpdate WithoutBgpCommunity(string community);
    }

    /// <summary>
    /// The stage of the route filter rule definition allowing access type of the rule.
    /// </summary>
    public interface IWithAccessType<ParentT> 
    {

        /// <summary>
        /// Gets Set 'Allow' acces type of the rule.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the definition.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Definition.IWithAttach<ParentT> AllowAccess { get; }

        /// <summary>
        /// Gets Set 'Deny' access type of the rule.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the definition.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Definition.IWithAttach<ParentT> DenyAccess { get; }
    }
}