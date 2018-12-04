// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class RegistryTaskRunImpl 
    {
        /// <summary>
        /// Gets the numbers of cpu.
        /// </summary>
        int Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun.Cpu
        {
            get
            {
                return this.Cpu();
            }
        }

        /// <summary>
        /// Gets the time when the run request was created.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun.CreateTime
        {
            get
            {
                return this.CreateTime();
            }
        }

        /// <summary>
        /// Gets whether archiving is enabled for the run request.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun.IsArchiveEnabled
        {
            get
            {
                return this.IsArchiveEnabled();
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
        /// Gets the last time the run request was updated.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun.LastUpdatedTime
        {
            get
            {
                return this.LastUpdatedTime();
            }
        }

        /// <summary>
        /// Gets the platform properties of the run request.
        /// </summary>
        Models.PlatformProperties Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun.Platform
        {
            get
            {
                return this.Platform();
            }
        }

        /// <summary>
        /// Gets the provisioning state of the run request.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the registry name of this task run request.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun.RegistryName
        {
            get
            {
                return this.RegistryName();
            }
        }

        /// <summary>
        /// Gets the name of the resource group for this task run request.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Gets the id of the run.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun.RunId
        {
            get
            {
                return this.RunId();
            }
        }

        /// <summary>
        /// Gets the run type of the run request.
        /// </summary>
        Models.RunType Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun.RunType
        {
            get
            {
                return this.RunType();
            }
        }

        /// <summary>
        /// Gets the status of the run request.
        /// </summary>
        Models.RunStatus Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// Gets the name of the task in the case of a TaskRunRequest (or null if task is still queued), null in other cases.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun.TaskName
        {
            get
            {
                return this.TaskName();
            }
        }

        /// <summary>
        /// Execute the request.
        /// </summary>
        /// <return>Execution result object.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun>.Execute()
        {
            return this.Execute();
        }

        /// <summary>
        /// Execute the request asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun>.ExecuteAsync(CancellationToken cancellationToken, bool multiThreaded = true)
        {
            return await this.ExecuteAsync(cancellationToken);
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun>.Refresh()
        {
            return this.Refresh();
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken);
        }

        /// <summary>
        /// The function that specifies archiving will or will not be enabled.
        /// </summary>
        /// <param name="enabled">Whether archive will be enabled.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRegistryTaskRunRequest RegistryTaskRun.Definition.IRegistryTaskRunRequest.WithArchiveEnabled(bool enabled)
        {
            return this.WithArchiveEnabled(enabled);
        }

        /// <summary>
        /// The function that specifies archiving is enabled or disabled.
        /// </summary>
        /// <param name="enabled">Whether archiving is enabled or not.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRunRequestExecutable RegistryTaskRun.Definition.IArchive.WithArchiveEnabled(bool enabled)
        {
            return this.WithArchiveEnabled(enabled);
        }

        /// <summary>
        /// The function that specifies the count of the CPU.
        /// </summary>
        /// <param name="count">The CPU count.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRunRequestExecutable RegistryTaskRun.Definition.IAgentConfiguration.WithCpuCount(int count)
        {
            return this.WithCpuCount(count);
        }

        /// <summary>
        /// The function that specifies the task run request type will be a Docker task.
        /// </summary>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryDockerTaskRunRequest.Definition.IBlank RegistryTaskRun.Definition.IRunRequestType.WithDockerTaskRunRequest()
        {
            return this.WithDockerTaskRunRequest();
        }

        /// <summary>
        /// The function that specifies the task run request type will be an encoded task.
        /// </summary>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryEncodedTaskRunRequest.Definition.IBlank RegistryTaskRun.Definition.IRunRequestType.WithEncodedTaskRunRequest()
        {
            return this.WithEncodedTaskRunRequest();
        }

        /// <summary>
        /// The function that specifies the registry this task run is called on.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group of the registry.</param>
        /// <param name="registryName">The name of the registry.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IPlatformAltTaskRunRequest RegistryTaskRun.Definition.IBlankFromRuns.WithExistingRegistry(string resourceGroupName, string registryName)
        {
            return this.WithExistingRegistry(resourceGroupName, registryName);
        }

        /// <summary>
        /// The function that specifies the task run request type will be a file task.
        /// </summary>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryFileTaskRunRequest.Definition.IBlank RegistryTaskRun.Definition.IRunRequestType.WithFileTaskRunRequest()
        {
            return this.WithFileTaskRunRequest();
        }

        /// <summary>
        /// The function that specifies the platform will have a Linux OS.
        /// </summary>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRunRequestType RegistryTaskRun.Definition.IPlatform.WithLinux()
        {
            return this.WithLinux();
        }

        /// <summary>
        /// The function that specifies the platform will have a Linux OS with Architecture architecture.
        /// </summary>
        /// <param name="architecture">The architecture the platform will have.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRunRequestType RegistryTaskRun.Definition.IPlatform.WithLinux(Architecture architecture)
        {
            return this.WithLinux(architecture);
        }

        /// <summary>
        /// The function that specifies the platform will have a Linux OS with Architecture architecture and Variant variant.
        /// </summary>
        /// <param name="architecture">The architecture the platform will have.</param>
        /// <param name="variant">The variant the platform will have.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRunRequestType RegistryTaskRun.Definition.IPlatform.WithLinux(Architecture architecture, Variant variant)
        {
            return this.WithLinux(architecture, variant);
        }

        /// <summary>
        /// The function that specifies whether a single value will be overridden and what it will be overridden by.
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingValue">The OverridingValue specifying what the value will be overridden with.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRegistryTaskRunRequest RegistryTaskRun.Definition.IRegistryTaskRunRequest.WithOverridingValue(string name, OverridingValue overridingValue)
        {
            return this.WithOverridingValue(name, overridingValue);
        }

        /// <summary>
        /// The function that specifies whether there are any values that will be overridden and what they will be overridden by.
        /// </summary>
        /// <param name="overridingValues">A map that has the name of the value to be overridden as the key and the value is an OverridingValue.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRegistryTaskRunRequest RegistryTaskRun.Definition.IRegistryTaskRunRequest.WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues)
        {
            return this.WithOverridingValues(overridingValues);
        }

        /// <summary>
        /// The function that specifies the platform properties of the registry task run.
        /// </summary>
        /// <param name="platformProperties">The properties of the platform.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRunRequestType RegistryTaskRun.Definition.IPlatform.WithPlatform(PlatformProperties platformProperties)
        {
            return this.WithPlatform(platformProperties);
        }

        /// <summary>
        /// The function that specifies the location of the source control.
        /// </summary>
        /// <param name="location">The location of the source control.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRunRequestExecutableWithSourceLocation RegistryTaskRun.Definition.IRunRequestExecutableWithSourceLocation.WithSourceLocation(string location)
        {
            return this.WithSourceLocation(location);
        }

        /// <summary>
        /// The function that specifies the name of the existing task to run.
        /// </summary>
        /// <param name="taskName">The name of the created task to pass into the task run request.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRegistryTaskRunRequest RegistryTaskRun.Definition.IPlatformAltTaskRunRequest.WithTaskRunRequest(string taskName)
        {
            return this.WithTaskRunRequest(taskName);
        }

        /// <summary>
        /// The function that specifies the timeout.
        /// </summary>
        /// <param name="timeout">The time the timeout lasts.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRunRequestExecutableWithSourceLocation RegistryTaskRun.Definition.IRunRequestExecutableWithSourceLocation.WithTimeout(int timeout)
        {
            return this.WithTimeout(timeout);
        }

        /// <summary>
        /// The function that specifies the platform will have a Windows OS.
        /// </summary>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRunRequestType RegistryTaskRun.Definition.IPlatform.WithWindows()
        {
            return this.WithWindows();
        }

        /// <summary>
        /// The function that specifies the platform will have a Windows OS with Architecture architecture.
        /// </summary>
        /// <param name="architecture">The architecture the platform will have.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRunRequestType RegistryTaskRun.Definition.IPlatform.WithWindows(Architecture architecture)
        {
            return this.WithWindows(architecture);
        }

        /// <summary>
        /// The function that specifies the platform will have a Windows OS with Architecture architecture and Variant variant.
        /// </summary>
        /// <param name="architecture">The architecture the platform will have.</param>
        /// <param name="variant">The variant the platform will have.</param>
        /// <return>The next stage of the container registry task run definition.</return>
        RegistryTaskRun.Definition.IRunRequestType RegistryTaskRun.Definition.IPlatform.WithWindows(Architecture architecture, Variant variant)
        {
            return this.WithWindows(architecture, variant);
        }
    }
}