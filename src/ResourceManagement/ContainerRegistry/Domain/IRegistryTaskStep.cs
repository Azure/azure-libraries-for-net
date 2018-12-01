// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure RegistryTaskStep registry task.
    /// </summary>
    public interface IRegistryTaskStep  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Gets the base image dependencies of this RegistryTaskStep.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.BaseImageDependency> BaseImageDependencies { get; }

        /// <summary>
        /// Gets the context path of this RegistryTaskStep.
        /// </summary>
        string ContextPath { get; }
    }
}