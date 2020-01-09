// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.AzureFirewall.Definition
{
    using System.Collections.Generic;

    /// <summary>
    /// The entirety of the Azure firewall definition.
    /// </summary>
    public interface IDefinition :
        IBlank,
        IWithCreate,
        IWithApplicationRuleCollectionSettings,
        IWithApplicationRuleSettings,
        IWithNatRuleCollectionSettings,
        IWithNatRuleSettings,
        IWithNetworkRuleCollectionSettings,
        IWithIpConfigurationSettings,
        IWithNetworkRuleSettings
    {
    }

    /// <summary>
    /// The first stage of Azure firewall definition.
    /// </summary>
    public interface IBlank :
        ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroupAndRegion<IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// (via  WithCreate.create()), but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        ResourceManager.Fluent.Core.ResourceActions.ICreatable<IAzureFirewall>,
        ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<IWithCreate>,
        ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<IWithCreate>,
        IWithAdditionalProperty,
        IWithApplicationRuleCollection,
        IWithNatRuleCollection,
        IWithNetworkRuleCollection,
        IWithFirewallPolicy,
        IWithIpConfiguration,
        IWithSku,
        IWithThreatIntelMode,
        IWithVirtualHub,
        IWithZones
    {
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify application rule collection.
    /// </summary>
    public interface IWithApplicationRuleCollection
    {
        /// <summary>
        /// Sets the Azure firewall application rule collection.
        /// </summary>
        /// <param name="name">The name of application rule collection.</param>
        /// <return>The next stage of the definition.</return>
        IWithApplicationRuleCollectionSettings DefineAzureFirewallApplicationRuleCollection(string name);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify application rule collection settings.
    /// </summary>
    public interface IWithApplicationRuleCollectionSettings :
        BaseRuleCollection.IWithPriority<IWithApplicationRuleCollectionSettings>,
        BaseRuleCollection.IWithRuleCollectionActionType<IWithApplicationRuleCollectionSettings>,
        ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<IWithCreate>
    {
        /// <summary>
        /// Sets the Azure firewall application rule.
        /// </summary>
        /// <param name="name">The name of application rule.</param>
        /// <return>The next stage of the definition.</return>
        IWithApplicationRuleSettings DefineAzureFirewallApplicationRule(string name);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify application rule settings.
    /// </summary>
    public interface IWithApplicationRuleSettings :
        BaseRule.IWithDescription<IWithApplicationRuleSettings>,
        BaseRule.IWithSourceAddress<IWithApplicationRuleSettings>,
        BaseRule.IWithApplicationRuleProtocol<IWithApplicationRuleSettings>,
        BaseRule.IWithTargetFqdn<IWithApplicationRuleSettings>,
        BaseRule.IWithFqdnTag<IWithApplicationRuleSettings>,
        BaseRule.IWithSourceIpGroup<IWithApplicationRuleSettings>,
        ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<IWithApplicationRuleCollectionSettings>
    {
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify nat rule collection.
    /// </summary>
    public interface IWithNatRuleCollection
    {
        /// <summary>
        /// Sets the Azure firewall nat rule collection.
        /// </summary>
        /// <param name="name">The name of nat rule collection.</param>
        /// <return>The next stage of the definition.</return>
        IWithNatRuleCollectionSettings DefineAzureFirewallNatRuleCollection(string name);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify nat rule collection settings.
    /// </summary>
    public interface IWithNatRuleCollectionSettings :
        BaseRuleCollection.IWithPriority<IWithNatRuleCollectionSettings>,
        BaseRuleCollection.IWithNatRuleCollectionActionType<IWithNatRuleCollectionSettings>,
        ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<IWithCreate>
    {
        /// <summary>
        /// Sets the Azure firewall nat rule.
        /// </summary>
        /// <param name="name">The name of nat rule.</param>
        /// <return>The next stage of the definition.</return>
        IWithNatRuleSettings DefineAzureFirewallNatRule(string name);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify nat rule settings.
    /// </summary>
    public interface IWithNatRuleSettings :
        BaseRule.IWithDescription<IWithNatRuleSettings>,
        BaseRule.IWithSourceAddress<IWithNatRuleSettings>,
        BaseRule.IWithDestinationAddress<IWithNatRuleSettings>,
        BaseRule.IWithDestinationPort<IWithNatRuleSettings>,
        BaseRule.IWithRuleProtocol<IWithNatRuleSettings>,
        ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<IWithNatRuleCollectionSettings>
    {
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify network rule collection.
    /// </summary>
    public interface IWithNetworkRuleCollection
    {
        /// <summary>
        /// Sets the Azure firewall network rule collection.
        /// </summary>
        /// <param name="name">The name of network rule collection.</param>
        /// <return>The next stage of the definition.</return>
        IWithNetworkRuleCollectionSettings DefineAzureFirewallNetworkRuleCollection(string name);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify network rule collection settings.
    /// </summary>
    public interface IWithNetworkRuleCollectionSettings :
        BaseRuleCollection.IWithPriority<IWithNetworkRuleCollectionSettings>,
        BaseRuleCollection.IWithRuleCollectionActionType<IWithNetworkRuleCollectionSettings>,
        ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<IWithCreate>
    {
        /// <summary>
        /// Sets the Azure firewall network rule.
        /// </summary>
        /// <param name="name">The name of network rule.</param>
        /// <return>The next stage of the definition.</return>
        IWithNetworkRuleSettings DefineAzureFirewallNetworkRule(string name);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify network rule settings.
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
        ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<IWithNetworkRuleCollectionSettings>
    {
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify IP configuration.
    /// </summary>
    public interface IWithIpConfiguration
    {
        /// <summary>
        /// Sets the IP configuration of Azure firewall .
        /// </summary>
        /// <param name="name">The name of IP configuration.</param>
        /// <return>The next stage of the definition.</return>
        IWithIpConfigurationSettings DefineAzureFirewallIpConfiguration(string name);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify IP configuration settings.
    /// </summary>
    public interface IWithIpConfigurationSettings :
        ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<IWithCreate>
    {
        /// <summary>
        /// Sets the subnet of Azure firewall.
        /// </summary>
        /// <param name="subnetId">The ID of subnet.</param>
        /// <return>The next stage of the definition.</return>
        IWithIpConfigurationSettings WithSubnet(string subnetId);

        /// <summary>
        /// Sets the public IP address of Azure firewall.
        /// </summary>
        /// <param name="publicIpAddressId">The ID of public IP address.</param>
        /// <return>The next stage of the definition.</return>
        IWithIpConfigurationSettings WithPublicIpAddress(string publicIpAddressId);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify the operation mode of threat intelligence.
    /// </summary>
    public interface IWithThreatIntelMode
    {
        /// <summary>
        /// Enables the operation mode as 'Alert' for threat intelligence.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithAlertModeForThreatIntel();

        /// <summary>
        /// Enables the operation mode as 'Deny' for threat intelligence.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithDenyModeForThreatIntel();

        /// <summary>
        /// Enables the operation mode as 'Off' for threat intelligence.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithOffModeForThreatIntel();
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify the virtual hub.
    /// </summary>
    public interface IWithVirtualHub
    {
        /// <summary>
        /// Sets the virtual hub to which the firewall belongs.
        /// </summary>
        /// <param name="virtualHubId">The ID of virtual hub.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithVirtualHub(string virtualHubId);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify the firewall policy.
    /// </summary>
    public interface IWithFirewallPolicy
    {
        /// <summary>
        /// Sets the firewall policy to which the firewall belongs.
        /// </summary>
        /// <param name="firewallPolicyId">The ID of firewall policy.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithFirewallPolicy(string firewallPolicyId);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify the firewall resource SKU.
    /// </summary>
    public interface IWithSku
    {
        /// <summary>
        /// Sets the resource SKU name to 'AZFW_VNet'.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithAzureFirewallVnetSkuName();

        /// <summary>
        /// Sets the resource SKU name to 'AZFW_Hub'.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithAzureFirewallHubSkuName();

        /// <summary>
        /// Sets the resource SKU tier to 'Standard'.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithStandardSkuTier();
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify the additional properties used to further config.
    /// </summary>
    public interface IWithAdditionalProperty
    {
        /// <summary>
        /// Sets the the additional properties used to further config.
        /// </summary>
        /// <param name="key">The key of additional properties.</param>
        /// <param name="value">The value of additional properties.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithAdditionalProperty(string key, string value);

        /// <summary>
        /// Sets the the additional properties used to further config.
        /// </summary>
        /// <param name="additionalProperties">The additional properties.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithAdditionalProperties(IDictionary<string, string> additionalProperties);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify the list of availability zones.
    /// </summary>
    public interface IWithZones
    {
        /// <summary>
        /// Sets the availability zone denoting where the resource needs to come from.
        /// </summary>
        /// <param name="zone">The availability zone.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithZone(string zone);

        /// <summary>
        /// Sets the list of availability zones denoting where the resource needs to come from.
        /// </summary>
        /// <param name="zones">The list of availability zone.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithZones(IList<string> zones);
    }
}
