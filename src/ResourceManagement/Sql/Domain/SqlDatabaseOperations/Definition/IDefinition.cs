// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition
{
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System;

    /// <summary>
    /// The SQL Database definition to set a restorable dropped database as the source database.
    /// </summary>
    public interface IWithRestorableDroppedDatabase  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithRestorableDroppedDatabaseBeta
    {
    }

    /// <summary>
    /// The stage to decide whether using existing database or not.
    /// </summary>
    public interface IWithExistingDatabaseAfterElasticPool  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithImportFromAfterElasticPool,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithRestorePointDatabaseAfterElasticPool,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithSampleDatabaseAfterElasticPool,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithSourceDatabaseId,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions
    {
    }

    /// <summary>
    /// The SQL Database definition to set the collation for database.
    /// </summary>
    public interface IWithCollation 
    {
        /// <summary>
        /// Sets the collation for the SQL Database.
        /// </summary>
        /// <param name="collation">Collation to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAllOptions WithCollation(string collation);
    }

    /// <summary>
    /// The SQL Database definition to set the Max Size in Bytes for database.
    /// </summary>
    public interface IWithMaxSizeBytesAfterElasticPoolOptions 
    {
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
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions WithMaxSizeBytes(long maxSizeBytes);
    }

    /// <summary>
    /// The SQL Database definition to set a sample database as the source database.
    /// </summary>
    public interface IWithSampleDatabase  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithSampleDatabaseBeta
    {
    }

    /// <summary>
    /// A SQL Database definition with sufficient inputs to create a new
    /// SQL database in the cloud, but exposing additional optional settings to
    /// specify.
    /// </summary>
    public interface IWithCreateAllOptions  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithServiceObjective,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithEdition,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithEditionDefaults,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCollation,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithMaxSizeBytes,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateFinal
    {
    }

    /// <summary>
    /// The SQL database interface with all starting options for definition.
    /// </summary>
    public interface IWithAllDifferentOptions  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithElasticPoolName,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithRestorableDroppedDatabase,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithImportFrom,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithRestorePointDatabase,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithSampleDatabase,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithSourceDatabaseId,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAllOptions
    {
    }

    /// <summary>
    /// The SQL Database definition to set a restore point as the source database within an elastic pool.
    /// </summary>
    public interface IWithRestorePointDatabaseAfterElasticPool  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithRestorePointDatabaseAfterElasticPoolBeta
    {
    }

    /// <summary>
    /// Sets the storage key type and value to use.
    /// </summary>
    public interface IWithStorageKey  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithStorageKeyBeta
    {
    }

    /// <summary>
    /// The final stage of the SQL Database definition after the SQL Elastic Pool definition.
    /// </summary>
    public interface IWithCreateAfterElasticPoolOptions  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCollationAfterElasticPoolOptions,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithMaxSizeBytesAfterElasticPoolOptions,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateFinal
    {
    }

    /// <summary>
    /// The SQL Database definition to set the create mode for database.
    /// </summary>
    public interface IWithCreateMode 
    {
        /// <summary>
        /// Sets the create mode for the SQL Database.
        /// </summary>
        /// <param name="createMode">Create mode for the database, should not be default in this flow.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateFinal WithMode(CreateMode createMode);
    }

    /// <summary>
    /// The SQL Database definition to set the elastic pool for database.
    /// </summary>
    public interface IWithElasticPoolName  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithElasticPoolNameBeta
    {
        /// <summary>
        /// Sets the new elastic pool for the SQLDatabase, this will create a new elastic pool while creating database.
        /// </summary>
        /// <param name="sqlElasticPool">Creatable definition for new elastic pool to be created for the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool WithNewElasticPool(ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> sqlElasticPool);

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="elasticPoolName">For the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool WithExistingElasticPool(string elasticPoolName);

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="sqlElasticPool">For the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool WithExistingElasticPool(ISqlElasticPool sqlElasticPool);
    }

    /// <summary>
    /// Sets the authentication type and SQL or Active Directory administrator login and password.
    /// </summary>
    public interface IWithAuthentication  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithAuthenticationBeta
    {
    }

    /// <summary>
    /// The stage of the SQL Database rule definition allowing to specify the parent resource group, SQL server and location.
    /// </summary>
    public interface IWithSqlServer  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithSqlServerBeta
    {
    }

    /// <summary>
    /// The SQL Database definition to set the collation for database.
    /// </summary>
    public interface IWithCollationAfterElasticPoolOptions 
    {
        /// <summary>
        /// Sets the collation for the SQL Database.
        /// </summary>
        /// <param name="collation">Collation to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions WithCollation(string collation);
    }

    /// <summary>
    /// A SQL Database definition with sufficient inputs to create a new
    /// SQL Server in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreateFinal  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateFinal>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>
    {
    }

    /// <summary>
    /// The SQL Database definition to import a BACPAC file as the source database.
    /// </summary>
    public interface IWithImportFrom  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithImportFromBeta
    {
    }

    /// <summary>
    /// The SQL Database definition to set the edition for database.
    /// </summary>
    public interface IWithEdition 
    {
        /// <summary>
        /// Sets the edition for the SQL Database.
        /// </summary>
        /// <param name="edition">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAllOptions WithEdition(DatabaseEdition edition);
    }

    /// <summary>
    /// The SQL Database definition to set the edition for database with defaults.
    /// </summary>
    public interface IWithEditionDefaults  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateFinal,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithEditionDefaultsBeta
    {
    }

    /// <summary>
    /// The SQL Database definition to set the Max Size in Bytes for database.
    /// </summary>
    public interface IWithMaxSizeBytes 
    {
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
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAllOptions WithMaxSizeBytes(long maxSizeBytes);
    }

    /// <summary>
    /// Sets the storage key type and value to use.
    /// </summary>
    public interface IWithStorageKeyAfterElasticPool  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithStorageKeyAfterElasticPoolBeta
    {
    }

    /// <summary>
    /// The SQL Database definition to set a sample database as the source database within an elastic pool.
    /// </summary>
    public interface IWithSampleDatabaseAfterElasticPool  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithSampleDatabaseAfterElasticPoolBeta
    {
    }

    /// <summary>
    /// The SQL Database definition to set a restore point as the source database.
    /// </summary>
    public interface IWithRestorePointDatabase  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithRestorePointDatabaseBeta
    {
    }

    /// <summary>
    /// The SQL Database definition to set the source database id for database.
    /// </summary>
    public interface IWithSourceDatabaseId 
    {
        /// <summary>
        /// Sets the resource if of source database for the SQL Database.
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="sourceDatabaseId">Id of the source database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateMode WithSourceDatabase(string sourceDatabaseId);

        /// <summary>
        /// Sets the resource if of source database for the SQL Database.
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="sourceDatabase">Instance of the source database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateMode WithSourceDatabase(ISqlDatabase sourceDatabase);
    }

    /// <summary>
    /// The first stage of the SQL database definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithAllDifferentOptions
    {
    }

    /// <summary>
    /// The SQL Database definition to import a BACPAC file as the source database.
    /// </summary>
    public interface IWithImportFromAfterElasticPool  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithImportFromAfterElasticPoolBeta
    {
    }

    /// <summary>
    /// Sets the authentication type and SQL or Active Directory administrator login and password.
    /// </summary>
    public interface IWithAuthenticationAfterElasticPool  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithAuthenticationAfterElasticPoolBeta
    {
    }

    /// <summary>
    /// The SQL Database definition to set the service level objective.
    /// </summary>
    public interface IWithServiceObjective 
    {
        /// <summary>
        /// Sets the service level objective for the SQL Database.
        /// </summary>
        /// <param name="serviceLevelObjective">Service level objected for the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAllOptions WithServiceObjective(ServiceObjectiveName serviceLevelObjective);
    }

    /// <summary>
    /// The SQL Database definition to set a restorable dropped database as the source database.
    /// </summary>
    public interface IWithRestorableDroppedDatabaseBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a new database from a previously deleted database (see restorable dropped database).
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="restorableDroppedDatabase">The restorable dropped database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateFinal FromRestorableDroppedDatabase(ISqlRestorableDroppedDatabase restorableDroppedDatabase);
    }

    /// <summary>
    /// The SQL Database definition to set a sample database as the source database.
    /// </summary>
    public interface IWithSampleDatabaseBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="sampleName">The sample database to use as the source.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAllOptions FromSample(SampleName sampleName);
    }

    /// <summary>
    /// The SQL Database definition to set a restore point as the source database within an elastic pool.
    /// </summary>
    public interface IWithRestorePointDatabaseAfterElasticPoolBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions FromRestorePoint(IRestorePoint restorePoint);

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <param name="restorePointDateTime">Date and time to restore from.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions FromRestorePoint(IRestorePoint restorePoint, DateTime restorePointDateTime);
    }

    /// <summary>
    /// Sets the storage key type and value to use.
    /// </summary>
    public interface IWithStorageKeyBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <param name="storageAccessKey">The storage access key to use.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithAuthentication WithStorageAccessKey(string storageAccessKey);

        /// <param name="sharedAccessKey">The shared access key to use; it must be preceded with a "?.".</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithAuthentication WithSharedAccessKey(string sharedAccessKey);
    }

    /// <summary>
    /// The SQL Database definition to set the elastic pool for database.
    /// </summary>
    public interface IWithElasticPoolNameBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Begins the definition of a new SQL Elastic Pool to be added to this database parent SQL server.
        /// </summary>
        /// <param name="elasticPoolName">The name of the new SQL Elastic Pool.</param>
        /// <return>The first stage of the new SQL Elastic Pool definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IBlank<Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> DefineElasticPool(string elasticPoolName);
    }

    /// <summary>
    /// Sets the authentication type and SQL or Active Directory administrator login and password.
    /// </summary>
    public interface IWithAuthenticationBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <param name="administratorLogin">The Active Directory administrator login.</param>
        /// <param name="administratorPassword">The Active Directory administrator password.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithEditionDefaults WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword);

        /// <param name="administratorLogin">The SQL administrator login.</param>
        /// <param name="administratorPassword">The SQL administrator password.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithEditionDefaults WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword);
    }

    /// <summary>
    /// The stage of the SQL Database rule definition allowing to specify the parent resource group, SQL server and location.
    /// </summary>
    public interface IWithSqlServerBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <param name="location">The parent SQL server location.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithAllDifferentOptions WithExistingSqlServer(string resourceGroupName, string sqlServerName, string location);

        /// <summary>
        /// Sets the parent SQL server for the new SQL Database.
        /// </summary>
        /// <param name="sqlServer">The parent SQL server.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithAllDifferentOptions WithExistingSqlServer(ISqlServer sqlServer);
    }

    /// <summary>
    /// The SQL Database definition to import a BACPAC file as the source database.
    /// </summary>
    public interface IWithImportFromBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageUri">The source URI for the database to be imported.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithStorageKey ImportFrom(string storageUri);

        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithAuthentication ImportFrom(IStorageAccount storageAccount, string containerName, string fileName);
    }

    /// <summary>
    /// The SQL Database definition to set the edition for database with defaults.
    /// </summary>
    public interface IWithEditionDefaultsBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets a "Standard" edition for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithEditionDefaults WithStandardEdition(SqlDatabaseStandardServiceObjective serviceObjective);

        /// <summary>
        /// Sets a "Standard" edition and maximum storage capacity for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <param name="maxStorageCapacity">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithEditionDefaults WithStandardEdition(SqlDatabaseStandardServiceObjective serviceObjective, SqlDatabaseStandardStorage maxStorageCapacity);

        /// <summary>
        /// Sets a "Premium" edition for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithEditionDefaults WithPremiumEdition(SqlDatabasePremiumServiceObjective serviceObjective);

        /// <summary>
        /// Sets a "Premium" edition and maximum storage capacity for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <param name="maxStorageCapacity">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithEditionDefaults WithPremiumEdition(SqlDatabasePremiumServiceObjective serviceObjective, SqlDatabasePremiumStorage maxStorageCapacity);

        /// <summary>
        /// Sets a "Basic" edition for the SQL Database.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithEditionDefaults WithBasicEdition();

        /// <summary>
        /// Sets a "Basic" edition for the SQL Database.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithEditionDefaults WithBasicEdition(SqlDatabaseBasicStorage maxStorageCapacity);
    }

    /// <summary>
    /// Sets the storage key type and value to use.
    /// </summary>
    public interface IWithStorageKeyAfterElasticPoolBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <param name="storageAccessKey">The storage access key to use.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithAuthenticationAfterElasticPool WithStorageAccessKey(string storageAccessKey);

        /// <param name="sharedAccessKey">The shared access key to use; it must be preceded with a "?.".</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithAuthenticationAfterElasticPool WithSharedAccessKey(string sharedAccessKey);
    }

    /// <summary>
    /// The SQL Database definition to set a sample database as the source database within an elastic pool.
    /// </summary>
    public interface IWithSampleDatabaseAfterElasticPoolBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="sampleName">The sample database to use as the source.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions FromSample(SampleName sampleName);
    }

    /// <summary>
    /// The SQL Database definition to set a restore point as the source database.
    /// </summary>
    public interface IWithRestorePointDatabaseBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAllOptions FromRestorePoint(IRestorePoint restorePoint);

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <param name="restorePointDateTime">Date and time to restore from.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAllOptions FromRestorePoint(IRestorePoint restorePoint, DateTime restorePointDateTime);
    }

    /// <summary>
    /// The SQL Database definition to import a BACPAC file as the source database.
    /// </summary>
    public interface IWithImportFromAfterElasticPoolBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageUri">The source URI for the database to be imported.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithStorageKeyAfterElasticPool ImportFrom(string storageUri);

        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithAuthenticationAfterElasticPool ImportFrom(IStorageAccount storageAccount, string containerName, string fileName);
    }

    /// <summary>
    /// Sets the authentication type and SQL or Active Directory administrator login and password.
    /// </summary>
    public interface IWithAuthenticationAfterElasticPoolBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <param name="administratorLogin">The Active Directory administrator login.</param>
        /// <param name="administratorPassword">The Active Directory administrator password.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword);

        /// <param name="administratorLogin">The SQL administrator login.</param>
        /// <param name="administratorPassword">The SQL administrator password.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithCreateAfterElasticPoolOptions WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword);
    }
}