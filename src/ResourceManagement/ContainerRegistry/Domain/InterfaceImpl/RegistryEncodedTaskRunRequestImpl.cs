// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Collections.Generic;

    internal partial class RegistryEncodedTaskRunRequestImpl 
    {
        /// <summary>
        /// Gets the number of CPUs.
        /// </summary>
        int Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryEncodedTaskRunRequest.CpuCount
        {
            get
            {
                return this.CpuCount();
            }
        }

        /// <summary>
        /// Begins defintion of encoded task step in the task run request.
        /// </summary>
        /// <returns>the next stage of the container encoded task run request definition</returns>
        RegistryEncodedTaskRunRequest.Definition.IEncodedTaskContent RegistryEncodedTaskRunRequest.Definition.IBlank.DefineEncodedTaskStep()
        {
            return this.DefineEncodedTaskStep();
        }

        /// <summary>
        /// Gets whether archive is enabled.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryEncodedTaskRunRequest.IsArchiveEnabled
        {
            get
            {
                return this.IsArchiveEnabled();
            }
        }

        /// <summary>
        /// Gets the properties of the platform.
        /// </summary>
        Models.PlatformProperties Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryEncodedTaskRunRequest.Platform
        {
            get
            {
                return this.Platform();
            }
        }

        /// <summary>
        /// Gets the location of the source control.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryEncodedTaskRunRequest.SourceLocation
        {
            get
            {
                return this.SourceLocation();
            }
        }

        /// <summary>
        /// Gets the length of the timeout.
        /// </summary>
        int Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryEncodedTaskRunRequest.Timeout
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
        /// The function that specifies the base64 encoded task content.
        /// </summary>
        /// <param name="encodedTaskContent">The base64 encoded task content.</param>
        /// <return>The next stage of the container encoded task run request definition.</return>
        RegistryEncodedTaskRunRequest.Definition.IEncodedTaskRunRequestStepAttachable RegistryEncodedTaskRunRequest.Definition.IEncodedTaskContent.WithBase64EncodedTaskContent(string encodedTaskContent)
        {
            return this.WithBase64EncodedTaskContent(encodedTaskContent);
        }

        /// <summary>
        /// The function that specifies the base64 encoded values content.
        /// </summary>
        /// <param name="encodedValueContent">The base64 encoded values content.</param>
        /// <return>The next stage of the container encoded task run request definition.</return>
        RegistryEncodedTaskRunRequest.Definition.IEncodedTaskRunRequestStepAttachable RegistryEncodedTaskRunRequest.Definition.IEncodedTaskRunRequestStepAttachable.WithBase64EncodedValueContent(string encodedValueContent)
        {
            return this.WithBase64EncodedValueContent(encodedValueContent);
        }

        /// <summary>
        /// The function that specifies the overriding value and what it will override.
        /// </summary>
        /// <param name="name">The name of the value to be overridden.</param>
        /// <param name="overridingValue">The content of the overriding value.</param>
        /// <return>The next stage of the container encoded task run request definition.</return>
        RegistryEncodedTaskRunRequest.Definition.IEncodedTaskRunRequestStepAttachable RegistryEncodedTaskRunRequest.Definition.IEncodedTaskRunRequestStepAttachable.WithOverridingValue(string name, OverridingValue overridingValue)
        {
            return this.WithOverridingValue(name, overridingValue);
        }

        /// <summary>
        /// The function that specifies the overriding values and what they will override.
        /// </summary>
        /// <param name="overridingValues">Map with key of the name of the value to be overridden and value OverridingValue specifying the content of the overriding value.</param>
        /// <return>The next stage of the container encoded task run request definition.</return>
        RegistryEncodedTaskRunRequest.Definition.IEncodedTaskRunRequestStepAttachable RegistryEncodedTaskRunRequest.Definition.IEncodedTaskRunRequestStepAttachable.WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues)
        {
            return this.WithOverridingValues(overridingValues);
        }
    }
}