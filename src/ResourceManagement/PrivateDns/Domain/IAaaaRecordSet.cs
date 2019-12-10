// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a AAAA (IPv6) record set in Azure Private DNS Zone.
    /// </summary>
    public interface IAaaaRecordSet :
        IPrivateDnsRecordSet
    {
        /// <summary>
        /// Gets the IPv6 addresses of AAAA records in this record set.
        /// </summary>
        IReadOnlyList<string> IPv6Addresses { get; }
    }
}
