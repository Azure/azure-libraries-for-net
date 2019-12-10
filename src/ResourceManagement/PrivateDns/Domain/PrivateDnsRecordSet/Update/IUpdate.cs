// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent.PrivateDnsRecordSet.Update
{
    using System.Collections.Generic;

    /// <summary>
    /// The entirety of a record sets update as a part of parent private DNS zone update.
    /// </summary>
    public interface IUpdateCombined :
        PrivateDnsRecordSet.Update.IUpdateARecordSet,
        PrivateDnsRecordSet.Update.IUpdateAaaaRecordSet,
        PrivateDnsRecordSet.Update.IUpdateCnameRecordSet,
        PrivateDnsRecordSet.Update.IUpdateMxRecordSet,
        PrivateDnsRecordSet.Update.IUpdatePtrRecordSet,
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet,
        PrivateDnsRecordSet.Update.IUpdateSrvRecordSet,
        PrivateDnsRecordSet.Update.IUpdateTxtRecordSet,
        PrivateDnsRecordSet.Update.IUpdate
    {
    }

    /// <summary>
    /// The set of configurations that can be updated for private DNS record set irrespective of their type RecordType.
    /// </summary>
    public interface IUpdate :
        ResourceManager.Fluent.Core.ChildResourceActions.ISettable<PrivateDnsZone.Update.IUpdate>,
        PrivateDnsRecordSet.Update.IWithETagCheck,
        PrivateDnsRecordSet.Update.IWithMetadata,
        PrivateDnsRecordSet.Update.IWithTtl
    {
    }

    /// <summary>
    /// The stage of the record set update allowing to specify TTL for the records in this record set.
    /// </summary>
    public interface IWithTtl
    {
        /// <summary>
        /// Specifies the TTL for the records in the record set.
        /// </summary>
        /// <param name="ttlInSeconds">TTL in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdate WithTimeToLive(long ttlInSeconds);
    }

    /// <summary>
    /// The stage of the record set update allowing to enable ETag validation.
    /// </summary>
    public interface IWithETagCheck
    {
        /// <summary>
        /// Specifies If-Match header to the current eTag value associated
        /// with the record set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        PrivateDnsRecordSet.Update.IUpdate WithETagCheck();

        /// <summary>
        /// Specifies If-Match header to the given eTag value.
        /// </summary>
        /// <param name="eTagValue">The eTag value.</param>
        /// <return>The next stage of the update.</return>
        PrivateDnsRecordSet.Update.IUpdate WithETagCheck(string eTagValue);
    }

    /// <summary>
    /// An update allowing metadata to be modified for the resource.
    /// </summary>
    public interface IWithMetadata
    {
        /// <summary>
        /// Adds a metadata to the record set.
        /// </summary>
        /// <param name="key">The key for the metadata.</param>
        /// <param name="value">The value for the metadata.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdate WithMetadata(string key, string value);

        /// <summary>
        /// Removes a metadata from the record set.
        /// </summary>
        /// <param name="key">The key of the metadata to remove.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdate WithoutMetadata(string key);
    }

    /// <summary>
    /// The entirety of a A record update as a part of parent private DNS zone update.
    /// </summary>
    public interface IUpdateARecordSet :
        PrivateDnsRecordSet.Update.IWithARecord,
        PrivateDnsRecordSet.Update.IUpdate
    {
    }

    /// <summary>
    /// The stage of the A record set update allowing to add or remove A record.
    /// </summary>
    public interface IWithARecord
    {
        /// <summary>
        /// Creates an A record with the provided IPv4 address in the record set.
        /// </summary>
        /// <param name="ipv4Address">An IPv4 address.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateARecordSet WithIPv4Address(string ipv4Address);

        /// <summary>
        /// Removes the A record with the provided IPv4 address from the record set.
        /// </summary>
        /// <param name="ipv4Address">An IPv4 address.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateARecordSet WithoutIPv4Address(string ipv4Address);
    }

    /// <summary>
    /// The entirety of a AAAA record update as a part of parent private DNS zone update.
    /// </summary>
    public interface IUpdateAaaaRecordSet :
        PrivateDnsRecordSet.Update.IWithAaaaRecord,
        PrivateDnsRecordSet.Update.IUpdate
    {    
    }

    /// <summary>
    /// The stage of the AAAA record set update allowing to add or remove AAAA record.
    /// </summary>
    public interface IWithAaaaRecord
    {
        /// <summary>
        /// Creates an AAAA record with the provided IPv6 address in this record set.
        /// </summary>
        /// <param name="ipv6Address">The IPv6 address.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateAaaaRecordSet WithIPv6Address(string ipv6Address);

        /// <summary>
        /// Removes an AAAA record with the provided IPv6 address from this record set.
        /// </summary>
        /// <param name="ipv6Address">The IPv6 address.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateAaaaRecordSet WithoutIPv6Address(string ipv6Address);
    }

    /// <summary>
    /// The entirety of a CNAME record update as a part of parent private DNS zone update.
    /// </summary>
    public interface IUpdateCnameRecordSet :
        PrivateDnsRecordSet.Update.IWithCnameRecord,
        PrivateDnsRecordSet.Update.IUpdate
    {
    }

    /// <summary>
    /// The stage of the CNAME record set update allowing to update the CNAME record.
    /// </summary>
    public interface IWithCnameRecord
    {
        /// <summary>
        /// The new alias for the CNAME record set.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateCnameRecordSet WithAlias(string alias);
    }

    /// <summary>
    /// The entirety of a MX record update as a part of parent private DNS zone update.
    /// </summary>
    public interface IUpdateMxRecordSet :
        PrivateDnsRecordSet.Update.IWithMxRecord,
        PrivateDnsRecordSet.Update.IUpdate
    {
    }

    /// <summary>
    /// The stage of the MX record set definition allowing to add or remove MX record.
    /// </summary>
    public interface IWithMxRecord
    {
        /// <summary>
        /// Creates and assigns priority to a MX record with the provided mail exchange server in this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateMxRecordSet WithMailExchange(string mailExchangeHostName, int priority);

        /// <summary>
        /// Removes MX record with the provided mail exchange server and priority from this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateMxRecordSet WithoutMailExchange(string mailExchangeHostName, int priority);
    }

    /// <summary>
    /// The entirety of a PTR record update as a part of parent private DNS zone update.
    /// </summary>
    public interface IUpdatePtrRecordSet :
        PrivateDnsRecordSet.Update.IWithPtrRecord,
        PrivateDnsRecordSet.Update.IUpdate
    {
    }

    /// <summary>
    /// The stage of the PTR record set definition allowing to add or remove PTR record.
    /// </summary>
    public interface IWithPtrRecord
    {
        /// <summary>
        /// Creates a PTR record with the provided canonical name in this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdatePtrRecordSet WithTargetDomainName(string targetDomainName);

        /// <summary>
        /// Removes the PTR record with the provided canonical name from this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdatePtrRecordSet WithoutTargetDomainName(string targetDomainName);
    }

    /// <summary>
    /// The entirety of a SOA record update as a part of parent private DNS zone update.
    /// </summary>
    public interface IUpdateSoaRecordSet :
        PrivateDnsRecordSet.Update.IWithSoaRecord,
        PrivateDnsRecordSet.Update.IUpdate
    {
    }

    /// <summary>
    /// The stage of the SOA record definition allowing to update its attributes.
    /// </summary>
    public interface IWithSoaRecord
    {
        /// <summary>
        /// Specifies the email server associated with the SOA record.
        /// </summary>
        /// <param name="emailServerHostName">The email server.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet WithEmailServer(string emailServerHostName);

        /// <summary>
        /// Specifies the time in seconds that a secondary name server will treat its cached zone file as valid
        /// when the primary name server cannot be contacted.
        /// </summary>
        /// <param name="expireTimeInSeconds">The expire time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet WithExpireTimeInSeconds(long expireTimeInSeconds);

        /// <summary>
        /// Specifies the time in seconds that any name server or resolver should cache a negative response.
        /// </summary>
        /// <param name="negativeCachingTimeToLive">The TTL for cached negative response.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet WithNegativeResponseCachingTimeToLiveInSeconds(long negativeCachingTimeToLive);

        /// <summary>
        /// Specifies time in seconds that a secondary name server should wait before trying to contact the
        /// the primary name server for a zone file update.
        /// </summary>
        /// <param name="refreshTimeInSeconds">The refresh time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet WithRefreshTimeInSeconds(long refreshTimeInSeconds);

        /// <summary>
        /// Specifies the time in seconds that a secondary name server should wait before trying to contact
        /// the primary name server again after a failed attempt to check for a zone file update.
        /// </summary>
        /// <param name="retryTimeInSeconds">The retry time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet WithRetryTimeInSeconds(long retryTimeInSeconds);

        /// <summary>
        /// Specifies the serial number for the zone file.
        /// </summary>
        /// <param name="serialNumber">The serial number.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet WithSerialNumber(long serialNumber);
    }

    /// <summary>
    /// The entirety of a SRV record update as a part of parent private DNS zone update.
    /// </summary>
    public interface IUpdateSrvRecordSet :
        PrivateDnsRecordSet.Update.IWithSrvRecord,
        PrivateDnsRecordSet.Update.IUpdate
    {
    }

    /// <summary>
    /// The stage of the SRV record definition allowing to add or remove service record.
    /// </summary>
    public interface IWithSrvRecord
    {
        /// <summary>
        /// Specifies a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host, lower the value higher the priority.</param>
        /// <param name="weight">The relative weight (preference) of the records with the same priority, higher the value more the preference.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSrvRecordSet WithRecord(string target, int port, int priority, int weight);

        /// <summary>
        /// Removes a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host.</param>
        /// <param name="weight">The relative weight (preference) of the records.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSrvRecordSet WithoutRecord(string target, int port, int priority, int weight);
    }

    /// <summary>
    /// The entirety of a TXT record update as a part of parent private DNS zone update.
    /// </summary>
    public interface IUpdateTxtRecordSet :
        PrivateDnsRecordSet.Update.IWithTxtRecord,
        PrivateDnsRecordSet.Update.IUpdate
    {
    }

    /// <summary>
    /// The stage of the Txt record definition allowing to add or remove TXT record.
    /// </summary>
    public interface IWithTxtRecord
    {
        /// <summary>
        /// Creates a Txt record with the given text in this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateTxtRecordSet WithText(string text);

        /// <summary>
        /// Removes a Txt record with the given text from this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateTxtRecordSet WithoutText(string text);

        /// <summary>
        /// Removes a Txt record with the given text (split into 255 char chunks) from this record set.
        /// </summary>
        /// <param name="textChunks">The text value as list.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateTxtRecordSet WithoutText(IList<string> textChunks);
    }
}
