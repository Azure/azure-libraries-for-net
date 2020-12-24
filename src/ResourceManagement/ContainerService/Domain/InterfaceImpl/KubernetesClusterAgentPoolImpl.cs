// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    internal partial class KubernetesClusterAgentPoolImpl
    {
        /// <summary>
        /// Gets the number of agents (virtual machines) to host docker containers.
        /// </summary>
        int Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool.Count
        {
            get
            {
                return this.Count();
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
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool.NetworkId
        {
            get
            {
                return this.NetworkId();
            }
        }

        /// <summary>
        /// Gets OS disk size in GB set for each virtual machine in the agent pool.
        /// </summary>
        int Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool.OSDiskSizeInGB
        {
            get
            {
                return this.OSDiskSizeInGB();
            }
        }

        /// <summary>
        /// Gets OS of each virtual machine in the agent pool.
        /// </summary>
        OSType Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool.OSType
        {
            get
            {
                return this.OSType();
            }
        }

        /// <summary>
        /// Gets the name of the subnet used by each virtual machine in the agent pool.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool.SubnetName
        {
            get
            {
                return this.SubnetName();
            }
        }

        /// <summary>
        /// Gets agent pool type.
        /// </summary>
        AgentPoolType Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Gets size of each agent virtual machine in the agent pool.
        /// </summary>
        ContainerServiceVMSizeTypes Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool.VMSize
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
        KubernetesCluster.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<KubernetesCluster.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Set agent pool type to every virtual machine in the agent pool.
        /// </summary>
        /// <param name="agentPoolType">The agent pool type for every machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesClusterAgentPool.Definition.IWithAgentPoolType<KubernetesCluster.Definition.IWithCreate>.WithAgentPoolType(AgentPoolType agentPoolType)
        {
            return this.WithAgentPoolType(agentPoolType);
        }

        /// <summary>
        /// Set agent pool type by type name.
        /// </summary>
        /// <param name="agentPoolTypeName">The agent pool type name in string format.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesClusterAgentPool.Definition.IWithAgentPoolType<KubernetesCluster.Definition.IWithCreate>.WithAgentPoolTypeName(string agentPoolTypeName)
        {
            return this.WithAgentPoolTypeName(agentPoolTypeName);
        }

        KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesClusterAgentPool.Definition.IWithAgentPoolMode<KubernetesCluster.Definition.IWithCreate>.WithAgentPoolMode(AgentPoolMode agentPoolMode)
        {
            return this.WithAgentPoolMode(agentPoolMode);
        }

        KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesClusterAgentPool.Definition.IWithAgentPoolMode<KubernetesCluster.Definition.IWithCreate>.WithAgentPoolModeName(string agentPoolModeName)
        {
            return this.WithAgentPoolModeName(agentPoolModeName);
        }

        /// <summary>
        /// Specifies the number of agents (Virtual Machines) to host docker containers.
        /// </summary>
        /// <param name="count">
        /// The number of agents (VMs) to host docker containers. Allowed values must be in the range
        /// of 1 to 100 (inclusive); the default value is 1.
        /// </param>
        /// <return>The next stage of the definition.</return>
        KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesClusterAgentPool.Definition.IWithAgentPoolVirtualMachineCount<KubernetesCluster.Definition.IWithCreate>.WithAgentPoolVirtualMachineCount(int count)
        {
            return this.WithAgentPoolVirtualMachineCount(count);
        }

        /// <summary>
        /// Specifies the maximum number of pods that can run on a node.
        /// </summary>
        /// <param name="podsCount">The maximum number of pods that can run on a node.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesClusterAgentPool.Definition.IWithMaxPodsCount<KubernetesCluster.Definition.IWithCreate>.WithMaxPodsCount(int podsCount)
        {
            return this.WithMaxPodsCount(podsCount);
        }

        /// <summary>
        /// OS disk size in GB to be used for each virtual machine in the agent pool.
        /// </summary>
        /// <param name="osDiskSizeInGB">OS Disk Size in GB to be used for every machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesClusterAgentPool.Definition.IWithOSDiskSize<KubernetesCluster.Definition.IWithCreate>.WithOSDiskSizeInGB(int osDiskSizeInGB)
        {
            return this.WithOSDiskSizeInGB(osDiskSizeInGB);
        }

        /// <summary>
        /// OS type to be used for each virtual machine in the agent pool.
        /// Default is Linux.
        /// </summary>
        /// <param name="osType">OS type to be used for each virtual machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesClusterAgentPool.Definition.IWithOSType<KubernetesCluster.Definition.IWithCreate>.WithOSType(OSType osType)
        {
            return this.WithOSType(osType);
        }

        /// <summary>
        /// Specifies the size of the agent virtual machines.
        /// </summary>
        /// <param name="vmSize">The size of each virtual machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesClusterAgentPool.Definition.IBlank<KubernetesCluster.Definition.IWithCreate>.WithVirtualMachineSize(ContainerServiceVMSizeTypes vmSize)
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
        KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesClusterAgentPool.Definition.IWithVirtualNetwork<KubernetesCluster.Definition.IWithCreate>.WithVirtualNetwork(string virtualNetworkId, string subnetName)
        {
            return this.WithVirtualNetwork(virtualNetworkId, subnetName);
        }
    }
}