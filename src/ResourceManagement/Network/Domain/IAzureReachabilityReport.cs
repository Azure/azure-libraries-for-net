// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of Azure reachability report details.
    /// </summary>
    public interface IAzureReachabilityReport  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Network.Fluent.IAzureReachabilityReport>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.AzureReachabilityReportInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>
    {

        /// <summary>
        /// Gets the aggregation level of Azure reachability report. Can be Country,
        /// State or City.
        /// </summary>
        string AggregationLevel { get; }

        /// <summary>
        /// Gets parameters used to query available internet providers.
        /// </summary>
        Models.AzureReachabilityReportParameters AzureReachabilityReportParameters { get; }

        /// <summary>
        /// Gets the providerLocation property.
        /// </summary>
        Models.AzureReachabilityReportLocation ProviderLocation { get; }

        /// <summary>
        /// Gets list of Azure reachability report items.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.AzureReachabilityReportItem> ReachabilityReport { get; }
    }
}