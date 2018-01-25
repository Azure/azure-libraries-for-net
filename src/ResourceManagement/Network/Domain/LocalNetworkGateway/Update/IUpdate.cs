// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Update
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of update allowing to specify local network gateway's BGP speaker settings.
    /// </summary>
    public interface IWithBgp
    {
        /// <summary>
        /// Enables BGP.
        /// </summary>
        /// <param name="asn">The BGP speaker's ASN.</param>
        /// <param name="bgpPeeringAddress">The BGP peering address and BGP identifier of this BGP speaker.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Update.IUpdate WithBgp(long asn, string bgpPeeringAddress);

        /// <summary>
        /// Disables BGP.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Update.IUpdate WithoutBgp();
    }

    /// <summary>
    /// The stage of the local network gateway update allowing to specify the address spaces.
    /// </summary>
    public interface IWithAddressSpace
    {
        /// <summary>
        /// Remove address space. Note: address space will be removed only in case of exact cidr string match.
        /// </summary>
        /// <param name="cidr">The CIDR representation of the local network site address space.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Update.IUpdate WithoutAddressSpace(string cidr);

        /// <summary>
        /// Adds address space.
        /// Note: this method's effect is additive, i.e. each time it is used, a new address space is added to the network.
        /// </summary>
        /// <param name="cidr">The CIDR representation of the local network site address space.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Update.IUpdate WithAddressSpace(string cidr);
    }

    /// <summary>
    /// The template for a local network gateway update operation, containing all the settings that
    /// can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Update.IWithIPAddress,
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Update.IWithAddressSpace,
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Update.IWithBgp
    {
    }

    /// <summary>
    /// The stage of the local network gateway update allowing to change IP address of local network gateway.
    /// </summary>
    public interface IWithIPAddress
    {
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Update.IUpdate WithIPAddress(string ipAddress);
    }
}