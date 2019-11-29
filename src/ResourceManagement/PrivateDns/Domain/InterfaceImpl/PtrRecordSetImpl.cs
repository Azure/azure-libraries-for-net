// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of PtrRecordSet.
    /// </summary>
    internal class PtrRecordSetImpl :
        PrivateDnsRecordSetImpl,
        IPtrRecordSet
    {
        internal PtrRecordSetImpl(string name, PrivateDnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.PTR), parent, innerModel)
        {
        }

        internal static PtrRecordSetImpl NewRecordSet(string name, PrivateDnsZoneImpl parent)
        {
            return new PtrRecordSetImpl(
                name,
                parent,
                new RecordSetInner { PtrRecords = new List<PtrRecord>() });
        }

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

        public IReadOnlyList<string> TargetDomainNames
        {
            get
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
}
