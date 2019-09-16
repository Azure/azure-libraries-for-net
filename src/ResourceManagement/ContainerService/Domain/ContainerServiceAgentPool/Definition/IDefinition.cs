// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify the agent pool ports to be exposed.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithPorts<ParentT> 
    {
        /// <summary>
        /// Ports to be exposed on this agent pool.
        /// The default exposed ports are different based on your choice of orchestrator.
        /// </summary>
        /// <param name="ports">Port numbers that will be exposed on this agent pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithAttach<ParentT> WithPorts(params int[] ports);
    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify a virtual network to be used for the agents.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithVirtualNetwork<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies the virtual network to be used for the agents.
        /// </summary>
        /// <param name="virtualNetworkId">The ID of a virtual network.</param>
        /// <param name="subnetName">
        /// The name of the subnet within the virtual network.; the subnet must have the service
        /// endpoints enabled for 'Microsoft.ContainerService'.
        /// </param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithAttach<ParentT> WithVirtualNetwork(string virtualNetworkId, string subnetName);
    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify the agent pool OS type.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithOSType<ParentT> 
    {
        /// <summary>
        /// OS type to be used for every machine in the agent pool.
        /// Default is Linux.
        /// </summary>
        /// <param name="osType">OS type to be used for every machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithAttach<ParentT> WithOSType(OSType osType);
    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify the DNS prefix.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithLeafDomainLabel<ParentT> 
    {
        /// <summary>
        /// Specify the DNS prefix to be used in the FQDN for the agent pool.
        /// </summary>
        /// <param name="dnsPrefix">The DNS prefix.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithAttach<ParentT> WithDnsPrefix(string dnsPrefix);
    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify the agent pool OS disk size.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithOSDiskSize<ParentT> 
    {
        /// <summary>
        /// OS Disk Size in GB to be used for every machine in the agent pool.
        /// </summary>
        /// <param name="osDiskSizeInGB">OS disk size in GB to be used for each virtual machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithAttach<ParentT> WithOSDiskSizeInGB(int osDiskSizeInGB);
    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify the agent virtual machine size.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithVMSize<ParentT> 
    {
        /// <summary>
        /// Specifies the size of the agent virtual machines.
        /// </summary>
        /// <param name="vmSize">The size of the virtual machine.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithLeafDomainLabel<ParentT> WithVirtualMachineSize(ContainerServiceVMSizeTypes vmSize);
    }

    /// <summary>
    /// The entirety of a container service agent pool definition as a part of a parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithVMSize<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithLeafDomainLabel<ParentT>
    {
    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify the agent pool storage kind.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithStorageProfile<ParentT> 
    {
        /// <summary>
        /// Specifies the storage kind to be used for each virtual machine in the agent pool.
        /// </summary>
        /// <param name="storageProfile">The storage kind to be used for each virtual machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithAttach<ParentT> WithStorageProfile(ContainerServiceStorageProfileTypes storageProfile);
    }

    /// <summary>
    /// The first stage of a container service agent pool definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> 
    {
        /// <summary>
        /// Specifies the number of agents (virtual machines) to host docker containers.
        /// </summary>
        /// <param name="count">A number between 1 and 100.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithVMSize<ParentT> WithVirtualMachineCount(int count);
    }

    /// <summary>
    /// The final stage of a container service agent pool definition.
    /// At this stage, any remaining optional settings can be specified, or the container service agent pool
    /// can be attached to the parent container service definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithOSType<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithOSDiskSize<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithPorts<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithStorageProfile<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceAgentPool.Definition.IWithVirtualNetwork<ParentT>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }
}