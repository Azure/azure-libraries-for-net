// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class ConnectivityCheckImpl
    {
        /// <param name="port">Destination port.</param>
        /// <return>Next definition stage.</return>
        ConnectivityCheck.Definition.IFromSourceVirtualMachine ConnectivityCheck.Definition.IToDestinationPort.ToDestinationPort(int port)
        {
            return this.ToDestinationPort(port);
        }

        /// <param name="port">Source port.</param>
        /// <return>Next definition stage.</return>
        ConnectivityCheck.Definition.IWithExecute ConnectivityCheck.Definition.IFromSourcePort.FromSourcePort(int port)
        {
            return this.FromSourcePort(port);
        }

        /// <param name="resourceId">The ID of the resource to which a connection attempt will be made.</param>
        /// <return>Next definition stage.</return>
        ConnectivityCheck.Definition.IToDestinationPort ConnectivityCheck.Definition.IToDestination.ToDestinationResourceId(string resourceId)
        {
            return this.ToDestinationResourceId(resourceId);
        }

        /// <param name="address">The IP address or URI the resource to which a connection attempt will be made.</param>
        /// <return>Next definition stage.</return>
        ConnectivityCheck.Definition.IToDestinationPort ConnectivityCheck.Definition.IToDestination.ToDestinationAddress(string address)
        {
            return this.ToDestinationAddress(address);
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
        /// Gets list of hops between the source and the destination.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ConnectivityHop> Microsoft.Azure.Management.Network.Fluent.IConnectivityCheck.Hops
        {
            get
            {
                return this.Hops();
            }
        }

        /// <summary>
        /// Gets minimum latency in milliseconds.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IConnectivityCheck.MinLatencyInMs
        {
            get
            {
                return this.MinLatencyInMs();
            }
        }

        /// <summary>
        /// Gets number of failed probes.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IConnectivityCheck.ProbesFailed
        {
            get
            {
                return this.ProbesFailed();
            }
        }

        /// <summary>
        /// Gets maximum latency in milliseconds.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IConnectivityCheck.MaxLatencyInMs
        {
            get
            {
                return this.MaxLatencyInMs();
            }
        }

        /// <summary>
        /// Gets the connection status.
        /// </summary>
        Models.ConnectionStatus Microsoft.Azure.Management.Network.Fluent.IConnectivityCheck.ConnectionStatus
        {
            get
            {
                return this.ConnectionStatus();
            }
        }

        /// <summary>
        /// Gets total number of probes sent.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IConnectivityCheck.ProbesSent
        {
            get
            {
                return this.ProbesSent();
            }
        }

        /// <summary>
        /// Gets average latency in milliseconds.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IConnectivityCheck.AvgLatencyInMs
        {
            get
            {
                return this.AvgLatencyInMs();
            }
        }

        /// <param name="resourceId">The ID of the virtual machine from which a connectivity check will be initiated.</param>
        /// <return>Next definition stage.</return>
        ConnectivityCheck.Definition.IWithExecute ConnectivityCheck.Definition.IFromSourceVirtualMachine.FromSourceVirtualMachine(string resourceId)
        {
            return this.FromSourceVirtualMachine(resourceId);
        }

        /// <param name="vm">Virtual machine from which a connectivity check will be initiated.</param>
        /// <return>Next definition stage.</return>
        ConnectivityCheck.Definition.IWithExecute ConnectivityCheck.Definition.IFromSourceVirtualMachine.FromSourceVirtualMachine(IHasNetworkInterfaces vm)
        {
            return this.FromSourceVirtualMachine(vm);
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        ConnectivityCheck.Definition.IWithExecute HasProtocol.Definition.IWithProtocol<ConnectivityCheck.Definition.IWithExecute,Models.Protocol>.WithProtocol(Protocol protocol)
        {
            return this.WithProtocol(protocol);
        }
    }
}