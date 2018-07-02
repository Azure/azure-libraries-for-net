// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class DeploymentSlotImpl
    {
        /// <summary>
        /// Copies the site configurations from the web app the deployment slot belongs to.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        DeploymentSlot.Definition.IWithCreate DeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromParent()
        {
            return this.WithConfigurationFromParent();
        }

        /// <summary>
        /// Copies the site configurations from a given web app.
        /// </summary>
        /// <param name="webApp">The web app to copy the configurations from.</param>
        /// <return>The next stage of the definition.</return>
        DeploymentSlot.Definition.IWithCreate DeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromWebApp(IWebApp webApp)
        {
            return this.WithConfigurationFromWebApp(webApp);
        }

        /// <summary>
        /// Copies the site configurations from a given deployment slot.
        /// </summary>
        /// <param name="deploymentSlot">The deployment slot to copy the configurations from.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Definition.IWithCreate DeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromDeploymentSlot(IDeploymentSlot deploymentSlot)
        {
            return this.WithConfigurationFromDeploymentSlot(deploymentSlot);
        }

        /// <summary>
        /// Creates the deployment slot with brand new site configurations.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Definition.IWithCreate DeploymentSlot.Definition.IWithConfiguration.WithBrandNewConfiguration()
        {
            return this.WithBrandNewConfiguration();
        }

        /// <summary>
        /// Deploys a WAR file onto the Azure specialized Tomcat on this web app.
        /// </summary>
        /// <param name="warFile">The WAR file to upload.</param>
        void Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot.WarDeploy(FileInfo warFile)
        {
 
            this.WarDeploy(warFile);
        }

        /// <summary>
        /// Deploys a WAR file onto the Azure specialized Tomcat on this web app.
        /// </summary>
        /// <param name="warFile">The WAR file to upload.</param>
        /// <return>A completable of the operation.</return>
        async Task Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot.WarDeployAsync(FileInfo warFile, CancellationToken cancellationToken)
        {
 
            await this.WarDeployAsync(warFile, cancellationToken);
        }
    }
}