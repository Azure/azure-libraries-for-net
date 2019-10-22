// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for DdosProtectionPlansOperations.
    /// </summary>
    public static partial class DdosProtectionPlansOperationsExtensions
    {
            /// <summary>
            /// Deletes the specified DDoS protection plan.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='ddosProtectionPlanName'>
            /// The name of the DDoS protection plan.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IDdosProtectionPlansOperations operations, string resourceGroupName, string ddosProtectionPlanName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, ddosProtectionPlanName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Gets information about the specified DDoS protection plan.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='ddosProtectionPlanName'>
            /// The name of the DDoS protection plan.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DdosProtectionPlanInner> GetAsync(this IDdosProtectionPlansOperations operations, string resourceGroupName, string ddosProtectionPlanName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, ddosProtectionPlanName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates a DDoS protection plan.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='ddosProtectionPlanName'>
            /// The name of the DDoS protection plan.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create or update operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DdosProtectionPlanInner> CreateOrUpdateAsync(this IDdosProtectionPlansOperations operations, string resourceGroupName, string ddosProtectionPlanName, DdosProtectionPlanInner parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, ddosProtectionPlanName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Update a DDoS protection plan tags.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='ddosProtectionPlanName'>
            /// The name of the DDoS protection plan.
            /// </param>
            /// <param name='tags'>
            /// Resource tags.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DdosProtectionPlanInner> UpdateTagsAsync(this IDdosProtectionPlansOperations operations, string resourceGroupName, string ddosProtectionPlanName, IDictionary<string, string> tags = default(IDictionary<string, string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateTagsWithHttpMessagesAsync(resourceGroupName, ddosProtectionPlanName, tags, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets all DDoS protection plans in a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DdosProtectionPlanInner>> ListAsync(this IDdosProtectionPlansOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets all the DDoS protection plans in a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DdosProtectionPlanInner>> ListByResourceGroupAsync(this IDdosProtectionPlansOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the specified DDoS protection plan.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='ddosProtectionPlanName'>
            /// The name of the DDoS protection plan.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IDdosProtectionPlansOperations operations, string resourceGroupName, string ddosProtectionPlanName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, ddosProtectionPlanName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Creates or updates a DDoS protection plan.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='ddosProtectionPlanName'>
            /// The name of the DDoS protection plan.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create or update operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DdosProtectionPlanInner> BeginCreateOrUpdateAsync(this IDdosProtectionPlansOperations operations, string resourceGroupName, string ddosProtectionPlanName, DdosProtectionPlanInner parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, ddosProtectionPlanName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Update a DDoS protection plan tags.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='ddosProtectionPlanName'>
            /// The name of the DDoS protection plan.
            /// </param>
            /// <param name='tags'>
            /// Resource tags.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DdosProtectionPlanInner> BeginUpdateTagsAsync(this IDdosProtectionPlansOperations operations, string resourceGroupName, string ddosProtectionPlanName, IDictionary<string, string> tags = default(IDictionary<string, string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginUpdateTagsWithHttpMessagesAsync(resourceGroupName, ddosProtectionPlanName, tags, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets all DDoS protection plans in a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DdosProtectionPlanInner>> ListNextAsync(this IDdosProtectionPlansOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets all the DDoS protection plans in a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DdosProtectionPlanInner>> ListByResourceGroupNextAsync(this IDdosProtectionPlansOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
