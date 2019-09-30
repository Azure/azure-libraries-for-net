// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    internal partial class ContainerServiceAgentPoolImpl 
    {
        /// <summary>
        /// Gets the number of agents (virtual machines) to host docker containers.
        /// </summary>
        int Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.Count
        {
            get
            {
                return this.Count();
            }
        }

        /// <summary>
        /// Gets DNS prefix to be used to create the FQDN for the agent pool.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.DnsPrefix
        {
            get
            {
                return this.DnsPrefix();
            }
        }

        /// <summary>
        /// Gets FDQN for the agent pool.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.Fqdn
        {
            get
            {
                return this.Fqdn();
            }
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the ID of the virtual network used by each virtual machine in the agent pool.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.NetworkId
        {
            get
            {
                return this.NetworkId();
            }
        }

        /// <summary>
        /// Gets OS disk size in GB set for each virtual machine in the agent pool.
        /// </summary>
        int Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.OSDiskSizeInGB
        {
            get
            {
                return this.OSDiskSizeInGB();
            }
        }

        /// <summary>
        /// Gets OS of each virtual machine in the agent pool.
        /// </summary>
        OSType Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.OSType
        {
            get
            {
                return this.OSType();
            }
        }

        /// <summary>
        /// Gets array of ports opened on this agent pool.
        /// </summary>
        int[] Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.Ports
        {
            get
            {
                return this.Ports();
            }
        }

        /// <summary>
        /// Gets the storage kind (managed or classic) set for each virtual machine in the agent pool.
        /// </summary>
        ContainerServiceStorageProfileTypes Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.StorageProfile
        {
            get
            {
                return this.StorageProfile();
            }
        }

        /// <summary>
        /// Gets the name of the subnet used by each virtual machine in the agent pool.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.SubnetName
        {
            get
            {
                return this.SubnetName();
            }
        }

        /// <summary>
        /// Gets the size of each virtual machine in the agent pool.
        /// </summary>
        ContainerServiceVMSizeTypes Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.VMSize
        {
            get
            {
                return this.VMSize();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ContainerService.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ContainerService.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Specify the DNS prefix to be used in the FQDN for the agent pool.
        /// </summary>
        /// <param name="dnsPrefix">The DNS prefix.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IWithLeafDomainLabel<ContainerService.Definition.IWithCreate>.WithDnsPrefix(string dnsPrefix)
        {
            return this.WithDnsPrefix(dnsPrefix);
        }

        /// <summary>
        /// OS Disk Size in GB to be used for every machine in the agent pool.
        /// </summary>
        /// <param name="osDiskSizeInGB">OS disk size in GB to be used for each virtual machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IWithOSDiskSize<ContainerService.Definition.IWithCreate>.WithOSDiskSizeInGB(int osDiskSizeInGB)
        {
            return this.WithOSDiskSizeInGB(osDiskSizeInGB);
        }

        /// <summary>
        /// OS type to be used for every machine in the agent pool.
        /// Default is Linux.
        /// </summary>
        /// <param name="osType">OS type to be used for every machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IWithOSType<ContainerService.Definition.IWithCreate>.WithOSType(OSType osType)
        {
            return this.WithOSType(osType);
        }

        /// <summary>
        /// Ports to be exposed on this agent pool.
        /// The default exposed ports are different based on your choice of orchestrator.
        /// </summary>
        /// <param name="ports">Port numbers that will be exposed on this agent pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IWithPorts<ContainerService.Definition.IWithCreate>.WithPorts(params int[] ports)
        {
            return this.WithPorts(ports);
        }

        /// <summary>
        /// Specifies the storage kind to be used for each virtual machine in the agent pool.
        /// </summary>
        /// <param name="storageProfile">The storage kind to be used for each virtual machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IWithStorageProfile<ContainerService.Definition.IWithCreate>.WithStorageProfile(ContainerServiceStorageProfileTypes storageProfile)
        {
            return this.WithStorageProfile(storageProfile);
        }

        /// <summary>
        /// Specifies the number of agents (virtual machines) to host docker containers.
        /// </summary>
        /// <param name="count">A number between 1 and 100.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithVMSize<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IBlank<ContainerService.Definition.IWithCreate>.WithVirtualMachineCount(int count)
        {
            return this.WithVirtualMachineCount(count);
        }

        /// <summary>
        /// Specifies the size of the agent virtual machines.
        /// </summary>
        /// <param name="vmSize">The size of the virtual machine.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithLeafDomainLabel<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IWithVMSize<ContainerService.Definition.IWithCreate>.WithVirtualMachineSize(ContainerServiceVMSizeTypes vmSize)
        {
            return this.WithVirtualMachineSize(vmSize);
        }

        /// <summary>
        /// Specifies the virtual network to be used for the agents.
        /// </summary>
        /// <param name="virtualNetworkId">The ID of a virtual network.</param>
        /// <param name="subnetName">
        /// The name of the subnet within the virtual network.; the subnet must have the service
        /// endpoints enabled for 'Microsoft.ContainerService'.
        /// </param>
        /// <return>The next stage.</return>
        ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IWithVirtualNetwork<ContainerService.Definition.IWithCreate>.WithVirtualNetwork(string virtualNetworkId, string subnetName)
        {
            return this.WithVirtualNetwork(virtualNetworkId, subnetName);
        }
    }
}