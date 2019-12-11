// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uRXhwcmVzc1JvdXRlQ2lyY3VpdFBlZXJpbmdJbXBs
    internal partial class ExpressRouteCircuitPeeringImpl :
        IndependentChildImpl<
            IExpressRouteCircuitPeering,
            IExpressRouteCircuit,
            ExpressRouteCircuitPeeringInner,
            ExpressRouteCircuitPeeringImpl,
            IHasId,
            IUpdate,
            INetworkManager>,
        IExpressRouteCircuitPeering,
        IDefinition,
        IUpdate
    {
        private IExpressRouteCircuitPeeringsOperations client;
        private IExpressRouteCircuit parent;
        private ExpressRouteCircuitStatsImpl stats;
        ///GENMHASH:CE19D6E1BE71E1233D9525A7E026BFC7:0DAA02A6E6149A594F1E611CEDA41775
        public string SharedKey()
        {
            return Inner.SharedKey;
        }

        ///GENMHASH:A50652422920394C30CADC3C3B5EB9A5:980EAF291C4225092A307D0171005F28
        public string PrimaryAzurePort()
        {
            return Inner.PrimaryAzurePort;
        }

        ///GENMHASH:F205630E75FA1148988CE1BB2312093B:B8A6D650BDAC3E4817F9DA420D6A8783
        public Ipv6ExpressRouteCircuitPeeringConfig IPv6PeeringConfig()
        {
            return Inner.Ipv6PeeringConfig;
        }

        ///GENMHASH:19E661FAB103F9F616D6E254F778F73A:D5E1AB9448B90D30C563BF0F3A2B2BBF
        public string SecondaryAzurePort()
        {
            return Inner.SecondaryAzurePort;
        }

        ///GENMHASH:C31CAD48396B22242629B56D7CF4C752:1C4FA0FB0A4C7AFB05F85FB74776EF31
        public ExpressRouteCircuitPeeringImpl WithPrimaryPeerAddressPrefix(string addressPrefix)
        {
            Inner.PrimaryPeerAddressPrefix = addressPrefix;
            return this;
        }

        ///GENMHASH:F39264C98D411F14A45DA1D84E9F98DE:BE4F1022441334645B5E05DE48196994
        private ExpressRouteCircuitPeeringConfig EnsureMicrosoftPeeringConfig()
        {
            if (Inner.MicrosoftPeeringConfig == null)
            {
                Inner.MicrosoftPeeringConfig = new ExpressRouteCircuitPeeringConfig();
            }
            return Inner.MicrosoftPeeringConfig;
        }

        ///GENMHASH:8102636A111E22807C7BD05E4AD19D5F:E29C120BDBF04F95AF1826A1AFEE43C6
        public int AzureAsn()
        {
            return Inner.AzureASN.HasValue ? Inner.AzureASN.Value : 0;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:754810EA5144700BBB078C6E55E8C153
        protected override async Task<Models.ExpressRouteCircuitPeeringInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await client.GetAsync(parent.ResourceGroupName, parent.Name, Name);
        }

        ///GENMHASH:B6A90BC231E9AF66CAE249DC54C16CE2:F78E367CA168F9A4650E2F8DD85F5907
        public string SecondaryPeerAddressPrefix()
        {
            return Inner.SecondaryPeerAddressPrefix;
        }

        ///GENMHASH:BA5CADB8C4D605E61A861FD937CC31A4:95B26F498B39D7FE039475F86AE24983
        public ExpressRouteCircuitStatsImpl Stats()
        {
            return stats;
        }

        ///GENMHASH:B411D8F65E0E6A8CB7A68775237D2253:88DD115259C0B2EE67A037B376BF5885
        public ExpressRouteCircuitPeeringImpl WithSecondaryPeerAddressPrefix(string addressPrefix)
        {
            Inner.SecondaryPeerAddressPrefix = addressPrefix;
            return this;
        }

        ///GENMHASH:BC7AEF2CB64C2D427124B07846346ACF:65C532C06CDE074161D2DD0F0A8FA440
        public string PrimaryPeerAddressPrefix()
        {
            return Inner.PrimaryPeerAddressPrefix;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:A3CF7B3DC953F353AAE8083D72F74056
        public override string Id
        {
            get
            {
                return Inner.Id;
            }
        }

        ///GENMHASH:AEE17FD09F624712647F5EBCEC141EA5:A2B4C8D5515FE0A160E2214A60FB99A6
        public ExpressRoutePeeringState State()
        {
            return Inner.State;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:4FC30E0F6EB4AA975F91CB9D7C798AFE
        protected override async Task<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetInner(await client.CreateOrUpdateAsync(parent.ResourceGroupName, parent.Name, this.Name, Inner));
            stats = new ExpressRouteCircuitStatsImpl(Inner.Stats);
            if (parent != null)
            {
                await parent.RefreshAsync(cancellationToken);
            }
            return this;
        }

        ///GENMHASH:485C72CDD911A007F5A804436A3BCA68:FF479A489725561C2045B0642CCBCCED
        public ExpressRoutePeeringType PeeringType()
        {
            return Inner.PeeringType;
        }

        ///GENMHASH:5B4E75310952352A341A438C97BCDE27:43D5810028C5A1E8F807D845A5FC84BD
        public ExpressRouteCircuitPeeringImpl WithVlanId(int vlanId)
        {
            Inner.VlanId = vlanId;
            return this;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:30C5ADA0233BA39DBC78FE6130CA9DC1
        public string ResourceGroupName()
        {
            return parent.ResourceGroupName;
        }

        ///GENMHASH:391F9005AD1C2F7A853CA2864862ED4F:DB3150F8D0E08097844D717E6619C2E3
        public int VlanId()
        {
            return Inner.VlanId.HasValue ? Inner.VlanId.Value : 0;
        }

        ///GENMHASH:F4BB98513D1B9E2571D1DD50496A5427:EB26B49EC1F5226DDE798B857F8726A7
        public string LastModifiedBy()
        {
            return Inner.LastModifiedBy;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:3DB04077E6BABC0FB5A5ACDA19D11309
        public ProvisioningState ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        ///GENMHASH:4F6F8EB53B615AA4FDE4C8CD06427C19:655E227778C880919192F106CB2F1726
        public long PeerAsn()
        {
            return Inner.PeerASN.HasValue ? Inner.PeerASN.Value : 0;
        }

        ///GENMHASH:BEA39F3632F73FBF1B8AF536983EFFFF:405C74E71663212A8907A343554332A4
        public ExpressRouteCircuitPeeringImpl WithAdvertisedPublicPrefixes(string publicPrefix)
        {
            EnsureMicrosoftPeeringConfig().AdvertisedPublicPrefixes = new List<string> { publicPrefix };
            return this;
        }

        ///GENMHASH:781AA51279F5B129E87598D4CD0AA7A2:FB9DCC9BF2304804D68997EC6E1F8CFB
        public ExpressRouteCircuitPeeringImpl WithPeerAsn(int peerAsn)
        {
            Inner.PeerASN = peerAsn;
            return this;
        }

        ///GENMHASH:631CF8EC2CF9DF06C92074E58975650B:53E334DA0EAD642691037F7A14026758
        public ExpressRouteCircuitPeeringConfig MicrosoftPeeringConfig()
        {
            return Inner.MicrosoftPeeringConfig;
        }

        ///GENMHASH:F1FF74FECF7AD81993920CCBF4D96B40:34F765B181E581705C5B1FEB895758A1
        internal ExpressRouteCircuitPeeringImpl(ExpressRouteCircuitImpl parent, ExpressRouteCircuitPeeringInner innerObject, IExpressRouteCircuitPeeringsOperations client, ExpressRoutePeeringType type)
            : base(type.Value, innerObject, parent.Manager)
        {
            this.client = client;
            this.parent = parent;
            stats = new ExpressRouteCircuitStatsImpl(innerObject.Stats);
            Inner.PeeringType = type;
        }
    }
}