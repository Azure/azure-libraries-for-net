// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition;

    /// <summary>
    /// A representation of the Azure SQL Sync Group operations.
    /// </summary>
    public interface ISqlSyncGroupOperations  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SqlSyncGroupOperations.Definition.IWithSqlServer>
    {
        /// <summary>
        /// Gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server resource.</param>
        /// <param name="databaseName">The name of SQL Database parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup GetBySqlServer(string resourceGroupName, string sqlServerName, string databaseName, string name);

        /// <summary>
        /// Gets a collection of sync database ids.
        /// </summary>
        /// <param name="locationName">The name of the region where the resource is located.</param>
        /// <return>A paged list of database IDs if successful.</return>
        Task<IEnumerable<string>> ListSyncDatabaseIdsAsync(string locationName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a collection of sync database ids.
        /// </summary>
        /// <param name="region">The region where the resource is located.</param>
        /// <return>A paged list of database IDs if successful.</return>
        Task<IEnumerable<string>> ListSyncDatabaseIdsAsync(Region region, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Asynchronously gets the information about a child resource from Azure SQL server, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <param name="databaseName">The name of SQL Database parent resource.</param>
        /// <param name="name">The name of the child resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup> GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string databaseName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a collection of sync database ids.
        /// </summary>
        /// <param name="locationName">The name of the region where the resource is located.</param>
        /// <return>A paged list of database IDs if successful.</return>
        System.Collections.Generic.IEnumerable<string> ListSyncDatabaseIds(string locationName);

        /// <summary>
        /// Gets a collection of sync database ids.
        /// </summary>
        /// <param name="region">The region where the resource is located.</param>
        /// <return>A paged list of database IDs if successful.</return>
        System.Collections.Generic.IEnumerable<string> ListSyncDatabaseIds(Region region);
    }
}