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
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IUpdate>,
        IWithOptions,
        IWithThroughput,
        IWithSharedKey,
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
    /// The stage of the mongo collection update allowing to set shared keys.
    /// </summary>
    public interface IWithSharedKey
    {
        /// <summary>
        /// Specifies a shared key with default partition kind "Hash".
        /// </summary>
        /// <param name="sharedKey">The shared key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithSharedKey(string sharedKey);

        /// <summary>
        /// Specifies a shared key.
        /// </summary>
        /// <param name="sharedKey">The shared key.</param>
        /// <param name="partitionKind">The partition kind, only support "Hash" partition kind in api-version 2019-08-01.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithSharedKey(string sharedKey, string partitionKind);

        /// <summary>
        /// Removes a shared key.
        /// </summary>
        /// <param name="sharedKey">The shared key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutSharedKey(string sharedKey);

        /// <summary>
        /// Appends all shared keys to current shared keys.
        /// </summary>
        /// <param name="sharedKeys">The shared keys needs appending.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithSharedKeys(IDictionary<string, string> sharedKeys);

        /// <summary>
        /// Removes all shared keys.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutSharedKeys();
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
        /// Removes a mongo index.
        /// </summary>
        /// <param name="index">The specific mongo index.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutIndex(MongoIndex index);

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
