// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of PtrRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5QdHJSZWNvcmRTZXRJbXBs
    internal partial class PtrRecordSetImpl :
        DnsRecordSetImpl,
        IPtrRecordSet
    {
        ///GENMHASH:92861CF149AF1B5720B293888EEEDA75:A233F56DB913EF6DC1BCF10C95C23CD2
        internal PtrRecordSetImpl(string name, DnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.PTR), parent, innerModel)
        {
        }

        ///GENMHASH:8ABF9B557B42803047EF280885243BA8:3A9FAA9DA036938CC040B66812450789
        internal static PtrRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent)
        {
            return new PtrRecordSetImpl(name, parent,
                new RecordSetInner
                {
                    PtrRecords = new List<PtrRecord>()
                });
        }

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:8254A32ABF739B147B00EFE318330056
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (Inner.PtrRecords != null && Inner.PtrRecords.Count > 0)
            {
                if (resource.PtrRecords == null)
                {
                    resource.PtrRecords = new List<PtrRecord>();
                }

                foreach (var record in Inner.PtrRecords)
                {
                    resource.PtrRecords.Add(record);
                }
                Inner.PtrRecords.Clear();
            }

            if (this.recordSetRemoveInfo.PtrRecords.Count > 0)
            {
                if (resource.PtrRecords != null)
                {
                    foreach (var recordToRemove in this.recordSetRemoveInfo.PtrRecords)
                    {
                        foreach (var record in resource.PtrRecords)
                        {
                            if (record.Ptrdname.Equals(recordToRemove.Ptrdname, StringComparison.OrdinalIgnoreCase))
                            {
                                resource.PtrRecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.PtrRecords.Clear();
            }
            return resource;
        }

        ///GENMHASH:0E9769D28DB5D19653E121715C77F6C8:87B8885472B9F53C36F3E59296FB7453
        public IReadOnlyList<string> TargetDomainNames()
        {
            List<string> targetDomainNames = new List<string>();
            if (Inner.PtrRecords != null)
            {
                foreach (var ptrRecord in Inner.PtrRecords)
                {
                    targetDomainNames.Add(ptrRecord.Ptrdname);
                }
            }
            return targetDomainNames;
        }
    }
}
