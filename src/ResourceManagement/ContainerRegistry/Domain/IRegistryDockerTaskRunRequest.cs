// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure registry Docker task run request.
    /// </summary>
    public interface IRegistryDockerTaskRunRequest  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Gets the number of CPUs.
        /// </summary>
        int CpuCount { get; }

        /// <summary>
        /// Gets whether archive is enabled.
        /// </summary>
        bool IsArchiveEnabled { get; }

        /// <summary>
        /// Gets the properties of the platform.
        /// </summary>
        Models.PlatformProperties Platform { get; }

        /// <summary>
        /// Gets the location of the source control.
        /// </summary>
        string SourceLocation { get; }

        /// <summary>
        /// Gets the length of the timeout.
        /// </summary>
        int Timeout { get; }
    }
}