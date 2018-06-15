// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition
{
    using Microsoft.Azure.Management.ContainerService.Fluent;
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;

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
    /// The stage of the Kubernetes cluster definition allowing to specify an agent pool profile.
    /// </summary>
    public interface IWithAgentPool 
    {
        /// <summary>
        /// Begins the definition of a agent pool profile to be attached to the Kubernetes cluster.
        /// </summary>
        /// <param name="name">The name for the agent pool profile.</param>
        /// <return>The stage representing configuration for the agent pool profile.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition.IBlank<Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithCreate> DefineAgentPool(string name);
    }

    /// <summary>
    /// The first stage of a container service definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithGroup>
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
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows for any other optional settings to
    /// be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster>,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithDnsPrefix,
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

        /// <summary>
        /// Properties for cluster service principals.
        /// </summary>
        /// <param name="vaultId">The ID for the service principal.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithKeyVaultSecret WithKeyVaultReference(string vaultId);
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
    /// Interface for all the definitions related to a Kubernetes cluster.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IBlank,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithGroup,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithVersion,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithLinuxRootUsername,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithLinuxSshKey,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithServicePrincipalClientId,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithServicePrincipalProfile,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithKeyVaultSecret,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithDnsPrefix,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAgentPool,
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the Kubernetes cluster definition allowing to specify the KeyVault secret name and version.
    /// </summary>
    public interface IWithKeyVaultSecret 
    {
        /// <summary>
        /// Specifies the KeyVault secret.
        /// </summary>
        /// <param name="secretName">The KeyVault reference to the secret which stores the password associated with the service principal.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAgentPool WithKeyVaultSecret(string secretName);

        /// <summary>
        /// Specifies the KeyVault secret and the version of it.
        /// </summary>
        /// <param name="secretName">The KeyVault reference to the secret which stores the password associated with the service principal.</param>
        /// <param name="secretVersion">The KeyVault secret version to be used.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithAgentPool WithKeyVaultSecret(string secretName, string secretVersion);
    }

    /// <summary>
    /// The stage of the Kubernetes cluster definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition.IWithVersion>
    {
    }
}