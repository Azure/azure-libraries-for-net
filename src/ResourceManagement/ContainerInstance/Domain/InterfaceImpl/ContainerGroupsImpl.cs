// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Storage.Fluent;

    internal partial class ContainerGroupsImpl
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
        ContainerGroup.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ContainerGroup.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup>.ListByResourceGroup(string resourceGroupName)
        {
            return this.ListByResourceGroup(resourceGroupName);
        }

        /// <summary>
        /// Lists all operations for Azure Container Instance service.
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Models.Operation>> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroups.ListOperationsAsync(CancellationToken cancellationToken)
        {
            return await this.ListOperationsAsync(cancellationToken);
        }

        /// <summary>
        /// Get the log content for the specified container instance within a container group.
        /// </summary>
        /// <param name="resourceGroupName">The Azure resource group name.</param>
        /// <param name="containerGroupName">The container group name.</param>
        /// <param name="containerName">The container instance name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>All available log lines.</return>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroups.GetLogContent(string resourceGroupName, string containerGroupName, string containerName)
        {
            return this.GetLogContent(resourceGroupName, containerGroupName, containerName);
        }

        /// <summary>
        /// Get the log content for the specified container instance within a container group.
        /// </summary>
        /// <param name="resourceGroupName">The Azure resource group name.</param>
        /// <param name="containerGroupName">The container group name.</param>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="tailLineCount">Only get the last log lines up to this.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The log lines from the end, up to the number specified.</return>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroups.GetLogContent(string resourceGroupName, string containerGroupName, string containerName, int tailLineCount)
        {
            return this.GetLogContent(resourceGroupName, containerGroupName, containerName, tailLineCount);
        }

        /// <summary>
        /// Lists all operations for Azure Container Instance service.
        /// </summary>
        /// <return>All operations for Azure Container Instance service.</return>
        System.Collections.Generic.IReadOnlyList<Models.Operation> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroups.ListOperations()
        {
            return this.ListOperations();
        }

        /// <summary>
        /// Get the log content for the specified container instance within a container group.
        /// </summary>
        /// <param name="resourceGroupName">The Azure resource group name.</param>
        /// <param name="containerGroupName">The container group name.</param>
        /// <param name="containerName">The container instance name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task<string> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroups.GetLogContentAsync(string resourceGroupName, string containerGroupName, string containerName, CancellationToken cancellationToken)
        {
            return await this.GetLogContentAsync(resourceGroupName, containerGroupName, containerName, cancellationToken);
        }

        /// <summary>
        /// Get the log content for the specified container instance within a container group.
        /// </summary>
        /// <param name="resourceGroupName">The Azure resource group name.</param>
        /// <param name="containerGroupName">The container group name.</param>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="tailLineCount">Only get the last log lines up to this.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task<string> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroups.GetLogContentAsync(string resourceGroupName, string containerGroupName, string containerName, int tailLineCount, CancellationToken cancellationToken)
        {
            return await this.GetLogContentAsync(resourceGroupName, containerGroupName, containerName, tailLineCount, cancellationToken);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup>.List()
        {
            return this.List();
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IContainerGroup>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken);
        }

        IReadOnlyList<CachedImages> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroups.ListCachedImages(string location)
        {
            return this.ListCachedImages(location);
        }

        async Task<IReadOnlyList<CachedImages>> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroups.ListCachedImagesAsync(string location, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListCachedImagesAsync(location, cancellationToken);
        }

        IReadOnlyList<Capabilities> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroups.ListCapabilities(string location)
        {
            return this.ListCapabilities(location);
        }

        async Task<IReadOnlyList<Capabilities>> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroups.ListCapabilitiesAsync(string location, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListCapabilitiesAsync(location, cancellationToken);
        }
    }
}