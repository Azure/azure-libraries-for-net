// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Server Sync Group.
    /// </summary>
    public interface ISqlSyncFullSchemaProperty  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SyncFullSchemaProperties>
    {
        /// <summary>
        /// Gets the list of tables in the database full schema.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.SyncFullSchemaTable> Tables { get; }

        /// <summary>
        /// Gets last update time of the database schema.
        /// </summary>
        System.DateTime? LastUpdateTime { get; }
    }
}