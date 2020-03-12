// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.AzureFirewall.Update
{
    using System.Collections.Generic;

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// Call  Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate :
        ResourceManager.Fluent.Core.ResourceActions.IAppliable<IAzureFirewall>,
        ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<IUpdate>,
        IWithThreatIntelMode,
        IWithVirtualHub,
        IWithFirewallPolicy,
        IWithSku,
        IWithAdditionalProperty,
        IWithZones,
        IWithApplicationRuleCollection,
        IWithNatRuleCollection,
        IWithNetworkRuleCollection
    {
    }

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the operation mode of threat intelligence.
    /// </summary>
    public interface IWithThreatIntelMode
    {
        /// <summary>
        /// Enables the operation mode as 'Alert' for threat intelligence.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate WithAlertModeForThreatIntel();

        /// <summary>
        /// Enables the operation mode as 'Deny' for threat intelligence.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate WithDenyModeForThreatIntel();

        /// <summary>
        /// Enables the operation mode as 'Off' for threat intelligence.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate WithOffModeForThreatIntel();
    }

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the virtual hub.
    /// </summary>
    public interface IWithVirtualHub
    {
        /// <summary>
        /// Sets the virtual hub to which the firewall belongs.
        /// </summary>
        /// <param name="virtualHubId">The ID of virtual hub.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithVirtualHub(string virtualHubId);
    }

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the firewall policy.
    /// </summary>
    public interface IWithFirewallPolicy
    {
        /// <summary>
        /// Sets the firewall policy to which the firewall belongs.
        /// </summary>
        /// <param name="firewallPolicyId">The ID of firewall policy.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithFirewallPolicy(string firewallPolicyId);
    }

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the firewall resource SKU.
    /// </summary>
    public interface IWithSku
    {
        /// <summary>
        /// Sets the resource SKU name to 'AZFW_VNet'.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate WithAzureFirewallVnetSkuName();

        /// <summary>
        /// Sets the resource SKU name to 'AZFW_Hub'.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate WithAzureFirewallHubSkuName();
    }

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the additional properties used to further config.
    /// </summary>
    public interface IWithAdditionalProperty
    {
        /// <summary>
        /// Sets the the additional properties used to further config.
        /// </summary>
        /// <param name="key">The key of additional properties.</param>
        /// <param name="value">The value of additional properties.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithAdditionalProperty(string key, string value);

        /// <summary>
        /// Sets the the additional properties used to further config.
        /// </summary>
        /// <param name="additionalProperties">The additional properties.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithAdditionalProperties(IDictionary<string, string> additionalProperties);

        /// <summary>
        /// Removes the additional properties used to further config.
        /// </summary>
        /// <param name="key">The key of additional properties.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutAdditionalProperty(string key);
    }

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the list of availability zones.
    /// </summary>
    public interface IWithZones
    {
        /// <summary>
        /// Sets the availability zone denoting where the resource needs to come from.
        /// </summary>
        /// <param name="zone">The availability zone.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithZone(string zone);

        /// <summary>
        /// Sets the list of availability zones denoting where the resource needs to come from.
        /// </summary>
        /// <param name="zones">The list of availability zone.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithZones(IList<string> zones);

        /// <summary>
        /// Removes the availability zone denoting where the resource needs to come from.
        /// </summary>
        /// <param name="zone">The availability zone.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutZone(string zone);
    }

    public interface IWithApplicationRuleCollection
    {
        IWithApplicationRuleCollectionSettings DefineAzureFirewallApplicationRuleCollection(string name);

        IWithApplicationRuleCollectionSettings UpdateAzureFirewallApplicationRuleCollection(string name);

        IUpdate WithoutAzureFirewallApplicationRuleCollection(string name);
    }

    public interface IWithApplicationRuleCollectionSettings :
        BaseRuleCollection.IWithPriority<IWithApplicationRuleCollectionSettings>,
        BaseRuleCollection.IWithRuleCollectionActionType<IWithApplicationRuleCollectionSettings>,
        ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<IUpdate>
    {
        IWithApplicationRuleSettings DefineAzureFirewallApplicationRule(string name);

        IWithApplicationRuleSettings UpdateAzureFirewallApplicationRule(string name);

        IWithApplicationRuleCollectionSettings WithoutAzureFirewallApplicationRule(string name);
    }

    public interface IWithApplicationRuleSettings :
        BaseRule.IWithDescription<IWithApplicationRuleSettings>,
        BaseRule.IWithSourceAddress<IWithApplicationRuleSettings>,
        BaseRule.IWithApplicationRuleProtocol<IWithApplicationRuleSettings>,
        BaseRule.IWithTargetFqdn<IWithApplicationRuleSettings>,
        BaseRule.IWithFqdnTag<IWithApplicationRuleSettings>,
        BaseRule.IWithSourceIpGroup<IWithApplicationRuleSettings>,
        ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<IWithApplicationRuleCollectionSettings>
    {
    }

    public interface IWithNatRuleCollection
    {
        IWithNatRuleCollectionSettings DefineAzureFirewallNatRuleCollection(string name);

        IWithNatRuleCollectionSettings UpdateAzureFirewallNatRuleCollection(string name);

        IUpdate WithoutAzureFirewallNatRuleCollection(string name);
    }

    public interface IWithNatRuleCollectionSettings :
        BaseRuleCollection.IWithPriority<IWithNatRuleCollectionSettings>,
        BaseRuleCollection.IWithNatRuleCollectionActionType<IWithNatRuleCollectionSettings>,
        ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<IUpdate>
    {
        IWithNatRuleSettings DefineAzureFirewallNatRule(string name);

        IWithNatRuleSettings UpdateAzureFirewallNatRule(string name);

        IWithNatRuleCollectionSettings WithoutAzureFirewallNatRule(string name);
    }

    public interface IWithNatRuleSettings :
        BaseRule.IWithDescription<IWithNatRuleSettings>,
        BaseRule.IWithSourceAddress<IWithNatRuleSettings>,
        BaseRule.IWithDestinationAddress<IWithNatRuleSettings>,
        BaseRule.IWithDestinationPort<IWithNatRuleSettings>,
        BaseRule.IWithRuleProtocol<IWithNatRuleSettings>,
        ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<IWithNatRuleCollectionSettings>
    {
    }

    public interface IWithNetworkRuleCollection
    {
        IWithNetworkRuleCollectionSettings DefineAzureFirewallNetworkRuleCollection(string name);

        IWithNetworkRuleCollectionSettings UpdateAzureFirewallNetworkRuleCollection(string name);

        IUpdate WithoutAzureFirewallNetworkRuleCollection(string name);
    }

    public interface IWithNetworkRuleCollectionSettings :
        BaseRuleCollection.IWithPriority<IWithNetworkRuleCollectionSettings>,
        BaseRuleCollection.IWithRuleCollectionActionType<IWithNetworkRuleCollectionSettings>,
        ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<IUpdate>
    {
        IWithNetworkRuleSettings DefineAzureFirewallNetworkRule(string name);

        IWithNetworkRuleSettings UpdateAzureFirewallNetworkRule(string name);

        IWithNetworkRuleCollectionSettings WithoutAzureFirewallNetworkRule(string name);
    }

    public interface IWithNetworkRuleSettings :
        BaseRule.IWithDescription<IWithNetworkRuleSettings>,
        BaseRule.IWithRuleProtocol<IWithNetworkRuleSettings>,
        BaseRule.IWithSourceAddress<IWithNetworkRuleSettings>,
        BaseRule.IWithDestinationAddress<IWithNetworkRuleSettings>,
        BaseRule.IWithDestinationPort<IWithNetworkRuleSettings>,
        BaseRule.IWithDestinationFqdn<IWithNetworkRuleSettings>,
        BaseRule.IWithSourceIpGroup<IWithNetworkRuleSettings>,
        BaseRule.IWithDestinationIpGroup<IWithNetworkRuleSettings>,
        ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<IWithNetworkRuleCollectionSettings>
    {
    }
}
