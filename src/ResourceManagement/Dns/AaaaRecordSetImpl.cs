// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of AaaaRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5BYWFhUmVjb3JkU2V0SW1wbA==
    internal partial class AaaaRecordSetImpl :
        DnsRecordSetImpl,
        IAaaaRecordSet
    {

        ///GENMHASH:7CA2212D17685B143C68189866F4BEBE:06887305F3E645C1D9ECB817FE4BEA6C
        internal AaaaRecordSetImpl(string name, DnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.AAAA), parent, innerModel)
        {
        }

        ///GENMHASH:8ABF9B557B42803047EF280885243BA8:6ED95E38836BAF17411E66F23109BE5B
        internal static AaaaRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent)
        {
            return new AaaaRecordSetImpl(name,
                parent,
                new RecordSetInner()
                {
                    AaaaRecords = new List<AaaaRecord>()
                });
        }

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:09F5D9EDC414E52781BD92550F31253C
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (Inner.AaaaRecords != null && Inner.AaaaRecords.Count > 0)
            {
                if (resource.AaaaRecords == null)
                {
                    resource.AaaaRecords = new List<AaaaRecord>();
                }

                foreach (var record in Inner.AaaaRecords)
                {
                    resource.AaaaRecords.Add(record);
                }
                Inner.AaaaRecords.Clear();
            }

            if (this.recordSetRemoveInfo.AaaaRecords.Count > 0)
            {
                if (resource.AaaaRecords != null)
                {
                    foreach (var recordToRemove in this.recordSetRemoveInfo.AaaaRecords)
                    {
                        foreach (var record in resource.AaaaRecords)
                        {
                            if (record.Ipv6Address.Equals(recordToRemove.Ipv6Address, StringComparison.OrdinalIgnoreCase))
                            {
                                resource.AaaaRecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.AaaaRecords.Clear();
            }
            return resource;
        }

        ///GENMHASH:4E53164CA4B37A1BF907696B7858DE65:0789FFFE5FE21310241EC5F7738AE5A4
        internal IReadOnlyList<string> IPv6Addresses()
        {
            List<string> ipv6Addresses = new List<string>();
            if (Inner.AaaaRecords != null)
            {
                foreach (var aaaaRecord in Inner.AaaaRecords)
                {
                    ipv6Addresses.Add(aaaaRecord.Ipv6Address);
                }
            }
            return ipv6Addresses;
        }

    }
}
