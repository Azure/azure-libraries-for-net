// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal class PrivateLinkServiceIPConfigurationImpl :
        Wrapper<PrivateLinkServiceIpConfigurationInner>,
        IPrivateLinkServiceIPConfiguration
    {
        internal PrivateLinkServiceIPConfigurationImpl(PrivateLinkServiceIpConfigurationInner inner) :
            base(inner)
        {
        }

        string IPrivateLinkServiceIPConfiguration.PrivateIPAddress
        {
            get
            {
                return Inner.PrivateIPAddress;
            }
        }
        IPAllocationMethod IPrivateLinkServiceIPConfiguration.PrivateIPAllocationMethod
        {
            get
            {
                return Inner.PrivateIPAllocationMethod;
            }
        }

        string IPrivateLinkServiceIPConfiguration.SubnetId
        {
            get
            {
                return Inner.Subnet?.Id;
            }
        }

        bool IPrivateLinkServiceIPConfiguration.Primary
        {
            get
            {
                return Inner.Primary.HasValue && Inner.Primary.Value == true;
            }
        }

        ProvisioningState IPrivateLinkServiceIPConfiguration.ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
            }
        }

        IPVersion IPrivateLinkServiceIPConfiguration.PrivateIPAddressVersion
        {
            get
            {
                return Inner.PrivateIPAddressVersion;
            }
        }

        string IPrivateLinkServiceIPConfiguration.Name
        {
            get
            {
                return Inner.Name;
            }
        }

        string IPrivateLinkServiceIPConfiguration.Etag
        {
            get
            {
                return Inner.Etag;
            }
        }

        string IPrivateLinkServiceIPConfiguration.Type
        {
            get
            {
                return Inner.Type;
            }
        }

        string IPrivateLinkServiceIPConfiguration.Id
        {
            get
            {
                return Inner.Id;
            }
        }
    }
}
