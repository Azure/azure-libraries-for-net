// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Update
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the container registry EncodedTaskStep update allowing to specify the path to the values.
    /// </summary>
    public interface IValuePath 
    {
        /// <summary>
        /// The function that specifies the path to the base64 encoded value content.
        /// </summary>
        /// <param name="encodedValueContent">The path to the base64 encoded value content.</param>
        /// <return>The next stage of the container registry EncodedTaskStep update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Update.IUpdate WithBase64EncodedValueContent(string encodedValueContent);
    }

    /// <summary>
    /// Container interface for all the updates related to a RegistryEncodedTaskStep.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Update.IEncodedTaskContent,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Update.IValuePath,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Update.IOverridingValues,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of the container registry EncodedTaskStep update allowing to specify the task path.
    /// </summary>
    public interface IEncodedTaskContent 
    {
        /// <summary>
        /// The function that specifies the path to the base64 encoded task content.
        /// </summary>
        /// <param name="encodedTaskContent">The path to the base64 encoded task content.</param>
        /// <return>The next stage of the container registry EncodedTaskStep update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Update.IUpdate WithBase64EncodedTaskContent(string encodedTaskContent);
    }

    /// <summary>
    /// The stage of the container registry EncodedTaskStep update allowing to specify the overriding values.
    /// </summary>
    public interface IOverridingValues 
    {
        /// <summary>
        /// The function that specifies a single value that will override the corresponding value specified under the function withBase64EncodedValueContent().
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingValue">The value of the value to be overridden.</param>
        /// <return>The next stage of the container registry EncodedTaskStep update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Update.IUpdate WithOverridingValue(string name, OverridingValue overridingValue);

        /// <summary>
        /// The function that specifies the values that override the corresponding values specified under the function withBase64EncodedValueContent().
        /// </summary>
        /// <param name="overridingValues">A map which contains the values that will override the corresponding values specified under the function withBase64EncodedValueContent().</param>
        /// <return>The next stage of the container registry EncodedTaskStep update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskStep.Update.IUpdate WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues);
    }
}