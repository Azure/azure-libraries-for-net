// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition;
    using Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.IndependentChild.Definition;
    using System;
    using System.Linq;

    /// <summary>
    /// Implementation for network peering.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya1BlZXJpbmdJbXBs
    internal partial class NetworkPeeringImpl :
        IndependentChildImpl<
            INetworkPeering,
            INetwork,
            VirtualNetworkPeeringInner,
            NetworkPeeringImpl,
            IHasId,
            IUpdate,
            INetworkManager>,
        INetworkPeering,
        IDefinition,
        IUpdate,
        IWithParentResource<INetworkPeering, INetwork>
    {
        private NetworkImpl parent;
        private INetwork remoteNetwork;
        private bool? remoteAccess;
        private bool? remoteForwarding;
        private bool? startGatewayUseByRemoteNetwork;
        private bool? allowGatewayUseOnRemoteNetwork;

        ///GENMHASH:268A8495CFD8E9DC5D727740FC0F43C2:3C8497A3469877DB7A9CBB41B5E887EE
        public NetworkPeeringImpl WithGatewayUseByRemoteNetworkStarted()
        {
            startGatewayUseByRemoteNetwork = true;
            allowGatewayUseOnRemoteNetwork = false;
            return WithGatewayUseByRemoteNetworkAllowed();
        }

        ///GENMHASH:D74CA19BB3B48FD642462D686BC2D7F7:04AC8A2ACB0EB040165C6D58676DAD6C
        public string RemoteNetworkId()
        {
            return Inner.RemoteVirtualNetwork?.Id;
        }

        public override string Id
        {
            get
            {
                return Inner.Id;
            }
        }

        ///GENMHASH:8C46C24CE8E712918A53F66F201BEAB5:BF854A451AEBEBE8F730420661396AD8
        public NetworkPeeringImpl WithoutTrafficForwardingFromEitherNetwork()
        {
            return WithoutTrafficForwardingFromRemoteNetwork().WithoutTrafficForwardingToRemoteNetwork();
        }

        ///GENMHASH:72C17FD2B8B963F9397431EC54A6E8E8:5E6587605D257E7EE0FC7E3DECB2D9F9
        public NetworkPeeringImpl WithAccessBetweenBothNetworks()
        {
            return WithAccessFromRemoteNetwork().WithAccessToRemoteNetwork();
        }

        ///GENMHASH:B18E1028D4CF4EB59D0438373B8B2DB7:242B3C9040820E707DE3D7CE607A4034
        public async Task<INetwork> GetRemoteNetworkAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (remoteNetwork != null)
            {
                // Return cached network
                return remoteNetwork;
            }
            else if (IsSameSubscription())
            {
                // Fetch and cache the remote network if within the same subscription
                remoteNetwork = await Manager.Networks.GetByIdAsync(RemoteNetworkId());
                return remoteNetwork;
            }
            else
            {
                // Otherwise bail out
                remoteNetwork = null;
                return null;
            }
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:F896673DBB924AED0E674E2DEB59DBDA
        protected override async Task<VirtualNetworkPeeringInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            remoteNetwork = null;
            return await Manager.Inner.VirtualNetworkPeerings.GetAsync(
                ResourceGroupName,
                ResourceUtils.NameFromResourceId(NetworkId()),
                Inner.Name,
                cancellationToken);
        }

        ///GENMHASH:637BB5BC3B1E915A283DCDB66094D68C:A4E0BD248DF10DDAC58971F6BD88250C
        public NetworkPeeringImpl WithoutTrafficForwardingFromRemoteNetwork()
        {
            Inner.AllowForwardedTraffic = false;
            return this;
        }

        ///GENMHASH:B537B322BD5DB6FE8BC5CA64AC30F3E6:E7D46B17327F69CB51FBE873D149CFA5
        public NetworkPeeringImpl WithoutAccessFromRemoteNetwork()
        {
            Inner.AllowVirtualNetworkAccess = false;
            return this;
        }

        ///GENMHASH:8E56E141A0FFA086E535B576CAE1399A:300600DD89B0B5AF201E798FEACCD3C1
        public INetworkPeering GetRemotePeering()
        {
            INetwork network = GetRemoteNetwork();
            return network?.Peerings.GetByRemoteNetwork(NetworkId());
        }

        ///GENMHASH:8BC8B7DBD32E2C220CA1ED27D58C6BE1:DB97D6B29E0EA10840989CD74AFD4E36
        public NetworkPeeringImpl WithAccessToRemoteNetwork()
        {
            remoteAccess = true;
            return this;
        }

        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:C36EA5528BB9B7DF20DBC8AE36479745
        public string NetworkId()
        {
            return parent.Id;
        }

        ///GENMHASH:AEE17FD09F624712647F5EBCEC141EA5:034BCA494728ED6A04C4FDDDF51A9FE6
        public VirtualNetworkPeeringState State()
        {
            return Inner.PeeringState;
        }

        ///GENMHASH:787CAB4CA1B6FFC990D0F22E05F7F245:ADC90767AEC7E624B4F4EFDC2F51DD6C
        public bool IsAccessFromRemoteNetworkAllowed()
        {
            return Inner.AllowVirtualNetworkAccess ?? false;
        }

        ///GENMHASH:2B0D326CAA6EEB83A1422780037EC41B:BBFC4CA7E603DCECB9062D2393E47190
        public NetworkPeeringImpl WithTrafficForwardingBetweenBothNetworks()
        {
            return WithTrafficForwardingFromRemoteNetwork().WithTrafficForwardingToRemoteNetwork();
        }

        ///GENMHASH:E9BA3CDC22BE7AAB0BAFCE73975135D0:4ADF33F89BC34BB10D7AF33D5AE6425B
        public NetworkPeeringGatewayUse GatewayUse()
        {
            if (Inner.AllowGatewayTransit ?? false)
            {
                return NetworkPeeringGatewayUse.ByRemoteNetwork;
            }
            else if (Inner.UseRemoteGateways ?? false)
            {
                return NetworkPeeringGatewayUse.OnRemoteNetwork;
            }
            else
            {
                return NetworkPeeringGatewayUse.None;
            }
        }

        ///GENMHASH:1F38EA9AC6E7BAF1EEE6EC0F7E47D370:A4FA20345CD34F34A72162DCC73A2E1F
        public NetworkPeeringImpl WithGatewayUseByRemoteNetworkAllowed()
        {
            Inner.AllowGatewayTransit = true;
            Inner.UseRemoteGateways = false;
            startGatewayUseByRemoteNetwork = null;
            allowGatewayUseOnRemoteNetwork = false;
            return this;
        }

        ///GENMHASH:7AB25198269F513A28F0F242C133DC71:A9AB4A90BBCCB13B3F7C02B2EA0BDF3E
        public NetworkPeeringImpl WithoutAccessFromEitherNetwork()
        {
            return WithoutAccessFromRemoteNetwork().WithoutAccessToRemoteNetwork();
        }

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:4FFCDCB491AE20C1268464BD73D55EF2
        protected override async Task<INetworkPeering> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            NetworkPeeringImpl localPeering = this;
            string networkName = ResourceUtils.NameFromResourceId(NetworkId());
            var inner = await Manager.Inner.VirtualNetworkPeerings.CreateOrUpdateAsync(
                parent.ResourceGroupName, networkName, Name, Inner);
            if (inner == null)
            {
                return null;
            }

            // After successful creation, update the inner
            SetInner(inner);

            // Then get the remote network to update it if needed and in the same subscription
            SubResource networkRef = inner.RemoteVirtualNetwork;
            INetwork remoteNetwork = null;
            if (localPeering.IsSameSubscription())
            {
                // Update the remote network only if it is in the same subscription
                remoteNetwork = await localPeering.Manager.Networks.GetByIdAsync(networkRef.Id);
            }

            // Then update the existing remote network if needed
            INetworkPeering remotePeering = null;
            if (remoteNetwork != null)
            {
                // Check if any peering is already pointing at this network
                var remotePeerings = await remoteNetwork.Peerings.ListAsync();
                remotePeering = remotePeerings.FirstOrDefault(p => p.RemoteNetworkId != null && p.RemoteNetworkId.Equals(localPeering.parent.Id, StringComparison.OrdinalIgnoreCase));
            }

            // Depending on the existence of a matching remote peering, create one or update existing
            if (remotePeering != null)
            {
                // Matching peering exists, so update as needed
                var remotePeeringUpdate = remotePeering.Update();
                bool isUpdateNeeded = false;

                // Update traffic forwarding on the remote peering if needed
                if (localPeering.remoteForwarding == null)
                {
                    // No traffic forwarding change, so ignore
                }
                else if (localPeering.remoteForwarding.Value && !remotePeering.IsTrafficForwardingFromRemoteNetworkAllowed)
                {
                    isUpdateNeeded = true;
                    remotePeeringUpdate = remotePeeringUpdate.WithTrafficForwardingFromRemoteNetwork();
                }
                else if (!localPeering.remoteForwarding.Value && remotePeering.IsTrafficForwardingFromRemoteNetworkAllowed)
                {
                    isUpdateNeeded = true;
                    remotePeeringUpdate = remotePeeringUpdate.WithoutTrafficForwardingFromRemoteNetwork();
                }

                // Update network access on the remote peering if needed
                if (localPeering.remoteAccess == null)
                {
                    // No access change, so ignore
                }
                else if (localPeering.remoteAccess.Value && !((NetworkPeeringImpl)remotePeering).IsAccessFromRemoteNetworkAllowed())
                {
                    isUpdateNeeded = true;
                    remotePeeringUpdate = ((NetworkPeeringImpl)remotePeeringUpdate).WithAccessFromRemoteNetwork();
                }
                else if (!localPeering.remoteAccess.Value && ((NetworkPeeringImpl)remotePeering).IsAccessFromRemoteNetworkAllowed())
                {
                    isUpdateNeeded = true;
                    remotePeeringUpdate = ((NetworkPeeringImpl)remotePeeringUpdate).WithoutAccessFromRemoteNetwork();
                }

                // Update gateway use permission on the remote peering if needed
                if (localPeering.allowGatewayUseOnRemoteNetwork == null)
                {
                    // No change, so ignore
                }
                else if (localPeering.allowGatewayUseOnRemoteNetwork.Value && remotePeering.GatewayUse != NetworkPeeringGatewayUse.ByRemoteNetwork)
                {
                    // Allow gateway use on remote network
                    isUpdateNeeded = true;
                    remotePeeringUpdate.WithGatewayUseByRemoteNetworkAllowed();
                }
                else if (!localPeering.allowGatewayUseOnRemoteNetwork.Value && remotePeering.GatewayUse == NetworkPeeringGatewayUse.ByRemoteNetwork)
                {
                    // Disallow gateway use on remote network
                    isUpdateNeeded = true;
                    remotePeeringUpdate.WithoutGatewayUseByRemoteNetwork();
                }

                // Update gateway use start on the remote peering if needed
                if (localPeering.startGatewayUseByRemoteNetwork == null)
                {
                    // No change, so ignore
                }
                else if (localPeering.startGatewayUseByRemoteNetwork.Value && remotePeering.GatewayUse != NetworkPeeringGatewayUse.OnRemoteNetwork)
                {
                    remotePeeringUpdate.WithGatewayUseOnRemoteNetworkStarted();
                    isUpdateNeeded = true;
                }
                else if (!localPeering.startGatewayUseByRemoteNetwork.Value && remotePeering.GatewayUse == NetworkPeeringGatewayUse.OnRemoteNetwork)
                {
                    remotePeeringUpdate.WithoutGatewayUseOnRemoteNetwork();
                    isUpdateNeeded = true;
                }

                if (isUpdateNeeded)
                {
                    localPeering.remoteForwarding = null;
                    localPeering.remoteAccess = null;
                    localPeering.startGatewayUseByRemoteNetwork = null;
                    localPeering.allowGatewayUseOnRemoteNetwork = null;
                    await remotePeeringUpdate.ApplyAsync();
                }
            }

            else
            {
                // No matching remote peering, so create one on the remote network
                string peeringName = SdkContext.RandomResourceName("peer", 15);
                var remotePeeringDefinition = remoteNetwork.Peerings.Define(peeringName)
                    .WithRemoteNetwork(localPeering.parent.Id);

                // Process remote network's UseRemoteGateways setting
                if (localPeering.startGatewayUseByRemoteNetwork == null)
                {
                    // Do nothing
                }
                else if (localPeering.startGatewayUseByRemoteNetwork.Value)
                {
                    // Start gateway use on this network by the remote network
                    remotePeeringDefinition.WithGatewayUseOnRemoteNetworkStarted();
                }

                // Process remote network's AllowGatewayTransit setting
                if (localPeering.allowGatewayUseOnRemoteNetwork == null)
                {
                    // Do nothing
                }
                else if (localPeering.allowGatewayUseOnRemoteNetwork.Value)
                {
                    // Allow gateway use on remote network
                    remotePeeringDefinition.WithGatewayUseByRemoteNetworkAllowed();
                }

                if (localPeering.remoteAccess != null && !localPeering.remoteAccess.Value)
                {
                    ((NetworkPeeringImpl)remotePeeringDefinition).WithoutAccessFromRemoteNetwork(); // Assumes by default access is on for new peerings
                }

                if (localPeering.remoteForwarding != null && localPeering.remoteForwarding.Value)
                {
                    remotePeeringDefinition.WithTrafficForwardingFromRemoteNetwork(); // Assumes by default forwarding is off for new peerings
                }

                localPeering.remoteAccess = null;
                localPeering.remoteForwarding = null;
                localPeering.startGatewayUseByRemoteNetwork = null;
                localPeering.allowGatewayUseOnRemoteNetwork = null;
                return await remotePeeringDefinition.CreateAsync();
            }

            // Then refresh the parent local network, if available
            if (localPeering.parent != null)
            {
                await localPeering.parent.RefreshAsync();
            }

            // Then refresh the remote network, if available and in the same subscription
            if (localPeering.remoteNetwork != null && localPeering.IsSameSubscription())
            {
                await localPeering.remoteNetwork.RefreshAsync();
            }

            // Then return the created local peering
            return localPeering;
        }

        ///GENMHASH:E9313E7AFF3D55B1D5E1491AAF57645D:55EF0880DF255C40FBB22F800E1919AE
        internal NetworkPeeringImpl(VirtualNetworkPeeringInner inner, NetworkImpl parent) : base(inner.Name, inner, parent.Manager)
        {
            this.parent = parent;
            remoteAccess = null;
            remoteForwarding = null;
        }

        ///GENMHASH:1DE9B25C7F05CD3046F6A4B66927D846:74BE4E048F73D777C4440FD66F6F4698
        public NetworkPeeringImpl WithoutGatewayUseOnRemoteNetwork()
        {
            Inner.UseRemoteGateways = false;
            return this;
        }

        ///GENMHASH:6EFDDDCC2F012C3BDBC1948FDA6ADD3C:1F7707035E5A0B88C60CF708B88C09C7
        public NetworkPeeringImpl WithRemoteNetwork(string resourceId)
        {
            Inner.RemoteVirtualNetwork = new SubResource() { Id = resourceId };
            return this;
        }

        ///GENMHASH:178C346603381ECF96FC9E3AF1489D2D:0B6E3FA0D7DA25A6FCE93201B079857B
        public NetworkPeeringImpl WithRemoteNetwork(INetwork network)
        {
            if (network != null)
            {
                remoteNetwork = network;
                return WithRemoteNetwork(network.Id);
            }
            else
            {
                return this;
            }
        }

        ///GENMHASH:66DA63C7E53E44771C1865118198C32A:D4D043FD877FB2085809FF6322CA51FC
        public NetworkPeeringImpl WithoutAccessToRemoteNetwork()
        {
            remoteAccess = false;
            return this;
        }

        ///GENMHASH:F3901A72835B885E57539D4A9E975D77:97ED1B0DB663D815E40F73FEC3C1422B
        public INetwork GetRemoteNetwork()
        {
            return Extensions.Synchronize(() => GetRemoteNetworkAsync());
        }

        ///GENMHASH:7C5C3C80D9FB64089606242B13E10068:8000879B305134D325DD5D8DD3352BDA
        public NetworkPeeringImpl WithGatewayUseOnRemoteNetworkStarted()
        {
            Inner.AllowGatewayTransit = false;
            Inner.UseRemoteGateways = true;
            startGatewayUseByRemoteNetwork = false;
            allowGatewayUseOnRemoteNetwork = true;
            return this;
        }

        ///GENMHASH:AE880716DDF5D804BE39546D66BA7717:7421A0DD03A66F56C356E523437A057F
        public async Task<INetworkPeering> GetRemotePeeringAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var remoteNetwork = await GetRemoteNetworkAsync();
            if (remoteNetwork != null)
            {
                return await remoteNetwork.Peerings.GetByRemoteNetworkAsync(NetworkId());
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:DEE77E157A54E1F40622B36C399B7443:F9614692AE565E77CD29AC394144EA66
        public NetworkPeeringImpl WithTrafficForwardingFromRemoteNetwork()
        {
            Inner.AllowForwardedTraffic = true;
            return this;
        }

        ///GENMHASH:971DF45F5927F52A02F39605C849EEB9:1EF9558C37E9621E7FD5EDF4AD13F37E
        public bool IsSameSubscription()
        {
            if (RemoteNetworkId() == null)
            {
                return false;
            }
            string localSubscriptionId = ResourceUtils.SubscriptionFromResourceId(Id);
            string remoteSubscriptionId = ResourceUtils.SubscriptionFromResourceId(RemoteNetworkId());
            return localSubscriptionId.Equals(remoteSubscriptionId, StringComparison.OrdinalIgnoreCase);
        }

        ///GENMHASH:34DF8E9C88A21F9A2D8BF90BE134BEAF:EA754168DDC4BC41F9486192FE5576DC
        public NetworkPeeringImpl WithoutTrafficForwardingToRemoteNetwork()
        {
            remoteForwarding = false;
            return this;
        }

        ///GENMHASH:C858C6401BC1F29B99ADDB8878D89FFB:BFB8CD0FD970DDF8A5EFA14885B1FDC1
        public bool IsTrafficForwardingFromRemoteNetworkAllowed()
        {
            return Inner.AllowForwardedTraffic ?? false;
        }

        ///GENMHASH:B046217185E66C64C8A114F5FFA24F5A:034B90F5862BF1C10D7074FFD66BD261
        public NetworkPeeringImpl WithoutAnyGatewayUse()
        {
            Inner.AllowGatewayTransit = false;
            return WithoutGatewayUseOnRemoteNetwork().WithoutGatewayUseByRemoteNetwork();
        }

        ///GENMHASH:E3CE5AB96400DD75EFA2209592A8AAD3:0C8C9209B2F913047D12746D06277341
        public NetworkPeeringImpl WithoutGatewayUseByRemoteNetwork()
        {
            startGatewayUseByRemoteNetwork = false;
            allowGatewayUseOnRemoteNetwork = false;
            return this;
        }

        ///GENMHASH:89335B7FCCBBF14B66CBDEB0367CEDAE:EADCB25A5A77A7288ECC097A26A915C4
        public NetworkPeeringImpl WithTrafficForwardingToRemoteNetwork()
        {
            remoteForwarding = true;
            return this;
        }

        ///GENMHASH:DDEF1058B2ECD04A381FBCD1806A84EC:A07D4A28FAF30BF9357F01CA874181FF
        public NetworkPeeringImpl WithAccessFromRemoteNetwork()
        {
            Inner.AllowVirtualNetworkAccess = true;
            return this;
        }

        ///GENMHASH:F8C8AE2CA027129A8C6051A94E25D216:F2F8E6E3ED818C594DBBBC9524DB0011
        public bool CheckAccessBetweenNetworks()
        {
            if (!(Inner.AllowVirtualNetworkAccess ?? false))
            {
                // If network access is disabled on this peering, then it's disabled for both networks, regardless of what the remote peering says
                return false;
            }

            // Check the access setting on the remote peering
            INetworkPeering remotePeering = GetRemotePeering();
            if (remotePeering == null)
            {
                return false;
            }
            else
            {
                // Access is enabled on local peering, so up to the remote peering to determine whether it's enabled or disabled overall
                return remotePeering.Inner.AllowVirtualNetworkAccess ?? false;
            }
        }

    }
}
