// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal class PrivateLinkServiceConnectionImpl :
        Wrapper<PrivateLinkServiceConnectionInner>,
        IPrivateLinkServiceConnection
    {
        internal PrivateLinkServiceConnectionImpl(PrivateLinkServiceConnectionInner inner)
            : base(inner)
        {
        }

        public ProvisioningState ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
            }
        }

        public string PrivateLinkServiceId
        {
            get
            {
                return Inner.PrivateLinkServiceId;
            }
        }

        public IReadOnlyList<string> GroupIds
        {
            get
            {
                List<string> ids;
                if (Inner.GroupIds != null)
                {
                    ids = new List<string>(Inner.GroupIds);
                }
                else
                {
                    ids = new List<string>();
                }
                return ids.AsReadOnly();
            }
        }

        public string RequestMessage
        {
            get
            {
                return Inner.RequestMessage;
            }
        }

        public PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState
        {
            get
            {
                return Inner.PrivateLinkServiceConnectionState;
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
