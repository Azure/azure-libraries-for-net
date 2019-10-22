// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Update;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Update;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.Update;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class RegistryTaskImpl
    {
        /// <summary>
        /// Gets the CPU count.
        /// </summary>
        int Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask.CpuCount
        {
            get
            {
                return this.CpuCount();
            }
        }

        /// <summary>
        /// Gets the creation date of build task.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask.CreationDate
        {
            get
            {
                return this.CreationDate();
            }
        }

        /// <summary>
        /// Gets The function that specifies a task step of type DockerTaskStep.
        /// </summary>
        /// <summary>
        /// Gets the first stage of the DockerTaskStep definition.
        /// </summary>
        RegistryDockerTaskStep.Definition.IBlank RegistryTask.Definition.ITaskStepType.DefineDockerTaskStep()
        {
            return this.DefineDockerTaskStep();
        }

        /// <summary>
        /// Gets The function that specifies a task step of type EncodedTaskStep.
        /// </summary>
        /// <summary>
        /// Gets the first stage of the EncodedTaskStep definition.
        /// </summary>
        RegistryEncodedTaskStep.Definition.IBlank RegistryTask.Definition.ITaskStepType.DefineEncodedTaskStep()
        {
            return this.DefineEncodedTaskStep();
        }

        /// <summary>
        /// Gets The function that specifies a task step of type FileTaskStep.
        /// </summary>
        /// <summary>
        /// Gets the first stage of the FileTaskStep definition.
        /// </summary>
        RegistryFileTaskStep.Definition.IBlank RegistryTask.Definition.ITaskStepType.DefineFileTaskStep()
        {
            return this.DefineFileTaskStep();
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the index key.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable.Key
        {
            get
            {
                return this.Key();
            }
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the parent ID of this resource.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask.ParentRegistryId
        {
            get
            {
                return this.ParentRegistryId();
            }
        }

        /// <summary>
        /// Gets the build timeout settings in seconds.
        /// </summary>
        Models.PlatformProperties Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask.Platform
        {
            get
            {
                return this.Platform();
            }
        }

        /// <summary>
        /// Gets the provisioning state of the build task.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the region the resource is in.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Region
        {
            get
            {
                return this.Region();
            }
        }

        /// <summary>
        /// Gets the name of the region the resource is in.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.RegionName
        {
            get
            {
                return this.RegionName();
            }
        }

        /// <summary>
        /// Gets the RegistryTaskStep of the current task.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskStep Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask.RegistryTaskStep
        {
            get
            {
                return this.RegistryTaskStep();
            }
        }

        /// <summary>
        /// Gets the name of the resource's resource group.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Gets the source triggers of the task.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistrySourceTrigger> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask.SourceTriggers
        {
            get
            {
                return this.SourceTriggers();
            }
        }

        /// <summary>
        /// Gets the current status of build task.
        /// </summary>
        Models.TaskStatus Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// Gets the tags for the resource.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Tags
        {
            get
            {
                return this.Tags();
            }
        }

        /// <summary>
        /// Gets the build timeout settings in seconds.
        /// </summary>
        int Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask.Timeout
        {
            get
            {
                return this.Timeout();
            }
        }

        /// <summary>
        /// Gets the trigger of the task.
        /// </summary>
        Models.TriggerProperties Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask.Trigger
        {
            get
            {
                return this.Trigger();
            }
        }

        /// <summary>
        /// Gets the type of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Begin update stage of DockerTaskStep.
        /// </summary>
        /// <returns>the first stage of the DockerTaskStep update</returns>
        RegistryDockerTaskStep.Update.IUpdate RegistryTask.Update.ITaskStepType.UpdateDockerTaskStep()
        {
            return this.UpdateDockerTaskStep();
        }

        /// <summary>
        /// Begin update stage of EncodedTaskStep.
        /// </summary>
        /// <returns>the first stage of the EncodedTaskStep update</returns>
        RegistryEncodedTaskStep.Update.IUpdate RegistryTask.Update.ITaskStepType.UpdateEncodedTaskStep()
        {
            return this.UpdateEncodedTaskStep();
        }

        /// <summary>
        /// Begin update stage of FileTaskStep.
        /// </summary>
        /// <returns>the first stage of the FileTaskStep update</returns>
        RegistryFileTaskStep.Update.IUpdate RegistryTask.Update.ITaskStepType.UpdateFileTaskStep()
        {
            return this.UpdateFileTaskStep();
        }

        /// <summary>
        /// Execute the update request.
        /// </summary>
        /// <return>The updated resource.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask>.Apply()
        {
            return this.Apply();
        }

        /// <summary>
        /// Execute the update request asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask>.ApplyAsync(CancellationToken cancellationToken, bool multiThreaded = true)
        {
            return await this.ApplyAsync(cancellationToken);
        }

        /// <summary>
        /// Execute the create request.
        /// </summary>
        /// <return>The create resource.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask>.Create()
        {
            return this.Create();
        }

        /// <summary>
        /// Puts the request into the queue and allow the HTTP client to execute
        /// it when system resources are available.
        /// </summary>
        /// <return>An observable of the request.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask>.CreateAsync(CancellationToken cancellationToken, bool multiThreaded = true)
        {
            return await this.CreateAsync(cancellationToken);
        }

        /// <summary>
        /// The function that begins the definition of a source trigger.
        /// </summary>
        /// <param name="sourceTriggerName">The name of the source trigger we are defining.</param>
        /// <return>The first stage of the RegistrySourceTrigger definition.</return>
        RegistrySourceTrigger.Definition.IBlank RegistryTask.Definition.ITriggerTypes.DefineSourceTrigger(string sourceTriggerName)
        {
            return this.DefineSourceTrigger(sourceTriggerName);
        }

        /// <summary>
        /// The function that allows us to define a new source trigger in a registry task update.
        /// </summary>
        /// <param name="sourceTriggerName">The name of the new source trigger we are updating.</param>
        /// <return>The next stage of the RegistrySourceTrigger update.</return>
        RegistrySourceTrigger.UpdateDefinition.IBlank RegistryTask.Update.ITriggerTypes.DefineSourceTrigger(string sourceTriggerName)
        {
            return this.DefineSourceTrigger(sourceTriggerName);
        }

        /// <summary>
        /// The function that begins the definition of a source trigger.
        /// </summary>
        /// <param name="sourceTriggerName">The name of the source trigger we are defining.</param>
        /// <return>The first stage of the RegistrySourceTrigger definition.</return>
        RegistrySourceTrigger.Definition.IBlank RegistryTask.Definition.ISourceTriggerDefinition.DefineSourceTrigger(string sourceTriggerName)
        {
            return this.DefineSourceTrigger(sourceTriggerName);
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask>.Refresh()
        {
            return this.Refresh();
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken);
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        RegistryTask.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<RegistryTask.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// The function that defines a base image trigger with the two parameters required for base image trigger update.
        /// </summary>
        /// <param name="baseImageTriggerName">The name of the base image trigger.</param>
        /// <param name="baseImageTriggerType">The trigger type for the base image. Can be "All", "Runtime", or something else that the user inputs.</param>
        /// <return>The next stage of the container registry task update.</return>
        RegistryTask.Update.IUpdate RegistryTask.Update.ITriggerTypes.UpdateBaseImageTrigger(string baseImageTriggerName, BaseImageTriggerType baseImageTriggerType)
        {
            return this.UpdateBaseImageTrigger(baseImageTriggerName, baseImageTriggerType);
        }

        /// <summary>
        /// The function that defines a base image trigger with all possible parameters for base image trigger update.
        /// </summary>
        /// <param name="baseImageTriggerName">The name of the base image trigger.</param>
        /// <param name="baseImageTriggerType">The trigger type for the base image. Can be "All", "Runtime", or something else that the user inputs.</param>
        /// <param name="triggerStatus">The status for the trigger. Can be enabled, disabled, or something else that the user inputs.</param>
        /// <return>The next stage of the container registry task update.</return>
        RegistryTask.Update.IUpdate RegistryTask.Update.ITriggerTypes.UpdateBaseImageTrigger(string baseImageTriggerName, BaseImageTriggerType baseImageTriggerType, TriggerStatus triggerStatus)
        {
            return this.UpdateBaseImageTrigger(baseImageTriggerName, baseImageTriggerType, triggerStatus);
        }

        /// <summary>
        /// The function that begins the definition of a source trigger.
        /// </summary>
        /// <return>The next stage of the RegistrySourceTrigger update.</return>
        RegistrySourceTrigger.Update.IUpdate RegistryTask.Update.ITriggerTypes.UpdateSourceTrigger(string sourceTriggerName)
        {
            return this.UpdateSourceTrigger(sourceTriggerName);
        }

        /// <summary>
        /// The function that defines a base image trigger with the two parameters required for base image trigger creation.
        /// </summary>
        /// <param name="baseImageTriggerName">The name of the base image trigger.</param>
        /// <param name="baseImageTriggerType">The trigger type for the base image. Can be "All", "Runtime", or something else that the user inputs.</param>
        /// <return>The next stage of the container registry task definition.</return>
        RegistryTask.Definition.ITaskCreatable RegistryTask.Definition.ITriggerTypes.WithBaseImageTrigger(string baseImageTriggerName, BaseImageTriggerType baseImageTriggerType)
        {
            return this.WithBaseImageTrigger(baseImageTriggerName, baseImageTriggerType);
        }

        /// <summary>
        /// The function that defines a base image trigger with all possible parameters for base image trigger creation.
        /// </summary>
        /// <param name="baseImageTriggerName">The name of the base image trigger.</param>
        /// <param name="baseImageTriggerType">The trigger type for the base image. Can be "All", "Runtime", or something else that the user inputs.</param>
        /// <param name="triggerStatus">The status for the trigger. Can be enabled, disabled, or something else that the user inputs.</param>
        /// <return>The next stage of the container registry task definition.</return>
        RegistryTask.Definition.ITaskCreatable RegistryTask.Definition.ITriggerTypes.WithBaseImageTrigger(string baseImageTriggerName, BaseImageTriggerType baseImageTriggerType, TriggerStatus triggerStatus)
        {
            return this.WithBaseImageTrigger(baseImageTriggerName, baseImageTriggerType, triggerStatus);
        }

        /// <summary>
        /// The function that specifies the count of the CPU.
        /// </summary>
        /// <param name="count">The CPU count.</param>
        /// <return>The next stage of the container registry task definition.</return>
        RegistryTask.Definition.ITaskCreatable RegistryTask.Definition.IAgentConfiguration.WithCpuCount(int count)
        {
            return this.WithCpuCount(count);
        }

        /// <summary>
        /// The function that updates the count of the CPU.
        /// </summary>
        /// <param name="count">The CPU count.</param>
        /// <return>The next stage of the container registry task update.</return>
        RegistryTask.Update.IUpdate RegistryTask.Update.IAgentConfiguration.WithCpuCount(int count)
        {
            return this.WithCpuCount(count);
        }

        /// <summary>
        /// The parameters referencing an existing container registry under which this task resides.
        /// </summary>
        /// <param name="resourceGroupName">The name of the parent container registry resource group.</param>
        /// <param name="registryName">The name of the existing container registry.</param>
        /// <return>The next stage of the container registry task definition.</return>
        RegistryTask.Definition.ILocation RegistryTask.Definition.IBlank.WithExistingRegistry(string resourceGroupName, string registryName)
        {
            return this.WithExistingRegistry(resourceGroupName, registryName);
        }

        /// <summary>
        /// The function that specifies a Linux OS system for the platform.
        /// </summary>
        /// <return>The next stage of the container registry task definition.</return>
        RegistryTask.Definition.ITaskStepType RegistryTask.Definition.IPlatform.WithLinux()
        {
            return this.WithLinux();
        }

        /// <summary>
        /// The function that specifies a Linux OS system and architecture for the platform.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <return>The next stage of the container registry task definition.</return>
        RegistryTask.Definition.ITaskStepType RegistryTask.Definition.IPlatform.WithLinux(Architecture architecture)
        {
            return this.WithLinux(architecture);
        }

        /// <summary>
        /// The function that specifies a Linux OS system, architecture, and CPU variant.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <param name="variant">The CPU variant.</param>
        /// <return>The next stage of the container registry task definition.</return>
        RegistryTask.Definition.ITaskStepType RegistryTask.Definition.IPlatform.WithLinux(Architecture architecture, Variant variant)
        {
            return this.WithLinux(architecture, variant);
        }

        /// <summary>
        /// The function that specifies a Linux OS system for the platform.
        /// </summary>
        /// <return>The next stage of the container registry task update.</return>
        RegistryTask.Update.IUpdate RegistryTask.Update.IPlatform.WithLinux()
        {
            return this.WithLinux();
        }

        /// <summary>
        /// The function that specifies a Linux OS system and architecture for the platform.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <return>The next stage of the container registry task update.</return>
        RegistryTask.Update.IUpdate RegistryTask.Update.IPlatform.WithLinux(Architecture architecture)
        {
            return this.WithLinux(architecture);
        }

        /// <summary>
        /// The function that specifies a Linux OS system, architecture, and CPU variant.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <param name="variant">The CPU variant.</param>
        /// <return>The next stage of the container registry task update.</return>
        RegistryTask.Update.IUpdate RegistryTask.Update.IPlatform.WithLinux(Architecture architecture, Variant variant)
        {
            return this.WithLinux(architecture, variant);
        }

        /// <summary>
        /// The parameters specifying location of the container registry task.
        /// </summary>
        /// <param name="location">The location of the container registry task.</param>
        /// <return>The next stage of the container registry task definition.</return>
        RegistryTask.Definition.IPlatform RegistryTask.Definition.ILocation.WithLocation(string location)
        {
            return this.WithLocation(location);
        }

        /// <summary>
        /// The parameters specifying location of the container registry task.
        /// </summary>
        /// <param name="location">The location of the container registry task.</param>
        /// <return>The next stage of the container registry task definition.</return>
        RegistryTask.Definition.IPlatform RegistryTask.Definition.ILocation.WithLocation(Region location)
        {
            return this.WithLocation(location);
        }

        /// <summary>
        /// The function that specifies a platform.
        /// </summary>
        /// <param name="platformProperties">The properties of the platform.</param>
        /// <return>The next stage of the container registry task definition.</return>
        RegistryTask.Definition.ITaskStepType RegistryTask.Definition.IPlatform.WithPlatform(PlatformProperties platformProperties)
        {
            return this.WithPlatform(platformProperties);
        }

        /// <summary>
        /// The function that specifies a platform.
        /// </summary>
        /// <param name="platformProperties">The properties of the platform.</param>
        /// <return>The next stage of the container registry task update.</return>
        RegistryTask.Update.IUpdate RegistryTask.Update.IPlatform.WithPlatform(PlatformUpdateParameters platformProperties)
        {
            return this.WithPlatform(platformProperties);
        }

        /// <summary>
        /// The function that sets the timeout time.
        /// </summary>
        /// <param name="timeout">The time for timeout.</param>
        /// <return>The next stage of the container registry task definition.</return>
        RegistryTask.Definition.ITaskCreatable RegistryTask.Definition.ITimeout.WithTimeout(int timeout)
        {
            return this.WithTimeout(timeout);
        }

        /// <summary>
        /// The function that updates the timeout time.
        /// </summary>
        /// <param name="timeout">The time for timeout.</param>
        /// <return>The next stage of the container registry task update.</return>
        RegistryTask.Update.IUpdate RegistryTask.Update.ITimeout.WithTimeout(int timeout)
        {
            return this.WithTimeout(timeout);
        }

        /// <summary>
        /// The function that specifies a Windows OS system for the platform.
        /// </summary>
        /// <return>The next stage of the container registry task definition.</return>
        RegistryTask.Definition.ITaskStepType RegistryTask.Definition.IPlatform.WithWindows()
        {
            return this.WithWindows();
        }

        /// <summary>
        /// The function that specifies a Windows OS system and architecture for the platform.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <return>The next stage of the container registry task definition.</return>
        RegistryTask.Definition.ITaskStepType RegistryTask.Definition.IPlatform.WithWindows(Architecture architecture)
        {
            return this.WithWindows(architecture);
        }

        /// <summary>
        /// The function that specifies a Windows OS system, architecture, and CPU variant.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <param name="variant">The CPU variant.</param>
        /// <return>The next stage of the container registry task definition.</return>
        RegistryTask.Definition.ITaskStepType RegistryTask.Definition.IPlatform.WithWindows(Architecture architecture, Variant variant)
        {
            return this.WithWindows(architecture, variant);
        }

        /// <summary>
        /// The function that specifies a Windows OS system for the platform.
        /// </summary>
        /// <return>The next stage of the container registry task update.</return>
        RegistryTask.Update.IUpdate RegistryTask.Update.IPlatform.WithWindows()
        {
            return this.WithWindows();
        }

        /// <summary>
        /// The function that specifies a Windows OS system and architecture for the platform.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <return>The next stage of the container registry task update.</return>
        RegistryTask.Update.IUpdate RegistryTask.Update.IPlatform.WithWindows(Architecture architecture)
        {
            return this.WithWindows(architecture);
        }

        /// <summary>
        /// The function that specifies a Windows OS system, architecture, and CPU variant.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <param name="variant">The CPU variant.</param>
        /// <return>The next stage of the container registry task update.</return>
        RegistryTask.Update.IUpdate RegistryTask.Update.IPlatform.WithWindows(Architecture architecture, Variant variant)
        {
            return this.WithWindows(architecture, variant);
        }
    }
}