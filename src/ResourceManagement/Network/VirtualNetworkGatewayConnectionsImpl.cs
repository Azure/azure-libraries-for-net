// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    /// <summary>
    /// The implementation of VirtualNetworkGatewayConnections.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uVmlydHVhbE5ldHdvcmtHYXRld2F5Q29ubmVjdGlvbnNJbXBs
    internal partial class VirtualNetworkGatewayConnectionsImpl :
        GroupableResources<IVirtualNetworkGatewayConnection,
            VirtualNetworkGatewayConnectionImpl,
            VirtualNetworkGatewayConnectionInner,
            IVirtualNetworkGatewayConnectionsOperations,
            INetworkManager>,
        IVirtualNetworkGatewayConnections
    {
        private VirtualNetworkGatewayImpl parent;
        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:7D20AFF6B32FFD01B49036D5C89ED11D
        public IVirtualNetworkGateway Parent()
        {
            return parent;
        }

        ///GENMHASH:269D67510C1F52A212C7338821114566:8BC410D1F211690FF9ADF477729D3C1E
        internal VirtualNetworkGatewayConnectionsImpl(VirtualNetworkGatewayImpl parent)
            : base(parent.Manager.Inner.VirtualNetworkGatewayConnections, parent.Manager)
        {
            this.parent = parent;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public VirtualNetworkGatewayConnectionImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:8B01EFA0F8D901873078F6C02C9DC1E8
        public IVirtualNetworkGatewayConnection GetByName(string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(name));
        }

        ///GENMHASH:7D35601E6590F84E3EC86E2AC56E37A0:FC0782D816C4C8992BAD757601232368
        protected async Task DeleteInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(resourceGroupName, name, cancellationToken);
        }

        ///GENMHASH:C2DC9CFAB6C291D220DD4F29AFF1BBEC:7459D8B9F8BB0A1EBD2FC4702A86F2F5
        public void DeleteByName(string name)
        {
            Extensions.Synchronize(() => DeleteByNameAsync(name));

        }

        ///GENMHASH:885F10CFCF9E6A9547B0702B4BBD8C9E:00AAF298A79312DBEAC5550F806012A4
        public async Task<IVirtualNetworkGatewayConnection> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await Inner.GetAsync(parent.ResourceGroupName, name, cancellationToken));
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:7318F6C27626927E3A3B42547541FF26
        public IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection> List()
        {
            return Extensions.Synchronize(() => ListAsync());
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:CD170B0409A65C3395FCE9D105479DEE
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IVirtualNetworkGatewayConnection>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IVirtualNetworkGatewayConnection, VirtualNetworkGatewayConnectionInner>.LoadPage(async (cancellation) =>
            {
                var resourceGroups = await Manager.ResourceManager.ResourceGroups.ListAsync(true, cancellation);
                var connections = await Task.WhenAll(resourceGroups.Select(async (rg) => await Inner.ListAsync(rg.Name, cancellation)));
                return connections.SelectMany(x => x);
            }, WrapModel, cancellationToken);
        }

        ///GENMHASH:0FEF45F7011A46EAF6E2D15139AE631D:D67A48FEA84DC597C7993B97FA50F4D8
        protected async Task<Models.VirtualNetworkGatewayConnectionInner> GetInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Inner.GetAsync(resourceGroupName, name, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:73203B0122B445623F23F6D2CB886925
        protected override VirtualNetworkGatewayConnectionImpl WrapModel(string name)
        {
            VirtualNetworkGatewayConnectionImpl connection = new VirtualNetworkGatewayConnectionImpl(name, parent, new VirtualNetworkGatewayConnectionInner());
            return connection;
        }

        ///GENMHASH:7CA9D2D08231720108B87FAE980BBE06:29E5BF1D5E06E1B153E83931DB971CFE
        protected override IVirtualNetworkGatewayConnection WrapModel(VirtualNetworkGatewayConnectionInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new VirtualNetworkGatewayConnectionImpl(inner.Name, parent, inner);
        }

        protected override async Task<VirtualNetworkGatewayConnectionInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Manager.Inner.VirtualNetworkGatewayConnections.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Manager.Inner.VirtualNetworkGateways.DeleteAsync(groupName, name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:D123AA24F5011F673F0DCE131A8F4F45
        public async Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(parent.ResourceGroupName, name, cancellationToken);
        }
    }
}