// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point to SQL Server management API.
    /// </summary>
    public interface ISqlServersBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Checks if container registry name is valid and is not in use asynchronously.
        /// </summary>
        /// <param name="name">The container registry name to check.</param>
        /// <return>A representation of the future computation of this call, returning whether the name is available or other info if not.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ICheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the SQL Server DNS aliases API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAliasOperations DnsAliases { get; }

        /// <summary>
        /// Gets the SQL Server Database API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseOperations Databases { get; }

        /// <summary>
        /// Gets the Azure SQL server capabilities for a given Azure region.
        /// </summary>
        /// <param name="region">The location to get the Azure SQL server capabilities for.</param>
        /// <return>The server capabilities object.</return>
        Microsoft.Azure.Management.Sql.Fluent.IRegionCapabilities GetCapabilitiesByRegion(Region region);

        /// <summary>
        /// Lists the Azure SQL server usages for a given Azure region asynchronously.
        /// </summary>
        /// <param name="region">The location to get the Azure SQL server usages for.</param>
        /// <return>A representation of the future computation of this call, returning the server usages object.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlSubscriptionUsageMetric>> ListUsageByRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the SQL Server Elastic Pools API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPoolOperations ElasticPools { get; }

        /// <summary>
        /// Gets the SQL Sync Group entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMemberOperations SyncMembers { get; }

        /// <summary>
        /// Gets the SQL Server VirtualNetwork Rules API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRuleOperations VirtualNetworkRules { get; }

        /// <summary>
        /// Gets the SQL Sync Group entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupOperations SyncGroups { get; }

        /// <summary>
        /// Gets the SQL Server Key entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlServerKeyOperations ServerKeys { get; }

        /// <summary>
        /// Lists the Azure SQL server usages for a given Azure region.
        /// </summary>
        /// <param name="region">The location to get the Azure SQL server usages for.</param>
        /// <return>The SQL usage object.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlSubscriptionUsageMetric> ListUsageByRegion(Region region);

        /// <summary>
        /// Checks if the specified container registry name is valid and available.
        /// </summary>
        /// <param name="name">The container registry name to check.</param>
        /// <return>Whether the name is available and other info if not.</return>
        Microsoft.Azure.Management.Sql.Fluent.ICheckNameAvailabilityResult CheckNameAvailability(string name);

        /// <summary>
        /// Gets the SQL Encryption Protector entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtectorOperations EncryptionProtectors { get; }

        /// <summary>
        /// Gets the SQL Failover Group API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroupOperations FailoverGroups { get; }

        /// <summary>
        /// Gets the Azure SQL server capabilities for a given Azure region asynchronously.
        /// </summary>
        /// <param name="region">The location to get the Azure SQL server capabilities for.</param>
        /// <return>A representation of the future computation of this call, returning the server capabilities object.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.IRegionCapabilities> GetCapabilitiesByRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the SQL Server Firewall Rules API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRuleOperations FirewallRules { get; }
    }
}