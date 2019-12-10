// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;

    /// <summary>
    /// Implementation of CnameRecordSets.
    /// </summary>
    internal class CnameRecordSetsImpl :
        PrivateDnsRecordSetsBaseImpl<ICnameRecordSet, CnameRecordSetImpl>,
        ICnameRecordSets
    {
        internal CnameRecordSetsImpl(PrivateDnsZoneImpl parent)
            : base(parent, RecordType.CNAME)
        {
        }

        protected override ICnameRecordSet WrapModel(RecordSetInner inner)
        {
            return inner == null ? null : new CnameRecordSetImpl(inner.Name, parent, inner);
        }
    }
}
