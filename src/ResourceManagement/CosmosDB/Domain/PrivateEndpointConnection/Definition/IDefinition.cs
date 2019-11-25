// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Definition
{
    /// <summary>
    /// The stage of the private endpoint connection definition allowing to set state.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithState<ParentT>
    {
        /// <summary>
        /// Specifies description of state property.
        /// </summary>
        /// <param name="description">The description of state property.</param>
        /// <return>The next stage of definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Definition.IWithAttach<ParentT> WithDescription(string description);

        /// <summary>
        /// Specifies state property.
        /// </summary>
        /// <param name="property">A private link service connection state property.</param>
        /// <return>The next stage of definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Definition.IWithAttach<ParentT> WithStateProperty(Models.PrivateLinkServiceConnectionStateProperty property);

        /// <summary>
        /// Specifies status of state property.
        /// </summary>
        /// <param name="status">The status of state property.</param>
        /// <return>The next stage of definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Definition.IWithAttach<ParentT> WithStatus(string status);
    }

    /// <summary>
    /// The final stage of the private endpoint connection definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Definition.IWithState<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a private endpoint connection definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Definition.IWithState<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a private endpoint connection definition as a part of parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT> :
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Definition.IWithState<ParentT>,
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Definition.IWithAttach<ParentT>
    {
    }
}