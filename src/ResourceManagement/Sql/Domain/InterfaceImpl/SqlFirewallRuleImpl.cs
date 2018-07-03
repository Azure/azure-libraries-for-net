// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.SqlFirewallRuleDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.SqlFirewallRuleOperationsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    internal partial class SqlFirewallRuleImpl 
    {
        /// <summary>
        /// Sets the ending IP address of SQL server's Firewall Rule.
        /// </summary>
        /// <param name="endIPAddress">End IP address in IPv4 format.</param>
        /// <return>The next stage of the update.</return>
        SqlFirewallRule.Update.IUpdate SqlFirewallRule.Update.IWithEndIPAddress.WithEndIPAddress(string endIPAddress)
        {
            return this.WithEndIPAddress(endIPAddress);
        }

        /// <summary>
        /// Sets the starting IP address of SQL server's Firewall Rule.
        /// </summary>
        /// <param name="startIPAddress">Start IP address in IPv4 format.</param>
        /// <return>The next stage of the update.</return>
        SqlFirewallRule.Update.IUpdate SqlFirewallRule.Update.IWithStartIPAddress.WithStartIPAddress(string startIPAddress)
        {
            return this.WithStartIPAddress(startIPAddress);
        }

        /// <summary>
        /// Sets the parent SQL server for the new Firewall rule.
        /// </summary>
        /// <param name="sqlServerId">The parent SQL server ID.</param>
        /// <return>The next stage of the definition.</return>
        SqlFirewallRuleOperations.Definition.IWithIPAddressRange SqlFirewallRuleOperations.Definition.IWithSqlServer.WithExistingSqlServerId(string sqlServerId)
        {
            return this.WithExistingSqlServerId(sqlServerId);
        }

        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <return>The next stage of the definition.</return>
        SqlFirewallRuleOperations.Definition.IWithIPAddressRange SqlFirewallRuleOperations.Definition.IWithSqlServer.WithExistingSqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.WithExistingSqlServer(resourceGroupName, sqlServerName);
        }

        /// <summary>
        /// Sets the parent SQL server for the new Firewall rule.
        /// </summary>
        /// <param name="sqlServer">The parent SQL server.</param>
        /// <return>The next stage of the definition.</return>
        SqlFirewallRuleOperations.Definition.IWithIPAddressRange SqlFirewallRuleOperations.Definition.IWithSqlServer.WithExistingSqlServer(ISqlServer sqlServer)
        {
            return this.WithExistingSqlServer(sqlServer);
        }

        /// <summary>
        /// Sets the ending IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="ipAddress">IP address in IPv4 format.</param>
        /// <return>The next stage of the definition.</return>
        SqlFirewallRuleOperations.Definition.IWithCreate SqlFirewallRuleOperations.Definition.IWithIPAddressRange.WithIPAddress(string ipAddress)
        {
            return this.WithIPAddress(ipAddress);
        }

        /// <summary>
        /// Sets the starting IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="startIPAddress">Starting IP address in IPv4 format.</param>
        /// <param name="endIPAddress">Starting IP address in IPv4 format.</param>
        /// <return>The next stage of the definition.</return>
        SqlFirewallRuleOperations.Definition.IWithCreate SqlFirewallRuleOperations.Definition.IWithIPAddressRange.WithIPAddressRange(string startIPAddress, string endIPAddress)
        {
            return this.WithIPAddressRange(startIPAddress, endIPAddress);
        }

        /// <summary>
        /// Sets the ending IP address of SQL server's Firewall Rule.
        /// </summary>
        /// <param name="ipAddress">IP address in IPv4 format.</param>
        /// <return>The next stage of the definition.</return>
        SqlFirewallRule.Definition.IWithAttach<SqlServer.Definition.IWithCreate> SqlFirewallRule.Definition.IWithIPAddress<SqlServer.Definition.IWithCreate>.WithIPAddress(string ipAddress)
        {
            return this.WithIPAddress(ipAddress);
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
        SqlFirewallRule.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlFirewallRule.Update.IUpdate>.Update()
        {
            return this.Update();
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
        /// Sets the starting IP address of SQL server's Firewall Rule.
        /// </summary>
        /// <param name="startIPAddress">Starting IP address in IPv4 format.</param>
        /// <param name="endIPAddress">Starting IP address in IPv4 format.</param>
        /// <return>The next stage of the definition.</return>
        SqlFirewallRule.Definition.IWithAttach<SqlServer.Definition.IWithCreate> SqlFirewallRule.Definition.IWithIPAddressRange<SqlServer.Definition.IWithCreate>.WithIPAddressRange(string startIPAddress, string endIPAddress)
        {
            return this.WithIPAddressRange(startIPAddress, endIPAddress);
        }

        /// <summary>
        /// Gets the start IP address (in IPv4 format) of the Azure SQL Server Firewall Rule.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.StartIPAddress
        {
            get
            {
                return this.StartIPAddress();
            }
        }

        /// <summary>
        /// Gets region of SQL Server that contains this Firewall Rule.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.Region
        {
            get
            {
                return this.Region();
            }
        }

        /// <summary>
        /// Gets the end IP address (in IPv4 format) of the Azure SQL Server Firewall Rule.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.EndIPAddress
        {
            get
            {
                return this.EndIPAddress();
            }
        }

        /// <summary>
        /// Gets kind of SQL Server that contains this Firewall Rule.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.Kind
        {
            get
            {
                return this.Kind();
            }
        }

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.ParentId
        {
            get
            {
                return this.ParentId();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this Firewall Rule belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Deletes the firewall rule.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.Delete()
        {
 
            this.Delete();
        }

        /// <summary>
        /// Deletes the firewall rule asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.DeleteAsync(CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(cancellationToken);
        }
    }
}