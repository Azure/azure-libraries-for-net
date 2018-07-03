// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.SqlServerKeyActionsDefinition;
    using System.Collections.Generic;

    internal partial class SqlServerKeyOperationsImpl 
    {
        /// <summary>
        /// Begins a definition for a new SQL Server Key resource.
        /// </summary>
        /// <return>The first stage of the resource definition.</return>
        SqlServerKeyOperations.Definition.IWithSqlServer Microsoft.Azure.Management.Sql.Fluent.ISqlServerKeyOperations.Define()
        {
            return this.Define();
        }

        /// <summary>
        /// Begins the definition of a new SQL Server key to be added to this server.
        /// </summary>
        /// <return>The first stage of the new SQL Server key definition.</return>
        SqlServerKeyOperations.Definition.IWithServerKeyType SqlServerKeyOperations.SqlServerKeyActionsDefinition.ISqlServerKeyActionsDefinition.Define()
        {
            return this.Define();
        }

        /// <summary>
        /// Deletes a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>.DeleteBySqlServer(string resourceGroupName, string sqlServerName, string name)
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
        Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>.GetBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            return this.GetBySqlServer(resourceGroupName, sqlServerName, name);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="sqlServer">The SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>.GetBySqlServer(ISqlServer sqlServer, string name)
        {
            return this.GetBySqlServer(sqlServer, name);
        }

        /// <summary>
        /// Lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of parent Azure SQL server.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>.ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.ListBySqlServer(resourceGroupName, sqlServerName);
        }

        /// <summary>
        /// Lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="sqlServer">The parent Azure SQL server.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>.ListBySqlServer(ISqlServer sqlServer)
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
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>.GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken)
        {
            return await this.GetBySqlServerAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="sqlServer">The SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>.GetBySqlServerAsync(ISqlServer sqlServer, string name, CancellationToken cancellationToken)
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
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>.DeleteBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteBySqlServerAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of parent Azure SQL server.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>.ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken)
        {
            return await this.ListBySqlServerAsync(resourceGroupName, sqlServerName, cancellationToken);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="sqlServer">The parent Azure SQL server.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>.ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken)
        {
            return await this.ListBySqlServerAsync(sqlServer, cancellationToken);
        }
    }
}