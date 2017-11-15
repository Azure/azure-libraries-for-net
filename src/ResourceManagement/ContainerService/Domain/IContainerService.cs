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
        /// <return>The type of the orchestrator.</return>
        Models.ContainerServiceOrchestratorTypes OrchestratorType();

        /// <return>The master node count.</return>
        int MasterNodeCount();

        /// <return>OS disk size in GB set for every machine in the master pool.</return>
        int MasterOSDiskSizeInGB();

        /// <return>The storage kind set for every machine in the master pool.</return>
        StorageProfileTypes MasterStorageProfile();

        /// <return>True if diagnostics are enabled.</return>
        bool IsDiagnosticsEnabled();

        /// <return>The master DNS prefix which was specified at creation time.</return>
        string MasterDnsPrefix();

        /// <return>The name of the subnet used by every machine in the master pool.</return>
        string MasterSubnetName();

        /// <return>The Linux root username.</return>
        string LinuxRootUsername();

        /// <return>The Linux SSH key.</return>
        string SshKey();

        /// <return>The master FQDN.</return>
        string MasterFqdn();

        /// <return>The ID of the virtual network used by every machine in the master and agent pools.</return>
        string NetworkId();

        /// <return>The service principal client ID.</return>
        string ServicePrincipalClientId();

        /// <return>The agent pools map.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool> AgentPools();

        /// <return>The service principal secret.</return>
        string ServicePrincipalSecret();
    }
}