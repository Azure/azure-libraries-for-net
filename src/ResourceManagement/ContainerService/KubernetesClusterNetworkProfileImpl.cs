// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The implementation for KubernetesClusterAgentPool and its create and update interfaces.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnNlcnZpY2UuaW1wbGVtZW50YXRpb24uS3ViZXJuZXRlc0NsdXN0ZXJOZXR3b3JrUHJvZmlsZUltcGw=
    internal partial class KubernetesClusterNetworkProfileImpl  :
        INetworkProfileDefinition<KubernetesCluster.Definition.IWithCreate>
    {
         KubernetesClusterImpl parentKubernetesCluster;

        ///GENMHASH:5511165182CA00FBE2E76008D1622ABF:01C999F4BE0FA873A5F345BAAFF81CB4
        internal  KubernetesClusterNetworkProfileImpl(KubernetesClusterImpl parent)
        {
            this.parentKubernetesCluster = parent;
        }

        ///GENMHASH:DDF0DF4B34FCADDFD2A69547543540FA:CB8233AF82365A3DDA9C940DDDF942BA
        private ContainerServiceNetworkProfile EnsureNetworkProfile()
        {
            if (this.parentKubernetesCluster.Inner.NetworkProfile == null)
            {
                this.parentKubernetesCluster.Inner.NetworkProfile = new ContainerServiceNetworkProfile();
            }
            return this.parentKubernetesCluster.Inner.NetworkProfile;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:5FA22507C001875E3BB054AF1B511F39
        public KubernetesClusterImpl Attach()
        {
            return parentKubernetesCluster;
        }

        ///GENMHASH:B28D5ED8BE23055CAB58C3C5804D2EBA:8CE914927C132930EF88F7F1AF1EF126
        public KubernetesClusterNetworkProfileImpl WithDnsServiceIP(string dnsServiceIP)
        {
            this.EnsureNetworkProfile().DnsServiceIP = dnsServiceIP;
            return this;
        }

        ///GENMHASH:ED71312CDF28F301B6220C12D4A683DF:1E437929437CD12E22270132873ACA5B
        public KubernetesClusterNetworkProfileImpl WithDockerBridgeCidr(string dockerBridgeCidr)
        {
            this.EnsureNetworkProfile().DockerBridgeCidr = dockerBridgeCidr;
            return this;
        }

        ///GENMHASH:C0DA13E58FA4E2F8A3C3295799D02961:FC96BA989471A87E3EF4B25DD25DA242
        public KubernetesClusterNetworkProfileImpl WithNetworkPlugin(NetworkPlugin networkPlugin)
        {
            this.EnsureNetworkProfile().NetworkPlugin = networkPlugin;
            return this;
        }

        ///GENMHASH:81FCB1F625D160C21630C458F9A6CA2B:A60126C45B1D069840148CF0F6141110
        public KubernetesClusterNetworkProfileImpl WithNetworkPolicy(NetworkPolicy networkPolicy)
        {
            this.EnsureNetworkProfile().NetworkPolicy = networkPolicy;
            return this;
        }

        ///GENMHASH:DA9B99175A84B055477699448E9E9320:E6FBDF6BB1A80A91B178ACCE3B5B0393
        public KubernetesClusterNetworkProfileImpl WithPodCidr(string podCidr)
        {
            this.EnsureNetworkProfile().PodCidr = podCidr;
            return this;
        }

        ///GENMHASH:20E93504EDB2C078583D09A245CD914D:56C87C5A8598C8AA0A4201FD16785DDD
        public KubernetesClusterNetworkProfileImpl WithServiceCidr(string serviceCidr)
        {
            this.EnsureNetworkProfile().ServiceCidr = serviceCidr;
            return this;
        }
    }
}