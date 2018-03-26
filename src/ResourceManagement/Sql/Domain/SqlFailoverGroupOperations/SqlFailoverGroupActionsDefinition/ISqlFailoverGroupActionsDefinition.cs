// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.SqlFailoverGroupActionsDefinition
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition;

    /// <summary>
    /// Grouping of the Azure SQL Failover Group common actions.
    /// </summary>
    public interface ISqlFailoverGroupActionsDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>
    {
        /// <summary>
        /// Fails over from the current primary server to this server. This operation might result in data loss.
        /// </summary>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>The SqlFailoverGroup object.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup ForceFailoverAllowDataLoss(string failoverGroupName);

        /// <summary>
        /// Fails over from the current primary server to this server.
        /// </summary>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>The SqlFailoverGroup object.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup Failover(string failoverGroupName);

        /// <summary>
        /// Fails over from the current primary server to this server. This operation might result in data loss.
        /// </summary>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>A representation of the deferred computation of this call returning the SqlFailoverGroup object.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> ForceFailoverAllowDataLossAsync(string failoverGroupName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Asynchronously fails over from the current primary server to this server.
        /// </summary>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>A representation of the deferred computation of this call returning the SqlFailoverGroup object.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> FailoverAsync(string failoverGroupName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Begins the definition of a new SQL Failover Group to be added to this server.
        /// </summary>
        /// <param name="failoverGroupName">The name of the new Failover Group to be created for the selected SQL server.</param>
        /// <return>The first stage of the new SQL Failover Group definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithReadWriteEndpointPolicy Define(string failoverGroupName);
    }
}