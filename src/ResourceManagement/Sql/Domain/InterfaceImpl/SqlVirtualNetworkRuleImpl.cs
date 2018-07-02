// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.SqlVirtualNetworkRuleDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.SqlVirtualNetworkRuleOperationsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    internal partial class SqlVirtualNetworkRuleImpl 
    {
        /// <summary>
        /// Sets the parent SQL server for the new Virtual Network Rule.
        /// </summary>
        /// <param name="sqlServerId">The parent SQL server ID.</param>
        /// <return>The next stage of the definition.</return>
        SqlVirtualNetworkRuleOperations.Definition.IWithSubnet SqlVirtualNetworkRuleOperations.Definition.IWithSqlServer.WithExistingSqlServerId(string sqlServerId)
        {
            return this.WithExistingSqlServerId(sqlServerId);
        }

        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <return>The next stage of the definition.</return>
        SqlVirtualNetworkRuleOperations.Definition.IWithSubnet SqlVirtualNetworkRuleOperations.Definition.IWithSqlServer.WithExistingSqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.WithExistingSqlServer(resourceGroupName, sqlServerName);
        }

        /// <summary>
        /// Sets the parent SQL server for the new Virtual Network Rule.
        /// </summary>
        /// <param name="sqlServer">The parent SQL server.</param>
        /// <return>The next stage of the definition.</return>
        SqlVirtualNetworkRuleOperations.Definition.IWithSubnet SqlVirtualNetworkRuleOperations.Definition.IWithSqlServer.WithExistingSqlServer(ISqlServer sqlServer)
        {
            return this.WithExistingSqlServer(sqlServer);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        SqlServer.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<SqlServer.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        SqlVirtualNetworkRule.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlVirtualNetworkRule.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Gets Sets the flag to ignore the missing subnet's SQL service endpoint entry.
        /// Virtual Machines in the subnet will not be able to connect to the SQL server until Microsoft.Sql
        /// service endpoint is added to the subnet.
        /// </summary>
        /// <summary>
        /// Gets The next stage of the definition.
        /// </summary>
        SqlVirtualNetworkRule.Definition.IWithAttach<SqlServer.Definition.IWithCreate> SqlVirtualNetworkRule.Definition.IWithServiceEndpoint<SqlServer.Definition.IWithCreate>.IgnoreMissingSqlServiceEndpoint
        {
            get
            {
                return this.IgnoreMissingSqlServiceEndpoint();
            }
        }

        /// <summary>
        /// Sets the virtual network ID and the subnet name for the SQL server Virtual Network Rule.
        /// </summary>
        /// <param name="networkId">The virtual network ID to be used.</param>
        /// <param name="subnetName">The name of the subnet within the virtual network to be used.</param>
        /// <return>The next stage of the definition.</return>
        SqlVirtualNetworkRule.Definition.IWithServiceEndpoint<SqlServer.Definition.IWithCreate> SqlVirtualNetworkRule.Definition.IWithSubnet<SqlServer.Definition.IWithCreate>.WithSubnet(string networkId, string subnetName)
        {
            return this.WithSubnet(networkId, subnetName);
        }

        /// <summary>
        /// Gets Sets the flag to ignore the missing subnet's SQL service endpoint entry.
        /// Virtual Machines in the subnet will not be able to connect to the SQL server until Microsoft.Sql
        /// service endpoint is added to the subnet.
        /// </summary>
        /// <summary>
        /// Gets The next stage of the definition.
        /// </summary>
        SqlVirtualNetworkRule.Update.IUpdate SqlVirtualNetworkRule.Update.IWithServiceEndpoint.IgnoreMissingSqlServiceEndpoint()
        {
            return this.IgnoreMissingSqlServiceEndpoint();
        }

        /// <summary>
        /// Gets Sets the flag to ignore the missing subnet's SQL service endpoint entry.
        /// Virtual Machines in the subnet will not be able to connect to the SQL server until Microsoft.Sql
        /// service endpoint is added to the subnet.
        /// </summary>
        /// <summary>
        /// Gets The next stage of the definition.
        /// </summary>
        SqlVirtualNetworkRuleOperations.Definition.IWithCreate SqlVirtualNetworkRuleOperations.Definition.IWithServiceEndpoint.IgnoreMissingSqlServiceEndpoint()
        {
            return this.IgnoreMissingSqlServiceEndpoint();
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Gets the subnet ID of the Azure SQL Server Virtual Network Rule.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule.SubnetId
        {
            get
            {
                return this.SubnetId();
            }
        }

        /// <summary>
        /// Gets the Azure SQL Server Virtual Network Rule state; possible values include: 'Initializing',
        /// 'InProgress', 'Ready', 'Deleting', 'Unknown'.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule.State
        {
            get
            {
                return this.State();
            }
        }

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule.ParentId
        {
            get
            {
                return this.ParentId();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this Virtual Network Rule belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Deletes the virtual network rule.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule.Delete()
        {
 
            this.Delete();
        }

        /// <summary>
        /// Deletes the virtual network rule asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule.DeleteAsync(CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(cancellationToken);
        }

        /// <summary>
        /// Sets the virtual network ID and the subnet name for the SQL server Virtual Network Rule.
        /// </summary>
        /// <param name="networkId">The virtual network ID to be used.</param>
        /// <param name="subnetName">The name of the subnet within the virtual network to be used.</param>
        /// <return>The next stage of the definition.</return>
        SqlVirtualNetworkRule.Update.IUpdate SqlVirtualNetworkRule.Update.IWithSubnet.WithSubnet(string networkId, string subnetName)
        {
            return this.WithSubnet(networkId, subnetName);
        }

        /// <summary>
        /// Sets the virtual network ID and the subnet name for the SQL server Virtual Network Rule.
        /// </summary>
        /// <param name="networkId">The virtual network ID to be used.</param>
        /// <param name="subnetName">The name of the subnet within the virtual network to be used.</param>
        /// <return>The next stage of the definition.</return>
        SqlVirtualNetworkRuleOperations.Definition.IWithServiceEndpoint SqlVirtualNetworkRuleOperations.Definition.IWithSubnet.WithSubnet(string networkId, string subnetName)
        {
            return this.WithSubnet(networkId, subnetName);
        }
    }
}