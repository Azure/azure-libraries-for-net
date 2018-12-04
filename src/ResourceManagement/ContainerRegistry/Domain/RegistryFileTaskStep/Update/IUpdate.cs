// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Update
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the container registry FileTaskStep update allowing to specify the path to the values.
    /// </summary>
    public interface IValuePath 
    {
        /// <summary>
        /// The function that specifies the path to the values.
        /// </summary>
        /// <param name="path">The path to the values.</param>
        /// <return>The next stage of the container registry FileTaskStep update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Update.IUpdate WithValuesPath(string path);
    }

    /// <summary>
    /// The stage of the container registry FileTaskStep update allowing to specify the task path.
    /// </summary>
    public interface IFileTaskPath 
    {
        /// <summary>
        /// The function that specifies the path to the task file.
        /// </summary>
        /// <param name="path">The path to the task file.</param>
        /// <return>The next stage of the container registry FileTaskStep update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Update.IUpdate WithTaskPath(string path);
    }

    /// <summary>
    /// The stage of the container registry FileTaskStep update allowing to specify the overriding values.
    /// </summary>
    public interface IOverridingValues 
    {
        /// <summary>
        /// The function that specifies a single value that will override the corresponding value specified under the function withValuesPath().
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingValue">The value of the value to be overridden.</param>
        /// <return>The next stage of the container registry FileTaskStep update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Update.IUpdate WithOverridingValue(string name, OverridingValue overridingValue);

        /// <summary>
        /// The function that specifies the values that override the corresponding values specified under the function withValuesPath().
        /// </summary>
        /// <param name="overridingValues">A map which contains the values that will override the corresponding values specified under the function withValuesPath().</param>
        /// <return>The next stage of the container registry FileTaskStep update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Update.IUpdate WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues);
    }

    /// <summary>
    /// Container interface for all the updates related to a RegistryFileTaskStep.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Update.IFileTaskPath,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Update.IValuePath,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Update.IOverridingValues,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate>
    {
    }
}