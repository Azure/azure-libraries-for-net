// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of a network peering update allowing to control traffic forwarding from or to the remote network.
    /// </summary>
    public interface IWithTrafficForwarding
    {
        /// <summary>
        /// Prevents traffic forwarding from the remote network.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IUpdate WithoutTrafficForwardingFromRemoteNetwork();

        /// <summary>
        /// Disables traffic forwarding from either peered network to the other.
        /// This setting will have effect on the remote network only if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding traffic forwarding setting on the remote network's matching peering explicitly.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IUpdate WithoutTrafficForwardingFromEitherNetwork();

        /// <summary>
        /// Allows traffic forwarding from the remote network.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IUpdate WithTrafficForwardingFromRemoteNetwork();

        /// <summary>
        /// Disables traffic forwarding to the remote network.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IUpdate WithoutTrafficForwardingToRemoteNetwork();

        /// <summary>
        /// Allows traffic forwarding both from either peered network to the other.
        /// This setting will have effect on the remote network only if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding traffic forwarding setting on the remote network's matching peering explicitly.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IUpdate WithTrafficForwardingBetweenBothNetworks();

        /// <summary>
        /// Allows traffic forwarding from this network to the remote network.
        /// This setting will only work here if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding traffic forwarding setting on the remote network's matching peering explicitly.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IUpdate WithTrafficForwardingToRemoteNetwork();
    }

    /// <summary>
    /// The stage of a network peering update allowing to control access from and to the remote network.
    /// </summary>
    public interface IWithAccess
    {
        /// <summary>
        /// Disallows access to either peered network from the other.
        /// This setting will have effect on the remote network only if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding access setting on the remote network's matching peering explicitly.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IUpdate WithoutAccessFromEitherNetwork();

        /// <summary>
        /// Enables access to either peered virtual network from the other.
        /// This setting will have effect on the remote network only if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding access setting on the remote network's matching peering explicitly.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IUpdate WithAccessBetweenBothNetworks();
    }

    /// <summary>
    /// The stage of a network peering update allowing to control the gateway use by or on the remote network.
    /// </summary>
    public interface IWithGatewayUse
    {
        /// <summary>
        /// Allows the remote network to use this network's gateway (a.k.a. gateway transit), but does not start the use of the gateway by the remote network.
        /// If this network is currently configured to use the remote network's gateway, that use will be automatically disabled, as these two settings cannot be used together.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IUpdate WithGatewayUseByRemoteNetworkAllowed();

        /// <summary>
        /// Allows and starts the use of this network's gateway by the remote network (a.k.a. gateway transit).
        /// If the remote network is not in the same subscription as this network, then gateway use by the remote gateway will only be allowed
        /// on this network, but not started. The matching peering on the remote network must be modified explicitly to start it.
        /// If this network is currently configured to use the remote network's gateway, that use will be automatically disabled, as these two settings cannot be used together.
        /// Before gateway use by a remote network can be started, a working gateway must already be in place within this network.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IUpdate WithGatewayUseByRemoteNetworkStarted();

        /// <summary>
        /// Starts the use of the remote network's gateway.
        /// If the remote network is in the same subscription, remote gateway use by this network (a.k.a. gateway transit) will also be automatically allowed on the remote network's side.
        /// Otherwise, this network will only be configured to use the remote gateway, but the matching peering on the remote network must still be additionally modified
        /// explicitly to allow gateway use by this network.
        /// If this network is currently configured to allow the remote network to use its gateway, that use will be automatically disabled, as these two settings cannot be used together.
        /// Before gateway use on a remote network can be started, a working gateway must already be in place within the remote network.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IUpdate WithGatewayUseOnRemoteNetworkStarted();

        /// <summary>
        /// Stops this network's use of the remote network's gateway.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IUpdate WithoutGatewayUseOnRemoteNetwork();

        /// <summary>
        /// Disables any gateway use by this network and the remote one.
        /// This will have effect on the remote network only if the remote network is in the same subscription as this network.
        /// Otherwise, only this network's use of the remote network's gateway will be stopped, but the use of this network's gateway
        /// by the remote network will only be disallowed. You will have to update the remote network's peering explicitly to properly stop
        /// its use of this network's gateway.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IUpdate WithoutAnyGatewayUse();

        /// <summary>
        /// Stops and disallows the use of this network's gateway by the remote network.
        /// If the remote network is not in the same subscription, then the use of that network's gateway by this network will be stopped but not disallowed
        /// by the remote network. The matching peering on the remote network must still be explicitly updated to also disallow such use.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IUpdate WithoutGatewayUseByRemoteNetwork();
    }

    /// <summary>
    /// The template for a load balancer update operation, containing all the settings that
    /// can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.INetworkPeering>,
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IWithTrafficForwarding,
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IWithAccess,
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update.IWithGatewayUse
    {
    }
}