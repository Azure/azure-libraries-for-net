// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using DefinitionParentT = SqlDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>;
    using UpdateDefinitionParentT = SqlDatabase.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>;
    using UpdateParentT = SqlDatabase.Update.IUpdate;
    internal partial class SqlContainerImpl
    {
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<ISqlContainer, ISqlDatabase>.Id
        {
            get
            {
                return this.Id();
            }
        }

        string ISqlContainer.SqlContainerId
        {
            get
            {
                return this.SqlContainerId();
            }
        }

        string ISqlContainer._rid
        {
            get
            {
                return this._rid();
            }
        }

        object ISqlContainer._ts
        {
            get
            {
                return this._ts();
            }
        }

        string ISqlContainer._etag
        {
            get
            {
                return this._etag();
            }
        }

        Models.IndexingPolicy ISqlContainer.IndexingPolicy
        {
            get
            {
                return this.IndexingPolicy();
            }
        }

        Models.ContainerPartitionKey ISqlContainer.PartitionKey
        {
            get
            {
                return this.PartitionKey();
            }
        }

        int? ISqlContainer.DefaultTtl
        {
            get
            {
                return this.DefaultTtl();
            }
        }

        Models.UniqueKeyPolicy ISqlContainer.UniqueKeyPolicy
        {
            get
            {
                return this.UniqueKeyPolicy();
            }
        }

        Models.ConflictResolutionPolicy ISqlContainer.ConflictResolutionPolicy
        {
            get
            {
                return this.ConflictResolutionPolicy();
            }
        }

        SqlContainer.Definition.IWithAttach<DefinitionParentT> HasOptions.Definition.IWithOptions<SqlContainer.Definition.IWithAttach<DefinitionParentT>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        SqlContainer.Definition.IWithAttach<DefinitionParentT> HasOptions.Definition.IWithOptions<SqlContainer.Definition.IWithAttach<DefinitionParentT>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        SqlContainer.Update.IUpdate HasOptions.Update.IWithOptions<SqlContainer.Update.IUpdate>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        SqlContainer.Update.IUpdate HasOptions.Update.IWithOptions<SqlContainer.Update.IUpdate>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        SqlContainer.Update.IUpdate HasOptions.Update.IWithOptions<SqlContainer.Update.IUpdate>.WithOptionsReplace(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsReplace(options);
        }

        SqlContainer.Update.IUpdate HasOptions.Update.IWithOptions<SqlContainer.Update.IUpdate>.WithoutOption(string key)
        {
            return this.WithoutOption(key);
        }

        SqlContainer.Update.IUpdate HasOptions.Update.IWithOptions<SqlContainer.Update.IUpdate>.WithoutOptions()
        {
            return this.WithoutOptions();
        }

        SqlContainer.Definition.IWithAttach<DefinitionParentT> HasThroughputSettings.Definition.IWithThroughput<SqlContainer.Definition.IWithAttach<DefinitionParentT>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        SqlContainer.Update.IUpdate HasThroughputSettings.Update.IWithThroughput<SqlContainer.Update.IUpdate>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        DefinitionParentT Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<DefinitionParentT>.Attach()
        {
            return this.Attach();
        }

        SqlDatabase.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.SqlDatabase.Update.IUpdate>.Parent()
        {
            return this.Attach();
        }

        SqlContainer.Definition.IWithAttach<DefinitionParentT> SqlContainer.Definition.IWithIndexingPolicy<DefinitionParentT>.WithIndexingPolicy(Models.IndexingPolicy indexingPolicy)
        {
            return this.WithIndexingPolicy(indexingPolicy);
        }

        IndexingPolicy.Definition.IBlank<SqlContainer.Definition.IWithAttach<DefinitionParentT>> SqlContainer.Definition.IWithIndexingPolicy<DefinitionParentT>.DefineIndexingPolicy()
        {
            return this.DefineIndexingPolicy();
        }

        SqlContainer.Definition.IWithAttach<DefinitionParentT> SqlContainer.Definition.IWithPartitionKey<DefinitionParentT>.WithContainerPartitionKey(Models.ContainerPartitionKey containerPartitionKey)
        {
            return this.WithContainerPartitionKey(containerPartitionKey);
        }

        SqlContainer.Definition.IWithAttach<DefinitionParentT> SqlContainer.Definition.IWithDefaultTtl<DefinitionParentT>.WithDefaultTtl(int ttl)
        {
            return this.WithDefaultTtl(ttl);
        }

        SqlContainer.Definition.IWithAttach<DefinitionParentT> SqlContainer.Definition.IWithUniqueKeyPolicy<DefinitionParentT>.WithUniqueKeyPolicy(Models.UniqueKeyPolicy uniqueKeyPolicy)
        {
            return this.WithUniqueKeyPolicy(uniqueKeyPolicy);
        }

        SqlContainer.Definition.IWithAttach<DefinitionParentT> SqlContainer.Definition.IWithUniqueKeyPolicy<DefinitionParentT>.WithUniqueKeys(System.Collections.Generic.IList<Models.UniqueKey> uniqueKeys)
        {
            return this.WithUniqueKeys(uniqueKeys);
        }

        SqlContainer.Definition.IWithAttach<DefinitionParentT> SqlContainer.Definition.IWithUniqueKeyPolicy<DefinitionParentT>.WithUniqueKey(Models.UniqueKey uniqueKey)
        {
            return this.WithUniqueKey(-1, uniqueKey);
        }

        SqlContainer.Definition.IWithAttach<DefinitionParentT> SqlContainer.Definition.IWithConflictResolutionPolicy<DefinitionParentT>.WithConflictResolutionPolicy(Models.ConflictResolutionPolicy conflictResolutionPolicy)
        {
            return this.WithConflictResolutionPolicy(conflictResolutionPolicy);
        }

        SqlContainer.Update.IUpdate SqlContainer.Update.IWithIndexingPolicy.WithIndexingPolicy(Models.IndexingPolicy indexingPolicy)
        {
            return this.WithIndexingPolicy(indexingPolicy);
        }

        SqlContainer.Update.IUpdate SqlContainer.Update.IWithIndexingPolicy.WithoutIndexingPolicy()
        {
            return this.WithoutIndexingPolicy();
        }

        IndexingPolicy.Update.IUpdate<SqlContainer.Update.IUpdate> SqlContainer.Update.IWithIndexingPolicy.UpdateIndexingPolicy()
        {
            return this.UpdateIndexingPolicy();
        }

        SqlContainer.Update.IUpdate SqlContainer.Update.IWithPartitionKey.WithContainerPartitionKey(Models.ContainerPartitionKey containerPartitionKey)
        {
            return this.WithContainerPartitionKey(containerPartitionKey);
        }

        SqlContainer.Update.IUpdate SqlContainer.Update.IWithPartitionKey.WithoutContainerPartitionKey()
        {
            return this.WithoutContainerPartitionKey();
        }

        SqlContainer.Update.IUpdate SqlContainer.Update.IWithDefaultTtl.WithDefaultTtl(int ttl)
        {
            return this.WithDefaultTtl(ttl);
        }

        SqlContainer.Update.IUpdate SqlContainer.Update.IWithDefaultTtl.WithoutDefaultTtl()
        {
            return this.WithoutDefaultTtl();
        }

        SqlContainer.Update.IUpdate SqlContainer.Update.IWithUniqueKeyPolicy.WithoutUniqueKey(int index)
        {
            return this.WithoutUniqueKey(index);
        }

        SqlContainer.Update.IUpdate SqlContainer.Update.IWithUniqueKeyPolicy.WithoutUniqueKey(Models.UniqueKey uniqueKey)
        {
            return this.WithoutUniqueKey(uniqueKey);
        }

        SqlContainer.Update.IUpdate SqlContainer.Update.IWithUniqueKeyPolicy.WithoutUniqueKeyPolicy()
        {
            return this.WithoutUniqueKeyPolicy();
        }

        SqlContainer.Update.IUpdate SqlContainer.Update.IWithUniqueKeyPolicy.WithUniqueKey(int index, Models.UniqueKey uniqueKey)
        {
            return this.WithUniqueKey(index, uniqueKey);
        }

        SqlContainer.Update.IUpdate SqlContainer.Update.IWithUniqueKeyPolicy.WithUniqueKeyPolicy(Models.UniqueKeyPolicy uniqueKeyPolicy)
        {
            return this.WithUniqueKeyPolicy(uniqueKeyPolicy);
        }

        SqlContainer.Update.IUpdate SqlContainer.Update.IWithUniqueKeyPolicy.WithUniqueKeys(System.Collections.Generic.IList<Models.UniqueKey> uniqueKeys)
        {
            return this.WithUniqueKeys(uniqueKeys);
        }

        SqlContainer.Update.IUpdate SqlContainer.Update.IWithConflictResolutionPolicy.WithConflictResolutionPolicy(Models.ConflictResolutionPolicy conflictResolutionPolicy)
        {
            return this.WithConflictResolutionPolicy(conflictResolutionPolicy);
        }

        SqlContainer.Update.IUpdate SqlContainer.Update.IWithConflictResolutionPolicy.WithoutConflictResolutionPolicy()
        {
            return this.WithoutConflictResolutionPolicy();
        }

        // definition for UpdateDefinitionParentT
        SqlContainer.Definition.IWithAttach<UpdateDefinitionParentT> HasOptions.Definition.IWithOptions<SqlContainer.Definition.IWithAttach<UpdateDefinitionParentT>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        SqlContainer.Definition.IWithAttach<UpdateDefinitionParentT> HasOptions.Definition.IWithOptions<SqlContainer.Definition.IWithAttach<UpdateDefinitionParentT>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        SqlContainer.Definition.IWithAttach<UpdateDefinitionParentT> HasThroughputSettings.Definition.IWithThroughput<SqlContainer.Definition.IWithAttach<UpdateDefinitionParentT>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        UpdateDefinitionParentT Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<UpdateDefinitionParentT>.Attach()
        {
            return this.Attach();
        }

        SqlContainer.Definition.IWithAttach<UpdateDefinitionParentT> SqlContainer.Definition.IWithIndexingPolicy<UpdateDefinitionParentT>.WithIndexingPolicy(Models.IndexingPolicy indexingPolicy)
        {
            return this.WithIndexingPolicy(indexingPolicy);
        }

        IndexingPolicy.Definition.IBlank<SqlContainer.Definition.IWithAttach<UpdateDefinitionParentT>> SqlContainer.Definition.IWithIndexingPolicy<UpdateDefinitionParentT>.DefineIndexingPolicy()
        {
            return this.DefineIndexingPolicyInParentUpdateDefinition();
        }

        SqlContainer.Definition.IWithAttach<UpdateDefinitionParentT> SqlContainer.Definition.IWithPartitionKey<UpdateDefinitionParentT>.WithContainerPartitionKey(Models.ContainerPartitionKey containerPartitionKey)
        {
            return this.WithContainerPartitionKey(containerPartitionKey);
        }

        SqlContainer.Definition.IWithAttach<UpdateDefinitionParentT> SqlContainer.Definition.IWithDefaultTtl<UpdateDefinitionParentT>.WithDefaultTtl(int ttl)
        {
            return this.WithDefaultTtl(ttl);
        }

        SqlContainer.Definition.IWithAttach<UpdateDefinitionParentT> SqlContainer.Definition.IWithUniqueKeyPolicy<UpdateDefinitionParentT>.WithUniqueKeyPolicy(Models.UniqueKeyPolicy uniqueKeyPolicy)
        {
            return this.WithUniqueKeyPolicy(uniqueKeyPolicy);
        }

        SqlContainer.Definition.IWithAttach<UpdateDefinitionParentT> SqlContainer.Definition.IWithUniqueKeyPolicy<UpdateDefinitionParentT>.WithUniqueKeys(System.Collections.Generic.IList<Models.UniqueKey> uniqueKeys)
        {
            return this.WithUniqueKeys(uniqueKeys);
        }

        SqlContainer.Definition.IWithAttach<UpdateDefinitionParentT> SqlContainer.Definition.IWithUniqueKeyPolicy<UpdateDefinitionParentT>.WithUniqueKey(Models.UniqueKey uniqueKey)
        {
            return this.WithUniqueKey(-1, uniqueKey);
        }

        SqlContainer.Definition.IWithAttach<UpdateDefinitionParentT> SqlContainer.Definition.IWithConflictResolutionPolicy<UpdateDefinitionParentT>.WithConflictResolutionPolicy(Models.ConflictResolutionPolicy conflictResolutionPolicy)
        {
            return this.WithConflictResolutionPolicy(conflictResolutionPolicy);
        }

        // definition for UpdateParentT
        SqlContainer.Definition.IWithAttach<UpdateParentT> HasOptions.Definition.IWithOptions<SqlContainer.Definition.IWithAttach<UpdateParentT>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        SqlContainer.Definition.IWithAttach<UpdateParentT> HasOptions.Definition.IWithOptions<SqlContainer.Definition.IWithAttach<UpdateParentT>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        SqlContainer.Definition.IWithAttach<UpdateParentT> HasThroughputSettings.Definition.IWithThroughput<SqlContainer.Definition.IWithAttach<UpdateParentT>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        UpdateParentT Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<UpdateParentT>.Attach()
        {
            return this.Attach();
        }

        SqlContainer.Definition.IWithAttach<UpdateParentT> SqlContainer.Definition.IWithIndexingPolicy<UpdateParentT>.WithIndexingPolicy(Models.IndexingPolicy indexingPolicy)
        {
            return this.WithIndexingPolicy(indexingPolicy);
        }

        IndexingPolicy.Definition.IBlank<SqlContainer.Definition.IWithAttach<UpdateParentT>> SqlContainer.Definition.IWithIndexingPolicy<UpdateParentT>.DefineIndexingPolicy()
        {
            return this.DefineIndexingPolicyInParentUpdate();
        }

        SqlContainer.Definition.IWithAttach<UpdateParentT> SqlContainer.Definition.IWithPartitionKey<UpdateParentT>.WithContainerPartitionKey(Models.ContainerPartitionKey containerPartitionKey)
        {
            return this.WithContainerPartitionKey(containerPartitionKey);
        }

        SqlContainer.Definition.IWithAttach<UpdateParentT> SqlContainer.Definition.IWithDefaultTtl<UpdateParentT>.WithDefaultTtl(int ttl)
        {
            return this.WithDefaultTtl(ttl);
        }

        SqlContainer.Definition.IWithAttach<UpdateParentT> SqlContainer.Definition.IWithUniqueKeyPolicy<UpdateParentT>.WithUniqueKeyPolicy(Models.UniqueKeyPolicy uniqueKeyPolicy)
        {
            return this.WithUniqueKeyPolicy(uniqueKeyPolicy);
        }

        SqlContainer.Definition.IWithAttach<UpdateParentT> SqlContainer.Definition.IWithUniqueKeyPolicy<UpdateParentT>.WithUniqueKeys(System.Collections.Generic.IList<Models.UniqueKey> uniqueKeys)
        {
            return this.WithUniqueKeys(uniqueKeys);
        }

        SqlContainer.Definition.IWithAttach<UpdateParentT> SqlContainer.Definition.IWithUniqueKeyPolicy<UpdateParentT>.WithUniqueKey(Models.UniqueKey uniqueKey)
        {
            return this.WithUniqueKey(-1, uniqueKey);
        }

        SqlContainer.Definition.IWithAttach<UpdateParentT> SqlContainer.Definition.IWithConflictResolutionPolicy<UpdateParentT>.WithConflictResolutionPolicy(Models.ConflictResolutionPolicy conflictResolutionPolicy)
        {
            return this.WithConflictResolutionPolicy(conflictResolutionPolicy);
        }
    }
}
