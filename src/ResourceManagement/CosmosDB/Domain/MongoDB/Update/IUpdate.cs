// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.MongoDB.Update
{
    /// <summary>
    /// The entirety of mongo database update as a part of parent cosmos db account update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IUpdate>,
        IWithOptions,
        IWithThroughput,
        IWithChildResource
    {
    }

    /// <summary>
    /// The stage of the mongo database update allowing to set options.
    /// </summary>
    public interface IWithOptions :
        HasOptions.Update.IWithOptions<IUpdate>
    {
    }

    /// <summary>
    /// The stage of the mongo database update allowing to set throughput.
    /// </summary>
    public interface IWithThroughput :
        HasThroughputSettings.Update.IWithThroughput<IUpdate>
    {
    }

    /// <summary>
    /// The stage of the mongo database update allowing to set child resources.
    /// </summary>
    public interface IWithChildResource
    {
        /// <summary>
        /// Defines a new mongo collection.
        /// </summary>
        /// <param name="name">The name of the mongo collection.</param>
        /// <returns>The next stage of the definition.</returns>
        MongoCollection.Definition.IBlank<IUpdate> DefineNewCollection(string name);

        /// <summary>
        /// Updates a mongo collection.
        /// </summary>
        /// <param name="name">The name of the mongo collection.</param>
        /// <returns>The next stage of the update.</returns>
        MongoCollection.Update.IUpdate UpdateCollection(string name);

        /// <summary>
        /// Removes a mongo collection.
        /// </summary>
        /// <param name="name">The name of the mongo v.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutCollection(string name);
    }
}
