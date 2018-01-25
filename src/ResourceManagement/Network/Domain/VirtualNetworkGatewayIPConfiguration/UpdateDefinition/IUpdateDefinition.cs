// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.UpdateDefinition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The first stage of a virtual network gateway IP configuration definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>
    {
    }

    /// <summary>
    /// The entirety of an application gateway IP configuration definition as part of a virtual network gateway update.
    /// </summary>
    /// <typeparam name="ParentT">The parent type.</typeparam>
    public interface IUpdateDefinition<ParentT> :
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of a virtual network gateway IP configuration definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>
    {
    }
}