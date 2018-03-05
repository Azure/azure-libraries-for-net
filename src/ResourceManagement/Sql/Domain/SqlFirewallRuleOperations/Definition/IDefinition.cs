// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The final stage of the SQL Firewall Rule definition.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>
    {
    }

    /// <summary>
    /// The SQL Firewall Rule definition to set the IP address range for the parent SQL Server.
    /// </summary>
    public interface IWithIPAddressRange 
    {
        /// <summary>
        /// Sets the starting IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="startIPAddress">Starting IP address in IPv4 format.</param>
        /// <param name="endIPAddress">Starting IP address in IPv4 format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition.IWithCreate WithIPAddressRange(string startIPAddress, string endIPAddress);

        /// <summary>
        /// Sets the ending IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="ipAddress">IP address in IPv4 format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition.IWithCreate WithIPAddress(string ipAddress);
    }

    /// <summary>
    /// The first stage of the SQL Server Firewall rule definition.
    /// </summary>
    public interface IWithSqlServer 
    {
        /// <summary>
        /// Sets the parent SQL server for the new Firewall rule.
        /// </summary>
        /// <param name="sqlServerId">The parent SQL server ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition.IWithIPAddressRange WithExistingSqlServerId(string sqlServerId);

        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition.IWithIPAddressRange WithExistingSqlServer(string resourceGroupName, string sqlServerName);

        /// <summary>
        /// Sets the parent SQL server for the new Firewall rule.
        /// </summary>
        /// <param name="sqlServer">The parent SQL server.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition.IWithIPAddressRange WithExistingSqlServer(ISqlServer sqlServer);
    }
}