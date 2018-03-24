// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.SqlVirtualNetworkRuleDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface ISqlVirtualNetworkRuleDefinition<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition.IWithSubnet<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition.IWithServiceEndpoint<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition.IWithAttach<ParentT>
    {
    }
}