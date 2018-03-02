// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// Response containing Azure SQL restorable dropped database.
    /// </summary>
    public interface ISqlRestorableDroppedDatabase  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.RestorableDroppedDatabaseInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId
    {
        /// <summary>
        /// Gets the elastic pool name of the database.
        /// </summary>
        string ElasticPoolName { get; }

        /// <summary>
        /// Gets the name of the database.
        /// </summary>
        string DatabaseName { get; }

        /// <summary>
        /// Gets the service level objective name of the database.
        /// </summary>
        string ServiceLevelObjective { get; }

        /// <summary>
        /// Gets the deletion date of the database (ISO8601 format).
        /// </summary>
        System.DateTime? DeletionDate { get; }

        /// <summary>
        /// Gets the max size in bytes of the database.
        /// </summary>
        string MaxSizeBytes { get; }

        /// <summary>
        /// Gets the edition of the database.
        /// </summary>
        string Edition { get; }

        /// <summary>
        /// Gets the geo-location where the resource lives.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Region { get; }

        /// <summary>
        /// Gets the creation date of the database (ISO8601 format).
        /// </summary>
        System.DateTime? CreationDate { get; }

        /// <summary>
        /// Gets the earliest restore date of the database (ISO8601 format).
        /// </summary>
        System.DateTime? EarliestRestoreDate { get; }
    }
}