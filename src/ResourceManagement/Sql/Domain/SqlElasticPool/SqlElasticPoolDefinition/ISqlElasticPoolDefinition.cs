// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.SqlElasticPoolDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface ISqlElasticPoolDefinition<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithEdition<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithBasicEdition<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithStandardEdition<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithPremiumEdition<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithAttach<ParentT>
    {
    }
}