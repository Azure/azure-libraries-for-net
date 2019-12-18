// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Client-side representation of express route circuit peering object, associated with express route circuit.
    /// </summary>
    public interface IExpressRouteCircuitPeering :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IIndependentChild<Microsoft.Azure.Management.Network.Fluent.INetworkManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ExpressRouteCircuitPeeringInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ExpressRouteCircuitPeering.Update.IUpdate>
    {
        /// <summary>
        /// Gets the shared key.
        /// </summary>
        string SharedKey { get; }

        /// <summary>
        /// Gets the primary port.
        /// </summary>
        string PrimaryAzurePort { get; }

        /// <summary>
        /// Gets the IPv6 peering configuration.
        /// </summary>
        Models.Ipv6ExpressRouteCircuitPeeringConfig IPv6PeeringConfig { get; }

        /// <summary>
        /// Gets the secondary port.
        /// </summary>
        string SecondaryAzurePort { get; }

        /// <summary>
        /// Gets the VLAN ID.
        /// </summary>
        int VlanId { get; }

        /// <summary>
        /// Gets whether the provider or the customer last modified the peering.
        /// </summary>
        string LastModifiedBy { get; }

        /// <summary>
        /// Gets the Azure ASN.
        /// </summary>
        int AzureAsn { get; }

        /// <summary>
        /// Gets the provisioning state of the resource.
        /// </summary>
        /// <summary>
        /// Gets provisioningState.
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the peer ASN.
        /// </summary>
        long PeerAsn { get; }

        /// <summary>
        /// Gets the secondary address prefix.
        /// </summary>
        string SecondaryPeerAddressPrefix { get; }

        /// <summary>
        /// Gets peering stats.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitStats Stats { get; }

        /// <summary>
        /// Gets the primary address prefix.
        /// </summary>
        string PrimaryPeerAddressPrefix { get; }

        /// <summary>
        /// Gets The Microsoft peering configuration.
        /// </summary>
        Models.ExpressRouteCircuitPeeringConfig MicrosoftPeeringConfig { get; }

        /// <summary>
        /// Gets the state of peering.
        /// </summary>
        /// <summary>
        /// Gets peering state.
        /// </summary>
        Models.ExpressRoutePeeringState State { get; }

        /// <summary>
        /// Gets peering type.
        /// </summary>
        Models.ExpressRoutePeeringType PeeringType { get; }
    }
}