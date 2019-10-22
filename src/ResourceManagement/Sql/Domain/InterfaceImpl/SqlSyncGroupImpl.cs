// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.SqlSyncGroupOperationsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.SqlSyncMemberActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    internal partial class SqlSyncGroupImpl 
    {
        /// <summary>
        /// Sets the conflict resolution policy to "HubWin".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroupOperations.Definition.IWithCreate SqlSyncGroupOperations.Definition.IWithConflictResolutionPolicy.WithConflictResolutionPolicyHubWins()
        {
            return this.WithConflictResolutionPolicyHubWins();
        }

        /// <summary>
        /// Sets the conflict resolution policy to "MemberWin".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroupOperations.Definition.IWithCreate SqlSyncGroupOperations.Definition.IWithConflictResolutionPolicy.WithConflictResolutionPolicyMemberWins()
        {
            return this.WithConflictResolutionPolicyMemberWins();
        }

        /// <summary>
        /// Sets the conflict resolution policy to "HubWin".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroup.Update.IUpdate SqlSyncGroup.Update.IWithConflictResolutionPolicy.WithConflictResolutionPolicyHubWins()
        {
            return this.WithConflictResolutionPolicyHubWins();
        }

        /// <summary>
        /// Sets the conflict resolution policy to "MemberWin".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroup.Update.IUpdate SqlSyncGroup.Update.IWithConflictResolutionPolicy.WithConflictResolutionPolicyMemberWins()
        {
            return this.WithConflictResolutionPolicyMemberWins();
        }

        /// <summary>
        /// Sets the schema.
        /// </summary>
        /// <param name="schema">The schema object to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroupOperations.Definition.IWithCreate SqlSyncGroupOperations.Definition.IWithSchema.WithSchema(SyncGroupSchema schema)
        {
            return this.WithSchema(schema);
        }

        /// <summary>
        /// Sets the schema.
        /// </summary>
        /// <param name="schema">The schema object to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroup.Update.IUpdate SqlSyncGroup.Update.IWithSchema.WithSchema(SyncGroupSchema schema)
        {
            return this.WithSchema(schema);
        }

        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroupOperations.Definition.IWithSyncGroupDatabase SqlSyncGroupOperations.Definition.IWithSqlServer.WithExistingSqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.WithExistingSqlServer(resourceGroupName, sqlServerName);
        }

        /// <summary>
        /// Sets the parent SQL server for the new Sync Group.
        /// </summary>
        /// <param name="sqlDatabase">The parent SQL database.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroupOperations.Definition.IWithSyncDatabaseId SqlSyncGroupOperations.Definition.IWithSqlServer.WithExistingSqlDatabase(ISqlDatabase sqlDatabase)
        {
            return this.WithExistingSqlDatabase(sqlDatabase);
        }

        /// <summary>
        /// Sets the sync frequency.
        /// </summary>
        /// <param name="interval">The sync frequency; set to -1 for manual sync.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroupOperations.Definition.IWithCreate SqlSyncGroupOperations.Definition.IWithInterval.WithInterval(int interval)
        {
            return this.WithInterval(interval);
        }

        /// <summary>
        /// Sets the sync frequency.
        /// </summary>
        /// <param name="interval">The sync frequency; set to -1 for manual sync.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroup.Update.IUpdate SqlSyncGroup.Update.IWithInterval.WithInterval(int interval)
        {
            return this.WithInterval(interval);
        }

        /// <summary>
        /// Gets last sync time of the sync group.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.LastSyncTime
        {
            get
            {
                return this.LastSyncTime();
            }
        }

        /// <summary>
        /// Gets the parent SQL Database ID.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.ParentId
        {
            get
            {
                return this.ParentId();
            }
        }

        /// <summary>
        /// Gets sync interval of the sync group.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.Interval
        {
            get
            {
                return this.Interval();
            }
        }

        /// <summary>
        /// Refreshes a hub database schema.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.RefreshHubSchema()
        {
 
            this.RefreshHubSchema();
        }

        /// <summary>
        /// Gets user name for the sync group hub database credential.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.DatabaseUserName
        {
            get
            {
                return this.DatabaseUserName();
            }
        }

        /// <summary>
        /// Cancels a sync group synchronization.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.CancelSynchronization()
        {
 
            this.CancelSynchronization();
        }

        /// <summary>
        /// Refreshes a hub database schema asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.RefreshHubSchemaAsync(CancellationToken cancellationToken)
        {
 
            await this.RefreshHubSchemaAsync(cancellationToken);
        }

        /// <summary>
        /// Gets name of the SQL Server to which this Sync Group belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Gets conflict resolution policy of the sync group.
        /// </summary>
        Models.SyncConflictResolutionPolicy Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.ConflictResolutionPolicy
        {
            get
            {
                return this.ConflictResolutionPolicy();
            }
        }

        /// <summary>
        /// Gets a collection of hub database schemas.
        /// </summary>
        /// <return>The paged list of SyncFullSchemaProperty objects if successful.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncFullSchemaProperty> Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.ListHubSchemas()
        {
            return this.ListHubSchemas();
        }

        /// <summary>
        /// Deletes the SQL Sync Group resource asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.DeleteAsync(CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(cancellationToken);
        }

        /// <summary>
        /// Triggers a sync group synchronization.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.TriggerSynchronization()
        {
 
            this.TriggerSynchronization();
        }

        /// <return>The SQL Sync Member entry point.</return>
        SqlSyncMemberOperations.SqlSyncMemberActionsDefinition.ISqlSyncMemberActionsDefinition Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.SyncMembers
        {
            get
            {
                return this.SyncMembers();
            }
        }

        /// <summary>
        /// Gets sync state of the sync group.
        /// </summary>
        Models.SyncGroupState Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.SyncState
        {
            get
            {
                return this.SyncState();
            }
        }

        /// <summary>
        /// Gets the ARM resource id of the sync database in the sync group.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.SyncDatabaseId
        {
            get
            {
                return this.SyncDatabaseId();
            }
        }

        /// <summary>
        /// Gets name of the SQL Database to which this Sync Group belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.SqlDatabaseName
        {
            get
            {
                return this.SqlDatabaseName();
            }
        }

        /// <summary>
        /// Gets sync schema of the sync group.
        /// </summary>
        Models.SyncGroupSchema Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.Schema
        {
            get
            {
                return this.Schema();
            }
        }

        /// <summary>
        /// Deletes the Sync Group resource.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.Delete()
        {
 
            this.Delete();
        }

        /// <summary>
        /// Gets a collection of hub database schemas asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncFullSchemaProperty>> Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.ListHubSchemasAsync(CancellationToken cancellationToken)
        {
            return await this.ListHubSchemasAsync(cancellationToken);
        }

        /// <summary>
        /// Gets a collection of sync group logs asynchronously.
        /// </summary>
        /// <param name="startTime">Get logs generated after this time.</param>
        /// <param name="endTime">Get logs generated before this time.</param>
        /// <param name="type">The types of logs to retrieve.</param>
        /// <return>A representation of the deferred computation of this call returning the group log property objects if successful.</return>
        async Task<IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupLogProperty>> Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.ListLogsAsync(string startTime, string endTime, Models.Type type, CancellationToken cancellationToken)
        {
            return await this.ListLogsAsync(startTime, endTime, type, cancellationToken);
        }

        /// <summary>
        /// Triggers a sync group synchronization.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.TriggerSynchronizationAsync(CancellationToken cancellationToken)
        {
 
            await this.TriggerSynchronizationAsync(cancellationToken);
        }

        /// <summary>
        /// Gets a collection of sync group logs.
        /// </summary>
        /// <param name="startTime">Get logs generated after this time.</param>
        /// <param name="endTime">Get logs generated before this time.</param>
        /// <param name="type">The types of logs to retrieve.</param>
        /// <return>The paged list containing the group log property objects if successful.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupLogProperty> Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.ListLogs(string startTime, string endTime, Models.Type type)
        {
            return this.ListLogs(startTime, endTime, type);
        }

        /// <summary>
        /// Cancels a sync group synchronization asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup.CancelSynchronizationAsync(CancellationToken cancellationToken)
        {
 
            await this.CancelSynchronizationAsync(cancellationToken);
        }

        /// <summary>
        /// Sets the name of the database on which the sync group is hosted.
        /// </summary>
        /// <param name="databaseName">The name of the database on which the sync group is hosted.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroupOperations.Definition.IWithSyncDatabaseId SqlSyncGroupOperations.Definition.IWithSyncGroupDatabase.WithExistingDatabaseName(string databaseName)
        {
            return this.WithExistingDatabaseName(databaseName);
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        SqlSyncGroup.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlSyncGroup.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Sets the database user name.
        /// </summary>
        /// <param name="userName">The database user name.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroupOperations.Definition.IWithDatabasePassword SqlSyncGroupOperations.Definition.IWithDatabaseUserName.WithDatabaseUserName(string userName)
        {
            return this.WithDatabaseUserName(userName);
        }

        /// <summary>
        /// Sets the database user name.
        /// </summary>
        /// <param name="userName">The database user name.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroup.Update.IUpdate SqlSyncGroup.Update.IWithDatabaseUserName.WithDatabaseUserName(string userName)
        {
            return this.WithDatabaseUserName(userName);
        }

        /// <summary>
        /// Sets the sync database ID.
        /// </summary>
        /// <param name="syncDatabaseId">The sync database ID value to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroupOperations.Definition.IWithDatabaseUserName SqlSyncGroupOperations.Definition.IWithSyncDatabaseId.WithSyncDatabaseId(string syncDatabaseId)
        {
            return this.WithSyncDatabaseId(syncDatabaseId);
        }

        /// <summary>
        /// Sets the sync database ID.
        /// </summary>
        /// <param name="databaseId">The sync database ID value to set.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroup.Update.IUpdate SqlSyncGroup.Update.IWithSyncDatabaseId.WithSyncDatabaseId(string databaseId)
        {
            return this.WithSyncDatabaseId(databaseId);
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
        /// Sets the database login password.
        /// </summary>
        /// <param name="password">The database login password.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroupOperations.Definition.IWithConflictResolutionPolicy SqlSyncGroupOperations.Definition.IWithDatabasePassword.WithDatabasePassword(string password)
        {
            return this.WithDatabasePassword(password);
        }

        /// <summary>
        /// Sets the database login password.
        /// </summary>
        /// <param name="password">The database login password.</param>
        /// <return>The next stage of the definition.</return>
        SqlSyncGroup.Update.IUpdate SqlSyncGroup.Update.IWithDatabasePassword.WithDatabasePassword(string password)
        {
            return this.WithDatabasePassword(password);
        }
    }
}