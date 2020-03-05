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

    using DefinitionParentT = MongoDB.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>;
    using UpdateDefinitionParentT = MongoDB.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>;

    internal partial class MongoCollectionImpl :
        ExternalChildResource<IMongoCollection,
            MongoDBCollectionGetResultsInner,
            IMongoDB,
            MongoDBImpl>,
        IMongoCollection,
        MongoCollection.Definition.IDefinition<DefinitionParentT>,
        MongoCollection.Definition.IDefinition<UpdateDefinitionParentT>,
        MongoCollection.Definition.IDefinition<MongoDB.Update.IUpdate>,
        MongoCollection.Update.IUpdate
    {
        private IMongoDBResourcesOperations Client { get { return Parent.Parent.Manager.Inner.MongoDBResources; } }
        private MongoDBCollectionCreateUpdateParameters createUpdateParameters;
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

        private string MongoDBName
        {
            get
            {
                return Parent.Name();
            }
        }

        internal MongoCollectionImpl(string name, MongoDBImpl parent, MongoDBCollectionGetResultsInner inner)
            : base(name, parent, inner)
        {
            InitializeCreateUpdateParameters();
        }

        private void InitializeCreateUpdateParameters()
        {
            this.createUpdateParameters = new MongoDBCollectionCreateUpdateParameters()
            {
                Location = this.Location,
                Resource = new MongoDBCollectionResource(id: this.Name()),
                Options = new CreateUpdateOptions(),
            };

            if (Inner.Resource != null)
            {
                this.createUpdateParameters.Resource.ShardKey = Inner.Resource.ShardKey;
                this.createUpdateParameters.Resource.Indexes = Inner.Resource.Indexes;
            }
        }

        public string MongoCollectionId()
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

        public IReadOnlyList<MongoIndex> Indexes()
        {
            return this.Inner.Resource.Indexes.ToList();
        }

        public IReadOnlyDictionary<string, string> ShardKey()
        {
            return this.Inner.Resource.ShardKey.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public MongoCollectionImpl WithOption(string key, string value)
        {
            if (this.createUpdateParameters.Options.AdditionalProperties == null)
                this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            this.createUpdateParameters.Options.AdditionalProperties.Add(key, value);
            return this;
        }

        public MongoCollectionImpl WithOptionsAppend(IDictionary<string, string> options)
        {
            if (this.createUpdateParameters.Options.AdditionalProperties == null)
                this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.AdditionalProperties.Add(option.Key, option.Value);
            }
            return this;
        }

        public MongoCollectionImpl WithOptionsReplace(IDictionary<string, string> options)
        {
            this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.AdditionalProperties.Add(option.Key, option.Value);
            }
            return this;
        }

        public MongoCollectionImpl WithoutOption(string key)
        {
            this.createUpdateParameters.Options.AdditionalProperties?.Remove(key);
            return this;
        }

        public MongoCollectionImpl WithoutOptions()
        {
            this.createUpdateParameters.Options.AdditionalProperties = null;
            return this;
        }

        public MongoCollectionImpl WithThroughput(int throughput)
        {
            this.createUpdateParameters.Options.Throughput = throughput.ToString();
            return this;
        }

        public MongoDBImpl Attach()
        {
            return this.Parent.WithCollection(this);
        }

        public async override Task<IMongoCollection> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Client.CreateUpdateMongoDBCollectionAsync(
                ResourceGroupName,
                AccountName,
                MongoDBName,
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
                childTasks.Add(this.Client.UpdateMongoDBCollectionThroughputAsync(
                    ResourceGroupName,
                    AccountName,
                    MongoDBName,
                    Name(),
                    this.throughputSettingsToUpdate,
                    cancellationToken
                    ));
            }

            await Task.WhenAll(childTasks);

            this.throughputSettingsToUpdate = null;

            return this;
        }

        public async override Task<IMongoCollection> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateAsync(cancellationToken);
        }

        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Client.DeleteMongoDBCollectionAsync(
                Parent.Parent.ResourceGroupName,
                Parent.Parent.Name,
                Parent.Name(),
                this.Name(),
                cancellationToken
                );
        }

        protected async override Task<MongoDBCollectionGetResultsInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Client.GetMongoDBCollectionAsync(
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
            var throughput = await this.Client.GetMongoDBCollectionThroughputAsync(
                Parent.Parent.ResourceGroupName,
                Parent.Parent.Name,
                Parent.Name(),
                this.Name(),
                cancellationToken
                );
            return throughput.Resource;
        }

        public MongoCollectionImpl WithShardKey(string shardKey)
        {
            return this.WithShardKey(shardKey, "Hash");
        }

        public MongoCollectionImpl WithShardKey(string shardKey, string partitionKind)
        {
            if (this.createUpdateParameters.Resource.ShardKey == null)
            {
                this.createUpdateParameters.Resource.ShardKey = new Dictionary<string, string>();
            }

            this.createUpdateParameters.Resource.ShardKey.Add(shardKey, partitionKind);
            return this;
        }

        public MongoCollectionImpl WithShardKeys(IDictionary<string, string> shardKeys)
        {
            if (this.createUpdateParameters.Resource.ShardKey == null)
            {
                this.createUpdateParameters.Resource.ShardKey = new Dictionary<string, string>();
            }

            foreach (var shardKey in shardKeys)
            {
                this.createUpdateParameters.Resource.ShardKey.Add(shardKey);
            }
            return this;
        }

        public MongoCollectionImpl WithoutShardKey(string shardKey)
        {
            this.createUpdateParameters.Resource.ShardKey?.Remove(shardKey);
            return this;
        }

        public MongoCollectionImpl WithoutShardKeys()
        {
            this.createUpdateParameters.Resource.ShardKey = null;
            return this;
        }

        public MongoCollectionImpl WithIndex(MongoIndex index)
        {
            if (this.createUpdateParameters.Resource.Indexes == null)
            {
                this.createUpdateParameters.Resource.Indexes = new List<MongoIndex>();
            }

            this.createUpdateParameters.Resource.Indexes.Add(index);
            return this;
        }

        public MongoCollectionImpl WithIndex(MongoIndexKeys key, MongoIndexOptions option)
        {
            return this.WithIndex(new MongoIndex(key: key, options: option));
        }

        public MongoCollectionImpl WithIndexesAppend(IList<MongoIndex> indexes)
        {
            if (this.createUpdateParameters.Resource.Indexes == null)
            {
                this.createUpdateParameters.Resource.Indexes = new List<MongoIndex>();
            }

            foreach (MongoIndex index in indexes)
            {
                this.createUpdateParameters.Resource.Indexes.Add(index);
            }
            return this;
        }

        public MongoCollectionImpl WithIndexesReplace(IList<MongoIndex> indexes)
        {
            this.createUpdateParameters.Resource.Indexes = new List<MongoIndex>();
            foreach (MongoIndex index in indexes)
            {
                this.createUpdateParameters.Resource.Indexes.Add(index);
            }
            return this;
        }

        public MongoCollectionImpl WithoutIndexes()
        {
            this.createUpdateParameters.Resource.Indexes = null;
            return this;
        }
    }
}
