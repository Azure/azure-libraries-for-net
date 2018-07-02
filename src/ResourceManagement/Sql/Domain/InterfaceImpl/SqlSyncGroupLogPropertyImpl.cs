// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    internal partial class SqlSyncGroupLogPropertyImpl 
    {
        /// <summary>
        /// Gets operation status of the sync group log.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupLogProperty.OperationStatus
        {
            get
            {
                return this.OperationStatus();
            }
        }

        /// <summary>
        /// Gets the details of the sync group log.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupLogProperty.Details
        {
            get
            {
                return this.Details();
            }
        }

        /// <summary>
        /// Gets the type of the sync group log.
        /// </summary>
        Models.SyncGroupLogType Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupLogProperty.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Gets the source of the sync group log.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupLogProperty.Source
        {
            get
            {
                return this.Source();
            }
        }

        /// <summary>
        /// Gets timestamp of the sync group log.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupLogProperty.Timestamp
        {
            get
            {
                return this.Timestamp();
            }
        }

        /// <summary>
        /// Gets the tracing ID of the sync group log.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupLogProperty.TracingId
        {
            get
            {
                return this.TracingId();
            }
        }
    }
}