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

    using DefinitionParentT = CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>;
    using UpdateDefinitionParentT = CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>;

    internal partial class CassandraTableImpl :
        ExternalChildResource<ICassandraTable,
            CassandraTableGetResultsInner,
            ICassandraKeyspace,
            CassandraKeyspaceImpl>,
        ICassandraTable,
        CassandraTable.Definition.IDefinition<DefinitionParentT>,
        CassandraTable.Definition.IDefinition<UpdateDefinitionParentT>,
        CassandraTable.Definition.IDefinition<CassandraKeyspace.Update.IUpdate>,
        CassandraTable.Update.IUpdate
    {
        private ICassandraResourcesOperations Client { get { return Parent.Parent.Manager.Inner.CassandraResources; } }
        private CassandraTableCreateUpdateParameters createUpdateParameters;
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

        private string CassandraKeyspaceName
        {
            get
            {
                return Parent.Name();
            }
        }

        internal CassandraTableImpl(string name, CassandraKeyspaceImpl parent, CassandraTableGetResultsInner inner)
            : base(name, parent, inner)
        {
            InitializeCreateUpdateParameters();
        }

        private void InitializeCreateUpdateParameters()
        {
            this.createUpdateParameters = new CassandraTableCreateUpdateParameters()
            {
                Location = this.Location,
                Resource = new CassandraTableResource(id: this.Name()),
                Options = new CreateUpdateOptions(),
            };

            if (Inner.Resource != null)
            {
                this.createUpdateParameters.Resource.Schema = Inner.Resource.Schema;
                this.createUpdateParameters.Resource.DefaultTtl = Inner.Resource.DefaultTtl;
            }
        }

        public string CassandraTableId()
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

        public Models.CassandraSchema Schema()
        {
            return this.Inner.Resource.Schema;
        }

        public int? DefaultTtl()
        {
            return this.Inner.Resource.DefaultTtl;
        }

        public CassandraTableImpl WithOption(string key, string value)
        {
            if (this.createUpdateParameters.Options.AdditionalProperties == null)
                this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            this.createUpdateParameters.Options.AdditionalProperties.Add(key, value);
            return this;
        }

        public CassandraTableImpl WithOptionsAppend(IDictionary<string, string> options)
        {
            if (this.createUpdateParameters.Options.AdditionalProperties == null)
                this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.AdditionalProperties.Add(option.Key, option.Value);
            }
            return this;
        }

        public CassandraTableImpl WithOptionsReplace(IDictionary<string, string> options)
        {
            this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.AdditionalProperties.Add(option.Key, option.Value);
            }
            return this;
        }

        public CassandraTableImpl WithoutOption(string key)
        {
            this.createUpdateParameters.Options.AdditionalProperties?.Remove(key);
            return this;
        }

        public CassandraTableImpl WithoutOptions()
        {
            this.createUpdateParameters.Options.AdditionalProperties = null;
            return this;
        }

        public CassandraTableImpl WithThroughput(int throughput)
        {
            this.createUpdateParameters.Options.Throughput = throughput.ToString();
            return this;
        }

        public CassandraKeyspaceImpl Attach()
        {
            return this.Parent.WithCassandraTable(this);
        }

        public async override Task<ICassandraTable> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Client.CreateUpdateCassandraTableAsync(
                ResourceGroupName,
                AccountName,
                CassandraKeyspaceName,
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
                childTasks.Add(this.Client.UpdateCassandraTableThroughputAsync(
                    ResourceGroupName,
                    AccountName,
                    CassandraKeyspaceName,
                    Name(),
                    this.throughputSettingsToUpdate,
                    cancellationToken
                    ));
            }

            await Task.WhenAll(childTasks);
            this.throughputSettingsToUpdate = null;

            return this;
        }

        public async override Task<ICassandraTable> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateAsync(cancellationToken);
        }

        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Client.DeleteCassandraTableAsync(
                Parent.Parent.ResourceGroupName,
                Parent.Parent.Name,
                Parent.Name(),
                this.Name(),
                cancellationToken
                );
        }

        protected async override Task<CassandraTableGetResultsInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Client.GetCassandraTableAsync(
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
            var throughput = await this.Client.GetCassandraTableThroughputAsync(
                Parent.Parent.ResourceGroupName,
                Parent.Parent.Name,
                Parent.Name(),
                this.Name(),
                cancellationToken
                );
            return throughput.Resource;
        }

        public CassandraTableImpl WithDefaultTtl(int ttl)
        {
            this.createUpdateParameters.Resource.DefaultTtl = ttl;
            return this;
        }

        public CassandraTableImpl WithoutDefaultTtl()
        {
            this.createUpdateParameters.Resource.DefaultTtl = null;
            return this;
        }

        public CassandraTableImpl WithColumn(Column column)
        {
            if (this.createUpdateParameters.Resource.Schema == null)
            {
                this.createUpdateParameters.Resource.Schema = new CassandraSchema();
            }
            if (this.createUpdateParameters.Resource.Schema.Columns == null)
            {
                this.createUpdateParameters.Resource.Schema.Columns = new List<Column>();
            }

            this.createUpdateParameters.Resource.Schema.Columns.Add(column);
            return this;
        }

        public CassandraTableImpl WithColumn(string name, string type)
        {
            return this.WithColumn(new Column(name, type));
        }

        public CassandraTableImpl WithoutColumn(string name)
        {
            this.createUpdateParameters.Resource.Schema?.Columns?.Remove(this.createUpdateParameters.Resource.Schema?.Columns?.FirstOrDefault(element => element.Name == name));
            return this;
        }

        public CassandraTableImpl WithColumnsAppend(IList<Models.Column> columns)
        {
            if (this.createUpdateParameters.Resource.Schema == null)
            {
                this.createUpdateParameters.Resource.Schema = new CassandraSchema();
            }
            if (this.createUpdateParameters.Resource.Schema.Columns == null)
            {
                this.createUpdateParameters.Resource.Schema.Columns = new List<Column>();
            }

            foreach (Column column in columns)
            {
                this.createUpdateParameters.Resource.Schema.Columns.Add(column);
            }
            return this;
        }

        public CassandraTableImpl WithColumnsReplace(IList<Models.Column> columns)
        {
            if (this.createUpdateParameters.Resource.Schema == null)
            {
                this.createUpdateParameters.Resource.Schema = new CassandraSchema();
            }
            this.createUpdateParameters.Resource.Schema.Columns = new List<Column>();
            foreach (Column column in columns)
            {
                this.createUpdateParameters.Resource.Schema.Columns.Add(column);
            }
            return this;
        }

        public CassandraTableImpl WithoutColumns()
        {
            if (this.createUpdateParameters.Resource.Schema != null)
            {
                this.createUpdateParameters.Resource.Schema.Columns = null;
            }
            return this;
        }

        public CassandraTableImpl WithPartitionKey(Models.CassandraPartitionKey partitionKey)
        {
            if (this.createUpdateParameters.Resource.Schema == null)
            {
                this.createUpdateParameters.Resource.Schema = new CassandraSchema();
            }
            if (this.createUpdateParameters.Resource.Schema.PartitionKeys == null)
            {
                this.createUpdateParameters.Resource.Schema.PartitionKeys = new List<CassandraPartitionKey>();
            }

            this.createUpdateParameters.Resource.Schema.PartitionKeys.Add(partitionKey);
            return this;
        }

        public CassandraTableImpl WithPartitionKey(string name)
        {
            return this.WithPartitionKey(new CassandraPartitionKey(name));
        }

        public CassandraTableImpl WithoutPartitionKey(string name)
        {
            this.createUpdateParameters.Resource.Schema?.PartitionKeys?.Remove(this.createUpdateParameters.Resource.Schema?.PartitionKeys?.FirstOrDefault(element => element.Name == name));
            return this;
        }

        public CassandraTableImpl WithPartitionKeysAppend(IList<Models.CassandraPartitionKey> partitionKeys)
        {
            if (this.createUpdateParameters.Resource.Schema == null)
            {
                this.createUpdateParameters.Resource.Schema = new CassandraSchema();
            }
            if (this.createUpdateParameters.Resource.Schema.PartitionKeys == null)
            {
                this.createUpdateParameters.Resource.Schema.PartitionKeys = new List<CassandraPartitionKey>();
            }

            foreach (CassandraPartitionKey partitionKey in partitionKeys)
            {
                this.createUpdateParameters.Resource.Schema.PartitionKeys.Add(partitionKey);
            }
            return this;
        }

        public CassandraTableImpl WithPartitionKeysReplace(IList<Models.CassandraPartitionKey> partitionKeys)
        {
            if (this.createUpdateParameters.Resource.Schema == null)
            {
                this.createUpdateParameters.Resource.Schema = new CassandraSchema();
            }
            this.createUpdateParameters.Resource.Schema.PartitionKeys = new List<CassandraPartitionKey>();

            foreach (CassandraPartitionKey partitionKey in partitionKeys)
            {
                this.createUpdateParameters.Resource.Schema.PartitionKeys.Add(partitionKey);
            }
            return this;
        }

        public CassandraTableImpl WithoutPartitionKeys()
        {
            if (this.createUpdateParameters.Resource.Schema != null)
            {
                this.createUpdateParameters.Resource.Schema.PartitionKeys = null;
            }
            return this;
        }

        public CassandraTableImpl WithClusterKey(Models.ClusterKey clusterKey)
        {
            if (this.createUpdateParameters.Resource.Schema == null)
            {
                this.createUpdateParameters.Resource.Schema = new CassandraSchema();
            }
            if (this.createUpdateParameters.Resource.Schema.ClusterKeys == null)
            {
                this.createUpdateParameters.Resource.Schema.ClusterKeys = new List<ClusterKey>();
            }

            this.createUpdateParameters.Resource.Schema.ClusterKeys.Add(clusterKey);
            return this;
        }

        public CassandraTableImpl WithClusterKey(string name, string orderBy)
        {
            return this.WithClusterKey(new ClusterKey(name, orderBy));
        }

        public CassandraTableImpl WithoutClusterKey(string name)
        {
            this.createUpdateParameters.Resource.Schema?.ClusterKeys?.Remove(this.createUpdateParameters.Resource.Schema?.ClusterKeys?.FirstOrDefault(element => element.Name == name));
            return this;
        }

        public CassandraTableImpl WithClusterKeysAppend(IList<Models.ClusterKey> clusterKeys)
        {
            if (this.createUpdateParameters.Resource.Schema == null)
            {
                this.createUpdateParameters.Resource.Schema = new CassandraSchema();
            }
            if (this.createUpdateParameters.Resource.Schema.ClusterKeys == null)
            {
                this.createUpdateParameters.Resource.Schema.ClusterKeys = new List<ClusterKey>();
            }

            foreach (ClusterKey clusterKey in clusterKeys)
            {
                this.createUpdateParameters.Resource.Schema.ClusterKeys.Add(clusterKey);
            }
            return this;
        }

        public CassandraTableImpl WithClusterKeysReplace(IList<Models.ClusterKey> clusterKeys)
        {
            if (this.createUpdateParameters.Resource.Schema == null)
            {
                this.createUpdateParameters.Resource.Schema = new CassandraSchema();
            }
            this.createUpdateParameters.Resource.Schema.ClusterKeys = new List<ClusterKey>();

            foreach (ClusterKey clusterKey in clusterKeys)
            {
                this.createUpdateParameters.Resource.Schema.ClusterKeys.Add(clusterKey);
            }
            return this;
        }

        public CassandraTableImpl WithoutClusterKeys()
        {
            if (this.createUpdateParameters.Resource.Schema != null)
            {
                this.createUpdateParameters.Resource.Schema.ClusterKeys = null;
            }
            return this;
        }
    }
}
