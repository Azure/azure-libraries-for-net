// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.Models;

    /// <summary>
    /// The template for a virtual network gateway update operation, containing all the settings that
    /// can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update.IWithSku,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update.IWithBgp,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update.IWithPointToSiteConfiguration
    {
    }

    /// <summary>
    /// The stage of update allowing to specify virtual network gateway's BGP speaker settings.
    /// Note: BGP is supported on Route-Based VPN gateways only.
    /// </summary>
    public interface IWithBgp
    {
        /// <summary>
        /// Enables BGP.
        /// </summary>
        /// <param name="asn">The BGP speaker's ASN.</param>
        /// <param name="bgpPeeringAddress">The BGP peering address and BGP identifier of this BGP speaker.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update.IUpdate WithBgp(long asn, string bgpPeeringAddress);

        /// <summary>
        /// Disables BGP for this virtual network gateway.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update.IUpdate WithoutBgp();
    }

    /// <summary>
    /// The stage of update allowing to specify virtual network gateway's point-to-site configuration.
    /// </summary>
    public interface IWithPointToSiteConfiguration
    {
        /// <summary>
        /// Begins update of existing point-to-site configuration for this virtual network gateway.
        /// </summary>
        /// <return>The first stage of the point-to-site configuration update.</return>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update.IUpdate UpdatePointToSiteConfiguration();

        /// <summary>
        /// Begins the definition of point-to-site configuration to be added to this virtual network gateway.
        /// </summary>
        /// <return>The first stage of the point-to-site configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IBlank<VirtualNetworkGateway.Update.IUpdate> DefinePointToSiteConfiguration();
    }

    /// <summary>
    /// The stage of virtual network gateway update allowing to change SKU.
    /// </summary>
    public interface IWithSku
    {
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update.IUpdate WithSku(VirtualNetworkGatewaySkuName skuName);
    }
}