// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a TXT (text) record set in Azure Private DNS Zone.
    /// </summary>
    public interface ITxtRecordSet :
        IPrivateDnsRecordSet
    {
        /// <summary>
        /// Gets the TXT records in this record set.
        /// </summary>
        IReadOnlyList<TxtRecord> Records { get; }
    }
}
