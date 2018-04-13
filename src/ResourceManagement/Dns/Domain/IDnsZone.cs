// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update;
    using Microsoft.Azure.Management.Dns.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure DNS Zone.
    /// </summary>
    public interface IDnsZone :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Dns.Fluent.IDnsZoneManager, Models.ZoneInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<DnsZone.Update.IUpdate>
    {

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing AAAA (IPv6 address) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.IAaaaRecordSets AaaaRecordSets { get; }

        /// <summary>
        /// Gets the access type of this zone (Private or Public).
        /// </summary>
        Models.ZoneType AccessType { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing A (IPv4 address) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.IARecordSets ARecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing Caa (canonical name) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.ICaaRecordSets CaaRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing CNAME (canonical name) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.ICNameRecordSets CNameRecordSets { get; }

        /// <summary>
        /// Gets the etag associated with this zone.
        /// </summary>
        string ETag { get; }

        /// <summary>
        /// Gets the maximum number of record sets that can be created in this zone.
        /// </summary>
        long MaxNumberOfRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing MX (mail exchange) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.IMXRecordSets MXRecordSets { get; }

        /// <summary>
        /// Gets name servers assigned for this zone.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> NameServers { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing NS (name server) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.INSRecordSets NSRecordSets { get; }

        /// <summary>
        /// Gets the current number of record sets in this zone.
        /// </summary>
        long NumberOfRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing PTR (pointer) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.IPtrRecordSets PtrRecordSets { get; }

        /// <summary>
        /// Gets a list of references to virtual networks that register hostnames in this DNS zone for Private DNS zone.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> RegistrationVirtualNetworkIds { get; }

        /// <summary>
        /// Gets a list of references to virtual networks that resolve records in this DNS zone for Private DNS zone.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> ResolutionVirtualNetworkIds { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing SRV (service) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.ISrvRecordSets SrvRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing TXT (text) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.ITxtRecordSets TxtRecordSets { get; }

        /// <return>The record set containing SOA (start of authority) record associated with this DNS zone.</return>
        Microsoft.Azure.Management.Dns.Fluent.ISoaRecordSet GetSoaRecordSet();

        /// <return>The record sets in this zone.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets();

        /// <summary>
        /// Lists all the record sets in this zone with the given suffix.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <return>The record sets.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets(string recordSetNameSuffix);

        /// <summary>
        /// Lists all the record sets in this zone with each entries in each page
        /// limited to the given size.
        /// </summary>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The record sets.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets(int pageSize);

        /// <summary>
        /// Lists all the record sets in this zone with the given suffix, also limits
        /// the number of entries per page to the given page size.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The record sets.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets(string recordSetNameSuffix, int pageSize);
    }
}