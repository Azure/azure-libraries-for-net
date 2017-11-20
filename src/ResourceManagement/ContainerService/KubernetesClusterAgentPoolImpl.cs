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
            Models.ContainerServiceAgentPoolProfile,
            Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterImpl,
            Microsoft.Azure.Management.ContainerService.Fluent.IOrchestratorServiceBase>,
        IKubernetesClusterAgentPool,
        KubernetesClusterAgentPool.Definition.IDefinition<KubernetesCluster.Definition.IWithCreate>
    {

        ///GENMHASH:98DFA3F9E5796918208C02E358977FEC:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal KubernetesClusterAgentPoolImpl(ContainerServiceAgentPoolProfile inner, KubernetesClusterImpl parent) : base(inner, parent)
        {
        }

        ///GENMHASH:11AAAD09C9684B6889E64AC8F924E50D:D461B25035B458150766C6D27E33A746
        public ContainerServiceVirtualMachineSizeTypes VMSize()
        {
            return ContainerServiceVirtualMachineSizeTypes.Parse(this.Inner.VmSize);
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

        ///GENMHASH:7F0A9CB4CB6BBC98F72CF50A81EBFBF4:BBFAD2E04A2C1C43EB33356B7F7A2AD6
        public StorageProfileTypes StorageProfile()
        {
            return StorageProfileTypes.Parse(this.Inner.StorageProfile);
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return this.Inner.Name;
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

        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:F71645491B82E137E4D1786750E7ADF0
        public ContainerServiceOSTypes OSType()
        {
            return ContainerServiceOSTypes.Parse(this.Inner.OsType);
        }


        ///GENMHASH:29F824FFD1866F35F3898F9D3ECE5F1B:E7F1DA78794C44C2AC55569F4DDCBD11
        public KubernetesClusterAgentPoolImpl WithOSType(ContainerServiceOSTypes osType)
        {
            this.Inner.OsType = osType.Value;

            return this;
        }

        ///GENMHASH:7A0B27D94CA2F0AFB4A9652950F57AFE:D8D5BBB00D0738A330A6BC7C9FFCA676
        public KubernetesClusterAgentPoolImpl WithOSDiskSizeInGB(int osDiskSizeInGB)
        {
            this.Inner.OsDiskSizeGB = osDiskSizeInGB;

            return this;
        }

        ///GENMHASH:BCF83D3C194B218EC19BFDDC8A30CBA4:5F7FD5FB381AEECF58C733CCD9F702A3
        public KubernetesClusterAgentPoolImpl WithVirtualMachineCount(int agentPoolCount)
        {
            this.Inner.Count = agentPoolCount;

            return this;
        }

        ///GENMHASH:C622FBAAB8FD0DD09A538E695C688BFC:70CBAB5746AAB14DF4C92F27CD513EE6
        public KubernetesClusterAgentPoolImpl WithVirtualMachineSize(ContainerServiceVirtualMachineSizeTypes param0)
        {
            this.Inner.VmSize = param0.Value;

            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:2C4DA36CDD9D10E16B3D1C614CBCE9BE
        public KubernetesCluster.Definition.IDefinition Attach()
        {
            this.Parent.Inner.AgentPoolProfiles.Add(this.Inner);

            return this.Parent;
        }

    }
}