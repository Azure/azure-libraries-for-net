// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent.PrivateDnsZone.Update
{
    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// Call  Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate :
        ResourceManager.Fluent.Core.ResourceActions.IAppliable<IPrivateDnsZone>,
        ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<IUpdate>,
        PrivateDnsZone.Update.IWithETagCheck,
        PrivateDnsZone.Update.IWithRecordSet,
        PrivateDnsZone.Update.IWithVirtualNetworkLink
    {
    }

    /// <summary>
    /// The stage of the private DNS zone update allowing to specify record set.
    /// </summary>
    public interface IWithRecordSet
    {
        /// <summary>
        /// Specifies definition of an A record set.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.IARecordSetBlank<IUpdate> DefineARecordSet(string name);

        /// <summary>
        /// Specifies definition of an AAAA record set.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The stage representing configuration for the AAAA record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.IAaaaRecordSetBlank<IUpdate> DefineAaaaRecordSet(string name);

        /// <summary>
        /// Specifies definition of a CNAME record set.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <return>The stage representing configuration for the CNAME record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.ICnameRecordSetBlank<IUpdate> DefineCnameRecordSet(string name);

        /// <summary>
        /// Specifies definition of a MX record set.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The stage representing configuration for the MX record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.IMxRecordSetBlank<IUpdate> DefineMxRecordSet(string name);

        /// <summary>
        /// Specifies definition of a PTR record set.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The stage representing configuration for the PTR record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.IPtrRecordSetBlank<IUpdate> DefinePtrRecordSet(string name);

        /// <summary>
        /// Specifies definition of a SOA record set.
        /// </summary>
        /// <return>The stage representing configuration for the SOA record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.ISoaRecordSetBlank<IUpdate> DefineSoaRecordSet();

        /// <summary>
        /// Specifies definition of a SRV record set.
        /// </summary>
        /// <param name="name">Name of the SRV record set.</param>
        /// <return>The stage representing configuration for the SRV record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.ISrvRecordSetBlank<IUpdate> DefineSrvRecordSet(string name);

        /// <summary>
        /// Specifies definition of a TXT record set.
        /// </summary>
        /// <param name="name">Name of the TXT record set.</param>
        /// <return>The stage representing configuration for the TXT record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.ITxtRecordSetBlank<IUpdate> DefineTxtRecordSet(string name);

        /// <summary>
        /// Specifies update of a AAAA record set.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The stage representing configuration for the AAAA record set.</return>
        PrivateDnsRecordSet.Update.IUpdateAaaaRecordSet UpdateAaaaRecordSet(string name);

        /// <summary>
        /// Specifies update of a A record set.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        PrivateDnsRecordSet.Update.IUpdateARecordSet UpdateARecordSet(string name);

        /// <summary>
        /// Specifies update of a CNAME record set.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <return>The stage representing configuration for the CNAME record set.</return>
        PrivateDnsRecordSet.Update.IUpdateARecordSet UpdateCnameRecordSet(string name);

        /// <summary>
        /// Specifies update of a MX record set.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The stage representing configuration for the MX record set.</return>
        PrivateDnsRecordSet.Update.IUpdateMxRecordSet UpdateMxRecordSet(string name);

        /// <summary>
        /// Specifies update of a PTR record set.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The stage representing configuration for the PTR record set.</return>
        PrivateDnsRecordSet.Update.IUpdatePtrRecordSet UpdatePtrRecordSet(string name);

        /// <summary>
        /// Specifies update of a SOA record set.
        /// </summary>
        /// <return>The stage representing configuration for the SOA record set.</return>
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet UpdateSoaRecordSet();

        /// <summary>
        /// Specifies update of a SRV record set.
        /// </summary>
        /// <param name="name">Name of the SRV record set.</param>
        /// <return>The stage representing configuration for the SRV record set.</return>
        PrivateDnsRecordSet.Update.IUpdateSrvRecordSet UpdateSrvRecordSet(string name);

        /// <summary>
        /// Specifies update of a TXT record set.
        /// </summary>
        /// <param name="name">Name of the TXT record set.</param>
        /// <return>The stage representing configuration for the TXT record set.</return>
        PrivateDnsRecordSet.Update.IUpdateTxtRecordSet UpdateTxtRecordSet(string name);

        /// <summary>
        /// Removes a AAAA record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutAaaaRecordSet(string name);

        /// <summary>
        /// Removes a AAAA record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutAaaaRecordSet(string name, string eTagValue);

        /// <summary>
        /// Removes a A record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutARecordSet(string name);

        /// <summary>
        /// Removes a A record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutARecordSet(string name, string eTagValue);

        /// <summary>
        /// Removes a CNAME record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutCnameRecordSet(string name);

        /// <summary>
        /// Removes a CNAME record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutCnameRecordSet(string name, string eTagValue);

        /// <summary>
        /// Removes a MX record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutMxRecordSet(string name);

        /// <summary>
        /// Removes a MX record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutMxRecordSet(string name, string eTagValue);

        /// <summary>
        /// Removes a PTR record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutPtrRecordSet(string name);

        /// <summary>
        /// Removes a PTR record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutPtrRecordSet(string name, string eTagValue);

        /// <summary>
        /// Removes a SOA record set in the private DNS zone.
        /// </summary>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutSoaRecordSet();

        /// <summary>
        /// Removes a SOA record set in the private DNS zone.
        /// </summary>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutSoaRecordSet(string eTagValue);

        /// <summary>
        /// Removes a SRV record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the SRV record set.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutSrvRecordSet(string name);

        /// <summary>
        /// Removes a SRV record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the SRV record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutSrvRecordSet(string name, string eTagValue);

        /// <summary>
        /// Removes a TXT record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the TXT record set.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutTxtRecordSet(string name);

        /// <summary>
        /// Removes a TXT record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the TXT record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutTxtRecordSet(string name, string eTagValue);
    }

    /// <summary>
    /// The stage of the private DNS zone update allowing to specify virtual network link.
    /// </summary>
    public interface IWithVirtualNetworkLink
    {
        /// <summary>
        /// Specifies definition of a virtual network link.
        /// </summary>
        /// <param name="name">Name of the virtual network link.</param>
        /// <return>The stage representing configuration for the virtual network link.</return>
        VirtualNetworkLink.UpdateDefinition.IBlank<IUpdate> DefineVirtualNetworkLink(string name);

        /// <summary>
        /// Specifies update of a virtual network link.
        /// </summary>
        /// <param name="name">Name of the virtual network link.</param>
        /// <return>The stage representing configuration for the virtual network link.</return>
        VirtualNetworkLink.Update.IUpdate UpdateVirtualNetworkLink(string name);

        /// <summary>
        /// Removes a virtual network link in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the virtual network link.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutVirtualNetworkLink(string name);

        /// <summary>
        /// Removes a virtual network link in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the virtual network link.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate WithoutVirtualNetworkLink(string name, string eTagValue);
    }

    /// <summary>
    /// The stage of the private DNS zone update allowing to enable ETag validation.
    /// </summary>
    public interface IWithETagCheck
    {
        /// <summary>
        /// Specifies If-Match header to the current eTag value associated
        /// with the private DNS Zone.
        /// </summary>
        /// <return>The next stage of the update.</return>
        PrivateDnsZone.Update.IUpdate WithETagCheck();

        /// <summary>
        /// Specifies If-Match header to the given eTag value.
        /// </summary>
        /// <param name="eTagValue">The eTag value.</param>
        /// <return>The next stage of the update.</return>
        PrivateDnsZone.Update.IUpdate WithEtagCheck(string eTagValue);
    }
}
