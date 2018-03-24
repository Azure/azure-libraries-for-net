// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition;

    /// <summary>
    /// A representation of the Azure SQL Virtual Network rule operations.
    /// </summary>
    public interface ISqlVirtualNetworkRuleOperations  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SqlVirtualNetworkRuleOperations.Definition.IWithSqlServer>,
        Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>
    {
    }
}