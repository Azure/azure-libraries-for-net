// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation of AzureReachabilityReport.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXp1cmVSZWFjaGFiaWxpdHlSZXBvcnRJbXBs
    internal partial class AzureReachabilityReportImpl  :
        Executable<Microsoft.Azure.Management.Network.Fluent.IAzureReachabilityReport>,
        IAzureReachabilityReport,
        IDefinition
    {
        private AzureReachabilityReportInner inner;
        private AzureReachabilityReportParameters parameters = new AzureReachabilityReportParameters();
        private NetworkWatcherImpl parent;

        ///GENMHASH:B35D63B671CF6D8D001FDE561D5CFDCF:425AAA90FA44C25BF65D98CF87FB3E57
        internal  AzureReachabilityReportImpl(NetworkWatcherImpl parent)
        {
            this.parent = parent;
            
        }

        ///GENMHASH:7310C299B150ACDDC5DAEFC3DB165FDF:C90872EB6C3409AAF1FEFC9F53B7B848
        public string AggregationLevel()
        {
            return inner.AggregationLevel;
        }

        ///GENMHASH:AF5B92F7D602ADD6835472AD2633A663:7A31B9AAF5466328BC49ECCDA3102A92
        public AzureReachabilityReportParameters AzureReachabilityReportParameters()
        {
            return parameters;
        }

        ///GENMHASH:637F0A3522F2C635C23E54FAAD79CBEA:4891FA97A857767ACE1138F0F8DDD55F
        public override async Task<IAzureReachabilityReport> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            this.inner =
                await parent.Manager.Inner.NetworkWatchers.GetAzureReachabilityReportAsync(parent.ResourceGroupName,
                    parent.Name, parameters, cancellationToken); 
            return this;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public AzureReachabilityReportInner Inner()
        {
            return this.inner;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public INetworkWatcher Parent()
        {
            return parent;
        }

        ///GENMHASH:F544AD5C2AD1F62DB8EA5D7AD1FD5021:D1C74C8C0866743532927974EA5CFB3C
        public AzureReachabilityReportLocation ProviderLocation()
        {
            return inner.ProviderLocation;
        }

        ///GENMHASH:4FE530CF34C22FA621A20EC7342C5275:2CB8A0991EDDDCF72582C9946B051367
        public IReadOnlyList<Models.AzureReachabilityReportItem> ReachabilityReport()
        {
            List<AzureReachabilityReportItem> result = new List<AzureReachabilityReportItem>();
            if (this.Inner().ReachabilityReport != null)
            {
                result.AddRange(this.Inner().ReachabilityReport);
            }
            return result.AsReadOnly();
        }

        ///GENMHASH:DBE908B51C2C3ACC09544176732C78B3:DBA36CA1C37ED3DF4C9385ED3FCE6A83
        public IWithExecute WithAzureLocations(params string[] azureLocations)
        {
            this.parameters.AzureLocations = new List<String>();
            foreach (var id in azureLocations)
            {
                this.parameters.AzureLocations.Add(id);
            }

            return this;
        }

        ///GENMHASH:C4FF9250259C19995B551B017771F384:E389C065ACF7E72C2E6424B83216EEB7
        public AzureReachabilityReportImpl WithEndTime(DateTime endTime)
        {
            parameters.EndTime = endTime;
            return this;
        }

        ///GENMHASH:66208FE3A0A4FC1FECC54CDA052552A1:65E1F47AFBE80C48C09EAA1BFBFB9292
        public AzureReachabilityReportImpl WithProviderLocation(string country)
        {
            parameters.ProviderLocation = new AzureReachabilityReportLocation(country: country);
            return this;
        }

        ///GENMHASH:402F2398A6E1237B28538BDC22CBA48F:F543AC24C3901A10BA5FBCA03E276F23
        public AzureReachabilityReportImpl WithProviderLocation(string country, string state)
        {
            parameters.ProviderLocation = new AzureReachabilityReportLocation(country: country, state: state);
            return this;
        }

        ///GENMHASH:B31E557AA2AFC2C8F55DF55DAFA84670:53866A5F2C01767FD42720B1DAF2EB99
        public AzureReachabilityReportImpl WithProviderLocation(string country, string state, string city)
        {
            parameters.ProviderLocation = new AzureReachabilityReportLocation(country: country, state: state, city: city);
            return this;
        }

        ///GENMHASH:F524E41F91C15EEEE804F9935D7208A0:576339BA7B4830E4C48F96C379A9FA2C
        public IWithExecute WithProviders(params string[] providers)
        {
            this.parameters.Providers = new List<String>();
            foreach (var id in providers)
            {
                this.parameters.Providers.Add(id);
            }

            return this;
        }

        ///GENMHASH:99D252694C3BCB6EB9B8CD48B089D0F9:01DBD646E603079CE2678567D30B518A
        public AzureReachabilityReportImpl WithStartTime(DateTime startTime)
        {
            parameters.StartTime = startTime;
            return this;
        }

        AzureReachabilityReportInner IHasInner<AzureReachabilityReportInner>.Inner
        {
            get { return inner; }
        }
    }
}