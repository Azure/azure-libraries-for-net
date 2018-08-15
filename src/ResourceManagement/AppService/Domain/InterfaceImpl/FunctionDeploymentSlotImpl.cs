// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.FunctionDeploymentSlot.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.FunctionDeploymentSlot.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;

    internal partial class FunctionDeploymentSlotImpl 
    {
        /// <summary>
        /// Copies the site configurations from the web app the function deployment slot belongs to.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        FunctionDeploymentSlot.Definition.IWithCreate FunctionDeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromParent()
        {
            return this.WithConfigurationFromParent();
        }

        /// <summary>
        /// Copies the site configurations from a given function app.
        /// </summary>
        /// <param name="app">The function app to copy the configurations from.</param>
        /// <return>The next stage of the definition.</return>
        FunctionDeploymentSlot.Definition.IWithCreate FunctionDeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromFunctionApp(IFunctionApp app)
        {
            return this.WithConfigurationFromFunctionApp(app);
        }

        /// <summary>
        /// Copies the site configurations from a givenfunction  deployment slot.
        /// </summary>
        /// <param name="deploymentSlot">The function deployment slot to copy the configurations from.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionDeploymentSlot.Definition.IWithCreate FunctionDeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromDeploymentSlot(IFunctionDeploymentSlot deploymentSlot)
        {
            return this.WithConfigurationFromDeploymentSlot(deploymentSlot);
        }

        /// <summary>
        /// Creates the function deployment slot with brand new site configurations.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionDeploymentSlot.Definition.IWithCreate FunctionDeploymentSlot.Definition.IWithConfiguration.WithBrandNewConfiguration()
        {
            return this.WithBrandNewConfiguration();
        }
    }
}