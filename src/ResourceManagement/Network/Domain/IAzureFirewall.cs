// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for Azure firewall management API in Azure.
    /// </summary>
    public interface IAzureFirewall :
        IGroupableResource<INetworkManager, AzureFirewallInner>,
        IRefreshable<IAzureFirewall>,
        IUpdatable<AzureFirewall.Update.IUpdate>
    {
        /// <summary>
        /// Gets collection of application rule collections used by Azure Firewall.
        /// </summary>
        IReadOnlyList<IAzureFirewallApplicationRuleCollection> ApplicationRuleCollections { get; }

        /// <summary>
        /// Gets collection of NAT rule collections used by Azure Firewall.
        /// </summary>
        IReadOnlyList<IAzureFirewallNatRuleCollection> NatRuleCollections { get; }

        /// <summary>
        /// Gets collection of network rule collections used by Azure Firewall.
        /// </summary>
        IReadOnlyList<IAzureFirewallNetworkRuleCollection> NetworkRuleCollections { get; }

        /// <summary>
        /// Gets IP configuration of the Azure Firewall resource.
        /// </summary>
        IReadOnlyList<IAzureFirewallIpConfiguration> IpConfigurations { get; }

        /// <summary>
        /// Gets the provisioning state of the Azure firewall resource.
        /// Possible values include: 'Succeeded', 'Updating', 'Deleting',
        /// 'Failed'
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets or sets the operation mode for Threat Intelligence. Possible
        /// values include: 'Alert', 'Deny', 'Off'
        /// </summary>
        AzureFirewallThreatIntelMode ThreatIntelMode { get; }

        /// <summary>
        /// Gets the virtualHub to which the firewall belongs.
        /// </summary>
        string VirtualHubId { get; }

        /// <summary>
        /// Gets the firewall policy associated with this Azure firewall.
        /// </summary>
        string FirewallPolicyId { get; }

        /// <summary>
        /// Gets IP addresses associated with Azure firewall.
        /// </summary>
        HubIPAddresses HubIPAddresses { get; }

        /// <summary>
        /// Gets the Azure firewall resource SKU.
        /// </summary>
        AzureFirewallSku Sku { get; }

        /// <summary>
        /// Gets the additional properties used to further config this Azure firewall.
        /// </summary>
        IReadOnlyDictionary<string, string> AdditionalProperties { get; }

        /// <summary>
        /// Gets a list of availability zones denoting where the resource needs to come from.
        /// </summary>
        IReadOnlyList<string> Zones { get; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource is updated.
        /// </summary>
        string Etag { get; }
    }
}
