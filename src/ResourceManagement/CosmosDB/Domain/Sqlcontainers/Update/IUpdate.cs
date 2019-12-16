﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.CosmosDB.Fluent.Sqlcontainers.Update
{
    /// <summary>
    /// The entirety of a sql container update as a part of parent update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.SqlDatabase.Update.IUpdate>,
        IWithOptions,
        IWithThroughput,
        IWithIndexingPolicy,
        IWithPartitionKey,
        IWithDefaultTtl,
        IWithUniqueKeyPolicy,
        IWithConflictResolutionPolicy
    {
    }

    /// <summary>
    /// The stage of a sql container update allowing to set options.
    /// </summary>
    public interface IWithOptions :
        HasOptions.Update.IWithOptions<IUpdate>
    {
    }

    /// <summary>
    /// The stage of a sql container update allowing to set through put.
    /// </summary>
    public interface IWithThroughput :
        HasThroughputSettings.Update.IWithThroughput<IUpdate>
    {
    }

    /// <summary>
    /// The stage of a sql container update allowing to set indexing policy.
    /// </summary>
    public interface IWithIndexingPolicy
    {
        /// <summary>
        /// Specifies indexing policy.
        /// </summary>
        /// <param name="indexingPolicy">The whole object of the indexing policy.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithIndexingPolicy(Models.IndexingPolicy indexingPolicy);

        /// <summary>
        /// Removes indexing policy.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutIndexingPolicy();

        /// <summary>
        /// Starts the update of indexing policy.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IndexingPolicy.Update.IUpdate<IUpdate> UpdateIndexingPolicy();
    }

    /// <summary>
    /// The stage of a sql container update allowing to set partition key.
    /// </summary>
    public interface IWithPartitionKey
    {
        /// <summary>
        /// Specifies container partition key.
        /// </summary>
        /// <param name="containerPartitionKey">The whole object of the container partition key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithContainerPartitionKey(ContainerPartitionKey containerPartitionKey);


        /// <summary>
        /// Removes container partition key.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutContainerPartitionKey();
    }

    /// <summary>
    /// The stage of a sql container update allowing to set default ttl.
    /// </summary>
    public interface IWithDefaultTtl
    {
        /// <summary>
        /// Specifies default ttl.
        /// </summary>
        /// <param name="ttl">The default time to live.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithDefaultTtl(int ttl);

        /// <summary>
        /// Remove default ttl.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutDefaultTtl();
    }

    /// <summary>
    /// The stage of a sql container update allowing to set unique key policy.
    /// </summary>
    public interface IWithUniqueKeyPolicy
    {
        /// <summary>
        /// Specifies unique key policy.
        /// </summary>
        /// <param name="uniqueKeyPolicy">The whole object of the unique key policy.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithUniqueKeyPolicy(UniqueKeyPolicy uniqueKeyPolicy);

        /// <summary>
        /// Removes unique key policy.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutUniqueKeyPolicy();

        /// <summary>
        /// Specifies the list of unique key.
        /// </summary>
        /// <param name="uniqueKeys">The list of unique key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithUniqueKeys(IList<UniqueKey> uniqueKeys);

        /// <summary>
        /// Specifies the a unique key appended to original list.
        /// </summary>
        /// <param name="uniqueKey">A unique key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithUniqueKey(UniqueKey uniqueKey);


        /// <summary>
        /// Removes a unique key.
        /// </summary>
        /// <param name="index">The index of the unique key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutUniqueKey(int index);
    }

    /// <summary>
    /// The stage of a sql container update allowing to set conflict resolution policy.
    /// </summary>
    public interface IWithConflictResolutionPolicy
    {
        /// <summary>
        /// Specifies conflict resolution policy.
        /// </summary>
        /// <param name="conflictResolutionPolicy">The whole object of the conflict resolution policy.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithConflictResolutionPolicy(ConflictResolutionPolicy conflictResolutionPolicy);

        /// <summary>
        /// Removes conflict resolution policy.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutConflictResolutionPolicy();
    }
}
