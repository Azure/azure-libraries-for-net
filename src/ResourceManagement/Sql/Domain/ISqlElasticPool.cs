// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Elastic Pool.
    /// </summary>
    public interface ISqlElasticPool  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool,Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ElasticPoolInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlElasticPool.Update.IUpdate>
    {
        /// <summary>
        /// Removes an existing SQL Database from the Elastic Pool.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <return>The database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase RemoveDatabase(string databaseName);

        /// <return>The information about elastic pool activities.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity> ListActivities();

        /// <summary>
        /// Gets the maximum DTU any one SQL Azure database can consume.
        /// </summary>
        int DatabaseDtuMax { get; }

        /// <summary>
        /// Gets the name of the region the resource is in.
        /// </summary>
        string RegionName { get; }

        /// <return>A representation of the deferred computation of the information about elastic pool activities.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity>> ListActivitiesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists the SQL databases in this SQL Elastic Pool.
        /// </summary>
        /// <return>The information about databases in elastic pool.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListDatabases();

        /// <summary>
        /// Gets the edition of Azure SQL Elastic Pool.
        /// </summary>
        ElasticPoolEdition Edition { get; }

        /// <summary>
        /// Adds a new SQL Database to the Elastic Pool.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <return>The database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase AddNewDatabase(string databaseName);

        /// <summary>
        /// Deletes this SQL Elastic Pool from the parent SQL server.
        /// </summary>
        void Delete();

        /// <summary>
        /// Lists the database metrics for this SQL Elastic Pool.
        /// </summary>
        /// <param name="filter">An OData filter expression that describes a subset of metrics to return.</param>
        /// <return>The elastic pool's database metrics.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric> ListDatabaseMetrics(string filter);

        /// <summary>
        /// Gets the minimum DTU all SQL Azure Databases are guaranteed.
        /// </summary>
        int DatabaseDtuMin { get; }

        /// <summary>
        /// Asynchronously lists the database metrics for this SQL Elastic Pool.
        /// </summary>
        /// <param name="filter">An OData filter expression that describes a subset of metrics to return.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric>> ListDatabaseMetricsAsync(string filter, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the state of the Azure SQL Elastic Pool.
        /// </summary>
        ElasticPoolState State { get; }

        /// <return>The information about elastic pool database activities.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity>> ListDatabaseActivitiesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists the database metric definitions for this SQL Elastic Pool.
        /// </summary>
        /// <return>The elastic pool's metric definitions.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition> ListDatabaseMetricDefinitions();

        /// <summary>
        /// Gets The total shared DTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        int Dtu { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this elastic pool belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets the storage capacity limit for the SQL Azure Database Elastic Pool in MB.
        /// </summary>
        int StorageCapacityInMB { get; }

        /// <summary>
        /// Deletes this SQL Elastic Pool asynchronously from the parent SQL server.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the creation date of the Azure SQL Elastic Pool.
        /// </summary>
        System.DateTime CreationDate { get; }

        /// <summary>
        /// Adds an existing SQL Database to the Elastic Pool.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <return>The database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase AddExistingDatabase(string databaseName);

        /// <summary>
        /// Adds an existing SQL Database to the Elastic Pool.
        /// </summary>
        /// <param name="database">The database to be added.</param>
        /// <return>The database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase AddExistingDatabase(ISqlDatabase database);

        /// <summary>
        /// Asynchronously lists the SQL databases in this SQL Elastic Pool.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>> ListDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string ParentId { get; }

        /// <summary>
        /// Asynchronously lists the database metric definitions for this SQL Elastic Pool.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition>> ListDatabaseMetricDefinitionsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The information about elastic pool database activities.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity> ListDatabaseActivities();

        /// <summary>
        /// Gets the specific database in the elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the database to look into.</param>
        /// <return>The information about specific database in elastic pool.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase GetDatabase(string databaseName);

        /// <summary>
        /// Gets the storage limit for the SQL Azure Database Elastic Pool in MB.
        /// </summary>
        int StorageMB { get; }

        /// <summary>
        /// Gets the region the resource is in.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Region { get; }
    }
}