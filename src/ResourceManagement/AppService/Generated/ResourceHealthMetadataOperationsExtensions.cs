// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ResourceHealthMetadataOperations.
    /// </summary>
    public static partial class ResourceHealthMetadataOperationsExtensions
    {
            /// <summary>
            /// List all ResourceHealthMetadata for all sites in the subscription.
            /// </summary>
            /// <remarks>
            /// List all ResourceHealthMetadata for all sites in the subscription.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<ResourceHealthMetadataInner>> ListAsync(this IResourceHealthMetadataOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// List all ResourceHealthMetadata for all sites in the resource group in the
            /// subscription.
            /// </summary>
            /// <remarks>
            /// List all ResourceHealthMetadata for all sites in the resource group in the
            /// subscription.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<ResourceHealthMetadataInner>> ListByResourceGroupAsync(this IResourceHealthMetadataOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the category of ResourceHealthMetadata to use for the given site as a
            /// collection
            /// </summary>
            /// <remarks>
            /// Gets the category of ResourceHealthMetadata to use for the given site as a
            /// collection
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='name'>
            /// Name of web app.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<ResourceHealthMetadataInner>> ListBySiteAsync(this IResourceHealthMetadataOperations operations, string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBySiteWithHttpMessagesAsync(resourceGroupName, name, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the category of ResourceHealthMetadata to use for the given site
            /// </summary>
            /// <remarks>
            /// Gets the category of ResourceHealthMetadata to use for the given site
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='name'>
            /// Name of web app
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ResourceHealthMetadataInner> GetBySiteAsync(this IResourceHealthMetadataOperations operations, string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetBySiteWithHttpMessagesAsync(resourceGroupName, name, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the category of ResourceHealthMetadata to use for the given site as a
            /// collection
            /// </summary>
            /// <remarks>
            /// Gets the category of ResourceHealthMetadata to use for the given site as a
            /// collection
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='name'>
            /// Name of web app.
            /// </param>
            /// <param name='slot'>
            /// Name of web app slot. If not specified then will default to production
            /// slot.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<ResourceHealthMetadataInner>> ListBySiteSlotAsync(this IResourceHealthMetadataOperations operations, string resourceGroupName, string name, string slot, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBySiteSlotWithHttpMessagesAsync(resourceGroupName, name, slot, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the category of ResourceHealthMetadata to use for the given site
            /// </summary>
            /// <remarks>
            /// Gets the category of ResourceHealthMetadata to use for the given site
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='name'>
            /// Name of web app
            /// </param>
            /// <param name='slot'>
            /// Name of web app slot. If not specified then will default to production
            /// slot.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ResourceHealthMetadataInner> GetBySiteSlotAsync(this IResourceHealthMetadataOperations operations, string resourceGroupName, string name, string slot, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetBySiteSlotWithHttpMessagesAsync(resourceGroupName, name, slot, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// List all ResourceHealthMetadata for all sites in the subscription.
            /// </summary>
            /// <remarks>
            /// List all ResourceHealthMetadata for all sites in the subscription.
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
            public static async Task<IPage<ResourceHealthMetadataInner>> ListNextAsync(this IResourceHealthMetadataOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// List all ResourceHealthMetadata for all sites in the resource group in the
            /// subscription.
            /// </summary>
            /// <remarks>
            /// List all ResourceHealthMetadata for all sites in the resource group in the
            /// subscription.
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
            public static async Task<IPage<ResourceHealthMetadataInner>> ListByResourceGroupNextAsync(this IResourceHealthMetadataOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the category of ResourceHealthMetadata to use for the given site as a
            /// collection
            /// </summary>
            /// <remarks>
            /// Gets the category of ResourceHealthMetadata to use for the given site as a
            /// collection
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
            public static async Task<IPage<ResourceHealthMetadataInner>> ListBySiteNextAsync(this IResourceHealthMetadataOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBySiteNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the category of ResourceHealthMetadata to use for the given site as a
            /// collection
            /// </summary>
            /// <remarks>
            /// Gets the category of ResourceHealthMetadata to use for the given site as a
            /// collection
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
            public static async Task<IPage<ResourceHealthMetadataInner>> ListBySiteSlotNextAsync(this IResourceHealthMetadataOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBySiteSlotNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
