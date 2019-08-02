// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// The first stage of the SQL Server definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithEdition<ParentT>
    {
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the edition for database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithEdition<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithEditionBeta<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the SQL Elastic Pool definition.
    /// At this stage, any remaining optional settings can be specified, or the SQL Elastic Pool definition
    /// can be attached to the parent SQL Server definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithDatabaseDtuMin<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithDatabaseDtuMax<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithDtu<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithStorageCapacity<ParentT>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the minimum DTU for database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDatabaseDtuMin<ParentT> 
    {
        /// <summary>
        /// Sets the minimum DTU all SQL Azure Databases are guaranteed.
        /// </summary>
        /// <param name="databaseDtuMin">Minimum DTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithAttach<ParentT> WithDatabaseDtuMin(int databaseDtuMin);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the maximum DTU for one database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDatabaseDtuMax<ParentT> 
    {
        /// <summary>
        /// Sets the maximum DTU any one SQL Azure Database can consume.
        /// </summary>
        /// <param name="databaseDtuMax">Maximum DTU any one SQL Azure Database can consume.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithAttach<ParentT> WithDatabaseDtuMax(int databaseDtuMax);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the number of shared DTU for elastic pool.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDtu<ParentT> 
    {
        /// <summary>
        /// Sets the total shared DTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="dtu">Total shared DTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithAttach<ParentT> WithDtu(int dtu);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the eDTU and storage capacity limits for a basic pool.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithBasicEdition<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithBasicEditionBeta<ParentT>
    {
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the eDTU and storage capacity limits for a standard pool.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStandardEdition<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithStandardEditionBeta<ParentT>
    {
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the eDTU and storage capacity limits for a premium pool.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPremiumEdition<ParentT>  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithPremiumEditionBeta<ParentT>
    {
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the storage limit for the SQL Azure Database Elastic Pool in MB.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStorageCapacity<ParentT> 
    {
        /// <summary>
        /// Sets the storage limit for the SQL Azure Database Elastic Pool in MB.
        /// </summary>
        /// <param name="storageMB">Storage limit for the SQL Azure Database Elastic Pool in MB.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithAttach<ParentT> WithStorageCapacity(int storageMB);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the edition for database.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithEditionBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the basic edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithBasicEdition<ParentT> WithBasicPool();

        /// <summary>
        /// Sets the standard edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithStandardEdition<ParentT> WithStandardPool();

        /// <summary>
        /// Sets the edition for the SQL Elastic Pool.
        /// </summary>
        /// <param name="edition">Edition to be set for elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithAttach<ParentT> WithEdition(ElasticPoolEdition edition);

        /// <summary>
        /// Sets the premium edition for the SQL Elastic Pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithPremiumEdition<ParentT> WithPremiumPool();
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the eDTU and storage capacity limits for a basic pool.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithBasicEditionBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithBasicEdition<ParentT> WithDatabaseDtuMin(SqlElasticPoolBasicMinEDTUs eDTU);

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithBasicEdition<ParentT> WithReservedDtu(SqlElasticPoolBasicEDTUs eDTU);

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithBasicEdition<ParentT> WithDatabaseDtuMax(SqlElasticPoolBasicMaxEDTUs eDTU);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the eDTU and storage capacity limits for a standard pool.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStandardEditionBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithStandardEdition<ParentT> WithDatabaseDtuMin(SqlElasticPoolStandardMinEDTUs eDTU);

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithStandardEdition<ParentT> WithReservedDtu(SqlElasticPoolStandardEDTUs eDTU);

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithStandardEdition<ParentT> WithDatabaseDtuMax(SqlElasticPoolStandardMaxEDTUs eDTU);

        /// <summary>
        /// Sets the storage capacity for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="storageCapacity">Storage capacity for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithStandardEdition<ParentT> WithStorageCapacity(SqlElasticPoolStandardStorage storageCapacity);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the eDTU and storage capacity limits for a premium pool.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPremiumEditionBeta<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the minimum number of eDTU for each database in the pool are regardless of its activity.
        /// </summary>
        /// <param name="eDTU">Minimum eDTU for all SQL Azure databases.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithPremiumEdition<ParentT> WithDatabaseDtuMin(SqlElasticPoolPremiumMinEDTUs eDTU);

        /// <summary>
        /// Sets the total shared eDTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="eDTU">Total shared eDTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithPremiumEdition<ParentT> WithReservedDtu(SqlElasticPoolPremiumEDTUs eDTU);

        /// <summary>
        /// Sets the maximum number of eDTU a database in the pool can consume.
        /// </summary>
        /// <param name="eDTU">Maximum eDTU a database in the pool can consume.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithPremiumEdition<ParentT> WithDatabaseDtuMax(SqlElasticPoolPremiumMaxEDTUs eDTU);

        /// <summary>
        /// Sets the storage capacity for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="storageCapacity">Storage capacity for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithPremiumEdition<ParentT> WithStorageCapacity(SqlElasticPoolPremiumSorage storageCapacity);
    }
}