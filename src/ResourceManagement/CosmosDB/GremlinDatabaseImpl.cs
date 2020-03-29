// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class GremlinDatabaseImpl :
        ExternalChildResource<IGremlinDatabase,
            GremlinDatabaseGetResultsInner,
            ICosmosDBAccount,
            CosmosDBAccountImpl>,
        IGremlinDatabase,
        GremlinDatabase.Definition.IDefinition<CosmosDBAccount.Definition.IWithCreate>,
        GremlinDatabase.Update.IUpdate,
        GremlinDatabase.Definition.IDefinition<CosmosDBAccount.Update.IWithOptionals>
    {
        private IGremlinResourcesOperations Client { get { return Parent.Manager.Inner.GremlinResources; } }
        private GremlinDatabaseCreateUpdateParameters createUpdateParameters;
        private ThroughputSettingsUpdateParameters throughputSettingsToUpdate;
        private GremlinGraphsImpl gremlinGraphs;

        internal GremlinDatabaseImpl(string name, CosmosDBAccountImpl parent, GremlinDatabaseGetResultsInner inner)
            : base(name, parent, inner)
        {
            this.gremlinGraphs = new GremlinGraphsImpl(this);
            InitializeCreateUpdateParameters();
        }

        private void InitializeCreateUpdateParameters()
        {
            this.createUpdateParameters = new GremlinDatabaseCreateUpdateParameters()
            {
                Location = Parent.Inner.Location,
                Resource = new GremlinDatabaseResource(id: this.Name()),
                Options = new CreateUpdateOptions(),
            };
        }

        public string GremlinDatabaseId()
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

        public GremlinDatabaseImpl WithOption(string key, string value)
        {
            if (this.createUpdateParameters.Options.AdditionalProperties == null)
                this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            this.createUpdateParameters.Options.AdditionalProperties.Add(key, value);
            return this;
        }

        public GremlinDatabaseImpl WithOptionsAppend(IDictionary<string, string> options)
        {
            if (this.createUpdateParameters.Options.AdditionalProperties == null)
                this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.AdditionalProperties.Add(option.Key, option.Value);
            }
            return this;
        }

        public GremlinDatabaseImpl WithOptionsReplace(IDictionary<string, string> options)
        {
            this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.AdditionalProperties.Add(option.Key, option.Value);
            }
            return this;
        }

        public GremlinDatabaseImpl WithoutOption(string key)
        {
            this.createUpdateParameters.Options.AdditionalProperties?.Remove(key);
            return this;
        }

        public GremlinDatabaseImpl WithoutOptions()
        {
            this.createUpdateParameters.Options.AdditionalProperties = null;
            return this;
        }

        public GremlinDatabaseImpl WithThroughput(int throughput)
        {
            this.createUpdateParameters.Options.Throughput = throughput.ToString();
            return this;
        }

        public CosmosDBAccountImpl Attach()
        {
            return this.Parent.WithGremlinDatabase(this);
        }

        public async override Task<IGremlinDatabase> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Client.CreateUpdateGremlinDatabaseAsync(
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
                childTasks.Add(this.Client.UpdateGremlinDatabaseThroughputAsync(
                    Parent.ResourceGroupName,
                    Parent.Name,
                    this.Name(),
                    this.throughputSettingsToUpdate,
                    cancellationToken
                    ));

                this.throughputSettingsToUpdate = null;
            }

            childTasks.Add(this.gremlinGraphs.CommitAndGetAllAsync(cancellationToken));
            await Task.WhenAll(childTasks);

            return this;
        }

        public async override Task<IGremlinDatabase> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateAsync(cancellationToken);
        }

        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Client.DeleteGremlinDatabaseAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                this.Name(),
                cancellationToken
                );
        }

        protected async override Task<GremlinDatabaseGetResultsInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Client.GetGremlinDatabaseAsync(
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
            var throughput = await this.Client.GetGremlinDatabaseThroughputAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                this.Name(),
                cancellationToken
                );
            return throughput.Resource;
        }

        public GremlinDatabaseImpl WithGremlinGraph(GremlinGraphImpl gremlinGraph)
        {
            this.gremlinGraphs.AddGremlinGraph(gremlinGraph);
            return this;
        }

        public GremlinGraphImpl DefineNewGremlinGraph(string name)
        {
            return this.gremlinGraphs.Define(name);
        }

        public GremlinGraphImpl UpdateGremlinGraph(string name)
        {
            return this.gremlinGraphs.Update(name);
        }

        public GremlinDatabaseImpl WithoutGremlinGraph(string name)
        {
            this.gremlinGraphs.Remove(name);
            return this;
        }

        public IEnumerable<IGremlinGraph> ListGremlinGraphs()
        {
            return Extensions.Synchronize(() => this.ListGremlinGraphsAsync());
        }

        public async Task<IEnumerable<IGremlinGraph>> ListGremlinGraphsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.gremlinGraphs.ListAsync(cancellationToken);
        }

        public IGremlinGraph GetGremlinGraph(string name)
        {
            return Extensions.Synchronize(() => this.GetGremlinGraphAsync(name));
        }

        public async Task<IGremlinGraph> GetGremlinGraphAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.gremlinGraphs.GetImplAsync(name, cancellationToken);
        }
    }
}
