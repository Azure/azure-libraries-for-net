// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Contains stats associated with the peering.
    /// </summary>
    public interface IExpressRouteCircuitStats :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ExpressRouteCircuitStatsInner>
    {
        /// <summary>
        /// Gets inbound bytes through secondary channel of the peering.
        /// </summary>
        long SecondaryBytesIn { get; }

        /// <summary>
        /// Gets outbound bytes through primary channel of the peering.
        /// </summary>
        long PrimaryBytesOut { get; }

        /// <summary>
        /// Gets outbound bytes through secondary channel of the peering.
        /// </summary>
        long SecondaryBytesOut { get; }

        /// <summary>
        /// Gets inbound bytes through primary channel of the peering.
        /// </summary>
        long PrimaryBytesIn { get; }
    }
}