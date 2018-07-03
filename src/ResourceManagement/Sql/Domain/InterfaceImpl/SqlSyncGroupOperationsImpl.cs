// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.SqlSyncGroupActionsDefinition;

    internal partial class SqlSyncGroupOperationsImpl 
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
        SqlSyncGroupOperations.Definition.IWithSqlServer Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SqlSyncGroupOperations.Definition.IWithSqlServer>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Begins the definition of a new SQL Sync Group to be added to this server.
        /// </summary>
        /// <param name="syncGroupName">The name of the new SQL Sync Group.</param>
        /// <return>The first stage of the new SQL Virtual Network Rule definition.</return>
        SqlSyncGroupOperations.Definition.IWithSyncDatabaseId SqlSyncGroupOperations.SqlSyncGroupActionsDefinition.ISqlSyncGroupActionsDefinition.Define(string syncGroupName)
        {
            return this.Define(syncGroupName);
        }

        /// <summary>
        /// Asynchronously delete a child resource from Azure SQL server, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>.DeleteByIdAsync(string id, CancellationToken cancellationToken)
        {
 
            await this.DeleteByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server.
        /// </summary>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>.Get(string name)
        {
            return this.Get(name);
        }

        /// <summary>
        /// Deletes a child resource from Azure SQL server, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        void SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>.DeleteById(string id)
        {
 
            this.DeleteById(id);
        }

        /// <summary>
        /// Lists Azure SQL child resources.
        /// </summary>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup> SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>.List()
        {
            return this.List();
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server using the resource ID.
        /// </summary>
        /// <param name="id">The ID of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup> SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>.GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server.
        /// </summary>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup> SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>.GetAsync(string name, CancellationToken cancellationToken)
        {
            return await this.GetAsync(name, cancellationToken);
        }

        /// <summary>
        /// Asynchronously delete a child resource from Azure SQL server.
        /// </summary>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>.DeleteAsync(string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(name, cancellationToken);
        }

        /// <summary>
        /// Deletes a child resource from Azure SQL server.
        /// </summary>
        /// <param name="name">The name of the child resource.</param>
        void SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>.Delete(string name)
        {
 
            this.Delete(name);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL child resources.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<IReadOnlyList<ISqlSyncGroup>> SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>.ListAsync(CancellationToken cancellationToken)
        {
            return await this.ListAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server using the resource ID.
        /// </summary>
        /// <param name="id">The ID of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>.GetById(string id)
        {
            return this.GetById(id);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="databaseName">The name of SQL Database parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup> Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupOperations.GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string databaseName, string name, CancellationToken cancellationToken)
        {
            return await this.GetBySqlServerAsync(resourceGroupName, sqlServerName, databaseName, name, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of sync database ids.
        /// </summary>
        /// <param name="locationName">The name of the region where the resource is located.</param>
        /// <return>A paged list of database IDs if successful.</return>
        async Task<IEnumerable<string>> Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupOperations.ListSyncDatabaseIdsAsync(string locationName, CancellationToken cancellationToken)
        {
            return await this.ListSyncDatabaseIdsAsync(locationName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of sync database ids.
        /// </summary>
        /// <param name="region">The region where the resource is located.</param>
        /// <return>A paged list of database IDs if successful.</return>
        async Task<IEnumerable<string>> Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupOperations.ListSyncDatabaseIdsAsync(Region region, CancellationToken cancellationToken)
        {
            return await this.ListSyncDatabaseIdsAsync(region, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server resource.</param>
        /// <param name="databaseName">The name of SQL Database parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupOperations.GetBySqlServer(string resourceGroupName, string sqlServerName, string databaseName, string name)
        {
            return this.GetBySqlServer(resourceGroupName, sqlServerName, databaseName, name);
        }

        /// <summary>
        /// Gets a collection of sync database ids.
        /// </summary>
        /// <param name="locationName">The name of the region where the resource is located.</param>
        /// <return>A paged list of database IDs if successful.</return>
        System.Collections.Generic.IEnumerable<string> Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupOperations.ListSyncDatabaseIds(string locationName)
        {
            return this.ListSyncDatabaseIds(locationName);
        }

        /// <summary>
        /// Gets a collection of sync database ids.
        /// </summary>
        /// <param name="region">The region where the resource is located.</param>
        /// <return>A paged list of database IDs if successful.</return>
        System.Collections.Generic.IEnumerable<string> Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupOperations.ListSyncDatabaseIds(Region region)
        {
            return this.ListSyncDatabaseIds(region);
        }
    }
}