// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal class PrivateEndpointImpl :
        Wrapper<PrivateEndpointInner>,
        IPrivateEndpoint
    {
        private readonly INetworkManager manager;
        internal PrivateEndpointImpl(PrivateEndpointInner inner, INetworkManager networkManager) :
            base(inner)
        {
            manager = networkManager;
        }

        public string SubnetId
        {
            get
            {
                return Inner.Subnet?.Id;
            }
        }

        public IReadOnlyList<INetworkInterface> NetworkInterfaces
        {
            get
            {
                List<INetworkInterface> networkInterfaces = new List<INetworkInterface>();
                if (Inner.NetworkInterfaces != null)
                {
                    foreach (var netInterface in Inner.NetworkInterfaces)
                    {
                        networkInterfaces.Add(new NetworkInterfaceImpl(netInterface.Name, netInterface, manager));
                    }
                }
                return networkInterfaces.AsReadOnly();
            }
        }

        public ProvisioningState ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
            }
        }

        public IReadOnlyList<IPrivateLinkServiceConnection> PrivateLinkServiceConnections
        {
            get
            {
                List<IPrivateLinkServiceConnection> connections = new List<IPrivateLinkServiceConnection>();
                if (Inner.PrivateLinkServiceConnections != null)
                {
                    foreach (var conn in Inner.PrivateLinkServiceConnections)
                    {
                        connections.Add(new PrivateLinkServiceConnectionImpl(conn));
                    }
                }
                return connections.AsReadOnly();
            }
        }

        public IReadOnlyList<IPrivateLinkServiceConnection> ManualPrivateLinkServiceConnections
        {
            get
            {
                List<IPrivateLinkServiceConnection> connections = new List<IPrivateLinkServiceConnection>();
                if (Inner.ManualPrivateLinkServiceConnections != null)
                {
                    foreach (var conn in Inner.ManualPrivateLinkServiceConnections)
                    {
                        connections.Add(new PrivateLinkServiceConnectionImpl(conn));
                    }
                }
                return connections.AsReadOnly();
            }
        }

        public string Etag
        {
            get
            {
                return Inner.Etag;
            }
        }

        public string Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public string Type
        {
            get
            {
                return Inner.Type;
            }
        }

        public string Id
        {
            get
            {
                return Inner.Id;
            }
        }
    }
}
