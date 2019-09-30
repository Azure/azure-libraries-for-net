// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.WebApp.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.IO;

    /// <summary>
    /// An immutable client-side representation of an Azure Web App.
    /// </summary>
    public interface IWebApp :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.AppService.Fluent.IWebAppBase,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.AppService.Fluent.IWebApp>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<WebApp.Update.IUpdate>
    {
        /// <summary>
        /// Deploys a WAR file onto the Azure specialized Tomcat on this web app.
        /// </summary>
        /// <param name="warFile">The WAR file to upload.</param>
        /// <return>A completable of the operation.</return>
        Task WarDeployAsync(FileInfo warFile, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the entry point to deployment slot management API under the web app.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlots DeploymentSlots { get; }

        /// <summary>
        /// Deploys a WAR file onto the Azure specialized Tomcat on this web app.
        /// </summary>
        /// <param name="warFile">The WAR file to upload.</param>
        void WarDeploy(FileInfo warFile);
    }
}