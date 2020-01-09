// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal class PrivateEndpointConnectionImpl :
        Wrapper<PrivateEndpointConnectionInner>,
        IPrivateEndpointConnection
    {
        private readonly INetworkManager manager;
        internal PrivateEndpointConnectionImpl(PrivateEndpointConnectionInner inner, INetworkManager networkManager) :
            base(inner)
        {
            manager = networkManager;
        }

        public IPrivateEndpoint PrivateEndpoint
        {
            get
            {
                return Inner.PrivateEndpoint == null ? null : new PrivateEndpointImpl(Inner.PrivateEndpoint, manager);
            }
        }

        public PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState
        {
            get
            {
                return Inner.PrivateLinkServiceConnectionState;
            }
        }

        public ProvisioningState ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
            }
        }

        public string LinkIdentifier
        {
            get
            {
                return Inner.LinkIdentifier;
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

        public string Etag
        {
            get
            {
                return Inner.Etag;
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
