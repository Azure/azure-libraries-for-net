// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.SqlDatabaseActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.SqlElasticPoolActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.SqlFailoverGroupActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.SqlFirewallRuleActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.SqlServerDnsAliasActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.SqlServerKeyActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.SqlVirtualNetworkRuleActionsDefinition;
    using System.Collections.Generic;
    using System;

    internal partial class SqlServerImpl 
    {
        /// <summary>
        /// Begins the definition of a new SQL Database to be added to this server.
        /// </summary>
        /// <param name="databaseName">The name of the new SQL Database.</param>
        /// <return>The first stage of the new SQL Database definition.</return>
        SqlDatabase.Definition.IBlank<SqlServer.Definition.IWithCreate> SqlServer.Definition.IWithDatabaseBeta.DefineDatabase(string databaseName)
        {
            return this.DefineDatabase(databaseName);
        }

        /// <summary>
        /// Creates new database in the SQL Server.
        /// </summary>
        /// <param name="databaseName">Name of the database to be created.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithDatabase.WithNewDatabase(string databaseName)
        {
            return this.WithNewDatabase(databaseName);
        }

        /// <summary>
        /// Remove database from the SQL Server.
        /// </summary>
        /// <param name="databaseName">Name of the database to be removed.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithDatabase.WithoutDatabase(string databaseName)
        {
            return this.WithoutDatabase(databaseName);
        }

        /// <summary>
        /// Create new database in the SQL Server.
        /// </summary>
        /// <param name="databaseName">Name of the database to be created.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithDatabase.WithNewDatabase(string databaseName)
        {
            return this.WithNewDatabase(databaseName);
        }

        /// <summary>
        /// Sets the administrator login password.
        /// </summary>
        /// <param name="administratorLoginPassword">Password for administrator login.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithAdministratorPassword.WithAdministratorPassword(string administratorLoginPassword)
        {
            return this.WithAdministratorPassword(administratorLoginPassword);
        }

        /// <summary>
        /// Sets the administrator login password.
        /// </summary>
        /// <param name="administratorLoginPassword">Password for administrator login.</param>
        /// <return>Next stage of the update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithAdministratorPassword.WithAdministratorPassword(string administratorLoginPassword)
        {
            return this.WithAdministratorPassword(administratorLoginPassword);
        }

        /// <summary>
        /// Begins the definition of a new SQL Elastic Pool to be added to this server.
        /// </summary>
        /// <param name="elasticPoolName">The name of the new SQL Elastic Pool.</param>
        /// <return>The first stage of the new SQL Elastic Pool definition.</return>
        SqlElasticPool.Definition.IBlank<SqlServer.Definition.IWithCreate> SqlServer.Definition.IWithElasticPoolBeta.DefineElasticPool(string elasticPoolName)
        {
            return this.DefineElasticPool(elasticPoolName);
        }

        /// <summary>
        /// Creates new elastic pool in the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be created.</param>
        /// <param name="elasticPoolEdition">Edition of the elastic pool.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithElasticPool.WithNewElasticPool(string elasticPoolName, ElasticPoolEdition elasticPoolEdition)
        {
            return this.WithNewElasticPool(elasticPoolName, elasticPoolEdition);
        }

        /// <summary>
        /// Creates new elastic pool in the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be created.</param>
        /// <param name="elasticPoolEdition">Edition of the elastic pool.</param>
        /// <param name="databaseNames">Names of the database to be included in the elastic pool.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithElasticPool.WithNewElasticPool(string elasticPoolName, ElasticPoolEdition elasticPoolEdition, params string[] databaseNames)
        {
            return this.WithNewElasticPool(elasticPoolName, elasticPoolEdition, databaseNames);
        }

        /// <summary>
        /// Removes elastic pool from the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be removed.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithElasticPool.WithoutElasticPool(string elasticPoolName)
        {
            return this.WithoutElasticPool(elasticPoolName);
        }

        /// <summary>
        /// Create new elastic pool in the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be created.</param>
        /// <param name="elasticPoolEdition">Edition of the elastic pool.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithElasticPoolBeta.WithNewElasticPool(string elasticPoolName, ElasticPoolEdition elasticPoolEdition)
        {
            return this.WithNewElasticPool(elasticPoolName, elasticPoolEdition);
        }

        /// <summary>
        /// Create new elastic pool in the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be created.</param>
        /// <param name="elasticPoolEdition">Edition of the elastic pool.</param>
        /// <param name="databaseNames">Names of the database to be included in the elastic pool.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithElasticPoolBeta.WithNewElasticPool(string elasticPoolName, ElasticPoolEdition elasticPoolEdition, params string[] databaseNames)
        {
            return this.WithNewElasticPool(elasticPoolName, elasticPoolEdition, databaseNames);
        }

        /// <summary>
        /// Gets returns entry point to manage SQL Firewall rules for this server.
        /// </summary>
        SqlFirewallRuleOperations.SqlFirewallRuleActionsDefinition.ISqlFirewallRuleActionsDefinition Microsoft.Azure.Management.Sql.Fluent.ISqlServer.FirewallRules
        {
            get
            {
                return this.FirewallRules();
            }
        }

        /// <summary>
        /// Gets entry point to manage Databases for this SQL server.
        /// </summary>
        SqlDatabaseOperations.SqlDatabaseActionsDefinition.ISqlDatabaseActionsDefinition Microsoft.Azure.Management.Sql.Fluent.ISqlServer.Databases
        {
            get
            {
                return this.Databases();
            }
        }

        /// <summary>
        /// Gets returns entry point to manage SQL Server DNS aliases for this server.
        /// </summary>
        SqlServerDnsAliasOperations.SqlServerDnsAliasActionsDefinition.ISqlServerDnsAliasActionsDefinition Microsoft.Azure.Management.Sql.Fluent.ISqlServer.DnsAliases
        {
            get
            {
                return this.DnsAliases();
            }
        }

        /// <summary>
        /// Sets the Azure services default access to this server to false.
        /// The firewall rule named "AllowAllWindowsAzureIps" will be removed from the SQL server.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlServer.RemoveAccessFromAzureServices()
        {
 
            this.RemoveAccessFromAzureServices();
        }

        /// <summary>
        /// Returns all the recommended elastic pools for the server.
        /// </summary>
        /// <return>List of recommended elastic pools for the server.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool> Microsoft.Azure.Management.Sql.Fluent.ISqlServer.ListRecommendedElasticPools()
        {
            return this.ListRecommendedElasticPools();
        }

        /// <summary>
        /// Gets the Active Directory administrator for this server.
        /// </summary>
        /// <return>A representation of a SQL Server Active Directory administrator object (null if one is not set).</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlActiveDirectoryAdministrator Microsoft.Azure.Management.Sql.Fluent.ISqlServer.GetActiveDirectoryAdministrator()
        {
            return this.GetActiveDirectoryAdministrator();
        }

        /// <summary>
        /// Gets the administrator login user name for the SQL Server.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServer.AdministratorLogin
        {
            get
            {
                return this.AdministratorLogin();
            }
        }

        /// <summary>
        /// Gets returns entry point to manage SQL Failover Group for this server.
        /// </summary>
        SqlFailoverGroupOperations.SqlFailoverGroupActionsDefinition.ISqlFailoverGroupActionsDefinition Microsoft.Azure.Management.Sql.Fluent.ISqlServer.FailoverGroups
        {
            get
            {
                return this.FailoverGroups();
            }
        }

        /// <summary>
        /// Sets an Active Directory administrator to this server.
        /// Azure Active Directory authentication allows you to centrally manage identity and access
        /// to your Azure SQL Database V12.
        /// </summary>
        /// <param name="userLogin">The user or group login; it can be the name or the email address.</param>
        /// <param name="id">The user or group unique ID.</param>
        /// <return>A representation of a SQL Server Active Directory administrator object.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlActiveDirectoryAdministrator Microsoft.Azure.Management.Sql.Fluent.ISqlServer.SetActiveDirectoryAdministrator(string userLogin, string id)
        {
            return this.SetActiveDirectoryAdministrator(userLogin, id);
        }

        /// <summary>
        /// Gets a SQL server automatic tuning state and options.
        /// </summary>
        /// <return>The SQL server automatic tuning state and options.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlServerAutomaticTuning Microsoft.Azure.Management.Sql.Fluent.ISqlServer.GetServerAutomaticTuning()
        {
            return this.GetServerAutomaticTuning();
        }

        /// <summary>
        /// Gets returns entry point to manage SQL Virtual Network Rule for this server.
        /// </summary>
        SqlVirtualNetworkRuleOperations.SqlVirtualNetworkRuleActionsDefinition.ISqlVirtualNetworkRuleActionsDefinition Microsoft.Azure.Management.Sql.Fluent.ISqlServer.VirtualNetworkRules
        {
            get
            {
                return this.VirtualNetworkRules();
            }
        }

        /// <summary>
        /// Gets returns entry point to manage SQL Server Keys for this server.
        /// </summary>
        SqlServerKeyOperations.SqlServerKeyActionsDefinition.ISqlServerKeyActionsDefinition Microsoft.Azure.Management.Sql.Fluent.ISqlServer.ServerKeys
        {
            get
            {
                return this.ServerKeys();
            }
        }

        /// <summary>
        /// Gets fully qualified name of the SQL Server.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServer.FullyQualifiedDomainName
        {
            get
            {
                return this.FullyQualifiedDomainName();
            }
        }

        /// <summary>
        /// Gets true if Managed Service Identity is enabled for the SQL server.
        /// </summary>
        bool Microsoft.Azure.Management.Sql.Fluent.ISqlServer.IsManagedServiceIdentityEnabled
        {
            get
            {
                return this.IsManagedServiceIdentityEnabled();
            }
        }

        /// <summary>
        /// Gets returns entry point to manage the SQL Elastic Pools for this server.
        /// </summary>
        SqlElasticPoolOperations.SqlElasticPoolActionsDefinition.ISqlElasticPoolActionsDefinition Microsoft.Azure.Management.Sql.Fluent.ISqlServer.ElasticPools
        {
            get
            {
                return this.ElasticPools();
            }
        }

        /// <return>Returns the list of usages (ServerMetric) of Azure SQL Server.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServerMetric> Microsoft.Azure.Management.Sql.Fluent.ISqlServer.ListUsages()
        {
            return this.ListUsages();
        }

        /// <return>The list of information on all service objectives.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServiceObjective> Microsoft.Azure.Management.Sql.Fluent.ISqlServer.ListServiceObjectives()
        {
            return this.ListServiceObjectives();
        }

        /// <return>The list of all restorable dropped databases.</return>
        async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase>> Microsoft.Azure.Management.Sql.Fluent.ISqlServer.ListRestorableDroppedDatabasesAsync(CancellationToken cancellationToken)
        {
            return await this.ListRestorableDroppedDatabasesAsync(cancellationToken);
        }

        /// <return>The list of all restorable dropped databases.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase> Microsoft.Azure.Management.Sql.Fluent.ISqlServer.ListRestorableDroppedDatabases()
        {
            return this.ListRestorableDroppedDatabases();
        }

        /// <summary>
        /// Sets the Azure services default access to this server to true.
        /// A firewall rule named "AllowAllWindowsAzureIps" with the start IP "0.0.0.0" will be added
        /// to the SQL server if one does not exist.
        /// </summary>
        /// <return>The SQL Firewall rule.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule Microsoft.Azure.Management.Sql.Fluent.ISqlServer.EnableAccessFromAzureServices()
        {
            return this.EnableAccessFromAzureServices();
        }

        /// <summary>
        /// Gets the information on a particular Sql Server Service Objective.
        /// </summary>
        /// <param name="serviceObjectiveName">Name of the service objective to be fetched.</param>
        /// <return>Information of the service objective.</return>
        Microsoft.Azure.Management.Sql.Fluent.IServiceObjective Microsoft.Azure.Management.Sql.Fluent.ISqlServer.GetServiceObjective(string serviceObjectiveName)
        {
            return this.GetServiceObjective(serviceObjectiveName);
        }

        /// <summary>
        /// Gets the SQL Server "kind".
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServer.Kind
        {
            get
            {
                return this.Kind();
            }
        }

        /// <return>Returns the list of usage metrics for an Azure SQL Server.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServerMetric> Microsoft.Azure.Management.Sql.Fluent.ISqlServer.ListUsageMetrics()
        {
            return this.ListUsageMetrics();
        }

        /// <summary>
        /// Gets returns entry point to manage SQL Encryption Protector for this server.
        /// </summary>
        SqlEncryptionProtectorOperations.SqlEncryptionProtectorActionsDefinition.ISqlEncryptionProtectorActionsDefinition Microsoft.Azure.Management.Sql.Fluent.ISqlServer.EncryptionProtectors
        {
            get
            {
                return this.EncryptionProtectors();
            }
        }

        /// <summary>
        /// Gets the System Assigned (Local) Managed Service Identity specific Active Directory service principal ID
        /// assigned to the SQL server.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServer.SystemAssignedManagedServiceIdentityPrincipalId
        {
            get
            {
                return this.SystemAssignedManagedServiceIdentityPrincipalId();
            }
        }

        /// <summary>
        /// Removes the Active Directory administrator from this server.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlServer.RemoveActiveDirectoryAdministrator()
        {
 
            this.RemoveActiveDirectoryAdministrator();
        }

        /// <summary>
        /// Gets the SQL Server version.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServer.Version
        {
            get
            {
                return this.Version();
            }
        }

        /// <summary>
        /// Gets the type of Managed Service Identity used for the SQL server.
        /// </summary>
        IdentityType Microsoft.Azure.Management.Sql.Fluent.ISqlServer.ManagedServiceIdentityType
        {
            get
            {
                return this.ManagedServiceIdentityType();
            }
        }

        /// <summary>
        /// Gets the System Assigned (Local) Managed Service Identity specific Active Directory tenant ID assigned
        /// to the SQL server.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServer.SystemAssignedManagedServiceIdentityTenantId
        {
            get
            {
                return this.SystemAssignedManagedServiceIdentityTenantId();
            }
        }

        /// <summary>
        /// Gets the state of the server.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServer.State
        {
            get
            {
                return this.State();
            }
        }

        /// <summary>
        /// Sets a system assigned (local) Managed Service Identity (MSI) for the SQL server resource.
        /// </summary>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithSystemAssignedManagedServiceIdentity.WithSystemAssignedManagedServiceIdentity()
        {
            return this.WithSystemAssignedManagedServiceIdentity();
        }

        /// <summary>
        /// Sets a system assigned (local) Managed Service Identity (MSI) for the SQL server resource.
        /// </summary>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithSystemAssignedManagedServiceIdentity.WithSystemAssignedManagedServiceIdentity()
        {
            return this.WithSystemAssignedManagedServiceIdentity();
        }

        /// <summary>
        /// Begins the definition of a new SQL Virtual Network Rule to be added to this server.
        /// </summary>
        /// <param name="virtualNetworkRuleName">The name of the new SQL Virtual Network Rule.</param>
        /// <return>The first stage of the new SQL Virtual Network Rule definition.</return>
        SqlVirtualNetworkRule.Definition.IBlank<SqlServer.Definition.IWithCreate> SqlServer.Definition.IWithVirtualNetworkRule.DefineVirtualNetworkRule(string virtualNetworkRuleName)
        {
            return this.DefineVirtualNetworkRule(virtualNetworkRuleName);
        }

        /// <summary>
        /// Sets the SQL Active Directory administrator.
        /// Azure Active Directory authentication allows you to centrally manage identity and access
        /// to your Azure SQL Database V12.
        /// </summary>
        /// <param name="userLogin">The user or group login; it can be the name or the email address.</param>
        /// <param name="id">The user or group unique ID.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithActiveDirectoryAdministrator.WithActiveDirectoryAdministrator(string userLogin, string id)
        {
            return this.WithActiveDirectoryAdministrator(userLogin, id);
        }

        /// <summary>
        /// Begins the definition of a new SQL Firewall rule to be added to this server.
        /// </summary>
        /// <param name="firewallRuleName">The name of the new SQL Firewall rule.</param>
        /// <return>The first stage of the new SQL Firewall rule definition.</return>
        SqlFirewallRule.Definition.IBlank<SqlServer.Definition.IWithCreate> SqlServer.Definition.IWithFirewallRuleBeta.DefineFirewallRule(string firewallRuleName)
        {
            return this.DefineFirewallRule(firewallRuleName);
        }

        /// <summary>
        /// Creates new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="ipAddress">IpAddress for the firewall rule.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithFirewallRule.WithNewFirewallRule(string ipAddress)
        {
            return this.WithNewFirewallRule(ipAddress);
        }

        /// <summary>
        /// Creates new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="startIPAddress">Start IP address for the firewall rule.</param>
        /// <param name="endIPAddress">End IP address for the firewall rule.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithFirewallRule.WithNewFirewallRule(string startIPAddress, string endIPAddress)
        {
            return this.WithNewFirewallRule(startIPAddress, endIPAddress);
        }

        /// <summary>
        /// Creates new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="startIPAddress">Start IP address for the firewall rule.</param>
        /// <param name="endIPAddress">End IP address for the firewall rule.</param>
        /// <param name="firewallRuleName">Name for the firewall rule.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithFirewallRule.WithNewFirewallRule(string startIPAddress, string endIPAddress, string firewallRuleName)
        {
            return this.WithNewFirewallRule(startIPAddress, endIPAddress, firewallRuleName);
        }

        /// <summary>
        /// Sets the Azure services default access to this server to false.
        /// The default is to allow Azure services default access to this server via a special
        /// firewall rule named "AllowAllWindowsAzureIps" with the start IP "0.0.0.0".
        /// </summary>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithFirewallRuleBeta.WithoutAccessFromAzureServices()
        {
            return this.WithoutAccessFromAzureServices();
        }

        /// <summary>
        /// Removes firewall rule from the SQL Server.
        /// </summary>
        /// <param name="firewallRuleName">Name of the firewall rule to be removed.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithFirewallRule.WithoutFirewallRule(string firewallRuleName)
        {
            return this.WithoutFirewallRule(firewallRuleName);
        }

        /// <summary>
        /// Create new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="ipAddress">IP address for the firewall rule.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithFirewallRule.WithNewFirewallRule(string ipAddress)
        {
            return this.WithNewFirewallRule(ipAddress);
        }

        /// <summary>
        /// Create new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="startIPAddress">Start IP address for the firewall rule.</param>
        /// <param name="endIPAddress">IP address for the firewall rule.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithFirewallRule.WithNewFirewallRule(string startIPAddress, string endIPAddress)
        {
            return this.WithNewFirewallRule(startIPAddress, endIPAddress);
        }

        /// <summary>
        /// Creates new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="startIPAddress">Start IP address for the firewall rule.</param>
        /// <param name="endIPAddress">End IP address for the firewall rule.</param>
        /// <param name="firewallRuleName">Name for the firewall rule.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithFirewallRule.WithNewFirewallRule(string startIPAddress, string endIPAddress, string firewallRuleName)
        {
            return this.WithNewFirewallRule(startIPAddress, endIPAddress, firewallRuleName);
        }

        /// <summary>
        /// Sets the administrator login user name.
        /// </summary>
        /// <param name="administratorLogin">Administrator login user name.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithAdministratorPassword SqlServer.Definition.IWithAdministratorLogin.WithAdministratorLogin(string administratorLogin)
        {
            return this.WithAdministratorLogin(administratorLogin);
        }
    }
}