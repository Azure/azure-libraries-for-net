// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.SqlElasticPoolActionsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition;

    /// <summary>
    /// Grouping of the Azure SQL Elastic Pool common actions.
    /// </summary>
    public interface ISqlElasticPoolActionsDefinition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>
    {
        /// <summary>
        /// Begins the definition of a new SQL Elastic Pool to be added to this server.
        /// </summary>
        /// <param name="elasticPoolName">The name of the new SQL Elastic Pool.</param>
        /// <return>The first stage of the new SQL Elastic Pool definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithEdition Define(string elasticPoolName);
    }
}