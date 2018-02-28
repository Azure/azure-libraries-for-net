// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.SqlElasticPoolOperationsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface ISqlElasticPoolOperationsDefinition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithSqlServer,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithEdition,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithBasicEdition,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithStandardEdition,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithPremiumEdition
    {
    }
}