// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.ObjectModel;
using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Definition;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayConnection.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for VirtualNetworkGatewayConnection and its create and update interfaces.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uVmlydHVhbE5ldHdvcmtHYXRld2F5Q29ubmVjdGlvbkltcGw=
    internal partial class VirtualNetworkGatewayConnectionImpl  :
        IndependentChildResourceImpl<
            IVirtualNetworkGatewayConnection,
            IVirtualNetworkGateway,
            VirtualNetworkGatewayConnectionInner,
            VirtualNetworkGatewayConnectionImpl,
            IHasId,
            IUpdate,
            INetworkManager>,
        IVirtualNetworkGatewayConnection,
        IDefinition,
        IUpdate
    {
        private IVirtualNetworkGateway parent;
        ///GENMHASH:F0389EF26F16D377233CEA0243D3C2D3:002AE7D0BF403F77853FCC09647B9C5D
        public string LocalNetworkGateway2Id()
        {
            if (Inner.LocalNetworkGateway2 == null) {
                return null;
            }
            return Inner.LocalNetworkGateway2.Id;
        }

        ///GENMHASH:CE19D6E1BE71E1233D9525A7E026BFC7:0DAA02A6E6149A594F1E611CEDA41775
        public string SharedKey()
        {
            return Inner.SharedKey;
        }

        ///GENMHASH:A4FB429FC35E326B6CD540115D02D73C:0688D196CF6445EF78F2CB4D55D76410
        public string PeerId()
        {
            return Inner.Peer == null ? null : Inner.Peer.Id;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public IVirtualNetworkGateway Parent()
        {
            return parent;
        }

        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:A029F579BEAF734FDD0D1A010CE89549
        private void BeforeCreating()
        {
            SubResource virtualNetworkGatewayRef = new SubResource()
            {
                Id = parent.Id
            };
            Inner.VirtualNetworkGateway1 = virtualNetworkGatewayRef;
            Inner.Location = Parent().RegionName;
        }

        ///GENMHASH:DC68CE09DB266400D8B7E08E0150F876:29C6CFED65DB9A6CE452F3BC85F8D71C
        public long IngressBytesTransferred()
        {
            return Inner.IngressBytesTransferred.HasValue ? Inner.IngressBytesTransferred.Value : 0;
        }

        ///GENMHASH:3A31ACD3BD909199AC20F8F3E3739FBC:D7548BDC33746E38BAEB0C477D73EA03
        public int RoutingWeight()
        {
            return Inner.RoutingWeight.HasValue ? Inner.RoutingWeight.Value : 0;
        }

        ///GENMHASH:B0CEE06B3527C9FAA4A6F6BB52F2A301:62CA2860C467549EA3B59C449E9C2DA6
        internal  VirtualNetworkGatewayConnectionImpl(string name, VirtualNetworkGatewayImpl parent, VirtualNetworkGatewayConnectionInner inner)
            : base(name, inner, parent.Manager)
        {
            this.parent = parent;
        }

        ///GENMHASH:8D609444E5B12F47A2302B445E89BEE5:43AD2FCE7B0EAA8CBA41E52CCCA78770
        public VirtualNetworkGatewayConnectionType ConnectionType()
        {
            return VirtualNetworkGatewayConnectionType.Parse(Inner.ConnectionType);
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:C6001AE2B48A1402A8313022A5CF5590
        protected async override Task<VirtualNetworkGatewayConnectionInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await parent.Manager.Inner.VirtualNetworkGatewayConnections.GetAsync(ResourceGroupName, Name, cancellationToken);
        }

        ///GENMHASH:04D6D858FF61D37F76DA127C20A5ABF9:DFC8C1E6C2A0BC0C3178B00DC329D6B7
        public VirtualNetworkGatewayConnectionImpl WithLocalNetworkGateway(ILocalNetworkGateway localNetworkGateway)
        {
            SubResource localNetworkGatewayRef = new SubResource()
            {
                Id = localNetworkGateway.Id
            };
            Inner.LocalNetworkGateway2 = localNetworkGatewayRef;
            return this;
        }

        ///GENMHASH:63E7CC3AA7BB3CB910E5D0EE8931223C:05BC5F2415598E47C21323CD8B084A89
        public bool UsePolicyBasedTrafficSelectors()
        {
            return Inner.UsePolicyBasedTrafficSelectors.HasValue ? Inner.UsePolicyBasedTrafficSelectors.Value : false;
        }

        ///GENMHASH:1526F9C6D16D576524554408BA6A97AD:5EBA369C1D9EE8D92A96DC8E7D452DF1
        public VirtualNetworkGatewayConnectionImpl WithSecondVirtualNetworkGateway(IVirtualNetworkGateway virtualNetworkGateway2)
        {
            SubResource virtualNetworkGateway2Ref = new SubResource()
            {
                Id = virtualNetworkGateway2.Id
            };
            Inner.VirtualNetworkGateway2 = virtualNetworkGateway2Ref;
            return this;
        }

        ///GENMHASH:528DB5AE9087793672AA421058153271:CC4E0FCDD0B71DE7618242C10BC4A4C0
        public long EgressBytesTransferred()
        {
            return Inner.EgressBytesTransferred.HasValue ? Inner.EgressBytesTransferred.Value : 0;
        }

        ///GENMHASH:7F86C125A87D152FD762C431C7E77E76:8499787EA21C54ECB62EBA36A555DD42
        public bool IsBgpEnabled()
        {
            return Inner.EnableBgp.HasValue ? Inner.EnableBgp.Value : false;
        }

        protected async override Task<IVirtualNetworkGatewayConnection> CreateChildResourceAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            await CreateResourceAsync(cancellationToken);
            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:CD4C551113E5E3B4D9BB22FF3918F2C2
        public async override Task<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayConnection> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            BeforeCreating();
            var connectionInner = await this.Manager.Inner.VirtualNetworkGatewayConnections.CreateOrUpdateAsync(parent.ResourceGroupName, this.Name, Inner);
            SetInner(connectionInner);
            return this;
        }

        protected override void SetParentName(VirtualNetworkGatewayConnectionInner inner)
        {
        }

        ///GENMHASH:BA5893FC2B54BDCAFF5340EE3F1D9D5D:0B239CD1935B35B49A325AE508F825DD
        public VirtualNetworkGatewayConnectionImpl WithBgp()
        {
            Inner.EnableBgp = true;
            return this;
        }

        ///GENMHASH:0D5B2EA57166FD9D37E2B87078924DF4:12E023CCFEF803E00F18A5BF276D26B7
        public string AuthorizationKey()
        {
            return Inner.AuthorizationKey;
        }

        ///GENMHASH:629786B45F85F8E289D849497FF3EB84:328FF3B049F2421E1BB77C26A4256370
        public VirtualNetworkGatewayConnectionImpl WithVNetToVNet()
        {
            Inner.ConnectionType = VirtualNetworkGatewayConnectionType.Vnet2Vnet.Value;
            return this;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:3DB04077E6BABC0FB5A5ACDA19D11309
        public string ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        ///GENMHASH:ACAE8064401EC62BFA5012E6FE5ADD0F:E2A95EE63056355B62101870AEDE47A6
        public IReadOnlyCollection<IpsecPolicy> IpsecPolicies()
        {
            return new ReadOnlyCollection<IpsecPolicy>(Inner.IpsecPolicies);
        }

        ///GENMHASH:AD4AAD7D7CE972B5534D97A24606A18F:E35EF8A35A152BC71CE31BA0440B23C7
        public string VirtualNetworkGateway2Id()
        {
            if (Inner.VirtualNetworkGateway2 == null) {
                return null;
            }
            return Inner.VirtualNetworkGateway2.Id;
        }

        ///GENMHASH:E40693A780061FC1A156598B974969F1:D0A28D861F54F2F5A4F869CE37D6ABB2
        public VirtualNetworkGatewayConnectionImpl WithExpressRoute()
        {
            Inner.ConnectionType = VirtualNetworkGatewayConnectionType.ExpressRoute.Value;
            return this;
        }

        ///GENMHASH:6E2DB095301FA5F54EABD8841D651031:07DD1422A75C454174F9F62F5D008DAC
        public VirtualNetworkGatewayConnectionImpl WithoutBgp()
        {
            Inner.EnableBgp = false;
            return this;
        }

        ///GENMHASH:1C40B7D65DDDB1CEAAD72DFB63629A65:AC41AE86773F8512C8D6E31D6F29A914
        public string VirtualNetworkGateway1Id()
        {
            if (Inner.VirtualNetworkGateway1 == null) {
                return null;
            }
            return Inner.VirtualNetworkGateway1.Id;
        }

        ///GENMHASH:FEB663768504525640BBFB5A208F3B76:BC57D6829223294BCF9ED45D4B96D238
        public VirtualNetworkGatewayConnectionStatus ConnectionStatus()
        {
            return VirtualNetworkGatewayConnectionStatus.Parse(Inner.ConnectionStatus);
        }

        ///GENMHASH:21044C5DE2790341DFD3F758A2850299:735429DEBDE0B3FC24266278F000BE53
        public VirtualNetworkGatewayConnectionImpl WithSiteToSite()
        {
            Inner.ConnectionType = VirtualNetworkGatewayConnectionType.IPsec.Value;
            return this;
        }

        ///GENMHASH:1CF1AEE9F6AD3D22730A7743178A5C9A:5B7F93EEF9A0C96F43B06C539EA492CF
        public VirtualNetworkGatewayConnectionImpl WithSharedKey(string sharedKey)
        {
            Inner.SharedKey = sharedKey;
            return this;
        }

        ///GENMHASH:AEC5916EA96BA85F7A39800471D3F359:729D419AA8EB92D8E2582EA1988A5D32
        public IReadOnlyCollection<TunnelConnectionHealth> TunnelConnectionStatus()
        {
            return new ReadOnlyCollection<TunnelConnectionHealth>(Inner.TunnelConnectionStatus);
        }

        public IVirtualNetworkGatewayConnection Update()
        {
            return this;
        }

        public IWithCreate WithTags(IDictionary<string, string> tags)
        {
            base.WithTags(tags);
            return this;
        }

        public IWithCreate WithTag(string key, string value)
        {
            base.WithTag(key, value);
            return this;
        }
    }
}