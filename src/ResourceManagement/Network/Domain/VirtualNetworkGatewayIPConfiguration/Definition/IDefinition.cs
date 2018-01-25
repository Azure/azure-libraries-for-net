// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.Definition
{
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The entirety of virtual network gateway IP configuration definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT> :
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.Definition.IWithPublicIPAddress<ParentT>
    {
    }

    /// <summary>
    /// The stage of virtual network gateway frontend definition allowing to specify an existing public IP address to make
    /// the virtual network gateway available at as Internet-facing.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent virtual network gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithPublicIPAddress<ParentT> :
        Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition.IWithExistingPublicIPAddress<Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithCreate>>
    {
    }

    /// <summary>
    /// The first stage of an virtual network gateway IP configuration definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.Definition.IWithSubnet<ParentT>
    {
    }

    /// <summary>
    /// The stage of virtual network gateway IP configuration definition allowing to specify the subnet the virtual network gateway is on.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the virtual network gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithSubnet<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Definition.IWithSubnet<Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithCreate>>
    {
        /// <summary>
        /// Specifies an existing subnet the virtual network gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.Definition.IWithAttach<ParentT> WithExistingSubnet(ISubnet subnet);

        /// <summary>
        /// Specifies an existing subnet the virtual network gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The name of a subnet within the selected network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.Definition.IWithAttach<ParentT> WithExistingSubnet(INetwork network, string subnetName);
    }

    /// <summary>
    /// The final stage of the virtual network gateway IP configuration definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent virtual network gateway definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }
}