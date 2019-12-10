// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;

    /// <summary>
    /// Implementation of SrvRecordSets.
    /// </summary>
    internal class SrvRecordSetsImpl :
        PrivateDnsRecordSetsBaseImpl<ISrvRecordSet, SrvRecordSetImpl>,
        ISrvRecordSets
    {
        internal SrvRecordSetsImpl(PrivateDnsZoneImpl parent)
            : base(parent, RecordType.SRV)
        {
        }

        protected override ISrvRecordSet WrapModel(RecordSetInner inner)
        {
            return inner == null ? null : new SrvRecordSetImpl(inner.Name, parent, inner);
        }
    }
}
