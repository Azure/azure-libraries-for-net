// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Rest.Azure;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for ContainerGroups.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcmluc3RhbmNlLmltcGxlbWVudGF0aW9uLkNvbnRhaW5lckdyb3Vwc0ltcGw=
    internal partial class ContainerGroupsImpl  :
        TopLevelModifiableResources<
            IContainerGroup,
            ContainerGroupImpl,
            Models.ContainerGroupInner,
            IContainerGroupsOperations,
            IContainerInstanceManager>,
        IContainerGroups
    {
        private IStorageManager storageManager;
        private IGraphRbacManager rbacManager;

        ///GENMHASH:4B84CDF05BC23E46E1685CBF90AA771F:68B05A08BFEE37BC22F39B7655B32F57
        public ContainerGroupsImpl(IContainerInstanceManager manager, IStorageManager storageManager, IGraphRbacManager rbacManager)
            : base(manager.Inner.ContainerGroups, manager)
        {
            this.storageManager = storageManager;
            this.rbacManager = rbacManager;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public ContainerGroupImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:27CE3B7EA8FFD4C215F2B93764A6F289
        protected override ContainerGroupImpl WrapModel(string name)
        {
            return new ContainerGroupImpl(name, new ContainerGroupInner(), this.Manager, this.storageManager, this.rbacManager);
        }

        ///GENMHASH:1B8C0DFED1520223EC9FC70DFE54F8AF:249E41BD7DC18164687B92988001D319
        protected override IContainerGroup WrapModel(ContainerGroupInner inner)
        {
            return inner != null ? new ContainerGroupImpl(inner.Name, inner, this.Manager, this.storageManager, this.rbacManager) : null;
        }

        ///GENMHASH:7D35601E6590F84E3EC86E2AC56E37A0:6DEC1347388279A0EAAC235B49F13A67
        protected async Task DeleteInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.ContainerGroups.DeleteAsync(resourceGroupName, name, cancellationToken: cancellationToken);
        }

        protected override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return this.DeleteInnerAsync(groupName, name, cancellationToken);
        }

        protected override Task<ContainerGroupInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return this.Manager.Inner.ContainerGroups.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }

        protected override Task<IPage<ContainerGroupInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return this.Manager.Inner.ContainerGroups.ListAsync(cancellationToken: cancellationToken);
        }

        protected override Task<IPage<ContainerGroupInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return this.Manager.Inner.ContainerGroups.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellationToken);
        }

        protected override Task<IPage<ContainerGroupInner>> ListInnerByGroupNextAsync(string link, CancellationToken cancellationToken)
        {
            return this.Manager.Inner.ContainerGroups.ListByResourceGroupNextAsync(link, cancellationToken: cancellationToken);
        }

        protected override Task<IPage<ContainerGroupInner>> ListInnerNextAsync(string link, CancellationToken cancellationToken)
        {
            return this.Manager.Inner.ContainerGroups.ListNextAsync(link, cancellationToken: cancellationToken);
        }

        ///GENMHASH:1087847AA7770A992044FCAD7C2E6E25:25ECC310DA204D7AE9DF59ABB6BE48D0
        public string GetLogContent(string resourceGroupName, string containerGroupName, string containerName)
        {
            return Extensions.Synchronize(() => this.Manager.Inner.Container.ListLogsAsync(resourceGroupName, containerGroupName, containerName)).Content;
        }

        ///GENMHASH:930B716992CF464D85E2800B8D7A3CAC:CCC7635873270CED63B2619818684889
        public string GetLogContent(string resourceGroupName, string containerGroupName, string containerName, int tailLineCount)
        {
            return Extensions.Synchronize(() => this.Manager.Inner.Container.ListLogsAsync(resourceGroupName, containerGroupName, containerName, tailLineCount)).Content;
        }

        ///GENMHASH:E5F0C5A3C906C759F86B2236BA4C8F2D:082860BCBD9604C97D9A7CDF1A2753E0
        public async Task<string> GetLogContentAsync(string resourceGroupName, string containerGroupName, string containerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return (await this.Manager.Inner.Container.ListLogsAsync(resourceGroupName, containerGroupName, containerName, cancellationToken: cancellationToken)).Content;
        }

        ///GENMHASH:EE41FB01DE3059005BFFAFA1F8F0593D:9E719F49B3FD58CCC203BAE5EDDB5218
        public async Task<string> GetLogContentAsync(string resourceGroupName, string containerGroupName, string containerName, int tailLineCount, CancellationToken cancellationToken = default(CancellationToken))
        {
            return (await this.Manager.Inner.Container.ListLogsAsync(resourceGroupName, containerGroupName, containerName, tailLineCount, cancellationToken: cancellationToken)).Content;
        }

        public override IEnumerable<IContainerGroup> List()
        {

            return WrapList(Extensions.Synchronize(() => this.ListInnerAsync(default(CancellationToken)))
                .AsContinuousCollection(link => Extensions.Synchronize(() => ListInnerNextAsync(link, default(CancellationToken)))))
                .Select(x =>
                {
                    return x.Refresh();
                });
        }

        public override IEnumerable<IContainerGroup> ListByResourceGroup(string resourceGroupName)
        {
            return WrapList(Extensions.Synchronize(() => this.ListInnerByGroupAsync(resourceGroupName, default(CancellationToken)))
                .AsContinuousCollection(link => Extensions.Synchronize(() => ListInnerByGroupNextAsync(link, default(CancellationToken)))))
                .Select(x =>
                {
                    return x.Refresh();
                });
        }

        public override async Task<IPagedCollection<IContainerGroup>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IContainerGroup, Models.ContainerGroupInner>.LoadPageWithWrapModelAsync(ListInnerAsync, ListInnerNextAsync, WrapModelForListAsync, loadAllPages, cancellationToken);
        }

        public override async Task<IPagedCollection<IContainerGroup>> ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IContainerGroup, Models.ContainerGroupInner>.LoadPageWithWrapModelAsync(
                async (cancellation) => await ListInnerByGroupAsync(resourceGroupName, cancellation),
                ListInnerByGroupNextAsync, WrapModelForListAsync, loadAllPages, cancellationToken);
        }

        protected async Task<IContainerGroup> WrapModelForListAsync(ContainerGroupInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (inner != null)
            {
                var result = new ContainerGroupImpl(inner.Name, inner, this.Manager, this.storageManager, this.rbacManager);

                return await result.RefreshAsync(cancellationToken);
            }
            else
            {
                return null;
            }
        }

        public IReadOnlyList<CachedImages> ListCachedImages(string location)
        {
            return ListCachedImagesAsync(location).Result as IReadOnlyList<CachedImages>;
        }

        public async Task<IReadOnlyList<CachedImages>> ListCachedImagesAsync(string location, CancellationToken cancellationToken = default(CancellationToken))
        {
            CachedImagesListResultInner cachedImagesListResultInner = await this.Manager.Inner.ListCachedImagesAsync(location, cancellationToken);
            return cachedImagesListResultInner.Value as IReadOnlyList<CachedImages>;
        }

        public IReadOnlyList<Capabilities> ListCapabilities(string location)
        {
            return ListCapabilitiesAsync(location).Result as IReadOnlyList<Capabilities>;
        }

        public async Task<IReadOnlyList<Capabilities>> ListCapabilitiesAsync(string location, CancellationToken cancellationToken = default(CancellationToken))
        {
            CapabilitiesListResultInner capabilitiesListResultInner = await this.Manager.Inner.ListCapabilitiesAsync(location, cancellationToken);
            return capabilitiesListResultInner.Value as IReadOnlyList<Capabilities>;
        }

        public void Start(string resourceGroupName, string containerGroupName)
        {
            StartAsync(resourceGroupName, containerGroupName).Wait();
        }

        public async Task StartAsync(string resourceGroupName, string containerGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.ContainerGroups.StartAsync(resourceGroupName, containerGroupName, cancellationToken);
        }

        public IReadOnlyList<Operation> ListOperations()
        {
           return ListOperationsAsync().Result;
        }

        public async Task<IReadOnlyList<Operation>> ListOperationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            OperationListResultInner operationListResultInner = await this.Manager.Inner.Operations.ListAsync(cancellationToken);
            return new ReadOnlyCollection<Operation>(operationListResultInner.Value);
        }
    }
}