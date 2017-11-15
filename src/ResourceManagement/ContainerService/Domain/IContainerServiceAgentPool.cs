// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A client-side representation for a container service agent pool.
    /// </summary>
    public interface IContainerServiceAgentPool  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.ContainerService.Fluent.IOrchestratorServiceBase>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ContainerServiceAgentPoolProfile>
    {
        /// <return>FDQN for the agent pool.</return>
        string Fqdn();

        /// <return>The storage kind (managed or classic) set for each virtual machine in the agent pool.</return>
        StorageProfileTypes StorageProfile();

        /// <return>The number of agents (virtual machines) to host docker containers.</return>
        int Count();

        /// <return>OS of each virtual machine in the agent pool.</return>
        ContainerServiceOSTypes OSType();

        /// <return>DNS prefix to be used to create the FQDN for the agent pool.</return>
        string DnsPrefix();

        /// <return>The ID of the virtual network used by each virtual machine in the agent pool.</return>
        string NetworkId();

        /// <return>The size of each virtual machine in the agent pool.</return>
        ContainerServiceVirtualMachineSizeTypes VMSize();

        /// <return>Array of ports opened on this agent pool.</return>
        int[] Ports();

        /// <return>OS disk size in GB set for each virtual machine in the agent pool.</return>
        int OSDiskSizeInGB();

        /// <return>The name of the subnet used by each virtual machine in the agent pool.</return>
        string SubnetName();
    }
}