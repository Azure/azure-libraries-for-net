// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;

    /// <summary>
    /// Implementation of PtrRecordSets.
    /// </summary>
    internal class PtrRecordSetsImpl :
        PrivateDnsRecordSetsBaseImpl<IPtrRecordSet, PtrRecordSetImpl>,
        IPtrRecordSets
    {
        internal PtrRecordSetsImpl(PrivateDnsZoneImpl parent)
            : base(parent, RecordType.PTR)
        {
        }

        protected override IPtrRecordSet WrapModel(RecordSetInner inner)
        {
            return inner == null ? null : new PtrRecordSetImpl(inner.Name, parent, inner);
        }
    }
}
