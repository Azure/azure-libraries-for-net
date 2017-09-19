// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure Container Group.
    /// </summary>
    public interface IContainerGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerInstanceManager,Models.ContainerGroupInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup>
    {
        /// <summary>
        /// Gets the Docker image registry servers by which the container group is created from.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> ImageRegistryServers { get; }

        /// <summary>
        /// Gets all the ports publicly exposed for this container group.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Models.Port> ExternalPorts { get; }

        /// <summary>
        /// Gets the volumes for this container group.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.Volume> Volumes { get; }

        /// <summary>
        /// Gets the IP address.
        /// </summary>
        string IPAddress { get; }

        /// <summary>
        /// Gets the UDP ports publicly exposed for this container group.
        /// </summary>
        int[] ExternalUdpPorts { get; }

        /// <summary>
        /// Gets the provisioningState of the container group.
        /// </summary>
        string ProvisioningState { get; }

        /// <summary>
        /// Gets the TCP ports publicly exposed for this container group.
        /// </summary>
        int[] ExternalTcpPorts { get; }

        /// <summary>
        /// Gets `always` Always restart.
        /// </summary>
        bool isAlwaysRestart { get; }

        /// <summary>
        /// Gets true if IP address is public.
        /// </summary>
        bool IsIPAddressPublic { get; }

        /// <summary>
        /// Gets the base level OS type required by the containers in the group.
        /// </summary>
        OSTypeName OSType { get; }

        /// <summary>
        /// Gets the container instances in this container group.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.Container> Containers { get; }

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
        /// Gets the state of the container group; only valid in response.
        /// </summary>
        string State { get; }

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
    }
}