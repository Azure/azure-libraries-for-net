// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    /// <summary>
    /// A SQL container.
    /// </summary>
    public interface ISqlContainer :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SqlContainerGetResultsInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<ISqlContainer, ISqlDatabase>
    {
        /// <summary>
        /// Gets name of the Cosmos DB SQL container.
        /// </summary>
        string SqlContainerId { get; }

        /// <summary>
        /// Gets the configuration of the indexing policy. By default,
        /// the indexing is automatic for all document paths within the
        /// container.
        /// </summary>
        Models.IndexingPolicy IndexingPolicy { get; }

        /// <summary>
        /// Gets the configuration of the partition key to be used for
        /// partitioning data into multiple partitions.
        /// </summary>
        Models.ContainerPartitionKey PartitionKey { get; }

        /// <summary>
        /// Gets default time to live.
        /// </summary>
        int? DefaultTtl { get; }

        /// <summary>
        /// Gets the unique key policy configuration for specifying
        /// uniqueness constraints on documents in the collection in the Azure
        /// Cosmos DB service.
        /// </summary>
        Models.UniqueKeyPolicy UniqueKeyPolicy { get; }

        /// <summary>
        /// Gets the conflict resolution policy for the container.
        /// </summary>
        Models.ConflictResolutionPolicy ConflictResolutionPolicy { get; }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        string _rid { get; }

        /// <summary>
        /// Gets a system generated property that denotes the last updated
        /// timestamp of the resource.
        /// </summary>
        object _ts { get; }

        /// <summary>
        /// Gets a system generated property representing the resource etag
        /// required for optimistic concurrency control.
        /// </summary>
        string _etag { get; }

        /// <returns>The throughput settings of the SQL container.</returns>
        ThroughputSettingsGetPropertiesResource GetThroughputSettings();

        /// <returns>The throughput settings of the SQL container.</returns>
        Task<ThroughputSettingsGetPropertiesResource> GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <returns>All stored procedures in the container.</returns>
        IEnumerable<SqlStoredProcedureGetPropertiesResource> ListStoredProcedures();

        /// <returns>All stored procedures in the container.</returns>
        Task<IEnumerable<SqlStoredProcedureGetPropertiesResource>> ListStoredProceduresAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="name">The name of the stored procedure.</param>
        /// <returns>The specific stored procedure.</returns>
        SqlStoredProcedureGetPropertiesResource GetStoredProcedure(string name);

        /// <param name="name">The name of the stored procedure.</param>
        /// <returns>The specific stored procedure.</returns>
        Task<SqlStoredProcedureGetPropertiesResource> GetStoredProcedureAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <returns>All user defined functions in the container.</returns>
        IEnumerable<SqlUserDefinedFunctionGetPropertiesResource> ListUserDefinedFunctions();

        /// <returns>All user defined functions in the container.</returns>
        Task<IEnumerable<SqlUserDefinedFunctionGetPropertiesResource>> ListUserDefinedFunctionsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="name">The name of the user defined function.</param>
        /// <returns>The specific user defined function.</returns>
        SqlUserDefinedFunctionGetPropertiesResource GetUserDefinedFunction(string name);

        /// <param name="name">The name of the user defined function.</param>
        /// <returns>The specific user defined function.</returns>
        Task<SqlUserDefinedFunctionGetPropertiesResource> GetUserDefinedFunctionAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <returns>All triggers in the container.</returns>
        IEnumerable<SqlTriggerGetPropertiesResource> ListTriggers();

        /// <returns>All triggers in the container.</returns>
        Task<IEnumerable<SqlTriggerGetPropertiesResource>> ListTriggersAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="name">The name of the trigger.</param>
        /// <returns>The specific trigger.</returns>
        SqlTriggerGetPropertiesResource GetTrigger(string name);

        /// <param name="name">The name of the trigger.</param>
        /// <returns>The specific trigger.</returns>
        Task<SqlTriggerGetPropertiesResource> GetTriggerAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}