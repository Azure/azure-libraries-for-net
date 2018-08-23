// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update;
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
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

        /// <summary>
        /// Gets the cluster's add-on's profiles.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.ContainerService.Fluent.Models.ManagedClusterAddonProfile> AddonProfiles { get; }

        /// <summary>
        /// Gets the Kubernetes configuration file content with administrative privileges to the cluster.
        /// </summary>
        byte[] AdminKubeConfigContent { get; }

        /// <summary>
        /// Gets the agent pools in the Kubernetes cluster.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool> AgentPools { get; }

        /// <summary>
        /// Gets the DNS prefix which was specified at creation time.
        /// </summary>
        string DnsPrefix { get; }

        /// <summary>
        /// Gets true if Kubernetes Role-Based Access Control is enabled.
        /// </summary>
        bool EnableRBAC { get; }

        /// <summary>
        /// Gets the FQDN for the master pool.
        /// </summary>
        string Fqdn { get; }

        /// <summary>
        /// Gets the Linux root username.
        /// </summary>
        string LinuxRootUsername { get; }

        /// <summary>
        /// Gets the Linux SSH key.
        /// </summary>
        Models.ContainerServiceNetworkProfile NetworkProfile { get; }

        /// <summary>
        /// Gets the name of the resource group containing agent pool nodes.
        /// </summary>
        string NodeResourceGroup { get; }

        /// <summary>
        /// Gets the provisioning state of the Kubernetes cluster.
        /// </summary>
        string ProvisioningState { get; }

        /// <summary>
        /// Gets the service principal client ID.
        /// </summary>
        string ServicePrincipalClientId { get; }

        /// <summary>
        /// Gets the service principal secret.
        /// </summary>
        string ServicePrincipalSecret { get; }

        /// <summary>
        /// Gets the Linux SSH key.
        /// </summary>
        string SshKey { get; }

        /// <summary>
        /// Gets the Kubernetes configuration file content with user-level privileges to the cluster.
        /// </summary>
        byte[] UserKubeConfigContent { get; }

        /// <summary>
        /// Gets the Kubernetes version.
        /// </summary>
        Microsoft.Azure.Management.ContainerService.Fluent.Models.KubernetesVersion Version { get; }
    }
}