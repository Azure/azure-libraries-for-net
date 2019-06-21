// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An immutable client-side representation of an Azure Container Group.
    /// </summary>
    public interface IContainerGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<IContainerInstanceManager, ContainerGroupInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ContainerGroup.Update.IUpdate>
    {

        /// <summary>
        /// Gets the container instances in this container group.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Container> Containers { get; }

        /// <summary>
        /// Gets the DNS configuration for the container group.
        /// </summary>
        DnsConfiguration DnsConfig { get; }

        /// <summary>
        /// Gets the DNS prefix which was specified at creation time.
        /// </summary>
        string DnsPrefix { get; }

        /// <summary>
        /// Gets the container group events.
        /// </summary>
        IReadOnlyCollection<EventModel> Events { get; }

        /// <summary>
        /// Gets all the ports publicly exposed for this container group.
        /// </summary>
        IReadOnlyCollection<Port> ExternalPorts { get; }

        /// <summary>
        /// Gets the TCP ports publicly exposed for this container group.
        /// </summary>
        int[] ExternalTcpPorts { get; }

        /// <summary>
        /// Gets the UDP ports publicly exposed for this container group.
        /// </summary>
        int[] ExternalUdpPorts { get; }

        /// <summary>
        /// Gets the FQDN for the container group.
        /// </summary>
        string Fqdn { get; }

        /// <summary>
        /// Gets the Docker image registry servers by which the container group is created from.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> ImageRegistryServers { get; }

        /// <summary>
        /// Gets the IP address.
        /// </summary>
        string IPAddress { get; }

        /// <summary>
        /// Gets true if IP address is private.
        /// </summary>
        bool IsIPAddressPrivate { get; }

        /// <summary>
        /// Gets true if IP address is public.
        /// </summary>
        bool IsIPAddressPublic { get; }

        /// <summary>
        /// Gets whether managed service identity is enabled for the container group.
        /// </summary>
        bool IsManagedServiceIdentityEnabled { get; }

        /// <summary>
        /// Gets the log analytics information of the container group.
        /// </summary>
        LogAnalytics LogAnalytics { get; }

        /// <summary>
        /// Gets whether managed service identity is system assigned, user assigned, both, or neither.
        /// </summary>
        ResourceIdentityType? ManagedServiceIdentityType { get; }

        /// <summary>
        /// Gets the id of the network profile for the container group.
        /// </summary>
        string NetworkProfileId { get; }

        /// <summary>
        /// Gets the base level OS type required by the containers in the group.
        /// </summary>
        Fluent.OSTypeName OSType { get; }

        /// <summary>
        /// Gets the provisioningState of the container group.
        /// </summary>
        string ProvisioningState { get; }

        /// <summary>
        /// Gets the container group restart policy.
        /// </summary>
        ContainerGroupRestartPolicy RestartPolicy { get; }

        /// <summary>
        /// Gets the state of the container group; only valid in response.
        /// </summary>
        string State { get; }

        /// <summary>
        /// Gets the principal id of the system assigned managed service identity. Null if managed
        /// service identity is not configured.
        /// </summary>
        string SystemAssignedManagedServiceIdentityPrincipalId { get; }

        /// <summary>
        /// Gets the tenant id of the system assigned managed service identity. Null if managed
        /// service identity is not configured.
        /// </summary>
        string SystemAssignedManagedServiceIdentityTenantId { get; }

        /// <summary>
        /// Gets the ids of the user assigned managed service identities. Returns an empty set if no
        /// MSIs are set.
        /// </summary>
        IReadOnlyCollection<string> UserAssignedManagedServiceIdentityIds { get; }

        /// <summary>
        /// Gets the volumes for this container group.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Volume> Volumes { get; }

        /// <summary>
        /// Starts the exec command for a specific container instance.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="command">The command to be executed.</param>
        /// <param name="row">The row size of the terminal.</param>
        /// <param name="column">The column size of the terminal.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The log lines from the end, up to the number specified.</return>
        IContainerExecResponse ExecuteCommand(string containerName, string command, int row, int column);

        /// <summary>
        /// Starts the exec command for a specific container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="command">The command to be executed.</param>
        /// <param name="row">The row size of the terminal.</param>
        /// <param name="column">The column size of the terminal.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        Task<IContainerExecResponse> ExecuteCommandAsync(string containerName, string command, int row, int column, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get the log content for the specified container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>All available log lines.</return>
        string GetLogContent(string containerName);

        /// <summary>
        /// Get the log content for the specified container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="tailLineCount">Only get the last log lines up to this.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The log lines from the end, up to the number specified.</return>
        string GetLogContent(string containerName, int tailLineCount);

        /// <summary>
        /// Get the log content for the specified container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        Task<string> GetLogContentAsync(string containerName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get the log content for the specified container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="tailLineCount">Only get the last log lines up to this.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        Task<string> GetLogContentAsync(string containerName, int tailLineCount, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Restarts all containers in a container group in place. If container image has updates, new image will be downloaded.
        /// </summary>
        void Restart();

        /// <summary>
        /// Restarts all containers in a container group in place asynchronously. If container image has updates, new image will be downloaded.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Stops all containers in a container group. Compute resources will be de-allocated and billing will stop.
        /// </summary>
        void Stop();

        /// <summary>
        /// Stops all containers in a container group asynchronously. Compute resources will be de-allocated and billing will stop.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}