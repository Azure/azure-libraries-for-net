// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.SqlDatabaseExportRequestDefinition;
    using Microsoft.Azure.Management.Storage.Fluent;

    internal partial class SqlDatabaseExportRequestImpl 
    {
        /// <param name="storageUri">The storage URI to use.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseExportRequest.Definition.IWithStorageTypeAndKey SqlDatabaseExportRequest.Definition.IExportTo.ExportTo(string storageUri)
        {
            return this.ExportTo(storageUri);
        }

        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword SqlDatabaseExportRequest.Definition.IExportTo.ExportTo(IStorageAccount storageAccount, string containerName, string fileName)
        {
            return this.ExportTo(storageAccount, containerName, fileName);
        }

        /// <param name="storageAccountCreatable">A storage account to be created as part of this execution flow.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword SqlDatabaseExportRequest.Definition.IExportTo.ExportTo(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable, string containerName, string fileName)
        {
            return this.ExportTo(storageAccountCreatable, containerName, fileName);
        }

        /// <param name="sharedAccessKey">The shared access key to use; it must be preceded with a "?.".</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword SqlDatabaseExportRequest.Definition.IWithStorageTypeAndKey.WithSharedAccessKey(string sharedAccessKey)
        {
            return this.WithSharedAccessKey(sharedAccessKey);
        }

        /// <param name="storageAccessKey">The storage access key to use.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword SqlDatabaseExportRequest.Definition.IWithStorageTypeAndKey.WithStorageAccessKey(string storageAccessKey)
        {
            return this.WithStorageAccessKey(storageAccessKey);
        }

        /// <param name="administratorLogin">The Active Directory administrator login.</param>
        /// <param name="administratorPassword">The Active Directory administrator password.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseExportRequest.Definition.IWithExecute SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword.WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            return this.WithActiveDirectoryLoginAndPassword(administratorLogin, administratorPassword);
        }

        /// <param name="administratorLogin">The SQL administrator login.</param>
        /// <param name="administratorPassword">The SQL administrator password.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseExportRequest.Definition.IWithExecute SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword.WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            return this.WithSqlAdministratorLoginAndPassword(administratorLogin, administratorPassword);
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>.Parent
        {
            get
            {
                return this.Parent();
            }
        }
    }
}