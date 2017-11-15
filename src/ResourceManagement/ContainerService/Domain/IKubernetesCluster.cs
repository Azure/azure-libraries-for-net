// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// A client-side representation for a managed Kubernetes cluster.
    /// </summary>
    public interface IKubernetesCluster  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceManager,Models.ManagedClusterInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<KubernetesCluster.Update.IUpdate>,
        Microsoft.Azure.Management.ContainerService.Fluent.IOrchestratorServiceBase
    {
        /// <return>The Linux root username.</return>
        string LinuxRootUsername();

        /// <return>The Kubernetes configuration file content with user-level privileges to the cluster.</return>
        byte[] UserKubeConfigContent();

        /// <return>The FQDN for the master pool.</return>
        string Fqdn();

        /// <return>The Linux SSH key.</return>
        string SshKey();

        /// <return>The key vault reference to the service principal secret.</return>
        Models.KeyVaultSecretRef KeyVaultSecretReference();

        /// <return>The DNS prefix which was specified at creation time.</return>
        string DnsPrefix();

        /// <return>The provisioning state of the Kubernetes cluster.</return>
        string ProvisioningState();

        /// <return>The service principal client ID.</return>
        string ServicePrincipalClientId();

        /// <return>The service principal secret.</return>
        string ServicePrincipalSecret();

        /// <return>The agent pools in the Kubernetes cluster.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool> AgentPools();

        /// <return>The Kubernetes version.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.KubernetesVersion Version();

        /// <return>The Kubernetes configuration file content with administrative privileges to the cluster.</return>
        byte[] AdminKubeConfigContent();
    }
}