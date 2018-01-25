// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Update
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of Express Route Circuit Peering update allowing to specify secondary address prefix.
    /// </summary>
    public interface IWithSecondaryPeerAddressPrefix
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Update.IUpdate WithSecondaryPeerAddressPrefix(string addressPrefix);
    }

    /// <summary>
    /// The stage of Express Route Circuit Peering update allowing to specify primary address prefix.
    /// </summary>
    public interface IWithPrimaryPeerAddressPrefix
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Update.IUpdate WithPrimaryPeerAddressPrefix(string addressPrefix);
    }

    /// <summary>
    /// Grouping of express route circuit peering update stages.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering>,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Update.IWithAdvertisedPublicPrefixes,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Update.IWithPrimaryPeerAddressPrefix,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Update.IWithSecondaryPeerAddressPrefix,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Update.IWithVlanId,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Update.IWithPeerAsn
    {
    }

    /// <summary>
    /// The stage of Express Route Circuit Peering update allowing to specify advertised address prefixes.
    /// </summary>
    public interface IWithAdvertisedPublicPrefixes
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Update.IUpdate WithAdvertisedPublicPrefixes(string publicPrefixes);
    }

    /// <summary>
    /// The stage of Express Route Circuit Peering update allowing to specify AS number for peering.
    /// </summary>
    public interface IWithPeerAsn
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Update.IUpdate WithPeerAsn(int peerAsn);
    }

    /// <summary>
    /// The stage of Express Route Circuit Peering update allowing to specify VLAN ID.
    /// </summary>
    public interface IWithVlanId
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Update.IUpdate WithVlanId(int vlanId);
    }
}