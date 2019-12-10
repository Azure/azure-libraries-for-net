﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    /// <summary>
    /// Entry point to A record sets in a private DNS zone.
    /// </summary>
    public interface IARecordSets :
        IPrivateDnsRecordSets<IARecordSet>
    {
    }
}
