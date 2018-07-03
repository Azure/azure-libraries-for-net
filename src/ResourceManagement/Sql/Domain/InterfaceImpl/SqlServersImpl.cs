// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Threading.Tasks;
    using System.Threading;

    internal partial class SqlServersImpl 
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        SqlServer.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SqlServer.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Gets the Azure SQL server capabilities for a given Azure region.
        /// </summary>
        /// <param name="region">The location to get the Azure SQL server capabilities for.</param>
        /// <return>The server capabilities object.</return>
        Microsoft.Azure.Management.Sql.Fluent.IRegionCapabilities Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.GetCapabilitiesByRegion(Region region)
        {
            return this.GetCapabilitiesByRegion(region);
        }

        /// <summary>
        /// Gets the SQL Server Firewall Rules API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRuleOperations Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.FirewallRules
        {
            get
            {
                return this.FirewallRules();
            }
        }

        /// <summary>
        /// Gets the SQL Server Database API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseOperations Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.Databases
        {
            get
            {
                return this.Databases();
            }
        }

        /// <summary>
        /// Gets the Azure SQL server capabilities for a given Azure region asynchronously.
        /// </summary>
        /// <param name="region">The location to get the Azure SQL server capabilities for.</param>
        /// <return>A representation of the future computation of this call, returning the server capabilities object.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.IRegionCapabilities> Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.GetCapabilitiesByRegionAsync(Region region, CancellationToken cancellationToken)
        {
            return await this.GetCapabilitiesByRegionAsync(region, cancellationToken);
        }

        /// <summary>
        /// Lists the Azure SQL server usages for a given Azure region.
        /// </summary>
        /// <param name="region">The location to get the Azure SQL server usages for.</param>
        /// <return>The SQL usage object.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlSubscriptionUsageMetric> Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.ListUsageByRegion(Region region)
        {
            return this.ListUsageByRegion(region);
        }

        /// <summary>
        /// Gets the SQL Server DNS aliases API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAliasOperations Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.DnsAliases
        {
            get
            {
                return this.DnsAliases();
            }
        }

        /// <summary>
        /// Gets the SQL Server Elastic Pools API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPoolOperations Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.ElasticPools
        {
            get
            {
                return this.ElasticPools();
            }
        }

        /// <summary>
        /// Gets the SQL Server VirtualNetwork Rules API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRuleOperations Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.VirtualNetworkRules
        {
            get
            {
                return this.VirtualNetworkRules();
            }
        }

        /// <summary>
        /// Gets the SQL Sync Group entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMemberOperations Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.SyncMembers
        {
            get
            {
                return this.SyncMembers();
            }
        }

        /// <summary>
        /// Checks if container registry name is valid and is not in use asynchronously.
        /// </summary>
        /// <param name="name">The container registry name to check.</param>
        /// <return>A representation of the future computation of this call, returning whether the name is available or other info if not.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ICheckNameAvailabilityResult> Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken)
        {
            return await this.CheckNameAvailabilityAsync(name, cancellationToken);
        }

        /// <summary>
        /// Checks if the specified container registry name is valid and available.
        /// </summary>
        /// <param name="name">The container registry name to check.</param>
        /// <return>Whether the name is available and other info if not.</return>
        Microsoft.Azure.Management.Sql.Fluent.ICheckNameAvailabilityResult Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.CheckNameAvailability(string name)
        {
            return this.CheckNameAvailability(name);
        }

        /// <summary>
        /// Lists the Azure SQL server usages for a given Azure region asynchronously.
        /// </summary>
        /// <param name="region">The location to get the Azure SQL server usages for.</param>
        /// <return>A representation of the future computation of this call, returning the server usages object.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlSubscriptionUsageMetric>> Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.ListUsageByRegionAsync(Region region, CancellationToken cancellationToken)
        {
            return await this.ListUsageByRegionAsync(region, cancellationToken);
        }

        /// <summary>
        /// Gets the SQL Sync Group entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupOperations Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.SyncGroups
        {
            get
            {
                return this.SyncGroups();
            }
        }

        /// <summary>
        /// Gets the SQL Encryption Protector entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtectorOperations Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.EncryptionProtectors
        {
            get
            {
                return this.EncryptionProtectors();
            }
        }

        /// <summary>
        /// Gets the SQL Server Key entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlServerKeyOperations Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.ServerKeys
        {
            get
            {
                return this.ServerKeys();
            }
        }

        /// <summary>
        /// Gets the SQL Failover Group API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroupOperations Microsoft.Azure.Management.Sql.Fluent.ISqlServersBeta.FailoverGroups
        {
            get
            {
                return this.FailoverGroups();
            }
        }
    }
}