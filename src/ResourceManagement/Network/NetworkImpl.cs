// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using System.Collections.Generic;
    using ResourceManager.Fluent.Core;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Linq;
    using System;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Implementation for Network
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya0ltcGw=
    internal partial class NetworkImpl :
        GroupableParentResourceWithTags<INetwork,
            VirtualNetworkInner,
            NetworkImpl,
            INetworkManager,
            Network.Definition.IWithGroup,
            Network.Definition.IWithCreate,
            Network.Definition.IWithCreate,
            Network.Update.IUpdate>,
        INetwork,
        Network.Definition.IDefinition,
        Network.Update.IUpdate
    {
        private ICreatable<Microsoft.Azure.Management.Network.Fluent.IDdosProtectionPlan> ddosProtectionPlanCreatable;
        private Dictionary<string, ISubnet> subnets;
        private NetworkPeeringsImpl peerings;

        ///GENMHASH:7BEA0E65533989105BEBCE9663A14E3A:3881994DCADCE14215F82F0CC81BDD88
        internal NetworkImpl(string name, VirtualNetworkInner innerModel, INetworkManager networkManager)
            : base(name, innerModel, networkManager)
        {
        }


        ///GENMHASH:6D9F740D6D73C56877B02D9F1C96F6E7:DDD01175DC699E92E7CD9E1C4C74A5A4
        override protected void InitializeChildrenFromInner()
        {
            subnets = new Dictionary<string, ISubnet>();
            IList<SubnetInner> inners = Inner.Subnets;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    SubnetImpl subnet = new SubnetImpl(inner, this);
                    subnets[inner.Name] = subnet;
                }
            }
            peerings = new NetworkPeeringsImpl(this);
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:D273A9F25EE8363ADDB7479305202A25
        protected override async Task<VirtualNetworkInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.VirtualNetworks.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:F792498DBF3C736E27E066C92C2E7F7A:129071765816A335066AAC27F7CCCEAD
        internal NetworkImpl WithSubnet(SubnetImpl subnet)
        {
            if (subnet != null)
            {
                subnets[subnet.Name()] = subnet;
            }
            return this;
        }


        ///GENMHASH:C46E686F6BFED9BDC32DE6EB942E24F4:5C325A68AD1779341F5DE4F1F9B669CB
        internal NetworkImpl WithDnsServer(string ipAddress)
        {
            if (Inner.DhcpOptions == null)
                Inner.DhcpOptions = new DhcpOptions();

            if (Inner.DhcpOptions.DnsServers == null)
                Inner.DhcpOptions.DnsServers = new List<string>();

            Inner.DhcpOptions.DnsServers.Add(ipAddress);
            return this;
        }


        ///GENMHASH:9047F7688B1B60794F60BC930616198C:5A25E7A3D3CA299925A5FF1DA732AFE4
        internal NetworkImpl WithSubnet(string name, string cidr)
        {
            return DefineSubnet(name)
                .WithAddressPrefix(cidr)
                .Attach();
        }

        ///GENMHASH:F6CBC7DFB0D824D353A7DFE6057B8612:8CF7AA492E5A9A8A95128893182A62A1
        internal NetworkImpl WithSubnets(IDictionary<string, string> nameCidrPairs)
        {
            subnets.Clear();
            foreach (var pair in nameCidrPairs)
            {
                WithSubnet(pair.Key, pair.Value);
            }
            return this;
        }

        ///GENMHASH:BCFE5A6437DFDD16AB17155407828358:D7A6E191BE445D616C7D7458438BA4AC
        internal NetworkImpl WithoutSubnet(string name)
        {
            subnets.Remove(name);
            return this;
        }

        ///GENMHASH:BF356D3C256200922092FDECCE2AEA83:2164178F2F2E4C2173DC1A4CB8E69169
        internal NetworkImpl WithAddressSpace(string cidr)
        {
            if (Inner.AddressSpace == null)
                Inner.AddressSpace = new AddressSpace();

            if (Inner.AddressSpace.AddressPrefixes == null)
                Inner.AddressSpace.AddressPrefixes = new List<string>();

            Inner.AddressSpace.AddressPrefixes.Add(cidr);
            return this;
        }

        ///GENMHASH:0A2FDD020AE5A41E49EC1B3AEB02B394:3B60772E45391CEB653A6108BC6868A5
        internal SubnetImpl DefineSubnet(string name)
        {
            SubnetInner inner = new SubnetInner(name: name);
            return new SubnetImpl(inner, this);
        }


        ///GENMHASH:0A630A9A81A6D7FB1D87E339FE830A51:FD878AA481D05018C98B67E014CFC475
        internal IReadOnlyList<string> AddressSpaces()
        {
            if (Inner.AddressSpace == null)
                return new List<string>();
            else if (Inner.AddressSpace.AddressPrefixes == null)
                return new List<string>();
            else
                return Inner.AddressSpace.AddressPrefixes?.ToList();
        }

        ///GENMHASH:286FDAB5963B6F7C00ABEDCF6FE545B5:6FEBAF2F043487BFE65A5D9D04AA1315
        internal IReadOnlyList<string> DnsServerIPs()
        {
            if (Inner.DhcpOptions == null)
                return new List<string>();
            else if (Inner.DhcpOptions.DnsServers == null)
                return new List<string>();
            else
                return Inner.DhcpOptions.DnsServers?.ToList();
        }

        ///GENMHASH:690E8F594CD13FA2074316AFD9B45928:8131F4AA7A989D064C8AB8B74BFCAD25
        internal IReadOnlyDictionary<string, ISubnet> Subnets()
        {
            return subnets;
        }

        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:E0C348C98FD0505C2908FDDC5F7096A1
        override protected void BeforeCreating()
        {
            // Ensure address spaces
            if (AddressSpaces().Count == 0)
            {
                WithAddressSpace("10.0.0.0/16"); // Default address space
            }

            if (IsInCreateMode)
            {
                // Create a subnet as needed, covering the entire first address space
                if (subnets.Count == 0)
                {
                    WithSubnet("subnet1", AddressSpaces()[0]);
                }
            }

            // Reset and update subnets
            Inner.Subnets = InnersFromWrappers<SubnetInner, ISubnet>(subnets.Values);
        }

        ///GENMHASH:F91F57741BB7E185BF012523964DEED0:B855D73B977281A4DC1F154F5A7D4DC5
        protected override void AfterCreating()
        {
            InitializeChildrenFromInner();
        }

        ///GENMHASH:073D775B4A47FA2FF6211510FDF879F4:D226D5E398319C2E7C55CCC94D6E4793
        internal SubnetImpl UpdateSubnet(string name)
        {
            ISubnet subnet;
            subnets.TryGetValue(name, out subnet);
            return (SubnetImpl)subnet;
        }

        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:A394B5B2A4C946983BF7F8DE2DAA697E
        protected async override Task<VirtualNetworkInner> CreateInnerAsync(CancellationToken cancellationToken)
        {
            if (ddosProtectionPlanCreatable != null)
            {
                var ddosProtectionPlan = this.CreatedResource(ddosProtectionPlanCreatable.Key);
                WithExistingDdosProtectionPlan(ddosProtectionPlan.Id);   
            }
            ddosProtectionPlanCreatable = null;
            return await this.Manager.Inner.VirtualNetworks.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner, cancellationToken);
        }

        ///GENMHASH:6A291EDC22581C4F2CC3D65986E9F5A3:B5C775B96E4C8B181BD73D9F917D80A6
        private IPAddressAvailabilityResultInner CheckIPAvailability(string ipAddress)
        {
            if (ipAddress == null)
            {
                return null;
            }
            IPAddressAvailabilityResultInner result = null;
            try
            {
                result = Extensions.Synchronize(() => Manager.Networks.Inner.CheckIPAddressAvailabilityAsync(
                    ResourceGroupName,
                    Name,
                    ipAddress));
            }
            catch (CloudException e)
            {
                if (!e.Body.Code.Equals("PrivateIPAddressNotInAnySubnet", StringComparison.OrdinalIgnoreCase))
                {
                    throw e; // Rethrow if the exception reason is anything other than IP address not found
                }
            }

            return result;
        }

        ///GENMHASH:B7779950F6715602F8E2A9BD80364364:10D7E4D988246C2703C9CB4955EDDB07
        public string DdosProtectionPlanId()
        {
            return Inner.DdosProtectionPlan == null ? null : Inner.DdosProtectionPlan.Id;
        }

       ///GENMHASH:6AC74D6FDBE69EBF2E6C71EBFAA28ABC:315575632095FCDF2361295DB923A6A6
        public bool IsDdosProtectionEnabled()
        {
            return Inner.EnableDdosProtection.GetValueOrDefault();
        }
        ///GENMHASH:8C8A52E21D5AB87F54C56A8705429BCB:4454DD801F596261F97DAB3093878A56
        public bool IsVmProtectionEnabled()
        {
            return Inner.EnableVmProtection.GetValueOrDefault();
        }
        ///GENMHASH:DAC0ADBD485D3FA7934FDCF3DF6AFB33:7A77202DEFA9CB2CDFBB1A2FD00F7FFA
        public INetworkPeerings Peerings()
        {
            return peerings;
        }

        ///GENMHASH:3C42C3EE58ED8EB273637D89B5D06905:46B0FEC0CFADACBCE7C272DDBAE1CF1D
        public bool IsPrivateIPAddressInNetwork(string ipAddress)
        {
            IPAddressAvailabilityResultInner result = CheckIPAvailability(ipAddress);
            return (result != null) ? true : false;
        }
        ///GENMHASH:975EDC5E759341EA29306B7C9EABDB32:881709B76B00095442458D0AB341E78F
        public NetworkImpl WithExistingDdosProtectionPlan(string planId)
        {
            Inner.EnableDdosProtection = true;
            Inner.DdosProtectionPlan = new SubResource(planId);
            return this;
        }

        ///GENMHASH:B93BCE53CDE70A01B7CFE70DD6DAF4DA:860FFB37184E1F1CDD3880F84DBB0BD3
        public NetworkImpl WithNewDdosProtectionPlan()
        {
            Inner.EnableDdosProtection = true;
            var ddosProtectionPlanWithGroup = Manager.DdosProtectionPlans
                .Define(SdkContext.RandomResourceName(Name, 20))
                .WithRegion(Region);
            var ddosProtectionPlanCreatable = this.newGroup != null
                ? ddosProtectionPlanWithGroup.WithNewResourceGroup(this.newGroup)
                : ddosProtectionPlanWithGroup.WithExistingResourceGroup(this.ResourceGroupName);
            AddCreatableDependency(ddosProtectionPlanCreatable as IResourceCreator<IHasId>);
            return this;
        }

        ///GENMHASH:2DDC261430ADA2CF9ED379E7C096EA18:B86A968ED1807214F1A8C9FB5538CA47
        public NetworkImpl WithoutAddressSpace(string cidr)
        {
            if (cidr == null)
            {
                // Skip
            }
            else if (Inner.AddressSpace == null)
            {
                // Skip
            }
            else if (Inner.AddressSpace.AddressPrefixes == null)
            {
                // Skip
            }
            else
            {
                Inner.AddressSpace.AddressPrefixes.Remove(cidr);
            }
            return this;
        }
        ///GENMHASH:09F7B9785A174DDAD832D685CC62A692:FB965F085372AEB63F5C3458757B644F
        public NetworkImpl WithoutDdosProtectionPlan()
        {
            Inner.EnableDdosProtection = false;
            Inner.DdosProtectionPlan = null;
            return this;
        }
        ///GENMHASH:BE68A28EB6432591B6E97F14DA41AB51:7FEA84D711B94AA3A0E20A20D2DCFF94
        public NetworkImpl WithoutVmProtection()
        {
            Inner.EnableVmProtection = false;
            return this;
        }
        public NetworkImpl WithVmProtection()
        {
            Inner.EnableVmProtection = true;
            return this;
        }
        ///GENMHASH:6ACD1798F2E9D87878DA2A89A9C924EC:C881614C8CEC0248E97A20723E81741D
        public bool IsPrivateIPAddressAvailable(string ipAddress)
        {
            IPAddressAvailabilityResultInner result = CheckIPAvailability(ipAddress);
            if (result == null)
            {
                return false;
            }
            else if (result.Available == null)
            {
                return false;
            }
            else
            {
                return result.Available.Value;
            }
        }

        protected override async Task<VirtualNetworkInner> ApplyTagsToInnerAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await this.Manager.Inner.VirtualNetworks.UpdateTagsAsync(ResourceGroupName, Name, Inner.Tags, cancellationToken);
        }
    }
}
