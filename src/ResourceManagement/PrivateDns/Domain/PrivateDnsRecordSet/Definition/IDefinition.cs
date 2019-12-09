// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent.PrivateDnsRecordSet.Definition
{
    /// <summary>
    /// The entirety of a private DNS zone record set definition as a part of parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT> :
        PrivateDnsRecordSet.Definition.IARecordSetBlank<ParentT>,
        PrivateDnsRecordSet.Definition.IWithARecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithARecordAttachable<ParentT>,
        PrivateDnsRecordSet.Definition.IAaaaRecordSetBlank<ParentT>,
        PrivateDnsRecordSet.Definition.IWithAaaaRecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithAaaaRecordAttachable<ParentT>,
        PrivateDnsRecordSet.Definition.ICnameRecordSetBlank<ParentT>,
        PrivateDnsRecordSet.Definition.IWithCnameRecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithCnameRecordAttachable<ParentT>,
        PrivateDnsRecordSet.Definition.IMxRecordSetBlank<ParentT>,
        PrivateDnsRecordSet.Definition.IWithMxRecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithMxRecordAttachable<ParentT>,
        PrivateDnsRecordSet.Definition.IPtrRecordSetBlank<ParentT>,
        PrivateDnsRecordSet.Definition.IWithPtrRecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithPtrRecordAttachable<ParentT>,
        PrivateDnsRecordSet.Definition.ISoaRecordSetBlank<ParentT>,
        PrivateDnsRecordSet.Definition.IWithSoaRecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<ParentT>,
        PrivateDnsRecordSet.Definition.ISrvRecordSetBlank<ParentT>,
        PrivateDnsRecordSet.Definition.IWithSrvRecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithSrvRecordAttachable<ParentT>,
        PrivateDnsRecordSet.Definition.ITxtRecordSetBlank<ParentT>,
        PrivateDnsRecordSet.Definition.IWithTxtRecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithTxtRecordAttachable<ParentT>,
        PrivateDnsRecordSet.Definition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the private DNS zone record set definition.
    /// At this stage, any remaining optional settings can be specified, or the private DNS zone record set
    /// definition can be attached.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        PrivateDnsRecordSet.Definition.IWithEtagCheck<ParentT>,
        PrivateDnsRecordSet.Definition.IWithMetadata<ParentT>,
        PrivateDnsRecordSet.Definition.IWithTtl<ParentT>
    {
    }

    /// <summary>
    /// The stage of the record set definition allowing to enable ETag validation.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithEtagCheck<ParentT>
    {
        /// <summary>
        /// Specifies If-None-Match header to prevent updating an existing record set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithAttach<ParentT> WithETagCheck();
    }

    /// <summary>
    /// The stage of the record set definition allowing to specify metadata.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithMetadata<ParentT>
    {
        /// <summary>
        /// Adds a metadata to the resource.
        /// </summary>
        /// <param name="key">The key for the metadata.</param>
        /// <param name="value">The value for the metadata.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithAttach<ParentT> WithMetadata(string key, string value);
    }

    /// <summary>
    /// The stage of the record set definition allowing to specify the Time To Live (TTL) for the records in this record set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithTtl<ParentT>
    {
        /// <summary>
        /// Specifies the Time To Live for the records in the record set.
        /// </summary>
        /// <param name="ttlInSeconds">TTL in seconds.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithAttach<ParentT> WithTimeToLive(long ttlInSeconds);
    }

    // <summary>
    /// The first stage of a A record definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IARecordSetBlank<ParentT> :
        PrivateDnsRecordSet.Definition.IWithARecord<ParentT>
    {
    }

    /// <summary>
    /// The stage of the A record set definition allowing to add first A record.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithARecord<ParentT>
    {
        /// <summary>
        /// Creates an A record with the provided IPv4 address in this record set.
        /// </summary>
        /// <param name="ipv4Address">The IPv4 address.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithARecordAttachable<ParentT> WithIPv4Address(string ipv4Address);
    }

    /// <summary>
    /// The stage of the A record set definition allowing to add additional A records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithARecordAttachable<ParentT> :
        PrivateDnsRecordSet.Definition.IWithARecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithAttach<ParentT>
    {
    }

    // <summary>
    /// The first stage of a AAAA record definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IAaaaRecordSetBlank<ParentT> :
        PrivateDnsRecordSet.Definition.IWithAaaaRecord<ParentT>
    {
    }

    /// <summary>
    /// The stage of the AAAA record set definition allowing to add new AAAA record.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAaaaRecord<ParentT>
    {
        /// <summary>
        /// Creates an AAAA record with the provided IPv6 address in this record set.
        /// </summary>
        /// <param name="ipv6Address">The IPv6 address.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithAaaaRecordAttachable<ParentT> WithIPv6Address(string ipv6Address);
    }

    /// <summary>
    /// The stage of the AAAA record set definition allowing to add additional AAAA records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAaaaRecordAttachable<ParentT> :
        PrivateDnsRecordSet.Definition.IWithAaaaRecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithAttach<ParentT>
    {
    }

    // <summary>
    /// The first stage of a CNAME record definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface ICnameRecordSetBlank<ParentT> :
        PrivateDnsRecordSet.Definition.IWithCnameRecord<ParentT>
    {
    }

    /// <summary>
    /// The stage of a CNAME record definition allowing to add new CNAME record.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCnameRecord<ParentT>
    {
        /// <summary>
        /// Creates a CNAME record with the provided alias.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithCnameRecordAttachable<ParentT> WithAlias(string alias);
    }

    /// <summary>
    /// The stage of the CNAME record set definition allowing to add additional CNAME records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCnameRecordAttachable<ParentT> :
        PrivateDnsRecordSet.Definition.IWithCnameRecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithAttach<ParentT>
    {
    }

    // <summary>
    /// The first stage of a MX record definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IMxRecordSetBlank<ParentT> :
        PrivateDnsRecordSet.Definition.IWithMxRecord<ParentT>
    {
    }

    /// <summary>
    /// The stage of a MX record definition allowing to add new MX record.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithMxRecord<ParentT>
    {
        /// <summary>
        /// Creates and assigns priority to a MX record with the provided mail exchange server in this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithMxRecordAttachable<ParentT> WithMailExchange(string mailExchangeHostName, int priority);
    }

    /// <summary>
    /// The stage of the MX record set definition allowing to add additional MX records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithMxRecordAttachable<ParentT> :
        PrivateDnsRecordSet.Definition.IWithMxRecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithAttach<ParentT>
    {
    }

    // <summary>
    /// The first stage of a PTR record definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IPtrRecordSetBlank<ParentT> :
        PrivateDnsRecordSet.Definition.IWithPtrRecord<ParentT>
    {
    }

    /// <summary>
    /// The stage of a PTR record definition allowing to add new PTR record.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPtrRecord<ParentT>
    {
        /// <summary>
        /// Creates a PTR record with the provided target domain name in this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithPtrRecordAttachable<ParentT> WithTargetDomainName(string targetDomainName);
    }

    /// <summary>
    /// The stage of the PTR record set definition allowing to add additional PTR records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPtrRecordAttachable<ParentT> :
        PrivateDnsRecordSet.Definition.IWithPtrRecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithAttach<ParentT>
    {
    }

    // <summary>
    /// The first stage of a SOA record definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface ISoaRecordSetBlank<ParentT> :
        PrivateDnsRecordSet.Definition.IWithSoaRecord<ParentT>
    {

    }

    /// <summary>
    /// The stage of a SOA record definition allowing to add new SOA record.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSoaRecord<ParentT>
    {
        /// <summary>
        /// Specifies email server host name.
        /// </summary>
        /// <param name="emailServerHostName">The name of email server host.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<ParentT> WithEmailServer(string emailServerHostName);

        /// <summary>
        /// Specifies expire time for this SOA record.
        /// </summary>
        /// <param name="expireTimeInSeconds">The value of expire time.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<ParentT> WithExpireTimeInSeconds(long expireTimeInSeconds);

        /// <summary>
        /// Specifies the domain name of the authoritative name server for this SOA record.
        /// </summary>
        /// <param name="domainName">The value of domain name.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<ParentT> WithDomain(string domainName);

        /// <summary>
        /// Specifies the minimum value for determining the negative caching duration.
        /// </summary>
        /// <param name="negativeCachingTimeToLive">The value of negative response caching time.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<ParentT> WithNegativeResponseCachingTimeToLiveInSeconds(long negativeCachingTimeToLive);

        /// <summary>
        /// Specifies the refresh time for this SOA record.
        /// </summary>
        /// <param name="refreshTimeInSeconds">The value of refresh time.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<ParentT> WithRefreshTimeInSeconds(long refreshTimeInSeconds);

        /// <summary>
        /// Specifies the retry time for this SOA record.
        /// </summary>
        /// <param name="retryTimeInSeconds">The value of retry time.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<ParentT> WithRetryTimeInSeconds(long retryTimeInSeconds);

        /// <summary>
        /// Specifies the serial number for this SOA record.
        /// </summary>
        /// <param name="serialNumber">The value of serial number.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<ParentT> WithSerialNumber(long serialNumber);
    }

    /// <summary>
    /// The stage of the SOA record set definition allowing to add additional SOA records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSoaRecordAttachable<ParentT> :
        PrivateDnsRecordSet.Definition.IWithSoaRecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithAttach<ParentT>
    {
    }

    // <summary>
    /// The first stage of a SRV record definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface ISrvRecordSetBlank<ParentT> :
        PrivateDnsRecordSet.Definition.IWithSrvRecord<ParentT>
    {
    }

    /// <summary>
    /// The stage of a SRV record definition allowing to add new SRV record.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSrvRecord<ParentT>
    {
        /// <summary>
        /// Specifies a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host, lower the value higher the priority.</param>
        /// <param name="weight">The relative weight (preference) of the records with the same priority, higher the value more the preference.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSrvRecordAttachable<ParentT> WithRecord(string target, int port, int priority, int weight);
    }

    /// <summary>
    /// The stage of the SRV record set definition allowing to add additional SRV records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSrvRecordAttachable<ParentT> :
        PrivateDnsRecordSet.Definition.IWithSrvRecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithAttach<ParentT>
    {
    }

    // <summary>
    /// The first stage of a TXT record definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface ITxtRecordSetBlank<ParentT> :
        PrivateDnsRecordSet.Definition.IWithTxtRecord<ParentT>
    {
    }

    /// <summary>
    /// The stage of a TXT record definition allowing to add new TXT record.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithTxtRecord<ParentT>
    {
        /// <summary>
        /// Creates a TXT record with the given text in this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithTxtRecordAttachable<ParentT> WithText(string text);
    }

    /// <summary>
    /// The stage of the TXT record set definition allowing to add additional TXT records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithTxtRecordAttachable<ParentT> :
        PrivateDnsRecordSet.Definition.IWithTxtRecord<ParentT>,
        PrivateDnsRecordSet.Definition.IWithAttach<ParentT>
    {
    }
}
