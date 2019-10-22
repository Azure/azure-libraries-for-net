// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the container registry DockerTaskStep update allowing to specify the image names.
    /// </summary>
    public interface IImageNames 
    {
        /// <summary>
        /// The function that specifies the image names.
        /// </summary>
        /// <param name="imageNames">The list of the names of the images.</param>
        /// <return>The next stage of the container registry DockerTaskStep update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update.IUpdate WithImageNames(IList<string> imageNames);
    }

    /// <summary>
    /// Container interface for all the updates related to a RegistryDockerTaskStep.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update.IDockerFilePath,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update.IImageNames,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update.IPush,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update.ICache,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update.IOverridingArgumentUpdate,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of the container registry DockerTaskStep update allowing to specify any overriding arguments.
    /// </summary>
    public interface IOverridingArgumentUpdate 
    {
        /// <summary>
        /// The function that specifies the overriding argument and what it will override.
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingArgument">The content of the overriding argument.</param>
        /// <return>The next stage of the container Docker task step update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update.IUpdate WithOverridingArgument(string name, OverridingArgument overridingArgument);

        /// <summary>
        /// The function that specifies the overriding arguments and what they will override.
        /// </summary>
        /// <param name="overridingArguments">Map with key of the name of the value to be overridden and value OverridingArgument specifying the content of the overriding argument.</param>
        /// <return>The next stage of the container Docker task step update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update.IUpdate WithOverridingArguments(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingArgument> overridingArguments);
    }

    /// <summary>
    /// The stage of the container registry DockerTaskStep update allowing to specify whether push is enabled or not.
    /// </summary>
    public interface IPush 
    {
        /// <summary>
        /// The function that specifies push is enabled.
        /// </summary>
        /// <param name="enabled">Whether push is enabled.</param>
        /// <return>The next stage of the container registry DockerTaskStep update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update.IUpdate WithPushEnabled(bool enabled);
    }

    /// <summary>
    /// The stage of the container registry DockerTaskStep update allowing to specify whether to have a cache or not.
    /// </summary>
    public interface ICache 
    {
        /// <summary>
        /// The function that specifies the task has a cache.
        /// </summary>
        /// <param name="enabled">Whether caching is enabled.</param>
        /// <return>The next stage of the container registry DockerTaskStep update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update.IUpdate WithCacheEnabled(bool enabled);
    }

    /// <summary>
    /// The stage of the container registry DockerTaskStep update allowing to specify the Docker file path.
    /// </summary>
    public interface IDockerFilePath 
    {
        /// <summary>
        /// The function that specifies the path to the Docker file.
        /// </summary>
        /// <param name="path">The path to the Docker file.</param>
        /// <return>The next stage of the container registry DockerTaskStep update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update.IUpdate WithDockerFilePath(string path);
    }
}