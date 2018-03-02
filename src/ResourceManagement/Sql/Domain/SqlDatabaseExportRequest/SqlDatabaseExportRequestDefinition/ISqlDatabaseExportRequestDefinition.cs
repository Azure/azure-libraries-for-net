// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.SqlDatabaseExportRequestDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition;

    /// <summary>
    /// The entirety of database export operation definition.
    /// </summary>
    public interface ISqlDatabaseExportRequestDefinition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition.IExportTo,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition.IWithStorageTypeAndKey,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition.IWithExecute
    {
    }
}