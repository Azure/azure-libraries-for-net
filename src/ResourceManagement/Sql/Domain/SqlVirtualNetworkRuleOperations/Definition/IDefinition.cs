// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The final stage of the SQL Virtual Network Rule definition.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>
    {
    }

    /// <summary>
    /// The SQL Virtual Network Rule definition to set ignore flag for the missing subnet's SQL service endpoint entry.
    /// </summary>
    public interface IWithServiceEndpoint  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition.IWithCreate
    {
        /// <summary>
        /// Gets Sets the flag to ignore the missing subnet's SQL service endpoint entry.
        /// Virtual Machines in the subnet will not be able to connect to the SQL server until Microsoft.Sql
        /// service endpoint is added to the subnet.
        /// </summary>
        /// <summary>
        /// Gets The next stage of the definition.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition.IWithCreate IgnoreMissingSqlServiceEndpoint();
    }

    /// <summary>
    /// The first stage of the SQL Server Virtual Network Rule definition.
    /// </summary>
    public interface IWithSqlServer  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the parent SQL server for the new Virtual Network Rule.
        /// </summary>
        /// <param name="sqlServerId">The parent SQL server ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition.IWithSubnet WithExistingSqlServerId(string sqlServerId);

        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition.IWithSubnet WithExistingSqlServer(string resourceGroupName, string sqlServerName);

        /// <summary>
        /// Sets the parent SQL server for the new Virtual Network Rule.
        /// </summary>
        /// <param name="sqlServer">The parent SQL server.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition.IWithSubnet WithExistingSqlServer(ISqlServer sqlServer);
    }

    /// <summary>
    /// The SQL Virtual Network Rule definition to set the virtual network ID and the subnet name.
    /// </summary>
    public interface IWithSubnet  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the virtual network ID and the subnet name for the SQL server Virtual Network Rule.
        /// </summary>
        /// <param name="networkId">The virtual network ID to be used.</param>
        /// <param name="subnetName">The name of the subnet within the virtual network to be used.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition.IWithServiceEndpoint WithSubnet(string networkId, string subnetName);
    }
}