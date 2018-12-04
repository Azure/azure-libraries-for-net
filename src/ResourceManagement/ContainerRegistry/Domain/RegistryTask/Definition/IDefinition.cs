// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created,
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface ITaskCreatable  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.IAgentConfiguration,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITimeout,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ISourceTriggerDefinition,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITriggerTypes,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask>
    {
    }

    /// <summary>
    /// Container interface for all the definitions related to a registry task.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.IBlank,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ILocation,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.IPlatform,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITaskStepType,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ISourceTriggerDefinition,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITriggerTypes,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITaskCreatable
    {
    }

    /// <summary>
    /// The stage of the container registry task definition that allows users to define either a source trigger and/or a base image trigger.
    /// </summary>
    public interface ITriggerTypes 
    {
        /// <summary>
        /// The function that begins the definition of a source trigger.
        /// </summary>
        /// <param name="sourceTriggerName">The name of the source trigger we are defining.</param>
        /// <return>The first stage of the RegistrySourceTrigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.Definition.IBlank DefineSourceTrigger(string sourceTriggerName);

        /// <summary>
        /// The function that defines a base image trigger with the two parameters required for base image trigger creation.
        /// </summary>
        /// <param name="baseImageTriggerName">The name of the base image trigger.</param>
        /// <param name="baseImageTriggerType">The trigger type for the base image. Can be "All", "Runtime", or something else that the user inputs.</param>
        /// <return>The next stage of the container registry task definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITaskCreatable WithBaseImageTrigger(string baseImageTriggerName, BaseImageTriggerType baseImageTriggerType);

        /// <summary>
        /// The function that defines a base image trigger with all possible parameters for base image trigger creation.
        /// </summary>
        /// <param name="baseImageTriggerName">The name of the base image trigger.</param>
        /// <param name="baseImageTriggerType">The trigger type for the base image. Can be "All", "Runtime", or something else that the user inputs.</param>
        /// <param name="triggerStatus">The status for the trigger. Can be enabled, disabled, or something else that the user inputs.</param>
        /// <return>The next stage of the container registry task definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITaskCreatable WithBaseImageTrigger(string baseImageTriggerName, BaseImageTriggerType baseImageTriggerType, TriggerStatus triggerStatus);
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
        /// Gets the first stage of the DockerTaskStep definition.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskStep.Definition.IBlank DefineDockerTaskStep();

        /// <summary>
        /// Gets The function that specifies a task step of type EncodedTaskStep.
        /// </summary>
        /// <summary>
        /// Gets the first stage of the EncodedTaskStep definition.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Definition.IBlank DefineEncodedTaskStep();

        /// <summary>
        /// Gets The function that specifies a task step of type FileTaskStep.
        /// </summary>
        /// <summary>
        /// Gets the first stage of the FileTaskStep definition.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Definition.IBlank DefineFileTaskStep();
    }

    /// <summary>
    /// The stage of the container registry task definition allowing to specify location.
    /// </summary>
    public interface ILocation 
    {
        /// <summary>
        /// The parameters specifying location of the container registry task.
        /// </summary>
        /// <param name="location">The location of the container registry task.</param>
        /// <return>The next stage of the container registry task definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.IPlatform WithLocation(string location);

        /// <summary>
        /// The parameters specifying location of the container registry task.
        /// </summary>
        /// <param name="location">The location of the container registry task.</param>
        /// <return>The next stage of the container registry task definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.IPlatform WithLocation(Region location);
    }

    /// <summary>
    /// The stage of the container registry task definition allowing to specify the platform.
    /// </summary>
    public interface IPlatform 
    {
        /// <summary>
        /// The function that specifies a Linux OS system for the platform.
        /// </summary>
        /// <return>The next stage of the container registry task definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITaskStepType WithLinux();

        /// <summary>
        /// The function that specifies a Linux OS system and architecture for the platform.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <return>The next stage of the container registry task definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITaskStepType WithLinux(Architecture architecture);

        /// <summary>
        /// The function that specifies a Linux OS system, architecture, and CPU variant.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <param name="variant">The CPU variant.</param>
        /// <return>The next stage of the container registry task definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITaskStepType WithLinux(Architecture architecture, Variant variant);

        /// <summary>
        /// The function that specifies a platform.
        /// </summary>
        /// <param name="platformProperties">The properties of the platform.</param>
        /// <return>The next stage of the container registry task definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITaskStepType WithPlatform(PlatformProperties platformProperties);

        /// <summary>
        /// The function that specifies a Windows OS system for the platform.
        /// </summary>
        /// <return>The next stage of the container registry task definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITaskStepType WithWindows();

        /// <summary>
        /// The function that specifies a Windows OS system and architecture for the platform.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <return>The next stage of the container registry task definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITaskStepType WithWindows(Architecture architecture);

        /// <summary>
        /// The function that specifies a Windows OS system, architecture, and CPU variant.
        /// </summary>
        /// <param name="architecture">The CPU architecture.</param>
        /// <param name="variant">The CPU variant.</param>
        /// <return>The next stage of the container registry task definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITaskStepType WithWindows(Architecture architecture, Variant variant);
    }

    /// <summary>
    /// The stage of the container registry task definition that allows users to define a source trigger.
    /// </summary>
    public interface ISourceTriggerDefinition 
    {
        /// <summary>
        /// The function that begins the definition of a source trigger.
        /// </summary>
        /// <param name="sourceTriggerName">The name of the source trigger we are defining.</param>
        /// <return>The first stage of the RegistrySourceTrigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.Definition.IBlank DefineSourceTrigger(string sourceTriggerName);
    }

    /// <summary>
    /// The first stage of a container registry task definition.
    /// </summary>
    public interface IBlank 
    {
        /// <summary>
        /// The parameters referencing an existing container registry under which this task resides.
        /// </summary>
        /// <param name="resourceGroupName">The name of the parent container registry resource group.</param>
        /// <param name="registryName">The name of the existing container registry.</param>
        /// <return>The next stage of the container registry task definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ILocation WithExistingRegistry(string resourceGroupName, string registryName);
    }

    /// <summary>
    /// The stage of the container registry task definition that specifies the timeout for the container registry task.
    /// </summary>
    public interface ITimeout 
    {
        /// <summary>
        /// The function that sets the timeout time.
        /// </summary>
        /// <param name="timeout">The time for timeout.</param>
        /// <return>The next stage of the container registry task definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITaskCreatable WithTimeout(int timeout);
    }

    /// <summary>
    /// The stage of the container registry task definition that specifies the AgentConfiguration for the container registry task.
    /// </summary>
    public interface IAgentConfiguration 
    {
        /// <summary>
        /// The function that specifies the count of the CPU.
        /// </summary>
        /// <param name="count">The CPU count.</param>
        /// <return>The next stage of the container registry task definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ITaskCreatable WithCpuCount(int count);
    }
}