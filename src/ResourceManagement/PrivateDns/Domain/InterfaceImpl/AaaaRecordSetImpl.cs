// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of AaaaRecordSet.
    /// </summary>
    internal class AaaaRecordSetImpl :
        PrivateDnsRecordSetImpl,
        IAaaaRecordSet
    {
        internal AaaaRecordSetImpl(string name, PrivateDnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.AAAA), parent, innerModel)
        {
        }

        internal static AaaaRecordSetImpl NewRecordSet(string name, PrivateDnsZoneImpl parent)
        {
            return new AaaaRecordSetImpl(
                name,
                parent,
                new RecordSetInner { AaaaRecords = new List<AaaaRecord>() }
                );
        }

        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (Inner.AaaaRecords != null && Inner.AaaaRecords.Count > 0)
            {
                if (resource.AaaaRecords == null)
                {
                    resource.AaaaRecords = new List<AaaaRecord>();
                }

                foreach (var record in Inner.AaaaRecords)
                {
                    resource.AaaaRecords.Add(record);
                }
                Inner.AaaaRecords.Clear();
            }

            if (this.recordSetRemoveInfo.AaaaRecords.Count > 0)
            {
                if (resource.AaaaRecords != null)
                {
                    foreach (var recordToRemove in this.recordSetRemoveInfo.AaaaRecords)
                    {
                        foreach (var record in resource.AaaaRecords)
                        {
                            if (record.Ipv6Address.Equals(recordToRemove.Ipv6Address, StringComparison.OrdinalIgnoreCase))
                            {
                                resource.AaaaRecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.AaaaRecords.Clear();
            }
            return resource;
        }

        IReadOnlyList<string> IAaaaRecordSet.IPv6Addresses
        {
            get
            {
                List<string> ipv6Addresses = new List<string>();
                if (Inner.AaaaRecords != null)
                {
                    foreach (var aaaaRecord in Inner.AaaaRecords)
                    {
                        ipv6Addresses.Add(aaaaRecord.Ipv6Address);
                    }
                }
                return ipv6Addresses;
            }
        }
    }
}
