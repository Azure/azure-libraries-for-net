// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Locks.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to management lock management.
    /// </summary>
    public interface IManagementLocks  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Locks.Fluent.IManagementLock>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ManagementLock.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Locks.Fluent.IManagementLock>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Locks.Fluent.IManagementLock>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Locks.Fluent.IManagementLock>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Locks.Fluent.IManagementLock>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Locks.Fluent.IAuthorizationManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Locks.Fluent.IManagementLocksOperations>
    {
        /// <summary>
        /// Lists management locks associated with the specified resource, its resource group and any resources below the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of the resource.</param>
        /// <return>Management locks.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Locks.Fluent.IManagementLock> ListForResource(string resourceId);

        /// <summary>
        /// Lists management locks associated with the specified resource, its resource group, and any level below the resource.
        /// </summary>
        /// <param name="resourceId">The resource Id of the resource.</param>
        /// <return>Management locks.</return>
        Task<IPagedCollection<IManagementLock>> ListForResourceAsync(string resourceId, CancellationToken cancellationToken = default(CancellationToken));
    }
}