// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Linq;
    using System;

    /// <summary>
    /// Implementation for network peerings.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya1BlZXJpbmdzSW1wbA==
    internal partial class NetworkPeeringsImpl :
        IndependentChildrenImpl<
            INetworkPeering,
            NetworkPeeringImpl,
            VirtualNetworkPeeringInner,
            IVirtualNetworkPeeringsOperations,
            INetworkManager,
            INetwork>,
        INetworkPeerings
    {
        private NetworkImpl network;
        ///GENMHASH:31765EEA1AC846369BF9436E32D2EA18:ED5536E94E5EC9F517090473579BDDF6
        public async Task<INetworkPeering> GetByRemoteNetworkAsync(INetwork network, CancellationToken cancellationToken = default(CancellationToken))
        {
            return (network != null) ? await GetByRemoteNetworkAsync(network.Id) : null;
        }

        ///GENMHASH:2601382D41F49CF9CEB130D1B7B2F577:50110639F684E518AB3F92CCAC684E86
        public async Task<INetworkPeering> GetByRemoteNetworkAsync(string remoteNetworkResourceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (remoteNetworkResourceId == null)
            {
                return null;
            }
            else
            {
                var peerings = await ListAsync();
                return peerings.FirstOrDefault(p =>
                {
                    return (p.RemoteNetworkId != null)
                    ? (p.RemoteNetworkId.Equals(remoteNetworkResourceId, StringComparison.OrdinalIgnoreCase))
                    : false;
                });
            }
        }

        ///GENMHASH:EA1A01CE829067751D1BD24D7AC819DA:C2343A76A3F8DDED57CC72E8DD1F1FD6
        public async override Task<INetworkPeering> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await Inner.GetAsync(resourceGroup, parentName, name, cancellationToken));
        }

        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:1B548782C32FC0F04862DDDB5537335F
        public new IEnumerable<INetworkPeering> ListByParent(string resourceGroupName, string parentName)
        {
            return WrapList(Extensions.Synchronize(() => Inner.ListAsync(resourceGroupName, parentName)));
        }

        public async override Task<IPagedCollection<INetworkPeering>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<INetworkPeering, VirtualNetworkPeeringInner>.LoadPage(
                async (cancellation) => await Inner.ListAsync(resourceGroupName, parentName, cancellation),
                WrapModel, cancellationToken);
        }

        ///GENMHASH:1F414E796475F1DA7286F29E3E27589D:544286E0EEEFD0731CB5503255EC30A3
        public async override Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Get the parent network of the peering to delete
            INetwork localNetwork = await Manager.Networks.GetByResourceGroupAsync(groupName, parentName);

            if (localNetwork == null)
            {
                // Missing local network, so nothing else to do
                return;
            }

            // Then find the local peering to delete
            List<INetworkPeering> peeringsToDelete = new List<INetworkPeering>();
            String peeringId = localNetwork.Id + "/peerings/" + name;
            INetworkPeering localPeering = await localNetwork.Peerings.GetByIdAsync(peeringId);

            INetworkPeering remotePeering = null;
            if (localPeering == null)
            {
                // Local peering does not exist, so nothing to delete
                return;
            }
            else
            {
                peeringsToDelete.Add(localPeering);
            }

            // Then get the remote peering if available and possible to delete
            if (localPeering.IsSameSubscription)
            {
                // Same subscription so get the remote peering
                remotePeering = await localPeering.GetRemotePeeringAsync();
                if (remotePeering != null)
                {
                    peeringsToDelete.Add(remotePeering);
                }
            }

            // Then delete each peering (this will be called for each of the peerings, so at least once for the local peering, and second time for the remote one if any
            List<Task> peeringDeleteTasks = new List<Task>();
            foreach (var peering in peeringsToDelete)
            {
                string networkName = ResourceUtils.NameFromResourceId(peering.NetworkId);
                peeringDeleteTasks.Add(peering.Manager.Inner.VirtualNetworkPeerings.DeleteAsync(
                    peering.ResourceGroupName,
                    networkName,
                    peering.Name));
            }
            await Task.WhenAll(peeringDeleteTasks);
        }

        ///GENMHASH:D386F0BE7537C4220FC0E91956E10A25:8F31E25B1FB1CE8C4694F2E9274E1CD8
        public INetworkPeering GetByRemoteNetwork(INetwork network)
        {
            return (network != null) ? GetByRemoteNetwork(network.Id) : null;
        }

        ///GENMHASH:FEB11B34B6BD4D33F16FE39DA7586D7F:986665BCBCA0EEB0AA9F1D112AF0A6DD
        public INetworkPeering GetByRemoteNetwork(string remoteNetworkResourceId)
        {
            return (remoteNetworkResourceId != null)
                ? List().FirstOrDefault(p => p.RemoteNetworkId.Equals(remoteNetworkResourceId, StringComparison.OrdinalIgnoreCase))
                : null;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public NetworkPeeringImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:5656FD013FB03DE151E2B9EF746A2384:C28B7FD5EBFFA3800C7C577610AB78BB
        internal NetworkPeeringsImpl(NetworkImpl parent) : base(parent.Manager.Inner.VirtualNetworkPeerings, parent.Manager)
        {
            network = parent;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:36D77DC2D156B03AD386962C63360272
        public IEnumerable<INetworkPeering> List()
        {
            return WrapList(Extensions.Synchronize(() => Inner.ListAsync(network.ResourceGroupName, network.Name)));
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:1F35F9CAEDCC9462F8462E3AE050584D
        public async Task<IPagedCollection<INetworkPeering>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<INetworkPeering, VirtualNetworkPeeringInner>.LoadPage(
                async (cancellation) => await Inner.ListAsync(network.ResourceGroupName, network.Name, cancellation), WrapModel, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:9B32E9E00DBB5C01193E9DF5FC3E95F8
        protected override NetworkPeeringImpl WrapModel(string name)
        {
            VirtualNetworkPeeringInner inner = new VirtualNetworkPeeringInner() { Name = name };
            return new NetworkPeeringImpl(inner, network);
        }

        ///GENMHASH:4E6BAA1DBD9325A97B4B922F2CE70AC1:319C885885D962B4524EC6860C3BC2D8
        protected override INetworkPeering WrapModel(VirtualNetworkPeeringInner inner)
        {
            return (inner != null) ? new NetworkPeeringImpl(inner, network) : null;
        }
    }
}