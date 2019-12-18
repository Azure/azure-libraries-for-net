// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System.Linq;
using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Xunit;

namespace Fluent.Tests.Network
{
    public class ExpressRouteCircuit
    {
        private static Region REGION = Region.USNorthCentral;

        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string circuitName = SdkContext.RandomResourceName("erc", 10);
                var groupName = SdkContext.RandomResourceName("rg", 6);
                var manager = TestHelper.CreateNetworkManager();

                try
                { 
                    // create Express Route Circuit
                    IExpressRouteCircuit erc = manager.ExpressRouteCircuits.Define(circuitName)
                        .WithRegion(REGION)
                        .WithNewResourceGroup(groupName)
                        .WithServiceProvider("Microsoft ER Test")
                        .WithPeeringLocation("Area51")
                        .WithBandwidthInMbps(50)
                        .WithSku(ExpressRouteCircuitSkuType.StandardMeteredData)
                        .WithTag("tag1", "value1")
                        .Create();
                    erc.Update()
                        .WithTag("tag2", "value2")
                        .WithoutTag("tag1")
                        .WithBandwidthInMbps(200)
                        .WithSku(ExpressRouteCircuitSkuType.PremiumUnlimitedData)
                        .Apply();
                    erc.Refresh();
                    Assert.True(erc.Tags.ContainsKey("tag2"));
                    Assert.True(!erc.Tags.ContainsKey("tag1"));
                    Assert.Equal(200, erc.ServiceProviderProperties.BandwidthInMbps);
                    Assert.Equal(ExpressRouteCircuitSkuType.PremiumUnlimitedData, erc.Sku);
                    manager.ExpressRouteCircuits.DeleteById(erc.Id);
                    manager.ResourceManager.ResourceGroups.DeleteByName(groupName);
                }
                finally
                {
                    try
                    {
                        manager.ResourceManager.ResourceGroups.DeleteByName(groupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreatePeering()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string circuitName = SdkContext.RandomResourceName("erc", 10);
                var groupName = SdkContext.RandomResourceName("rg", 6);
                var manager = TestHelper.CreateNetworkManager();

                try
                {
                    // create Express Route Circuit
                    IExpressRouteCircuit erc = manager.ExpressRouteCircuits.Define(circuitName)
                        .WithRegion(REGION)
                        .WithNewResourceGroup(groupName)
                        .WithServiceProvider("Microsoft ER Test")
                        .WithPeeringLocation("Area51")
                        .WithBandwidthInMbps(50)
                        .WithSku(ExpressRouteCircuitSkuType.PremiumMeteredData)
                        .WithTag("tag1", "value1")
                        .Create();
                    erc.Peerings.DefineMicrosoftPeering()
                        .WithAdvertisedPublicPrefixes("124.1.0.0/24")
                        .WithPrimaryPeerAddressPrefix("124.0.0.0/30")
                        .WithSecondaryPeerAddressPrefix("124.0.0.4/30")
                        .WithVlanId(200)
                        .WithPeerAsn(100)
                        .Create();
                    Assert.Equal(1, erc.PeeringsMap.Count);
                    Assert.True(erc.PeeringsMap.ContainsKey(ExpressRoutePeeringType.MicrosoftPeering.ToString()));
                    var peering = erc.PeeringsMap[ExpressRoutePeeringType.MicrosoftPeering.ToString()]
                            .Update()
                            .WithVlanId(300)
                            .WithPeerAsn(101)
                            .WithSecondaryPeerAddressPrefix("124.0.0.8/30")
                            .Apply();
                    Assert.Equal(300, peering.VlanId);
                    Assert.Equal(101, peering.PeerAsn);
                    Assert.Equal("124.0.0.8/30", peering.SecondaryPeerAddressPrefix);
                    manager.ResourceManager.ResourceGroups.BeginDeleteByName(groupName);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(groupName);
                    }
                    catch { }
                }
            }
        }
    }
}