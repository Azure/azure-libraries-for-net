// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.Msi.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class ContainerGroupImpl
    {
        /// <summary>
        /// Gets the container instances in this container group.
        /// </summary>
        IReadOnlyDictionary<string, Container> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.Containers
        {
            get
            {
                return this.Containers();
            }
        }

        /// <summary>
        /// Gets the DNS configuration for the container group.
        /// </summary>
        DnsConfiguration Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.DnsConfig
        {
            get
            {
                return this.DnsConfig();
            }
        }

        /// <summary>
        /// Gets the DNS prefix which was specified at creation time.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.DnsPrefix
        {
            get
            {
                return this.DnsPrefix();
            }
        }

        /// <summary>
        /// Gets the container group events.
        /// </summary>
        IReadOnlyCollection<EventModel> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.Events
        {
            get
            {
                return this.Events();
            }
        }

        /// <summary>
        /// Gets all the ports publicly exposed for this container group.
        /// </summary>
        IReadOnlyCollection<Port> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ExternalPorts
        {
            get
            {
                return this.ExternalPorts();
            }
        }

        /// <summary>
        /// Gets the TCP ports publicly exposed for this container group.
        /// </summary>
        int[] Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ExternalTcpPorts
        {
            get
            {
                return this.ExternalTcpPorts();
            }
        }

        /// <summary>
        /// Gets the UDP ports publicly exposed for this container group.
        /// </summary>
        int[] Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ExternalUdpPorts
        {
            get
            {
                return this.ExternalUdpPorts();
            }
        }

        /// <summary>
        /// Gets the FQDN for the container group.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.Fqdn
        {
            get
            {
                return this.Fqdn();
            }
        }

        /// <summary>
        /// Gets the Docker image registry servers by which the container group is created from.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ImageRegistryServers
        {
            get
            {
                return this.ImageRegistryServers();
            }
        }

        /// <summary>
        /// Gets the IP address.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.IPAddress
        {
            get
            {
                return this.IPAddress();
            }
        }

        /// <summary>
        /// Gets true if IP address is private.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.IsIPAddressPrivate
        {
            get
            {
                return this.IsIPAddressPrivate();
            }
        }

        /// <summary>
        /// Gets true if IP address is public.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.IsIPAddressPublic
        {
            get
            {
                return this.IsIPAddressPublic();
            }
        }

        /// <summary>
        /// Gets whether managed service identity is enabled for the container group.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.IsManagedServiceIdentityEnabled
        {
            get
            {
                return this.IsManagedServiceIdentityEnabled();
            }
        }

        /// <summary>
        /// Gets the log analytics information of the container group.
        /// </summary>
        LogAnalytics Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.LogAnalytics
        {
            get
            {
                return this.LogAnalytics();
            }
        }

        /// <summary>
        /// Gets whether managed service identity is system assigned, user assigned, both, or neither.
        /// </summary>
        ResourceIdentityType? Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ManagedServiceIdentityType
        {
            get
            {
                return this.ManagedServiceIdentityType();
            }
        }

        /// <summary>
        /// Gets the id of the network profile for the container group.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.NetworkProfileId
        {
            get
            {
                return this.NetworkProfileId();
            }
        }

        /// <summary>
        /// Gets the base level OS type required by the containers in the group.
        /// </summary>
        Fluent.OSTypeName Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.OSType
        {
            get
            {
                return this.OSType();
            }
        }

        /// <summary>
        /// Gets the provisioningState of the container group.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the container group restart policy.
        /// </summary>
        ContainerGroupRestartPolicy Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.RestartPolicy
        {
            get
            {
                return this.RestartPolicy();
            }
        }

        /// <summary>
        /// Gets the state of the container group; only valid in response.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.State
        {
            get
            {
                return this.State();
            }
        }

        /// <summary>
        /// Gets the principal id of the system assigned managed service identity. Null if managed
        /// service identity is not configured.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.SystemAssignedManagedServiceIdentityPrincipalId
        {
            get
            {
                return this.SystemAssignedManagedServiceIdentityPrincipalId();
            }
        }

        /// <summary>
        /// Gets the tenant id of the system assigned managed service identity. Null if managed
        /// service identity is not configured.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.SystemAssignedManagedServiceIdentityTenantId
        {
            get
            {
                return this.SystemAssignedManagedServiceIdentityTenantId();
            }
        }

        /// <summary>
        /// Gets the ids of the user assigned managed service identities. Returns an empty set if no
        /// MSIs are set.
        /// </summary>
        IReadOnlyCollection<string> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.UserAssignedManagedServiceIdentityIds
        {
            get
            {
                return this.UserAssignedManagedServiceIdentityIds();
            }
        }

        /// <summary>
        /// Gets the volumes for this container group.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Volume> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.Volumes
        {
            get
            {
                return this.Volumes();
            }
        }

        /// <summary>
        /// Begins the definition of a container instance.
        /// </summary>
        /// <param name="name">The name of the container instance.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IContainerInstanceDefinitionBlank<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithFirstContainerInstance.DefineContainerInstance(string name)
        {
            return this.DefineContainerInstance(name);
        }

        /// <summary>
        /// Begins the definition of a container instance.
        /// </summary>
        /// <param name="name">The name of the volume.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IContainerInstanceDefinitionBlank<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithNextContainerInstance.DefineContainerInstance(string name)
        {
            return this.DefineContainerInstance(name);
        }

        /// <summary>
        /// Begins the definition of a volume that can be shared by the container instances in the container group.
        /// The definition must be completed with a call to  VolumeDefinitionStages.WithVolumeAttach.attach().
        /// </summary>
        /// <param name="name">The name of the volume.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IVolumeDefinitionBlank<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume.DefineVolume(string name)
        {
            return this.DefineVolume(name);
        }

        /// <summary>
        /// Begins the definition of a volume that can be shared by the container instances in the container group.
        /// The definition must be completed with a call to  VolumeDefinitionStages.WithVolumeAttach.attach().
        /// </summary>
        /// <param name="name">The name of the volume.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IVolumeDefinitionBlank<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithVolume.DefineVolume(string name)
        {
            return this.DefineVolume(name);
        }

        /// <summary>
        /// Starts the exec command for a specific container instance.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="command">The command to be executed.</param>
        /// <param name="row">The row size of the terminal.</param>
        /// <param name="column">The column size of the terminal.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The log lines from the end, up to the number specified.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerExecResponse Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ExecuteCommand(string containerName, string command, int row, int column)
        {
            return this.ExecuteCommand(containerName, command, row, column);
        }

        /// <summary>
        /// Starts the exec command for a specific container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="command">The command to be executed.</param>
        /// <param name="row">The row size of the terminal.</param>
        /// <param name="column">The column size of the terminal.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerExecResponse> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ExecuteCommandAsync(string containerName, string command, int row, int column, CancellationToken cancellationToken)
        {
            return await this.ExecuteCommandAsync(containerName, command, row, column, cancellationToken);
        }

        /// <summary>
        /// Get the log content for the specified container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>All available log lines.</return>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.GetLogContent(string containerName)
        {
            return this.GetLogContent(containerName);
        }

        /// <summary>
        /// Get the log content for the specified container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="tailLineCount">Only get the last log lines up to this.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The log lines from the end, up to the number specified.</return>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.GetLogContent(string containerName, int tailLineCount)
        {
            return this.GetLogContent(containerName, tailLineCount);
        }

        /// <summary>
        /// Get the log content for the specified container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task<string> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.GetLogContentAsync(string containerName, CancellationToken cancellationToken)
        {
            return await this.GetLogContentAsync(containerName, cancellationToken);
        }

        /// <summary>
        /// Get the log content for the specified container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="tailLineCount">Only get the last log lines up to this.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task<string> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.GetLogContentAsync(string containerName, int tailLineCount, CancellationToken cancellationToken)
        {
            return await this.GetLogContentAsync(containerName, tailLineCount, cancellationToken);
        }

        /// <summary>
        /// Restarts all containers in a container group in place. If container image has updates, new image will be downloaded.
        /// </summary>
        void Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.Restart()
        {

            this.Restart();
        }

        /// <summary>
        /// Restarts all containers in a container group in place asynchronously. If container image has updates, new image will be downloaded.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.RestartAsync(CancellationToken cancellationToken)
        {

            await this.RestartAsync(cancellationToken);
        }

        /// <summary>
        /// Stops all containers in a container group. Compute resources will be de-allocated and billing will stop.
        /// </summary>
        void Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.Stop()
        {

            this.Stop();
        }

        /// <summary>
        /// Stops all containers in a container group asynchronously. Compute resources will be de-allocated and billing will stop.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.StopAsync(CancellationToken cancellationToken)
        {

            await this.StopAsync(cancellationToken);
        }

        /// <summary>
        /// Defines one container instance for the specified image with one CPU count and 1.5 GB memory, with TCP port 80 opened externally.
        /// </summary>
        /// <param name="imageName">The name of the container image.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithFirstContainerInstance.WithContainerInstance(string imageName)
        {
            return this.WithContainerInstance(imageName);
        }

        /// <summary>
        /// Defines one container instance for the specified image with one CPU count and 1.5 GB memory, with a custom TCP port opened externally.
        /// </summary>
        /// <param name="imageName">The name of the container image.</param>
        /// <param name="port">The external port to be opened.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithFirstContainerInstance.WithContainerInstance(string imageName, int port)
        {
            return this.WithContainerInstance(imageName, port);
        }

        /// <summary>
        /// Specifies the DNS configuration for the container group.
        /// </summary>
        /// <param name="dnsServerNames">The names of the DNS servers for the container group.</param>
        /// <param name="dnsSearchDomains">The DNS search domains for hostname lookup in the container group.</param>
        /// <param name="dnsOptions">The DNS options for the container group.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithDnsConfigBeta.WithDnsConfiguration(IList<string> dnsServerNames, string dnsSearchDomains, string dnsOptions)
        {
            return this.WithDnsConfiguration(dnsServerNames, dnsSearchDomains, dnsOptions);
        }

        /// <summary>
        /// Specifies the DNS prefix to be used to create the FQDN for the container group.
        /// </summary>
        /// <param name="dnsPrefix">The DNS prefix to be used to create the FQDN for the container group.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithDnsPrefix.WithDnsPrefix(string dnsPrefix)
        {
            return this.WithDnsPrefix(dnsPrefix);
        }

        /// <summary>
        /// Specifies the DNS servers for the container group.
        /// </summary>
        /// <param name="dnsServerNames">The names of the DNS servers.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithDnsConfigBeta.WithDnsServerNames(IList<string> dnsServerNames)
        {
            return this.WithDnsServerNames(dnsServerNames);
        }

        /// <summary>
        /// Specifies an empty directory volume that can be shared by the container instances in the container group.
        /// </summary>
        /// <param name="name">The name of the empty directory volume.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithFirstContainerInstance ContainerGroup.Definition.IWithPrivateImageRegistryOrVolumeBeta.WithEmptyDirectoryVolume(string name)
        {
            return this.WithEmptyDirectoryVolume(name);
        }

        /// <summary>
        /// Specifies an existing user assigned identity to be associate with the container group.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithUserAssignedManagedServiceIdentityBeta.WithExistingUserAssignedManagedServiceIdentity(IIdentity identity)
        {
            return this.WithExistingUserAssignedManagedServiceIdentity(identity);
        }

        /// <summary>
        /// Specifies this is a Linux container group.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPublicOrPrivateImageRegistry ContainerGroup.Definition.IWithOsType.WithLinux()
        {
            return this.WithLinux();
        }

        /// <summary>
        /// Specifies the log analytics workspace to use for the container group.
        /// </summary>
        /// <param name="workspaceId">The id of the previously-created log analytics workspace.</param>
        /// <param name="workspaceKey">The key of the previously-created log analytics workspace.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithLogAnalyticsBeta.WithLogAnalytics(string workspaceId, string workspaceKey)
        {
            return this.WithLogAnalytics(workspaceId, workspaceKey);
        }

        /// <summary>
        /// Specifies the log analytics workspace with optional add-ons for the container group.
        /// </summary>
        /// <param name="workspaceId">The id of the previously-created log analytics workspace.</param>
        /// <param name="workspaceKey">The key of the previously-created log analytics workspace.</param>
        /// <param name="logType">The log type to be used. Possible values include: 'ContainerInsights', 'ContainerInstanceLogs'.</param>
        /// <param name="metadata">The metadata for log analytics.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithLogAnalyticsBeta.WithLogAnalytics(string workspaceId, string workspaceKey, LogAnalyticsLogType logType, IDictionary<string, string> metadata)
        {
            return this.WithLogAnalytics(workspaceId, workspaceKey, logType, metadata);
        }

        /// <summary>
        /// Specifies the network profile information for a container group.
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription of the network profile.</param>
        /// <param name="resourceGroupName">The name of the resource group of the network profile.</param>
        /// <param name="networkProfileName">The name of the network profile.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IDnsConfigFork ContainerGroup.Definition.IWithNetworkProfileBeta.WithNetworkProfileId(string subscriptionId, string resourceGroupName, string networkProfileName)
        {
            return this.WithNetworkProfileId(subscriptionId, resourceGroupName, networkProfileName);
        }

        /// <summary>
        /// Specifies a new Azure file share name to be created.
        /// </summary>
        /// <param name="volumeName">The name of the volume.</param>
        /// <param name="shareName">The Azure file share name to be created.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithFirstContainerInstance ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume.WithNewAzureFileShareVolume(string volumeName, string shareName)
        {
            return this.WithNewAzureFileShareVolume(volumeName, shareName);
        }

        /// <summary>
        /// Specifies the definition of a not-yet-created user assigned identity to be associated with the virtual machine.
        /// </summary>
        /// <param name="creatableIdentity">A creatable identity definition.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithUserAssignedManagedServiceIdentityBeta.WithNewUserAssignedManagedServiceIdentity(ICreatable<Microsoft.Azure.Management.Msi.Fluent.IIdentity> creatableIdentity)
        {
            return this.WithNewUserAssignedManagedServiceIdentity(creatableIdentity);
        }

        /// <summary>
        /// Skips the definition of volumes to be shared by the container instances.
        /// An IllegalArgumentException will be thrown if a container instance attempts to define a volume mounting.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithFirstContainerInstance ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume.WithoutVolume()
        {
            return this.WithoutVolume();
        }

        /// <summary>
        /// Specifies the private container image registry server login for the container group.
        /// </summary>
        /// <param name="server">Docker image registry server, without protocol such as "http" and "https".</param>
        /// <param name="username">The username for the private registry.</param>
        /// <param name="password">The password for the private registry.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume ContainerGroup.Definition.IWithPrivateImageRegistry.WithPrivateImageRegistry(string server, string username, string password)
        {
            return this.WithPrivateImageRegistry(server, username, password);
        }

        /// <summary>
        /// Only public container image repository will be used to create the container instances in the container group.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume ContainerGroup.Definition.IWithPublicImageRegistryOnly.WithPublicImageRegistryOnly()
        {
            return this.WithPublicImageRegistryOnly();
        }

        /// <summary>
        /// Specifies the restart policy for all the container instances within the container group.
        /// </summary>
        /// <param name="restartPolicy">The restart policy for all the container instances within the container group.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithRestartPolicyBeta.WithRestartPolicy(ContainerGroupRestartPolicy restartPolicy)
        {
            return this.WithRestartPolicy(restartPolicy);
        }

        /// <summary>
        /// Specifies a system assigned managed service identity with access to a specific resource with a specified role.
        /// </summary>
        /// <param name="resourceId">The id of the resource you are setting up access to.</param>
        /// <param name="role">Access role to be assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate ContainerGroup.Definition.IWithSystemAssignedIdentityBasedAccessOrCreateBeta.WithSystemAssignedIdentityBasedAccessTo(string resourceId, BuiltInRole role)
        {
            return this.WithSystemAssignedIdentityBasedAccessTo(resourceId, role);
        }

        /// <summary>
        /// Specifies a system assigned managed service identity with access to a specific resource with a specified role from the id.
        /// </summary>
        /// <param name="resourceId">The id of the resource you are setting up access to.</param>
        /// <param name="roleDefinitionId">Id of the access role to be assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate ContainerGroup.Definition.IWithSystemAssignedIdentityBasedAccessOrCreateBeta.WithSystemAssignedIdentityBasedAccessTo(string resourceId, string roleDefinitionId)
        {
            return this.WithSystemAssignedIdentityBasedAccessTo(resourceId, roleDefinitionId);
        }

        /// <summary>
        /// Specifies a system assigned managed service identity with access to the current resource group and with the specified role.
        /// </summary>
        /// <param name="role">Access role to be assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate ContainerGroup.Definition.IWithSystemAssignedIdentityBasedAccessOrCreateBeta.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole role)
        {
            return this.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(role);
        }

        /// <summary>
        /// Specifies a system assigned managed service identity with access to the current resource group and with the specified role from the id.
        /// </summary>
        /// <param name="roleDefinitionId">Id of the access role to be assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate ContainerGroup.Definition.IWithSystemAssignedIdentityBasedAccessOrCreateBeta.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            return this.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(roleDefinitionId);
        }

        /// <summary>
        /// Specifies a system assigned managed service identity for the container group.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate ContainerGroup.Definition.IWithSystemAssignedManagedServiceIdentityBeta.WithSystemAssignedManagedServiceIdentity()
        {
            return this.WithSystemAssignedManagedServiceIdentity();
        }

        /// <summary>
        /// Specifies this is a Windows container group.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPublicOrPrivateImageRegistry ContainerGroup.Definition.IWithOsType.WithWindows()
        {
            return this.WithWindows();
        }
    }
}