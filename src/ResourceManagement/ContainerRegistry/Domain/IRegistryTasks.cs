// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface to define the RegistryTasks collection.
    /// </summary>
    public interface IRegistryTasks  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<ITasksOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<RegistryTask.Definition.IBlank>
    {

        /// <summary>
        /// Deletes a task in a registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group of the parent registry.</param>
        /// <param name="registryName">The name of the parent registry.</param>
        /// <param name="taskName">The name of the task.</param>
        void DeleteByRegistry(string resourceGroupName, string registryName, string taskName);

        /// <summary>
        /// Deletes a task in a registry asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group of the parent registry.</param>
        /// <param name="registryName">The name of the parent registry.</param>
        /// <param name="taskName">The name of the task.</param>
        /// <return>The handle to the request.</return>
        Task DeleteByRegistryAsync(string resourceGroupName, string registryName, string taskName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a task in a registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group of the parent registry.</param>
        /// <param name="registryName">The name of the parent registry.</param>
        /// <param name="taskName">The name of the task.</param>
        /// <param name="includeSecrets">Whether to include secrets or not.</param>
        /// <return>The task.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask GetByRegistry(string resourceGroupName, string registryName, string taskName, bool includeSecrets);

        /// <summary>
        /// Gets a task in a registry asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group of the parent registry.</param>
        /// <param name="registryName">The name of the parent registry.</param>
        /// <param name="taskName">The name of the task.</param>
        /// <param name="includeSecrets">Whether to include secrets or not.</param>
        /// <return>The task.</return>
        Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask> GetByRegistryAsync(string resourceGroupName, string registryName, string taskName, bool includeSecrets, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists the tasks in a registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group of the parent registry.</param>
        /// <param name="registryName">The name of the parent registry.</param>
        /// <return>The tasks with parent registry registry.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask> ListByRegistry(string resourceGroupName, string registryName);

        /// <summary>
        /// Lists the tasks in a registry asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group of the parent registry.</param>
        /// <param name="registryName">The name of the parent registry.</param>
        /// <return>The tasks with parent registry registry.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask>> ListByRegistryAsync(string resourceGroupName, string registryName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));
    }
}