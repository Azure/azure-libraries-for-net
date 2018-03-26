// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The SQL Virtual Network Rule definition to set ignore flag for the missing subnet's SQL service endpoint entry.
    /// </summary>
    public interface IWithServiceEndpoint  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets Sets the flag to ignore the missing subnet's SQL service endpoint entry.
        /// Virtual Machines in the subnet will not be able to connect to the SQL server until Microsoft.Sql
        /// service endpoint is added to the subnet.
        /// </summary>
        /// <summary>
        /// Gets The next stage of the definition.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Update.IUpdate IgnoreMissingSqlServiceEndpoint();
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
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Update.IUpdate WithSubnet(string networkId, string subnetName);
    }

    /// <summary>
    /// The template for a SQL Virtual Network Rule update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Update.IWithSubnet,
        Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Update.IWithServiceEndpoint,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>
    {
    }
}