// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point to private link services management API in Azure.
    /// </summary>
    public interface IPrivateLinkServices :
        ISupportsCreating<PrivateLinkService.Definition.IBlank>,
        ISupportsGettingById<IPrivateLinkService>,
        ISupportsGettingByResourceGroup<IPrivateLinkService>,
        ISupportsListingByResourceGroup<IPrivateLinkService>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        IHasManager<INetworkManager>,
        IHasInner<IPrivateLinkServicesOperations>
    {
        /// <summary>
        /// Checks whether the subscription is visible to private link service.
        /// </summary>
        /// <param name="location">The value of location.</param>
        /// <param name="privateLinkServiceAlias">The value of private link service alias.</param>
        /// <return>The private link service visibility.</return>
        IPrivateLinkServiceVisibility CheckVisibility(string location, string privateLinkServiceAlias = default(string));

        /// <summary>
        /// Checks whether the subscription is visible to private link service asynchronously.
        /// </summary>
        /// <param name="location">The value of location.</param>
        /// <param name="privateLinkServiceAlias">The value of private link service alias.</param>
        /// <return>The private link service visibility.</return>
        Task<IPrivateLinkServiceVisibility> CheckVisibilityAsync(string location, string privateLinkServiceAlias = default(string), CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Checks whether the subscription is visible to private link service.
        /// </summary>
        /// <param name="resourceGroupName">The value of resource group name.</param>
        /// <param name="location">The value of location.</param>
        /// <param name="privateLinkServiceAlias">The value of private link service alias.</param>
        /// <return>The private link service visibility.</return>
        IPrivateLinkServiceVisibility CheckVisibilityByResourceGroup(string resourceGroupName, string location, string privateLinkServiceAlias = default(string));

        /// <summary>
        /// Checks whether the subscription is visible to private link service asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The value of resource group name.</param>
        /// <param name="location">The value of location.</param>
        /// <param name="privateLinkServiceAlias">The value of private link service alias.</param>
        /// <return>The private link service visibility.</return>
        Task<IPrivateLinkServiceVisibility> CheckVisibilityByResourceGroupAsync(string resourceGroupName, string location, string privateLinkServiceAlias = default(string), CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all auto approved private link service.
        /// </summary>
        /// <param name="location">The value of location.</param>
        /// <return>The list of auto approved private link service.</return>
        IEnumerable<IAutoApprovedPrivateLinkService> ListAutoApprovedPrivateLinkServices(string location);

        /// <summary>
        /// Lists all auto approved private link service asynchronously.
        /// </summary>
        /// <param name="location">The value of location.</param>
        /// <return>The list of auto approved private link service.</return>
        Task<IPagedCollection<IAutoApprovedPrivateLinkService>> ListAutoApprovedPrivateLinkServicesAsync(string location, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all auto approved private link services.
        /// </summary>
        /// <param name="resourceGroupName">The value of resource group name.</param>
        /// <param name="location">The value of location.</param>
        /// <return>The list of auto approved private link services.</return>
        IEnumerable<IAutoApprovedPrivateLinkService> ListAutoApprovedPrivateLinkServicesByResourceGroup(string resourceGroupName, string location);

        /// <summary>
        /// Lists all auto approved private link service asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The value of resource group name.</param>
        /// <param name="location">The value of location.</param>
        /// <return>The list of auto approved private link services.</return>
        Task<IPagedCollection<IAutoApprovedPrivateLinkService>> ListAutoApprovedPrivateLinkServicesByResourceGroupAsync(string resourceGroupName, string location, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all private link services in a subscription.
        /// </summary>
        /// <return>The list of private link services.</return>
        IEnumerable<IPrivateLinkService> ListBySubscription();

        /// <summary>
        /// Lists all private link services in a subscription asynchronously.
        /// </summary>
        /// <return>The list of private link services.</return>
        Task<IPagedCollection<IPrivateLinkService>> ListBySubscriptionAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the specific private end point connection by specific private link service in the resource group.
        /// </summary>
        /// <param name="resourceGroupName">The value of resource group name.</param>
        /// <param name="privateLinkServiceName">The value of private link service name.</param>
        /// <param name="privateEndpointConnectionName">The value of private endpoint connection name.</param>
        /// <return>The private endpoint connection.</return>
        IPrivateEndpointConnection GetPrivateEndpointConnection(string resourceGroupName, string privateLinkServiceName, string privateEndpointConnectionName);

        /// <summary>
        /// Gets the specific private end point connection by specific private link service in the resource group asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The value of resource group name.</param>
        /// <param name="privateLinkServiceName">The value of private link service name.</param>
        /// <param name="privateEndpointConnectionName">The value of private endpoint connection name.</param>
        /// <return>The private endpoint connection.</return>
        Task<IPrivateEndpointConnection> GetPrivateEndpointConnectionAsync(string resourceGroupName, string privateLinkServiceName, string privateEndpointConnectionName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specific private end point connection by specific private link service in the resource group.
        /// </summary>
        /// <param name="resourceGroupName">The value of resource group name.</param>
        /// <param name="privateLinkServiceName">The value of private link service name.</param>
        /// <param name="privateEndpointConnectionName">The value of private endpoint connection name.</param>
        void DeletePrivateEndpointConnection(string resourceGroupName, string privateLinkServiceName, string privateEndpointConnectionName);

        /// <summary>
        /// Deletes the specific private end point connection by specific private link service in the resource group asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The value of resource group name.</param>
        /// <param name="privateLinkServiceName">The value of private link service name.</param>
        /// <param name="privateEndpointConnectionName">The value of private endpoint connection name.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        Task DeletePrivateEndpointConnectionAsync(string resourceGroupName, string privateLinkServiceName, string privateEndpointConnectionName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all private endpoint connections in the resource group.
        /// </summary>
        /// <param name="resourceGroupName">The value of resource group name.</param>
        /// <param name="privateLinkServiceName">The value of private link service.</param>
        /// <return>The list of private endpoint connections.</return>
        IEnumerable<IPrivateEndpointConnection> ListPrivateEndpointConnections(string resourceGroupName, string privateLinkServiceName);

        /// <summary>
        /// Lists all private endpoint connections in the resource group asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The value of resource group name.</param>
        /// <param name="privateLinkServiceName">The value of private link service.</param>
        /// <return>The list of private endpoint connections.</return>
        Task<IPagedCollection<IPrivateEndpointConnection>> ListPrivateEndpointConnectionsAsync(string resourceGroupName, string privateLinkServiceName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));
    }
}
