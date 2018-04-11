// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition
{
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// The first stage of the SQL Sync Member definition.
    /// </summary>
    public interface IWithSqlServer  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the parent SQL server for the new Sync Member.
        /// </summary>
        /// <param name="sqlSyncGroup">The parent SQL Sync Group.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithMemberSqlServer WithExistingSyncGroup(ISqlSyncGroup sqlSyncGroup);

        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithSyncMemberDatabase WithExistingSqlServer(string resourceGroupName, string sqlServerName);
    }

    /// <summary>
    /// The SQL Sync Member definition to set the member database.
    /// </summary>
    public interface IWithMemberSqlDatabase  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the member SQL Database name.
        /// </summary>
        /// <param name="sqlDatabaseName">The member SQL Database name value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithMemberUserName WithMemberSqlDatabaseName(string sqlDatabaseName);
    }

    /// <summary>
    /// The final stage of the SQL Sync Member definition.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember>
    {
    }

    /// <summary>
    /// The SQL Sync Member definition to set the member database user name.
    /// </summary>
    public interface IWithMemberUserName  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the member SQL Database username.
        /// </summary>
        /// <param name="userName">The member SQL Database username value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithMemberPassword WithMemberUserName(string userName);
    }

    /// <summary>
    /// The SQL Sync Member definition to set the parent database name.
    /// </summary>
    public interface IWithSyncGroupName  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the name of the database on which the sync Member is hosted.
        /// </summary>
        /// <param name="syncGroupName">The name of the sync group on which the Sync Member is hosted.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithMemberSqlServer WithExistingSyncGroupName(string syncGroupName);
    }

    /// <summary>
    /// The SQL Sync Member definition to set the member database password.
    /// </summary>
    public interface IWithMemberPassword  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the member SQL Database password.
        /// </summary>
        /// <param name="password">The member SQL Database password value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithMemberDatabaseType WithMemberPassword(string password);
    }

    /// <summary>
    /// The SQL Sync Member definition to set the sync direction.
    /// </summary>
    public interface IWithSyncDirection  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the sync direction.
        /// </summary>
        /// <param name="syncDirection">The sync direction value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithCreate WithDatabaseType(SyncDirection syncDirection);
    }

    /// <summary>
    /// The SQL Sync Member definition to set the member server and database.
    /// </summary>
    public interface IWithMemberSqlServer  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the member SQL server name.
        /// </summary>
        /// <param name="sqlServerName">The member SQL server name value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithMemberSqlDatabase WithMemberSqlServerName(string sqlServerName);

        /// <summary>
        /// Sets the member SQL Database.
        /// </summary>
        /// <param name="sqlDatabase">The member SQL Database value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithMemberUserName WithMemberSqlDatabase(ISqlDatabase sqlDatabase);
    }

    /// <summary>
    /// The SQL Sync Member definition to set the database type.
    /// </summary>
    public interface IWithMemberDatabaseType  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the member database type.
        /// </summary>
        /// <param name="databaseType">The database type value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithSyncDirection WithMemberDatabaseType(SyncMemberDbType databaseType);
    }

    /// <summary>
    /// The SQL Sync Member definition to set the parent database name.
    /// </summary>
    public interface IWithSyncMemberDatabase  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the name of the database on which the sync Member is hosted.
        /// </summary>
        /// <param name="databaseName">The name of the database on which the sync Member is hosted.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithSyncGroupName WithExistingDatabaseName(string databaseName);
    }
}