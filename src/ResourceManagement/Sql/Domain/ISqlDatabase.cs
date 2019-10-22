// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImportRequest.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Server Database.
    /// </summary>
    public interface ISqlDatabase  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase,Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.DatabaseInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlDatabase.Update.IUpdate>
    {
        /// <summary>
        /// Gets the elasticPoolName value.
        /// </summary>
        string ElasticPoolName { get; }

        /// <summary>
        /// Lists the SQL database usage metrics.
        /// </summary>
        /// <return>The SQL database usage metrics.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseUsageMetric> ListUsageMetrics();

        /// <summary>
        /// Gets the name of the region the resource is in.
        /// </summary>
        string RegionName { get; }

        /// <return>A representation of the deferred computation of all the replication links associated with this database.</return>
        Task<IReadOnlyDictionary<string, Microsoft.Azure.Management.Sql.Fluent.IReplicationLink>> ListReplicationLinksAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the edition of the Azure SQL Database.
        /// </summary>
        DatabaseEdition Edition { get; }

        /// <summary>
        /// Gets the SQL Sync Group entry point for the current database.
        /// </summary>
        SqlSyncGroupOperations.SqlSyncGroupActionsDefinition.ISqlSyncGroupActionsDefinition SyncGroups { get; }

        /// <summary>
        /// Gets an Azure SQL Database Transparent Data Encryption for this database.
        /// </summary>
        /// <return>A representation of the deferred computation of an Azure SQL Database Transparent Data Encryption for this database.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption> GetTransparentDataEncryptionAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the database from the server.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets the current Service Level Objective Id of the Azure SQL Database, this is the Id of the
        /// Service Level Objective that is currently active.
        /// </summary>
        System.Guid? CurrentServiceObjectiveId { get; }

        /// <summary>
        /// Gets the max size of the Azure SQL Database expressed in bytes.
        /// </summary>
        long MaxSizeBytes { get; }

        /// <param name="filter">An OData filter expression that describes a subset of metrics to return.</param>
        /// <return>The list of metrics for this database.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric> ListMetrics(string filter);

        /// <summary>
        /// Gets a SQL database automatic tuning state and options.
        /// </summary>
        /// <return>The SQL database automatic tuning state and options.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseAutomaticTuning GetDatabaseAutomaticTuning();

        /// <summary>
        /// Gets the defaultSecondaryLocation value.
        /// </summary>
        string DefaultSecondaryLocation { get; }

        /// <summary>
        /// Gets the collation of the Azure SQL Database.
        /// </summary>
        string Collation { get; }

        /// <summary>
        /// Gets the tags for the current SQL Database
        /// </summary>
        IReadOnlyDictionary<string, string> Tags { get; }

        /// <summary>
        /// Imports into the current database from a specified URI path; the current database must be empty.
        /// </summary>
        /// <param name="storageUri">The storage URI to use.</param>
        /// <return>Response object.</return>
        SqlDatabaseImportRequest.Definition.IWithStorageTypeAndKey ImportBacpac(string storageUri);

        /// <summary>
        /// Imports into the current database from an existing storage account and relative path; the current database must be empty.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>Response object.</return>
        SqlDatabaseImportRequest.Definition.IWithAuthenticationTypeAndLoginPassword ImportBacpac(IStorageAccount storageAccount, string containerName, string fileName);

        /// <summary>
        /// Gets the Id of the Azure SQL Database.
        /// </summary>
        string DatabaseId { get; }

        /// <return>A representation of the deferred computation of the metric definitions for this database.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition>> ListMetricDefinitionsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Asynchronously lists the SQL database usage metrics.
        /// </summary>
        /// <return>A representation of the deferred computation of this call returning the SQL database usage metrics.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseUsageMetric>> ListUsageMetricsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the recovery period start date of the Azure SQL Database. This
        /// records the start date and time when recovery is available for this
        /// Azure SQL Database.
        /// </summary>
        System.DateTime? EarliestRestoreDate { get; }

        /// <summary>
        /// Gets the name of the configured Service Level Objective of the Azure
        /// SQL Database, this is the Service Level Objective that is being
        /// applied to the Azure SQL Database.
        /// </summary>
        ServiceObjectiveName RequestedServiceObjectiveName { get; }

        /// <return>All the replication links associated with this database.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IReplicationLink> ListReplicationLinks();

        /// <summary>
        /// Gets a SQL database threat detection policy.
        /// </summary>
        /// <return>The SQL database threat detection policy for the current database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy GetThreatDetectionPolicy();

        /// <return>The list of usages (DatabaseMetrics) of this database.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric> ListUsages();

        /// <summary>
        /// Gets name of the SQL Server to which this database belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets an Azure SQL Database Transparent Data Encryption for this database.
        /// </summary>
        /// <return>An Azure SQL Database Transparent Data Encryption for this database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption GetTransparentDataEncryption();

        /// <param name="filter">An OData filter expression that describes a subset of metrics to return.</param>
        /// <return>A representation of the deferred computation of the metrics for this database.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric>> ListMetricsAsync(string filter, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The list of metric definitions for this database.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition> ListMetricDefinitions();

        /// <summary>
        /// Deletes the database asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The list of all restore points on this database.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint> ListRestorePoints();

        /// <summary>
        /// Renames the database asynchronously.
        /// </summary>
        /// <param name="newDatabaseName">The new name for the database.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> RenameAsync(string newDatabaseName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the creation date of the Azure SQL Database.
        /// </summary>
        System.DateTime? CreationDate { get; }

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string ParentId { get; }

        /// <summary>
        /// Gets the Service Level Objective of the Azure SQL Database.
        /// </summary>
        ServiceObjectiveName ServiceLevelObjective { get; }

        /// <summary>
        /// Renames the database.
        /// </summary>
        /// <param name="newDatabaseName">The new name for the database.</param>
        /// <return>The renamed SQL database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase Rename(string newDatabaseName);

        /// <return>SqlWarehouse instance for more operations.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse AsWarehouse();

        /// <summary>
        /// Begins a definition for a security alert policy.
        /// </summary>
        /// <param name="policyName">The name of the security alert policy.</param>
        /// <return>The first stage of the SqlDatabaseThreatDetectionPolicy definition.</return>
        SqlDatabaseThreatDetectionPolicy.Definition.IBlank DefineThreatDetectionPolicy(string policyName);

        /// <summary>
        /// Gets the region the resource is in.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Region { get; }

        /// <summary>
        /// Gets true if this Database is SqlWarehouse.
        /// </summary>
        bool IsDataWarehouse { get; }

        /// <return>A representation of the deferred computation of the information about service tier advisors for this database.</return>
        Task<IReadOnlyDictionary<string, Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor>> ListServiceTierAdvisorsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Exports the current database to a specified URI path.
        /// </summary>
        /// <param name="storageUri">The storage URI to use.</param>
        /// <return>Response object.</return>
        SqlDatabaseExportRequest.Definition.IWithStorageTypeAndKey ExportTo(string storageUri);

        /// <summary>
        /// Exports the current database to an existing storage account and relative path.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>Response object.</return>
        SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword ExportTo(IStorageAccount storageAccount, string containerName, string fileName);

        /// <summary>
        /// Exports the current database to a new storage account and relative path.
        /// </summary>
        /// <param name="storageAccountCreatable">A storage account to be created as part of this execution flow.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>Response object.</return>
        SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword ExportTo(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable, string containerName, string fileName);

        /// <summary>
        /// Gets the configured Service Level Objective Id of the Azure SQL
        /// Database, this is the Service Level Objective that is being applied to
        /// the Azure SQL Database.
        /// </summary>
        System.Guid? RequestedServiceObjectiveId { get; }

        /// <return>The list of all restore points on this database.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint>> ListRestorePointsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the status of the Azure SQL Database.
        /// </summary>
        string Status { get; }

        /// <return>Information about service tier advisors for the current database.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor> ListServiceTierAdvisors();
    }
}