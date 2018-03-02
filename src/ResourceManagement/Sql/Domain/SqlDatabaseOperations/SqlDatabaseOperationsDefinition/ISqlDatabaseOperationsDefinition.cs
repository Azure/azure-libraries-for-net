// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.SqlDatabaseOperationsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface ISqlDatabaseOperationsDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IBlank,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithSqlServer,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithAllDifferentOptions,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithElasticPoolName,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithRestorableDroppedDatabase,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithImportFrom,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithStorageKey,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithAuthentication,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithRestorePointDatabase,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithSourceDatabaseId,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateMode,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAllOptions,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateFinal
    {
    }
}