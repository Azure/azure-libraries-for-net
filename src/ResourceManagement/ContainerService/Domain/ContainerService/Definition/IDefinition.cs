// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;

    /// <summary>
    /// The stage of the container service definition allowing to specific the Linux root username.
    /// </summary>
    public interface IWithLinuxRootUsername 
    {
        /// <summary>
        /// Begins the definition to specify Linux root username.
        /// </summary>
        /// <param name="rootUserName">The root username.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithLinuxSshKey WithRootUsername(string rootUserName);
    }

    /// <summary>
    /// The stage of the container service definition allowing to specify the master VM size.
    /// </summary>
    public interface IWithMasterVMSize 
    {
        /// <summary>
        /// Specifies the size of the master VMs, default set to "Standard_D2_v2".
        /// </summary>
        /// <param name="vmSize">The size of the VM.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithCreate WithMasterVMSize(ContainerServiceVMSizeTypes vmSize);
    }

    /// <summary>
    /// Container interface for all the definitions related to a container service.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IBlank,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithGroup,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithOrchestrator,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithMasterNodeCount,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithLinux,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithLinuxRootUsername,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithLinuxSshKey,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithAgentPool,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithServicePrincipalProfile,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The first stage of a container service definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created,
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithMasterDnsPrefix,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithDiagnostics,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithMasterVMSize,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithMasterStorageProfile,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithMasterOSDiskSize,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithSubnet,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.ContainerService.Fluent.IContainerService>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the container service definition allowing to specify an agent pool profile.
    /// </summary>
    public interface IWithAgentPool 
    {
        /// <summary>
        /// Begins the definition of a agent pool profile to be attached to the container service.
        /// </summary>
        /// <param name="name">The name for the agent pool profile.</param>
        /// <return>The stage representing configuration for the agent pool profile.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IBlank<Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithCreate> DefineAgentPool(string name);
    }

    /// <summary>
    /// The stage of the container service definition allowing to specify the master node count.
    /// </summary>
    public interface IWithMasterNodeCount 
    {
        /// <summary>
        /// Specifies the master node count.
        /// </summary>
        /// <param name="count">Master profile count (1, 3, 5).</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithAgentPool WithMasterNodeCount(ContainerServiceMasterProfileCount count);
    }

    /// <summary>
    /// The stage of a container service definition allowing to specify the master pool OS disk size.
    /// </summary>
    public interface IWithMasterOSDiskSize 
    {
        /// <summary>
        /// OS Disk Size in GB to be used for every machine in the master pool.
        /// If you specify 0, the default osDisk size will be used according to the vmSize specified.
        /// </summary>
        /// <param name="osDiskSizeInGB">OS Disk Size in GB to be used for every machine in the master pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithCreate WithMasterOSDiskSizeInGB(int osDiskSizeInGB);
    }

    /// <summary>
    /// The stage of the container service definition allowing to specific the Linux SSH key.
    /// </summary>
    public interface IWithLinuxSshKey 
    {
        /// <summary>
        /// Begins the definition to specify Linux ssh key.
        /// </summary>
        /// <param name="sshKeyData">The SSH key data.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithMasterNodeCount WithSshKey(string sshKeyData);
    }

    /// <summary>
    /// The stage of the container service definition allowing to specify the master DNS prefix label.
    /// </summary>
    public interface IWithMasterDnsPrefix 
    {
        /// <summary>
        /// Specifies the DNS prefix to be used to create the FQDN for the master pool.
        /// </summary>
        /// <param name="dnsPrefix">The DNS prefix to be used to create the FQDN for the master pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithCreate WithMasterDnsPrefix(string dnsPrefix);
    }

    /// <summary>
    /// The stage of the container service definition allowing to specify the virtual network and subnet for the machines.
    /// </summary>
    public interface IWithSubnet 
    {
        /// <summary>
        /// Specifies the virtual network and subnet for the virtual machines in the master and agent pools.
        /// </summary>
        /// <param name="networkId">The network ID to be used by the machines.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithCreate WithSubnet(string networkId, string subnetName);
    }

    /// <summary>
    /// The stage of a container service definition allowing to specify the master's virtual machine storage kind.
    /// </summary>
    public interface IWithMasterStorageProfile 
    {
        /// <summary>
        /// Specifies the storage kind to be used for every machine in master pool.
        /// </summary>
        /// <param name="storageProfile">The storage kind to be used for every machine in the master pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithCreate WithMasterStorageProfile(ContainerServiceStorageProfileTypes storageProfile);
    }

    /// <summary>
    /// The stage of the container service definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithOrchestrator>
    {
    }

    /// <summary>
    /// The stage of the container service definition allowing to specify orchestration type.
    /// </summary>
    public interface IWithOrchestrator 
    {
        /// <summary>
        /// Specifies the Kubernetes orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithServicePrincipalProfile WithKubernetesOrchestration();

        /// <summary>
        /// Specifies the DCOS orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithLinux WithDcosOrchestration();

        /// <summary>
        /// Specifies the Swarm orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithLinux WithSwarmOrchestration();
    }

    /// <summary>
    /// The stage of the container service definition allowing the start of defining Linux specific settings.
    /// </summary>
    public interface IWithLinux 
    {
        /// <summary>
        /// Begins the definition to specify Linux settings.
        /// </summary>
        /// <return>The stage representing configuration of Linux specific settings.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithLinuxRootUsername WithLinux();
    }

    /// <summary>
    /// The stage allowing properties for cluster service principals to be specified.
    /// </summary>
    public interface IWithServicePrincipalProfile 
    {
        /// <summary>
        /// Properties for cluster service principals.
        /// </summary>
        /// <param name="clientId">The ID for the service principal.</param>
        /// <param name="secret">The secret password associated with the service principal.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithLinux WithServicePrincipal(string clientId, string secret);
    }

    /// <summary>
    /// The stage of the container service definition allowing to enable diagnostics.
    /// </summary>
    public interface IWithDiagnostics 
    {
        /// <summary>
        /// Enables diagnostics.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition.IWithCreate WithDiagnostics();
    }
}