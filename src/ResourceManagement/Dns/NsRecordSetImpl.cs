// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of NSRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5Oc1JlY29yZFNldEltcGw=
    internal partial class NSRecordSetImpl :
        DnsRecordSetImpl,
        INSRecordSet
    {
        ///GENMHASH:A32DA1B10AD690D0DB576BF48E9106A5:7270289553046B6B86F20D5FF6F86E21
        internal NSRecordSetImpl(string name, DnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.NS), parent, innerModel)
        {
        }

        ///GENMHASH:8ABF9B557B42803047EF280885243BA8:3B7875C9F1D55D791F7FB235348D9938
        internal static NSRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent)
        {
            return new NSRecordSetImpl(name, parent,
            new RecordSetInner
            {
                NsRecords = new List<NsRecord>()
            });
        }

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:E6E1BF61694F9FB722424D294C6DFFA4
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (Inner.NsRecords != null && Inner.NsRecords.Count > 0)
            {
                if (resource.NsRecords == null)
                {
                    resource.NsRecords = new List<NsRecord>();
                }

                foreach (var record in Inner.NsRecords)
                {
                    resource.NsRecords.Add(record);
                }
                Inner.NsRecords.Clear();
            }

            if (this.recordSetRemoveInfo.NsRecords.Count > 0)
            {
                if (resource.NsRecords != null)
                {
                    foreach (var recordToRemove in this.recordSetRemoveInfo.NsRecords)
                    {
                        foreach (var record in resource.NsRecords)
                        {
                            if (record.Nsdname.Equals(recordToRemove.Nsdname, StringComparison.OrdinalIgnoreCase))
                            {
                                resource.NsRecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.NsRecords.Clear();
            }
            return resource;
        }

        ///GENMHASH:2EBE0E253F1D6DB178F3433FF5310EA8:90C2D44162C23B74515368207322B17F
        public IReadOnlyList<string> NameServers()
        {
            List<string> nameServers = new List<string>();
            if (Inner.NsRecords != null)
            {
                foreach (var nsRecord in Inner.NsRecords)
                {
                    nameServers.Add(nsRecord.Nsdname);
                }
            }
            return nameServers;
        }
    }
}
