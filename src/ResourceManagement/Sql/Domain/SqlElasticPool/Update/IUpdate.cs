// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The template for a SQL Elastic Pool update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IWithReservedDTUAndStorageCapacity,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IWithDatabaseDtuMax,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IWithDatabaseDtuMin,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IWithDtu,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IWithStorageCapacity,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IWithDatabase,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>
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
        /// <return>The next stage of definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithStorageCapacity(int storageMB);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the minimum DTU for database.
    /// </summary>
    public interface IWithDatabaseDtuMin 
    {
        /// <summary>
        /// Sets the minimum DTU all SQL Azure Databases are guaranteed.
        /// </summary>
        /// <param name="databaseDtuMin">Minimum DTU for all SQL Azure databases.</param>
        /// <return>The next stage of definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithDatabaseDtuMin(int databaseDtuMin);
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
        /// <return>The next stage of definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithDtu(int dtu);
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
        /// <return>The next stage of definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithDatabaseDtuMax(int databaseDtuMax);
    }

    /// <summary>
    /// The SQL Elastic Pool update definition to set the eDTU and storage capacity limits.
    /// </summary>
    public interface IWithReservedDTUAndStorageCapacity  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IWithReservedDTUAndStorageCapacityBeta
    {
    }

    /// <summary>
    /// The SQL Elastic Pool definition to add the Database in the elastic pool.
    /// </summary>
    public interface IWithDatabase 
    {
        /// <summary>
        /// Adds an existing database in the SQL elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the existing database to be added in the elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithExistingDatabase(string databaseName);

        /// <summary>
        /// Adds the database in the SQL elastic pool.
        /// </summary>
        /// <param name="database">Database instance to be added in SQL elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithExistingDatabase(ISqlDatabase database);

        /// <summary>
        /// Creates a new database in the SQL elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the new database to be added in the elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithNewDatabase(string databaseName);
    }

    /// <summary>
    /// The SQL Elastic Pool update definition to set the eDTU and storage capacity limits.
    /// </summary>
    public interface IWithReservedDTUAndStorageCapacityBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithDatabaseDtuMin(SqlElasticPoolBasicMinEDTUs eDTU);

        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithDatabaseDtuMin(SqlElasticPoolStandardMinEDTUs eDTU);

        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithDatabaseDtuMin(SqlElasticPoolPremiumMinEDTUs eDTU);

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithReservedDtu(SqlElasticPoolBasicEDTUs eDTU);

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithReservedDtu(SqlElasticPoolStandardEDTUs eDTU);

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithReservedDtu(SqlElasticPoolPremiumEDTUs eDTU);

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithDatabaseDtuMax(SqlElasticPoolBasicMaxEDTUs eDTU);

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithDatabaseDtuMax(SqlElasticPoolStandardMaxEDTUs eDTU);

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithDatabaseDtuMax(SqlElasticPoolPremiumMaxEDTUs eDTU);

        /// <summary>
        /// Sets the storage capacity for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="storageCapacity">Storage capacity for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithStorageCapacity(SqlElasticPoolStandardStorage storageCapacity);

        /// <summary>
        /// Sets the storage capacity for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="storageCapacity">Storage capacity for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the update definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithStorageCapacity(SqlElasticPoolPremiumSorage storageCapacity);
    }
}