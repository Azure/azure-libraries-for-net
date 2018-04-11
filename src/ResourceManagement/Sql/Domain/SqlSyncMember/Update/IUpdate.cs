// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlSyncMember.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// The template for a SQL Sync Group update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMember.Update.IWithMemberUserName,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMember.Update.IWithMemberPassword,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMember.Update.IWithMemberDatabaseType,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMember.Update.IWithSyncDirection,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember>
    {
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
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMember.Update.IUpdate WithMemberDatabaseType(SyncMemberDbType databaseType);
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
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMember.Update.IUpdate WithDatabaseType(SyncDirection syncDirection);
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
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMember.Update.IUpdate WithMemberUserName(string userName);
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
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMember.Update.IUpdate WithMemberPassword(string password);
    }
}