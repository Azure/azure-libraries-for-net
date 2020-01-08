// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using DefinitionParentT = MongoDB.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>;
    using UpdateDefinitionParentT = MongoDB.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>;
    using UpdateParentT = MongoDB.Update.IUpdate;
    internal partial class MongoCollectionImpl
    {
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<IMongoCollection, IMongoDB>.Id
        {
            get
            {
                return this.Id();
            }
        }

        string IMongoCollection.MongoCollectionId
        {
            get
            {
                return this.MongoCollectionId();
            }
        }

        string IMongoCollection._rid
        {
            get
            {
                return this._rid();
            }
        }

        object IMongoCollection._ts
        {
            get
            {
                return this._ts();
            }
        }

        string IMongoCollection._etag
        {
            get
            {
                return this._etag();
            }
        }

        IReadOnlyDictionary<string, string> IMongoCollection.ShardKey
        {
            get
            {
                return this.ShardKey();
            }
        }

        IReadOnlyList<MongoIndex> IMongoCollection.Indexes
        {
            get
            {
                return this.Indexes();
            }
        }

        ThroughputSettingsGetPropertiesResource IMongoCollection.GetThroughputSettings()
        {
            return this.GetThroughputSettings();
        }

        Task<ThroughputSettingsGetPropertiesResource> IMongoCollection.GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetThroughputSettingsAsync(cancellationToken);
        }

        MongoCollection.Update.IUpdate HasOptions.Update.IWithOptions<MongoCollection.Update.IUpdate>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        MongoCollection.Update.IUpdate HasOptions.Update.IWithOptions<MongoCollection.Update.IUpdate>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        MongoCollection.Update.IUpdate HasOptions.Update.IWithOptions<MongoCollection.Update.IUpdate>.WithOptionsReplace(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsReplace(options);
        }

        MongoCollection.Update.IUpdate HasOptions.Update.IWithOptions<MongoCollection.Update.IUpdate>.WithoutOption(string key)
        {
            return this.WithoutOption(key);
        }

        MongoCollection.Update.IUpdate HasOptions.Update.IWithOptions<MongoCollection.Update.IUpdate>.WithoutOptions()
        {
            return this.WithoutOptions();
        }

        MongoCollection.Update.IUpdate HasThroughputSettings.Update.IWithThroughput<MongoCollection.Update.IUpdate>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        MongoDB.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.MongoDB.Update.IUpdate>.Parent()
        {
            return this.Attach();
        }

        MongoCollection.Update.IUpdate MongoCollection.Update.IWithShardKey.WithShardKey(string shardKey)
        {
            return this.WithShardKey(shardKey);
        }

        MongoCollection.Update.IUpdate MongoCollection.Update.IWithShardKey.WithShardKey(string shardKey, string partitionKind)
        {
            return this.WithShardKey(shardKey, partitionKind);
        }

        MongoCollection.Update.IUpdate MongoCollection.Update.IWithShardKey.WithoutShardKey(string shardKey)
        {
            return this.WithoutShardKey(shardKey);
        }

        MongoCollection.Update.IUpdate MongoCollection.Update.IWithShardKey.WithShardKeys(IDictionary<string, string> shardKeys)
        {
            return this.WithShardKeys(shardKeys);
        }

        MongoCollection.Update.IUpdate MongoCollection.Update.IWithShardKey.WithoutShardKeys()
        {
            return this.WithoutShardKeys();
        }

        MongoCollection.Update.IUpdate MongoCollection.Update.IWithIndex.WithIndex(MongoIndex index)
        {
            return this.WithIndex(index);
        }

        MongoCollection.Update.IUpdate MongoCollection.Update.IWithIndex.WithIndex(MongoIndexKeys key, MongoIndexOptions option)
        {
            return this.WithIndex(key, option);
        }

        MongoCollection.Update.IUpdate MongoCollection.Update.IWithIndex.WithIndexesAppend(IList<MongoIndex> indexes)
        {
            return this.WithIndexesAppend(indexes);
        }

        MongoCollection.Update.IUpdate MongoCollection.Update.IWithIndex.WithIndexesReplace(IList<MongoIndex> indexes)
        {
            return this.WithIndexesReplace(indexes);
        }

        MongoCollection.Update.IUpdate MongoCollection.Update.IWithIndex.WithoutIndexes()
        {
            return this.WithoutIndexes();
        }

        // definition for DefinitionParentT

        MongoCollection.Definition.IWithAttach<DefinitionParentT> HasOptions.Definition.IWithOptions<MongoCollection.Definition.IWithAttach<DefinitionParentT>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        MongoCollection.Definition.IWithAttach<DefinitionParentT> HasOptions.Definition.IWithOptions<MongoCollection.Definition.IWithAttach<DefinitionParentT>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        MongoCollection.Definition.IWithAttach<DefinitionParentT> HasThroughputSettings.Definition.IWithThroughput<MongoCollection.Definition.IWithAttach<DefinitionParentT>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        DefinitionParentT Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<DefinitionParentT>.Attach()
        {
            return this.Attach();
        }

        MongoCollection.Definition.IWithAttach<DefinitionParentT> MongoCollection.Definition.IWithShardKey<DefinitionParentT>.WithShardKey(string shardKey)
        {
            return this.WithShardKey(shardKey);
        }

        MongoCollection.Definition.IWithAttach<DefinitionParentT> MongoCollection.Definition.IWithShardKey<DefinitionParentT>.WithShardKey(string shardKey, string partitionKind)
        {
            return this.WithShardKey(shardKey, partitionKind);
        }

        MongoCollection.Definition.IWithAttach<DefinitionParentT> MongoCollection.Definition.IWithShardKey<DefinitionParentT>.WithShardKeys(IDictionary<string, string> shardKeys)
        {
            return this.WithShardKeys(shardKeys);
        }

        MongoCollection.Definition.IWithAttach<DefinitionParentT> MongoCollection.Definition.IWithIndex<DefinitionParentT>.WithIndex(MongoIndex index)
        {
            return this.WithIndex(index);
        }

        MongoCollection.Definition.IWithAttach<DefinitionParentT> MongoCollection.Definition.IWithIndex<DefinitionParentT>.WithIndex(MongoIndexKeys key, MongoIndexOptions option)
        {
            return this.WithIndex(key, option);
        }

        MongoCollection.Definition.IWithAttach<DefinitionParentT> MongoCollection.Definition.IWithIndex<DefinitionParentT>.WithIndexes(IList<MongoIndex> indexes)
        {
            return this.WithIndexesAppend(indexes);
        }

        // definition for UpdateDefinitionParentT
        MongoCollection.Definition.IWithAttach<UpdateDefinitionParentT> HasOptions.Definition.IWithOptions<MongoCollection.Definition.IWithAttach<UpdateDefinitionParentT>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        MongoCollection.Definition.IWithAttach<UpdateDefinitionParentT> HasOptions.Definition.IWithOptions<MongoCollection.Definition.IWithAttach<UpdateDefinitionParentT>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        MongoCollection.Definition.IWithAttach<UpdateDefinitionParentT> HasThroughputSettings.Definition.IWithThroughput<MongoCollection.Definition.IWithAttach<UpdateDefinitionParentT>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        UpdateDefinitionParentT Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<UpdateDefinitionParentT>.Attach()
        {
            return this.Attach();
        }

        MongoCollection.Definition.IWithAttach<UpdateDefinitionParentT> MongoCollection.Definition.IWithShardKey<UpdateDefinitionParentT>.WithShardKey(string shardKey)
        {
            return this.WithShardKey(shardKey);
        }

        MongoCollection.Definition.IWithAttach<UpdateDefinitionParentT> MongoCollection.Definition.IWithShardKey<UpdateDefinitionParentT>.WithShardKey(string shardKey, string partitionKind)
        {
            return this.WithShardKey(shardKey, partitionKind);
        }

        MongoCollection.Definition.IWithAttach<UpdateDefinitionParentT> MongoCollection.Definition.IWithShardKey<UpdateDefinitionParentT>.WithShardKeys(IDictionary<string, string> shardKeys)
        {
            return this.WithShardKeys(shardKeys);
        }

        MongoCollection.Definition.IWithAttach<UpdateDefinitionParentT> MongoCollection.Definition.IWithIndex<UpdateDefinitionParentT>.WithIndex(MongoIndex index)
        {
            return this.WithIndex(index);
        }

        MongoCollection.Definition.IWithAttach<UpdateDefinitionParentT> MongoCollection.Definition.IWithIndex<UpdateDefinitionParentT>.WithIndex(MongoIndexKeys key, MongoIndexOptions option)
        {
            return this.WithIndex(key, option);
        }

        MongoCollection.Definition.IWithAttach<UpdateDefinitionParentT> MongoCollection.Definition.IWithIndex<UpdateDefinitionParentT>.WithIndexes(IList<MongoIndex> indexes)
        {
            return this.WithIndexesAppend(indexes);
        }

        // definition for UpdateParentT
        MongoCollection.Definition.IWithAttach<UpdateParentT> HasOptions.Definition.IWithOptions<MongoCollection.Definition.IWithAttach<UpdateParentT>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        MongoCollection.Definition.IWithAttach<UpdateParentT> HasOptions.Definition.IWithOptions<MongoCollection.Definition.IWithAttach<UpdateParentT>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        MongoCollection.Definition.IWithAttach<UpdateParentT> HasThroughputSettings.Definition.IWithThroughput<MongoCollection.Definition.IWithAttach<UpdateParentT>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        UpdateParentT Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<UpdateParentT>.Attach()
        {
            return this.Attach();
        }

        MongoCollection.Definition.IWithAttach<UpdateParentT> MongoCollection.Definition.IWithShardKey<UpdateParentT>.WithShardKey(string shardKey)
        {
            return this.WithShardKey(shardKey);
        }

        MongoCollection.Definition.IWithAttach<UpdateParentT> MongoCollection.Definition.IWithShardKey<UpdateParentT>.WithShardKey(string shardKey, string partitionKind)
        {
            return this.WithShardKey(shardKey, partitionKind);
        }

        MongoCollection.Definition.IWithAttach<UpdateParentT> MongoCollection.Definition.IWithShardKey<UpdateParentT>.WithShardKeys(IDictionary<string, string> shardKeys)
        {
            return this.WithShardKeys(shardKeys);
        }

        MongoCollection.Definition.IWithAttach<UpdateParentT> MongoCollection.Definition.IWithIndex<UpdateParentT>.WithIndex(MongoIndex index)
        {
            return this.WithIndex(index);
        }

        MongoCollection.Definition.IWithAttach<UpdateParentT> MongoCollection.Definition.IWithIndex<UpdateParentT>.WithIndex(MongoIndexKeys key, MongoIndexOptions option)
        {
            return this.WithIndex(key, option);
        }

        MongoCollection.Definition.IWithAttach<UpdateParentT> MongoCollection.Definition.IWithIndex<UpdateParentT>.WithIndexes(IList<MongoIndex> indexes)
        {
            return this.WithIndexesAppend(indexes);
        }
    }
}
