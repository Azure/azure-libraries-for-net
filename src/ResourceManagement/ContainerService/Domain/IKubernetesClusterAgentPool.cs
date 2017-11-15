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
        /// <return>The storage kind (managed or classic) set for each virtual machine in the agent pool.</return>
        StorageProfileTypes StorageProfile();

        /// <return>The number of agents (virtual machines) to host docker containers.</return>
        int Count();

        /// <return>OS of each virtual machine in the agent pool.</return>
        ContainerServiceOSTypes OSType();

        /// <return>Size of each agent virtual machine in the agent pool.</return>
        ContainerServiceVirtualMachineSizeTypes VMSize();

        /// <return>OS disk size in GB set for each virtual machine in the agent pool.</return>
        int OSDiskSizeInGB();
    }
}