// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.AzureFirewall.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AzureFirewallsImpl :
        IAzureFirewalls
    {
        private readonly NetworkManager manager;
        internal AzureFirewallsImpl(NetworkManager networkManager)
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

        public IAzureFirewallsOperations Inner
        {
            get
            {
                return manager.Inner.AzureFirewalls;
            }
        }

        public IBlank Define(string name)
        {
            return WrapModel(name);
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

        public IAzureFirewall GetById(string id)
        {
           return Extensions.Synchronize(() => GetByIdAsync(id, CancellationToken.None));
        }

        public async Task<IAzureFirewall> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GetByResourceGroupAsync(
                ResourceUtils.GroupFromResourceId(id),
                ResourceUtils.NameFromResourceId(id),
                cancellationToken);
        }

        public IAzureFirewall GetByResourceGroup(string resourceGroupName, string name)
        {
            return Extensions.Synchronize(() => GetByResourceGroupAsync(resourceGroupName, name, CancellationToken.None));
        }

        public async Task<IAzureFirewall> GetByResourceGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureFirewallInner inner = await Inner.GetAsync(
                resourceGroupName,
                name,
                cancellationToken);
            return inner == null ? null : WrapModel(inner);
        }

        public IEnumerable<IAzureFirewall> List()
        {
            return Extensions.Synchronize(() => ListAsync(true, CancellationToken.None));
        }

        public async Task<IPagedCollection<IAzureFirewall>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IAzureFirewall, AzureFirewallInner>.LoadPage(
                async(cancellation) => await Inner.ListAllAsync(cancellation),
                Inner.ListAllNextAsync,
                WrapModel,
                loadAllPages,
                cancellationToken);
        }

        public IEnumerable<IAzureFirewall> ListByResourceGroup(string resourceGroupName)
        {
            return Extensions.Synchronize(() => ListByResourceGroupAsync(resourceGroupName, true, CancellationToken.None));
        }

        public async Task<IPagedCollection<IAzureFirewall>> ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IAzureFirewall, AzureFirewallInner>.LoadPage(
                async(cancellation) => await Inner.ListAsync(resourceGroupName, cancellation),
                Inner.ListNextAsync,
                WrapModel,
                loadAllPages,
                cancellationToken);
        }

        protected AzureFirewallImpl WrapModel(string name)
        {
            return WrapModel(new AzureFirewallInner(name: name));
        }

        protected AzureFirewallImpl WrapModel(AzureFirewallInner inner)
        {
            return new AzureFirewallImpl(inner.Name, inner, manager);
        }
    }
}
