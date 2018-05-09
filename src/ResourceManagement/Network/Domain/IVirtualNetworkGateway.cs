// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Entry point for Virtual Network Gateway management API in Azure.
    /// </summary>
    public interface IVirtualNetworkGateway :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Network.Fluent.INetworkManager, Models.VirtualNetworkGatewayInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<VirtualNetworkGateway.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.IUpdatableWithTags<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway>
    {
        /// <summary>
        /// Resets the primary of the virtual network gateway asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task ResetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the resource id of the LocalNetworkGateway resource which represents local network site having default routes.
        /// </summary>
        string GatewayDefaultSiteResourceId { get; }

        /// <summary>
        /// Gets activeActive flag.
        /// </summary>
        bool ActiveActive { get; }

        /// <summary>
        /// Generates asynchronously VPN profile for P2S client of the virtual network gateway in the specified resource group. Used for IKEV2 and radius based authentication.
        /// </summary>
        /// <return>String object if successful.</return>
        Task<string> GenerateVpnProfileAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets virtual network gateway's BGP speaker settings.
        /// </summary>
        Models.BgpSettings BgpSettings { get; }

        /// <return>All the connections associated with this virtual network gateway.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection> ListConnections();

        /// <summary>
        /// Get all the connections associated with this virtual network gateway asynchronously.
        /// </summary>
        /// <return>All the connections associated with this virtual network gateway.</return>
        Task<IPagedCollection<IVirtualNetworkGatewayConnection>> ListConnectionsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets IP configurations for virtual network gateway.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayIPConfiguration> IPConfigurations { get; }

        /// <summary>
        /// Gets the gatewayType value.
        /// </summary>
        Models.VirtualNetworkGatewayType GatewayType { get; }

        /// <summary>
        /// Generates VPN profile for P2S client of the virtual network gateway in the specified resource group. Used for IKEV2 and radius based authentication.
        /// </summary>
        /// <return>String object if successful.</return>
        string GenerateVpnProfile();

        /// <summary>
        /// Resets the primary of the virtual network gateway.
        /// </summary>
        void Reset();

        /// <summary>
        /// Gets the reference of the VpnClientConfiguration resource which represents the P2S VpnClient configurations.
        /// </summary>
        Models.VpnClientConfiguration VpnClientConfiguration { get; }

        /// <summary>
        /// Gets the type of this virtual network gateway.
        /// </summary>
        Models.VpnType VpnType { get; }

        /// <summary>
        /// Gets whether BGP is enabled for this virtual network gateway or not.
        /// </summary>
        bool IsBgpEnabled { get; }

        /// <summary>
        /// Gets the SKU of this virtual network gateway.
        /// </summary>
        Models.VirtualNetworkGatewaySku Sku { get; }

        /// <summary>
        /// Gets the entry point to virtual network gateway connections management API for this virtual network gateway.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnections Connections { get; }
    }
}