// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using System;

    /// <summary>
    /// Implementation of CnameRecordSet.
    /// </summary>
    internal class CnameRecordSetImpl :
        PrivateDnsRecordSetImpl,
        ICnameRecordSet
    {
        internal CnameRecordSetImpl(string name, PrivateDnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.CNAME), parent, innerModel)
        {
        }

        internal static CnameRecordSetImpl NewRecordSet(string name, PrivateDnsZoneImpl parent)
        {
            return new CnameRecordSetImpl(
                name, 
                parent,
                new RecordSetInner { CnameRecord = new CnameRecord() });
        }

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

        public string CanonicalName
        {
            get
            {
                return Inner.CnameRecord.Cname;
            }
        }
    }
}
