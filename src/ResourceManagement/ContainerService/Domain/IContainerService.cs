// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Update;
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// A client-side representation for a container service.
    /// </summary>
    public interface IContainerService  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceManager,Models.ContainerServiceInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerService.Fluent.IContainerService>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ContainerService.Update.IUpdate>,
        Microsoft.Azure.Management.ContainerService.Fluent.IOrchestratorServiceBase
    {

        /// <summary>
        /// Gets the agent pools map.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool> AgentPools { get; }

        /// <summary>
        /// Gets true if diagnostics are enabled.
        /// </summary>
        bool IsDiagnosticsEnabled { get; }

        /// <summary>
        /// Gets the Linux root username.
        /// </summary>
        string LinuxRootUsername { get; }

        /// <summary>
        /// Gets the master DNS prefix which was specified at creation time.
        /// </summary>
        string MasterDnsPrefix { get; }

        /// <summary>
        /// Gets the master FQDN.
        /// </summary>
        string MasterFqdn { get; }

        /// <summary>
        /// Gets the master node count.
        /// </summary>
        int MasterNodeCount { get; }

        /// <summary>
        /// Gets OS disk size in GB set for every machine in the master pool.
        /// </summary>
        int MasterOSDiskSizeInGB { get; }

        /// <summary>
        /// Gets the storage kind set for every machine in the master pool.
        /// </summary>
        ContainerServiceStorageProfileTypes MasterStorageProfile { get; }

        /// <summary>
        /// Gets the name of the subnet used by every machine in the master pool.
        /// </summary>
        string MasterSubnetName { get; }

        /// <summary>
        /// Gets the ID of the virtual network used by every machine in the master and agent pools.
        /// </summary>
        string NetworkId { get; }

        /// <summary>
        /// Gets the type of the orchestrator.
        /// </summary>
        Models.ContainerServiceOrchestratorTypes OrchestratorType { get; }

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
    }
}