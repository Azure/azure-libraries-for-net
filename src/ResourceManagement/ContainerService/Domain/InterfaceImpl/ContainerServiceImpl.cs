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
    using Microsoft.Azure.Management.Compute.Fluent;

    internal partial class ContainerServiceImpl 
    {
        /// <summary>
        /// Specifies the DCOS orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithLinux ContainerService.Definition.IWithOrchestrator.WithDcosOrchestration()
        {
            return this.WithDcosOrchestration() as ContainerService.Definition.IWithLinux;
        }

        /// <summary>
        /// Specifies the Kubernetes orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithServicePrincipalProfile ContainerService.Definition.IWithOrchestrator.WithKubernetesOrchestration()
        {
            return this.WithKubernetesOrchestration() as ContainerService.Definition.IWithServicePrincipalProfile;
        }

        /// <summary>
        /// Specifies the Swarm orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithLinux ContainerService.Definition.IWithOrchestrator.WithSwarmOrchestration()
        {
            return this.WithSwarmOrchestration() as ContainerService.Definition.IWithLinux;
        }

        /// <summary>
        /// OS Disk Size in GB to be used for every machine in the master pool.
        /// If you specify 0, the default osDisk size will be used according to the vmSize specified.
        /// </summary>
        /// <param name="osDiskSizeInGB">OS Disk Size in GB to be used for every machine in the master pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithCreate ContainerService.Definition.IWithMasterOSDiskSize.WithMasterOSDiskSizeInGB(int osDiskSizeInGB)
        {
            return this.WithMasterOSDiskSizeInGB(osDiskSizeInGB) as ContainerService.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins the definition to specify Linux ssh key.
        /// </summary>
        /// <param name="sshKeyData">The SSH key data.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithMasterNodeCount ContainerService.Definition.IWithLinuxSshKey.WithSshKey(string sshKeyData)
        {
            return this.WithSshKey(sshKeyData) as ContainerService.Definition.IWithMasterNodeCount;
        }

        /// <summary>
        /// Begins the definition of a agent pool profile to be attached to the container service.
        /// </summary>
        /// <param name="name">The name for the agent pool profile.</param>
        /// <return>The stage representing configuration for the agent pool profile.</return>
        ContainerServiceAgentPool.Definition.IBlank<ContainerService.Definition.IWithCreate> ContainerService.Definition.IWithAgentPool.DefineAgentPool(string name)
        {
            return this.DefineAgentPool(name) as ContainerServiceAgentPool.Definition.IBlank<ContainerService.Definition.IWithCreate>;
        }

        /// <summary>
        /// Begins the definition to specify Linux root username.
        /// </summary>
        /// <param name="rootUserName">The root username.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithLinuxSshKey ContainerService.Definition.IWithLinuxRootUsername.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName) as ContainerService.Definition.IWithLinuxSshKey;
        }

        /// <summary>
        /// Specifies the storage kind to be used for every machine in master pool.
        /// </summary>
        /// <param name="storageProfile">The storage kind to be used for every machine in the master pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithCreate ContainerService.Definition.IWithMasterStorageProfile.WithMasterStorageProfile(StorageProfileTypes storageProfile)
        {
            return this.WithMasterStorageProfile(storageProfile) as ContainerService.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins the definition to specify Linux settings.
        /// </summary>
        /// <return>The stage representing configuration of Linux specific settings.</return>
        ContainerService.Definition.IWithLinuxRootUsername ContainerService.Definition.IWithLinux.WithLinux()
        {
            return this.WithLinux() as ContainerService.Definition.IWithLinuxRootUsername;
        }

        /// <summary>
        /// Updates the agent pool virtual machine count.
        /// </summary>
        /// <param name="agentCount">The number of agents (virtual machines) to host docker containers.</param>
        /// <return>The next stage of the update.</return>
        ContainerService.Update.IUpdate ContainerService.Update.IWithUpdateAgentPoolCount.WithAgentVMCount(int agentCount)
        {
            return this.WithAgentVMCount(agentCount) as ContainerService.Update.IUpdate;
        }

        /// <summary>
        /// Properties for cluster service principals.
        /// </summary>
        /// <param name="clientId">The ID for the service principal.</param>
        /// <param name="secret">The secret password associated with the service principal.</param>
        /// <return>The next stage.</return>
        ContainerService.Definition.IWithLinux ContainerService.Definition.IWithServicePrincipalProfile.WithServicePrincipal(string clientId, string secret)
        {
            return this.WithServicePrincipal(clientId, secret) as ContainerService.Definition.IWithLinux;
        }

        /// <summary>
        /// Enables diagnostics.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithCreate ContainerService.Definition.IWithDiagnostics.WithDiagnostics()
        {
            return this.WithDiagnostics() as ContainerService.Definition.IWithCreate;
        }

        /// <summary>
        /// Disables diagnostics.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Update.IUpdate ContainerService.Update.IWithDiagnostics.WithoutDiagnostics()
        {
            return this.WithoutDiagnostics() as ContainerService.Update.IUpdate;
        }

        /// <summary>
        /// Enables diagnostics.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Update.IUpdate ContainerService.Update.IWithDiagnostics.WithDiagnostics()
        {
            return this.WithDiagnostics() as ContainerService.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the master node count.
        /// </summary>
        /// <param name="count">Master profile count (1, 3, 5).</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithAgentPool ContainerService.Definition.IWithMasterNodeCount.WithMasterNodeCount(ContainerServiceMasterProfileCount count)
        {
            return this.WithMasterNodeCount(count) as ContainerService.Definition.IWithAgentPool;
        }

        /// <return>The name of the subnet used by every machine in the master pool.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.MasterSubnetName()
        {
            return this.MasterSubnetName();
        }

        /// <return>The master FQDN.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.MasterFqdn()
        {
            return this.MasterFqdn();
        }

        /// <return>The Linux root username.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.LinuxRootUsername()
        {
            return this.LinuxRootUsername();
        }

        /// <return>The master node count.</return>
        int Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.MasterNodeCount()
        {
            return this.MasterNodeCount();
        }

        /// <return>True if diagnostics are enabled.</return>
        bool Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.IsDiagnosticsEnabled()
        {
            return this.IsDiagnosticsEnabled();
        }

        /// <return>The master DNS prefix which was specified at creation time.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.MasterDnsPrefix()
        {
            return this.MasterDnsPrefix();
        }

        /// <return>The agent pools map.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool> Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.AgentPools()
        {
            return this.AgentPools() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool>;
        }

        /// <return>The service principal client ID.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.ServicePrincipalClientId()
        {
            return this.ServicePrincipalClientId();
        }

        /// <return>The service principal secret.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.ServicePrincipalSecret()
        {
            return this.ServicePrincipalSecret();
        }

        /// <return>The ID of the virtual network used by every machine in the master and agent pools.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.NetworkId()
        {
            return this.NetworkId();
        }

        /// <return>The type of the orchestrator.</return>
        Models.ContainerServiceOrchestratorTypes Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.OrchestratorType()
        {
            return this.OrchestratorType();
        }

        /// <return>OS disk size in GB set for every machine in the master pool.</return>
        int Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.MasterOSDiskSizeInGB()
        {
            return this.MasterOSDiskSizeInGB();
        }

        /// <return>The Linux SSH key.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.SshKey()
        {
            return this.SshKey();
        }

        /// <return>The storage kind set for every machine in the master pool.</return>
        StorageProfileTypes Microsoft.Azure.Management.ContainerService.Fluent.IContainerService.MasterStorageProfile()
        {
            return this.MasterStorageProfile() as StorageProfileTypes;
        }

        /// <summary>
        /// Specifies the virtual network and subnet for the virtual machines in the master and agent pools.
        /// </summary>
        /// <param name="networkId">The network ID to be used by the machines.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithCreate ContainerService.Definition.IWithSubnet.WithSubnet(string networkId, string subnetName)
        {
            return this.WithSubnet(networkId, subnetName) as ContainerService.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the DNS prefix to be used to create the FQDN for the master pool.
        /// </summary>
        /// <param name="dnsPrefix">The DNS prefix to be used to create the FQDN for the master pool.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithCreate ContainerService.Definition.IWithMasterDnsPrefix.WithMasterDnsPrefix(string dnsPrefix)
        {
            return this.WithMasterDnsPrefix(dnsPrefix) as ContainerService.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the size of the master VMs, default set to "Standard_D2_v2".
        /// </summary>
        /// <param name="vmSize">The size of the VM.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithCreate ContainerService.Definition.IWithMasterVMSize.WithMasterVMSize(ContainerServiceVirtualMachineSizeTypes vmSize)
        {
            return this.WithMasterVMSize(vmSize) as ContainerService.Definition.IWithCreate;
        }
    }
}