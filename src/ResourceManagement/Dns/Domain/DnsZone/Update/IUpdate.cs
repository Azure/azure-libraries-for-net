// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update
{
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the DNS zone update allowing to specify record set.
    /// </summary>
    public interface IWithRecordSet
    {

        /// <summary>
        /// Specifies definition of an AAAA record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The stage representing configuration for the AAAA record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IAaaaRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefineAaaaRecordSet(string name);

        /// <summary>
        /// Specifies definition of an A record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IARecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefineARecordSet(string name);

        /// <summary>
        /// Specifies definition of a Caa record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">The name of the Caa record set.</param>
        /// <return>The stage representing configuration for the Caa record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.ICaaRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefineCaaRecordSet(string name);

        /// <summary>
        /// Specifies definition of a CNAME record set.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <return>The next stage of DNS zone definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.ICNameRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefineCNameRecordSet(string name);

        /// <summary>
        /// Specifies definition of a MX record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The stage representing configuration for the MX record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IMXRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefineMXRecordSet(string name);

        /// <summary>
        /// Specifies definition of an NS record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">Name of the NS record set.</param>
        /// <return>The stage representing configuration for the NS record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.INSRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefineNSRecordSet(string name);

        /// <summary>
        /// Specifies definition of a PTR record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The stage representing configuration for the PTR record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IPtrRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefinePtrRecordSet(string name);

        /// <summary>
        /// Specifies definition of a SRV record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">The name of the SRV record set.</param>
        /// <return>The stage representing configuration for the SRV record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.ISrvRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefineSrvRecordSet(string name);

        /// <summary>
        /// Specifies definition of a TXT record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">The name of the TXT record set.</param>
        /// <return>The stage representing configuration for the TXT record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.ITxtRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefineTxtRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing AAAA record set in this DNS zone.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The stage representing configuration for the AAAA record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateAaaaRecordSet.IUpdateAaaaRecordSet UpdateAaaaRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing A record set in this DNS zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateARecordSet.IUpdateARecordSet UpdateARecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing Caa record set in this DNS zone.
        /// </summary>
        /// <param name="name">The name of the Caa record set.</param>
        /// <return>The stage representing configuration for the Caa record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateCaaRecordSet.IUpdateCaaRecordSet UpdateCaaRecordSet(string name);

        /// <summary>
        /// Specifies definition of a CNAME record set.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <return>The stage representing configuration for the CNAME record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateCNameRecordSet.IUpdateCNameRecordSet UpdateCNameRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing MX record set in this DNS zone.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The stage representing configuration for the MX record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateMXRecordSet.IUpdateMXRecordSet UpdateMXRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing NS record set in this DNS zone.
        /// </summary>
        /// <param name="name">Name of the NS record set.</param>
        /// <return>The stage representing configuration for the NS record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateNSRecordSet.IUpdateNSRecordSet UpdateNSRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing PTR record set in this DNS zone.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The stage representing configuration for the PTR record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdatePtrRecordSet.IUpdatePtrRecordSet UpdatePtrRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of the SOA record in this DNS zone.
        /// </summary>
        /// <return>The stage representing configuration for the TXT record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord UpdateSoaRecord();

        /// <summary>
        /// Begins the description of an update of an existing SRV record set in this DNS zone.
        /// </summary>
        /// <param name="name">The name of the SRV record set.</param>
        /// <return>The stage representing configuration for the SRV record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSrvRecordSet.IUpdateSrvRecordSet UpdateSrvRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing TXT record set in this DNS zone.
        /// </summary>
        /// <param name="name">The name of the TXT record set.</param>
        /// <return>The stage representing configuration for the TXT record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateTxtRecordSet.IUpdateTxtRecordSet UpdateTxtRecordSet(string name);

        /// <summary>
        /// Specifies definition of a CNAME record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <param name="alias">The CNAME record alias.</param>
        /// <return>The next stage of DNS zone definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithCNameRecordSet(string name, string alias);

        /// <summary>
        /// Removes a AAAA record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutAaaaRecordSet(string name);

        /// <summary>
        /// Removes a AAAA record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutAaaaRecordSet(string name, string eTagValue);

        /// <summary>
        /// Removes a A record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutARecordSet(string name);

        /// <summary>
        /// Removes a A record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutARecordSet(string name, string eTagValue);

        /// <summary>
        /// Removes a Caa record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the Caa record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutCaaRecordSet(string name);

        /// <summary>
        /// Removes a Caa record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the Caa record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutCaaRecordSet(string name, string eTagValue);

        /// <summary>
        /// Removes a CNAME record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutCNameRecordSet(string name);

        /// <summary>
        /// Removes a CNAME record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutCNameRecordSet(string name, string eTagValue);

        /// <summary>
        /// Removes a MX record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutMXRecordSet(string name);

        /// <summary>
        /// Removes a MX record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutMXRecordSet(string name, string eTagValue);

        /// <summary>
        /// Removes a NS record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the NS record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutNSRecordSet(string name);

        /// <summary>
        /// Removes a NS record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the NS record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutNSRecordSet(string name, string eTagValue);

        /// <summary>
        /// Removes a PTR record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutPtrRecordSet(string name);

        /// <summary>
        /// Removes a PTR record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutPtrRecordSet(string name, string eTagValue);

        /// <summary>
        /// Removes a SRV record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the SRV record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutSrvRecordSet(string name);

        /// <summary>
        /// Removes a SRV record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the SRV record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutSrvRecordSet(string name, string eTagValue);

        /// <summary>
        /// Removes a TXT record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the TXT record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutTxtRecordSet(string name);

        /// <summary>
        /// Removes a TXT record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the TXT record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutTxtRecordSet(string name, string eTagValue);
    }

    /// <summary>
    /// The stage of the DNS zone update allowing to enable ETag validation.
    /// </summary>
    public interface IWithETagCheck
    {

        /// <summary>
        /// Specifies that If-Match header needs to set to the current eTag value associated
        /// with the DNS Zone.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithETagCheck();

        /// <summary>
        /// Specifies that if-Match header needs to set to the given eTag value.
        /// </summary>
        /// <param name="eTagValue">The eTag value.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithETagCheck(string eTagValue);
    }

    /// <summary>
    /// The stage of the DNS zone update allowing to specify Zone access type.
    /// </summary>
    public interface IWithZoneType
    {

        /// <summary>
        /// Sets the type of this zone to Private.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithPrivateAccess();

        /// <summary>
        /// Sets the type of this zone to Private.
        /// </summary>
        /// <param name="registrationVirtualNetworkIds">A list of references to virtual networks that register hostnames in this DNS zone.</param>
        /// <param name="resolutionVirtualNetworkIds">A list of references to virtual networks that resolve records in this DNS zone.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithPrivateAccess(IList<string> registrationVirtualNetworkIds, IList<string> resolutionVirtualNetworkIds);

        /// <summary>
        /// Sets the type of this zone to Public (default behavior).
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithPublicAccess();
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// Call  Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IWithRecordSet,
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IWithETagCheck,
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IWithZoneType,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate>
    {

    }
}