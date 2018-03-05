// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// Response containing result of the Azure SQL Database import or export operation.
    /// </summary>
    public interface ISqlDatabaseImportExportResponse  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ImportExportResponseInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName
    {
        /// <summary>
        /// Gets the operation status last modified time.
        /// </summary>
        string LastModifiedTime { get; }

        /// <summary>
        /// Gets the operation queued time.
        /// </summary>
        string QueuedTime { get; }

        /// <summary>
        /// Gets the request type of the operation.
        /// </summary>
        string RequestType { get; }

        /// <summary>
        /// Gets the name of the database.
        /// </summary>
        string DatabaseName { get; }

        /// <summary>
        /// Gets the UUID of the operation.
        /// </summary>
        string RequestId { get; }

        /// <summary>
        /// Gets the blob uri.
        /// </summary>
        string BlobUri { get; }

        /// <summary>
        /// Gets the error message returned from the server.
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        /// Gets the name of the server.
        /// </summary>
        string ServerName { get; }

        /// <summary>
        /// Gets the status message returned from the server.
        /// </summary>
        string Status { get; }
    }
}