// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Definition
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// The first stage of a RegistryEncodedTaskStep definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Definition.IEncodedTaskContent
    {
    }

    /// <summary>
    /// The stage of the container registry EncodedTaskStep definition allowing to specify the base64 encoded task content.
    /// </summary>
    public interface IEncodedTaskContent 
    {
        /// <summary>
        /// The function that specifies the base64 encoded task content.
        /// </summary>
        /// <param name="encodedTaskContent">The base64 encoded task content.</param>
        /// <return>The next stage of the container registry EncodedTaskStep definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Definition.IEncodedTaskStepAttachable WithBase64EncodedTaskContent(string encodedTaskContent);
    }

    /// <summary>
    /// Container interface for all the definitions related to a RegistryEncodedTaskStep.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Definition.IBlank,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Definition.IEncodedTaskContent,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Definition.IEncodedTaskStepAttachable
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be attached,
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IEncodedTaskStepAttachable  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IAttachable<Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.ISourceTriggerDefinition>
    {
        /// <summary>
        /// The function that specifies the base64 encoded value content.
        /// </summary>
        /// <param name="encodedValueContent">The base64 encoded value content.</param>
        /// <return>The next stage of the container registry EncodedTaskStep definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Definition.IEncodedTaskStepAttachable WithBase64EncodedValueContent(string encodedValueContent);

        /// <summary>
        /// The function that specifies a single value that will override the corresponding value specified under the function withBase64EncodedValueContent().
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingValue">The value of the value to be overridden.</param>
        /// <return>The next stage of the container registry EncodedTaskStep definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Definition.IEncodedTaskStepAttachable WithOverridingValue(string name, OverridingValue overridingValue);

        /// <summary>
        /// The function that specifies the values that override the corresponding values specified under the function withBase64EncodedValueContent().
        /// </summary>
        /// <param name="overridingValues">A map which contains the values that will override the corresponding values specified under the function withBase64EncodedValueContent().</param>
        /// <return>The next stage of the container registry EncodedTaskStep definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Definition.IEncodedTaskStepAttachable WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues);
    }
}