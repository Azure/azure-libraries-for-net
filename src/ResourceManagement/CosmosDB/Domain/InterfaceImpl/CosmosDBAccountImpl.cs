// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition;
    using Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Collections.Generic;

    public partial class CosmosDBAccountImpl
    {
        /// <summary>
        /// Creates an Azure Table CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithConsistencyPolicy CosmosDBAccount.Definition.IWithKindBeta.WithDataModelAzureTable()
        {
            return this.WithDataModelAzureTable();
        }

        /// <summary>
        /// Creates a SQL CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithConsistencyPolicy CosmosDBAccount.Definition.IWithKindBeta.WithDataModelSql()
        {
            return this.WithDataModelSql();
        }

        /// <summary>
        /// Creates a MongoDB CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithConsistencyPolicy CosmosDBAccount.Definition.IWithKindBeta.WithDataModelMongoDB()
        {
            return this.WithDataModelMongoDB();
        }

        /// <summary>
        /// Creates a Cassandra CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithConsistencyPolicy CosmosDBAccount.Definition.IWithKindBeta.WithDataModelCassandra()
        {
            return this.WithDataModelCassandra();
        }

        /// <summary>
        /// The database account kind for the CosmosDB account.
        /// </summary>
        /// <param name="kind">The account kind.</param>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithConsistencyPolicy CosmosDBAccount.Definition.IWithKind.WithKind(string kind)
        {
            return this.WithKind(kind);
        }

        /// <summary>
        /// The database account kind for the CosmosDB account.
        /// </summary>
        /// <param name="kind">The account kind.</param>
        /// <param name="capabilities">The list of Cosmos DB capabilities for the account.</param>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithConsistencyPolicy CosmosDBAccount.Definition.IWithKindBeta.WithKind(DatabaseAccountKind kind, params Capability[] capabilities)
        {
            return this.WithKind(kind, capabilities);
        }

        /// <summary>
        /// Creates a Gremlin CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithConsistencyPolicy CosmosDBAccount.Definition.IWithKindBeta.WithDataModelGremlin()
        {
            return this.WithDataModelGremlin();
        }

        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithConsistencyPolicy.WithSessionConsistency()
        {
            return this.WithSessionConsistency();
        }

        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <param name="maxStalenessPrefix">The max staleness prefix.</param>
        /// <param name="maxIntervalInSeconds">The max interval in seconds.</param>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithConsistencyPolicy.WithBoundedStalenessConsistency(int maxStalenessPrefix, int maxIntervalInSeconds)
        {
            return this.WithBoundedStalenessConsistency(maxStalenessPrefix, maxIntervalInSeconds);
        }

        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithConsistencyPolicy.WithEventualConsistency()
        {
            return this.WithEventualConsistency();
        }

        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithConsistencyPolicy.WithStrongConsistency()
        {
            return this.WithStrongConsistency();
        }

        /// <summary>
        /// The session consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithWriteReplication CosmosDBAccount.Definition.IWithConsistencyPolicy.WithSessionConsistency()
        {
            return this.WithSessionConsistency();
        }

        /// <summary>
        /// The bounded staleness consistency policy for the CosmosDB account.
        /// </summary>
        /// <param name="maxStalenessPrefix">The max staleness prefix.</param>
        /// <param name="maxIntervalInSeconds">The max interval in seconds.</param>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithWriteReplication CosmosDBAccount.Definition.IWithConsistencyPolicy.WithBoundedStalenessConsistency(long maxStalenessPrefix, int maxIntervalInSeconds)
        {
            return this.WithBoundedStalenessConsistency(maxStalenessPrefix, maxIntervalInSeconds);
        }

        /// <summary>
        /// The eventual consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithWriteReplication CosmosDBAccount.Definition.IWithConsistencyPolicy.WithEventualConsistency()
        {
            return this.WithEventualConsistency();
        }

        /// <summary>
        /// The strong consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithCreate CosmosDBAccount.Definition.IWithConsistencyPolicy.WithStrongConsistency()
        {
            return this.WithStrongConsistency();
        }

        /// <summary>
        /// A georeplication location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Definition.IWithCreate CosmosDBAccount.Definition.IWithReadReplication.WithReadReplication(Region region, bool? isZoneRedundant)
        {
            return this.WithReadReplication(region, isZoneRedundant);
        }

        /// <summary>
        /// CosmosDB Firewall Support: This value specifies the set of IP addresses or IP address ranges in CIDR
        /// form to be included as the allowed list of client IPs for a given database account. IP addresses/ranges
        /// must be comma separated and must not contain any spaces.
        /// </summary>
        /// <param name="ipRangeFilter">Specifies the set of IP addresses or IP address ranges.</param>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithIpRangeFilter.WithIpRangeFilter(string ipRangeFilter)
        {
            return this.WithIpRangeFilter(ipRangeFilter);
        }

        /// <summary>
        /// CosmosDB Firewall Support: This value specifies the set of IP addresses or IP address ranges in CIDR
        /// form to be included as the allowed list of client IPs for a given database account. IP addresses/ranges
        /// must be comma separated and must not contain any spaces.
        /// </summary>
        /// <param name="ipRangeFilter">Specifies the set of IP addresses or IP address ranges.</param>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithCreate CosmosDBAccount.Definition.IWithIpRangeFilter.WithIpRangeFilter(string ipRangeFilter)
        {
            return this.WithIpRangeFilter(ipRangeFilter);
        }

        /// <summary>
        /// A georeplication location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Definition.IWithCreate CosmosDBAccount.Definition.IWithWriteReplication.WithWriteReplication(Region region, bool? isZoneRedundant)
        {
            return this.WithWriteReplication(region, isZoneRedundant);
        }

        IWithCreate CosmosDBAccount.Definition.IWithWriteReplication.WithDefaultWriteReplication()
        {
            return this.WithDefaultWriteReplication();
        }

        /// <summary>
        /// A georeplication location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Update.IWithReadLocations CosmosDBAccount.Update.IWithReadLocations.WithoutReadReplication(Region region)
        {
            return this.WithoutReadReplication(region);
        }

        /// <summary>
        /// A georeplication location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Update.IWithReadLocations CosmosDBAccount.Update.IWithReadLocations.WithReadReplication(Region region, bool? isZoneRedundant)
        {
            return this.WithReadReplication(region, isZoneRedundant);
        }

        CosmosDBAccount.Update.IWithWriteReplication CosmosDBAccount.Update.IWithReadLocations.WithoutAllReplications()
        {
            return this.WithoutAllReplications();
        }

        CosmosDBAccount.Update.IWithReadLocations CosmosDBAccount.Update.IWithWriteReplication.WithWriteReplication(Region region, bool? isZoneRedundant)
        {
            return this.WithWriteReplication(region, isZoneRedundant);
        }

        IWithReadLocations CosmosDBAccount.Update.IWithWriteReplication.WithDefaultWriteReplication()
        {
            return this.WithDefaultWriteReplication();
        }

        /// <return>The connection strings for the specified Azure CosmosDB database account.</return>
        async Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListConnectionStringsResult> Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.ListConnectionStringsAsync(CancellationToken cancellationToken)
        {
            return await this.ListConnectionStringsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets an array that contains the readable georeplication locations enabled for the CosmosDB account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.ReadableReplications
        {
            get
            {
                return this.ReadableReplications();
            }
        }

        /// <summary>
        /// Gets the default consistency level for the CosmosDB database account.
        /// </summary>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.DefaultConsistencyLevel Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.DefaultConsistencyLevel
        {
            get
            {
                return this.DefaultConsistencyLevel();
            }
        }

        /// <param name="keyKind">The key kind.</param>
        void Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.RegenerateKey(string keyKind)
        {

            this.RegenerateKey(keyKind);
        }

        /// <summary>
        /// Gets an array that contains the writable georeplication locations enabled for the CosmosDB account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.WritableReplications
        {
            get
            {
                return this.WritableReplications();
            }
        }

        /// <summary>
        /// Gets specifies the set of IP addresses or IP address ranges in CIDR form.
        /// </summary>
        string Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.IPRangeFilter
        {
            get
            {
                return this.IPRangeFilter();
            }
        }

        /// <summary>
        /// Gets the connection endpoint for the CosmosDB database account.
        /// </summary>
        string Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.DocumentEndpoint
        {
            get
            {
                return this.DocumentEndpoint();
            }
        }

        /// <param name="keyKind">The key kind.</param>
        /// <return>The ServiceResponse object if successful.</return>
        async Task Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.RegenerateKeyAsync(string keyKind, CancellationToken cancellationToken)
        {

            await this.RegenerateKeyAsync(keyKind, cancellationToken);
        }

        /// <summary>
        /// Gets the consistency policy for the CosmosDB database account.
        /// </summary>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.ConsistencyPolicy Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.ConsistencyPolicy
        {
            get
            {
                return this.ConsistencyPolicy();
            }
        }

        /// <summary>
        /// Gets whether cassandra connector is enabled or not.
        /// </summary>
        bool Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.CassandraConnectorEnabled
        {
            get
            {
                return this.CassandraConnectorEnabled();
            }
        }

        /// <summary>
        /// Gets the current cassandra connector offer.
        /// </summary>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.ConnectorOffer Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.CassandraConnectorOffer
        {
            get
            {
                return this.CassandraConnectorOffer();
            }
        }

        /// <summary>
        /// Gets whether metadata write access is disabled or not.
        /// </summary>
        bool ICosmosDBAccount.KeyBasedMetadataWriteAccessDisabled
        {
            get
            {
                return this.KeyBaseMetadataWriteAccessDisabled();
            }
        }

        bool ICosmosDBAccount.AutomaticFailoverEnabled
        {
            get
            {
                return this.AutomaticFailoverEnabled();
            }
        }

        string ICosmosDBAccount.KeyVaultUri
        {
            get
            {
                return this.KeyVaultUri();
            }
        }

        bool ICosmosDBAccount.VirtualNetoworkFilterEnabled
        {
            get
            {
                return this.VirtualNetoworkFilterEnabled();
            }
        }

        /// <return>The access keys for the specified Azure CosmosDB database account.</return>
        async Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListKeysResult> Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.ListKeysAsync(CancellationToken cancellationToken)
        {
            return await this.ListKeysAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the offer type for the CosmosDB database account.
        /// </summary>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountOfferType Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.DatabaseAccountOfferType
        {
            get
            {
                return this.DatabaseAccountOfferType();
            }
        }

        /// <return>The access keys for the specified Azure CosmosDB database account.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListKeysResult Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.ListKeys()
        {
            return this.ListKeys();
        }

        /// <summary>
        /// Gets indicates the type of database account.
        /// </summary>
        string Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.Kind
        {
            get
            {
                return this.Kind();
            }
        }

        /// <summary>
        /// Gets whether multiple write locations are enabled or not.
        /// </summary>
        bool? Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.MultipleWriteLocationsEnabled
        {
            get
            {
                return this.MultipleWriteLocationsEnabled();
            }
        }

        /// <summary>
        /// Gets a list that contains the Cosmos DB capabilities.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.Capability> Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.Capabilities
        {
            get
            {
                return this.Capabilities();
            }
        }

        /// <summary>
        /// Gets a list that contains the Cosmos DB Virtual Network ACL Rules (empty list if none is set).
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.VirtualNetworkRule> Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.VirtualNetworkRules
        {
            get
            {
                return this.VirtualNetworkRules();
            }
        }

        /// <return>The connection strings for the specified Azure CosmosDB database account.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListConnectionStringsResult Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.ListConnectionStrings()
        {
            return this.ListConnectionStrings();
        }

        /// <return>The read-only access keys for the specified Azure CosmosDB database account.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListReadOnlyKeysResult Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.ListReadOnlyKeys()
        {
            return this.ListReadOnlyKeys();
        }

        /// <return>The read-only access keys for the specified Azure CosmosDB database account.</return>
        async Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListReadOnlyKeysResult> Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.ListReadOnlyKeysAsync(CancellationToken cancellationToken)
        {
            return await this.ListReadOnlyKeysAsync(cancellationToken);
        }

        /// <return>The SQL databases for the specified Azure CosmosDB database account.</return>
        IEnumerable<ISqlDatabase> ICosmosDBAccount.ListSqlDatabases()
        {
            return this.ListSqlDatabases();
        }

        /// <return>The SQL databases for the specified Azure CosmosDB database account.</return>
        async Task<IEnumerable<ISqlDatabase>> ICosmosDBAccount.ListSqlDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListSqlDatabasesAsync(cancellationToken);
        }

        /// <summary>
        /// It takes offline the specified region for the current Azure Cosmos DB database account.
        /// </summary>
        /// <param name="region">Cosmos DB region.</param>
        void Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.OfflineRegion(Region region)
        {

            this.OfflineRegion(region);
        }

        /// <summary>
        /// Asynchronously it takes offline the specified region for the current Azure Cosmos DB database account.
        /// </summary>
        /// <param name="region">Cosmos DB region.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.OfflineRegionAsync(Region region, CancellationToken cancellationToken)
        {

            await this.OfflineRegionAsync(region, cancellationToken);
        }

        /// <summary>
        /// It brings online the specified region for the current Azure Cosmos DB database account.
        /// </summary>
        /// <param name="region">Cosmos DB region.</param>
        void Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.OnlineRegion(Region region)
        {

            this.OnlineRegion(region);
        }

        /// <summary>
        /// Asynchronously it brings online the specified region for the current Azure Cosmos DB database account.
        /// </summary>
        /// <param name="region">Cosmos DB region.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.OnlineRegionAsync(Region region, CancellationToken cancellationToken)
        {

            await this.OnlineRegionAsync(region, cancellationToken);
        }

        /// <summary>
        /// Removes a Virtual Network ACL Rule for the CosmosDB account.
        /// </summary>
        /// <param name="virtualNetworkId">The ID of a virtual network.</param>
        /// <param name="subnetName">
        /// The name of the subnet within the virtual network; the subnet must have the service
        /// endpoints enabled for 'Microsoft.AzureCosmosDB'.
        /// </param>
        /// <return>The next stage of the update definition.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithVirtualNetworkRule.WithoutVirtualNetworkRule(string virtualNetworkId, string subnetName)
        {
            return this.WithoutVirtualNetworkRule(virtualNetworkId, subnetName);
        }

        /// <summary>
        /// Specifies a Virtual Network ACL Rule for the CosmosDB account.
        /// </summary>
        /// <param name="virtualNetworkId">The ID of a virtual network.</param>
        /// <param name="subnetName">
        /// The name of the subnet within the virtual network; the subnet must have the service
        /// endpoints enabled for 'Microsoft.AzureCosmosDB'.
        /// </param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Definition.IWithCreate CosmosDBAccount.Definition.IWithVirtualNetworkRule.WithVirtualNetworkRule(string virtualNetworkId, string subnetName, bool? ignoreMissingVNetServiceEndpoint)
        {
            return this.WithVirtualNetworkRule(virtualNetworkId, subnetName, ignoreMissingVNetServiceEndpoint);
        }

        CosmosDBAccount.Definition.IWithCreate CosmosDBAccount.Definition.IWithVirtualNetworkRule.WithVirtualNetworkFilterEnabled(bool enable)
        {
            return this.WithVirtualNetworkFilterEnabled(enable);
        }

        IWithCreate CosmosDBAccount.Definition.IWithKeyVault.WithKeyVault(string keyVaultUri)
        {
            return this.WithKeyVault(keyVaultUri);
        }

        /// <summary>
        /// Specifies a new Virtual Network ACL Rule for the CosmosDB account.
        /// </summary>
        /// <param name="virtualNetworkId">The ID of a virtual network.</param>
        /// <param name="subnetName">
        /// The name of the subnet within the virtual network; the subnet must have the service
        /// endpoints enabled for 'Microsoft.AzureCosmosDB'.
        /// </param>
        /// <return>The next stage of the update definition.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithVirtualNetworkRule.WithVirtualNetworkRule(string virtualNetworkId, string subnetName, bool? ignoreMissingVNetServiceEndpoint)
        {
            return this.WithVirtualNetworkRule(virtualNetworkId, subnetName, ignoreMissingVNetServiceEndpoint);
        }

        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithVirtualNetworkRule.WithVirtualNetworkFilterEnabled(bool enable)
        {
            return this.WithVirtualNetworkFilterEnabled(enable);
        }

        IWithOptionals CosmosDBAccount.Update.IWithKeyVault.WithKeyVault(string keyVaultUri)
        {
            return this.WithKeyVault(keyVaultUri);
        }

        IWithOptionals CosmosDBAccount.Update.IWithKeyVault.WithoutKeyVault()
        {
            return this.WithoutKeyVault();
        }

        /// <summary>
        /// Specifies whether mutliple write locations are enabled for this cosmos db account.
        /// </summary>
        /// <param name="enabled">Whether mutliple write locations are enabled or not</param>
        /// <returns>The next stage.</returns>
        CosmosDBAccount.Definition.IWithCreate CosmosDBAccount.Definition.IWithMultipleLocations.WithMultipleWriteLocationsEnabled(bool enabled)
        {
            return this.WithMultipleWriteLocationsEnabled(enabled);
        }

        /// <summary>
        /// Specifies whether multiple write locations are enabled for this cosmos db account.
        /// </summary>
        /// <param name="enabled">Whether multiple write locations are enabled or not,</param>
        /// <returns>The next stage of the update definition.</returns>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithMultipleLocations.WithMultipleWriteLocationsEnabled(bool enabled)
        {
            return this.WithMultipleWriteLocationsEnabled(enabled);
        }

        /// <summary>
        /// Specifies the list of Virtual Network ACL Rules for the CosmosDB account.
        /// </summary>
        /// <param name="virtualNetworkRules">The list of Virtual Network ACL Rules.</param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Definition.IWithCreate CosmosDBAccount.Definition.IWithVirtualNetworkRule.WithVirtualNetworkRules(IList<Models.VirtualNetworkRule> virtualNetworkRules)
        {
            return this.WithVirtualNetworkRules(virtualNetworkRules);
        }

        /// <summary>
        /// A Virtual Network ACL Rule for the CosmosDB account.
        /// </summary>
        /// <param name="virtualNetworkRules">
        /// The list of Virtual Network ACL Rules (an empty list value
        /// will remove all the rules).
        /// </param>
        /// <return>The next stage of the update definition.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithVirtualNetworkRule.WithVirtualNetworkRules(IList<Models.VirtualNetworkRule> virtualNetworkRules)
        {
            return this.WithVirtualNetworkRules(virtualNetworkRules);
        }

        /// <summary>
        /// Specifies a connector offer for cassandra connector.
        /// </summary>
        /// <param name="connectorOffer">Connector offer to specify.</param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Definition.IWithCreate CosmosDBAccount.Definition.IWithConnector.WithCassandraConnector(ConnectorOffer connectorOffer)
        {
            return this.WithCassandraConnector(connectorOffer);
        }

        /// <summary>
        /// Specifies a connector offer for cassandra connector.
        /// </summary>
        /// <param name="connectorOffer">Connector offer to specify.</param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithConnector.WithCassandraConnector(ConnectorOffer connectorOffer)
        {
            return this.WithCassandraConnector(connectorOffer);
        }

        /// <summary>
        /// Remove the connector offer.
        /// </summary>
        /// <return>The next stage.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithConnector.WithoutCassandraConnector()
        {
            return this.WithoutCassandraConnector();
        }

        /// <summary>
        /// Starts the definition of a private endpoint connection to be attached
        /// to the cosmos db account.
        /// </summary>
        /// <param name="name">The reference name for the private endpoint connection.</param>
        /// <returns>The first stage of a private endpoint connection definition.</returns>
        PrivateEndpointConnection.Definition.IBlank<CosmosDBAccount.Definition.IWithCreate> CosmosDBAccount.Definition.IWithPrivateEndpointConnection.DefineNewPrivateEndpointConnection(string name)
        {
            return this.DefineNewPrivateEndpointConnection(name);
        }

        /// <summary>
        /// Starts the definition of a private endpoint connection to be attached
        /// to the cosmos db account.
        /// </summary>
        /// <param name="name">The reference name for the private endpoint connection.</param>
        /// <returns>The first stage of a private endpoint connection definition.</returns>
        PrivateEndpointConnection.UpdateDefinition.IBlank<CosmosDBAccount.Update.IWithOptionals> CosmosDBAccount.Update.IWithPrivateEndpointConnection.DefineNewPrivateEndpointConnection(string name)
        {
            return this.DefineNewPrivateEndpointConnection(name);
        }

        /// <summary>
        /// Start the update of an existing private endpoint connection.
        /// </summary>
        /// <param name="name">The reference name for the private endpoint connection.</param>
        /// <returns>The first stage of a private endpoint connection definition.</returns>
        PrivateEndpointConnection.Update.IUpdate CosmosDBAccount.Update.IWithPrivateEndpointConnection.UpdatePrivateEndpointConnection(string name)
        {
            return this.UpdatePrivateEndpointConnection(name);
        }

        /// <summary>
        /// Remove an existing private endpoint connection.
        /// </summary>
        /// <param name="name">The reference name for the private endpoint connection.</param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithPrivateEndpointConnection.WithoutPrivateEndpointConnection(string name)
        {
            return this.WithoutPrivateEndpointConnection(name);
        }

        /// <summary>
        /// Specifies whether metadata write access should be disabled.
        /// </summary>
        /// <param name="disabled">Whether metadata write access is disabled or not.</param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Definition.IWithCreate CosmosDBAccount.Definition.IWithKeyBasedMetadataWriteAccess.WithDisableKeyBaseMetadataWriteAccess(bool disabled)
        {
            return this.WithDisableKeyBaseMetadataWriteAccess(disabled);
        }

        /// <summary>
        /// Specifies whether metadata write access should be disabled.
        /// </summary>
        /// <param name="disabled">Whether metadata write access is disabled or not.</param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithKeyBasedMetadataWriteAccess.WithDisableKeyBaseMetadataWriteAccess(bool disabled)
        {
            return this.WithDisableKeyBaseMetadataWriteAccess(disabled);
        }

        IWithCreate CosmosDBAccount.Definition.IWithAutomaticFailover.WithAutomaticFailoverEnabled(bool enabled)
        {
            return this.WithAutomaticFailoverEnabled(enabled);
        }

        IWithOptionals CosmosDBAccount.Update.IWithAutomaticFailover.WithAutomaticFailoverEnabled(bool enabled)
        {
            return this.WithAutomaticFailoverEnabled(enabled);
        }

        SqlDatabase.Definition.IBlank<IWithCreate> CosmosDBAccount.Definition.IWithChildResource.DefineNewSqlDatabase(string name)
        {
            return this.DefineNewSqlDatabase(name);
        }

        SqlDatabase.Definition.IBlank<IWithOptionals> CosmosDBAccount.Update.IWithChildResource.DefineNewSqlDatabase(string name)
        {
            return this.DefineNewSqlDatabase(name);
        }

        SqlDatabase.Update.IUpdate CosmosDBAccount.Update.IWithChildResource.UpdateSqlDatabase(string name)
        {
            return this.UpdateSqlDatabase(name);
        }

        IWithOptionals CosmosDBAccount.Update.IWithChildResource.WithoutSqlDatabase(string name)
        {
            return this.WithoutSqlDatabase(name);
        }

        IMongoDB ICosmosDBAccount.GetMongoDB(string databaseName)
        {
            return this.GetMongoDB(databaseName);
        }

        Task<IMongoDB> ICosmosDBAccount.GetMongoDBAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetMongoDBAsync(databaseName, cancellationToken);
        }

        IEnumerable<IMongoDB> ICosmosDBAccount.ListMongoDBs()
        {
            return this.ListMongoDBs();
        }

        Task<IEnumerable<IMongoDB>> ICosmosDBAccount.ListMongoDBsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListMongoDBsAsync(cancellationToken);
        }

        MongoDB.Definition.IBlank<IWithCreate> CosmosDBAccount.Definition.IWithChildResource.DefineNewMongoDB(string name)
        {
            return this.DefineNewMongoDB(name);
        }

        MongoDB.Definition.IBlank<IWithOptionals> CosmosDBAccount.Update.IWithChildResource.DefineNewMongoDB(string name)
        {
            return this.DefineNewMongoDB(name);
        }

        MongoDB.Update.IUpdate CosmosDBAccount.Update.IWithChildResource.UpdateMongoDB(string name)
        {
            return this.UpdateMongoDB(name);
        }

        IWithOptionals CosmosDBAccount.Update.IWithChildResource.WithoutMongoDB(string name)
        {
            return this.WithoutMongoDB(name);
        }

        ICassandraKeyspace ICosmosDBAccount.GetCassandraKeyspace(string databaseName)
        {
            return this.GetCassandraKeyspace(databaseName);
        }

        Task<ICassandraKeyspace> ICosmosDBAccount.GetCassandraKeyspaceAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetCassandraKeyspaceAsync(databaseName, cancellationToken);
        }

        IEnumerable<ICassandraKeyspace> ICosmosDBAccount.ListCassandraKeyspaces()
        {
            return this.ListCassandraKeyspaces();
        }

        Task<IEnumerable<ICassandraKeyspace>> ICosmosDBAccount.ListCassandraKeyspacesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListCassandraKeyspacesAsync(cancellationToken);
        }

        CassandraKeyspace.Definition.IBlank<IWithCreate> CosmosDBAccount.Definition.IWithChildResource.DefineNewCassandraKeyspace(string name)
        {
            return this.DefineNewCassandraKeyspace(name);
        }

        CassandraKeyspace.Definition.IBlank<IWithOptionals> CosmosDBAccount.Update.IWithChildResource.DefineNewCassandraKeyspace(string name)
        {
            return this.DefineNewCassandraKeyspace(name);
        }

        CassandraKeyspace.Update.IUpdate CosmosDBAccount.Update.IWithChildResource.UpdateCassandraKeyspace(string name)
        {
            return this.UpdateCassandraKeyspace(name);
        }

        IWithOptionals CosmosDBAccount.Update.IWithChildResource.WithoutCassandraKeyspace(string name)
        {
            return this.WithoutCassandraKeyspace(name);
        }

        IGremlinDatabase ICosmosDBAccount.GetGremlinDatabase(string databaseName)
        {
            return this.GetGremlinDatabase(databaseName);
        }

        Task<IGremlinDatabase> ICosmosDBAccount.GetGremlinDatabaseAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetGremlinDatabaseAsync(databaseName, cancellationToken);
        }

        IEnumerable<IGremlinDatabase> ICosmosDBAccount.ListGremlinDatabases()
        {
            return this.ListGremlinDatabases();
        }

        Task<IEnumerable<IGremlinDatabase>> ICosmosDBAccount.ListGremlinDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListGremlinDatabasesAsync(cancellationToken);
        }

        GremlinDatabase.Definition.IBlank<IWithCreate> CosmosDBAccount.Definition.IWithChildResource.DefineNewGremlinDatabase(string name)
        {
            return this.DefineNewGremlinDatabase(name);
        }

        GremlinDatabase.Definition.IBlank<IWithOptionals> CosmosDBAccount.Update.IWithChildResource.DefineNewGremlinDatabase(string name)
        {
            return this.DefineNewGremlinDatabase(name);
        }

        GremlinDatabase.Update.IUpdate CosmosDBAccount.Update.IWithChildResource.UpdateGremlinDatabase(string name)
        {
            return this.UpdateGremlinDatabase(name);
        }

        IWithOptionals CosmosDBAccount.Update.IWithChildResource.WithoutGremlinDatabase(string name)
        {
            return this.WithoutGremlinDatabase(name);
        }

        ITable ICosmosDBAccount.GetTable(string databaseName)
        {
            return this.GetTable(databaseName);
        }

        Task<ITable> ICosmosDBAccount.GetTableAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetTableAsync(databaseName, cancellationToken);
        }

        IEnumerable<ITable> ICosmosDBAccount.ListTables()
        {
            return this.ListTables();
        }

        Task<IEnumerable<ITable>> ICosmosDBAccount.ListTablesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListTablesAsync(cancellationToken);
        }

        Table.Definition.IBlank<IWithCreate> CosmosDBAccount.Definition.IWithChildResource.DefineNewTable(string name)
        {
            return this.DefineNewTable(name);
        }

        Table.Definition.IBlank<IWithOptionals> CosmosDBAccount.Update.IWithChildResource.DefineNewTable(string name)
        {
            return this.DefineNewTable(name);
        }

        Table.Update.IUpdate CosmosDBAccount.Update.IWithChildResource.UpdateTable(string name)
        {
            return this.UpdateTable(name);
        }

        IWithOptionals CosmosDBAccount.Update.IWithChildResource.WithoutTable(string name)
        {
            return this.WithoutTable(name);
        }
    }
}