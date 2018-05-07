// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of ConnectivityCheck.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQ29ubmVjdGl2aXR5Q2hlY2tJbXBs
    internal partial class ConnectivityCheckImpl :
        Executable<Microsoft.Azure.Management.Network.Fluent.IConnectivityCheck>,
        IConnectivityCheck,
        IDefinition
    {
        private NetworkWatcherImpl parent;
        private ConnectivityParameters parameters = new ConnectivityParameters();
        private ConnectivityInformationInner result;
        ///GENMHASH:7099791AF90C47ACDEDA5E7DCAC2262C:01CB734F343C6462053765168A26F354
        private ConnectivitySource EnsureConnectivitySource()
        {
            if (parameters.Source == null)
            {
                parameters.Source = new ConnectivitySource();
            }
            return parameters.Source;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public NetworkWatcherImpl Parent()
        {
            return parent;
        }

        ///GENMHASH:C32E303545B4033613B86D06F01768CA:425AAA90FA44C25BF65D98CF87FB3E57
        internal ConnectivityCheckImpl(NetworkWatcherImpl parent)
        {
            this.parent = parent;
        }

        ///GENMHASH:282C87D48123ABFEF9EF6A386444C394:F8FB2267A3287319252955F71E47CEB3
        private ConnectivityDestination EnsureConnectivityDestination()
        {
            if (parameters.Destination == null)
            {
                parameters.Destination = new ConnectivityDestination();
            }
            return parameters.Destination;
        }

        ///GENMHASH:F9B04EF0AD67F90EEEDA6BF3CEEF8C3A:78A5084A233EFAB83DABE4CEF67496B6
        public IWithExecute FromSourcePort(int port)
        {
            EnsureConnectivitySource().Port = port;
            return this;
        }

        ///GENMHASH:319DD913519C94F24D4BF455A772CE0A:EBA8A67D1FC05CCA048B2A44C44C2274
        public ConnectivityCheckImpl ToDestinationResourceId(string resourceId)
        {
            EnsureConnectivityDestination().ResourceId = resourceId;
            return this;
        }

        ///GENMHASH:96C854892D77CC5A6F68053BD7792B3C:4760624617D2FED31BC5F3BB5A1FEA38
        public int MinLatencyInMs()
        {
            return result.MinLatencyInMs.HasValue ? result.MinLatencyInMs.Value : 0;
        }

        ///GENMHASH:7EBA1F61EEB9EF7BACB91B1A04DC9418:3DC015D5C7A93E5C5F1F29BC0CDA776D
        public ConnectivityCheckImpl ToDestinationPort(int port)
        {
            EnsureConnectivityDestination().Port = port;
            return this;
        }

        ///GENMHASH:DA7C859A3D0F5D8B31101F4BF7127618:0167B7FD4F694AD9CA024AF48F9BD394
        public int ProbesSent()
        {
            return result.ProbesSent.HasValue ? result.ProbesSent.Value : 0;
        }

        ///GENMHASH:10457C17D058484634F7E44121EF15F1:539C2A385CE08C660FECFD97FDC642AB
        public int MaxLatencyInMs()
        {
            return result.MaxLatencyInMs.HasValue ? result.MaxLatencyInMs.Value : 0;
        }

        ///GENMHASH:62C5423B6D48CB8281B5A57B9766CB8E:46D04225DE03D8A73C54BC6B17123E52
        public int AvgLatencyInMs()
        {
            return result.AvgLatencyInMs.HasValue ? result.AvgLatencyInMs.Value : 0;
        }

        ///GENMHASH:E1AA6757882A9C665F2BEB461C38A0B6:79F9343E2E8382675ED7AC9A1CCAAE10
        public ConnectivityCheckImpl FromSourceVirtualMachine(string sourceResourceId)
        {
            EnsureConnectivitySource().ResourceId = sourceResourceId;
            return this;
        }

        ///GENMHASH:5923BB148512C06B82BD2E0966465DC4:B23DC266219015460528CB1BADC350E0
        public IWithExecute FromSourceVirtualMachine(IHasNetworkInterfaces vm)
        {
            EnsureConnectivitySource().ResourceId = vm.Id;
            return this;
        }

        ///GENMHASH:FEB663768504525640BBFB5A208F3B76:604674CBADE49147ABB656FB35848A27
        public Microsoft.Azure.Management.Network.Fluent.Models.ConnectionStatus ConnectionStatus()
        {
            return result.ConnectionStatus;
        }

        ///GENMHASH:C12D19550E9A52E850122F1D8B46F8F8:086B6C086549309C625D249938B171B9
        public int ProbesFailed()
        {
            return result.ProbesFailed.HasValue ? result.ProbesFailed.Value : 0;
        }

        ///GENMHASH:87DFD88338243C866D697F0FB60257A3:BBF4CA7BC7BA4A01BAEE7568BD14D607
        public IReadOnlyList<Models.ConnectivityHop> Hops()
        {
            return result.Hops?.ToList();
        }

        ///GENMHASH:134E26C7E06E727E9F0121BD632FD318:9E34B407A461E20E702EEF6D70C3F022
        public ConnectivityCheckImpl ToDestinationAddress(string address)
        {
            EnsureConnectivityDestination().Address = address;
            return this;
        }

        ///GENMHASH:637F0A3522F2C635C23E54FAAD79CBEA:BA1FE24CBE3ADC9B3EE70482C4BFDF0B
        public override async Task<Microsoft.Azure.Management.Network.Fluent.IConnectivityCheck> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            this.result = await parent.Manager.Inner.NetworkWatchers
                .CheckConnectivityAsync(parent.ResourceGroupName, parent.Name, parameters);
            return this;
        }

        ///GENMHASH:BB86B1F07AADE33841AA4762FF3CC20E:B387E3DD8624B2499C0BDB4DDC202E72
        public ConnectivityCheckImpl WithProtocol(Protocol protocol)
        {
            parameters.Protocol = protocol;
            return this;
        }
    }
}