// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for VirtualNetworkGateways.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uVmlydHVhbE5ldHdvcmtHYXRld2F5c0ltcGw=
    internal partial class VirtualNetworkGatewaysImpl :
        GroupableResources<IVirtualNetworkGateway,
            VirtualNetworkGatewayImpl,
            VirtualNetworkGatewayInner,
            IVirtualNetworkGatewaysOperations,
            INetworkManager>,
        IVirtualNetworkGateways
    {
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public VirtualNetworkGatewayImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:7D35601E6590F84E3EC86E2AC56E37A0:FBFA0902403A234112A18515EE78DB0D
        protected async Task DeleteInnerAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:D68C381A90986BEE0F49BCCD7705E394
        public IEnumerable<IVirtualNetworkGateway> List()
        {
            return Manager.ResourceManager.ResourceGroups.List()
                .SelectMany(rg => ListByResourceGroup(rg.Name));
        }

        ///GENMHASH:9C5B42FF47E71D8582BAB26BBDEC1E0B:D21C20CB4507042130C1D13862BEE143
        public async Task<IPagedCollection<IVirtualNetworkGateway>> ListByResourceGroupAsync(string groupName, bool loadAllPages, CancellationToken cancellationToken = default(CancellationToken))
        {
            var innerVirtualNetworkGateways = await Inner.ListAsync(groupName, cancellationToken);
            var result = innerVirtualNetworkGateways.Select((innerVirtualGateway) => WrapModel(innerVirtualGateway));
            return PagedCollection<IVirtualNetworkGateway, VirtualNetworkGatewayInner>.CreateFromEnumerable(result);
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:6F60801C39F5AD18497B65AF050BF8D8
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IVirtualNetworkGateway>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IVirtualNetworkGateway, VirtualNetworkGatewayInner>.LoadPage(async (cancellation) =>
            {
                var resourceGroups = await Manager.ResourceManager.ResourceGroups.ListAsync(true, cancellation);
                var virtualNetworkGateways = await Task.WhenAll(resourceGroups.Select(async (rg) => await Inner.ListAsync(rg.Name, cancellation)));
                return virtualNetworkGateways.SelectMany(x => x);
            }, WrapModel, cancellationToken);
        }

        ///GENMHASH:0FEF45F7011A46EAF6E2D15139AE631D:A606C608C6616DA4F865A57B39DF3F12
        protected async Task<Models.VirtualNetworkGatewayInner> GetInnerAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:8C2AD6094D4F51961933D083CE43EE8F
        protected override VirtualNetworkGatewayImpl WrapModel(string name)
        {
            return new VirtualNetworkGatewayImpl(name, new VirtualNetworkGatewayInner(), Manager);
        }

        ///GENMHASH:08FD436B4648E9F31FE74790CB261D33:748CA462E88B9308E3A7A056CFE91830
        protected override IVirtualNetworkGateway WrapModel(VirtualNetworkGatewayInner inner)
        {
            return new VirtualNetworkGatewayImpl(inner.Name, inner, Manager);
        }

        ///GENMHASH:23437868CE68EFB16A049AF2B13B3DAB:3D6404118CFB640869888EDF59D554E2
        internal VirtualNetworkGatewaysImpl(INetworkManager networkManager)
            : base(networkManager.Inner.VirtualNetworkGateways, networkManager)
        {
        }

        protected override async Task<VirtualNetworkGatewayInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Manager.Inner.VirtualNetworkGateways.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Manager.Inner.VirtualNetworkGateways.DeleteAsync(groupName, name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:178BF162835B0E3978203EDEF988B6EB:74D523E66AA62B2B4DECAB1282A54E4D
        public IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway> ListByResourceGroup(string groupName)
        {
            return WrapList(Extensions.Synchronize(() => Inner.ListAsync(groupName)));
        }
    }
}