// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition;

    /// <summary>
    /// A representation of the Azure SQL Server Key operations.
    /// </summary>
    public interface ISqlServerKeyOperations  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>
    {
        /// <summary>
        /// Begins a definition for a new SQL Server Key resource.
        /// </summary>
        /// <return>The first stage of the resource definition.</return>
        SqlServerKeyOperations.Definition.IWithSqlServer Define();
    }
}