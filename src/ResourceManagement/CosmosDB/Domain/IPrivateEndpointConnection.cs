// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;

    /// <summary>
    /// A private endpoint connection.
    /// </summary>
    public interface IPrivateEndpointConnection :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.CosmosDB.Fluent.Models.PrivateEndpointConnectionInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateEndpointConnection, Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>
    {

        /// <summary>
        /// Gets private endpoint which the connection belongs to.
        /// </summary>
        PrivateEndpointProperty PrivateEndpoint { get; }

        /// <summary>
        /// Gets connection State of the Private Endpoint Connection.
        /// </summary>
        PrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get; }
    }
}