// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.Network.Fluent.UpdatableWithTags.UpdatableWithTags;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition;
    using Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update;

    /// <summary>
    /// Implementation for VirtualNetworkGateway and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uVmlydHVhbE5ldHdvcmtHYXRld2F5SW1wbA==
    internal partial class VirtualNetworkGatewayImpl :
        GroupableParentResourceWithTags<IVirtualNetworkGateway,
            VirtualNetworkGatewayInner,
            VirtualNetworkGatewayImpl,
            INetworkManager,
            IWithGroup,
            IWithNetwork,
            IWithCreate,
            VirtualNetworkGateway.Update.IUpdate>,
        IVirtualNetworkGateway,
        IDefinition,
        VirtualNetworkGateway.Update.IUpdate
    {
        private string GATEWAY_SUBNET = "GatewaySubnet";
        private Dictionary<string, Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayIPConfiguration> ipConfigs;
        private IVirtualNetworkGatewayConnections connections;
        private ICreatable<INetwork> creatableNetwork;
        private ICreatable<IPublicIPAddress> creatablePip;

        ///GENMHASH:7D08FA84C64E6E32E5C2ED4B63EE0731:3881994DCADCE14215F82F0CC81BDD88
        internal VirtualNetworkGatewayImpl(string name, VirtualNetworkGatewayInner innerModel, INetworkManager networkManager)
            : base(name, innerModel, networkManager)
        {
        }

        ///GENMHASH:8535B0E23E6704558262509B5A55B45D:A38A2517ECAC89D37EAB01B83A00D407
        public IReadOnlyCollection<IVirtualNetworkGatewayIPConfiguration> IPConfigurations()
        {
            return ipConfigs.Values.ToList().AsReadOnly();
        }


        ///GENMHASH:0BDDE35CB8B3DD88A33C6363C54C0AF4:A53FB902D8052D360814DFFA0B1CEB40
        public VirtualNetworkGatewayType GatewayType()
        {
            return Inner.GatewayType;
        }

        ///GENMHASH:7B35A850EB3ED4D45443736E5DA5F56D:D1DF4B3C91F52A00A90DDD465919E483
        public VpnClientConfiguration VpnClientConfiguration()
        {
            return Inner.VpnClientConfiguration;
        }

        ///GENMHASH:7F86C125A87D152FD762C431C7E77E76:8499787EA21C54ECB62EBA36A555DD42
        public bool IsBgpEnabled()
        {
            if (Inner.EnableBgp.HasValue)
            {
                return Inner.EnableBgp.Value;
            }
            return false;
        }

        ///GENMHASH:F157B95CCB8CF0DA53120069F9F2C22E:AC1F1618AD3F0F9E28C72955671856B0
        public BgpSettings BgpSettings()
        {
            return Inner.BgpSettings;
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:43E446F640DC3345BDBD9A3378F2018A
        public VirtualNetworkGatewaySku Sku()
        {
            return this.Inner.Sku;
        }

        ///GENMHASH:F99E854D8AAB8BF785315F056C8E5841:F8CE870B2409B36218704067B16D0893
        public bool ActiveActive()
        {
            return Inner.ActiveActive.HasValue ? Inner.ActiveActive.Value : false;
        }

        ///GENMHASH:386C210EC4D5BBD8C3D394142B2C0750:D3617A465978379A3EFA4AC36D95F3B2
        public IVirtualNetworkGatewayConnections Connections()
        {
            if (connections == null)
            {
                connections = new VirtualNetworkGatewayConnectionsImpl(this);
            }
            return connections;
        }

        ///GENMHASH:3B2C34DD470793DBFE07EF485D8E35B3:3D625CD3BE33F1BDF4A380925C6BCAC2
        public async Task ResetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // TODO: gatewayVip is not null for Active-Active configuration
            await Manager.Inner.VirtualNetworkGateways.ResetAsync(ResourceGroupName, Name, null, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:E22C6898BD46DFC7E4BA741E47A25FCD:130D5B3A30C34F066046287000EF7300
        internal VirtualNetworkGatewayImpl WithConfig(VirtualNetworkGatewayIPConfigurationImpl config)
        {
            if (config != null)
            {
                ipConfigs[config.Name()] = config;
            }
            return this;
        }

        ///GENMHASH:6E2DB095301FA5F54EABD8841D651031:6ECEFC402E9AA9F35C569FFECCCFB74C
        public VirtualNetworkGatewayImpl WithoutBgp()
        {
            Inner.BgpSettings = null;
            Inner.EnableBgp = false;
            return this;
        }

        ///GENMHASH:52541ED0C8AE1806DF3F2DF0DE092357:0C8BC6D2668030C17723EE0F2EBC2291
        public VirtualNetworkGatewayImpl WithNewPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            this.creatablePip = creatable;
            return this;
        }

        ///GENMHASH:1C505DCDEFCB5F029B7A60E2375286BF:21FFE595C29A65C12E3FE69611717038
        public VirtualNetworkGatewayImpl WithNewPublicIPAddress()
        {
            string pipName = SdkContext.RandomResourceName("pip", 9);
            this.creatablePip = this.Manager.PublicIPAddresses.Define(pipName)
                .WithRegion(this.RegionName)
                .WithExistingResourceGroup(this.ResourceGroupName);
            return this;
        }

        public string GenerateVpnProfile()
        {
            return Extensions.Synchronize(() => this.GenerateVpnProfileAsync());
        }

        public PointToSiteConfigurationImpl UpdatePointToSiteConfiguration()
        {
            return new PointToSiteConfigurationImpl(Inner.VpnClientConfiguration, this);
        }

        internal void AttachPointToSiteConfiguration(PointToSiteConfigurationImpl pointToSiteConfiguration)
        {
            Inner.VpnClientConfiguration = pointToSiteConfiguration.Inner;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:ED53F38CFE3724E460E65F33FB69C01D
        protected override async Task<Models.VirtualNetworkGatewayInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.VirtualNetworkGateways.GetAsync(ResourceGroupName, Name);
        }

        ///GENMHASH:D232B3BB0D86D13CC0B242F4000DBF07:A6337C672FE4D2497063C4689F0BFDAE
        private ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> EnsureDefaultPipDefinition()
        {
            if (creatablePip == null)
            {
                string pipName = SdkContext.RandomResourceName("pip", 9);
                creatablePip = Manager.PublicIPAddresses.Define(pipName)
                    .WithRegion(this.RegionName)
                    .WithExistingResourceGroup(this.ResourceGroupName);
            }

            return creatablePip;
        }

        ///GENMHASH:F1D809E72100A32A88F33ADB2356893B:83A6444D89474D9E0A81484A4E69AE59
        private void InitializeIPConfigsFromInner()
        {
            ipConfigs = new Dictionary<string, IVirtualNetworkGatewayIPConfiguration>();
            var inners = this.Inner.IpConfigurations;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var config = new VirtualNetworkGatewayIPConfigurationImpl(inner, this);
                    ipConfigs[inner.Name] = config;
                }
            }
        }

        ///GENMHASH:EE424593047EC034E4F687A7D891306B:FB90A8FA59771F5D7A9F2D0152458B21
        public VirtualNetworkGatewayImpl WithBgp(long asn, string bgpPeeringAddress)
        {
            Inner.EnableBgp = true;
            BgpSettings bgpSettings = EnsureBgpSettings();
            bgpSettings.Asn = asn;
            bgpSettings.BgpPeeringAddress = bgpPeeringAddress;
            return this;
        }
        ///GENMHASH:CD9D1A4AC3ED441D00B98B9B320AC09D:BF1BB51B936203E7C498DE394C7D6437
        public VirtualNetworkGatewayImpl WithPolicyBasedVpn()
        {
            Inner.GatewayType = VirtualNetworkGatewayType.Vpn;
            Inner.VpnType = Models.VpnType.PolicyBased;
            return this;
        }

        ///GENMHASH:7BCFE88DA79B70F3091D2820BC2AD538:235D0452060ED10B1F26C762062BDAC8
        public VirtualNetworkGatewayImpl WithRouteBasedVpn()
        {
            Inner.GatewayType = VirtualNetworkGatewayType.Vpn;
            Inner.VpnType = Models.VpnType.RouteBased;
            return this;
        }
        ///GENMHASH:5F33673C89B8C86CEB000C662B79A4D9:6EC0094C76D2A9C5B6105BABB8EAA58C
        public string GatewayDefaultSiteResourceId()
        {
            return Inner.GatewayDefaultSite == null ? null : Inner.GatewayDefaultSite.Id;
        }

        public async Task<string> GenerateVpnProfileAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await Manager.Inner.VirtualNetworkGateways
                .GenerateVpnProfileWithHttpMessagesAsync(ResourceGroupName, Name, new VpnClientParameters(), cancellationToken: cancellationToken))
            {
                if (result.Body != null) return result.Body;

                var bodyString = await result.Response.Content.ReadAsStringAsync();
                return bodyString.Replace("\"", "");
            }
        }

        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:149EB760CEBAD953681C8A653E657563
        protected async override Task<Models.VirtualNetworkGatewayInner> CreateInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var tasks = new List<Task>();

            VirtualNetworkGatewayIPConfigurationImpl defaultIPConfig = EnsureDefaultIPConfig();
            if (defaultIPConfig != null && defaultIPConfig.PublicIPAddressId() == null)
            {
                // If public ip not specified, then create a default PIP
                Task pipTask = Task.Run( async ()=>
                {
                    var publicIP = await EnsureDefaultPipDefinition().CreateAsync(cancellationToken);

                    defaultIPConfig.WithExistingPublicIPAddress(publicIP);
                });
                tasks.Add(pipTask);
            }

            // Determine if default VNet should be created
            if (defaultIPConfig.SubnetName() == null)
            {
                // But if default IP config does not have a subnet specified, then create a VNet
                Task networkTask = Task.Run(async ()=>
                {
                    var network = await creatableNetwork.CreateAsync(cancellationToken);
                    //... and assign the created VNet to the default IP config
                    defaultIPConfig.WithExistingSubnet(network, GATEWAY_SUBNET);
                });
                tasks.Add(networkTask);
            }
            await Task.WhenAll(tasks.ToArray());

            return await Manager.Inner.VirtualNetworkGateways.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken);
        }

        ///GENMHASH:6D9F740D6D73C56877B02D9F1C96F6E7:AAE687D87772A524C1EDF3A8BE3E97C4
        protected override void InitializeChildrenFromInner()
        {
            InitializeIPConfigsFromInner();

        }

        ///GENMHASH:F91F57741BB7E185BF012523964DEED0:B855D73B977281A4DC1F154F5A7D4DC5
        protected override void AfterCreating()
        {
        }

        ///GENMHASH:BE684C4F4845D0C09A9399569DFB7A42:05B694DF2AF4DFEC5D2DC7534C0AD459
        public VirtualNetworkGatewayImpl WithExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            EnsureDefaultIPConfig().WithExistingPublicIPAddress(publicIPAddress);
            return this;
        }

        ///GENMHASH:3C078CA3D79C59C878B566E6BDD55B86:7BA8858E84B3207FCBA833B4007045AC
        public VirtualNetworkGatewayImpl WithExistingPublicIPAddress(string resourceId)
        {
            EnsureDefaultIPConfig().WithExistingPublicIPAddress(resourceId);
            return this;
        }

        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:166EA5FAEBD8EF7829C0875573231D79
        protected override void BeforeCreating()
        {
            // Reset and update IP configs
            EnsureDefaultIPConfig();
            this.Inner.IpConfigurations = InnersFromWrappers<VirtualNetworkGatewayIPConfigurationInner, IVirtualNetworkGatewayIPConfiguration>(this.ipConfigs.Values);
        }

        ///GENMHASH:6EBB2EF319A59A13633F5A0954A40EF9:5E1483B1F2AC819468AF87C89BCDB29C
        private VirtualNetworkGatewayIPConfigurationImpl EnsureDefaultIPConfig()
        {
            VirtualNetworkGatewayIPConfigurationImpl ipConfig = (VirtualNetworkGatewayIPConfigurationImpl)DefaultIPConfiguration();
            if (ipConfig == null)
            {
                string name = SdkContext.RandomResourceName("ipcfg", 11);
                ipConfig = DefineIPConfiguration(name);
                ipConfig.Attach();
            }
            return ipConfig;
        }

        ///GENMHASH:8477D6D598DD5DE7CFD64D231FD9BB43:35CBFE2D3067627F27C17685399D1852
        public IEnumerable<IVirtualNetworkGatewayConnection> ListConnections()
        {
            return WrapConnectionsList(Extensions.Synchronize(() => Manager.Inner.VirtualNetworkGateways.ListConnectionsAsync(this.ResourceGroupName, this.Name)));
        }

        ///GENMHASH:1CF7458570EB3183A47A71F08EA5D0DA:9ABE9FDD63D8CCC22EA023A49D808C8A
        public async Task<IPagedCollection<IVirtualNetworkGatewayConnection>> ListConnectionsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var connections = await Manager.Inner.VirtualNetworkGateways.ListConnectionsAsync(this.ResourceGroupName, this.Name);
            var result = connections.Select((inner) => WrapConnection(inner));
            return PagedCollection<IVirtualNetworkGatewayConnection, VirtualNetworkGatewayConnectionListEntityInner>.CreateFromEnumerable(result);
        }

        ///GENMHASH:FFC621DA0580E44927EBEA8D394C1105:84CEF0775356674F2DF43DA4215FAB0F
        private BgpSettings EnsureBgpSettings()
        {
            if (Inner.BgpSettings == null)
            {
                Inner.BgpSettings = new BgpSettings();
            }
            return Inner.BgpSettings;
        }

        ///GENMHASH:336A01EC3CBEC3D567B7528698CA0183:88F798BAC90F5A637C8159732624C8FB
        internal IVirtualNetworkGatewayIPConfiguration DefaultIPConfiguration()
        {
            if (ipConfigs != null && ipConfigs.Count == 1)
            {
                var enumerator = ipConfigs.Values.GetEnumerator();
                enumerator.MoveNext();
                return enumerator.Current;
            }
            return null;
        }


        ///GENMHASH:E40693A780061FC1A156598B974969F1:BB97F4F4051A2B51D3862BFF3B7F9556
        public VirtualNetworkGatewayImpl WithExpressRoute()
        {
            Inner.GatewayType = VirtualNetworkGatewayType.ExpressRoute;
            return this;
        }

        ///GENMHASH:DE0F4E4D7BE6C2D424AD89F5B15B8C65:728DC4397D3FF615073A7E4F0B270949
        public VirtualNetworkGatewayImpl WithNewNetwork(ICreatable<INetwork> creatable)
        {
            this.creatableNetwork = creatable;
            return this;
        }

        ///GENMHASH:BADDFF325BE650E465684B9E9C420713:EF15F2179E69AEE60447694AD9406A85
        public VirtualNetworkGatewayImpl WithNewNetwork(string name, string addressSpace, string subnetAddressSpaceCidr)
        {
            Network.Definition.IWithGroup definitionWithGroup = Manager.Networks
                .Define(name)
                .WithRegion(RegionName);

            Network.Definition.IWithCreate definitionAfterGroup;
            if (NewGroup() != null)
            {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(NewGroup());
            }
            else
            {
                definitionAfterGroup = definitionWithGroup.WithExistingResourceGroup(ResourceGroupName);
            }

            return WithNewNetwork(definitionAfterGroup.WithAddressSpace(addressSpace).WithSubnet(GATEWAY_SUBNET, subnetAddressSpaceCidr));
        }

        ///GENMHASH:B5B394278E45FCA8B4503E2FCB31EF46:73855B85F080F7898FA413DCAC4083C7
        public VirtualNetworkGatewayImpl WithNewNetwork(string addressSpaceCidr, string subnetAddressSpaceCidr)
        {
            WithNewNetwork(SdkContext.RandomResourceName("vnet", 8), addressSpaceCidr, subnetAddressSpaceCidr);
            return this;
        }

        ///GENMHASH:5108328B04041EB0EF9F49CCD01547AA:CE49984EEED57FF39333B5210E47B1D5
        public VirtualNetworkGatewayImpl WithSku(VirtualNetworkGatewaySkuName skuName)
        {
            VirtualNetworkGatewaySku sku = new VirtualNetworkGatewaySku()
            {
                // same sku tier as sku name
                Name = skuName,
                Tier = VirtualNetworkGatewaySkuTier.Parse(skuName.Value)
            };
            Inner.Sku = sku;
            return this;
        }


        ///GENMHASH:9C0E7D718A08B4C0A786388FB107D59D:7D5BABA29E5B9822D918808ECCADA379
        private IEnumerable<IVirtualNetworkGatewayConnection> WrapConnectionsList(IEnumerable<VirtualNetworkGatewayConnectionListEntityInner> connectionListEntityInners)
        {
            return connectionListEntityInners.Select(inner => WrapConnection(inner));
        }

        private IVirtualNetworkGatewayConnection WrapConnection(VirtualNetworkGatewayConnectionListEntityInner inner)
        {
            return Connections().GetById(inner.Id);
        }

        public PointToSiteConfigurationImpl DefinePointToSiteConfiguration()
        {
            return new PointToSiteConfigurationImpl(new VpnClientConfiguration(), this);
        }

        ///GENMHASH:B54CAD7C3DE0D3C50B8DCF3D902BFB18:4F12E780C5065E3EB6FFCB437197D940
        public VirtualNetworkGatewayImpl WithExistingNetwork(INetwork network)
        {
            EnsureDefaultIPConfig().WithExistingSubnet(network, GATEWAY_SUBNET);
            return this;
        }

        ///GENMHASH:274B24299CAF08B0C464C44F81F293C4:A21F23524D896AC1F0F5FBED80AD9C2B
        public void Reset()
        {
            Extensions.Synchronize(() => ResetAsync());
        }

        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:DD9138528C6276E1CD3AB7D791FB3CCD
        public async override Task<IVirtualNetworkGateway> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await GetInnerAsync(cancellationToken);
            SetInner(inner);
            InitializeChildrenFromInner();
            return this;
        }

        ///GENMHASH:EB9010098916DB0783BD4F8210557775:9DED2E4BB6BF3B4B59C279F025D54359
        public VpnType VpnType()
        {
            return Inner.VpnType;
        }

        ///GENMHASH:30845DAECBF61D7211678C9DC6EC7B14:80D31269AE598B94897682B4DE95A6D1
        internal ICreatable<Microsoft.Azure.Management.ResourceManager.Fluent.IResourceGroup> NewGroup()
        {
            return newGroup;
        }

        ///GENMHASH:A50981B34B33B00C33160ECE2AE8F250:0A11AD43F04ABC9EA06ABCD8A9D06567
        private VirtualNetworkGatewayIPConfigurationImpl DefineIPConfiguration(string name)
        {
            IVirtualNetworkGatewayIPConfiguration value = null;
            if (this.ipConfigs.TryGetValue(name, out value))
            {
                return (VirtualNetworkGatewayIPConfigurationImpl)value;
            }
            var inner = new VirtualNetworkGatewayIPConfigurationInner()
            {
                Name = name
            };
            return new VirtualNetworkGatewayIPConfigurationImpl(inner, this);
        }

        protected override async Task<VirtualNetworkGatewayInner> ApplyTagsToInnerAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await this.Manager.Inner.VirtualNetworkGateways.UpdateTagsAsync(ResourceGroupName, Name, Inner.Tags, cancellationToken);
        }
    }
}