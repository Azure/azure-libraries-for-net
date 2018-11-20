// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// A web app diagnostic log update allowing retention days to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IWithRetentionDays<ParentT> 
    {

        /// <summary>
        /// Specifies the maximum days of logs to keep. Logs older than this will be deleted.
        /// </summary>
        /// <param name="retentionDays">The maximum days of logs to keep.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT> WithLogRetentionDays(int retentionDays);

        /// <summary>
        /// Specifies the logs will not be deleted beyond a certain time.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT> WithUnlimitedLogRetentionDays();
    }

    /// <summary>
    /// The final stage of the web app diagnostic log update.
    /// At this stage, any remaining optional settings can be specified, or the web app diagnostic log update
    /// can be attached to the parent web app update using  Update.parent().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  Update.parent().</typeparam>
    public interface IUpdate<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithDetailedErrorMessages<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithFailedRequestTracing<ParentT>
    {

    }

    /// <summary>
    /// A web app diagnostic log update allowing detailed error messages to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IWithDetailedErrorMessages<ParentT> 
    {

        /// <summary>
        /// Specifies if detailed error messages should be gathered from the web app.
        /// </summary>
        /// <param name="enabled">True if detailed error messages should be gathered.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT> WithDetailedErrorMessages(bool enabled);
    }

    /// <summary>
    /// The final stage of the web app diagnostic log update, plus extra settings for web server logs stored in a Storage blob.
    /// At this stage, any remaining optional settings can be specified, or the web app diagnostic log update
    /// can be attached to the parent web app update using  Update.parent().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  Update.parent().</typeparam>
    public interface IWithAttachForWebServerStorage<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithRetentionDays<ParentT>
    {

    }

    /// <summary>
    /// A web app diagnostic log update allowing application log storage location to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IWithoutStorageLocationForApplication<ParentT> 
    {

        /// <summary>
        /// Stops application logs to be stored on the file system.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT> WithoutApplicationLogsStoredOnFileSystem();

        /// <summary>
        /// Stops application logs to be stored on in a Storage blob.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT> WithoutApplicationLogsStoredOnStorageBlob();
    }

    /// <summary>
    /// A web app diagnostic log update allowing application log storage location to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IWithStorageLocationForApplication<ParentT> 
    {

        /// <summary>
        /// Specifies the storage location of application logs to be on the file system.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT> WithApplicationLogsStoredOnFileSystem();

        /// <summary>
        /// Specifies the storage location of application logs to be on in a Storage blob.
        /// </summary>
        /// <param name="containerSasUrl">The URL to the container including the SAS token.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithAttachForApplicationStorage<ParentT> WithApplicationLogsStoredOnStorageBlob(string containerSasUrl);
    }

    /// <summary>
    /// A web app diagnostic log update allowing the log source to be set.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IWithDiagnosticLogging<ParentT> 
    {

        /// <summary>
        /// Enable logging from the web application.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithApplicationLogLevel<ParentT> WithApplicationLogging();

        /// <summary>
        /// Disable logging from the web application.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT> WithoutApplicationLogging();

        /// <summary>
        /// Disable logging from the web server.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT> WithoutWebServerLogging();

        /// <summary>
        /// Enable logging from the web server.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithStorageLocationForWebServer<ParentT> WithWebServerLogging();
    }

    /// <summary>
    /// A web app diagnostic log update allowing failed request tracing to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IWithFailedRequestTracing<ParentT> 
    {

        /// <summary>
        /// Specifies if diagnostic information on failed requests should be gathered.
        /// </summary>
        /// <param name="enabled">True if diagnostic information on failed requests should be gathered.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT> WithFailedRequestTracing(bool enabled);
    }

    /// <summary>
    /// A web app diagnostic log update allowing web server file system logging quota to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IWithQuota<ParentT> 
    {

        /// <summary>
        /// Specifies the maximum size of logs allowed on the file system (in MB).
        /// </summary>
        /// <param name="quotaInMB">The maximum size of logs allowed (in MB). Must be between 25 and 100.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithAttachForWebServerFileSystem<ParentT> WithWebServerFileSystemQuotaInMB(int quotaInMB);
    }

    /// <summary>
    /// The final stage of the web app diagnostic log update, plus extra settings for web server logs stored in the file system.
    /// At this stage, any remaining optional settings can be specified, or the web app diagnostic log update
    /// can be attached to the parent web app update using  Update.parent().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  Update.parent().</typeparam>
    public interface IWithAttachForWebServerFileSystem<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithQuota<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithRetentionDays<ParentT>
    {

    }

    /// <summary>
    /// A web app diagnostic log update allowing application log level to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IWithApplicationLogLevel<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithoutStorageLocationForApplication<ParentT>
    {

        /// <summary>
        /// Specifies the application log level.
        /// </summary>
        /// <param name="logLevel">The application log level.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithStorageLocationForApplication<ParentT> WithLogLevel(LogLevel logLevel);
    }

    /// <summary>
    /// A web app diagnostic log update allowing web server log storage location to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IWithStorageLocationForWebServer<ParentT> 
    {

        /// <summary>
        /// Stops web server logs to be stored on the file system.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT> WithoutWebServerLogsStoredOnFileSystem();

        /// <summary>
        /// Stops web server logs to be stored on in a Storage blob.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT> WithoutWebServerLogsStoredOnStorageBlob();

        /// <summary>
        /// Specifies the storage location of web server logs to be on the file system.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithAttachForWebServerFileSystem<ParentT> WithWebServerLogsStoredOnFileSystem();

        /// <summary>
        /// Specifies the storage location of web server logs to be on in a Storage blob.
        /// </summary>
        /// <param name="containerSasUrl">The URL to the container including the SAS token.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithAttachForWebServerStorage<ParentT> WithWebServerLogsStoredOnStorageBlob(string containerSasUrl);
    }

    /// <summary>
    /// The final stage of the web app diagnostic log update, plus extra settings for application logs stored in a Storage blob.
    /// At this stage, any remaining optional settings can be specified, or the web app diagnostic log update
    /// can be attached to the parent web app update using  Update.parent().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  Update.parent().</typeparam>
    public interface IWithAttachForApplicationStorage<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithRetentionDays<ParentT>
    {

    }

    /// <summary>
    /// The first stage of a web app diagnostic log update as part of a update of a web app.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithDiagnosticLogging<ParentT>
    {

    }
}