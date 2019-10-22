// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Route.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Route.Update;
    using Microsoft.Azure.Management.Network.Fluent.Route.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.RouteTable.Definition;
    using Microsoft.Azure.Management.Network.Fluent.RouteTable.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class RouteTableImpl
    {
        /// <summary>
        /// Gets whether to disable the routes learned by BGP on that route
        /// table. True means disable.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IRouteTableBeta.IsBgpRoutePropagationDisabled
        {
            get
            {
                return this.IsBgpRoutePropagationDisabled();
            }
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.IRouteTable> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IRouteTable>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the routes of this route table.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IRoute> Microsoft.Azure.Management.Network.Fluent.IRouteTable.Routes
        {
            get
            {
                return this.Routes();
            }
        }

        /// <return>List of subnets associated with this resource.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Network.Fluent.ISubnet> Microsoft.Azure.Management.Network.Fluent.IHasAssociatedSubnets.ListAssociatedSubnets()
        {
            return this.ListAssociatedSubnets();
        }

        /// <summary>
        /// Disable the routes learned by BGP on that route table.
        /// </summary>
        /// <return>The next stage of the update.</return>
        RouteTable.Update.IUpdate RouteTable.Update.IWithBgpRoutePropagation.WithDisableBgpRoutePropagation()
        {
            return this.WithDisableBgpRoutePropagation();
        }

        /// <summary>
        /// Disable the routes learned by BGP on that route table.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        RouteTable.Definition.IWithCreate RouteTable.Definition.IWithBgpRoutePropagation.WithDisableBgpRoutePropagation()
        {
            return this.WithDisableBgpRoutePropagation();
        }

        /// <summary>
        /// Enable the routes learned by BGP on that route table.
        /// </summary>
        /// <return>The next stage of the update.</return>
        RouteTable.Update.IUpdate RouteTable.Update.IWithBgpRoutePropagation.WithEnableBgpRoutePropagation()
        {
            return this.WithEnableBgpRoutePropagation();
        }

        /// <summary>
        /// Creates a non-virtual appliance route.
        /// The name is generated automatically.
        /// </summary>
        /// <param name="destinationAddressPrefix">The destination address prefix, expressed in the CIDR notation, for the route to apply to.</param>
        /// <param name="nextHop">The next hop type.</param>
        /// <return>The next stage of the update.</return>
        RouteTable.Update.IUpdate RouteTable.Update.IWithRoute.WithRoute(string destinationAddressPrefix, RouteNextHopType nextHop)
        {
            return this.WithRoute(destinationAddressPrefix, nextHop);
        }

        /// <summary>
        /// Creates a route via a virtual appliance.
        /// </summary>
        /// <param name="destinationAddressPrefix">The destination address prefix, expressed in the CIDR notation, for the route to apply to.</param>
        /// <param name="ipAddress">The IP address of the virtual appliance to route the traffic through.</param>
        /// <return>The next stage of the update.</return>
        RouteTable.Update.IUpdate RouteTable.Update.IWithRoute.WithRouteViaVirtualAppliance(string destinationAddressPrefix, string ipAddress)
        {
            return this.WithRouteViaVirtualAppliance(destinationAddressPrefix, ipAddress);
        }

        /// <summary>
        /// Removes the specified route from the route table.
        /// </summary>
        /// <param name="name">The name of an existing route on this route table.</param>
        /// <return>The next stage of the update.</return>
        RouteTable.Update.IUpdate RouteTable.Update.IWithRoute.WithoutRoute(string name)
        {
            return this.WithoutRoute(name);
        }

        /// <summary>
        /// Begins the update of an existing route on this route table.
        /// </summary>
        /// <param name="name">The name of an existing route.</param>
        /// <return>The first stage of the update.</return>
        Route.Update.IUpdate RouteTable.Update.IWithRoute.UpdateRoute(string name)
        {
            return this.UpdateRoute(name);
        }

        /// <summary>
        /// Begins the definition of a new route to add to the route table.
        /// The definition must be completed with a call to  Route.UpdateDefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the route.</param>
        /// <return>The first stage of the definition.</return>
        Route.UpdateDefinition.IBlank<RouteTable.Update.IUpdate> RouteTable.Update.IWithRoute.DefineRoute(string name)
        {
            return this.DefineRoute(name);
        }

        /// <summary>
        /// Creates a non-virtual appliance route.
        /// The name is generated automatically.
        /// </summary>
        /// <param name="destinationAddressPrefix">The destination address prefix, expressed in the CIDR notation, for the route to apply to.</param>
        /// <param name="nextHop">The next hop type.</param>
        /// <return>The next stage of the definition.</return>
        RouteTable.Definition.IWithCreate RouteTable.Definition.IWithRoute.WithRoute(string destinationAddressPrefix, RouteNextHopType nextHop)
        {
            return this.WithRoute(destinationAddressPrefix, nextHop);
        }

        /// <summary>
        /// Creates a route via a virtual appliance.
        /// </summary>
        /// <param name="destinationAddressPrefix">The destination address prefix, expressed in the CIDR notation, for the route to apply to.</param>
        /// <param name="ipAddress">The IP address of the virtual appliance to route the traffic through.</param>
        /// <return>The next stage of the definition.</return>
        RouteTable.Definition.IWithCreate RouteTable.Definition.IWithRoute.WithRouteViaVirtualAppliance(string destinationAddressPrefix, string ipAddress)
        {
            return this.WithRouteViaVirtualAppliance(destinationAddressPrefix, ipAddress);
        }

        /// <summary>
        /// Begins the definition of a new route to add to the route table.
        /// The definition must be completed with a call to  Route.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the route.</param>
        /// <return>The first stage of the definition.</return>
        Route.Definition.IBlank<RouteTable.Definition.IWithCreate> RouteTable.Definition.IWithRoute.DefineRoute(string name)
        {
            return this.DefineRoute(name);
        }
    }
}