// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure Cosmos DB.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface ICosmosDBAccount :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBManager, Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountGetResultsInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<CosmosDBAccount.Update.IUpdate>
    {
        /// <summary>
        /// Gets an array that contains the writable georeplication locations enabled for the CosmosDB account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> WritableReplications { get; }

        /// <summary>
        /// Gets the default consistency level for the CosmosDB database account.
        /// </summary>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.DefaultConsistencyLevel DefaultConsistencyLevel { get; }

        /// <return>The connection strings for the specified Azure CosmosDB database account.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListConnectionStringsResult ListConnectionStrings();

        /// <return>The access keys for the specified Azure CosmosDB database account.</return>
        Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListKeysResult> ListKeysAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets specifies the set of IP addresses or IP address ranges in CIDR form.
        /// </summary>
        string IPRangeFilter { get; }

        /// <return>The access keys for the specified Azure CosmosDB database account.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListKeysResult ListKeys();

        /// <summary>
        /// Gets the consistency policy for the CosmosDB database account.
        /// </summary>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.ConsistencyPolicy ConsistencyPolicy { get; }

        /// <summary>
        /// Gets whether cassandra connector is enabled or not.
        /// </summary>
        bool CassandraConnectorEnabled { get; }

        /// <summary>
        /// Gets the current cassandra connector offer.
        /// </summary>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.ConnectorOffer CassandraConnectorOffer { get; }

        /// <summary>
        /// Gets indicates the type of database account.
        /// </summary>
        string Kind { get; }

        /// <summary>
        /// Gets whether write is enabled for multiple locations or not
        /// </summary>
        bool? MultipleWriteLocationsEnabled { get; }

        /// <summary>
        /// Gets a list that contains the Cosmos DB capabilities.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.Capability> Capabilities { get; }

        /// <summary>
        /// Gets the connection endpoint for the CosmosDB database account.
        /// </summary>
        string DocumentEndpoint { get; }

        /// <summary>
        /// Gets an array that contains the readable georeplication locations enabled for the CosmosDB account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> ReadableReplications { get; }

        /// <summary>
        /// Gets the offer type for the CosmosDB database account.
        /// </summary>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountOfferType DatabaseAccountOfferType { get; }

        /// <summary>
        /// Gets whether metadata write access is disabled or not.
        /// </summary>
        bool KeyBasedMetadataWriteAccessDisabled { get; }

        /// <summary>
        /// Gets the key vault identifier linked to the CosmosDB account.
        /// </summary>
        string KeyVaultUri { get; }

        /// <summary>
        /// Gets whether automatic failover is enabled or not.
        /// </summary>
        bool AutomaticFailoverEnabled { get; }

        /// <summary>
        /// Gets whether virtual network filter is enabled or not.
        /// </summary>
        bool VirtualNetoworkFilterEnabled { get; }

        /// <param name="keyKind">The key kind.</param>
        /// <return>The ServiceResponse object if successful.</return>
        Task RegenerateKeyAsync(string keyKind, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The connection strings for the specified Azure CosmosDB database account.</return>
        Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListConnectionStringsResult> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a list that contains the Cosmos DB Virtual Network ACL Rules (empty list if none is set).
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.VirtualNetworkRule> VirtualNetworkRules { get; }

        /// <param name="name">Name of private endpoint connection.</param>
        /// <return>The specific private endpoint connection.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateEndpointConnection GetPrivateEndpointConnection(string name);

        /// <param name="name">Name of private endpoint connection.</param>
        /// <return>The specific private endpoint connection.</return>
        Task<Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateEndpointConnection> GetPrivateEndpointConnectionAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="groupName">Group name of private link resource.</param>
        /// <return>The specific private link resource group.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateLinkResource GetPrivateLinkResource(string groupName);

        /// <param name="groupName">Group name of private link resource.</param>
        /// <return>The specific private link resource group.</return>
        Task<Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateLinkResource> GetPrivateLinkResourceAsync(string groupName, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="databaseName">Database name of SQL database.</param>
        /// <returns>The specific SQL database.</returns>
        ISqlDatabase GetSqlDatabase(string databaseName);

        /// <param name="databaseName">Database name of SQL database.</param>
        /// <returns>The specific SQL database.</returns>
        Task<ISqlDatabase> GetSqlDatabaseAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The read-only access keys for the specified Azure CosmosDB database account.</return>
        Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListReadOnlyKeysResult> ListReadOnlyKeysAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The read-only access keys for the specified Azure CosmosDB database account.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListReadOnlyKeysResult ListReadOnlyKeys();

        /// <return>The SQL databases for the specified Azure CosmosDB database account.</return>
        IEnumerable<ISqlDatabase> ListSqlDatabases();

        /// <return>The SQL databases for the specified Azure CosmosDB database account.</return>
        Task<IEnumerable<ISqlDatabase>> ListSqlDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>All private endpoint connection in the account.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateEndpointConnection> ListPrivateEndpointConnection();

        /// <return>All private endpoint connection in the account.</return>
        Task<System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateEndpointConnection>> ListPrivateEndpointConnectionAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>All private link resources in the account.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateLinkResource> ListPrivateLinkResources();

        /// <return>All private link resources in the account.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateLinkResource>> ListPrivateLinkResourcesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// It takes offline the specified region for the current Azure Cosmos DB database account.
        /// </summary>
        /// <param name="region">Cosmos DB region.</param>
        void OfflineRegion(Region region);

        /// <summary>
        /// Asynchronously it takes offline the specified region for the current Azure Cosmos DB database account.
        /// </summary>
        /// <param name="region">Cosmos DB region.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task OfflineRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// It brings online the specified region for the current Azure Cosmos DB database account.
        /// </summary>
        /// <param name="region">Cosmos DB region.</param>
        void OnlineRegion(Region region);

        /// <summary>
        /// Asynchronously it brings online the specified region for the current Azure Cosmos DB database account.
        /// </summary>
        /// <param name="region">Cosmos DB region.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task OnlineRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="keyKind">The key kind.</param>
        void RegenerateKey(string keyKind);

        /// <param name="databaseName">Database name of Mongo database.</param>
        /// <returns>The specific Mongo database.</returns>
        IMongoDB GetMongoDB(string databaseName);

        /// <param name="databaseName">Database name of Mongo database.</param>
        /// <returns>The specific Mongo database.</returns>
        Task<IMongoDB> GetMongoDBAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The Mongo databases for the specified Azure CosmosDB database account.</return>
        IEnumerable<IMongoDB> ListMongoDBs();

        /// <return>The Mongo databases for the specified Azure CosmosDB database account.</return>
        Task<IEnumerable<IMongoDB>> ListMongoDBsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="name">The name of Cassandra keyspace.</param>
        /// <returns>The specific Cassandra keyspace.</returns>
        ICassandraKeyspace GetCassandraKeyspace(string name);

        /// <param name="name">The name of Cassandra keyspace.</param>
        /// <returns>The specific Cassandra keyspace.</returns>
        Task<ICassandraKeyspace> GetCassandraKeyspaceAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The Cassandra keyspaces for the specified Azure CosmosDB database account.</return>
        IEnumerable<ICassandraKeyspace> ListCassandraKeyspaces();

        /// <return>The Cassandra keyspaces for the specified Azure CosmosDB database account.</return>
        Task<IEnumerable<ICassandraKeyspace>> ListCassandraKeyspacesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="name">The name of Gremlin Database.</param>
        /// <returns>The specific Gremlin Database.</returns>
        IGremlinDatabase GetGremlinDatabase(string name);

        /// <param name="name">The name of Gremlin Database.</param>
        /// <returns>The specific Gremlin Database.</returns>
        Task<IGremlinDatabase> GetGremlinDatabaseAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The Gremlin Databases for the specified Azure CosmosDB database account.</return>
        IEnumerable<IGremlinDatabase> ListGremlinDatabases();

        /// <return>The Gremlin Databases for the specified Azure CosmosDB database account.</return>
        Task<IEnumerable<IGremlinDatabase>> ListGremlinDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="name">The name of Table Database.</param>
        /// <returns>The specific Table Database.</returns>
        ITable GetTable(string name);

        /// <param name="name">The name of Table Database.</param>
        /// <returns>The specific Table Database.</returns>
        Task<ITable> GetTableAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The Table Databases for the specified Azure CosmosDB database account.</return>
        IEnumerable<ITable> ListTables();

        /// <return>The Table Databases for the specified Azure CosmosDB database account.</return>
        Task<IEnumerable<ITable>> ListTablesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}