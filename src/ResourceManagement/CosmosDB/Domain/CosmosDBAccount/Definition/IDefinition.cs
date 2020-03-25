// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.CosmosDB.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the cosmos db definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithKind>
    {
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing to set the database account kind.
    /// </summary>
    public interface IWithKind :
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithKindBeta
    {
        /// <summary>
        /// The database account kind for the CosmosDB account.
        /// </summary>
        /// <param name="kind">The account kind.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithConsistencyPolicy WithKind(string kind);
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing to specify cassandra connector offer.
    /// </summary>
    public interface IWithConnector
    {
        /// <summary>
        /// Specifies a connector offer for cassandra connector.
        /// </summary>
        /// <param name="connectorOffer">Connector offer to specify.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithCassandraConnector(ConnectorOffer connectorOffer);
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing the definition of a Virtual Network ACL Rule.
    /// </summary>
    public interface IWithVirtualNetworkRule :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies a Virtual Network ACL Rule for the CosmosDB account.
        /// </summary>
        /// <param name="virtualNetworkId">The ID of a virtual network.</param>
        /// <param name="subnetName">
        /// The name of the subnet within the virtual network; the subnet must have the service
        /// endpoints enabled for 'Microsoft.AzureCosmosDB'.
        /// </param>
        /// <param name="ignoreMissingVNetServiceEndpoint">The boolean decides to ignore missing endpoint or not.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithVirtualNetworkRule(string virtualNetworkId, string subnetName, bool? ignoreMissingVNetServiceEndpoint = default(bool?));

        /// <summary>
        /// Specifies Virtual Network Fileter manually.
        /// </summary>
        /// <param name="enable">The fileter is enabled or not.</param>
        /// <returns>The next stage.</returns>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithVirtualNetworkFilterEnabled(bool enable);

        /// <summary>
        /// Specifies the list of Virtual Network ACL Rules for the CosmosDB account.
        /// </summary>
        /// <param name="virtualNetworkRules">The list of Virtual Network ACL Rules.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithVirtualNetworkRules(IList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.VirtualNetworkRule> virtualNetworkRules);
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing to specify whether multiple write locations will be enabled.
    /// </summary>
    public interface IWithMultipleLocations
    {
        /// <summary>
        /// Specifies whether multiple write locations are enabled for this cosmos db account.
        /// </summary>
        /// <param name="enabled">Whether multiple write locations are enabled or not.</param>
        /// <returns>The next stage.</returns>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithMultipleWriteLocationsEnabled(bool enabled);
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing to set the database account kind.
    /// </summary>
    public interface IWithKindBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// The database account kind for the CosmosDB account.
        /// </summary>
        /// <param name="kind">The account kind.</param>
        /// <param name="capabilities">The list of Cosmos DB capabilities for the account.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithConsistencyPolicy WithKind(DatabaseAccountKind kind, params Capability[] capabilities);

        /// <summary>
        /// Creates a Cassandra CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithConsistencyPolicy WithDataModelCassandra();

        /// <summary>
        /// Creates a MongoDB CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithConsistencyPolicy WithDataModelMongoDB();

        /// <summary>
        /// Creates an Azure Table CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithConsistencyPolicy WithDataModelAzureTable();

        /// <summary>
        /// Creates a Gremlin CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithConsistencyPolicy WithDataModelGremlin();

        /// <summary>
        /// Creates a SQL CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithConsistencyPolicy WithDataModelSql();
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithConsistencyPolicy,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithReadReplication,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithIpRangeFilter,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithVirtualNetworkRule,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithMultipleLocations,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithConnector,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithKeyBasedMetadataWriteAccess,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithPrivateEndpointConnection,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithAutomaticFailover,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithKeyVault,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithChildResource,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing to specify metadata write access.
    /// </summary>
    public interface IWithKeyBasedMetadataWriteAccess
    {
        /// <summary>
        /// Specifies whether metadata write access should be disabled.
        /// </summary>
        /// <param name="disabled">Whether metadata write access is disabled or not.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithDisableKeyBaseMetadataWriteAccess(bool disabled);
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing to specify private endpoint connection.
    /// </summary>
    public interface IWithPrivateEndpointConnection
    {
        /// <summary>
        /// Starts the definition of a private endpoint connection to be attached
        /// to the cosmos db account.
        /// </summary>
        /// <param name="name">The reference name for the private endpoint connection.</param>
        /// <return>The first stage of a private endpoint connection definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Definition.IBlank<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate> DefineNewPrivateEndpointConnection(string name);
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing the definition of a read location.
    /// </summary>
    public interface IWithReadReplication
    {
        /// <summary>
        /// Sets a read location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <param name="isZoneRedundant">Flag to indicate whether or not this region is an AvailabilityZone region.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithReadReplication(Region region, bool? isZoneRedundant = default(bool?));
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing to set the IP range filter.
    /// </summary>
    public interface IWithIpRangeFilter
    {
        /// <summary>
        /// CosmosDB Firewall Support: This value specifies the set of IP addresses or IP address ranges in CIDR
        /// form to be included as the allowed list of client IPs for a given database account. IP addresses/ranges
        /// must be comma separated and must not contain any spaces.
        /// </summary>
        /// <param name="ipRangeFilter">Specifies the set of IP addresses or IP address ranges.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithIpRangeFilter(string ipRangeFilter);
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
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithWriteReplication(Region region, bool? isZoneRedundant = default(bool?));

        /// <summary>
        /// Sets the write location same as the CosmosDB account location.
        /// </summary>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithDefaultWriteReplication();
    }

    /// <summary>
    /// Grouping of cosmos db definition stages.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IBlank,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithGroup,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithKind,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithWriteReplication,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithReadReplication,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithChildResource,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The first stage of a cosmos db definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing to set the consistency policy.
    /// </summary>
    public interface IWithConsistencyPolicy
    {
        /// <summary>
        /// The bounded staleness consistency policy for the CosmosDB account.
        /// </summary>
        /// <param name="maxStalenessPrefix">The max staleness prefix.</param>
        /// <param name="maxIntervalInSeconds">The max interval in seconds.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithWriteReplication WithBoundedStalenessConsistency(long maxStalenessPrefix, int maxIntervalInSeconds);

        /// <summary>
        /// The strong consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithStrongConsistency();

        /// <summary>
        /// The eventual consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithWriteReplication WithEventualConsistency();

        /// <summary>
        /// The session consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithWriteReplication WithSessionConsistency();
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing to set the automatic failover.
    /// </summary>
    public interface IWithAutomaticFailover
    {
        /// <summary>
        /// Specifies whether automatic failover is enabled for this cosmos db account.
        /// </summary>
        /// <param name="enabled">Whether automatic failover is enabled or not.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithCreate WithAutomaticFailoverEnabled(bool enabled);
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
        /// <returns>The next stage of the definition.</returns>
        IWithCreate WithKeyVault(string keyVaultUri);
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing to set child resources.
    /// </summary>
    public interface IWithChildResource
    {
        /// <summary>
        /// Defines a new SQL database.
        /// </summary>
        /// <param name="name">The name of SQL database.</param>
        /// <returns>The next stage of the definition.</returns>
        SqlDatabase.Definition.IBlank<IWithCreate> DefineNewSqlDatabase(string name);

        /// <summary>
        /// Defines a new Mongo database.
        /// </summary>
        /// <param name="name">The name of Mongo database.</param>
        /// <returns>The next stage of the definition.</returns>
        MongoDB.Definition.IBlank<IWithCreate> DefineNewMongoDB(string name);

        /// <summary>
        /// Defines a new Cassandra keyspace.
        /// </summary>
        /// <param name="name">The name of Cassandra keyspace.</param>
        /// <returns>The next stage of the definition.</returns>
        CassandraKeyspace.Definition.IBlank<IWithCreate> DefineNewCassandraKeyspace(string name);

        /// <summary>
        /// Defines a new Gremlin Database.
        /// </summary>
        /// <param name="name">The name of Gremlin Database.</param>
        /// <returns>The next stage of the definition.</returns>
        GremlinDatabase.Definition.IBlank<IWithCreate> DefineNewGremlinDatabase(string name);

        /// <summary>
        /// Defines a new Table Database.
        /// </summary>
        /// <param name="name">The name of Table Database.</param>
        /// <returns>The next stage of the definition.</returns>
        Table.Definition.IBlank<IWithCreate> DefineNewTable(string name);
    }
}