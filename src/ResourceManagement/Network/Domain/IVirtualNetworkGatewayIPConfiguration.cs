// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A client-side representation of an virtual network gateway IP configuration.
    /// </summary>
    public interface IVirtualNetworkGatewayIPConfiguration :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.VirtualNetworkGatewayIPConfigurationInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway>
    {
        /// <return>
        /// The subnet the virtual network gateway is in
        /// Note, this results in a separate call to Azure.
        /// </return>
        Microsoft.Azure.Management.Network.Fluent.ISubnet GetSubnet();

        /// <summary>
        /// Gets the private IP allocation method. Possible values are: 'Static' and
        /// 'Dynamic'.
        /// </summary>
        Models.IPAllocationMethod PrivateIPAllocationMethod { get; }

        /// <summary>
        /// Gets the resource id of associated public IP address.
        /// </summary>
        string PublicIPAddressId { get; }

        /// <summary>
        /// Gets the resource ID of the virtual network the application gateway is in.
        /// </summary>
        string NetworkId { get; }

        /// <summary>
        /// Gets the name of the subnet the virtual network gateway is in.
        /// </summary>
        string SubnetName { get; }
    }
}