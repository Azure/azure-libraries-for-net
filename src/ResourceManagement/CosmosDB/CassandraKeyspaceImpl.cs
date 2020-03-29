// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class CassandraKeyspaceImpl :
        ExternalChildResource<ICassandraKeyspace,
            CassandraKeyspaceGetResultsInner,
            ICosmosDBAccount,
            CosmosDBAccountImpl>,
        ICassandraKeyspace,
        CassandraKeyspace.Definition.IDefinition<CosmosDBAccount.Definition.IWithCreate>,
        CassandraKeyspace.Update.IUpdate,
        CassandraKeyspace.Definition.IDefinition<CosmosDBAccount.Update.IWithOptionals>
    {
        private ICassandraResourcesOperations Client { get { return Parent.Manager.Inner.CassandraResources; } }
        private CassandraKeyspaceCreateUpdateParameters createUpdateParameters;
        private ThroughputSettingsUpdateParameters throughputSettingsToUpdate;
        private CassandraTablesImpl cassandraTables;

        internal CassandraKeyspaceImpl(string name, CosmosDBAccountImpl parent, CassandraKeyspaceGetResultsInner inner)
            : base(name, parent, inner)
        {
            this.cassandraTables = new CassandraTablesImpl(this);
            InitializeCreateUpdateParameters();
        }

        private void InitializeCreateUpdateParameters()
        {
            this.createUpdateParameters = new CassandraKeyspaceCreateUpdateParameters()
            {
                Location = Parent.Inner.Location,
                Resource = new CassandraKeyspaceResource(id: this.Name()),
                Options = new CreateUpdateOptions(),
            };
        }

        public string CassandraKeyspaceId()
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

        public CassandraKeyspaceImpl WithOption(string key, string value)
        {
            if (this.createUpdateParameters.Options.AdditionalProperties == null)
                this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            this.createUpdateParameters.Options.AdditionalProperties.Add(key, value);
            return this;
        }

        public CassandraKeyspaceImpl WithOptionsAppend(IDictionary<string, string> options)
        {
            if (this.createUpdateParameters.Options.AdditionalProperties == null)
                this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.AdditionalProperties.Add(option.Key, option.Value);
            }
            return this;
        }

        public CassandraKeyspaceImpl WithOptionsReplace(IDictionary<string, string> options)
        {
            this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.AdditionalProperties.Add(option.Key, option.Value);
            }
            return this;
        }

        public CassandraKeyspaceImpl WithoutOption(string key)
        {
            this.createUpdateParameters.Options.AdditionalProperties?.Remove(key);
            return this;
        }

        public CassandraKeyspaceImpl WithoutOptions()
        {
            this.createUpdateParameters.Options.AdditionalProperties = null;
            return this;
        }

        public CassandraKeyspaceImpl WithThroughput(int throughput)
        {
            this.createUpdateParameters.Options.Throughput = throughput.ToString();
            return this;
        }

        public CosmosDBAccountImpl Attach()
        {
            return this.Parent.WithCassandraKeyspace(this);
        }

        public async override Task<ICassandraKeyspace> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Client.CreateUpdateCassandraKeyspaceAsync(
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
                childTasks.Add(this.Client.UpdateCassandraKeyspaceThroughputAsync(
                    Parent.ResourceGroupName,
                    Parent.Name,
                    this.Name(),
                    this.throughputSettingsToUpdate,
                    cancellationToken
                    ));

                this.throughputSettingsToUpdate = null;
            }

            childTasks.Add(this.cassandraTables.CommitAndGetAllAsync(cancellationToken));
            await Task.WhenAll(childTasks);

            return this;
        }

        public async override Task<ICassandraKeyspace> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateAsync(cancellationToken);
        }

        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Client.DeleteCassandraKeyspaceAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                this.Name(),
                cancellationToken
                );
        }

        protected async override Task<CassandraKeyspaceGetResultsInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Client.GetCassandraKeyspaceAsync(
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
            var throughput = await this.Client.GetCassandraKeyspaceThroughputAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                this.Name(),
                cancellationToken
                );
            return throughput.Resource;
        }

        public CassandraKeyspaceImpl WithCassandraTable(CassandraTableImpl cassandraTable)
        {
            this.cassandraTables.AddCassandraTable(cassandraTable);
            return this;
        }

        public CassandraTableImpl DefineNewCassandraTable(string name)
        {
            return this.cassandraTables.Define(name);
        }

        public CassandraTableImpl UpdateCassandraTable(string name)
        {
            return this.cassandraTables.Update(name);
        }

        public CassandraKeyspaceImpl WithoutCassandraTable(string name)
        {
            this.cassandraTables.Remove(name);
            return this;
        }

        public IEnumerable<ICassandraTable> ListCassandraTables()
        {
            return Extensions.Synchronize(() => this.ListCassandraTablesAsync());
        }

        public async Task<IEnumerable<ICassandraTable>> ListCassandraTablesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.cassandraTables.ListAsync(cancellationToken);
        }

        public ICassandraTable GetCassandraTable(string name)
        {
            return Extensions.Synchronize(() => this.GetCassandraTableAsync(name));
        }

        public async Task<ICassandraTable> GetCassandraTableAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.cassandraTables.GetImplAsync(name, cancellationToken);
        }
    }
}
