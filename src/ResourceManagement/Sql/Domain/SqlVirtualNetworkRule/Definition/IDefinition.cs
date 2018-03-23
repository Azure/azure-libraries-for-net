// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The SQL Virtual Network Rule definition to set the virtual network ID and the subnet name.
    /// </summary>
    public interface IWithSubnet<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the virtual network ID and the subnet name for the SQL server Virtual Network Rule.
        /// </summary>
        /// <param name="networkId">The virtual network ID to be used.</param>
        /// <param name="subnetName">The name of the subnet within the virtual network to be used.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition.IWithServiceEndpoint<ParentT> WithSubnet(string networkId, string subnetName);
    }

    /// <summary>
    /// The first stage of the SQL Server Virtual Network Rule definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition.IWithSubnet<ParentT>
    {
    }

    /// <summary>
    /// The SQL Virtual Network Rule definition to set ignore flag for the missing subnet's SQL service endpoint entry.
    /// </summary>
    public interface IWithServiceEndpoint<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition.IWithAttach<ParentT>
    {
        /// <summary>
        /// Gets Sets the flag to ignore the missing subnet's SQL service endpoint entry.
        /// Virtual Machines in the subnet will not be able to connect to the SQL server until Microsoft.Sql
        /// service endpoint is added to the subnet.
        /// </summary>
        /// <summary>
        /// Gets The next stage of the definition.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition.IWithAttach<ParentT> IgnoreMissingSqlServiceEndpoint { get; }
    }

    /// <summary>
    /// The final stage of the SQL Virtual Network Rule definition.
    /// At this stage, any remaining optional settings can be specified, or the SQL Virtual Network Rule definition
    /// can be attached to the parent SQL Server definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }
}