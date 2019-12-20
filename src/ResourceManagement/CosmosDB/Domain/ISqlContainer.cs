// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    public interface ISqlContainer :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SqlContainerGetResultsInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<ISqlContainer, ISqlDatabase>
    {
        /// <summary>
        /// Gets name of the Cosmos DB SQL container
        /// </summary>
        string SqlContainerId { get; }

        /// <summary>
        /// Gets the configuration of the indexing policy. By default,
        /// the indexing is automatic for all document paths within the
        /// container
        /// </summary>
        Models.IndexingPolicy IndexingPolicy { get; }

        /// <summary>
        /// Gets the configuration of the partition key to be used for
        /// partitioning data into multiple partitions
        /// </summary>
        Models.ContainerPartitionKey PartitionKey { get; }

        /// <summary>
        /// Gets default time to live
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
    }
}