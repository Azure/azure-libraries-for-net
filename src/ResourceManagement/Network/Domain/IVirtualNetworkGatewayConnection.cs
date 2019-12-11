// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Client-side representation of Virtual Network Gateway Connection object, associated with Virtual Network Gateway.
    /// </summary>
    public interface IVirtualNetworkGatewayConnection :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IIndependentChildResource<Microsoft.Azure.Management.Network.Fluent.INetworkManager, Models.VirtualNetworkGatewayConnectionInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<VirtualNetworkGatewayConnection.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.IUpdatableWithTags<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway>
    {
        /// <summary>
        /// Gets the reference to local network gateway resource.
        /// </summary>
        string LocalNetworkGateway2Id { get; }

        /// <summary>
        /// Gets the IPSec shared key.
        /// </summary>
        string SharedKey { get; }

        /// <summary>
        /// Gets the reference to peerings resource.
        /// </summary>
        string PeerId { get; }

        /// <summary>
        /// Gets the authorizationKey value.
        /// </summary>
        /// <summary>
        /// Gets the authorizationKey value.
        /// </summary>
        string AuthorizationKey { get; }

        /// <summary>
        /// Gets the egress bytes transferred in this connection.
        /// </summary>
        long IngressBytesTransferred { get; }

        /// <summary>
        /// Gets the routing weight.
        /// </summary>
        int RoutingWeight { get; }

        /// <summary>
        /// Gets the provisioning state of the VirtualNetworkGatewayConnection resource.
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the IPSec Policies to be considered by this connection.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Models.IpsecPolicy> IpsecPolicies { get; }

        /// <summary>
        /// Gets the gateway connection type.
        /// </summary>
        /// <summary>
        /// Gets the connectionType value.
        /// </summary>
        Models.VirtualNetworkGatewayConnectionType ConnectionType { get; }

        /// <summary>
        /// Gets the reference to virtual network gateway resource.
        /// </summary>
        string VirtualNetworkGateway2Id { get; }

        /// <summary>
        /// Gets the reference to virtual network gateway resource.
        /// </summary>
        string VirtualNetworkGateway1Id { get; }

        /// <summary>
        /// Gets the Virtual Network Gateway connection status.
        /// </summary>
        /// <summary>
        /// Gets the connectionStatus value.
        /// </summary>
        Models.VirtualNetworkGatewayConnectionStatus ConnectionStatus { get; }

        /// <summary>
        /// Gets if policy-based traffic selectors enabled.
        /// </summary>
        bool UsePolicyBasedTrafficSelectors { get; }

        /// <summary>
        /// Gets the egress bytes transferred in this connection.
        /// </summary>
        long EgressBytesTransferred { get; }

        /// <summary>
        /// Gets the enableBgp flag.
        /// </summary>
        bool IsBgpEnabled { get; }

        /// <summary>
        /// Gets the tunnelConnectionStatus value.
        /// </summary>
        /// <summary>
        /// Gets collection of all tunnels' connection health status.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Models.TunnelConnectionHealth> TunnelConnectionStatus { get; }
    }
}