// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    /// <summary>
    /// A Gremlin Database.
    /// </summary>
    public interface IGremlinDatabase :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.GremlinDatabaseGetResultsInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<IGremlinDatabase, ICosmosDBAccount>
    {
        /// <summary>
        /// Gets name of the Cosmos DB Gremlin Database.
        /// </summary>
        string GremlinDatabaseId { get; }

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

        /// <returns>The throughput settings of the Gremlin Database.</returns>
        ThroughputSettingsGetPropertiesResource GetThroughputSettings();

        /// <returns>The throughput settings of the Gremlin Database.</returns>
        Task<ThroughputSettingsGetPropertiesResource> GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <returns>All Gremlin Graphs in the DB.</returns>
        IEnumerable<IGremlinGraph> ListGremlinGraphs();

        /// <returns>All Gremlin Graphs in the DB.</returns>
        Task<IEnumerable<IGremlinGraph>> ListGremlinGraphsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="name">The name of the Gremlin Graph.</param>
        /// <returns>The specific Gremlin Graph.</returns>
        IGremlinGraph GetGremlinGraph(string name);

        /// <param name="name">The name of the Gremlin Graph.</param>
        /// <returns>The specific Gremlin Graph.</returns>
        Task<IGremlinGraph> GetGremlinGraphAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}
