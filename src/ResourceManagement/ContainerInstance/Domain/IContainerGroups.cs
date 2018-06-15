// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point to the container instance management API.
    /// </summary>
    public interface IContainerGroups  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ContainerGroup.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerInstanceManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroupsOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup>
    {
        /// <summary>
        /// Lists all operations for Azure Container Instance service.
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        Task<System.Collections.Generic.IReadOnlyCollection<Models.Operation>> ListOperationsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all operations for Azure Container Instance service.
        /// </summary>
        /// <return>All operations for Azure Container Instance service.</return>
        System.Collections.Generic.IReadOnlyCollection<Models.Operation> ListOperations();

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
    }
}