// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition;
    using Microsoft.Azure.Management.Storage.Fluent;

    internal partial class SqlDatabaseForElasticPoolImpl 
    {
        /// <summary>
        /// Sets the create mode for the SQL Database.
        /// </summary>
        /// <param name="createMode">Create mode for the database, should not be default in this flow.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachFinal<SqlElasticPoolOperations.Definition.IWithCreate> SqlDatabase.Definition.IWithCreateMode<SqlElasticPoolOperations.Definition.IWithCreate>.WithMode(string createMode)
        {
            return this.WithMode(createMode) as SqlDatabase.Definition.IWithAttachFinal<SqlElasticPoolOperations.Definition.IWithCreate>;
        }

        /// <summary>
        /// Sets the collation for the SQL Database.
        /// </summary>
        /// <param name="collation">Collation to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<SqlElasticPoolOperations.Definition.IWithCreate> SqlDatabase.Definition.IWithCollationAfterElasticPoolOptions<SqlElasticPoolOperations.Definition.IWithCreate>.WithCollation(string collation)
        {
            return this.WithCollation(collation) as SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<SqlElasticPoolOperations.Definition.IWithCreate>;
        }

        /// <summary>
        /// Sets the resource if of source database for the SQL Database.
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="sourceDatabaseId">Id of the source database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithCreateMode<SqlElasticPoolOperations.Definition.IWithCreate> SqlDatabase.Definition.IWithSourceDatabaseId<SqlElasticPoolOperations.Definition.IWithCreate>.WithSourceDatabase(string sourceDatabaseId)
        {
            return this.WithSourceDatabase(sourceDatabaseId) as SqlDatabase.Definition.IWithCreateMode<SqlElasticPoolOperations.Definition.IWithCreate>;
        }

        /// <summary>
        /// Sets the resource if of source database for the SQL Database.
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="sourceDatabase">Instance of the source database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithCreateMode<SqlElasticPoolOperations.Definition.IWithCreate> SqlDatabase.Definition.IWithSourceDatabaseId<SqlElasticPoolOperations.Definition.IWithCreate>.WithSourceDatabase(ISqlDatabase sourceDatabase)
        {
            return this.WithSourceDatabase(sourceDatabase) as SqlDatabase.Definition.IWithCreateMode<SqlElasticPoolOperations.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageUri">The source URI for the database to be imported.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithStorageKeyAfterElasticPool<SqlElasticPoolOperations.Definition.IWithCreate> SqlDatabase.Definition.IWithImportFromAfterElasticPoolBeta<SqlElasticPoolOperations.Definition.IWithCreate>.ImportFrom(string storageUri)
        {
            return this.ImportFrom(storageUri) as SqlDatabase.Definition.IWithStorageKeyAfterElasticPool<SqlElasticPoolOperations.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new database from a BACPAC file.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be used.</param>
        /// <param name="containerName">The container name within the storage account to use.</param>
        /// <param name="fileName">The exported database file name.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAuthenticationAfterElasticPool<SqlElasticPoolOperations.Definition.IWithCreate> SqlDatabase.Definition.IWithImportFromAfterElasticPoolBeta<SqlElasticPoolOperations.Definition.IWithCreate>.ImportFrom(IStorageAccount storageAccount, string containerName, string fileName)
        {
            return this.ImportFrom(storageAccount, containerName, fileName) as SqlDatabase.Definition.IWithAuthenticationAfterElasticPool<SqlElasticPoolOperations.Definition.IWithCreate>;
        }

        /// <param name="administratorLogin">The Active Directory administrator login.</param>
        /// <param name="administratorPassword">The Active Directory administrator password.</param>
        /// <return>Next definition stage.</return>
        SqlDatabase.Definition.IWithAttachFinal<SqlElasticPoolOperations.Definition.IWithCreate> SqlDatabase.Definition.IWithAuthenticationAfterElasticPoolBeta<SqlElasticPoolOperations.Definition.IWithCreate>.WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            return this.WithActiveDirectoryLoginAndPassword(administratorLogin, administratorPassword) as SqlDatabase.Definition.IWithAttachFinal<SqlElasticPoolOperations.Definition.IWithCreate>;
        }

        /// <param name="administratorLogin">The SQL administrator login.</param>
        /// <param name="administratorPassword">The SQL administrator password.</param>
        /// <return>Next definition stage.</return>
        SqlDatabase.Definition.IWithAttachFinal<SqlElasticPoolOperations.Definition.IWithCreate> SqlDatabase.Definition.IWithAuthenticationAfterElasticPoolBeta<SqlElasticPoolOperations.Definition.IWithCreate>.WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            return this.WithSqlAdministratorLoginAndPassword(administratorLogin, administratorPassword) as SqlDatabase.Definition.IWithAttachFinal<SqlElasticPoolOperations.Definition.IWithCreate>;
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
        SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<SqlElasticPoolOperations.Definition.IWithCreate> SqlDatabase.Definition.IWithMaxSizeBytesAfterElasticPoolOptions<SqlElasticPoolOperations.Definition.IWithCreate>.WithMaxSizeBytes(long maxSizeBytes)
        {
            return this.WithMaxSizeBytes(maxSizeBytes) as SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<SqlElasticPoolOperations.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        SqlElasticPoolOperations.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<SqlElasticPoolOperations.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as SqlElasticPoolOperations.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="sampleName">The sample database to use as the source.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<SqlElasticPoolOperations.Definition.IWithCreate> SqlDatabase.Definition.IWithSampleDatabaseAfterElasticPoolBeta<SqlElasticPoolOperations.Definition.IWithCreate>.FromSample(SampleName sampleName)
        {
            return this.FromSample(sampleName) as SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<SqlElasticPoolOperations.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new database from a restore point.
        /// </summary>
        /// <param name="restorePoint">The restore point.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<SqlElasticPoolOperations.Definition.IWithCreate> SqlDatabase.Definition.IWithRestorePointDatabaseAfterElasticPoolBeta<SqlElasticPoolOperations.Definition.IWithCreate>.FromRestorePoint(IRestorePoint restorePoint)
        {
            return this.FromRestorePoint(restorePoint) as SqlDatabase.Definition.IWithAttachAfterElasticPoolOptions<SqlElasticPoolOperations.Definition.IWithCreate>;
        }

        /// <param name="sharedAccessKey">The shared access key to use; it must be preceded with a "?.".</param>
        /// <return>Next definition stage.</return>
        SqlDatabase.Definition.IWithAuthenticationAfterElasticPool<SqlElasticPoolOperations.Definition.IWithCreate> SqlDatabase.Definition.IWithStorageKeyAfterElasticPoolBeta<SqlElasticPoolOperations.Definition.IWithCreate>.WithSharedAccessKey(string sharedAccessKey)
        {
            return this.WithSharedAccessKey(sharedAccessKey) as SqlDatabase.Definition.IWithAuthenticationAfterElasticPool<SqlElasticPoolOperations.Definition.IWithCreate>;
        }

        /// <param name="storageAccessKey">The storage access key to use.</param>
        /// <return>Next definition stage.</return>
        SqlDatabase.Definition.IWithAuthenticationAfterElasticPool<SqlElasticPoolOperations.Definition.IWithCreate> SqlDatabase.Definition.IWithStorageKeyAfterElasticPoolBeta<SqlElasticPoolOperations.Definition.IWithCreate>.WithStorageAccessKey(string storageAccessKey)
        {
            return this.WithStorageAccessKey(storageAccessKey) as SqlDatabase.Definition.IWithAuthenticationAfterElasticPool<SqlElasticPoolOperations.Definition.IWithCreate>;
        }
    }
}