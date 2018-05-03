// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.ObjectModel;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for Connection Monitor and its create and update interfaces.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQ29ubmVjdGlvbk1vbml0b3JJbXBs
    internal partial class ConnectionMonitorImpl  :
        Creatable<IConnectionMonitor, ConnectionMonitorResultInner, ConnectionMonitorImpl, IConnectionMonitor>,
        IConnectionMonitor,
        IDefinition
    {
        private IConnectionMonitorsOperations client;
        private ConnectionMonitorInner createParameters;
        private INetworkWatcher parent;

        ///GENMHASH:5FF6F22B17DD7078FE6B3E25A08DAF00:C76EE92DA65DAA991DB405193AE42CE5
        internal  ConnectionMonitorImpl(string name, NetworkWatcherImpl parent, ConnectionMonitorResultInner innerObject, IConnectionMonitorsOperations client)
            : base(name, innerObject)
        {
            this.client = client;
            this.parent = parent;
            this.createParameters = new ConnectionMonitorInner()
            {
                Location = parent.RegionName
            };
        }

        ///GENMHASH:B9D2BB4C39728B86BB5341EC27BEF5F2:334CE58D69655A76396F940D26F5397B
        private ConnectionMonitorDestination EnsureConnectionMonitorDestination()
        {
            if (createParameters.Destination == null) {
                createParameters.Destination = new ConnectionMonitorDestination();
            }
            return createParameters.Destination;
        }

        ///GENMHASH:488CBB31D59278A34B699ED73A10F5DB:9C13FADD3289F7BC4E46C0F6C78A51BF
        private ConnectionMonitorSource EnsureConnectionMonitorSource()
        {
            if (createParameters.Source == null) {
                createParameters.Source = new ConnectionMonitorSource();
            }
            return createParameters.Source;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:754810EA5144700BBB078C6E55E8C153
        protected override async Task<Models.ConnectionMonitorResultInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.client.GetAsync(parent.ResourceGroupName, parent.Name, Name, cancellationToken);
        }

        ///GENMHASH:C5D89656612B3B4FD5897FBFC88C3AFB:72EB2BF07E27ECC8589DC1335BAC8634
        public bool AutoStart()
        {
            return Inner.AutoStart.GetValueOrDefault();
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:228A9A3D68EE8BB5ABA520AE16356B8A
        public override async Task<Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetInner(await this.client.CreateOrUpdateAsync(parent.ResourceGroupName, parent.Name, this.Name,
                createParameters, cancellationToken));

            return this;
        }

        ///GENMHASH:D330F5721F151F2EF9CE3A499FEC146C:6241791A4C41364EBE5B29EF053BFE99
        public ConnectionMonitorDestination Destination()
        {
            return Inner.Destination;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:A3CF7B3DC953F353AAE8083D72F74056
        public string Id()
        {
            return Inner.Id;
        }

        ///GENMHASH:76EDE6DBF107009D2B06F19698F6D5DB:19C4BD8FCE58F39FC1CCEB1A6C862717
        public bool IsInCreateMode()
        {
            return this.Inner.Id == null;
        }

        ///GENMHASH:A85BBC58BA3B783F90EB92B75BD97D51:0D9EEC636DF1E11A81923129881E6F92
        public string Location()
        {
            return Inner.Location;
        }

        ///GENMHASH:EAFDB99A61316B0968D2B5817643E652:31A5B5F46E0134D8E34EBD8783C0CD33
        public int MonitoringIntervalInSeconds()
        {
            return Inner.MonitoringIntervalInSeconds.GetValueOrDefault();
        }

        ///GENMHASH:08BED39C9817265E9F51D92232F5E007:6998790F6649D3ED6685336731B5252B
        public string MonitoringStatus()
        {
            return Inner.MonitoringStatus;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:3DB04077E6BABC0FB5A5ACDA19D11309
        public ProvisioningState ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        ///GENMHASH:BF76A8643A23730A004C9A3DAA62583F:B0655019009F078380DC66C730FBA78F
        public IConnectionMonitorQueryResult Query()
        {
            return Extensions.Synchronize(() => QueryAsync());
        }

        ///GENMHASH:A409C3D3741509AF429A05127B5E4382:58F7FC16B9BBD602D0D4676357994540
        public  async Task<Microsoft.Azure.Management.Network.Fluent.IConnectionMonitorQueryResult> QueryAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return new ConnectionMonitorQueryResultImpl(await this.client.QueryAsync(parent.ResourceGroupName, parent.Name, Name, cancellationToken));
        }

        ///GENMHASH:32ABF27B7A32286845C5FAFE717F8E4D:E5A3D960F98D36AB45F0D6541D43C4D9
        public ConnectionMonitorSource Source()
        {
            return Inner.Source;
        }

        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:1A0917D3B99C0446F2507D37E60DF88A
        public void Start()
        {
            Extensions.Synchronize(() => StartAsync());

        }

        ///GENMHASH:D5AD274A3026D80CDF6A0DD97D9F20D4:C86F332142083D93E0A8AECBA0BFB621
        public async Task StartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await client.StartAsync(parent.ResourceGroupName, parent.Name, Name, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:8550B4F26F41D82222F735D9324AEB6D:29AAFE9F1BD0E0EEB26150A53E8B7A36
        public DateTime StartTime()
        {
            return Inner.StartTime.GetValueOrDefault();
        }

        ///GENMHASH:EB854F18026EDB6E01762FA4580BE789:42462B796F15B0EB6E603ACA753873C0
        public void Stop()
        {
            Extensions.Synchronize(() => StopAsync());

        }

        ///GENMHASH:D6FBED7FC7CBF34940541851FF5C3CC1:420B8DFD511324EA1988F38805A1D401
        public async Task StopAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await client.StopAsync(parent.ResourceGroupName, parent.Name, Name, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:15C9AB470710087E177FDDC5B9B7425E
        public IReadOnlyDictionary<string,string> Tags()
        {
            IDictionary<string, string> tags = Inner.Tags;
            if (tags == null)
            {
                tags = new Dictionary<string, string>();
            }
            return new ReadOnlyDictionary<string, string>(tags);
        }

        ///GENMHASH:388CBA9D80803D0B06C6BEF1D75F45BE:F0B76E5F29DC1C6CB2AB2A49CE5033A9
        public ConnectionMonitorImpl WithDestination(IHasNetworkInterfaces vm)
        {
            EnsureConnectionMonitorDestination().ResourceId = vm.Id;
            return this;
        }

        ///GENMHASH:8A174EF40FE176D85B52DCBE164A95D2:1F01EEB3C44ECBF508683E4031406628
        public IWithDestinationPort WithDestinationAddress(string address)
        {
            EnsureConnectionMonitorDestination().Address = address;
            return this;
        }

        ///GENMHASH:5BFD78BA0B8D6AD63806A2E1A394B896:0DC49C4F23113DFE2125346DC6F3618C
        public ConnectionMonitorImpl WithDestinationId(string resourceId)
        {
            EnsureConnectionMonitorDestination().ResourceId = resourceId;
            return this;
        }

        ///GENMHASH:5C1319A874A387C53AA45A67B22181DD:65CBFD400090B912B507538B6F3F10C0
        public ConnectionMonitorImpl WithDestinationPort(int port)
        {
            EnsureConnectionMonitorDestination().Port = port;
            return this;
        }

        ///GENMHASH:A4EC698B9E229B245DB08EABB50ED30F:5FD4951B514D8558230BD6974A41B56C
        public ConnectionMonitorImpl WithMonitoringInterval(int seconds)
        {
            createParameters.MonitoringIntervalInSeconds = seconds;
            return this;
        }

        ///GENMHASH:DA48CE39A0F1A776641DCC49EA175DB1:C2FFEC15CF486D6F001384A4795E4192
        public ConnectionMonitorImpl WithoutAutoStart()
        {
            createParameters.AutoStart = false;
            return this;
        }

        ///GENMHASH:2345D3E100BA4B78504A2CC57A361F1E:3F3F4D4DB4FC89533CF7F0CB3337D43E
        public ConnectionMonitorImpl WithoutTag(string key)
        {
            if (this.createParameters.Tags != null) {
                this.createParameters.Tags.Remove(key);
            }
            return this;
        }

        ///GENMHASH:0022FE3C90BA353F5DFB1A0CD71BAFEC:AD3EAB000A98E8F8E7437C14A2A03788
        public ConnectionMonitorImpl WithSource(IHasNetworkInterfaces vm)
        {
            EnsureConnectionMonitorSource().ResourceId = vm.Id;
            return this;
        }

        ///GENMHASH:3FE297B3D6780FD582BD7FDEFCE71BB3:DC53311C981BF68101FB10F19A9D9086
        public ConnectionMonitorImpl WithSourceId(string resourceId)
        {
            EnsureConnectionMonitorSource().ResourceId = resourceId;
            return this;
        }

        ///GENMHASH:9C64003375BC094D7FF90E056718A78F:0BAE81001ED785473AC6A725480D5EFD
        public ConnectionMonitorImpl WithSourcePort(int port)
        {
            EnsureConnectionMonitorSource().Port = port;
            return this;
        }

        ///GENMHASH:FF80DD5A8C82E021759350836BD2FAD1:64CC65B272BB8B61AFE073828F00AA2F
        public ConnectionMonitorImpl WithTag(string key, string value)
        {
            if (Inner.Tags == null)
            {
                Inner.Tags = new Dictionary<string, string>();
            }
            Inner.Tags.Add(key, value);
            return this;
        }

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:810B4CB467DA820135856412C60BC6FD
        public ConnectionMonitorImpl WithTags(IDictionary<string,string> tags)
        {
            Inner.Tags = new Dictionary<string, string>(tags);
            return this;
        }
    }
}