// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the container registry task definition for TaskRunRequests that allows the user to specify overriding values
    /// and whether archiving is enabled or not.
    /// </summary>
    public interface IRegistryTaskRunRequest  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestExecutable
    {
        /// <summary>
        /// The function that specifies archiving will or will not be enabled.
        /// </summary>
        /// <param name="enabled">Whether archive will be enabled.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRegistryTaskRunRequest WithArchiveEnabled(bool enabled);

        /// <summary>
        /// The function that specifies whether a single value will be overridden and what it will be overridden by.
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingValue">The OverridingValue specifying what the value will be overridden with.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRegistryTaskRunRequest WithOverridingValue(string name, OverridingValue overridingValue);

        /// <summary>
        /// The function that specifies whether there are any values that will be overridden and what they will be overridden by.
        /// </summary>
        /// <param name="overridingValues">A map that has the name of the value to be overridden as the key and the value is an OverridingValue.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRegistryTaskRunRequest WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues);
    }

    /// <summary>
    /// The stage of the container registry task run that specifies the AgentConfiguration for the container registry task run.
    /// </summary>
    public interface IAgentConfiguration 
    {
        /// <summary>
        /// The function that specifies the count of the CPU.
        /// </summary>
        /// <param name="count">The CPU count.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestExecutable WithCpuCount(int count);
    }

    /// <summary>
    /// The stage of the container registry task run definition which contains all the minimum required inputs for the resource to be executed
    /// if the task run request type is either file, encoded, or Docker, but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IRunRequestExecutableWithSourceLocation  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IAgentConfiguration,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestExecutable
    {
        /// <summary>
        /// The function that specifies the location of the source control.
        /// </summary>
        /// <param name="location">The location of the source control.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestExecutableWithSourceLocation WithSourceLocation(string location);

        /// <summary>
        /// The function that specifies the timeout.
        /// </summary>
        /// <param name="timeout">The time the timeout lasts.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestExecutableWithSourceLocation WithTimeout(int timeout);
    }

    /// <summary>
    /// The stage of the definition that specifies the task run request type.
    /// </summary>
    public interface IRunRequestType 
    {
        /// <summary>
        /// The function that specifies the task run request type will be a Docker task.
        /// </summary>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition.IBlank WithDockerTaskRunRequest();

        /// <summary>
        /// The function that specifies the task run request type will be an encoded task.
        /// </summary>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskRunRequest.Definition.IBlank WithEncodedTaskRunRequest();

        /// <summary>
        /// The function that specifies the task run request type will be a file task.
        /// </summary>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskRunRequest.Definition.IBlank WithFileTaskRunRequest();
    }

    /// <summary>
    /// The stage of the container registry task definition that specifies the platform for the container registry task run.
    /// </summary>
    public interface IPlatform 
    {
        /// <summary>
        /// The function that specifies the platform will have a Linux OS.
        /// </summary>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestType WithLinux();

        /// <summary>
        /// The function that specifies the platform will have a Linux OS with Architecture architecture.
        /// </summary>
        /// <param name="architecture">The architecture the platform will have.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestType WithLinux(Architecture architecture);

        /// <summary>
        /// The function that specifies the platform will have a Linux OS with Architecture architecture and Variant variant.
        /// </summary>
        /// <param name="architecture">The architecture the platform will have.</param>
        /// <param name="variant">The variant the platform will have.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestType WithLinux(Architecture architecture, Variant variant);

        /// <summary>
        /// The function that specifies the platform properties of the registry task run.
        /// </summary>
        /// <param name="platformProperties">The properties of the platform.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestType WithPlatform(PlatformProperties platformProperties);

        /// <summary>
        /// The function that specifies the platform will have a Windows OS.
        /// </summary>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestType WithWindows();

        /// <summary>
        /// The function that specifies the platform will have a Windows OS with Architecture architecture.
        /// </summary>
        /// <param name="architecture">The architecture the platform will have.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestType WithWindows(Architecture architecture);

        /// <summary>
        /// The function that specifies the platform will have a Windows OS with Architecture architecture and Variant variant.
        /// </summary>
        /// <param name="architecture">The architecture the platform will have.</param>
        /// <param name="variant">The variant the platform will have.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestType WithWindows(Architecture architecture, Variant variant);
    }

    /// <summary>
    /// Container interface for all the definitions related to a RegistryTaskRun.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IBlankFromRegistry,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IBlankFromRuns,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IPlatform,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IPlatformAltTaskRunRequest,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRegistryTaskRunRequest,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestType,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestExecutableWithSourceLocation,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestExecutable
    {
    }

    /// <summary>
    /// The stage of the definition in the case of using a TaskRunRequest which contains
    /// all the minimum required inputs for the resource to be executed, but also allows for any other optional settings
    /// to be specified.
    /// </summary>
    public interface IRunRequestExecutable  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IArchive,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun>
    {
    }

    /// <summary>
    /// The stage of the container registry task run definition that specifies the enabling and disabling of archiving.
    /// </summary>
    public interface IArchive 
    {
        /// <summary>
        /// The function that specifies archiving is enabled or disabled.
        /// </summary>
        /// <param name="enabled">Whether archiving is enabled or not.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestExecutable WithArchiveEnabled(bool enabled);
    }

    /// <summary>
    /// The stage of the container registry task run definition that allows to specify the task run is going to be run
    /// with a TaskRunRequest.
    /// </summary>
    public interface IPlatformAltTaskRunRequest  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IPlatform
    {
        /// <summary>
        /// The function that specifies the name of the existing task to run.
        /// </summary>
        /// <param name="taskName">The name of the created task to pass into the task run request.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRegistryTaskRunRequest WithTaskRunRequest(string taskName);
    }

    /// <summary>
    /// The first stage of a a RegistryTaskRun definition if originating from a call on a registry.
    /// </summary>
    public interface IBlankFromRegistry  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IPlatformAltTaskRunRequest
    {
    }

    /// <summary>
    /// The first stage of a RegistryTaskRun definition if definition is originating from a call on an existing RegistryTaskRun.
    /// </summary>
    public interface IBlankFromRuns 
    {
        /// <summary>
        /// The function that specifies the registry this task run is called on.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group of the registry.</param>
        /// <param name="registryName">The name of the registry.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IPlatformAltTaskRunRequest WithExistingRegistry(string resourceGroupName, string registryName);
    }
}