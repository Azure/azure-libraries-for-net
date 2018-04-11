// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.SqlSyncMemberActionsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition;

    /// <summary>
    /// Grouping of the Azure SQL Server Sync Member common actions.
    /// </summary>
    public interface ISqlSyncMemberActionsDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember>
    {
        /// <summary>
        /// Begins the definition of a new SQL Sync Member to be added to this server.
        /// </summary>
        /// <param name="syncMemberName">The name of the new SQL Sync Member.</param>
        /// <return>The first stage of the new SQL Virtual Network Rule definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithMemberSqlServer Define(string syncMemberName);
    }
}