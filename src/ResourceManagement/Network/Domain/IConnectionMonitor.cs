// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Client-side representation of Connection Monitor object, associated with Network Watcher.
    /// </summary>
    public interface IConnectionMonitor  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ConnectionMonitorResultInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable
    {

        /// <summary>
        /// Gets Determines if the connection monitor will start automatically once
        /// created.
        /// </summary>
        /// <summary>
        /// Gets true if the connection monitor will start automatically once created, false otherwise.
        /// </summary>
        bool AutoStart { get; }

        /// <summary>
        /// Gets the destination property.
        /// </summary>
        Models.ConnectionMonitorDestination Destination { get; }

        /// <summary>
        /// Gets connection monitor location.
        /// </summary>
        string Location { get; }

        /// <summary>
        /// Gets monitoring interval in seconds.
        /// </summary>
        int MonitoringIntervalInSeconds { get; }

        /// <summary>
        /// Gets the monitoring status of the connection monitor.
        /// </summary>
        string MonitoringStatus { get; }

        /// <summary>
        /// Gets the provisioning state of the connection monitor.
        /// </summary>
        Models.ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the source property.
        /// </summary>
        Models.ConnectionMonitorSource Source { get; }

        /// <summary>
        /// Gets the date and time when the connection monitor was started.
        /// </summary>
        System.DateTime StartTime { get; }

        /// <summary>
        /// Gets connection monitor tags.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Tags { get; }

        /// <summary>
        /// Query a snapshot of the most recent connection state of a connection monitor.
        /// </summary>
        /// <return>Snapshot of the most recent connection state.</return>
        Microsoft.Azure.Management.Network.Fluent.IConnectionMonitorQueryResult Query();

        /// <summary>
        /// Query a snapshot of the most recent connection state of a connection monitor asynchronously.
        /// </summary>
        /// <return>Snapshot of the most recent connection state.</return>
        Task<Microsoft.Azure.Management.Network.Fluent.IConnectionMonitorQueryResult> QueryAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts a specified connection monitor.
        /// </summary>
        void Start();

        /// <summary>
        /// Starts a specified connection monitor asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Stops a specified connection monitor.
        /// </summary>
        void Stop();

        /// <summary>
        /// Stops a specified connection monitor asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}