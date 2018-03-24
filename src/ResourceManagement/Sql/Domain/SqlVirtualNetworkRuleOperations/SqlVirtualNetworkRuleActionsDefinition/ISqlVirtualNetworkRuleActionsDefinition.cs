// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.SqlVirtualNetworkRuleActionsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition;

    /// <summary>
    /// Grouping of the Azure SQL Server Virtual Network Rule common actions.
    /// </summary>
    public interface ISqlVirtualNetworkRuleActionsDefinition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>
    {
        /// <summary>
        /// Begins the definition of a new SQL Virtual Network Rule to be added to this server.
        /// </summary>
        /// <param name="virtualNetworkRuleName">The name of the new SQL Virtual Network Rule.</param>
        /// <return>The first stage of the new SQL Virtual Network Rule definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition.IWithSubnet Define(string virtualNetworkRuleName);
    }
}