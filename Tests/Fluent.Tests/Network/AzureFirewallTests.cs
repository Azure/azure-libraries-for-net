// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
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
                        .WithAzfwVnetSkuName()
                        .WithAlertModeForThreatIntel()
                        .Create();

                    Assert.NotNull(azureFirewall);
                    Assert.True(azureFirewall.ApplicationRuleCollections.Count == 1);
                    Assert.Equal(AzureFirewallRCActionType.Allow, azureFirewall.ApplicationRuleCollections[0].Action.Type);
                    Assert.True(azureFirewall.ApplicationRuleCollections[0].Rules.Count == 1);
                    Assert.Equal("Allow-Google", azureFirewall.ApplicationRuleCollections[0].Rules[0].Name);
                    Assert.Equal(AzureFirewallSkuName.AZFWVNet, azureFirewall.Sku.Name);
                    Assert.Equal(AzureFirewallThreatIntelMode.Alert, azureFirewall.ThreatIntelMode);
                    Assert.True(azureFirewall.AdditionalProperties.Count == 0);

                    azureFirewall.Update()
                        .WithDenyModeForThreatIntel()
                        .WithAdditionalProperty("key1", "valueToAdd")
                        .Apply();

                    Assert.Equal(AzureFirewallThreatIntelMode.Deny, azureFirewall.ThreatIntelMode);
                    Assert.True(azureFirewall.AdditionalProperties.Count == 1);
                    Assert.True(azureFirewall.AdditionalProperties.ContainsKey("key1"));

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
