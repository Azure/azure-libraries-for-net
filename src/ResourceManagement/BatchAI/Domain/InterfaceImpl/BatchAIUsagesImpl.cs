// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class BatchAIUsagesImpl 
    {
        /// <summary>
        /// Lists all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="region">The selected Azure region.</param>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIUsage> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIUsage>.ListByRegion(Region region)
        {
            return this.ListByRegion(region);
        }

        /// <summary>
        /// List all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="regionName">The name of an Azure region.</param>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIUsage> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIUsage>.ListByRegion(string regionName)
        {
            return this.ListByRegion(regionName);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="region">The selected Azure region.</param>
        /// <return>A representation of the deferred computation of this call, returning the requested resources.</return>
        async Task<IPagedCollection<IBatchAIUsage>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<IBatchAIUsage>.ListByRegionAsync(Region region, CancellationToken cancellationToken)
        {
            return await this.ListByRegionAsync(region, cancellationToken);
        }

        /// <summary>
        /// List all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="regionName">The name of an Azure region.</param>
        /// <return>A representation of the deferred computation of this call, returning the requested resources.</return>
        async Task<IPagedCollection<IBatchAIUsage>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIUsage>.ListByRegionAsync(string regionName, CancellationToken cancellationToken)
        {
            return await this.ListByRegionAsync(regionName, cancellationToken);
        }
    }
}