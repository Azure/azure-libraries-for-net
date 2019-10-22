// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using System.Collections.Generic;

    internal partial class RegistryDockerTaskStepImpl 
    {
        /// <summary>
        /// Gets the arguments this Docker task step.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.Argument> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryDockerTaskStep.Arguments
        {
            get
            {
                return this.Arguments();
            }
        }

        /// <summary>
        /// Gets Docker file path for this Docker task step.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryDockerTaskStep.DockerFilePath
        {
            get
            {
                return this.DockerFilePath();
            }
        }

        /// <summary>
        /// Gets the image names of this Docker task step.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryDockerTaskStep.ImageNames
        {
            get
            {
                return this.ImageNames();
            }
        }

        /// <summary>
        /// Gets whether push is enabled for this Docker task step.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryDockerTaskStep.IsPushEnabled
        {
            get
            {
                return this.IsPushEnabled();
            }
        }

        /// <summary>
        /// Gets whether there is no cache for this Docker task step.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryDockerTaskStep.NoCache
        {
            get
            {
                return this.NoCache();
            }
        }

        /// <summary>
        /// Attaches this child object's definition to its parent's definition.
        /// </summary>
        /// <return>The next stage of the parent object's definition.</return>
        RegistryTask.Definition.ISourceTriggerDefinition Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IAttachable<RegistryTask.Definition.ISourceTriggerDefinition>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Begins an update for a child resource.
        /// This is the beginning of the builder pattern used to update child resources
        /// The final method completing the update and continue
        /// the actual parent resource update process in Azure is  Settable.parent().
        /// </summary>
        /// <return>The stage of  parent resource update.</return>
        RegistryTask.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<RegistryTask.Update.IUpdate>.Parent()
        {
            return this.Parent();
        }

        /// <summary>
        /// The function that specifies the task has a cache.
        /// </summary>
        /// <param name="enabled">Whether caching is enabled.</param>
        /// <return>The next stage of the container registry DockerTaskStep update.</return>
        RegistryDockerTaskStep.Update.IUpdate RegistryDockerTaskStep.Update.ICache.WithCacheEnabled(bool enabled)
        {
            return this.WithCacheEnabled(enabled);
        }

        /// <summary>
        /// The function that specifies the use of a cache based on user input parameter.
        /// </summary>
        /// <param name="enabled">Whether caching will be enabled.</param>
        /// <return>The next step of the container registry DockerTaskStep definition.</return>
        RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable.WithCacheEnabled(bool enabled)
        {
            return this.WithCacheEnabled(enabled);
        }

        /// <summary>
        /// The function that specifies the path to the Docker file.
        /// </summary>
        /// <param name="path">The path to the Docker file.</param>
        /// <return>The next stage of the container registry DockerTaskStep definition.</return>
        RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable RegistryDockerTaskStep.Definition.IDockerFilePath.WithDockerFilePath(string path)
        {
            return this.WithDockerFilePath(path);
        }

        /// <summary>
        /// The function that specifies the path to the Docker file.
        /// </summary>
        /// <param name="path">The path to the Docker file.</param>
        /// <return>The next stage of the container registry DockerTaskStep update.</return>
        RegistryDockerTaskStep.Update.IUpdate RegistryDockerTaskStep.Update.IDockerFilePath.WithDockerFilePath(string path)
        {
            return this.WithDockerFilePath(path);
        }

        /// <summary>
        /// The function that specifies the image names.
        /// </summary>
        /// <param name="imageNames">The list of the names of the images.</param>
        /// <return>The next stage of the container registry DockerTaskStep update.</return>
        RegistryDockerTaskStep.Update.IUpdate RegistryDockerTaskStep.Update.IImageNames.WithImageNames(IList<string> imageNames)
        {
            return this.WithImageNames(imageNames);
        }

        /// <summary>
        /// The function that specifies the list of image names.
        /// </summary>
        /// <param name="imageNames">The image names.</param>
        /// <return>The next step of the container registry DockerTaskStep definition.</return>
        RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable.WithImageNames(IList<string> imageNames)
        {
            return this.WithImageNames(imageNames);
        }

        /// <summary>
        /// The function that specifies the overriding argument and what it will override.
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingArgument">The content of the overriding argument.</param>
        /// <return>The next stage of the container Docker task step update.</return>
        RegistryDockerTaskStep.Update.IUpdate RegistryDockerTaskStep.Update.IOverridingArgumentUpdate.WithOverridingArgument(string name, OverridingArgument overridingArgument)
        {
            return this.WithOverridingArgument(name, overridingArgument);
        }

        /// <summary>
        /// The function that specifies the overriding argument and what it will override.
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingArgument">The content of the overriding argument.</param>
        /// <return>The next stage of the container Docker task step definition.</return>
        RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable.WithOverridingArgument(string name, OverridingArgument overridingArgument)
        {
            return this.WithOverridingArgument(name, overridingArgument);
        }

        /// <summary>
        /// The function that specifies the overriding arguments and what they will override.
        /// </summary>
        /// <param name="overridingArguments">Map with key of the name of the value to be overridden and value OverridingArgument specifying the content of the overriding argument.</param>
        /// <return>The next stage of the container Docker task step update.</return>
        RegistryDockerTaskStep.Update.IUpdate RegistryDockerTaskStep.Update.IOverridingArgumentUpdate.WithOverridingArguments(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingArgument> overridingArguments)
        {
            return this.WithOverridingArguments(overridingArguments);
        }

        /// <summary>
        /// The function that specifies the overriding arguments and what they will override.
        /// </summary>
        /// <param name="overridingArguments">Map with key of the name of the value to be overridden and value OverridingArgument specifying the content of the overriding argument.</param>
        /// <return>The next stage of the container Docker task step definition.</return>
        RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable.WithOverridingArguments(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingArgument> overridingArguments)
        {
            return this.WithOverridingArguments(overridingArguments);
        }

        /// <summary>
        /// The function that specifies push is enabled.
        /// </summary>
        /// <param name="enabled">Whether push is enabled.</param>
        /// <return>The next stage of the container registry DockerTaskStep update.</return>
        RegistryDockerTaskStep.Update.IUpdate RegistryDockerTaskStep.Update.IPush.WithPushEnabled(bool enabled)
        {
            return this.WithPushEnabled(enabled);
        }

        /// <summary>
        /// The function that enables push depending on user input parameter.
        /// </summary>
        /// <param name="enabled">Whether push will be enabled.</param>
        /// <return>The next step of the container registry DockerTaskStep definition.</return>
        RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable RegistryDockerTaskStep.Definition.IDockerTaskStepAttachable.WithPushEnabled(bool enabled)
        {
            return this.WithPushEnabled(enabled);
        }
    }
}