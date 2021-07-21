// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.AzureFirewall.BaseRule;
    using Microsoft.Azure.Management.Network.Fluent.AzureFirewall.BaseRuleCollection;
    using Microsoft.Azure.Management.Network.Fluent.AzureFirewall.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AzureFirewallImpl :
        GroupableResource<IAzureFirewall,
            AzureFirewallInner,
            AzureFirewallImpl,
            INetworkManager,
            AzureFirewall.Definition.IWithCreate,
            AzureFirewall.Definition.IWithCreate,
            AzureFirewall.Definition.IWithCreate,
            AzureFirewall.Update.IUpdate>,
        IAzureFirewall,
        AzureFirewall.Definition.IDefinition,
        AzureFirewall.Update.IUpdateCombined
    {
        private AzureFirewallApplicationRuleCollectionInner applicationRuleCollection;
        private AzureFirewallNatRuleCollectionInner natRuleCollection;
        private AzureFirewallNetworkRuleCollectionInner networkRuleCollection;
        private AzureFirewallIPConfigurationInner ipConfiguration;
        private AzureFirewallApplicationRule applicationRule;
        private AzureFirewallNatRule natRule;
        private AzureFirewallNetworkRule networkRule;
        
        internal AzureFirewallImpl(string name, AzureFirewallInner innerModel, INetworkManager networkManager)
            : base(name, innerModel, networkManager)
        {
        }

        IReadOnlyList<IAzureFirewallApplicationRuleCollection> IAzureFirewall.ApplicationRuleCollections
        {
            get
            {
                List<IAzureFirewallApplicationRuleCollection> collections = new List<IAzureFirewallApplicationRuleCollection>();
                if (Inner.ApplicationRuleCollections != null)
                {
                    foreach(var collectionInner in Inner.ApplicationRuleCollections)
                    {
                        collections.Add(new AzureFirewallApplicationRuleCollectionImpl(collectionInner));
                    }
                }
                return collections.AsReadOnly();
            }
        }

        IReadOnlyList<IAzureFirewallNatRuleCollection> IAzureFirewall.NatRuleCollections
        {
            get
            {
                List<IAzureFirewallNatRuleCollection> collections = new List<IAzureFirewallNatRuleCollection>();
                if (Inner.NatRuleCollections != null)
                {
                    foreach (var collectionInner in Inner.NatRuleCollections)
                    {
                        collections.Add(new AzureFirewallNatRuleCollectionImpl(collectionInner));
                    }
                }
                return collections.AsReadOnly();
            }
        }

        IReadOnlyList<IAzureFirewallNetworkRuleCollection> IAzureFirewall.NetworkRuleCollections
        {
            get
            {
                List<IAzureFirewallNetworkRuleCollection> collections = new List<IAzureFirewallNetworkRuleCollection>();
                if (Inner.NetworkRuleCollections != null)
                {
                    foreach (var collectionInner in Inner.NetworkRuleCollections)
                    {
                        collections.Add(new AzureFirewallNetworkRuleCollectionImpl(collectionInner));
                    }
                }
                return collections.AsReadOnly();
            }
        }

        IReadOnlyList<IAzureFirewallIpConfiguration> IAzureFirewall.IpConfigurations
        {
            get
            {
                List<IAzureFirewallIpConfiguration> configurations = new List<IAzureFirewallIpConfiguration>();
                if (Inner.IpConfigurations != null)
                {
                    foreach (var configurationInner in Inner.IpConfigurations)
                    {
                        configurations.Add(new AzureFirewallIpConfigurationImpl(configurationInner));
                    }
                }
                return configurations.AsReadOnly();
            }
        }

        ProvisioningState IAzureFirewall.ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
            }
        }

        AzureFirewallThreatIntelMode IAzureFirewall.ThreatIntelMode
        {
            get
            {
                return Inner.ThreatIntelMode;
            }
        }

        string IAzureFirewall.VirtualHubId
        {
            get
            {
                return Inner.VirtualHub?.Id;
            }
        }

        string IAzureFirewall.FirewallPolicyId
        {
            get
            {
                return Inner.FirewallPolicy?.Id;
            }
        }

        HubIPAddresses IAzureFirewall.HubIPAddresses
        {
            get
            {
                return Inner.HubIpAddresses;
            }
        }

        AzureFirewallSku IAzureFirewall.Sku
        {
            get
            {
                return Inner.Sku;
            }
        }

        IReadOnlyDictionary<string, string> IAzureFirewall.AdditionalProperties
        {
            get
            {
                IReadOnlyDictionary<string, string> additionalProps;
                if (Inner.AdditionalProperties != null)
                {
                    additionalProps = new Dictionary<string, string>(Inner.AdditionalProperties);
                }
                else
                {
                    additionalProps = new Dictionary<string, string>();
                }
                return additionalProps;
            }
        }

        IReadOnlyList<string> IAzureFirewall.Zones
        {
            get
            {
                List<string> zones;
                if (Inner.Zones != null)
                {
                    zones = new List<string>(Inner.Zones);
                }
                else
                {
                    zones = new List<string>();
                }
                return zones.AsReadOnly();
            }
        }

        string IAzureFirewall.Etag
        {
            get
            {
                return Inner.Etag;
            }
        }

        AzureFirewall.Definition.IWithApplicationRuleCollectionSettings IInDefinition<AzureFirewall.Definition.IWithApplicationRuleCollectionSettings>.Attach()
        {
            return Attach();
        }

        public async override Task<IAzureFirewall> CreateResourceAsync(CancellationToken cancellationToken)
        {
            AzureFirewallInner innerResource = await Manager.Inner.AzureFirewalls.CreateOrUpdateAsync(
                ResourceGroupName,
                Name,
                Inner,
                cancellationToken);
            SetInner(innerResource);
            ResetAll();
            return this; 
        }

        AzureFirewall.Definition.IWithApplicationRuleSettings AzureFirewall.Definition.IWithApplicationRuleCollectionSettings.DefineAzureFirewallApplicationRule(string name)
        {
            return DefineAzureFirewallApplicationRule(name);
        }

        AzureFirewall.Definition.IWithApplicationRuleCollectionSettings AzureFirewall.Definition.IWithApplicationRuleCollection.DefineAzureFirewallApplicationRuleCollection(string name)
        {
            return DefineAzureFirewallApplicationRuleCollection(name);
        }

        AzureFirewall.Definition.IWithIpConfigurationSettings AzureFirewall.Definition.IWithIpConfiguration.DefineAzureFirewallIpConfiguration(string name)
        {
            return DefineAzureFirewallIpConfiguration(name);
        }

        AzureFirewall.Definition.IWithNatRuleSettings AzureFirewall.Definition.IWithNatRuleCollectionSettings.DefineAzureFirewallNatRule(string name)
        {
            return DefineAzureFirewallNatRule(name);
        }

        AzureFirewall.Definition.IWithNatRuleCollectionSettings AzureFirewall.Definition.IWithNatRuleCollection.DefineAzureFirewallNatRuleCollection(string name)
        {
            return DefineAzureFirewallNatRuleCollection(name);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.Definition.IWithNetworkRuleCollectionSettings.DefineAzureFirewallNetworkRule(string name)
        {
            return DefineAzureFirewallNetworkRule(name);
        }

        AzureFirewall.Definition.IWithNetworkRuleCollectionSettings AzureFirewall.Definition.IWithNetworkRuleCollection.DefineAzureFirewallNetworkRuleCollection(string name)
        {
            return DefineAzureFirewallNetworkRuleCollection(name);
        }

        AzureFirewall.Definition.IWithCreate AzureFirewall.Definition.IWithAdditionalProperty.WithAdditionalProperties(IDictionary<string, string> additionalProperties)
        {
            return WithAdditionalProperties(additionalProperties);
        }

        AzureFirewall.Definition.IWithCreate AzureFirewall.Definition.IWithAdditionalProperty.WithAdditionalProperty(string key, string value)
        {
            return WithAdditionalProperty(key, value);
        }

        AzureFirewall.Definition.IWithCreate AzureFirewall.Definition.IWithThreatIntelMode.WithAlertModeForThreatIntel()
        {
            return WithAlertModeForThreatIntel();
        }

        AzureFirewall.Definition.IWithApplicationRuleCollectionSettings AzureFirewall.BaseRuleCollection.IWithRuleCollectionActionType<AzureFirewall.Definition.IWithApplicationRuleCollectionSettings>.WithAllowActionType()
        {
            return WithAllowActionTypeInApplicationRuleCollection();
        }

        AzureFirewall.Definition.IWithNatRuleSettings AzureFirewall.BaseRule.IWithRuleProtocol<AzureFirewall.Definition.IWithNatRuleSettings>.WithAnyProtocol()
        {
            return WithAnyProtocolInNatRule();
        }

        AzureFirewall.Definition.IWithCreate AzureFirewall.Definition.IWithSku.WithAzureFirewallHubSkuName()
        {
            return WithAzureFirewallHubSkuName();
        }

        AzureFirewall.Definition.IWithCreate AzureFirewall.Definition.IWithSku.WithAzureFirewallVnetSkuName()
        {
            return WithAzureFirewallVnetSkuName();
        }

        AzureFirewall.Definition.IWithApplicationRuleCollectionSettings AzureFirewall.BaseRuleCollection.IWithRuleCollectionActionType<AzureFirewall.Definition.IWithApplicationRuleCollectionSettings>.WithDenyActionType()
        {
            return WithDenyActionTypeInApplicationRuleCollection();
        }

        AzureFirewall.Definition.IWithCreate AzureFirewall.Definition.IWithThreatIntelMode.WithDenyModeForThreatIntel()
        {
            return WithDenyModeForThreatIntel();
        }

        AzureFirewall.Definition.IWithApplicationRuleSettings AzureFirewall.BaseRule.IWithDescription<AzureFirewall.Definition.IWithApplicationRuleSettings>.WithDescription(string description)
        {
            return WithDescriptionInApplicationRule(description);
        }

        AzureFirewall.Definition.IWithNatRuleSettings AzureFirewall.BaseRule.IWithDestinationAddress<AzureFirewall.Definition.IWithNatRuleSettings>.WithDestinationAddress(string destinationAddress)
        {
            return WithDestinationAddressInNatRule(destinationAddress);
        }

        AzureFirewall.Definition.IWithNatRuleSettings AzureFirewall.BaseRule.IWithDestinationAddress<AzureFirewall.Definition.IWithNatRuleSettings>.WithDestinationAddresses(IList<string> destinationAddresses)
        {
            return WithDestinationAddressesInNatRule(destinationAddresses);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithDestinationFqdn<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithDestinationFullQualifiedDomainName(string domainName)
        {
            return WithDestinationFullQualifiedDomainNameInNetworkRule(domainName);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithDestinationFqdn<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithDestinationFullQualifiedDomainNames(IList<string> domainNames)
        {
            return WithDestinationFullQualifiedDomainNamesInNetworkRule(domainNames);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithDestinationIpGroup<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithDestinationIpGroup(string destinationIpGroup)
        {
            return WithDestinationIpGroupInNetworkRule(destinationIpGroup);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithDestinationIpGroup<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithDestinationIpGroups(IList<string> destinationIpGroups)
        {
            return WithDestinationIpGroupsInNetworkRule(destinationIpGroups);
        }

        AzureFirewall.Definition.IWithNatRuleSettings AzureFirewall.BaseRule.IWithDestinationPort<AzureFirewall.Definition.IWithNatRuleSettings>.WithDestinationPort(string destinationPort)
        {
            return WithDestinationPortInNatRule(destinationPort);
        }

        AzureFirewall.Definition.IWithNatRuleSettings AzureFirewall.BaseRule.IWithDestinationPort<AzureFirewall.Definition.IWithNatRuleSettings>.WithDestinationPorts(IList<string> destinationPorts)
        {
            return WithDestinationPortsInNatRule(destinationPorts);
        }

        AzureFirewall.Definition.IWithNatRuleCollectionSettings AzureFirewall.BaseRuleCollection.IWithNatRuleCollectionActionType<AzureFirewall.Definition.IWithNatRuleCollectionSettings>.WithDnatActionType()
        {
            return WithDnatActionType();
        }

        AzureFirewall.Definition.IWithCreate AzureFirewall.Definition.IWithFirewallPolicy.WithFirewallPolicy(string firewallPolicyId)
        {
            return WithFirewallPolicy(firewallPolicyId);
        }

        AzureFirewall.Definition.IWithApplicationRuleSettings AzureFirewall.BaseRule.IWithFqdnTag<AzureFirewall.Definition.IWithApplicationRuleSettings>.WithFullQualifiedDomainNameTag(string tag)
        {
            return WithFullQualifiedDomainNameTagInApplicationRule(tag);
        }

        AzureFirewall.Definition.IWithApplicationRuleSettings AzureFirewall.BaseRule.IWithFqdnTag<AzureFirewall.Definition.IWithApplicationRuleSettings>.WithFullQualifiedDomainNameTags(IList<string> tags)
        {
            return WithFullQualifiedDomainNameTagsInApplicationRule(tags);
        }

        AzureFirewall.Definition.IWithApplicationRuleSettings AzureFirewall.BaseRule.IWithApplicationRuleProtocol<AzureFirewall.Definition.IWithApplicationRuleSettings>.WithHttpProtocol(int? port)
        {
            return WithHttpProtocolInApplicationRule(port);
        }

        AzureFirewall.Definition.IWithApplicationRuleSettings AzureFirewall.BaseRule.IWithApplicationRuleProtocol<AzureFirewall.Definition.IWithApplicationRuleSettings>.WithHttpsProtocol(int? port)
        {
            return WithHttpsProtocolInApplicationRule(port);
        }

        AzureFirewall.Definition.IWithNatRuleSettings AzureFirewall.BaseRule.IWithRuleProtocol<AzureFirewall.Definition.IWithNatRuleSettings>.WithIcmpProtocol()
        {
            return WithIcmpProtocolInNatRule();
        }

        AzureFirewall.Definition.IWithApplicationRuleSettings AzureFirewall.BaseRule.IWithApplicationRuleProtocol<AzureFirewall.Definition.IWithApplicationRuleSettings>.WithMssqlProtocol(int? port)
        {
            return WithMssqlProtocolInApplicationRule(port);
        }

        AzureFirewall.Definition.IWithCreate AzureFirewall.Definition.IWithThreatIntelMode.WithOffModeForThreatIntel()
        {
            return WithOffModeForThreatIntel();
        }

        AzureFirewall.Definition.IWithApplicationRuleCollectionSettings AzureFirewall.BaseRuleCollection.IWithPriority<AzureFirewall.Definition.IWithApplicationRuleCollectionSettings>.WithPriority(int priority)
        {
            return WithPriorityInApplicationRuleCollection(priority);
        }

        AzureFirewall.Definition.IWithNatRuleCollectionSettings AzureFirewall.BaseRuleCollection.IWithNatRuleCollectionActionType<AzureFirewall.Definition.IWithNatRuleCollectionSettings>.WithSnatActionType()
        {
            return WithSnatActionTypeInNatRuleCollection();
        }

        AzureFirewall.Definition.IWithApplicationRuleSettings AzureFirewall.BaseRule.IWithSourceAddress<AzureFirewall.Definition.IWithApplicationRuleSettings>.WithSourceAddress(string sourceAddress)
        {
            return WithSourceAddressInApplicationRule(sourceAddress);
        }

        AzureFirewall.Definition.IWithApplicationRuleSettings AzureFirewall.BaseRule.IWithSourceAddress<AzureFirewall.Definition.IWithApplicationRuleSettings>.WithSourceAddresses(IList<string> sourceAddresses)
        {
            return WithSourceAddressesInApplicationRule(sourceAddresses);
        }

        AzureFirewall.Definition.IWithApplicationRuleSettings AzureFirewall.BaseRule.IWithSourceIpGroup<AzureFirewall.Definition.IWithApplicationRuleSettings>.WithSourceIpGroup(string sourceIpGroup)
        {
            return WithSourceIpGroupInApplicationRule(sourceIpGroup);
        }

        AzureFirewall.Definition.IWithApplicationRuleSettings AzureFirewall.BaseRule.IWithSourceIpGroup<AzureFirewall.Definition.IWithApplicationRuleSettings>.WithSourceIpGroups(IList<string> sourceIpGroups)
        {
            return WithSourceIpGroupsInApplicationRule(sourceIpGroups);
        }

        AzureFirewall.Definition.IWithCreate AzureFirewall.Definition.IWithSku.WithStandardSkuTier()
        {
            return WithStandardSkuTier();
        }

        AzureFirewall.Definition.IWithApplicationRuleSettings AzureFirewall.BaseRule.IWithTargetFqdn<AzureFirewall.Definition.IWithApplicationRuleSettings>.WithTargetFullQualifiedDomainName(string domainName)
        {
            return WithTargetFullQualifiedDomainNameInApplicationRule(domainName);
        }

        AzureFirewall.Definition.IWithApplicationRuleSettings AzureFirewall.BaseRule.IWithTargetFqdn<AzureFirewall.Definition.IWithApplicationRuleSettings>.WithTargetFullQualifiedDomainNames(IList<string> domainNames)
        {
            return WithTargetFullQualifiedDomainNamesInApplicationRule(domainNames);
        }

        AzureFirewall.Definition.IWithNatRuleSettings AzureFirewall.BaseRule.IWithRuleProtocol<AzureFirewall.Definition.IWithNatRuleSettings>.WithTcpProtocol()
        {
            return WithTcpProtocolInNatRule();
        }

        AzureFirewall.Definition.IWithNatRuleSettings AzureFirewall.BaseRule.IWithRuleProtocol<AzureFirewall.Definition.IWithNatRuleSettings>.WithUdpProtocol()
        {
            return WithUdpProtocolInNatRule();
        }

        AzureFirewall.Definition.IWithCreate AzureFirewall.Definition.IWithVirtualHub.WithVirtualHub(string virtualHubId)
        {
            return WithVirtualHub(virtualHubId);
        }

        AzureFirewall.Definition.IWithCreate AzureFirewall.Definition.IWithZones.WithZone(string zone)
        {
            return WithZone(zone);
        }

        AzureFirewall.Definition.IWithCreate AzureFirewall.Definition.IWithZones.WithZones(IList<string> zones)
        {
            return WithZones(zones);
        }

        protected async override Task<AzureFirewallInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.AzureFirewalls.GetAsync(
                ResourceGroupName,
                Name,
                cancellationToken);
        }

        AzureFirewall.Definition.IWithNatRuleCollectionSettings IInDefinition<AzureFirewall.Definition.IWithNatRuleCollectionSettings>.Attach()
        {
            return Attach();
        }

        AzureFirewall.Definition.IWithCreate IInDefinition<AzureFirewall.Definition.IWithCreate>.Attach()
        {
            return Attach();
        }

        AzureFirewall.Definition.IWithNetworkRuleCollectionSettings IInDefinition<AzureFirewall.Definition.IWithNetworkRuleCollectionSettings>.Attach()
        {
            return Attach();
        }

        AzureFirewall.Definition.IWithNetworkRuleCollectionSettings AzureFirewall.BaseRuleCollection.IWithRuleCollectionActionType<AzureFirewall.Definition.IWithNetworkRuleCollectionSettings>.WithAllowActionType()
        {
            return WithAllowActionTypeInNetworkRuleCollection();
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithRuleProtocol<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithAnyProtocol()
        {
            return WithAnyProtocolInNetworkRule();
        }

        AzureFirewall.Definition.IWithNetworkRuleCollectionSettings AzureFirewall.BaseRuleCollection.IWithRuleCollectionActionType<AzureFirewall.Definition.IWithNetworkRuleCollectionSettings>.WithDenyActionType()
        {
            return WithDenyActionTypeInNetworkRuleCollection();
        }

        AzureFirewall.Definition.IWithNatRuleSettings AzureFirewall.BaseRule.IWithDescription<AzureFirewall.Definition.IWithNatRuleSettings>.WithDescription(string description)
        {
            return WithDescriptionInNatRule(description);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithDescription<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithDescription(string description)
        {
            return WithDescriptionInNetworkRule(description);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithDestinationAddress<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithDestinationAddress(string destinationAddress)
        {
            return WithDestinationAddressInNetworkRule(destinationAddress);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithDestinationAddress<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithDestinationAddresses(IList<string> destinationAddresses)
        {
            return WithDestinationAddressesInNetworkRule(destinationAddresses);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithDestinationPort<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithDestinationPort(string destinationPort)
        {
            return WithDestinationPortInNetworkRule(destinationPort);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithDestinationPort<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithDestinationPorts(IList<string> destinationPorts)
        {
            return WithDestinationPortsInNetworkRule(destinationPorts);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithRuleProtocol<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithIcmpProtocol()
        {
            return WithIcmpProtocolInNetworkRule();
        }

        AzureFirewall.Definition.IWithNatRuleCollectionSettings AzureFirewall.BaseRuleCollection.IWithPriority<AzureFirewall.Definition.IWithNatRuleCollectionSettings>.WithPriority(int priority)
        {
            return WithPriorityInNatRuleCollection(priority);
        }

        AzureFirewall.Definition.IWithNetworkRuleCollectionSettings AzureFirewall.BaseRuleCollection.IWithPriority<AzureFirewall.Definition.IWithNetworkRuleCollectionSettings>.WithPriority(int priority)
        {
            return WithPriorityInNetworkRuleCollection(priority);
        }

        AzureFirewall.Definition.IWithNatRuleSettings AzureFirewall.BaseRule.IWithSourceAddress<AzureFirewall.Definition.IWithNatRuleSettings>.WithSourceAddress(string sourceAddress)
        {
            return WithSourceAddressInNatRule(sourceAddress);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithSourceAddress<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithSourceAddress(string sourceAddress)
        {
            return WithSourceAddressInNetworkRule(sourceAddress);
        }

        AzureFirewall.Definition.IWithNatRuleSettings AzureFirewall.BaseRule.IWithSourceAddress<AzureFirewall.Definition.IWithNatRuleSettings>.WithSourceAddresses(IList<string> sourceAddresses)
        {
            return WithSourceAddressesInNatRule(sourceAddresses);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithSourceAddress<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithSourceAddresses(IList<string> sourceAddresses)
        {
            return WithSourceAddressesInNetworkRule(sourceAddresses);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithSourceIpGroup<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithSourceIpGroup(string sourceIpGroup)
        {
            return WithSourceIpGroupInNetworkRule(sourceIpGroup);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithSourceIpGroup<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithSourceIpGroups(IList<string> sourceIpGroups)
        {
            return WithSourceIpGroupsInNetworkRule(sourceIpGroups);
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithRuleProtocol<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithTcpProtocol()
        {
            return WithTcpProtocolInNetworkRule();
        }

        AzureFirewall.Definition.IWithNetworkRuleSettings AzureFirewall.BaseRule.IWithRuleProtocol<AzureFirewall.Definition.IWithNetworkRuleSettings>.WithUdpProtocol()
        {
            return WithUdpProtocolInNetworkRule();
        }

        AzureFirewall.Definition.IWithIpConfigurationSettings AzureFirewall.Definition.IWithIpConfigurationSettings.WithSubnet(string subnetId)
        {
            return WithSubnet(subnetId);
        }

        AzureFirewall.Definition.IWithIpConfigurationSettings AzureFirewall.Definition.IWithIpConfigurationSettings.WithPublicIpAddress(string publicIpAddressId)
        {
            return WithPublicIpAddress(publicIpAddressId);
        }

        AzureFirewall.Update.IUpdate AzureFirewall.Update.IWithThreatIntelMode.WithAlertModeForThreatIntel()
        {
            return WithAlertModeForThreatIntel();
        }

        AzureFirewall.Update.IUpdate AzureFirewall.Update.IWithThreatIntelMode.WithDenyModeForThreatIntel()
        {
            return WithDenyModeForThreatIntel();
        }

        AzureFirewall.Update.IUpdate AzureFirewall.Update.IWithThreatIntelMode.WithOffModeForThreatIntel()
        {
            return WithOffModeForThreatIntel();
        }

        AzureFirewall.Update.IUpdate AzureFirewall.Update.IWithVirtualHub.WithVirtualHub(string virtualHubId)
        {
            return WithVirtualHub(virtualHubId);
        }

        AzureFirewall.Update.IUpdate AzureFirewall.Update.IWithFirewallPolicy.WithFirewallPolicy(string firewallPolicyId)
        {
            return WithFirewallPolicy(firewallPolicyId);
        }

        AzureFirewall.Update.IUpdate AzureFirewall.Update.IWithSku.WithAzureFirewallVnetSkuName()
        {
            return WithAzureFirewallVnetSkuName();
        }

        AzureFirewall.Update.IUpdate AzureFirewall.Update.IWithSku.WithAzureFirewallHubSkuName()
        {
            return WithAzureFirewallHubSkuName();
        }

        AzureFirewall.Update.IUpdate AzureFirewall.Update.IWithAdditionalProperty.WithAdditionalProperty(string key, string value)
        {
            return WithAdditionalProperty(key, value);
        }

        AzureFirewall.Update.IUpdate AzureFirewall.Update.IWithAdditionalProperty.WithAdditionalProperties(IDictionary<string, string> additionalProperties)
        {
            return WithAdditionalProperties(additionalProperties);
        }

        AzureFirewall.Update.IUpdate AzureFirewall.Update.IWithAdditionalProperty.WithoutAdditionalProperty(string key)
        {
            return WithoutAdditionalProperty(key);
        }

        AzureFirewall.Update.IUpdate AzureFirewall.Update.IWithZones.WithZone(string zone)
        {
            return WithZone(zone);
        }

        AzureFirewall.Update.IUpdate AzureFirewall.Update.IWithZones.WithZones(IList<string> zones)
        {
            return WithZones(zones);
        }

        AzureFirewall.Update.IUpdate AzureFirewall.Update.IWithZones.WithoutZone(string zone)
        {
            return WithoutZone(zone);
        }

        IWithApplicationRuleCollectionSettings IWithApplicationRuleCollection.DefineAzureFirewallApplicationRuleCollection(string name)
        {
            return DefineAzureFirewallApplicationRuleCollection(name);
        }

        IWithApplicationRuleCollectionSettings IWithApplicationRuleCollection.UpdateAzureFirewallApplicationRuleCollection(string name)
        {
            return UpdateAzureFirewallApplicationRuleCollection(name);
        }

        IUpdate IWithApplicationRuleCollection.WithoutAzureFirewallApplicationRuleCollection(string name)
        {
            return WithoutAzureFirewallApplicationRuleCollection(name);
        }

        IWithNatRuleCollectionSettings IWithNatRuleCollection.DefineAzureFirewallNatRuleCollection(string name)
        {
            return DefineAzureFirewallNatRuleCollection(name);
        }

        IWithNatRuleCollectionSettings IWithNatRuleCollection.UpdateAzureFirewallNatRuleCollection(string name)
        {
            return UpdateAzureFirewallNatRuleCollection(name);
        }

        IUpdate IWithNatRuleCollection.WithoutAzureFirewallNatRuleCollection(string name)
        {
            return WithoutAzureFirewallNatRuleCollection(name);
        }

        IWithNetworkRuleCollectionSettings IWithNetworkRuleCollection.DefineAzureFirewallNetworkRuleCollection(string name)
        {
            return DefineAzureFirewallNetworkRuleCollection(name);
        }

        IWithNetworkRuleCollectionSettings IWithNetworkRuleCollection.UpdateAzureFirewallNetworkRuleCollection(string name)
        {
            return UpdateAzureFirewallNetworkRuleCollection(name);
        }

        IUpdate IWithNetworkRuleCollection.WithoutAzureFirewallNetworkRuleCollection(string name)
        {
            return WithoutAzureFirewallNetworkRuleCollection(name);
        }

        IWithApplicationRuleSettings IWithApplicationRuleCollectionSettings.DefineAzureFirewallApplicationRule(string name)
        {
            return DefineAzureFirewallApplicationRule(name);
        }

        IWithApplicationRuleSettings IWithApplicationRuleCollectionSettings.UpdateAzureFirewallApplicationRule(string name)
        {
            return UpdateAzureFirewallApplicationRule(name);
        }

        IWithApplicationRuleCollectionSettings IWithApplicationRuleCollectionSettings.WithoutAzureFirewallApplicationRule(string name)
        {
            return WithoutAzureFirewallApplicationRule(name);
        }

        IWithApplicationRuleCollectionSettings IWithPriority<IWithApplicationRuleCollectionSettings>.WithPriority(int priority)
        {
            return WithPriorityInApplicationRuleCollection(priority);
        }

        IWithApplicationRuleCollectionSettings IWithRuleCollectionActionType<IWithApplicationRuleCollectionSettings>.WithAllowActionType()
        {
            return WithAllowActionTypeInApplicationRuleCollection();
        }

        IWithApplicationRuleCollectionSettings IWithRuleCollectionActionType<IWithApplicationRuleCollectionSettings>.WithDenyActionType()
        {
            return WithDenyActionTypeInApplicationRuleCollection();
        }

        IWithApplicationRuleSettings IWithDescription<IWithApplicationRuleSettings>.WithDescription(string description)
        {
            return WithDescriptionInApplicationRule(description);
        }

        IWithApplicationRuleSettings IWithSourceAddress<IWithApplicationRuleSettings>.WithSourceAddress(string sourceAddress)
        {
            return WithSourceAddressInApplicationRule(sourceAddress);
        }

        IWithApplicationRuleSettings IWithSourceAddress<IWithApplicationRuleSettings>.WithSourceAddresses(IList<string> sourceAddresses)
        {
            return WithSourceAddressesInApplicationRule(sourceAddresses);
        }

        IWithApplicationRuleSettings IWithApplicationRuleProtocol<IWithApplicationRuleSettings>.WithHttpProtocol(int? port)
        {
            return WithHttpProtocolInApplicationRule(port);
        }

        IWithApplicationRuleSettings IWithApplicationRuleProtocol<IWithApplicationRuleSettings>.WithHttpsProtocol(int? port)
        {
            return WithHttpsProtocolInApplicationRule(port);
        }

        IWithApplicationRuleSettings IWithApplicationRuleProtocol<IWithApplicationRuleSettings>.WithMssqlProtocol(int? port)
        {
            return WithMssqlProtocolInApplicationRule(port);
        }

        IWithApplicationRuleSettings IWithTargetFqdn<IWithApplicationRuleSettings>.WithTargetFullQualifiedDomainName(string domainName)
        {
            return WithTargetFullQualifiedDomainNameInApplicationRule(domainName);
        }

        IWithApplicationRuleSettings IWithTargetFqdn<IWithApplicationRuleSettings>.WithTargetFullQualifiedDomainNames(IList<string> domainNames)
        {
            return WithTargetFullQualifiedDomainNamesInApplicationRule(domainNames);
        }

        IWithApplicationRuleSettings IWithFqdnTag<IWithApplicationRuleSettings>.WithFullQualifiedDomainNameTag(string tag)
        {
            return WithFullQualifiedDomainNameTagInApplicationRule(tag);
        }

        IWithApplicationRuleSettings IWithFqdnTag<IWithApplicationRuleSettings>.WithFullQualifiedDomainNameTags(IList<string> tags)
        {
            return WithFullQualifiedDomainNameTagsInApplicationRule(tags);
        }

        IWithApplicationRuleSettings IWithSourceIpGroup<IWithApplicationRuleSettings>.WithSourceIpGroup(string sourceIpGroup)
        {
            return WithSourceIpGroupInApplicationRule(sourceIpGroup);
        }

        IWithApplicationRuleSettings IWithSourceIpGroup<IWithApplicationRuleSettings>.WithSourceIpGroups(IList<string> sourceIpGroups)
        {
            return WithSourceIpGroupsInApplicationRule(sourceIpGroups);
        }

        IWithApplicationRuleCollectionSettings IInUpdate<IWithApplicationRuleCollectionSettings>.Attach()
        {
            return Attach();
        }

        IWithNatRuleSettings IWithNatRuleCollectionSettings.DefineAzureFirewallNatRule(string name)
        {
            return DefineAzureFirewallNatRule(name);
        }

        IWithNatRuleSettings IWithNatRuleCollectionSettings.UpdateAzureFirewallNatRule(string name)
        {
            return UpdateAzureFirewallNatRule(name);
        }

        IWithNatRuleCollectionSettings IWithNatRuleCollectionSettings.WithoutAzureFirewallNatRule(string name)
        {
            return WithoutAzureFirewallNatRule(name);
        }

        IWithNatRuleCollectionSettings IWithPriority<IWithNatRuleCollectionSettings>.WithPriority(int priority)
        {
            return WithPriorityInNatRuleCollection(priority);
        }

        IWithNatRuleCollectionSettings IWithNatRuleCollectionActionType<IWithNatRuleCollectionSettings>.WithSnatActionType()
        {
            return WithSnatActionTypeInNatRuleCollection();
        }

        IWithNatRuleCollectionSettings IWithNatRuleCollectionActionType<IWithNatRuleCollectionSettings>.WithDnatActionType()
        {
            return WithDnatActionType();
        }

        IWithNatRuleSettings IWithDescription<IWithNatRuleSettings>.WithDescription(string description)
        {
            return WithDescriptionInNatRule(description);
        }

        IWithNatRuleSettings IWithSourceAddress<IWithNatRuleSettings>.WithSourceAddress(string sourceAddress)
        {
            return WithSourceAddressInNatRule(sourceAddress);
        }

        IWithNatRuleSettings IWithSourceAddress<IWithNatRuleSettings>.WithSourceAddresses(IList<string> sourceAddresses)
        {
            return WithSourceAddressesInNatRule(sourceAddresses);
        }

        IWithNatRuleSettings IWithDestinationAddress<IWithNatRuleSettings>.WithDestinationAddress(string destinationAddress)
        {
            return WithDestinationAddressInNatRule(destinationAddress);
        }

        IWithNatRuleSettings IWithDestinationAddress<IWithNatRuleSettings>.WithDestinationAddresses(IList<string> destinationAddresses)
        {
            return WithDestinationAddressesInNatRule(destinationAddresses);
        }

        IWithNatRuleSettings IWithDestinationPort<IWithNatRuleSettings>.WithDestinationPort(string destinationPort)
        {
            return WithDestinationPortInNatRule(destinationPort);
        }

        IWithNatRuleSettings IWithDestinationPort<IWithNatRuleSettings>.WithDestinationPorts(IList<string> destinationPorts)
        {
            return WithDestinationPortsInNatRule(destinationPorts);
        }

        IWithNatRuleSettings IWithRuleProtocol<IWithNatRuleSettings>.WithTcpProtocol()
        {
            return WithTcpProtocolInNatRule();
        }

        IWithNatRuleSettings IWithRuleProtocol<IWithNatRuleSettings>.WithUdpProtocol()
        {
            return WithUdpProtocolInNatRule();
        }

        IWithNatRuleSettings IWithRuleProtocol<IWithNatRuleSettings>.WithAnyProtocol()
        {
            return WithAnyProtocolInNatRule();
        }

        IWithNatRuleSettings IWithRuleProtocol<IWithNatRuleSettings>.WithIcmpProtocol()
        {
            return WithIcmpProtocolInNatRule();
        }

        IWithNatRuleCollectionSettings IInUpdate<IWithNatRuleCollectionSettings>.Attach()
        {
            return Attach();
        }

        IWithNetworkRuleSettings IWithNetworkRuleCollectionSettings.DefineAzureFirewallNetworkRule(string name)
        {
            return DefineAzureFirewallNetworkRule(name);
        }

        IWithNetworkRuleSettings IWithNetworkRuleCollectionSettings.UpdateAzureFirewallNetworkRule(string name)
        {
            return UpdateAzureFirewallNetworkRule(name);
        }

        IWithNetworkRuleCollectionSettings IWithNetworkRuleCollectionSettings.WithoutAzureFirewallNetworkRule(string name)
        {
            return WithoutAzureFirewallNetworkRule(name);
        }

        IWithNetworkRuleCollectionSettings IWithPriority<IWithNetworkRuleCollectionSettings>.WithPriority(int priority)
        {
            return WithPriorityInNetworkRuleCollection(priority);
        }

        IWithNetworkRuleCollectionSettings IWithRuleCollectionActionType<IWithNetworkRuleCollectionSettings>.WithAllowActionType()
        {
            return WithAllowActionTypeInNetworkRuleCollection();
        }

        IWithNetworkRuleCollectionSettings IWithRuleCollectionActionType<IWithNetworkRuleCollectionSettings>.WithDenyActionType()
        {
            return WithDenyActionTypeInNetworkRuleCollection();
        }

        IUpdate IInUpdate<IUpdate>.Attach()
        {
            return this;
        }

        IWithNetworkRuleSettings IWithDescription<IWithNetworkRuleSettings>.WithDescription(string description)
        {
            return WithDescriptionInNetworkRule(description);
        }

        IWithNetworkRuleSettings IWithRuleProtocol<IWithNetworkRuleSettings>.WithTcpProtocol()
        {
            return WithTcpProtocolInNetworkRule();
        }

        IWithNetworkRuleSettings IWithRuleProtocol<IWithNetworkRuleSettings>.WithUdpProtocol()
        {
            return WithUdpProtocolInNetworkRule();
        }

        IWithNetworkRuleSettings IWithRuleProtocol<IWithNetworkRuleSettings>.WithAnyProtocol()
        {
            return WithAnyProtocolInNetworkRule();
        }

        IWithNetworkRuleSettings IWithRuleProtocol<IWithNetworkRuleSettings>.WithIcmpProtocol()
        {
            return WithIcmpProtocolInNetworkRule();
        }

        IWithNetworkRuleSettings IWithSourceAddress<IWithNetworkRuleSettings>.WithSourceAddress(string sourceAddress)
        {
            return WithSourceAddressInNetworkRule(sourceAddress);
        }

        IWithNetworkRuleSettings IWithSourceAddress<IWithNetworkRuleSettings>.WithSourceAddresses(IList<string> sourceAddresses)
        {
            return WithSourceAddressesInNetworkRule(sourceAddresses);
        }

        IWithNetworkRuleSettings IWithDestinationAddress<IWithNetworkRuleSettings>.WithDestinationAddress(string destinationAddress)
        {
            return WithDestinationAddressInNetworkRule(destinationAddress);
        }

        IWithNetworkRuleSettings IWithDestinationAddress<IWithNetworkRuleSettings>.WithDestinationAddresses(IList<string> destinationAddresses)
        {
            return WithDestinationAddressesInNetworkRule(destinationAddresses);
        }

        IWithNetworkRuleSettings IWithDestinationPort<IWithNetworkRuleSettings>.WithDestinationPort(string destinationPort)
        {
            return WithDestinationPortInNetworkRule(destinationPort);
        }

        IWithNetworkRuleSettings IWithDestinationPort<IWithNetworkRuleSettings>.WithDestinationPorts(IList<string> destinationPorts)
        {
            return WithDestinationPortsInNetworkRule(destinationPorts);
        }

        IWithNetworkRuleSettings IWithDestinationFqdn<IWithNetworkRuleSettings>.WithDestinationFullQualifiedDomainName(string domainName)
        {
            return WithDestinationFullQualifiedDomainNameInNetworkRule(domainName);
        }

        IWithNetworkRuleSettings IWithDestinationFqdn<IWithNetworkRuleSettings>.WithDestinationFullQualifiedDomainNames(IList<string> domainNames)
        {
            return WithDestinationFullQualifiedDomainNamesInNetworkRule(domainNames);
        }

        IWithNetworkRuleSettings IWithSourceIpGroup<IWithNetworkRuleSettings>.WithSourceIpGroup(string sourceIpGroup)
        {
            return WithSourceIpGroupInNetworkRule(sourceIpGroup);
        }

        IWithNetworkRuleSettings IWithSourceIpGroup<IWithNetworkRuleSettings>.WithSourceIpGroups(IList<string> sourceIpGroups)
        {
            return WithSourceIpGroupsInNetworkRule(sourceIpGroups);
        }

        IWithNetworkRuleSettings IWithDestinationIpGroup<IWithNetworkRuleSettings>.WithDestinationIpGroup(string destinationIpGroup)
        {
            return WithDestinationIpGroupInNetworkRule(destinationIpGroup);
        }

        IWithNetworkRuleSettings IWithDestinationIpGroup<IWithNetworkRuleSettings>.WithDestinationIpGroups(IList<string> destinationIpGroups)
        {
            return WithDestinationIpGroupsInNetworkRule(destinationIpGroups);
        }

        IWithNetworkRuleCollectionSettings IInUpdate<IWithNetworkRuleCollectionSettings>.Attach()
        {
            return Attach();
        }

        private AzureFirewallImpl Attach()
        {
            return this;
        }

        private AzureFirewallImpl DefineAzureFirewallApplicationRule(string name)
        {
            if (applicationRuleCollection.Rules == null)
            {
                applicationRuleCollection.Rules = new List<AzureFirewallApplicationRule>();
            }
            else if (GetApplicationRule(name) != null)
            {
                throw new ArgumentException(string.Format("Application rule %s is already existing in the collection %s.", name, applicationRuleCollection.Name));
            }
            applicationRule = new AzureFirewallApplicationRule
            {
                Name = name
            };
            applicationRuleCollection.Rules.Add(applicationRule);
            return this;
        }

        private AzureFirewallImpl UpdateAzureFirewallApplicationRule(string name)
        {
            if (GetApplicationRule(name) == null)
            {
                throw new ArgumentException(string.Format("Application rule %s is not found in the collection %s.", name, applicationRuleCollection.Name));
            }
            return this;
        }

        private AzureFirewallImpl WithoutAzureFirewallApplicationRule(string name)
        {
            if (GetApplicationRule(name) != null)
            {
                applicationRuleCollection.Rules.Remove(applicationRule);
            }
            return this;
        }

        private AzureFirewallApplicationRule GetApplicationRule(string name)
        {
            if (applicationRuleCollection != null && applicationRuleCollection.Rules != null)
            {
                foreach (var rule in applicationRuleCollection.Rules)
                {
                    if (string.Equals(name, rule.Name))
                    {
                        applicationRule = rule;
                        return rule;
                    }
                }
            }
            return null;
        }

        private AzureFirewallImpl DefineAzureFirewallApplicationRuleCollection(string name)
        {
            if (Inner.ApplicationRuleCollections == null)
            {
                Inner.ApplicationRuleCollections = new List<AzureFirewallApplicationRuleCollectionInner>();
            }
            else if (GetApplicationRuleCollection(name) != null)
            {
                throw new ArgumentException(string.Format("Application rule collection %s is already existing.", name));
            }
            applicationRuleCollection = new AzureFirewallApplicationRuleCollectionInner
            {
                Name = name
            };
            Inner.ApplicationRuleCollections.Add(applicationRuleCollection);
            return this;
        }

        private AzureFirewallImpl UpdateAzureFirewallApplicationRuleCollection(string name)
        {
            if (GetApplicationRuleCollection(name) == null)
            {
                throw new ArgumentException(string.Format("Application rule collection %s is not found.", name));
            }
            return this;
        }

        private AzureFirewallImpl WithoutAzureFirewallApplicationRuleCollection(string name)
        {
            if (GetApplicationRuleCollection(name) != null)
            {
                Inner.ApplicationRuleCollections.Remove(applicationRuleCollection);
            }
            return this;
        }

        private AzureFirewallApplicationRuleCollectionInner GetApplicationRuleCollection(string name)
        {
            if (Inner.ApplicationRuleCollections != null)
            {
                foreach (var collection in Inner.ApplicationRuleCollections)
                {
                    if (string.Equals(name, collection.Name))
                    {
                        applicationRuleCollection = collection;
                        return collection;
                    }
                }
            }
            return null;
        }

        private AzureFirewallImpl DefineAzureFirewallIpConfiguration(string name)
        {
            ipConfiguration = new AzureFirewallIPConfigurationInner
            {
                Name = name
            };
            if (Inner.IpConfigurations == null)
            {
                Inner.IpConfigurations = new List<AzureFirewallIPConfigurationInner>();
            }
            Inner.IpConfigurations.Add(ipConfiguration);
            return this;
        }

        private AzureFirewallImpl DefineAzureFirewallNatRule(string name)
        {
            if (natRuleCollection.Rules == null)
            {
                natRuleCollection.Rules = new List<AzureFirewallNatRule>();
            }
            else if (GetNatRule(name) != null)
            {
                throw new ArgumentException(string.Format("Nat rule %s is already existing in the collection %s.", name, natRuleCollection.Name));
            }
            natRule = new AzureFirewallNatRule
            {
                Name = name
            };
            natRuleCollection.Rules.Add(natRule);
            return this;
        }

        private AzureFirewallImpl UpdateAzureFirewallNatRule(string name)
        {
            if (GetNatRule(name) == null)
            {
                throw new ArgumentException(string.Format("Nat rule %s is not found in the collection %s.", name, natRuleCollection.Name));
            }
            return this;
        }

        private AzureFirewallImpl WithoutAzureFirewallNatRule(string name)
        {
            if (GetNatRule(name) != null)
            {
                applicationRuleCollection.Rules.Remove(applicationRule);
            }

            return this;
        }

        private AzureFirewallNatRule GetNatRule(string name)
        {
            if (natRuleCollection != null && natRuleCollection.Rules != null)
            {
                foreach (var rule in natRuleCollection.Rules)
                {
                    if (string.Equals(name, rule.Name))
                    {
                        natRule = rule;
                        return rule;
                    }
                }
            }
            return null;
        }

        private AzureFirewallImpl DefineAzureFirewallNatRuleCollection(string name)
        {
            if (Inner.NatRuleCollections == null)
            {
                Inner.NatRuleCollections = new List<AzureFirewallNatRuleCollectionInner>();
            }
            else if (GetNatRuleCollection(name) != null)
            {
                throw new ArgumentException(string.Format("Nat rule collection %s is already existing.", name));
            }
            natRuleCollection = new AzureFirewallNatRuleCollectionInner
            {
                Name = name
            };
            Inner.NatRuleCollections.Add(natRuleCollection);
            return this;
        }

        private AzureFirewallImpl UpdateAzureFirewallNatRuleCollection(string name)
        {
            if (GetNatRuleCollection(name) == null)
            {
                throw new ArgumentException(string.Format("Nat rule collection %s is not found.", name));
            }
            return this;
        }

        private AzureFirewallImpl WithoutAzureFirewallNatRuleCollection(string name)
        {
            if (GetNatRuleCollection(name) != null)
            {
                Inner.NatRuleCollections.Remove(natRuleCollection);
            }
            return this;
        }

        private AzureFirewallNatRuleCollectionInner GetNatRuleCollection(string name)
        {
            if (Inner.NatRuleCollections != null)
            {
                foreach (var collection in Inner.NatRuleCollections)
                {
                    if (string.Equals(name, collection.Name))
                    {
                        natRuleCollection = collection;
                        return collection;
                    }
                }
            }
            return null;
        }

        private AzureFirewallImpl DefineAzureFirewallNetworkRule(string name)
        {
            if (networkRuleCollection.Rules == null)
            {
                networkRuleCollection.Rules = new List<AzureFirewallNetworkRule>();
            }
            else if (GetNetworkRule(name) != null)
            {
                throw new ArgumentException(string.Format("Network rule %s is already existing in the collection %s.", name, networkRuleCollection.Name));
            }
            networkRule = new AzureFirewallNetworkRule
            {
                Name = name
            };
            networkRuleCollection.Rules.Add(networkRule);
            return this;
        }

        private AzureFirewallImpl UpdateAzureFirewallNetworkRule(string name)
        {
            if (GetNetworkRule(name) == null)
            {
                throw new ArgumentException(string.Format("Network rule %s is not found in the collection %s.", name, networkRuleCollection.Name));
            }
            return this;
        }

        private AzureFirewallImpl WithoutAzureFirewallNetworkRule(string name)
        {
            if (GetNetworkRule(name) != null)
            {
                networkRuleCollection.Rules.Remove(networkRule);
            }

            return this;
        }

        private AzureFirewallNetworkRule GetNetworkRule(string name)
        {
            if (networkRuleCollection != null && networkRuleCollection.Rules != null)
            {
                foreach (var rule in networkRuleCollection.Rules)
                {
                    if (string.Equals(name, rule.Name))
                    {
                        networkRule = rule;
                        return rule;
                    }
                }
            }
            return null;
        }

        private AzureFirewallImpl DefineAzureFirewallNetworkRuleCollection(string name)
        {
            if (Inner.NetworkRuleCollections == null)
            {
                Inner.NetworkRuleCollections = new List<AzureFirewallNetworkRuleCollectionInner>();
            }
            else if (GetNetworkRuleCollection(name) != null)
            {
                throw new ArgumentException(string.Format("Network rule collection %s is already existing.", name));
            }
            networkRuleCollection = new AzureFirewallNetworkRuleCollectionInner
            {
                Name = name
            };
            Inner.NetworkRuleCollections.Add(networkRuleCollection);
            return this;
        }

        private AzureFirewallImpl UpdateAzureFirewallNetworkRuleCollection(string name)
        {
            if (GetNetworkRuleCollection(name) == null)
            {
                throw new ArgumentException(string.Format("Network rule collection %s is not found.", name));
            }
            return this;
        }

        private AzureFirewallImpl WithoutAzureFirewallNetworkRuleCollection(string name)
        {
            if (GetNetworkRuleCollection(name) != null)
            {
                Inner.NetworkRuleCollections.Remove(networkRuleCollection);
            }
            return this;
        }

        private AzureFirewallNetworkRuleCollectionInner GetNetworkRuleCollection(string name)
        {
            if (Inner.NetworkRuleCollections != null)
            {
                foreach (var collection in Inner.NetworkRuleCollections)
                {
                    if (string.Equals(name, collection.Name))
                    {
                        networkRuleCollection = collection;
                        return collection;
                    }
                }
            }
            return null;
        }

        private AzureFirewallImpl WithAdditionalProperties(IDictionary<string, string> additionalProperties)
        {
            Inner.AdditionalProperties = additionalProperties;
            return this;
        }

        private AzureFirewallImpl WithAdditionalProperty(string key, string value)
        {
            if (Inner.AdditionalProperties == null)
            {
                Inner.AdditionalProperties = new Dictionary<String, String>();
            }
            Inner.AdditionalProperties.Add(key, value);
            return this;
        }

        private AzureFirewallImpl WithoutAdditionalProperty(string key)
        {
            if (Inner.AdditionalProperties != null)
            {
                Inner.AdditionalProperties.Remove(key);
            }
            return this;
        }

        private AzureFirewallImpl WithAlertModeForThreatIntel()
        {
            Inner.ThreatIntelMode = AzureFirewallThreatIntelMode.Alert;
            return this;
        }

        private AzureFirewallImpl WithAllowActionTypeInApplicationRuleCollection()
        {
            applicationRuleCollection.Action = new AzureFirewallRCAction(AzureFirewallRCActionType.Allow);
            return this;
        }

        private AzureFirewallImpl WithAllowActionTypeInNetworkRuleCollection()
        {
            networkRuleCollection.Action = new AzureFirewallRCAction(AzureFirewallRCActionType.Allow);
            return this;
        }

        private AzureFirewallImpl WithAnyProtocolInNatRule()
        {
            if (natRule.Protocols == null)
            {
                natRule.Protocols = new List<AzureFirewallNetworkRuleProtocol>();
            }
            natRule.Protocols.Add(AzureFirewallNetworkRuleProtocol.Any);
            return this;
        }

        private AzureFirewallImpl WithAnyProtocolInNetworkRule()
        {
            if (networkRule.Protocols == null)
            {
                networkRule.Protocols = new List<AzureFirewallNetworkRuleProtocol>();
            }
            networkRule.Protocols.Add(AzureFirewallNetworkRuleProtocol.Any);
            return this;
        }

        private AzureFirewallImpl WithAzureFirewallHubSkuName()
        {
            if (Inner.Sku == null)
            {
                Inner.Sku = new AzureFirewallSku();
            }
            Inner.Sku.Name = AzureFirewallSkuName.AZFWHub;
            return this;
        }

        private AzureFirewallImpl WithAzureFirewallVnetSkuName()
        {
            if (Inner.Sku == null)
            {
                Inner.Sku = new AzureFirewallSku();
            }
            Inner.Sku.Name = AzureFirewallSkuName.AZFWVNet;
            return this;
        }

        private AzureFirewallImpl WithDenyActionTypeInApplicationRuleCollection()
        {
            applicationRuleCollection.Action = new AzureFirewallRCAction(AzureFirewallRCActionType.Deny);
            return this;
        }

        private AzureFirewallImpl WithDenyActionTypeInNetworkRuleCollection()
        {
            networkRuleCollection.Action = new AzureFirewallRCAction(AzureFirewallRCActionType.Deny);
            return this;
        }

        private AzureFirewallImpl WithDenyModeForThreatIntel()
        {
            Inner.ThreatIntelMode = AzureFirewallThreatIntelMode.Deny;
            return this;
        }

        private AzureFirewallImpl WithDescriptionInApplicationRule(string description)
        {
            applicationRule.Description = description;
            return this;
        }

        private AzureFirewallImpl WithDescriptionInNatRule(string description)
        {
            natRule.Description = description;
            return this;
        }

        private AzureFirewallImpl WithDescriptionInNetworkRule(string description)
        {
            networkRule.Description = description;
            return this;
        }

        private AzureFirewallImpl WithDestinationAddressInNatRule(string destinationAddress)
        {
            if (natRule.DestinationAddresses == null)
            {
                natRule.DestinationAddresses = new List<string>();
            }
            natRule.DestinationAddresses.Add(destinationAddress);
            return this;
        }

        private AzureFirewallImpl WithDestinationAddressesInNatRule(IList<string> destinationAddresses)
        {
            natRule.DestinationAddresses = destinationAddresses;
            return this;
        }

        private AzureFirewallImpl WithDestinationAddressInNetworkRule(string destinationAddress)
        {
            if (networkRule.DestinationAddresses == null)
            {
                networkRule.DestinationAddresses = new List<string>();
            }
            networkRule.DestinationAddresses.Add(destinationAddress);
            return this;
        }

        private AzureFirewallImpl WithDestinationAddressesInNetworkRule(IList<string> destinationAddresses)
        {
            networkRule.DestinationAddresses = destinationAddresses;
            return this;
        }

        private AzureFirewallImpl WithDestinationFullQualifiedDomainNameInNetworkRule(string domainName)
        {
            if (networkRule.DestinationFqdns == null)
            {
                networkRule.DestinationFqdns = new List<string>();
            }
            networkRule.DestinationFqdns.Add(domainName);
            return this;
        }

        private AzureFirewallImpl WithDestinationFullQualifiedDomainNamesInNetworkRule(IList<string> domainNames)
        {
            networkRule.DestinationFqdns = domainNames;
            return this;
        }

        private AzureFirewallImpl WithDestinationIpGroupInNetworkRule(string destinationIpGroup)
        {
            if (networkRule.DestinationIpGroups == null)
            {
                networkRule.DestinationIpGroups = new List<string>();
            }
            networkRule.DestinationIpGroups.Add(destinationIpGroup);
            return this;
        }

        private AzureFirewallImpl WithDestinationIpGroupsInNetworkRule(IList<string> destinationIpGroups)
        {
            networkRule.DestinationIpGroups = destinationIpGroups;
            return this;
        }

        private AzureFirewallImpl WithDestinationPortInNatRule(string destinationPort)
        {
            if (natRule.DestinationPorts == null)
            {
                natRule.DestinationPorts = new List<string>();
            }
            natRule.DestinationPorts.Add(destinationPort);
            return this;
        }

        private AzureFirewallImpl WithDestinationPortsInNatRule(IList<string> destinationPorts)
        {
            natRule.DestinationPorts = destinationPorts;
            return this;
        }

        private AzureFirewallImpl WithDestinationPortInNetworkRule(string destinationPort)
        {
            if (networkRule.DestinationPorts == null)
            {
                networkRule.DestinationPorts = new List<string>();
            }
            networkRule.DestinationPorts.Add(destinationPort);
            return this;
        }

        private AzureFirewallImpl WithDestinationPortsInNetworkRule(IList<string> destinationPorts)
        {
            networkRule.DestinationPorts = destinationPorts;
            return this;
        }

        private AzureFirewallImpl WithDnatActionType()
        {
            natRuleCollection.Action = new AzureFirewallNatRCAction(AzureFirewallNatRCActionType.Dnat);
            return this;
        }

        private AzureFirewallImpl WithFirewallPolicy(string firewallPolicyId)
        {
            Inner.FirewallPolicy = new SubResource(firewallPolicyId);
            return this;
        }

        private AzureFirewallImpl WithFullQualifiedDomainNameTagInApplicationRule(string tag)
        {
            if (applicationRule.FqdnTags == null)
            {
                applicationRule.FqdnTags = new List<string>();
            }
            applicationRule.FqdnTags.Add(tag);
            return this;
        }

        private AzureFirewallImpl WithFullQualifiedDomainNameTagsInApplicationRule(IList<string> tags)
        {
            applicationRule.FqdnTags = tags;
            return this;
        }

        private AzureFirewallImpl WithHttpProtocolInApplicationRule(int? port)
        {
            if (applicationRule.Protocols == null)
            {
                applicationRule.Protocols = new List<AzureFirewallApplicationRuleProtocol>();
            }
            applicationRule.Protocols.Add(
                new AzureFirewallApplicationRuleProtocol(
                    AzureFirewallApplicationRuleProtocolType.Http, 
                    port));
            return this;
        }

        private AzureFirewallImpl WithHttpsProtocolInApplicationRule(int? port)
        {
            if (applicationRule.Protocols == null)
            {
                applicationRule.Protocols = new List<AzureFirewallApplicationRuleProtocol>();
            }
            applicationRule.Protocols.Add(
                new AzureFirewallApplicationRuleProtocol(
                    AzureFirewallApplicationRuleProtocolType.Https,
                    port));
            return this;
        }

        private AzureFirewallImpl WithMssqlProtocolInApplicationRule(int? port)
        {
            if (applicationRule.Protocols == null)
            {
                applicationRule.Protocols = new List<AzureFirewallApplicationRuleProtocol>();
            }
            applicationRule.Protocols.Add(
                new AzureFirewallApplicationRuleProtocol(
                    AzureFirewallApplicationRuleProtocolType.Mssql,
                    port));
            return this;
        }

        private AzureFirewallImpl WithIcmpProtocolInNatRule()
        {
            if (natRule.Protocols == null)
            {
                natRule.Protocols = new List<AzureFirewallNetworkRuleProtocol>();
            }
            natRule.Protocols.Add(AzureFirewallNetworkRuleProtocol.ICMP);
            return this;
        }

        private AzureFirewallImpl WithIcmpProtocolInNetworkRule()
        {
            if (networkRule.Protocols == null)
            {
                networkRule.Protocols = new List<AzureFirewallNetworkRuleProtocol>();
            }
            networkRule.Protocols.Add(AzureFirewallNetworkRuleProtocol.ICMP);
            return this;
        }

        private AzureFirewallImpl WithOffModeForThreatIntel()
        {
            Inner.ThreatIntelMode = AzureFirewallThreatIntelMode.Off;
            return this;
        }

        private AzureFirewallImpl WithPriorityInApplicationRuleCollection(int priority)
        {
            applicationRuleCollection.Priority = priority;
            return this;
        }

        private AzureFirewallImpl WithPriorityInNatRuleCollection(int priority)
        {
            natRuleCollection.Priority = priority;
            return this;
        }

        private AzureFirewallImpl WithPriorityInNetworkRuleCollection(int priority)
        {
            networkRuleCollection.Priority = priority;
            return this;
        }

        private AzureFirewallImpl WithSnatActionTypeInNatRuleCollection()
        {
            natRuleCollection.Action = new AzureFirewallNatRCAction(AzureFirewallNatRCActionType.Snat);
            return this;
        }

        private AzureFirewallImpl WithSourceAddressInApplicationRule(string sourceAddress)
        {
            if (applicationRule.SourceAddresses == null)
            {
                applicationRule.SourceAddresses = new List<string>();
            }
            applicationRule.SourceAddresses.Add(sourceAddress);
            return this;
        }

        private AzureFirewallImpl WithSourceAddressesInApplicationRule(IList<string> sourceAddresses)
        {
            applicationRule.SourceAddresses = sourceAddresses;
            return this;
        }

        private AzureFirewallImpl WithSourceAddressInNatRule(string sourceAddress)
        {
            if (natRule.SourceAddresses == null)
            {
                natRule.SourceAddresses = new List<string>();
            }
            natRule.SourceAddresses.Add(sourceAddress);
            return this;
        }

        private AzureFirewallImpl WithSourceAddressesInNatRule(IList<string> sourceAddresses)
        {
            natRule.SourceAddresses = sourceAddresses;
            return this;
        }

        private AzureFirewallImpl WithSourceAddressInNetworkRule(string sourceAddress)
        {
            if (networkRule.SourceAddresses == null)
            {
                networkRule.SourceAddresses = new List<string>();
            }
            networkRule.SourceAddresses.Add(sourceAddress);
            return this;
        }

        private AzureFirewallImpl WithSourceAddressesInNetworkRule(IList<string> sourceAddresses)
        {
            networkRule.SourceAddresses = sourceAddresses;
            return this;
        }

        private AzureFirewallImpl WithSourceIpGroupInApplicationRule(string sourceIpGroup)
        {
            if (applicationRule.SourceIpGroups == null)
            {
                applicationRule.SourceIpGroups = new List<string>();
            }
            applicationRule.SourceIpGroups.Add(sourceIpGroup);
            return this;
        }

        private AzureFirewallImpl WithSourceIpGroupsInApplicationRule(IList<string> sourceIpGroups)
        {
            applicationRule.SourceIpGroups = sourceIpGroups;
            return this;
        }

        private AzureFirewallImpl WithSourceIpGroupInNetworkRule(string sourceIpGroup)
        {
            if (networkRule.SourceIpGroups == null)
            {
                networkRule.SourceIpGroups = new List<string>();
            }
            networkRule.SourceIpGroups.Add(sourceIpGroup);
            return this;
        }

        private AzureFirewallImpl WithSourceIpGroupsInNetworkRule(IList<string> sourceIpGroups)
        {
            networkRule.SourceIpGroups = sourceIpGroups;
            return this;
        }

        private AzureFirewallImpl WithStandardSkuTier()
        {
            if (Inner.Sku == null)
            {
                Inner.Sku = new AzureFirewallSku();
            }
            Inner.Sku.Tier = AzureFirewallSkuTier.Standard;
            return this;
        }

        private AzureFirewallImpl WithTargetFullQualifiedDomainNameInApplicationRule(string domainName)
        {
            if (applicationRule.TargetFqdns == null)
            {
                applicationRule.TargetFqdns = new List<string>();
            }
            applicationRule.TargetFqdns.Add(domainName);
            return this;
        }

        private AzureFirewallImpl WithTargetFullQualifiedDomainNamesInApplicationRule(IList<string> domainNames)
        {
            applicationRule.TargetFqdns = domainNames;
            return this;
        }

        private AzureFirewallImpl WithTcpProtocolInNatRule()
        {
            if (natRule.Protocols == null)
            {
                natRule.Protocols = new List<AzureFirewallNetworkRuleProtocol>();
            }
            natRule.Protocols.Add(AzureFirewallNetworkRuleProtocol.TCP);
            return this;
        }

        private AzureFirewallImpl WithTcpProtocolInNetworkRule()
        {
            if (networkRule.Protocols == null)
            {
                networkRule.Protocols = new List<AzureFirewallNetworkRuleProtocol>();
            }
            networkRule.Protocols.Add(AzureFirewallNetworkRuleProtocol.TCP);
            return this;
        }

        private AzureFirewallImpl WithUdpProtocolInNatRule()
        {
            if (natRule.Protocols == null)
            {
                natRule.Protocols = new List<AzureFirewallNetworkRuleProtocol>();
            }
            natRule.Protocols.Add(AzureFirewallNetworkRuleProtocol.UDP);
            return this;
        }

        private AzureFirewallImpl WithUdpProtocolInNetworkRule()
        {
            if (networkRule.Protocols == null)
            {
                networkRule.Protocols = new List<AzureFirewallNetworkRuleProtocol>();
            }
            networkRule.Protocols.Add(AzureFirewallNetworkRuleProtocol.UDP);
            return this;
        }

        private AzureFirewallImpl WithVirtualHub(string virtualHubId)
        {
            Inner.VirtualHub = new SubResource(virtualHubId);
            return this;
        }

        private AzureFirewallImpl WithZone(string zone)
        {
            if (Inner.Zones == null)
            {
                Inner.Zones = new List<string>();
            }
            Inner.Zones.Add(zone);
            return this;
        }

        private AzureFirewallImpl WithoutZone(string zone)
        {
            if (Inner.Zones != null)
            {
                Inner.Zones.Remove(zone);
            }
            return this;
        }

        private AzureFirewallImpl WithZones(IList<string> zones)
        {
            Inner.Zones = zones;
            return this;
        }

        private AzureFirewallImpl WithSubnet(string subnetId)
        {
            InitIpConfiguratioin();
            ipConfiguration.Subnet = new SubResource(subnetId);
            return this;
        }

        private AzureFirewallImpl WithPublicIpAddress(string publicIpAddressId)
        {
            InitIpConfiguratioin();
            ipConfiguration.PublicIPAddress = new SubResource(publicIpAddressId);
            return this;
        }

        private void InitIpConfiguratioin()
        {
            if (ipConfiguration == null)
            {
                ipConfiguration = new AzureFirewallIPConfigurationInner();
            }
            if (Inner.IpConfigurations == null)
            {
                Inner.IpConfigurations = new List<AzureFirewallIPConfigurationInner>();
            }
        }

        private void ResetAll()
        {
            applicationRuleCollection = null;
            natRuleCollection = null;
            networkRuleCollection = null;
            ipConfiguration = null;
            applicationRule = null;
            natRule = null;
            networkRule = null;
        }
    }
}
