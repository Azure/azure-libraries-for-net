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
    public interface INetworkBeta  :
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