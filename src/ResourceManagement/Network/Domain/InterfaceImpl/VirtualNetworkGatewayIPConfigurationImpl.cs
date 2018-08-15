// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.Definition;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    internal partial class VirtualNetworkGatewayIPConfigurationImpl
    {
        /// <summary>
        /// Gets the resource id of associated public IP address.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayIPConfiguration.PublicIPAddressId
        {
            get
            {
                return this.PublicIPAddressId();
            }
        }

        /// <summary>
        /// Gets the name of the subnet the virtual network gateway is in.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayIPConfiguration.SubnetName
        {
            get
            {
                return this.SubnetName();
            }
        }

        /// <return>
        /// The subnet the virtual network gateway is in
        /// Note, this results in a separate call to Azure.
        /// </return>
        Microsoft.Azure.Management.Network.Fluent.ISubnet Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayIPConfiguration.GetSubnet()
        {
            return this.GetSubnet();
        }

        /// <summary>
        /// Gets the resource ID of the virtual network the application gateway is in.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayIPConfiguration.NetworkId
        {
            get
            {
                return this.NetworkId();
            }
        }

        /// <summary>
        /// Gets the private IP allocation method. Possible values are: 'Static' and
        /// 'Dynamic'.
        /// </summary>
        Models.IPAllocationMethod Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGatewayIPConfiguration.PrivateIPAllocationMethod
        {
            get
            {
                return this.PrivateIPAllocationMethod();
            }
        }

        /// <summary>
        /// Assigns the specified subnet to this resource.
        /// </summary>
        /// <param name="parentNetworkResourceId">The resource ID of the virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGatewayIPConfiguration.Definition.IWithAttach<VirtualNetworkGateway.Definition.IWithCreate> Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Definition.IWithSubnet<VirtualNetworkGatewayIPConfiguration.Definition.IWithAttach<VirtualNetworkGateway.Definition.IWithCreate>>.WithExistingSubnet(string parentNetworkResourceId, string subnetName)
        {
            return this.WithExistingSubnet(parentNetworkResourceId, subnetName);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        VirtualNetworkGateway.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<VirtualNetworkGateway.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGatewayIPConfiguration.Definition.IWithAttach<VirtualNetworkGateway.Definition.IWithCreate> HasPublicIPAddress.Definition.IWithExistingPublicIPAddress<VirtualNetworkGatewayIPConfiguration.Definition.IWithAttach<VirtualNetworkGateway.Definition.IWithCreate>>.WithExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.WithExistingPublicIPAddress(publicIPAddress);
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGatewayIPConfiguration.Definition.IWithAttach<VirtualNetworkGateway.Definition.IWithCreate> HasPublicIPAddress.Definition.IWithExistingPublicIPAddress<VirtualNetworkGatewayIPConfiguration.Definition.IWithAttach<VirtualNetworkGateway.Definition.IWithCreate>>.WithExistingPublicIPAddress(string resourceId)
        {
            return this.WithExistingPublicIPAddress(resourceId);
        }

        /// <summary>
        /// Specifies an existing subnet the virtual network gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGatewayIPConfiguration.Definition.IWithAttach<VirtualNetworkGateway.Definition.IWithCreate> VirtualNetworkGatewayIPConfiguration.Definition.IWithSubnet<VirtualNetworkGateway.Definition.IWithCreate>.WithExistingSubnet(ISubnet subnet)
        {
            return this.WithExistingSubnet(subnet);
        }

        /// <summary>
        /// Specifies an existing subnet the virtual network gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The name of a subnet within the selected network.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkGatewayIPConfiguration.Definition.IWithAttach<VirtualNetworkGateway.Definition.IWithCreate> VirtualNetworkGatewayIPConfiguration.Definition.IWithSubnet<VirtualNetworkGateway.Definition.IWithCreate>.WithExistingSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingSubnet(network, subnetName);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        VirtualNetworkGateway.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<VirtualNetworkGateway.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }
    }
}