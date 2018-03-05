// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImportRequest.SqlDatabaseImportRequestDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImportRequest.Definition;

    /// <summary>
    /// The entirety of database import operation definition.
    /// </summary>
    public interface ISqlDatabaseImportRequestDefinition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImportRequest.Definition.IImportFrom,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImportRequest.Definition.IWithStorageTypeAndKey,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImportRequest.Definition.IWithAuthenticationTypeAndLoginPassword,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImportRequest.Definition.IWithExecute
    {
    }
}