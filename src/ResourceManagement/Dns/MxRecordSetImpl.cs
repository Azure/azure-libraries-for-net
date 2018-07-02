// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of MXRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5NeFJlY29yZFNldEltcGw=
    internal partial class MXRecordSetImpl :
        DnsRecordSetImpl,
        IMXRecordSet
    {

        ///GENMHASH:8C062CAD2CB6B3A3EB1A20739BD955B8:5205B04345D2FBE96BA2D2EEA5D0B4B0
        internal MXRecordSetImpl(string name, DnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.MX), parent, innerModel)
        {
        }

        ///GENMHASH:8ABF9B557B42803047EF280885243BA8:022D9C60C58262185036CF6D6C366BCA
        internal static MXRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent)
        {
            return new MXRecordSetImpl(name, parent,
                new RecordSetInner
                {
                    MxRecords = new List<MxRecord>()
                });
        }

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:3DADD08418376111AE3468B0B95AA093
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (Inner.MxRecords != null && Inner.MxRecords.Count > 0)
            {
                if (resource.MxRecords == null)
                {
                    resource.MxRecords = new List<MxRecord>();
                }

                foreach (var record in Inner.MxRecords)
                {
                    resource.MxRecords.Add(record);
                }
                Inner.MxRecords.Clear();
            }

            if (this.recordSetRemoveInfo.MxRecords.Count > 0)
            {
                if (resource.MxRecords != null)
                {
                    foreach (var recordToRemove in this.recordSetRemoveInfo.MxRecords)
                    {
                        foreach (var record in resource.MxRecords)
                        {
                            if (record.Exchange.Equals(recordToRemove.Exchange, StringComparison.OrdinalIgnoreCase)
                                && (record.Preference == recordToRemove.Preference))
                            {
                                resource.MxRecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.MxRecords.Clear();
            }
            return resource;
        }

        ///GENMHASH:4FC81B687476F8722014B0A4F98E1756:27B32B5AC9D0BA9549BAC568D5725266
        public IReadOnlyList<MxRecord> Records()
        {
            List<MxRecord> records = new List<MxRecord>();
            if (Inner.MxRecords != null)
            {
                foreach (MxRecord record in Inner.MxRecords)
                {
                    records.Add(new MxRecord
                    {
                        Preference = record.Preference,
                        Exchange = record.Exchange
                    });
                }
            }
            return records;
        }
    }
}
