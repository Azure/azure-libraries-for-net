// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class SqlDatabaseImpl :
        ExternalChildResource<ISqlDatabase,
            SqlDatabaseGetResultsInner,
            ICosmosDBAccount,
            CosmosDBAccountImpl>,
        ISqlDatabase,
        SqlDatabase.Definition.IDefinition<CosmosDBAccount.Definition.IWithCreate>,
        SqlDatabase.Update.IUpdate,
        SqlDatabase.Definition.IDefinition<CosmosDBAccount.Update.IWithOptionals>
    {
        private ISqlResourcesOperations Client { get { return Parent.Manager.Inner.SqlResources; } }
        private SqlDatabaseCreateUpdateParameters createUpdateParameters;
        private ThroughputSettingsUpdateParameters throughputSettingsToUpdate;
        private SqlContainersImpl sqlContainers;

        internal SqlDatabaseImpl(string name, CosmosDBAccountImpl parent, SqlDatabaseGetResultsInner inner)
            : base(name, parent, inner)
        {
            this.sqlContainers = new SqlContainersImpl(this);
            InitializeCreateUpdateParameters();
        }

        private void InitializeCreateUpdateParameters()
        {
            this.createUpdateParameters = new SqlDatabaseCreateUpdateParameters()
            {
                Location = Parent.Inner.Location,
                Resource = new SqlDatabaseResource(id: this.Name()),
                Options = new CreateUpdateOptions(),
            };
        }

        public string SqlDatabaseId()
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

        public string _colls()
        {
            return this.Inner.Resource._colls;
        }

        public string _users()
        {
            return this.Inner.Resource._users;
        }

        public string Id()
        {
            return this.Inner.Id;
        }

        public SqlDatabaseImpl WithOption(string key, string value)
        {
            if (this.createUpdateParameters.Options.AdditionalProperties == null)
                this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            this.createUpdateParameters.Options.AdditionalProperties.Add(key, value);
            return this;
        }

        public SqlDatabaseImpl WithOptionsAppend(IDictionary<string, string> options)
        {
            if (this.createUpdateParameters.Options.AdditionalProperties == null)
                this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.AdditionalProperties.Add(option.Key, option.Value);
            }
            return this;
        }

        public SqlDatabaseImpl WithOptionsReplace(IDictionary<string, string> options)
        {
            this.createUpdateParameters.Options.AdditionalProperties = new Dictionary<string, object>();
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.AdditionalProperties.Add(option.Key, option.Value);
            }
            return this;
        }

        public SqlDatabaseImpl WithoutOption(string key)
        {
            this.createUpdateParameters.Options.AdditionalProperties?.Remove(key);
            return this;
        }

        public SqlDatabaseImpl WithoutOptions()
        {
            this.createUpdateParameters.Options.AdditionalProperties = null;
            return this;
        }

        public SqlDatabaseImpl WithThroughput(int throughput)
        {
            this.createUpdateParameters.Options.Throughput = throughput.ToString();
            return this;
        }

        public CosmosDBAccountImpl Attach()
        {
            return this.Parent.WithSqlDatabase(this);
        }

        public async override Task<ISqlDatabase> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Client.CreateUpdateSqlDatabaseAsync(
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
                childTasks.Add(this.Client.UpdateSqlDatabaseThroughputAsync(
                    Parent.ResourceGroupName,
                    Parent.Name,
                    this.Name(),
                    this.throughputSettingsToUpdate,
                    cancellationToken
                    ));

                this.throughputSettingsToUpdate = null;
            }

            childTasks.Add(this.sqlContainers.CommitAndGetAllAsync(cancellationToken));
            await Task.WhenAll(childTasks);

            return this;
        }

        public async override Task<ISqlDatabase> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateAsync(cancellationToken);
        }

        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Client.DeleteSqlDatabaseAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                this.Name(),
                cancellationToken
                );
        }

        protected async override Task<SqlDatabaseGetResultsInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Client.GetSqlDatabaseAsync(
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
            var throughput = await this.Client.GetSqlDatabaseThroughputAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                this.Name(),
                cancellationToken
                );
            return throughput.Resource;
        }

        public SqlDatabaseImpl WithSqlContainer(SqlContainerImpl sqlContainer)
        {
            this.sqlContainers.AddSqlContainer(sqlContainer);
            return this;
        }

        public SqlContainerImpl DefineNewSqlContainer(string name)
        {
            return this.sqlContainers.Define(name);
        }

        public SqlContainerImpl UpdateSqlContainer(string name)
        {
            return this.sqlContainers.Update(name);
        }

        public SqlDatabaseImpl WithoutSqlContainer(string name)
        {
            this.sqlContainers.Remove(name);
            return this;
        }

        public IEnumerable<ISqlContainer> ListSqlContainers()
        {
            return Extensions.Synchronize(() => this.ListSqlContainersAsync());
        }

        public async Task<IEnumerable<ISqlContainer>> ListSqlContainersAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlContainers.ListAsync(cancellationToken);
        }

        public ISqlContainer GetSqlContainer(string name)
        {
            return Extensions.Synchronize(() => this.GetSqlContainerAsync(name));
        }

        public async Task<ISqlContainer> GetSqlContainerAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlContainers.GetImplAsync(name, cancellationToken);
        }
    }
}
