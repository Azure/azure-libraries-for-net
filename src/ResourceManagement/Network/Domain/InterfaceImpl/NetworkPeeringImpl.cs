// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition;
    using Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.IndependentChild.Definition;

    internal partial class NetworkPeeringImpl
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name;
            }
        }

        /// <summary>
        /// Gets the type of gateway use enabled for this network.
        /// </summary>
        Models.NetworkPeeringGatewayUse Microsoft.Azure.Management.Network.Fluent.INetworkPeering.GatewayUse
        {
            get
            {
                return this.GatewayUse();
            }
        }

        /// <summary>
        /// Gets the associated remote virtual network's ID.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkPeering.RemoteNetworkId
        {
            get
            {
                return this.RemoteNetworkId();
            }
        }

        /// <return>The remote network if it is in the same subscription, otherwise null.</return>
        Microsoft.Azure.Management.Network.Fluent.INetwork Microsoft.Azure.Management.Network.Fluent.INetworkPeering.GetRemoteNetwork()
        {
            return this.GetRemoteNetwork();
        }

        /// <summary>
        /// Gets the remote network associated with this peering asynchronously.
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.INetwork> Microsoft.Azure.Management.Network.Fluent.INetworkPeering.GetRemoteNetworkAsync(CancellationToken cancellationToken)
        {
            return await this.GetRemoteNetworkAsync(cancellationToken);
        }

        /// <return>The associated matching peering on the remote network if it is in the same subscription, otherwise this future computation will evaluate to null.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkPeering Microsoft.Azure.Management.Network.Fluent.INetworkPeering.GetRemotePeering()
        {
            return this.GetRemotePeering();
        }

        /// <summary>
        /// Gets the local virtual network's ID.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkPeering.NetworkId
        {
            get
            {
                return this.NetworkId();
            }
        }

        /// <summary>
        /// Gets true if traffic forwarding from the remote network is allowed into this network.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.INetworkPeering.IsTrafficForwardingFromRemoteNetworkAllowed
        {
            get
            {
                return this.IsTrafficForwardingFromRemoteNetworkAllowed();
            }
        }

        /// <summary>
        /// Gets the associated matching peering on the remote network if it is in the same subscription.
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.INetworkPeering> Microsoft.Azure.Management.Network.Fluent.INetworkPeering.GetRemotePeeringAsync(CancellationToken cancellationToken)
        {
            return await this.GetRemotePeeringAsync(cancellationToken);
        }

        /// <summary>
        /// Gets true if the peered networks are in the same subscription, otherwise false.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.INetworkPeering.IsSameSubscription
        {
            get
            {
                return this.IsSameSubscription();
            }
        }

        /// <return>
        /// True if the peering enables IP addresses within the peered networks to be accessible from both networks, otherwise false
        /// (Note this method makes a separate call to Azure.).
        /// </return>
        bool Microsoft.Azure.Management.Network.Fluent.INetworkPeering.CheckAccessBetweenNetworks()
        {
            return this.CheckAccessBetweenNetworks();
        }

        /// <summary>
        /// Gets the state of the peering between the two networks.
        /// </summary>
        Models.VirtualNetworkPeeringState Microsoft.Azure.Management.Network.Fluent.INetworkPeering.State
        {
            get
            {
                return this.State();
            }
        }

        /// <summary>
        /// Disallows access to either peered network from the other.
        /// This setting will have effect on the remote network only if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding access setting on the remote network's matching peering explicitly.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkPeering.Update.IUpdate NetworkPeering.Update.IWithAccess.WithoutAccessFromEitherNetwork()
        {
            return this.WithoutAccessFromEitherNetwork();
        }

        /// <summary>
        /// Enables access to either peered virtual network from the other.
        /// This setting will have effect on the remote network only if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding access setting on the remote network's matching peering explicitly.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkPeering.Update.IUpdate NetworkPeering.Update.IWithAccess.WithAccessBetweenBothNetworks()
        {
            return this.WithAccessBetweenBothNetworks();
        }

        /// <summary>
        /// Disallows access to either peered network from the other.
        /// This setting will have effect on the remote network only if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding access setting on the remote network's matching peering explicitly.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkPeering.Definition.IWithCreate NetworkPeering.Definition.IWithAccess.WithoutAccessFromEitherNetwork()
        {
            return this.WithoutAccessFromEitherNetwork();
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id;
            }
        }

        /// <summary>
        /// Disables any gateway use by this network and the remote one.
        /// This will have effect on the remote network only if the remote network is in the same subscription as this network.
        /// Otherwise, only this network's use of the remote network's gateway will be stopped, but the use of this network's gateway
        /// by the remote network will only be disallowed. You will have to update the remote network's peering explicitly to properly stop
        /// its use of this network's gateway.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkPeering.Update.IUpdate NetworkPeering.Update.IWithGatewayUse.WithoutAnyGatewayUse()
        {
            return this.WithoutAnyGatewayUse();
        }

        /// <summary>
        /// Starts the use of the remote network's gateway.
        /// If the remote network is in the same subscription, remote gateway use by this network (a.k.a. gateway transit) will also be automatically allowed on the remote network's side.
        /// Otherwise, this network will only be configured to use the remote gateway, but the matching peering on the remote network must still be additionally modified
        /// explicitly to allow gateway use by this network.
        /// If this network is currently configured to allow the remote network to use its gateway, that use will be automatically disabled, as these two settings cannot be used together.
        /// Before gateway use on a remote network can be started, a working gateway must already be in place within the remote network.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkPeering.Update.IUpdate NetworkPeering.Update.IWithGatewayUse.WithGatewayUseOnRemoteNetworkStarted()
        {
            return this.WithGatewayUseOnRemoteNetworkStarted();
        }

        /// <summary>
        /// Allows and starts the use of this network's gateway by the remote network (a.k.a. gateway transit).
        /// If the remote network is not in the same subscription as this network, then gateway use by the remote gateway will only be allowed
        /// on this network, but not started. The matching peering on the remote network must be modified explicitly to start it.
        /// If this network is currently configured to use the remote network's gateway, that use will be automatically disabled, as these two settings cannot be used together.
        /// Before gateway use by a remote network can be started, a working gateway must already be in place within this network.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkPeering.Update.IUpdate NetworkPeering.Update.IWithGatewayUse.WithGatewayUseByRemoteNetworkStarted()
        {
            return this.WithGatewayUseByRemoteNetworkStarted();
        }

        /// <summary>
        /// Stops this network's use of the remote network's gateway.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkPeering.Update.IUpdate NetworkPeering.Update.IWithGatewayUse.WithoutGatewayUseOnRemoteNetwork()
        {
            return this.WithoutGatewayUseOnRemoteNetwork();
        }

        /// <summary>
        /// Allows the remote network to use this network's gateway (a.k.a. gateway transit), but does not start the use of the gateway by the remote network.
        /// If this network is currently configured to use the remote network's gateway, that use will be automatically disabled, as these two settings cannot be used together.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkPeering.Update.IUpdate NetworkPeering.Update.IWithGatewayUse.WithGatewayUseByRemoteNetworkAllowed()
        {
            return this.WithGatewayUseByRemoteNetworkAllowed();
        }

        /// <summary>
        /// Stops and disallows the use of this network's gateway by the remote network.
        /// If the remote network is not in the same subscription, then the use of that network's gateway by this network will be stopped but not disallowed
        /// by the remote network. The matching peering on the remote network must still be explicitly updated to also disallow such use.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkPeering.Update.IUpdate NetworkPeering.Update.IWithGatewayUse.WithoutGatewayUseByRemoteNetwork()
        {
            return this.WithoutGatewayUseByRemoteNetwork();
        }

        /// <summary>
        /// Disables any gateway use by this network and the remote one.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkPeering.Definition.IWithCreate NetworkPeering.Definition.IWithGatewayUse.WithoutAnyGatewayUse()
        {
            return this.WithoutAnyGatewayUse();
        }

        /// <summary>
        /// Starts the use of the remote network's gateway.
        /// If the remote network is in the same subscription, remote gateway use by this network (a.k.a. gateway transit) will also be automatically allowed on the remote network's side.
        /// Otherwise, this network will only be configured to use the remote gateway, but the matching peering on the remote network must still be additionally modified
        /// explicitly to allow gateway use by this network.
        /// If this network is currently configured to allow the remote network to use its gateway, that use will be automatically disabled, as these two settings cannot be used together.
        /// Before gateway use on a remote network can be started, a working gateway must already be in place within the remote network.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkPeering.Definition.IWithCreate NetworkPeering.Definition.IWithGatewayUse.WithGatewayUseOnRemoteNetworkStarted()
        {
            return this.WithGatewayUseOnRemoteNetworkStarted();
        }

        /// <summary>
        /// Allows and starts the use of this network's gateway by the remote network (a.k.a. gateway transit).
        /// If the remote network is not in the same subscription as this network, then gateway use by the remote gateway will only be
        /// allowed on this network, but not started. The matching peering on the remote network must be modified explicitly to start it.
        /// If this network is currently configured to use the remote network's gateway, that use will be automatically disabled, as these two settings cannot be used together.
        /// Before gateway use by a remote network can be started, a working gateway must already be in place within this network.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkPeering.Definition.IWithCreate NetworkPeering.Definition.IWithGatewayUse.WithGatewayUseByRemoteNetworkStarted()
        {
            return this.WithGatewayUseByRemoteNetworkStarted();
        }

        /// <summary>
        /// Allows the remote network to use this network's gateway (a.k.a. gateway transit), but does not start the use of the gateway by the remote network.
        /// If this network is currently configured to use the remote network's gateway, that use will be automatically disabled, as these two settings cannot be used together.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkPeering.Definition.IWithCreate NetworkPeering.Definition.IWithGatewayUse.WithGatewayUseByRemoteNetworkAllowed()
        {
            return this.WithGatewayUseByRemoteNetworkAllowed();
        }

        /// <summary>
        /// Prevents traffic forwarding from the remote network.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkPeering.Update.IUpdate NetworkPeering.Update.IWithTrafficForwarding.WithoutTrafficForwardingFromRemoteNetwork()
        {
            return this.WithoutTrafficForwardingFromRemoteNetwork();
        }

        /// <summary>
        /// Disables traffic forwarding to the remote network.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkPeering.Update.IUpdate NetworkPeering.Update.IWithTrafficForwarding.WithoutTrafficForwardingToRemoteNetwork()
        {
            return this.WithoutTrafficForwardingToRemoteNetwork();
        }

        /// <summary>
        /// Allows traffic forwarding from this network to the remote network.
        /// This setting will only work here if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding traffic forwarding setting on the remote network's matching peering explicitly.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkPeering.Update.IUpdate NetworkPeering.Update.IWithTrafficForwarding.WithTrafficForwardingToRemoteNetwork()
        {
            return this.WithTrafficForwardingToRemoteNetwork();
        }

        /// <summary>
        /// Disables traffic forwarding from either peered network to the other.
        /// This setting will have effect on the remote network only if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding traffic forwarding setting on the remote network's matching peering explicitly.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkPeering.Update.IUpdate NetworkPeering.Update.IWithTrafficForwarding.WithoutTrafficForwardingFromEitherNetwork()
        {
            return this.WithoutTrafficForwardingFromEitherNetwork();
        }

        /// <summary>
        /// Allows traffic forwarding both from either peered network to the other.
        /// This setting will have effect on the remote network only if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding traffic forwarding setting on the remote network's matching peering explicitly.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkPeering.Update.IUpdate NetworkPeering.Update.IWithTrafficForwarding.WithTrafficForwardingBetweenBothNetworks()
        {
            return this.WithTrafficForwardingBetweenBothNetworks();
        }

        /// <summary>
        /// Allows traffic forwarding from the remote network.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkPeering.Update.IUpdate NetworkPeering.Update.IWithTrafficForwarding.WithTrafficForwardingFromRemoteNetwork()
        {
            return this.WithTrafficForwardingFromRemoteNetwork();
        }

        /// <summary>
        /// Allows traffic forwarding from this network to the remote network.
        /// This setting will have effect only if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding traffic forwarding setting on the remote network's matching peering explicitly.
        /// </summary>
        NetworkPeering.Definition.IWithCreate NetworkPeering.Definition.IWithTrafficForwarding.WithTrafficForwardingToRemoteNetwork()
        {
            return this.WithTrafficForwardingToRemoteNetwork();
        }

        /// <summary>
        /// Allows traffic forwarding both from either peered network into the other.
        /// This setting will have effect on the remote network only if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding traffic forwarding setting on the remote network's matching peering explicitly.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkPeering.Definition.IWithCreate NetworkPeering.Definition.IWithTrafficForwarding.WithTrafficForwardingBetweenBothNetworks()
        {
            return this.WithTrafficForwardingBetweenBothNetworks();
        }

        /// <summary>
        /// Allows traffic forwarded from the remote network.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkPeering.Definition.IWithCreate NetworkPeering.Definition.IWithTrafficForwarding.WithTrafficForwardingFromRemoteNetwork()
        {
            return this.WithTrafficForwardingFromRemoteNetwork();
        }

        /// <summary>
        /// Specifies the remote network to peer with.
        /// The remote network will have the matching peering associated with it automatically.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing network.</param>
        /// <return>The next stage of the definition.</return>
        NetworkPeering.Definition.IWithCreate NetworkPeering.Definition.IWithRemoteNetwork.WithRemoteNetwork(string resourceId)
        {
            return this.WithRemoteNetwork(resourceId);
        }

        /// <summary>
        /// Specifies the remote network to peer with.
        /// The remote network will have the matching peering associated with it automatically.
        /// </summary>
        /// <param name="network">An existing network.</param>
        /// <return>The next stage of the definition.</return>
        NetworkPeering.Definition.IWithCreate NetworkPeering.Definition.IWithRemoteNetwork.WithRemoteNetwork(INetwork network)
        {
            return this.WithRemoteNetwork(network);
        }
    }
}