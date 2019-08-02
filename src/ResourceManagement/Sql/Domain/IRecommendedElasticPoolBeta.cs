// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Recommended ElasticPool.
    /// </summary>
    public interface IRecommendedElasticPoolBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Get a specific database in the recommended database.
        /// </summary>
        /// <param name="databaseName">Name of the database to be fetched.</param>
        /// <return>A representation of the deferred computation to get the database in the recommended elastic pool.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> GetDatabaseAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches list of databases by making call to Azure.
        /// </summary>
        /// <return>A representation of the deferred computation of the databases in this recommended elastic pool.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>> ListDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the edition of the Azure SQL Recommended Elastic Pool. The
        /// ElasticPoolEdition enumeration contains all the valid editions.
        /// Possible values include: 'Basic', 'Standard', 'Premium'.
        /// </summary>
        ElasticPoolEdition DatabaseEdition { get; }
    }
}