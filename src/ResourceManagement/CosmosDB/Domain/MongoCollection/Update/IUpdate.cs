// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.CosmosDB.Fluent.MongoCollection.Update
{
    /// <summary>
    /// The entirety of mongo collection update as a part of parent cosmos db account update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.MongoDB.Update.IUpdate>,
        IWithOptions,
        IWithThroughput,
        IWithShardKey,
        IWithIndex
    {
    }

    /// <summary>
    /// The stage of the mongo collection update allowing to set options.
    /// </summary>
    public interface IWithOptions :
        HasOptions.Update.IWithOptions<IUpdate>
    {
    }

    /// <summary>
    /// The stage of the mongo collection update allowing to set throughput.
    /// </summary>
    public interface IWithThroughput :
        HasThroughputSettings.Update.IWithThroughput<IUpdate>
    {
    }

    /// <summary>
    /// The stage of the mongo collection update allowing to set shard keys.
    /// </summary>
    public interface IWithShardKey
    {
        /// <summary>
        /// Specifies a shard key with default partition kind "Hash".
        /// </summary>
        /// <param name="shardKey">The shard key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithShardKey(string shardKey);

        /// <summary>
        /// Specifies a shard key.
        /// </summary>
        /// <param name="shardKey">The shard key.</param>
        /// <param name="partitionKind">The partition kind, only support "Hash" partition kind in api-version 2019-08-01.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithShardKey(string shardKey, string partitionKind);

        /// <summary>
        /// Removes a shard key.
        /// </summary>
        /// <param name="shardKey">The shard key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutShardKey(string shardKey);

        /// <summary>
        /// Appends all shard keys to current shard keys.
        /// </summary>
        /// <param name="shardKeys">The shard keys needs appending.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithShardKeys(IDictionary<string, string> shardKeys);

        /// <summary>
        /// Removes all shard keys.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutShardKeys();
    }

    /// <summary>
    /// The stage of the mongo collection update allowing to set indexes.
    /// </summary>
    public interface IWithIndex
    {
        /// <summary>
        /// Specifies a mongo index.
        /// </summary>
        /// <param name="index">The specific mongo index.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithIndex(MongoIndex index);

        /// <summary>
        /// Specifies a mongo index.
        /// </summary>
        /// <param name="key">The key of the index.</param>
        /// <param name="option">The option of the index.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithIndex(MongoIndexKeys key, MongoIndexOptions option);

        /// <summary>
        /// Appends all mongo indexes to current indexes.
        /// </summary>
        /// <param name="indexes">The indexes needs appending.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithIndexesAppend(IList<MongoIndex> indexes);

        /// <summary>
        /// Replaces the mongo indexes.
        /// </summary>
        /// <param name="indexes">The mongo indexes.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithIndexesReplace(IList<MongoIndex> indexes);

        /// <summary>
        /// Removes all mongo indexes.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutIndexes();
    }
}
