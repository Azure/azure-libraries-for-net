// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilter.Definition;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilter.Update;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class RouteFilterImpl
    {
        /// <summary>
        /// Gets express route circuit peerings associated with this route filter, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering> Microsoft.Azure.Management.Network.Fluent.IRouteFilter.Peerings
        {
            get
            {
                return this.Peerings();
            }
        }

        /// <summary>
        /// Gets the provisioning state of the route filter resource.
        /// </summary>
        ProvisioningState Microsoft.Azure.Management.Network.Fluent.IRouteFilter.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets rules associated with this route filter, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IRouteFilterRule> Microsoft.Azure.Management.Network.Fluent.IRouteFilter.Rules
        {
            get
            {
                return this.Rules();
            }
        }

        /// <summary>
        /// Begins the definition of a new route filter rule to be added to this route filter.
        /// </summary>
        /// <param name="name">The name of the route filter rule.</param>
        /// <return>The first stage of the new route filter rule definition.</return>
        RouteFilterRule.UpdateDefinition.IBlank<RouteFilter.Update.IUpdate> RouteFilter.Update.IWithRule.DefineRule(string name)
        {
            return this.DefineRule(name);
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.IRouteFilter> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IRouteFilter>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken);
        }

        /// <summary>
        /// Begins the description of an update of an existing route filter rule of this route filter.
        /// </summary>
        /// <param name="name">The name of an existing route filter rule.</param>
        /// <return>The first stage of the route filter rule update description.</return>
        RouteFilterRule.Update.IUpdate RouteFilter.Update.IWithRule.UpdateRule(string name)
        {
            return this.UpdateRule(name);
        }

        /// <summary>
        /// Removes an route filter rule.
        /// </summary>
        /// <param name="name">The name of the route filter rule to remove.</param>
        /// <return>The next stage of the route filter update.</return>
        RouteFilter.Update.IUpdate RouteFilter.Update.IWithRule.WithoutRule(string name)
        {
            return this.WithoutRule(name);
        }
    }
}