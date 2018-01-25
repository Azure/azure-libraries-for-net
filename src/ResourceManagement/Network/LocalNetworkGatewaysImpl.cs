// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for LocalNetworkGateways.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9jYWxOZXR3b3JrR2F0ZXdheXNJbXBs
    internal partial class LocalNetworkGatewaysImpl :
        GroupableResources<ILocalNetworkGateway,
            LocalNetworkGatewayImpl,
            LocalNetworkGatewayInner,
            ILocalNetworkGatewaysOperations,
            INetworkManager>,
        ILocalNetworkGateways
    {
        ///GENMHASH:65F9F8F498352BBE79897954DDC4983B:483F7E7D6F61A4ECEBF12761F166A376
        internal LocalNetworkGatewaysImpl(INetworkManager networkManager)
            : base(networkManager.Inner.LocalNetworkGateways, networkManager)
        {
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public LocalNetworkGatewayImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:7D35601E6590F84E3EC86E2AC56E37A0:FBFA0902403A234112A18515EE78DB0D
        protected async Task DeleteInnerAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:35026E7CB6B6FB9ACC5509A9F4EE26F5
        public IEnumerable<Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway> List()
        {
            return Manager.ResourceManager.ResourceGroups.List()
                .SelectMany(rg => ListByResourceGroup(rg.Name));
        }

        ///GENMHASH:9C5B42FF47E71D8582BAB26BBDEC1E0B:D21C20CB4507042130C1D13862BEE143
        public async Task<IPagedCollection<ILocalNetworkGateway>> ListByResourceGroupAsync(string groupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var innerLocalNetworkGateways = await Inner.ListAsync(groupName, cancellationToken);
            var result = innerLocalNetworkGateways.Select((innerVirtualGateway) => WrapModel(innerVirtualGateway));
            return PagedCollection<ILocalNetworkGateway, LocalNetworkGatewayInner>.CreateFromEnumerable(result);
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:CAB88407089EFFF792A7B997566459B3
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<ILocalNetworkGateway>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<ILocalNetworkGateway, LocalNetworkGatewayInner>.LoadPage(async (cancellation) =>
            {
                var resourceGroups = await Manager.ResourceManager.ResourceGroups.ListAsync(true, cancellation);
                var localNetworkGateways = await Task.WhenAll(resourceGroups.Select(async (rg) => await Inner.ListAsync(rg.Name, cancellation)));
                return localNetworkGateways.SelectMany(x => x);
            }, WrapModel, cancellationToken);
        }

        ///GENMHASH:0FEF45F7011A46EAF6E2D15139AE631D:A606C608C6616DA4F865A57B39DF3F12
        protected async Task<Models.LocalNetworkGatewayInner> GetInnerAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:7B29DA142EEAE9C0CEA820616FAF8EBB
        protected override LocalNetworkGatewayImpl WrapModel(string name)
        {
            LocalNetworkGatewayInner inner = new LocalNetworkGatewayInner();
            return new LocalNetworkGatewayImpl(name, inner, Manager);
        }

        ///GENMHASH:4530DB9CAA4E6B05E73B8EC48AEA0560:9366AD687720FCC97C68ABECA05A4CF3
        protected override ILocalNetworkGateway WrapModel(LocalNetworkGatewayInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new LocalNetworkGatewayImpl(inner.Name, inner, Manager);
        }

        protected override async Task<LocalNetworkGatewayInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Manager.Inner.LocalNetworkGateways.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Manager.Inner.VirtualNetworkGateways.DeleteAsync(groupName, name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:178BF162835B0E3978203EDEF988B6EB:74D523E66AA62B2B4DECAB1282A54E4D
        public IEnumerable<Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway> ListByResourceGroup(string groupName)
        {
            return WrapList(Extensions.Synchronize(() => Inner.ListAsync(groupName)));
        }
    }
}