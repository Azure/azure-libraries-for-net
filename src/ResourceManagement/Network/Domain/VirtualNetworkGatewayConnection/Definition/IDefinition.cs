// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Stage of definition allowing to enable BGP for the connection.
    /// </summary>
    public interface IWithBgp
    {
        /// <summary>
        /// Enable BGP for the connection.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithCreate WithBgp();
    }

    /// <summary>
    /// Stage of definition allowing to add authorization for the connection.
    /// </summary>
    public interface IWithAuthorization
    {
        /// <summary>
        /// Specify authorization key.
        /// This is required in case of Express Route connection if Express Route circuit and virtual network gateway reside in different subscriptions.
        /// </summary>
        /// <param name="authorizationKey">Authorization key to use.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithCreate WithAuthorization(string authorizationKey);
    }

    /// <summary>
    /// Stage of definition allowing to specify shared key for the connection.
    /// </summary>
    public interface IWithSharedKey
    {
        /// <summary>
        /// Specify shared key.
        /// </summary>
        /// <param name="sharedKey">Shared key.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithCreate WithSharedKey(string sharedKey);
    }

    /// <summary>
    /// The first stage of virtual network gateway connection definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithConnectionType
    {
    }

    /// <summary>
    /// The stage of a virtual network gateway connection definition with sufficient inputs to create a new connection in the cloud,
    /// but exposing additional optional settings to specify.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithCreate>,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithBgp,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithAuthorization
    {
    }

    /// <summary>
    /// The entirety of the virtual network gateway connection definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithConnectionType,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithLocalNetworkGateway,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithSecondVirtualNetworkGateway,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithSharedKey,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithAuthorization,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithCreate
    {
    }

    /// <summary>
    /// Stage of definition allowing to specify local network gateway to connect to.
    /// </summary>
    public interface IWithLocalNetworkGateway
    {
        /// <param name="localNetworkGateway">Local network gateway to connect to.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithSharedKey WithLocalNetworkGateway(ILocalNetworkGateway localNetworkGateway);
    }

    /// <summary>
    /// Stage of definition allowing to specify virtual network gateway to connect to.
    /// </summary>
    public interface IWithSecondVirtualNetworkGateway
    {
        /// <param name="virtualNetworkGateway2">Virtual network gateway to connect to.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithSharedKey WithSecondVirtualNetworkGateway(IVirtualNetworkGateway virtualNetworkGateway2);
    }

    /// <summary>
    /// Stage of definition allowing to specify connection type.
    /// </summary>
    public interface IWithConnectionType
    {
        /// <summary>
        /// Create Express Route connection.
        /// </summary>
        /// <param name="circuitId">Id of Express Route circuit used for connection.</param>
        /// <return>Next stage of definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithCreate WithExpressRoute(string circuitId);

        /// <summary>
        /// Create Express Route connection.
        /// </summary>
        /// <param name="circuit">Express Route circuit used for connection.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithCreate WithExpressRoute(IExpressRouteCircuit circuit);

        /// <summary>
        /// Create VNet-to-VNet connection.
        /// </summary>
        /// <return>The next stage of the definition, allowing to specify virtual network gateway to connect to.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithSecondVirtualNetworkGateway WithVNetToVNet();

        /// <summary>
        /// Create Site-to-Site connection.
        /// </summary>
        /// <return>Next stage of definition, allowing to specify local network gateway.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithLocalNetworkGateway WithSiteToSite();
    }
}