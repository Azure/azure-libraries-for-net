// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.UpdateDefinition
{
    using Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update;

    /// <summary>
    /// The entirety of a web app diagnostic log definition as part of a web app update.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Update.parent() ()}.</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IBlank<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IUpdate<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithDiagnosticLogging<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithApplicationLogLevel<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithStorageLocationForApplication<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithStorageLocationForWebServer<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithAttachForWebServerStorage<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithAttachForWebServerFileSystem<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IWithAttachForApplicationStorage<ParentT>
    {

    }
}