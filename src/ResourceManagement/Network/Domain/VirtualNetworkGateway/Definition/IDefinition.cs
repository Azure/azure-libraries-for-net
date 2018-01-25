// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of virtual network gateway definition allowing to specify SKU.
    /// </summary>
    public interface IWithSku
    {
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithCreate WithSku(VirtualNetworkGatewaySkuName skuName);
    }

    /// <summary>
    /// The stage of virtual network gateway definition allowing to specify public IP address for IP configuration.
    /// </summary>
    public interface IWithPublicIPAddress :
        Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition.IWithPublicIPAddressNoDnsLabel<Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the virtual network gateway definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithNetwork>
    {
    }

    /// <summary>
    /// The entirety of the virtual network gateway definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithGroup,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithGatewayType,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithSku,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithNetwork,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithBgp,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The first stage of a virtual network gateway definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of definition allowing to specify virtual network gateway's BGP speaker settings.
    /// Note: BGP is supported on Route-Based VPN gateways only.
    /// </summary>
    public interface IWithBgp
    {
        /// <param name="asn">The BGP speaker's ASN.</param>
        /// <param name="bgpPeeringAddress">The BGP peering address and BGP identifier of this BGP speaker.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithCreate WithBgp(long asn, string bgpPeeringAddress);
    }

    /// <summary>
    /// The stage of virtual network gateway definition allowing to specify virtual network gateway type.
    /// </summary>
    public interface IWithGatewayType
    {
        /// <summary>
        /// Use Express route gateway type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithSku WithExpressRoute();

        /// <summary>
        /// Use Policy-based VPN type. Note: this is available only for Basic SKU.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithCreate WithPolicyBasedVpn();

        /// <summary>
        /// Use Route-based VPN type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithSku WithRouteBasedVpn();
    }

    /// <summary>
    /// The stage of the virtual network gateway definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithCreate>,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithPublicIPAddress,
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithBgp
    {
    }

    /// <summary>
    /// The stage of the virtual network gateway definition allowing to specify the virtual network.
    /// </summary>
    public interface IWithNetwork
    {
        /// <summary>
        /// Create a new virtual network to associate with the virtual network gateway,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithGatewayType WithNewNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable);

        /// <summary>
        /// Creates a new virtual network to associate with the virtual network gateway.
        /// the virtual network will be created in the same resource group and region as of parent
        /// virtual network gateway, it will be created with the specified address space and a subnet for virtual network gateway.
        /// </summary>
        /// <param name="name">The name of the new virtual network.</param>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <param name="subnetAddressSpaceCidr">The address space for the subnet.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithGatewayType WithNewNetwork(string name, string addressSpace, string subnetAddressSpaceCidr);

        /// <summary>
        /// Creates a new virtual network to associate with the virtual network gateway.
        /// the virtual network will be created in the same resource group and region as of parent virtual network gateway,
        /// it will be created with the specified address space and a default subnet for virtual network gateway.
        /// </summary>
        /// <param name="addressSpaceCidr">The address space for the virtual network.</param>
        /// <param name="subnetAddressSpaceCidr">The address space for the subnet.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithGatewayType WithNewNetwork(string addressSpaceCidr, string subnetAddressSpaceCidr);

        /// <summary>
        /// Associate an existing virtual network with the virtual network gateway .
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition.IWithGatewayType WithExistingNetwork(INetwork network);
    }
}