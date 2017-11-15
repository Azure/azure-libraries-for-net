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
        /// Specifies the storage kind to be used for each virtual machine in the agent pool.
        /// </summary>
        /// <param name="storageProfile">The storage kind to be used for each virtual machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IWithStorageProfile<ContainerService.Definition.IWithCreate>.WithStorageProfile(StorageProfileTypes storageProfile)
        {
            return this.WithStorageProfile(storageProfile) as ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate>;
        }

        /// <summary>
        /// Ports to be exposed on this agent pool.
        /// The default exposed ports are different based on your choice of orchestrator.
        /// </summary>
        /// <param name="ports">Port numbers that will be exposed on this agent pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IWithPorts<ContainerService.Definition.IWithCreate>.WithPorts(params int[] ports)
        {
            return this.WithPorts(ports) as ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate>;
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
        /// OS Disk Size in GB to be used for every machine in the agent pool.
        /// </summary>
        /// <param name="osDiskSizeInGB">OS disk size in GB to be used for each virtual machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IWithOSDiskSize<ContainerService.Definition.IWithCreate>.WithOSDiskSizeInGB(int osDiskSizeInGB)
        {
            return this.WithOSDiskSizeInGB(osDiskSizeInGB) as ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the size of the agent virtual machines.
        /// </summary>
        /// <param name="vmSize">The size of the virtual machine.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithLeafDomainLabel<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IWithVMSize<ContainerService.Definition.IWithCreate>.WithVirtualMachineSize(ContainerServiceVirtualMachineSizeTypes vmSize)
        {
            return this.WithVirtualMachineSize(vmSize) as ContainerServiceAgentPool.Definition.IWithLeafDomainLabel<ContainerService.Definition.IWithCreate>;
        }

        /// <summary>
        /// OS type to be used for every machine in the agent pool.
        /// Default is Linux.
        /// </summary>
        /// <param name="osType">OS type to be used for every machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IWithOSType<ContainerService.Definition.IWithCreate>.WithOSType(ContainerServiceOSTypes osType)
        {
            return this.WithOSType(osType) as ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ContainerService.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ContainerService.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as ContainerService.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the number of agents (virtual machines) to host docker containers.
        /// </summary>
        /// <param name="count">A number between 1 and 100.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithVMSize<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IBlank<ContainerService.Definition.IWithCreate>.WithVirtualMachineCount(int count)
        {
            return this.WithVirtualMachineCount(count) as ContainerServiceAgentPool.Definition.IWithVMSize<ContainerService.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specify the DNS prefix to be used in the FQDN for the agent pool.
        /// </summary>
        /// <param name="dnsPrefix">The DNS prefix.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IWithLeafDomainLabel<ContainerService.Definition.IWithCreate>.WithDnsPrefix(string dnsPrefix)
        {
            return this.WithDnsPrefix(dnsPrefix) as ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate>;
        }

        /// <return>DNS prefix to be used to create the FQDN for the agent pool.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.DnsPrefix()
        {
            return this.DnsPrefix();
        }

        /// <return>The number of agents (virtual machines) to host docker containers.</return>
        int Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.Count()
        {
            return this.Count();
        }

        /// <return>FDQN for the agent pool.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.Fqdn()
        {
            return this.Fqdn();
        }

        /// <return>The storage kind (managed or classic) set for each virtual machine in the agent pool.</return>
        StorageProfileTypes Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.StorageProfile()
        {
            return this.StorageProfile() as StorageProfileTypes;
        }

        /// <return>The size of each virtual machine in the agent pool.</return>
        ContainerServiceVirtualMachineSizeTypes Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.VMSize()
        {
            return this.VMSize() as ContainerServiceVirtualMachineSizeTypes;
        }

        /// <return>OS disk size in GB set for each virtual machine in the agent pool.</return>
        int Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.OSDiskSizeInGB()
        {
            return this.OSDiskSizeInGB();
        }

        /// <return>Array of ports opened on this agent pool.</return>
        int[] Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.Ports()
        {
            return this.Ports();
        }

        /// <return>The name of the subnet used by each virtual machine in the agent pool.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.SubnetName()
        {
            return this.SubnetName();
        }

        /// <return>The ID of the virtual network used by each virtual machine in the agent pool.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.NetworkId()
        {
            return this.NetworkId();
        }

        /// <return>OS of each virtual machine in the agent pool.</return>
        ContainerServiceOSTypes Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool.OSType()
        {
            return this.OSType() as ContainerServiceOSTypes;
        }

        /// <summary>
        /// Specifies the subnet to be used for each virtual machine in the agent pool.
        /// The subnet must be in the same virtual network as specified for the master. By default, the master subnet will be used.
        /// </summary>
        /// <param name="subnetName">The name of the subnet to be used for each virtual machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate> ContainerServiceAgentPool.Definition.IWithSubnet<ContainerService.Definition.IWithCreate>.WithSubnetName(string subnetName)
        {
            return this.WithSubnetName(subnetName) as ContainerServiceAgentPool.Definition.IWithAttach<ContainerService.Definition.IWithCreate>;
        }
    }
}