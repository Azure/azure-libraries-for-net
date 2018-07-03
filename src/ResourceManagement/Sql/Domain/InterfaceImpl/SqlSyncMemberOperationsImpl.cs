// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.SqlSyncMemberActionsDefinition;
    using System.Collections.Generic;

    internal partial class SqlSyncMemberOperationsImpl 
    {
        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="databaseName">The name of SQL Database parent resource.</param>
        /// <param name="syncGroupName">The name of the sync group on which the Sync Member is hosted.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember> Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMemberOperations.GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string databaseName, string syncGroupName, string name, CancellationToken cancellationToken)
        {
            return await this.GetBySqlServerAsync(resourceGroupName, sqlServerName, databaseName, syncGroupName, name, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server resource.</param>
        /// <param name="databaseName">The name of SQL Database parent resource.</param>
        /// <param name="syncGroupName">The name of the sync group on which the Sync Member is hosted.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMemberOperations.GetBySqlServer(string resourceGroupName, string sqlServerName, string databaseName, string syncGroupName, string name)
        {
            return this.GetBySqlServer(resourceGroupName, sqlServerName, databaseName, syncGroupName, name);
        }

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
        SqlSyncMemberOperations.Definition.IWithSqlServer Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SqlSyncMemberOperations.Definition.IWithSqlServer>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Asynchronously delete a child resource from Azure SQL server, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember>.DeleteByIdAsync(string id, CancellationToken cancellationToken)
        {
 
            await this.DeleteByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server.
        /// </summary>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember>.Get(string name)
        {
            return this.Get(name);
        }

        /// <summary>
        /// Deletes a child resource from Azure SQL server, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        void SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember>.DeleteById(string id)
        {
 
            this.DeleteById(id);
        }

        /// <summary>
        /// Lists Azure SQL child resources.
        /// </summary>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember> SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember>.List()
        {
            return this.List();
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server using the resource ID.
        /// </summary>
        /// <param name="id">The ID of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember> SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember>.GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server.
        /// </summary>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember> SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember>.GetAsync(string name, CancellationToken cancellationToken)
        {
            return await this.GetAsync(name, cancellationToken);
        }

        /// <summary>
        /// Asynchronously delete a child resource from Azure SQL server.
        /// </summary>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember>.DeleteAsync(string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(name, cancellationToken);
        }

        /// <summary>
        /// Deletes a child resource from Azure SQL server.
        /// </summary>
        /// <param name="name">The name of the child resource.</param>
        void SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember>.Delete(string name)
        {
 
            this.Delete(name);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL child resources.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<IReadOnlyList<ISqlSyncMember>> SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember>.ListAsync(CancellationToken cancellationToken)
        {
            return await this.ListAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the information about a child resource from Azure SQL server using the resource ID.
        /// </summary>
        /// <param name="id">The ID of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember>.GetById(string id)
        {
            return this.GetById(id);
        }

        /// <summary>
        /// Begins the definition of a new SQL Sync Member to be added to this server.
        /// </summary>
        /// <param name="syncMemberName">The name of the new SQL Sync Member.</param>
        /// <return>The first stage of the new SQL Virtual Network Rule definition.</return>
        SqlSyncMemberOperations.Definition.IWithMemberSqlServer SqlSyncMemberOperations.SqlSyncMemberActionsDefinition.ISqlSyncMemberActionsDefinition.Define(string syncMemberName)
        {
            return this.Define(syncMemberName);
        }
    }
}