// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// The stage of the SQL Server definition allowing to specify the SQL Virtual Network Rules.
    /// </summary>
    public interface IWithVirtualNetworkRule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Begins the definition of a new SQL Virtual Network Rule to be added to this server.
        /// </summary>
        /// <param name="virtualNetworkRuleName">The name of the new SQL Virtual Network Rule.</param>
        /// <return>The first stage of the new SQL Virtual Network Rule definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition.IBlank<Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate> DefineVirtualNetworkRule(string virtualNetworkRuleName);
    }

    /// <summary>
    /// A SQL Server definition with sufficient inputs to create a new
    /// SQL Server in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithActiveDirectoryAdministrator,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithSystemAssignedManagedServiceIdentity,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithElasticPool,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithDatabase,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithFirewallRule,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithVirtualNetworkRule,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// A SQL Server definition allowing resource group to be set.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithAdministratorLogin>
    {
    }

    /// <summary>
    /// The stage of the SQL Server definition allowing to specify the SQL Firewall rules.
    /// </summary>
    public interface IWithFirewallRule  :
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithFirewallRuleBeta
    {
        /// <summary>
        /// Creates new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="ipAddress">IpAddress for the firewall rule.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate WithNewFirewallRule(string ipAddress);

        /// <summary>
        /// Creates new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="startIPAddress">Start IP address for the firewall rule.</param>
        /// <param name="endIPAddress">End IP address for the firewall rule.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate WithNewFirewallRule(string startIPAddress, string endIPAddress);

        /// <summary>
        /// Creates new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="startIPAddress">Start IP address for the firewall rule.</param>
        /// <param name="endIPAddress">End IP address for the firewall rule.</param>
        /// <param name="firewallRuleName">Name for the firewall rule.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate WithNewFirewallRule(string startIPAddress, string endIPAddress, string firewallRuleName);
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IBlank,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithGroup,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithAdministratorLogin,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithAdministratorPassword,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithElasticPool,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithDatabase,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithFirewallRule,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate
    {
    }

    /// <summary>
    /// A SQL Server definition setting the managed service identity.
    /// </summary>
    public interface IWithSystemAssignedManagedServiceIdentity  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets a system assigned (local) Managed Service Identity (MSI) for the SQL server resource.
        /// </summary>
        /// <return>Next stage of the SQL Server definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate WithSystemAssignedManagedServiceIdentity();
    }

    /// <summary>
    /// A SQL Server definition setting administrator user name.
    /// </summary>
    public interface IWithAdministratorLogin 
    {
        /// <summary>
        /// Sets the administrator login user name.
        /// </summary>
        /// <param name="administratorLogin">Administrator login user name.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithAdministratorPassword WithAdministratorLogin(string administratorLogin);
    }

    /// <summary>
    /// A SQL Server definition setting admin user password.
    /// </summary>
    public interface IWithAdministratorPassword 
    {
        /// <summary>
        /// Sets the administrator login password.
        /// </summary>
        /// <param name="administratorLoginPassword">Password for administrator login.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate WithAdministratorPassword(string administratorLoginPassword);
    }

    /// <summary>
    /// A SQL Server definition for specifying the databases.
    /// </summary>
    public interface IWithDatabase  :
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithDatabaseBeta
    {
        /// <summary>
        /// Creates new database in the SQL Server.
        /// </summary>
        /// <param name="databaseName">Name of the database to be created.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate WithNewDatabase(string databaseName);
    }

    /// <summary>
    /// The first stage of the SQL Server definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// A SQL Server definition setting the Active Directory administrator.
    /// </summary>
    public interface IWithActiveDirectoryAdministrator  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the SQL Active Directory administrator.
        /// Azure Active Directory authentication allows you to centrally manage identity and access
        /// to your Azure SQL Database V12.
        /// </summary>
        /// <param name="userLogin">The user or group login; it can be the name or the email address.</param>
        /// <param name="id">The user or group unique ID.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate WithActiveDirectoryAdministrator(string userLogin, string id);
    }

    /// <summary>
    /// A SQL Server definition for specifying elastic pool.
    /// </summary>
    public interface IWithElasticPool  :
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithElasticPoolBeta
    {
        /// <summary>
        /// Creates new elastic pool in the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be created.</param>
        /// <param name="elasticPoolEdition">Edition of the elastic pool.</param>
        /// <param name="databaseNames">Names of the database to be included in the elastic pool.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate WithNewElasticPool(string elasticPoolName, ElasticPoolEdition elasticPoolEdition, params string[] databaseNames);

        /// <summary>
        /// Creates new elastic pool in the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be created.</param>
        /// <param name="elasticPoolEdition">Edition of the elastic pool.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate WithNewElasticPool(string elasticPoolName, ElasticPoolEdition elasticPoolEdition);

    }

    /// <summary>
    /// The stage of the SQL Server definition allowing to specify the SQL Firewall rules.
    /// </summary>
    public interface IWithFirewallRuleBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the Azure services default access to this server to false.
        /// The default is to allow Azure services default access to this server via a special
        /// firewall rule named "AllowAllWindowsAzureIps" with the start IP "0.0.0.0".
        /// </summary>
        /// <return>Next stage of the SQL Server definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate WithoutAccessFromAzureServices();

        /// <summary>
        /// Begins the definition of a new SQL Firewall rule to be added to this server.
        /// </summary>
        /// <param name="firewallRuleName">The name of the new SQL Firewall rule.</param>
        /// <return>The first stage of the new SQL Firewall rule definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition.IBlank<Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate> DefineFirewallRule(string firewallRuleName);
    }

    /// <summary>
    /// A SQL Server definition for specifying the databases.
    /// </summary>
    public interface IWithDatabaseBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Begins the definition of a new SQL Database to be added to this server.
        /// </summary>
        /// <param name="databaseName">The name of the new SQL Database.</param>
        /// <return>The first stage of the new SQL Database definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IBlank<Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate> DefineDatabase(string databaseName);
    }

    /// <summary>
    /// A SQL Server definition for specifying elastic pool.
    /// </summary>
    public interface IWithElasticPoolBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Begins the definition of a new SQL Elastic Pool to be added to this server.
        /// </summary>
        /// <param name="elasticPoolName">The name of the new SQL Elastic Pool.</param>
        /// <return>The first stage of the new SQL Elastic Pool definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IBlank<Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition.IWithCreate> DefineElasticPool(string elasticPoolName);
    }
}