// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// Sets the storage URI to use.
    /// </summary>
    public interface IExportTo 
    {
        /// <param name="storageUri">The storage URI to use.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition.IWithStorageTypeAndKey ExportTo(string storageUri);

        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword ExportTo(IStorageAccount storageAccount, string containerName, string fileName);

        /// <param name="storageAccountCreatable">A storage account to be created as part of this execution flow.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword ExportTo(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable, string containerName, string fileName);
    }

    /// <summary>
    /// Sets the storage key type and value to use.
    /// </summary>
    public interface IWithStorageTypeAndKey 
    {
        /// <param name="storageAccessKey">The storage access key to use.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword WithStorageAccessKey(string storageAccessKey);

        /// <param name="sharedAccessKey">The shared access key to use; it must be preceded with a "?.".</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword WithSharedAccessKey(string sharedAccessKey);
    }

    /// <summary>
    /// Sets the authentication type and SQL or Active Directory administrator login and password.
    /// </summary>
    public interface IWithAuthenticationTypeAndLoginPassword 
    {
        /// <param name="administratorLogin">The Active Directory administrator login.</param>
        /// <param name="administratorPassword">The Active Directory administrator password.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition.IWithExecute WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword);

        /// <param name="administratorLogin">The SQL administrator login.</param>
        /// <param name="administratorPassword">The SQL administrator password.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition.IWithExecute WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for execution, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithExecute  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse>
    {
    }
}