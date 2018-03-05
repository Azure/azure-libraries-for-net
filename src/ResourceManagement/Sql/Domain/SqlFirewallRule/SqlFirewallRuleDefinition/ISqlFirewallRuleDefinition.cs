// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.SqlFirewallRuleDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface ISqlFirewallRuleDefinition<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition.IWithIPAddress<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition.IWithIPAddressRange<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition.IWithAttach<ParentT>
    {
    }
}