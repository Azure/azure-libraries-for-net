// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilter.Definition;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilter.Update;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;

    internal partial class RouteFilterRuleImpl
    {
        /// <summary>
        /// Gets the access type of the rule.
        /// </summary>
        Models.Access Microsoft.Azure.Management.Network.Fluent.IRouteFilterRule.Access
        {
            get
            {
                return this.Access();
            }
        }

        /// <summary>
        /// Gets Set 'Allow' acces type of the rule.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the definition.
        /// </summary>
        RouteFilterRule.Definition.IWithAttach<RouteFilter.Definition.IWithCreate> RouteFilterRule.Definition.IWithAccessType<RouteFilter.Definition.IWithCreate>.AllowAccess
        {
            get
            {
                return this.AllowAccess();
            }
        }

        /// <summary>
        /// Gets Set 'Allow' acces type of the rule.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the definition.
        /// </summary>
        RouteFilterRule.Update.IUpdate RouteFilterRule.Update.IWithAccessType.AllowAccess
        {
            get
            {
                return this.AllowAccess();
            }
        }

        /// <summary>
        /// Gets The collection for bgp community values to filter on. e.g.
        /// ['12076:5010','12076:5020'].
        /// </summary>
        /// <summary>
        /// Gets collection of community values.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Network.Fluent.IRouteFilterRule.Communities
        {
            get
            {
                return this.Communities();
            }
        }

        /// <summary>
        /// Gets Set 'Deny' access type of the rule.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the definition.
        /// </summary>
        RouteFilterRule.Definition.IWithAttach<RouteFilter.Definition.IWithCreate> RouteFilterRule.Definition.IWithAccessType<RouteFilter.Definition.IWithCreate>.DenyAccess
        {
            get
            {
                return this.DenyAccess();
            }
        }

        /// <summary>
        /// Gets Set 'Deny' access type of the rule.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the definition.
        /// </summary>
        RouteFilterRule.Update.IUpdate RouteFilterRule.Update.IWithAccessType.DenyAccess
        {
            get
            {
                return this.DenyAccess();
            }
        }

        /// <summary>
        /// Gets resource location.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IRouteFilterRule.Location
        {
            get
            {
                return this.Location();
            }
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the provisioning state of the resource.
        /// </summary>
        ProvisioningState Microsoft.Azure.Management.Network.Fluent.IRouteFilterRule.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the rule type of the rule.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IRouteFilterRule.RouteFilterRuleType
        {
            get
            {
                return this.RouteFilterRuleType();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        RouteFilter.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<RouteFilter.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        RouteFilter.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<RouteFilter.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// The collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020']. Note: this method will overwrite existing communities.
        /// </summary>
        /// <param name="communities">Service communities.</param>
        /// <return>The next stage of the update.</return>
        RouteFilterRule.Update.IUpdate RouteFilterRule.Update.IWithBgpCommunities.WithBgpCommunities(params string[] communities)
        {
            return this.WithBgpCommunities(communities);
        }

        /// <summary>
        /// Set the collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020'].
        /// </summary>
        /// <param name="communities">Service communities.</param>
        /// <return>The next stage of the definition.</return>
        RouteFilterRule.Definition.IWithAttach<RouteFilter.Definition.IWithCreate> RouteFilterRule.Definition.IWithBgpCommunities<RouteFilter.Definition.IWithCreate>.WithBgpCommunities(params string[] communities)
        {
            return this.WithBgpCommunities(communities);
        }

        /// <summary>
        /// Set the collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020'].
        /// </summary>
        /// <param name="communities">Service communities.</param>
        /// <return>The next stage of the definition.</return>
        RouteFilterRule.UpdateDefinition.IWithAttach<RouteFilter.Update.IUpdate> RouteFilterRule.UpdateDefinition.IWithBgpCommunities<RouteFilter.Update.IUpdate>.WithBgpCommunities(params string[] communities)
        {
            return this.WithBgpCommunities(communities);
        }

        /// <summary>
        /// The bgp community values to filter on. e.g. '12076:5010'. This method has additive effect.
        /// </summary>
        /// <return>The next stage of the update.</return>
        RouteFilterRule.Update.IUpdate RouteFilterRule.Update.IWithBgpCommunities.WithBgpCommunity(string community)
        {
            return this.WithBgpCommunity(community);
        }

        /// <summary>
        /// Set bgp community value to filter on. e.g. '12076:5020'.
        /// </summary>
        /// <param name="community">Service community.</param>
        /// <return>The next stage of the definition.</return>
        RouteFilterRule.Definition.IWithAttach<RouteFilter.Definition.IWithCreate> RouteFilterRule.Definition.IWithBgpCommunities<RouteFilter.Definition.IWithCreate>.WithBgpCommunity(string community)
        {
            return this.WithBgpCommunity(community);
        }

        /// <summary>
        /// Set bgp community value to filter on. e.g. '12076:5020'.
        /// </summary>
        /// <param name="community">Service community.</param>
        /// <return>The next stage of the definition.</return>
        RouteFilterRule.UpdateDefinition.IWithAttach<RouteFilter.Update.IUpdate> RouteFilterRule.UpdateDefinition.IWithBgpCommunities<RouteFilter.Update.IUpdate>.WithBgpCommunity(string community)
        {
            return this.WithBgpCommunity(community);
        }

        /// <summary>
        /// Remove the bgp community value to filter on. e.g. '12076:5010'.
        /// </summary>
        /// <return>The next stage of the update.</return>
        RouteFilterRule.Update.IUpdate RouteFilterRule.Update.IWithBgpCommunities.WithoutBgpCommunity(string community)
        {
            return this.WithoutBgpCommunity(community);
        }

        /// <summary>
        /// Remove the bgp community value to filter on. e.g. '12076:5010'.
        /// </summary>
        /// <return>The next stage of the update.</return>
        RouteFilterRule.Update.IUpdate RouteFilterRule.Definition.IWithBgpCommunities<RouteFilter.Definition.IWithCreate>.WithoutBgpCommunity(string community)
        {
            return this.WithoutBgpCommunity(community);
        }

        /// <summary>
        /// Remove the bgp community value to filter on. e.g. '12076:5010'.
        /// </summary>
        /// <return>The next stage of the update.</return>
        RouteFilterRule.Update.IUpdate RouteFilterRule.UpdateDefinition.IWithBgpCommunities<RouteFilter.Update.IUpdate>.WithoutBgpCommunity(string community)
        {
            return this.WithoutBgpCommunity(community);
        }
    }
}