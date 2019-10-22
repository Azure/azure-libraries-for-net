// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure RegistryDockerTaskStep registry task.
    /// </summary>
    public interface IRegistryDockerTaskStep  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.DockerTaskStep>,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskStep
    {

        /// <summary>
        /// Gets the arguments this Docker task step.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.Argument> Arguments { get; }

        /// <summary>
        /// Gets Docker file path for this Docker task step.
        /// </summary>
        string DockerFilePath { get; }

        /// <summary>
        /// Gets the image names of this Docker task step.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> ImageNames { get; }

        /// <summary>
        /// Gets whether push is enabled for this Docker task step.
        /// </summary>
        bool IsPushEnabled { get; }

        /// <summary>
        /// Gets whether there is no cache for this Docker task step.
        /// </summary>
        bool NoCache { get; }
    }
}