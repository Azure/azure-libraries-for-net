// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The entirety of the express route circuit peering definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition.IWithAdvertisedPublicPrefixes,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition.IWithPrimaryPeerAddressPrefix,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition.IWithSecondaryPeerAddressPrefix,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition.IWithVlanId,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition.IWithPeerAsn,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition.IWithCreate
    {
    }

    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering>
    {
    }

    public interface IBlank :
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition.IWithPrimaryPeerAddressPrefix
    {
    }

    /// <summary>
    /// The stage of Express Route Circuit Peering definition allowing to specify primary address prefix.
    /// </summary>
    public interface IWithPrimaryPeerAddressPrefix
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition.IWithSecondaryPeerAddressPrefix WithPrimaryPeerAddressPrefix(string addressPrefix);
    }

    /// <summary>
    /// The stage of Express Route Circuit Peering definition allowing to specify advertised address prefixes.
    /// </summary>
    public interface IWithAdvertisedPublicPrefixes
    {
        /// <summary>
        /// Specify advertised prefixes: sets a list of all prefixes that are planned to advertise over the BGP session.
        /// Only public IP address prefixes are accepted. A set of prefixes can be sent as a comma-separated list.
        /// These prefixes must be registered to you in an RIR / IRR.
        /// </summary>
        /// <param name="publicPrefixes">Advertised prefixes.</param>
        /// <return>Next stage of definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition.IWithPrimaryPeerAddressPrefix WithAdvertisedPublicPrefixes(string publicPrefixes);
    }

    /// <summary>
    /// The stage of Express Route Circuit Peering definition allowing to specify AS number for peering.
    /// </summary>
    public interface IWithPeerAsn
    {
        /// <param name="peerAsn">AS number for peering. Both 2-byte and 4-byte AS numbers can be used.</param>
        /// <return>Next stage of definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition.IWithCreate WithPeerAsn(int peerAsn);
    }

    /// <summary>
    /// The stage of Express Route Circuit Peering definition allowing to specify secondary address prefix.
    /// </summary>
    public interface IWithSecondaryPeerAddressPrefix
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition.IWithVlanId WithSecondaryPeerAddressPrefix(string addressPrefix);
    }

    /// <summary>
    /// The stage of Express Route Circuit Peering definition allowing to specify VLAN ID.
    /// </summary>
    public interface IWithVlanId
    {
        /// <param name="vlanId">A valid VLAN ID to establish this peering on. No other peering in the circuit can use the same VLAN ID.</param>
        /// <return>Next stage of definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition.IWithPeerAsn WithVlanId(int vlanId);
    }
}