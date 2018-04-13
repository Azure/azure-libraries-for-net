// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implementation of TxtRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5UeHRSZWNvcmRTZXRJbXBs
    internal partial class TxtRecordSetImpl :
        DnsRecordSetImpl,
        ITxtRecordSet
    {
        ///GENMHASH:BCDFEFE12CEE04070A4BEFF0946CAA2C:51674516D8D4498FBB083895496288A6
        internal TxtRecordSetImpl(string name, DnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.TXT), parent, innerModel)
        {
        }

        ///GENMHASH:8ABF9B557B42803047EF280885243BA8:E3F7C8F53700022EA914AF1C82CAD188
        internal static TxtRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent)
        {
            return new TxtRecordSetImpl(name, parent,
            new RecordSetInner
            {
                TxtRecords = new List<TxtRecord>()
            });
        }

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:EE1172F9D1290826C7FCCEB7011C5DBF
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (Inner.TxtRecords != null && Inner.TxtRecords.Count > 0)
            {
                if (resource.TxtRecords == null)
                {
                    resource.TxtRecords = new List<TxtRecord>();
                }

                foreach (var record in Inner.TxtRecords)
                {
                    resource.TxtRecords.Add(record);
                }

                Inner.TxtRecords.Clear();
            }

            if (this.recordSetRemoveInfo.TxtRecords.Count > 0)
            {
                if (resource.TxtRecords != null)
                {
                    foreach (var recordToRemove in this.recordSetRemoveInfo.TxtRecords)
                    {
                        foreach (var record in resource.TxtRecords)
                        {
                            if (record.Value.Count != 0 && record.Value[0].Equals(recordToRemove.Value[0], StringComparison.OrdinalIgnoreCase))
                            {
                                resource.TxtRecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.TxtRecords.Clear();
            }
            return resource;
        }

        ///GENMHASH:4FC81B687476F8722014B0A4F98E1756:271F0595F800257FBA25E945FA53FCF5
        public IReadOnlyList<TxtRecord> Records()
        {
            if (Inner.TxtRecords != null)
            {
                return Inner.TxtRecords?.ToList();
            }
            return new List<TxtRecord>();
        }
    }
}
