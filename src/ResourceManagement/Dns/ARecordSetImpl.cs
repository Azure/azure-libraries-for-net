// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of ARecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5BUmVjb3JkU2V0SW1wbA==
    internal partial class ARecordSetImpl :
        DnsRecordSetImpl,
        IARecordSet
    {

        ///GENMHASH:4136E00FD2D74B5CCF6653A06CCE195E:90FA9D38445FC1A7EA8298AA2C095642
        internal ARecordSetImpl(string name, DnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.A), parent, innerModel)
        {
        }

        ///GENMHASH:8ABF9B557B42803047EF280885243BA8:ED2AFC67A333CA63D9D3750D1F57797C
        internal static ARecordSetImpl NewRecordSet(string name, DnsZoneImpl parent)
        {
            return new ARecordSetImpl(name, parent,
                new RecordSetInner
                {
                    ARecords = new List<ARecord>()
                });
        }

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:BFFE923AC1A74C33749D31F3CABB1EA2
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (Inner.ARecords != null && Inner.ARecords.Count > 0)
            {
                if (resource.ARecords == null)
                {
                    resource.ARecords = new List<ARecord>();
                }
                foreach (var record in Inner.ARecords)
                {
                    resource.ARecords.Add(record);
                }
                Inner.ARecords.Clear();
            }

            if (this.recordSetRemoveInfo.ARecords.Count > 0)
            {
                if (resource.ARecords != null)
                {
                    foreach (var recordToRemove in this.recordSetRemoveInfo.ARecords)
                    {
                        foreach (var record in resource.ARecords)
                        {
                            if (record.Ipv4Address.Equals(recordToRemove.Ipv4Address, System.StringComparison.OrdinalIgnoreCase))
                            {
                                resource.ARecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.ARecords.Clear();
            }
            return resource;
        }

        ///GENMHASH:04586DB2C8D9E7DB2F3AB47785D5A15A:F328364702E41F21DD4388BDA9FC5770
        public IReadOnlyList<string> IPv4Addresses()
        {
            List<string> ipv4Addresses = new List<string>();
            if (Inner.ARecords != null)
            {
                foreach (var aRecord in Inner.ARecords)
                {
                    ipv4Addresses.Add(aRecord.Ipv4Address);
                }
            }
            return ipv4Addresses;
        }
    }
}
