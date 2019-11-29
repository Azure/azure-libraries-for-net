// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;

    /// <summary>
    /// Implementation of SoaRecordSets.
    /// </summary>
    internal class SoaRecordSetsImpl :
        PrivateDnsRecordSetsBaseImpl<ISoaRecordSet, SoaRecordSetImpl>,
        ISoaRecordSets
    {
        internal SoaRecordSetsImpl(PrivateDnsZoneImpl parent)
            : base(parent, RecordType.SOA)
        {
        }

        protected override ISoaRecordSet WrapModel(RecordSetInner inner)
        {
            return inner == null ? null : new SoaRecordSetImpl(inner.Name, parent, inner);
        }
    }
}
