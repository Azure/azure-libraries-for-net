// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implementation of TxtRecordSet.
    /// </summary>
    internal class TxtRecordSetImpl :
        PrivateDnsRecordSetImpl,
        ITxtRecordSet
    {
        internal TxtRecordSetImpl(string name, PrivateDnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.TXT), parent, innerModel)
        {
        }

        internal static TxtRecordSetImpl NewRecordSet(string name, PrivateDnsZoneImpl parent)
        {
            return new TxtRecordSetImpl(
                name,
                parent,
                new RecordSetInner { TxtRecords = new List<TxtRecord>() });
        }

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

        public IReadOnlyList<TxtRecord> Records
        {
            get
            {
                if (Inner.TxtRecords != null)
                {
                    return Inner.TxtRecords?.ToList();
                }
                return new List<TxtRecord>();
            }
        }
    }
}
