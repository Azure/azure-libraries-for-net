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
            return this.WithDataModelAzureTable() as CosmosDBAccount.Definition.IWithConsistencyPolicy;
        }

        /// <summary>
        /// Creates a SQL CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithConsistencyPolicy CosmosDBAccount.Definition.IWithKindBeta.WithDataModelSql()
        {
            return this.WithDataModelSql() as CosmosDBAccount.Definition.IWithConsistencyPolicy;
        }

        /// <summary>
        /// Creates a MongoDB CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithConsistencyPolicy CosmosDBAccount.Definition.IWithKindBeta.WithDataModelMongoDB()
        {
            return this.WithDataModelMongoDB() as CosmosDBAccount.Definition.IWithConsistencyPolicy;
        }

        /// <summary>
        /// Creates a Cassandra CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithConsistencyPolicy CosmosDBAccount.Definition.IWithKindBeta.WithDataModelCassandra()
        {
            return this.WithDataModelCassandra() as CosmosDBAccount.Definition.IWithConsistencyPolicy;
        }

        /// <summary>
        /// The database account kind for the CosmosDB account.
        /// </summary>
        /// <param name="kind">The account kind.</param>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithConsistencyPolicy CosmosDBAccount.Definition.IWithKind.WithKind(string kind)
        {
            return this.WithKind(kind) as CosmosDBAccount.Definition.IWithConsistencyPolicy;
        }

        /// <summary>
        /// The database account kind for the CosmosDB account.
        /// </summary>
        /// <param name="kind">The account kind.</param>
        /// <param name="capabilities">The list of Cosmos DB capabilities for the account.</param>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithConsistencyPolicy CosmosDBAccount.Definition.IWithKindBeta.WithKind(DatabaseAccountKind kind, params Capability[] capabilities)
        {
            return this.WithKind(kind, capabilities) as CosmosDBAccount.Definition.IWithConsistencyPolicy;
        }

        /// <summary>
        /// Creates a Gremlin CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithConsistencyPolicy CosmosDBAccount.Definition.IWithKindBeta.WithDataModelGremlin()
        {
            return this.WithDataModelGremlin() as CosmosDBAccount.Definition.IWithConsistencyPolicy;
        }

        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithConsistencyPolicy.WithSessionConsistency()
        {
            return this.WithSessionConsistency() as CosmosDBAccount.Update.IWithOptionals;
        }

        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <param name="maxStalenessPrefix">The max staleness prefix.</param>
        /// <param name="maxIntervalInSeconds">The max interval in seconds.</param>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithConsistencyPolicy.WithBoundedStalenessConsistency(int maxStalenessPrefix, int maxIntervalInSeconds)
        {
            return this.WithBoundedStalenessConsistency(maxStalenessPrefix, maxIntervalInSeconds) as CosmosDBAccount.Update.IWithOptionals;
        }

        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithConsistencyPolicy.WithEventualConsistency()
        {
            return this.WithEventualConsistency() as CosmosDBAccount.Update.IWithOptionals;
        }

        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Update.IWithOptionals CosmosDBAccount.Update.IWithConsistencyPolicy.WithStrongConsistency()
        {
            return this.WithStrongConsistency() as CosmosDBAccount.Update.IWithOptionals;
        }

        /// <summary>
        /// The session consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithWriteReplication CosmosDBAccount.Definition.IWithConsistencyPolicy.WithSessionConsistency()
        {
            return this.WithSessionConsistency() as CosmosDBAccount.Definition.IWithWriteReplication;
        }

        /// <summary>
        /// The bounded staleness consistency policy for the CosmosDB account.
        /// </summary>
        /// <param name="maxStalenessPrefix">The max staleness prefix.</param>
        /// <param name="maxIntervalInSeconds">The max interval in seconds.</param>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithWriteReplication CosmosDBAccount.Definition.IWithConsistencyPolicy.WithBoundedStalenessConsistency(int maxStalenessPrefix, int maxIntervalInSeconds)
        {
            return this.WithBoundedStalenessConsistency(maxStalenessPrefix, maxIntervalInSeconds) as CosmosDBAccount.Definition.IWithWriteReplication;
        }

        /// <summary>
        /// The eventual consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithWriteReplication CosmosDBAccount.Definition.IWithConsistencyPolicy.WithEventualConsistency()
        {
            return this.WithEventualConsistency() as CosmosDBAccount.Definition.IWithWriteReplication;
        }

        /// <summary>
        /// The strong consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        CosmosDBAccount.Definition.IWithCreate CosmosDBAccount.Definition.IWithConsistencyPolicy.WithStrongConsistency()
        {
            return this.WithStrongConsistency() as CosmosDBAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// A georeplication location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Definition.IWithCreate CosmosDBAccount.Definition.IWithReadReplication.WithReadReplication(Region region)
        {
            return this.WithReadReplication(region) as CosmosDBAccount.Definition.IWithCreate;
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
            return this.WithIpRangeFilter(ipRangeFilter) as CosmosDBAccount.Update.IWithOptionals;
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
            return this.WithIpRangeFilter(ipRangeFilter) as CosmosDBAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// A georeplication location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Definition.IWithCreate CosmosDBAccount.Definition.IWithWriteReplication.WithWriteReplication(Region region)
        {
            return this.WithWriteReplication(region) as CosmosDBAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// A georeplication location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Update.IWithReadLocations CosmosDBAccount.Update.IWithReadLocations.WithoutReadReplication(Region region)
        {
            return this.WithoutReadReplication(region) as CosmosDBAccount.Update.IWithReadLocations;
        }

        /// <summary>
        /// A georeplication location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        CosmosDBAccount.Update.IWithReadLocations CosmosDBAccount.Update.IWithReadLocations.WithReadReplication(Region region)
        {
            return this.WithReadReplication(region) as CosmosDBAccount.Update.IWithReadLocations;
        }

        /// <return>The connection strings for the specified Azure CosmosDB database account.</return>
        async Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListConnectionStringsResult> Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.ListConnectionStringsAsync(CancellationToken cancellationToken)
        {
            return await this.ListConnectionStringsAsync(cancellationToken) as Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListConnectionStringsResult;
        }

        /// <summary>
        /// Gets an array that contains the readable georeplication locations enabled for the CosmosDB account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.ReadableReplications
        {
            get
            {
                return this.ReadableReplications() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location>;
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
                return this.WritableReplications() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location>;
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
                return this.ConsistencyPolicy() as Microsoft.Azure.Management.CosmosDB.Fluent.Models.ConsistencyPolicy;
            }
        }

        /// <return>The access keys for the specified Azure CosmosDB database account.</return>
        async Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListKeysResult> Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.ListKeysAsync(CancellationToken cancellationToken)
        {
            return await this.ListKeysAsync(cancellationToken) as Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListKeysResult;
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
            return this.ListKeys() as Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListKeysResult;
        }

        /// <summary>
        /// Gets indicates the type of database account.
        /// </summary>
        string Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.Kind
        {
            get
            {
                return this.Kind() as string;
            }
        }

        /// <summary>
        /// Gets a list that contains the Cosmos DB capabilities.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.Capability> Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.Capabilities
        {
            get
            {
                return this.Capabilities() as System.Collections.Generic.IReadOnlyList<Models.Capability>;
            }
        }

        /// <return>The connection strings for the specified Azure CosmosDB database account.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListConnectionStringsResult Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.ListConnectionStrings()
        {
            return this.ListConnectionStrings() as Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListConnectionStringsResult;
        }

        /// <return>The read-only access keys for the specified Azure CosmosDB database account.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListReadOnlyKeysResult Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.ListReadOnlyKeys()
        {
            return this.ListReadOnlyKeys() as Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListReadOnlyKeysResult;
        }

        /// <return>The read-only access keys for the specified Azure CosmosDB database account.</return>
        async Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListReadOnlyKeysResult> Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount.ListReadOnlyKeysAsync(CancellationToken cancellationToken)
        {
            return await this.ListReadOnlyKeysAsync(cancellationToken) as Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListReadOnlyKeysResult;
        }
    }
}