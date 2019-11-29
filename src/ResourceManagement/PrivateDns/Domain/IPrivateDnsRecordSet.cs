// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a record set in Azure Private DNS Zone.
    /// </summary>
    public interface IPrivateDnsRecordSet :
        IExternalChildResource<IPrivateDnsRecordSet, IPrivateDnsZone>,
        IHasInner<RecordSetInner>
    {
        /// <summary>
        /// Gets the etag associated with the record set.
        /// </summary>
        string ETag { get; }

        /// <summary>
        /// Gets the fully qualified domain name of the record set.
        /// </summary>
        string Fqdn { get; }

        /// <summary>
        /// Gets the flag that indicates whether record set is auto-registered 
        /// in the Private DNS zone through a virtual network link.
        /// </summary>
        bool IsAutoRegistered { get; }

        /// <summary>
        /// Gets the metadata associated with this record set.
        /// </summary>
        IReadOnlyDictionary<string, string> Metadata { get; }

        /// <summary>
        /// Gets TTL of the records in this record set.
        /// </summary>
        long TimeToLive { get; }
    }
}
