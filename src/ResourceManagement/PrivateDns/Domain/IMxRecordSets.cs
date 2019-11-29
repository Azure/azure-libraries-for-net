// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    /// <summary>
    /// Entry point to MX record sets in an Azure private DNS zone.
    /// </summary>
    public interface IMxRecordSets :
        IPrivateDnsRecordSets<IMxRecordSet>
    {
    }
}
