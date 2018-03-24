// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.SqlFailoverGroupOperationsDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface ISqlFailoverGroupOperationsDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithSqlServer,
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithReadWriteEndpointPolicy,
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithReadOnlyEndpointPolicy,
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithPartnerServer,
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithDatabase,
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithCreate
    {
    }
}