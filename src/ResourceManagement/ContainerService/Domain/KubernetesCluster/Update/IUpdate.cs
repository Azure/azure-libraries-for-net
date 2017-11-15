// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update
{
    using Microsoft.Azure.Management.ContainerService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IWithUpdateAgentPoolCount
    {
    }

    /// <summary>
    /// The stage of the Kubernetes cluster update definition allowing to specify the number of agents in the specified pool.
    /// </summary>
    public interface IWithUpdateAgentPoolCount 
    {
        /// <summary>
        /// Updates the agent pool virtual machine count.
        /// </summary>
        /// <param name="agentPoolName">The name of the agent pool to be updated.</param>
        /// <param name="agentCount">The number of agents (virtual machines) to host docker containers.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IUpdate WithAgentVirtualMachineCount(string agentPoolName, int agentCount);

        /// <summary>
        /// Updates all the agent pools virtual machine count.
        /// </summary>
        /// <param name="agentCount">The number of agents (virtual machines) to host docker containers.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IUpdate WithAgentVirtualMachineCount(int agentCount);
    }
}