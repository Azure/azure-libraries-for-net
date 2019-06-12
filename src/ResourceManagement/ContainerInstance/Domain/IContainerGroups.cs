// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using Microsoft.Azure.Management.ContainerInstance.Fluent;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point to the container instance management API.
    /// </summary>
    public interface IContainerGroups :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ContainerGroup.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<IContainerInstanceManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<IContainerGroupsOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<IContainerGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<IContainerGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<IContainerGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<IContainerGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<IContainerGroup>
    {

        /// <summary>
        /// Get the log content for the specified container instance within a container group.
        /// </summary>
        /// <param name="resourceGroupName">The Azure resource group name.</param>
        /// <param name="containerGroupName">The container group name.</param>
        /// <param name="containerName">The container instance name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>All available log lines.</return>
        string GetLogContent(string resourceGroupName, string containerGroupName, string containerName);

        /// <summary>
        /// Get the log content for the specified container instance within a container group.
        /// </summary>
        /// <param name="resourceGroupName">The Azure resource group name.</param>
        /// <param name="containerGroupName">The container group name.</param>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="tailLineCount">Only get the last log lines up to this.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The log lines from the end, up to the number specified.</return>
        string GetLogContent(string resourceGroupName, string containerGroupName, string containerName, int tailLineCount);

        /// <summary>
        /// Get the log content for the specified container instance within a container group.
        /// </summary>
        /// <param name="resourceGroupName">The Azure resource group name.</param>
        /// <param name="containerGroupName">The container group name.</param>
        /// <param name="containerName">The container instance name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        Task<string> GetLogContentAsync(string resourceGroupName, string containerGroupName, string containerName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get the log content for the specified container instance within a container group.
        /// </summary>
        /// <param name="resourceGroupName">The Azure resource group name.</param>
        /// <param name="containerGroupName">The container group name.</param>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="tailLineCount">Only get the last log lines up to this.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        Task<string> GetLogContentAsync(string resourceGroupName, string containerGroupName, string containerName, int tailLineCount, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists cached images for a subscription in a region.
        /// </summary>
        /// <param name="location">The identifier for the physical azure location.</param>
        /// <return>All cached images from the specified location.</return>
        System.Collections.Generic.IReadOnlyList<CachedImages> ListCachedImages(string location);

        /// <summary>
        /// Lists cached images for a subscription in a region.
        /// </summary>
        /// <param name="location">The identifier for the physical azure location.</param>
        /// <return>A representation of the future computation of this call.</return>
        Task<IReadOnlyList<CachedImages>> ListCachedImagesAsync(string location, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists the capabilities of a location.
        /// </summary>
        /// <param name="location">The identifier for the physical azure location.</param>
        /// <return>A list of all of the capabilities of the given location.</return>
        System.Collections.Generic.IReadOnlyList<Capabilities> ListCapabilities(string location);

        /// <summary>
        /// Lists the capabilities of a location.
        /// </summary>
        /// <param name="location">The identifier for the physical azure location.</param>
        /// <return>A representation of the future computation of this call.</return>
        Task<IReadOnlyList<Capabilities>> ListCapabilitiesAsync(string location, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all operations for Azure Container Instance service.
        /// </summary>
        /// <return>All operations for Azure Container Instance service.</return>
        System.Collections.Generic.IReadOnlyList<Operation> ListOperations();

        /// <summary>
        /// Lists all operations for Azure Container Instance service.
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        Task<System.Collections.Generic.IReadOnlyList<Operation>> ListOperationsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts all containers in a container group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group of the container group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        void Start(string resourceGroupName, string containerGroupName);

        /// <summary>
        /// Starts all containers in a container group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group of the container group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        /// <return>A representation of the future computation of this call.</return>
        Task StartAsync(string resourceGroupName, string containerGroupName, CancellationToken cancellationToken = default(CancellationToken));
    }
}