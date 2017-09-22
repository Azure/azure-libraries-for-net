// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of update allowing to specify virtual network gateway's BGP speaker settings.
    /// Note: BGP is supported on Route-Based VPN gateways only.
    /// </summary>
    public interface IWithBgp 
    {
        /// <param name="asn">The BGP speaker's ASN.</param>
        /// <param name="bgpPeeringAddress">The BGP peering address and BGP identifier of this BGP speaker.</param>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update.IUpdate WithBgp(long asn, string bgpPeeringAddress);

        /// <summary>
        /// Gets Disable BGP for this virtual network gateway.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update.IUpdate DisableBgp { get; }
    }

    /// <summary>
    /// The stage of virtual network gateway update allowing to change SKU.
    /// </summary>
    public interface IWithSku 
    {
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update.IUpdate WithSku(VirtualNetworkGatewaySkuName skuName);
    }

    /// <summary>
    /// The template for a virtual network gateway update operation, containing all the settings that
    /// can be modified.
    /// Call  Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update.IWithSku,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update.IWithBgp
    {
    }
}