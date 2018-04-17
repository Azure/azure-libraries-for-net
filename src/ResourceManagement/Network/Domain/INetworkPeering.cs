// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An client-side representation of a network peering.
    /// </summary>
    public interface INetworkPeering :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IIndependentChild<Microsoft.Azure.Management.Network.Fluent.INetworkManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.VirtualNetworkPeeringInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetworkPeering>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<NetworkPeering.Update.IUpdate>
    {
        /// <return>
        /// True if the peering enables IP addresses within the peered networks to be accessible from both networks, otherwise false
        /// (Note this method makes a separate call to Azure.).
        /// </return>
        bool CheckAccessBetweenNetworks();

        /// <return>The associated matching peering on the remote network if it is in the same subscription, otherwise this future computation will evaluate to null.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkPeering GetRemotePeering();

        /// <summary>
        /// Gets the associated remote virtual network's ID.
        /// </summary>
        string RemoteNetworkId { get; }

        /// <summary>
        /// Gets the associated matching peering on the remote network if it is in the same subscription.
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        Task<Microsoft.Azure.Management.Network.Fluent.INetworkPeering> GetRemotePeeringAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the remote network associated with this peering asynchronously.
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        Task<Microsoft.Azure.Management.Network.Fluent.INetwork> GetRemoteNetworkAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets true if the peered networks are in the same subscription, otherwise false.
        /// </summary>
        bool IsSameSubscription { get; }

        /// <summary>
        /// Gets the local virtual network's ID.
        /// </summary>
        string NetworkId { get; }

        /// <return>The remote network if it is in the same subscription, otherwise null.</return>
        Microsoft.Azure.Management.Network.Fluent.INetwork GetRemoteNetwork();

        /// <summary>
        /// Gets the state of the peering between the two networks.
        /// </summary>
        Models.VirtualNetworkPeeringState State { get; }

        /// <summary>
        /// Gets the type of gateway use enabled for this network.
        /// </summary>
        Models.NetworkPeeringGatewayUse GatewayUse { get; }

        /// <summary>
        /// Gets true if traffic forwarding from the remote network is allowed into this network.
        /// </summary>
        bool IsTrafficForwardingFromRemoteNetworkAllowed { get; }
    }
}