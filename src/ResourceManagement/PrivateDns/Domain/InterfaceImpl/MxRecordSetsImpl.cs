// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;

    /// <summary>
    /// Implementation of MxRecordSets.
    /// </summary>
    internal class MxRecordSetsImpl :
        PrivateDnsRecordSetsBaseImpl<IMxRecordSet, MxRecordSetImpl>,
        IMxRecordSets
    {
        internal MxRecordSetsImpl(PrivateDnsZoneImpl parent)
            : base(parent, RecordType.MX)
        {
        }

        protected override IMxRecordSet WrapModel(RecordSetInner inner)
        {
            return inner == null ? null : new MxRecordSetImpl(inner.Name, parent, inner);
        }
    }
}
