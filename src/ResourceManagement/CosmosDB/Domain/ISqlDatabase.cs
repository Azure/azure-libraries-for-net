// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    /// <summary>
    /// A SQL database.
    /// </summary>
    public interface ISqlDatabase :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SqlDatabaseGetResultsInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<ISqlDatabase, ICosmosDBAccount>
    {
        /// <summary>
        /// Gets name of the Cosmos DB SQL database.
        /// </summary>
        string SqlDatabaseId { get; }

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

        /// <summary>
        /// Gets a system generated property that specified the
        /// addressable path of the collections resource.
        /// </summary>
        string _colls { get; }

        /// <summary>
        /// Gets a system generated property that specifies the
        /// addressable path of the users resource.
        /// </summary>
        string _users { get; }

        /// <returns>The throughput settings of the SQL database.</returns>
        ThroughputSettingsGetPropertiesResource GetThroughputSettings();

        /// <returns>The throughput settings of the SQL database.</returns>
        Task<ThroughputSettingsGetPropertiesResource> GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <returns>All SQL containers in the DB.</returns>
        IEnumerable<ISqlContainer> ListSqlContainers();

        /// <returns>All SQL containers in the DB.</returns>
        Task<IEnumerable<ISqlContainer>> ListSqlContainersAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="name">The name of the SQL container.</param>
        /// <returns>The specific SQL container.</returns>
        ISqlContainer GetSqlContainer(string name);

        /// <param name="name">The name of the SQL container.</param>
        /// <returns>The specific SQL container.</returns>
        Task<ISqlContainer> GetSqlContainerAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}
