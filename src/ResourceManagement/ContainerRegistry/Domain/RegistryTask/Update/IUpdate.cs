// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;

    /// <summary>
    /// Container interface for all the updates related to a registry task.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IPlatform,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.ITriggerTypes,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IAgentConfiguration,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.ITimeout,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.ITaskStepType,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask>
    {
    }

    /// <summary>
    /// The stage of the container registry task update that updates the timeout for the container registry task.
    /// </summary>
    public interface ITimeout 
    {
        /// <summary>
        /// The function that updates the timeout time.
        /// </summary>
        /// <param name="timeout">The time for timeout.</param>
        /// <return>The next stage of the container registry task update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate WithTimeout(int timeout);
    }

    /// <summary>
    /// The stage of the container registry task update that updates the AgentConfiguration for the container registry task.
    /// </summary>
    public interface IAgentConfiguration 
    {
        /// <summary>
        /// The function that updates the count of the CPU.
        /// </summary>
        /// <param name="count">The CPU count.</param>
        /// <return>The next stage of the container registry task update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate WithCpuCount(int count);
    }

    /// <summary>
    /// The stage of the container registry task update that allows users to update either a source trigger and/or a base image trigger.
    /// </summary>
    public interface ITriggerTypes 
    {
        /// <summary>
        /// The function that allows us to define a new source trigger in a registry task update.
        /// </summary>
        /// <param name="sourceTriggerName">The name of the new source trigger we are updating.</param>
        /// <return>The next stage of the RegistrySourceTrigger update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.IBlank DefineSourceTrigger(string sourceTriggerName);

        /// <summary>
        /// The function that defines a base image trigger with the two parameters required for base image trigger update.
        /// </summary>
        /// <param name="baseImageTriggerName">The name of the base image trigger.</param>
        /// <param name="baseImageTriggerType">The trigger type for the base image. Can be "All", "Runtime", or something else that the user inputs.</param>
        /// <return>The next stage of the container registry task update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate UpdateBaseImageTrigger(string baseImageTriggerName, BaseImageTriggerType baseImageTriggerType);

        /// <summary>
        /// The function that defines a base image trigger with all possible parameters for base image trigger update.
        /// </summary>
        /// <param name="baseImageTriggerName">The name of the base image trigger.</param>
        /// <param name="baseImageTriggerType">The trigger type for the base image. Can be "All", "Runtime", or something else that the user inputs.</param>
        /// <param name="triggerStatus">The status for the trigger. Can be enabled, disabled, or something else that the user inputs.</param>
        /// <return>The next stage of the container registry task update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate UpdateBaseImageTrigger(string baseImageTriggerName, BaseImageTriggerType baseImageTriggerType, TriggerStatus triggerStatus);

        /// <summary>
        /// The function that begins the definition of a source trigger.
        /// </summary>
        /// <return>The next stage of the RegistrySourceTrigger update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.Update.IUpdate UpdateSourceTrigger(string sourceTriggerName);
    }

    /// <summary>
    /// The stage of the container registry task update allowing to update the platform.
    /// </summary>
    public interface IPlatform 
    {
        /// <summary>
        /// The function that specifies a Linux OS system for the platform.
        /// </summary>
        /// <return>The next stage of the container registry task update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate WithLinux();

        /// <summary>
        /// The function that specifies a Linux OS system and architecture for the platform.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <return>The next stage of the container registry task update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate WithLinux(Architecture architecture);

        /// <summary>
        /// The function that specifies a Linux OS system, architecture, and CPU variant.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <param name="variant">The CPU variant.</param>
        /// <return>The next stage of the container registry task update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate WithLinux(Architecture architecture, Variant variant);

        /// <summary>
        /// The function that specifies a platform.
        /// </summary>
        /// <param name="platformProperties">The properties of the platform.</param>
        /// <return>The next stage of the container registry task update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate WithPlatform(PlatformUpdateParameters platformProperties);

        /// <summary>
        /// The function that specifies a Windows OS system for the platform.
        /// </summary>
        /// <return>The next stage of the container registry task update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate WithWindows();

        /// <summary>
        /// The function that specifies a Windows OS system and architecture for the platform.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <return>The next stage of the container registry task update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate WithWindows(Architecture architecture);

        /// <summary>
        /// The function that specifies a Windows OS system, architecture, and CPU variant.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <param name="variant">The CPU variant.</param>
        /// <return>The next stage of the container registry task update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate WithWindows(Architecture architecture, Variant variant);
    }

    /// <summary>
    /// The stage of the container registry task definition that specifies the type of task step.
    /// </summary>
    public interface ITaskStepType 
    {
        /// <summary>
        /// Gets The function that specifies a task step of type DockerTaskStep.
        /// </summary>
        /// <summary>
        /// Gets the first stage of the DockerTaskStep update.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Update.IUpdate UpdateDockerTaskStep();

        /// <summary>
        /// Gets The function that specifies a task step of type EncodedTaskStep.
        /// </summary>
        /// <summary>
        /// Gets the first stage of the EncodedTaskStep update.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Update.IUpdate UpdateEncodedTaskStep();

        /// <summary>
        /// Gets The function that specifies a task step of type FileTaskStep.
        /// </summary>
        /// <summary>
        /// Gets the first stage of the FileTaskStep update.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Update.IUpdate UpdateFileTaskStep();
    }
}