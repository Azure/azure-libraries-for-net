// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.CassandraTable.Update
{
    using System.Collections.Generic;

    /// <summary>
    /// The entirety of a Cassandra table update as a part of parent update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.CassandraKeyspace.Update.IUpdate>,
        IWithOptions,
        IWithThroughput,
        IWithDefaultTtl,
        IWithColumn,
        IWithPartitionKey,
        IWithClusterKey
    {
    }

    /// <summary>
    /// The stage of a Cassandra table update allowing to set options.
    /// </summary>
    public interface IWithOptions :
        HasOptions.Update.IWithOptions<IUpdate>
    {
    }

    /// <summary>
    /// The stage of a Cassandra table update allowing to set throughput.
    /// </summary>
    public interface IWithThroughput :
        HasThroughputSettings.Update.IWithThroughput<IUpdate>
    {
    }

    /// <summary>
    /// The stage of a Cassandra table update allowing to set default ttl.
    /// </summary>
    public interface IWithDefaultTtl
    {
        /// <summary>
        /// Specifies the default time to live.
        /// </summary>
        /// <param name="ttl">The default time to live.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithDefaultTtl(int ttl);

        /// <summary>
        /// Removes the default ttl.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutDefaultTtl();
    }

    /// <summary>
    /// The stage of a Cassandra table update allowing to set Cassandra table columns.
    /// </summary>
    public interface IWithColumn
    {
        /// <summary>
        /// Specifies a Cassandra table column.
        /// </summary>
        /// <param name="column">The Cassandra column.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithColumn(Models.Column column);

        /// <summary>
        /// Specifies a Cassandra table column.
        /// </summary>
        /// <param name="name">The name of the Cassandra table column.</param>
        /// <param name="type">The type of the Cassandra table column</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithColumn(string name, string type);

        /// <summary>
        /// Removes a Cassandra table column.
        /// </summary>
        /// <param name="name">The name of the Cassandra table column.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutColumn(string name);

        /// <summary>
        /// Appends all columns.
        /// </summary>
        /// <param name="columns">The list of the Cassandra table column.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithColumnsAppend(IList<Models.Column> columns);

        /// <summary>
        /// Replaces the columns.
        /// </summary>
        /// <param name="columns">The list of the Cassandra table column.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithColumnsReplace(IList<Models.Column> columns);

        /// <summary>
        /// Removes all columns.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutColumns();
    }

    /// <summary>
    /// The stage of a Cassandra table update allowing to set partition keys.
    /// </summary>
    public interface IWithPartitionKey
    {
        /// <summary>
        /// Specifies a Cassandra table partition key.
        /// </summary>
        /// <param name="partitionKey">The Cassandra table partition key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithPartitionKey(Models.CassandraPartitionKey partitionKey);

        /// <summary>
        /// Specifies a Cassandra partition key.
        /// </summary>
        /// <param name="name">The name of the Cassandra partition key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithPartitionKey(string name);

        /// <summary>
        /// Removes a Cassandra partition key.
        /// </summary>
        /// <param name="name">The name of the Cassandra partition key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutPartitionKey(string name);

        /// <summary>
        /// Appends all partition keys.
        /// </summary>
        /// <param name="partitionKeys">The list of the Cassandra table partition key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithPartitionKeysAppend(IList<Models.CassandraPartitionKey> partitionKeys);

        /// <summary>
        /// Replaces the partition keys.
        /// </summary>
        /// <param name="partitionKeys">The list of the Cassandra table partition key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithPartitionKeysReplace(IList<Models.CassandraPartitionKey> partitionKeys);

        /// <summary>
        /// Removes all partition keys.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutPartitionKeys();
    }

    /// <summary>
    /// The stage of a Cassandra table update allowing to specify cluster keys.
    /// </summary>
    public interface IWithClusterKey
    {
        /// <summary>
        /// Specifies a Cassandra table cluster key.
        /// </summary>
        /// <param name="clusterKey">The Cassandra table cluster key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithClusterKey(Models.ClusterKey clusterKey);

        /// <summary>
        /// Specifies a Cassandra cluster key.
        /// </summary>
        /// <param name="name">The name of the Cassandra cluster key.</param>
        /// <param name="orderBy">The order of the Cassandra cluster key. Only support "Asc" and "Desc" in api-version 2019-08-01.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithClusterKey(string name, string orderBy);

        /// <summary>
        /// Removes a Cassandra cluster key.
        /// </summary>
        /// <param name="name">The name of the Cassandra cluster key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutClusterKey(string name);

        /// <summary>
        /// Appends all cluster keys.
        /// </summary>
        /// <param name="clusterKeys">The list of the Cassandra table cluster key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithClusterKeysAppend(IList<Models.ClusterKey> clusterKeys);

        /// <summary>
        /// Replaces the cluster keys.
        /// </summary>
        /// <param name="clusterKeys">The list of the Cassandra table cluster key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithClusterKeysReplace(IList<Models.ClusterKey> clusterKeys);

        /// <summary>
        /// Removes all cluster keys.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutClusterKeys();
    }
}
