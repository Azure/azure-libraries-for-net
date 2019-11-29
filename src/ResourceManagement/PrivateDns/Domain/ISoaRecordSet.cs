// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of a SOA (start of authority) record set in Azure Private DNS Zone.
    /// </summary>
    public interface ISoaRecordSet :
        IPrivateDnsRecordSet
    {
        /// <summary>
        /// Gets the SOA record in this record set.
        /// </summary>
        SoaRecord Record { get; }
    }
}
