// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Update
{
    /// <summary>
    /// The stage of the private endpoint connection update allowing to specify state.
    /// </summary>
    public interface IWithState
    {
        /// <summary>
        /// Specifies description of state property.
        /// </summary>
        /// <param name="description">The description of state property.</param>
        /// <return>The next stage of update.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Update.IUpdate WithDescription(string description);

        /// <summary>
        /// Specifies state property.
        /// </summary>
        /// <param name="property">A private link service connection state property.</param>
        /// <return>The next stage of update.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Update.IUpdate WithStateProperty(Models.PrivateLinkServiceConnectionStateProperty property);

        /// <summary>
        /// Specifies status of state property.
        /// </summary>
        /// <param name="status">The status of state property.</param>
        /// <return>The next stage of update.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Update.IUpdate WithStatus(string status);
    }

    /// <summary>
    /// The entirety of private endpoint connection update as a part of parent virtual machine update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IUpdate>,
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Update.IWithState
    {
    }
}