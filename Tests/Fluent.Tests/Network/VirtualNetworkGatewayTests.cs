// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Tests;
using Fluent.Tests.Common;
using Fluent.Tests.Compute;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Xunit.Abstractions;

namespace Fluent.Tests.Network
{
    public class VirtualNetworkGatewayTest
    {
        private static Region REGION = Region.USWest;
        public VirtualNetworkGatewayTest(ITestOutputHelper output)
        {
             TestHelper.TestLogger = output;
             ServiceClientTracing.IsEnabled = true;
             ServiceClientTracing.AddTracingInterceptor(new XunitTracingInterceptor(output));
        }

        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string gatewayName = SdkContext.RandomResourceName("vngw", 10);
                var groupName = SdkContext.RandomResourceName("rg", 6);
                var manager = TestHelper.CreateNetworkManager();

                // Create virtual network gateway
                IVirtualNetworkGateway vngw = manager.VirtualNetworkGateways.Define(gatewayName)
                    .WithRegion(REGION)
                    .WithNewResourceGroup(groupName)
                    .WithNewNetwork("10.0.0.0/25", "10.0.0.0/27")
                    .WithRouteBasedVpn()
                    .WithSku(VirtualNetworkGatewaySkuName.VpnGw1)
                    .WithTag("tag1", "value1")
                    .Create();
                var resource = manager.VirtualNetworkGateways.GetByResourceGroup(groupName, gatewayName);
                resource = resource.Update()
                    .WithTag("tag2", "value2")
                    .WithoutTag("tag1")
                    .Apply();
                Assert.True(resource.Tags.ContainsKey("tag2"));
                Assert.True(!resource.Tags.ContainsKey("tag1"));
                manager.VirtualNetworkGateways.DeleteById(resource.Id);
                manager.ResourceManager.ResourceGroups.DeleteByName(groupName);
            }
        }

        [Fact]
        public void CanCreateSiteToSiteConnection()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string vpnGatewayName = SdkContext.RandomResourceName("vngw", 10);
                string localGatewayName = SdkContext.RandomResourceName("lngw", 10);
                var groupName = SdkContext.RandomResourceName("rg", 6);
                var manager = TestHelper.CreateNetworkManager();
                var connectionName = "myNewConnection";

                // Create virtual network gateway
                IVirtualNetworkGateway vngw = manager.VirtualNetworkGateways.Define(vpnGatewayName)
                    .WithRegion(REGION)
                    .WithNewResourceGroup(groupName)
                    .WithNewNetwork("10.0.0.0/25", "10.0.0.0/27")
                    .WithRouteBasedVpn()
                    .WithSku(VirtualNetworkGatewaySkuName.VpnGw1)
                    .Create();
                var lngw = manager.LocalNetworkGateways.Define(localGatewayName)
                    .WithRegion(vngw.Region)
                    .WithExistingResourceGroup(vngw.ResourceGroupName)
                    .WithIPAddress("40.71.184.214")
                    .WithAddressSpace("192.168.3.0/24")
                    .Create();
                vngw.Connections
                    .Define(connectionName)
                    .WithSiteToSite()
                    .WithLocalNetworkGateway(lngw)
                    .WithSharedKey("MySecretKey")
                    .Create();

                Assert.Single(vngw.IPConfigurations);
                ISubnet subnet = vngw.IPConfigurations.First().GetSubnet();
                Assert.Equal("10.0.0.0/27", subnet.AddressPrefix);

                Assert.Equal("40.71.184.214", lngw.IPAddress);
                Assert.Single(lngw.AddressSpaces);
                Assert.Equal("192.168.3.0/24", lngw.AddressSpaces.First());

                var connections = vngw.ListConnections();
                Assert.Single(connections);
                Assert.Equal(vngw.Id, connections.First().VirtualNetworkGateway1Id);
                Assert.Equal(lngw.Id, connections.First().LocalNetworkGateway2Id);

                vngw.Connections.DeleteByName(connectionName);
                connections = vngw.ListConnections();
                Assert.Empty(connections);
                manager.ResourceManager.ResourceGroups.DeleteByName(groupName);
            }
        }

        [Fact]
        public void CanCreateVNetToVNetConnection()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string vpnGatewayName = SdkContext.RandomResourceName("vngw", 10);
                string vpnGatewayName2 = SdkContext.RandomResourceName("vngw2", 10);
                var groupName = SdkContext.RandomResourceName("rg", 6);
                var manager = TestHelper.CreateNetworkManager();
                var connectionName = "myNewConnection";

                // Create first virtual network gateway
                var vngw1 = manager.VirtualNetworkGateways.Define(vpnGatewayName)
                    .WithRegion(REGION)
                    .WithNewResourceGroup(groupName)
                    .WithNewNetwork("10.11.0.0/16", "10.11.255.0/27")
                    .WithRouteBasedVpn()
                    .WithSku(VirtualNetworkGatewaySkuName.VpnGw1)
                    .Create();

                var vngw2 = manager.VirtualNetworkGateways.Define(vpnGatewayName2)
                    .WithRegion(REGION)
                    .WithNewResourceGroup(groupName)
                    .WithNewNetwork("10.41.0.0/16", "10.41.255.0/27")
                    .WithRouteBasedVpn()
                    .WithSku(VirtualNetworkGatewaySkuName.VpnGw1)
                    .Create();

                vngw1.Connections
                    .Define(connectionName)
                    .WithVNetToVNet()
                    .WithSecondVirtualNetworkGateway(vngw2)
                    .WithSharedKey("MySecretKey")
                    .Create();
                var connections = vngw1.ListConnections();
                Assert.Single(connections);
                Assert.Equal(vngw1.Id, connections.First().VirtualNetworkGateway1Id);
                Assert.Equal(vngw2.Id, connections.First().VirtualNetworkGateway2Id);
               
                vngw1.Connections.DeleteByName(connectionName);
                connections = vngw1.ListConnections();
                Assert.Empty(connections);
                manager.ResourceManager.ResourceGroups.DeleteByName(groupName);
            }
        }
    }
}