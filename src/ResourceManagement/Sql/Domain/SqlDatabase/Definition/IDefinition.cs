// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition
{
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using System;

    /// <summary>
    /// The SQL Database definition to set a restore point as the source database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithRestorePointDatabase<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithRestorePointDatabaseBeta<ParentT>
    {
    }

    /// <summary>
    /// The SQL Database definition to set the source database id for database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSourceDatabaseId<ParentT> 
    {
        /// <summary>
        /// Sets the resource if of source database for the SQL Database.
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="sourceDatabaseId">Id of the source database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithCreateMode<ParentT> WithSourceDatabase(string sourceDatabaseId);

        /// <summary>
        /// Sets the resource if of source database for the SQL Database.
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="sourceDatabase">Instance of the source database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithCreateMode<ParentT> WithSourceDatabase(ISqlDatabase sourceDatabase);
    }

    /// <summary>
    /// The final stage of the SQL Database definition after the SQL Elastic Pool definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttachAfterElasticPoolOptions<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithCollationAfterElasticPoolOptions<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithMaxSizeBytesAfterElasticPoolOptions<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachFinal<ParentT>
    {
    }

    /// <summary>
    /// The SQL Database definition to set the service level objective.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithServiceObjective<ParentT> 
    {
        /// <summary>
        /// Sets the service level objective for the SQL Database.
        /// </summary>
        /// <param name="serviceLevelObjective">Service level objected for the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAllOptions<ParentT> WithServiceObjective(ServiceObjectiveName serviceLevelObjective);
    }

    /// <summary>
    /// The SQL Database definition to set a sample database as the source database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSampleDatabase<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithSampleDatabaseBeta<ParentT>
    {
    }

    /// <summary>
    /// The SQL Database definition to import a BACPAC file as the source database within an elastic pool.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithImportFromAfterElasticPool<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithImportFromAfterElasticPoolBeta<ParentT>
    {
    }

    /// <summary>
    /// The SQL Database definition to set the edition for database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithEdition<ParentT> 
    {
        /// <summary>
        /// Sets the edition for the SQL Database.
        /// </summary>
        /// <param name="edition">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAllOptions<ParentT> WithEdition(DatabaseEdition edition);
    }

    /// <summary>
    /// The SQL Database definition to set a restore point as the source database within an elastic pool.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithRestorePointDatabaseAfterElasticPool<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithRestorePointDatabaseAfterElasticPoolBeta<ParentT>
    {
    }

    /// <summary>
    /// The first stage of the SQL Server Firewall rule definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAllDifferentOptions<ParentT>
    {
    }

    /// <summary>
    /// The SQL Database definition to import a BACPAC file as the source database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithImportFrom<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithImportFromBeta<ParentT>
    {
    }

    /// <summary>
    /// The SQL Database definition to set a sample database as the source database within an elastic pool.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSampleDatabaseAfterElasticPool<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithSampleDatabaseAfterElasticPoolBeta<ParentT>
    {
    }

    /// <summary>
    /// The SQL Database definition to set the Max Size in Bytes for database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithMaxSizeBytes<ParentT> 
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
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAllOptions<ParentT> WithMaxSizeBytes(long maxSizeBytes);
    }

    /// <summary>
    /// The SQL Database definition to set the Max Size in Bytes for database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithMaxSizeBytesAfterElasticPoolOptions<ParentT> 
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
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<ParentT> WithMaxSizeBytes(long maxSizeBytes);
    }

    /// <summary>
    /// The SQL Database definition to set the edition default for database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithEditionDefaults<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachFinal<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithEditionDefaultsBeta<ParentT>
    {
    }

    /// <summary>
    /// The SQL Database definition to set a restorable dropped database as the source database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithRestorableDroppedDatabase<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithRestorableDroppedDatabaseBeta<ParentT>
    {
    }

    /// <summary>
    /// The stage to decide whether using existing database or not.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithExistingDatabaseAfterElasticPool<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithImportFromAfterElasticPool<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithRestorePointDatabaseAfterElasticPool<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithSampleDatabaseAfterElasticPool<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithSourceDatabaseId<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<ParentT>
    {
    }

    /// <summary>
    /// Sets the storage key type and value to use.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStorageKeyAfterElasticPool<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithStorageKeyAfterElasticPoolBeta<ParentT>
    {
    }

    /// <summary>
    /// Sets the authentication type and SQL or Active Directory administrator login and password.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAuthenticationAfterElasticPool<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAuthenticationAfterElasticPoolBeta<ParentT>
    {
    }

    /// <summary>
    /// The SQL Database definition to set the elastic pool for database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithElasticPoolName<ParentT> 
    {
        /// <summary>
        /// Sets the new elastic pool for the SQLDatabase, this will create a new elastic pool while creating database.
        /// </summary>
        /// <param name="sqlElasticPool">Creatable definition for new elastic pool to be created for the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithExistingDatabaseAfterElasticPool<ParentT> WithNewElasticPool(ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> sqlElasticPool);

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="elasticPoolName">For the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithExistingDatabaseAfterElasticPool<ParentT> WithExistingElasticPool(string elasticPoolName);

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="sqlElasticPool">For the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithExistingDatabaseAfterElasticPool<ParentT> WithExistingElasticPool(ISqlElasticPool sqlElasticPool);
    }

    /// <summary>
    /// The SQL Database definition to set the create mode for database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCreateMode<ParentT> 
    {
        /// <summary>
        /// Sets the create mode for the SQL Database.
        /// </summary>
        /// <param name="createMode">Create mode for the database, should not be default in this flow.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachFinal<ParentT> WithMode(CreateMode createMode);
    }

    /// <summary>
    /// The final stage of the SQL Database definition with all the other options.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttachAllOptions<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithServiceObjective<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithEdition<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithEditionDefaults<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithCollation<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithMaxSizeBytes<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachFinal<ParentT>
    {
    }

    /// <summary>
    /// Sets the storage key type and value to use.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStorageKey<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithStorageKeyBeta<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the SQL Database definition.
    /// At this stage, any remaining optional settings can be specified, or the SQL Database definition
    /// can be attached to the parent SQL Server definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttachFinal<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }

    /// <summary>
    /// Sets the authentication type and SQL or Active Directory administrator login and password.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAuthentication<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAuthenticationBeta<ParentT>
    {
    }

    /// <summary>
    /// The SQL database interface with all starting options for definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAllDifferentOptions<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithElasticPoolName<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithRestorableDroppedDatabase<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithImportFrom<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithRestorePointDatabase<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithSampleDatabase<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithSourceDatabaseId<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithEditionDefaults<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAllOptions<ParentT>
    {
    }

    /// <summary>
    /// The SQL Database definition to set the collation for database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCollationAfterElasticPoolOptions<ParentT> 
    {
        /// <summary>
        /// Sets the collation for the SQL Database.
        /// </summary>
        /// <param name="collation">Collation to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<ParentT> WithCollation(string collation);
    }

    /// <summary>
    /// The SQL Database definition to set the collation for database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCollation<ParentT> 
    {
        /// <summary>
        /// Sets the collation for the SQL Database.
        /// </summary>
        /// <param name="collation">Collation to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAllOptions<ParentT> WithCollation(string collation);
    }

    /// <summary>
    /// The SQL Database definition to set a restore point as the source database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithRestorePointDatabaseBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAllOptions<ParentT> FromRestorePoint(IRestorePoint restorePoint);

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <param name="restorePointDateTime">Date and time to restore from.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAllOptions<ParentT> FromRestorePoint(IRestorePoint restorePoint, DateTime restorePointDateTime);
    }

    /// <summary>
    /// The SQL Database definition to set a sample database as the source database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSampleDatabaseBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="sampleName">The sample database to use as the source.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAllOptions<ParentT> FromSample(SampleName sampleName);
    }

    /// <summary>
    /// The SQL Database definition to import a BACPAC file as the source database within an elastic pool.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithImportFromAfterElasticPoolBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageUri">The source URI for the database to be imported.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithStorageKeyAfterElasticPool<ParentT> ImportFrom(string storageUri);

        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAuthenticationAfterElasticPool<ParentT> ImportFrom(IStorageAccount storageAccount, string containerName, string fileName);
    }

    /// <summary>
    /// The SQL Database definition to set a restore point as the source database within an elastic pool.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithRestorePointDatabaseAfterElasticPoolBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<ParentT> FromRestorePoint(IRestorePoint restorePoint);

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <param name="restorePointDateTime">Date and time to restore from.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<ParentT> FromRestorePoint(IRestorePoint restorePoint, DateTime restorePointDateTime);
    }

    /// <summary>
    /// The SQL Database definition to import a BACPAC file as the source database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithImportFromBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageUri">The source URI for the database to be imported.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithStorageKey<ParentT> ImportFrom(string storageUri);

        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAuthentication<ParentT> ImportFrom(IStorageAccount storageAccount, string containerName, string fileName);
    }

    /// <summary>
    /// The SQL Database definition to set a sample database as the source database within an elastic pool.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSampleDatabaseAfterElasticPoolBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="sampleName">The sample database to use as the source.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<ParentT> FromSample(SampleName sampleName);
    }

    /// <summary>
    /// The SQL Database definition to set the edition default for database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithEditionDefaultsBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets a "Standard" edition for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithEditionDefaults<ParentT> WithStandardEdition(SqlDatabaseStandardServiceObjective serviceObjective);

        /// <summary>
        /// Sets a "Standard" edition and maximum storage capacity for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <param name="maxStorageCapacity">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithEditionDefaults<ParentT> WithStandardEdition(SqlDatabaseStandardServiceObjective serviceObjective, SqlDatabaseStandardStorage maxStorageCapacity);

        /// <summary>
        /// Sets a "Premium" edition for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithEditionDefaults<ParentT> WithPremiumEdition(SqlDatabasePremiumServiceObjective serviceObjective);

        /// <summary>
        /// Sets a "Premium" edition and maximum storage capacity for the SQL Database.
        /// </summary>
        /// <param name="serviceObjective">Edition to be set for database.</param>
        /// <param name="maxStorageCapacity">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithEditionDefaults<ParentT> WithPremiumEdition(SqlDatabasePremiumServiceObjective serviceObjective, SqlDatabasePremiumStorage maxStorageCapacity);

        /// <summary>
        /// Sets a "Basic" edition for the SQL Database.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithEditionDefaults<ParentT> WithBasicEdition();

        /// <summary>
        /// Sets a "Basic" edition and maximum storage capacity for the SQL Database.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithEditionDefaults<ParentT> WithBasicEdition(SqlDatabaseBasicStorage maxStorageCapacity);
    }

    /// <summary>
    /// The SQL Database definition to set a restorable dropped database as the source database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithRestorableDroppedDatabaseBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Creates a new database from a previously deleted database (see restorable dropped database).
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="restorableDroppedDatabase">The restorable dropped database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachFinal<ParentT> FromRestorableDroppedDatabase(ISqlRestorableDroppedDatabase restorableDroppedDatabase);
    }

    /// <summary>
    /// Sets the storage key type and value to use.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStorageKeyAfterElasticPoolBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <param name="storageAccessKey">The storage access key to use.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAuthenticationAfterElasticPool<ParentT> WithStorageAccessKey(string storageAccessKey);

        /// <param name="sharedAccessKey">The shared access key to use; it must be preceded with a "?.".</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAuthenticationAfterElasticPool<ParentT> WithSharedAccessKey(string sharedAccessKey);
    }

    /// <summary>
    /// Sets the authentication type and SQL or Active Directory administrator login and password.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAuthenticationAfterElasticPoolBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <param name="administratorLogin">The Active Directory administrator login.</param>
        /// <param name="administratorPassword">The Active Directory administrator password.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachFinal<ParentT> WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword);

        /// <param name="administratorLogin">The SQL administrator login.</param>
        /// <param name="administratorPassword">The SQL administrator password.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachFinal<ParentT> WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword);
    }

    /// <summary>
    /// Sets the storage key type and value to use.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStorageKeyBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <param name="storageAccessKey">The storage access key to use.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAuthentication<ParentT> WithStorageAccessKey(string storageAccessKey);

        /// <param name="sharedAccessKey">The shared access key to use; it must be preceded with a "?.".</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAuthentication<ParentT> WithSharedAccessKey(string sharedAccessKey);
    }

    /// <summary>
    /// Sets the authentication type and SQL or Active Directory administrator login and password.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAuthenticationBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <param name="administratorLogin">The Active Directory administrator login.</param>
        /// <param name="administratorPassword">The Active Directory administrator password.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAllOptions<ParentT> WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword);

        /// <param name="administratorLogin">The SQL administrator login.</param>
        /// <param name="administratorPassword">The SQL administrator password.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithAttachAllOptions<ParentT> WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword);
    }
}