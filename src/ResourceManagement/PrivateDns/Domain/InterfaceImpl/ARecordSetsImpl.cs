// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;

    /// <summary>
    /// Implementation of ARecordSets.
    /// </summary>
    internal class ARecordSetsImpl :
        PrivateDnsRecordSetsBaseImpl<IARecordSet, ARecordSetImpl>,
        IARecordSets
    {
        internal ARecordSetsImpl(PrivateDnsZoneImpl parent)
            : base(parent, RecordType.A)
        {
        }

        protected override IARecordSet WrapModel(RecordSetInner inner)
        {
            return inner == null ? null : new ARecordSetImpl(inner.Name, parent, inner);
        }
    }
}
