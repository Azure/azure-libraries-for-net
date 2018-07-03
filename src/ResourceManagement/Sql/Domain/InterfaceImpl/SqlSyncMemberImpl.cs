// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMember.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.SqlSyncMemberOperationsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    internal partial class SqlSyncMemberImpl 
    {
        /// <summary>
        /// Sets the member SQL Database username.
        /// </summary>
        /// <param name="userName">The member SQL Database username value to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMember.Update.IUpdate SqlSyncMember.Update.IWithMemberUserName.WithMemberUserName(string userName)
        {
            return this.WithMemberUserName(userName);
        }

        /// <summary>
        /// Sets the member SQL Database username.
        /// </summary>
        /// <param name="userName">The member SQL Database username value to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMemberOperations.Definition.IWithMemberPassword SqlSyncMemberOperations.Definition.IWithMemberUserName.WithMemberUserName(string userName)
        {
            return this.WithMemberUserName(userName);
        }

        /// <summary>
        /// Gets the SQL Database id of the sync member.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.SqlServerDatabaseId
        {
            get
            {
                return this.SqlServerDatabaseId();
            }
        }

        /// <summary>
        /// Gets the parent SQL Sync Group ID.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.ParentId
        {
            get
            {
                return this.ParentId();
            }
        }

        /// <summary>
        /// Lists the sync member database schemas.
        /// </summary>
        /// <return>The paged list object if successful.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncFullSchemaProperty> Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.ListMemberSchemas()
        {
            return this.ListMemberSchemas();
        }

        /// <summary>
        /// Gets the Database type of the sync member.
        /// </summary>
        Models.SyncMemberDbType Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.DatabaseType
        {
            get
            {
                return this.DatabaseType();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this Sync Member belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Refreshes a sync member database schema asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.RefreshMemberSchemaAsync(CancellationToken cancellationToken)
        {
 
            await this.RefreshMemberSchemaAsync(cancellationToken);
        }

        /// <summary>
        /// Deletes the SQL Member resource asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.DeleteAsync(CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the SQL Server name of the member database in the sync member.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.MemberServerName
        {
            get
            {
                return this.MemberServerName();
            }
        }

        /// <summary>
        /// Gets the ARM resource id of the sync agent in the sync member.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.SyncAgentId
        {
            get
            {
                return this.SyncAgentId();
            }
        }

        /// <summary>
        /// Gets the user name of the member database in the sync member.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.UserName
        {
            get
            {
                return this.UserName();
            }
        }

        /// <summary>
        /// Gets the sync state of the sync member.
        /// </summary>
        Models.SyncMemberState Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.SyncState
        {
            get
            {
                return this.SyncState();
            }
        }

        /// <summary>
        /// Gets name of the SQL Database to which this Sync Member belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.SqlDatabaseName
        {
            get
            {
                return this.SqlDatabaseName();
            }
        }

        /// <summary>
        /// Deletes the Sync Member resource.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.Delete()
        {
 
            this.Delete();
        }

        /// <summary>
        /// Gets name of the SQL Sync Group to which this Sync Member belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.SqlSyncGroupName
        {
            get
            {
                return this.SqlSyncGroupName();
            }
        }

        /// <summary>
        /// Lists the sync member database schemas asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncFullSchemaProperty>> Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.ListMemberSchemasAsync(CancellationToken cancellationToken)
        {
            return await this.ListMemberSchemasAsync(cancellationToken);
        }

        /// <summary>
        /// Gets Database name of the member database in the sync member.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.MemberDatabaseName
        {
            get
            {
                return this.MemberDatabaseName();
            }
        }

        /// <summary>
        /// Refreshes a sync member database schema.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.RefreshMemberSchema()
        {
 
            this.RefreshMemberSchema();
        }

        /// <summary>
        /// Gets the sync direction of the sync member.
        /// </summary>
        Models.SyncDirection Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember.SyncDirection
        {
            get
            {
                return this.SyncDirection();
            }
        }

        /// <summary>
        /// Sets the member SQL Database password.
        /// </summary>
        /// <param name="password">The member SQL Database password value to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMember.Update.IUpdate SqlSyncMember.Update.IWithMemberPassword.WithMemberPassword(string password)
        {
            return this.WithMemberPassword(password);
        }

        /// <summary>
        /// Sets the member SQL Database password.
        /// </summary>
        /// <param name="password">The member SQL Database password value to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMemberOperations.Definition.IWithMemberDatabaseType SqlSyncMemberOperations.Definition.IWithMemberPassword.WithMemberPassword(string password)
        {
            return this.WithMemberPassword(password);
        }

        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMemberOperations.Definition.IWithSyncMemberDatabase SqlSyncMemberOperations.Definition.IWithSqlServer.WithExistingSqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.WithExistingSqlServer(resourceGroupName, sqlServerName);
        }

        /// <summary>
        /// Sets the parent SQL server for the new Sync Member.
        /// </summary>
        /// <param name="sqlSyncGroup">The parent SQL Sync Group.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMemberOperations.Definition.IWithMemberSqlServer SqlSyncMemberOperations.Definition.IWithSqlServer.WithExistingSyncGroup(ISqlSyncGroup sqlSyncGroup)
        {
            return this.WithExistingSyncGroup(sqlSyncGroup);
        }

        /// <summary>
        /// Sets the member SQL Database.
        /// </summary>
        /// <param name="sqlDatabase">The member SQL Database value to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMemberOperations.Definition.IWithMemberUserName SqlSyncMemberOperations.Definition.IWithMemberSqlServer.WithMemberSqlDatabase(ISqlDatabase sqlDatabase)
        {
            return this.WithMemberSqlDatabase(sqlDatabase);
        }

        /// <summary>
        /// Sets the member SQL server name.
        /// </summary>
        /// <param name="sqlServerName">The member SQL server name value to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMemberOperations.Definition.IWithMemberSqlDatabase SqlSyncMemberOperations.Definition.IWithMemberSqlServer.WithMemberSqlServerName(string sqlServerName)
        {
            return this.WithMemberSqlServerName(sqlServerName);
        }

        /// <summary>
        /// Sets the member SQL Database name.
        /// </summary>
        /// <param name="sqlDatabaseName">The member SQL Database name value to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMemberOperations.Definition.IWithMemberUserName SqlSyncMemberOperations.Definition.IWithMemberSqlDatabase.WithMemberSqlDatabaseName(string sqlDatabaseName)
        {
            return this.WithMemberSqlDatabaseName(sqlDatabaseName);
        }

        /// <summary>
        /// Sets the member database type.
        /// </summary>
        /// <param name="databaseType">The database type value to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMember.Update.IUpdate SqlSyncMember.Update.IWithMemberDatabaseType.WithMemberDatabaseType(SyncMemberDbType databaseType)
        {
            return this.WithMemberDatabaseType(databaseType);
        }

        /// <summary>
        /// Sets the member database type.
        /// </summary>
        /// <param name="databaseType">The database type value to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMemberOperations.Definition.IWithSyncDirection SqlSyncMemberOperations.Definition.IWithMemberDatabaseType.WithMemberDatabaseType(SyncMemberDbType databaseType)
        {
            return this.WithMemberDatabaseType(databaseType);
        }

        /// <summary>
        /// Sets the name of the database on which the sync Member is hosted.
        /// </summary>
        /// <param name="syncGroupName">The name of the sync group on which the Sync Member is hosted.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMemberOperations.Definition.IWithMemberSqlServer SqlSyncMemberOperations.Definition.IWithSyncGroupName.WithExistingSyncGroupName(string syncGroupName)
        {
            return this.WithExistingSyncGroupName(syncGroupName);
        }

        /// <summary>
        /// Sets the sync direction.
        /// </summary>
        /// <param name="syncDirection">The sync direction value to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMember.Update.IUpdate SqlSyncMember.Update.IWithSyncDirection.WithDatabaseType(SyncDirection syncDirection)
        {
            return this.WithDatabaseType(syncDirection);
        }

        /// <summary>
        /// Sets the sync direction.
        /// </summary>
        /// <param name="syncDirection">The sync direction value to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMemberOperations.Definition.IWithCreate SqlSyncMemberOperations.Definition.IWithSyncDirection.WithDatabaseType(SyncDirection syncDirection)
        {
            return this.WithDatabaseType(syncDirection);
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        SqlSyncMember.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlSyncMember.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Sets the name of the database on which the sync Member is hosted.
        /// </summary>
        /// <param name="databaseName">The name of the database on which the sync Member is hosted.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncMemberOperations.Definition.IWithSyncGroupName SqlSyncMemberOperations.Definition.IWithSyncMemberDatabase.WithExistingDatabaseName(string databaseName)
        {
            return this.WithExistingDatabaseName(databaseName);
        }
    }
}