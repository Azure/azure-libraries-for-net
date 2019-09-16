// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The implementation for ContainerServiceAgentPool and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnNlcnZpY2UuaW1wbGVtZW50YXRpb24uQ29udGFpbmVyU2VydmljZUFnZW50UG9vbEltcGw=
    internal partial class ContainerServiceAgentPoolImpl  :
        ChildResource<
            Models.ContainerServiceAgentPoolProfile,
            Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceImpl,
            Microsoft.Azure.Management.ContainerService.Fluent.IOrchestratorServiceBase>,
            IContainerServiceAgentPool,
            ContainerServiceAgentPool.Definition.IDefinition<ContainerService.Definition.IWithCreate>
    {
        private string subnetName;

        ///GENMHASH:7A49B979D1157C2A0B68E0EFC009B2BE:75C8B95CEE5BD5CC0585593F400260CA
        internal ContainerServiceAgentPoolImpl(ContainerServiceAgentPoolProfile inner, ContainerServiceImpl parent) : base(inner, parent)
        {
            var subnetId = (inner != null) ? this.Inner.VnetSubnetID : null;
            this.subnetName = ResourceUtils.NameFromResourceId(subnetId);
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:11AAAD09C9684B6889E64AC8F924E50D:D461B25035B458150766C6D27E33A746
        public ContainerServiceVMSizeTypes VMSize()
        {
            return this.Inner.VmSize;
        }

        ///GENMHASH:577F8437932AEC6E08E1A137969BDB4A:A1945CF277DF5AE74D653481F44D96CE
        public string Fqdn()
        {
            return this.Inner.Fqdn;
        }

        ///GENMHASH:B84BFB9102C12A7625CB9CF2E3B5E7CF:BDFE6561FEC5EBDFF96600CDB5E62997
        public int Count()
        {
            if (this.Inner.Count == null || !this.Inner.Count.HasValue)
            {
                return 0;
            }

            return this.Inner.Count.Value;
        }

        ///GENMHASH:1A47F5D7ADFC88A0C42A9748D238C24D:A2B122981A8361B1703B4FC642EA8A74
        public int[] Ports()
        {
            if (this.Inner.Ports == null || this.Inner.Ports.Count == 0)
            {
                return new int[0];
            }
            int[] ports = new int[this.Inner.Ports.Count];
            for (int i = 0; i < this.Inner.Ports.Count; i++)
            {
                ports[i] = this.Inner.Ports[i].Value;
            }
            return ports;
        }

        ///GENMHASH:84A1C38F299C7713046CF6F1527D8F63:475A4C956E8066CDFDFB6FD41618AFA1
        public int OSDiskSizeInGB()
        {
            if (this.Inner.OsDiskSizeGB == null || !this.Inner.OsDiskSizeGB.HasValue)
            {
                return 0;
            }

            return this.Inner.OsDiskSizeGB.Value;
        }

        ///GENMHASH:C57133CD301470A479B3BA07CD283E86:0C9FA269AD671A2004FE56897AF90C53
        public string SubnetName()
        {
            if (subnetName != null)
            {
                return this.subnetName;
            }
            else
            {
                return ResourceUtils.NameFromResourceId(this.Inner.VnetSubnetID);
            }
        }

        ///GENMHASH:7F0A9CB4CB6BBC98F72CF50A81EBFBF4:BBFAD2E04A2C1C43EB33356B7F7A2AD6
        public ContainerServiceStorageProfileTypes StorageProfile()
        {
            return this.Inner.StorageProfile;
        }

        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:F71645491B82E137E4D1786750E7ADF0
        public OSType OSType()
        {
            return this.Inner.OsType;
        }

        ///GENMHASH:59348A25FD515049ECD26A6290F76B85:99DA2F06545702040B219110889AFC52
        public string DnsPrefix()
        {
            return this.Inner.DnsPrefix;
        }

        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:CC1F09230C48EC2C015059C28C3F6ABE
        public string NetworkId()
        {
            var subnetId = (this.Inner != null) ? this.Inner.VnetSubnetID : null;
            return (subnetId != null) ? ResourceUtils.ParentResourcePathFromResourceId(subnetId) : null;
        }

        ///GENMHASH:7A0B27D94CA2F0AFB4A9652950F57AFE:D8D5BBB00D0738A330A6BC7C9FFCA676
        public ContainerServiceAgentPoolImpl WithOSDiskSizeInGB(int osDiskSizeInGB)
        {
            this.Inner.OsDiskSizeGB = osDiskSizeInGB;

            return this;
        }

        ///GENMHASH:8642FC9B9C8DC7375DEE3CC5736F8853:29D1CB622B31FAC97C901D90A28F979B
        public ContainerServiceAgentPoolImpl WithDnsPrefix(string param0)
        {
            this.Inner.DnsPrefix = param0;

            return this;
        }

        ///GENMHASH:BCF83D3C194B218EC19BFDDC8A30CBA4:5F7FD5FB381AEECF58C733CCD9F702A3
        public ContainerServiceAgentPoolImpl WithVirtualMachineCount(int agentPoolCount)
        {
            this.Inner.Count = agentPoolCount;

            return this;
        }

        ///GENMHASH:A7BB228682D91D0BE3771990EB9A8B24:A767CA83A1AD0D08917EABEC893AD28A
        public ContainerServiceAgentPoolImpl WithStorageProfile(ContainerServiceStorageProfileTypes storageProfile)
        {
            this.Inner.StorageProfile = storageProfile;

            return this;
        }

        ///GENMHASH:29F824FFD1866F35F3898F9D3ECE5F1B:E7F1DA78794C44C2AC55569F4DDCBD11
        public ContainerServiceAgentPoolImpl WithOSType(OSType osType)
        {
            this.Inner.OsType = osType;

            return this;
        }

        ///GENMHASH:9E41BF1F12D044B7D521513935721D02:6283ADA42B1865CAD8C5611E6A5B20DA
        public ContainerServiceAgentPoolImpl WithSubnetName(string subnetName)
        {
            this.subnetName = subnetName;
            this.Inner.VnetSubnetID = subnetName;

            return this;
        }

        ///GENMHASH:C622FBAAB8FD0DD09A538E695C688BFC:BD0EF4C17E803CA04B5D85ACE1E77A7D
        public ContainerServiceAgentPoolImpl WithVirtualMachineSize(ContainerServiceVMSizeTypes param0)
        {
            this.Inner.VmSize = param0;

            return this;
        }

        ///GENMHASH:E0EEECAB197A3EB83AD2077639A650AA:4867F3D28F7890EDA6176D830C82F2E7
        public ContainerServiceAgentPoolImpl WithPorts(params int[] ports)
        {
            if (ports != null && ports.Length > 0)
            {
                this.Inner.Ports = new List<int?>();
                foreach (var port in ports)
                {
                    this.Inner.Ports.Add(port);
                }
            }

            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:2C4DA36CDD9D10E16B3D1C614CBCE9BE
        public ContainerService.Definition.IDefinition Attach()
        {
            this.Parent.Inner.AgentPoolProfiles.Add(this.Inner);

            return this.Parent;
        }

        ///GENMHASH:AC3242CC7AFA5FD11163B235DA2E6D85:F993D1DA892FDAE482F0E46B146ED99F
        public ContainerServiceAgentPoolImpl WithVirtualNetwork(string virtualNetworkId, string subnetName)
        {
            string vnetSubnetId = virtualNetworkId + "/subnets/" + subnetName;
            this.subnetName = subnetName;
            this.Inner.VnetSubnetID = vnetSubnetId;
            return this;
        }
    }
}