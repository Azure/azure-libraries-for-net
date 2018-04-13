// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition
{
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

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
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithCreate WithInterval(int interval);
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
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithCreate WithSchema(SyncGroupSchema schema);
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
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithCreate WithConflictResolutionPolicyHubWins();

        /// <summary>
        /// Sets the conflict resolution policy to "MemberWin".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithCreate WithConflictResolutionPolicyMemberWins();
    }

    /// <summary>
    /// The final stage of the SQL Sync Group definition.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithInterval,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithSchema,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>
    {
    }

    /// <summary>
    /// The first stage of the SQL Sync Group definition.
    /// </summary>
    public interface IWithSqlServer  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithSyncGroupDatabase WithExistingSqlServer(string resourceGroupName, string sqlServerName);

        /// <summary>
        /// Sets the parent SQL server for the new Sync Group.
        /// </summary>
        /// <param name="sqlDatabase">The parent SQL database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithSyncDatabaseId WithExistingSqlDatabase(ISqlDatabase sqlDatabase);
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
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithDatabasePassword WithDatabaseUserName(string userName);
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
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithConflictResolutionPolicy WithDatabasePassword(string password);
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
        /// <param name="syncDatabaseId">The sync database ID value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithDatabaseUserName WithSyncDatabaseId(string syncDatabaseId);
    }

    /// <summary>
    /// The SQL Sync Group definition to set the parent database name.
    /// </summary>
    public interface IWithSyncGroupDatabase  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the name of the database on which the sync group is hosted.
        /// </summary>
        /// <param name="databaseName">The name of the database on which the sync group is hosted.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithSyncDatabaseId WithExistingDatabaseName(string databaseName);
    }
}