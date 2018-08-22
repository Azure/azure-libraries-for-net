// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for PublicIPAddress.
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUHVibGljSVBBZGRyZXNzSW1wbA==
    internal partial class PublicIPAddressImpl :
        GroupableResource<IPublicIPAddress,
            PublicIPAddressInner,
            PublicIPAddressImpl,
            INetworkManager,
            PublicIPAddress.Definition.IWithGroup,
            PublicIPAddress.Definition.IWithCreate,
            PublicIPAddress.Definition.IWithCreate,
            PublicIPAddress.Update.IUpdate>,
        IPublicIPAddress,
        PublicIPAddress.Definition.IDefinition,
        PublicIPAddress.Update.IUpdate,
        IAppliableWithTags<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress>
    {

        ///GENMHASH:63A53AB51A7D5A79D8B7047D1A8C8CCF:3881994DCADCE14215F82F0CC81BDD88
        internal PublicIPAddressImpl(
            string name,
            PublicIPAddressInner innerModel,
            INetworkManager networkManager) : base(name, innerModel, networkManager)
        {
        }


        ///GENMHASH:0268D4A22C553236F2D086625BC961C0:99F3B859668CAC9A1F4A84E29AE2E9C5
        internal PublicIPAddressImpl WithIdleTimeoutInMinutes(int minutes)
        {
            Inner.IdleTimeoutInMinutes = minutes;
            return this;
        }

        ///GENMHASH:5D8D71845C83EB59F52EB2C4B1C05618:996B2BEC0DFE2E48ABD0B158B0F517CC
        public PublicIPAddressImpl WithAvailabilityZone(AvailabilityZoneId zoneId)
        {
            // Note: Zone is not updatable as of now, so this is available only during definition time.
            // Service return `ResourceAvailabilityZonesCannotBeModified` upon attempt to append a new
            // zone or remove one. Trying to remove the last one means attempt to change resource from
            // zonal to regional, which is not supported.
            //
            if (this.Inner.Zones == null)
            {
                this.Inner.Zones = new List<string>();
            }
            this.Inner.Zones.Add(zoneId.ToString());
            return this;
        }

        ///GENMHASH:9A443A611DC75C5B1989A92740A6632E:6164D897AE308F9AC8CE783A820AA66B
        public PublicIPAddressImpl WithSku(PublicIPSkuType skuType)
        {
            // Note: SKU is not updatable as of now, so this is available only during definition time.
            // Service return `SkuCannotBeChangedOnUpdate` upon attempt to change it.
            // Service default is PublicIPSkuType.BASIC
            //
            this.Inner.Sku = new PublicIPAddressSku
            {
                Name = PublicIPAddressSkuName.Parse(skuType.ToString())
            };
            return this;
        }

        ///GENMHASH:F856C02184EB290DC74E5823D4280D7C:C06C8F12A2F1E86C908BE0388D483D06
        public System.Collections.Generic.ISet<Microsoft.Azure.Management.ResourceManager.Fluent.Core.AvailabilityZoneId> AvailabilityZones()
        {
            var zones = new HashSet<Microsoft.Azure.Management.ResourceManager.Fluent.Core.AvailabilityZoneId>();
            if (this.Inner.Zones != null)
            {
                foreach (var zone in this.Inner.Zones)
                {
                    zones.Add(AvailabilityZoneId.Parse(zone));
                }
            }
            return zones;
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:C92566E1FEC54840C1B1CFEBC8066D9A
        public PublicIPSkuType Sku()
        {
            if (this.Inner.Sku == null || this.Inner.Sku.Name == null)
            {
                return null;
            }
            return PublicIPSkuType.Parse(this.Inner.Sku.Name.Value);
        }

        ///GENMHASH:969BC7B1870284D2FCF3192BD82F142F:5DAA827087A429B57970263E396335D1
        internal PublicIPAddressImpl WithStaticIP()
        {

            Inner.PublicIPAllocationMethod = Models.IPAllocationMethod.Static;
            return this;
        }


        ///GENMHASH:E601A7030461C04378EF23ACF207D4C2:6F94222AD7A6FAA5BDB1F4A8C2336D54
        internal PublicIPAddressImpl WithDynamicIP()
        {
            Inner.PublicIPAllocationMethod = Models.IPAllocationMethod.Dynamic;
            return this;
        }


        ///GENMHASH:4FD71958F542A872CEE597B1CEA332F8:AB2BC7CCCA80EFA2219ABEAE56789805
        internal PublicIPAddressImpl WithLeafDomainLabel(string dnsName)
        {
            if (Inner.DnsSettings == null)
            {
                Inner.DnsSettings = new PublicIPAddressDnsSettings();
            }
            Inner.DnsSettings.DomainNameLabel = dnsName?.ToLower();
            return this;
        }


        ///GENMHASH:D0C9704935325DA53D3E18EA383CD798:3A3B2F00929ADB2E5CB95C1ABC9DB961
        internal PublicIPAddressImpl WithoutLeafDomainLabel()
        {
            return WithLeafDomainLabel(null);
        }


        ///GENMHASH:0A9A497E14DD1A2758E52AC9D42D71E4:D54DE8ED5EB6D0455BCE0CD34D01FF08
        internal PublicIPAddressImpl WithReverseFqdn(string reverseFqdn)
        {
            if (Inner.DnsSettings == null)
            {
                Inner.DnsSettings = new PublicIPAddressDnsSettings();
            }
            Inner.DnsSettings.ReverseFqdn = reverseFqdn.ToLower();
            return this;
        }


        ///GENMHASH:CC17160998D6B4E37C903F79D511BFF8:41B40BEF775E8DC82AB66ADC6601D69B
        internal PublicIPAddressImpl WithoutReverseFqdn()
        {
            return WithReverseFqdn(null);
        }


        ///GENMHASH:D4505189DA8BE6159A0773DFA0AC5132:A12F20EDB49307C5BFD8B28E927C67DA
        internal int IdleTimeoutInMinutes()
        {
            return (Inner.IdleTimeoutInMinutes.HasValue) ? Inner.IdleTimeoutInMinutes.Value : 0;
        }


        ///GENMHASH:7248510394946B110C799F104E023F9D:00D88D2717A616B24525A5934BEBB4F1
        internal IPAllocationMethod IPAllocationMethod()
        {
            return Inner.PublicIPAllocationMethod;
        }


        ///GENMHASH:493B1EDB88EACA3A476D936362A5B14C:FCE799745FA15D3EA39692B492C8E747
        internal IPVersion Version()
        {
            return Inner.PublicIPAddressVersion;
        }


        ///GENMHASH:577F8437932AEC6E08E1A137969BDB4A:DF24BB824B6120C47B7D78874CC08BE4
        internal string Fqdn()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.Fqdn : null;
        }


        ///GENMHASH:F7F6CD29C046FFE5CC8019B6D29D4C49:00BEC0361DBB94C8C1961479021B2DB0
        internal string ReverseFqdn()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.ReverseFqdn : null;
        }


        ///GENMHASH:EB9638E8F65D17F5F594E27D773A247D:1F3289A2A9DF010E78AD3BD5B49AA422
        internal string IPAddress()
        {
            return Inner.IpAddress;
        }


        ///GENMHASH:D8227AFFBD25C58BB7DEDE4EE7B555B2:C767F9B041C82EFD9866C5FFB21D93D6
        internal string LeafDomainLabel()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.DomainNameLabel : null;
        }


        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:B65DC9A7BA04E810BF21FC1AF864DDBF
        public async override Task<IPublicIPAddress> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            PublicIPAddressDnsSettings dnsSettings = Inner.DnsSettings;
            if (dnsSettings != null)
            {
                if (string.IsNullOrWhiteSpace(dnsSettings.DomainNameLabel)
                   && string.IsNullOrWhiteSpace(dnsSettings.Fqdn)
                   && string.IsNullOrWhiteSpace(dnsSettings.ReverseFqdn))
                {
                    Inner.DnsSettings = null;
                }
            }

            SetInner(await Manager.Inner.PublicIPAddresses.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken));
            return this;
        }


        ///GENMHASH:6F4C8A6809867E6F20C204CD3308DA84:5200E97FCE5138CD9DD63AD78E39C256
        private bool EqualsResourceType(string resourceType)
        {

            IPConfigurationInner ipConfig = Inner.IpConfiguration;
            if (ipConfig == null || resourceType == null)
            {
                return false;
            }
            else
            {
                string refId = Inner.IpConfiguration.Id;
                string resourceType2 = ResourceUtils.ResourceTypeFromResourceId(refId);
                return resourceType.Equals(resourceType2, System.StringComparison.OrdinalIgnoreCase);
            }
        }


        ///GENMHASH:CD5A0A8CF5779E1E813F20D0B3CD83F7:EB6216948B7FDAD24F133B42C68DFB59
        internal bool HasAssignedLoadBalancer()
        {
            return EqualsResourceType("frontendIPConfigurations");
        }


        ///GENMHASH:3D00D26E72F1900D476D1ACE8411DAF6:F971C39FDCD048594E38CC74943E6D11
        internal ILoadBalancerPublicFrontend GetAssignedLoadBalancerFrontend()
        {
            if (HasAssignedLoadBalancer() == true)
            {
                string refId = Inner.IpConfiguration.Id;
                string loadBalancerId = ResourceUtils.ParentResourcePathFromResourceId(refId);
                ILoadBalancer lb = Manager.LoadBalancers.GetById(loadBalancerId);
                string frontendName = ResourceUtils.NameFromResourceId(refId);
                return (ILoadBalancerPublicFrontend)lb.Frontends[frontendName];
            }
            else
            {
                return null;
            }
        }


        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:B38C21836BA9DDBB11E47E4224EB7F47
        protected override async Task<PublicIPAddressInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.PublicIPAddresses.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }


        ///GENMHASH:7D4EDB8798720C21E834ABC3BEB6E503:C11A523B66806B5E409AF440EE4B612E
        internal bool HasAssignedNetworkInterface()
        {
            return EqualsResourceType("ipConfigurations");
        }


        ///GENMHASH:A1B27043EDDA443759481B85FD256336:71FB3A052B839706E2B1CB9C30A82790
        internal INicIPConfiguration GetAssignedNetworkInterfaceIPConfiguration()
        {
            if (HasAssignedNetworkInterface())
            {
                string refId = Inner.IpConfiguration.Id;
                string parentId = ResourceUtils.ParentResourcePathFromResourceId(refId);
                INetworkInterface nic = Manager.NetworkInterfaces.GetById(parentId);
                string childName = ResourceUtils.NameFromResourceId(refId);
                return nic.IPConfigurations[childName];
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:BCABB5578B0BD7DC8F8C22F4769FD3DE:02984D22C1D2E484D62F2595E7B0E86C
        public IPublicIPAddress ApplyTags()
        {
            return Extensions.Synchronize(() => ApplyTagsAsync());
        }

        ///GENMHASH:6B8BA63027964E06F44A927837B450A0:73A3E3DE52EE39671B79DFFC66BC8B20
        public async Task<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> ApplyTagsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await Manager.Inner.PublicIPAddresses.UpdateTagsAsync(ResourceGroupName, Name, Inner.Tags, cancellationToken);
            SetInner(inner);
            return this;
        }


        ///GENMHASH:DD514B859A01D5FDAFF5D26EACDFE197:40A980295F5EA8FF8304DA8C06E899BF
        public PublicIPAddressImpl UpdateTags()
        {
            return this;
        }
    }
}