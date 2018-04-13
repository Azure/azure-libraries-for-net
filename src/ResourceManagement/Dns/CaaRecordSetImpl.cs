// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Dns.Fluent.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implementation of CaaRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5DYWFSZWNvcmRTZXRJbXBs
    internal partial class CaaRecordSetImpl :
        DnsRecordSetImpl,
        ICaaRecordSet
    {
        ///GENMHASH:AFBEDFBC176015E810C704516E312343:85D6A5010FF9177B5375652BA9EBB48F
        internal CaaRecordSetImpl(string name, DnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.CAA), parent, innerModel)
        {
        }

        ///GENMHASH:8ABF9B557B42803047EF280885243BA8:51A1395810B6B63ACB9AAD75263C5312
        internal static CaaRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent)
        {
            return new CaaRecordSetImpl(name, parent,
                new RecordSetInner
                {
                    CaaRecords = new List<CaaRecord>()
                });
        }

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:4C25CCDE325968ECA10D0148DB18F640
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (Inner.CaaRecords != null && Inner.CaaRecords.Count > 0)
            {
                if (resource.CaaRecords == null)
                {
                    resource.CaaRecords = new List<CaaRecord>();
                }
                foreach (var record in Inner.CaaRecords)
                {
                    resource.CaaRecords.Add(record);
                }
                Inner.CaaRecords.Clear();
            }
            if (this.recordSetRemoveInfo.CaaRecords.Count > 0)
            {
                if (resource.CaaRecords != null)
                {
                    foreach (var recordToRemove in this.recordSetRemoveInfo.CaaRecords)
                    {
                        foreach (var record in resource.CaaRecords)
                        {
                            if (record.Value.Equals(recordToRemove.Value, StringComparison.OrdinalIgnoreCase)
                                && (record.Flags == recordToRemove.Flags)
                                && (record.Tag.Equals(recordToRemove.Tag, StringComparison.OrdinalIgnoreCase)))
                            {
                                resource.CaaRecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.CaaRecords.Clear();
            }
            return resource;
        }

        ///GENMHASH:4FC81B687476F8722014B0A4F98E1756:C652C60A45CDE6E59D8BD2A29AC8B0ED
        public IReadOnlyList<Models.CaaRecord> Records()
        {
            if (Inner.CaaRecords != null)
            {
                return Inner.CaaRecords?.ToList();
            }
            return new List<CaaRecord>();
        }
    }
}