// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The implementation for  ComputeSku.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uQ29tcHV0ZVNrdUltcGw=
    internal sealed partial class ComputeSkuImpl : IComputeSku
    {
        private readonly ResourceSkuInner inner;

        ResourceSkuInner IHasInner<ResourceSkuInner>.Inner => this.Inner();

        ///GENMHASH:8D9D2C9D2BDF48FE8D9C24EBA1CF6ACD:BC4B1282CA708DC220050F834F17A184
        internal ComputeSkuImpl(ResourceSkuInner inner)
        {
            this.inner = inner;
        }

        ///GENMHASH:60625ECBA02456ACAA508AE89C60D15A:538FA83196E649561A55A428573B44CE
        public AvailabilitySetSkuTypes AvailabilitySetSkuType()
        {
            if (this.inner.ResourceType != null
                && this.inner.ResourceType.Equals("availabilitySets", System.StringComparison.OrdinalIgnoreCase)
                && this.inner.Name != null)
            {
                return AvailabilitySetSkuTypes.Parse(this.inner.Name);
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:4A20EAC69A38862B2EB0CA9B812A106E:A408EB66E596ED5640638AEF93324A3C
        public IReadOnlyList<Models.ResourceSkuCosts> Costs()
        {
            if (this.inner.Costs != null)
            {
                return new List<Models.ResourceSkuCosts>(this.inner.Costs);
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:59C1E25F0E77F718395079384661872B:B562BFB1C5ECFEB2DC2005E876CE0263
        public IReadOnlyList<Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region> Regions()
        {
            var regions = new List<Region>();
            if (this.inner.Locations != null)
            {
                foreach (var location in this.inner.Locations)
                {
                    regions.Add(Region.Create(location));
                }
            }
            return regions;
        }

        ///GENMHASH:35EB1A31F5F9EE9C1A764577CD186B0D:FE9742C1322FA638CF7AAFBE12C456F8
        public IReadOnlyList<Models.ResourceSkuCapabilities> Capabilities()
        {
            if (this.inner.Capabilities != null)
            {
                return new List<Models.ResourceSkuCapabilities>(this.inner.Capabilities);
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:2AE8A9F45F1B5A337F363BAAC701B2FA:DBB1AD7AF7B78F043E64EA8D7C1891B9
        public IReadOnlyList<Models.ResourceSkuRestrictions> Restrictions()
        {
            if (this.inner.Restrictions != null)
            {
                return new List<Models.ResourceSkuRestrictions>(this.inner.Restrictions);
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:E087239423DB24947B067EFDA925648F:F36C060B935C63BD26B291576032CC5A
        public IReadOnlyDictionary<Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region, System.Collections.Generic.ISet<Microsoft.Azure.Management.ResourceManager.Fluent.Core.AvailabilityZoneId>> Zones()
        {
            Dictionary<Region, ISet<AvailabilityZoneId>> regionToZones = new Dictionary<Region, ISet<AvailabilityZoneId>>();
            if (this.inner.LocationInfo != null)
            {
                foreach (var info in this.inner.LocationInfo)
                {
                    if (info.Location != null)
                    {
                        var region = Region.Create(info.Location);
                        if (!regionToZones.ContainsKey(region))
                        {
                            regionToZones.Add(region, new HashSet<AvailabilityZoneId>());
                        }
                        ISet<AvailabilityZoneId> availabilityZoneIds = regionToZones[region];
                        if (info.Zones != null)
                        {
                            foreach (var zoneStr in info.Zones)
                            {
                                var zone = AvailabilityZoneId.Parse(zoneStr);
                                if (!availabilityZoneIds.Contains(zone))
                                {
                                    availabilityZoneIds.Add(zone);
                                }
                            }
                        }
                    }
                }
            }
            return regionToZones;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public ResourceSkuInner Inner()
        {
            return this.inner;
        }

        ///GENMHASH:F0B439C5B2A4923B3B36B77503386DA7:45B46E567729791C7C4BE2AD5B53963C
        public ResourceSkuCapacity Capacity()
        {
            return this.inner.Capacity;
        }

        ///GENMHASH:F756CBB3F13EF6198269C107AED6F9A2:5A9D8298D3068EA259CB3F7B6A5ABFEC
        public ComputeSkuTier Tier()
        {
            if (this.inner.Tier != null)
            {
                return ComputeSkuTier.Parse(this.inner.Tier);
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:B14A05E800FF2D9D7B9EEA65A62FB0B8:7907AA5814695DDB88E01212981836D8
        public IReadOnlyList<string> ApiVersions()
        {
            if (this.inner.ApiVersions != null)
            {
                return new List<string>(this.inner.ApiVersions);
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:5D505211AD0873F68073B4A7850ECB04
        public ComputeSkuName Name()
        {
            if (this.inner.Name != null)
            {
                return ComputeSkuName.Parse(this.inner.Name);
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:ADBB2BA7D9DA68A975B518B1AED2CBC7:625A4487ABCC03FFC076F2A5FA047ABB
        public VirtualMachineSizeTypes VirtualMachineSizeType()
        {
            if (this.inner.ResourceType != null
                && this.inner.ResourceType.Equals("virtualMachines", System.StringComparison.OrdinalIgnoreCase)
                && this.inner.Name != null)
            {
                return VirtualMachineSizeTypes.Parse(this.inner.Name);
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:EC2A5EE0E9C0A186CA88677B91632991:73A8AB022E64791584A29A74AEF6C9C7
        public ComputeResourceType ResourceType()
        {
            if (this.inner.ResourceType != null)
            {
                return ComputeResourceType.Parse(this.inner.ResourceType);
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:08C16A717E4778526168C783D7E02873:5CDB83FF69B6F42640F7ADC9D700AF7A
        public DiskSkuTypes DiskSkuType()
        {
            if (this.inner.ResourceType != null
                && (this.inner.ResourceType.Equals("disks", System.StringComparison.OrdinalIgnoreCase)
                || this.inner.ResourceType.Equals("snapshots", System.StringComparison.OrdinalIgnoreCase))
                && this.inner.Name != null)
            {
                if (this.inner.Name.Equals("Standard_LRS", System.StringComparison.OrdinalIgnoreCase))
                {
                    return DiskSkuTypes.FromStorageAccountType(DiskStorageAccountTypes.StandardLRS);
                }
                if (this.inner.Name.Equals("Premium_LRS", System.StringComparison.OrdinalIgnoreCase))
                {
                    return DiskSkuTypes.FromStorageAccountType(DiskStorageAccountTypes.PremiumLRS);
                }
				if (this.inner.Name.Equals("StandardSSD_LRS", System.StringComparison.OrdinalIgnoreCase))
                {
                    return DiskSkuTypes.FromStorageAccountType(DiskStorageAccountTypes.StandardSSDLRS);
                }
				if (this.inner.Name.Equals("UltraSSD_LRS", System.StringComparison.OrdinalIgnoreCase))
                {
                    return DiskSkuTypes.FromStorageAccountType(DiskStorageAccountTypes.UltraSSDLRS);
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}