// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An immutable client-side representation of an Azure Private DNS Zone.
    /// </summary>
    public interface IPrivateDnsZone :
        IGroupableResource<IPrivateDnsZoneManager, PrivateZoneInner>,
        IRefreshable<IPrivateDnsZone>,
        IUpdatable<PrivateDnsZone.Update.IUpdate>
    {
        /// <summary>
        /// Gets the etag associated with the private DNS zone.
        /// </summary>
        string ETag { get; }

        /// <summary>
        /// Gets the maximum number of record sets that can be created in this
        /// Private DNS zone.
        /// </summary>
        long MaxNumberOfRecordSets { get; }

        /// <summary>
        /// Gets the current number of record sets in this Private DNS zone.
        /// </summary>
        long NumberOfRecordSets { get; }

        /// <summary>
        /// Gets the maximum number of virtual networks that can be linked to
        /// this Private DNS zone.
        /// </summary>
        long MaxNumberOfVirtualNetworkLinks { get; }

        /// <summary>
        /// Gets the current number of virtual networks that are linked to this
        /// Private DNS zone.
        /// </summary>
        long NumberOfVirtualNetworkLinks { get; }

        /// <summary>
        /// Gets the maximum number of virtual networks that can be linked to
        /// this Private DNS zone with registration enabled.
        /// </summary>
        long MaxNumberOfVirtualNetworkLinksWithRegistration { get; }

        /// <summary>
        /// Gets the current number of virtual networks that are linked to this
        /// Private DNS zone with registration enabled.
        /// </summary>
        long NumberOfVirtualNetworkLinksWithRegistration { get; }

        /// <summary>
        /// Gets the provisioning state of the resource.
        /// Possible values include: 'Creating', 'Updating', 'Deleting',
        /// 'Succeeded', 'Failed', 'Canceled'
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing A (IPv4 address) records.
        /// </summary>
        IARecordSets ARecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing AAAA (IPv6 address) records.
        /// </summary>
        IAaaaRecordSets AaaaRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing CNAME (canonical name) records.
        /// </summary>
        ICnameRecordSets CnameRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing MX (mail exchange) records.
        /// </summary>
        IMxRecordSets MxRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing PTR (pointer) records.
        /// </summary>
        IPtrRecordSets PtrRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing SOA (start of authority) records.
        /// </summary>
        ISoaRecordSets SoaRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing SRV (service) records.
        /// </summary>
        ISrvRecordSets SrvRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing TXT (text) records.
        /// </summary>
        ITxtRecordSets TxtRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage virtual network links in this private zone.
        /// </summary>
        IVirtualNetworkLinks VirtualNetworkLinks { get; }

        /// <summary>
        /// Lists all the record sets in this private zone with the given suffix, also limits
        /// the number of entries per page to the given page size.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The record sets.</return>
        IEnumerable<IPrivateDnsRecordSet> ListRecordSets(string recordSetNameSuffix = default(string), int? pageSize = default(int?));

        /// <summary>
        /// Asynchronously lists all the record sets in this private zone with the given suffix, also limits
        /// the number of entries per page to the given page size.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The record sets.</return>
        Task<IPagedCollection<IPrivateDnsRecordSet>> ListRecordSetsAsync(string recordSetNameSuffix = default(string), int? pageSize = default(int?), bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));
    }
}
