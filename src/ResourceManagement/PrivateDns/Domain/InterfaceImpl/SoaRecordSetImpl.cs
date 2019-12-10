// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using System;

    /// <summary>
    /// Implementation of SoaRecordSet.
    /// </summary>
    internal class SoaRecordSetImpl :
        PrivateDnsRecordSetImpl,
        ISoaRecordSet
    {
        internal SoaRecordSetImpl(string name, PrivateDnsZoneImpl parent, RecordSetInner innerModel)
            : base(name, Enum.GetName(typeof(RecordType), Models.RecordType.SOA), parent, innerModel)
        {
        }

        internal static SoaRecordSetImpl NewRecordSet(PrivateDnsZoneImpl parent)
        {
            return new SoaRecordSetImpl(
                "@",
                parent,
                new RecordSetInner { SoaRecord = new SoaRecord() });
        }

        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (resource.SoaRecord == null)
            {
                resource.SoaRecord = new SoaRecord();
            }

            if (Inner.SoaRecord.Email != null)
            {
                resource.SoaRecord.Email = Inner.SoaRecord.Email;
            }

            if (Inner.SoaRecord.ExpireTime != null)
            {
                resource.SoaRecord.ExpireTime = Inner.SoaRecord.ExpireTime;
            }

            if (Inner.SoaRecord.MinimumTtl != null)
            {
                resource.SoaRecord.MinimumTtl = Inner.SoaRecord.MinimumTtl;
            }

            if (Inner.SoaRecord.RefreshTime != null)
            {
                resource.SoaRecord.RefreshTime = Inner.SoaRecord.RefreshTime;
            }

            if (Inner.SoaRecord.RetryTime != null)
            {
                resource.SoaRecord.RetryTime = Inner.SoaRecord.RetryTime;
            }

            if (Inner.SoaRecord.SerialNumber != null)
            {
                resource.SoaRecord.SerialNumber = Inner.SoaRecord.SerialNumber;
            }

            Inner.SoaRecord = new SoaRecord();
            return resource;
        }

        public SoaRecord Record
        {
            get
            {
                return Inner.SoaRecord;
            }
        }
    }
}
