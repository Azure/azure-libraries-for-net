// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.FunctionDeploymentSlot.Definition
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The first stage of the function deployment slot definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.AppService.Fluent.FunctionDeploymentSlot.Definition.IWithConfiguration
    {
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.AppService.Fluent.FunctionDeploymentSlot.Definition.IBlank,
        Microsoft.Azure.Management.AppService.Fluent.FunctionDeploymentSlot.Definition.IWithConfiguration,
        Microsoft.Azure.Management.AppService.Fluent.FunctionDeploymentSlot.Definition.IWithCreate
    {
    }

    /// <summary>
    /// A site definition with sufficient inputs to create a new web app /
    /// deployments slot in the cloud, but exposing additional optional
    /// inputs to specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.AppService.Fluent.IFunctionDeploymentSlot>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IFunctionDeploymentSlot>
    {
    }

    /// <summary>
    /// A function deployment slot definition allowing the configuration to clone from to be specified.
    /// </summary>
    public interface IWithConfiguration 
    {
        /// <summary>
        /// Copies the site configurations from the web app the function deployment slot belongs to.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionDeploymentSlot.Definition.IWithCreate WithConfigurationFromParent();

        /// <summary>
        /// Copies the site configurations from a givenfunction  deployment slot.
        /// </summary>
        /// <param name="deploymentSlot">The function deployment slot to copy the configurations from.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionDeploymentSlot.Definition.IWithCreate WithConfigurationFromDeploymentSlot(IFunctionDeploymentSlot deploymentSlot);

        /// <summary>
        /// Copies the site configurations from a given function app.
        /// </summary>
        /// <param name="app">The function app to copy the configurations from.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionDeploymentSlot.Definition.IWithCreate WithConfigurationFromFunctionApp(IFunctionApp app);

        /// <summary>
        /// Creates the function deployment slot with brand new site configurations.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionDeploymentSlot.Definition.IWithCreate WithBrandNewConfiguration();
    }
}