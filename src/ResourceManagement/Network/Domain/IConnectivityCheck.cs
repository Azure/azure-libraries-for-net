// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// A client-side representation allowing user to verify the possibility of establishing a direct TCP connection
    /// from a virtual machine to a given endpoint including another VM or an arbitrary remote server.
    /// </summary>
    public interface IConnectivityCheck :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Network.Fluent.IConnectivityCheck>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>
    {
        /// <summary>
        /// Gets maximum latency in milliseconds.
        /// </summary>
        int MaxLatencyInMs { get; }

        /// <summary>
        /// Gets average latency in milliseconds.
        /// </summary>
        int AvgLatencyInMs { get; }

        /// <summary>
        /// Gets the connection status.
        /// </summary>
        Models.ConnectionStatus ConnectionStatus { get; }

        /// <summary>
        /// Gets number of failed probes.
        /// </summary>
        int ProbesFailed { get; }

        /// <summary>
        /// Gets list of hops between the source and the destination.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ConnectivityHop> Hops { get; }

        /// <summary>
        /// Gets minimum latency in milliseconds.
        /// </summary>
        int MinLatencyInMs { get; }

        /// <summary>
        /// Gets total number of probes sent.
        /// </summary>
        int ProbesSent { get; }
    }
}