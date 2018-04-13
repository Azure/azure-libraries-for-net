// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Server Sync Group.
    /// </summary>
    public interface ISqlSyncGroupLogProperty  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SyncGroupLogProperties>
    {
        /// <summary>
        /// Gets the tracing ID of the sync group log.
        /// </summary>
        string TracingId { get; }

        /// <summary>
        /// Gets operation status of the sync group log.
        /// </summary>
        string OperationStatus { get; }

        /// <summary>
        /// Gets the details of the sync group log.
        /// </summary>
        string Details { get; }

        /// <summary>
        /// Gets the source of the sync group log.
        /// </summary>
        string Source { get; }

        /// <summary>
        /// Gets the type of the sync group log.
        /// </summary>
        Models.SyncGroupLogType Type { get; }

        /// <summary>
        /// Gets timestamp of the sync group log.
        /// </summary>
        System.DateTime? Timestamp { get; }
    }
}