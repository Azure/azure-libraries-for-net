// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.SqlServerDnsAliasOperationsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface ISqlServerDnsAliasOperationsDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.Definition.IWithSqlServer,
        Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.Definition.IWithCreate
    {
    }
}