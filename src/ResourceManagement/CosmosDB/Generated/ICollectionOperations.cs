// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CollectionOperations operations.
    /// </summary>
    public partial interface ICollectionOperations
    {
        /// <summary>
        /// Retrieves the metrics determined by the given filter for the given
        /// database account and collection.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseRid'>
        /// Cosmos DB database rid.
        /// </param>
        /// <param name='collectionRid'>
        /// Cosmos DB collection rid.
        /// </param>
        /// <param name='filter'>
        /// An OData filter expression that describes a subset of metrics to
        /// return. The parameters that can be filtered are name.value (name of
        /// the metric, can have an or of multiple names), startTime, endTime,
        /// and timeGrain. The supported operator is eq.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IEnumerable<Metric>>> ListMetricsWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseRid, string collectionRid, string filter, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Retrieves the usages (most recent storage data) for the given
        /// collection.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseRid'>
        /// Cosmos DB database rid.
        /// </param>
        /// <param name='collectionRid'>
        /// Cosmos DB collection rid.
        /// </param>
        /// <param name='filter'>
        /// An OData filter expression that describes a subset of usages to
        /// return. The supported parameter is name.value (name of the metric,
        /// can have an or of multiple names).
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IEnumerable<Usage>>> ListUsagesWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseRid, string collectionRid, string filter = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Retrieves metric definitions for the given collection.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseRid'>
        /// Cosmos DB database rid.
        /// </param>
        /// <param name='collectionRid'>
        /// Cosmos DB collection rid.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IEnumerable<MetricDefinition>>> ListMetricDefinitionsWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseRid, string collectionRid, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
