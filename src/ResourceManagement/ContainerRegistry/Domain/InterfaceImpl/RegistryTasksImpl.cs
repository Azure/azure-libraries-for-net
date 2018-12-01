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

    internal partial class RegistryTasksImpl 
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        RegistryTask.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<RegistryTask.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Deletes a task in a registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group of the parent registry.</param>
        /// <param name="registryName">The name of the parent registry.</param>
        /// <param name="taskName">The name of the task.</param>
        void Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTasks.DeleteByRegistry(string resourceGroupName, string registryName, string taskName)
        {
 
            this.DeleteByRegistry(resourceGroupName, registryName, taskName);
        }

        /// <summary>
        /// Deletes a task in a registry asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group of the parent registry.</param>
        /// <param name="registryName">The name of the parent registry.</param>
        /// <param name="taskName">The name of the task.</param>
        /// <return>The handle to the request.</return>
        async Task Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTasks.DeleteByRegistryAsync(string resourceGroupName, string registryName, string taskName, CancellationToken cancellationToken)
        {
 
            await this.DeleteByRegistryAsync(resourceGroupName, registryName, taskName, cancellationToken);
        }

        /// <summary>
        /// Gets a task in a registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group of the parent registry.</param>
        /// <param name="registryName">The name of the parent registry.</param>
        /// <param name="taskName">The name of the task.</param>
        /// <param name="includeSecrets">Whether to include secrets or not.</param>
        /// <return>The task.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTasks.GetByRegistry(string resourceGroupName, string registryName, string taskName, bool includeSecrets)
        {
            return this.GetByRegistry(resourceGroupName, registryName, taskName, includeSecrets);
        }

        /// <summary>
        /// Gets a task in a registry asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group of the parent registry.</param>
        /// <param name="registryName">The name of the parent registry.</param>
        /// <param name="taskName">The name of the task.</param>
        /// <param name="includeSecrets">Whether to include secrets or not.</param>
        /// <return>The task.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTasks.GetByRegistryAsync(string resourceGroupName, string registryName, string taskName, bool includeSecrets, CancellationToken cancellationToken)
        {
            return await this.GetByRegistryAsync(resourceGroupName, registryName, taskName, includeSecrets, cancellationToken);
        }

        /// <summary>
        /// Lists the tasks in a registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group of the parent registry.</param>
        /// <param name="registryName">The name of the parent registry.</param>
        /// <return>The tasks with parent registry registry.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTasks.ListByRegistry(string resourceGroupName, string registryName)
        {
            return this.ListByRegistry(resourceGroupName, registryName);
        }

        /// <summary>
        /// Lists the tasks in a registry asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group of the parent registry.</param>
        /// <param name="registryName">The name of the parent registry.</param>
        /// <return>The tasks with parent registry registry.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask>> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTasks.ListByRegistryAsync(string resourceGroupName, string registryName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListByRegistryAsync(resourceGroupName, registryName, loadAllPages, cancellationToken);
        }
    }
}