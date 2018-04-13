// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Dns.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an CAA (service) record set in Azure DNS Zone.
    /// </summary>
    public interface ICaaRecordSet :
        Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet
    {

        /// <summary>
        /// Gets the CAA records in this record set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.CaaRecord> Records { get; }
    }
}