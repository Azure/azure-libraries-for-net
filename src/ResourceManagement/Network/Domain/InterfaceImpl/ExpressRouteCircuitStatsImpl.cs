// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class ExpressRouteCircuitStatsImpl
    {
        /// <summary>
        /// Gets outbound bytes through secondary channel of the peering.
        /// </summary>
        long Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitStats.SecondaryBytesOut
        {
            get
            {
                return this.SecondaryBytesOut();
            }
        }

        /// <summary>
        /// Gets inbound bytes through primary channel of the peering.
        /// </summary>
        long Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitStats.PrimaryBytesIn
        {
            get
            {
                return this.PrimaryBytesIn();
            }
        }

        /// <summary>
        /// Gets inbound bytes through secondary channel of the peering.
        /// </summary>
        long Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitStats.SecondaryBytesIn
        {
            get
            {
                return this.SecondaryBytesIn();
            }
        }

        /// <summary>
        /// Gets outbound bytes through primary channel of the peering.
        /// </summary>
        long Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitStats.PrimaryBytesOut
        {
            get
            {
                return this.PrimaryBytesOut();
            }
        }
    }
}