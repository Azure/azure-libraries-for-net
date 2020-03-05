// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using DefinitionParentT = GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>;
    using UpdateDefinitionParentT = GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>;
    using UpdateParentT = GremlinDatabase.Update.IUpdate;
    internal partial class GremlinGraphImpl
    {
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<IGremlinGraph, IGremlinDatabase>.Id
        {
            get
            {
                return this.Id();
            }
        }

        string IGremlinGraph.GremlinGraphId
        {
            get
            {
                return this.GremlinGraphId();
            }
        }

        string IGremlinGraph._rid
        {
            get
            {
                return this._rid();
            }
        }

        object IGremlinGraph._ts
        {
            get
            {
                return this._ts();
            }
        }

        string IGremlinGraph._etag
        {
            get
            {
                return this._etag();
            }
        }

        Models.IndexingPolicy IGremlinGraph.IndexingPolicy
        {
            get
            {
                return this.IndexingPolicy();
            }
        }

        Models.ContainerPartitionKey IGremlinGraph.PartitionKey
        {
            get
            {
                return this.PartitionKey();
            }
        }

        int? IGremlinGraph.DefaultTtl
        {
            get
            {
                return this.DefaultTtl();
            }
        }

        Models.UniqueKeyPolicy IGremlinGraph.UniqueKeyPolicy
        {
            get
            {
                return this.UniqueKeyPolicy();
            }
        }

        Models.ConflictResolutionPolicy IGremlinGraph.ConflictResolutionPolicy
        {
            get
            {
                return this.ConflictResolutionPolicy();
            }
        }

        ThroughputSettingsGetPropertiesResource IGremlinGraph.GetThroughputSettings()
        {
            return this.GetThroughputSettings();
        }

        Task<ThroughputSettingsGetPropertiesResource> IGremlinGraph.GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetThroughputSettingsAsync(cancellationToken);
        }

        GremlinGraph.Update.IUpdate HasOptions.Update.IWithOptions<GremlinGraph.Update.IUpdate>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        GremlinGraph.Update.IUpdate HasOptions.Update.IWithOptions<GremlinGraph.Update.IUpdate>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        GremlinGraph.Update.IUpdate HasOptions.Update.IWithOptions<GremlinGraph.Update.IUpdate>.WithOptionsReplace(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsReplace(options);
        }

        GremlinGraph.Update.IUpdate HasOptions.Update.IWithOptions<GremlinGraph.Update.IUpdate>.WithoutOption(string key)
        {
            return this.WithoutOption(key);
        }

        GremlinGraph.Update.IUpdate HasOptions.Update.IWithOptions<GremlinGraph.Update.IUpdate>.WithoutOptions()
        {
            return this.WithoutOptions();
        }

        GremlinGraph.Update.IUpdate HasThroughputSettings.Update.IWithThroughput<GremlinGraph.Update.IUpdate>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        GremlinDatabase.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.GremlinDatabase.Update.IUpdate>.Parent()
        {
            return this.Attach();
        }

        GremlinGraph.Update.IUpdate GremlinGraph.Update.IWithIndexingPolicy.WithIndexingPolicy(Models.IndexingPolicy indexingPolicy)
        {
            return this.WithIndexingPolicy(indexingPolicy);
        }

        GremlinGraph.Update.IUpdate GremlinGraph.Update.IWithIndexingPolicy.WithoutIndexingPolicy()
        {
            return this.WithoutIndexingPolicy();
        }

        IndexingPolicy.Update.IWithAttach<GremlinGraph.Update.IUpdate> GremlinGraph.Update.IWithIndexingPolicy.UpdateIndexingPolicy()
        {
            return this.UpdateIndexingPolicy();
        }

        GremlinGraph.Update.IUpdate GremlinGraph.Update.IWithPartitionKey.WithPartitionKey(Models.ContainerPartitionKey containerPartitionKey)
        {
            return this.WithPartitionKey(containerPartitionKey);
        }

        GremlinGraph.Update.IUpdate GremlinGraph.Update.IWithPartitionKey.WithPartitionKey(IList<string> paths, Models.PartitionKind kind, int? version)
        {
            return this.WithPartitionKey(paths, kind, version);
        }

        GremlinGraph.Update.IUpdate GremlinGraph.Update.IWithPartitionKey.WithoutPartitionKey()
        {
            return this.WithoutPartitionKey();
        }

        GremlinGraph.Update.IUpdate GremlinGraph.Update.IWithDefaultTtl.WithDefaultTtl(int ttl)
        {
            return this.WithDefaultTtl(ttl);
        }

        GremlinGraph.Update.IUpdate GremlinGraph.Update.IWithDefaultTtl.WithoutDefaultTtl()
        {
            return this.WithoutDefaultTtl();
        }

        GremlinGraph.Update.IUpdate GremlinGraph.Update.IWithUniqueKeyPolicy.WithoutUniqueKeyPolicy()
        {
            return this.WithoutUniqueKeyPolicy();
        }

        GremlinGraph.Update.IUpdate GremlinGraph.Update.IWithUniqueKeyPolicy.WithUniqueKey(Models.UniqueKey uniqueKey)
        {
            return this.WithUniqueKey(uniqueKey);
        }

        GremlinGraph.Update.IUpdate GremlinGraph.Update.IWithUniqueKeyPolicy.WithUniqueKeyPolicy(Models.UniqueKeyPolicy uniqueKeyPolicy)
        {
            return this.WithUniqueKeyPolicy(uniqueKeyPolicy);
        }

        GremlinGraph.Update.IUpdate GremlinGraph.Update.IWithUniqueKeyPolicy.WithUniqueKeys(System.Collections.Generic.IList<Models.UniqueKey> uniqueKeys)
        {
            return this.WithUniqueKeys(uniqueKeys);
        }

        GremlinGraph.Update.IUpdate GremlinGraph.Update.IWithConflictResolutionPolicy.WithConflictResolutionPolicy(Models.ConflictResolutionPolicy conflictResolutionPolicy)
        {
            return this.WithConflictResolutionPolicy(conflictResolutionPolicy);
        }

        GremlinGraph.Update.IUpdate GremlinGraph.Update.IWithConflictResolutionPolicy.WithoutConflictResolutionPolicy()
        {
            return this.WithoutConflictResolutionPolicy();
        }

        // definition for DefinitionParentT

        GremlinGraph.Definition.IWithAttach<DefinitionParentT> HasOptions.Definition.IWithOptions<GremlinGraph.Definition.IWithAttach<DefinitionParentT>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        GremlinGraph.Definition.IWithAttach<DefinitionParentT> HasOptions.Definition.IWithOptions<GremlinGraph.Definition.IWithAttach<DefinitionParentT>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        GremlinGraph.Definition.IWithAttach<DefinitionParentT> HasThroughputSettings.Definition.IWithThroughput<GremlinGraph.Definition.IWithAttach<DefinitionParentT>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        DefinitionParentT Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<DefinitionParentT>.Attach()
        {
            return this.Attach();
        }

        GremlinGraph.Definition.IWithAttach<DefinitionParentT> GremlinGraph.Definition.IWithIndexingPolicy<DefinitionParentT>.WithIndexingPolicy(Models.IndexingPolicy indexingPolicy)
        {
            return this.WithIndexingPolicy(indexingPolicy);
        }

        IndexingPolicy.Definition.IBlank<GremlinGraph.Definition.IWithAttach<DefinitionParentT>> GremlinGraph.Definition.IWithIndexingPolicy<DefinitionParentT>.DefineIndexingPolicy()
        {
            return this.DefineIndexingPolicy();
        }

        GremlinGraph.Definition.IWithAttach<DefinitionParentT> GremlinGraph.Definition.IWithPartitionKey<DefinitionParentT>.WithPartitionKey(Models.ContainerPartitionKey containerPartitionKey)
        {
            return this.WithPartitionKey(containerPartitionKey);
        }

        GremlinGraph.Definition.IWithAttach<DefinitionParentT> GremlinGraph.Definition.IWithPartitionKey<DefinitionParentT>.WithPartitionKey(IList<string> paths, Models.PartitionKind kind, int? version)
        {
            return this.WithPartitionKey(paths, kind, version);
        }

        GremlinGraph.Definition.IWithAttach<DefinitionParentT> GremlinGraph.Definition.IWithDefaultTtl<DefinitionParentT>.WithDefaultTtl(int ttl)
        {
            return this.WithDefaultTtl(ttl);
        }

        GremlinGraph.Definition.IWithAttach<DefinitionParentT> GremlinGraph.Definition.IWithUniqueKeyPolicy<DefinitionParentT>.WithUniqueKeyPolicy(Models.UniqueKeyPolicy uniqueKeyPolicy)
        {
            return this.WithUniqueKeyPolicy(uniqueKeyPolicy);
        }

        GremlinGraph.Definition.IWithAttach<DefinitionParentT> GremlinGraph.Definition.IWithUniqueKeyPolicy<DefinitionParentT>.WithUniqueKeys(System.Collections.Generic.IList<Models.UniqueKey> uniqueKeys)
        {
            return this.WithUniqueKeys(uniqueKeys);
        }

        GremlinGraph.Definition.IWithAttach<DefinitionParentT> GremlinGraph.Definition.IWithUniqueKeyPolicy<DefinitionParentT>.WithUniqueKey(Models.UniqueKey uniqueKey)
        {
            return this.WithUniqueKey(uniqueKey);
        }

        GremlinGraph.Definition.IWithAttach<DefinitionParentT> GremlinGraph.Definition.IWithConflictResolutionPolicy<DefinitionParentT>.WithConflictResolutionPolicy(Models.ConflictResolutionPolicy conflictResolutionPolicy)
        {
            return this.WithConflictResolutionPolicy(conflictResolutionPolicy);
        }

        // definition for UpdateDefinitionParentT
        GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT> HasOptions.Definition.IWithOptions<GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT> HasOptions.Definition.IWithOptions<GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT> HasThroughputSettings.Definition.IWithThroughput<GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        UpdateDefinitionParentT Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<UpdateDefinitionParentT>.Attach()
        {
            return this.Attach();
        }

        GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT> GremlinGraph.Definition.IWithIndexingPolicy<UpdateDefinitionParentT>.WithIndexingPolicy(Models.IndexingPolicy indexingPolicy)
        {
            return this.WithIndexingPolicy(indexingPolicy);
        }

        IndexingPolicy.Definition.IBlank<GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT>> GremlinGraph.Definition.IWithIndexingPolicy<UpdateDefinitionParentT>.DefineIndexingPolicy()
        {
            return this.DefineIndexingPolicyInParentUpdateDefinition();
        }

        GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT> GremlinGraph.Definition.IWithPartitionKey<UpdateDefinitionParentT>.WithPartitionKey(Models.ContainerPartitionKey containerPartitionKey)
        {
            return this.WithPartitionKey(containerPartitionKey);
        }

        GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT> GremlinGraph.Definition.IWithPartitionKey<UpdateDefinitionParentT>.WithPartitionKey(IList<string> paths, Models.PartitionKind kind, int? version)
        {
            return this.WithPartitionKey(paths, kind, version);
        }

        GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT> GremlinGraph.Definition.IWithDefaultTtl<UpdateDefinitionParentT>.WithDefaultTtl(int ttl)
        {
            return this.WithDefaultTtl(ttl);
        }

        GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT> GremlinGraph.Definition.IWithUniqueKeyPolicy<UpdateDefinitionParentT>.WithUniqueKeyPolicy(Models.UniqueKeyPolicy uniqueKeyPolicy)
        {
            return this.WithUniqueKeyPolicy(uniqueKeyPolicy);
        }

        GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT> GremlinGraph.Definition.IWithUniqueKeyPolicy<UpdateDefinitionParentT>.WithUniqueKeys(System.Collections.Generic.IList<Models.UniqueKey> uniqueKeys)
        {
            return this.WithUniqueKeys(uniqueKeys);
        }

        GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT> GremlinGraph.Definition.IWithUniqueKeyPolicy<UpdateDefinitionParentT>.WithUniqueKey(Models.UniqueKey uniqueKey)
        {
            return this.WithUniqueKey(uniqueKey);
        }

        GremlinGraph.Definition.IWithAttach<UpdateDefinitionParentT> GremlinGraph.Definition.IWithConflictResolutionPolicy<UpdateDefinitionParentT>.WithConflictResolutionPolicy(Models.ConflictResolutionPolicy conflictResolutionPolicy)
        {
            return this.WithConflictResolutionPolicy(conflictResolutionPolicy);
        }

        // definition for UpdateParentT
        GremlinGraph.Definition.IWithAttach<UpdateParentT> HasOptions.Definition.IWithOptions<GremlinGraph.Definition.IWithAttach<UpdateParentT>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        GremlinGraph.Definition.IWithAttach<UpdateParentT> HasOptions.Definition.IWithOptions<GremlinGraph.Definition.IWithAttach<UpdateParentT>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        GremlinGraph.Definition.IWithAttach<UpdateParentT> HasThroughputSettings.Definition.IWithThroughput<GremlinGraph.Definition.IWithAttach<UpdateParentT>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        UpdateParentT Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<UpdateParentT>.Attach()
        {
            return this.Attach();
        }

        GremlinGraph.Definition.IWithAttach<UpdateParentT> GremlinGraph.Definition.IWithIndexingPolicy<UpdateParentT>.WithIndexingPolicy(Models.IndexingPolicy indexingPolicy)
        {
            return this.WithIndexingPolicy(indexingPolicy);
        }

        IndexingPolicy.Definition.IBlank<GremlinGraph.Definition.IWithAttach<UpdateParentT>> GremlinGraph.Definition.IWithIndexingPolicy<UpdateParentT>.DefineIndexingPolicy()
        {
            return this.DefineIndexingPolicyInParentUpdate();
        }

        GremlinGraph.Definition.IWithAttach<UpdateParentT> GremlinGraph.Definition.IWithPartitionKey<UpdateParentT>.WithPartitionKey(Models.ContainerPartitionKey containerPartitionKey)
        {
            return this.WithPartitionKey(containerPartitionKey);
        }

        GremlinGraph.Definition.IWithAttach<UpdateParentT> GremlinGraph.Definition.IWithPartitionKey<UpdateParentT>.WithPartitionKey(IList<string> paths, Models.PartitionKind kind, int? version)
        {
            return this.WithPartitionKey(paths, kind, version);
        }

        GremlinGraph.Definition.IWithAttach<UpdateParentT> GremlinGraph.Definition.IWithDefaultTtl<UpdateParentT>.WithDefaultTtl(int ttl)
        {
            return this.WithDefaultTtl(ttl);
        }

        GremlinGraph.Definition.IWithAttach<UpdateParentT> GremlinGraph.Definition.IWithUniqueKeyPolicy<UpdateParentT>.WithUniqueKeyPolicy(Models.UniqueKeyPolicy uniqueKeyPolicy)
        {
            return this.WithUniqueKeyPolicy(uniqueKeyPolicy);
        }

        GremlinGraph.Definition.IWithAttach<UpdateParentT> GremlinGraph.Definition.IWithUniqueKeyPolicy<UpdateParentT>.WithUniqueKeys(System.Collections.Generic.IList<Models.UniqueKey> uniqueKeys)
        {
            return this.WithUniqueKeys(uniqueKeys);
        }

        GremlinGraph.Definition.IWithAttach<UpdateParentT> GremlinGraph.Definition.IWithUniqueKeyPolicy<UpdateParentT>.WithUniqueKey(Models.UniqueKey uniqueKey)
        {
            return this.WithUniqueKey(uniqueKey);
        }

        GremlinGraph.Definition.IWithAttach<UpdateParentT> GremlinGraph.Definition.IWithConflictResolutionPolicy<UpdateParentT>.WithConflictResolutionPolicy(Models.ConflictResolutionPolicy conflictResolutionPolicy)
        {
            return this.WithConflictResolutionPolicy(conflictResolutionPolicy);
        }
    }
}
