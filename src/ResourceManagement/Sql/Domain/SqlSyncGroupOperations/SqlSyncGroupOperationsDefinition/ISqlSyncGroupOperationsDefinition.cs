// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.SqlSyncGroupOperationsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface ISqlSyncGroupOperationsDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithSqlServer,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithSyncGroupDatabase,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithSyncDatabaseId,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithDatabaseUserName,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithDatabasePassword,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithConflictResolutionPolicy,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithInterval,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithSchema,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition.IWithCreate
    {
    }
}