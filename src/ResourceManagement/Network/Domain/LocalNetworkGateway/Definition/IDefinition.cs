// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The entirety of the local network gateway definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Definition.IWithGroup,
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Definition.IWithIPAddress,
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of definition allowing to specify local network gateway's BGP speaker settings.
    /// </summary>
    public interface IWithBgp
    {
        /// <summary>
        /// Enables BGP.
        /// </summary>
        /// <param name="asn">The BGP speaker's ASN.</param>
        /// <param name="bgpPeeringAddress">The BGP peering address and BGP identifier of this BGP speaker.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Definition.IWithCreate WithBgp(long asn, string bgpPeeringAddress);
    }

    /// <summary>
    /// The stage of the local network gateway definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Definition.IWithIPAddress>
    {
    }

    /// <summary>
    /// The stage of the local network gateway definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()).
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Definition.IWithCreate>,
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Definition.IWithAddressSpace,
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Definition.IWithBgp
    {
    }

    /// <summary>
    /// The stage of the local network gateway definition allowing to specify the address space.
    /// </summary>
    public interface IWithAddressSpace
    {
        /// <summary>
        /// Adds address space.
        /// Note: this method's effect is additive, i.e. each time it is used, a new address space is added to the network.
        /// </summary>
        /// <param name="cidr">The CIDR representation of the local network site address space.</param>
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Definition.IWithCreate WithAddressSpace(string cidr);
    }

    /// <summary>
    /// The first stage of a local network gateway definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the local network gateway definition allowing to specify IP address of local network gateway.
    /// </summary>
    public interface IWithIPAddress
    {
        /// <summary>
        /// Specifies the IP address of the local network gateway.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Definition.IWithAddressSpace WithIPAddress(string ipAddress);
    }
}