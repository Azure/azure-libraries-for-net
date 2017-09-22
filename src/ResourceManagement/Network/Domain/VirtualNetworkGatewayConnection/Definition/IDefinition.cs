// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    public interface IBlank  :
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithConnectionType
    {
    }

    public interface IWithBgp 
    {
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithCreate WithBgp();
    }

    public interface IWithSharedKey 
    {
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithCreate WithSharedKey(string sharedKey);
    }

    public interface IWithSecondVirtualNetworkGateway 
    {
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithSharedKey WithSecondVirtualNetworkGateway(IVirtualNetworkGateway virtualNetworkGateway2);
    }

    public interface IWithExpressRoute 
    {
    }

    public interface IWithLocalNetworkGateway 
    {
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithSharedKey WithLocalNetworkGateway(ILocalNetworkGateway localNetworkGateway);
    }

    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithCreate>,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithBgp
    {
    }

    public interface IWithConnectionType 
    {
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithExpressRoute WithExpressRoute();

        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithSecondVirtualNetworkGateway WithVNetToVNet();

        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithLocalNetworkGateway WithSiteToSite();
    }

    /// <summary>
    /// The entirety of the virtual network gateway connection definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithConnectionType,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithLocalNetworkGateway,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithSecondVirtualNetworkGateway,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithExpressRoute,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithSharedKey,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition.IWithCreate
    {
    }
}