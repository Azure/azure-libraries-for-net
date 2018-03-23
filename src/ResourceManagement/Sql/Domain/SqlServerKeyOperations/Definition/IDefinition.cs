// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition
{
    using Microsoft.Azure.Management.Sql.Fluent;
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The SQL Server Key definition to set the server key type.
    /// </summary>
    public interface IWithServerKeyType  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the server key type as "AzureKeyVault" and the URI to the key.
        /// </summary>
        /// <param name="uri">The URI of the server key.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition.IWithCreate WithAzureKeyVaultKey(string uri);
    }

    /// <summary>
    /// The first stage of the SQL Server Key definition.
    /// </summary>
    public interface IWithSqlServer  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the parent SQL server for the new Server Key.
        /// </summary>
        /// <param name="sqlServerId">The parent SQL server ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition.IWithServerKeyType WithExistingSqlServerId(string sqlServerId);

        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition.IWithServerKeyType WithExistingSqlServer(string resourceGroupName, string sqlServerName);

        /// <summary>
        /// Sets the parent SQL server for the new Server Key.
        /// </summary>
        /// <param name="sqlServer">The parent SQL server.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition.IWithServerKeyType WithExistingSqlServer(ISqlServer sqlServer);
    }

    /// <summary>
    /// The SQL Server Key definition to set the server key creation date.
    /// </summary>
    public interface IWithCreationDate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the server key creation date.
        /// </summary>
        /// <param name="creationDate">The server key creation date.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition.IWithCreate WithCreationDate(DateTime creationDate);
    }

    /// <summary>
    /// The SQL Server Key definition to set the thumbprint.
    /// </summary>
    public interface IWithThumbprint  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the thumbprint of the server key.
        /// </summary>
        /// <param name="thumbprint">The thumbprint of the server key.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition.IWithCreate WithThumbprint(string thumbprint);
    }

    /// <summary>
    /// The final stage of the SQL Server Key definition.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition.IWithThumbprint,
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition.IWithCreationDate,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>
    {
    }
}