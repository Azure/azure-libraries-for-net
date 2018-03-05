// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.SqlDatabaseDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface ISqlDatabaseDefinition<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAllDifferentOptions<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithElasticPoolName<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithRestorableDroppedDatabase<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithImportFrom<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithStorageKey<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAuthentication<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithRestorePointDatabase<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithSourceDatabaseId<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithCreateMode<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAllOptions<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachFinal<ParentT>
    {
    }
}