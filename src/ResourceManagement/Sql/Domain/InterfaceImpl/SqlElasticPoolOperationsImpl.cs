// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.SqlElasticPoolActionsDefinition;
    using System.Collections.Generic;

    internal partial class SqlElasticPoolOperationsImpl 
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
        SqlElasticPoolOperations.Definition.IWithSqlServer Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SqlElasticPoolOperations.Definition.IWithSqlServer>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL child resources.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<IReadOnlyList<ISqlElasticPool>> SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.ListAsync(CancellationToken cancellationToken)
        {
            return await this.ListAsync(cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server using the resource ID.
        /// </summary>
        /// <param name="id">The ID of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server.
        /// </summary>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.GetAsync(string name, CancellationToken cancellationToken)
        {
            return await this.GetAsync(name, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server using the resource ID.
        /// </summary>
        /// <param name="id">The ID of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.GetById(string id)
        {
            return this.GetById(id);
        }

        /// <summary>
        /// Asynchronously delete a child resource from Azure SQL server, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.DeleteByIdAsync(string id, CancellationToken cancellationToken)
        {
 
            await this.DeleteByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Deletes a child resource from Azure SQL server.
        /// </summary>
        /// <param name="name">The name of the child resource.</param>
        void SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.Delete(string name)
        {
 
            this.Delete(name);
        }

        /// <summary>
        /// Asynchronously delete a child resource from Azure SQL server.
        /// </summary>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.DeleteAsync(string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(name, cancellationToken);
        }

        /// <summary>
        /// Lists Azure SQL child resources.
        /// </summary>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.List()
        {
            return this.List();
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server.
        /// </summary>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.Get(string name)
        {
            return this.Get(name);
        }

        /// <summary>
        /// Deletes a child resource from Azure SQL server, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        void SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.DeleteById(string id)
        {
 
            this.DeleteById(id);
        }

        /// <summary>
        /// Begins the definition of a new SQL Elastic Pool to be added to this server.
        /// </summary>
        /// <param name="elasticPoolName">The name of the new SQL Elastic Pool.</param>
        /// <return>The first stage of the new SQL Elastic Pool definition.</return>
        SqlElasticPoolOperations.Definition.IWithEdition SqlElasticPoolOperations.SqlElasticPoolActionsDefinition.ISqlElasticPoolActionsDefinition.Define(string elasticPoolName)
        {
            return this.Define(elasticPoolName);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.GetBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            return this.GetBySqlServer(resourceGroupName, sqlServerName, name);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="sqlServer">The SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.GetBySqlServer(ISqlServer sqlServer, string name)
        {
            return this.GetBySqlServer(sqlServer, name);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server using the resource ID.
        /// </summary>
        /// <param name="id">The ID of the resource.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of parent Azure SQL server.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.ListBySqlServer(resourceGroupName, sqlServerName);
        }

        /// <summary>
        /// Lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="sqlServer">The parent Azure SQL server.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.ListBySqlServer(ISqlServer sqlServer)
        {
            return this.ListBySqlServer(sqlServer);
        }

        /// <summary>
        /// Deletes a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.DeleteBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
 
            this.DeleteBySqlServer(resourceGroupName, sqlServerName, name);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken)
        {
            return await this.GetBySqlServerAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="sqlServer">The SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.GetBySqlServerAsync(ISqlServer sqlServer, string name, CancellationToken cancellationToken)
        {
            return await this.GetBySqlServerAsync(sqlServer, name, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server using the resource ID.
        /// </summary>
        /// <param name="id">The ID of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.GetById(string id)
        {
            return this.GetById(id);
        }

        /// <summary>
        /// Asynchronously delete a child resource from Azure SQL server, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.DeleteByIdAsync(string id, CancellationToken cancellationToken)
        {
 
            await this.DeleteByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of parent Azure SQL server.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken)
        {
            return await this.ListBySqlServerAsync(resourceGroupName, sqlServerName, cancellationToken);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL child resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="sqlServer">The parent Azure SQL server.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>> Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken)
        {
            return await this.ListBySqlServerAsync(sqlServer, cancellationToken);
        }

        /// <summary>
        /// Asynchronously delete a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.DeleteBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteBySqlServerAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        /// <summary>
        /// Deletes a child resource from Azure SQL server, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.DeleteById(string id)
        {
 
            this.DeleteById(id);
        }
    }
}