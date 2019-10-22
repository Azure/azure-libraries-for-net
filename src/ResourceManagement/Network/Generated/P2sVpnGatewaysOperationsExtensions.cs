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
    /// Extension methods for P2sVpnGatewaysOperations.
    /// </summary>
    public static partial class P2sVpnGatewaysOperationsExtensions
    {
            /// <summary>
            /// Retrieves the details of a virtual wan p2s vpn gateway.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name of the P2SVpnGateway.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the gateway.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<P2SVpnGatewayInner> GetAsync(this IP2sVpnGatewaysOperations operations, string resourceGroupName, string gatewayName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, gatewayName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates a virtual wan p2s vpn gateway if it doesn't exist else updates the
            /// existing gateway.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name of the P2SVpnGateway.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the gateway.
            /// </param>
            /// <param name='p2SVpnGatewayParameters'>
            /// Parameters supplied to create or Update a virtual wan p2s vpn gateway.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<P2SVpnGatewayInner> CreateOrUpdateAsync(this IP2sVpnGatewaysOperations operations, string resourceGroupName, string gatewayName, P2SVpnGatewayInner p2SVpnGatewayParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, gatewayName, p2SVpnGatewayParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates virtual wan p2s vpn gateway tags.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name of the P2SVpnGateway.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the gateway.
            /// </param>
            /// <param name='tags'>
            /// Resource tags.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<P2SVpnGatewayInner> UpdateTagsAsync(this IP2sVpnGatewaysOperations operations, string resourceGroupName, string gatewayName, IDictionary<string, string> tags = default(IDictionary<string, string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateTagsWithHttpMessagesAsync(resourceGroupName, gatewayName, tags, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes a virtual wan p2s vpn gateway.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name of the P2SVpnGateway.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the gateway.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IP2sVpnGatewaysOperations operations, string resourceGroupName, string gatewayName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, gatewayName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Lists all the P2SVpnGateways in a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name of the P2SVpnGateway.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<P2SVpnGatewayInner>> ListByResourceGroupAsync(this IP2sVpnGatewaysOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists all the P2SVpnGateways in a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<P2SVpnGatewayInner>> ListAsync(this IP2sVpnGatewaysOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Generates VPN profile for P2S client of the P2SVpnGateway in the specified
            /// resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the P2SVpnGateway.
            /// </param>
            /// <param name='authenticationMethod'>
            /// VPN client authentication method. Possible values include: 'EAPTLS',
            /// 'EAPMSCHAPv2'
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<VpnProfileResponseInner> GenerateVpnProfileAsync(this IP2sVpnGatewaysOperations operations, string resourceGroupName, string gatewayName, AuthenticationMethod authenticationMethod = default(AuthenticationMethod), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GenerateVpnProfileWithHttpMessagesAsync(resourceGroupName, gatewayName, authenticationMethod, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the connection health of P2S clients of the virtual wan P2SVpnGateway
            /// in the specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the P2SVpnGateway.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<P2SVpnGatewayInner> GetP2sVpnConnectionHealthAsync(this IP2sVpnGatewaysOperations operations, string resourceGroupName, string gatewayName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetP2sVpnConnectionHealthWithHttpMessagesAsync(resourceGroupName, gatewayName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates a virtual wan p2s vpn gateway if it doesn't exist else updates the
            /// existing gateway.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name of the P2SVpnGateway.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the gateway.
            /// </param>
            /// <param name='p2SVpnGatewayParameters'>
            /// Parameters supplied to create or Update a virtual wan p2s vpn gateway.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<P2SVpnGatewayInner> BeginCreateOrUpdateAsync(this IP2sVpnGatewaysOperations operations, string resourceGroupName, string gatewayName, P2SVpnGatewayInner p2SVpnGatewayParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, gatewayName, p2SVpnGatewayParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates virtual wan p2s vpn gateway tags.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name of the P2SVpnGateway.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the gateway.
            /// </param>
            /// <param name='tags'>
            /// Resource tags.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<P2SVpnGatewayInner> BeginUpdateTagsAsync(this IP2sVpnGatewaysOperations operations, string resourceGroupName, string gatewayName, IDictionary<string, string> tags = default(IDictionary<string, string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginUpdateTagsWithHttpMessagesAsync(resourceGroupName, gatewayName, tags, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes a virtual wan p2s vpn gateway.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name of the P2SVpnGateway.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the gateway.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IP2sVpnGatewaysOperations operations, string resourceGroupName, string gatewayName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, gatewayName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Generates VPN profile for P2S client of the P2SVpnGateway in the specified
            /// resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the P2SVpnGateway.
            /// </param>
            /// <param name='authenticationMethod'>
            /// VPN client authentication method. Possible values include: 'EAPTLS',
            /// 'EAPMSCHAPv2'
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<VpnProfileResponseInner> BeginGenerateVpnProfileAsync(this IP2sVpnGatewaysOperations operations, string resourceGroupName, string gatewayName, AuthenticationMethod authenticationMethod = default(AuthenticationMethod), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginGenerateVpnProfileWithHttpMessagesAsync(resourceGroupName, gatewayName, authenticationMethod, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the connection health of P2S clients of the virtual wan P2SVpnGateway
            /// in the specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the P2SVpnGateway.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<P2SVpnGatewayInner> BeginGetP2sVpnConnectionHealthAsync(this IP2sVpnGatewaysOperations operations, string resourceGroupName, string gatewayName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginGetP2sVpnConnectionHealthWithHttpMessagesAsync(resourceGroupName, gatewayName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists all the P2SVpnGateways in a resource group.
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
            public static async Task<IPage<P2SVpnGatewayInner>> ListByResourceGroupNextAsync(this IP2sVpnGatewaysOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists all the P2SVpnGateways in a subscription.
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
            public static async Task<IPage<P2SVpnGatewayInner>> ListNextAsync(this IP2sVpnGatewaysOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
