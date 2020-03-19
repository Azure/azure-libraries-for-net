// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Xunit;

namespace Fluent.Tests.Network
{
    public class AzureFirewall
    {
        private static Region REGION = Region.AsiaSouthEast;

        [Fact]
        public void CanCreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = SdkContext.RandomResourceName("rg", 10);
                var fwName = SdkContext.RandomResourceName("azfw", 10);

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    var resourceGroup = azure.ResourceGroups.Define(rgName)
                        .WithRegion(REGION)
                        .Create();

                    var azureFirewall = azure.AzureFirewalls.Define(fwName)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithRegion(REGION)
                        .DefineAzureFirewallApplicationRuleCollection("App-Coll01")
                            .DefineAzureFirewallApplicationRule("Allow-Google")
                                .WithSourceAddress("10.0.2.0/24")
                                .WithHttpProtocol(8080)
                                .WithHttpsProtocol(8081)
                                .WithTargetFullQualifiedDomainName("www.google.com")
                                .Attach()
                            .WithPriority(200)
                            .WithAllowActionType()
                            .Attach()
                        .DefineAzureFirewallNetworkRuleCollection("RCNet01")
                            .DefineAzureFirewallNetworkRule("Allow-DNS")
                                .WithUdpProtocol()
                                .WithSourceAddress("10.0.2.0/24")
                                .WithDestinationAddress("209.244.0.3")
                                .WithDestinationAddress("209.244.0.4")
                                .WithDestinationPort("53")
                                .Attach()
                            .WithAllowActionType()
                            .WithPriority(200)
                            .Attach()
                        .WithAzureFirewallVnetSkuName()
                        .WithAlertModeForThreatIntel()
                        .Create();

                    //validate azure firewall
                    Assert.NotNull(azureFirewall);
                    Assert.Equal(AzureFirewallSkuName.AZFWVNet, azureFirewall.Sku.Name);
                    Assert.Equal(AzureFirewallThreatIntelMode.Alert, azureFirewall.ThreatIntelMode);
                    Assert.True(azureFirewall.AdditionalProperties.Count == 0);
                    //validate application rule collections
                    Assert.True(azureFirewall.ApplicationRuleCollections.Count == 1);
                    Assert.Equal(AzureFirewallRCActionType.Allow, azureFirewall.ApplicationRuleCollections[0].Action.Type);
                    Assert.True(azureFirewall.ApplicationRuleCollections[0].Rules.Count == 1);
                    Assert.True(azureFirewall.ApplicationRuleCollections[0].Priority == 200);
                    Assert.Equal("Allow-Google", azureFirewall.ApplicationRuleCollections[0].Rules[0].Name);
                    //validate network rule collections
                    Assert.True(azureFirewall.NetworkRuleCollections.Count == 1);
                    Assert.True(azureFirewall.NetworkRuleCollections[0].Rules.Count == 1);

                    azureFirewall.Update()
                        .WithDenyModeForThreatIntel()
                        .WithAdditionalProperty("key1", "valueToAdd")
                        .UpdateAzureFirewallNetworkRuleCollection("RCNet01")
                            .DefineAzureFirewallNetworkRule("Allow-SPEC")
                                .WithUdpProtocol()
                                .WithSourceAddress("10.0.1.0/24")
                                .WithDestinationAddress("209.244.0.5")
                                .WithDestinationAddress("209.244.0.6")
                                .WithDestinationPort("33")
                                .Attach()
                            .Attach()
                        .UpdateAzureFirewallApplicationRuleCollection("App-Coll01")
                            .UpdateAzureFirewallApplicationRule("Allow-Google")
                                .WithDescription("Updated v1")
                                .Attach()
                            .WithPriority(220)
                            .Attach()
                        .DefineAzureFirewallApplicationRuleCollection("App-Coll02")
                            .DefineAzureFirewallApplicationRule("Allow-LinkedIn")
                                .WithSourceAddress("10.0.1.0/24")
                                .WithHttpProtocol(1020)
                                .WithHttpsProtocol(1021)
                                .WithTargetFullQualifiedDomainName("www.linkedin.com")
                                .Attach()
                            .WithPriority(101)
                            .WithAllowActionType()
                            .Attach()
                        .Apply();

                    //validate azure firewall
                    Assert.Equal(AzureFirewallThreatIntelMode.Deny, azureFirewall.ThreatIntelMode);
                    Assert.True(azureFirewall.AdditionalProperties.Count == 1);
                    Assert.True(azureFirewall.AdditionalProperties.ContainsKey("key1"));
                    //validate application rule collections
                    Assert.True(azureFirewall.ApplicationRuleCollections.Count == 2);
                    IAzureFirewallApplicationRuleCollection collection1 = null;
                    IAzureFirewallApplicationRuleCollection collection2 = null;
                    foreach (var collection in azureFirewall.ApplicationRuleCollections)
                    {
                        if (string.Equals(collection.Name, "App-Coll01"))
                        {
                            collection1 = collection;
                        }
                        else if (string.Equals(collection.Name, "App-Coll02"))
                        {
                            collection2 = collection;
                        }
                    }
                    Assert.NotNull(collection1);
                    Assert.True(collection1.Priority == 220);
                    Assert.Equal("Updated v1", collection1.Rules[0].Description);

                    Assert.NotNull(collection2);
                    Assert.True(collection2.Rules.Count == 1);
                    Assert.Equal("Allow-LinkedIn", collection2.Rules[0].Name);
                    //validate network rule collections
                    Assert.True(azureFirewall.NetworkRuleCollections.Count == 1);
                    Assert.True(azureFirewall.NetworkRuleCollections[0].Rules.Count == 2);
                    Assert.Equal("Allow-DNS", azureFirewall.NetworkRuleCollections[0].Rules[0].Name);

                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
