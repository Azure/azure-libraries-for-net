// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskRunRequest.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using System.Collections.Generic;

    internal partial class RegistryFileTaskRunRequestImpl 
    {
        /// <summary>
        /// Gets the number of CPUs.
        /// </summary>
        int Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryFileTaskRunRequest.CpuCount
        {
            get
            {
                return this.CpuCount();
            }
        }

        /// <summary>
        /// Gets The function that begins the definition of the file task step in the task run request.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the container file task run request definition.
        /// </summary>
        RegistryFileTaskRunRequest.Definition.IFileTaskPath RegistryFileTaskRunRequest.Definition.IBlank.DefineFileTaskStep()
        {
            return this.DefineFileTaskStep();
        }

        /// <summary>
        /// Gets whether archive is enabled.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryFileTaskRunRequest.IsArchiveEnabled
        {
            get
            {
                return this.IsArchiveEnabled();
            }
        }

        /// <summary>
        /// Gets the properties of the platform.
        /// </summary>
        Models.PlatformProperties Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryFileTaskRunRequest.Platform
        {
            get
            {
                return this.Platform();
            }
        }

        /// <summary>
        /// Gets the location of the source control.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryFileTaskRunRequest.SourceLocation
        {
            get
            {
                return this.SourceLocation();
            }
        }

        /// <summary>
        /// Gets the length of the timeout.
        /// </summary>
        int Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryFileTaskRunRequest.Timeout
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
        /// The function that specifies the overriding value and what it will override.
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingValue">The content of the overriding value.</param>
        /// <return>The next stage of the container file task run request definition.</return>
        RegistryFileTaskRunRequest.Definition.IFileTaskRunRequestStepAttachable RegistryFileTaskRunRequest.Definition.IFileTaskRunRequestStepAttachable.WithOverridingValue(string name, OverridingValue overridingValue)
        {
            return this.WithOverridingValue(name, overridingValue);
        }

        /// <summary>
        /// The function that specifies the overriding values and what they will override.
        /// </summary>
        /// <param name="overridingValues">Map with key of the name of the value to be overridden and value OverridingValue specifying the content of the overriding value.</param>
        /// <return>The next stage of the container file task run request definition.</return>
        RegistryFileTaskRunRequest.Definition.IFileTaskRunRequestStepAttachable RegistryFileTaskRunRequest.Definition.IFileTaskRunRequestStepAttachable.WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues)
        {
            return this.WithOverridingValues(overridingValues);
        }

        /// <summary>
        /// The function that specifies the path to the task file.
        /// </summary>
        /// <param name="taskPath">The path to the task file.</param>
        /// <return>The next stage of the container file task run request definition.</return>
        RegistryFileTaskRunRequest.Definition.IFileTaskRunRequestStepAttachable RegistryFileTaskRunRequest.Definition.IFileTaskPath.WithTaskPath(string taskPath)
        {
            return this.WithTaskPath(taskPath);
        }

        /// <summary>
        /// The function that specifies the path to the values file.
        /// </summary>
        /// <param name="valuesPath">The path to the values file.</param>
        /// <return>The next stage of the container file task run request definition.</return>
        RegistryFileTaskRunRequest.Definition.IFileTaskRunRequestStepAttachable RegistryFileTaskRunRequest.Definition.IFileTaskRunRequestStepAttachable.WithValuesPath(string valuesPath)
        {
            return this.WithValuesPath(valuesPath);
        }
    }
}