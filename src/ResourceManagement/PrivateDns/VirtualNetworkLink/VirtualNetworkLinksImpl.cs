// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a virtual network link collection associated with a private DNS zone.
    /// </summary>
    internal class VirtualNetworkLinksImpl :
        ExternalChildResourcesNonCached<VirtualNetworkLinkImpl, IVirtualNetworkLink, VirtualNetworkLinkInner, IPrivateDnsZone, PrivateDnsZoneImpl>,
        IVirtualNetworkLinks
    {
        internal VirtualNetworkLinksImpl(PrivateDnsZoneImpl parent)
            : base(parent, "PrivateDnsVirtualNetworkLink")
        {
        }

        /// <summary>
        /// Deletes a record set from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the record set to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        public void DeleteById(string id, string eTagValue = default(string))
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id, eTagValue, CancellationToken.None));
        }

        /// <summary>
        /// Asynchronously delete the record set from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the record set to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        public async Task DeleteByIdAsync(string id, string eTagValue = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            await Parent.Manager.Inner.VirtualNetworkLinks.DeleteAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                ResourceUtils.NameFromResourceId(id),
                ifMatch: eTagValue,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes a virtual network link from Azure, identifying it by its name.
        /// </summary>
        /// <param name="virtualNetworkLinkName">The name of the virtual network link to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        public void DeleteByName(string virtualNetworkLinkName, string eTagValue = default(string))
        {
            Extensions.Synchronize(() => DeleteByNameAsync(virtualNetworkLinkName, eTagValue, CancellationToken.None));
        }

        /// <summary>
        /// Asynchronously delete the virtual network link from Azure, identifying it by its name.
        /// </summary>
        /// <param name="virtualNetworkLinkName">The name of the virtual network link to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        public async Task DeleteByNameAsync(string virtualNetworkLinkName, string eTagValue = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            await Parent.Manager.Inner.VirtualNetworkLinks.DeleteAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                virtualNetworkLinkName,
                ifMatch: eTagValue,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets a virtual network link by its ID.
        /// </summary>
        /// <param name="id">The ID of virtual network link.</param>
        /// <return>The virtual network link.</return>
        public IVirtualNetworkLink GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id, CancellationToken.None));
        }

        /// <summary>
        /// Gets a virtual network link by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of virtual network link.</param>
        /// <return>The virtual network link.</return>
        public async Task<IVirtualNetworkLink> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            VirtualNetworkLinkInner inner = await Parent.Manager.Inner.VirtualNetworkLinks.GetAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                ResourceUtils.NameFromResourceId(id),
                cancellationToken);
            return WrapModel(inner);
        }

        /// <summary>
        /// Gets a virtual network link by its name.
        /// </summary>
        /// <param name="name">The name of virtual network link.</param>
        /// <return>The virtual network link.</return>
        public IVirtualNetworkLink GetByName(string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(name, CancellationToken.None));
        }

        /// <summary>
        /// Gets a virtual network link by its name asynchronously.
        /// </summary>
        /// <param name="name">The name of virtual network link.</param>
        /// <return>The virtual network link.</return>
        public async Task<IVirtualNetworkLink> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            VirtualNetworkLinkInner inner = await Parent.Manager.Inner.VirtualNetworkLinks.GetAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                name,
                cancellationToken);
            return WrapModel(inner);
        }

        /// <summary>
        /// Lists all the virtual network links, allowing optional parameter to limit the number of entries
        /// per page to the given page size.
        /// </summary>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The virtual network links.</return>
        public IEnumerable<IVirtualNetworkLink> List(int? pageSize = default(int?))
        {
            return Extensions.Synchronize(() => ListAsync(pageSize, pageSize == null, CancellationToken.None));
        }

        /// <summary>
        /// Asynchronously lists all the virtual network links, allowing optional parameter to limit the number of entries
        /// per page to the given page size.
        /// </summary>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The virtual network links.</return>
        public async Task<IPagedCollection<IVirtualNetworkLink>> ListAsync(int? pageSize = default(int?), bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IVirtualNetworkLink, VirtualNetworkLinkInner>.LoadPage(
                async(cancellation) => await Parent.Manager.Inner.VirtualNetworkLinks.ListAsync(
                    Parent.ResourceGroupName,
                    Parent.Name,
                    pageSize,
                    cancellation),
                Parent.Manager.Inner.VirtualNetworkLinks.ListNextAsync,
                WrapModel,
                loadAllPages,
                cancellationToken);
        }

        IPrivateDnsZone IHasParent<IPrivateDnsZone>.Parent
        {
            get
            {
                return Parent;
            }
        }

        IVirtualNetworkLinksOperations IHasInner<IVirtualNetworkLinksOperations>.Inner
        {
            get
            {
                return Parent.Manager.Inner.VirtualNetworkLinks;
            }
        }

        private IVirtualNetworkLink WrapModel(VirtualNetworkLinkInner inner)
        {
            return inner == null ? null : new VirtualNetworkLinkImpl(Parent, inner);
        }

        internal void ClearPendingOperations()
        {
            collection.Clear();
        }

        internal VirtualNetworkLinkImpl DefineVirtualNetworkLink(string name)
        {
            return PrepareDefine(VirtualNetworkLinkImpl.NewVirtualNetworkLink(name, Parent));
        }

        internal VirtualNetworkLinkImpl UpdateVirtualNetworkLink(string name)
        {
            return PrepareUpdate(VirtualNetworkLinkImpl.NewVirtualNetworkLink(name, Parent));
        }

        internal void WithoutVirtualNetworkLink(string name, string eTagValue)
        {
            PrepareRemove(VirtualNetworkLinkImpl.NewVirtualNetworkLink(name, Parent).WithETagOnDelete(eTagValue));
        }
    }
}
