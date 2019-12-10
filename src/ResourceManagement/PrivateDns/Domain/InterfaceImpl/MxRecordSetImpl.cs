// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of MxRecordSet.
    /// </summary>
    internal class MxRecordSetImpl :
        PrivateDnsRecordSetImpl,
        IMxRecordSet
    {
        internal MxRecordSetImpl(string name, PrivateDnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.MX), parent, innerModel)
        {
        }

        internal static MxRecordSetImpl NewRecordSet(string name, PrivateDnsZoneImpl parent)
        {
            return new MxRecordSetImpl(
                name,
                parent,
                new RecordSetInner { MxRecords = new List<MxRecord>() });
        }

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

        public IReadOnlyList<MxRecord> Records
        {
            get
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
}
