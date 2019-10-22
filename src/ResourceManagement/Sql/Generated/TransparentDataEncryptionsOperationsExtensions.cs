// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for TransparentDataEncryptionsOperations.
    /// </summary>
    public static partial class TransparentDataEncryptionsOperationsExtensions
    {
            /// <summary>
            /// Creates or updates a database's transparent data encryption configuration.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='serverName'>
            /// The name of the server.
            /// </param>
            /// <param name='databaseName'>
            /// The name of the database for which setting the transparent data encryption
            /// applies.
            /// </param>
            /// <param name='status'>
            /// The status of the database transparent data encryption. Possible values
            /// include: 'Enabled', 'Disabled'
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<TransparentDataEncryptionInner> CreateOrUpdateAsync(this ITransparentDataEncryptionsOperations operations, string resourceGroupName, string serverName, string databaseName, TransparentDataEncryptionStatus? status = default(TransparentDataEncryptionStatus?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, serverName, databaseName, status, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a database's transparent data encryption configuration.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='serverName'>
            /// The name of the server.
            /// </param>
            /// <param name='databaseName'>
            /// The name of the database for which the transparent data encryption applies.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<TransparentDataEncryptionInner> GetAsync(this ITransparentDataEncryptionsOperations operations, string resourceGroupName, string serverName, string databaseName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, serverName, databaseName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
