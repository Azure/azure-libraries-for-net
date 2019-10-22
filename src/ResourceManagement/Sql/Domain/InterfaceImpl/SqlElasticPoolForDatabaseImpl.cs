// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.SqlElasticPoolDefinition;

    internal partial class SqlElasticPoolForDatabaseImpl 
    {
        /// <summary>
        /// Sets the minimum DTU all SQL Azure Databases are guaranteed.
        /// </summary>
        /// <param name="databaseDtuMin">Minimum DTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithAttach<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithDatabaseDtuMin<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithDatabaseDtuMin(int databaseDtuMin)
        {
            return this.WithDatabaseDtuMin(databaseDtuMin);
        }

        /// <summary>
        /// Sets the storage limit for the SQL Azure Database Elastic Pool in MB.
        /// </summary>
        /// <param name="storageMB">Storage limit for the SQL Azure Database Elastic Pool in MB.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithAttach<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithStorageCapacity<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithStorageCapacity(int storageMB)
        {
            return this.WithStorageCapacity(storageMB);
        }

        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithBasicEdition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithBasicEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithDatabaseDtuMin(SqlElasticPoolBasicMinEDTUs eDTU)
        {
            return this.WithDatabaseDtuMin(eDTU);
        }

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithBasicEdition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithBasicEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithDatabaseDtuMax(SqlElasticPoolBasicMaxEDTUs eDTU)
        {
            return this.WithDatabaseDtuMax(eDTU);
        }

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithBasicEdition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithBasicEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithReservedDtu(SqlElasticPoolBasicEDTUs eDTU)
        {
            return this.WithReservedDtu(eDTU);
        }

        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithPremiumEdition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithPremiumEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithDatabaseDtuMin(SqlElasticPoolPremiumMinEDTUs eDTU)
        {
            return this.WithDatabaseDtuMin(eDTU);
        }

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithPremiumEdition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithPremiumEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithDatabaseDtuMax(SqlElasticPoolPremiumMaxEDTUs eDTU)
        {
            return this.WithDatabaseDtuMax(eDTU);
        }

        /// <summary>
        /// Sets the storage capacity for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="storageCapacity">Storage capacity for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithPremiumEdition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithPremiumEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithStorageCapacity(SqlElasticPoolPremiumSorage storageCapacity)
        {
            return this.WithStorageCapacity(storageCapacity);
        }

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithPremiumEdition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithPremiumEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithReservedDtu(SqlElasticPoolPremiumEDTUs eDTU)
        {
            return this.WithReservedDtu(eDTU);
        }

        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithStandardEdition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithStandardEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithDatabaseDtuMin(SqlElasticPoolStandardMinEDTUs eDTU)
        {
            return this.WithDatabaseDtuMin(eDTU);
        }

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithStandardEdition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithStandardEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithDatabaseDtuMax(SqlElasticPoolStandardMaxEDTUs eDTU)
        {
            return this.WithDatabaseDtuMax(eDTU);
        }

        /// <summary>
        /// Sets the storage capacity for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="storageCapacity">Storage capacity for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithStandardEdition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithStandardEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithStorageCapacity(SqlElasticPoolStandardStorage storageCapacity)
        {
            return this.WithStorageCapacity(storageCapacity);
        }

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithStandardEdition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithStandardEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithReservedDtu(SqlElasticPoolStandardEDTUs eDTU)
        {
            return this.WithReservedDtu(eDTU);
        }

        /// <summary>
        /// Sets the maximum DTU any one SQL Azure Database can consume.
        /// </summary>
        /// <param name="databaseDtuMax">Maximum DTU any one SQL Azure Database can consume.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithAttach<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithDatabaseDtuMax<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithDatabaseDtuMax(int databaseDtuMax)
        {
            return this.WithDatabaseDtuMax(databaseDtuMax);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Sets the basic edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithBasicEdition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithBasicPool()
        {
            return this.WithBasicPool();
        }

        /// <summary>
        /// Sets the premium edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithPremiumEdition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithPremiumPool()
        {
            return this.WithPremiumPool();
        }

        /// <summary>
        /// Sets the edition for the SQL Elastic Pool.
        /// </summary>
        /// <param name="edition">Edition to be set for elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithAttach<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithEdition(ElasticPoolEdition edition)
        {
            return this.WithEdition(edition);
        }

        /// <summary>
        /// Sets the standard edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithStandardEdition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithEditionBeta<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithStandardPool()
        {
            return this.WithStandardPool();
        }

        /// <summary>
        /// Sets the total shared DTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="dtu">Total shared DTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        SqlElasticPool.Definition.IWithAttach<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool> SqlElasticPool.Definition.IWithDtu<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>.WithDtu(int dtu)
        {
            return this.WithDtu(dtu);
        }
    }
}