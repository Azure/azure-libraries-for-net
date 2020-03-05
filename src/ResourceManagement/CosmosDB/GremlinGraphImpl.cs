// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;

    using DefinitionParentT = GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>;
    using UpdateDefinitionParentT = GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>;
    using DefinitionIndexingPolicyImpl = IndexingPolicyImpl<GremlinGraphImpl, IGremlinGraph, GremlinGraph.Definition.IWithAttach<GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>, GremlinGraph.Update.IUpdate>;
    using UpdateDefinitionIndexingPolicyImpl = IndexingPolicyImpl<GremlinGraphImpl, IGremlinGraph, GremlinGraph.Definition.IWithAttach<GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>>, GremlinGraph.Update.IUpdate>;
    using UpdateIndexingPolicyImpl = IndexingPolicyImpl<GremlinGraphImpl, IGremlinGraph, GremlinGraph.Definition.IWithAttach<GremlinDatabase.Update.IUpdate>, GremlinGraph.Update.IUpdate>;

    internal partial class GremlinGraphImpl :
        ExternalChildResource<IGremlinGraph,
            GremlinGraphGetResultsInner,
            IGremlinDatabase,
            GremlinDatabaseImpl>,
        IGremlinGraph,
        GremlinGraph.Definition.IDefinition<DefinitionParentT>,
        GremlinGraph.Definition.IDefinition<UpdateDefinitionParentT>,
        GremlinGraph.Definition.IDefinition<GremlinDatabase.Update.IUpdate>,
        GremlinGraph.Update.IUpdate,
        IHasIndexingPolicy<GremlinGraphImpl>
    {
        private IGremlinResourcesOperations Client { get { return Parent.Parent.Manager.Inner.GremlinResources; } }
        private GremlinGraphCreateUpdateParameters createUpdateParameters;
        private ThroughputSettingsUpdateParameters throughputSettingsToUpdate;

        private string Location
        {
            get
            {
                return Parent.Parent.RegionName.ToLower();
            }
        }

        private string ResourceGroupName
        {
            get
            {
                return Parent.Parent.ResourceGroupName;
            }
        }

        private string AccountName
        {
            get
            {
                return Parent.Parent.Name;
            }
        }

        private string GremlinDatabaseName
        {
            get
            {
                return Parent.Name();
            }
        }

        internal GremlinGraphImpl(string name, GremlinDatabaseImpl parent, GremlinGraphGetResultsInner inner)
            : base(name, parent, inner)
        {
            InitializeCreateUpdateParameters();
            InitChildResource();
        }

        private void InitChildResource()
        {
            this.throughputSettingsToUpdate = null;
        }

        private void InitializeCreateUpdateParameters()
        {
            this.createUpdateParameters = new GremlinGraphCreateUpdateParameters()
            {
                Location = this.Location,
                Resource = new GremlinGraphResource(id: this.Name()),
                Options = new CreateUpdateOptions(),
            };

            if (Inner.Resource != null)
            {
                this.createUpdateParameters.Resource.IndexingPolicy = Inner.Resource.IndexingPolicy;
                this.createUpdateParameters.Resource.PartitionKey = Inner.Resource.PartitionKey;
                this.createUpdateParameters.Resource.UniqueKeyPolicy = Inner.Resource.UniqueKeyPolicy;
                this.createUpdateParameters.Resource.ConflictResolutionPolicy = Inner.Resource.ConflictResolutionPolicy;
                this.createUpdateParameters.Resource.DefaultTtl = Inner.Resource.DefaultTtl;
            }
        }

        public string GremlinGraphId()
        {
            return this.Inner.Resource.Id;
        }

        public string _rid()
        {
            return this.Inner.Resource._rid;
        }

        public object _ts()
        {
            return this.Inner.Resource._ts;
        }

        public string _etag()
        {
            return this.Inner.Resource._etag;
        }

        public string Id()
        {
            return this.Inner.Id;
        }

        public Models.IndexingPolicy IndexingPolicy()
        {
            return this.Inner.Resource.IndexingPolicy;
        }

        public Models.ContainerPartitionKey PartitionKey()
        {
            return this.Inner.Resource.PartitionKey;
        }

        public int? DefaultTtl()
        {
            return this.Inner.Resource.DefaultTtl;
        }

        public Models.UniqueKeyPolicy UniqueKeyPolicy()
        {
            return this.Inner.Resource.UniqueKeyPolicy;
        }

        public Models.ConflictResolutionPolicy ConflictResolutionPolicy()
        {
            return this.Inner.Resource.ConflictResolutionPolicy;
        }

        public GremlinGraphImpl WithOption(string key, string value)
        {
            if (this.createUpdateParameters.Options.AdditionalProperties == null)
                this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            this.createUpdateParameters.Options.AdditionalProperties.Add(key, value);
            return this;
        }

        public GremlinGraphImpl WithOptionsAppend(IDictionary<string, string> options)
        {
            if (this.createUpdateParameters.Options.AdditionalProperties == null)
                this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.AdditionalProperties.Add(option.Key, option.Value);
            }
            return this;
        }

        public GremlinGraphImpl WithOptionsReplace(IDictionary<string, string> options)
        {
            this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.AdditionalProperties.Add(option.Key, option.Value);
            }
            return this;
        }

        public GremlinGraphImpl WithoutOption(string key)
        {
            this.createUpdateParameters.Options.AdditionalProperties?.Remove(key);
            return this;
        }

        public GremlinGraphImpl WithoutOptions()
        {
            this.createUpdateParameters.Options.AdditionalProperties = null;
            return this;
        }

        public GremlinGraphImpl WithThroughput(int throughput)
        {
            this.createUpdateParameters.Options.Throughput = throughput.ToString();
            return this;
        }

        public GremlinDatabaseImpl Attach()
        {
            return this.Parent.WithGremlinGraph(this);
        }

        public async override Task<IGremlinGraph> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Client.CreateUpdateGremlinGraphAsync(
                ResourceGroupName,
                AccountName,
                GremlinDatabaseName,
                this.Name(),
                this.createUpdateParameters,
                cancellationToken
                );

            SetInner(inner);
            InitializeCreateUpdateParameters();
            List<Task> childTasks = new List<Task>();

            if (this.throughputSettingsToUpdate != null)
            {
                this.throughputSettingsToUpdate.Location = Location;
                childTasks.Add(this.Client.UpdateGremlinGraphThroughputAsync(
                    ResourceGroupName,
                    AccountName,
                    GremlinDatabaseName,
                    Name(),
                    this.throughputSettingsToUpdate,
                    cancellationToken
                    ));
            }

            await Task.WhenAll(childTasks);
            InitChildResource();

            return this;
        }

        public async override Task<IGremlinGraph> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateAsync(cancellationToken);
        }

        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Client.DeleteGremlinGraphAsync(
                Parent.Parent.ResourceGroupName,
                Parent.Parent.Name,
                Parent.Name(),
                this.Name(),
                cancellationToken
                );
        }

        protected async override Task<GremlinGraphGetResultsInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Client.GetGremlinGraphAsync(
                Parent.Parent.ResourceGroupName,
                Parent.Parent.Name,
                Parent.Name(),
                this.Name(),
                cancellationToken
                );
        }

        public ThroughputSettingsGetPropertiesResource GetThroughputSettings()
        {
            return Extensions.Synchronize(() => this.GetThroughputSettingsAsync());
        }

        public async Task<ThroughputSettingsGetPropertiesResource> GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var throughput = await this.Client.GetGremlinGraphThroughputAsync(
                Parent.Parent.ResourceGroupName,
                Parent.Parent.Name,
                Parent.Name(),
                this.Name(),
                cancellationToken
                );
            return throughput.Resource;
        }

        public GremlinGraphImpl WithIndexingPolicy(Models.IndexingPolicy indexingPolicy)
        {
            this.createUpdateParameters.Resource.IndexingPolicy = indexingPolicy;
            return this;
        }

        public GremlinGraphImpl WithoutIndexingPolicy()
        {
            this.createUpdateParameters.Resource.IndexingPolicy = null;
            return this;
        }

        public DefinitionIndexingPolicyImpl DefineIndexingPolicy()
        {
            return new DefinitionIndexingPolicyImpl(new Models.IndexingPolicy(), this);
        }

        public DefinitionIndexingPolicyImpl UpdateIndexingPolicy()
        {
            Models.IndexingPolicy indexingPolicyInner = this.createUpdateParameters.Resource.IndexingPolicy ?? new Models.IndexingPolicy();
            return new DefinitionIndexingPolicyImpl(indexingPolicyInner, this);
        }

        public UpdateDefinitionIndexingPolicyImpl DefineIndexingPolicyInParentUpdateDefinition()
        {
            return new UpdateDefinitionIndexingPolicyImpl(new Models.IndexingPolicy(), this);
        }

        public UpdateIndexingPolicyImpl DefineIndexingPolicyInParentUpdate()
        {
            return new UpdateIndexingPolicyImpl(new Models.IndexingPolicy(), this);
        }

        public GremlinGraphImpl WithPartitionKey(ContainerPartitionKey containerPartitionKey)
        {
            this.createUpdateParameters.Resource.PartitionKey = containerPartitionKey;
            return this;
        }

        public GremlinGraphImpl WithPartitionKey(IList<string> paths, PartitionKind kind, int? version)
        {
            return this.WithPartitionKey(new ContainerPartitionKey(paths: paths, kind: kind, version: version));
        }

        public GremlinGraphImpl WithoutPartitionKey()
        {
            this.createUpdateParameters.Resource.PartitionKey = null;
            return this;
        }

        public GremlinGraphImpl WithDefaultTtl(int ttl)
        {
            this.createUpdateParameters.Resource.DefaultTtl = ttl;
            return this;
        }

        public GremlinGraphImpl WithoutDefaultTtl()
        {
            this.createUpdateParameters.Resource.DefaultTtl = null;
            return this;
        }

        public GremlinGraphImpl WithUniqueKeyPolicy(UniqueKeyPolicy uniqueKeyPolicy)
        {
            this.createUpdateParameters.Resource.UniqueKeyPolicy = uniqueKeyPolicy;
            return this;
        }

        public GremlinGraphImpl WithoutUniqueKeyPolicy()
        {
            this.createUpdateParameters.Resource.UniqueKeyPolicy = null;
            return this;
        }

        public GremlinGraphImpl WithUniqueKeys(IList<UniqueKey> uniqueKeys)
        {
            if (this.createUpdateParameters.Resource.UniqueKeyPolicy == null)
            {
                this.createUpdateParameters.Resource.UniqueKeyPolicy = new UniqueKeyPolicy();
            }
            if (this.createUpdateParameters.Resource.UniqueKeyPolicy.UniqueKeys == null)
            {
                this.createUpdateParameters.Resource.UniqueKeyPolicy.UniqueKeys = new List<UniqueKey>();
            }
            foreach (var uniqueKey in uniqueKeys)
            {
                this.createUpdateParameters.Resource.UniqueKeyPolicy.UniqueKeys.Add(uniqueKey);
            }
            return this;
        }

        public GremlinGraphImpl WithUniqueKey(UniqueKey uniqueKey)
        {
            if (this.createUpdateParameters.Resource.UniqueKeyPolicy == null)
            {
                this.createUpdateParameters.Resource.UniqueKeyPolicy = new UniqueKeyPolicy();
            }
            if (this.createUpdateParameters.Resource.UniqueKeyPolicy.UniqueKeys == null)
            {
                this.createUpdateParameters.Resource.UniqueKeyPolicy.UniqueKeys = new List<UniqueKey>();
            }

            this.createUpdateParameters.Resource.UniqueKeyPolicy.UniqueKeys.Add(uniqueKey);
            return this;
        }

        public GremlinGraphImpl WithConflictResolutionPolicy(ConflictResolutionPolicy conflictResolutionPolicy)
        {
            this.createUpdateParameters.Resource.ConflictResolutionPolicy = conflictResolutionPolicy;
            return this;
        }

        public GremlinGraphImpl WithoutConflictResolutionPolicy()
        {
            this.createUpdateParameters.Resource.ConflictResolutionPolicy = null;
            return this;
        }
    }
}
