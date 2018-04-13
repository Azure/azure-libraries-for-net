// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// The template for a SQL Sync Group update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update.IWithSyncDatabaseId,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update.IWithDatabaseUserName,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update.IWithDatabasePassword,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update.IWithConflictResolutionPolicy,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update.IWithInterval,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update.IWithSchema,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>
    {
    }

    /// <summary>
    /// The SQL Sync Group definition to set the conflict resolution policy.
    /// </summary>
    public interface IWithConflictResolutionPolicy  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the conflict resolution policy to "HubWin".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update.IUpdate WithConflictResolutionPolicyHubWins();

        /// <summary>
        /// Sets the conflict resolution policy to "MemberWin".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update.IUpdate WithConflictResolutionPolicyMemberWins();
    }

    /// <summary>
    /// The SQL Sync Group definition to set the database ID to sync with.
    /// </summary>
    public interface IWithSyncDatabaseId  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the sync database ID.
        /// </summary>
        /// <param name="databaseId">The sync database ID value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update.IUpdate WithSyncDatabaseId(string databaseId);
    }

    /// <summary>
    /// The SQL Sync Group definition to set the database login password.
    /// </summary>
    public interface IWithDatabasePassword  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the database login password.
        /// </summary>
        /// <param name="password">The database login password.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update.IUpdate WithDatabasePassword(string password);
    }

    /// <summary>
    /// The SQL Sync Group definition to set the sync frequency.
    /// </summary>
    public interface IWithInterval  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the sync frequency.
        /// </summary>
        /// <param name="interval">The sync frequency; set to -1 for manual sync.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update.IUpdate WithInterval(int interval);
    }

    /// <summary>
    /// The SQL Sync Group definition to set the schema.
    /// </summary>
    public interface IWithSchema  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the schema.
        /// </summary>
        /// <param name="schema">The schema object to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update.IUpdate WithSchema(SyncGroupSchema schema);
    }

    /// <summary>
    /// The SQL Sync Group definition to set the database user name.
    /// </summary>
    public interface IWithDatabaseUserName  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the database user name.
        /// </summary>
        /// <param name="userName">The database user name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update.IUpdate WithDatabaseUserName(string userName);
    }
}