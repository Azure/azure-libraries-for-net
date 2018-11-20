// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// A web app diagnostic log configuration in a web app.
    /// </summary>
    public interface IWebAppDiagnosticLogs  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SiteLogsConfigInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.AppService.Fluent.IWebAppBase>
    {

        /// <summary>
        /// Gets application log level on file system.
        /// </summary>
        Models.LogLevel ApplicationLoggingFileSystemLogLevel { get; }

        /// <summary>
        /// Gets Azure Storage Blob container URL for storing application logs.
        /// </summary>
        string ApplicationLoggingStorageBlobContainer { get; }

        /// <summary>
        /// Gets application log level on Azure Storage Blob.
        /// </summary>
        Models.LogLevel ApplicationLoggingStorageBlobLogLevel { get; }

        /// <summary>
        /// Gets application log retention days on Azure Storage Blob.
        /// </summary>
        int ApplicationLoggingStorageBlobRetentionDays { get; }

        /// <summary>
        /// Gets if detailed error messages should be gathered.
        /// </summary>
        bool DetailedErrorMessages { get; }

        /// <summary>
        /// Gets if diagnostic information on failed requests should be gathered.
        /// </summary>
        bool FailedRequestsTracing { get; }

        /// <summary>
        /// Gets web server quota in MB on file system.
        /// </summary>
        int WebServerLoggingFileSystemQuotaInMB { get; }

        /// <summary>
        /// Gets web server log retention days on file system.
        /// </summary>
        int WebServerLoggingFileSystemRetentionDays { get; }

        /// <summary>
        /// Gets Azure Storage Blob container URL for storing web server logs.
        /// </summary>
        string WebServerLoggingStorageBlobContainer { get; }

        /// <summary>
        /// Gets web server log retention days on Azure Storage Blob.
        /// </summary>
        int WebServerLoggingStorageBlobRetentionDays { get; }
    }
}