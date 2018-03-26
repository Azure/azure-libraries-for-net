// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The final stage of the SQL Server DNS alias definition.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>
    {
    }

    /// <summary>
    /// The first stage of the SQL Server DNS alias definition.
    /// </summary>
    public interface IWithSqlServer  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the parent SQL server for the new Server DNS alias.
        /// </summary>
        /// <param name="sqlServerId">The parent SQL server ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.Definition.IWithCreate WithExistingSqlServerId(string sqlServerId);

        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.Definition.IWithCreate WithExistingSqlServer(string resourceGroupName, string sqlServerName);

        /// <summary>
        /// Sets the parent SQL server for the new Server DNS alias.
        /// </summary>
        /// <param name="sqlServer">The parent SQL server.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.Definition.IWithCreate WithExistingSqlServer(ISqlServer sqlServer);
    }
}