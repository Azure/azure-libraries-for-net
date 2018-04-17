// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using NetworkWatcher.Definition;
    using NetworkWatcher.Update;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for Network Watcher and its create and update interfaces.
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya1dhdGNoZXJJbXBs
    internal partial class NetworkWatcherImpl :
        GroupableResource<INetworkWatcher,
            NetworkWatcherInner,
            NetworkWatcherImpl,
            INetworkManager,
            IWithGroup,
            IWithCreate,
            IWithCreate,
            IUpdate>,
        INetworkWatcher,
        NetworkWatcher.Definition.IDefinition,
        IUpdate
    {
        private PacketCapturesImpl packetCaptures;


        ///GENMHASH:C23435CBB02FDD2925C2595F4B8144FF:7D0B9662AF579C16E98FA90A469D83C1
        internal NetworkWatcherImpl(string name, NetworkWatcherInner innerModel, INetworkManager networkManager)
            : base(name, innerModel, networkManager)
        {
            packetCaptures = new PacketCapturesImpl(networkManager.Inner.PacketCaptures, this);
        }


        ///GENMHASH:D44E087EDB7D7768653BF41409E6F465:6D92C6C15D79FD13F06FBA7B0F889152
        public NextHopImpl NextHop()
        {
            return new NextHopImpl(this);
        }


        ///GENMHASH:8C3F7A74AC5004631D21F8903860DC6B:E33BD6B245B7E9C2814D6C577505B7F9
        public PacketCapturesImpl PacketCaptures()
        {
            return packetCaptures;
        }

        ///GENMHASH:6ADE0CC8B76996D06BE85035269E8EC9:8852F6E8948BB93D289E3C993AA4F3B7
        public ConnectivityCheckImpl CheckConnectivity()
        {
            return new ConnectivityCheckImpl(this);
        }

        ///GENMHASH:F57C7696A3ED75E619C8E1A9DFE5EA61:9938198EE6EDB0DC20C3A7100AD87595
        public IFlowLogSettings GetFlowLogSettings(string nsgId)
        {
            FlowLogInformationInner flowLogInformationInner = Extensions.Synchronize(() => this.Manager.Inner.NetworkWatchers
                .GetFlowLogStatusAsync(this.ResourceGroupName, this.Name, nsgId));
            return new FlowLogSettingsImpl(this, flowLogInformationInner, nsgId);
        }


        ///GENMHASH:F53B77B44D807B414A2C263BFEF2EC24:D02D2D01B74AD726DBDB2CD0A0B044FA
        public VerificationIPFlowImpl VerifyIPFlow()
        {
            return new VerificationIPFlowImpl(this);
        }

        ///GENMHASH:51DE54583E09DB26EDE4D4AFC37B768E:9FEF863720522C36E187D60DBDE933AE
        public TroubleshootingImpl Troubleshoot()
        {
            return new TroubleshootingImpl(this);
        }

        ///GENMHASH:45B21E1285D8F8B4EDB1C12C6E80097B:EB7D34365F1B3B24BC2A133D30D583EF
        public async Task<Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings> GetFlowLogSettingsAsync(
            string nsgId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await this.Manager.Inner.NetworkWatchers
                .GetFlowLogStatusAsync(this.ResourceGroupName, this.Name, nsgId);
            return new FlowLogSettingsImpl(this, response, nsgId);
        }


        ///GENMHASH:C71E107FA8B2DA3EDF8CE88700E11F09:960DE2BF69BF56B713EE1D6546783210
        public ISecurityGroupView GetSecurityGroupView(string vmId)
        {
            SecurityGroupViewResultInner securityGroupViewResultInner = Extensions.Synchronize(() => this.Manager.Inner.NetworkWatchers
                .GetVMSecurityRulesAsync(this.ResourceGroupName, this.Name, vmId));
            return new SecurityGroupViewImpl(this, securityGroupViewResultInner, vmId);
        }


        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:87D235BBEAAE6A036EDEF87C44B81A1F
        protected async override Task<Models.NetworkWatcherInner> GetInnerAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.NetworkWatchers.GetAsync(this.ResourceGroupName, this.Name);
        }


        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:D224F7274AEC02F8ED1C6B93F4C64F4E
        public async override Task<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher> CreateResourceAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await this.Manager.Inner.NetworkWatchers.CreateOrUpdateAsync(
                this.ResourceGroupName, this.Name, this.Inner);
            SetInner(response);
            return this;
        }

        ///GENMHASH:E4A3944A84B2B14B8970F2EDB1A93DFF:A4A98DC2FF2FF460C68A01A5E459AB5F
        public TopologyImpl Topology()
        {
            return new TopologyImpl(this);
        }

        ///GENMHASH:39EDCBB843031828E5101FAF38C0D8AF:6961C7D54DE752340917E5F05FB8EAE2
        public async Task<Microsoft.Azure.Management.Network.Fluent.ISecurityGroupView> GetSecurityGroupViewAsync(
            string vmId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await this.Manager.Inner.NetworkWatchers
                .GetVMSecurityRulesAsync(this.ResourceGroupName, this.Name, vmId);
            return new SecurityGroupViewImpl(this, response, vmId);
        }
    }
}
