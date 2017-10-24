// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.BatchAI;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// ClustersOperations operations.
    /// </summary>
    public partial interface IClustersOperations
    {
        /// <summary>
        /// Adds a cluster. A cluster is a collection of compute nodes.
        /// Multiple jobs can be run on the same cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group to which the resource belongs.
        /// </param>
        /// <param name='clusterName'>
        /// The name of the cluster within the specified resource group.
        /// Cluster names can only contain a combination of alphanumeric
        /// characters along with dash (-) and underscore (_). The name must be
        /// from 1 through 64 characters long.
        /// </param>
        /// <param name='parameters'>
        /// The parameters to provide for cluster creation.
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
        Task<AzureOperationResponse<ClusterInner>> CreateWithHttpMessagesAsync(string resourceGroupName, string clusterName, ClusterCreateParametersInner parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update the properties of a given cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group to which the resource belongs.
        /// </param>
        /// <param name='clusterName'>
        /// The name of the cluster within the specified resource group.
        /// Cluster names can only contain a combination of alphanumeric
        /// characters along with dash (-) and underscore (_). The name must be
        /// from 1 through 64 characters long.
        /// </param>
        /// <param name='parameters'>
        /// Additional parameters for cluster update.
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
        Task<AzureOperationResponse<ClusterInner>> UpdateWithHttpMessagesAsync(string resourceGroupName, string clusterName, ClusterUpdateParametersInner parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes a Cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group to which the resource belongs.
        /// </param>
        /// <param name='clusterName'>
        /// The name of the cluster within the specified resource group.
        /// Cluster names can only contain a combination of alphanumeric
        /// characters along with dash (-) and underscore (_). The name must be
        /// from 1 through 64 characters long.
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
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string clusterName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets information about the specified Cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group to which the resource belongs.
        /// </param>
        /// <param name='clusterName'>
        /// The name of the cluster within the specified resource group.
        /// Cluster names can only contain a combination of alphanumeric
        /// characters along with dash (-) and underscore (_). The name must be
        /// from 1 through 64 characters long.
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
        Task<AzureOperationResponse<ClusterInner>> GetWithHttpMessagesAsync(string resourceGroupName, string clusterName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get the IP address, port of all the compute nodes in the cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group to which the resource belongs.
        /// </param>
        /// <param name='clusterName'>
        /// The name of the cluster within the specified resource group.
        /// Cluster names can only contain a combination of alphanumeric
        /// characters along with dash (-) and underscore (_). The name must be
        /// from 1 through 64 characters long.
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
        Task<AzureOperationResponse<IPage<RemoteLoginInformation>>> ListRemoteLoginInformationWithHttpMessagesAsync(string resourceGroupName, string clusterName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets information about the Clusters associated with the
        /// subscription.
        /// </summary>
        /// <param name='clustersListOptions'>
        /// Additional parameters for the operation
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
        Task<AzureOperationResponse<IPage<ClusterInner>>> ListWithHttpMessagesAsync(ClustersListOptionsInner clustersListOptions = default(ClustersListOptionsInner), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets information about the Clusters associated within the specified
        /// resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group to which the resource belongs.
        /// </param>
        /// <param name='clustersListByResourceGroupOptions'>
        /// Additional parameters for the operation
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
        Task<AzureOperationResponse<IPage<ClusterInner>>> ListByResourceGroupWithHttpMessagesAsync(string resourceGroupName, ClustersListByResourceGroupOptionsInner clustersListByResourceGroupOptions = default(ClustersListByResourceGroupOptionsInner), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Adds a cluster. A cluster is a collection of compute nodes.
        /// Multiple jobs can be run on the same cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group to which the resource belongs.
        /// </param>
        /// <param name='clusterName'>
        /// The name of the cluster within the specified resource group.
        /// Cluster names can only contain a combination of alphanumeric
        /// characters along with dash (-) and underscore (_). The name must be
        /// from 1 through 64 characters long.
        /// </param>
        /// <param name='parameters'>
        /// The parameters to provide for cluster creation.
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
        Task<AzureOperationResponse<ClusterInner>> BeginCreateWithHttpMessagesAsync(string resourceGroupName, string clusterName, ClusterCreateParametersInner parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes a Cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group to which the resource belongs.
        /// </param>
        /// <param name='clusterName'>
        /// The name of the cluster within the specified resource group.
        /// Cluster names can only contain a combination of alphanumeric
        /// characters along with dash (-) and underscore (_). The name must be
        /// from 1 through 64 characters long.
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
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string clusterName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get the IP address, port of all the compute nodes in the cluster.
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
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
        Task<AzureOperationResponse<IPage<RemoteLoginInformation>>> ListRemoteLoginInformationNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets information about the Clusters associated with the
        /// subscription.
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
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
        Task<AzureOperationResponse<IPage<ClusterInner>>> ListNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets information about the Clusters associated within the specified
        /// resource group.
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
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
        Task<AzureOperationResponse<IPage<ClusterInner>>> ListByResourceGroupNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}