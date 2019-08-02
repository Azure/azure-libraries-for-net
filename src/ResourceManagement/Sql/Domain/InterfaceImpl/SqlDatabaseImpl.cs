// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.SqlDatabaseDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImportRequest.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.SqlDatabaseOperationsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Collections.Generic;
    using System;

    internal partial class SqlDatabaseImpl 
    {
        /// <param name="storageAccessKey">The storage access key to use.</param>
        /// <return>Next definition stage.</return>
        SqlDatabase.Definition.IWithAuthenticationAfterElasticPool<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithStorageKeyAfterElasticPoolBeta<SqlServer.Definition.IWithCreate>.WithStorageAccessKey(string storageAccessKey)
        {
            return this.WithStorageAccessKey(storageAccessKey);
        }

        /// <param name="sharedAccessKey">The shared access key to use; it must be preceded with a "?.".</param>
        /// <return>Next definition stage.</return>
        SqlDatabase.Definition.IWithAuthenticationAfterElasticPool<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithStorageKeyAfterElasticPoolBeta<SqlServer.Definition.IWithCreate>.WithSharedAccessKey(string sharedAccessKey)
        {
            return this.WithSharedAccessKey(sharedAccessKey);
        }

        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageUri">The source URI for the database to be imported.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithStorageKey<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithImportFromBeta<SqlServer.Definition.IWithCreate>.ImportFrom(string storageUri)
        {
            return this.ImportFrom(storageUri);
        }

        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAuthentication<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithImportFromBeta<SqlServer.Definition.IWithCreate>.ImportFrom(IStorageAccount storageAccount, string containerName, string fileName)
        {
            return this.ImportFrom(storageAccount, containerName, fileName);
        }

        /// <summary>
        /// Sets the edition for the SQL Database.
        /// </summary>
        /// <param name="edition">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAllOptions<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithEdition<SqlServer.Definition.IWithCreate>.WithEdition(DatabaseEdition edition)
        {
            return this.WithEdition(edition);
        }

        /// <summary>
        /// Sets the max size in bytes for SQL Database.
        /// </summary>
        /// <param name="maxSizeBytes">
        /// Max size of the Azure SQL Database expressed in bytes. Note: Only
        /// the following sizes are supported (in addition to limitations being
        /// placed on each edition): { 100 MB | 500 MB |1 GB | 5 GB | 10 GB | 20
        /// GB | 30 GB … 150 GB | 200 GB … 500 GB }.
        /// </param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions SqlDatabaseOperations.Definition.IWithMaxSizeBytesAfterElasticPoolOptions.WithMaxSizeBytes(long maxSizeBytes)
        {
            return this.WithMaxSizeBytes(maxSizeBytes);
        }

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="sampleName">The sample database to use as the source.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions SqlDatabaseOperations.Definition.IWithSampleDatabaseAfterElasticPoolBeta.FromSample(SampleName sampleName)
        {
            return this.FromSample(sampleName);
        }

        /// <summary>
        /// Sets the new elastic pool for the SQLDatabase, this will create a new elastic pool while creating database.
        /// </summary>
        /// <param name="sqlElasticPool">Creatable definition for new elastic pool to be created for the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithExistingDatabaseAfterElasticPool<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithElasticPoolName<SqlServer.Definition.IWithCreate>.WithNewElasticPool(ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> sqlElasticPool)
        {
            return this.WithNewElasticPool(sqlElasticPool);
        }

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="elasticPoolName">For the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithExistingDatabaseAfterElasticPool<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithElasticPoolName<SqlServer.Definition.IWithCreate>.WithExistingElasticPool(string elasticPoolName)
        {
            return this.WithExistingElasticPool(elasticPoolName);
        }

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="sqlElasticPool">For the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithExistingDatabaseAfterElasticPool<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithElasticPoolName<SqlServer.Definition.IWithCreate>.WithExistingElasticPool(ISqlElasticPool sqlElasticPool)
        {
            return this.WithExistingElasticPool(sqlElasticPool);
        }

        /// <summary>
        /// Creates a new database from a previously deleted database (see restorable dropped database).
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="restorableDroppedDatabase">The restorable dropped database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateFinal SqlDatabaseOperations.Definition.IWithRestorableDroppedDatabaseBeta.FromRestorableDroppedDatabase(ISqlRestorableDroppedDatabase restorableDroppedDatabase)
        {
            return this.FromRestorableDroppedDatabase(restorableDroppedDatabase);
        }

        /// <summary>
        /// Sets the collation for the SQL Database.
        /// </summary>
        /// <param name="collation">Collation to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithCollationAfterElasticPoolOptions<SqlServer.Definition.IWithCreate>.WithCollation(string collation)
        {
            return this.WithCollation(collation);
        }

        /// <param name="administratorLogin">The SQL administrator login.</param>
        /// <param name="administratorPassword">The SQL administrator password.</param>
        /// <return>Next definition stage.</return>
        SqlDatabase.Definition.IWithAttachFinal<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithAuthenticationAfterElasticPoolBeta<SqlServer.Definition.IWithCreate>.WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            return this.WithSqlAdministratorLoginAndPassword(administratorLogin, administratorPassword);
        }

        /// <param name="administratorLogin">The Active Directory administrator login.</param>
        /// <param name="administratorPassword">The Active Directory administrator password.</param>
        /// <return>Next definition stage.</return>
        SqlDatabase.Definition.IWithAttachFinal<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithAuthenticationAfterElasticPoolBeta<SqlServer.Definition.IWithCreate>.WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            return this.WithActiveDirectoryLoginAndPassword(administratorLogin, administratorPassword);
        }

        /// <summary>
        /// Sets a "Basic" edition for the SQL Database.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithEditionDefaults<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithEditionDefaultsBeta<SqlServer.Definition.IWithCreate>.WithBasicEdition()
        {
            return this.WithBasicEdition();
        }

        /// <summary>
        /// Sets a "Basic" edition and maximum storage capacity for the SQL Database.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithEditionDefaults<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithEditionDefaultsBeta<SqlServer.Definition.IWithCreate>.WithBasicEdition(SqlDatabaseBasicStorage maxStorageCapacity)
        {
            return this.WithBasicEdition(maxStorageCapacity);
        }

        /// <summary>
        /// Sets a "Premium" edition for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithEditionDefaults<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithEditionDefaultsBeta<SqlServer.Definition.IWithCreate>.WithPremiumEdition(SqlDatabasePremiumServiceObjective serviceObjective)
        {
            return this.WithPremiumEdition(serviceObjective);
        }

        /// <summary>
        /// Sets a "Premium" edition and maximum storage capacity for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <param name="maxStorageCapacity">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithEditionDefaults<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithEditionDefaultsBeta<SqlServer.Definition.IWithCreate>.WithPremiumEdition(SqlDatabasePremiumServiceObjective serviceObjective, SqlDatabasePremiumStorage maxStorageCapacity)
        {
            return this.WithPremiumEdition(serviceObjective, maxStorageCapacity);
        }

        /// <summary>
        /// Sets a "Standard" edition for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithEditionDefaults<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithEditionDefaultsBeta<SqlServer.Definition.IWithCreate>.WithStandardEdition(SqlDatabaseStandardServiceObjective serviceObjective)
        {
            return this.WithStandardEdition(serviceObjective);
        }

        /// <summary>
        /// Sets a "Standard" edition and maximum storage capacity for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <param name="maxStorageCapacity">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithEditionDefaults<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithEditionDefaultsBeta<SqlServer.Definition.IWithCreate>.WithStandardEdition(SqlDatabaseStandardServiceObjective serviceObjective, SqlDatabaseStandardStorage maxStorageCapacity)
        {
            return this.WithStandardEdition(serviceObjective, maxStorageCapacity);
        }

        /// <param name="administratorLogin">The SQL administrator login.</param>
        /// <param name="administratorPassword">The SQL administrator password.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseOperations.Definition.IWithEditionDefaults SqlDatabaseOperations.Definition.IWithAuthenticationBeta.WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            return this.WithSqlAdministratorLoginAndPassword(administratorLogin, administratorPassword);
        }

        /// <param name="administratorLogin">The Active Directory administrator login.</param>
        /// <param name="administratorPassword">The Active Directory administrator password.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseOperations.Definition.IWithEditionDefaults SqlDatabaseOperations.Definition.IWithAuthenticationBeta.WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            return this.WithActiveDirectoryLoginAndPassword(administratorLogin, administratorPassword);
        }

        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageUri">The source URI for the database to be imported.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithStorageKeyAfterElasticPool<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithImportFromAfterElasticPoolBeta<SqlServer.Definition.IWithCreate>.ImportFrom(string storageUri)
        {
            return this.ImportFrom(storageUri);
        }

        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAuthenticationAfterElasticPool<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithImportFromAfterElasticPoolBeta<SqlServer.Definition.IWithCreate>.ImportFrom(IStorageAccount storageAccount, string containerName, string fileName)
        {
            return this.ImportFrom(storageAccount, containerName, fileName);
        }

        /// <summary>
        /// Gets the Service Level Objective of the Azure SQL Database.
        /// </summary>
        ServiceObjectiveName Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ServiceLevelObjective
        {
            get
            {
                return this.ServiceLevelObjective();
            }
        }

        /// <summary>
        /// Gets the elasticPoolName value.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ElasticPoolName
        {
            get
            {
                return this.ElasticPoolName();
            }
        }

        /// <return>A representation of the deferred computation of the information about service tier advisors for this database.</return>
        async Task<IReadOnlyDictionary<string, Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor>> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListServiceTierAdvisorsAsync(CancellationToken cancellationToken)
        {
            return await this.ListServiceTierAdvisorsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets a SQL database threat detection policy.
        /// </summary>
        /// <return>The SQL database threat detection policy for the current database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.GetThreatDetectionPolicy()
        {
            return this.GetThreatDetectionPolicy();
        }

        /// <summary>
        /// Gets the name of the configured Service Level Objective of the Azure
        /// SQL Database, this is the Service Level Objective that is being
        /// applied to the Azure SQL Database.
        /// </summary>
        ServiceObjectiveName Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.RequestedServiceObjectiveName
        {
            get
            {
                return this.RequestedServiceObjectiveName();
            }
        }

        /// <summary>
        /// Gets the recovery period start date of the Azure SQL Database. This
        /// records the start date and time when recovery is available for this
        /// Azure SQL Database.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.EarliestRestoreDate
        {
            get
            {
                return this.EarliestRestoreDate();
            }
        }

        /// <return>The list of usages (DatabaseMetrics) of this database.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListUsages()
        {
            return this.ListUsages();
        }

        /// <summary>
        /// Renames the database asynchronously.
        /// </summary>
        /// <param name="newDatabaseName">The new name for the database.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.RenameAsync(string newDatabaseName, CancellationToken cancellationToken)
        {
            return await this.RenameAsync(newDatabaseName, cancellationToken);
        }

        /// <param name="filter">An OData filter expression that describes a subset of metrics to return.</param>
        /// <return>A representation of the deferred computation of the metrics for this database.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric>> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListMetricsAsync(string filter, CancellationToken cancellationToken)
        {
            return await this.ListMetricsAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Gets the name of the region the resource is in.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.RegionName
        {
            get
            {
                return this.RegionName();
            }
        }

        /// <summary>
        /// Gets the SQL Sync Group entry point for the current database.
        /// </summary>
        SqlSyncGroupOperations.SqlSyncGroupActionsDefinition.ISqlSyncGroupActionsDefinition Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.SyncGroups
        {
            get
            {
                return this.SyncGroups();
            }
        }

        /// <summary>
        /// Deletes the database asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.DeleteAsync(CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(cancellationToken);
        }

        /// <return>The list of all restore points on this database.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListRestorePoints()
        {
            return this.ListRestorePoints();
        }

        /// <return>All the replication links associated with this database.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IReplicationLink> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListReplicationLinks()
        {
            return this.ListReplicationLinks();
        }

        /// <summary>
        /// Exports the current database to a specified URI path.
        /// </summary>
        /// <param name="storageUri">The storage URI to use.</param>
        /// <return>Response object.</return>
        SqlDatabaseExportRequest.Definition.IWithStorageTypeAndKey Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ExportTo(string storageUri)
        {
            return this.ExportTo(storageUri);
        }

        /// <summary>
        /// Exports the current database to an existing storage account and relative path.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>Response object.</return>
        SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ExportTo(IStorageAccount storageAccount, string containerName, string fileName)
        {
            return this.ExportTo(storageAccount, containerName, fileName);
        }

        /// <summary>
        /// Exports the current database to a new storage account and relative path.
        /// </summary>
        /// <param name="storageAccountCreatable">A storage account to be created as part of this execution flow.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>Response object.</return>
        SqlDatabaseExportRequest.Definition.IWithAuthenticationTypeAndLoginPassword Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ExportTo(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable, string containerName, string fileName)
        {
            return this.ExportTo(storageAccountCreatable, containerName, fileName);
        }

        /// <return>The list of metric definitions for this database.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListMetricDefinitions()
        {
            return this.ListMetricDefinitions();
        }

        /// <summary>
        /// Renames the database.
        /// </summary>
        /// <param name="newDatabaseName">The new name for the database.</param>
        /// <return>The renamed SQL database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.Rename(string newDatabaseName)
        {
            return this.Rename(newDatabaseName);
        }

        /// <param name="filter">An OData filter expression that describes a subset of metrics to return.</param>
        /// <return>The list of metrics for this database.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListMetrics(string filter)
        {
            return this.ListMetrics(filter);
        }

        /// <summary>
        /// Gets the status of the Azure SQL Database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// Gets an Azure SQL Database Transparent Data Encryption for this database.
        /// </summary>
        /// <return>An Azure SQL Database Transparent Data Encryption for this database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.GetTransparentDataEncryption()
        {
            return this.GetTransparentDataEncryption();
        }

        /// <summary>
        /// Gets the configured Service Level Objective Id of the Azure SQL
        /// Database, this is the Service Level Objective that is being applied to
        /// the Azure SQL Database.
        /// </summary>
        System.Guid? Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.RequestedServiceObjectiveId
        {
            get
            {
                return this.RequestedServiceObjectiveId();
            }
        }

        /// <summary>
        /// Gets a SQL database automatic tuning state and options.
        /// </summary>
        /// <return>The SQL database automatic tuning state and options.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseAutomaticTuning Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.GetDatabaseAutomaticTuning()
        {
            return this.GetDatabaseAutomaticTuning();
        }

        /// <summary>
        /// Gets the current Service Level Objective Id of the Azure SQL Database, this is the Id of the
        /// Service Level Objective that is currently active.
        /// </summary>
        System.Guid? Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.CurrentServiceObjectiveId
        {
            get
            {
                return this.CurrentServiceObjectiveId();
            }
        }

        /// <return>Information about service tier advisors for the current database.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListServiceTierAdvisors()
        {
            return this.ListServiceTierAdvisors();
        }

        /// <summary>
        /// Gets true if this Database is SqlWarehouse.
        /// </summary>
        bool Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.IsDataWarehouse
        {
            get
            {
                return this.IsDataWarehouse();
            }
        }

        /// <summary>
        /// Gets the region the resource is in.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.Region
        {
            get
            {
                return this.Region();
            }
        }

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ParentId
        {
            get
            {
                return this.ParentId();
            }
        }

        /// <return>A representation of the deferred computation of the metric definitions for this database.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition>> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListMetricDefinitionsAsync(CancellationToken cancellationToken)
        {
            return await this.ListMetricDefinitionsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the defaultSecondaryLocation value.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.DefaultSecondaryLocation
        {
            get
            {
                return this.DefaultSecondaryLocation();
            }
        }

        /// <summary>
        /// Begins a definition for a security alert policy.
        /// </summary>
        /// <param name="policyName">The name of the security alert policy.</param>
        /// <return>The first stage of the SqlDatabaseThreatDetectionPolicy definition.</return>
        SqlDatabaseThreatDetectionPolicy.Definition.IBlank Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.DefineThreatDetectionPolicy(string policyName)
        {
            return this.DefineThreatDetectionPolicy(policyName);
        }

        /// <summary>
        /// Gets the collation of the Azure SQL Database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.Collation
        {
            get
            {
                return this.Collation();
            }
        }

        /// <summary>
        /// Gets the tags for the current SQL Database
        /// </summary>
        IReadOnlyDictionary<string, string> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.Tags
        {
            get
            {
                return this.Tags();
            }
        }

        /// <summary>
        /// Gets the Id of the Azure SQL Database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.DatabaseId
        {
            get
            {
                return this.DatabaseId();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this database belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Gets an Azure SQL Database Transparent Data Encryption for this database.
        /// </summary>
        /// <return>A representation of the deferred computation of an Azure SQL Database Transparent Data Encryption for this database.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.GetTransparentDataEncryptionAsync(CancellationToken cancellationToken)
        {
            return await this.GetTransparentDataEncryptionAsync(cancellationToken);
        }

        /// <return>The list of all restore points on this database.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint>> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListRestorePointsAsync(CancellationToken cancellationToken)
        {
            return await this.ListRestorePointsAsync(cancellationToken);
        }

        /// <summary>
        /// Imports into the current database from a specified URI path; the current database must be empty.
        /// </summary>
        /// <param name="storageUri">The storage URI to use.</param>
        /// <return>Response object.</return>
        SqlDatabaseImportRequest.Definition.IWithStorageTypeAndKey Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ImportBacpac(string storageUri)
        {
            return this.ImportBacpac(storageUri);
        }

        /// <summary>
        /// Imports into the current database from an existing storage account and relative path; the current database must be empty.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>Response object.</return>
        SqlDatabaseImportRequest.Definition.IWithAuthenticationTypeAndLoginPassword Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ImportBacpac(IStorageAccount storageAccount, string containerName, string fileName)
        {
            return this.ImportBacpac(storageAccount, containerName, fileName);
        }

        /// <return>A representation of the deferred computation of all the replication links associated with this database.</return>
        async Task<IReadOnlyDictionary<string, Microsoft.Azure.Management.Sql.Fluent.IReplicationLink>> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListReplicationLinksAsync(CancellationToken cancellationToken)
        {
            return await this.ListReplicationLinksAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the max size of the Azure SQL Database expressed in bytes.
        /// </summary>
        long Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.MaxSizeBytes
        {
            get
            {
                return this.MaxSizeBytes();
            }
        }

        /// <summary>
        /// Asynchronously lists the SQL database usage metrics.
        /// </summary>
        /// <return>A representation of the deferred computation of this call returning the SQL database usage metrics.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseUsageMetric>> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListUsageMetricsAsync(CancellationToken cancellationToken)
        {
            return await this.ListUsageMetricsAsync(cancellationToken);
        }

        /// <summary>
        /// Deletes the database from the server.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.Delete()
        {
 
            this.Delete();
        }

        /// <summary>
        /// Gets the edition of the Azure SQL Database.
        /// </summary>
        DatabaseEdition Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.Edition
        {
            get
            {
                return this.Edition();
            }
        }

        /// <summary>
        /// Lists the SQL database usage metrics.
        /// </summary>
        /// <return>The SQL database usage metrics.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseUsageMetric> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListUsageMetrics()
        {
            return this.ListUsageMetrics();
        }

        /// <summary>
        /// Gets the creation date of the Azure SQL Database.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.CreationDate
        {
            get
            {
                return this.CreationDate();
            }
        }

        /// <return>SqlWarehouse instance for more operations.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.AsWarehouse()
        {
            return this.AsWarehouse();
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <param name="storageAccessKey">The storage access key to use.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseOperations.Definition.IWithAuthenticationAfterElasticPool SqlDatabaseOperations.Definition.IWithStorageKeyAfterElasticPoolBeta.WithStorageAccessKey(string storageAccessKey)
        {
            return this.WithStorageAccessKey(storageAccessKey);
        }

        /// <param name="sharedAccessKey">The shared access key to use; it must be preceded with a "?.".</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseOperations.Definition.IWithAuthenticationAfterElasticPool SqlDatabaseOperations.Definition.IWithStorageKeyAfterElasticPoolBeta.WithSharedAccessKey(string sharedAccessKey)
        {
            return this.WithSharedAccessKey(sharedAccessKey);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        SqlServer.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<SqlServer.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <param name="administratorLogin">The SQL administrator login.</param>
        /// <param name="administratorPassword">The SQL administrator password.</param>
        /// <return>Next definition stage.</return>
        SqlDatabase.Definition.IWithAttachAllOptions<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithAuthenticationBeta<SqlServer.Definition.IWithCreate>.WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            return this.WithSqlAdministratorLoginAndPassword(administratorLogin, administratorPassword);
        }

        /// <param name="administratorLogin">The Active Directory administrator login.</param>
        /// <param name="administratorPassword">The Active Directory administrator password.</param>
        /// <return>Next definition stage.</return>
        SqlDatabase.Definition.IWithAttachAllOptions<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithAuthenticationBeta<SqlServer.Definition.IWithCreate>.WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            return this.WithActiveDirectoryLoginAndPassword(administratorLogin, administratorPassword);
        }

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="sampleName">The sample database to use as the source.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAllOptions<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithSampleDatabaseBeta<SqlServer.Definition.IWithCreate>.FromSample(SampleName sampleName)
        {
            return this.FromSample(sampleName);
        }

        /// <summary>
        /// Sets the new elastic pool for the SQLDatabase, this will create a new elastic pool while creating database.
        /// </summary>
        /// <param name="sqlElasticPool">Creatable definition for new elastic pool to be created for the SQL Database.</param>
        /// <return>The next stage of the update.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithElasticPoolName.WithNewElasticPool(ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> sqlElasticPool)
        {
            return this.WithNewElasticPool(sqlElasticPool);
        }

        /// <summary>
        /// Removes database from it's elastic pool.
        /// </summary>
        /// <return>The next stage of the update.</return>
        SqlDatabase.Update.IWithEdition SqlDatabase.Update.IWithElasticPoolName.WithoutElasticPool()
        {
            return this.WithoutElasticPool();
        }

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="elasticPoolName">For the SQL Database.</param>
        /// <return>The next stage of the update.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithElasticPoolName.WithExistingElasticPool(string elasticPoolName)
        {
            return this.WithExistingElasticPool(elasticPoolName);
        }

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="sqlElasticPool">For the SQL Database.</param>
        /// <return>The next stage of the update.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithElasticPoolName.WithExistingElasticPool(ISqlElasticPool sqlElasticPool)
        {
            return this.WithExistingElasticPool(sqlElasticPool);
        }

        /// <summary>
        /// Begins the definition of a new SQL Elastic Pool to be added to this database parent SQL server.
        /// </summary>
        /// <param name="elasticPoolName">The name of the new SQL Elastic Pool.</param>
        /// <return>The first stage of the new SQL Elastic Pool definition.</return>
        SqlElasticPool.Definition.IBlank<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlDatabaseOperations.Definition.IWithElasticPoolNameBeta.DefineElasticPool(string elasticPoolName)
        {
            return this.DefineElasticPool(elasticPoolName);
        }

        /// <summary>
        /// Sets the new elastic pool for the SQLDatabase, this will create a new elastic pool while creating database.
        /// </summary>
        /// <param name="sqlElasticPool">Creatable definition for new elastic pool to be created for the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool SqlDatabaseOperations.Definition.IWithElasticPoolName.WithNewElasticPool(ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> sqlElasticPool)
        {
            return this.WithNewElasticPool(sqlElasticPool);
        }

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="elasticPoolName">For the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool SqlDatabaseOperations.Definition.IWithElasticPoolName.WithExistingElasticPool(string elasticPoolName)
        {
            return this.WithExistingElasticPool(elasticPoolName);
        }

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="sqlElasticPool">For the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool SqlDatabaseOperations.Definition.IWithElasticPoolName.WithExistingElasticPool(ISqlElasticPool sqlElasticPool)
        {
            return this.WithExistingElasticPool(sqlElasticPool);
        }

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAllOptions<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithRestorePointDatabaseBeta<SqlServer.Definition.IWithCreate>.FromRestorePoint(IRestorePoint restorePoint)
        {
            return this.FromRestorePoint(restorePoint);
        }

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <param name="restorePointDateTime">Date and time to restore from.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAllOptions<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithRestorePointDatabaseBeta<SqlServer.Definition.IWithCreate>.FromRestorePoint(IRestorePoint restorePoint, DateTime restorePointDateTime)
        {
            return this.FromRestorePoint(restorePoint, restorePointDateTime);
        }

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateAllOptions SqlDatabaseOperations.Definition.IWithRestorePointDatabaseBeta.FromRestorePoint(IRestorePoint restorePoint)
        {
            return this.FromRestorePoint(restorePoint);
        }

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <param name="restorePointDateTime">Date and time to restore from.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateAllOptions SqlDatabaseOperations.Definition.IWithRestorePointDatabaseBeta.FromRestorePoint(IRestorePoint restorePoint, DateTime restorePointDateTime)
        {
            return this.FromRestorePoint(restorePoint, restorePointDateTime);
        }

        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageUri">The source URI for the database to be imported.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithStorageKey SqlDatabaseOperations.Definition.IWithImportFromBeta.ImportFrom(string storageUri)
        {
            return this.ImportFrom(storageUri);
        }

        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithAuthentication SqlDatabaseOperations.Definition.IWithImportFromBeta.ImportFrom(IStorageAccount storageAccount, string containerName, string fileName)
        {
            return this.ImportFrom(storageAccount, containerName, fileName);
        }

        /// <summary>
        /// Sets the create mode for the SQL Database.
        /// </summary>
        /// <param name="createMode">Create mode for the database, should not be default in this flow.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateFinal SqlDatabaseOperations.Definition.IWithCreateMode.WithMode(CreateMode createMode)
        {
            return this.WithMode(createMode);
        }

        /// <summary>
        /// Creates a new database from a previously deleted database (see restorable dropped database).
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="restorableDroppedDatabase">The restorable dropped database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachFinal<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithRestorableDroppedDatabaseBeta<SqlServer.Definition.IWithCreate>.FromRestorableDroppedDatabase(ISqlRestorableDroppedDatabase restorableDroppedDatabase)
        {
            return this.FromRestorableDroppedDatabase(restorableDroppedDatabase);
        }

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="sampleName">The sample database to use as the source.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithSampleDatabaseAfterElasticPoolBeta<SqlServer.Definition.IWithCreate>.FromSample(SampleName sampleName)
        {
            return this.FromSample(sampleName);
        }

        /// <summary>
        /// Sets the service level objective for the SQL Database.
        /// </summary>
        /// <param name="serviceLevelObjective">Service level objected for the SQL Database.</param>
        /// <return>The next stage of the update.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithServiceObjective.WithServiceObjective(ServiceObjectiveName serviceLevelObjective)
        {
            return this.WithServiceObjective(serviceLevelObjective);
        }

        /// <summary>
        /// Sets the service level objective for the SQL Database.
        /// </summary>
        /// <param name="serviceLevelObjective">Service level objected for the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateAllOptions SqlDatabaseOperations.Definition.IWithServiceObjective.WithServiceObjective(ServiceObjectiveName serviceLevelObjective)
        {
            return this.WithServiceObjective(serviceLevelObjective);
        }

        /// <summary>
        /// Sets a "Basic" edition for the SQL Database.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithEditionDefaults SqlDatabaseOperations.Definition.IWithEditionDefaultsBeta.WithBasicEdition()
        {
            return this.WithBasicEdition();
        }

        /// <summary>
        /// Sets a "Basic" edition for the SQL Database.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithEditionDefaults SqlDatabaseOperations.Definition.IWithEditionDefaultsBeta.WithBasicEdition(SqlDatabaseBasicStorage maxStorageCapacity)
        {
            return this.WithBasicEdition(maxStorageCapacity);
        }

        /// <summary>
        /// Sets a "Premium" edition for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithEditionDefaults SqlDatabaseOperations.Definition.IWithEditionDefaultsBeta.WithPremiumEdition(SqlDatabasePremiumServiceObjective serviceObjective)
        {
            return this.WithPremiumEdition(serviceObjective);
        }

        /// <summary>
        /// Sets a "Premium" edition and maximum storage capacity for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <param name="maxStorageCapacity">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithEditionDefaults SqlDatabaseOperations.Definition.IWithEditionDefaultsBeta.WithPremiumEdition(SqlDatabasePremiumServiceObjective serviceObjective, SqlDatabasePremiumStorage maxStorageCapacity)
        {
            return this.WithPremiumEdition(serviceObjective, maxStorageCapacity);
        }

        /// <summary>
        /// Sets a "Standard" edition for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithEditionDefaults SqlDatabaseOperations.Definition.IWithEditionDefaultsBeta.WithStandardEdition(SqlDatabaseStandardServiceObjective serviceObjective)
        {
            return this.WithStandardEdition(serviceObjective);
        }

        /// <summary>
        /// Sets a "Standard" edition and maximum storage capacity for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <param name="maxStorageCapacity">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithEditionDefaults SqlDatabaseOperations.Definition.IWithEditionDefaultsBeta.WithStandardEdition(SqlDatabaseStandardServiceObjective serviceObjective, SqlDatabaseStandardStorage maxStorageCapacity)
        {
            return this.WithStandardEdition(serviceObjective, maxStorageCapacity);
        }

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithRestorePointDatabaseAfterElasticPoolBeta<SqlServer.Definition.IWithCreate>.FromRestorePoint(IRestorePoint restorePoint)
        {
            return this.FromRestorePoint(restorePoint);
        }

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <param name="restorePointDateTime">Date and time to restore from.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithRestorePointDatabaseAfterElasticPoolBeta<SqlServer.Definition.IWithCreate>.FromRestorePoint(IRestorePoint restorePoint, DateTime restorePointDateTime)
        {
            return this.FromRestorePoint(restorePoint, restorePointDateTime);
        }

        /// <summary>
        /// Sets the service level objective for the SQL Database.
        /// </summary>
        /// <param name="serviceLevelObjective">Service level objected for the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAllOptions<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithServiceObjective<SqlServer.Definition.IWithCreate>.WithServiceObjective(ServiceObjectiveName serviceLevelObjective)
        {
            return this.WithServiceObjective(serviceLevelObjective);
        }

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateFinal Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateFinal>.WithTag(string key, string value)
        {
            return this.WithTag(key, value);
        }

        /// <summary>
        /// Specifies tags for the resource as a  Map.
        /// </summary>
        /// <param name="tags">A  Map of tags.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateFinal Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateFinal>.WithTags(IDictionary<string,string> tags)
        {
            return this.WithTags(tags);
        }

        /// <summary>
        /// Sets the resource if of source database for the SQL Database.
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="sourceDatabaseId">Id of the source database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithCreateMode<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithSourceDatabaseId<SqlServer.Definition.IWithCreate>.WithSourceDatabase(string sourceDatabaseId)
        {
            return this.WithSourceDatabase(sourceDatabaseId);
        }

        /// <summary>
        /// Sets the resource if of source database for the SQL Database.
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="sourceDatabase">Instance of the source database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithCreateMode<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithSourceDatabaseId<SqlServer.Definition.IWithCreate>.WithSourceDatabase(ISqlDatabase sourceDatabase)
        {
            return this.WithSourceDatabase(sourceDatabase);
        }

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions SqlDatabaseOperations.Definition.IWithRestorePointDatabaseAfterElasticPoolBeta.FromRestorePoint(IRestorePoint restorePoint)
        {
            return this.FromRestorePoint(restorePoint);
        }

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <param name="restorePointDateTime">Date and time to restore from.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions SqlDatabaseOperations.Definition.IWithRestorePointDatabaseAfterElasticPoolBeta.FromRestorePoint(IRestorePoint restorePoint, DateTime restorePointDateTime)
        {
            return this.FromRestorePoint(restorePoint, restorePointDateTime);
        }

        /// <summary>
        /// Sets the collation for the SQL Database.
        /// </summary>
        /// <param name="collation">Collation to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAllOptions<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithCollation<SqlServer.Definition.IWithCreate>.WithCollation(string collation)
        {
            return this.WithCollation(collation);
        }

        /// <param name="storageAccessKey">The storage access key to use.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseOperations.Definition.IWithAuthentication SqlDatabaseOperations.Definition.IWithStorageKeyBeta.WithStorageAccessKey(string storageAccessKey)
        {
            return this.WithStorageAccessKey(storageAccessKey);
        }

        /// <param name="sharedAccessKey">The shared access key to use; it must be preceded with a "?.".</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseOperations.Definition.IWithAuthentication SqlDatabaseOperations.Definition.IWithStorageKeyBeta.WithSharedAccessKey(string sharedAccessKey)
        {
            return this.WithSharedAccessKey(sharedAccessKey);
        }

        /// <summary>
        /// Sets the max size in bytes for SQL Database.
        /// </summary>
        /// <param name="maxSizeBytes">
        /// Max size of the Azure SQL Database expressed in bytes. Note: Only
        /// the following sizes are supported (in addition to limitations being
        /// placed on each edition): { 100 MB | 500 MB |1 GB | 5 GB | 10 GB | 20
        /// GB | 30 GB … 150 GB | 200 GB … 500 GB }.
        /// </param>
        /// <return>The next stage of the update.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithMaxSizeBytes.WithMaxSizeBytes(long maxSizeBytes)
        {
            return this.WithMaxSizeBytes(maxSizeBytes);
        }

        /// <summary>
        /// Sets the max size in bytes for SQL Database.
        /// </summary>
        /// <param name="maxSizeBytes">
        /// Max size of the Azure SQL Database expressed in bytes. Note: Only
        /// the following sizes are supported (in addition to limitations being
        /// placed on each edition): { 100 MB | 500 MB |1 GB | 5 GB | 10 GB | 20
        /// GB | 30 GB … 150 GB | 200 GB … 500 GB }.
        /// </param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateAllOptions SqlDatabaseOperations.Definition.IWithMaxSizeBytes.WithMaxSizeBytes(long maxSizeBytes)
        {
            return this.WithMaxSizeBytes(maxSizeBytes);
        }

        /// <summary>
        /// Sets the resource if of source database for the SQL Database.
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="sourceDatabaseId">Id of the source database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateMode SqlDatabaseOperations.Definition.IWithSourceDatabaseId.WithSourceDatabase(string sourceDatabaseId)
        {
            return this.WithSourceDatabase(sourceDatabaseId);
        }

        /// <summary>
        /// Sets the resource if of source database for the SQL Database.
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="sourceDatabase">Instance of the source database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateMode SqlDatabaseOperations.Definition.IWithSourceDatabaseId.WithSourceDatabase(ISqlDatabase sourceDatabase)
        {
            return this.WithSourceDatabase(sourceDatabase);
        }

        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <param name="location">The parent SQL server location.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithAllDifferentOptions SqlDatabaseOperations.Definition.IWithSqlServerBeta.WithExistingSqlServer(string resourceGroupName, string sqlServerName, string location)
        {
            return this.WithExistingSqlServer(resourceGroupName, sqlServerName, location);
        }

        /// <summary>
        /// Sets the parent SQL server for the new SQL Database.
        /// </summary>
        /// <param name="sqlServer">The parent SQL server.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithAllDifferentOptions SqlDatabaseOperations.Definition.IWithSqlServerBeta.WithExistingSqlServer(ISqlServer sqlServer)
        {
            return this.WithExistingSqlServer(sqlServer);
        }

        /// <summary>
        /// Sets the create mode for the SQL Database.
        /// </summary>
        /// <param name="createMode">Create mode for the database, should not be default in this flow.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachFinal<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithCreateMode<SqlServer.Definition.IWithCreate>.WithMode(CreateMode createMode)
        {
            return this.WithMode(createMode);
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        SqlDatabase.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlDatabase.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Sets the collation for the SQL Database.
        /// </summary>
        /// <param name="collation">Collation to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions SqlDatabaseOperations.Definition.IWithCollationAfterElasticPoolOptions.WithCollation(string collation)
        {
            return this.WithCollation(collation);
        }

        /// <summary>
        /// Sets the edition for the SQL Database.
        /// </summary>
        /// <param name="edition">Edition to be set for database.</param>
        /// <return>The next stage of the update.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithEdition.WithEdition(DatabaseEdition edition)
        {
            return this.WithEdition(edition);
        }

        /// <summary>
        /// Sets a "Basic" edition for the SQL Database.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithEditionBeta.WithBasicEdition()
        {
            return this.WithBasicEdition();
        }

        /// <summary>
        /// Sets a "Basic" edition and maximum storage capacity for the SQL Database.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithEditionBeta.WithBasicEdition(SqlDatabaseBasicStorage maxStorageCapacity)
        {
            return this.WithBasicEdition(maxStorageCapacity);
        }

        /// <summary>
        /// Sets a "Premium" edition for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithEditionBeta.WithPremiumEdition(SqlDatabasePremiumServiceObjective serviceObjective)
        {
            return this.WithPremiumEdition(serviceObjective);
        }

        /// <summary>
        /// Sets a "Premium" edition and maximum storage capacity for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <param name="maxStorageCapacity">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithEditionBeta.WithPremiumEdition(SqlDatabasePremiumServiceObjective serviceObjective, SqlDatabasePremiumStorage maxStorageCapacity)
        {
            return this.WithPremiumEdition(serviceObjective, maxStorageCapacity);
        }

        /// <summary>
        /// Sets a "Standard" edition for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithEditionBeta.WithStandardEdition(SqlDatabaseStandardServiceObjective serviceObjective)
        {
            return this.WithStandardEdition(serviceObjective);
        }

        /// <summary>
        /// Sets a "Standard" edition and maximum storage capacity for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <param name="maxStorageCapacity">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithEditionBeta.WithStandardEdition(SqlDatabaseStandardServiceObjective serviceObjective, SqlDatabaseStandardStorage maxStorageCapacity)
        {
            return this.WithStandardEdition(serviceObjective, maxStorageCapacity);
        }

        /// <summary>
        /// Sets the edition for the SQL Database.
        /// </summary>
        /// <param name="edition">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateAllOptions SqlDatabaseOperations.Definition.IWithEdition.WithEdition(DatabaseEdition edition)
        {
            return this.WithEdition(edition);
        }

        /// <summary>
        /// Sets the collation for the SQL Database.
        /// </summary>
        /// <param name="collation">Collation to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateAllOptions SqlDatabaseOperations.Definition.IWithCollation.WithCollation(string collation)
        {
            return this.WithCollation(collation);
        }

        /// <summary>
        /// Sets the max size in bytes for SQL Database.
        /// </summary>
        /// <param name="maxSizeBytes">
        /// Max size of the Azure SQL Database expressed in bytes. Note: Only
        /// the following sizes are supported (in addition to limitations being
        /// placed on each edition): { 100 MB | 500 MB |1 GB | 5 GB | 10 GB | 20
        /// GB | 30 GB … 150 GB | 200 GB … 500 GB }.
        /// </param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAllOptions<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithMaxSizeBytes<SqlServer.Definition.IWithCreate>.WithMaxSizeBytes(long maxSizeBytes)
        {
            return this.WithMaxSizeBytes(maxSizeBytes);
        }

        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageUri">The source URI for the database to be imported.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithStorageKeyAfterElasticPool SqlDatabaseOperations.Definition.IWithImportFromAfterElasticPoolBeta.ImportFrom(string storageUri)
        {
            return this.ImportFrom(storageUri);
        }

        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithAuthenticationAfterElasticPool SqlDatabaseOperations.Definition.IWithImportFromAfterElasticPoolBeta.ImportFrom(IStorageAccount storageAccount, string containerName, string fileName)
        {
            return this.ImportFrom(storageAccount, containerName, fileName);
        }

        /// <summary>
        /// Removes a tag from the resource.
        /// </summary>
        /// <param name="key">The key of the tag to remove.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update.IUpdate>.WithoutTag(string key)
        {
            return this.WithoutTag(key);
        }

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update.IUpdate>.WithTag(string key, string value)
        {
            return this.WithTag(key, value);
        }

        /// <summary>
        /// Specifies tags for the resource as a  Map.
        /// </summary>
        /// <param name="tags">A  Map of tags.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update.IUpdate>.WithTags(IDictionary<string,string> tags)
        {
            return this.WithTags(tags);
        }

        /// <param name="administratorLogin">The SQL administrator login.</param>
        /// <param name="administratorPassword">The SQL administrator password.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions SqlDatabaseOperations.Definition.IWithAuthenticationAfterElasticPoolBeta.WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            return this.WithSqlAdministratorLoginAndPassword(administratorLogin, administratorPassword);
        }

        /// <param name="administratorLogin">The Active Directory administrator login.</param>
        /// <param name="administratorPassword">The Active Directory administrator password.</param>
        /// <return>Next definition stage.</return>
        SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions SqlDatabaseOperations.Definition.IWithAuthenticationAfterElasticPoolBeta.WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            return this.WithActiveDirectoryLoginAndPassword(administratorLogin, administratorPassword);
        }

        /// <param name="storageAccessKey">The storage access key to use.</param>
        /// <return>Next definition stage.</return>
        SqlDatabase.Definition.IWithAuthentication<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithStorageKeyBeta<SqlServer.Definition.IWithCreate>.WithStorageAccessKey(string storageAccessKey)
        {
            return this.WithStorageAccessKey(storageAccessKey);
        }

        /// <param name="sharedAccessKey">The shared access key to use; it must be preceded with a "?.".</param>
        /// <return>Next definition stage.</return>
        SqlDatabase.Definition.IWithAuthentication<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithStorageKeyBeta<SqlServer.Definition.IWithCreate>.WithSharedAccessKey(string sharedAccessKey)
        {
            return this.WithSharedAccessKey(sharedAccessKey);
        }

        /// <summary>
        /// Sets the max size in bytes for SQL Database.
        /// </summary>
        /// <param name="maxSizeBytes">
        /// Max size of the Azure SQL Database expressed in bytes. Note: Only
        /// the following sizes are supported (in addition to limitations being
        /// placed on each edition): { 100 MB | 500 MB |1 GB | 5 GB | 10 GB | 20
        /// GB | 30 GB … 150 GB | 200 GB … 500 GB }.
        /// </param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<SqlServer.Definition.IWithCreate> SqlDatabase.Definition.IWithMaxSizeBytesAfterElasticPoolOptions<SqlServer.Definition.IWithCreate>.WithMaxSizeBytes(long maxSizeBytes)
        {
            return this.WithMaxSizeBytes(maxSizeBytes);
        }

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="sampleName">The sample database to use as the source.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseOperations.Definition.IWithCreateAllOptions SqlDatabaseOperations.Definition.IWithSampleDatabaseBeta.FromSample(SampleName sampleName)
        {
            return this.FromSample(sampleName);
        }
    }
}