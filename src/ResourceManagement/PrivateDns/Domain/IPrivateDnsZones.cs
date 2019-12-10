// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point to private DNS zone management API in Azure.
    /// </summary>
    public interface IPrivateDnsZones :
        ISupportsCreating<PrivateDnsZone.Definition.IBlank>,
        ISupportsGettingById<IPrivateDnsZone>,
        ISupportsGettingByResourceGroup<IPrivateDnsZone>,
        IHasManager<IPrivateDnsZoneManager>,
        IHasInner<IPrivateZonesOperations>
    {
        /// <summary>
        /// Deletes a private zone from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the private zone to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        void DeleteById(string id, string eTagValue = default(string));

        /// <summary>
        /// Asynchronously delete a private zone from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the private zone to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        Task DeleteByIdAsync(string id, string eTagValue = default(string), CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the zone from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="privateZoneName">The name of the private zone.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        void DeleteByResourceGroupName(string resourceGroupName, string privateZoneName, string eTagValue = default(string));

        /// <summary>
        /// Deletes the zone from Azure, identifying it by its name and its resource group asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="privateZoneName">The name of the private zone.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        Task DeleteByResourceGroupNameAsync(string resourceGroupName, string privateZoneName, string eTagValue = default(string), CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all the private zones in the currently selected subscription.
        /// </summary>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The private zones</return>
        IEnumerable<IPrivateDnsZone> List(int? pageSize = default(int?));

        /// <summary>
        /// Lists all the private zones in the currently selected subscription asynchronously.
        /// </summary>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The private zones</return>
        Task<IPagedCollection<IPrivateDnsZone>> ListAsync(int? pageSize = default(int?), bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all the private zones, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The private zones</return>
        IEnumerable<IPrivateDnsZone> ListByResourceGroup(string resourceGroupName, int? pageSize = default(int?));

        /// <summary>
        /// Lists all the private zones, identifying it by its name and its resource group asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The private zones</return>
        Task<IPagedCollection<IPrivateDnsZone>> ListByResourceGroupAsync(string resourceGroupName, int? pageSize = default(int?), bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));
    }
}
