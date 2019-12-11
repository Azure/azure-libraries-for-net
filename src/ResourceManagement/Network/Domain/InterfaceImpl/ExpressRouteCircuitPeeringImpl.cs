// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class ExpressRouteCircuitPeeringImpl
    {
        /// <summary>
        /// Specify advertised prefixes: sets a list of all prefixes that are planned to advertise over the BGP session.
        /// Only public IP address prefixes are accepted. A set of prefixes can be sent as a comma-separated list.
        /// These prefixes must be registered to you in an RIR / IRR.
        /// </summary>
        /// <param name="publicPrefixes">Advertised prefixes.</param>
        /// <return>Next stage of definition.</return>
        ExpressRouteCircuitPeering.Definition.IWithPrimaryPeerAddressPrefix ExpressRouteCircuitPeering.Definition.IWithAdvertisedPublicPrefixes.WithAdvertisedPublicPrefixes(string publicPrefixes)
        {
            return this.WithAdvertisedPublicPrefixes(publicPrefixes);
        }

        ExpressRouteCircuitPeering.Update.IUpdate ExpressRouteCircuitPeering.Update.IWithAdvertisedPublicPrefixes.WithAdvertisedPublicPrefixes(string publicPrefixes)
        {
            return this.WithAdvertisedPublicPrefixes(publicPrefixes);
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id;
            }
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Network.Fluent.INetworkManager>.Manager
        {
            get
            {
                return this.Manager;
            }
        }

        ExpressRouteCircuitPeering.Definition.IWithVlanId ExpressRouteCircuitPeering.Definition.IWithSecondaryPeerAddressPrefix.WithSecondaryPeerAddressPrefix(string addressPrefix)
        {
            return this.WithSecondaryPeerAddressPrefix(addressPrefix);
        }

        ExpressRouteCircuitPeering.Update.IUpdate ExpressRouteCircuitPeering.Update.IWithSecondaryPeerAddressPrefix.WithSecondaryPeerAddressPrefix(string addressPrefix)
        {
            return this.WithSecondaryPeerAddressPrefix(addressPrefix);
        }

        /// <param name="vlanId">A valid VLAN ID to establish this peering on. No other peering in the circuit can use the same VLAN ID.</param>
        /// <return>Next stage of definition.</return>
        ExpressRouteCircuitPeering.Definition.IWithPeerAsn ExpressRouteCircuitPeering.Definition.IWithVlanId.WithVlanId(int vlanId)
        {
            return this.WithVlanId(vlanId);
        }

        ExpressRouteCircuitPeering.Update.IUpdate ExpressRouteCircuitPeering.Update.IWithVlanId.WithVlanId(int vlanId)
        {
            return this.WithVlanId(vlanId);
        }

        ExpressRouteCircuitPeering.Definition.IWithSecondaryPeerAddressPrefix ExpressRouteCircuitPeering.Definition.IWithPrimaryPeerAddressPrefix.WithPrimaryPeerAddressPrefix(string addressPrefix)
        {
            return this.WithPrimaryPeerAddressPrefix(addressPrefix);
        }

        ExpressRouteCircuitPeering.Update.IUpdate ExpressRouteCircuitPeering.Update.IWithPrimaryPeerAddressPrefix.WithPrimaryPeerAddressPrefix(string addressPrefix)
        {
            return this.WithPrimaryPeerAddressPrefix(addressPrefix);
        }

        /// <param name="peerAsn">AS number for peering. Both 2-byte and 4-byte AS numbers can be used.</param>
        /// <return>Next stage of definition.</return>
        ExpressRouteCircuitPeering.Definition.IWithCreate ExpressRouteCircuitPeering.Definition.IWithPeerAsn.WithPeerAsn(int peerAsn)
        {
            return this.WithPeerAsn(peerAsn);
        }

        ExpressRouteCircuitPeering.Update.IUpdate ExpressRouteCircuitPeering.Update.IWithPeerAsn.WithPeerAsn(int peerAsn)
        {
            return this.WithPeerAsn(peerAsn);
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Gets the Azure ASN.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.AzureAsn
        {
            get
            {
                return this.AzureAsn();
            }
        }

        /// <summary>
        /// Gets the primary port.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.PrimaryAzurePort
        {
            get
            {
                return this.PrimaryAzurePort();
            }
        }

        /// <summary>
        /// Gets the VLAN ID.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.VlanId
        {
            get
            {
                return this.VlanId();
            }
        }

        /// <summary>
        /// Gets the peer ASN.
        /// </summary>
        long Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.PeerAsn
        {
            get
            {
                return this.PeerAsn();
            }
        }

        /// <summary>
        /// Gets the state of peering.
        /// </summary>
        /// <summary>
        /// Gets peering state.
        /// </summary>
        Models.ExpressRoutePeeringState Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.State
        {
            get
            {
                return this.State();
            }
        }

        /// <summary>
        /// Gets whether the provider or the customer last modified the peering.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.LastModifiedBy
        {
            get
            {
                return this.LastModifiedBy();
            }
        }

        /// <summary>
        /// Gets peering type.
        /// </summary>
        Models.ExpressRoutePeeringType Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.PeeringType
        {
            get
            {
                return this.PeeringType();
            }
        }

        /// <summary>
        /// Gets the provisioning state of the resource.
        /// </summary>
        /// <summary>
        /// Gets provisioningState.
        /// </summary>
        ProvisioningState Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the secondary address prefix.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.SecondaryPeerAddressPrefix
        {
            get
            {
                return this.SecondaryPeerAddressPrefix();
            }
        }

        /// <summary>
        /// Gets the primary address prefix.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.PrimaryPeerAddressPrefix
        {
            get
            {
                return this.PrimaryPeerAddressPrefix();
            }
        }

        /// <summary>
        /// Gets the IPv6 peering configuration.
        /// </summary>
        Models.Ipv6ExpressRouteCircuitPeeringConfig Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.IPv6PeeringConfig
        {
            get
            {
                return this.IPv6PeeringConfig();
            }
        }

        /// <summary>
        /// Gets peering stats.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitStats Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.Stats
        {
            get
            {
                return this.Stats();
            }
        }

        /// <summary>
        /// Gets The Microsoft peering configuration.
        /// </summary>
        Models.ExpressRouteCircuitPeeringConfig Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.MicrosoftPeeringConfig
        {
            get
            {
                return this.MicrosoftPeeringConfig();
            }
        }

        /// <summary>
        /// Gets the secondary port.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.SecondaryAzurePort
        {
            get
            {
                return this.SecondaryAzurePort();
            }
        }

        /// <summary>
        /// Gets the shared key.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering.SharedKey
        {
            get
            {
                return this.SharedKey();
            }
        }
    }
}