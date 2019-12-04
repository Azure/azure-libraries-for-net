// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update;
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class KubernetesClusterImpl
    {
        /// <summary>
        /// Gets the cluster's add-on's profiles.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.ContainerService.Fluent.Models.ManagedClusterAddonProfile> Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.AddonProfiles
        {
            get
            {
                return this.AddonProfiles();
            }
        }

        /// <summary>
        /// Gets the Kubernetes configuration file content with administrative privileges to the cluster.
        /// </summary>
        byte[] Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.AdminKubeConfigContent
        {
            get
            {
                return this.AdminKubeConfigContent();
            }
        }

        /// <summary>
        /// Gets the agent pools in the Kubernetes cluster.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool> Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.AgentPools
        {
            get
            {
                return this.AgentPools();
            }
        }

        /// <summary>
        /// Gets Begins the definition of a network profile to be attached to the Kubernetes cluster.
        /// </summary>
        /// <summary>
        /// Gets the stage representing configuration for the network profile.
        /// </summary>
        KubernetesCluster.Definition.IBlank<KubernetesCluster.Definition.IWithCreate> KubernetesCluster.Definition.IWithNetworkProfile.DefineNetworkProfile
        {
            get
            {
                return this.DefineNetworkProfile();
            }
        }

        /// <summary>
        /// Gets the DNS prefix which was specified at creation time.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.DnsPrefix
        {
            get
            {
                return this.DnsPrefix();
            }
        }

        /// <summary>
        /// Gets true if Kubernetes Role-Based Access Control is enabled.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.EnableRBAC
        {
            get
            {
                return this.EnableRBAC();
            }
        }

        /// <summary>
        /// Gets the FQDN for the master pool.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.Fqdn
        {
            get
            {
                return this.Fqdn();
            }
        }

        /// <summary>
        /// Gets the Linux root username.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.LinuxRootUsername
        {
            get
            {
                return this.LinuxRootUsername();
            }
        }

        /// <summary>
        /// Gets the Linux SSH key.
        /// </summary>
        Models.ContainerServiceNetworkProfile Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.NetworkProfile
        {
            get
            {
                return this.NetworkProfile();
            }
        }

        /// <summary>
        /// Gets the name of the resource group containing agent pool nodes.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.NodeResourceGroup
        {
            get
            {
                return this.NodeResourceGroup();
            }
        }

        /// <summary>
        /// Gets the provisioning state of the Kubernetes cluster.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the service principal client ID.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.ServicePrincipalClientId
        {
            get
            {
                return this.ServicePrincipalClientId();
            }
        }

        /// <summary>
        /// Gets the service principal secret.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.ServicePrincipalSecret
        {
            get
            {
                return this.ServicePrincipalSecret();
            }
        }

        /// <summary>
        /// Gets the Linux SSH key.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.SshKey
        {
            get
            {
                return this.SshKey();
            }
        }

        /// <summary>
        /// Gets the Kubernetes configuration file content with user-level privileges to the cluster.
        /// </summary>
        byte[] Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.UserKubeConfigContent
        {
            get
            {
                return this.UserKubeConfigContent();
            }
        }

        /// <summary>
        /// Gets the Kubernetes version.
        /// </summary>
        Microsoft.Azure.Management.ContainerService.Fluent.Models.KubernetesVersion Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.Version
        {
            get
            {
                return this.Version();
            }
        }

        /// <summary>
        /// Begins the definition of a agent pool profile to be attached to the Kubernetes cluster.
        /// </summary>
        /// <param name="name">The name for the agent pool profile.</param>
        /// <return>The stage representing configuration for the agent pool profile.</return>
        KubernetesClusterAgentPool.Definition.IBlank<KubernetesCluster.Definition.IWithCreate> KubernetesCluster.Definition.IWithAgentPool.DefineAgentPool(string name)
        {
            return this.DefineAgentPool(name);
        }

        /// <summary>
        /// Updates the cluster's add-on's profiles.
        /// </summary>
        /// <param name="addOnProfileMap">The cluster's add-on's profiles.</param>
        /// <return>The next stage of the update.</return>
        KubernetesCluster.Update.IUpdate KubernetesCluster.Update.IWithAddOnProfilesBeta.WithAddOnProfiles(IDictionary<string, Microsoft.Azure.Management.ContainerService.Fluent.Models.ManagedClusterAddonProfile> addOnProfileMap)
        {
            return this.WithAddOnProfiles(addOnProfileMap);
        }

        /// <summary>
        /// Updates the cluster's add-on's profiles.
        /// </summary>
        /// <param name="addOnProfileMap">The cluster's add-on's profiles.</param>
        /// <return>The next stage of the update.</return>
        KubernetesCluster.Update.IUpdate KubernetesCluster.Definition.IWithAddOnProfilesBeta.WithAddOnProfiles(IDictionary<string, Microsoft.Azure.Management.ContainerService.Fluent.Models.ManagedClusterAddonProfile> addOnProfileMap)
        {
            return this.WithAddOnProfiles(addOnProfileMap);
        }

        /// <summary>
        /// Updates the agent pool virtual machine count.
        /// </summary>
        /// <param name="agentPoolName">The name of the agent pool to be updated.</param>
        /// <param name="agentCount">The number of agents (virtual machines) to host docker containers.</param>
        /// <return>The next stage of the update.</return>
        KubernetesCluster.Update.IUpdate KubernetesCluster.Update.IWithUpdateAgentPoolCountBeta.WithAgentPoolVirtualMachineCount(string agentPoolName, int agentCount)
        {
            return this.WithAgentPoolVirtualMachineCount(agentPoolName, agentCount);
        }

        /// <summary>
        /// Updates all the agent pools virtual machine count.
        /// </summary>
        /// <param name="agentCount">The number of agents (virtual machines) to host docker containers.</param>
        /// <return>The next stage of the update.</return>
        KubernetesCluster.Update.IUpdate KubernetesCluster.Update.IWithUpdateAgentPoolCountBeta.WithAgentPoolVirtualMachineCount(int agentCount)
        {
            return this.WithAgentPoolVirtualMachineCount(agentCount);
        }

        /// <summary>
        /// Specifies the DNS prefix to be used to create the FQDN for the master pool.
        /// </summary>
        /// <param name="dnsPrefix">The DNS prefix to be used to create the FQDN for the master pool.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithCreate KubernetesCluster.Definition.IWithDnsPrefix.WithDnsPrefix(string dnsPrefix)
        {
            return this.WithDnsPrefix(dnsPrefix);
        }

        /// <summary>
        /// Uses the latest version for the Kubernetes cluster.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithLinuxRootUsername KubernetesCluster.Definition.IWithVersion.WithLatestVersion()
        {
            return this.WithLatestVersion();
        }

        /// <summary>
        /// Updates the cluster's network profile.
        /// </summary>
        /// <param name="networkProfile">The cluster's networkProfile.</param>
        /// <return>The next stage of the update.</return>
        KubernetesCluster.Update.IUpdate KubernetesCluster.Update.IWithNetworkProfileBeta.WithNetworkProfile(ContainerServiceNetworkProfile networkProfile)
        {
            return this.WithNetworkProfile(networkProfile);
        }

        /// <summary>
        /// Updates the cluster to specify the Kubernetes Role-Based Access Control is disabled.
        /// </summary>
        /// <return>The next stage of the update.</return>
        KubernetesCluster.Update.IUpdate KubernetesCluster.Update.IWithRBACBeta.WithRBACDisabled()
        {
            return this.WithRBACDisabled();
        }

        /// <summary>
        /// Updates the cluster to specify the Kubernetes Role-Based Access Control is enabled.
        /// </summary>
        /// <return>The next stage of the update.</return>
        KubernetesCluster.Update.IUpdate KubernetesCluster.Update.IWithRBACBeta.WithRBACEnabled()
        {
            return this.WithRBACEnabled();
        }

        /// <summary>
        /// Begins the definition to specify Linux root username.
        /// </summary>
        /// <param name="rootUserName">The root username.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithLinuxSshKey KubernetesCluster.Definition.IWithLinuxRootUsername.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName);
        }

        /// <summary>
        /// Properties for Kubernetes cluster service principal.
        /// </summary>
        /// <param name="clientId">The ID for the service principal.</param>
        /// <return>The next stage.</return>
        KubernetesCluster.Definition.IWithServicePrincipalProfile KubernetesCluster.Definition.IWithServicePrincipalClientId.WithServicePrincipalClientId(string clientId)
        {
            return this.WithServicePrincipalClientId(clientId);
        }

        /// <summary>
        /// Properties for  service principal.
        /// </summary>
        /// <param name="secret">The secret password associated with the service principal.</param>
        /// <return>The next stage.</return>
        KubernetesCluster.Definition.IWithAgentPool KubernetesCluster.Definition.IWithServicePrincipalProfile.WithServicePrincipalSecret(string secret)
        {
            return this.WithServicePrincipalSecret(secret);
        }

        /// <summary>
        /// Begins the definition to specify Linux ssh key.
        /// </summary>
        /// <param name="sshKeyData">The SSH key data.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithServicePrincipalClientId KubernetesCluster.Definition.IWithLinuxSshKey.WithSshKey(string sshKeyData)
        {
            return this.WithSshKey(sshKeyData);
        }

        /// <summary>
        /// Specifies the version for the Kubernetes cluster.
        /// </summary>
        /// <param name="kubernetesVersion">The kubernetes version.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithLinuxRootUsername KubernetesCluster.Definition.IWithVersion.WithVersion(Microsoft.Azure.Management.ContainerService.Fluent.Models.KubernetesVersion kubernetesVersion)
        {
            return this.WithVersion(kubernetesVersion);
        }

        /// <summary>
        /// Specifies the version for the Kubernetes cluster.
        /// </summary>
        /// <param name="kubernetesVersion">The kubernetes version.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithLinuxRootUsername KubernetesCluster.Definition.IWithVersion.WithVersion(string kubernetesVersion)
        {
            return this.WithVersion(kubernetesVersion);
        }

        /// <summary>
        /// Creates a virtual node with ACI.
        /// </summary>
        /// <param name="subnetName">The subnet to create virtual node.</param>
        /// <returns>The next stage of the definition.</returns>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithCreate KubernetesCluster.Definition.IWithVirtualNode.WithVirtualNode(string subnetName)
        {
            return this.WithVirtualNode(subnetName);
        }

        /// <summary>
        /// Creates a virtual node with ACI.
        /// </summary>
        /// <param name="subnetName">The subnet to create virtual node.</param>
        /// <returns>The next stage of the update.</returns>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IUpdate KubernetesCluster.Update.IWithVirtualNode.WithVirtualNode(string subnetName)
        {
            return this.WithVirtualNode(subnetName);
        }


        /// <summary>
        /// Removes ACI virtual node.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update.IUpdate KubernetesCluster.Update.IWithVirtualNode.WithoutVirtualNode()
        {
            return this.WithoutVirtualNode();
        }
    }
}