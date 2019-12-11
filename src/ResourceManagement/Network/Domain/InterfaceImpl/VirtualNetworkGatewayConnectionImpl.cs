// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Collections.Generic;

    internal partial class VirtualNetworkGatewayConnectionImpl
    {
        /// <summary>
        /// Specify shared key.
        /// </summary>
        /// <param name="sharedKey">Shared key.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGatewayConnection.Definition.IWithCreate VirtualNetworkGatewayConnection.Definition.IWithSharedKey.WithSharedKey(string sharedKey)
        {
            return this.WithSharedKey(sharedKey);
        }

        /// <summary>
        /// Specify shared key.
        /// </summary>
        /// <param name="sharedKey">Shared key.</param>
        /// <return>The next stage of the update.</return>
        VirtualNetworkGatewayConnection.Update.IUpdate VirtualNetworkGatewayConnection.Update.IWithSharedKey.WithSharedKey(string sharedKey)
        {
            return this.WithSharedKey(sharedKey);
        }

        /// <summary>
        /// Gets the reference to virtual network gateway resource.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.VirtualNetworkGateway1Id
        {
            get
            {
                return this.VirtualNetworkGateway1Id();
            }
        }

        /// <summary>
        /// Gets the authorizationKey value.
        /// </summary>
        /// <summary>
        /// Gets the authorizationKey value.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.AuthorizationKey
        {
            get
            {
                return this.AuthorizationKey();
            }
        }

        /// <summary>
        /// Gets the egress bytes transferred in this connection.
        /// </summary>
        long Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.IngressBytesTransferred
        {
            get
            {
                return this.IngressBytesTransferred();
            }
        }

        /// <summary>
        /// Gets the tunnelConnectionStatus value.
        /// </summary>
        /// <summary>
        /// Gets collection of all tunnels' connection health status.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Models.TunnelConnectionHealth> Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.TunnelConnectionStatus
        {
            get
            {
                return this.TunnelConnectionStatus();
            }
        }

        /// <summary>
        /// Gets the Virtual Network Gateway connection status.
        /// </summary>
        /// <summary>
        /// Gets the connectionStatus value.
        /// </summary>
        Models.VirtualNetworkGatewayConnectionStatus Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.ConnectionStatus
        {
            get
            {
                return this.ConnectionStatus();
            }
        }

        /// <summary>
        /// Gets the reference to local network gateway resource.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.LocalNetworkGateway2Id
        {
            get
            {
                return this.LocalNetworkGateway2Id();
            }
        }

        /// <summary>
        /// Gets the provisioning state of the VirtualNetworkGatewayConnection resource.
        /// </summary>
        ProvisioningState Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the reference to virtual network gateway resource.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.VirtualNetworkGateway2Id
        {
            get
            {
                return this.VirtualNetworkGateway2Id();
            }
        }

        /// <summary>
        /// Gets if policy-based traffic selectors enabled.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors
        {
            get
            {
                return this.UsePolicyBasedTrafficSelectors();
            }
        }

        /// <summary>
        /// Gets the routing weight.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.RoutingWeight
        {
            get
            {
                return this.RoutingWeight();
            }
        }

        /// <summary>
        /// Gets the gateway connection type.
        /// </summary>
        /// <summary>
        /// Gets the connectionType value.
        /// </summary>
        Models.VirtualNetworkGatewayConnectionType Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.ConnectionType
        {
            get
            {
                return this.ConnectionType();
            }
        }

        /// <summary>
        /// Gets the reference to peerings resource.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.PeerId
        {
            get
            {
                return this.PeerId();
            }
        }

        /// <summary>
        /// Gets the IPSec Policies to be considered by this connection.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Models.IpsecPolicy> Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.IpsecPolicies
        {
            get
            {
                return this.IpsecPolicies();
            }
        }

        /// <summary>
        /// Gets the egress bytes transferred in this connection.
        /// </summary>
        long Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.EgressBytesTransferred
        {
            get
            {
                return this.EgressBytesTransferred();
            }
        }

        /// <summary>
        /// Gets the IPSec shared key.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.SharedKey
        {
            get
            {
                return this.SharedKey();
            }
        }

        /// <summary>
        /// Gets the enableBgp flag.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.IsBgpEnabled
        {
            get
            {
                return this.IsBgpEnabled();
            }
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway>.Parent
        {
            get
            {
                return this.Parent();
            }
        }

        /// <param name="localNetworkGateway">Local network gateway to connect to.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGatewayConnection.Definition.IWithSharedKey VirtualNetworkGatewayConnection.Definition.IWithLocalNetworkGateway.WithLocalNetworkGateway(ILocalNetworkGateway localNetworkGateway)
        {
            return this.WithLocalNetworkGateway(localNetworkGateway);
        }

        /// <summary>
        /// Specify authorization key.
        /// This is required in case of Express Route connection if Express Route circuit and virtual network gateway reside in different subscriptions.
        /// </summary>
        /// <param name="authorizationKey">Authorization key to use.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGatewayConnection.Definition.IWithCreate VirtualNetworkGatewayConnection.Definition.IWithAuthorization.WithAuthorization(string authorizationKey)
        {
            return this.WithAuthorization(authorizationKey);
        }

        /// <summary>
        /// Specify authorization key.
        /// This is required in case of Express Route connection if Express Route circuit and virtual network gateway reside in different subscriptions.
        /// </summary>
        /// <param name="authorizationKey">Authorization key to use.</param>
        /// <return>The next stage of the update.</return>
        VirtualNetworkGatewayConnection.Update.IUpdate VirtualNetworkGatewayConnection.Update.IWithAuthorization.WithAuthorization(string authorizationKey)
        {
            return this.WithAuthorization(authorizationKey);
        }

        /// <summary>
        /// Enable BGP for the connection.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGatewayConnection.Definition.IWithCreate VirtualNetworkGatewayConnection.Definition.IWithBgp.WithBgp()
        {
            return this.WithBgp();
        }

        /// <summary>
        /// Disable BGP for the connection.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualNetworkGatewayConnection.Update.IUpdate VirtualNetworkGatewayConnection.Update.IWithBgp.WithoutBgp()
        {
            return this.WithoutBgp();
        }

        /// <summary>
        /// Enable BGP for the connection.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualNetworkGatewayConnection.Update.IUpdate VirtualNetworkGatewayConnection.Update.IWithBgp.WithBgp()
        {
            return this.WithBgp();
        }

        /// <summary>
        /// Create Site-to-Site connection.
        /// </summary>
        /// <return>Next stage of definition, allowing to specify local network gateway.</return>
        VirtualNetworkGatewayConnection.Definition.IWithLocalNetworkGateway VirtualNetworkGatewayConnection.Definition.IWithConnectionType.WithSiteToSite()
        {
            return this.WithSiteToSite();
        }

        /// <summary>
        /// Create VNet-to-VNet connection.
        /// </summary>
        /// <return>The next stage of the definition, allowing to specify virtual network gateway to connect to.</return>
        VirtualNetworkGatewayConnection.Definition.IWithSecondVirtualNetworkGateway VirtualNetworkGatewayConnection.Definition.IWithConnectionType.WithVNetToVNet()
        {
            return this.WithVNetToVNet();
        }

        /// <summary>
        /// Create Express Route connection.
        /// </summary>
        /// <param name="circuitId">Id of Express Route circuit used for connection.</param>
        /// <return>Next stage of definition.</return>
        VirtualNetworkGatewayConnection.Definition.IWithCreate VirtualNetworkGatewayConnection.Definition.IWithConnectionType.WithExpressRoute(string circuitId)
        {
            return this.WithExpressRoute(circuitId);
        }

        /// <summary>
        /// Create Express Route connection.
        /// </summary>
        /// <param name="circuit">Express Route circuit used for connection.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGatewayConnection.Definition.IWithCreate VirtualNetworkGatewayConnection.Definition.IWithConnectionType.WithExpressRoute(IExpressRouteCircuit circuit)
        {
            return this.WithExpressRoute(circuit);
        }

        /// <param name="virtualNetworkGateway2">Virtual network gateway to connect to.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGatewayConnection.Definition.IWithSharedKey VirtualNetworkGatewayConnection.Definition.IWithSecondVirtualNetworkGateway.WithSecondVirtualNetworkGateway(IVirtualNetworkGateway virtualNetworkGateway2)
        {
            return this.WithSecondVirtualNetworkGateway(virtualNetworkGateway2);
        }

        public IAppliableWithTags<IVirtualNetworkGatewayConnection> WithoutTag(string key)
        {
            return base.WithoutTag(key);
        }

        public IAppliableWithTags<IVirtualNetworkGatewayConnection> WithTag(string key, string value)
        {
            return base.WithTag(key, value);
        }

        public IAppliableWithTags<IVirtualNetworkGatewayConnection> WithTags(IDictionary<string, string> tags)
        {
            return base.WithTags(tags);
        }

        IWithCreate IDefinitionWithTags<IWithCreate>.WithTags(IDictionary<string, string> tags)
        {
            return base.WithTags(tags);
        }

        IUpdate IUpdateWithTags<IUpdate>.WithTag(string key, string value)
        {
            return base.WithTag(key, value);
        }

        IUpdate IUpdateWithTags<IUpdate>.WithoutTag(string key)
        {
            return base.WithoutTag(key);
        }

        IUpdate IUpdateWithTags<IUpdate>.WithTags(IDictionary<string, string> tags)
        {
            return base.WithTags(tags);
        }

        IWithCreate IDefinitionWithTags<IWithCreate>.WithTag(string key, string value)
        {
            return base.WithTag(key, value);
        }
    }
}