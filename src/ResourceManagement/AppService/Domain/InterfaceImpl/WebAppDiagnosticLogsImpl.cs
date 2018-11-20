// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>
    {
        IWithCreate<FluentT> ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<IWithCreate<FluentT>>.Attach()
        {
            return this.Attach();
        }

        WebAppBase.Update.IUpdate<FluentT> ResourceManager.Fluent.Core.ChildResourceActions.ISettable<WebAppBase.Update.IUpdate<FluentT>>.Parent()
        {
            return this.Attach();
        }

        /// <summary>
        /// Gets application log level on file system.
        /// </summary>
        Models.LogLevel Microsoft.Azure.Management.AppService.Fluent.IWebAppDiagnosticLogs.ApplicationLoggingFileSystemLogLevel
        {
            get
            {
                return this.ApplicationLoggingFileSystemLogLevel();
            }
        }

        /// <summary>
        /// Gets Azure Storage Blob container URL for storing application logs.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppDiagnosticLogs.ApplicationLoggingStorageBlobContainer
        {
            get
            {
                return this.ApplicationLoggingStorageBlobContainer();
            }
        }

        /// <summary>
        /// Gets application log level on Azure Storage Blob.
        /// </summary>
        Models.LogLevel Microsoft.Azure.Management.AppService.Fluent.IWebAppDiagnosticLogs.ApplicationLoggingStorageBlobLogLevel
        {
            get
            {
                return this.ApplicationLoggingStorageBlobLogLevel();
            }
        }

        /// <summary>
        /// Gets application log retention days on Azure Storage Blob.
        /// </summary>
        int Microsoft.Azure.Management.AppService.Fluent.IWebAppDiagnosticLogs.ApplicationLoggingStorageBlobRetentionDays
        {
            get
            {
                return this.ApplicationLoggingStorageBlobRetentionDays();
            }
        }

        /// <summary>
        /// Gets if detailed error messages should be gathered.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppDiagnosticLogs.DetailedErrorMessages
        {
            get
            {
                return this.DetailedErrorMessages();
            }
        }

        /// <summary>
        /// Gets if diagnostic information on failed requests should be gathered.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppDiagnosticLogs.FailedRequestsTracing
        {
            get
            {
                return this.FailedRequestsTracing();
            }
        }

        /// <summary>
        /// Gets web server quota in MB on file system.
        /// </summary>
        int Microsoft.Azure.Management.AppService.Fluent.IWebAppDiagnosticLogs.WebServerLoggingFileSystemQuotaInMB
        {
            get
            {
                return this.WebServerLoggingFileSystemQuotaInMB();
            }
        }

        /// <summary>
        /// Gets web server log retention days on file system.
        /// </summary>
        int Microsoft.Azure.Management.AppService.Fluent.IWebAppDiagnosticLogs.WebServerLoggingFileSystemRetentionDays
        {
            get
            {
                return this.WebServerLoggingFileSystemRetentionDays();
            }
        }

        /// <summary>
        /// Gets Azure Storage Blob container URL for storing web server logs.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppDiagnosticLogs.WebServerLoggingStorageBlobContainer
        {
            get
            {
                return this.WebServerLoggingStorageBlobContainer();
            }
        }

        /// <summary>
        /// Gets web server log retention days on Azure Storage Blob.
        /// </summary>
        int Microsoft.Azure.Management.AppService.Fluent.IWebAppDiagnosticLogs.WebServerLoggingStorageBlobRetentionDays
        {
            get
            {
                return this.WebServerLoggingStorageBlobRetentionDays();
            }
        }

        /// <summary>
        /// Enable logging from the web application.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        WebAppDiagnosticLogs.Definition.IWithApplicationLogLevel<WebAppBase.Definition.IWithCreate<FluentT>> WebAppDiagnosticLogs.Definition.IWithDiagnosticLogging<WebAppBase.Definition.IWithCreate<FluentT>>.WithApplicationLogging()
        {
            return this.WithApplicationLogging();
        }

        /// <summary>
        /// Enable logging from the web application.
        /// </summary>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IWithApplicationLogLevel<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithDiagnosticLogging<WebAppBase.Update.IUpdate<FluentT>>.WithApplicationLogging()
        {
            return this.WithApplicationLogging();
        }

        /// <summary>
        /// Specifies the storage location of application logs to be on the file system.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        WebAppDiagnosticLogs.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppDiagnosticLogs.Definition.IWithStorageLocationForApplication<WebAppBase.Definition.IWithCreate<FluentT>>.WithApplicationLogsStoredOnFileSystem()
        {
            return this.WithApplicationLogsStoredOnFileSystem();
        }

        /// <summary>
        /// Specifies the storage location of application logs to be on the file system.
        /// </summary>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IUpdate<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithStorageLocationForApplication<WebAppBase.Update.IUpdate<FluentT>>.WithApplicationLogsStoredOnFileSystem()
        {
            return this.WithApplicationLogsStoredOnFileSystem();
        }

        /// <summary>
        /// Specifies the storage location of application logs to be on in a Storage blob.
        /// </summary>
        /// <param name="containerSasUrl">The URL to the container including the SAS token.</param>
        /// <return>The next stage of the definition.</return>
        WebAppDiagnosticLogs.Definition.IWithAttachForApplicationStorage<WebAppBase.Definition.IWithCreate<FluentT>> WebAppDiagnosticLogs.Definition.IWithStorageLocationForApplication<WebAppBase.Definition.IWithCreate<FluentT>>.WithApplicationLogsStoredOnStorageBlob(string containerSasUrl)
        {
            return this.WithApplicationLogsStoredOnStorageBlob(containerSasUrl);
        }

        /// <summary>
        /// Specifies the storage location of application logs to be on in a Storage blob.
        /// </summary>
        /// <param name="containerSasUrl">The URL to the container including the SAS token.</param>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IWithAttachForApplicationStorage<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithStorageLocationForApplication<WebAppBase.Update.IUpdate<FluentT>>.WithApplicationLogsStoredOnStorageBlob(string containerSasUrl)
        {
            return this.WithApplicationLogsStoredOnStorageBlob(containerSasUrl);
        }

        /// <summary>
        /// Specifies if detailed error messages should be gathered from the web app.
        /// </summary>
        /// <param name="enabled">True if detailed error messages should be gathered.</param>
        /// <return>The next stage of the definition.</return>
        WebAppDiagnosticLogs.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppDiagnosticLogs.Definition.IWithDetailedErrorMessages<WebAppBase.Definition.IWithCreate<FluentT>>.WithDetailedErrorMessages(bool enabled)
        {
            return this.WithDetailedErrorMessages(enabled);
        }

        /// <summary>
        /// Specifies if detailed error messages should be gathered from the web app.
        /// </summary>
        /// <param name="enabled">True if detailed error messages should be gathered.</param>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IUpdate<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithDetailedErrorMessages<WebAppBase.Update.IUpdate<FluentT>>.WithDetailedErrorMessages(bool enabled)
        {
            return this.WithDetailedErrorMessages(enabled);
        }

        /// <summary>
        /// Specifies if diagnostic information on failed requests should be gathered.
        /// </summary>
        /// <param name="enabled">True if diagnostic information on failed requests should be gathered.</param>
        /// <return>The next stage of the definition.</return>
        WebAppDiagnosticLogs.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppDiagnosticLogs.Definition.IWithFailedRequestTracing<WebAppBase.Definition.IWithCreate<FluentT>>.WithFailedRequestTracing(bool enabled)
        {
            return this.WithFailedRequestTracing(enabled);
        }

        /// <summary>
        /// Specifies if diagnostic information on failed requests should be gathered.
        /// </summary>
        /// <param name="enabled">True if diagnostic information on failed requests should be gathered.</param>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IUpdate<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithFailedRequestTracing<WebAppBase.Update.IUpdate<FluentT>>.WithFailedRequestTracing(bool enabled)
        {
            return this.WithFailedRequestTracing(enabled);
        }

        /// <summary>
        /// Specifies the application log level.
        /// </summary>
        /// <param name="logLevel">The application log level.</param>
        /// <return>The next stage of the definition.</return>
        WebAppDiagnosticLogs.Definition.IWithStorageLocationForApplication<WebAppBase.Definition.IWithCreate<FluentT>> WebAppDiagnosticLogs.Definition.IWithApplicationLogLevel<WebAppBase.Definition.IWithCreate<FluentT>>.WithLogLevel(LogLevel logLevel)
        {
            return this.WithLogLevel(logLevel);
        }

        /// <summary>
        /// Specifies the application log level.
        /// </summary>
        /// <param name="logLevel">The application log level.</param>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IWithStorageLocationForApplication<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithApplicationLogLevel<WebAppBase.Update.IUpdate<FluentT>>.WithLogLevel(LogLevel logLevel)
        {
            return this.WithLogLevel(logLevel);
        }

        /// <summary>
        /// Specifies the maximum days of logs to keep. Logs older than this will be deleted.
        /// </summary>
        /// <param name="retentionDays">The maximum days of logs to keep.</param>
        /// <return>The next stage of the definition.</return>
        WebAppDiagnosticLogs.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppDiagnosticLogs.Definition.IWithRetentionDays<WebAppBase.Definition.IWithCreate<FluentT>>.WithLogRetentionDays(int retentionDays)
        {
            return this.WithLogRetentionDays(retentionDays);
        }

        /// <summary>
        /// Specifies the maximum days of logs to keep. Logs older than this will be deleted.
        /// </summary>
        /// <param name="retentionDays">The maximum days of logs to keep.</param>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IUpdate<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithRetentionDays<WebAppBase.Update.IUpdate<FluentT>>.WithLogRetentionDays(int retentionDays)
        {
            return this.WithLogRetentionDays(retentionDays);
        }

        /// <summary>
        /// Disable logging from the web application.
        /// </summary>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IUpdate<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithDiagnosticLogging<WebAppBase.Update.IUpdate<FluentT>>.WithoutApplicationLogging()
        {
            return this.WithoutApplicationLogging();
        }

        /// <summary>
        /// Stops application logs to be stored on the file system.
        /// </summary>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IUpdate<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithoutStorageLocationForApplication<WebAppBase.Update.IUpdate<FluentT>>.WithoutApplicationLogsStoredOnFileSystem()
        {
            return this.WithoutApplicationLogsStoredOnFileSystem();
        }

        /// <summary>
        /// Stops application logs to be stored on in a Storage blob.
        /// </summary>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IUpdate<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithoutStorageLocationForApplication<WebAppBase.Update.IUpdate<FluentT>>.WithoutApplicationLogsStoredOnStorageBlob()
        {
            return this.WithoutApplicationLogsStoredOnStorageBlob();
        }

        /// <summary>
        /// Disable logging from the web server.
        /// </summary>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IUpdate<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithDiagnosticLogging<WebAppBase.Update.IUpdate<FluentT>>.WithoutWebServerLogging()
        {
            return this.WithoutWebServerLogging();
        }

        /// <summary>
        /// Stops web server logs to be stored on the file system.
        /// </summary>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IUpdate<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithStorageLocationForWebServer<WebAppBase.Update.IUpdate<FluentT>>.WithoutWebServerLogsStoredOnFileSystem()
        {
            return this.WithoutWebServerLogsStoredOnFileSystem();
        }

        /// <summary>
        /// Stops web server logs to be stored on in a Storage blob.
        /// </summary>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IUpdate<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithStorageLocationForWebServer<WebAppBase.Update.IUpdate<FluentT>>.WithoutWebServerLogsStoredOnStorageBlob()
        {
            return this.WithoutWebServerLogsStoredOnStorageBlob();
        }

        /// <summary>
        /// Specifies the logs will not be deleted beyond a certain time.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        WebAppDiagnosticLogs.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppDiagnosticLogs.Definition.IWithRetentionDays<WebAppBase.Definition.IWithCreate<FluentT>>.WithUnlimitedLogRetentionDays()
        {
            return this.WithUnlimitedLogRetentionDays();
        }

        /// <summary>
        /// Specifies the logs will not be deleted beyond a certain time.
        /// </summary>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IUpdate<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithRetentionDays<WebAppBase.Update.IUpdate<FluentT>>.WithUnlimitedLogRetentionDays()
        {
            return this.WithUnlimitedLogRetentionDays();
        }

        /// <summary>
        /// Specifies the maximum size of logs allowed on the file system (in MB).
        /// </summary>
        /// <param name="quotaInMB">The maximum size of logs allowed (in MB). Must be between 25 and 100.</param>
        /// <return>The next stage of the definition.</return>
        WebAppDiagnosticLogs.Definition.IWithAttachForWebServerFileSystem<WebAppBase.Definition.IWithCreate<FluentT>> WebAppDiagnosticLogs.Definition.IWithQuota<WebAppBase.Definition.IWithCreate<FluentT>>.WithWebServerFileSystemQuotaInMB(int quotaInMB)
        {
            return this.WithWebServerFileSystemQuotaInMB(quotaInMB);
        }

        /// <summary>
        /// Specifies the maximum size of logs allowed on the file system (in MB).
        /// </summary>
        /// <param name="quotaInMB">The maximum size of logs allowed (in MB). Must be between 25 and 100.</param>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IWithAttachForWebServerFileSystem<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithQuota<WebAppBase.Update.IUpdate<FluentT>>.WithWebServerFileSystemQuotaInMB(int quotaInMB)
        {
            return this.WithWebServerFileSystemQuotaInMB(quotaInMB);
        }

        /// <summary>
        /// Enable logging from the web server.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        WebAppDiagnosticLogs.Definition.IWithStorageLocationForWebServer<WebAppBase.Definition.IWithCreate<FluentT>> WebAppDiagnosticLogs.Definition.IWithDiagnosticLogging<WebAppBase.Definition.IWithCreate<FluentT>>.WithWebServerLogging()
        {
            return this.WithWebServerLogging();
        }

        /// <summary>
        /// Enable logging from the web server.
        /// </summary>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IWithStorageLocationForWebServer<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithDiagnosticLogging<WebAppBase.Update.IUpdate<FluentT>>.WithWebServerLogging()
        {
            return this.WithWebServerLogging();
        }

        /// <summary>
        /// Specifies the storage location of web server logs to be on the file system.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        WebAppDiagnosticLogs.Definition.IWithAttachForWebServerFileSystem<WebAppBase.Definition.IWithCreate<FluentT>> WebAppDiagnosticLogs.Definition.IWithStorageLocationForWebServer<WebAppBase.Definition.IWithCreate<FluentT>>.WithWebServerLogsStoredOnFileSystem()
        {
            return this.WithWebServerLogsStoredOnFileSystem();
        }

        /// <summary>
        /// Specifies the storage location of web server logs to be on the file system.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        WebAppDiagnosticLogs.Update.IWithAttachForWebServerFileSystem<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithStorageLocationForWebServer<WebAppBase.Update.IUpdate<FluentT>>.WithWebServerLogsStoredOnFileSystem()
        {
            return this.WithWebServerLogsStoredOnFileSystem();
        }

        /// <summary>
        /// Specifies the storage location of web server logs to be on in a Storage blob.
        /// </summary>
        /// <param name="containerSasUrl">The URL to the container including the SAS token.</param>
        /// <return>The next stage of the definition.</return>
        WebAppDiagnosticLogs.Definition.IWithAttachForWebServerStorage<WebAppBase.Definition.IWithCreate<FluentT>> WebAppDiagnosticLogs.Definition.IWithStorageLocationForWebServer<WebAppBase.Definition.IWithCreate<FluentT>>.WithWebServerLogsStoredOnStorageBlob(string containerSasUrl)
        {
            return this.WithWebServerLogsStoredOnStorageBlob(containerSasUrl);
        }

        /// <summary>
        /// Specifies the storage location of web server logs to be on in a Storage blob.
        /// </summary>
        /// <param name="containerSasUrl">The URL to the container including the SAS token.</param>
        /// <return>The next stage of the update.</return>
        WebAppDiagnosticLogs.Update.IWithAttachForWebServerStorage<WebAppBase.Update.IUpdate<FluentT>> WebAppDiagnosticLogs.Update.IWithStorageLocationForWebServer<WebAppBase.Update.IUpdate<FluentT>>.WithWebServerLogsStoredOnStorageBlob(string containerSasUrl)
        {
            return this.WithWebServerLogsStoredOnStorageBlob(containerSasUrl);
        }
    }
}