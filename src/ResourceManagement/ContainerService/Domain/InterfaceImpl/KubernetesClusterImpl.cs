// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update;
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Collections.Generic;

    internal partial class KubernetesClusterImpl 
    {
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
        /// Specifies the KeyVault secret.
        /// </summary>
        /// <param name="secretName">The KeyVault reference to the secret which stores the password associated with the service principal.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithAgentPool KubernetesCluster.Definition.IWithKeyVaultSecret.WithKeyVaultSecret(string secretName)
        {
            return this.WithKeyVaultSecret(secretName);
        }

        /// <summary>
        /// Specifies the KeyVault secret and the version of it.
        /// </summary>
        /// <param name="secretName">The KeyVault reference to the secret which stores the password associated with the service principal.</param>
        /// <param name="secretVersion">The KeyVault secret version to be used.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithAgentPool KubernetesCluster.Definition.IWithKeyVaultSecret.WithKeyVaultSecret(string secretName, string secretVersion)
        {
            return this.WithKeyVaultSecret(secretName, secretVersion);
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
        /// Begins the definition of a agent pool profile to be attached to the Kubernetes cluster.
        /// </summary>
        /// <param name="name">The name for the agent pool profile.</param>
        /// <return>The stage representing configuration for the agent pool profile.</return>
        KubernetesClusterAgentPool.Definition.IBlank<KubernetesCluster.Definition.IWithCreate> KubernetesCluster.Definition.IWithAgentPool.DefineAgentPool(string name)
        {
            return this.DefineAgentPool(name);
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
        /// Specifies the version for the Kubernetes cluster.
        /// </summary>
        /// <param name="kubernetesVersion">The kubernetes version.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithLinuxRootUsername KubernetesCluster.Definition.IWithVersion.WithVersion(string kubernetesVersion)
        {
            return this.WithVersion(kubernetesVersion);
        }

        /// <summary>
        /// Specifies the version for the Kubernetes cluster.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithLinuxRootUsername KubernetesCluster.Definition.IWithVersion.WithVersion(Microsoft.Azure.Management.ContainerService.Fluent.Models.KubernetesVersion kubernetesVersion)
        {
            return this.WithVersion(kubernetesVersion);
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
        /// Properties for Kubernetes cluster service principal.
        /// </summary>
        /// <param name="clientId">The ID for the service principal.</param>
        /// <return>The next stage.</return>
        KubernetesCluster.Definition.IWithServicePrincipalProfile KubernetesCluster.Definition.IWithServicePrincipalClientId.WithServicePrincipalClientId(string clientId)
        {
            return this.WithServicePrincipalClientId(clientId);
        }

        /// <summary>
        /// Updates the agent pool virtual machine count.
        /// </summary>
        /// <param name="agentPoolName">The name of the agent pool to be updated.</param>
        /// <param name="agentCount">The number of agents (virtual machines) to host docker containers.</param>
        /// <return>The next stage of the update.</return>
        KubernetesCluster.Update.IUpdate KubernetesCluster.Update.IWithUpdateAgentPoolCount.WithAgentVirtualMachineCount(string agentPoolName, int agentCount)
        {
            return this.WithAgentVirtualMachineCount(agentPoolName, agentCount);
        }

        /// <summary>
        /// Updates all the agent pools virtual machine count.
        /// </summary>
        /// <param name="agentCount">The number of agents (virtual machines) to host docker containers.</param>
        /// <return>The next stage of the update.</return>
        KubernetesCluster.Update.IUpdate KubernetesCluster.Update.IWithUpdateAgentPoolCount.WithAgentVirtualMachineCount(int agentCount)
        {
            return this.WithAgentVirtualMachineCount(agentCount);
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
        /// Properties for cluster service principals.
        /// </summary>
        /// <param name="vaultId">The ID for the service principal.</param>
        /// <return>The next stage.</return>
        KubernetesCluster.Definition.IWithKeyVaultSecret KubernetesCluster.Definition.IWithServicePrincipalProfile.WithKeyVaultReference(string vaultId)
        {
            return this.WithKeyVaultReference(vaultId);
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
        /// Gets the key vault reference to the service principal secret.
        /// </summary>
        Models.KeyVaultSecretRef Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.KeyVaultSecretReference
        {
            get
            {
                return this.KeyVaultSecretReference();
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
        /// Gets the agent pools in the Kubernetes cluster.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool> Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.AgentPools
        {
            get
            {
                return this.AgentPools();
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
        /// Gets the Linux SSH key.
        /// </summary>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.SshKey
        {
            get
            {
                return this.SshKey();
            }
        }
    }
}