// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure RegistryFileTaskStep registry task.
    /// </summary>
    public interface IRegistryFileTaskStep  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskStep
    {

        /// <summary>
        /// Gets the task file path of this file task step.
        /// </summary>
        string TaskFilePath { get; }

        /// <summary>
        /// Gets the values of this file task step.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.SetValue> Values { get; }

        /// <summary>
        /// Gets the values file path of this file task step.
        /// </summary>
        string ValuesFilePath { get; }
    }
}