// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.CassandraTable.Definition
{
    using System.Collections.Generic;

    /// <summary>
    /// The entirety of a Cassandra table definition as a part of parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT> :
        IBlank<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a Cassandra table definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the Cassandra table definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        IWithOptions<ParentT>,
        IWithThroughput<ParentT>,
        IWithDefaultTtl<ParentT>,
        IWithColumn<ParentT>,
        IWithPartitionKey<ParentT>,
        IWithClusterKey<ParentT>
    {
    }

    /// <summary>
    /// The stage of a Cassandra table definition allowing to set options.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithOptions<ParentT> :
        HasOptions.Definition.IWithOptions<IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// The stage of a Cassandra table definition allowing to set throughput.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithThroughput<ParentT> :
        HasThroughputSettings.Definition.IWithThroughput<IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// The stage of a Cassandra table definition allowing to set default ttl.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDefaultTtl<ParentT>
    {
        /// <summary>
        /// Specifies the default time to live.
        /// </summary>
        /// <param name="ttl">The default time to live.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithDefaultTtl(int ttl);
    }

    /// <summary>
    /// The stage of a Cassandra table definition allowing to set Cassandra table columns.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithColumn<ParentT>
    {
        /// <summary>
        /// Specifies a Cassandra table column.
        /// </summary>
        /// <param name="column">The Cassandra column.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithColumn(Models.Column column);

        /// <summary>
        /// Specifies a Cassandra table column.
        /// </summary>
        /// <param name="name">The name of the Cassandra table column.</param>
        /// <param name="type">The type of the Cassandra table column</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithColumn(string name, string type);

        /// <summary>
        /// Appends all columns.
        /// </summary>
        /// <param name="columns">The list of the Cassandra table column.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithColumns(IList<Models.Column> columns);
    }

    /// <summary>
    /// The stage of a Cassandra table definition allowing to set partition keys.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPartitionKey<ParentT>
    {
        /// <summary>
        /// Specifies a Cassandra table partition key.
        /// </summary>
        /// <param name="partitionKey">The Cassandra table partition key.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithPartitionKey(Models.CassandraPartitionKey partitionKey);

        /// <summary>
        /// Specifies a Cassandra partition key.
        /// </summary>
        /// <param name="name">The name of the Cassandra partition key.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithPartitionKey(string name);

        /// <summary>
        /// Appends all partition keys.
        /// </summary>
        /// <param name="partitionKeys">The list of the Cassandra table partition key.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithPartitionKeys(IList<Models.CassandraPartitionKey> partitionKeys);
    }

    /// <summary>
    /// The stage of a Cassandra table definition allowing to specify cluster keys.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithClusterKey<ParentT>
    {
        /// <summary>
        /// Specifies a Cassandra table cluster key.
        /// </summary>
        /// <param name="clusterKey">The Cassandra table cluster key.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithClusterKey(Models.ClusterKey clusterKey);

        /// <summary>
        /// Specifies a Cassandra cluster key.
        /// </summary>
        /// <param name="name">The name of the Cassandra cluster key.</param>
        /// <param name="orderBy">The order of the Cassandra cluster key. Only support "Asc" and "Desc" in api-version 2019-08-01.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithClusterKey(string name, string orderBy);

        /// <summary>
        /// Appends all cluster keys.
        /// </summary>
        /// <param name="clusterKeys">The list of the Cassandra table cluster key.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithClusterKeys(IList<Models.ClusterKey> clusterKeys);
    }
}
