// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.IO;

    /// <summary>
    /// An immutable client-side representation of an Azure Web App deployment slot.
    /// </summary>
    public interface IDeploymentSlot  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IIndependentChildResource<Microsoft.Azure.Management.AppService.Fluent.IAppServiceManager,Models.SiteInner>,
        Microsoft.Azure.Management.AppService.Fluent.IWebAppBase,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<DeploymentSlot.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.AppService.Fluent.IWebApp>
    {
        /// <summary>
        /// Deploys a WAR file onto the Azure specialized Tomcat on this web app.
        /// </summary>
        /// <param name="warFile">The WAR file to upload.</param>
        /// <return>A completable of the operation.</return>
        Task WarDeployAsync(FileInfo warFile, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deploys a WAR file onto the Azure specialized Tomcat on this web app.
        /// </summary>
        /// <param name="warFile">The WAR file to upload.</param>
        void WarDeploy(FileInfo warFile);
    }
}