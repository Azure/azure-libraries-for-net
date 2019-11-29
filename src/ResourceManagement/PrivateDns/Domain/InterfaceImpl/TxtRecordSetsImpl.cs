// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;

    /// <summary>
    /// Implementation of TxtRecordSets.
    /// </summary>
    internal class TxtRecordSetsImpl :
        PrivateDnsRecordSetsBaseImpl<ITxtRecordSet, TxtRecordSetImpl>,
        ITxtRecordSets
    {
        internal TxtRecordSetsImpl(PrivateDnsZoneImpl parent)
            : base(parent, RecordType.TXT)
        {
        }

        protected override ITxtRecordSet WrapModel(RecordSetInner inner)
        {
            return inner == null ? null : new TxtRecordSetImpl(inner.Name, parent, inner);
        }
    }
}
