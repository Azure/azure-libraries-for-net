// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Definition
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// The first stage of a RegistryFileTaskStep definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Definition.IFileTaskPath
    {
    }

    /// <summary>
    /// Container interface for all the definitions related to a RegistryFileTaskStep.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Definition.IBlank,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Definition.IFileTaskPath,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Definition.IFileTaskStepAttachable
    {
    }

    /// <summary>
    /// The stage of the container registry FileTaskStep definition allowing to specify the task path.
    /// </summary>
    public interface IFileTaskPath 
    {
        /// <summary>
        /// The function that specifies the path to the task file.
        /// </summary>
        /// <param name="path">The path to the task file.</param>
        /// <return>The next stage of the container registry FileTaskStep definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Definition.IFileTaskStepAttachable WithTaskPath(string path);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be attached,
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IFileTaskStepAttachable  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IAttachable<Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ISourceTriggerDefinition>
    {
        /// <summary>
        /// The function that specifies a single value that will override the corresponding value specified under the function withValuesPath().
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingValue">The value of the value to be overridden.</param>
        /// <return>The next stage of the container registry FileTaskStep definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Definition.IFileTaskStepAttachable WithOverridingValue(string name, OverridingValue overridingValue);

        /// <summary>
        /// The function that specifies the values that override the corresponding values specified under the function withValuesPath().
        /// </summary>
        /// <param name="overridingValues">A map which contains the values that will override the corresponding values specified under the function withValuesPath().</param>
        /// <return>The next stage of the container registry FileTaskStep definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Definition.IFileTaskStepAttachable WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues);

        /// <summary>
        /// The function that specifies the path to the values.
        /// </summary>
        /// <param name="path">The path to the values.</param>
        /// <return>The next stage of the container registry FileTaskStep definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Definition.IFileTaskStepAttachable WithValuesPath(string path);
    }
}