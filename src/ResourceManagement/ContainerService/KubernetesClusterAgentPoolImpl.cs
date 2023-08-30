// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterAgentPool.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using System;

    /// <summary>
    /// The implementation for KubernetesClusterAgentPool and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnNlcnZpY2UuaW1wbGVtZW50YXRpb24uS3ViZXJuZXRlc0NsdXN0ZXJBZ2VudFBvb2xJbXBs
    internal partial class KubernetesClusterAgentPoolImpl :
        ChildResource<
            Models.ManagedClusterAgentPoolProfile,
            Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterImpl,
            Microsoft.Azure.Management.ContainerService.Fluent.IOrchestratorServiceBase>,
        IKubernetesClusterAgentPool,
        KubernetesClusterAgentPool.Definition.IDefinition<KubernetesCluster.Definition.IWithCreate>
    {
        string subnetName;

        ///GENMHASH:98DFA3F9E5796918208C02E358977FEC:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal KubernetesClusterAgentPoolImpl(ManagedClusterAgentPoolProfile inner, KubernetesClusterImpl parent) : base(inner, parent)
        {
            string subnetId = inner?.VnetSubnetID;
            subnetName = (subnetId != null) ? ResourceUtils.NameFromResourceId(subnetId) : null;
        }

        ///GENMHASH:11AAAD09C9684B6889E64AC8F924E50D:D461B25035B458150766C6D27E33A746
        public ContainerServiceVMSizeTypes VMSize()
        {
            return this.Inner.VmSize;
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

        ///GENMHASH:B84BFB9102C12A7625CB9CF2E3B5E7CF:BDFE6561FEC5EBDFF96600CDB5E62997
        public int Count()
        {
            if (this.Inner.Count <= 0)
            {
                return 0;
            }

            return this.Inner.Count ?? 0;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return this.Inner.Name;
        }

        public AgentPoolType Type()
        {
            return this.Inner.Type;
        }

        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:CC1F09230C48EC2C015059C28C3F6ABE
        public string NetworkId()
        {
            string subnetId = this.Inner?.VnetSubnetID;
            return (subnetId != null) ? ResourceUtils.ParentResourcePathFromResourceId(subnetId) : null;
        }

        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:F71645491B82E137E4D1786750E7ADF0
        public OSType OSType()
        {
            return this.Inner.OsType;
        }


        ///GENMHASH:29F824FFD1866F35F3898F9D3ECE5F1B:E7F1DA78794C44C2AC55569F4DDCBD11
        public KubernetesClusterAgentPoolImpl WithOSType(OSType osType)
        {
            this.Inner.OsType = osType;

            return this;
        }

        ///GENMHASH:73E98D352C374833FF41103FC46D3A0F:D8A954022322D0DB34AE14ECDCEC78B7
        public KubernetesClusterAgentPoolImpl WithAgentPoolVirtualMachineCount(int count)
        {
            this.Inner.Count = count;
            return this;
        }

        ///GENMHASH:B9F2B445162CECADE05A873AE85E93A6:EC0D9D64D8F64291B672502919E853BB
        public KubernetesClusterAgentPoolImpl WithMaxPodsCount(int podsCount)
        {
            this.Inner.MaxPods = podsCount;
            return this;
        }

        ///GENMHASH:7A0B27D94CA2F0AFB4A9652950F57AFE:D8D5BBB00D0738A330A6BC7C9FFCA676
        public KubernetesClusterAgentPoolImpl WithOSDiskSizeInGB(int osDiskSizeInGB)
        {
            this.Inner.OsDiskSizeGB = osDiskSizeInGB;

            return this;
        }

        ///GENMHASH:C622FBAAB8FD0DD09A538E695C688BFC:70CBAB5746AAB14DF4C92F27CD513EE6
        public KubernetesClusterAgentPoolImpl WithVirtualMachineSize(ContainerServiceVMSizeTypes param0)
        {
            this.Inner.VmSize = param0;

            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:2C4DA36CDD9D10E16B3D1C614CBCE9BE
        public KubernetesCluster.Definition.IDefinition Attach()
        {
            this.Parent.Inner.AgentPoolProfiles.Add(this.Inner);

            return this.Parent;
        }

        ///GENMHASH:C57133CD301470A479B3BA07CD283E86:0C9FA269AD671A2004FE56897AF90C53
        public string SubnetName()
        {
            if (this.subnetName != null)
            {
                return this.subnetName;
            }
            else
            {
                return ResourceUtils.NameFromResourceId(this.Inner.VnetSubnetID);
            }
        }

        ///GENMHASH:AC3242CC7AFA5FD11163B235DA2E6D85:F993D1DA892FDAE482F0E46B146ED99F
        public KubernetesClusterAgentPoolImpl WithVirtualNetwork(string virtualNetworkId, string subnetName)
        {
            string vnetSubnetId = virtualNetworkId + "/subnets/" + subnetName;
            this.subnetName = subnetName;
            this.Inner.VnetSubnetID = vnetSubnetId;
            return this;
        }

        public KubernetesClusterAgentPoolImpl WithAgentPoolType(AgentPoolType agentPoolType)
        {
            this.Inner.Type = agentPoolType;
            return this;
        }

        public KubernetesClusterAgentPoolImpl WithAgentPoolTypeName(string agentPoolTypeName)
        {
            this.Inner.Type = AgentPoolType.Parse(agentPoolTypeName);
            return this;
        }

        public KubernetesClusterAgentPoolImpl WithAgentPoolMode(AgentPoolMode agentPoolMode)
        {
            this.Inner.Mode = agentPoolMode;
            return this;
        }

        public KubernetesClusterAgentPoolImpl WithAgentPoolModeName(string agentPoolModeName)
        {
            this.Inner.Mode = AgentPoolMode.Parse(agentPoolModeName);
            return this;
        }
    }
}