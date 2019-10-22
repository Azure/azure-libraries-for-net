// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;

    /// <summary>
    /// A web app diagnostic log definition allowing failed request tracing to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFailedRequestTracing<ParentT> 
    {

        /// <summary>
        /// Specifies if diagnostic information on failed requests should be gathered.
        /// </summary>
        /// <param name="enabled">True if diagnostic information on failed requests should be gathered.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttach<ParentT> WithFailedRequestTracing(bool enabled);
    }

    /// <summary>
    /// The first stage of a web app diagnostic log definition as part of a definition of a web app.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithDiagnosticLogging<ParentT>
    {

    }

    /// <summary>
    /// The entirety of a web app diagnostic log definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithDiagnosticLogging<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithApplicationLogLevel<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithStorageLocationForApplication<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithStorageLocationForWebServer<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttachForWebServerStorage<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttachForWebServerFileSystem<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttachForApplicationStorage<ParentT>
    {

    }

    /// <summary>
    /// A web app diagnostic log definition allowing application log storage location to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStorageLocationForApplication<ParentT> 
    {

        /// <summary>
        /// Specifies the storage location of application logs to be on the file system.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttach<ParentT> WithApplicationLogsStoredOnFileSystem();

        /// <summary>
        /// Specifies the storage location of application logs to be on in a Storage blob.
        /// </summary>
        /// <param name="containerSasUrl">The URL to the container including the SAS token.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttachForApplicationStorage<ParentT> WithApplicationLogsStoredOnStorageBlob(string containerSasUrl);
    }

    /// <summary>
    /// The final stage of the web app diagnostic log definition, plus extra settings for web server logs stored in a Storage blob.
    /// At this stage, any remaining optional settings can be specified, or the web app diagnostic log definition
    /// can be attached to the parent web app definition using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttachForWebServerStorage<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithRetentionDays<ParentT>
    {

    }

    /// <summary>
    /// The final stage of the web app diagnostic log definition, plus extra settings for application logs stored in a Storage blob.
    /// At this stage, any remaining optional settings can be specified, or the web app diagnostic log definition
    /// can be attached to the parent web app definition using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttachForApplicationStorage<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithRetentionDays<ParentT>
    {

    }

    /// <summary>
    /// A web app diagnostic log definition allowing the log source to be set.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IWithDiagnosticLogging<ParentT> 
    {

        /// <summary>
        /// Enable logging from the web application.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithApplicationLogLevel<ParentT> WithApplicationLogging();

        /// <summary>
        /// Enable logging from the web server.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithStorageLocationForWebServer<ParentT> WithWebServerLogging();
    }

    /// <summary>
    /// A web app diagnostic log definition allowing application log level to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithApplicationLogLevel<ParentT> 
    {

        /// <summary>
        /// Specifies the application log level.
        /// </summary>
        /// <param name="logLevel">The application log level.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithStorageLocationForApplication<ParentT> WithLogLevel(LogLevel logLevel);
    }

    /// <summary>
    /// A web app diagnostic log definition allowing web server log storage location to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStorageLocationForWebServer<ParentT> 
    {

        /// <summary>
        /// Specifies the storage location of web server logs to be on the file system.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttachForWebServerFileSystem<ParentT> WithWebServerLogsStoredOnFileSystem();

        /// <summary>
        /// Specifies the storage location of web server logs to be on in a Storage blob.
        /// </summary>
        /// <param name="containerSasUrl">The URL to the container including the SAS token.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttachForWebServerStorage<ParentT> WithWebServerLogsStoredOnStorageBlob(string containerSasUrl);
    }

    /// <summary>
    /// A web app diagnostic log definition allowing detailed error messages to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDetailedErrorMessages<ParentT> 
    {

        /// <summary>
        /// Specifies if detailed error messages should be gathered from the web app.
        /// </summary>
        /// <param name="enabled">True if detailed error messages should be gathered.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttach<ParentT> WithDetailedErrorMessages(bool enabled);
    }

    /// <summary>
    /// The final stage of the web app diagnostic log definition.
    /// At this stage, any remaining optional settings can be specified, or the web app diagnostic log definition
    /// can be attached to the parent web app definition using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithDetailedErrorMessages<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithFailedRequestTracing<ParentT>
    {

    }

    /// <summary>
    /// A web app diagnostic log definition allowing web server file system logging quota to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithQuota<ParentT> 
    {

        /// <summary>
        /// Specifies the maximum size of logs allowed on the file system (in MB).
        /// </summary>
        /// <param name="quotaInMB">The maximum size of logs allowed (in MB). Must be between 25 and 100.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttachForWebServerFileSystem<ParentT> WithWebServerFileSystemQuotaInMB(int quotaInMB);
    }

    /// <summary>
    /// The final stage of the web app diagnostic log definition, plus extra settings for web server logs stored in the file system.
    /// At this stage, any remaining optional settings can be specified, or the web app diagnostic log definition
    /// can be attached to the parent web app definition using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttachForWebServerFileSystem<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithQuota<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithRetentionDays<ParentT>
    {

    }

    /// <summary>
    /// A web app diagnostic log definition allowing retention days to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithRetentionDays<ParentT> 
    {

        /// <summary>
        /// Specifies the maximum days of logs to keep. Logs older than this will be deleted.
        /// </summary>
        /// <param name="retentionDays">The maximum days of logs to keep.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttach<ParentT> WithLogRetentionDays(int retentionDays);

        /// <summary>
        /// Specifies the logs will not be deleted beyond a certain time.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IWithAttach<ParentT> WithUnlimitedLogRetentionDays();
    }
}