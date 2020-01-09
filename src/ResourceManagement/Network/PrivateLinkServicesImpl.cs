// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PrivateLinkServicesImpl :
        IPrivateLinkServices
    {
        private readonly NetworkManager manager;
        internal PrivateLinkServicesImpl(NetworkManager networkManager)
        {
            manager = networkManager;
        }

        public INetworkManager Manager
        {
            get
            {
                return manager;
            }
        }

        public IPrivateLinkServicesOperations Inner
        {
            get
            {
                return manager.Inner.PrivateLinkServices;
            }
        }

        public IPrivateLinkServiceVisibility CheckVisibility(string location, string privateLinkServiceAlias = default(string))
        {
            return Extensions.Synchronize(() => CheckVisibilityAsync(location, privateLinkServiceAlias, CancellationToken.None));
        }

        public async Task<IPrivateLinkServiceVisibility> CheckVisibilityAsync(string location, string privateLinkServiceAlias = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            PrivateLinkServiceVisibilityInner inner = await Inner.CheckPrivateLinkServiceVisibilityAsync(
                location,
                privateLinkServiceAlias,
                cancellationToken);
            return inner == null ? null : new PrivateLinkServiceVisibilityImpl(inner);
        }

        public IPrivateLinkServiceVisibility CheckVisibilityByResourceGroup(string resourceGroupName, string location, string privateLinkServiceAlias = default(string))
        {
            return Extensions.Synchronize(() => CheckVisibilityByResourceGroupAsync(resourceGroupName, location, privateLinkServiceAlias, CancellationToken.None));
        }

        public async Task<IPrivateLinkServiceVisibility> CheckVisibilityByResourceGroupAsync(string resourceGroupName, string location, string privateLinkServiceAlias = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            PrivateLinkServiceVisibilityInner inner = await Inner.CheckPrivateLinkServiceVisibilityByResourceGroupAsync(
                location,
                resourceGroupName,
                privateLinkServiceAlias,
                cancellationToken);
            return inner == null ? null : new PrivateLinkServiceVisibilityImpl(inner);
        }

        PrivateLinkService.Definition.IBlank ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<PrivateLinkService.Definition.IBlank>.Define(string name)
        {
            return WrapModel(new PrivateLinkServiceInner(name: name));
        }

        public void DeleteById(string id)
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id, CancellationToken.None));
        }

        public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await DeleteByResourceGroupAsync(
                ResourceUtils.GroupFromResourceId(id),
                ResourceUtils.NameFromResourceId(id),
                cancellationToken);
        }

        public void DeleteByResourceGroup(string resourceGroupName, string name)
        {
            Extensions.Synchronize(() => DeleteByResourceGroupAsync(resourceGroupName, name, CancellationToken.None));
        }

        public async Task DeleteByResourceGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(resourceGroupName, name, cancellationToken);
        }

        public void DeletePrivateEndpointConnection(string resourceGroupName, string privateLinkServiceName, string privateEndpointConnectionName)
        {
            Extensions.Synchronize(() => DeletePrivateEndpointConnectionAsync(resourceGroupName, privateLinkServiceName, privateEndpointConnectionName, CancellationToken.None));
        }

        public async Task DeletePrivateEndpointConnectionAsync(string resourceGroupName, string privateLinkServiceName, string privateEndpointConnectionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeletePrivateEndpointConnectionAsync(resourceGroupName, privateLinkServiceName, privateEndpointConnectionName, cancellationToken);
        }

        public IPrivateLinkService GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id, CancellationToken.None));
        }

        public async Task<IPrivateLinkService> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            PrivateLinkServiceInner inner = await Inner.GetAsync(
                ResourceUtils.GroupFromResourceId(id),
                ResourceUtils.NameFromResourceId(id),
                null,
                cancellationToken);
            return inner == null ? null : WrapModel(inner);
        }

        public IPrivateLinkService GetByResourceGroup(string resourceGroupName, string name)
        {
            return Extensions.Synchronize(() => GetByResourceGroupAsync(resourceGroupName, name, CancellationToken.None));
        }

        public async Task<IPrivateLinkService> GetByResourceGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            PrivateLinkServiceInner inner = await Inner.GetAsync(resourceGroupName, name, null, cancellationToken);
            return inner == null ? null : WrapModel(inner);
        }

        public IPrivateEndpointConnection GetPrivateEndpointConnection(string resourceGroupName, string privateLinkServiceName, string privateEndpointConnectionName)
        {
            return Extensions.Synchronize(() => GetPrivateEndpointConnectionAsync(resourceGroupName, privateLinkServiceName, privateEndpointConnectionName));
        }

        public async Task<IPrivateEndpointConnection> GetPrivateEndpointConnectionAsync(string resourceGroupName, string privateLinkServiceName, string privateEndpointConnectionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            PrivateEndpointConnectionInner inner = await Inner.GetPrivateEndpointConnectionAsync(resourceGroupName, privateLinkServiceName, privateEndpointConnectionName, null, cancellationToken);
            return inner == null ? null : new PrivateEndpointConnectionImpl(inner, Manager);
        }

        public IEnumerable<IAutoApprovedPrivateLinkService> ListAutoApprovedPrivateLinkServices(string location)
        {
            return Extensions.Synchronize(() => ListAutoApprovedPrivateLinkServicesAsync(location, true, CancellationToken.None));
        }

        public async Task<IPagedCollection<IAutoApprovedPrivateLinkService>> ListAutoApprovedPrivateLinkServicesAsync(string location, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IAutoApprovedPrivateLinkService, AutoApprovedPrivateLinkService>.LoadPage(
                async(cancellation) => await Inner.ListAutoApprovedPrivateLinkServicesAsync(location ,cancellation),
                Inner.ListAutoApprovedPrivateLinkServicesNextAsync,
                WrapAutoApprovedService,
                loadAllPages,
                cancellationToken);
        }

        public IEnumerable<IAutoApprovedPrivateLinkService> ListAutoApprovedPrivateLinkServicesByResourceGroup(string resourceGroupName, string location)
        {
            return Extensions.Synchronize(() => ListAutoApprovedPrivateLinkServicesByResourceGroupAsync(resourceGroupName, location, true, CancellationToken.None));
        }

        public async Task<IPagedCollection<IAutoApprovedPrivateLinkService>> ListAutoApprovedPrivateLinkServicesByResourceGroupAsync(string resourceGroupName, string location, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IAutoApprovedPrivateLinkService, AutoApprovedPrivateLinkService>.LoadPage(
                async (cancellation) => await Inner.ListAutoApprovedPrivateLinkServicesByResourceGroupAsync(location, resourceGroupName, cancellation),
                Inner.ListAutoApprovedPrivateLinkServicesByResourceGroupNextAsync,
                WrapAutoApprovedService,
                loadAllPages,
                cancellationToken);
        }

        public IEnumerable<IPrivateLinkService> ListByResourceGroup(string resourceGroupName)
        {
            return Extensions.Synchronize(() => ListByResourceGroupAsync(resourceGroupName, true, CancellationToken.None));
        }

        public async Task<IPagedCollection<IPrivateLinkService>> ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IPrivateLinkService, PrivateLinkServiceInner>.LoadPage(
                async (cancellation) => await Inner.ListAsync(resourceGroupName, cancellation),
                Inner.ListNextAsync,
                WrapModel,
                loadAllPages,
                cancellationToken);
        }

        public IEnumerable<IPrivateLinkService> ListBySubscription()
        {
            return Extensions.Synchronize(() => ListBySubscriptionAsync(true, CancellationToken.None));
        }

        public async Task<IPagedCollection<IPrivateLinkService>> ListBySubscriptionAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IPrivateLinkService, PrivateLinkServiceInner>.LoadPage(
                async (cancellation) => await Inner.ListBySubscriptionAsync(cancellation),
                Inner.ListBySubscriptionNextAsync,
                WrapModel,
                loadAllPages,
                cancellationToken);
        }

        public IEnumerable<IPrivateEndpointConnection> ListPrivateEndpointConnections(string resourceGroupName, string privateLinkServiceName)
        {
            return Extensions.Synchronize(() => ListPrivateEndpointConnectionsAsync(resourceGroupName, privateLinkServiceName, true, CancellationToken.None));
        }

        public async Task<IPagedCollection<IPrivateEndpointConnection>> ListPrivateEndpointConnectionsAsync(string resourceGroupName, string privateLinkServiceName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IPrivateEndpointConnection, PrivateEndpointConnectionInner>.LoadPage(
                async (cancellation) => await Inner.ListPrivateEndpointConnectionsAsync(resourceGroupName, privateLinkServiceName, cancellation),
                Inner.ListPrivateEndpointConnectionsNextAsync,
                WrapPrivateEndpointConnetion,
                loadAllPages,
                cancellationToken);
        }

        protected PrivateLinkServiceImpl WrapModel(PrivateLinkServiceInner inner)
        {
            return new PrivateLinkServiceImpl(inner.Name, inner, manager);
        }

        protected AutoApprovedPrivateLinkServiceImpl WrapAutoApprovedService(AutoApprovedPrivateLinkService inner)
        {
            return new AutoApprovedPrivateLinkServiceImpl(inner);
        }

        protected PrivateEndpointConnectionImpl WrapPrivateEndpointConnetion(PrivateEndpointConnectionInner inner)
        {
            return new PrivateEndpointConnectionImpl(inner, Manager);
        }
    }
}
