// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class WebAppImpl 
    {
        /// <summary>
        /// Uses an existing app service plan for the web app.
        /// </summary>
        /// <param name="appServicePlan">The existing app service plan.</param>
        /// <return>The next stage of the definition.</return>
        WebApp.Definition.IExistingWindowsPlanWithGroup WebApp.Definition.IBlank.WithExistingWindowsPlan(IAppServicePlan appServicePlan)
        {
            return this.WithExistingWindowsPlan(appServicePlan);
        }

        /// <summary>
        /// Uses an existing app service plan for the web app.
        /// </summary>
        /// <param name="appServicePlan">The existing app service plan.</param>
        /// <return>The next stage of the definition.</return>
        WebApp.Definition.IExistingLinuxPlanWithGroup WebApp.Definition.IBlank.WithExistingLinuxPlan(IAppServicePlan appServicePlan)
        {
            return this.WithExistingLinuxPlan(appServicePlan);
        }

        /// <summary>
        /// Specifies the startup command.
        /// </summary>
        /// <param name="startUpCommand">Startup command to replace "CMD" in Dockerfile.</param>
        /// <return>The next stage of the definition.</return>
        WebApp.Update.IUpdate WebApp.Update.IWithStartUpCommand.WithStartUpCommand(string startUpCommand)
        {
            return this.WithStartUpCommand(startUpCommand);
        }

        /// <summary>
        /// Specifies the startup command.
        /// </summary>
        /// <param name="startUpCommand">Startup command to replace "CMD" in Dockerfile.</param>
        /// <return>The next stage of the definition.</return>
        WebApp.Definition.IWithCreate WebApp.Definition.IWithStartUpCommand.WithStartUpCommand(string startUpCommand)
        {
            return this.WithStartUpCommand(startUpCommand);
        }

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="pricingTier">The sku of the app service plan.</param>
        /// <return>The next stage of the definition.</return>
        WebApp.Definition.IWithWindowsRuntimeStack WebApp.Definition.IWithNewAppServicePlan.WithNewWindowsPlan(PricingTier pricingTier)
        {
            return this.WithNewWindowsPlan(pricingTier);
        }

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="appServicePlanCreatable">The new app service plan creatable.</param>
        /// <return>The next stage of the definition.</return>
        WebApp.Definition.IWithWindowsRuntimeStack WebApp.Definition.IWithNewAppServicePlan.WithNewWindowsPlan(ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> appServicePlanCreatable)
        {
            return this.WithNewWindowsPlan(appServicePlanCreatable);
        }

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="pricingTier">The sku of the app service plan.</param>
        /// <return>The next stage of the definition.</return>
        WebApp.Definition.IWithDockerContainerImage WebApp.Definition.IWithNewAppServicePlan.WithNewLinuxPlan(PricingTier pricingTier)
        {
            return this.WithNewLinuxPlan(pricingTier);
        }

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="appServicePlanCreatable">The new app service plan creatable.</param>
        /// <return>The next stage of the definition.</return>
        WebApp.Definition.IWithDockerContainerImage WebApp.Definition.IWithNewAppServicePlan.WithNewLinuxPlan(ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> appServicePlanCreatable)
        {
            return this.WithNewLinuxPlan(appServicePlanCreatable);
        }

        /// <summary>
        /// Creates a new free app service plan. This will fail if there are 10 or more
        /// free plans in the current subscription.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithWindowsRuntimeStack WebApp.Definition.IWithNewAppServicePlan.WithNewFreeAppServicePlan()
        {
            return this.WithNewFreeAppServicePlan();
        }

        /// <summary>
        /// Creates a new shared app service plan.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithWindowsRuntimeStack WebApp.Definition.IWithNewAppServicePlan.WithNewSharedAppServicePlan()
        {
            return this.WithNewSharedAppServicePlan();
        }

        /// <summary>
        /// Specifies the docker container image to be one from Docker Hub.
        /// </summary>
        /// <param name="imageAndTag">Image and optional tag (eg 'image:tag').</param>
        /// <return>The next stage of the web app update.</return>
        WebApp.Update.IWithCredentials WebApp.Update.IWithDockerContainerImage.WithPrivateDockerHubImage(string imageAndTag)
        {
            return this.WithPrivateDockerHubImage(imageAndTag);
        }

        /// <summary>
        /// Specifies the docker container image to be one from Docker Hub.
        /// </summary>
        /// <param name="imageAndTag">Image and optional tag (eg 'image:tag').</param>
        /// <return>The next stage of the web app update.</return>
        WebApp.Update.IWithStartUpCommand WebApp.Update.IWithDockerContainerImage.WithPublicDockerHubImage(string imageAndTag)
        {
            return this.WithPublicDockerHubImage(imageAndTag);
        }

        /// <summary>
        /// Specifies the docker container image to be a built in one.
        /// </summary>
        /// <param name="runtimeStack">The runtime stack installed on the image.</param>
        /// <return>The next stage of the web app update.</return>
        WebApp.Update.IUpdate WebApp.Update.IWithDockerContainerImage.WithBuiltInImage(RuntimeStack runtimeStack)
        {
            return this.WithBuiltInImage(runtimeStack);
        }

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="pricingTier">The sku of the app service plan.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WebApp.Update.IWithAppServicePlan.WithNewAppServicePlan(PricingTier pricingTier)
        {
            return this.WithNewAppServicePlan(pricingTier);
        }

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="appServicePlanCreatable">The new app service plan creatable.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WebApp.Update.IWithAppServicePlan.WithNewAppServicePlan(ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> appServicePlanCreatable)
        {
            return this.WithNewAppServicePlan(appServicePlanCreatable);
        }

        /// <summary>
        /// Creates a new free app service plan. This will fail if there are 10 or more
        /// free plans in the current subscription.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WebApp.Update.IWithAppServicePlan.WithNewFreeAppServicePlan()
        {
            return this.WithNewFreeAppServicePlan();
        }

        /// <summary>
        /// Uses an existing app service plan for the web app.
        /// </summary>
        /// <param name="appServicePlan">The existing app service plan.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WebApp.Update.IWithAppServicePlan.WithExistingAppServicePlan(IAppServicePlan appServicePlan)
        {
            return this.WithExistingAppServicePlan(appServicePlan);
        }

        /// <summary>
        /// Creates a new shared app service plan.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WebApp.Update.IWithAppServicePlan.WithNewSharedAppServicePlan()
        {
            return this.WithNewSharedAppServicePlan();
        }

        /// <summary>
        /// Specifies the docker container image to be one from a private registry.
        /// </summary>
        /// <param name="imageAndTag">Image and optional tag (eg 'image:tag').</param>
        /// <param name="serverUrl">The URL to the private registry server.</param>
        /// <return>The next stage of the web app update.</return>
        WebApp.Update.IWithCredentials WebApp.Update.IWithDockerContainerImage.WithPrivateRegistryImage(string imageAndTag, string serverUrl)
        {
            return this.WithPrivateRegistryImage(imageAndTag, serverUrl);
        }

        /// <summary>
        /// Specifies the docker container image to be one from Docker Hub.
        /// </summary>
        /// <param name="imageAndTag">Image and optional tag (eg 'image:tag').</param>
        /// <return>The next stage of the definition.</return>
        WebApp.Definition.IWithCredentials WebApp.Definition.IWithContainerImage.WithPrivateDockerHubImage(string imageAndTag)
        {
            return this.WithPrivateDockerHubImage(imageAndTag);
        }

        /// <summary>
        /// Specifies the docker container image to be one from Docker Hub.
        /// </summary>
        /// <param name="imageAndTag">Image and optional tag (eg 'image:tag').</param>
        /// <return>The next stage of the definition.</return>
        WebApp.Definition.IWithStartUpCommand WebApp.Definition.IWithContainerImage.WithPublicDockerHubImage(string imageAndTag)
        {
            return this.WithPublicDockerHubImage(imageAndTag);
        }

        /// <summary>
        /// Specifies the docker container image to be a built in one.
        /// </summary>
        /// <param name="runtimeStack">The runtime stack installed on the image.</param>
        /// <return>The next stage of the definition.</return>
        WebApp.Definition.IWithCreate WebApp.Definition.IWithDockerContainerImage.WithBuiltInImage(RuntimeStack runtimeStack)
        {
            return this.WithBuiltInImage(runtimeStack);
        }

        /// <summary>
        /// Specifies the docker container image to be one from a private registry.
        /// </summary>
        /// <param name="imageAndTag">Image and optional tag (eg 'image:tag').</param>
        /// <param name="serverUrl">The URL to the private registry server.</param>
        /// <return>The next stage of the definition.</return>
        WebApp.Definition.IWithCredentials WebApp.Definition.IWithContainerImage.WithPrivateRegistryImage(string imageAndTag, string serverUrl)
        {
            return this.WithPrivateRegistryImage(imageAndTag, serverUrl);
        }

        /// <summary>
        /// Specifies the username and password for Docker Hub.
        /// </summary>
        /// <param name="username">The username for Docker Hub.</param>
        /// <param name="password">The password for Docker Hub.</param>
        /// <return>The next stage of the web app update.</return>
        WebApp.Update.IWithStartUpCommand WebApp.Update.IWithCredentials.WithCredentials(string username, string password)
        {
            return this.WithCredentials(username, password);
        }

        /// <summary>
        /// Specifies the username and password for Docker Hub or the docker registry.
        /// </summary>
        /// <param name="username">The username for Docker Hub or the docker registry.</param>
        /// <param name="password">The password for Docker Hub or the docker registry.</param>
        /// <return>The next stage of the definition.</return>
        WebApp.Definition.IWithStartUpCommand WebApp.Definition.IWithCredentials.WithCredentials(string username, string password)
        {
            return this.WithCredentials(username, password);
        }

        WebApp.Definition.IWithCreate WebApp.Definition.IWithWindowsRuntimeStack.WithRuntimeStack(WebAppRuntimeStack runtimeStack)
        {
            return this.WithRuntimeStack(runtimeStack);
        }

        WebApp.Update.IUpdate WebApp.Update.IWithWindowsRuntimeStack.WithRuntimeStack(WebAppRuntimeStack runtimeStack)
        {
            return this.WithRuntimeStack(runtimeStack);
        }

        /// <summary>
        /// Deploys a WAR file onto the Azure specialized Tomcat on this web app.
        /// </summary>
        /// <param name="warFile">The WAR file to upload.</param>
        void Microsoft.Azure.Management.AppService.Fluent.IWebApp.WarDeploy(FileInfo warFile)
        {
 
            this.WarDeploy(warFile);
        }

        /// <summary>
        /// Deploys a WAR file onto the Azure specialized Tomcat on this web app.
        /// </summary>
        /// <param name="warFile">The WAR file to upload.</param>
        /// <return>A completable of the operation.</return>
        async Task Microsoft.Azure.Management.AppService.Fluent.IWebApp.WarDeployAsync(FileInfo warFile, CancellationToken cancellationToken)
        {
 
            await this.WarDeployAsync(warFile, cancellationToken);
        }

        /// <summary>
        /// Gets the entry point to deployment slot management API under the web app.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlots Microsoft.Azure.Management.AppService.Fluent.IWebApp.DeploymentSlots
        {
            get
            {
                return this.DeploymentSlots();
            }
        }
    }
}