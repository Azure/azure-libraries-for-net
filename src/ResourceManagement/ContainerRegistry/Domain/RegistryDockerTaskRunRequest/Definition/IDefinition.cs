// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// The first stage of a container registry Docker task run request definition.
    /// </summary>
    public interface IBlank 
    {
        /// <summary>
        /// Gets The function that begins the definition of the Docker task step in the task run request.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the container Docker task run request definition.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition.IDockerFilePath DefineDockerTaskStep();
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be attached,
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IDockerTaskRunRequestStepAttachable  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IAttachable<Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestExecutableWithSourceLocation>
    {
        /// <summary>
        /// The function that specifies a cache will be used or not.
        /// </summary>
        /// <param name="enabled">Whether caching is enabled or not.</param>
        /// <return>The next stage of the container Docker task run request definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable WithCacheEnabled(bool enabled);

        /// <summary>
        /// The function that specifies the list of image names.
        /// </summary>
        /// <param name="imageNames">The list of image names.</param>
        /// <return>The next stage of the container Docker task run request definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable WithImageNames(IList<string> imageNames);

        /// <summary>
        /// The function that specifies the overriding argument and what it will override.
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingArgument">The content of the overriding argument.</param>
        /// <return>The next stage of the container Docker task run request definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable WithOverridingArgument(string name, OverridingArgument overridingArgument);

        /// <summary>
        /// The function that specifies the overriding arguments and what they will override.
        /// </summary>
        /// <param name="overridingArguments">Map with key of the name of the argument to be overridden and value OverridingArgument specifying the content of the overriding argument.</param>
        /// <return>The next stage of the container Docker task run request definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable WithOverridingArguments(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingArgument> overridingArguments);

        /// <summary>
        /// The function that specifies push is enabled or not.
        /// </summary>
        /// <param name="enabled">Whether push is enabled.</param>
        /// <return>The next stage of the container Docker task run request definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable WithPushEnabled(bool enabled);
    }

    /// <summary>
    /// The stage of the container Docker task run request definition that specifies the path to the Docker file.
    /// </summary>
    public interface IDockerFilePath 
    {
        /// <summary>
        /// The function that specifies the path to the Docker file.
        /// </summary>
        /// <param name="path">The path to the Docker file.</param>
        /// <return>The next stage of the container Docker task run request definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable WithDockerFilePath(string path);
    }

    /// <summary>
    /// Container interface for all the definitions related to a registry Docker task run request.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition.IBlank,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition.IDockerFilePath,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable
    {

    }
}