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
        /// OS type to be used for each virtual machine in the agent pool.
        /// Default is Linux.
        /// </summary>
        /// <param name="osType">OS type to be used for each virtual machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesClusterAgentPool.Definition.IWithOSType<KubernetesCluster.Definition.IWithCreate>.WithOSType(ContainerServiceOSTypes osType)
        {
            return this.WithOSType(osType) as KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate>;
        }

        /// <summary>
        /// OS disk size in GB to be used for each virtual machine in the agent pool.
        /// </summary>
        /// <param name="osDiskSizeInGB">OS Disk Size in GB to be used for every machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesClusterAgentPool.Definition.IWithOSDiskSize<KubernetesCluster.Definition.IWithCreate>.WithOSDiskSizeInGB(int osDiskSizeInGB)
        {
            return this.WithOSDiskSizeInGB(osDiskSizeInGB) as KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate>;
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
        /// Specifies the size of the agent virtual machines.
        /// </summary>
        /// <param name="vmSize">The size of each virtual machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesClusterAgentPool.Definition.IWithVMSize<KubernetesCluster.Definition.IWithCreate>.WithVirtualMachineSize(ContainerServiceVirtualMachineSizeTypes vmSize)
        {
            return this.WithVirtualMachineSize(vmSize) as KubernetesClusterAgentPool.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate>;
        }

        /// <return>Size of each agent virtual machine in the agent pool.</return>
        ContainerServiceVirtualMachineSizeTypes Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool.VMSize()
        {
            return this.VMSize() as ContainerServiceVirtualMachineSizeTypes;
        }

        /// <return>OS of each virtual machine in the agent pool.</return>
        ContainerServiceOSTypes Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool.OSType()
        {
            return this.OSType() as ContainerServiceOSTypes;
        }

        /// <return>OS disk size in GB set for each virtual machine in the agent pool.</return>
        int Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool.OSDiskSizeInGB()
        {
            return this.OSDiskSizeInGB();
        }

        /// <return>The number of agents (virtual machines) to host docker containers.</return>
        int Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool.Count()
        {
            return this.Count();
        }

        /// <return>The storage kind (managed or classic) set for each virtual machine in the agent pool.</return>
        StorageProfileTypes Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool.StorageProfile()
        {
            return this.StorageProfile() as StorageProfileTypes;
        }

        /// <summary>
        /// Specifies the number of agents (virtual machines) to host docker containers.
        /// </summary>
        /// <param name="count">A number between 1 and 100.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesClusterAgentPool.Definition.IWithVMSize<KubernetesCluster.Definition.IWithCreate> KubernetesClusterAgentPool.Definition.IBlank<KubernetesCluster.Definition.IWithCreate>.WithVirtualMachineCount(int count)
        {
            return this.WithVirtualMachineCount(count) as KubernetesClusterAgentPool.Definition.IWithVMSize<KubernetesCluster.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        KubernetesCluster.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<KubernetesCluster.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as KubernetesCluster.Definition.IWithCreate;
        }
    }
}