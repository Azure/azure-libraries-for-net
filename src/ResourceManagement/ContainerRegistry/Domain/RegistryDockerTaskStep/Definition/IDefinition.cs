// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Definition
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the container registry DockerTaskStep definition allowing to specify the path to the Docker file.
    /// </summary>
    public interface IDockerFilePath 
    {
        /// <summary>
        /// The function that specifies the path to the Docker file.
        /// </summary>
        /// <param name="path">The path to the Docker file.</param>
        /// <return>The next stage of the container registry DockerTaskStep definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable WithDockerFilePath(string path);
    }

    /// <summary>
    /// The first stage of a DockerFileTaskStep definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Definition.IDockerFilePath
    {

    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be attached,
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IDockerTaskStepAttachable  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IAttachable<Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ISourceTriggerDefinition>
    {
        /// <summary>
        /// The function that specifies the use of a cache based on user input parameter.
        /// </summary>
        /// <param name="enabled">Whether caching will be enabled.</param>
        /// <return>The next step of the container registry DockerTaskStep definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable WithCacheEnabled(bool enabled);

        /// <summary>
        /// The function that specifies the list of image names.
        /// </summary>
        /// <param name="imageNames">The image names.</param>
        /// <return>The next step of the container registry DockerTaskStep definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable WithImageNames(IList<string> imageNames);

        /// <summary>
        /// The function that specifies the overriding argument and what it will override.
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingArgument">The content of the overriding argument.</param>
        /// <return>The next stage of the container Docker task step definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable WithOverridingArgument(string name, OverridingArgument overridingArgument);

        /// <summary>
        /// The function that specifies the overriding arguments and what they will override.
        /// </summary>
        /// <param name="overridingArguments">Map with key of the name of the value to be overridden and value OverridingArgument specifying the content of the overriding argument.</param>
        /// <return>The next stage of the container Docker task step definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable WithOverridingArguments(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingArgument> overridingArguments);

        /// <summary>
        /// The function that enables push depending on user input parameter.
        /// </summary>
        /// <param name="enabled">Whether push will be enabled.</param>
        /// <return>The next step of the container registry DockerTaskStep definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable WithPushEnabled(bool enabled);
    }

    /// <summary>
    /// Container interface for all the definitions related to a RegistryDockerTaskStep.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Definition.IBlank,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Definition.IDockerFilePath,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable
    {
    }
}