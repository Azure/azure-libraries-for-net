// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.GremlinDatabase.Update
{
    /// <summary>
    /// The entirety of Gremlin Database update as a part of parent cosmos db account update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IUpdate>,
        IWithOptions,
        IWithThroughput,
        IWithChildResource
    {
    }

    /// <summary>
    /// The stage of the Gremlin Database update allowing to set options.
    /// </summary>
    public interface IWithOptions :
        HasOptions.Update.IWithOptions<IUpdate>
    {
    }

    /// <summary>
    /// The stage of the Gremlin Database update allowing to set throughput.
    /// </summary>
    public interface IWithThroughput :
        HasThroughputSettings.Update.IWithThroughput<IUpdate>
    {
    }

    /// <summary>
    /// The stage of the Gremlin Database update allowing to set child resources.
    /// </summary>
    public interface IWithChildResource
    {
        /// <summary>
        /// Defines a new Gremlin Graph.
        /// </summary>
        /// <param name="name">The name of Gremlin Graph.</param>
        /// <returns>The next stage of the update.</returns>
        GremlinGraph.Definition.IBlank<IUpdate> DefineNewGremlinGraph(string name);

        /// <summary>
        /// Updates a Gremlin Graph.
        /// </summary>
        /// <param name="name">The name of the Gremlin Graph.</param>
        /// <returns>The next stage of the update.</returns>
        GremlinGraph.Update.IUpdate UpdateGremlinGraph(string name);

        /// <summary>
        /// Removes a Gremlin Graph.
        /// </summary>
        /// <param name="name">The name of the Gremlin Graph.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutGremlinGraph(string name);
    }
}
