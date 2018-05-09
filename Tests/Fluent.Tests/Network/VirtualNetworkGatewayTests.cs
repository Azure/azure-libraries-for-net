// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
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
    public class VirtualNetworkGateway
    {
        private static Region REGION = Region.USWest;
        private static String CERTIFICATE_NAME = "myTest3.cer";

        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string gatewayName = SdkContext.RandomResourceName("vngw", 10);
                var groupName = SdkContext.RandomResourceName("rg", 6);
                var manager = TestHelper.CreateNetworkManager();

                try
                { 
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

                try
                { 
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

                try
                { 
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
                    vngw2.Connections
                        .Define(connectionName + "2")
                        .WithVNetToVNet()
                        .WithSecondVirtualNetworkGateway(vngw1)
                        .WithSharedKey("MySecretKey")
                        .Create();

                    var connections = vngw1.ListConnections();
                    Assert.Single(connections);
                    Assert.Equal(vngw1.Id, connections.First().VirtualNetworkGateway1Id);
                    Assert.Equal(vngw2.Id, connections.First().VirtualNetworkGateway2Id);
               
                    vngw1.Connections.DeleteByName(connectionName);
                    connections = vngw1.ListConnections();
                    Assert.Empty(connections);
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

        [Fact]
        public void CanCreatePointToSiteConfigurtation()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string vpnGatewayName = SdkContext.RandomResourceName("vngw", 10);
                string networkName = SdkContext.RandomResourceName("net", 10);
                var groupName = SdkContext.RandomResourceName("rg", 6);
                var manager = TestHelper.CreateNetworkManager();

                try
                { 
                    INetwork network = manager.Networks.Define(networkName)
                        .WithRegion(REGION)
                        .WithNewResourceGroup(groupName)
                        .WithAddressSpace("192.168.0.0/16")
                        .WithAddressSpace("10.254.0.0/16")
                        .WithSubnet("GatewaySubnet", "192.168.200.0/24")
                        .WithSubnet("FrontEnd", "192.168.1.0/24")
                        .WithSubnet("BackEnd", "10.254.1.0/24")
                        .Create();
                    IVirtualNetworkGateway vngw1 = manager.VirtualNetworkGateways.Define(vpnGatewayName)
                        .WithRegion(REGION)
                        .WithExistingResourceGroup(groupName)
                        .WithExistingNetwork(network)
                        .WithRouteBasedVpn()
                        .WithSku(VirtualNetworkGatewaySkuName.VpnGw1)
                        .Create();

                    vngw1.Update()
                        .DefinePointToSiteConfiguration()
                        .WithAddressPool("172.16.201.0/24")
                        .WithAzureCertificateFromFile(CERTIFICATE_NAME, new FileInfo(Path.Combine("Assets", "myTest3.cer")))
                        .Attach()
                        .Apply();

                    Assert.NotNull(vngw1.VpnClientConfiguration);
                    Assert.Equal("172.16.201.0/24", vngw1.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes.First());
                    Assert.Equal(1, vngw1.VpnClientConfiguration.VpnClientRootCertificates.Count);
                    Assert.Equal(CERTIFICATE_NAME, vngw1.VpnClientConfiguration.VpnClientRootCertificates.First().Name);
                    String profile = vngw1.GenerateVpnProfile();
                    Assert.NotNull(profile);

                    vngw1.Update().UpdatePointToSiteConfiguration()
                        .WithRevokedCertificate(CERTIFICATE_NAME, "bdf834528f0fff6eaae4c154e06b54322769276c")
                        .Parent()
                        .Apply();
                    Assert.Equal(CERTIFICATE_NAME, vngw1.VpnClientConfiguration.VpnClientRevokedCertificates.First().Name);

                    vngw1.Update().UpdatePointToSiteConfiguration()
                        .WithoutAzureCertificate(CERTIFICATE_NAME)
                        .Parent()
                        .Apply();
                    Assert.Equal(0, vngw1.VpnClientConfiguration.VpnClientRootCertificates.Count);
   
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