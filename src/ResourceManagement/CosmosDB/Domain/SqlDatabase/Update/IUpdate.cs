// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.SqlDatabase.Update
{
    /// <summary>
    /// The entirety of SQL database update as a part of parent cosmos db account update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IUpdate>,
        IWithOptions,
        IWithThroughput,
        IWithChildResource
    {
    }

    /// <summary>
    /// The stage of the SQL database update allowing to set options.
    /// </summary>
    public interface IWithOptions :
        HasOptions.Update.IWithOptions<IUpdate>
    {
    }

    /// <summary>
    /// The stage of the SQL database update allowing to set throughput.
    /// </summary>
    public interface IWithThroughput :
        HasThroughputSettings.Update.IWithThroughput<IUpdate>
    {
    }

    /// <summary>
    /// The stage of the SQL database update allowing to set child resources.
    /// </summary>
    public interface IWithChildResource
    {
        /// <summary>
        /// Defines a new SQL container.
        /// </summary>
        /// <param name="name">The name of SQL container.</param>
        /// <returns>The next stage of the update.</returns>
        SqlContainer.Definition.IBlank<IUpdate> DefineNewSqlContainer(string name);

        /// <summary>
        /// Updates a SQL container.
        /// </summary>
        /// <param name="name">The name of the SQL container.</param>
        /// <returns>The next stage of the update.</returns>
        SqlContainer.Update.IUpdate UpdateSqlContainer(string name);

        /// <summary>
        /// Removes a SQL container.
        /// </summary>
        /// <param name="name">The name of the SQL container.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutSqlContainer(string name);
    }
}
