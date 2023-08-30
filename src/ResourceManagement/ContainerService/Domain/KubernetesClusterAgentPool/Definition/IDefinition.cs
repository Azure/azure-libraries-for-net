// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The final stage of a container service agent pool definition.
    /// At this stage, any remaining optional settings can be specified, or the container service agent pool
    /// can be attached to the parent container service definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithOSType<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithOSDiskSize<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAgentPoolType<ParentT>,
        IWithAgentPoolMode<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAgentPoolVirtualMachineCount<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithMaxPodsCount<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithVirtualNetwork<ParentT>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {

    }

    /// <summary>
    /// The entirety of a container service agent pool definition as a part of a parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithOSType<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithOSDiskSize<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAgentPoolType<ParentT>,
        IWithAgentPoolMode<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAgentPoolVirtualMachineCount<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithMaxPodsCount<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithVirtualNetwork<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAttach<ParentT>
    {

    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify the agent pool OS type.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithOSType<ParentT>
    {

        /// <summary>
        /// OS type to be used for each virtual machine in the agent pool.
        /// Default is Linux.
        /// </summary>
        /// <param name="osType">OS type to be used for each virtual machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAttach<ParentT> WithOSType(OSType osType);
    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify the maximum number of pods that can run on a node.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithMaxPodsCount<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies the maximum number of pods that can run on a node.
        /// </summary>
        /// <param name="podsCount">The maximum number of pods that can run on a node.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAttach<ParentT> WithMaxPodsCount(int podsCount);
    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify a virtual network to be used for the agents.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithVirtualNetwork<ParentT> :
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
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAttach<ParentT> WithVirtualNetwork(string virtualNetworkId, string subnetName);
    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify the number of agents
    /// (Virtual Machines) to host docker containers.
    /// Allowed values must be in the range of 1 to 100 (inclusive); the default value is 1.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithAgentPoolVirtualMachineCount<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies the number of agents (Virtual Machines) to host docker containers.
        /// </summary>
        /// <param name="count">
        /// The number of agents (VMs) to host docker containers. Allowed values must be in the range
        /// of 1 to 100 (inclusive); the default value is 1.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAttach<ParentT> WithAgentPoolVirtualMachineCount(int count);
    }

    /// <summary>
    /// The first stage of a container service agent pool definition allowing to specify the agent virtual machine size.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies the size of the virtual machines to be used as agents.
        /// </summary>
        /// <param name="vmSize">The size of each virtual machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAttach<ParentT> WithVirtualMachineSize(ContainerServiceVMSizeTypes vmSize);
    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify the agent pool OS disk size.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithOSDiskSize<ParentT>
    {

        /// <summary>
        /// OS disk size in GB to be used for each virtual machine in the agent pool.
        /// </summary>
        /// <param name="osDiskSizeInGB">OS Disk Size in GB to be used for every machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAttach<ParentT> WithOSDiskSizeInGB(int osDiskSizeInGB);
    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify the type of agent pool.
    /// Allowed values could be seen in AgentPoolType Class.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithAgentPoolType<ParentT>
    {

        /// <summary>
        /// Set agent pool type to every virtual machine in the agent pool.
        /// </summary>
        /// <param name="agentPoolType">The agent pool type for every machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAttach<ParentT> WithAgentPoolType(AgentPoolType agentPoolType);

        /// <summary>
        /// Set agent pool type by type name.
        /// </summary>
        /// <param name="agentPoolTypeName">The agent pool type name in string format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAttach<ParentT> WithAgentPoolTypeName(string agentPoolTypeName);
    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify the mode of agent pool.
    /// Allowed values could be seen in AgentPoolMode Class.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithAgentPoolMode<ParentT>
    {

        /// <summary>
        /// Set agent pool type to every virtual machine in the agent pool.
        /// </summary>
        /// <param name="agentPoolMode">The agent pool mode for the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAttach<ParentT> WithAgentPoolMode(AgentPoolMode agentPoolMode);

        /// <summary>
        /// Set agent pool type by type name.
        /// </summary>
        /// <param name="agentPoolModeName">The agent pool mode name in string format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAttach<ParentT> WithAgentPoolModeName(string agentPoolModeName);
    }
}