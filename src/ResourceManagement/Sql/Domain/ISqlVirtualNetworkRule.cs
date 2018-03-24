// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Update;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Server Virtual Network Rule.
    /// </summary>
    public interface ISqlVirtualNetworkRule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule,Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.VirtualNetworkRuleInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlVirtualNetworkRule.Update.IUpdate>
    {
        /// <summary>
        /// Gets the subnet ID of the Azure SQL Server Virtual Network Rule.
        /// </summary>
        string SubnetId { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this Virtual Network Rule belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Deletes the virtual network rule asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the Azure SQL Server Virtual Network Rule state; possible values include: 'Initializing',
        /// 'InProgress', 'Ready', 'Deleting', 'Unknown'.
        /// </summary>
        string State { get; }

        /// <summary>
        /// Deletes the virtual network rule.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string ParentId { get; }
    }
}