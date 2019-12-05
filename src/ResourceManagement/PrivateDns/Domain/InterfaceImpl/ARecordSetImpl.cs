// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of ARecordSet.
    /// </summary>
    internal class ARecordSetImpl :
        PrivateDnsRecordSetImpl,
        IARecordSet
    {
        internal ARecordSetImpl(string name, PrivateDnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.A), parent, innerModel)
        {
        }

        internal static ARecordSetImpl NewRecordSet(string name, PrivateDnsZoneImpl parent)
        {
            return new ARecordSetImpl(
                name, 
                parent, 
                new RecordSetInner { ARecords = new List<ARecord>() });
        }

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

        public IReadOnlyList<string> IPv4Addresses
        {
            get
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
}
