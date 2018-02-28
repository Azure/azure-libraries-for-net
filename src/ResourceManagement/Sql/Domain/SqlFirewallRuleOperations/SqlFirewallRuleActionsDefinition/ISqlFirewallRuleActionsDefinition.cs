// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.SqlFirewallRuleActionsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition;

    /// <summary>
    /// Grouping of the Azure SQL Server Firewall Rule common actions.
    /// </summary>
    public interface ISqlFirewallRuleActionsDefinition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>
    {
        /// <summary>
        /// Begins the definition of a new SQL Firewall rule to be added to this server.
        /// </summary>
        /// <param name="firewallRuleName">The name of the new SQL Firewall rule.</param>
        /// <return>The first stage of the new SQL Firewall rule definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition.IWithIPAddressRange Define(string firewallRuleName);
    }
}