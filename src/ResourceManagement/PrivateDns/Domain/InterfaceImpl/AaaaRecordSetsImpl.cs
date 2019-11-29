// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;

    /// <summary>
    /// Implementation of AaaaRecordSets.
    /// </summary>
    internal class AaaaRecordSetsImpl :
        PrivateDnsRecordSetsBaseImpl<IAaaaRecordSet, AaaaRecordSetImpl>,
        IAaaaRecordSets
    {
        internal AaaaRecordSetsImpl(PrivateDnsZoneImpl privateDnsZone)
            : base(privateDnsZone, RecordType.AAAA)
        {
        }

        protected override IAaaaRecordSet WrapModel(RecordSetInner inner)
        {
            return inner == null ? null : new AaaaRecordSetImpl(inner.Name, parent, inner);
        }
    }
}
