// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implementation of SrvRecordSet.
    /// </summary>
    internal class SrvRecordSetImpl :
        PrivateDnsRecordSetImpl,
        ISrvRecordSet
    {
        internal SrvRecordSetImpl(string name, PrivateDnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.SRV), parent, innerModel)
        {
        }

        internal static SrvRecordSetImpl NewRecordSet(string name, PrivateDnsZoneImpl parent)
        {
            return new SrvRecordSetImpl(
                name,
                parent,
                new RecordSetInner { SrvRecords = new List<SrvRecord>() });
        }

        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (Inner.SrvRecords != null && Inner.SrvRecords.Count > 0)
            {
                if (resource.SrvRecords == null)
                {
                    resource.SrvRecords = new List<SrvRecord>();
                }
                foreach (var record in Inner.SrvRecords)
                {
                    resource.SrvRecords.Add(record);
                }
                Inner.SrvRecords.Clear();
            }
            if (this.recordSetRemoveInfo.SrvRecords.Count > 0)
            {
                if (resource.SrvRecords != null)
                {
                    foreach (var recordToRemove in this.recordSetRemoveInfo.SrvRecords)
                    {
                        foreach (var record in resource.SrvRecords)
                        {
                            if (record.Target.Equals(recordToRemove.Target, StringComparison.OrdinalIgnoreCase)
                                && (record.Port == recordToRemove.Port)
                                && (record.Weight == recordToRemove.Weight)
                                && (record.Priority == recordToRemove.Priority))
                            {
                                resource.SrvRecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.SrvRecords.Clear();
            }
            return resource;
        }

        public IReadOnlyList<SrvRecord> Records
        {
            get
            {
                if (Inner.SrvRecords != null)
                {
                    return Inner.SrvRecords?.ToList();
                }
                return new List<SrvRecord>();
            }
        }
    }
}
