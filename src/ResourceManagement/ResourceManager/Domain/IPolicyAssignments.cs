// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IPolicyAssignments :
        ISupportsListing<IPolicyAssignment>,
        ISupportsListingByResourceGroup<IPolicyAssignment>,
        ISupportsGettingById<IPolicyAssignment>,
        ISupportsCreating<PolicyAssignment.Definition.IBlank>,
        ISupportsDeletingById
    {
        /// <summary>
        /// List policy assignments of the resource.
        /// </summary>
        /// <param name="resourceId">The resource id value.</param>
        /// <returns>The list of policy assignments.</returns>
        IEnumerable<IPolicyAssignment> ListByResource(string resourceId);

        /// <summary>
        /// List policy assignments of the resource.
        /// </summary>
        /// <param name="resourceId">The resource id value.</param>
        /// <returns>The list of policy assignments.</returns>
        Task<IPagedCollection<IPolicyAssignment>> ListByResourceAsync(string resourceId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
