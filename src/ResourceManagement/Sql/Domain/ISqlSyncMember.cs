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
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Server Sync Member.
    /// </summary>
    public interface ISqlSyncMember  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember,Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SyncMemberInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlSyncMember.Update.IUpdate>
    {
        /// <summary>
        /// Gets the SQL Database id of the sync member.
        /// </summary>
        string SqlServerDatabaseId { get; }

        /// <summary>
        /// Gets the SQL Server name of the member database in the sync member.
        /// </summary>
        string MemberServerName { get; }

        /// <summary>
        /// Gets Database name of the member database in the sync member.
        /// </summary>
        string MemberDatabaseName { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this Sync Member belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets the sync state of the sync member.
        /// </summary>
        Models.SyncMemberState SyncState { get; }

        /// <summary>
        /// Lists the sync member database schemas asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task<IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncFullSchemaProperty>> ListMemberSchemasAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the SQL Member resource asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the user name of the member database in the sync member.
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// Deletes the Sync Member resource.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets the parent SQL Sync Group ID.
        /// </summary>
        string ParentId { get; }

        /// <summary>
        /// Gets the ARM resource id of the sync agent in the sync member.
        /// </summary>
        string SyncAgentId { get; }

        /// <summary>
        /// Gets the Database type of the sync member.
        /// </summary>
        Models.SyncMemberDbType DatabaseType { get; }

        /// <summary>
        /// Gets the sync direction of the sync member.
        /// </summary>
        Models.SyncDirection SyncDirection { get; }

        /// <summary>
        /// Lists the sync member database schemas.
        /// </summary>
        /// <return>The paged list object if successful.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncFullSchemaProperty> ListMemberSchemas();

        /// <summary>
        /// Refreshes a sync member database schema.
        /// </summary>
        void RefreshMemberSchema();

        /// <summary>
        /// Refreshes a sync member database schema asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RefreshMemberSchemaAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets name of the SQL Sync Group to which this Sync Member belongs.
        /// </summary>
        string SqlSyncGroupName { get; }

        /// <summary>
        /// Gets name of the SQL Database to which this Sync Member belongs.
        /// </summary>
        string SqlDatabaseName { get; }
    }
}