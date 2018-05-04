// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation of AvailableProviders.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXZhaWxhYmxlUHJvdmlkZXJzSW1wbA==
    internal partial class AvailableProvidersImpl  :
        Executable<Microsoft.Azure.Management.Network.Fluent.IAvailableProviders>,
        IAvailableProviders,
        IDefinition
    {
        private AvailableProvidersListInner inner;
        private AvailableProvidersListParameters parameters = new AvailableProvidersListParameters();
        private NetworkWatcherImpl parent;
        private Dictionary<string,Models.AvailableProvidersListCountry> providersByCountry;

        ///GENMHASH:EE7F5688BBA4BAC83F18F142CC37FA52:425AAA90FA44C25BF65D98CF87FB3E57
        internal  AvailableProvidersImpl(NetworkWatcherImpl parent)
        {
            this.parent = parent;
        }

        ///GENMHASH:2C6EAE1A0B195DB734B33ADDB4203F3F:B40D655DCD341BFB1E761F25EE1B87D6
        private void InitializeResourcesFromInner()
        {
            providersByCountry = new Dictionary<string, AvailableProvidersListCountry>();
            var inners = Inner().Countries;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    providersByCountry[inner.CountryName] = inner;
                }
            }
        }

        ///GENMHASH:23A4346B0B0D770DF432AC5949EE9666:7A31B9AAF5466328BC49ECCDA3102A92
        public AvailableProvidersListParameters AvailableProvidersParameters()
        {
            return parameters;
        }

        ///GENMHASH:637F0A3522F2C635C23E54FAAD79CBEA:2F3886FC773DF9FABF63CDBC571E5451
        public override async Task<IAvailableProviders> ExecuteAsync(CancellationToken cancellationToken = new CancellationToken(), bool multiThreaded = true)
        {
            this.inner =
                await parent.Manager.Inner.NetworkWatchers.ListAvailableProvidersAsync(parent.ResourceGroupName,
                    parent.Name, parameters, cancellationToken);
            InitializeResourcesFromInner();
            return this;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public AvailableProvidersListInner Inner()
        {
            return this.inner;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public INetworkWatcher Parent()
        {
            return parent;
        }

        ///GENMHASH:02D4291678B9DD815B24067695A568FE:CBB7D90388387B638B8F355DFCA9DB53
        public IReadOnlyDictionary<string,Models.AvailableProvidersListCountry> ProvidersByCountry()
        {
            return this.providersByCountry;
        }

        ///GENMHASH:C69ABFB260D78D792D404EC3BF958ED7:BC72AF070CE5DBB4DA29D4F2E31326A3
        public AvailableProvidersImpl WithAzureLocation(string azureLocation)
        {
            if (parameters.AzureLocations == null) {
                parameters.AzureLocations = new List<string>();
            }
            parameters.AzureLocations.Add(azureLocation);
            return this;
        }

        ///GENMHASH:DBE908B51C2C3ACC09544176732C78B3:DBA36CA1C37ED3DF4C9385ED3FCE6A83
        public AvailableProvidersImpl WithAzureLocations(params string[] azureLocations)
        {
            if (parameters.AzureLocations == null)
            {
                parameters.AzureLocations = new List<string>();
            }
            foreach (var location in azureLocations)
            {
                parameters.AzureLocations.Add(location);
            }
            return this;
        }

        ///GENMHASH:79B40BC8608C55BE421D10368B0976C1:96C65C9DA3972BEFA81DC69060C3E54B
        public AvailableProvidersImpl WithCity(string city)
        {
            parameters.City = city;
            return this;
        }

        ///GENMHASH:EDA6C55DA7B7CC343CABE6D814140EA9:8DC8CE367538B8FE24ACCADF429E8EC5
        public AvailableProvidersImpl WithCountry(string country)
        {
            parameters.Country = country;
            return this;
        }

        ///GENMHASH:9F6E4390422675F2E5488C65F0A3E8E5:098BC7C46E9AD37B1829B1585080C79C
        public AvailableProvidersImpl WithState(string state)
        {
            parameters.State = state;
            return this;
        }

        AvailableProvidersListInner IHasInner<AvailableProvidersListInner>.Inner
        {
            get { return Inner(); }
        }
    }
}