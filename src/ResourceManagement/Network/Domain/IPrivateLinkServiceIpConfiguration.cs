// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;

    /// <summary>
    /// Entry point for private link service IP configuration management API in Azure.
    /// </summary>
    public interface IPrivateLinkServiceIPConfiguration
    {
        /// <summary>
        /// Gets the private IP address of the IP configuration.
        /// </summary>
        string PrivateIPAddress { get; }

        /// <summary>
        /// Gets the private IP address allocation method. Possible values include: 'Static', 'Dynamic'
        /// </summary>
        IPAllocationMethod PrivateIPAllocationMethod { get; }

        /// <summary>
        /// Gets the reference to the subnet resource.
        /// </summary>
        string SubnetId { get; }

        /// <summary>
        /// Gets whether the ip configuration is primary or not.
        /// </summary>
        bool Primary { get; }

        /// <summary>
        /// Gets the provisioning state of the private link service IP
        /// configuration resource. Possible values include: 'Succeeded',
        /// 'Updating', 'Deleting', 'Failed'
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets whether the specific IP configuration is IPv4 or IPv6.
        /// Default is IPv4. Possible values include: 'IPv4', 'IPv6'
        /// </summary>
        IPVersion PrivateIPAddressVersion { get; }

        /// <summary>
        /// Gets the name of private link service IP configuration.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource is updated.
        /// </summary>
        string Etag { get; }

        /// <summary>
        /// Gets the resource type.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets ID of the resource.
        /// </summary>
        string Id { get; }
    }
}
