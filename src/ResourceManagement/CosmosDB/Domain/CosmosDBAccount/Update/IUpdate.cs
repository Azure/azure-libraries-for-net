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
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithoutVirtualNetwork(string virtualNetworkId, string subnetName);

        /// <summary>
        /// Specifies a new Virtual Network ACL Rule for the CosmosDB account.
        /// </summary>
        /// <param name="virtualNetworkId">The ID of a virtual network.</param>
        /// <param name="subnetName">
        /// The name of the subnet within the virtual network; the subnet must have the service
        /// endpoints enabled for 'Microsoft.AzureCosmosDB'.
        /// </param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithVirtualNetwork(string virtualNetworkId, string subnetName);

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
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithChildResource
    {
    }

    /// <summary>
    /// Grouping of cosmos db update stages.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithReadLocations,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals
    {
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing the definition of a write location.
    /// </summary>
    public interface IWithReadLocations :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>
    {
        /// <summary>
        /// A georeplication location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithReadLocations WithReadReplication(Region region);

        /// <summary>
        /// A georeplication location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithReadLocations WithoutReadReplication(Region region);
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
    }
}