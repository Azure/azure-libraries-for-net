// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImportRequest.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImportRequest.SqlDatabaseImportRequestDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Storage.Fluent;

    internal partial class SqlDatabaseImportRequestImpl 
    {
        /// <param name="storageUri">The storage URI to use.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseImportRequest.Definition.IWithStorageTypeAndKey SqlDatabaseImportRequest.Definition.IImportFrom.ImportFrom(string storageUri)
        {
            return this.ImportFrom(storageUri);
        }

        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        SqlDatabaseImportRequest.Definition.IWithAuthenticationTypeAndLoginPassword SqlDatabaseImportRequest.Definition.IImportFrom.ImportFrom(IStorageAccount storageAccount, string containerName, string fileName)
        {
            return this.ImportFrom(storageAccount, containerName, fileName);
        }

        /// <param name="sharedAccessKey">The shared access key to use; it must be preceded with a "?.".</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseImportRequest.Definition.IWithAuthenticationTypeAndLoginPassword SqlDatabaseImportRequest.Definition.IWithStorageTypeAndKey.WithSharedAccessKey(string sharedAccessKey)
        {
            return this.WithSharedAccessKey(sharedAccessKey);
        }

        /// <param name="storageAccessKey">The storage access key to use.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseImportRequest.Definition.IWithAuthenticationTypeAndLoginPassword SqlDatabaseImportRequest.Definition.IWithStorageTypeAndKey.WithStorageAccessKey(string storageAccessKey)
        {
            return this.WithStorageAccessKey(storageAccessKey);
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

        /// <param name="administratorLogin">The Active Directory administrator login.</param>
        /// <param name="administratorPassword">The Active Directory administrator password.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseImportRequest.Definition.IWithExecute SqlDatabaseImportRequest.Definition.IWithAuthenticationTypeAndLoginPassword.WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            return this.WithActiveDirectoryLoginAndPassword(administratorLogin, administratorPassword);
        }

        /// <param name="administratorLogin">The SQL administrator login.</param>
        /// <param name="administratorPassword">The SQL administrator password.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseImportRequest.Definition.IWithExecute SqlDatabaseImportRequest.Definition.IWithAuthenticationTypeAndLoginPassword.WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            return this.WithSqlAdministratorLoginAndPassword(administratorLogin, administratorPassword);
        }
    }
}