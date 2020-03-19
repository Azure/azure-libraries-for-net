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
    /// The combined template containing all the settings that can be modified.
    /// </summary>
    public interface IUpdateCombined :
        IUpdate,
        IWithApplicationRuleCollectionSettings,
        IWithApplicationRuleSettings,
        IWithNatRuleCollectionSettings,
        IWithNatRuleSettings,
        IWithNetworkRuleCollectionSettings,
        IWithNetworkRuleSettings
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

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the application rule collection.
    /// </summary>
    public interface IWithApplicationRuleCollection
    {
        /// <summary>
        /// Sets the Azure firewall application rule collection.
        /// </summary>
        /// <param name="name">The name of application rule collection.</param>
        /// <return>The next stage of the update.</return>
        IWithApplicationRuleCollectionSettings DefineAzureFirewallApplicationRuleCollection(string name);

        /// <summary>
        /// Updates the Azure firewall application rule collection.
        /// </summary>
        /// <param name="name">The name of application rule collection.</param>
        /// <return>The next stage of the update.</return>
        IWithApplicationRuleCollectionSettings UpdateAzureFirewallApplicationRuleCollection(string name);

        /// <summary>
        /// Removes the Azure firewall application rule collection.
        /// </summary>
        /// <param name="name">The name of application rule collection.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutAzureFirewallApplicationRuleCollection(string name);
    }

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the application rule collection settings.
    /// </summary>
    public interface IWithApplicationRuleCollectionSettings :
        BaseRuleCollection.IWithPriority<IWithApplicationRuleCollectionSettings>,
        BaseRuleCollection.IWithRuleCollectionActionType<IWithApplicationRuleCollectionSettings>,
        ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<IUpdate>
    {
        /// <summary>
        /// Sets the Azure firewall application rule.
        /// </summary>
        /// <param name="name">The name of application rule.</param>
        /// <return>The next stage of the update.</return>
        IWithApplicationRuleSettings DefineAzureFirewallApplicationRule(string name);

        /// <summary>
        /// Updates the Azure firewall application rule.
        /// </summary>
        /// <param name="name">The name of application rule.</param>
        /// <return>The next stage of the update.</return>
        IWithApplicationRuleSettings UpdateAzureFirewallApplicationRule(string name);

        /// <summary>
        /// Removes the Azure firewall application rule.
        /// </summary>
        /// <param name="name">The name of application rule.</param>
        /// <return>The next stage of the update.</return>
        IWithApplicationRuleCollectionSettings WithoutAzureFirewallApplicationRule(string name);
    }

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the application rule settings.
    /// </summary>
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

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the nat rule collection.
    /// </summary>
    public interface IWithNatRuleCollection
    {
        /// <summary>
        /// Sets the Azure firewall nat rule collection.
        /// </summary>
        /// <param name="name">The name of nat rule collection.</param>
        /// <return>The next stage of the update.</return>
        IWithNatRuleCollectionSettings DefineAzureFirewallNatRuleCollection(string name);

        /// <summary>
        /// Updates the Azure firewall nat rule collection.
        /// </summary>
        /// <param name="name">The name of nat rule collection.</param>
        /// <return>The next stage of the update.</return>
        IWithNatRuleCollectionSettings UpdateAzureFirewallNatRuleCollection(string name);

        /// <summary>
        /// Removes the Azure firewall nat rule collection.
        /// </summary>
        /// <param name="name">The name of nat rule collection.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutAzureFirewallNatRuleCollection(string name);
    }

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the nat rule collection settings.
    /// </summary>
    public interface IWithNatRuleCollectionSettings :
        BaseRuleCollection.IWithPriority<IWithNatRuleCollectionSettings>,
        BaseRuleCollection.IWithNatRuleCollectionActionType<IWithNatRuleCollectionSettings>,
        ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<IUpdate>
    {
        /// <summary>
        /// Sets the Azure firewall nat rule.
        /// </summary>
        /// <param name="name">The name of nat rule.</param>
        /// <return>The next stage of the update.</return>
        IWithNatRuleSettings DefineAzureFirewallNatRule(string name);

        /// <summary>
        /// Updates the Azure firewall nat rule.
        /// </summary>
        /// <param name="name">The name of nat rule.</param>
        /// <return>The next stage of the update.</return>
        IWithNatRuleSettings UpdateAzureFirewallNatRule(string name);

        /// <summary>
        /// Removes the Azure firewall nat rule.
        /// </summary>
        /// <param name="name">The name of nat rule.</param>
        /// <return>The next stage of the update.</return>
        IWithNatRuleCollectionSettings WithoutAzureFirewallNatRule(string name);
    }

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the nat rule settings.
    /// </summary>
    public interface IWithNatRuleSettings :
        BaseRule.IWithDescription<IWithNatRuleSettings>,
        BaseRule.IWithSourceAddress<IWithNatRuleSettings>,
        BaseRule.IWithDestinationAddress<IWithNatRuleSettings>,
        BaseRule.IWithDestinationPort<IWithNatRuleSettings>,
        BaseRule.IWithRuleProtocol<IWithNatRuleSettings>,
        ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<IWithNatRuleCollectionSettings>
    {
    }

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the network rule collection.
    /// </summary>
    public interface IWithNetworkRuleCollection
    {
        /// <summary>
        /// Sets the Azure firewall network rule collection.
        /// </summary>
        /// <param name="name">The name of network rule collection.</param>
        /// <return>The next stage of the update.</return>
        IWithNetworkRuleCollectionSettings DefineAzureFirewallNetworkRuleCollection(string name);

        /// <summary>
        /// Updates the Azure firewall network rule collection.
        /// </summary>
        /// <param name="name">The name of network rule collection.</param>
        /// <return>The next stage of the update.</return>
        IWithNetworkRuleCollectionSettings UpdateAzureFirewallNetworkRuleCollection(string name);

        /// <summary>
        /// Removes the Azure firewall network rule collection.
        /// </summary>
        /// <param name="name">The name of network rule collection.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutAzureFirewallNetworkRuleCollection(string name);
    }

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the network rule collection settings.
    /// </summary>
    public interface IWithNetworkRuleCollectionSettings :
        BaseRuleCollection.IWithPriority<IWithNetworkRuleCollectionSettings>,
        BaseRuleCollection.IWithRuleCollectionActionType<IWithNetworkRuleCollectionSettings>,
        ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<IUpdate>
    {
        /// <summary>
        /// Sets the Azure firewall network rule.
        /// </summary>
        /// <param name="name">The name of network rule.</param>
        /// <return>The next stage of the update.</return>
        IWithNetworkRuleSettings DefineAzureFirewallNetworkRule(string name);

        /// <summary>
        /// Updates the Azure firewall network rule.
        /// </summary>
        /// <param name="name">The name of network rule.</param>
        /// <return>The next stage of the update.</return>
        IWithNetworkRuleSettings UpdateAzureFirewallNetworkRule(string name);

        /// <summary>
        /// Removes the Azure firewall network rule.
        /// </summary>
        /// <param name="name">The name of network rule.</param>
        /// <return>The next stage of the update.</return>
        IWithNetworkRuleCollectionSettings WithoutAzureFirewallNetworkRule(string name);
    }

    /// <summary>
    /// The stage of the Azure firewall update allowing to specify the network rule settings.
    /// </summary>
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
