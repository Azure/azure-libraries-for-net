// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class LocalNetworkGatewayImpl
    {
        /// <summary>
        /// Remove address space. Note: address space will be removed only in case of exact cidr string match.
        /// </summary>
        /// <param name="cidr">The CIDR representation of the local network site address space.</param>
        /// <return>The next stage of the update.</return>
        LocalNetworkGateway.Update.IUpdate LocalNetworkGateway.Update.IWithAddressSpace.WithoutAddressSpace(string cidr)
        {
            return this.WithoutAddressSpace(cidr);
        }

        /// <summary>
        /// Execute the update request.
        /// </summary>
        /// <return>The updated resource.</return>
        Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway Microsoft.Azure.Management.Network.Fluent.IAppliableWithTags<Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway>.ApplyTags()
        {
            return this.ApplyTags();
        }

        /// <summary>
        /// Execute the update request asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway> Microsoft.Azure.Management.Network.Fluent.IAppliableWithTags<Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway>.ApplyTagsAsync(CancellationToken cancellationToken)
        {
            return await this.ApplyTagsAsync(cancellationToken);
        }

        /// <summary>
        /// Begins a tags update for a resource.
        /// This is the beginning of the builder pattern used to update tags for a resources
        /// in Azure. The final method completing the definition and starting the actual resource update
        /// process in Azure is  AppliableWithTags.applyTags().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        UpdatableWithTags.UpdatableWithTags.IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway> Microsoft.Azure.Management.Network.Fluent.IUpdatableWithTags<Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway>.UpdateTags()
        {
            return this.UpdateTags();
        }

        public IAppliableWithTags<ILocalNetworkGateway> WithoutTag(string key)
        {
            return base.WithoutTag(key);
        }

        public IAppliableWithTags<ILocalNetworkGateway> WithTag(string key, string value)
        {
            return base.WithTag(key, value);
        }

        public IAppliableWithTags<ILocalNetworkGateway> WithTags(IDictionary<string, string> tags)
        {
            return base.WithTags(tags);
        }

        /// <summary>
        /// Adds address space.
        /// Note: this method's effect is additive, i.e. each time it is used, a new address space is added to the network.
        /// </summary>
        /// <param name="cidr">The CIDR representation of the local network site address space.</param>
        /// <return>The next stage of the update.</return>
        LocalNetworkGateway.Update.IUpdate LocalNetworkGateway.Update.IWithAddressSpace.WithAddressSpace(string cidr)
        {
            return this.WithAddressSpace(cidr);
        }

        /// <summary>
        /// Adds address space.
        /// Note: this method's effect is additive, i.e. each time it is used, a new address space is added to the network.
        /// </summary>
        /// <param name="cidr">The CIDR representation of the local network site address space.</param>
        LocalNetworkGateway.Definition.IWithCreate LocalNetworkGateway.Definition.IWithAddressSpace.WithAddressSpace(string cidr)
        {
            return this.WithAddressSpace(cidr);
        }

        /// <summary>
        /// Gets local network site address spaces.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway.AddressSpaces
        {
            get
            {
                return this.AddressSpaces();
            }
        }

        /// <summary>
        /// Gets the provisioning state of the LocalNetworkGateway resource.
        /// </summary>
        ProvisioningState Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets local network gateway's BGP speaker settings.
        /// </summary>
        Models.BgpSettings Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway.BgpSettings
        {
            get
            {
                return this.BgpSettings();
            }
        }

        /// <summary>
        /// Gets IP address of local network gateway.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway.IPAddress
        {
            get
            {
                return this.IPAddress();
            }
        }

        LocalNetworkGateway.Update.IUpdate LocalNetworkGateway.Update.IWithIPAddress.WithIPAddress(string ipAddress)
        {
            return this.WithIPAddress(ipAddress);
        }

        /// <summary>
        /// Specifies the IP address of the local network gateway.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the definition.</return>
        LocalNetworkGateway.Definition.IWithAddressSpace LocalNetworkGateway.Definition.IWithIPAddress.WithIPAddress(string ipAddress)
        {
            return this.WithIPAddress(ipAddress);
        }

        /// <summary>
        /// Enables BGP.
        /// </summary>
        /// <param name="asn">The BGP speaker's ASN.</param>
        /// <param name="bgpPeeringAddress">The BGP peering address and BGP identifier of this BGP speaker.</param>
        /// <return>The next stage of the update.</return>
        LocalNetworkGateway.Update.IUpdate LocalNetworkGateway.Update.IWithBgp.WithBgp(long asn, string bgpPeeringAddress)
        {
            return this.WithBgp(asn, bgpPeeringAddress);
        }

        /// <summary>
        /// Disables BGP.
        /// </summary>
        /// <return>The next stage of the update.</return>
        LocalNetworkGateway.Update.IUpdate LocalNetworkGateway.Update.IWithBgp.WithoutBgp()
        {
            return this.WithoutBgp();
        }

        /// <summary>
        /// Enables BGP.
        /// </summary>
        /// <param name="asn">The BGP speaker's ASN.</param>
        /// <param name="bgpPeeringAddress">The BGP peering address and BGP identifier of this BGP speaker.</param>
        /// <return>The next stage of the definition.</return>
        LocalNetworkGateway.Definition.IWithCreate LocalNetworkGateway.Definition.IWithBgp.WithBgp(long asn, string bgpPeeringAddress)
        {
            return this.WithBgp(asn, bgpPeeringAddress);
        }
    }
}