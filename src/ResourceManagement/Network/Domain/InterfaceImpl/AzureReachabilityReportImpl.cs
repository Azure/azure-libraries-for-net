// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class AzureReachabilityReportImpl 
    {
        /// <summary>
        /// Gets the aggregation level of Azure reachability report. Can be Country,
        /// State or City.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IAzureReachabilityReport.AggregationLevel
        {
            get
            {
                return this.AggregationLevel();
            }
        }

        /// <summary>
        /// Gets parameters used to query available internet providers.
        /// </summary>
        Models.AzureReachabilityReportParameters Microsoft.Azure.Management.Network.Fluent.IAzureReachabilityReport.AzureReachabilityReportParameters
        {
            get
            {
                return this.AzureReachabilityReportParameters();
            }
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkWatcher Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>.Parent
        {
            get
            {
                return this.Parent();
            }
        }

        /// <summary>
        /// Gets the providerLocation property.
        /// </summary>
        Models.AzureReachabilityReportLocation Microsoft.Azure.Management.Network.Fluent.IAzureReachabilityReport.ProviderLocation
        {
            get
            {
                return this.ProviderLocation();
            }
        }

        /// <summary>
        /// Gets list of Azure reachability report items.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.AzureReachabilityReportItem> Microsoft.Azure.Management.Network.Fluent.IAzureReachabilityReport.ReachabilityReport
        {
            get
            {
                return this.ReachabilityReport();
            }
        }

        AzureReachabilityReport.Definition.IWithExecute AzureReachabilityReport.Definition.IWithAzureLocations.WithAzureLocations(params string[] azureLocations)
        {
            return this.WithAzureLocations(azureLocations);
        }

        /// <param name="endTime">The start time for the Azure reachability report.</param>
        /// <return>The next stage of the definition.</return>
        AzureReachabilityReport.Definition.IWithExecute AzureReachabilityReport.Definition.IWithEndTime.WithEndTime(DateTime endTime)
        {
            return this.WithEndTime(endTime);
        }

        /// <param name="country">The name of the country.</param>
        /// <return>The AzureReachabilityReport object itself.</return>
        AzureReachabilityReport.Definition.IWithStartTime AzureReachabilityReport.Definition.IWithProviderLocation.WithProviderLocation(string country)
        {
            return this.WithProviderLocation(country);
        }

        /// <param name="country">The name of the country.</param>
        /// <param name="state">The name of the state.</param>
        /// <return>The AzureReachabilityReport object itself.</return>
        AzureReachabilityReport.Definition.IWithStartTime AzureReachabilityReport.Definition.IWithProviderLocation.WithProviderLocation(string country, string state)
        {
            return this.WithProviderLocation(country, state);
        }

        /// <param name="country">The name of the country.</param>
        /// <param name="state">The name of the state.</param>
        /// <param name="city">The name of the city.</param>
        /// <return>The AzureReachabilityReport object itself.</return>
        AzureReachabilityReport.Definition.IWithStartTime AzureReachabilityReport.Definition.IWithProviderLocation.WithProviderLocation(string country, string state, string city)
        {
            return this.WithProviderLocation(country, state, city);
        }

        /// <param name="providers">The list of Internet service providers.</param>
        /// <return>The next stage of the definition.</return>
        AzureReachabilityReport.Definition.IWithExecute AzureReachabilityReport.Definition.IWithProviders.WithProviders(params string[] providers)
        {
            return this.WithProviders(providers);
        }

        /// <param name="startTime">The start time for the Azure reachability report.</param>
        /// <return>The next stage of the definition.</return>
        AzureReachabilityReport.Definition.IWithEndTime AzureReachabilityReport.Definition.IWithStartTime.WithStartTime(DateTime startTime)
        {
            return this.WithStartTime(startTime);
        }
    }
}