// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Threading;
    using System.Threading.Tasks;
    /// <summary>
    /// A Cassandra table.
    /// </summary>
    public interface ICassandraTable :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.CassandraTableGetResultsInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<ICassandraTable, ICassandraKeyspace>
    {
        /// <summary>
        /// Gets name of the Cosmos DB Cassandra table.
        /// </summary>
        string CassandraTableId { get; }

        /// <summary>
        /// Gets default time to live.
        /// </summary>
        int? DefaultTtl { get; }

        /// <summary>
        /// Gets schema of the Cosmos DB Cassandra table.
        /// </summary>
        CassandraSchema Schema { get; }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        string _rid { get; }

        /// <summary>
        /// Gets a system generated property that denotes the last updated
        /// timestamp of the resource.
        /// </summary>
        object _ts { get; }

        /// <summary>
        /// Gets a system generated property representing the resource etag
        /// required for optimistic concurrency control.
        /// </summary>
        string _etag { get; }

        /// <returns>The throughput settings of the Cassandra table.</returns>
        ThroughputSettingsGetPropertiesResource GetThroughputSettings();

        /// <returns>The throughput settings of the Cassandra table.</returns>
        Task<ThroughputSettingsGetPropertiesResource> GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}