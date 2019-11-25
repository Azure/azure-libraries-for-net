// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;

    internal partial class PrivateEndpointConnectionImpl
    {
        /// <summary>
        /// Gets private endpoint which the connection belongs to.
        /// </summary>
        /// <summary>
        /// Gets the privateEndpoint value.
        /// </summary>
        PrivateEndpointProperty Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateEndpointConnection.PrivateEndpoint
        {
            get
            {
                return this.PrivateEndpoint();
            }
        }

        /// <summary>
        /// Gets connection State of the Private Endpoint Connection.
        /// </summary>
        /// <summary>
        /// Gets the privateLinkServiceConnectionState value.
        /// </summary>
        PrivateLinkServiceConnectionStateProperty Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateEndpointConnection.PrivateLinkServiceConnectionState
        {
            get
            {
                return this.PrivateLinkServiceConnectionState();
            }
        }

        /// <summary>
        /// Specifies description of state property.
        /// </summary>
        /// <param name="description">The description of state property.</param>
        /// <return>The next stage of update.</return>
        PrivateEndpointConnection.Update.IUpdate PrivateEndpointConnection.Update.IWithState.WithDescription(string description)
        {
            return this.WithDescription(description);
        }

        /// <summary>
        /// Specifies description of state property.
        /// </summary>
        /// <param name="description">The description of state property.</param>
        /// <return>The next stage of definition.</return>
        PrivateEndpointConnection.UpdateDefinition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> PrivateEndpointConnection.UpdateDefinition.IWithState<CosmosDBAccount.Update.IWithOptionals>.WithDescription(string description)
        {
            return this.WithDescription(description);
        }

        /// <summary>
        /// Specifies description of state property.
        /// </summary>
        /// <param name="description">The description of state property.</param>
        /// <return>The next stage of definition.</return>
        PrivateEndpointConnection.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> PrivateEndpointConnection.Definition.IWithState<CosmosDBAccount.Definition.IWithCreate>.WithDescription(string description)
        {
            return this.WithDescription(description);
        }

        /// <summary>
        /// Specifies state property.
        /// </summary>
        /// <param name="property">A private link service connection state property.</param>
        /// <return>The next stage of update.</return>
        PrivateEndpointConnection.Update.IUpdate PrivateEndpointConnection.Update.IWithState.WithStateProperty(PrivateLinkServiceConnectionStateProperty property)
        {
            return this.WithStateProperty(property);
        }

        /// <summary>
        /// Specifies state property.
        /// </summary>
        /// <param name="property">A private link service connection state property.</param>
        /// <return>The next stage of definition.</return>
        PrivateEndpointConnection.UpdateDefinition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> PrivateEndpointConnection.UpdateDefinition.IWithState<CosmosDBAccount.Update.IWithOptionals>.WithStateProperty(PrivateLinkServiceConnectionStateProperty property)
        {
            return this.WithStateProperty(property);
        }

        /// <summary>
        /// Specifies state property.
        /// </summary>
        /// <param name="property">A private link service connection state property.</param>
        /// <return>The next stage of definition.</return>
        PrivateEndpointConnection.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> PrivateEndpointConnection.Definition.IWithState<CosmosDBAccount.Definition.IWithCreate>.WithStateProperty(PrivateLinkServiceConnectionStateProperty property)
        {
            return this.WithStateProperty(property);
        }

        /// <summary>
        /// Specifies status of state property.
        /// </summary>
        /// <param name="status">The status of state property.</param>
        /// <return>The next stage of update.</return>
        PrivateEndpointConnection.Update.IUpdate PrivateEndpointConnection.Update.IWithState.WithStatus(string status)
        {
            return this.WithStatus(status);
        }

        /// <summary>
        /// Specifies status of state property.
        /// </summary>
        /// <param name="status">The status of state property.</param>
        /// <return>The next stage of definition.</return>
        PrivateEndpointConnection.UpdateDefinition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> PrivateEndpointConnection.UpdateDefinition.IWithState<CosmosDBAccount.Update.IWithOptionals>.WithStatus(string status)
        {
            return this.WithStatus(status);
        }

        /// <summary>
        /// Specifies status of state property.
        /// </summary>
        /// <param name="status">The status of state property.</param>
        /// <return>The next stage of definition.</return>
        PrivateEndpointConnection.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> PrivateEndpointConnection.Definition.IWithState<CosmosDBAccount.Definition.IWithCreate>.WithStatus(string status)
        {
            return this.WithStatus(status);
        }
    }
}