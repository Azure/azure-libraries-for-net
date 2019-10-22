// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed partial class ComputeSkusImpl
    {
        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IComputeManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Compute.Fluent.IComputeManager>.Manager
        {
            get
            {
                return this.Manager();
            }
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IComputeSku> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>.List()
        {
            return this.List();
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IComputeSku>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken);
        }

        /// <summary>
        /// List all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="regionName">The name of an Azure region.</param>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IComputeSku> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>.ListByRegion(string regionName)
        {
            return this.ListByRegion(regionName);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="region">The selected Azure region.</param>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IComputeSku> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>.ListByRegion(Region region)
        {
            return this.ListByRegion(region);
        }

        /// <summary>
        /// Lists all the skus with the specified resource type in the given region.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <return>The skus list.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IComputeSku> Microsoft.Azure.Management.Compute.Fluent.IComputeSkus.ListbyRegionAndResourceType(Region region, ComputeResourceType resourceType)
        {
            return this.ListbyRegionAndResourceType(region, resourceType);
        }

        /// <summary>
        /// Lists all the skus with the specified resource type in the given region.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <return>An observable that emits skus.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>> Microsoft.Azure.Management.Compute.Fluent.IComputeSkus.ListbyRegionAndResourceTypeAsync(Region region, ComputeResourceType resourceType, CancellationToken cancellationToken)
        {
            return await this.ListbyRegionAndResourceTypeAsync(region, resourceType, cancellationToken);
        }

        /// <summary>
        /// List all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="regionName">The name of an Azure region.</param>
        /// <return>A representation of the deferred computation of this call, returning the requested resources.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>.ListByRegionAsync(string regionName, CancellationToken cancellationToken)
        {
            return await this.ListByRegionAsync(regionName, cancellationToken);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="region">The selected Azure region.</param>
        /// <return>A representation of the deferred computation of this call, returning the requested resources.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>.ListByRegionAsync(Region region, CancellationToken cancellationToken)
        {
            return await this.ListByRegionAsync(region, cancellationToken);
        }

        /// <summary>
        /// Lists all the skus with the specified resource type.
        /// </summary>
        /// <param name="resourceType">The compute resource type.</param>
        /// <return>The skus list.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IComputeSku> Microsoft.Azure.Management.Compute.Fluent.IComputeSkus.ListByResourceType(ComputeResourceType resourceType)
        {
            return this.ListByResourceType(resourceType);
        }

        /// <summary>
        /// Lists all the skus with the specified resource type.
        /// </summary>
        /// <param name="resourceType">The compute resource type.</param>
        /// <return>An observable that emits skus.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>> Microsoft.Azure.Management.Compute.Fluent.IComputeSkus.ListByResourceTypeAsync(ComputeResourceType resourceType, CancellationToken cancellationToken)
        {
            return await this.ListByResourceTypeAsync(resourceType, cancellationToken);
        }
    }
}