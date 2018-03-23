// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition;

    /// <summary>
    /// A representation of the Azure SQL Failover Group operations.
    /// </summary>
    public interface ISqlFailoverGroupOperations  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SqlFailoverGroupOperations.Definition.IWithSqlServer>,
        Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>
    {
        /// <summary>
        /// Fails over from the current primary server to this server. This operation might result in data loss.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group that contains the resource.</param>
        /// <param name="serverName">The name of the server containing the failover group.</param>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>The SqlFailoverGroup object.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup ForceFailoverAllowDataLoss(string resourceGroupName, string serverName, string failoverGroupName);

        /// <summary>
        /// Fails over from the current primary server to this server.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group that contains the resource.</param>
        /// <param name="serverName">The name of the server containing the failover group.</param>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>The SqlFailoverGroup object.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup Failover(string resourceGroupName, string serverName, string failoverGroupName);

        /// <summary>
        /// Fails over from the current primary server to this server. This operation might result in data loss.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group that contains the resource.</param>
        /// <param name="serverName">The name of the server containing the failover group.</param>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>A representation of the deferred computation of this call returning the SqlFailoverGroup object.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> ForceFailoverAllowDataLossAsync(string resourceGroupName, string serverName, string failoverGroupName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Asynchronously fails over from the current primary server to this server.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group that contains the resource.</param>
        /// <param name="serverName">The name of the server containing the failover group.</param>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>A representation of the deferred computation of this call returning the SqlFailoverGroup object.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> FailoverAsync(string resourceGroupName, string serverName, string failoverGroupName, CancellationToken cancellationToken = default(CancellationToken));
    }
}