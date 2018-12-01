// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Collections.Generic;

    internal partial class RegistryFileTaskStepImpl 
    {
        /// <summary>
        /// Gets the task file path of this file task step.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryFileTaskStep.TaskFilePath
        {
            get
            {
                return this.TaskFilePath();
            }
        }

        /// <summary>
        /// Gets the values of this file task step.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.SetValue> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryFileTaskStep.Values
        {
            get
            {
                return this.Values();
            }
        }

        /// <summary>
        /// Gets the values file path of this file task step.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryFileTaskStep.ValuesFilePath
        {
            get
            {
                return this.ValuesFilePath();
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
        /// The function that specifies a single value that will override the corresponding value specified under the function withValuesPath().
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingValue">The value of the value to be overridden.</param>
        /// <return>The next stage of the container registry FileTaskStep definition.</return>
        RegistryFileTaskStep.Definition.IFileTaskStepAttachable RegistryFileTaskStep.Definition.IFileTaskStepAttachable.WithOverridingValue(string name, OverridingValue overridingValue)
        {
            return this.WithOverridingValue(name, overridingValue);
        }

        /// <summary>
        /// The function that specifies a single value that will override the corresponding value specified under the function withValuesPath().
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingValue">The value of the value to be overridden.</param>
        /// <return>The next stage of the container registry FileTaskStep update.</return>
        RegistryFileTaskStep.Update.IUpdate RegistryFileTaskStep.Update.IOverridingValues.WithOverridingValue(string name, OverridingValue overridingValue)
        {
            return this.WithOverridingValue(name, overridingValue);
        }

        /// <summary>
        /// The function that specifies the values that override the corresponding values specified under the function withValuesPath().
        /// </summary>
        /// <param name="overridingValues">A map which contains the values that will override the corresponding values specified under the function withValuesPath().</param>
        /// <return>The next stage of the container registry FileTaskStep definition.</return>
        RegistryFileTaskStep.Definition.IFileTaskStepAttachable RegistryFileTaskStep.Definition.IFileTaskStepAttachable.WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues)
        {
            return this.WithOverridingValues(overridingValues);
        }

        /// <summary>
        /// The function that specifies the values that override the corresponding values specified under the function withValuesPath().
        /// </summary>
        /// <param name="overridingValues">A map which contains the values that will override the corresponding values specified under the function withValuesPath().</param>
        /// <return>The next stage of the container registry FileTaskStep update.</return>
        RegistryFileTaskStep.Update.IUpdate RegistryFileTaskStep.Update.IOverridingValues.WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues)
        {
            return this.WithOverridingValues(overridingValues);
        }

        /// <summary>
        /// The function that specifies the path to the task file.
        /// </summary>
        /// <param name="path">The path to the task file.</param>
        /// <return>The next stage of the container registry FileTaskStep update.</return>
        RegistryFileTaskStep.Update.IUpdate RegistryFileTaskStep.Update.IFileTaskPath.WithTaskPath(string path)
        {
            return this.WithTaskPath(path);
        }

        /// <summary>
        /// The function that specifies the path to the task file.
        /// </summary>
        /// <param name="path">The path to the task file.</param>
        /// <return>The next stage of the container registry FileTaskStep definition.</return>
        RegistryFileTaskStep.Definition.IFileTaskStepAttachable RegistryFileTaskStep.Definition.IFileTaskPath.WithTaskPath(string path)
        {
            return this.WithTaskPath(path);
        }

        /// <summary>
        /// The function that specifies the path to the values.
        /// </summary>
        /// <param name="path">The path to the values.</param>
        /// <return>The next stage of the container registry FileTaskStep update.</return>
        RegistryFileTaskStep.Update.IUpdate RegistryFileTaskStep.Update.IValuePath.WithValuesPath(string path)
        {
            return this.WithValuesPath(path);
        }

        /// <summary>
        /// The function that specifies the path to the values.
        /// </summary>
        /// <param name="path">The path to the values.</param>
        /// <return>The next stage of the container registry FileTaskStep definition.</return>
        RegistryFileTaskStep.Definition.IFileTaskStepAttachable RegistryFileTaskStep.Definition.IFileTaskStepAttachable.WithValuesPath(string path)
        {
            return this.WithValuesPath(path);
        }
    }
}