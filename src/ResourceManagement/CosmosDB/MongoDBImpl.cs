// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class MongoDBImpl :
        ExternalChildResource<IMongoDB,
            MongoDBDatabaseGetResultsInner,
            ICosmosDBAccount,
            CosmosDBAccountImpl>,
        IMongoDB,
        MongoDB.Definition.IDefinition<CosmosDBAccount.Definition.IWithCreate>,
        MongoDB.Update.IUpdate,
        MongoDB.Definition.IDefinition<CosmosDBAccount.Update.IWithOptionals>
    {
        private IMongoDBResourcesOperations Client { get { return Parent.Manager.Inner.MongoDBResources; } }
        private MongoDBDatabaseCreateUpdateParameters createUpdateParameters;
        private ThroughputSettingsUpdateParameters throughputSettingsToUpdate;
        private MongoCollectionsImpl collections;

        internal MongoDBImpl(string name, CosmosDBAccountImpl parent, MongoDBDatabaseGetResultsInner inner)
            : base(name, parent, inner)
        {
            this.collections = new MongoCollectionsImpl(this);
            InitializeCreateUpdateParameters();
        }

        private void InitializeCreateUpdateParameters()
        {
            this.createUpdateParameters = new MongoDBDatabaseCreateUpdateParameters()
            {
                Location = Parent.Inner.Location,
                Resource = new MongoDBDatabaseResource(id: this.Name()),
                Options = new CreateUpdateOptions(),
            };
        }

        public string MongoDBId()
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

        public MongoDBImpl WithOption(string key, string value)
        {
            if (this.createUpdateParameters.Options.AdditionalProperties == null)
                this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            this.createUpdateParameters.Options.AdditionalProperties.Add(key, value);
            return this;
        }

        public MongoDBImpl WithOptionsAppend(IDictionary<string, string> options)
        {
            if (this.createUpdateParameters.Options.AdditionalProperties == null)
                this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.AdditionalProperties.Add(option.Key, option.Value);
            }
            return this;
        }

        public MongoDBImpl WithOptionsReplace(IDictionary<string, string> options)
        {
            this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.AdditionalProperties.Add(option.Key, option.Value);
            }
            return this;
        }

        public MongoDBImpl WithoutOption(string key)
        {
            this.createUpdateParameters.Options.AdditionalProperties?.Remove(key);
            return this;
        }

        public MongoDBImpl WithoutOptions()
        {
            this.createUpdateParameters.Options.AdditionalProperties = null;
            return this;
        }

        public MongoDBImpl WithThroughput(int throughput)
        {
            this.createUpdateParameters.Options.Throughput = throughput.ToString();
            return this;
        }

        public CosmosDBAccountImpl Attach()
        {
            return this.Parent.WithMongoDB(this);
        }

        public async override Task<IMongoDB> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Client.CreateUpdateMongoDBDatabaseAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                this.Name(),
                this.createUpdateParameters,
                cancellationToken
                );

            SetInner(inner);
            InitializeCreateUpdateParameters();
            List<Task> childTasks = new List<Task>();

            if (this.throughputSettingsToUpdate != null)
            {
                this.throughputSettingsToUpdate.Location = Parent.RegionName.ToLower();
                childTasks.Add(this.Client.UpdateMongoDBDatabaseThroughputAsync(
                    Parent.ResourceGroupName,
                    Parent.Name,
                    this.Name(),
                    this.throughputSettingsToUpdate,
                    cancellationToken
                    ));

                this.throughputSettingsToUpdate = null;
            }

            childTasks.Add(this.collections.CommitAndGetAllAsync(cancellationToken));
            await Task.WhenAll(childTasks);

            return this;
        }

        public async override Task<IMongoDB> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateAsync(cancellationToken);
        }

        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Client.DeleteMongoDBDatabaseAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                this.Name(),
                cancellationToken
                );
        }

        protected async override Task<MongoDBDatabaseGetResultsInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Client.GetMongoDBDatabaseAsync(
                Parent.ResourceGroupName,
                Parent.Name,
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
            var throughput = await this.Client.GetMongoDBDatabaseThroughputAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                this.Name(),
                cancellationToken
                );
            return throughput.Resource;
        }

        public MongoDBImpl WithCollection(MongoCollectionImpl collection)
        {
            this.collections.AddMongoCollection(collection);
            return this;
        }

        public MongoCollectionImpl DefineNewCollection(string name)
        {
            return this.collections.Define(name);
        }

        public MongoCollectionImpl UpdateCollection(string name)
        {
            return this.collections.Update(name);
        }

        public MongoDBImpl WithoutCollection(string name)
        {
            this.collections.Remove(name);
            return this;
        }

        public IEnumerable<IMongoCollection> ListCollections()
        {
            return Extensions.Synchronize(() => this.ListCollectionsAsync());
        }

        public async Task<IEnumerable<IMongoCollection>> ListCollectionsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.collections.ListAsync(cancellationToken);
        }

        public IMongoCollection GetCollection(string name)
        {
            return Extensions.Synchronize(() => this.GetCollectionAsync(name));
        }

        public async Task<IMongoCollection> GetCollectionAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.collections.GetImplAsync(name, cancellationToken);
        }
    }
}
