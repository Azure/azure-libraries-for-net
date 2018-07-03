// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.SqlVirtualNetworkRuleActionsDefinition;
    using System.Collections.Generic;

    internal partial class SqlVirtualNetworkRuleOperationsImpl 
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        SqlVirtualNetworkRuleOperations.Definition.IWithSqlServer Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SqlVirtualNetworkRuleOperations.Definition.IWithSqlServer>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Begins the definition of a new SQL Virtual Network Rule to be added to this server.
        /// </summary>
        /// <param name="virtualNetworkRuleName">The name of the new SQL Virtual Network Rule.</param>
        /// <return>The first stage of the new SQL Virtual Network Rule definition.</return>
        SqlVirtualNetworkRuleOperations.Definition.IWithSubnet SqlVirtualNetworkRuleOperations.SqlVirtualNetworkRuleActionsDefinition.ISqlVirtualNetworkRuleActionsDefinition.Define(string virtualNetworkRuleName)
        {
            return this.Define(virtualNetworkRuleName);
        }

        /// <summary>
        /// Deletes a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>.DeleteBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
 
            this.DeleteBySqlServer(resourceGroupName, sqlServerName, name);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>.GetBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            return this.GetBySqlServer(resourceGroupName, sqlServerName, name);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="sqlServer">The SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>.GetBySqlServer(ISqlServer sqlServer, string name)
        {
            return this.GetBySqlServer(sqlServer, name);
        }

        /// <summary>
        /// Lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of parent Azure SQL server.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>.ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.ListBySqlServer(resourceGroupName, sqlServerName);
        }

        /// <summary>
        /// Lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="sqlServer">The parent Azure SQL server.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>.ListBySqlServer(ISqlServer sqlServer)
        {
            return this.ListBySqlServer(sqlServer);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>.GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken)
        {
            return await this.GetBySqlServerAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="sqlServer">The SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>.GetBySqlServerAsync(ISqlServer sqlServer, string name, CancellationToken cancellationToken)
        {
            return await this.GetBySqlServerAsync(sqlServer, name, cancellationToken);
        }

        /// <summary>
        /// Asynchronously delete a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>.DeleteBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteBySqlServerAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of parent Azure SQL server.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>.ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken)
        {
            return await this.ListBySqlServerAsync(resourceGroupName, sqlServerName, cancellationToken);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="sqlServer">The parent Azure SQL server.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>.ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken)
        {
            return await this.ListBySqlServerAsync(sqlServer, cancellationToken);
        }
    }
}