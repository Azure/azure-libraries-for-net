// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point to compute service SKUs.
    /// </summary>
    public interface IComputeSkus :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<IResourceSkusOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Compute.Fluent.IComputeManager>
    {

        /// <summary>
        /// Lists all the skus with the specified resource type in the given region.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <return>The skus list.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IComputeSku> ListbyRegionAndResourceType(Region region, ComputeResourceType resourceType);

        /// <summary>
        /// Lists all the skus with the specified resource type in the given region.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <return>An observable that emits skus.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>> ListbyRegionAndResourceTypeAsync(Region region, ComputeResourceType resourceType, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all the skus with the specified resource type.
        /// </summary>
        /// <param name="resourceType">The compute resource type.</param>
        /// <return>The skus list.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IComputeSku> ListByResourceType(ComputeResourceType resourceType);

        /// <summary>
        /// Lists all the skus with the specified resource type.
        /// </summary>
        /// <param name="resourceType">The compute resource type.</param>
        /// <return>An observable that emits skus.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>> ListByResourceTypeAsync(ComputeResourceType resourceType, CancellationToken cancellationToken = default(CancellationToken));
    }
}