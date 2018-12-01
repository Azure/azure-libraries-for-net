// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using System.Collections.Generic;

    internal partial class RegistryDockerTaskRunRequestImpl 
    {
        /// <summary>
        /// Gets the number of CPUs.
        /// </summary>
        int Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryDockerTaskRunRequest.CpuCount
        {
            get
            {
                return this.CpuCount();
            }
        }

        /// <summary>
        /// Gets The function that begins the definition of the Docker task step in the task run request.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the container Docker task run request definition.
        /// </summary>
        RegistryDockerTaskRunRequest.Definition.IDockerFilePath RegistryDockerTaskRunRequest.Definition.IBlank.DefineDockerTaskStep()
        {
            return this.DefineDockerTaskStep();
        }

        /// <summary>
        /// Gets whether archive is enabled.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryDockerTaskRunRequest.IsArchiveEnabled
        {
            get
            {
                return this.IsArchiveEnabled();
            }
        }

        /// <summary>
        /// Gets the properties of the platform.
        /// </summary>
        Models.PlatformProperties Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryDockerTaskRunRequest.Platform
        {
            get
            {
                return this.Platform();
            }
        }

        /// <summary>
        /// Gets the location of the source control.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryDockerTaskRunRequest.SourceLocation
        {
            get
            {
                return this.SourceLocation();
            }
        }

        /// <summary>
        /// Gets the length of the timeout.
        /// </summary>
        int Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryDockerTaskRunRequest.Timeout
        {
            get
            {
                return this.Timeout();
            }
        }

        /// <summary>
        /// Attaches this child object's definition to its parent's definition.
        /// </summary>
        /// <return>The next stage of the parent object's definition.</return>
        RegistryTaskRun.Definition.IRunRequestExecutableWithSourceLocation Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IAttachable<RegistryTaskRun.Definition.IRunRequestExecutableWithSourceLocation>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// The function that specifies a cache will be used or not.
        /// </summary>
        /// <param name="enabled">Whether caching is enabled or not.</param>
        /// <return>The next stage of the container Docker task run request definition.</return>
        RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable.WithCacheEnabled(bool enabled)
        {
            return this.WithCacheEnabled(enabled);
        }

        /// <summary>
        /// The function that specifies the path to the Docker file.
        /// </summary>
        /// <param name="path">The path to the Docker file.</param>
        /// <return>The next stage of the container Docker task run request definition.</return>
        RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable RegistryDockerTaskRunRequest.Definition.IDockerFilePath.WithDockerFilePath(string path)
        {
            return this.WithDockerFilePath(path);
        }

        /// <summary>
        /// The function that specifies the list of image names.
        /// </summary>
        /// <param name="imageNames">The list of image names.</param>
        /// <return>The next stage of the container Docker task run request definition.</return>
        RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable.WithImageNames(IList<string> imageNames)
        {
            return this.WithImageNames(imageNames);
        }

        /// <summary>
        /// The function that specifies the overriding argument and what it will override.
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingArgument">The content of the overriding argument.</param>
        /// <return>The next stage of the container Docker task run request definition.</return>
        RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable.WithOverridingArgument(string name, OverridingArgument overridingArgument)
        {
            return this.WithOverridingArgument(name, overridingArgument);
        }

        /// <summary>
        /// The function that specifies the overriding arguments and what they will override.
        /// </summary>
        /// <param name="overridingArguments">Map with key of the name of the argument to be overridden and value OverridingArgument specifying the content of the overriding argument.</param>
        /// <return>The next stage of the container Docker task run request definition.</return>
        RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable.WithOverridingArguments(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingArgument> overridingArguments)
        {
            return this.WithOverridingArguments(overridingArguments);
        }

        /// <summary>
        /// The function that specifies push is enabled or not.
        /// </summary>
        /// <param name="enabled">Whether push is enabled.</param>
        /// <return>The next stage of the container Docker task run request definition.</return>
        RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable RegistryDockerTaskRunRequest.Definition.IDockerTaskRunRequestStepAttachable.WithPushEnabled(bool enabled)
        {
            return this.WithPushEnabled(enabled);
        }
    }
}