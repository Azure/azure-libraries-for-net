// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.SqlServerDnsAliasActionsDefinition;
    using System.Collections.Generic;

    internal partial class SqlServerDnsAliasOperationsImpl 
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
        SqlServerDnsAliasOperations.Definition.IWithSqlServer Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SqlServerDnsAliasOperations.Definition.IWithSqlServer>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Acquires server DNS alias from another server.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group that contains the resource.</param>
        /// <param name="serverName">The name of the server that the alias is pointing to.</param>
        /// <param name="dnsAliasName">The name of the Server DNS alias.</param>
        /// <param name="sqlServerId">The id of the other SQL server that the DNS alias was pointing to.</param>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAliasOperations.Acquire(string resourceGroupName, string serverName, string dnsAliasName, string sqlServerId)
        {
 
            this.Acquire(resourceGroupName, serverName, dnsAliasName, sqlServerId);
        }

        /// <summary>
        /// Acquires server DNS alias from another server.
        /// </summary>
        /// <param name="dnsAliasName">The name of the Server DNS alias.</param>
        /// <param name="oldSqlServerId">The id of the other SQL server that the DNS alias was pointing to.</param>
        /// <param name="newSqlServerId">The id of the server that the alias is pointing to.</param>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAliasOperations.Acquire(string dnsAliasName, string oldSqlServerId, string newSqlServerId)
        {
 
            this.Acquire(dnsAliasName, oldSqlServerId, newSqlServerId);
        }

        /// <summary>
        /// Acquires server DNS alias from another server asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group that contains the resource.</param>
        /// <param name="serverName">The name of the server that the alias is pointing to.</param>
        /// <param name="dnsAliasName">The name of the Server DNS alias.</param>
        /// <param name="sqlServerId">The id of the other SQL server that the DNS alias was pointing to.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAliasOperations.AcquireAsync(string resourceGroupName, string serverName, string dnsAliasName, string sqlServerId, CancellationToken cancellationToken)
        {
 
            await this.AcquireAsync(resourceGroupName, serverName, dnsAliasName, sqlServerId, cancellationToken);
        }

        /// <summary>
        /// Acquires server DNS alias from another server asynchronously.
        /// </summary>
        /// <param name="dnsAliasName">The name of the Server DNS alias.</param>
        /// <param name="oldSqlServerId">The id of the other SQL server that the DNS alias was pointing to.</param>
        /// <param name="newSqlServerId">The id of the server that the alias is pointing to.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAliasOperations.AcquireAsync(string dnsAliasName, string oldSqlServerId, string newSqlServerId, CancellationToken cancellationToken)
        {
 
            await this.AcquireAsync(dnsAliasName, oldSqlServerId, newSqlServerId, cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>.GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken)
        {
            return await this.GetBySqlServerAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="sqlServer">The SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>.GetBySqlServerAsync(ISqlServer sqlServer, string name, CancellationToken cancellationToken)
        {
            return await this.GetBySqlServerAsync(sqlServer, name, cancellationToken);
        }

        /// <summary>
        /// Deletes a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>.DeleteBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
 
            this.DeleteBySqlServer(resourceGroupName, sqlServerName, name);
        }

        /// <summary>
        /// Asynchronously delete a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>.DeleteBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteBySqlServerAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of parent Azure SQL server.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>.ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken)
        {
            return await this.ListBySqlServerAsync(resourceGroupName, sqlServerName, cancellationToken);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="sqlServer">The parent Azure SQL server.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>.ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken)
        {
            return await this.ListBySqlServerAsync(sqlServer, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>.GetBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            return this.GetBySqlServer(resourceGroupName, sqlServerName, name);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="sqlServer">The SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>.GetBySqlServer(ISqlServer sqlServer, string name)
        {
            return this.GetBySqlServer(sqlServer, name);
        }

        /// <summary>
        /// Lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of parent Azure SQL server.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>.ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.ListBySqlServer(resourceGroupName, sqlServerName);
        }

        /// <summary>
        /// Lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="sqlServer">The parent Azure SQL server.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>.ListBySqlServer(ISqlServer sqlServer)
        {
            return this.ListBySqlServer(sqlServer);
        }

        /// <summary>
        /// Acquires server DNS alias from another server.
        /// </summary>
        /// <param name="dnsAliasName">The name of the Server DNS alias.</param>
        /// <param name="sqlServerId">The id of the other SQL server that the DNS alias was pointing to.</param>
        void SqlServerDnsAliasOperations.SqlServerDnsAliasActionsDefinition.ISqlServerDnsAliasActionsDefinition.Acquire(string dnsAliasName, string sqlServerId)
        {
 
            this.Acquire(dnsAliasName, sqlServerId);
        }

        /// <summary>
        /// Begins the definition of a new SQL Server DNS alias to be added to this server.
        /// </summary>
        /// <param name="serverDnsAliasName">The name of the new DNS alias to be created for the selected SQL server.</param>
        /// <return>The first stage of the new SQL Server DNS alias definition.</return>
        SqlServerDnsAliasOperations.Definition.IWithCreate SqlServerDnsAliasOperations.SqlServerDnsAliasActionsDefinition.ISqlServerDnsAliasActionsDefinition.Define(string serverDnsAliasName)
        {
            return this.Define(serverDnsAliasName);
        }

        /// <summary>
        /// Acquires server DNS alias from another server asynchronously.
        /// </summary>
        /// <param name="dnsAliasName">The name of the Server DNS alias.</param>
        /// <param name="sqlServerId">The id of the other SQL server that the DNS alias was pointing to.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task SqlServerDnsAliasOperations.SqlServerDnsAliasActionsDefinition.ISqlServerDnsAliasActionsDefinition.AcquireAsync(string dnsAliasName, string sqlServerId, CancellationToken cancellationToken)
        {
 
            await this.AcquireAsync(dnsAliasName, sqlServerId, cancellationToken);
        }
    }
}