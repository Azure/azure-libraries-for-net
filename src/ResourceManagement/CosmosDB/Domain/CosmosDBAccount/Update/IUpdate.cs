// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update
{
    using Microsoft.Azure.Management.CosmosDB.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;

    /// <summary>
    /// The stage of the cosmos db update allowing to set the consistency policy.
    /// </summary>
    public interface IWithConsistencyPolicy
    {
        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <param name="maxStalenessPrefix">The max staleness prefix.</param>
        /// <param name="maxIntervalInSeconds">The max interval in seconds.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithBoundedStalenessConsistency(int maxStalenessPrefix, int maxIntervalInSeconds);

        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithStrongConsistency();

        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithEventualConsistency();

        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithSessionConsistency();
    }

    /// <summary>
    /// The stage of the Cosmos DB update definition allowing the definition of a Virtual Network ACL Rule.
    /// </summary>
    public interface IWithVirtualNetworkRule :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Removes a Virtual Network ACL Rule for the CosmosDB account.
        /// </summary>
        /// <param name="virtualNetworkId">The ID of a virtual network.</param>
        /// <param name="subnetName">
        /// The name of the subnet within the virtual network; the subnet must have the service
        /// endpoints enabled for 'Microsoft.AzureCosmosDB'.
        /// </param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithoutVirtualNetworkRule(string virtualNetworkId, string subnetName);

        /// <summary>
        /// Specifies a new Virtual Network ACL Rule for the CosmosDB account.
        /// </summary>
        /// <param name="virtualNetworkId">The ID of a virtual network.</param>
        /// <param name="subnetName">
        /// The name of the subnet within the virtual network; the subnet must have the service
        /// endpoints enabled for 'Microsoft.AzureCosmosDB'.
        /// </param>
        /// <param name="ignoreMissingVNetServiceEndpoint">The boolean decides to ignore missing endpoint or not.</param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithVirtualNetworkRule(string virtualNetworkId, string subnetName, bool? ignoreMissingVNetServiceEndpoint = default(bool?));

        /// <summary>
        /// Specifies Virtual Network Fileter manually.
        /// </summary>
        /// <param name="enable">The fileter is enabled or not.</param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithVirtualNetworkFilterEnabled(bool enable);

        /// <summary>
        /// A Virtual Network ACL Rule for the CosmosDB account.
        /// </summary>
        /// <param name="virtualNetworkRules">
        /// The list of Virtual Network ACL Rules (an empty list value
        /// will remove all the rules).
        /// </param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithVirtualNetworkRules(IList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.VirtualNetworkRule> virtualNetworkRules);
    }

    /// <summary>
    /// The stage of the cosmos db update definition allowing to set the IP range filter.
    /// </summary>
    public interface IWithIpRangeFilter
    {
        /// <summary>
        /// CosmosDB Firewall Support: This value specifies the set of IP addresses or IP address ranges in CIDR
        /// form to be included as the allowed list of client IPs for a given database account. IP addresses/ranges
        /// must be comma separated and must not contain any spaces.
        /// </summary>
        /// <param name="ipRangeFilter">Specifies the set of IP addresses or IP address ranges.</param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithIpRangeFilter(string ipRangeFilter);
    }

    /// <summary>
    /// The stage of the cosmos db update allowing to specify metadata write access.
    /// </summary>
    public interface IWithKeyBasedMetadataWriteAccess
    {
        /// <summary>
        /// Specifies whether metadata write access should be disabled.
        /// </summary>
        /// <param name="disabled">Whether metadata write access is disabled or not.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithDisableKeyBaseMetadataWriteAccess(bool disabled);
    }

    /// <summary>
    /// The stage of the cosmos db update definition allowing to specify whether multiple write locations are enabled or not.
    /// </summary>
    public interface IWithMultipleLocations
    {
        /// <summary>
        /// Specifies whether multiple write locations are enabled or not for this cosmos db account.
        /// </summary>
        /// <param name="enabled">Whether multiple write locations are enabled or not for this cosmos db account.</param>
        /// <returns>The next stage of the update definition.</returns>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithMultipleWriteLocationsEnabled(bool enabled);
    }

    /// <summary>
    /// The stage of the cosmos db update allowing to specify cassandra connector offer.
    /// </summary>
    public interface IWithConnector
    {
        /// <summary>
        /// Specifies a connector offer for cassandra connector.
        /// </summary>
        /// <param name="connectorOffer">Connector offer to specify.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithCassandraConnector(ConnectorOffer connectorOffer);

        /// <summary>
        /// Remove the connector offer.
        /// </summary>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithoutCassandraConnector();
    }

    /// <summary>
    /// Grouping of cosmos db update stages.
    /// </summary>
    public interface IWithOptionals :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithConsistencyPolicy,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithVirtualNetworkRule,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithIpRangeFilter,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithConnector,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithMultipleLocations,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithKeyBasedMetadataWriteAccess,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithPrivateEndpointConnection,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithAutomaticFailover,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithKeyVault,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithChildResource
    {
    }

    /// <summary>
    /// Grouping of cosmos db update stages.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithReadLocations,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithWriteReplication,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals
    {
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing the definition of a read location.
    /// </summary>
    public interface IWithReadLocations :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>
    {
        /// <summary>
        /// Sets a read location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <param name="isZoneRedundant">Flag to indicate whether or not this region is an AvailabilityZone region.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithReadLocations WithReadReplication(Region region, bool? isZoneRedundant = default(bool?));

        /// <summary>
        /// Removes a read location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithReadLocations WithoutReadReplication(Region region);

        /// <summary>
        /// Removes all replications for the CosmosDB account.
        /// </summary>
        /// <returns>The next stage.</returns>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithWriteReplication WithoutAllReplications();
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing the definition of a write location.
    /// </summary>
    public interface IWithWriteReplication
    {
        /// <summary>
        /// Sets a write location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <param name="isZoneRedundant">Flag to indicate whether or not this region is an AvailabilityZone region.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithReadLocations WithWriteReplication(Region region, bool? isZoneRedundant = default(bool?));

        /// <summary>
        /// Sets the write location same as the CosmosDB account location.
        /// </summary>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithReadLocations WithDefaultWriteReplication();
    }

    /// <summary>
    /// The stage of the cosmos db update allowing to specify private endpoint connection.
    /// </summary>
    public interface IWithPrivateEndpointConnection
    {
        /// <summary>
        /// Start the definition of a private endpoint connection to be attached
        /// to the cosmos db account.
        /// </summary>
        /// <param name="name">The reference name for the private endpoint connection.</param>
        /// <return>The first stage of a private endpoint connection definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.UpdateDefinition.IBlank<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals> DefineNewPrivateEndpointConnection(string name);

        /// <summary>
        /// Start the update of an existing private endpoint connection.
        /// </summary>
        /// <param name="name">The reference name for the private endpoint connection.</param>
        /// <return>The first stage of a private endpoint connection update.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Update.IUpdate UpdatePrivateEndpointConnection(string name);

        /// <summary>
        /// Remove an existing private endpoint connection.
        /// </summary>
        /// <param name="name">The reference name for the private endpoint connection.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithoutPrivateEndpointConnection(string name);
    }

    /// <summary>
    /// The stage of the cosmos db update allowing to set the automatic failover.
    /// </summary>
    public interface IWithAutomaticFailover
    {
        /// <summary>
        /// Specifies whether automatic failover is enabled for this cosmos db account.
        /// </summary>
        /// <param name="enabled">Whether automatic failover is enabled or not.</param>
        /// <returns>The next stage of the update.</returns>
        IWithOptionals WithAutomaticFailoverEnabled(bool enabled);
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing to specify a key vault.
    /// </summary>
    public interface IWithKeyVault
    {
        /// <summary>
        /// Specifies a key vault uri for this cosmos db account.
        /// </summary>
        /// <param name="keyVaultUri">The uri of the key vault.</param>
        /// <returns>The next stage of the update.</returns>
        IWithOptionals WithKeyVault(string keyVaultUri);

        /// <summary>
        /// Removes the key vault.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IWithOptionals WithoutKeyVault();
    }

    /// <summary>
    /// The stage of the cosmos db update allowing to set child resources.
    /// </summary>
    public interface IWithChildResource
    {
        /// <summary>
        /// Defines a new SQL database.
        /// </summary>
        /// <param name="name">The name of SQL database.</param>
        /// <returns>The next stage of the update.</returns>
        SqlDatabase.Definition.IBlank<IWithOptionals> DefineNewSqlDatabase(string name);

        /// <summary>
        /// Updates a SQL database.
        /// </summary>
        /// <param name="name">The name of SQL database.</param>
        /// <returns>The next stage of the update.</returns>
        SqlDatabase.Update.IUpdate UpdateSqlDatabase(string name);

        /// <summary>
        /// Removes a SQL database.
        /// </summary>
        /// <param name="name">The name of SQL database.</param>
        /// <returns>The next stage of the update.</returns>
        IWithOptionals WithoutSqlDatabase(string name);

        /// <summary>
        /// Defines a new Mongo database.
        /// </summary>
        /// <param name="name">The name of Mongo database.</param>
        /// <returns>The next stage of the update.</returns>
        MongoDB.Definition.IBlank<IWithOptionals> DefineNewMongoDB(string name);

        /// <summary>
        /// Updates a Mongo database.
        /// </summary>
        /// <param name="name">The name of Mongo database.</param>
        /// <returns>The next stage of the update.</returns>
        MongoDB.Update.IUpdate UpdateMongoDB(string name);

        /// <summary>
        /// Removes a Mongo database.
        /// </summary>
        /// <param name="name">The name of Mongo database.</param>
        /// <returns>The next stage of the update.</returns>
        IWithOptionals WithoutMongoDB(string name);

        /// <summary>
        /// Defines a new Cassandra keyspace.
        /// </summary>
        /// <param name="name">The name of Cassandra keyspace.</param>
        /// <returns>The next stage of the update.</returns>
        CassandraKeyspace.Definition.IBlank<IWithOptionals> DefineNewCassandraKeyspace(string name);

        /// <summary>
        /// Updates a Cassandra keyspace.
        /// </summary>
        /// <param name="name">The name of Cassandra keyspace.</param>
        /// <returns>The next stage of the update.</returns>
        CassandraKeyspace.Update.IUpdate UpdateCassandraKeyspace(string name);

        /// <summary>
        /// Removes a Cassandra keyspace.
        /// </summary>
        /// <param name="name">The name of Cassandra keyspace.</param>
        /// <returns>The next stage of the update.</returns>
        IWithOptionals WithoutCassandraKeyspace(string name);

        /// <summary>
        /// Defines a new Gremlin Database.
        /// </summary>
        /// <param name="name">The name of Gremlin Database.</param>
        /// <returns>The next stage of the update.</returns>
        GremlinDatabase.Definition.IBlank<IWithOptionals> DefineNewGremlinDatabase(string name);

        /// <summary>
        /// Updates a Gremlin Database.
        /// </summary>
        /// <param name="name">The name of Gremlin Database.</param>
        /// <returns>The next stage of the update.</returns>
        GremlinDatabase.Update.IUpdate UpdateGremlinDatabase(string name);

        /// <summary>
        /// Removes a Gremlin Database.
        /// </summary>
        /// <param name="name">The name of Gremlin Database.</param>
        /// <returns>The next stage of the update.</returns>
        IWithOptionals WithoutGremlinDatabase(string name);

        /// <summary>
        /// Defines a new Table Database.
        /// </summary>
        /// <param name="name">The name of Table Database.</param>
        /// <returns>The next stage of the update.</returns>
        Table.Definition.IBlank<IWithOptionals> DefineNewTable(string name);

        /// <summary>
        /// Updates a Table Database.
        /// </summary>
        /// <param name="name">The name of Table Database.</param>
        /// <returns>The next stage of the update.</returns>
        Table.Update.IUpdate UpdateTable(string name);

        /// <summary>
        /// Removes a Table Database.
        /// </summary>
        /// <param name="name">The name of Table Database.</param>
        /// <returns>The next stage of the update.</returns>
        IWithOptionals WithoutTable(string name);
    }
}