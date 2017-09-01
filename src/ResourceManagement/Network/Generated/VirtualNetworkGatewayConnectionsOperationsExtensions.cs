// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for VirtualNetworkGatewayConnectionsOperations.
    /// </summary>
    public static partial class VirtualNetworkGatewayConnectionsOperationsExtensions
    {
            /// <summary>
            /// Creates or updates a virtual network gateway connection in the specified
            /// resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway connection.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create or update virtual network gateway
            /// connection operation.
            /// </param>
            public static VirtualNetworkGatewayConnectionInner CreateOrUpdate(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, VirtualNetworkGatewayConnectionInner parameters)
            {
                return operations.CreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayConnectionName, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates a virtual network gateway connection in the specified
            /// resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway connection.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create or update virtual network gateway
            /// connection operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<VirtualNetworkGatewayConnectionInner> CreateOrUpdateAsync(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, VirtualNetworkGatewayConnectionInner parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayConnectionName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the specified virtual network gateway connection by resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway connection.
            /// </param>
            public static VirtualNetworkGatewayConnectionInner Get(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName)
            {
                return operations.GetAsync(resourceGroupName, virtualNetworkGatewayConnectionName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the specified virtual network gateway connection by resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway connection.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<VirtualNetworkGatewayConnectionInner> GetAsync(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayConnectionName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the specified virtual network Gateway connection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway connection.
            /// </param>
            public static void Delete(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName)
            {
                operations.DeleteAsync(resourceGroupName, virtualNetworkGatewayConnectionName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the specified virtual network Gateway connection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway connection.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayConnectionName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// The Put VirtualNetworkGatewayConnectionSharedKey operation sets the virtual
            /// network gateway connection shared key for passed virtual network gateway
            /// connection in the specified resource group through Network resource
            /// provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The virtual network gateway connection name.
            /// </param>
            /// <param name='value'>
            /// The virtual network connection shared key value.
            /// </param>
            public static ConnectionSharedKeyInner SetSharedKey(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, string value)
            {
                return operations.SetSharedKeyAsync(resourceGroupName, virtualNetworkGatewayConnectionName, value).GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Put VirtualNetworkGatewayConnectionSharedKey operation sets the virtual
            /// network gateway connection shared key for passed virtual network gateway
            /// connection in the specified resource group through Network resource
            /// provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The virtual network gateway connection name.
            /// </param>
            /// <param name='value'>
            /// The virtual network connection shared key value.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ConnectionSharedKeyInner> SetSharedKeyAsync(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, string value, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SetSharedKeyWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayConnectionName, value, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// The Get VirtualNetworkGatewayConnectionSharedKey operation retrieves
            /// information about the specified virtual network gateway connection shared
            /// key through Network resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The virtual network gateway connection shared key name.
            /// </param>
            public static ConnectionSharedKeyInner GetSharedKey(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName)
            {
                return operations.GetSharedKeyAsync(resourceGroupName, virtualNetworkGatewayConnectionName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Get VirtualNetworkGatewayConnectionSharedKey operation retrieves
            /// information about the specified virtual network gateway connection shared
            /// key through Network resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The virtual network gateway connection shared key name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ConnectionSharedKeyInner> GetSharedKeyAsync(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetSharedKeyWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayConnectionName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// The List VirtualNetworkGatewayConnections operation retrieves all the
            /// virtual network gateways connections created.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            public static IPage<VirtualNetworkGatewayConnectionInner> List(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName)
            {
                return operations.ListAsync(resourceGroupName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List VirtualNetworkGatewayConnections operation retrieves all the
            /// virtual network gateways connections created.
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
            public static async Task<IPage<VirtualNetworkGatewayConnectionInner>> ListAsync(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// The VirtualNetworkGatewayConnectionResetSharedKey operation resets the
            /// virtual network gateway connection shared key for passed virtual network
            /// gateway connection in the specified resource group through Network resource
            /// provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The virtual network gateway connection reset shared key Name.
            /// </param>
            /// <param name='keyLength'>
            /// The virtual network connection reset shared key length, should between 1
            /// and 128.
            /// </param>
            public static ConnectionResetSharedKeyInner ResetSharedKey(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, int keyLength)
            {
                return operations.ResetSharedKeyAsync(resourceGroupName, virtualNetworkGatewayConnectionName, keyLength).GetAwaiter().GetResult();
            }

            /// <summary>
            /// The VirtualNetworkGatewayConnectionResetSharedKey operation resets the
            /// virtual network gateway connection shared key for passed virtual network
            /// gateway connection in the specified resource group through Network resource
            /// provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The virtual network gateway connection reset shared key Name.
            /// </param>
            /// <param name='keyLength'>
            /// The virtual network connection reset shared key length, should between 1
            /// and 128.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ConnectionResetSharedKeyInner> ResetSharedKeyAsync(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, int keyLength, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ResetSharedKeyWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayConnectionName, keyLength, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates a virtual network gateway connection in the specified
            /// resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway connection.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create or update virtual network gateway
            /// connection operation.
            /// </param>
            public static VirtualNetworkGatewayConnectionInner BeginCreateOrUpdate(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, VirtualNetworkGatewayConnectionInner parameters)
            {
                return operations.BeginCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayConnectionName, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates a virtual network gateway connection in the specified
            /// resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway connection.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create or update virtual network gateway
            /// connection operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<VirtualNetworkGatewayConnectionInner> BeginCreateOrUpdateAsync(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, VirtualNetworkGatewayConnectionInner parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayConnectionName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the specified virtual network Gateway connection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway connection.
            /// </param>
            public static void BeginDelete(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName)
            {
                operations.BeginDeleteAsync(resourceGroupName, virtualNetworkGatewayConnectionName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the specified virtual network Gateway connection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway connection.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayConnectionName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// The Put VirtualNetworkGatewayConnectionSharedKey operation sets the virtual
            /// network gateway connection shared key for passed virtual network gateway
            /// connection in the specified resource group through Network resource
            /// provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The virtual network gateway connection name.
            /// </param>
            /// <param name='value'>
            /// The virtual network connection shared key value.
            /// </param>
            public static ConnectionSharedKeyInner BeginSetSharedKey(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, string value)
            {
                return operations.BeginSetSharedKeyAsync(resourceGroupName, virtualNetworkGatewayConnectionName, value).GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Put VirtualNetworkGatewayConnectionSharedKey operation sets the virtual
            /// network gateway connection shared key for passed virtual network gateway
            /// connection in the specified resource group through Network resource
            /// provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The virtual network gateway connection name.
            /// </param>
            /// <param name='value'>
            /// The virtual network connection shared key value.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ConnectionSharedKeyInner> BeginSetSharedKeyAsync(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, string value, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginSetSharedKeyWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayConnectionName, value, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// The VirtualNetworkGatewayConnectionResetSharedKey operation resets the
            /// virtual network gateway connection shared key for passed virtual network
            /// gateway connection in the specified resource group through Network resource
            /// provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The virtual network gateway connection reset shared key Name.
            /// </param>
            /// <param name='keyLength'>
            /// The virtual network connection reset shared key length, should between 1
            /// and 128.
            /// </param>
            public static ConnectionResetSharedKeyInner BeginResetSharedKey(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, int keyLength)
            {
                return operations.BeginResetSharedKeyAsync(resourceGroupName, virtualNetworkGatewayConnectionName, keyLength).GetAwaiter().GetResult();
            }

            /// <summary>
            /// The VirtualNetworkGatewayConnectionResetSharedKey operation resets the
            /// virtual network gateway connection shared key for passed virtual network
            /// gateway connection in the specified resource group through Network resource
            /// provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The virtual network gateway connection reset shared key Name.
            /// </param>
            /// <param name='keyLength'>
            /// The virtual network connection reset shared key length, should between 1
            /// and 128.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ConnectionResetSharedKeyInner> BeginResetSharedKeyAsync(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, int keyLength, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginResetSharedKeyWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayConnectionName, keyLength, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// The List VirtualNetworkGatewayConnections operation retrieves all the
            /// virtual network gateways connections created.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<VirtualNetworkGatewayConnectionInner> ListNext(this IVirtualNetworkGatewayConnectionsOperations operations, string nextPageLink)
            {
                return operations.ListNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List VirtualNetworkGatewayConnections operation retrieves all the
            /// virtual network gateways connections created.
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
            public static async Task<IPage<VirtualNetworkGatewayConnectionInner>> ListNextAsync(this IVirtualNetworkGatewayConnectionsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
