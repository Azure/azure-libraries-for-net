// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Stage of virtual network gateway connection update allowing to enable or disable BGP for the connection.
    /// </summary>
    public interface IWithBgp
    {
        /// <summary>
        /// Enable BGP for the connection.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update.IUpdate WithBgp();

        /// <summary>
        /// Disable BGP for the connection.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update.IUpdate WithoutBgp();
    }

    /// <summary>
    /// Grouping of virtual network gateway connection update stages.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update.IWithBgp,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update.IWithSharedKey,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update.IWithAuthorization
    {
    }

    /// <summary>
    /// Stage of virtual network gateway connection update allowing to specify shared key for the connection.
    /// </summary>
    public interface IWithSharedKey
    {
        /// <summary>
        /// Specify shared key.
        /// </summary>
        /// <param name="sharedKey">Shared key.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update.IUpdate WithSharedKey(string sharedKey);
    }

    /// <summary>
    /// Stage of virtual network gateway connection update allowing to add authorization for the connection.
    /// </summary>
    public interface IWithAuthorization
    {
        /// <summary>
        /// Specify authorization key.
        /// This is required in case of Express Route connection if Express Route circuit and virtual network gateway reside in different subscriptions.
        /// </summary>
        /// <param name="authorizationKey">Authorization key to use.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update.IUpdate WithAuthorization(string authorizationKey);
    }
}