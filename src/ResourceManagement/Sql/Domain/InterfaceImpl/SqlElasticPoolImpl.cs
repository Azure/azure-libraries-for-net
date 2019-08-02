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
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.SqlElasticPoolDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.SqlElasticPoolOperationsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    internal partial class SqlElasticPoolImpl 
    {
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

        /// <summary>
        /// Sets the minimum DTU all SQL Azure Databases are guaranteed.
        /// </summary>
        /// <param name="databaseDtuMin">Minimum DTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithCreate SqlElasticPoolOperations.Definition.IWithDatabaseDtuMin.WithDatabaseDtuMin(int databaseDtuMin)
        {
            return this.WithDatabaseDtuMin(databaseDtuMin);
        }

        /// <summary>
        /// Sets the minimum DTU all SQL Azure Databases are guaranteed.
        /// </summary>
        /// <param name="databaseDtuMin">Minimum DTU for all SQL Azure databases.</param>
        /// <return>The next stage of definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithDatabaseDtuMin.WithDatabaseDtuMin(int databaseDtuMin)
        {
            return this.WithDatabaseDtuMin(databaseDtuMin);
        }

        /// <summary>
        /// Sets the premium edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithPremiumEdition SqlElasticPoolOperations.Definition.IWithEditionBeta.WithPremiumPool()
        {
            return this.WithPremiumPool();
        }

        /// <summary>
        /// Sets the edition for the SQL Elastic Pool.
        /// </summary>
        /// <param name="edition">Edition to be set for Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithCreate SqlElasticPoolOperations.Definition.IWithEditionBeta.WithEdition(ElasticPoolEdition edition)
        {
            return this.WithEdition(edition);
        }

        /// <summary>
        /// Sets the standard edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithStandardEdition SqlElasticPoolOperations.Definition.IWithEditionBeta.WithStandardPool()
        {
            return this.WithStandardPool();
        }

        /// <summary>
        /// Sets the basic edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithBasicEdition SqlElasticPoolOperations.Definition.IWithEditionBeta.WithBasicPool()
        {
            return this.WithBasicPool();
        }

        /// <summary>
        /// Sets the total shared DTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="dtu">Total shared DTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithAttach<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithDtu<SqlServer.Definition.IWithCreate>.WithDtu(int dtu)
        {
            return this.WithDtu(dtu);
        }

        /// <summary>
        /// Sets the storage limit for the SQL Azure Database Elastic Pool in MB.
        /// </summary>
        /// <param name="storageMB">Storage limit for the SQL Azure Database Elastic Pool in MB.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithCreate SqlElasticPoolOperations.Definition.IWithStorageCapacity.WithStorageCapacity(int storageMB)
        {
            return this.WithStorageCapacity(storageMB);
        }

        /// <summary>
        /// Sets the storage limit for the SQL Azure Database Elastic Pool in MB.
        /// </summary>
        /// <param name="storageMB">Storage limit for the SQL Azure Database Elastic Pool in MB.</param>
        /// <return>The next stage of definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithStorageCapacity.WithStorageCapacity(int storageMB)
        {
            return this.WithStorageCapacity(storageMB);
        }

        /// <summary>
        /// Adds an existing database in the SQL elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the existing database to be added in the elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithCreate SqlElasticPoolOperations.Definition.IWithDatabase.WithExistingDatabase(string databaseName)
        {
            return this.WithExistingDatabase(databaseName);
        }

        /// <summary>
        /// Adds the database in the SQL elastic pool.
        /// </summary>
        /// <param name="database">Database instance to be added in SQL elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithCreate SqlElasticPoolOperations.Definition.IWithDatabase.WithExistingDatabase(ISqlDatabase database)
        {
            return this.WithExistingDatabase(database);
        }

        /// <summary>
        /// Begins the definition of a new SQL Database to be added to this server.
        /// </summary>
        /// <param name="databaseName">The name of the new SQL Database.</param>
        /// <return>The first stage of the new SQL Database definition.</return>
        SqlDatabase.Definition.IWithExistingDatabaseAfterElasticPool<SqlElasticPoolOperations.Definition.IWithCreate> SqlElasticPoolOperations.Definition.IWithDatabaseBeta.DefineDatabase(string databaseName)
        {
            return this.DefineDatabase(databaseName);
        }

        /// <summary>
        /// Creates a new database in the SQL elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the new database to be added in the elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithCreate SqlElasticPoolOperations.Definition.IWithDatabase.WithNewDatabase(string databaseName)
        {
            return this.WithNewDatabase(databaseName);
        }

        /// <summary>
        /// Adds an existing database in the SQL elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the existing database to be added in the elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithDatabase.WithExistingDatabase(string databaseName)
        {
            return this.WithExistingDatabase(databaseName);
        }

        /// <summary>
        /// Adds the database in the SQL elastic pool.
        /// </summary>
        /// <param name="database">Database instance to be added in SQL elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithDatabase.WithExistingDatabase(ISqlDatabase database)
        {
            return this.WithExistingDatabase(database);
        }

        /// <summary>
        /// Creates a new database in the SQL elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the new database to be added in the elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithDatabase.WithNewDatabase(string databaseName)
        {
            return this.WithNewDatabase(databaseName);
        }

        /// <summary>
        /// Sets the maximum DTU any one SQL Azure Database can consume.
        /// </summary>
        /// <param name="databaseDtuMax">Maximum DTU any one SQL Azure Database can consume.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithCreate SqlElasticPoolOperations.Definition.IWithDatabaseDtuMax.WithDatabaseDtuMax(int databaseDtuMax)
        {
            return this.WithDatabaseDtuMax(databaseDtuMax);
        }

        /// <summary>
        /// Sets the maximum DTU any one SQL Azure Database can consume.
        /// </summary>
        /// <param name="databaseDtuMax">Maximum DTU any one SQL Azure Database can consume.</param>
        /// <return>The next stage of definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithDatabaseDtuMax.WithDatabaseDtuMax(int databaseDtuMax)
        {
            return this.WithDatabaseDtuMax(databaseDtuMax);
        }

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithBasicEdition<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithBasicEditionBeta<SqlServer.Definition.IWithCreate>.WithReservedDtu(SqlElasticPoolBasicEDTUs eDTU)
        {
            return this.WithReservedDtu(eDTU);
        }

        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithBasicEdition<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithBasicEditionBeta<SqlServer.Definition.IWithCreate>.WithDatabaseDtuMin(SqlElasticPoolBasicMinEDTUs eDTU)
        {
            return this.WithDatabaseDtuMin(eDTU);
        }

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithBasicEdition<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithBasicEditionBeta<SqlServer.Definition.IWithCreate>.WithDatabaseDtuMax(SqlElasticPoolBasicMaxEDTUs eDTU)
        {
            return this.WithDatabaseDtuMax(eDTU);
        }

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithPremiumEdition<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithPremiumEditionBeta<SqlServer.Definition.IWithCreate>.WithReservedDtu(SqlElasticPoolPremiumEDTUs eDTU)
        {
            return this.WithReservedDtu(eDTU);
        }

        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithPremiumEdition<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithPremiumEditionBeta<SqlServer.Definition.IWithCreate>.WithDatabaseDtuMin(SqlElasticPoolPremiumMinEDTUs eDTU)
        {
            return this.WithDatabaseDtuMin(eDTU);
        }

        /// <summary>
        /// Sets the storage capacity for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="storageCapacity">Storage capacity for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithPremiumEdition<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithPremiumEditionBeta<SqlServer.Definition.IWithCreate>.WithStorageCapacity(SqlElasticPoolPremiumSorage storageCapacity)
        {
            return this.WithStorageCapacity(storageCapacity);
        }

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithPremiumEdition<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithPremiumEditionBeta<SqlServer.Definition.IWithCreate>.WithDatabaseDtuMax(SqlElasticPoolPremiumMaxEDTUs eDTU)
        {
            return this.WithDatabaseDtuMax(eDTU);
        }

        /// <summary>
        /// Removes a tag from the resource.
        /// </summary>
        /// <param name="key">The key of the tag to remove.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate IUpdateWithTags<SqlElasticPool.Update.IUpdate>.WithoutTag(string key)
        {
            return this.WithoutTag(key);
        }

        /// <summary>
        /// Specifies tags for the resource as a  Map.
        /// </summary>
        /// <param name="tags">A  Map of tags.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate>.WithTags(IDictionary<string,string> tags)
        {
            return this.WithTags(tags);
        }

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate>.WithTag(string key, string value)
        {
            return this.WithTag(key, value);
        }

        /// <summary>
        /// Sets the total shared DTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="dtu">Total shared DTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithCreate SqlElasticPoolOperations.Definition.IWithDtu.WithDtu(int dtu)
        {
            return this.WithDtu(dtu);
        }

        /// <summary>
        /// Sets the total shared DTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="dtu">Total shared DTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithDtu.WithDtu(int dtu)
        {
            return this.WithDtu(dtu);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        SqlServer.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<SqlServer.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithPremiumEdition SqlElasticPoolOperations.Definition.IWithPremiumEditionBeta.WithReservedDtu(SqlElasticPoolPremiumEDTUs eDTU)
        {
            return this.WithReservedDtu(eDTU);
        }

        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithPremiumEdition SqlElasticPoolOperations.Definition.IWithPremiumEditionBeta.WithDatabaseDtuMin(SqlElasticPoolPremiumMinEDTUs eDTU)
        {
            return this.WithDatabaseDtuMin(eDTU);
        }

        /// <summary>
        /// Sets the storage capacity for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="storageCapacity">Storage capacity for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithPremiumEdition SqlElasticPoolOperations.Definition.IWithPremiumEditionBeta.WithStorageCapacity(SqlElasticPoolPremiumSorage storageCapacity)
        {
            return this.WithStorageCapacity(storageCapacity);
        }

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithPremiumEdition SqlElasticPoolOperations.Definition.IWithPremiumEditionBeta.WithDatabaseDtuMax(SqlElasticPoolPremiumMaxEDTUs eDTU)
        {
            return this.WithDatabaseDtuMax(eDTU);
        }

        /// <summary>
        /// Sets the maximum DTU any one SQL Azure Database can consume.
        /// </summary>
        /// <param name="databaseDtuMax">Maximum DTU any one SQL Azure Database can consume.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithAttach<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithDatabaseDtuMax<SqlServer.Definition.IWithCreate>.WithDatabaseDtuMax(int databaseDtuMax)
        {
            return this.WithDatabaseDtuMax(databaseDtuMax);
        }

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithStandardEdition SqlElasticPoolOperations.Definition.IWithStandardEditionBeta.WithReservedDtu(SqlElasticPoolStandardEDTUs eDTU)
        {
            return this.WithReservedDtu(eDTU);
        }

        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithStandardEdition SqlElasticPoolOperations.Definition.IWithStandardEditionBeta.WithDatabaseDtuMin(SqlElasticPoolStandardMinEDTUs eDTU)
        {
            return this.WithDatabaseDtuMin(eDTU);
        }

        /// <summary>
        /// Sets the storage capacity for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="storageCapacity">Storage capacity for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithStandardEdition SqlElasticPoolOperations.Definition.IWithStandardEditionBeta.WithStorageCapacity(SqlElasticPoolStandardStorage storageCapacity)
        {
            return this.WithStorageCapacity(storageCapacity);
        }

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithStandardEdition SqlElasticPoolOperations.Definition.IWithStandardEditionBeta.WithDatabaseDtuMax(SqlElasticPoolStandardMaxEDTUs eDTU)
        {
            return this.WithDatabaseDtuMax(eDTU);
        }

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithBasicEdition SqlElasticPoolOperations.Definition.IWithBasicEditionBeta.WithReservedDtu(SqlElasticPoolBasicEDTUs eDTU)
        {
            return this.WithReservedDtu(eDTU);
        }

        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithBasicEdition SqlElasticPoolOperations.Definition.IWithBasicEditionBeta.WithDatabaseDtuMin(SqlElasticPoolBasicMinEDTUs eDTU)
        {
            return this.WithDatabaseDtuMin(eDTU);
        }

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithBasicEdition SqlElasticPoolOperations.Definition.IWithBasicEditionBeta.WithDatabaseDtuMax(SqlElasticPoolBasicMaxEDTUs eDTU)
        {
            return this.WithDatabaseDtuMax(eDTU);
        }

        /// <summary>
        /// Lists the SQL databases in this SQL Elastic Pool.
        /// </summary>
        /// <return>The information about databases in elastic pool.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.ListDatabases()
        {
            return this.ListDatabases();
        }

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.ParentId
        {
            get
            {
                return this.ParentId();
            }
        }

        /// <summary>
        /// Asynchronously lists the database metric definitions for this SQL Elastic Pool.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition>> Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.ListDatabaseMetricDefinitionsAsync(CancellationToken cancellationToken)
        {
            return await this.ListDatabaseMetricDefinitionsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets name of the SQL Server to which this elastic pool belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Gets the edition of Azure SQL Elastic Pool.
        /// </summary>
        ElasticPoolEdition Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.Edition
        {
            get
            {
                return this.Edition();
            }
        }

        /// <summary>
        /// Gets the maximum DTU any one SQL Azure database can consume.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.DatabaseDtuMax
        {
            get
            {
                return this.DatabaseDtuMax();
            }
        }

        /// <return>The information about elastic pool database activities.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity>> Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.ListDatabaseActivitiesAsync(CancellationToken cancellationToken)
        {
            return await this.ListDatabaseActivitiesAsync(cancellationToken);
        }

        /// <return>A representation of the deferred computation of the information about elastic pool activities.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity>> Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.ListActivitiesAsync(CancellationToken cancellationToken)
        {
            return await this.ListActivitiesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets The total shared DTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.Dtu
        {
            get
            {
                return this.Dtu();
            }
        }

        /// <summary>
        /// Gets the name of the region the resource is in.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.RegionName
        {
            get
            {
                return this.RegionName();
            }
        }

        /// <summary>
        /// Gets the storage limit for the SQL Azure Database Elastic Pool in MB.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.StorageMB
        {
            get
            {
                return this.StorageMB();
            }
        }

        /// <summary>
        /// Deletes this SQL Elastic Pool asynchronously from the parent SQL server.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.DeleteAsync(CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(cancellationToken);
        }

        /// <return>The information about elastic pool activities.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity> Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.ListActivities()
        {
            return this.ListActivities();
        }

        /// <summary>
        /// Asynchronously lists the database metrics for this SQL Elastic Pool.
        /// </summary>
        /// <param name="filter">An OData filter expression that describes a subset of metrics to return.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric>> Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.ListDatabaseMetricsAsync(string filter, CancellationToken cancellationToken)
        {
            return await this.ListDatabaseMetricsAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Lists the database metric definitions for this SQL Elastic Pool.
        /// </summary>
        /// <return>The elastic pool's metric definitions.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition> Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.ListDatabaseMetricDefinitions()
        {
            return this.ListDatabaseMetricDefinitions();
        }

        /// <summary>
        /// Gets the specific database in the elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the database to look into.</param>
        /// <return>The information about specific database in elastic pool.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.GetDatabase(string databaseName)
        {
            return this.GetDatabase(databaseName);
        }

        /// <summary>
        /// Gets the storage capacity limit for the SQL Azure Database Elastic Pool in MB.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.StorageCapacityInMB
        {
            get
            {
                return this.StorageCapacityInMB();
            }
        }

        /// <summary>
        /// Deletes this SQL Elastic Pool from the parent SQL server.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.Delete()
        {
 
            this.Delete();
        }

        /// <summary>
        /// Gets the creation date of the Azure SQL Elastic Pool.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.CreationDate
        {
            get
            {
                return this.CreationDate();
            }
        }

        /// <summary>
        /// Asynchronously lists the SQL databases in this SQL Elastic Pool.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>> Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.ListDatabasesAsync(CancellationToken cancellationToken)
        {
            return await this.ListDatabasesAsync(cancellationToken);
        }

        /// <summary>
        /// Adds a new SQL Database to the Elastic Pool.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <return>The database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.AddNewDatabase(string databaseName)
        {
            return this.AddNewDatabase(databaseName);
        }

        /// <summary>
        /// Gets the minimum DTU all SQL Azure Databases are guaranteed.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.DatabaseDtuMin
        {
            get
            {
                return this.DatabaseDtuMin();
            }
        }

        /// <summary>
        /// Adds an existing SQL Database to the Elastic Pool.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <return>The database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.AddExistingDatabase(string databaseName)
        {
            return this.AddExistingDatabase(databaseName);
        }

        /// <summary>
        /// Adds an existing SQL Database to the Elastic Pool.
        /// </summary>
        /// <param name="database">The database to be added.</param>
        /// <return>The database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.AddExistingDatabase(ISqlDatabase database)
        {
            return this.AddExistingDatabase(database);
        }

        /// <summary>
        /// Lists the database metrics for this SQL Elastic Pool.
        /// </summary>
        /// <param name="filter">An OData filter expression that describes a subset of metrics to return.</param>
        /// <return>The elastic pool's database metrics.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric> Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.ListDatabaseMetrics(string filter)
        {
            return this.ListDatabaseMetrics(filter);
        }

        /// <summary>
        /// Gets the region the resource is in.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.Region
        {
            get
            {
                return this.Region();
            }
        }

        /// <summary>
        /// Removes an existing SQL Database from the Elastic Pool.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <return>The database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.RemoveDatabase(string databaseName)
        {
            return this.RemoveDatabase(databaseName);
        }

        /// <summary>
        /// Gets the state of the Azure SQL Elastic Pool.
        /// </summary>
        ElasticPoolState Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.State
        {
            get
            {
                return this.State();
            }
        }

        /// <return>The information about elastic pool database activities.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity> Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool.ListDatabaseActivities()
        {
            return this.ListDatabaseActivities();
        }

        /// <summary>
        /// Sets the storage limit for the SQL Azure Database Elastic Pool in MB.
        /// </summary>
        /// <param name="storageMB">Storage limit for the SQL Azure Database Elastic Pool in MB.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithAttach<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithStorageCapacity<SqlServer.Definition.IWithCreate>.WithStorageCapacity(int storageMB)
        {
            return this.WithStorageCapacity(storageMB);
        }

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithStandardEdition<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithStandardEditionBeta<SqlServer.Definition.IWithCreate>.WithReservedDtu(SqlElasticPoolStandardEDTUs eDTU)
        {
            return this.WithReservedDtu(eDTU);
        }

        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithStandardEdition<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithStandardEditionBeta<SqlServer.Definition.IWithCreate>.WithDatabaseDtuMin(SqlElasticPoolStandardMinEDTUs eDTU)
        {
            return this.WithDatabaseDtuMin(eDTU);
        }

        /// <summary>
        /// Sets the storage capacity for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="storageCapacity">Storage capacity for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithStandardEdition<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithStandardEditionBeta<SqlServer.Definition.IWithCreate>.WithStorageCapacity(SqlElasticPoolStandardStorage storageCapacity)
        {
            return this.WithStorageCapacity(storageCapacity);
        }

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithStandardEdition<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithStandardEditionBeta<SqlServer.Definition.IWithCreate>.WithDatabaseDtuMax(SqlElasticPoolStandardMaxEDTUs eDTU)
        {
            return this.WithDatabaseDtuMax(eDTU);
        }

        /// <summary>
        /// Sets the premium edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithPremiumEdition<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithEditionBeta<SqlServer.Definition.IWithCreate>.WithPremiumPool()
        {
            return this.WithPremiumPool();
        }

        /// <summary>
        /// Sets the edition for the SQL Elastic Pool.
        /// </summary>
        /// <param name="edition">Edition to be set for elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithAttach<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithEditionBeta<SqlServer.Definition.IWithCreate>.WithEdition(ElasticPoolEdition edition)
        {
            return this.WithEdition(edition);
        }

        /// <summary>
        /// Sets the standard edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithStandardEdition<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithEditionBeta<SqlServer.Definition.IWithCreate>.WithStandardPool()
        {
            return this.WithStandardPool();
        }

        /// <summary>
        /// Sets the basic edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithBasicEdition<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithEditionBeta<SqlServer.Definition.IWithCreate>.WithBasicPool()
        {
            return this.WithBasicPool();
        }

        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <param name="location">The parent SQL server location.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithEdition SqlElasticPoolOperations.Definition.IWithSqlServer.WithExistingSqlServer(string resourceGroupName, string sqlServerName, string location)
        {
            return this.WithExistingSqlServer(resourceGroupName, sqlServerName, location);
        }

        /// <summary>
        /// Sets the parent SQL server for the new Elastic Pool.
        /// </summary>
        /// <param name="sqlServer">The parent SQL server.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPoolOperations.Definition.IWithEdition SqlElasticPoolOperations.Definition.IWithSqlServer.WithExistingSqlServer(ISqlServer sqlServer)
        {
            return this.WithExistingSqlServer(sqlServer);
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        SqlElasticPool.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlElasticPool.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Sets the minimum DTU all SQL Azure Databases are guaranteed.
        /// </summary>
        /// <param name="databaseDtuMin">Minimum DTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithAttach<SqlServer.Definition.IWithCreate> SqlElasticPool.Definition.IWithDatabaseDtuMin<SqlServer.Definition.IWithCreate>.WithDatabaseDtuMin(int databaseDtuMin)
        {
            return this.WithDatabaseDtuMin(databaseDtuMin);
        }

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the update definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithReservedDTUAndStorageCapacityBeta.WithReservedDtu(SqlElasticPoolBasicEDTUs eDTU)
        {
            return this.WithReservedDtu(eDTU);
        }

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the update definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithReservedDTUAndStorageCapacityBeta.WithReservedDtu(SqlElasticPoolStandardEDTUs eDTU)
        {
            return this.WithReservedDtu(eDTU);
        }

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the update definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithReservedDTUAndStorageCapacityBeta.WithReservedDtu(SqlElasticPoolPremiumEDTUs eDTU)
        {
            return this.WithReservedDtu(eDTU);
        }

        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the update definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithReservedDTUAndStorageCapacityBeta.WithDatabaseDtuMin(SqlElasticPoolBasicMinEDTUs eDTU)
        {
            return this.WithDatabaseDtuMin(eDTU);
        }

        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the update definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithReservedDTUAndStorageCapacityBeta.WithDatabaseDtuMin(SqlElasticPoolStandardMinEDTUs eDTU)
        {
            return this.WithDatabaseDtuMin(eDTU);
        }

        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the update definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithReservedDTUAndStorageCapacityBeta.WithDatabaseDtuMin(SqlElasticPoolPremiumMinEDTUs eDTU)
        {
            return this.WithDatabaseDtuMin(eDTU);
        }

        /// <summary>
        /// Sets the storage capacity for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="storageCapacity">Storage capacity for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the update definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithReservedDTUAndStorageCapacityBeta.WithStorageCapacity(SqlElasticPoolStandardStorage storageCapacity)
        {
            return this.WithStorageCapacity(storageCapacity);
        }

        /// <summary>
        /// Sets the storage capacity for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="storageCapacity">Storage capacity for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the update definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithReservedDTUAndStorageCapacityBeta.WithStorageCapacity(SqlElasticPoolPremiumSorage storageCapacity)
        {
            return this.WithStorageCapacity(storageCapacity);
        }

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the update definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithReservedDTUAndStorageCapacityBeta.WithDatabaseDtuMax(SqlElasticPoolBasicMaxEDTUs eDTU)
        {
            return this.WithDatabaseDtuMax(eDTU);
        }

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the update definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithReservedDTUAndStorageCapacityBeta.WithDatabaseDtuMax(SqlElasticPoolStandardMaxEDTUs eDTU)
        {
            return this.WithDatabaseDtuMax(eDTU);
        }

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the update definition.</return>
        SqlElasticPool.Update.IUpdate SqlElasticPool.Update.IWithReservedDTUAndStorageCapacityBeta.WithDatabaseDtuMax(SqlElasticPoolPremiumMaxEDTUs eDTU)
        {
            return this.WithDatabaseDtuMax(eDTU);
        }

        /// <summary>
        /// Specifies tags for the resource as a  Map.
        /// </summary>
        /// <param name="tags">A  Map of tags.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate>.WithTags(IDictionary<string,string> tags)
        {
            return this.WithTags(tags);
        }

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition.IWithCreate>.WithTag(string key, string value)
        {
            return this.WithTag(key, value);
        }
    }
}