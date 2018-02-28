// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.SqlDatabaseActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.SqlElasticPoolActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.SqlFirewallRuleActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Server.
    /// </summary>
    public interface ISqlServer  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Sql.Fluent.ISqlManager,Models.ServerInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlServer.Update.IUpdate>
    {
        /// <summary>
        /// Gets the administrator login user name for the SQL Server.
        /// </summary>
        string AdministratorLogin { get; }

        /// <summary>
        /// Gets entry point to manage Databases for this SQL server.
        /// </summary>
        SqlDatabaseOperations.SqlDatabaseActionsDefinition.ISqlDatabaseActionsDefinition Databases { get; }

        /// <summary>
        /// Removes the Active Directory administrator from this server.
        /// </summary>
        void RemoveActiveDirectoryAdministrator();

        /// <return>Returns the list of usages (ServerMetric) of Azure SQL Server.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServerMetric> ListUsages();

        /// <return>Returns the list of usage metrics for an Azure SQL Server.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServerMetric> ListUsageMetrics();

        /// <summary>
        /// Gets fully qualified name of the SQL Server.
        /// </summary>
        string FullyQualifiedDomainName { get; }

        /// <summary>
        /// Gets the SQL Server "kind".
        /// </summary>
        string Kind { get; }

        /// <summary>
        /// Sets the Azure services default access to this server to false.
        /// The firewall rule named "AllowAllWindowsAzureIps" will be removed from the SQL server.
        /// </summary>
        void RemoveAccessFromAzureServices();

        /// <summary>
        /// Gets returns entry point to manage the SQL Elastic Pools for this server.
        /// </summary>
        SqlElasticPoolOperations.SqlElasticPoolActionsDefinition.ISqlElasticPoolActionsDefinition ElasticPools { get; }

        /// <return>The list of information on all service objectives.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServiceObjective> ListServiceObjectives();

        /// <return>The list of all restorable dropped databases.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase> ListRestorableDroppedDatabases();

        /// <summary>
        /// Gets the SQL Server version.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Gets the Active Directory administrator for this server.
        /// </summary>
        /// <return>A representation of a SQL Server Active Directory administrator object (null if one is not set).</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlActiveDirectoryAdministrator GetActiveDirectoryAdministrator();

        /// <summary>
        /// Gets the information on a particular Sql Server Service Objective.
        /// </summary>
        /// <param name="serviceObjectiveName">Name of the service objective to be fetched.</param>
        /// <return>Information of the service objective.</return>
        Microsoft.Azure.Management.Sql.Fluent.IServiceObjective GetServiceObjective(string serviceObjectiveName);

        /// <summary>
        /// Sets the Azure services default access to this server to true.
        /// A firewall rule named "AllowAllWindowsAzureIps" with the start IP "0.0.0.0" will be added
        /// to the SQL server if one does not exist.
        /// </summary>
        /// <return>The SQL Firewall rule.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule EnableAccessFromAzureServices();

        /// <summary>
        /// Sets an Active Directory administrator to this server.
        /// Azure Active Directory authentication allows you to centrally manage identity and access
        /// to your Azure SQL Database V12.
        /// </summary>
        /// <param name="userLogin">The user or group login; it can be the name or the email address.</param>
        /// <param name="id">The user or group unique ID.</param>
        /// <return>A representation of a SQL Server Active Directory administrator object.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlActiveDirectoryAdministrator SetActiveDirectoryAdministrator(string userLogin, string id);

        /// <summary>
        /// Returns all the recommended elastic pools for the server.
        /// </summary>
        /// <return>List of recommended elastic pools for the server.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool> ListRecommendedElasticPools();

        /// <summary>
        /// Gets the state of the server.
        /// </summary>
        string State { get; }

        /// <summary>
        /// Gets returns entry point to manage SQL Firewall rules for this server.
        /// </summary>
        SqlFirewallRuleOperations.SqlFirewallRuleActionsDefinition.ISqlFirewallRuleActionsDefinition FirewallRules { get; }

        /// <return>The list of all restorable dropped databases.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase> ListRestorableDroppedDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}