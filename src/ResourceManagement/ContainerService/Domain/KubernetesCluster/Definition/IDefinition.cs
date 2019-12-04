// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition
{
    using Microsoft.Azure.Management.ContainerService.Fluent;
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// The Kubernetes cluster definition allowing to specify a network profile.
    /// </summary>
    public interface INetworkProfileDefinitionStages
    {

    }

    /// <summary>
    /// The stage of the Kubernetes cluster definition allowing to specify the DNS prefix label.
    /// </summary>
    public interface IWithDnsPrefix
    {

        /// <summary>
        /// Specifies the DNS prefix to be used to create the FQDN for the master pool.
        /// </summary>
        /// <param name="dnsPrefix">The DNS prefix to be used to create the FQDN for the master pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithCreate WithDnsPrefix(string dnsPrefix);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows for any other optional settings to
    /// be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithNetworkProfile,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithDnsPrefix,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAddOnProfiles,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithVirtualNode,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithCreate>
    {

    }

    /// <summary>
    /// The stage of the Kubernetes cluster definition allowing to specify the service principal secret.
    /// </summary>
    public interface IWithServicePrincipalProfile
    {

        /// <summary>
        /// Properties for  service principal.
        /// </summary>
        /// <param name="secret">The secret password associated with the service principal.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAgentPool WithServicePrincipalSecret(string secret);
    }

    /// <summary>
    /// The stage of the Kubernetes cluster definition allowing to specify the cluster's add-on's profiles.
    /// </summary>
    public interface IWithAddOnProfiles :
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAddOnProfilesBeta
    {

    }

    /// <summary>
    /// The stage of the Kubernetes cluster definition allowing to specific the Linux root username.
    /// </summary>
    public interface IWithLinuxRootUsername
    {
        /// <summary>
        /// Begins the definition to specify Linux root username.
        /// </summary>
        /// <param name="rootUserName">The root username.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithLinuxSshKey WithRootUsername(string rootUserName);
    }

    /// <summary>
    /// The stage of the Kubernetes cluster definition allowing to specify a network profile.
    /// </summary>
    public interface IWithNetworkProfile :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Gets Begins the definition of a network profile to be attached to the Kubernetes cluster.
        /// </summary>
        /// <summary>
        /// Gets the stage representing configuration for the network profile.
        /// </summary>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IBlank<Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithCreate> DefineNetworkProfile { get; }
    }

    /// <summary>
    /// The stage of the Kubernetes cluster definition allowing to specify the service principal client ID.
    /// </summary>
    public interface IWithServicePrincipalClientId
    {
        /// <summary>
        /// Properties for Kubernetes cluster service principal.
        /// </summary>
        /// <param name="clientId">The ID for the service principal.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithServicePrincipalProfile WithServicePrincipalClientId(string clientId);
    }

    /// <summary>
    /// The final stage of a network profile definition.
    /// At this stage, any remaining optional settings can be specified, or the container service agent pool
    /// can be attached to the parent container service definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithNetworkPolicy<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithPodCidr<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithServiceCidr<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithDnsServiceIP<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithDockerBridgeCidr<ParentT>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {

    }

    /// <summary>
    /// The stage of the Kubernetes cluster definition allowing to specify an agent pool profile.
    /// </summary>
    public interface IWithAgentPool
    {

        /// <summary>
        /// Begins the definition of an agent pool profile to be attached to the Kubernetes cluster.
        /// </summary>
        /// <param name="name">The name for the agent pool profile.</param>
        /// <return>The stage representing configuration for the agent pool profile.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IBlank<Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithCreate> DefineAgentPool(string name);
    }

    /// <summary>
    /// The first stage of a network profile definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the Kubernetes cluster network profile definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAttach<ParentT>
    {

        /// <summary>
        /// Specifies the network plugin type to be used for building the Kubernetes network.
        /// </summary>
        /// <param name="networkPlugin">The network plugin type to be used for building the Kubernetes network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAttach<ParentT> WithNetworkPlugin(NetworkPlugin networkPlugin);
    }

    /// <summary>
    /// Interface for all the definitions related to a Kubernetes cluster.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IBlank,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithGroup,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithVersion,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithLinuxRootUsername,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithLinuxSshKey,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithServicePrincipalClientId,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithServicePrincipalProfile,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithDnsPrefix,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAgentPool,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithNetworkProfile,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAddOnProfiles,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithVirtualNode,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithCreate
    {

    }

    /// <summary>
    /// The stage of the Kubernetes cluster definition allowing to specific the Linux SSH key.
    /// </summary>
    public interface IWithLinuxSshKey
    {
        /// <summary>
        /// Begins the definition to specify Linux ssh key.
        /// </summary>
        /// <param name="sshKeyData">The SSH key data.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithServicePrincipalClientId WithSshKey(string sshKeyData);
    }

    /// <summary>
    /// The stage of a network profile definition allowing to specify a CIDR notation IP range assigned to the
    /// Docker bridge network.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the network profile definition to return to after attaching this definition.</typeparam>
    public interface IWithDockerBridgeCidr<ParentT>
    {

        /// <summary>
        /// Specifies a CIDR notation IP range assigned to the Docker bridge network; it must not overlap with
        /// any subnet IP ranges or the Kubernetes service address range.
        /// </summary>
        /// <param name="dockerBridgeCidr">
        /// The CIDR notation IP range assigned to the Docker bridge network; it must not
        /// overlap with any subnet IP ranges or the Kubernetes service address range.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAttach<ParentT> WithDockerBridgeCidr(string dockerBridgeCidr);
    }

    /// <summary>
    /// The stage of a network profile definition allowing to specify an IP address assigned to the Kubernetes DNS service.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the network profile definition to return to after attaching this definition.</typeparam>
    public interface IWithDnsServiceIP<ParentT>
    {

        /// <summary>
        /// Specifies an IP address assigned to the Kubernetes DNS service; it must be within the Kubernetes service
        /// address range specified in the service CIDR.
        /// </summary>
        /// <param name="dnsServiceIP">
        /// The IP address assigned to the Kubernetes DNS service; it must be within the
        /// Kubernetes service address range specified in the service CIDR.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAttach<ParentT> WithDnsServiceIP(string dnsServiceIP);
    }

    /// <summary>
    /// The stage of a network profile definition allowing to specify a CIDR notation IP range from which to
    /// assign service cluster IPs.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the network profile definition to return to after attaching this definition.</typeparam>
    public interface IWithServiceCidr<ParentT>
    {

        /// <summary>
        /// Specifies a CIDR notation IP range from which to assign service cluster IPs; must not overlap with
        /// any subnet IP ranges.
        /// </summary>
        /// <param name="serviceCidr">
        /// The CIDR notation IP range from which to assign service cluster IPs; it must not
        /// overlap with any Subnet IP ranges.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAttach<ParentT> WithServiceCidr(string serviceCidr);
    }

    /// <summary>
    /// The Kubernetes cluster network profile definition.
    /// The entirety of a Kubernetes cluster network profile definition as a part of a parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface INetworkProfileDefinition<ParentT> :
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithNetworkPolicy<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithPodCidr<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithServiceCidr<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithDnsServiceIP<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithDockerBridgeCidr<ParentT>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAttach<ParentT>
    {

    }

    /// <summary>
    /// The stage of the Kubernetes cluster definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithVersion>
    {

    }

    /// <summary>
    /// The stage of a network profile definition allowing to specify a CIDR notation IP range from which to
    /// assign pod IPs when kubenet is used.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the network profile definition to return to after attaching this definition.</typeparam>
    public interface IWithPodCidr<ParentT>
    {

        /// <summary>
        /// Specifies a CIDR notation IP range from which to assign pod IPs when kubenet is used.
        /// </summary>
        /// <param name="podCidr">The CIDR notation IP range from which to assign pod IPs when kubenet is used.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAttach<ParentT> WithPodCidr(string podCidr);
    }

    /// <summary>
    /// The stage of a network profile definition allowing to specify the network policy.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the network profile definition to return to after attaching this definition.</typeparam>
    public interface IWithNetworkPolicy<ParentT>
    {

        /// <summary>
        /// Specifies the network policy to be used for building the Kubernetes network.
        /// </summary>
        /// <param name="networkPolicy">The network policy to be used for building the Kubernetes network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAttach<ParentT> WithNetworkPolicy(NetworkPolicy networkPolicy);
    }

    /// <summary>
    /// The stage of the Kubernetes cluster definition allowing to specify orchestration type.
    /// </summary>
    public interface IWithVersion
    {

        /// <summary>
        /// Uses the latest version for the Kubernetes cluster.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithLinuxRootUsername WithLatestVersion();

        /// <summary>
        /// Specifies the version for the Kubernetes cluster.
        /// </summary>
        /// <param name="kubernetesVersion">The kubernetes version.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithLinuxRootUsername WithVersion(Models.KubernetesVersion kubernetesVersion);

        /// <summary>
        /// Specifies the version for the Kubernetes cluster.
        /// </summary>
        /// <param name="kubernetesVersion">The kubernetes version.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithLinuxRootUsername WithVersion(string kubernetesVersion);
    }

    /// <summary>
    /// The first stage of a container service definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithGroup>
    {

    }

    /// <summary>
    /// The stage of the Kubernetes cluster definition allowing to specify the cluster's add-on's profiles.
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
    /// The stage of the Kubernetes cluster definition allowing to enable virtual node.
    /// </summary>
    public interface IWithVirtualNode :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a virtual node with ACI.
        /// IMPORTANT! This method should be called after 'WithAddOnProfiles'.
        /// </summary>
        /// <param name="subnetName">The subnet in AKS network to create virtual node.</param>
        /// <returns>The next stage of the definition.</returns>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithCreate WithVirtualNode(string subnetName);
    }
}