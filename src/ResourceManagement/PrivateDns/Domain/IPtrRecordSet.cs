// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a PTR (pointer) record set in Azure Private DNS Zone.
    /// </summary>
    public interface IPtrRecordSet :
        IPrivateDnsRecordSet
    {
        /// <summary>
        /// Gets the target domain names of PTR records in this record set.
        /// </summary>
        IReadOnlyList<string> TargetDomainNames { get; }
    }
}
