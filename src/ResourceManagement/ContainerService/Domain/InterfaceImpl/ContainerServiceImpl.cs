// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Update;
    using Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Collections.Generic;

    internal partial class ContainerServiceImpl 
    {
        /// <summary>
        /// Gets the agent pools map.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool> Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.AgentPools
        {
            get
            {
                return this.AgentPools();
            }
        }

        /// <summary>
        /// Gets true if diagnostics are enabled.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.IsDiagnosticsEnabled
        {
            get
            {
                return this.IsDiagnosticsEnabled();
            }
        }

        /// <summary>
        /// Gets the Linux root username.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.LinuxRootUsername
        {
            get
            {
                return this.LinuxRootUsername();
            }
        }

        /// <summary>
        /// Gets the master DNS prefix which was specified at creation time.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.MasterDnsPrefix
        {
            get
            {
                return this.MasterDnsPrefix();
            }
        }

        /// <summary>
        /// Gets the master FQDN.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.MasterFqdn
        {
            get
            {
                return this.MasterFqdn();
            }
        }

        /// <summary>
        /// Gets the master node count.
        /// </summary>
        int Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.MasterNodeCount
        {
            get
            {
                return this.MasterNodeCount();
            }
        }

        /// <summary>
        /// Gets OS disk size in GB set for every machine in the master pool.
        /// </summary>
        int Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.MasterOSDiskSizeInGB
        {
            get
            {
                return this.MasterOSDiskSizeInGB();
            }
        }

        /// <summary>
        /// Gets the storage kind set for every machine in the master pool.
        /// </summary>
        ContainerServiceStorageProfileTypes Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.MasterStorageProfile
        {
            get
            {
                return this.MasterStorageProfile();
            }
        }

        /// <summary>
        /// Gets the name of the subnet used by every machine in the master pool.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.MasterSubnetName
        {
            get
            {
                return this.MasterSubnetName();
            }
        }

        /// <summary>
        /// Gets the ID of the virtual network used by every machine in the master and agent pools.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.NetworkId
        {
            get
            {
                return this.NetworkId();
            }
        }

        /// <summary>
        /// Gets the type of the orchestrator.
        /// </summary>
        Models.ContainerServiceOrchestratorTypes Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.OrchestratorType
        {
            get
            {
                return this.OrchestratorType();
            }
        }

        /// <summary>
        /// Gets the service principal client ID.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.ServicePrincipalClientId
        {
            get
            {
                return this.ServicePrincipalClientId();
            }
        }

        /// <summary>
        /// Gets the service principal secret.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.ServicePrincipalSecret
        {
            get
            {
                return this.ServicePrincipalSecret();
            }
        }

        /// <summary>
        /// Gets the Linux SSH key.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.SshKey
        {
            get
            {
                return this.SshKey();
            }
        }

        /// <summary>
        /// Begins the definition of a agent pool profile to be attached to the container service.
        /// </summary>
        /// <param name="name">The name for the agent pool profile.</param>
        /// <return>The stage representing configuration for the agent pool profile.</return>
        ContainerServiceAgentPool.Definition.IBlank<ContainerService.Definition.IWithCreate> ContainerService.Definition.IWithAgentPool.DefineAgentPool(string name)
        {
            return this.DefineAgentPool(name);
        }

        /// <summary>
        /// Updates the agent pool virtual machine count.
        /// </summary>
        /// <param name="agentCount">The number of agents (virtual machines) to host docker containers.</param>
        /// <return>The next stage of the update.</return>
        ContainerService.Update.IUpdate ContainerService.Update.IWithUpdateAgentPoolCount.WithAgentVirtualMachineCount(int agentCount)
        {
            return this.WithAgentVirtualMachineCount(agentCount);
        }

        /// <summary>
        /// Specifies the DCOS orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithLinux ContainerService.Definition.IWithOrchestrator.WithDcosOrchestration()
        {
            return this.WithDcosOrchestration();
        }

        /// <summary>
        /// Enables diagnostics.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithCreate ContainerService.Definition.IWithDiagnostics.WithDiagnostics()
        {
            return this.WithDiagnostics();
        }

        /// <summary>
        /// Enables diagnostics.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Update.IUpdate ContainerService.Update.IWithDiagnostics.WithDiagnostics()
        {
            return this.WithDiagnostics();
        }

        /// <summary>
        /// Specifies the Kubernetes orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithServicePrincipalProfile ContainerService.Definition.IWithOrchestrator.WithKubernetesOrchestration()
        {
            return this.WithKubernetesOrchestration();
        }

        /// <summary>
        /// Begins the definition to specify Linux settings.
        /// </summary>
        /// <return>The stage representing configuration of Linux specific settings.</return>
        ContainerService.Definition.IWithLinuxRootUsername ContainerService.Definition.IWithLinux.WithLinux()
        {
            return this.WithLinux();
        }

        /// <summary>
        /// Specifies the DNS prefix to be used to create the FQDN for the master pool.
        /// </summary>
        /// <param name="dnsPrefix">The DNS prefix to be used to create the FQDN for the master pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithCreate ContainerService.Definition.IWithMasterDnsPrefix.WithMasterDnsPrefix(string dnsPrefix)
        {
            return this.WithMasterDnsPrefix(dnsPrefix);
        }

        /// <summary>
        /// Specifies the master node count.
        /// </summary>
        /// <param name="count">Master profile count (1, 3, 5).</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithAgentPool ContainerService.Definition.IWithMasterNodeCount.WithMasterNodeCount(ContainerServiceMasterProfileCount count)
        {
            return this.WithMasterNodeCount(count);
        }

        /// <summary>
        /// OS Disk Size in GB to be used for every machine in the master pool.
        /// If you specify 0, the default osDisk size will be used according to the vmSize specified.
        /// </summary>
        /// <param name="osDiskSizeInGB">OS Disk Size in GB to be used for every machine in the master pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithCreate ContainerService.Definition.IWithMasterOSDiskSize.WithMasterOSDiskSizeInGB(int osDiskSizeInGB)
        {
            return this.WithMasterOSDiskSizeInGB(osDiskSizeInGB);
        }

        /// <summary>
        /// Specifies the storage kind to be used for every machine in master pool.
        /// </summary>
        /// <param name="storageProfile">The storage kind to be used for every machine in the master pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithCreate ContainerService.Definition.IWithMasterStorageProfile.WithMasterStorageProfile(ContainerServiceStorageProfileTypes storageProfile)
        {
            return this.WithMasterStorageProfile(storageProfile);
        }

        /// <summary>
        /// Specifies the size of the master VMs, default set to "Standard_D2_v2".
        /// </summary>
        /// <param name="vmSize">The size of the VM.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithCreate ContainerService.Definition.IWithMasterVMSize.WithMasterVMSize(ContainerServiceVMSizeTypes vmSize)
        {
            return this.WithMasterVMSize(vmSize);
        }

        /// <summary>
        /// Disables diagnostics.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Update.IUpdate ContainerService.Update.IWithDiagnostics.WithoutDiagnostics()
        {
            return this.WithoutDiagnostics();
        }

        /// <summary>
        /// Begins the definition to specify Linux root username.
        /// </summary>
        /// <param name="rootUserName">The root username.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithLinuxSshKey ContainerService.Definition.IWithLinuxRootUsername.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName);
        }

        /// <summary>
        /// Properties for cluster service principals.
        /// </summary>
        /// <param name="clientId">The ID for the service principal.</param>
        /// <param name="secret">The secret password associated with the service principal.</param>
        /// <return>The next stage.</return>
        ContainerService.Definition.IWithLinux ContainerService.Definition.IWithServicePrincipalProfile.WithServicePrincipal(string clientId, string secret)
        {
            return this.WithServicePrincipal(clientId, secret);
        }

        /// <summary>
        /// Begins the definition to specify Linux ssh key.
        /// </summary>
        /// <param name="sshKeyData">The SSH key data.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithMasterNodeCount ContainerService.Definition.IWithLinuxSshKey.WithSshKey(string sshKeyData)
        {
            return this.WithSshKey(sshKeyData);
        }

        /// <summary>
        /// Specifies the virtual network and subnet for the virtual machines in the master and agent pools.
        /// </summary>
        /// <param name="networkId">The network ID to be used by the machines.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithCreate ContainerService.Definition.IWithSubnet.WithSubnet(string networkId, string subnetName)
        {
            return this.WithSubnet(networkId, subnetName);
        }

        /// <summary>
        /// Specifies the Swarm orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithLinux ContainerService.Definition.IWithOrchestrator.WithSwarmOrchestration()
        {
            return this.WithSwarmOrchestration();
        }
    }
}