// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update
{
    using Microsoft.Azure.Management.ContainerService.Fluent;
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// The stage of the Kubernetes cluster update definition allowing to specify the cluster's network profile.
    /// </summary>
    public interface IWithNetworkProfile :
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IWithNetworkProfileBeta
    {

    }

    /// <summary>
    /// The stage of the Kubernetes cluster update definition allowing to specify the number of agents in the specified pool.
    /// </summary>
    public interface IWithUpdateAgentPoolCount :
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IWithUpdateAgentPoolCountBeta
    {

    }

    /// <summary>
    /// The stage of the Kubernetes cluster update definition allowing to specify if Kubernetes Role-Based Access Control is enabled or disabled.
    /// </summary>
    public interface IWithRBAC :
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IWithRBACBeta
    {

    }

    /// <summary>
    /// The stage of the Kubernetes cluster update definition allowing to specify the cluster's add-on's profiles.
    /// </summary>
    public interface IWithAddOnProfiles :
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IWithAddOnProfilesBeta
    {

    }

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IWithUpdateAgentPoolCount,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IWithAddOnProfiles,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IWithNetworkProfile,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IWithRBAC,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IWithVirtualNode,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster>
    {

    }

    /// <summary>
    /// The stage of the Kubernetes cluster update definition allowing to specify the cluster's network profile.
    /// </summary>
    public interface IWithNetworkProfileBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Updates the cluster's network profile.
        /// </summary>
        /// <param name="networkProfile">The cluster's networkProfile.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IUpdate WithNetworkProfile(ContainerServiceNetworkProfile networkProfile);
    }

    /// <summary>
    /// The stage of the Kubernetes cluster update definition allowing to specify the number of agents in the specified pool.
    /// </summary>
    public interface IWithUpdateAgentPoolCountBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Updates the agent pool virtual machine count.
        /// </summary>
        /// <param name="agentPoolName">The name of the agent pool to be updated.</param>
        /// <param name="agentCount">The number of agents (virtual machines) to host docker containers.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IUpdate WithAgentPoolVirtualMachineCount(string agentPoolName, int agentCount);

        /// <summary>
        /// Updates all the agent pools virtual machine count.
        /// </summary>
        /// <param name="agentCount">The number of agents (virtual machines) to host docker containers.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IUpdate WithAgentPoolVirtualMachineCount(int agentCount);
    }

    /// <summary>
    /// The stage of the Kubernetes cluster update definition allowing to specify if Kubernetes Role-Based Access Control is enabled or disabled.
    /// </summary>
    public interface IWithRBACBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Updates the cluster to specify the Kubernetes Role-Based Access Control is disabled.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IUpdate WithRBACDisabled();

        /// <summary>
        /// Updates the cluster to specify the Kubernetes Role-Based Access Control is enabled.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IUpdate WithRBACEnabled();
    }

    /// <summary>
    /// The stage of the Kubernetes cluster update definition allowing to specify the cluster's add-on's profiles.
    /// </summary>
    public interface IWithAddOnProfilesBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Updates the cluster's add-on's profiles.
        /// </summary>
        /// <param name="addOnProfileMap">The cluster's add-on's profiles.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IUpdate WithAddOnProfiles(IDictionary<string, Microsoft.Azure.Management.ContainerService.Fluent.Models.ManagedClusterAddonProfile> addOnProfileMap);
    }

    /// <summary>
    /// The stage of the Kubernetes cluster definition allowing to specify virtual node.
    /// </summary>
    public interface IWithVirtualNode :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a virtual node with ACI.
        /// IMPORTANT! This method should be called after 'WithAddOnProfiles'.
        /// </summary>
        /// <param name="subnetName">The subnet in AKS network to create virtual node.</param>
        /// <returns>The next stage of the update.</returns>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IUpdate WithVirtualNode(string subnetName);

        /// <summary>
        /// Removes ACI virtual node.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IUpdate WithoutVirtualNode();
    }
}