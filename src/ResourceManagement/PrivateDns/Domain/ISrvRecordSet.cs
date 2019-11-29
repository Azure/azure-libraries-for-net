// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an SVR (service) record set in Azure Private DNS Zone.
    /// </summary>
    public interface ISrvRecordSet :
        IPrivateDnsRecordSet
    {
        /// <summary>
        /// Gets the SRV records in this record set.
        /// </summary>
        IReadOnlyList<SrvRecord> Records { get; }
    }
}
