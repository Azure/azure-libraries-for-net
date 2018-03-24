// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.SqlVirtualNetworkRuleOperationsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface ISqlVirtualNetworkRuleOperationsDefinition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition.IWithSqlServer,
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition.IWithSubnet,
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition.IWithServiceEndpoint,
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition.IWithCreate
    {
    }
}