// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    /// <summary>
    /// An immutable client-side representation of a CNAME (canonical name) record set in Azure Private DNS Zone.
    /// </summary>
    public interface ICnameRecordSet :
        IPrivateDnsRecordSet
    {
        /// <summary>
        /// Gets the canonical name (without a terminating dot) of CName record in this record set.
        /// </summary>
        string CanonicalName { get; }
    }
}
