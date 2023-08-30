// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using Microsoft.Azure.Management.PrivateDns.Fluent.PrivateDnsRecordSet.Definition;
    using Microsoft.Azure.Management.PrivateDns.Fluent.PrivateDnsRecordSet.Update;
    using Microsoft.Azure.Management.PrivateDns.Fluent.PrivateDnsZone.Definition;
    using Microsoft.Azure.Management.PrivateDns.Fluent.PrivateDnsRecordSet.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    

    /// <summary>
    /// Implementation of PrivateDnsRecordSet.
    /// </summary>
    internal class PrivateDnsRecordSetImpl :
        ExternalChildResource<IPrivateDnsRecordSet, RecordSetInner, IPrivateDnsZone, PrivateDnsZoneImpl>,
        IPrivateDnsRecordSet,
        IDefinition<IWithCreate>,
        IUpdateDefinition<PrivateDnsZone.Update.IUpdate>,
        IUpdateCombined
    {
        private ETagState eTagState = new ETagState();
        protected RecordSetInner recordSetRemoveInfo;
        protected RecordType type;

        internal PrivateDnsRecordSetImpl(string name, string type, PrivateDnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, parent, innerModel)
        {
            this.type = GetRecordType(type);

            recordSetRemoveInfo = new RecordSetInner
            {
                AaaaRecords = new List<AaaaRecord>(),
                ARecords = new List<ARecord>(),
                CnameRecord = new CnameRecord(),
                MxRecords = new List<MxRecord>(),
                PtrRecords = new List<PtrRecord>(),
                SoaRecord = new SoaRecord(),
                SrvRecords = new List<SrvRecord>(),
                TxtRecords = new List<TxtRecord>(),
                Metadata = new Dictionary<string, string>()
            };
        }

        internal PrivateDnsRecordSetImpl WithETagOnDelete(string eTagValue)
        {
            eTagState.WithExplicitETagCheckOnDelete(eTagValue);
            return this;
        }

        private async Task<IPrivateDnsRecordSet> CreateOrUpdateAsync(RecordSetInner resource, CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner inner = await Parent.Manager.Inner.RecordSets.CreateOrUpdateAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                RecordType(),
                Name(),
                resource,
                ifMatch: eTagState.IfMatchValueOnUpdate(resource.Etag),
                ifNoneMatch: eTagState.IfNonMatchValueOnCreate(),
                cancellationToken: cancellationToken);
            SetInner(inner);
            eTagState.Clear();
            return this;
        }

        private RecordSetInner Prepare(RecordSetInner resource)
        {
            if (this.recordSetRemoveInfo.Metadata.Count > 0)
            {
                if (resource.Metadata != null)
                {
                    foreach (var key in this.recordSetRemoveInfo.Metadata.Keys)
                    {
                        if (resource.Metadata.ContainsKey(key))
                        {
                            resource.Metadata.Remove(key);
                        }
                    }
                }
                this.recordSetRemoveInfo.Metadata.Clear();
            }

            if (Inner.Metadata != null && Inner.Metadata.Count > 0)
            {
                if (resource.Metadata == null)
                {
                    resource.Metadata = new Dictionary<string, string>();
                }

                foreach (var keyVal in Inner.Metadata)
                {
                    resource.Metadata.Add(keyVal.Key, keyVal.Value);
                }
                Inner.Metadata.Clear();
            }

            if (Inner.Ttl != null)
            {
                resource.Ttl = Inner.Ttl;
                Inner.Ttl = null;
            }
            return PrepareForUpdate(resource);
        }

        protected virtual RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            return resource;
        }

        private RecordType GetRecordType(string type)
        {
            var fullyQualifiedType = type;
            var parts = fullyQualifiedType.Split('/');
            return RecordTypeEnumExtension.ParseRecordType(parts[parts.Length - 1]).Value;
        }

        /// <summary>
        /// Gets the record type of the record set.
        /// </summary>
        public RecordType RecordType()
        {
            return type;
        }

        /// <summary>
        /// Gets the etag associated with the record set.
        /// </summary>
        public string ETag
        {
            get
            {
                return Inner.Etag;
            }
        }

        /// <summary>
        /// Gets the fully qualified domain name of the record set.
        /// </summary>
        public string Fqdn
        {
            get
            {
                return Inner.Fqdn;
            }
        }

        /// <summary>
        /// Gets the flag whether record set is auto-registered 
        /// in the Private DNS zone through a virtual network link.
        /// </summary>
        public bool IsAutoRegistered
        {
            get
            {
                return Inner.IsAutoRegistered.HasValue ? Inner.IsAutoRegistered.Value : false;
            }
        }

        /// <summary>
        /// Gets the metadata associated with this record set.
        /// </summary>
        public IReadOnlyDictionary<string, string> Metadata
        {
            get
            {
                if(Inner.Metadata == null)
                {
                    return new Dictionary<string, string>();
                }
                else
                {
                    return Inner.Metadata as Dictionary<string, string>;
                }
            }
        }

        /// <summary>
        /// Gets TTL of the records in this record set.
        /// </summary>
        public long TimeToLive
        {
            get
            {
                return Inner.Ttl.HasValue ? Inner.Ttl.Value : 0;
            }
        }

        /// <summary>
        /// Gets resource ID of the record set.
        /// </summary>
        public string Id
        {
            get
            {
                return Inner.Id;
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        PrivateDnsZone.Definition.IWithCreate ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<PrivateDnsZone.Definition.IWithCreate>.Attach()
        {
            return Parent;
        }

        public override string ChildResourceKey
        {
            get
            {
                return Name() + "_" + RecordType().ToString();
            }
        }

        public async override Task<IPrivateDnsRecordSet> CreateAsync(CancellationToken cancellationToken)
        {
            return await CreateOrUpdateAsync(Inner, cancellationToken);
        }

        public async override Task DeleteAsync(CancellationToken cancellationToken)
        {
            await Parent.Manager.Inner.RecordSets.DeleteAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                RecordType(),
                Name(),
                ifMatch: eTagState.IfMatchValueOnDelete(),
                cancellationToken: cancellationToken);
        }

        public async override Task<IPrivateDnsRecordSet> UpdateAsync(CancellationToken cancellationToken)
        {
            RecordSetInner resource = await Parent.Manager.Inner.RecordSets.GetAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                RecordType(),
                Name(),
                cancellationToken);
            resource = Prepare(resource);
            return await CreateOrUpdateAsync(resource, cancellationToken);
        }

        /// <summary>
        /// Creates a CNAME record with the provided alias.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithCnameRecordAttachable<IWithCreate> PrivateDnsRecordSet.Definition.IWithCnameRecord<PrivateDnsZone.Definition.IWithCreate>.WithAlias(string alias)
        {
            return WithAliasInternal(alias);
        }

        /// <summary>
        /// Specifies the domain name of the authoritative name server for this SOA record.
        /// </summary>
        /// <param name="domainName">The value of domain name.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<IWithCreate> PrivateDnsRecordSet.Definition.IWithSoaRecord<PrivateDnsZone.Definition.IWithCreate>.WithDomain(string domainName)
        {
            return WithDomainInternal(domainName);
        }

        /// <summary>
        /// Specifies email server host name.
        /// </summary>
        /// <param name="emailServerHostName">The name of email server host.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<IWithCreate> PrivateDnsRecordSet.Definition.IWithSoaRecord<PrivateDnsZone.Definition.IWithCreate>.WithEmailServer(string emailServerHostName)
        {
            return WithEmailServerInternal(emailServerHostName);
        }

        /// <summary>
        /// Specifies If-Match header to prevent updating existing resource.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithAttach<IWithCreate> PrivateDnsRecordSet.Definition.IWithEtagCheck<PrivateDnsZone.Definition.IWithCreate>.WithETagCheck()
        {
            return WithETagCheckInternal();
        }

        /// <summary>
        /// Specifies If-Match header needs to set to the given eTag value.
        /// </summary>
        /// <param name="eTagValue">The eTag value.</param>
        /// <return>The next stage of the update.</return>
        PrivateDnsRecordSet.Update.IUpdate PrivateDnsRecordSet.Update.IWithETagCheck.WithETagCheck(string eTagValue)
        {
            return WithETagCheckInternal(eTagValue);
        }

        /// <summary>
        /// Specifies expire time for this SOA record.
        /// </summary>
        /// <param name="expireTimeInSeconds">The value of expire time.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<IWithCreate> PrivateDnsRecordSet.Definition.IWithSoaRecord<PrivateDnsZone.Definition.IWithCreate>.WithExpireTimeInSeconds(long expireTimeInSeconds)
        {
            return WithExpireTimeInSecondsInternal(expireTimeInSeconds);
        }

        /// <summary>
        /// Creates an A record with the provided IPv4 address in this record set.
        /// </summary>
        /// <param name="ipv4Address">The IPv4 address.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithARecordAttachable<IWithCreate> PrivateDnsRecordSet.Definition.IWithARecord<PrivateDnsZone.Definition.IWithCreate>.WithIPv4Address(string ipv4Address)
        {
            return WithIPv4AddressInternal(ipv4Address);
        }

        /// <summary>
        /// Creates an AAAA record with the provided IPv6 address in this record set.
        /// </summary>
        /// <param name="ipv6Address">The IPv6 address.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithAaaaRecordAttachable<IWithCreate> PrivateDnsRecordSet.Definition.IWithAaaaRecord<PrivateDnsZone.Definition.IWithCreate>.WithIPv6Address(string ipv6Address)
        {
            return WithIPv6AddressInternal(ipv6Address);
        }

        /// <summary>
        /// Creates and assigns priority to a MX record with the provided mail exchange server in this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithMxRecordAttachable<IWithCreate> PrivateDnsRecordSet.Definition.IWithMxRecord<PrivateDnsZone.Definition.IWithCreate>.WithMailExchange(string mailExchangeHostName, int priority)
        {
            return WithMailExchangeInternal(mailExchangeHostName, priority);
        }

        /// <summary>
        /// Adds a metadata to the resource.
        /// </summary>
        /// <param name="key">The key for the metadata.</param>
        /// <param name="value">The value for the metadata.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithAttach<IWithCreate> PrivateDnsRecordSet.Definition.IWithMetadata<PrivateDnsZone.Definition.IWithCreate>.WithMetadata(string key, string value)
        {
            return WithMetadataInternal(key, value);
        }

        /// <summary>
        /// Specifies the minimum value for determining the negative caching duration.
        /// </summary>
        /// <param name="negativeCachingTimeToLive">The value of negative response caching time.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<IWithCreate> PrivateDnsRecordSet.Definition.IWithSoaRecord<PrivateDnsZone.Definition.IWithCreate>.WithNegativeResponseCachingTimeToLiveInSeconds(long negativeCachingTimeToLive)
        {
            return WithNegativeResponseCachingTimeToLiveInSecondsInternal(negativeCachingTimeToLive);
        }

        /// <summary>
        /// Removes the A record with the provided IPv4 address from the record set.
        /// </summary>
        /// <param name="ipv4Address">An IPv4 address.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateARecordSet PrivateDnsRecordSet.Update.IWithARecord.WithoutIPv4Address(string ipv4Address)
        {
            return WithoutIPv4AddressInternal(ipv4Address);
        }

        /// <summary>
        /// Removes an AAAA record with the provided IPv6 address from this record set.
        /// </summary>
        /// <param name="ipv6Address">The IPv6 address.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateAaaaRecordSet PrivateDnsRecordSet.Update.IWithAaaaRecord.WithoutIPv6Address(string ipv6Address)
        {
            return WithoutIPv6AddressInternal(ipv6Address);
        }

        /// <summary>
        /// Removes MX record with the provided mail exchange server and priority from this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateMxRecordSet PrivateDnsRecordSet.Update.IWithMxRecord.WithoutMailExchange(string mailExchangeHostName, int priority)
        {
            return WithoutMailExchangeInternal(mailExchangeHostName, priority);
        }

        /// <summary>
        /// Removes a metadata from the record set.
        /// </summary>
        /// <param name="key">The key of the metadata to remove.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdate PrivateDnsRecordSet.Update.IWithMetadata.WithoutMetadata(string key)
        {
            return WithoutMetadataInternal(key);
        }

        /// <summary>
        /// Removes a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host.</param>
        /// <param name="weight">The relative weight (preference) of the records.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSrvRecordSet PrivateDnsRecordSet.Update.IWithSrvRecord.WithoutRecord(string target, int port, int priority, int weight)
        {
            return WithoutRecordInternal(target, port, priority, weight);
        }

        /// <summary>
        /// Removes the PTR record with the provided canonical name from this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdatePtrRecordSet PrivateDnsRecordSet.Update.IWithPtrRecord.WithoutTargetDomainName(string targetDomainName)
        {
            return WithoutTargetDomainNameInternal(targetDomainName);
        }

        /// <summary>
        /// Removes a Txt record with the given text from this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateTxtRecordSet PrivateDnsRecordSet.Update.IWithTxtRecord.WithoutText(string text)
        {
            return WithoutTextInternal(text);
        }

        /// <summary>
        /// Removes a Txt record with the given text (split into 255 char chunks) from this record set.
        /// </summary>
        /// <param name="textChunks">The text value as list.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateTxtRecordSet PrivateDnsRecordSet.Update.IWithTxtRecord.WithoutText(IList<string> textChunks)
        {
            return WithoutTextInternal(textChunks);
        }

        /// <summary>
        /// Specifies a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host, lower the value higher the priority.</param>
        /// <param name="weight">The relative weight (preference) of the records with the same priority, higher the value more the preference.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSrvRecordAttachable<PrivateDnsZone.Definition.IWithCreate> PrivateDnsRecordSet.Definition.IWithSrvRecord<IWithCreate>.WithRecord(string target, int port, int priority, int weight)
        {
            return WithRecordInternal(target, port, priority, weight);
        }

        /// <summary>
        /// Specifies the refresh time for this SOA record.
        /// </summary>
        /// <param name="refreshTimeInSeconds">The value of refresh time.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<PrivateDnsZone.Definition.IWithCreate> PrivateDnsRecordSet.Definition.IWithSoaRecord<IWithCreate>.WithRefreshTimeInSeconds(long refreshTimeInSeconds)
        {
            return WithRefreshTimeInSecondsInternal(refreshTimeInSeconds);
        }

        /// <summary>
        /// Specifies the retry time for this SOA record.
        /// </summary>
        /// <param name="retryTimeInSeconds">The value of retry time.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<PrivateDnsZone.Definition.IWithCreate> PrivateDnsRecordSet.Definition.IWithSoaRecord<IWithCreate>.WithRetryTimeInSeconds(long retryTimeInSeconds)
        {
            return WithRetryTimeInSecondsInternal(retryTimeInSeconds);
        }

        /// <summary>
        /// Specifies the serial number for this SOA record.
        /// </summary>
        /// <param name="serialNumber">The value of serial number.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithSoaRecordAttachable<PrivateDnsZone.Definition.IWithCreate> PrivateDnsRecordSet.Definition.IWithSoaRecord<IWithCreate>.WithSerialNumber(long serialNumber)
        {
            return WithSerialNumberInternal(serialNumber);
        }

        /// <summary>
        /// Creates a PTR record with the provided target domain name in this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithPtrRecordAttachable<PrivateDnsZone.Definition.IWithCreate> PrivateDnsRecordSet.Definition.IWithPtrRecord<IWithCreate>.WithTargetDomainName(string targetDomainName)
        {
            return WithTargetDomainNameInternal(targetDomainName);
        }

        /// <summary>
        /// Creates a TXT record with the given text in this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithTxtRecordAttachable<PrivateDnsZone.Definition.IWithCreate> PrivateDnsRecordSet.Definition.IWithTxtRecord<IWithCreate>.WithText(string text)
        {
            return WithTextInternal(text);
        }

        /// <summary>
        /// Specifies the Time To Live for the records in the record set.
        /// </summary>
        /// <param name="ttlInSeconds">TTL in seconds.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.Definition.IWithAttach<PrivateDnsZone.Definition.IWithCreate> PrivateDnsRecordSet.Definition.IWithTtl<IWithCreate>.WithTimeToLive(long ttlInSeconds)
        {
            return WithTimeToLiveInternal(ttlInSeconds);
        }

        protected async override Task<RecordSetInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Parent.Manager.Inner.RecordSets.GetAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                RecordType(),
                Name(),
                cancellationToken);
        }

        /// <summary>
        /// The new alias for the CNAME record set.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateCnameRecordSet PrivateDnsRecordSet.Update.IWithCnameRecord.WithAlias(string alias)
        {
            return WithAliasInternal(alias);
        }

        /// <summary>
        /// Specifies the email server associated with the SOA record.
        /// </summary>
        /// <param name="emailServerHostName">The email server.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet PrivateDnsRecordSet.Update.IWithSoaRecord.WithEmailServer(string emailServerHostName)
        {
            return WithEmailServerInternal(emailServerHostName);
        }

        /// <summary>
        /// Specifies If-Match header to the current eTag value associated with the record set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        PrivateDnsRecordSet.Update.IUpdate PrivateDnsRecordSet.Update.IWithETagCheck.WithETagCheck()
        {
            return WithETagCheckInternal();
        }

        /// <summary>
        /// Specifies the time in seconds that a secondary name server will treat its cached zone file as valid
        /// when the primary name server cannot be contacted.
        /// </summary>
        /// <param name="expireTimeInSeconds">The expire time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet PrivateDnsRecordSet.Update.IWithSoaRecord.WithExpireTimeInSeconds(long expireTimeInSeconds)
        {
            return WithExpireTimeInSecondsInternal(expireTimeInSeconds);
        }

        /// <summary>
        /// Creates an A record with the provided IPv4 address in the record set.
        /// </summary>
        /// <param name="ipv4Address">An IPv4 address.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateARecordSet PrivateDnsRecordSet.Update.IWithARecord.WithIPv4Address(string ipv4Address)
        {
            return WithIPv4AddressInternal(ipv4Address);
        }

        /// <summary>
        /// Creates an AAAA record with the provided IPv6 address in this record set.
        /// </summary>
        /// <param name="ipv6Address">The IPv6 address.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateAaaaRecordSet PrivateDnsRecordSet.Update.IWithAaaaRecord.WithIPv6Address(string ipv6Address)
        {
            return WithIPv6AddressInternal(ipv6Address);
        }

        /// <summary>
        /// Creates and assigns priority to a MX record with the provided mail exchange server in this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateMxRecordSet PrivateDnsRecordSet.Update.IWithMxRecord.WithMailExchange(string mailExchangeHostName, int priority)
        {
            return WithMailExchangeInternal(mailExchangeHostName, priority);
        }

        /// <summary>
        /// Adds a metadata to the record set.
        /// </summary>
        /// <param name="key">The key for the metadata.</param>
        /// <param name="value">The value for the metadata.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdate PrivateDnsRecordSet.Update.IWithMetadata.WithMetadata(string key, string value)
        {
            return WithMetadataInternal(key, value);
        }

        /// <summary>
        /// Specifies the time in seconds that any name server or resolver should cache a negative response.
        /// </summary>
        /// <param name="negativeCachingTimeToLive">The TTL for cached negative response.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet PrivateDnsRecordSet.Update.IWithSoaRecord.WithNegativeResponseCachingTimeToLiveInSeconds(long negativeCachingTimeToLive)
        {
            return WithNegativeResponseCachingTimeToLiveInSecondsInternal(negativeCachingTimeToLive);
        }

        /// <summary>
        /// Specifies a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host, lower the value higher the priority.</param>
        /// <param name="weight">The relative weight (preference) of the records with the same priority, higher the value more the preference.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSrvRecordSet PrivateDnsRecordSet.Update.IWithSrvRecord.WithRecord(string target, int port, int priority, int weight)
        {
            return WithRecordInternal(target, port, priority, weight);
        }

        /// <summary>
        /// Specifies time in seconds that a secondary name server should wait before trying to contact the
        /// the primary name server for a zone file update.
        /// </summary>
        /// <param name="refreshTimeInSeconds">The refresh time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet PrivateDnsRecordSet.Update.IWithSoaRecord.WithRefreshTimeInSeconds(long refreshTimeInSeconds)
        {
            return WithRefreshTimeInSecondsInternal(refreshTimeInSeconds);
        }

        /// <summary>
        /// Specifies the time in seconds that a secondary name server should wait before trying to contact
        /// the primary name server again after a failed attempt to check for a zone file update.
        /// </summary>
        /// <param name="retryTimeInSeconds">The retry time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet PrivateDnsRecordSet.Update.IWithSoaRecord.WithRetryTimeInSeconds(long retryTimeInSeconds)
        {
            return WithRetryTimeInSecondsInternal(retryTimeInSeconds);
        }

        /// <summary>
        /// Specifies the serial number for the zone file.
        /// </summary>
        /// <param name="serialNumber">The serial number.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet PrivateDnsRecordSet.Update.IWithSoaRecord.WithSerialNumber(long serialNumber)
        {
            return WithSerialNumberInternal(serialNumber);
        }

        /// <summary>
        /// Creates a PTR record with the provided canonical name in this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdatePtrRecordSet PrivateDnsRecordSet.Update.IWithPtrRecord.WithTargetDomainName(string targetDomainName)
        {
            return WithTargetDomainNameInternal(targetDomainName);
        }

        /// <summary>
        /// Creates a Txt record with the given text in this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdateTxtRecordSet PrivateDnsRecordSet.Update.IWithTxtRecord.WithText(string text)
        {
            return WithTextInternal(text);
        }

        /// <summary>
        /// Specifies the TTL for the records in the record set.
        /// </summary>
        /// <param name="ttlInSeconds">TTL in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        PrivateDnsRecordSet.Update.IUpdate PrivateDnsRecordSet.Update.IWithTtl.WithTimeToLive(long ttlInSeconds)
        {
            return WithTimeToLiveInternal(ttlInSeconds);
        }

        private PrivateDnsRecordSetImpl WithAliasInternal(string alias)
        {
            Inner.CnameRecord.Cname = alias;
            return this;
        }

        private PrivateDnsRecordSetImpl WithDomainInternal(string domainName)
        {
            Inner.SoaRecord.Host = domainName;
            return this;
        }

        private PrivateDnsRecordSetImpl WithEmailServerInternal(string emailServerHostName)
        {
            Inner.SoaRecord.Email = emailServerHostName;
            return this;
        }

        private PrivateDnsRecordSetImpl WithETagCheckInternal()
        {
            eTagState.WithImplicitETagCheckOnCreate();
            eTagState.WithImplicitETagCheckOnUpdate();
            return this;
        }

        private PrivateDnsRecordSetImpl WithETagCheckInternal(string eTagValue)
        {
            eTagState.WithExplicitETagCheckOnUpdate(eTagValue);
            return this;
        }

        private PrivateDnsRecordSetImpl WithExpireTimeInSecondsInternal(long expireTimeInSeconds)
        {
            Inner.SoaRecord.ExpireTime = expireTimeInSeconds;
            return this;
        }

        private PrivateDnsRecordSetImpl WithIPv4AddressInternal(string ipv4Address)
        {
            Inner.ARecords.Add(new ARecord { Ipv4Address = ipv4Address });
            return this;
        }

        private PrivateDnsRecordSetImpl WithIPv6AddressInternal(string ipv6Address)
        {
            Inner.AaaaRecords.Add(new AaaaRecord { Ipv6Address = ipv6Address });
            return this;
        }

        private PrivateDnsRecordSetImpl WithMailExchangeInternal(string mailExchangeHostName, int priority)
        {
            Inner.MxRecords.Add(
                new MxRecord
                {
                    Exchange = mailExchangeHostName,
                    Preference = priority
                }
                );
            return this;
        }

        private PrivateDnsRecordSetImpl WithMetadataInternal(string key, string value)
        {
            if (Inner.Metadata == null)
            {
                Inner.Metadata = new Dictionary<string, string>();
            }
            if (Inner.Metadata.ContainsKey(key))
            {
                Inner.Metadata[key] = value;
            }
            else
            {
                Inner.Metadata.Add(key, value);
            }
            return this;
        }

        private PrivateDnsRecordSetImpl WithNegativeResponseCachingTimeToLiveInSecondsInternal(long negativeCachingTimeToLive)
        {
            Inner.SoaRecord.MinimumTtl = negativeCachingTimeToLive;
            return this;
        }

        private PrivateDnsRecordSetImpl WithoutIPv4AddressInternal(string ipv4Address)
        {
            recordSetRemoveInfo.ARecords.Add(new ARecord { Ipv4Address = ipv4Address });
            return this;
        }

        private PrivateDnsRecordSetImpl WithoutIPv6AddressInternal(string ipv6Address)
        {
            recordSetRemoveInfo.AaaaRecords.Add(new AaaaRecord { Ipv6Address = ipv6Address });
            return this;
        }

        private PrivateDnsRecordSetImpl WithoutMailExchangeInternal(string mailExchangeHostName, int priority)
        {
            recordSetRemoveInfo.MxRecords.Add(
                new MxRecord
                {
                    Exchange = mailExchangeHostName,
                    Preference = priority
                });
            return this;
        }

        private PrivateDnsRecordSetImpl WithoutMetadataInternal(string key)
        {
            recordSetRemoveInfo.Metadata.Add(key, null);
            return this;
        }

        private PrivateDnsRecordSetImpl WithoutRecordInternal(string target, int port, int priority, int weight)
        {
            recordSetRemoveInfo.SrvRecords.Add(
                new SrvRecord
                {
                    Target = target,
                    Port = port,
                    Priority = priority,
                    Weight = weight
                });
            return this;
        }

        private PrivateDnsRecordSetImpl WithoutTargetDomainNameInternal(string targetDomainName)
        {
            recordSetRemoveInfo.PtrRecords.Add(new PtrRecord { Ptrdname = targetDomainName });
            return this;
        }

        private PrivateDnsRecordSetImpl WithoutTextInternal(string text)
        {
            if (text == null)
            {
                return this;
            }
            List<string> chunks = new List<string>();
            chunks.Add(text);
            return WithoutTextInternal(chunks);
        }

        private PrivateDnsRecordSetImpl WithoutTextInternal(IList<string> textChunks)
        {
            recordSetRemoveInfo.TxtRecords.Add(new TxtRecord { Value = textChunks });
            return this;
        }

        private PrivateDnsRecordSetImpl WithRecordInternal(string target, int port, int priority, int weight)
        {
            Inner.SrvRecords.Add(
                new SrvRecord
                {
                    Target = target,
                    Port = port,
                    Priority = priority,
                    Weight = weight
                });
            return this;
        }

        private PrivateDnsRecordSetImpl WithRefreshTimeInSecondsInternal(long refreshTimeInSeconds)
        {
            Inner.SoaRecord.RefreshTime = refreshTimeInSeconds;
            return this;
        }

        private PrivateDnsRecordSetImpl WithRetryTimeInSecondsInternal(long retryTimeInSeconds)
        {
            Inner.SoaRecord.RetryTime = retryTimeInSeconds;
            return this;
        }

        private PrivateDnsRecordSetImpl WithSerialNumberInternal(long serialNumber)
        {
            Inner.SoaRecord.SerialNumber = serialNumber;
            return this;
        }

        private PrivateDnsRecordSetImpl WithTargetDomainNameInternal(string targetDomainName)
        {
            Inner.PtrRecords.Add(new PtrRecord { Ptrdname = targetDomainName });
            return this;
        }

        private PrivateDnsRecordSetImpl WithTextInternal(string text)
        {
            if (text == null)
            {
                return this;
            }
            List<string> value = new List<string>();
            if (text.Length < 255)
            {
                value.Add(text);
            }
            else
            {
                value.AddRange(Enumerable.Range(0, (int)(Math.Ceiling(text.Length / (double)255))).Select(i => text.Substring(i * 255, Math.Min(255, text.Length - i * 255))));
            }
            Inner.TxtRecords.Add(new TxtRecord { Value = value });
            return this;
        }

        internal PrivateDnsRecordSetImpl WithTimeToLiveInternal(long ttlInSeconds)
        {
            Inner.Ttl = ttlInSeconds;
            return this;
        }

        PrivateDnsZone.Update.IUpdate ISettable<PrivateDnsZone.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        /// <summary>
        /// Creates an A record with the provided IPv4 address in this record set.
        /// </summary>
        /// <param name="ipv4Address">The IPv4 address.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithARecordAttachable<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithARecord<PrivateDnsZone.Update.IUpdate>.WithIPv4Address(string ipv4Address)
        {
            return WithIPv4AddressInternal(ipv4Address);
        }

        /// <summary>
        /// Creates an AAAA record with the provided IPv6 address in this record set.
        /// </summary>
        /// <param name="ipv6Address">The IPv6 address.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithAaaaRecordAttachable<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithAaaaRecord<PrivateDnsZone.Update.IUpdate>.WithIPv6Address(string ipv6Address)
        {
            return WithIPv6AddressInternal(ipv6Address);
        }

        /// <summary>
        /// Creates a CNAME record with the provided alias.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithCnameRecordAttachable<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithCnameRecord<PrivateDnsZone.Update.IUpdate>.WithAlias(string alias)
        {
            return WithAliasInternal(alias);
        }

        /// <summary>
        /// Creates and assigns priority to a MX record with the provided mail exchange server in this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithMxRecordAttachable<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithMxRecord<PrivateDnsZone.Update.IUpdate>.WithMailExchange(string mailExchangeHostName, int priority)
        {
            return WithMailExchangeInternal(mailExchangeHostName, priority);
        }

        /// <summary>
        /// Creates a PTR record with the provided target domain name in this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithPtrRecordAttachable<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithPtrRecord<PrivateDnsZone.Update.IUpdate>.WithTargetDomainName(string targetDomainName)
        {
            return WithTargetDomainNameInternal(targetDomainName);
        }

        /// <summary>
        /// Specifies email server host name.
        /// </summary>
        /// <param name="emailServerHostName">The name of email server host.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithSoaRecordAttachable<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithSoaRecord<PrivateDnsZone.Update.IUpdate>.WithEmailServer(string emailServerHostName)
        {
            return WithEmailServerInternal(emailServerHostName);
        }

        /// <summary>
        /// Specifies expire time for this SOA record.
        /// </summary>
        /// <param name="expireTimeInSeconds">The value of expire time.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithSoaRecordAttachable<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithSoaRecord<PrivateDnsZone.Update.IUpdate>.WithExpireTimeInSeconds(long expireTimeInSeconds)
        {
            return WithExpireTimeInSecondsInternal(expireTimeInSeconds);
        }

        /// <summary>
        /// Specifies the domain name of the authoritative name server for this SOA record.
        /// </summary>
        /// <param name="domainName">The value of domain name.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithSoaRecordAttachable<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithSoaRecord<PrivateDnsZone.Update.IUpdate>.WithDomain(string domainName)
        {
            return WithDomainInternal(domainName);
        }

        /// <summary>
        /// Specifies the minimum value for determining the negative caching duration.
        /// </summary>
        /// <param name="negativeCachingTimeToLive">The value of negative response caching time.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithSoaRecordAttachable<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithSoaRecord<PrivateDnsZone.Update.IUpdate>.WithNegativeResponseCachingTimeToLiveInSeconds(long negativeCachingTimeToLive)
        {
            return WithNegativeResponseCachingTimeToLiveInSecondsInternal(negativeCachingTimeToLive);
        }

        /// <summary>
        /// Specifies the refresh time for this SOA record.
        /// </summary>
        /// <param name="refreshTimeInSeconds">The value of refresh time.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithSoaRecordAttachable<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithSoaRecord<PrivateDnsZone.Update.IUpdate>.WithRefreshTimeInSeconds(long refreshTimeInSeconds)
        {
            return WithRefreshTimeInSecondsInternal(refreshTimeInSeconds);
        }

        /// <summary>
        /// Specifies the retry time for this SOA record.
        /// </summary>
        /// <param name="retryTimeInSeconds">The value of retry time.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithSoaRecordAttachable<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithSoaRecord<PrivateDnsZone.Update.IUpdate>.WithRetryTimeInSeconds(long retryTimeInSeconds)
        {
            return WithRetryTimeInSecondsInternal(retryTimeInSeconds);
        }

        /// <summary>
        /// Specifies the serial number for this SOA record.
        /// </summary>
        /// <param name="serialNumber">The value of serial number.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithSoaRecordAttachable<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithSoaRecord<PrivateDnsZone.Update.IUpdate>.WithSerialNumber(long serialNumber)
        {
            return WithSerialNumberInternal(serialNumber);
        }

        /// <summary>
        /// Specifies a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host, lower the value higher the priority.</param>
        /// <param name="weight">The relative weight (preference) of the records with the same priority, higher the value more the preference.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithSrvRecordAttachable<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithSrvRecord<PrivateDnsZone.Update.IUpdate>.WithRecord(string target, int port, int priority, int weight)
        {
            return WithRecordInternal(target, port, priority, weight);
        }

        /// <summary>
        /// Creates a TXT record with the given text in this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithTxtRecordAttachable<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithTxtRecord<PrivateDnsZone.Update.IUpdate>.WithText(string text)
        {
            return WithTextInternal(text);
        }

        /// <summary>
        /// Attaches the child update to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent update.</return>
        PrivateDnsZone.Update.IUpdate IInUpdate<PrivateDnsZone.Update.IUpdate>.Attach()
        {
            return Parent;
        }

        /// <summary>
        /// Specifies the TTL for the records in the record set.
        /// </summary>
        /// <param name="ttlInSeconds">TTL in seconds.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithAttach<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithTtl<PrivateDnsZone.Update.IUpdate>.WithTimeToLive(long ttlInSeconds)
        {
            return WithTimeToLiveInternal(ttlInSeconds);
        }

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the metadata.</param>
        /// <param name="value">The value for the metadata.</param>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithAttach<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithMetadata<PrivateDnsZone.Update.IUpdate>.WithMetadata(string key, string value)
        {
            return WithMetadataInternal(key, value);
        }

        /// <summary>
        /// Specifies If-None-Match header to prevent updating an existing record set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.IWithAttach<PrivateDnsZone.Update.IUpdate> PrivateDnsRecordSet.UpdateDefinition.IWithEtagCheck<PrivateDnsZone.Update.IUpdate>.WithETagCheck()
        {
            return WithETagCheckInternal();
        }
    }
}
