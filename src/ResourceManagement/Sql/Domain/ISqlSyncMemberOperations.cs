// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition;

    /// <summary>
    /// A representation of the Azure SQL Sync Member operations.
    /// </summary>
    public interface ISqlSyncMemberOperations  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SqlSyncMemberOperations.Definition.IWithSqlServer>
    {
        /// <summary>
        /// Gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server resource.</param>
        /// <param name="databaseName">The name of SQL Database parent resource.</param>
        /// <param name="syncGroupName">The name of the sync group on which the Sync Member is hosted.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember GetBySqlServer(string resourceGroupName, string sqlServerName, string databaseName, string syncGroupName, string name);

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="databaseName">The name of SQL Database parent resource.</param>
        /// <param name="syncGroupName">The name of the sync group on which the Sync Member is hosted.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember> GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string databaseName, string syncGroupName, string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}