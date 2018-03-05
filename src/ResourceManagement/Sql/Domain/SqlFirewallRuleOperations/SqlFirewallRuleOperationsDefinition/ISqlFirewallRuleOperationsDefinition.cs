// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.SqlFirewallRuleOperationsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface ISqlFirewallRuleOperationsDefinition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition.IWithSqlServer,
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition.IWithIPAddressRange,
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition.IWithCreate
    {
    }
}