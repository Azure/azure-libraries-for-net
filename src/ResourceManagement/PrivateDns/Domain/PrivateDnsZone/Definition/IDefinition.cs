// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent.PrivateDnsZone.Definition
{
    /// <summary>
    /// The entirety of the private DNS zone definition.
    /// </summary>
    public interface IDefinition :
        PrivateDnsZone.Definition.IBlank,
        PrivateDnsZone.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the private zone definition allowing to specify the resource group.
    /// </summary>
    public interface IBlank :
        ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroupAndRegion<IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// (via  WithCreate.create()), but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        ResourceManager.Fluent.Core.ResourceActions.ICreatable<IPrivateDnsZone>,
        ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<IWithCreate>,
        PrivateDnsZone.Definition.IWithETagCheck,
        PrivateDnsZone.Definition.IWithRecordSet,
        PrivateDnsZone.Definition.IWithVirtualNetworkLink
    {
    }

    /// <summary>
    /// The stage of the private DNS zone definition allowing to enable ETag validation.
    /// </summary>
    public interface IWithETagCheck
    {
        /// <summary>
        /// Specifies If-None-Match header to prevent updating an existing private DNS zone.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        PrivateDnsZone.Definition.IWithCreate WithETagCheck();
    }

    /// <summary>
    /// The stage of the private DNS zone definition allowing to specify record set.
    /// </summary>
    public interface IWithRecordSet
    {
        /// <summary>
        /// Specifies definition of an A record set.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        PrivateDnsRecordSet.Definition.IARecordSetBlank<IWithCreate> DefineARecordSet(string name);

        /// <summary>
        /// Specifies definition of an AAAA record set.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The stage representing configuration for the AAAA record set.</return>
        PrivateDnsRecordSet.Definition.IAaaaRecordSetBlank<IWithCreate> DefineAaaaRecordSet(string name);

        /// <summary>
        /// Specifies definition of a CNAME record set.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <return>The next stage of DNS zone definition.</return>
        PrivateDnsRecordSet.Definition.ICnameRecordSetBlank<IWithCreate> DefineCnameRecordSet(string name);

        /// <summary>
        /// Specifies definition of a MX record set.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The stage representing configuration for the MX record set.</return>
        PrivateDnsRecordSet.Definition.IMxRecordSetBlank<IWithCreate> DefineMxRecordSet(string name);

        /// <summary>
        /// Specifies definition of a PTR record set.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The stage representing configuration for the PTR record set.</return>
        PrivateDnsRecordSet.Definition.IPtrRecordSetBlank<IWithCreate> DefinePtrRecordSet(string name);

        /// <summary>
        /// Specifies definition of a SOA record set.
        /// </summary>
        /// <return>The stage representing configuration for the SOA record set.</return>
        PrivateDnsRecordSet.Definition.ISoaRecordSetBlank<IWithCreate> DefineSoaRecordSet();

        /// <summary>
        /// Specifies definition of a SRV record set.
        /// </summary>
        /// <param name="name">The name of the SRV record set.</param>
        /// <return>The stage representing configuration for the SRV record set.</return>
        PrivateDnsRecordSet.Definition.ISrvRecordSetBlank<IWithCreate> DefineSrvRecordSet(string name);

        /// <summary>
        /// Specifies definition of a TXT record set.
        /// </summary>
        /// <param name="name">The name of the TXT record set.</param>
        /// <return>The stage representing configuration for the TXT record set.</return>
        PrivateDnsRecordSet.Definition.ITxtRecordSetBlank<IWithCreate> DefineTxtRecordSet(string name);
    }

    /// <summary>
    /// The stage of the private DNS zone definition allowing to specify virtual network link.
    /// </summary>
    public interface IWithVirtualNetworkLink
    {
        /// <summary>
        /// Specifies definition of a virtual network link.
        /// </summary>
        /// <param name="name">The name of the virtual network link.</param>
        /// <return>The stage representing configuration for the virtual network link.</return>
        VirtualNetworkLink.Definition.IBlank<IWithCreate> DefineVirtualNetworkLink(string name);
    }
}
