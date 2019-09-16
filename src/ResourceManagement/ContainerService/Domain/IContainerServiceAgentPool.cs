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
        /// <summary>
        /// Gets the number of agents (virtual machines) to host docker containers.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets DNS prefix to be used to create the FQDN for the agent pool.
        /// </summary>
        string DnsPrefix { get; }

        /// <summary>
        /// Gets FDQN for the agent pool.
        /// </summary>
        string Fqdn { get; }

        /// <summary>
        /// Gets the ID of the virtual network used by each virtual machine in the agent pool.
        /// </summary>
        string NetworkId { get; }

        /// <summary>
        /// Gets OS disk size in GB set for each virtual machine in the agent pool.
        /// </summary>
        int OSDiskSizeInGB { get; }

        /// <summary>
        /// Gets OS of each virtual machine in the agent pool.
        /// </summary>
        OSType OSType { get; }

        /// <summary>
        /// Gets array of ports opened on this agent pool.
        /// </summary>
        int[] Ports { get; }

        /// <summary>
        /// Gets the storage kind (managed or classic) set for each virtual machine in the agent pool.
        /// </summary>
        ContainerServiceStorageProfileTypes StorageProfile { get; }

        /// <summary>
        /// Gets the name of the subnet used by each virtual machine in the agent pool.
        /// </summary>
        string SubnetName { get; }

        /// <summary>
        /// Gets the size of each virtual machine in the agent pool.
        /// </summary>
        ContainerServiceVMSizeTypes VMSize { get; }
    }
}