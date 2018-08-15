// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Locks.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition;
    using Microsoft.Azure.Management.Locks.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    internal partial class ManagementLocksImpl 
    {
        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        async Task<IPagedCollection<IManagementLock>> ISupportsListingByResourceGroup<IManagementLock>.ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListByResourceGroupAsync(resourceGroupName, loadAllPages, cancellationToken);
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Locks.Fluent.IManagementLock> ISupportsListingByResourceGroup<IManagementLock>.ListByResourceGroup(string resourceGroupName)
        {
            return this.ListByResourceGroup(resourceGroupName);
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.Locks.Fluent.IAuthorizationManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Locks.Fluent.IAuthorizationManager>.Manager
        {
            get
            {
                return this.Manager();
            }
        }

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="name">The name of the resource.</param>
        void Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup.DeleteByResourceGroup(string resourceGroupName, string name)
        {
 
            this.DeleteByResourceGroup(resourceGroupName, name);
        }

        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="name">The name of the resource.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup.DeleteByResourceGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteByResourceGroupAsync(resourceGroupName, name, cancellationToken);
        }

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
        ManagementLock.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ManagementLock.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById.DeleteByIdAsync(string id, CancellationToken cancellationToken)
        {
 
            await this.DeleteByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IManagementLock>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Locks.Fluent.IManagementLock>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Locks.Fluent.IManagementLock> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Locks.Fluent.IManagementLock>.List()
        {
            return this.List();
        }

        /// <summary>
        /// Lists management locks associated with the specified resource, its resource group, and any level below the resource.
        /// </summary>
        /// <param name="resourceId">The resource Id of the resource.</param>
        /// <return>Management locks.</return>
        async Task<IPagedCollection<IManagementLock>> IManagementLocks.ListForResourceAsync(string resourceId, CancellationToken cancellationToken)
        {
            return await this.ListForResourceAsync(resourceId, cancellationToken);
        }

        /// <summary>
        /// Lists management locks associated with the specified resource, its resource group and any resources below the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of the resource.</param>
        /// <return>Management locks.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Locks.Fluent.IManagementLock> Microsoft.Azure.Management.Locks.Fluent.IManagementLocks.ListForResource(string resourceId)
        {
            return this.ListForResource(resourceId);
        }

        /// <summary>
        /// Deletes the specified resources from Azure.
        /// </summary>
        /// <param name="ids">Resource IDs of the resources to be deleted.</param>
        void ISupportsBatchDeletion.DeleteByIds(IList<string> ids)
        {
            this.DeleteByIds(ids);
        }

        /// <summary>
        /// Deletes the specified resources from Azure.
        /// </summary>
        /// <param name="ids">Resource IDs of the resources to be deleted.</param>
        void Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion.DeleteByIds(params string[] ids)
        {
 
            this.DeleteByIds(ids);
        }

        /// <summary>
        /// Deletes the specified resources from Azure asynchronously and in parallel.
        /// </summary>
        /// <param name="ids">Resource IDs of the resources to be deleted.</param>
        /// <return>A representation of the deferred computation of this call returning the resource ID of each successfully deleted resource.</return>
        async Task<IEnumerable<string>> ISupportsBatchDeletion.DeleteByIdsAsync(IList<string> ids, CancellationToken cancellationToken)
        {
            return await this.DeleteByIdsAsync(ids, cancellationToken);
        }

        /// <summary>
        /// Deletes the specified resources from Azure asynchronously and in parallel.
        /// </summary>
        /// <param name="ids">Resource IDs of the resources to be deleted.</param>
        /// <return>A representation of the deferred computation of this call returning the resource ID of each successfully deleted resource.</return>
        async Task<System.Collections.Generic.IEnumerable<string>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion.DeleteByIdsAsync(string[] ids, CancellationToken cancellationToken)
        {
            return await this.DeleteByIdsAsync(ids, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name and the name of its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the resource is in.</param>
        /// <param name="name">The name of the resource. (Note, this is not the ID).</param>
        /// <return>Observable to an immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Locks.Fluent.IManagementLock> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Locks.Fluent.IManagementLock>.GetByResourceGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken)
        {
            return await this.GetByResourceGroupAsync(resourceGroupName, name, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name and the name of its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the resource is in.</param>
        /// <param name="name">The name of the resource. (Note, this is not the ID).</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Locks.Fluent.IManagementLock Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Locks.Fluent.IManagementLock>.GetByResourceGroup(string resourceGroupName, string name)
        {
            return this.GetByResourceGroup(resourceGroupName, name);
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Locks.Fluent.IManagementLock> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Locks.Fluent.IManagementLock>.GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Locks.Fluent.IManagementLock Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Locks.Fluent.IManagementLock>.GetById(string id)
        {
            return this.GetById(id);
        }
    }
}