// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskRunRequest.Definition
{
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the container encoded task run request definition that specifies the base64 encoded task content.
    /// </summary>
    public interface IEncodedTaskContent 
    {
        /// <summary>
        /// The function that specifies the base64 encoded task content.
        /// </summary>
        /// <param name="encodedTaskContent">The base64 encoded task content.</param>
        /// <return>The next stage of the container encoded task run request definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskRunRequest.Definition.IEncodedTaskRunRequestStepAttachable WithBase64EncodedTaskContent(string encodedTaskContent);
    }

    /// <summary>
    /// The first stage of an encoded task run request definition.
    /// </summary>
    public interface IBlank 
    {
        /// <summary>
        /// Gets The function that begins the definition of the encoded task step in the task run request.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the container encoded task run request definition.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskRunRequest.Definition.IEncodedTaskContent DefineEncodedTaskStep();
    }

    /// <summary>
    /// Container interface for all the definitions related to a registry Encoded task run request.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskRunRequest.Definition.IBlank,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskRunRequest.Definition.IEncodedTaskContent,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskRunRequest.Definition.IEncodedTaskRunRequestStepAttachable
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be attached,
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IEncodedTaskRunRequestStepAttachable  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IAttachable<Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IRunRequestExecutableWithSourceLocation>
    {
        /// <summary>
        /// The function that specifies the base64 encoded values content.
        /// </summary>
        /// <param name="encodedValueContent">The base64 encoded values content.</param>
        /// <return>The next stage of the container encoded task run request definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskRunRequest.Definition.IEncodedTaskRunRequestStepAttachable WithBase64EncodedValueContent(string encodedValueContent);

        /// <summary>
        /// The function that specifies the overriding value and what it will override.
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingValue">The content of the overriding value.</param>
        /// <return>The next stage of the container encoded task run request definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskRunRequest.Definition.IEncodedTaskRunRequestStepAttachable WithOverridingValue(string name, OverridingValue overridingValue);

        /// <summary>
        /// The function that specifies the overriding values and what they will override.
        /// </summary>
        /// <param name="overridingValues">Map with key of the name of the value to be overridden and value OverridingValue specifying the content of the overriding value.</param>
        /// <return>The next stage of the container encoded task run request definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskRunRequest.Definition.IEncodedTaskRunRequestStepAttachable WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues);
    }
}