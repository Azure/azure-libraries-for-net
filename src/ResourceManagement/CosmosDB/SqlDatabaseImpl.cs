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
        SqlDatabase.Update.IUpdate
    {
        private ISqlResourcesOperations Client { get; set; }
        private SqlDatabaseCreateUpdateParameters createUpdateParameters;
        private ThroughputSettingsUpdateParameters ThroughputSettingsToUpdate;

        internal SqlDatabaseImpl(string name, CosmosDBAccountImpl parent, SqlDatabaseGetResultsInner inner, ISqlResourcesOperations client)
            : base(name, parent, inner)
        {
            this.Client = client;
            this.createUpdateParameters = new SqlDatabaseCreateUpdateParameters()
            {
                Location = parent.Inner.Location,
                Resource = new SqlDatabaseResource(id: name),
                Options = new Dictionary<string, string>(),
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
            this.createUpdateParameters.Options.Add(key, value);
            return this;
        }

        public SqlDatabaseImpl WithOptionsAppend(IDictionary<string, string> options)
        {
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.Add(option.Key, option.Value);
            }
            return this;
        }

        public SqlDatabaseImpl WithOptionsReplace(IDictionary<string, string> options)
        {
            this.createUpdateParameters.Options = options;
            return this;
        }

        public SqlDatabaseImpl WithoutOption(string key)
        {
            this.createUpdateParameters.Options.Remove(key);
            return this;
        }

        public SqlDatabaseImpl WithoutOptions()
        {
            this.createUpdateParameters.Options.Clear();
            return this;
        }

        public SqlDatabaseImpl WithThroughput(int throughput)
        {
            if (this.ThroughputSettingsToUpdate == null)
            {
                this.ThroughputSettingsToUpdate = new ThroughputSettingsUpdateParameters();
            }
            if (this.ThroughputSettingsToUpdate.Resource == null)
            {
                this.ThroughputSettingsToUpdate.Resource = new ThroughputSettingsResource();
            }

            this.ThroughputSettingsToUpdate.Resource.Throughput = throughput;
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

            if (this.ThroughputSettingsToUpdate != null)
            {
                await this.Client.BeginUpdateSqlDatabaseThroughputAsync(
                    Parent.ResourceGroupName,
                    Parent.Name,
                    this.Name(),
                    this.ThroughputSettingsToUpdate,
                    cancellationToken
                    );

                this.ThroughputSettingsToUpdate = null;
            }

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
    }
}
