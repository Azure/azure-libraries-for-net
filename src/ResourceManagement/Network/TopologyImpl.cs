// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Fluent.Topology.Definition;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// The implementation of Topology.
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uVG9wb2xvZ3lJbXBs
    internal partial class TopologyImpl :
        Executable<Microsoft.Azure.Management.Network.Fluent.ITopology>,
        ITopology,
        IDefinition
    {
        private TopologyInner inner;
        private TopologyParameters parameters = new TopologyParameters();
        private NetworkWatcherImpl parent;
        private Dictionary<string,Models.TopologyResource> resources;

        ///GENMHASH:9367E0B24ED8FDE050D80357883C7D19:425AAA90FA44C25BF65D98CF87FB3E57
        internal  TopologyImpl(NetworkWatcherImpl parent)
        {
            this.parent = parent;
        }

        ///GENMHASH:5995F84711525BE1DF7039D80FA0DB81:0643202CC76D12C6FF1D8572DE9E7E85
        public DateTime CreatedTime()
        {
            return inner.CreatedDateTime.GetValueOrDefault();
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:A3CF7B3DC953F353AAE8083D72F74056
        public string Id()
        {
            return inner.Id;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public TopologyInner Inner()
        {
            return this.inner;
        }

        ///GENMHASH:5ED618DE41DCDE9DBC9F8179EF143BC3:976080A1C501F480EBF3B1F05875F199
        public DateTime LastModifiedTime()
        {
            return inner.LastModified.GetValueOrDefault();
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public INetworkWatcher Parent()
        {
            return parent;
        }

        ///GENMHASH:272D43EFAA6C6AE625C0BC8C8FB25122:17D30BB94758BE3383DDEAF359B1D080
        public IReadOnlyDictionary<string, Models.TopologyResource> Resources()
        {
            return resources;
        }

        ///GENMHASH:84BDC0B42FDA162E561023D1F1909DF5:7A31B9AAF5466328BC49ECCDA3102A92
        public TopologyParameters TopologyParameters()
        {
            return parameters;
        }

        ///GENMHASH:B99006B0A7B245E596D61D4E9EBC3D61:96A0F7833F128FF4EC3C8F0C9723C345
        public TopologyImpl WithTargetNetwork(string networkId)
        {
            parameters.TargetVirtualNetwork = new SubResource(networkId);
            return this;
        }

        ///GENMHASH:0469EC2C76E3623A08B0419CCDB8996A:0BDA941CA520A2A1B2D8906A6FDA3BAD
        public TopologyImpl WithTargetResourceGroup(string resourceGroupName)
        {
            parameters.TargetResourceGroupName = resourceGroupName;
            return this;
        }

        ///GENMHASH:DCDA550B76AF12C3664B16EDA3AC4865:FB6C8D58B695E6D20ED22DC34DA99871
        public TopologyImpl WithTargetSubnet(string subnetName)
        {
            parameters.TargetSubnet = new SubResource(parameters.TargetVirtualNetwork.Id + "/subnets/" + subnetName);
            return this;
        }

        ///GENMHASH:2C6EAE1A0B195DB734B33ADDB4203F3F:DE9D26C56D3E36A7300D87DFF280D5C5
        private void InitializeResourcesFromInner()
        {
            resources = new Dictionary<string, TopologyResource>();
            IList<TopologyResource> inners = Inner().Resources;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    resources[inner.Id] = inner;
                }
            }
        }

        public override async Task<ITopology> ExecuteAsync(CancellationToken cancellationToken = new CancellationToken(), bool multiThreaded = true)
        {
            this.inner = await parent.Manager.Inner.NetworkWatchers.GetTopologyAsync(parent.ResourceGroupName, parent.Name, parameters, cancellationToken);
            InitializeResourcesFromInner();
            return this;
        }

        TopologyInner IHasInner<TopologyInner>.Inner => inner;
    }
}
