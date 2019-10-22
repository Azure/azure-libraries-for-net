// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure RegistryEncodedTaskStep registry task.
    /// </summary>
    public interface IRegistryEncodedTaskStep  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskStep
    {

        /// <summary>
        /// Gets the encoded task content of this encoded task step.
        /// </summary>
        string EncodedTaskContent { get; }

        /// <summary>
        /// Gets the encoded values content of this encoded task step.
        /// </summary>
        string EncodedValuesContent { get; }

        /// <summary>
        /// Gets the values of this encoded task step.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.SetValue> Values { get; }
    }
}