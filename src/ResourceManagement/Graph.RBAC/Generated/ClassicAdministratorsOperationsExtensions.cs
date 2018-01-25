// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Graph;
    using Microsoft.Azure.Management.Graph.RBAC;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ClassicAdministratorsOperations.
    /// </summary>
    public static partial class ClassicAdministratorsOperationsExtensions
    {

        /// <summary>
        /// Gets service administrator, account administrator, and co-administrators
        /// for the subscription.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='apiVersion'>
        /// The API version to use for this operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IPage<ClassicAdministrator>> ListAsync(this IClassicAdministratorsOperations operations, string apiVersion, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.ListWithHttpMessagesAsync(apiVersion, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }


        /// <summary>
        /// Gets service administrator, account administrator, and co-administrators
        /// for the subscription.
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
        public static async Task<IPage<ClassicAdministrator>> ListNextAsync(this IClassicAdministratorsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

    }
}
