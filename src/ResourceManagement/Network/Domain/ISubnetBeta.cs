// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;

    /// <summary>
    /// A client-side representation of a subnet of a virtual network.
    /// </summary>
    public interface ISubnetBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <return>Available private IP addresses within this network.</return>
        System.Collections.Generic.ISet<string> ListAvailablePrivateIPAddresses();

        /// <summary>
        /// Gets the services that has access to the subnet.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<ServiceEndpointType, System.Collections.Generic.List<Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region>> ServicesWithAccess { get; }
    }
}