// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.SqlServerKeyOperationsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface ISqlServerKeyOperationsDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition.IWithSqlServer,
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition.IWithServerKeyType,
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition.IWithThumbprint,
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition.IWithCreationDate,
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition.IWithCreate
    {
    }
}