// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Update;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Server Firewall Rule.
    /// </summary>
    public interface ISqlFirewallRule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule,Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.FirewallRuleInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlFirewallRule.Update.IUpdate>
    {
        /// <summary>
        /// Gets name of the SQL Server to which this Firewall Rule belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets kind of SQL Server that contains this Firewall Rule.
        /// </summary>
        string Kind { get; }

        /// <summary>
        /// Deletes the firewall rule asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the start IP address (in IPv4 format) of the Azure SQL Server Firewall Rule.
        /// </summary>
        string StartIPAddress { get; }

        /// <summary>
        /// Gets region of SQL Server that contains this Firewall Rule.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Region { get; }

        /// <summary>
        /// Deletes the firewall rule.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string ParentId { get; }

        /// <summary>
        /// Gets the end IP address (in IPv4 format) of the Azure SQL Server Firewall Rule.
        /// </summary>
        string EndIPAddress { get; }
    }
}