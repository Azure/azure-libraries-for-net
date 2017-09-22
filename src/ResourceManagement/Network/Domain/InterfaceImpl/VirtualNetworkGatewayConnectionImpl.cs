// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
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
        VirtualNetworkGatewayConnection.Definition.IWithCreate VirtualNetworkGatewayConnection.Definition.IWithSharedKey.WithSharedKey(string sharedKey)
        {
            return this.WithSharedKey(sharedKey) as VirtualNetworkGatewayConnection.Definition.IWithCreate;
        }

        VirtualNetworkGatewayConnection.Update.IUpdate VirtualNetworkGatewayConnection.Update.IWithSharedKey.WithSharedKey(string sharedKey)
        {
            return this.WithSharedKey(sharedKey) as VirtualNetworkGatewayConnection.Update.IUpdate;
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
                return this.TunnelConnectionStatus() as System.Collections.Generic.IReadOnlyCollection<Models.TunnelConnectionHealth>;
            }
        }

        /// <summary>
        /// Gets the Virtual Network Gateway connection status. Possible values are
        /// 'Unknown', 'Connecting', 'Connected' and 'NotConnected'. Possible values
        /// include: 'Unknown', 'Connecting', 'Connected', 'NotConnected'.
        /// </summary>
        /// <summary>
        /// Gets the connectionStatus value.
        /// </summary>
        Models.VirtualNetworkGatewayConnectionStatus Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.ConnectionStatus
        {
            get
            {
                return this.ConnectionStatus() as Models.VirtualNetworkGatewayConnectionStatus;
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
        string Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.ProvisioningState
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
        /// Gets the gateway connection type. Possible values are:
        /// 'Ipsec','Vnet2Vnet','ExpressRoute', and 'VPNClient.
        /// </summary>
        /// <summary>
        /// Gets the connectionType value.
        /// </summary>
        Models.VirtualNetworkGatewayConnectionType Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection.ConnectionType
        {
            get
            {
                return this.ConnectionType() as Models.VirtualNetworkGatewayConnectionType;
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
                return this.IpsecPolicies() as System.Collections.Generic.IReadOnlyCollection<Models.IpsecPolicy>;
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
                return this.Parent() as Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway;
            }
        }

        VirtualNetworkGatewayConnection.Definition.IWithSharedKey VirtualNetworkGatewayConnection.Definition.IWithLocalNetworkGateway.WithLocalNetworkGateway(ILocalNetworkGateway localNetworkGateway)
        {
            return this.WithLocalNetworkGateway(localNetworkGateway) as VirtualNetworkGatewayConnection.Definition.IWithSharedKey;
        }

        VirtualNetworkGatewayConnection.Definition.IWithCreate VirtualNetworkGatewayConnection.Definition.IWithBgp.WithBgp()
        {
            return this.WithBgp() as VirtualNetworkGatewayConnection.Definition.IWithCreate;
        }

        VirtualNetworkGatewayConnection.Update.IUpdate VirtualNetworkGatewayConnection.Update.IWithBgp.WithoutBgp()
        {
            return this.WithoutBgp() as VirtualNetworkGatewayConnection.Update.IUpdate;
        }

        VirtualNetworkGatewayConnection.Update.IUpdate VirtualNetworkGatewayConnection.Update.IWithBgp.WithBgp()
        {
            return this.WithBgp() as VirtualNetworkGatewayConnection.Update.IUpdate;
        }

        VirtualNetworkGatewayConnection.Definition.IWithLocalNetworkGateway VirtualNetworkGatewayConnection.Definition.IWithConnectionType.WithSiteToSite()
        {
            return this.WithSiteToSite() as VirtualNetworkGatewayConnection.Definition.IWithLocalNetworkGateway;
        }

        VirtualNetworkGatewayConnection.Definition.IWithSecondVirtualNetworkGateway VirtualNetworkGatewayConnection.Definition.IWithConnectionType.WithVNetToVNet()
        {
            return this.WithVNetToVNet() as VirtualNetworkGatewayConnection.Definition.IWithSecondVirtualNetworkGateway;
        }

        VirtualNetworkGatewayConnection.Definition.IWithExpressRoute VirtualNetworkGatewayConnection.Definition.IWithConnectionType.WithExpressRoute()
        {
            return this.WithExpressRoute() as VirtualNetworkGatewayConnection.Definition.IWithExpressRoute;
        }

        VirtualNetworkGatewayConnection.Definition.IWithSharedKey VirtualNetworkGatewayConnection.Definition.IWithSecondVirtualNetworkGateway.WithSecondVirtualNetworkGateway(IVirtualNetworkGateway virtualNetworkGateway2)
        {
            return this.WithSecondVirtualNetworkGateway(virtualNetworkGateway2) as VirtualNetworkGatewayConnection.Definition.IWithSharedKey;
        }
    }
}