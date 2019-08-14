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
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.SqlSyncMemberActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Server Sync Group.
    /// </summary>
    public interface ISqlSyncGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup,Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SyncGroupInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlSyncGroup.Update.IUpdate>
    {
        /// <summary>
        /// Gets sync schema of the sync group.
        /// </summary>
        Models.SyncGroupSchema Schema { get; }

        /// <summary>
        /// Triggers a sync group synchronization.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task TriggerSynchronizationAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets last sync time of the sync group.
        /// </summary>
        System.DateTime? LastSyncTime { get; }

        /// <summary>
        /// Gets the ARM resource id of the sync database in the sync group.
        /// </summary>
        string SyncDatabaseId { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this Sync Group belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets sync state of the sync group.
        /// </summary>
        Models.SyncGroupState SyncState { get; }

        /// <summary>
        /// Gets a collection of hub database schemas.
        /// </summary>
        /// <return>The paged list of SyncFullSchemaProperty objects if successful.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncFullSchemaProperty> ListHubSchemas();

        /// <return>The SQL Sync Member entry point.</return>
        SqlSyncMemberOperations.SqlSyncMemberActionsDefinition.ISqlSyncMemberActionsDefinition SyncMembers { get; }

        /// <summary>
        /// Deletes the SQL Sync Group resource asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Refreshes a hub database schema asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RefreshHubSchemaAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a collection of sync group logs asynchronously.
        /// </summary>
        /// <param name="startTime">Get logs generated after this time.</param>
        /// <param name="endTime">Get logs generated before this time.</param>
        /// <param name="type">The types of logs to retrieve.</param>
        /// <return>A representation of the deferred computation of this call returning the group log property objects if successful.</return>
        Task<IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupLogProperty>> ListLogsAsync(string startTime, string endTime, Models.Type type, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets conflict resolution policy of the sync group.
        /// </summary>
        Models.SyncConflictResolutionPolicy ConflictResolutionPolicy { get; }

        /// <summary>
        /// Deletes the Sync Group resource.
        /// </summary>
        void Delete();

        /// <summary>
        /// Refreshes a hub database schema.
        /// </summary>
        void RefreshHubSchema();

        /// <summary>
        /// Gets the parent SQL Database ID.
        /// </summary>
        string ParentId { get; }

        /// <summary>
        /// Gets user name for the sync group hub database credential.
        /// </summary>
        string DatabaseUserName { get; }

        /// <summary>
        /// Cancels a sync group synchronization.
        /// </summary>
        void CancelSynchronization();

        /// <summary>
        /// Triggers a sync group synchronization.
        /// </summary>
        void TriggerSynchronization();

        /// <summary>
        /// Gets sync interval of the sync group.
        /// </summary>
        int Interval { get; }

        /// <summary>
        /// Gets a collection of hub database schemas asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task<IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncFullSchemaProperty>> ListHubSchemasAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a collection of sync group logs.
        /// </summary>
        /// <param name="startTime">Get logs generated after this time.</param>
        /// <param name="endTime">Get logs generated before this time.</param>
        /// <param name="type">The types of logs to retrieve.</param>
        /// <return>The paged list containing the group log property objects if successful.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupLogProperty> ListLogs(string startTime, string endTime, Models.Type type);

        /// <summary>
        /// Gets name of the SQL Database to which this Sync Group belongs.
        /// </summary>
        string SqlDatabaseName { get; }

        /// <summary>
        /// Cancels a sync group synchronization asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task CancelSynchronizationAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}