// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Dns.Fluent.Models;
using System;

namespace Microsoft.Azure.Management.Dns.Fluent
{
    /// <summary>
    /// Implementation of CNameRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5DbmFtZVJlY29yZFNldEltcGw=
    internal partial class CNameRecordSetImpl :
        DnsRecordSetImpl,
        ICNameRecordSet
    {

        ///GENMHASH:2FAAC2E68CA201E834513D95AF3AB0E9:800ED21D063D1854C18CE481A01079EB
        internal CNameRecordSetImpl(string name, DnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.CNAME), parent, innerModel)
        {
        }

        ///GENMHASH:8ABF9B557B42803047EF280885243BA8:4AE55D0B92E4F80757DBF4938ADDE5C3
        internal static CNameRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent)
        {
            return new CNameRecordSetImpl(name, parent,
            new RecordSetInner
            {
                CnameRecord = new CnameRecord()
            });
        }

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:AF11C8A7E2B299112E3CED7714F622A7
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (resource.CnameRecord == null)
            {
                resource.CnameRecord = new CnameRecord();
            }
            if (Inner.CnameRecord.Cname != null)
            {
                resource.CnameRecord.Cname = Inner.CnameRecord.Cname;
            }
            return resource;
        }


        ///GENMHASH:90659807B6B17ED9B2E619F2F74829BA:5F97BB0D1B58FFF4810D8B3F037EC111
        public string CanonicalName()
        {
            if (Inner.CnameRecord != null)
            {
                return Inner.CnameRecord.Cname;
            }
            return null;
        }
    }
}
