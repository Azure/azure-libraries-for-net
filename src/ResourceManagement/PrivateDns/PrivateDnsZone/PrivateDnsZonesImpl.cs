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
    /// Implementation of PrivateDnsZones.
    /// </summary>
    internal class PrivateDnsZonesImpl :
        IPrivateDnsZones
    {
        private readonly PrivateDnsZoneManager manager;
        internal PrivateDnsZonesImpl(PrivateDnsZoneManager privateDnsZoneManager)
        {
            manager = privateDnsZoneManager;
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
        PrivateDnsZone.Definition.IBlank ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<PrivateDnsZone.Definition.IBlank>.Define(string name)
        {
            return WrapModel(name);
        }

        /// <summary>
        /// Deletes a private zone from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the private zone to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        public void DeleteById(string id, string eTagValue = default(string))
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id, eTagValue, CancellationToken.None));
        }

        /// <summary>
        /// Asynchronously delete a private zone from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the private zone to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        public async Task DeleteByIdAsync(string id, string eTagValue = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            await DeleteByResourceGroupNameAsync(
                ResourceUtils.GroupFromResourceId(id), 
                ResourceUtils.NameFromResourceId(id),
                eTagValue, 
                cancellationToken);
        }

        /// <summary>
        /// Deletes the zone from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="privateZoneName">The name of the private zone.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        public void DeleteByResourceGroupName(string resourceGroupName, string privateZoneName, string eTagValue = default(string))
        {
            Extensions.Synchronize(() => DeleteByResourceGroupNameAsync(resourceGroupName, privateZoneName, eTagValue, CancellationToken.None));
        }

        /// <summary>
        /// Deletes the zone from Azure, identifying it by its name and its resource group asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="privateZoneName">The name of the private zone.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        public async Task DeleteByResourceGroupNameAsync(string resourceGroupName, string privateZoneName, string eTagValue = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            await manager.Inner.PrivateZones.DeleteAsync(resourceGroupName, privateZoneName, eTagValue, cancellationToken);
        }

        /// <summary>
        /// Gets a private DNS zone by its ID.
        /// </summary>
        /// <param name="id">The resource ID of the private DNS zone.</param>
        /// <return>The private zone</return>
        public IPrivateDnsZone GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id, CancellationToken.None));
        }

        /// <summary>
        /// Gets a private DNS zone by its ID asynchronously.
        /// </summary>
        /// <param name="id">The resource ID of the private DNS zone.</param>
        /// <return>The private zone</return>
        public async Task<IPrivateDnsZone> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await manager.Inner.PrivateZones.GetAsync(
                    ResourceUtils.GroupFromResourceId(id),
                    ResourceUtils.NameFromResourceId(id),
                    cancellationToken);
            return inner == null ? null : WrapModel(inner);
        }

        /// <summary>
        /// Gets a private DNS zone by the resource group name it belongs to and its name.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name it belongs to.</param>
        /// <param name="name">The name of the private DNS zone.</param>
        /// <return>The private zone</return>
        public IPrivateDnsZone GetByResourceGroup(string resourceGroupName, string name)
        {
            return Extensions.Synchronize(() => GetByResourceGroupAsync(resourceGroupName, name, CancellationToken.None));
        }

        /// <summary>
        /// Gets a private DNS zone by the resource group name it belongs to and its name asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name it belongs to.</param>
        /// <param name="name">The name of the private DNS zone.</param>
        /// <return>The private zone</return>
        public async Task<IPrivateDnsZone> GetByResourceGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await manager.Inner.PrivateZones.GetAsync(resourceGroupName, name, cancellationToken);
            return inner == null ? null : WrapModel(inner);
        }

        /// <summary>
        /// Lists all the private zones in the currently selected subscription.
        /// </summary>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The private zones</return>
        public IEnumerable<IPrivateDnsZone> List(int? pageSize = default(int?))
        {
            return Extensions.Synchronize(() => ListAsync(pageSize, pageSize == null, CancellationToken.None));
        }

        /// <summary>
        /// Lists all the private zones in the currently selected subscription asynchronously.
        /// </summary>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The private zones</return>
        public async Task<IPagedCollection<IPrivateDnsZone>> ListAsync(int? pageSize = default(int?), bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IPrivateDnsZone, PrivateZoneInner>.LoadPage(
                async (cancellation) => await manager.Inner.PrivateZones.ListAsync(pageSize, cancellationToken),
                manager.Inner.PrivateZones.ListNextAsync,
                WrapModel,
                loadAllPages,
                cancellationToken);
        }

        /// <summary>
        /// Lists all the private zones, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The private zones</return>
        public IEnumerable<IPrivateDnsZone> ListByResourceGroup(string resourceGroupName, int? pageSize = default(int?))
        {
            return Extensions.Synchronize(() => ListByResourceGroupAsync(resourceGroupName, pageSize, pageSize == null, CancellationToken.None));
        }

        /// <summary>
        /// Lists all the private zones, identifying it by its name and its resource group asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The private zones</return>
        public async Task<IPagedCollection<IPrivateDnsZone>> ListByResourceGroupAsync(string resourceGroupName, int? pageSize = default(int?), bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IPrivateDnsZone, PrivateZoneInner>.LoadPage(
                async(cancellation) => await manager.Inner.PrivateZones.ListByResourceGroupAsync(resourceGroupName, pageSize, cancellation),
                manager.Inner.PrivateZones.ListByResourceGroupNextAsync,
                WrapModel,
                loadAllPages,
                cancellationToken);
        }

        IPrivateDnsZoneManager IHasManager<IPrivateDnsZoneManager>.Manager
        {
            get
            {
                return manager;
            }
        }

        IPrivateZonesOperations IHasInner<IPrivateZonesOperations>.Inner
        {
            get
            {
                return manager.Inner.PrivateZones;
            }
        }

        protected PrivateDnsZoneImpl WrapModel(string name)
        {
            return WrapModel(new PrivateZoneInner(name: name, location:"global"));
        }

        protected PrivateDnsZoneImpl WrapModel(PrivateZoneInner inner)
        {
            return new PrivateDnsZoneImpl(inner.Name, inner, manager);
        }
    }
}
