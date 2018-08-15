// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.SqlFailoverGroupActionsDefinition;
    using System.Collections.Generic;

    internal partial class SqlFailoverGroupOperationsImpl 
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
        SqlFailoverGroupOperations.Definition.IWithSqlServer Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SqlFailoverGroupOperations.Definition.IWithSqlServer>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Fails over from the current primary server to this server. This operation might result in data loss.
        /// </summary>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>The SqlFailoverGroup object.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup SqlFailoverGroupOperations.SqlFailoverGroupActionsDefinition.ISqlFailoverGroupActionsDefinition.ForceFailoverAllowDataLoss(string failoverGroupName)
        {
            return this.ForceFailoverAllowDataLoss(failoverGroupName);
        }

        /// <summary>
        /// Begins the definition of a new SQL Failover Group to be added to this server.
        /// </summary>
        /// <param name="failoverGroupName">The name of the new Failover Group to be created for the selected SQL server.</param>
        /// <return>The first stage of the new SQL Failover Group definition.</return>
        SqlFailoverGroupOperations.Definition.IWithReadWriteEndpointPolicy SqlFailoverGroupOperations.SqlFailoverGroupActionsDefinition.ISqlFailoverGroupActionsDefinition.Define(string failoverGroupName)
        {
            return this.Define(failoverGroupName);
        }

        /// <summary>
        /// Asynchronously fails over from the current primary server to this server.
        /// </summary>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>A representation of the deferred computation of this call returning the SqlFailoverGroup object.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> SqlFailoverGroupOperations.SqlFailoverGroupActionsDefinition.ISqlFailoverGroupActionsDefinition.FailoverAsync(string failoverGroupName, CancellationToken cancellationToken)
        {
            return await this.FailoverAsync(failoverGroupName, cancellationToken);
        }

        /// <summary>
        /// Fails over from the current primary server to this server. This operation might result in data loss.
        /// </summary>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>A representation of the deferred computation of this call returning the SqlFailoverGroup object.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> SqlFailoverGroupOperations.SqlFailoverGroupActionsDefinition.ISqlFailoverGroupActionsDefinition.ForceFailoverAllowDataLossAsync(string failoverGroupName, CancellationToken cancellationToken)
        {
            return await this.ForceFailoverAllowDataLossAsync(failoverGroupName, cancellationToken);
        }

        /// <summary>
        /// Fails over from the current primary server to this server.
        /// </summary>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>The SqlFailoverGroup object.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup SqlFailoverGroupOperations.SqlFailoverGroupActionsDefinition.ISqlFailoverGroupActionsDefinition.Failover(string failoverGroupName)
        {
            return this.Failover(failoverGroupName);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>.GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken)
        {
            return await this.GetBySqlServerAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="sqlServer">The SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>.GetBySqlServerAsync(ISqlServer sqlServer, string name, CancellationToken cancellationToken)
        {
            return await this.GetBySqlServerAsync(sqlServer, name, cancellationToken);
        }

        /// <summary>
        /// Deletes a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>.DeleteBySqlServer(string resourceGroupName, string sqlServerName, string name)
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
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>.DeleteBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteBySqlServerAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>.GetBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            return this.GetBySqlServer(resourceGroupName, sqlServerName, name);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="sqlServer">The SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>.GetBySqlServer(ISqlServer sqlServer, string name)
        {
            return this.GetBySqlServer(sqlServer, name);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of parent Azure SQL server.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>.ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken)
        {
            return await this.ListBySqlServerAsync(resourceGroupName, sqlServerName, cancellationToken);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="sqlServer">The parent Azure SQL server.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>.ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken)
        {
            return await this.ListBySqlServerAsync(sqlServer, cancellationToken);
        }

        /// <summary>
        /// Lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of parent Azure SQL server.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>.ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.ListBySqlServer(resourceGroupName, sqlServerName);
        }

        /// <summary>
        /// Lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="sqlServer">The parent Azure SQL server.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>.ListBySqlServer(ISqlServer sqlServer)
        {
            return this.ListBySqlServer(sqlServer);
        }

        /// <summary>
        /// Fails over from the current primary server to this server. This operation might result in data loss.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group that contains the resource.</param>
        /// <param name="serverName">The name of the server containing the failover group.</param>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>The SqlFailoverGroup object.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroupOperations.ForceFailoverAllowDataLoss(string resourceGroupName, string serverName, string failoverGroupName)
        {
            return this.ForceFailoverAllowDataLoss(resourceGroupName, serverName, failoverGroupName);
        }

        /// <summary>
        /// Asynchronously fails over from the current primary server to this server.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group that contains the resource.</param>
        /// <param name="serverName">The name of the server containing the failover group.</param>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>A representation of the deferred computation of this call returning the SqlFailoverGroup object.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroupOperations.FailoverAsync(string resourceGroupName, string serverName, string failoverGroupName, CancellationToken cancellationToken)
        {
            return await this.FailoverAsync(resourceGroupName, serverName, failoverGroupName, cancellationToken);
        }

        /// <summary>
        /// Fails over from the current primary server to this server. This operation might result in data loss.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group that contains the resource.</param>
        /// <param name="serverName">The name of the server containing the failover group.</param>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>A representation of the deferred computation of this call returning the SqlFailoverGroup object.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroupOperations.ForceFailoverAllowDataLossAsync(string resourceGroupName, string serverName, string failoverGroupName, CancellationToken cancellationToken)
        {
            return await this.ForceFailoverAllowDataLossAsync(resourceGroupName, serverName, failoverGroupName, cancellationToken);
        }

        /// <summary>
        /// Fails over from the current primary server to this server.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group that contains the resource.</param>
        /// <param name="serverName">The name of the server containing the failover group.</param>
        /// <param name="failoverGroupName">The name of the failover group.</param>
        /// <return>The SqlFailoverGroup object.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroupOperations.Failover(string resourceGroupName, string serverName, string failoverGroupName)
        {
            return this.Failover(resourceGroupName, serverName, failoverGroupName);
        }
    }
}