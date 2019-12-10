// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IVirtualNetworkLinks :
        ISupportsGettingById<IVirtualNetworkLink>,
        ISupportsGettingByName<IVirtualNetworkLink>,
        IHasParent<IPrivateDnsZone>,
        IHasInner<IVirtualNetworkLinksOperations>
    {
        /// <summary>
        /// Deletes a record set from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the record set to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        void DeleteById(string id, string eTagValue = default(string));

        /// <summary>
        /// Asynchronously delete the record set from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the record set to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        Task DeleteByIdAsync(string id, string eTagValue = default(string), CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a virtual network link from Azure, identifying it by its name.
        /// </summary>
        /// <param name="virtualNetworkLinkName">The name of the virtual network link to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        void DeleteByName(string virtualNetworkLinkName, string eTagValue = default(string));

        /// <summary>
        /// Asynchronously delete the virtual network link from Azure, identifying it by its name.
        /// </summary>
        /// <param name="virtualNetworkLinkName">The name of the virtual network link to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        Task DeleteByNameAsync(string virtualNetworkLinkName, string eTagValue = default(string), CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all the virtual network links, allowing optional parameter to limit the number of entries
        /// per page to the given page size.
        /// </summary>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The virtual network links.</return>
        IEnumerable<IVirtualNetworkLink> List(int? pageSize = default(int?));

        /// <summary>
        /// Asynchronously lists all the virtual network links, allowing optional parameter to limit the number of entries
        /// per page to the given page size.
        /// </summary>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The virtual network links.</return>
        Task<IPagedCollection<IVirtualNetworkLink>> ListAsync(int? pageSize = default(int?), bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));
    }
}
