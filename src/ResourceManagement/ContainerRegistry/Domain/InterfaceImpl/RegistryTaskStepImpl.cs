// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using System.Collections.Generic;

    internal abstract partial class RegistryTaskStepImpl 
    {
        /// <summary>
        /// Gets the base image dependencies of this RegistryTaskStep.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.BaseImageDependency> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskStep.BaseImageDependencies
        {
            get
            {
                return this.BaseImageDependencies();
            }
        }

        /// <summary>
        /// Gets the context path of this RegistryTaskStep.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskStep.ContextPath
        {
            get
            {
                return this.ContextPath();
            }
        }
    }
}