// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.CassandraKeyspace.Update
{
    /// <summary>
    /// The entirety of Cassandra Keyspace update as a part of parent cosmos db account update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IUpdate>,
        IWithOptions,
        IWithThroughput,
        IWithChildResource
    {
    }

    /// <summary>
    /// The stage of the Cassandra Keyspace update allowing to set options.
    /// </summary>
    public interface IWithOptions :
        HasOptions.Update.IWithOptions<IUpdate>
    {
    }

    /// <summary>
    /// The stage of the Cassandra Keyspace update allowing to set throughput.
    /// </summary>
    public interface IWithThroughput :
        HasThroughputSettings.Update.IWithThroughput<IUpdate>
    {
    }

    /// <summary>
    /// The stage of the Cassandra Keyspace update allowing to set child resources.
    /// </summary>
    public interface IWithChildResource
    {
        /// <summary>
        /// Defines a new Cassandra table.
        /// </summary>
        /// <param name="name">The name of Cassandra table.</param>
        /// <returns>The next stage of the update.</returns>
        CassandraTable.Definition.IBlank<IUpdate> DefineNewCassandraTable(string name);

        /// <summary>
        /// Updates a Cassandra table.
        /// </summary>
        /// <param name="name">The name of the Cassandra table.</param>
        /// <returns>The next stage of the update.</returns>
        CassandraTable.Update.IUpdate UpdateCassandraTable(string name);

        /// <summary>
        /// Removes a Cassandra table.
        /// </summary>
        /// <param name="name">The name of the Cassandra table.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutCassandraTable(string name);
    }
}
