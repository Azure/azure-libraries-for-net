// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition;
    using Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update;
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.Resource.Update;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for DatabaseAccount.
    /// </summary>
    public partial class CosmosDBAccountImpl :
        GroupableResource<
            ICosmosDBAccount,
            Models.DatabaseAccountGetResultsInner,
            CosmosDBAccountImpl,
            ICosmosDBManager,
            IWithGroup,
            IWithKind,
            IWithCreate,
            IUpdate>,
        ICosmosDBAccount,
        IDefinition,
        IUpdate
    {
        private IList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> failoverPolicies;
        private bool isFailoverPolicyLoaded;
        private const int maxDelayDueToMissingFailovers = 5000 * 12 * 10;
        private Dictionary<string, List<Models.VirtualNetworkRule>> virtualNetworkRulesMap;
        private PrivateEndpointConnectionsImpl privateEndpointConnections;
        private SqlDatabasesImpl sqlDatabases;
        private MongoDBsImpl mongoDBs;
        private CassandraKeyspacesImpl cassandraKeyspaces;
        private GremlinDatabasesImpl gremlinDatabases;
        private TablesImpl tables;

        internal CosmosDBAccountImpl(string name, Models.DatabaseAccountGetResultsInner innerObject, ICosmosDBManager manager) :
            base(name, innerObject, manager)
        {
            this.failoverPolicies = new List<Models.Location>();
            this.privateEndpointConnections = new PrivateEndpointConnectionsImpl(this);
            this.sqlDatabases = new SqlDatabasesImpl(this);
            this.mongoDBs = new MongoDBsImpl(this);
            this.cassandraKeyspaces = new CassandraKeyspacesImpl(this);
            this.gremlinDatabases = new GremlinDatabasesImpl(this);
            this.tables = new TablesImpl(this);
        }

        public CosmosDBAccountImpl WithReadReplication(Region region, bool? isZoneRedundant)
        {
            this.EnsureFailoverIsInitialized();
            Models.Location FailoverPolicy = new Models.Location();
            FailoverPolicy.LocationName = region.Name;
            FailoverPolicy.IsZoneRedundant = isZoneRedundant;
            FailoverPolicy.FailoverPriority = this.failoverPolicies.Count;
            this.isFailoverPolicyLoaded = true;
            this.failoverPolicies.Add(FailoverPolicy);
            return this;
        }

        public CosmosDBAccountImpl WithoutAllReplications()
        {
            this.failoverPolicies.Clear();
            this.isFailoverPolicyLoaded = true;
            return this;
        }

        private async Task<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount> DoDatabaseUpdateCreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            CosmosDBAccountImpl self = this;
            int currentDelayDueToMissingFailovers = 0;
            HasLocation locationParameters;

            if (IsInCreateMode)
            {
                Models.DatabaseAccountCreateUpdateParameters createUpdateParametersInner =
                    this.CreateUpdateParametersInner(this.Inner);
                await this.Manager.Inner.DatabaseAccounts.CreateOrUpdateAsync(
                    ResourceGroupName, Name, createUpdateParametersInner);
                locationParameters = new CreateUpdateLocationParameters(createUpdateParametersInner);
            }
            else
            {
                Models.DatabaseAccountUpdateParameters updateParametersInner =
                    this.UpdateParametersInner(this.Inner);
                await this.Manager.Inner.DatabaseAccounts.UpdateAsync(
                    ResourceGroupName, Name, updateParametersInner);
                locationParameters = new UpdateLocationParameters(updateParametersInner);
            }
            this.failoverPolicies.Clear();
            this.isFailoverPolicyLoaded = false;
            bool done = false;
            ICosmosDBAccount databaseAccount = null;
            while (!done)
            {
                await SdkContext.DelayProvider.DelayAsync(5000, cancellationToken);
                databaseAccount = await this.Manager.CosmosDBAccounts.GetByResourceGroupAsync(
                    ResourceGroupName, Name);

                if (maxDelayDueToMissingFailovers > currentDelayDueToMissingFailovers &&
                    (databaseAccount.Id == null
                    || databaseAccount.Id.Length == 0
                    || locationParameters.Locations.Count >
                        databaseAccount.Inner.FailoverPolicies.Count))
                {
                    currentDelayDueToMissingFailovers += 5000;
                    continue;
                }

                if (this.IsProvisioningStateFinal(databaseAccount.Inner.ProvisioningState))
                {
                    done = true;
                    foreach (Models.Location location in databaseAccount.ReadableReplications)
                    {
                        if (!this.IsProvisioningStateFinal(location.ProvisioningState))
                        {
                            done = false;
                            break;
                        }
                    }
                }
            }

            List<Task> childTasks = new List<Task>();
            childTasks.Add(this.privateEndpointConnections.CommitAndGetAllAsync(cancellationToken));
            childTasks.Add(this.sqlDatabases.CommitAndGetAllAsync(cancellationToken));
            childTasks.Add(this.mongoDBs.CommitAndGetAllAsync(cancellationToken));
            childTasks.Add(this.cassandraKeyspaces.CommitAndGetAllAsync(cancellationToken));
            childTasks.Add(this.gremlinDatabases.CommitAndGetAllAsync(cancellationToken));
            childTasks.Add(this.tables.CommitAndGetAllAsync(cancellationToken));
            await Task.WhenAll(childTasks);

            this.SetInner(databaseAccount.Inner);
            this.initializeFailover();
            return databaseAccount;
        }

        private Models.DatabaseAccountCreateUpdateParameters CreateUpdateParametersInner(Models.DatabaseAccountGetResultsInner inner)
        {
            this.EnsureFailoverIsInitialized();
            Models.DatabaseAccountCreateUpdateParameters createUpdateParametersInner =
            new Models.DatabaseAccountCreateUpdateParameters();
            createUpdateParametersInner.Location = this.RegionName.ToLower();
            createUpdateParametersInner.ConsistencyPolicy = inner.ConsistencyPolicy;
            createUpdateParametersInner.IpRangeFilter = inner.IpRangeFilter;
            createUpdateParametersInner.Kind = inner.Kind;
            createUpdateParametersInner.Capabilities = inner.Capabilities;
            createUpdateParametersInner.Tags = inner.Tags;
            createUpdateParametersInner.IsVirtualNetworkFilterEnabled = inner.IsVirtualNetworkFilterEnabled;
            createUpdateParametersInner.EnableMultipleWriteLocations = inner.EnableMultipleWriteLocations;
            createUpdateParametersInner.EnableCassandraConnector = inner.EnableCassandraConnector;
            createUpdateParametersInner.ConnectorOffer = inner.ConnectorOffer;
            createUpdateParametersInner.EnableAutomaticFailover = inner.EnableAutomaticFailover;
            createUpdateParametersInner.DisableKeyBasedMetadataWriteAccess = inner.DisableKeyBasedMetadataWriteAccess;
            createUpdateParametersInner.KeyVaultKeyUri = inner.KeyVaultKeyUri;
            if (virtualNetworkRulesMap != null)
            {
                createUpdateParametersInner.VirtualNetworkRules = virtualNetworkRulesMap.Values.SelectMany(l => l).ToList();
                virtualNetworkRulesMap = null;
            }
            this.AddLocationsForParameters(new CreateUpdateLocationParameters(createUpdateParametersInner), this.failoverPolicies);
            return createUpdateParametersInner;
        }

        private DatabaseAccountUpdateParameters UpdateParametersInner(DatabaseAccountGetResultsInner inner)
        {
            this.EnsureFailoverIsInitialized();
            var updateParametersInner = new DatabaseAccountUpdateParameters();
            updateParametersInner.Tags = inner.Tags;
            updateParametersInner.Location = this.RegionName.ToLower();
            updateParametersInner.ConsistencyPolicy = inner.ConsistencyPolicy;
            updateParametersInner.IpRangeFilter = inner.IpRangeFilter;
            updateParametersInner.IsVirtualNetworkFilterEnabled = inner.IsVirtualNetworkFilterEnabled;
            updateParametersInner.EnableAutomaticFailover = inner.EnableAutomaticFailover;
            updateParametersInner.Capabilities = inner.Capabilities;
            updateParametersInner.EnableMultipleWriteLocations = inner.EnableMultipleWriteLocations;
            updateParametersInner.EnableCassandraConnector = inner.EnableCassandraConnector;
            updateParametersInner.ConnectorOffer = inner.ConnectorOffer;
            updateParametersInner.DisableKeyBasedMetadataWriteAccess = inner.DisableKeyBasedMetadataWriteAccess;
            updateParametersInner.KeyVaultKeyUri = inner.KeyVaultKeyUri;
            if (virtualNetworkRulesMap != null)
            {
                updateParametersInner.VirtualNetworkRules = this.virtualNetworkRulesMap.Values.SelectMany(l => l).ToList();
                this.virtualNetworkRulesMap = null;
            }
            AddLocationsForParameters(new UpdateLocationParameters(updateParametersInner), this.failoverPolicies);
            return updateParametersInner;
        }

        private bool IsProvisioningStateFinal(string state)
        {
            switch (state.ToLower())
            {
                case "succeeded":
                case "canceled":
                case "failed":
                    return true;
                default:
                    return false;
            }
        }

        public IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> WritableReplications()
        {
            return this.Inner.WriteLocations as IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location>;
        }

        public async Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListKeysResult> ListKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await this.Manager.Inner.DatabaseAccounts.ListKeysAsync(this.ResourceGroupName,
                this.Name);
            return result != null ? new DatabaseAccountListKeysResultImpl(result) : null;
        }

        public override async Task<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.DoDatabaseUpdateCreateAsync(cancellationToken);
        }

        public IDatabaseAccountListKeysResult ListKeys()
        {
            return Extensions.Synchronize(() => this.ListKeysAsync());
        }

        public string IPRangeFilter()
        {
            return this.Inner.IpRangeFilter;
        }

        public string Kind()
        {
            return this.Inner.Kind.Value;
        }
        public bool? MultipleWriteLocationsEnabled()
        {
            return this.Inner.EnableMultipleWriteLocations;
        }

        private void EnsureFailoverIsInitialized()
        {
            if (this.IsInCreateMode)
            {
                return;
            }

            if (!this.isFailoverPolicyLoaded)
            {
                this.initializeFailover();
            }
        }

        private void initializeFailover()
        {
            this.failoverPolicies.Clear();
            Models.Location[] locationInners = new Models.Location[this.Inner.Locations.Count];
            for (var i = 0; i < locationInners.Length; i++)
            {
                locationInners[i] = this.Inner.Locations[i];
            }

            Array.Sort(locationInners, (o1, o2) =>
            {
                return o1.FailoverPriority.GetValueOrDefault().CompareTo(o2.FailoverPriority.GetValueOrDefault());
            });

            for (int i = 0; i < locationInners.Length; i++)
            {
                this.failoverPolicies.Add(locationInners[i]);
            }

            this.isFailoverPolicyLoaded = true;
        }

        public CosmosDBAccountImpl WithStrongConsistency()
        {
            this.SetConsistencyPolicy(Models.DefaultConsistencyLevel.Strong, 0, 0);
            return this;
        }

        private void SetConsistencyPolicy(Models.DefaultConsistencyLevel level, long maxStalenessPrefix, int maxIntervalInSeconds)
        {
            var policy = new Models.ConsistencyPolicy();
            policy.DefaultConsistencyLevel = level;
            if (level == Models.DefaultConsistencyLevel.BoundedStaleness)
            {
                policy.MaxIntervalInSeconds = maxIntervalInSeconds;
                policy.MaxStalenessPrefix = (long)maxStalenessPrefix;
            }

            this.Inner.ConsistencyPolicy = policy;
        }

        public async Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListConnectionStringsResult> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await this.Manager.Inner.DatabaseAccounts.ListConnectionStringsAsync(this.ResourceGroupName,
                this.Name);
            return result != null ? new DatabaseAccountListConnectionStringsResultImpl(result) : null;
        }

        public async Task RegenerateKeyAsync(string keyKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.DatabaseAccounts.RegenerateKeyAsync(this.ResourceGroupName, this.Name, KeyKind.Parse(keyKind));
        }

        public CosmosDBAccountImpl WithKind(string kind)
        {
            this.Inner.Kind = DatabaseAccountKind.Parse(kind);
            return this;
        }

        public CosmosDBAccountImpl WithEventualConsistency()
        {
            this.SetConsistencyPolicy(Models.DefaultConsistencyLevel.Eventual, 0, 0);
            return this;
        }

        public CosmosDBAccountImpl WithBoundedStalenessConsistency(long maxStalenessPrefix, int maxIntervalInSeconds)
        {
            this.SetConsistencyPolicy(Models.DefaultConsistencyLevel.BoundedStaleness,
                maxStalenessPrefix,
                maxIntervalInSeconds);
            return this;
        }

        public Models.DefaultConsistencyLevel DefaultConsistencyLevel()
        {
            if (this.Inner.ConsistencyPolicy == null)
            {
                throw new Exception("Consistency policy is missing!");
            }

            return this.Inner.ConsistencyPolicy.DefaultConsistencyLevel;
        }

        public IDatabaseAccountListConnectionStringsResult ListConnectionStrings()
        {
            return Extensions.Synchronize(() => this.ListConnectionStringsAsync());
        }

        public Models.ConsistencyPolicy ConsistencyPolicy()
        {
            return this.Inner.ConsistencyPolicy;
        }

        public CosmosDBAccountImpl WithoutReadReplication(Region region)
        {
            this.EnsureFailoverIsInitialized();
            for (int i = 1; i < this.failoverPolicies.Count; i++)
            {
                if (this.failoverPolicies[i].LocationName != null)
                {
                    string locName = this.failoverPolicies[i].LocationName.Replace(" ", "").ToLower();
                    if (locName.Equals(region.Name))
                    {
                        this.failoverPolicies.RemoveAt(i);
                    }
                }
            }

            return this;
        }

        public CosmosDBAccountImpl WithSessionConsistency()
        {
            this.SetConsistencyPolicy(Models.DefaultConsistencyLevel.Session, 0, 0);
            return this;
        }

        private void AddLocationsForParameters(HasLocation locationParameters, IList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> failoverPolicies)
        {
            List<Models.Location> locations = new List<Models.Location>();
            if (failoverPolicies.Count > 0)
            {
                for (int i = 0; i < failoverPolicies.Count; ++i)
                {
                    failoverPolicies[i].FailoverPriority = i;
                }
                locations.AddRange(failoverPolicies);
            }
            else
            {
                Models.Location location = new Models.Location();
                location.FailoverPriority = 0;
                location.LocationName = locationParameters.Location;
                locations.Add(location);
            }

            locationParameters.Locations = locations;
        }

        public CosmosDBAccountImpl WithIpRangeFilter(string ipRangeFilter)
        {
            this.Inner.IpRangeFilter = ipRangeFilter;
            return this;
        }

        public CosmosDBAccountImpl WithWriteReplication(Region region, bool? isZoneRedundant)
        {
            Models.Location FailoverPolicy = new Models.Location();
            FailoverPolicy.LocationName = region.Name;
            FailoverPolicy.IsZoneRedundant = isZoneRedundant;
            FailoverPolicy.FailoverPriority = this.failoverPolicies.Count;
            this.isFailoverPolicyLoaded = true;
            this.failoverPolicies.Add(FailoverPolicy);
            return this;
        }

        public CosmosDBAccountImpl WithDefaultWriteReplication()
        {
            return this.WithWriteReplication(this.Region, null);
        }

        public string DocumentEndpoint()
        {
            return this.Inner.DocumentEndpoint;
        }

        public IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> ReadableReplications()
        {
            return this.Inner.ReadLocations as IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location>;
        }

        protected override async Task<Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountGetResultsInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.DatabaseAccounts.GetAsync(this.ResourceGroupName, this.Name);
        }

        public Models.DatabaseAccountOfferType DatabaseAccountOfferType()
        {
            return this.Inner.DatabaseAccountOfferType.GetValueOrDefault();
        }

        public void RegenerateKey(string keyKind)
        {
            Extensions.Synchronize(() => this.RegenerateKeyAsync(keyKind));
        }

        private static string FixDBName(string name)
        {
            return name.ToLower();
        }

        IWithOptionals IUpdateWithTags<IWithOptionals>.WithTags(IDictionary<string, string> tags)
        {
            this.WithTags(tags);
            return this;
        }

        IWithOptionals IUpdateWithTags<IWithOptionals>.WithTag(string key, string value)
        {
            this.WithTag(key, value);
            return this;
        }

        IWithOptionals IUpdateWithTags<IWithOptionals>.WithoutTag(string key)
        {
            this.WithoutTag(key);
            return this;
        }

        ///GENMHASH:199BC8B250DE6FDC60059ADB2A4D8A17:0D023FA55B68AD0828AD9BF823383A9A
        public IDatabaseAccountListReadOnlyKeysResult ListReadOnlyKeys()
        {
            return Extensions.Synchronize(() => this.ListReadOnlyKeysAsync());
        }

        ///GENMHASH:53B98D29180D0703E1A1842F17ACDE80:FC86BA20A774722CAD5A76DA690B6B40
        public async Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListReadOnlyKeysResult> ListReadOnlyKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await this.Manager.Inner.DatabaseAccounts
                .ListReadOnlyKeysAsync(this.ResourceGroupName, this.Name);
            return result != null ? new DatabaseAccountListReadOnlyKeysResultImpl(result) : null;
        }

        public IEnumerable<ISqlDatabase> ListSqlDatabases()
        {
            return Extensions.Synchronize(() => this.ListSqlDatabasesAsync());
        }

        public async Task<IEnumerable<ISqlDatabase>> ListSqlDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlDatabases.ListAsync(cancellationToken);
        }

        public ISqlDatabase GetSqlDatabase(string databaseName)
        {
            return Extensions.Synchronize(() => this.GetSqlDatabaseAsync(databaseName));
        }

        public async Task<ISqlDatabase> GetSqlDatabaseAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlDatabases.GetImplAsync(databaseName, cancellationToken);
        }

        ///GENMHASH:6A08D79B3D058AD12B94D8E88D3A66BB:CBB08B5D2F8EBB6B1A4BE51DA2907810
        public CosmosDBAccountImpl WithDataModelGremlin()
        {
            this.Inner.Kind = DatabaseAccountKind.GlobalDocumentDB;
            List<Capability> capabilities = new List<Capability>();
            capabilities.Add(new Capability("EnableGremlin"));
            this.Inner.Capabilities = capabilities;
            this.WithTag("defaultExperience", "Graph");

            return this;
        }

        ///GENMHASH:34B523C69C7FD510214D27D478D971AA:49F5455D8963DDB2BE21EA8B38B4C7BE
        public CosmosDBAccountImpl WithDataModelCassandra()
        {
            this.Inner.Kind = DatabaseAccountKind.GlobalDocumentDB;
            List<Capability> capabilities = new List<Capability>();
            capabilities.Add(new Capability("EnableCassandra"));
            this.Inner.Capabilities = capabilities;
            this.WithTag("defaultExperience", "Cassandra");
            return this;
        }

        ///GENMHASH:FE98547B907685F667775CEF9663148D:443A834D31456201597F04A15B4BD4A4
        public CosmosDBAccountImpl WithDataModelMongoDB()
        {
            this.Inner.Kind = DatabaseAccountKind.MongoDB;

            return this;
        }

        ///GENMHASH:D21A1256B8AE75B30461590AB84F759B:5B9CF5267A2EC5C6DB95D90298E3ADB2
        public CosmosDBAccountImpl WithDataModelSql()
        {
            this.Inner.Kind = DatabaseAccountKind.GlobalDocumentDB;

            return this;
        }

        ///GENMHASH:CA81479D1B8439CD804916091691404E:3032A4A8923DA7CE6CCD1FF98076F538
        public CosmosDBAccountImpl WithDataModelAzureTable()
        {
            this.Inner.Kind = DatabaseAccountKind.GlobalDocumentDB;
            List<Capability> capabilities = new List<Capability>();
            capabilities.Add(new Capability("EnableTable"));
            this.Inner.Capabilities = capabilities;
            this.WithTag("defaultExperience", "Table");

            return this;
        }

        ///GENMHASH:A86A41D6B877011AC6B43DCB0D23965B:1E42DEC842C982C7303E6EE753676F51
        public CosmosDBAccountImpl WithKind(DatabaseAccountKind kind, params Capability[] capabilities)
        {
            this.Inner.Kind = kind;
            this.Inner.Capabilities = capabilities;
            return this;
        }

        ///GENMHASH:35EB1A31F5F9EE9C1A764577CD186B0D:C38E77AA90C47C0D1306953EF1EEE431
        public IReadOnlyList<Models.Capability> Capabilities()
        {
            List<Capability> capabilities = new List<Capability>(this.Inner.Capabilities);
            return capabilities.AsReadOnly();
        }

        ///GENMHASH:AC3242CC7AFA5FD11163B235DA2E6D85:F7D80B9BD1E3B78FD1EE1DF1FBB4845E
        public CosmosDBAccountImpl WithVirtualNetworkRule(string virtualNetworkId, string subnetName, bool? ignoreMissingVNetServiceEndpoint)
        {
            this.Inner.IsVirtualNetworkFilterEnabled = true;
            string vnetId = virtualNetworkId + "/subnets/" + subnetName;
            var internalMap = EnsureVirtualNetworkRules();
            if (!internalMap.ContainsKey(vnetId))
            {
                internalMap.Add(vnetId, new List<VirtualNetworkRule>());
            }
            internalMap[vnetId].Add(new VirtualNetworkRule() { Id = vnetId, IgnoreMissingVNetServiceEndpoint = ignoreMissingVNetServiceEndpoint });
            return this;
        }

        public CosmosDBAccountImpl WithVirtualNetworkFilterEnabled(bool enable)
        {
            this.Inner.IsVirtualNetworkFilterEnabled = enable;
            return this;
        }

        public CosmosDBAccountImpl WithKeyVault(string keyVaultUri)
        {
            this.Inner.KeyVaultKeyUri = keyVaultUri;
            return this;
        }

        public CosmosDBAccountImpl WithoutKeyVault()
        {
            this.Inner.KeyVaultKeyUri = null;
            return this;
        }

        ///GENMHASH:2BAA9926FD32E7ED76BE6DA4E3CFDF0A:EC13F18969F111A4EF37992607E9430C
        public CosmosDBAccountImpl WithVirtualNetworkRules(IList<Models.VirtualNetworkRule> virtualNetworkRules)
        {
            var vnetRules = EnsureVirtualNetworkRules();
            if (virtualNetworkRules == null || virtualNetworkRules.Count == 0)
            {
                vnetRules.Clear();
                this.Inner.IsVirtualNetworkFilterEnabled = false;
            }
            else
            {
                this.Inner.IsVirtualNetworkFilterEnabled = true;
                foreach (var vnetRule in virtualNetworkRules)
                {
                    if (!this.virtualNetworkRulesMap.ContainsKey(vnetRule.Id))
                    {
                        this.virtualNetworkRulesMap.Add(vnetRule.Id, new List<VirtualNetworkRule>());
                    }
                    this.virtualNetworkRulesMap[vnetRule.Id].Add(vnetRule);
                }
            }
            return this;
        }

        ///GENMHASH:17381C8EEA34CDB3DCBE083E7F6D6502:89110E5415CB9D8F19001F6DD8615C07
        public CosmosDBAccountImpl WithoutVirtualNetworkRule(string virtualNetworkId, string subnetName)
        {
            var vnetRules = EnsureVirtualNetworkRules();
            vnetRules.Remove(virtualNetworkId + "/subnets/" + subnetName);
            if (vnetRules.Count == 0)
            {
                this.Inner.IsVirtualNetworkFilterEnabled = false;
            }
            return this;
        }

        public CosmosDBAccountImpl WithMultipleWriteLocationsEnabled(bool enabled)
        {
            this.Inner.EnableMultipleWriteLocations = enabled;
            return this;
        }

        ///GENMHASH:ED2CFE8848802E73EC1E094FD7531ECC:49712209F38177A621F85B96C0B5A1BD
        public IReadOnlyList<Models.VirtualNetworkRule> VirtualNetworkRules()
        {
            List<VirtualNetworkRule> result = (this.Inner != null && this.Inner.VirtualNetworkRules != null) ? new List<VirtualNetworkRule>(this.Inner.VirtualNetworkRules) : new List<VirtualNetworkRule>();
            return result.AsReadOnly();
        }

        ///GENMHASH:9DD08936D3B4E402E37AEF19676FBBE5:B75CF3B3BDA8D4D5A2337A51BF9E22A0
        private Dictionary<string, List<Models.VirtualNetworkRule>> EnsureVirtualNetworkRules()
        {
            if (this.virtualNetworkRulesMap == null)
            {
                this.virtualNetworkRulesMap = new Dictionary<string, List<VirtualNetworkRule>>();
                if (this.Inner != null && this.Inner.VirtualNetworkRules != null)
                {
                    foreach (var item in this.Inner.VirtualNetworkRules)
                    {
                        if (!this.virtualNetworkRulesMap.ContainsKey(item.Id))
                        {
                            this.virtualNetworkRulesMap.Add(item.Id, new List<VirtualNetworkRule>());
                        }
                        this.virtualNetworkRulesMap[item.Id].Add(item);
                    }
                }
            }
            return this.virtualNetworkRulesMap;
        }

        ///GENMHASH:6E12523D3FA35427B421697F84BC8C8E:CF5AA1C3299F3EAB8439C499BFAD21B3
        public void OfflineRegion(Region region)
        {
            Extensions.Synchronize(() => this.OfflineRegionAsync(region));
        }

        ///GENMHASH:ABD34DADCC62B1C6C4CAC76E3F30BA2A:BC9F58EA7772977E5CC09E30FDDA0E5F
        public async Task OfflineRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.DatabaseAccounts.OfflineRegionAsync(this.ResourceGroupName, this.Name, region.Name, cancellationToken);
        }

        ///GENMHASH:A81623860EADE07F6CC2D783FF2781AF:5E28B3B12A4E565FD3BC928F3675CF8A
        public void OnlineRegion(Region region)
        {
            Extensions.Synchronize(() => this.OnlineRegionAsync(region));
        }

        ///GENMHASH:0BDF69B81ED4468EAFAB0B382798913E:A9398126CC05684804C52BFD5F15265C
        public async Task OnlineRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.DatabaseAccounts.OnlineRegionAsync(this.ResourceGroupName, this.Name, region.Name, cancellationToken);
        }

        public override async Task<ICosmosDBAccount> RefreshAsync(CancellationToken cancellation = default(CancellationToken))
        {
            await base.RefreshAsync(cancellation);
            this.sqlDatabases = new SqlDatabasesImpl(this);
            this.mongoDBs = new MongoDBsImpl(this);
            this.cassandraKeyspaces = new CassandraKeyspacesImpl(this);
            this.gremlinDatabases = new GremlinDatabasesImpl(this);
            this.tables = new TablesImpl(this);
            return this;
        }

        public bool CassandraConnectorEnabled()
        {
            return this.Inner.EnableCassandraConnector ?? false;
        }

        public ConnectorOffer CassandraConnectorOffer()
        {
            return this.Inner.ConnectorOffer;
        }

        public CosmosDBAccountImpl WithCassandraConnector(ConnectorOffer connectorOffer)
        {
            this.Inner.EnableCassandraConnector = true;
            this.Inner.ConnectorOffer = connectorOffer;
            return this;
        }

        public CosmosDBAccountImpl WithoutCassandraConnector()
        {
            this.Inner.EnableCassandraConnector = false;
            this.Inner.ConnectorOffer = null;
            return this;
        }

        public bool KeyBaseMetadataWriteAccessDisabled()
        {
            return this.Inner.DisableKeyBasedMetadataWriteAccess ?? false;
        }

        public bool AutomaticFailoverEnabled()
        {
            return this.Inner.EnableAutomaticFailover ?? false;
        }

        public bool VirtualNetoworkFilterEnabled()
        {
            return this.Inner.IsVirtualNetworkFilterEnabled ?? false;
        }

        public string KeyVaultUri()
        {
            return this.Inner.KeyVaultKeyUri;
        }

        public CosmosDBAccountImpl WithDisableKeyBaseMetadataWriteAccess(bool disabled)
        {
            this.Inner.DisableKeyBasedMetadataWriteAccess = disabled;
            return this;
        }

        public CosmosDBAccountImpl WithAutomaticFailoverEnabled(bool enabled)
        {
            this.Inner.EnableAutomaticFailover = enabled;
            return this;
        }

        internal CosmosDBAccountImpl WithPrivateEndpointConnection(PrivateEndpointConnectionImpl privateEndpointConnection)
        {
            this.privateEndpointConnections.AddPrivateEndpointConnection(privateEndpointConnection);
            return this;
        }

        internal PrivateEndpointConnectionImpl DefineNewPrivateEndpointConnection(string name)
        {
            return this.privateEndpointConnections.Define(name);
        }

        internal PrivateEndpointConnectionImpl UpdatePrivateEndpointConnection(string name)
        {
            return this.privateEndpointConnections.Update(name);
        }

        public CosmosDBAccountImpl WithoutPrivateEndpointConnection(string name)
        {
            this.privateEndpointConnections.Remove(name);
            return this;
        }

        public IPrivateEndpointConnection GetPrivateEndpointConnection(string name)
        {
            return Extensions.Synchronize(() => this.GetPrivateEndpointConnectionAsync(name));
        }

        public async Task<IPrivateEndpointConnection> GetPrivateEndpointConnectionAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.privateEndpointConnections.GetImplAsync(name, cancellationToken);
        }

        public IReadOnlyDictionary<string, IPrivateEndpointConnection> ListPrivateEndpointConnection()
        {
            return Extensions.Synchronize(() => this.ListPrivateEndpointConnectionAsync());
        }

        public async Task<IReadOnlyDictionary<string, IPrivateEndpointConnection>> ListPrivateEndpointConnectionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var privateEndpointConnection = await this.privateEndpointConnections.AsMapAsync(cancellationToken);
            return privateEndpointConnection.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public IPrivateLinkResource GetPrivateLinkResource(string groupName)
        {
            return Extensions.Synchronize(() => this.GetPrivateLinkResourceAsync(groupName));
        }

        public async Task<IPrivateLinkResource> GetPrivateLinkResourceAsync(string groupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Manager.Inner.PrivateLinkResources.GetAsync(ResourceGroupName, Name, groupName, cancellationToken);
            return new PrivateLinkResourceImpl(inner);
        }

        public IReadOnlyList<IPrivateLinkResource> ListPrivateLinkResources()
        {
            return Extensions.Synchronize(() => this.ListPrivateLinkResourcesAsync());
        }

        public async Task<IReadOnlyList<IPrivateLinkResource>> ListPrivateLinkResourcesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inners = await this.Manager.Inner.PrivateLinkResources.ListByDatabaseAccountAsync(ResourceGroupName, Name, cancellationToken);

            var result = new List<IPrivateLinkResource>();
            foreach (var inner in inners)
            {
                result.Add(new PrivateLinkResourceImpl(inner));
            }
            return result;
        }

        internal CosmosDBAccountImpl WithSqlDatabase(SqlDatabaseImpl sqlDatabase)
        {
            this.sqlDatabases.AddSqlDatabase(sqlDatabase);
            return this;
        }

        internal SqlDatabaseImpl DefineNewSqlDatabase(string name)
        {
            return this.sqlDatabases.Define(name);
        }

        internal SqlDatabaseImpl UpdateSqlDatabase(string name)
        {
            return this.sqlDatabases.Update(name);
        }

        public CosmosDBAccountImpl WithoutSqlDatabase(string name)
        {
            this.sqlDatabases.Remove(name);
            return this;
        }

        public IEnumerable<IMongoDB> ListMongoDBs()
        {
            return Extensions.Synchronize(() => this.ListMongoDBsAsync());
        }

        public async Task<IEnumerable<IMongoDB>> ListMongoDBsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.mongoDBs.ListAsync(cancellationToken);
        }

        public IMongoDB GetMongoDB(string databaseName)
        {
            return Extensions.Synchronize(() => this.GetMongoDBAsync(databaseName));
        }

        public async Task<IMongoDB> GetMongoDBAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.mongoDBs.GetImplAsync(databaseName, cancellationToken);
        }
        internal CosmosDBAccountImpl WithMongoDB(MongoDBImpl mongoDB)
        {
            this.mongoDBs.AddMongoDB(mongoDB);
            return this;
        }

        internal MongoDBImpl DefineNewMongoDB(string name)
        {
            return this.mongoDBs.Define(name);
        }

        internal MongoDBImpl UpdateMongoDB(string name)
        {
            return this.mongoDBs.Update(name);
        }

        public CosmosDBAccountImpl WithoutMongoDB(string name)
        {
            this.mongoDBs.Remove(name);
            return this;
        }

        public IEnumerable<ICassandraKeyspace> ListCassandraKeyspaces()
        {
            return Extensions.Synchronize(() => this.ListCassandraKeyspacesAsync());
        }

        public async Task<IEnumerable<ICassandraKeyspace>> ListCassandraKeyspacesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.cassandraKeyspaces.ListAsync(cancellationToken);
        }

        public ICassandraKeyspace GetCassandraKeyspace(string databaseName)
        {
            return Extensions.Synchronize(() => this.GetCassandraKeyspaceAsync(databaseName));
        }

        public async Task<ICassandraKeyspace> GetCassandraKeyspaceAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.cassandraKeyspaces.GetImplAsync(databaseName, cancellationToken);
        }
        internal CosmosDBAccountImpl WithCassandraKeyspace(CassandraKeyspaceImpl cassandraKeyspace)
        {
            this.cassandraKeyspaces.AddCassandraKeyspace(cassandraKeyspace);
            return this;
        }

        internal CassandraKeyspaceImpl DefineNewCassandraKeyspace(string name)
        {
            return this.cassandraKeyspaces.Define(name);
        }

        internal CassandraKeyspaceImpl UpdateCassandraKeyspace(string name)
        {
            return this.cassandraKeyspaces.Update(name);
        }

        public CosmosDBAccountImpl WithoutCassandraKeyspace(string name)
        {
            this.cassandraKeyspaces.Remove(name);
            return this;
        }

        public IEnumerable<IGremlinDatabase> ListGremlinDatabases()
        {
            return Extensions.Synchronize(() => this.ListGremlinDatabasesAsync());
        }

        public async Task<IEnumerable<IGremlinDatabase>> ListGremlinDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.gremlinDatabases.ListAsync(cancellationToken);
        }

        public IGremlinDatabase GetGremlinDatabase(string databaseName)
        {
            return Extensions.Synchronize(() => this.GetGremlinDatabaseAsync(databaseName));
        }

        public async Task<IGremlinDatabase> GetGremlinDatabaseAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.gremlinDatabases.GetImplAsync(databaseName, cancellationToken);
        }
        internal CosmosDBAccountImpl WithGremlinDatabase(GremlinDatabaseImpl gremlinDatabase)
        {
            this.gremlinDatabases.AddGremlinDatabase(gremlinDatabase);
            return this;
        }

        internal GremlinDatabaseImpl DefineNewGremlinDatabase(string name)
        {
            return this.gremlinDatabases.Define(name);
        }

        internal GremlinDatabaseImpl UpdateGremlinDatabase(string name)
        {
            return this.gremlinDatabases.Update(name);
        }

        public CosmosDBAccountImpl WithoutGremlinDatabase(string name)
        {
            this.gremlinDatabases.Remove(name);
            return this;
        }

        public IEnumerable<ITable> ListTables()
        {
            return Extensions.Synchronize(() => this.ListTablesAsync());
        }

        public async Task<IEnumerable<ITable>> ListTablesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.tables.ListAsync(cancellationToken);
        }

        public ITable GetTable(string databaseName)
        {
            return Extensions.Synchronize(() => this.GetTableAsync(databaseName));
        }

        public async Task<ITable> GetTableAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.tables.GetImplAsync(databaseName, cancellationToken);
        }
        internal CosmosDBAccountImpl WithTable(TableImpl table)
        {
            this.tables.AddTable(table);
            return this;
        }

        internal TableImpl DefineNewTable(string name)
        {
            return this.tables.Define(name);
        }

        internal TableImpl UpdateTable(string name)
        {
            return this.tables.Update(name);
        }

        public CosmosDBAccountImpl WithoutTable(string name)
        {
            this.tables.Remove(name);
            return this;
        }

        interface HasLocation
        {
            string Location { get; }
            IList<Location> Locations { get; set; }
        }

        public class CreateUpdateLocationParameters : HasLocation
        {
            private DatabaseAccountCreateUpdateParameters parameters;

            public CreateUpdateLocationParameters(DatabaseAccountCreateUpdateParameters createUpdateParameters)
            {
                parameters = createUpdateParameters;
            }

            public string Location
            {
                get
                {
                    return parameters.Location;
                }
            }

            public IList<Location> Locations
            {
                get
                {
                    return parameters.Locations;
                }
                set
                {
                    parameters.Locations = value;
                }
            }
        }

        public class UpdateLocationParameters : HasLocation
        {
            private DatabaseAccountUpdateParameters parameters;

            public UpdateLocationParameters(DatabaseAccountUpdateParameters updateParameters)
            {
                parameters = updateParameters;
            }

            public string Location
            {
                get
                {
                    return parameters.Location;
                }
            }

            public IList<Location> Locations
            {
                get
                {
                    return parameters.Locations;
                }
                set
                {
                    parameters.Locations = value;
                }
            }
        }
    }
}