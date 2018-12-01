// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskRunRequest.Definition
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the container file task run request definition that specifies the path to the task file.
    /// </summary>
    public interface IFileTaskPath 
    {
        /// <summary>
        /// The function that specifies the path to the task file.
        /// </summary>
        /// <param name="taskPath">The path to the task file.</param>
        /// <return>The next stage of the container file task run request definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskRunRequest.Definition.IFileTaskRunRequestStepAttachable WithTaskPath(string taskPath);
    }

    /// <summary>
    /// The first stage of a file task run request definition.
    /// </summary>
    public interface IBlank 
    {
        /// <summary>
        /// Gets The function that begins the definition of the file task step in the task run request.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the container file task run request definition.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskRunRequest.Definition.IFileTaskPath DefineFileTaskStep();
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be attached,
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IFileTaskRunRequestStepAttachable  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IAttachable<Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestExecutableWithSourceLocation>
    {
        /// <summary>
        /// The function that specifies the overriding value and what it will override.
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingValue">The content of the overriding value.</param>
        /// <return>The next stage of the container file task run request definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskRunRequest.Definition.IFileTaskRunRequestStepAttachable WithOverridingValue(string name, OverridingValue overridingValue);

        /// <summary>
        /// The function that specifies the overriding values and what they will override.
        /// </summary>
        /// <param name="overridingValues">Map with key of the name of the value to be overridden and value OverridingValue specifying the content of the overriding value.</param>
        /// <return>The next stage of the container file task run request definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskRunRequest.Definition.IFileTaskRunRequestStepAttachable WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues);

        /// <summary>
        /// The function that specifies the path to the values file.
        /// </summary>
        /// <param name="valuesPath">The path to the values file.</param>
        /// <return>The next stage of the container file task run request definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskRunRequest.Definition.IFileTaskRunRequestStepAttachable WithValuesPath(string valuesPath);
    }

    /// <summary>
    /// Container interface for all the definitions related to a registry file task run request.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskRunRequest.Definition.IBlank,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskRunRequest.Definition.IFileTaskPath,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskRunRequest.Definition.IFileTaskRunRequestStepAttachable
    {
    }
}