// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Failover Group.
    /// </summary>
    public interface ISqlFailoverGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.FailoverGroupInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlFailoverGroup.Update.IUpdate>
    {
        /// <summary>
        /// Gets the failover policy of the read-write endpoint for the failover group.
        /// </summary>
        Models.ReadWriteEndpointFailoverPolicy ReadWriteEndpointPolicy { get; }

        /// <summary>
        /// Gets the local replication role of the failover group instance.
        /// </summary>
        Models.FailoverGroupReplicationRole ReplicationRole { get; }

        /// <summary>
        /// Gets the replication state of the failover group instance.
        /// </summary>
        string ReplicationState { get; }

        /// <summary>
        /// Gets the list of database IDs in the failover group.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Databases { get; }

        /// <summary>
        /// Gets the list of partner server information for the failover group.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.PartnerInfo> PartnerServers { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this Failover Group belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets the failover policy of the read-only endpoint for the failover group.
        /// </summary>
        Models.ReadOnlyEndpointFailoverPolicy ReadOnlyEndpointPolicy { get; }

        /// <summary>
        /// Deletes the Failover Group asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the grace period before failover with data loss is attempted for the read-write endpoint.
        /// </summary>
        int ReadWriteEndpointDataLossGracePeriodMinutes { get; }

        /// <summary>
        /// Deletes the Failover Group.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string ParentId { get; }
    }
}