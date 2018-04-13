// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Implementation for SqlSyncGroup.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTeW5jRnVsbFNjaGVtYVByb3BlcnR5SW1wbA==
    internal partial class SqlSyncFullSchemaPropertyImpl  :
        Wrapper<Models.SyncFullSchemaProperties>,
        ISqlSyncFullSchemaProperty
    {
        ///GENMHASH:D9C1BCA6B7E1DBD64A3AFC44CF889C32:C0C35E00AF4E17F141675A2C05C7067B
        internal SqlSyncFullSchemaPropertyImpl(SyncFullSchemaProperties innerObject)
            : base(innerObject)
        {
        }

        ///GENMHASH:076577B471DF79F3276FF729D186FAA0:268B2BEF09E9F28438E1F124208F1D3B
        public IReadOnlyList<Models.SyncFullSchemaTable> Tables()
        {
            return this.Inner.Tables != null ? new List<Models.SyncFullSchemaTable>(this.Inner.Tables).AsReadOnly() : new List<Models.SyncFullSchemaTable>().AsReadOnly();
        }

        ///GENMHASH:20F1A3672E9A255AC53A408D27A42B92:DC625EF0FFFB071AC4E4B4515C1C0145
        public DateTime? LastUpdateTime()
        {
            return this.Inner.LastUpdateTime;
        }
    }
}