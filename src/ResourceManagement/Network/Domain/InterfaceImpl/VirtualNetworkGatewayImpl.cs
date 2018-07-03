// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    internal partial class VirtualNetworkGatewayImpl
    {
        /// <summary>
        /// Create a new virtual network to associate with the virtual network gateway,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGateway.Definition.IWithGatewayType VirtualNetworkGateway.Definition.IWithNetwork.WithNewNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable)
        {
            return this.WithNewNetwork(creatable);
        }

        /// <summary>
        /// Creates a new virtual network to associate with the virtual network gateway.
        /// the virtual network will be created in the same resource group and region as of parent
        /// virtual network gateway, it will be created with the specified address space and a subnet for virtual network gateway.
        /// </summary>
        /// <param name="name">The name of the new virtual network.</param>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <param name="subnetAddressSpaceCidr">The address space for the subnet.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGateway.Definition.IWithGatewayType VirtualNetworkGateway.Definition.IWithNetwork.WithNewNetwork(string name, string addressSpace, string subnetAddressSpaceCidr)
        {
            return this.WithNewNetwork(name, addressSpace, subnetAddressSpaceCidr);
        }

        /// <summary>
        /// Creates a new virtual network to associate with the virtual network gateway.
        /// the virtual network will be created in the same resource group and region as of parent virtual network gateway,
        /// it will be created with the specified address space and a default subnet for virtual network gateway.
        /// </summary>
        /// <param name="addressSpaceCidr">The address space for the virtual network.</param>
        /// <param name="subnetAddressSpaceCidr">The address space for the subnet.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGateway.Definition.IWithGatewayType VirtualNetworkGateway.Definition.IWithNetwork.WithNewNetwork(string addressSpaceCidr, string subnetAddressSpaceCidr)
        {
            return this.WithNewNetwork(addressSpaceCidr, subnetAddressSpaceCidr);
        }

        /// <summary>
        /// Associate an existing virtual network with the virtual network gateway .
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGateway.Definition.IWithGatewayType VirtualNetworkGateway.Definition.IWithNetwork.WithExistingNetwork(INetwork network)
        {
            return this.WithExistingNetwork(network);
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken);
        }

        /// <summary>
        /// Use Route-based VPN type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGateway.Definition.IWithSku VirtualNetworkGateway.Definition.IWithGatewayType.WithRouteBasedVpn()
        {
            return this.WithRouteBasedVpn();
        }

        /// <summary>
        /// Use Express route gateway type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGateway.Definition.IWithSku VirtualNetworkGateway.Definition.IWithGatewayType.WithExpressRoute()
        {
            return this.WithExpressRoute();
        }

        /// <summary>
        /// Use Policy-based VPN type. Note: this is available only for Basic SKU.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGateway.Definition.IWithCreate VirtualNetworkGateway.Definition.IWithGatewayType.WithPolicyBasedVpn()
        {
            return this.WithPolicyBasedVpn();
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGateway.Definition.IWithCreate HasPublicIPAddress.Definition.IWithExistingPublicIPAddress<VirtualNetworkGateway.Definition.IWithCreate>.WithExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.WithExistingPublicIPAddress(publicIPAddress);
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGateway.Definition.IWithCreate HasPublicIPAddress.Definition.IWithExistingPublicIPAddress<VirtualNetworkGateway.Definition.IWithCreate>.WithExistingPublicIPAddress(string resourceId)
        {
            return this.WithExistingPublicIPAddress(resourceId);
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGateway.Definition.IWithCreate HasPublicIPAddress.Definition.IWithNewPublicIPAddressNoDnsLabel<VirtualNetworkGateway.Definition.IWithCreate>.WithNewPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            return this.WithNewPublicIPAddress(creatable);
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGateway.Definition.IWithCreate HasPublicIPAddress.Definition.IWithNewPublicIPAddressNoDnsLabel<VirtualNetworkGateway.Definition.IWithCreate>.WithNewPublicIPAddress()
        {
            return this.WithNewPublicIPAddress();
        }

        /// <summary>
        /// Gets the resource id of the LocalNetworkGateway resource which represents local network site having default routes.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway.GatewayDefaultSiteResourceId
        {
            get
            {
                return this.GatewayDefaultSiteResourceId();
            }
        }

        /// <summary>
        /// Gets activeActive flag.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway.ActiveActive
        {
            get
            {
                return this.ActiveActive();
            }
        }

        /// <summary>
        /// Gets the reference of the VpnClientConfiguration resource which represents the P2S VpnClient configurations.
        /// </summary>
        Models.VpnClientConfiguration Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway.VpnClientConfiguration
        {
            get
            {
                return this.VpnClientConfiguration();
            }
        }

        /// <return>All the connections associated with this virtual network gateway.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection> Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway.ListConnections()
        {
            return this.ListConnections();
        }

        /// <summary>
        /// Gets whether BGP is enabled for this virtual network gateway or not.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway.IsBgpEnabled
        {
            get
            {
                return this.IsBgpEnabled();
            }
        }

        /// <summary>
        /// Get all the connections associated with this virtual network gateway asynchronously.
        /// </summary>
        /// <return>All the connections associated with this virtual network gateway.</return>
        async Task<IPagedCollection<IVirtualNetworkGatewayConnection>> Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway.ListConnectionsAsync(CancellationToken cancellationToken)
        {
            return await this.ListConnectionsAsync(cancellationToken);
        }

        /// <summary>
        /// Resets the primary of the virtual network gateway asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway.ResetAsync(CancellationToken cancellationToken)
        {

            await this.ResetAsync(cancellationToken);
        }

        /// <summary>
        /// Gets virtual network gateway's BGP speaker settings.
        /// </summary>
        Models.BgpSettings Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway.BgpSettings
        {
            get
            {
                return this.BgpSettings();
            }
        }

        /// <summary>
        /// Gets IP configurations for virtual network gateway.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayIPConfiguration> Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway.IPConfigurations
        {
            get
            {
                return this.IPConfigurations();
            }
        }

        /// <summary>
        /// Gets the entry point to virtual network gateway connections management API for this virtual network gateway.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnections Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway.Connections
        {
            get
            {
                return this.Connections();
            }
        }

        /// <summary>
        /// Gets the SKU of this virtual network gateway.
        /// </summary>
        Models.VirtualNetworkGatewaySku Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway.Sku
        {
            get
            {
                return this.Sku();
            }
        }

        /// <summary>
        /// Gets the gatewayType value.
        /// </summary>
        Models.VirtualNetworkGatewayType Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway.GatewayType
        {
            get
            {
                return this.GatewayType();
            }
        }

        /// <summary>
        /// Resets the primary of the virtual network gateway.
        /// </summary>
        void Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway.Reset()
        {

            this.Reset();
        }

        /// <summary>
        /// Gets the type of this virtual network gateway.
        /// </summary>
        Models.VpnType Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway.VpnType
        {
            get
            {
                return this.VpnType();
            }
        }

        /// <param name="asn">The BGP speaker's ASN.</param>
        /// <param name="bgpPeeringAddress">The BGP peering address and BGP identifier of this BGP speaker.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGateway.Definition.IWithCreate VirtualNetworkGateway.Definition.IWithBgp.WithBgp(long asn, string bgpPeeringAddress)
        {
            return this.WithBgp(asn, bgpPeeringAddress);
        }

        /// <summary>
        /// Disables BGP for this virtual network gateway.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualNetworkGateway.Update.IUpdate VirtualNetworkGateway.Update.IWithBgp.WithoutBgp()
        {
            return this.WithoutBgp();
        }

        /// <summary>
        /// Enables BGP.
        /// </summary>
        /// <param name="asn">The BGP speaker's ASN.</param>
        /// <param name="bgpPeeringAddress">The BGP peering address and BGP identifier of this BGP speaker.</param>
        /// <return>The next stage of the update.</return>
        VirtualNetworkGateway.Update.IUpdate VirtualNetworkGateway.Update.IWithBgp.WithBgp(long asn, string bgpPeeringAddress)
        {
            return this.WithBgp(asn, bgpPeeringAddress);
        }

        VirtualNetworkGateway.Definition.IWithCreate VirtualNetworkGateway.Definition.IWithSku.WithSku(VirtualNetworkGatewaySkuName skuName)
        {
            return this.WithSku(skuName);
        }

        VirtualNetworkGateway.Update.IUpdate VirtualNetworkGateway.Update.IWithSku.WithSku(VirtualNetworkGatewaySkuName skuName)
        {
            return this.WithSku(skuName);
        }
        PointToSiteConfiguration.Update.IUpdate IWithPointToSiteConfiguration.UpdatePointToSiteConfiguration()
        {
            return this.UpdatePointToSiteConfiguration();
        }

        PointToSiteConfiguration.Definition.IBlank<VirtualNetworkGateway.Update.IUpdate> IWithPointToSiteConfiguration.DefinePointToSiteConfiguration()
        {
            return this.DefinePointToSiteConfiguration();
        }
    }
}