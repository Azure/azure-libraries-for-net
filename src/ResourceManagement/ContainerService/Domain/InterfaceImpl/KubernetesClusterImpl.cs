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
            return this.WithDnsPrefix(dnsPrefix) as KubernetesCluster.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the KeyVault secret.
        /// </summary>
        /// <param name="secretName">The KeyVault reference to the secret which stores the password associated with the service principal.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithAgentPool KubernetesCluster.Definition.IWithKeyVaultSecret.WithKeyVaultSecret(string secretName)
        {
            return this.WithKeyVaultSecret(secretName) as KubernetesCluster.Definition.IWithAgentPool;
        }

        /// <summary>
        /// Specifies the KeyVault secret and the version of it.
        /// </summary>
        /// <param name="secretName">The KeyVault reference to the secret which stores the password associated with the service principal.</param>
        /// <param name="secretVersion">The KeyVault secret version to be used.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithAgentPool KubernetesCluster.Definition.IWithKeyVaultSecret.WithKeyVaultSecret(string secretName, string secretVersion)
        {
            return this.WithKeyVaultSecret(secretName, secretVersion) as KubernetesCluster.Definition.IWithAgentPool;
        }

        /// <summary>
        /// Begins the definition to specify Linux ssh key.
        /// </summary>
        /// <param name="sshKeyData">The SSH key data.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithServicePrincipalClientId KubernetesCluster.Definition.IWithLinuxSshKey.WithSshKey(string sshKeyData)
        {
            return this.WithSshKey(sshKeyData) as KubernetesCluster.Definition.IWithServicePrincipalClientId;
        }

        /// <summary>
        /// Begins the definition of a agent pool profile to be attached to the Kubernetes cluster.
        /// </summary>
        /// <param name="name">The name for the agent pool profile.</param>
        /// <return>The stage representing configuration for the agent pool profile.</return>
        KubernetesClusterAgentPool.Definition.IBlank<KubernetesCluster.Definition.IWithCreate> KubernetesCluster.Definition.IWithAgentPool.DefineAgentPool(string name)
        {
            return this.DefineAgentPool(name) as KubernetesClusterAgentPool.Definition.IBlank<KubernetesCluster.Definition.IWithCreate>;
        }

        /// <summary>
        /// Begins the definition to specify Linux root username.
        /// </summary>
        /// <param name="rootUserName">The root username.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithLinuxSshKey KubernetesCluster.Definition.IWithLinuxRootUsername.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName) as KubernetesCluster.Definition.IWithLinuxSshKey;
        }

        /// <summary>
        /// Specifies the version for the Kubernetes cluster.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithDnsPrefix KubernetesCluster.Definition.IWithVersion.WithVersion(KubernetesVersion kubernetesVersion)
        {
            return this.WithVersion(kubernetesVersion) as KubernetesCluster.Definition.IWithDnsPrefix;
        }

        /// <summary>
        /// Uses the latest version for the Kubernetes cluster.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithLinuxRootUsername KubernetesCluster.Definition.IWithVersion.WithLatestVersion()
        {
            return this.WithLatestVersion() as KubernetesCluster.Definition.IWithLinuxRootUsername;
        }

        /// <summary>
        /// Properties for Kubernetes cluster service principal.
        /// </summary>
        /// <param name="clientId">The ID for the service principal.</param>
        /// <return>The next stage.</return>
        KubernetesCluster.Definition.IWithServicePrincipalProfile KubernetesCluster.Definition.IWithServicePrincipalClientId.WithServicePrincipalClientId(string clientId)
        {
            return this.WithServicePrincipalClientId(clientId) as KubernetesCluster.Definition.IWithServicePrincipalProfile;
        }

        /// <summary>
        /// Updates the agent pool virtual machine count.
        /// </summary>
        /// <param name="agentPoolName">The name of the agent pool to be updated.</param>
        /// <param name="agentCount">The number of agents (virtual machines) to host docker containers.</param>
        /// <return>The next stage of the update.</return>
        KubernetesCluster.Update.IUpdate KubernetesCluster.Update.IWithUpdateAgentPoolCount.WithAgentVMCount(string agentPoolName, int agentCount)
        {
            return this.WithAgentVMCount(agentPoolName, agentCount) as KubernetesCluster.Update.IUpdate;
        }

        /// <summary>
        /// Updates all the agent pools virtual machine count.
        /// </summary>
        /// <param name="agentCount">The number of agents (virtual machines) to host docker containers.</param>
        /// <return>The next stage of the update.</return>
        KubernetesCluster.Update.IUpdate KubernetesCluster.Update.IWithUpdateAgentPoolCount.WithAgentVMCount(int agentCount)
        {
            return this.WithAgentVMCount(agentCount) as KubernetesCluster.Update.IUpdate;
        }

        /// <summary>
        /// Properties for  service principal.
        /// </summary>
        /// <param name="secret">The secret password associated with the service principal.</param>
        /// <return>The next stage.</return>
        KubernetesCluster.Definition.IWithAgentPool KubernetesCluster.Definition.IWithServicePrincipalProfile.WithServicePrincipalSecret(string secret)
        {
            return this.WithServicePrincipalSecret(secret) as KubernetesCluster.Definition.IWithAgentPool;
        }

        /// <summary>
        /// Properties for cluster service principals.
        /// </summary>
        /// <param name="vaultId">The ID for the service principal.</param>
        /// <return>The next stage.</return>
        KubernetesCluster.Definition.IWithKeyVaultSecret KubernetesCluster.Definition.IWithServicePrincipalProfile.WithKeyVaultReference(string vaultId)
        {
            return this.WithKeyVaultReference(vaultId) as KubernetesCluster.Definition.IWithKeyVaultSecret;
        }

        /// <return>The Linux root username.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.LinuxRootUsername()
        {
            return this.LinuxRootUsername();
        }

        /// <return>The service principal secret.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.ServicePrincipalSecret()
        {
            return this.ServicePrincipalSecret();
        }

        /// <return>The key vault reference to the service principal secret.</return>
        Models.KeyVaultSecretRef Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.KeyVaultSecretReference()
        {
            return this.KeyVaultSecretReference() as Models.KeyVaultSecretRef;
        }

        /// <return>The Kubernetes version.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesVersion Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.Version()
        {
            return this.Version() as Microsoft.Azure.Management.ContainerService.Fluent.KubernetesVersion;
        }

        /// <return>The DNS prefix which was specified at creation time.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.DnsPrefix()
        {
            return this.DnsPrefix();
        }

        /// <return>The FQDN for the master pool.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.Fqdn()
        {
            return this.Fqdn();
        }

        /// <return>The agent pools in the Kubernetes cluster.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool> Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.AgentPools()
        {
            return this.AgentPools() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool>;
        }

        /// <return>The provisioning state of the Kubernetes cluster.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.ProvisioningState()
        {
            return this.ProvisioningState();
        }

        /// <return>The Kubernetes configuration file content with administrative privileges to the cluster.</return>
        byte[] Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.AdminKubeConfigContent()
        {
            return this.AdminKubeConfigContent();
        }

        /// <return>The Kubernetes configuration file content with user-level privileges to the cluster.</return>
        byte[] Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.UserKubeConfigContent()
        {
            return this.UserKubeConfigContent();
        }

        /// <return>The service principal client ID.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.ServicePrincipalClientId()
        {
            return this.ServicePrincipalClientId();
        }

        /// <return>The Linux SSH key.</return>
        string Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster.SshKey()
        {
            return this.SshKey();
        }
    }
}