// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;

    /// <summary>
    /// Entry point for Azure firewall IP configuration management API in Azure.
    /// </summary>
    public interface IAzureFirewallIpConfiguration
    {
        /// <summary>
        /// Gets the Firewall Internal Load Balancer IP to be used as the next
        /// hop in User Defined Routes.
        /// </summary>
        string PrivateIPAddress { get; }

        /// <summary>
        /// Gets reference of the subnet resource. This value must be 'AzureFirewallSubnet'.
        /// </summary>
        string SubnetId { get; }

        /// <summary>
        /// Gets reference of the PublicIP resource.
        /// </summary>
        string PublicIPAddressId { get; }

        /// <summary>
        /// Gets the provisioning state of the Azure firewall IP configuration
        /// resource. Possible values include: 'Succeeded', 'Updating',
        /// 'Deleting', 'Failed'.
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets name of the resource.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated.
        /// </summary>
        string Etag { get; }

        /// <summary>
        /// Gets the ID of the resource.
        /// </summary>
        string Id { get; }
    }
}
