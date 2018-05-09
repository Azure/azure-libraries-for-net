// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Text;
using Xunit;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Rest;
using Xunit.Abstractions;

namespace Fluent.Tests.Network
{
    public class Network
    {
        [Fact]
        public void CreateUpdatePeering()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var testId = TestUtilities.GenerateName("");
                Region region = Region.USEast;
                string groupName = "rg" + testId;
                string networkName = "netA" + testId;
                string networkName2 = "netB" + testId;
                var networks = TestHelper.CreateNetworkManager().Networks;

                try
                { 
                    // Create networks
                    ICreatable<INetwork> remoteNetworkDefinition = networks.Define(networkName2)
                            .WithRegion(region)
                            .WithNewResourceGroup(groupName)
                            .WithAddressSpace("10.1.0.0/27")
                            .WithSubnet("subnet3", "10.1.0.0/27");

                    ICreatable<INetwork> localNetworkDefinition = networks.Define(networkName)
                            .WithRegion(region)
                            .WithNewResourceGroup(groupName)
                            .WithAddressSpace("10.0.0.0/27")
                            .WithSubnet("subnet1", "10.0.0.0/28")
                            .WithSubnet("subnet2", "10.0.0.16/28");

                    var createdNetworks = networks.Create(remoteNetworkDefinition, localNetworkDefinition);
                    INetwork localNetwork = createdNetworks.FirstOrDefault(o => o.Key == localNetworkDefinition.Key);
                    Assert.NotNull(localNetwork);
                    INetwork remoteNetwork = createdNetworks.FirstOrDefault(o => o.Key == remoteNetworkDefinition.Key);
                    Assert.NotNull(remoteNetwork);

                    // Create peering
                    INetworkPeering localPeering = localNetwork.Peerings.Define("peer0")
                        .WithRemoteNetwork(remoteNetwork)

                        // Optionals
                        .WithTrafficForwardingBetweenBothNetworks()
                        .WithoutAccessFromEitherNetwork()
                        .WithGatewayUseByRemoteNetworkAllowed()
                        .Create();

                    // Verify local peering
                    Assert.NotNull(localNetwork.Peerings);
                    var localPeerings = localNetwork.Peerings.List();
                    Assert.Single(localPeerings);
                    localPeering = localPeerings.FirstOrDefault();
                    Assert.NotNull(localPeering);
                    Assert.Equal("peer0", localPeering.Name, true);
                    Assert.Equal(VirtualNetworkPeeringState.Connected, localPeering.State);
                    Assert.True(localPeering.IsTrafficForwardingFromRemoteNetworkAllowed);
                    Assert.False(localPeering.CheckAccessBetweenNetworks());
                    Assert.Equal(NetworkPeeringGatewayUse.ByRemoteNetwork, localPeering.GatewayUse);

                    // Verify remote peering
                    Assert.NotNull(remoteNetwork.Peerings);
                    Assert.Single(remoteNetwork.Peerings.List());
                    INetworkPeering remotePeering = localPeering.GetRemotePeering();
                    Assert.NotNull(remotePeering);
                    Assert.Equal(localNetwork.Id, remotePeering.RemoteNetworkId, true);
                    Assert.Equal(VirtualNetworkPeeringState.Connected, remotePeering.State);
                    Assert.True(remotePeering.IsTrafficForwardingFromRemoteNetworkAllowed);
                    Assert.False(remotePeering.CheckAccessBetweenNetworks());
                    Assert.Equal(NetworkPeeringGatewayUse.None, remotePeering.GatewayUse);

                    // Update peering
                    localPeering = localNetwork.Peerings.List().FirstOrDefault();
                    Assert.NotNull(localPeering);

                    // Verify remote IP invisibility to local network before peering
                    remoteNetwork = localPeering.GetRemoteNetwork();
                    Assert.NotNull(remoteNetwork);
                    ISubnet remoteSubnet = remoteNetwork.Subnets["subnet3"];
                    Assert.NotNull(remoteSubnet);
                    var remoteAvailableIPs = remoteSubnet.ListAvailablePrivateIPAddresses();
                    Assert.NotNull(remoteAvailableIPs);
                    Assert.NotEmpty(remoteAvailableIPs);
                    string remoteTestIP = remoteAvailableIPs.FirstOrDefault();
                    Assert.False(localNetwork.IsPrivateIPAddressAvailable(remoteTestIP));

                    localPeering.Update()
                        .WithoutTrafficForwardingFromEitherNetwork()
                        .WithAccessBetweenBothNetworks()
                        .WithoutAnyGatewayUse()
                        .Apply();

                    // Verify local peering changes
                    Assert.False(localPeering.IsTrafficForwardingFromRemoteNetworkAllowed);
                    Assert.True(localPeering.CheckAccessBetweenNetworks());
                    Assert.Equal(NetworkPeeringGatewayUse.None, localPeering.GatewayUse);

                    // Verify remote peering changes
                    remotePeering = localPeering.GetRemotePeering();
                    Assert.NotNull(remotePeering);
                    Assert.False(remotePeering.IsTrafficForwardingFromRemoteNetworkAllowed);
                    Assert.True(remotePeering.CheckAccessBetweenNetworks());
                    Assert.Equal(NetworkPeeringGatewayUse.None, remotePeering.GatewayUse);

                    // Delete the peering
                    localNetwork.Peerings.DeleteById(remotePeering.Id);

                    // Verify deletion
                    Assert.Empty(localNetwork.Peerings.List());
                    Assert.Empty(remoteNetwork.Peerings.List());

                    // Cleanup
                    networks.Manager.ResourceManager.ResourceGroups.BeginDeleteByName(groupName);
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
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var testId = TestUtilities.GenerateName("");

                string newName = "net" + testId;
                var region = Region.USWest;
                var groupName = "rg" + testId;

                try
                { 
                    // Create an NSG
                    var manager = TestHelper.CreateNetworkManager();
                    var nsg = manager.NetworkSecurityGroups.Define("nsg" + testId)
                        .WithRegion(region)
                        .WithNewResourceGroup(groupName)
                        .Create();

                    // Create a network
                    INetwork network = manager.Networks.Define(newName)
                            .WithRegion(region)
                            .WithNewResourceGroup(groupName)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithAddressSpace("10.1.0.0/28")
                            .WithSubnet("subnetA", "10.0.0.0/29")
                            .DefineSubnet("subnetB")
                                .WithAddressPrefix("10.0.0.8/29")
                                .WithExistingNetworkSecurityGroup(nsg)
                                .Attach()
                            .Create();

                    // Verify address spaces
                    Assert.Equal(2, network.AddressSpaces.Count);
                    Assert.Contains("10.1.0.0/28", network.AddressSpaces);

                    // Verify subnets
                    Assert.Equal(2, network.Subnets.Count);
                    ISubnet subnet = network.Subnets["subnetA"];
                    Assert.Equal("10.0.0.0/29", subnet.AddressPrefix);
                    subnet = network.Subnets["subnetB"];
                    Assert.Equal("10.0.0.8/29", subnet.AddressPrefix);
                    Assert.Equal(nsg.Id, subnet.NetworkSecurityGroupId, ignoreCase: true);

                    // Verify NSG
                    var subnets = nsg.Refresh().ListAssociatedSubnets();
                    Assert.Equal(1, subnets.Count);
                    subnet = subnets[0];
                    Assert.Equal("subnetB", subnet.Name, ignoreCase: true);
                    Assert.Equal(subnet.Parent.Name, newName, ignoreCase: true);
                    Assert.NotNull(subnet.NetworkSecurityGroupId);
                    INetworkSecurityGroup nsg2 = subnet.GetNetworkSecurityGroup();
                    Assert.NotNull(nsg2);
                    Assert.Equal(nsg2.Id, nsg.Id, ignoreCase: true);

                    network = manager.Networks.GetByResourceGroup(groupName, newName);
                    network = network.Update()
                        .WithTag("tag1", "value1")
                        .WithTag("tag2", "value2")
                        .WithAddressSpace("141.25.0.0/16")
                        .WithoutAddressSpace("10.1.0.0/28")
                        .WithSubnet("subnetC", "141.25.0.0/29")
                        .WithoutSubnet("subnetA")
                        .UpdateSubnet("subnetB")
                            .WithAddressPrefix("141.25.0.8/29")
                            .WithoutNetworkSecurityGroup()
                            .Parent()
                        .DefineSubnet("subnetD")
                            .WithAddressPrefix("141.25.0.16/29")
                            .WithExistingNetworkSecurityGroup(nsg)
                            .Attach()
                        .Apply();

                    // Verify address spaces
                    Assert.Equal(2, network.AddressSpaces.Count);
                    Assert.DoesNotContain("10.1.0.0/28", network.AddressSpaces);

                    // Verify subnets
                    Assert.Equal(3, network.Subnets.Count);
                    Assert.False(network.Subnets.ContainsKey("subnetA"));

                    Assert.True(network.Subnets.ContainsKey("subnetB"));
                    subnet = network.Subnets["subnetB"];
                    Assert.Equal("141.25.0.8/29", subnet.AddressPrefix);
                    Assert.Null(subnet.NetworkSecurityGroupId);

                    Assert.True(network.Subnets.ContainsKey("subnetC"));
                    subnet = network.Subnets["subnetC"];
                    Assert.Equal("141.25.0.0/29", subnet.AddressPrefix);
                    Assert.Null(subnet.NetworkSecurityGroupId);

                    Assert.True(network.Subnets.ContainsKey("subnetD"));
                    subnet = network.Subnets["subnetD"];
                    Assert.NotNull(subnet);
                    Assert.Equal("141.25.0.16/29", subnet.AddressPrefix);
                    Assert.Equal(nsg.Id, subnet.NetworkSecurityGroupId, ignoreCase: true);

                    Assert.True(network.Tags.ContainsKey("tag1"));

                    manager.Networks.DeleteById(network.Id);
                    manager.NetworkSecurityGroups.DeleteById(nsg.Id);
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
        public void CreateUpdateSubnetServiceAccess()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var testId = TestUtilities.GenerateName("");
                string nwName = "net" + testId;
                var region = Region.USWest;
                var groupName = "rg" + testId;

                var manager = TestHelper.CreateNetworkManager();

                try
                { 
                    // Create a network
                    INetwork network = manager.Networks.Define(nwName)
                            .WithRegion(region)
                            .WithNewResourceGroup(groupName)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithSubnet("subnetA", "10.0.0.0/29")
                            .DefineSubnet("subnetB")
                                .WithAddressPrefix("10.0.0.8/29")
                                .WithAccessFromService(ServiceEndpointType.MicrosoftStorage)
                                .Attach()
                            .Create();

                    // Verify address spaces
                    Assert.Single(network.AddressSpaces);
                    Assert.Contains("10.0.0.0/28", network.AddressSpaces);

                    // Verify subnets
                    Assert.Equal(2, network.Subnets.Count);
                    Assert.True(network.Subnets.ContainsKey("subnetA"));

                    ISubnet subnet = network.Subnets["subnetA"];
                    Assert.Equal("10.0.0.0/29", subnet.AddressPrefix);

                    Assert.True(network.Subnets.ContainsKey("subnetB"));
                    subnet = network.Subnets["subnetB"];
                    Assert.Equal("10.0.0.8/29", subnet.AddressPrefix);
                    Assert.NotNull(subnet.ServicesWithAccess);
                    Assert.True(subnet.ServicesWithAccess.ContainsKey(ServiceEndpointType.MicrosoftStorage));
                    Assert.True(subnet.ServicesWithAccess[ServiceEndpointType.MicrosoftStorage].Count > 0);

                    network = network.Update()
                        .WithTag("tag1", "value1")
                        .WithTag("tag2", "value2")
                        .WithAddressSpace("141.25.0.0/16")
                        .WithoutAddressSpace("10.1.0.0/28")
                        .WithSubnet("subnetC", "141.25.0.0/29")
                        .WithoutSubnet("subnetA")
                        .UpdateSubnet("subnetB")
                            .WithAddressPrefix("141.25.0.8/29")
                            .WithoutAccessFromService(ServiceEndpointType.MicrosoftStorage)
                            .Parent()
                        .DefineSubnet("subnetD")
                            .WithAddressPrefix("141.25.0.16/29")
                            .WithAccessFromService(ServiceEndpointType.MicrosoftStorage)
                            .Attach()
                        .Apply();

                    Assert.True(network.Tags.ContainsKey("tag1"));

                    // Verify address spaces
                    Assert.Equal(2, network.AddressSpaces.Count);
                    Assert.DoesNotContain("10.1.0.0/28", network.AddressSpaces);

                    // Verify subnets
                    Assert.Equal(3, network.Subnets.Count);
                    Assert.False(network.Subnets.ContainsKey("subnetA"));

                    Assert.True(network.Subnets.ContainsKey("subnetB"));
                    subnet = network.Subnets["subnetB"];
                    Assert.NotNull(subnet);
                    Assert.Equal("141.25.0.8/29", subnet.AddressPrefix);
                    Assert.NotNull(subnet.ServicesWithAccess);
                    Assert.Empty(subnet.ServicesWithAccess);

                    Assert.True(network.Subnets.ContainsKey("subnetC"));
                    subnet = network.Subnets["subnetC"];
                    Assert.NotNull(subnet);
                    Assert.Equal("141.25.0.0/29", subnet.AddressPrefix);

                    Assert.True(network.Subnets.ContainsKey("subnetD"));
                    subnet = network.Subnets["subnetD"];
                    Assert.NotNull(subnet);
                    Assert.Equal("141.25.0.16/29", subnet.AddressPrefix);
                    Assert.NotNull(subnet.ServicesWithAccess);
                    Assert.True(subnet.ServicesWithAccess.ContainsKey(ServiceEndpointType.MicrosoftStorage));
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

        internal void Print(INetwork resource)
        {
            var info = new StringBuilder();
            info.Append("INetwork: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags)
                    .Append("\n\tAddress spaces: ").Append(resource.AddressSpaces)
                    .Append("\n\tDNS server IPs: ").Append(resource.DnsServerIPs);

            // Output subnets
            foreach (ISubnet subnet in resource.Subnets.Values)
            {
                info.Append("\n\tSubnet: ").Append(subnet.Name)
                    .Append("\n\t\tAddress prefix: ").Append(subnet.AddressPrefix)
                    .Append("\n\tAssociated NSG: ");

                INetworkSecurityGroup nsg;
                try
                {
                    nsg = subnet.GetNetworkSecurityGroup();
                }
                catch
                {
                    nsg = null;
                }

                if (null == nsg)
                {
                    info.Append("(None)");
                }
                else
                {
                    info.Append(nsg.ResourceGroupName + "/" + nsg.Name);
                }

                // Output services with access
                //
                var services = subnet.ServicesWithAccess;
                if (services.Count() > 0)
                {
                    info.Append("\n\tServices with access");
                    foreach (var service in services)
                    {
                        info.Append("\n\t\tService: ")
                                .Append(service.Key.ToString())
                                .Append(" Regions: " + service.Value + "");
                    }
                }
            }

            TestHelper.WriteLine(info.ToString());
        }
    }
}
