// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal class AzureFirewallIpConfigurationImpl :
        Wrapper<AzureFirewallIPConfigurationInner>,
        IAzureFirewallIpConfiguration
    {
        internal AzureFirewallIpConfigurationImpl(AzureFirewallIPConfigurationInner inner)
            : base(inner)
        {
        }

        string IAzureFirewallIpConfiguration.PrivateIPAddress
        {
            get
            {
                return Inner.PrivateIPAddress;
            }
        }

        string IAzureFirewallIpConfiguration.SubnetId
        {
            get
            {
                return Inner.Subnet == null ? null : Inner.Subnet.Id;
            }
        }

        string IAzureFirewallIpConfiguration.PublicIPAddressId
        {
            get
            {
                return Inner.PublicIPAddress == null ? null : Inner.PublicIPAddress.Id;
            }
        }

        ProvisioningState IAzureFirewallIpConfiguration.ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
            }
        }

        string IAzureFirewallIpConfiguration.Name
        {
            get
            {
                return Inner.Name;
            }
        }

        string IAzureFirewallIpConfiguration.Etag
        {
            get
            {
                return Inner.Etag;
            }
        }

        string IAzureFirewallIpConfiguration.Id
        {
            get
            {
                return Inner.Id;
            }
        }
    }
}
