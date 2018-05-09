// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Network.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for Virtual Network management API in Azure.
    /// </summary>
    public interface INetwork :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Network.Fluent.INetworkManager, Models.VirtualNetworkInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetwork>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Network.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.IUpdatableWithTags<Microsoft.Azure.Management.Network.Fluent.INetwork>,
        Microsoft.Azure.Management.Network.Fluent.INetworkBeta
    {
        /// <summary>
        /// Gets list of address spaces associated with this virtual network, in the CIDR notation.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> AddressSpaces { get; }

        /// <summary>
        /// Gets the DDoS protection plan id associated with the virtual network.
        /// </summary>
        string DdosProtectionPlanId { get; }

        /// <summary>
        /// Gets list of DNS server IP addresses associated with this virtual network.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> DnsServerIPs { get; }

        /// <summary>
        /// Gets whether DDoS protection is enabled for all the protected resources
        /// in the virtual network. It requires a DDoS protection plan associated with the resource.
        /// </summary>
        bool IsDdosProtectionEnabled { get; }

        /// <summary>
        /// Gets whether VM protection is enabled for all the subnets in the virtual network.
        /// </summary>
        bool IsVmProtectionEnabled { get; }

        /// <summary>
        /// Gets subnets of this virtual network as a map indexed by subnet name
        /// Note that when a virtual network is created with no subnets explicitly defined, a default subnet is
        /// automatically created with the name "subnet1".
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ISubnet> Subnets { get; }
    }

    /// <summary>
    /// Entry point for Virtual Network management API in Azure.
    /// </summary>
    public interface INetworkBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Checks if the specified private IP address is available in this network.
        /// </summary>
        /// <param name="ipAddress">An IP address from this network's address space.</param>
        /// <return>True if the address is within this network's address space and is available.</return>
        bool IsPrivateIPAddressAvailable(string ipAddress);

        /// <summary>
        /// Checks if the specified private IP address is within this network's address space.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>True if the specified IP address is within this network's address space, otherwise false.</return>
        bool IsPrivateIPAddressInNetwork(string ipAddress);

        /// <summary>
        /// Gets entry point to managing virtual network peerings for this network.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkPeerings Peerings { get; }
    }
}