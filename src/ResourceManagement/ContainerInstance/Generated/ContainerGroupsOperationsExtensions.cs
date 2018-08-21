// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ContainerGroupsOperations.
    /// </summary>
    public static partial class ContainerGroupsOperationsExtensions
    {
            /// <summary>
            /// Get a list of container groups in the specified subscription.
            /// </summary>
            /// <remarks>
            /// Get a list of container groups in the specified subscription. This
            /// operation returns properties of each container group including containers,
            /// image registry credentials, restart policy, IP address type, OS type,
            /// state, and volumes.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<ContainerGroupInner>> ListAsync(this IContainerGroupsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get a list of container groups in the specified subscription and resource
            /// group.
            /// </summary>
            /// <remarks>
            /// Get a list of container groups in a specified subscription and resource
            /// group. This operation returns properties of each container group including
            /// containers, image registry credentials, restart policy, IP address type, OS
            /// type, state, and volumes.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<ContainerGroupInner>> ListByResourceGroupAsync(this IContainerGroupsOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get the properties of the specified container group.
            /// </summary>
            /// <remarks>
            /// Gets the properties of the specified container group in the specified
            /// subscription and resource group. The operation returns the properties of
            /// each container group including containers, image registry credentials,
            /// restart policy, IP address type, OS type, state, and volumes.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='containerGroupName'>
            /// The name of the container group.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContainerGroupInner> GetAsync(this IContainerGroupsOperations operations, string resourceGroupName, string containerGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, containerGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Create or update container groups.
            /// </summary>
            /// <remarks>
            /// Create or update container groups with specified configurations.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='containerGroupName'>
            /// The name of the container group.
            /// </param>
            /// <param name='containerGroup'>
            /// The properties of the container group to be created or updated.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContainerGroupInner> CreateOrUpdateAsync(this IContainerGroupsOperations operations, string resourceGroupName, string containerGroupName, ContainerGroupInner containerGroup, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, containerGroupName, containerGroup, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Update container groups.
            /// </summary>
            /// <remarks>
            /// Updates container group tags with specified values.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='containerGroupName'>
            /// The name of the container group.
            /// </param>
            /// <param name='resource'>
            /// The container group resource with just the tags to be updated.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContainerGroupInner> UpdateAsync(this IContainerGroupsOperations operations, string resourceGroupName, string containerGroupName, ResourceInner resource, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(resourceGroupName, containerGroupName, resource, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete the specified container group.
            /// </summary>
            /// <remarks>
            /// Delete the specified container group in the specified subscription and
            /// resource group. The operation does not delete other resources provided by
            /// the user, such as volumes.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='containerGroupName'>
            /// The name of the container group.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContainerGroupInner> DeleteAsync(this IContainerGroupsOperations operations, string resourceGroupName, string containerGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteWithHttpMessagesAsync(resourceGroupName, containerGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Restarts all containers in a container group.
            /// </summary>
            /// <remarks>
            /// Restarts all containers in a contaienr group in place. If container image
            /// has updates, new image will be downloaded.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='containerGroupName'>
            /// The name of the container group.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task RestartAsync(this IContainerGroupsOperations operations, string resourceGroupName, string containerGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.RestartWithHttpMessagesAsync(resourceGroupName, containerGroupName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Stops all containers in a container group.
            /// </summary>
            /// <remarks>
            /// Stops all containers in a contaienr group. Compute resources will be
            /// deallocated and billing will stop.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='containerGroupName'>
            /// The name of the container group.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task StopAsync(this IContainerGroupsOperations operations, string resourceGroupName, string containerGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.StopWithHttpMessagesAsync(resourceGroupName, containerGroupName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Create or update container groups.
            /// </summary>
            /// <remarks>
            /// Create or update container groups with specified configurations.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='containerGroupName'>
            /// The name of the container group.
            /// </param>
            /// <param name='containerGroup'>
            /// The properties of the container group to be created or updated.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContainerGroupInner> BeginCreateOrUpdateAsync(this IContainerGroupsOperations operations, string resourceGroupName, string containerGroupName, ContainerGroupInner containerGroup, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, containerGroupName, containerGroup, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Restarts all containers in a container group.
            /// </summary>
            /// <remarks>
            /// Restarts all containers in a contaienr group in place. If container image
            /// has updates, new image will be downloaded.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='containerGroupName'>
            /// The name of the container group.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginRestartAsync(this IContainerGroupsOperations operations, string resourceGroupName, string containerGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.BeginRestartWithHttpMessagesAsync(resourceGroupName, containerGroupName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get a list of container groups in the specified subscription.
            /// </summary>
            /// <remarks>
            /// Get a list of container groups in the specified subscription. This
            /// operation returns properties of each container group including containers,
            /// image registry credentials, restart policy, IP address type, OS type,
            /// state, and volumes.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<ContainerGroupInner>> ListNextAsync(this IContainerGroupsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get a list of container groups in the specified subscription and resource
            /// group.
            /// </summary>
            /// <remarks>
            /// Get a list of container groups in a specified subscription and resource
            /// group. This operation returns properties of each container group including
            /// containers, image registry credentials, restart policy, IP address type, OS
            /// type, state, and volumes.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<ContainerGroupInner>> ListByResourceGroupNextAsync(this IContainerGroupsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
