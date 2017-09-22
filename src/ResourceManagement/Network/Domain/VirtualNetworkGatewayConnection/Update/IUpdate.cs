// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update
{
    public interface IWithBgp 
    {
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update.IUpdate WithBgp();

        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update.IUpdate WithoutBgp();
    }

    public interface IWithSharedKey 
    {
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update.IUpdate WithSharedKey(string sharedKey);
    }

    /// <summary>
    /// Grouping of virtual network gateway connection update stages.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update.IWithBgp,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update.IWithSharedKey
    {
    }
}