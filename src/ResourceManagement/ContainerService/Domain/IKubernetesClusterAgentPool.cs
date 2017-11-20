// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A client-side representation for a Kubernetes cluster agent pool.
    /// </summary>
    public interface IKubernetesClusterAgentPool  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.ContainerService.Fluent.IOrchestratorServiceBase>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ContainerServiceAgentPoolProfile>
    {
        /// <summary>
        /// Gets the storage kind (managed or classic) set for each virtual machine in the agent pool.
        /// </summary>
        StorageProfileTypes StorageProfile { get; }

        /// <summary>
        /// Gets the number of agents (virtual machines) to host docker containers.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets OS of each virtual machine in the agent pool.
        /// </summary>
        ContainerServiceOSTypes OSType { get; }

        /// <summary>
        /// Gets size of each agent virtual machine in the agent pool.
        /// </summary>
        ContainerServiceVirtualMachineSizeTypes VMSize { get; }

        /// <summary>
        /// Gets OS disk size in GB set for each virtual machine in the agent pool.
        /// </summary>
        int OSDiskSizeInGB { get; }
    }
}