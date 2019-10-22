// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition;

    /// <summary>
    /// The SQL Elastic Pool definition to set the minimum DTU for database.
    /// </summary>
    public interface IWithDatabaseDtuMin 
    {
        /// <summary>
        /// Sets the minimum DTU all SQL Azure Databases are guaranteed.
        /// </summary>
        /// <param name="databaseDtuMin">Minimum DTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate WithDatabaseDtuMin(int databaseDtuMin);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the maximum DTU for one database.
    /// </summary>
    public interface IWithDatabaseDtuMax 
    {
        /// <summary>
        /// Sets the maximum DTU any one SQL Azure Database can consume.
        /// </summary>
        /// <param name="databaseDtuMax">Maximum DTU any one SQL Azure Database can consume.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate WithDatabaseDtuMax(int databaseDtuMax);
    }

    /// <summary>
    /// A SQL Server definition with sufficient inputs to create a new SQL Elastic Pool in the cloud,
    /// but exposing additional optional inputs to specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithDatabaseDtuMin,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithDatabaseDtuMax,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithDtu,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithStorageCapacity,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithDatabase,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>
    {
    }

    /// <summary>
    /// The first stage of the SQL Server Elastic Pool definition.
    /// </summary>
    public interface IWithSqlServer 
    {
        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <param name="location">The parent SQL server location.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithEdition WithExistingSqlServer(string resourceGroupName, string sqlServerName, string location);

        /// <summary>
        /// Sets the parent SQL server for the new Elastic Pool.
        /// </summary>
        /// <param name="sqlServer">The parent SQL server.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithEdition WithExistingSqlServer(ISqlServer sqlServer);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the eDTU and storage capacity limits for a basic pool.
    /// </summary>
    public interface IWithBasicEdition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithBasicEditionBeta
    {
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the eDTU and storage capacity limits for a premium pool.
    /// </summary>
    public interface IWithPremiumEdition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithPremiumEditionBeta
    {
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the edition type.
    /// </summary>
    public interface IWithEdition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithEditionBeta
    {
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the storage limit for the SQL Azure Database Elastic Pool in MB.
    /// </summary>
    public interface IWithStorageCapacity 
    {
        /// <summary>
        /// Sets the storage limit for the SQL Azure Database Elastic Pool in MB.
        /// </summary>
        /// <param name="storageMB">Storage limit for the SQL Azure Database Elastic Pool in MB.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate WithStorageCapacity(int storageMB);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the eDTU and storage capacity limits for a standard pool.
    /// </summary>
    public interface IWithStandardEdition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithStandardEditionBeta
    {
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the number of shared DTU for elastic pool.
    /// </summary>
    public interface IWithDtu 
    {
        /// <summary>
        /// Sets the total shared DTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="dtu">Total shared DTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate WithDtu(int dtu);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to add the Database in the Elastic Pool.
    /// </summary>
    public interface IWithDatabase  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithDatabaseBeta
    {
        /// <summary>
        /// Adds an existing database in the SQL elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the existing database to be added in the elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate WithExistingDatabase(string databaseName);

        /// <summary>
        /// Adds the database in the SQL elastic pool.
        /// </summary>
        /// <param name="database">Database instance to be added in SQL elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate WithExistingDatabase(ISqlDatabase database);

        /// <summary>
        /// Creates a new database in the SQL elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the new database to be added in the elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate WithNewDatabase(string databaseName);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the eDTU and storage capacity limits for a basic pool.
    /// </summary>
    public interface IWithBasicEditionBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithBasicEdition WithDatabaseDtuMin(SqlElasticPoolBasicMinEDTUs eDTU);

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithBasicEdition WithReservedDtu(SqlElasticPoolBasicEDTUs eDTU);

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithBasicEdition WithDatabaseDtuMax(SqlElasticPoolBasicMaxEDTUs eDTU);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the eDTU and storage capacity limits for a premium pool.
    /// </summary>
    public interface IWithPremiumEditionBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithPremiumEdition WithDatabaseDtuMin(SqlElasticPoolPremiumMinEDTUs eDTU);

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithPremiumEdition WithReservedDtu(SqlElasticPoolPremiumEDTUs eDTU);

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithPremiumEdition WithDatabaseDtuMax(SqlElasticPoolPremiumMaxEDTUs eDTU);

        /// <summary>
        /// Sets the storage capacity for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="storageCapacity">Storage capacity for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithPremiumEdition WithStorageCapacity(SqlElasticPoolPremiumSorage storageCapacity);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the edition type.
    /// </summary>
    public interface IWithEditionBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the basic edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithBasicEdition WithBasicPool();

        /// <summary>
        /// Sets the standard edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithStandardEdition WithStandardPool();

        /// <summary>
        /// Sets the edition for the SQL Elastic Pool.
        /// </summary>
        /// <param name="edition">Edition to be set for Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate WithEdition(ElasticPoolEdition edition);

        /// <summary>
        /// Sets the premium edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithPremiumEdition WithPremiumPool();
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the eDTU and storage capacity limits for a standard pool.
    /// </summary>
    public interface IWithStandardEditionBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithStandardEdition WithDatabaseDtuMin(SqlElasticPoolStandardMinEDTUs eDTU);

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithStandardEdition WithReservedDtu(SqlElasticPoolStandardEDTUs eDTU);

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithStandardEdition WithDatabaseDtuMax(SqlElasticPoolStandardMaxEDTUs eDTU);

        /// <summary>
        /// Sets the storage capacity for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="storageCapacity">Storage capacity for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithStandardEdition WithStorageCapacity(SqlElasticPoolStandardStorage storageCapacity);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to add the Database in the Elastic Pool.
    /// </summary>
    public interface IWithDatabaseBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Begins the definition of a new SQL Database to be added to this server.
        /// </summary>
        /// <param name="databaseName">The name of the new SQL Database.</param>
        /// <return>The first stage of the new SQL Database definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithExistingDatabaseAfterElasticPool<Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate> DefineDatabase(string databaseName);
    }
}