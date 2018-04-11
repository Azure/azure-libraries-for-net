// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.SqlSyncMemberOperationsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface ISqlSyncMemberOperationsDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithSqlServer,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithSyncMemberDatabase,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithSyncGroupName,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithMemberSqlServer,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithMemberSqlDatabase,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithMemberUserName,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithMemberPassword,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithMemberDatabaseType,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithSyncDirection,
        Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition.IWithCreate
    {
    }
}