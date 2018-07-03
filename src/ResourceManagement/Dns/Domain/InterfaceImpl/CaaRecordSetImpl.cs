// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Dns.Fluent.Models;
    using System.Collections.Generic;

    internal partial class CaaRecordSetImpl
    {
        /// <summary>
        /// Gets the CAA records in this record set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.CaaRecord> Microsoft.Azure.Management.Dns.Fluent.ICaaRecordSet.Records
        {
            get
            {
                return this.Records();
            }
        }
    }
}