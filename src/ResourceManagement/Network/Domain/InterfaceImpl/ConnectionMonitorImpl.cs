// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class ConnectionMonitorImpl 
    {
        /// <summary>
        /// Gets Determines if the connection monitor will start automatically once
        /// created.
        /// </summary>
        /// <summary>
        /// Gets true if the connection monitor will start automatically once created, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.AutoStart
        {
            get
            {
                return this.AutoStart();
            }
        }

        /// <summary>
        /// Gets the destination property.
        /// </summary>
        Models.ConnectionMonitorDestination Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.Destination
        {
            get
            {
                return this.Destination();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets connection monitor location.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.Location
        {
            get
            {
                return this.Location();
            }
        }

        /// <summary>
        /// Gets monitoring interval in seconds.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.MonitoringIntervalInSeconds
        {
            get
            {
                return this.MonitoringIntervalInSeconds();
            }
        }

        /// <summary>
        /// Gets the monitoring status of the connection monitor.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.MonitoringStatus
        {
            get
            {
                return this.MonitoringStatus();
            }
        }

        /// <summary>
        /// Gets the provisioning state of the connection monitor.
        /// </summary>
        Models.ProvisioningState Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the source property.
        /// </summary>
        Models.ConnectionMonitorSource Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.Source
        {
            get
            {
                return this.Source();
            }
        }

        /// <summary>
        /// Gets the date and time when the connection monitor was started.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.StartTime
        {
            get
            {
                return this.StartTime();
            }
        }

        /// <summary>
        /// Gets connection monitor tags.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.Tags
        {
            get
            {
                return this.Tags();
            }
        }

        /// <summary>
        /// Query a snapshot of the most recent connection state of a connection monitor.
        /// </summary>
        /// <return>Snapshot of the most recent connection state.</return>
        Microsoft.Azure.Management.Network.Fluent.IConnectionMonitorQueryResult Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.Query()
        {
            return this.Query();
        }

        /// <summary>
        /// Query a snapshot of the most recent connection state of a connection monitor asynchronously.
        /// </summary>
        /// <return>Snapshot of the most recent connection state.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.IConnectionMonitorQueryResult> Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.QueryAsync(CancellationToken cancellationToken)
        {
            return await this.QueryAsync(cancellationToken);
        }

        /// <summary>
        /// Starts a specified connection monitor.
        /// </summary>
        void Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.Start()
        {
 
            this.Start();
        }

        /// <summary>
        /// Starts a specified connection monitor asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        async Task Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.StartAsync(CancellationToken cancellationToken)
        {
 
            await this.StartAsync(cancellationToken);
        }

        /// <summary>
        /// Stops a specified connection monitor.
        /// </summary>
        void Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.Stop()
        {
 
            this.Stop();
        }

        /// <summary>
        /// Stops a specified connection monitor asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        async Task Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor.StopAsync(CancellationToken cancellationToken)
        {
 
            await this.StopAsync(cancellationToken);
        }

        /// <param name="vm">Virtual machine used as the source by connection monitor.</param>
        /// <return>Next definition stage.</return>
        ConnectionMonitor.Definition.IWithDestinationPort ConnectionMonitor.Definition.IWithDestination.WithDestination(IHasNetworkInterfaces vm)
        {
            return this.WithDestination(vm);
        }

        /// <param name="address">Address of the connection monitor destination (IP or domain name).</param>
        /// <return>Next definition stage.</return>
        ConnectionMonitor.Definition.IWithDestinationPort ConnectionMonitor.Definition.IWithDestination.WithDestinationAddress(string address)
        {
            return this.WithDestinationAddress(address);
        }

        /// <param name="resourceId">The ID of the resource used as the source by connection monitor.</param>
        /// <return>Next definition stage.</return>
        ConnectionMonitor.Definition.IWithDestinationPort ConnectionMonitor.Definition.IWithDestination.WithDestinationId(string resourceId)
        {
            return this.WithDestinationId(resourceId);
        }

        /// <param name="port">The ID of the resource used as the source by connection monitor.</param>
        /// <return>Next definition stage.</return>
        ConnectionMonitor.Definition.IWithCreate ConnectionMonitor.Definition.IWithDestinationPort.WithDestinationPort(int port)
        {
            return this.WithDestinationPort(port);
        }

        /// <param name="seconds">Monitoring interval in seconds.</param>
        /// <return>Next definition stage.</return>
        ConnectionMonitor.Definition.IWithCreate ConnectionMonitor.Definition.IWithMonitoringInterval.WithMonitoringInterval(int seconds)
        {
            return this.WithMonitoringInterval(seconds);
        }

        /// <summary>
        /// Disable auto start.
        /// </summary>
        /// <return>Next definition stage.</return>
        ConnectionMonitor.Definition.IWithCreate ConnectionMonitor.Definition.IWithAutoStart.WithoutAutoStart()
        {
            return this.WithoutAutoStart();
        }

        /// <summary>
        /// Removes a tag from the connection monitor.
        /// </summary>
        /// <param name="key">The key of the tag to remove.</param>
        /// <return>The next stage of the definition.</return>
        ConnectionMonitor.Definition.IWithCreate ConnectionMonitor.Definition.IWithTags.WithoutTag(string key)
        {
            return this.WithoutTag(key);
        }

        /// <param name="vm">Virtual machine used as the source by connection monitor.</param>
        /// <return>Next definition stage.</return>
        ConnectionMonitor.Definition.IWithDestination ConnectionMonitor.Definition.IWithSource.WithSource(IHasNetworkInterfaces vm)
        {
            return this.WithSource(vm);
        }

        /// <param name="resourceId">The ID of the resource used as the source by connection monitor.</param>
        /// <return>Next definition stage.</return>
        ConnectionMonitor.Definition.IWithDestination ConnectionMonitor.Definition.IWithSource.WithSourceId(string resourceId)
        {
            return this.WithSourceId(resourceId);
        }

        /// <param name="port">Source port used by connection monitor.</param>
        /// <return>Next definition stage.</return>
        ConnectionMonitor.Definition.IWithDestination ConnectionMonitor.Definition.IWithSourcePort.WithSourcePort(int port)
        {
            return this.WithSourcePort(port);
        }

        /// <summary>
        /// Adds a tag to the connection monitor.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the definition.</return>
        ConnectionMonitor.Definition.IWithCreate ConnectionMonitor.Definition.IWithTags.WithTag(string key, string value)
        {
            return this.WithTag(key, value);
        }

        /// <summary>
        /// Specifies tags for the connection monitor.
        /// </summary>
        /// <param name="tags">Tags indexed by name.</param>
        /// <return>The next stage of the definition.</return>
        ConnectionMonitor.Definition.IWithCreate ConnectionMonitor.Definition.IWithTags.WithTags(IDictionary<string,string> tags)
        {
            return this.WithTags(tags);
        }
    }
}