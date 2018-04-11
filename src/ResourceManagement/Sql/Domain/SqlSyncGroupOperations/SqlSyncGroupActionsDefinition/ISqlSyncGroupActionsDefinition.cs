// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.SqlSyncGroupActionsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition;

    /// <summary>
    /// Grouping of the Azure SQL Server Sync Group common actions.
    /// </summary>
    public interface ISqlSyncGroupActionsDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>
    {
        /// <summary>
        /// Begins the definition of a new SQL Sync Group to be added to this server.
        /// </summary>
        /// <param name="syncGroupName">The name of the new SQL Sync Group.</param>
        /// <return>The first stage of the new SQL Virtual Network Rule definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithSyncDatabaseId Define(string syncGroupName);
    }
}