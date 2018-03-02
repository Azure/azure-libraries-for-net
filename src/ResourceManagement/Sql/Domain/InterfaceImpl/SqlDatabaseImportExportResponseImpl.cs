// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    internal partial class SqlDatabaseImportExportResponseImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the name of the server.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse.ServerName
        {
            get
            {
                return this.ServerName();
            }
        }

        /// <summary>
        /// Gets the UUID of the operation.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse.RequestId
        {
            get
            {
                return this.RequestId();
            }
        }

        /// <summary>
        /// Gets the operation queued time.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse.QueuedTime
        {
            get
            {
                return this.QueuedTime();
            }
        }

        /// <summary>
        /// Gets the blob uri.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse.BlobUri
        {
            get
            {
                return this.BlobUri();
            }
        }

        /// <summary>
        /// Gets the status message returned from the server.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// Gets the operation status last modified time.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse.LastModifiedTime
        {
            get
            {
                return this.LastModifiedTime();
            }
        }

        /// <summary>
        /// Gets the request type of the operation.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse.RequestType
        {
            get
            {
                return this.RequestType();
            }
        }

        /// <summary>
        /// Gets the error message returned from the server.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse.ErrorMessage
        {
            get
            {
                return this.ErrorMessage();
            }
        }

        /// <summary>
        /// Gets the name of the database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse.DatabaseName
        {
            get
            {
                return this.DatabaseName();
            }
        }

        /// <summary>
        /// Gets the index key.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable.Key
        {
            get
            {
                return this.Key();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }
    }
}