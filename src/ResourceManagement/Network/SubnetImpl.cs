// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Network.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Subnet.Definition;
    using Models;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implementation for Subnet and its create and update interfaces.
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uU3VibmV0SW1wbA==
    internal partial class SubnetImpl :
        ChildResource<SubnetInner, NetworkImpl, INetwork>,
        ISubnet,
        Subnet.Definition.IDefinition<Network.Definition.IWithCreateAndSubnet>,
        Subnet.UpdateDefinition.IUpdateDefinition<Network.Update.IUpdate>,
        Subnet.Update.IUpdate
    {

        ///GENMHASH:95294A80FBE609A8A5735E8840009FC0:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal SubnetImpl(SubnetInner inner, NetworkImpl parent) : base(inner, parent)
        {
        }

        ///GENMHASH:800CEBA636763193270CED876CFEF15E:CB481EB2DEF3D1F45015152F66FFC968
        internal ISet<INicIPConfiguration> GetNetworkInterfaceIPConfigurations()
        {
            return (new SortedSet<INicIPConfiguration>(ListNetworkInterfaceIPConfigurations()));
        }

        ///GENMHASH:965854F936E6686E5CF712FF5E950D9E:49D3D07DD88DEEA404C2173A84254C19
        internal int NetworkInterfaceIPConfigurationCount()
        {
            var ipConfigRefs = Inner.IpConfigurations;
            if (ipConfigRefs != null)
            {
                return ipConfigRefs.Count;
            }
            else
            {
                return 0;
            }
        }


        ///GENMHASH:B9CBDB4C51BC9B92E1A239DE256FB5B6:8F0C59692A7F0EEB231DF5A0F980E52E
        internal string AddressPrefix()
        {
            return Inner.AddressPrefix;
        }


        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }


        ///GENMHASH:A9777D8010E6AF7B603113E49858FE75:0A1C32015C3FE7888D450702542868EA
        public string NetworkSecurityGroupId()
        {
            return (Inner.NetworkSecurityGroup != null) ? Inner.NetworkSecurityGroup.Id : null;
        }


        ///GENMHASH:A52B043B03F5F5DD10F6A96CBC569DBC:08C6FC794C26CE7AA9BBF95E8E59293F
        public string RouteTableId()
        {
            return (Inner.RouteTable != null) ? Inner.RouteTable.Id : null;
        }


        ///GENMHASH:2E4015B29759BBD97527EBAE809B083C:92C42A9D6A5461310D3C0243B1847E84
        internal INetworkSecurityGroup GetNetworkSecurityGroup()
        {
            var nsgId = NetworkSecurityGroupId();
            return (nsgId != null)
                ? Parent.Manager.NetworkSecurityGroups.GetById(nsgId)
                : null;
        }


        ///GENMHASH:BA4A7979677C1D828E7871F45A6E05CC:E8989A21602F80AB9EDF762AAAC1EAEF
        public IRouteTable GetRouteTable()
        {
            return (RouteTableId() != null)
                ? Parent.Manager.RouteTables.GetById(RouteTableId())
                : null;
        }

        ///GENMHASH:33C1C987DF52CFF94EDF2633458514E4:DE74936B83C8416C09839259665F2BD2
        public IReadOnlyDictionary<Models.ServiceEndpointType, System.Collections.Generic.List<Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region>> ServicesWithAccess()
        {
            var services = new Dictionary<ServiceEndpointType, List<Region>>();
            if (this.Inner.ServiceEndpoints != null)
            {
                foreach (var endpoint in this.Inner.ServiceEndpoints)
                {
                    ServiceEndpointType serviceEndpointType = ServiceEndpointType.Parse(endpoint.Service);
                    if (!services.ContainsKey(serviceEndpointType))
                    {
                        services.Add(serviceEndpointType, new List<Region>());
                    }
                    if (endpoint.Locations != null)
                    {
                        List<Region> regions = new List<Region>();
                        foreach (var location in endpoint.Locations)
                        {
                            regions.Add(Region.Create(location));
                        }
                        services[serviceEndpointType].AddRange(regions);
                    }
                }
            }
            return services;
        }

        ///GENMHASH:749BD8C1D070A6DAE2D9F29DAE294FAE:9DD0E90F3B1A067185751A1074341EAF
        internal SubnetImpl WithExistingNetworkSecurityGroup(string resourceId)
        {
            Inner.NetworkSecurityGroup = new SubResource(id: resourceId);
            return this;
        }


        ///GENMHASH:9BCDEB79AFC04D55B9BC280847723DFC:3BACEC234E558FC90E41F9212B768D2E
        internal SubnetImpl WithExistingNetworkSecurityGroup(INetworkSecurityGroup nsg)
        {
            return WithExistingNetworkSecurityGroup(nsg.Id);
        }


        ///GENMHASH:FCA489D9E7B6963A2EAC736958554ABD:772ECDA870E1C3E00E31EFE045675F09
        public SubnetImpl WithExistingRouteTable(IRouteTable routeTable)
        {
            return WithExistingRouteTable(routeTable.Id);
        }


        ///GENMHASH:E65C5C625AF875FB82198BA44FB9C760:255A6ED505A38F6AAE7A10907F6CCDFC
        public Subnet.Update.IUpdate WithoutRouteTable()
        {
            Inner.RouteTable = null;
            return this;
        }


        ///GENMHASH:C142A0234F22048E67709B65DD642261:61C2A1A23D6BCA62D6705980C8D1BECE
        public SubnetImpl WithExistingRouteTable(string resourceId)
        {
            Inner.RouteTable = new SubResource(id: resourceId);
            return this;
        }


        ///GENMHASH:E56906080D3615F5D04C5EFAC903C1FB:FE030A8DB000669434FF6335D5D2136F
        internal SubnetImpl WithAddressPrefix(string cidr)
        {
            Inner.AddressPrefix = cidr;
            return this;
        }

        ///GENMHASH:4BBEC5095F134F13806627750ADC9D39:94AECEF6A2216225A2656ED6B352544E
        public SubnetImpl WithAccessFromService(ServiceEndpointType service)
        {
            if (this.Inner.ServiceEndpoints == null)
            {
                this.Inner.ServiceEndpoints = new List<ServiceEndpointPropertiesFormat>();
            }
            bool found = false;
            foreach (var endpoint in this.Inner.ServiceEndpoints)
            {
                if (endpoint.Service.Equals(service.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                this.Inner
                    .ServiceEndpoints
                    .Add(new ServiceEndpointPropertiesFormat
                    {
                        Service = service.ToString(),
                        Locations = new List<string>()
                    });
            }
            return this;
        }

        ///GENMHASH:4BF88A9FA8C6CBDE8C9FB8F2E36F2042:2364D37AC0E056BCEDF007BC6849ADD1
        public Subnet.Update.IUpdate WithoutAccessFromService(ServiceEndpointType service)
        {
            if (this.Inner.ServiceEndpoints != null)
            {
                int foundIndex = -1;
                int i = 0;
                foreach (var endpoint in this.Inner.ServiceEndpoints)
                {
                    if (endpoint.Service.Equals(service.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        foundIndex = i;
                        break;
                    }
                    i++;
                }
                if (foundIndex != -1)
                {
                    this.Inner.ServiceEndpoints.RemoveAt(foundIndex);
                }
            }
            return this;
        }


        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:3EB15D579457E999436D02A2F8EEB291
        internal NetworkImpl Attach()
        {
            return Parent.WithSubnet(this);
        }

        Network.Update.IUpdate ISettable<Network.Update.IUpdate>.Parent()
        {
            return Parent;
        }


        ///GENMHASH:31626FBDA69232B7DD9945ADF14E191A:245758B25F0370039EC9345CF6DFAC4C
        internal SubnetImpl WithoutNetworkSecurityGroup()
        {
            Inner.NetworkSecurityGroup = null;
            return this;
        }

        ///GENMHASH:A4DDE1D1D48B67FA48D835924D16FDA1:FF7B041ADA25EA1EECE12F0DADBD55E5
        internal IReadOnlyCollection<INicIPConfiguration> ListNetworkInterfaceIPConfigurations()
        {
            List<INicIPConfiguration> ipConfigs = new List<INicIPConfiguration>();
            IDictionary<string, INetworkInterface> nics = new SortedDictionary<string, INetworkInterface>();
            IList<IPConfigurationInner> ipConfigRefs = Inner.IpConfigurations;
            if (ipConfigRefs == null)
            {
                return ipConfigs;
            }

            foreach (var ipConfigRef in ipConfigRefs)
            {
                string nicID = ResourceUtils.ParentResourcePathFromResourceId(ipConfigRef.Id);
                string ipConfigName = ResourceUtils.NameFromResourceId(ipConfigRef.Id);
                // Check if NIC already cached
                INetworkInterface nic;
                if (!nics.TryGetValue(nicID.ToLower(), out nic))
                {
                    //  NIC not previously found, so ask Azure for it
                    nic = Parent.Manager.NetworkInterfaces.GetById(nicID);
                }

                if (nic == null)
                {
                    // NIC doesn't exist so ignore this bad reference
                    continue;
                }

                // Cache the NIC
                nics[nic.Id.ToLower()] = nic;

                // Get the IP config
                INicIPConfiguration ipConfig = nic.IPConfigurations[ipConfigName];
                if (ipConfig == null)
                {
                    // IP config not found, so ignore this bad reference
                    continue;
                }

                ipConfigs.Add(ipConfig);
            }

            return ipConfigs;
        }

        ///GENMHASH:51856D80D1043AF4DAEAC97421929883:1EE6C0626118BB9397921EAE99A6FE25
        internal ISet<string> ListAvailablePrivateIPAddresses()
        {
            ISet<string> ipAddresses = new SortedSet<string>();

            string cidr = AddressPrefix();
            if (cidr == null)
            {
                return ipAddresses; // Should never happen, but just in case
            }

            string takenIPAddress = cidr.Split('/')[0];

            var result = Extensions.Synchronize(() => Parent.Manager.Networks.Inner.CheckIPAddressAvailabilityAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                takenIPAddress));

            if (result == null)
            {
                return ipAddresses;
            }

            ipAddresses.UnionWith(result.AvailableIPAddresses);
            return ipAddresses;
        }

        internal SubnetImpl WithDelegation(string serviceName)
        {
            if (Inner.Delegations == null)
            {
                Inner.Delegations = new List<DelegationInner>();
            }
            Inner.Delegations.Add(new DelegationInner()
            {
                Name = serviceName,
                ServiceName = serviceName
            });
            return this;
        }

        internal SubnetImpl WithoutDelegation(string serviceName)
        {
            if (Inner.Delegations != null)
            {
                Inner.Delegations = Inner.Delegations.Where(d => !d.ServiceName.Equals(serviceName)).ToList();
            }
            if (Inner.Delegations.Count == 0)
            {
                Inner.Delegations = null;
            }
            return this;
        }

        internal SubnetImpl WithoutDelegations()
        {
            Inner.Delegations = null;
            return this;
        }
    }
}
