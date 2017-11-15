// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The final stage of a container service agent pool definition.
    /// At this stage, any remaining optional settings can be specified, or the container service agent pool
    /// can be attached to the parent container service definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithOSType<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithOSDiskSize<ParentT>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a container service agent pool definition as a part of a parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithVMSize<ParentT>,
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
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAttach<ParentT> WithOSType(ContainerServiceOSTypes osType);
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
        /// <param name="vmSize">The size of each virtual machine in the agent pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithAttach<ParentT> WithVirtualMachineSize(ContainerServiceVirtualMachineSizeTypes vmSize);
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
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IWithVMSize<ParentT> WithVirtualMachineCount(int count);
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
}