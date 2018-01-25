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
    using Microsoft.Rest.Azure.OData;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for UsersOperations.
    /// </summary>
    public static partial class UsersOperationsExtensions
    {

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='parameters'>
        /// Parameters to create a user.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<UserInner> CreateAsync(this IUsersOperations operations, UserCreateParametersInner parameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.CreateWithHttpMessagesAsync(parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }


        /// <summary>
        /// Gets list of users for the current tenant.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='odataQuery'>
        /// OData parameters to apply to the operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IPage<UserInner>> ListAsync(this IUsersOperations operations, ODataQuery<UserInner> odataQuery = default(ODataQuery<UserInner>), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.ListWithHttpMessagesAsync(odataQuery, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }


        /// <summary>
        /// Gets user information from the directory.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='upnOrObjectId'>
        /// The object ID or principal name of the user for which to get information.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<UserInner> GetAsync(this IUsersOperations operations, string upnOrObjectId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetWithHttpMessagesAsync(upnOrObjectId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }


        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='upnOrObjectId'>
        /// The object ID or principal name of the user to update.
        /// </param>
        /// <param name='parameters'>
        /// Parameters to update an existing user.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task UpdateAsync(this IUsersOperations operations, string upnOrObjectId, UserUpdateParametersInner parameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.UpdateWithHttpMessagesAsync(upnOrObjectId, parameters, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }


        /// <summary>
        /// Delete a user.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='upnOrObjectId'>
        /// The object ID or principal name of the user to delete.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task DeleteAsync(this IUsersOperations operations, string upnOrObjectId, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.DeleteWithHttpMessagesAsync(upnOrObjectId, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }


        /// <summary>
        /// Gets a collection that contains the object IDs of the groups of which the
        /// user is a member.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='objectId'>
        /// The object ID of the user for which to get group membership.
        /// </param>
        /// <param name='parameters'>
        /// User filtering parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IEnumerable<string>> GetMemberGroupsAsync(this IUsersOperations operations, string objectId, UserGetMemberGroupsParametersInner parameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetMemberGroupsWithHttpMessagesAsync(objectId, parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }


        /// <summary>
        /// Gets a list of users for the current tenant.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='nextLink'>
        /// Next link for the list operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IPage<UserInner>> ListNextAsync(this IUsersOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.ListNextWithHttpMessagesAsync(nextLink, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

    }
}
