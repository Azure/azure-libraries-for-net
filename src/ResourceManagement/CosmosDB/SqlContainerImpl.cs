﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;

    using DefinitionParentT = SqlDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>;
    using UpdateDefinitionParentT = SqlDatabase.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>;
    using DefinitionIndexingPolicyImpl = IndexingPolicyImpl<SqlContainerImpl, ISqlContainer, SqlContainer.Definition.IWithAttach<SqlDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>, SqlContainer.Update.IUpdate>;
    using UpdateDefinitionIndexingPolicyImpl = IndexingPolicyImpl<SqlContainerImpl, ISqlContainer, SqlContainer.Definition.IWithAttach<SqlDatabase.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>>, SqlContainer.Update.IUpdate>;
    using UpdateIndexingPolicyImpl = IndexingPolicyImpl<SqlContainerImpl, ISqlContainer, SqlContainer.Definition.IWithAttach<SqlDatabase.Update.IUpdate>, SqlContainer.Update.IUpdate>;

    internal partial class SqlContainerImpl :
        ExternalChildResource<ISqlContainer,
            SqlContainerGetResultsInner,
            ISqlDatabase,
            SqlDatabaseImpl>,
        ISqlContainer,
        SqlContainer.Definition.IDefinition<DefinitionParentT>,
        SqlContainer.Definition.IDefinition<UpdateDefinitionParentT>,
        SqlContainer.Definition.IDefinition<SqlDatabase.Update.IUpdate>,
        SqlContainer.Update.IUpdate,
        IHasIndexingPolicy<SqlContainerImpl>
    {
        private ISqlResourcesOperations Client { get; set; }
        private SqlContainerCreateUpdateParameters createUpdateParameters;
        private ThroughputSettingsUpdateParameters throughputSettingsToUpdate;
        private IDictionary<string, SqlStoredProcedureCreateUpdateParameters> storedProcedureToUpdate;
        private IList<string> storedProcedureToDelete;
        private IDictionary<string, SqlUserDefinedFunctionCreateUpdateParameters> userDefinedFunctionToUpdate;
        private IList<string> userDefinedFunctionToDelete;
        private IDictionary<string, SqlTriggerCreateUpdateParameters> triggerToUpdate;
        private IList<string> triggerToDelete;

        public string Location
        {
            get
            {
                return Parent.Parent.RegionName.ToLower();
            }
        }

        public string ResourceGroupName
        {
            get
            {
                return Parent.Parent.ResourceGroupName;
            }
        }

        public string AccountName
        {
            get
            {
                return Parent.Parent.Name;
            }
        }

        public string SqlDatabaseName
        {
            get
            {
                return Parent.Name();
            }
        }

        internal SqlContainerImpl(string name, SqlDatabaseImpl parent, SqlContainerGetResultsInner inner, ISqlResourcesOperations client)
            : base(name, parent, inner)
        {
            this.Client = client;
            SetCreateUpdateParameters();
            InitChildResource(true);
        }

        private void InitChildResource(bool firstInitial)
        {
            this.throughputSettingsToUpdate = null;
            if (firstInitial)
            {
                this.storedProcedureToUpdate = new Dictionary<string, SqlStoredProcedureCreateUpdateParameters>();
                this.storedProcedureToDelete = new List<string>();
                this.userDefinedFunctionToUpdate = new Dictionary<string, SqlUserDefinedFunctionCreateUpdateParameters>();
                this.userDefinedFunctionToDelete = new List<string>();
                this.triggerToUpdate = new Dictionary<string, SqlTriggerCreateUpdateParameters>();
                this.triggerToDelete = new List<string>();
            }
            else
            {
                this.storedProcedureToDelete.Clear();
                this.storedProcedureToUpdate.Clear();
                this.userDefinedFunctionToDelete.Clear();
                this.userDefinedFunctionToUpdate.Clear();
                this.triggerToDelete.Clear();
                this.triggerToUpdate.Clear();
            }
        }

        private void SetCreateUpdateParameters()
        {
            this.createUpdateParameters = new SqlContainerCreateUpdateParameters()
            {
                Location = Parent.Inner.Location,
                Resource = new SqlContainerResource(id: this.Name()),
                Options = new Dictionary<string, string>(),
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

        public string SqlContainerId()
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

        public SqlContainerImpl WithOption(string key, string value)
        {
            this.createUpdateParameters.Options.Add(key, value);
            return this;
        }

        public SqlContainerImpl WithOptionsAppend(IDictionary<string, string> options)
        {
            foreach (var option in options)
            {
                this.createUpdateParameters.Options.Add(option.Key, option.Value);
            }
            return this;
        }

        public SqlContainerImpl WithOptionsReplace(IDictionary<string, string> options)
        {
            this.createUpdateParameters.Options = options;
            return this;
        }

        public SqlContainerImpl WithoutOption(string key)
        {
            this.createUpdateParameters.Options.Remove(key);
            return this;
        }

        public SqlContainerImpl WithoutOptions()
        {
            this.createUpdateParameters.Options.Clear();
            return this;
        }

        public SqlContainerImpl WithThroughput(int throughput)
        {
            if (this.throughputSettingsToUpdate == null)
            {
                this.throughputSettingsToUpdate = new ThroughputSettingsUpdateParameters();
            }
            if (this.throughputSettingsToUpdate.Resource == null)
            {
                this.throughputSettingsToUpdate.Resource = new ThroughputSettingsResource();
            }

            this.throughputSettingsToUpdate.Resource.Throughput = throughput;
            return this;
        }

        public SqlDatabaseImpl Attach()
        {
            return this.Parent.WithSqlContainer(this);
        }

        public async override Task<ISqlContainer> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Client.CreateUpdateSqlContainerAsync(
                ResourceGroupName,
                AccountName,
                SqlDatabaseName,
                this.Name(),
                this.createUpdateParameters,
                cancellationToken
                );

            SetInner(inner);
            SetCreateUpdateParameters();
            var ChildTask = new List<Task>();

            if (this.throughputSettingsToUpdate != null)
            {
                this.throughputSettingsToUpdate.Location = Location;
                ChildTask.Add(this.Client.UpdateSqlContainerThroughputAsync(
                    ResourceGroupName,
                    AccountName,
                    SqlDatabaseName,
                    Name(),
                    this.throughputSettingsToUpdate,
                    cancellationToken
                    ));
            }

            if (this.storedProcedureToDelete.Count > 0)
            {
                ChildTask.AddRange(this.storedProcedureToDelete.Select(name => this.Client.DeleteSqlStoredProcedureAsync(
                    ResourceGroupName,
                    AccountName,
                    SqlDatabaseName,
                    Name(),
                    name,
                    cancellationToken
                    )));
            }

            if (this.storedProcedureToUpdate.Count > 0)
            {
                ChildTask.AddRange(this.storedProcedureToUpdate.Select(param => this.Client.CreateUpdateSqlStoredProcedureAsync(
                    ResourceGroupName,
                    AccountName,
                    SqlDatabaseName,
                    Name(),
                    param.Key,
                    param.Value,
                    cancellationToken
                    )));
            }

            if (this.userDefinedFunctionToDelete.Count > 0)
            {
                ChildTask.AddRange(this.userDefinedFunctionToDelete.Select(name => this.Client.DeleteSqlUserDefinedFunctionAsync(
                    ResourceGroupName,
                    AccountName,
                    SqlDatabaseName,
                    Name(),
                    name,
                    cancellationToken
                    )));
            }

            if (this.userDefinedFunctionToUpdate.Count > 0)
            {
                ChildTask.AddRange(this.userDefinedFunctionToUpdate.Select(param => this.Client.CreateUpdateSqlUserDefinedFunctionAsync(
                    ResourceGroupName,
                    AccountName,
                    SqlDatabaseName,
                    Name(),
                    param.Key,
                    param.Value,
                    cancellationToken
                    )));
            }

            if (this.triggerToDelete.Count > 0)
            {
                ChildTask.AddRange(this.triggerToDelete.Select(name => this.Client.DeleteSqlTriggerAsync(
                    ResourceGroupName,
                    AccountName,
                    SqlDatabaseName,
                    Name(),
                    name,
                    cancellationToken
                    )));
            }

            if (this.triggerToUpdate.Count > 0)
            {
                ChildTask.AddRange(this.triggerToUpdate.Select(param => this.Client.CreateUpdateSqlTriggerAsync(
                    ResourceGroupName,
                    AccountName,
                    SqlDatabaseName,
                    Name(),
                    param.Key,
                    param.Value,
                    cancellationToken
                    )));
            }

            await Task.WhenAll(ChildTask);
            InitChildResource(false);

            return this;
        }

        public async override Task<ISqlContainer> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateAsync(cancellationToken);
        }

        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Client.DeleteSqlContainerAsync(
                Parent.Parent.ResourceGroupName,
                Parent.Parent.Name,
                Parent.Name(),
                this.Name(),
                cancellationToken
                );
        }

        protected async override Task<SqlContainerGetResultsInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Client.GetSqlContainerAsync(
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
            var throughput = await this.Client.GetSqlContainerThroughputAsync(
                Parent.Parent.ResourceGroupName,
                Parent.Parent.Name,
                Parent.Name(),
                this.Name(),
                cancellationToken
                );
            return throughput.Resource;
        }

        public SqlContainerImpl WithIndexingPolicy(Models.IndexingPolicy indexingPolicy)
        {
            this.createUpdateParameters.Resource.IndexingPolicy = indexingPolicy;
            return this;
        }

        public SqlContainerImpl WithoutIndexingPolicy()
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
            var indexingPolicyInner = this.createUpdateParameters.Resource.IndexingPolicy ?? new Models.IndexingPolicy();
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

        public SqlContainerImpl WithContainerPartitionKey(ContainerPartitionKey containerPartitionKey)
        {
            this.createUpdateParameters.Resource.PartitionKey = containerPartitionKey;
            return this;
        }

        public SqlContainerImpl WithoutContainerPartitionKey()
        {
            this.createUpdateParameters.Resource.PartitionKey = null;
            return this;
        }

        public SqlContainerImpl WithDefaultTtl(int ttl)
        {
            this.createUpdateParameters.Resource.DefaultTtl = ttl;
            return this;
        }

        public SqlContainerImpl WithoutDefaultTtl()
        {
            this.createUpdateParameters.Resource.DefaultTtl = null;
            return this;
        }

        public SqlContainerImpl WithUniqueKeyPolicy(UniqueKeyPolicy uniqueKeyPolicy)
        {
            this.createUpdateParameters.Resource.UniqueKeyPolicy = uniqueKeyPolicy;
            return this;
        }

        public SqlContainerImpl WithoutUniqueKeyPolicy()
        {
            this.createUpdateParameters.Resource.UniqueKeyPolicy = null;
            return this;
        }

        public SqlContainerImpl WithUniqueKeys(IList<UniqueKey> uniqueKeys)
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

        public SqlContainerImpl WithUniqueKey(int index, UniqueKey uniqueKey)
        {
            if (this.createUpdateParameters.Resource.UniqueKeyPolicy == null)
            {
                this.createUpdateParameters.Resource.UniqueKeyPolicy = new UniqueKeyPolicy();
            }
            if (this.createUpdateParameters.Resource.UniqueKeyPolicy.UniqueKeys == null)
            {
                this.createUpdateParameters.Resource.UniqueKeyPolicy.UniqueKeys = new List<UniqueKey>();
            }

            if (index < 0 || this.createUpdateParameters.Resource.UniqueKeyPolicy.UniqueKeys.Count <= index)
            {
                this.createUpdateParameters.Resource.UniqueKeyPolicy.UniqueKeys.Add(uniqueKey);
            }
            else
            {
                this.createUpdateParameters.Resource.UniqueKeyPolicy.UniqueKeys[index] = uniqueKey;
            }
            return this;
        }

        public SqlContainerImpl WithoutUniqueKey(int index)
        {
            var uniqueKeys = this.createUpdateParameters.Resource.UniqueKeyPolicy?.UniqueKeys;
            if (uniqueKeys != null)
            {
                uniqueKeys.RemoveAt(index);
            }
            return this;
        }

        public SqlContainerImpl WithoutUniqueKey(UniqueKey uniqueKey)
        {
            var uniqueKeys = this.createUpdateParameters.Resource.UniqueKeyPolicy?.UniqueKeys;
            if (uniqueKeys != null)
            {
                uniqueKeys.Remove(uniqueKey);
            }
            return this;
        }

        public SqlContainerImpl WithConflictResolutionPolicy(ConflictResolutionPolicy conflictResolutionPolicy)
        {
            this.createUpdateParameters.Resource.ConflictResolutionPolicy = conflictResolutionPolicy;
            return this;
        }

        public SqlContainerImpl WithoutConflictResolutionPolicy()
        {
            this.createUpdateParameters.Resource.ConflictResolutionPolicy = null;
            return this;
        }

        public SqlContainerImpl WithStoredProcedure(string name, SqlStoredProcedureResource resource = default(SqlStoredProcedureResource), IDictionary<string, string> options = default(IDictionary<string, string>))
        {
            var parameter = new SqlStoredProcedureCreateUpdateParameters()
            {
                Location = this.Location,
                Resource = resource ?? new SqlStoredProcedureResource(),
                Options = options ?? new Dictionary<string, string>(),
            };
            parameter.Resource.Id = name;
            this.storedProcedureToUpdate.Add(name, parameter);
            return this;
        }

        public SqlContainerImpl WithoutStoredProcedure(string name)
        {
            this.storedProcedureToDelete.Add(name);
            return this;
        }

        public SqlContainerImpl WithUserDefinedFunction(string name, SqlUserDefinedFunctionResource resource = default(SqlUserDefinedFunctionResource), IDictionary<string, string> options = default(IDictionary<string, string>))
        {
            var parameter = new SqlUserDefinedFunctionCreateUpdateParameters()
            {
                Location = this.Location,
                Resource = resource ?? new SqlUserDefinedFunctionResource(),
                Options = options ?? new Dictionary<string, string>(),
            };
            parameter.Resource.Id = name;
            this.userDefinedFunctionToUpdate.Add(name, parameter);
            return this;
        }

        public SqlContainerImpl WithoutUserDefinedFunction(string name)
        {
            this.userDefinedFunctionToDelete.Add(name);
            return this;
        }

        public SqlContainerImpl WithTrigger(string name, SqlTriggerResource resource = default(SqlTriggerResource), IDictionary<string, string> options = default(IDictionary<string, string>))
        {
            var parameter = new SqlTriggerCreateUpdateParameters()
            {
                Location = this.Location,
                Resource = resource ?? new SqlTriggerResource(),
                Options = options ?? new Dictionary<string, string>(),
            };
            parameter.Resource.Id = name;
            this.triggerToUpdate.Add(name, parameter);
            return this;
        }

        public SqlContainerImpl WithoutTrigger(string name)
        {
            this.triggerToDelete.Add(name);
            return this;
        }

        public IEnumerable<SqlStoredProcedureGetPropertiesResource> ListStoredProcedures()
        {
            return Extensions.Synchronize(() => this.ListStoredProceduresAsync());
        }

        public async Task<IEnumerable<SqlStoredProcedureGetPropertiesResource>> ListStoredProceduresAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inners = await this.Client.ListSqlStoredProceduresAsync(
                ResourceGroupName,
                AccountName,
                SqlDatabaseName,
                Name(),
                cancellationToken
                );
            return inners.Select(inner => inner.Resource);
        }

        public SqlStoredProcedureGetPropertiesResource GetStoredProcedure(string name)
        {
            return Extensions.Synchronize(() => this.GetStoredProcedureAsync(name));
        }

        public async Task<SqlStoredProcedureGetPropertiesResource> GetStoredProcedureAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Client.GetSqlStoredProcedureAsync(
                ResourceGroupName,
                AccountName,
                SqlDatabaseName,
                Name(),
                name,
                cancellationToken
                );
            return inner.Resource;
        }

        public IEnumerable<SqlUserDefinedFunctionGetPropertiesResource> ListUserDefinedFunctions()
        {
            return Extensions.Synchronize(() => this.ListUserDefinedFunctionsAsync());
        }

        public async Task<IEnumerable<SqlUserDefinedFunctionGetPropertiesResource>> ListUserDefinedFunctionsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inners = await this.Client.ListSqlUserDefinedFunctionsAsync(
                ResourceGroupName,
                AccountName,
                SqlDatabaseName,
                Name(),
                cancellationToken
                );
            return inners.Select(inner => inner.Resource);
        }

        public SqlUserDefinedFunctionGetPropertiesResource GetUserDefinedFunction(string name)
        {
            return Extensions.Synchronize(() => this.GetUserDefinedFunctionAsync(name));
        }

        public async Task<SqlUserDefinedFunctionGetPropertiesResource> GetUserDefinedFunctionAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Client.GetSqlUserDefinedFunctionAsync(
                ResourceGroupName,
                AccountName,
                SqlDatabaseName,
                Name(),
                name,
                cancellationToken
                );
            return inner.Resource;
        }

        public IEnumerable<SqlTriggerGetPropertiesResource> ListTriggers()
        {
            return Extensions.Synchronize(() => this.ListTriggersAsync());
        }

        public async Task<IEnumerable<SqlTriggerGetPropertiesResource>> ListTriggersAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inners = await this.Client.ListSqlTriggersAsync(
                ResourceGroupName,
                AccountName,
                SqlDatabaseName,
                Name(),
                cancellationToken
                );
            return inners.Select(inner => inner.Resource);
        }

        public SqlTriggerGetPropertiesResource GetTrigger(string name)
        {
            return Extensions.Synchronize(() => this.GetTriggerAsync(name));
        }

        public async Task<SqlTriggerGetPropertiesResource> GetTriggerAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Client.GetSqlTriggerAsync(
                ResourceGroupName,
                AccountName,
                SqlDatabaseName,
                Name(),
                name,
                cancellationToken
                );
            return inner.Resource;
        }
    }
}
