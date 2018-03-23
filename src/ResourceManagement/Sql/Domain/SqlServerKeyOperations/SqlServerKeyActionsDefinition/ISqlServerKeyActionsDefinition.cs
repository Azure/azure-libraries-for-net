// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.SqlServerKeyActionsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition;

    /// <summary>
    /// Grouping of the Azure SQL Server Key common actions.
    /// </summary>
    public interface ISqlServerKeyActionsDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>
    {
        /// <summary>
        /// Begins the definition of a new SQL Server key to be added to this server.
        /// </summary>
        /// <return>The first stage of the new SQL Server key definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition.IWithServerKeyType Define();
    }
}