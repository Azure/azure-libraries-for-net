// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Collections.Generic;

    internal partial class RegistryEncodedTaskStepImpl 
    {
        /// <summary>
        /// Gets the encoded task content of this encoded task step.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryEncodedTaskStep.EncodedTaskContent
        {
            get
            {
                return this.EncodedTaskContent();
            }
        }

        /// <summary>
        /// Gets the encoded values content of this encoded task step.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryEncodedTaskStep.EncodedValuesContent
        {
            get
            {
                return this.EncodedValuesContent();
            }
        }

        /// <summary>
        /// Gets the values of this encoded task step.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.SetValue> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryEncodedTaskStep.Values
        {
            get
            {
                return this.Values();
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
        /// The function that specifies the path to the base64 encoded task content.
        /// </summary>
        /// <param name="encodedTaskContent">The path to the base64 encoded task content.</param>
        /// <return>The next stage of the container registry EncodedTaskStep update.</return>
        RegistryEncodedTaskStep.Update.IUpdate RegistryEncodedTaskStep.Update.IEncodedTaskContent.WithBase64EncodedTaskContent(string encodedTaskContent)
        {
            return this.WithBase64EncodedTaskContent(encodedTaskContent);
        }

        /// <summary>
        /// The function that specifies the base64 encoded task content.
        /// </summary>
        /// <param name="encodedTaskContent">The base64 encoded task content.</param>
        /// <return>The next stage of the container registry EncodedTaskStep definition.</return>
        RegistryEncodedTaskStep.Definition.IEncodedTaskStepAttachable RegistryEncodedTaskStep.Definition.IEncodedTaskContent.WithBase64EncodedTaskContent(string encodedTaskContent)
        {
            return this.WithBase64EncodedTaskContent(encodedTaskContent);
        }

        /// <summary>
        /// The function that specifies the base64 encoded value content.
        /// </summary>
        /// <param name="encodedValueContent">The base64 encoded value content.</param>
        /// <return>The next stage of the container registry EncodedTaskStep definition.</return>
        RegistryEncodedTaskStep.Definition.IEncodedTaskStepAttachable RegistryEncodedTaskStep.Definition.IEncodedTaskStepAttachable.WithBase64EncodedValueContent(string encodedValueContent)
        {
            return this.WithBase64EncodedValueContent(encodedValueContent);
        }

        /// <summary>
        /// The function that specifies the path to the base64 encoded value content.
        /// </summary>
        /// <param name="encodedValueContent">The path to the base64 encoded value content.</param>
        /// <return>The next stage of the container registry EncodedTaskStep update.</return>
        RegistryEncodedTaskStep.Update.IUpdate RegistryEncodedTaskStep.Update.IValuePath.WithBase64EncodedValueContent(string encodedValueContent)
        {
            return this.WithBase64EncodedValueContent(encodedValueContent);
        }

        /// <summary>
        /// The function that specifies a single value that will override the corresponding value specified under the function withBase64EncodedValueContent().
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingValue">The value of the value to be overridden.</param>
        /// <return>The next stage of the container registry EncodedTaskStep definition.</return>
        RegistryEncodedTaskStep.Definition.IEncodedTaskStepAttachable RegistryEncodedTaskStep.Definition.IEncodedTaskStepAttachable.WithOverridingValue(string name, OverridingValue overridingValue)
        {
            return this.WithOverridingValue(name, overridingValue);
        }

        /// <summary>
        /// The function that specifies a single value that will override the corresponding value specified under the function withBase64EncodedValueContent().
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingValue">The value of the value to be overridden.</param>
        /// <return>The next stage of the container registry EncodedTaskStep update.</return>
        RegistryEncodedTaskStep.Update.IUpdate RegistryEncodedTaskStep.Update.IOverridingValues.WithOverridingValue(string name, OverridingValue overridingValue)
        {
            return this.WithOverridingValue(name, overridingValue);
        }

        /// <summary>
        /// The function that specifies the values that override the corresponding values specified under the function withBase64EncodedValueContent().
        /// </summary>
        /// <param name="overridingValues">A map which contains the values that will override the corresponding values specified under the function withBase64EncodedValueContent().</param>
        /// <return>The next stage of the container registry EncodedTaskStep definition.</return>
        RegistryEncodedTaskStep.Definition.IEncodedTaskStepAttachable RegistryEncodedTaskStep.Definition.IEncodedTaskStepAttachable.WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues)
        {
            return this.WithOverridingValues(overridingValues);
        }

        /// <summary>
        /// The function that specifies the values that override the corresponding values specified under the function withBase64EncodedValueContent().
        /// </summary>
        /// <param name="overridingValues">A map which contains the values that will override the corresponding values specified under the function withBase64EncodedValueContent().</param>
        /// <return>The next stage of the container registry EncodedTaskStep update.</return>
        RegistryEncodedTaskStep.Update.IUpdate RegistryEncodedTaskStep.Update.IOverridingValues.WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues)
        {
            return this.WithOverridingValues(overridingValues);
        }
    }
}