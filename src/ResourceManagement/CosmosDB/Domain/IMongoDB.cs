// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    /// <summary>
    /// A Mongo DB.
    /// </summary>
    public interface IMongoDB :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.MongoDBDatabaseGetResultsInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<IMongoDB, ICosmosDBAccount>
    {
        /// <summary>
        /// Gets name of the Cosmos DB Mongo DB.
        /// </summary>
        string MongoDBId { get; }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        string _rid { get; }

        /// <summary>
        /// Gets a system generated property that denotes the last
        /// updated timestamp of the resource.
        /// </summary>
        object _ts { get; }

        /// <summary>
        /// Gets a system generated property representing the resource
        /// etag required for optimistic concurrency control.
        /// </summary>
        string _etag { get; }

        /// <returns>The throughput settings of the Mongo DB.</returns>
        ThroughputSettingsGetPropertiesResource GetThroughputSettings();

        /// <returns>The throughput settings of the Mongo DB.</returns>
        Task<ThroughputSettingsGetPropertiesResource> GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <returns>All Mongo Collections in the DB.</returns>
        IEnumerable<IMongoCollection> ListCollections();

        /// <returns>All Mongo Collections in the DB.</returns>
        Task<IEnumerable<IMongoCollection>> ListCollectionsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="name">The name of the Mongo Collection.</param>
        /// <returns>The specific Mongo Collection.</returns>
        IMongoCollection GetCollection(string name);

        /// <param name="name">The name of the Mongo Collection.</param>
        /// <returns>The specific Mongo Collection.</returns>
        Task<IMongoCollection> GetCollectionAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}
