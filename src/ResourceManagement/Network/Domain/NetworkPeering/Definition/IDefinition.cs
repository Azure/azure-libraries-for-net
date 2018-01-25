// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of a network peering definition with sufficient inputs to create a new
    /// network peering in the cloud, but exposing additional optional settings to
    /// specify.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkPeering>,
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithGatewayUse,
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithTrafficForwarding,
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithAccess
    {
    }

    /// <summary>
    /// The first stage of a network peering definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithRemoteNetwork
    {
    }

    /// <summary>
    /// The entirety of the network peering definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithCreate,
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithRemoteNetwork
    {
    }

    /// <summary>
    /// The stage of a network peering definition allowing to specify the remote virtual network.
    /// </summary>
    public interface IWithRemoteNetwork
    {
        /// <summary>
        /// Specifies the remote network to peer with.
        /// The remote network will have the matching peering associated with it automatically.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithCreate WithRemoteNetwork(string resourceId);

        /// <summary>
        /// Specifies the remote network to peer with.
        /// The remote network will have the matching peering associated with it automatically.
        /// </summary>
        /// <param name="network">An existing network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithCreate WithRemoteNetwork(INetwork network);
    }

    /// <summary>
    /// The stage of a network peering definition allowing to control traffic forwarding from or to the remote network.
    /// </summary>
    public interface IWithTrafficForwarding
    {
        /// <summary>
        /// Allows traffic forwarded from the remote network.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithCreate WithTrafficForwardingFromRemoteNetwork();

        /// <summary>
        /// Allows traffic forwarding both from either peered network into the other.
        /// This setting will have effect on the remote network only if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding traffic forwarding setting on the remote network's matching peering explicitly.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithCreate WithTrafficForwardingBetweenBothNetworks();

        /// <summary>
        /// Allows traffic forwarding from this network to the remote network.
        /// This setting will have effect only if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding traffic forwarding setting on the remote network's matching peering explicitly.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithCreate WithTrafficForwardingToRemoteNetwork();
    }

    /// <summary>
    /// The stage of a network peering definition allowing to control the gateway use by or on the remote network.
    /// </summary>
    public interface IWithGatewayUse
    {
        /// <summary>
        /// Allows the remote network to use this network's gateway (a.k.a. gateway transit), but does not start the use of the gateway by the remote network.
        /// If this network is currently configured to use the remote network's gateway, that use will be automatically disabled, as these two settings cannot be used together.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithCreate WithGatewayUseByRemoteNetworkAllowed();

        /// <summary>
        /// Allows and starts the use of this network's gateway by the remote network (a.k.a. gateway transit).
        /// If the remote network is not in the same subscription as this network, then gateway use by the remote gateway will only be
        /// allowed on this network, but not started. The matching peering on the remote network must be modified explicitly to start it.
        /// If this network is currently configured to use the remote network's gateway, that use will be automatically disabled, as these two settings cannot be used together.
        /// Before gateway use by a remote network can be started, a working gateway must already be in place within this network.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithCreate WithGatewayUseByRemoteNetworkStarted();

        /// <summary>
        /// Starts the use of the remote network's gateway.
        /// If the remote network is in the same subscription, remote gateway use by this network (a.k.a. gateway transit) will also be automatically allowed on the remote network's side.
        /// Otherwise, this network will only be configured to use the remote gateway, but the matching peering on the remote network must still be additionally modified
        /// explicitly to allow gateway use by this network.
        /// If this network is currently configured to allow the remote network to use its gateway, that use will be automatically disabled, as these two settings cannot be used together.
        /// Before gateway use on a remote network can be started, a working gateway must already be in place within the remote network.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithCreate WithGatewayUseOnRemoteNetworkStarted();

        /// <summary>
        /// Disables any gateway use by this network and the remote one.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithCreate WithoutAnyGatewayUse();
    }

    /// <summary>
    /// The stage of a network peering definition allowing to control access from and to the remote network.
    /// </summary>
    public interface IWithAccess
    {
        /// <summary>
        /// Disallows access to either peered network from the other.
        /// This setting will have effect on the remote network only if the remote network is in the same subscription. Otherwise, it will be ignored and you need to change
        /// the corresponding access setting on the remote network's matching peering explicitly.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition.IWithCreate WithoutAccessFromEitherNetwork();
    }
}