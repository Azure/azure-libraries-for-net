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
    public class NetworkWatcher
    {
        private static Region REGION = Region.USWest;

        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string newName = SdkContext.RandomResourceName("nw", 6);
                var groupName = SdkContext.RandomResourceName("rg", 6);
                var manager = TestHelper.CreateNetworkManager();

                try
                { 
                    // make sure Network Watcher is disabled in current subscription and region as only one can exist
                    EnsureNetworkWatcherNotExists(manager.NetworkWatchers);

                    // Create network watcher
                    var nw = manager.NetworkWatchers.Define(newName)
                        .WithRegion(REGION)
                        .WithNewResourceGroup(groupName)
                        .WithTag("tag1", "value1")
                        .Create();
                    var resource = manager.NetworkWatchers.GetByResourceGroup(groupName, newName);
                    resource = resource.Update()
                        .WithTag("tag2", "value2")
                        .WithoutTag("tag1")
                        .Apply();
                    Assert.True(resource.Tags.ContainsKey("tag2"));
                    Assert.True(!resource.Tags.ContainsKey("tag1"));
                    manager.NetworkWatchers.DeleteById(resource.Id);
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

        [Fact(Skip = "Temporary skipping until figure out Traffic Analytics usage woth Flow Log settings")]
        public void CanWatchNetwork()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string newName = SdkContext.RandomResourceName("nw", 6);
                var groupName = SdkContext.RandomResourceName("rg", 6);
                var resourcesGroupName = SdkContext.RandomResourceName("rg", 8);

                // Create network watcher
                var manager = TestHelper.CreateNetworkManager();
                var computeManager = TestHelper.CreateComputeManager();

                try
                { 
                    // make sure Network Watcher is disabled in current subscription and region as only one can exist
                    EnsureNetworkWatcherNotExists(manager.NetworkWatchers);

                    var nw = manager.NetworkWatchers.Define(newName)
                        .WithRegion(REGION)
                        .WithNewResourceGroup(groupName)
                        .Create();

                    // pre-create VMs to show topology on
                    ICreatedResources<IVirtualMachine> virtualMachines = EnsureNetwork(manager, computeManager, resourcesGroupName);
                    var vm0 = virtualMachines.ElementAt(0);
                    ITopology topology = nw.Topology()
                        .WithTargetResourceGroup(vm0.ResourceGroupName)
                        .Execute();
                    Assert.Equal(11, topology.Resources.Count);
                    Assert.True(topology.Resources.ContainsKey(vm0.PrimaryNetworkInterfaceId));
                    Assert.Equal(4, topology.Resources[vm0.PrimaryNetworkInterfaceId].Associations.Count);

                    ISecurityGroupView sgViewResult = nw.GetSecurityGroupView(virtualMachines.ElementAt(0).Id);
                    Assert.Equal(1, sgViewResult.NetworkInterfaces.Count);
                    Assert.Equal(virtualMachines.ElementAt(0).PrimaryNetworkInterfaceId,
                        sgViewResult.NetworkInterfaces.Keys.First());

                    IFlowLogSettings flowLogSettings =
                        nw.GetFlowLogSettings(vm0.GetPrimaryNetworkInterface().NetworkSecurityGroupId);
                    IStorageAccount storageAccount = EnsureStorageAccount(resourcesGroupName);
                    flowLogSettings.Update()
                        .WithLogging()
                        .WithStorageAccount(storageAccount.Id)
                        .WithRetentionPolicyDays(5)
                        .WithRetentionPolicyEnabled()
                        .Apply();
                    Assert.True(flowLogSettings.Enabled);
                    Assert.Equal(5, flowLogSettings.RetentionDays);
                    Assert.Equal(storageAccount.Id, flowLogSettings.StorageId);

                    INextHop nextHop = nw.NextHop().WithTargetResourceId(vm0.Id)
                        .WithSourceIPAddress("10.0.0.4")
                        .WithDestinationIPAddress("8.8.8.8")
                        .Execute();
                    Assert.Equal("System Route", nextHop.RouteTableId);
                    Assert.Equal(NextHopType.Internet, nextHop.NextHopType);
                    Assert.Null(nextHop.NextHopIpAddress);

                    IVerificationIPFlow verificationIPFlow = nw.VerifyIPFlow()
                        .WithTargetResourceId(vm0.Id)
                        .WithDirection(Direction.Outbound)
                        .WithProtocol(IpFlowProtocol.TCP)
                        .WithLocalIPAddress("10.0.0.4")
                        .WithRemoteIPAddress("8.8.8.8")
                        .WithLocalPort("443")
                        .WithRemotePort("443")
                        .Execute();
                    Assert.Equal(Access.Allow, verificationIPFlow.Access);
                    Assert.Equal("defaultSecurityRules/AllowInternetOutBound", verificationIPFlow.RuleName);

                    // test packet capture
                    IEnumerable<IPacketCapture> packetCaptures = nw.PacketCaptures.List();
                    Assert.Empty(packetCaptures);
                    IPacketCapture packetCapture = nw.PacketCaptures
                        .Define("NewPacketCapture")
                        .WithTarget(vm0.Id)
                        .WithStorageAccountId(storageAccount.Id)
                        .WithTimeLimitInSeconds(1500)
                        .DefinePacketCaptureFilter()
                            .WithProtocol(PcProtocol.TCP)
                            .WithLocalIPAddresses(new List<string>(){"127.0.0.1", "127.0.0.5"})
                            .Attach()
                        .Create();
                    packetCaptures = nw.PacketCaptures.List();
                    Assert.Single(packetCaptures);
                    Assert.Equal("NewPacketCapture", packetCapture.Name);
                    Assert.Equal(1500, packetCapture.TimeLimitInSeconds);
                    Assert.Equal(PcProtocol.TCP, packetCapture.Filters[0].Protocol);
                    Assert.Equal("127.0.0.1;127.0.0.5", packetCapture.Filters[0].LocalIPAddress);
                    //        Assert.assertEquals("Running", packetCapture.getStatus().packetCaptureStatus().toString());
                    packetCapture.Stop();
                    Assert.Equal("Stopped", packetCapture.GetStatus().PacketCaptureStatus.Value);
                    nw.PacketCaptures.DeleteByName(packetCapture.Name);
                    IConnectivityCheck connectivityCheck = nw.CheckConnectivity()
                        .ToDestinationResourceId(vm0.Id)
                        .ToDestinationPort(80)
                        .FromSourceVirtualMachine(virtualMachines.ElementAt(0).Id)
                        .Execute();
                    Assert.Equal("Reachable", connectivityCheck.ConnectionStatus.ToString());

                    computeManager.VirtualMachines.DeleteById(virtualMachines.ElementAt(1).Id);
                    topology.Execute();
                    Assert.Equal(10, topology.Resources.Count);

                    manager.ResourceManager.ResourceGroups.DeleteByName(nw.ResourceGroupName);
                    manager.ResourceManager.ResourceGroups.DeleteByName(resourcesGroupName);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(resourcesGroupName);
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(groupName);
                    }
                    catch { }
                }
            }
        }

        [Fact(Skip = "Server side change from returning empty response body to null response body for status code 202")]
        public void CanTroubleshootConnection()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string newName = SdkContext.RandomResourceName("nw", 6);
                var groupName = SdkContext.RandomResourceName("rg", 6);
                String gatewayName = SdkContext.RandomResourceName("vngw", 8);
                String connectionName = SdkContext.RandomResourceName("vngwc", 8);

                try
                { 
                    // Create network watcher
                    var manager = TestHelper.CreateNetworkManager();

                    // make sure Network Watcher is disabled in current subscription and region as only one can exist
                    EnsureNetworkWatcherNotExists(manager.NetworkWatchers);

                    var nw = manager.NetworkWatchers.Define(newName)
                        .WithRegion(REGION)
                        .WithNewResourceGroup(groupName)
                        .Create();

                    IVirtualNetworkGateway vngw1 = manager.VirtualNetworkGateways.Define(gatewayName)
                        .WithRegion(REGION)
                        .WithExistingResourceGroup(groupName)
                        .WithNewNetwork("10.11.0.0/16", "10.11.255.0/27")
                        .WithRouteBasedVpn()
                        .WithSku(VirtualNetworkGatewaySkuName.VpnGw1)
                        .Create();

                    IVirtualNetworkGateway vngw2 = manager.VirtualNetworkGateways.Define(gatewayName + "2")
                        .WithRegion(REGION)
                        .WithExistingResourceGroup(groupName)
                        .WithNewNetwork("10.41.0.0/16", "10.41.255.0/27")
                        .WithRouteBasedVpn()
                        .WithSku(VirtualNetworkGatewaySkuName.VpnGw1)
                        .Create();
                    IVirtualNetworkGatewayConnection connection1 = vngw1.Connections
                        .Define(connectionName)
                        .WithVNetToVNet()
                        .WithSecondVirtualNetworkGateway(vngw2)
                        .WithSharedKey("MySecretKey")
                        .Create();

                    // Create storage account to store troubleshooting information
                    IStorageAccount storageAccount = EnsureStorageAccount(groupName);

                    // Troubleshoot connection
                    ITroubleshooting troubleshooting = nw.Troubleshoot()
                        .WithTargetResourceId(connection1.Id)
                        .WithStorageAccount(storageAccount.Id)
                        .WithStoragePath(storageAccount.EndPoints.Primary.Blob + "results")
                        .Execute();
                    Assert.Equal("UnHealthy", troubleshooting.Code);

                    // Create corresponding connection on second gateway to make it work
                    vngw2.Connections
                        .Define(connectionName + "2")
                        .WithVNetToVNet()
                        .WithSecondVirtualNetworkGateway(vngw1)
                        .WithSharedKey("MySecretKey")
                        .Create();
                    TestHelper.Delay(250000);
                    troubleshooting = nw.Troubleshoot()
                        .WithTargetResourceId(connection1.Id)
                        .WithStorageAccount(storageAccount.Id)
                        .WithStoragePath(storageAccount.EndPoints.Primary.Blob + "results")
                        .Execute();
                    Assert.Equal("Healthy", troubleshooting.Code);

                    manager.ResourceManager.ResourceGroups.DeleteByName(nw.ResourceGroupName);
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

        // Helper method to pre-create infrastructure to test Network Watcher
        ICreatedResources<IVirtualMachine> EnsureNetwork(INetworkManager networkManager, IComputeManager computeManager, String groupName)
        {
            IVirtualMachines vms = computeManager.VirtualMachines;
            
            // Create an NSG
            INetworkSecurityGroup nsg = networkManager.NetworkSecurityGroups.Define(SdkContext.RandomResourceName("nsg", 8))
                .WithRegion(REGION)
                .WithNewResourceGroup(groupName)
                .Create();

            // Create a network for the VMs
            INetwork network = networkManager.Networks.Define(SdkContext.RandomResourceName("net", 8))
                .WithRegion(REGION)
                .WithExistingResourceGroup(groupName)
                .WithAddressSpace("10.0.0.0/28")
                .DefineSubnet("subnet1")
                    .WithAddressPrefix("10.0.0.0/29")
                    .WithExistingNetworkSecurityGroup(nsg)
                    .Attach()
                .WithSubnet("subnet2", "10.0.0.8/29")
                .Create();

            INetworkInterface nic = networkManager.NetworkInterfaces.Define(SdkContext.RandomResourceName("ni", 8))
                .WithRegion(REGION)
                .WithExistingResourceGroup(groupName)
                .WithNewPrimaryNetwork("10.0.0.0/28")
                .WithPrimaryPrivateIPAddressDynamic()
                .WithNewPrimaryPublicIPAddress(SdkContext.RandomResourceName("pip", 8))
                .WithIPForwarding()
                .WithExistingNetworkSecurityGroup(nsg)
                .Create();

            // Create the requested number of VM definitions
            String userName = "testuser";
            var vmDefinitions = new List<ICreatable<IVirtualMachine>>();

            var vm1 = vms.Define(SdkContext.RandomResourceName("vm", 15))
                .WithRegion(REGION)
                .WithExistingResourceGroup(groupName)
                .WithExistingPrimaryNetworkInterface(nic)
                .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer14_04_Lts)
                .WithRootUsername(userName)
                .WithRootPassword("Abcdef.123456")
                .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                .DefineNewExtension("packetCapture")
                    .WithPublisher("Microsoft.Azure.NetworkWatcher")
                    .WithType("NetworkWatcherAgentLinux")
                    .WithVersion("1.4")
                    .WithMinorVersionAutoUpgrade()
                    .Attach();

            String vmName = SdkContext.RandomResourceName("vm", 15);

            ICreatable<IVirtualMachine> vm2 = vms.Define(vmName)
                .WithRegion(REGION)
                .WithExistingResourceGroup(groupName)
                .WithExistingPrimaryNetwork(network)
                .WithSubnet(network.Subnets.Values.First().Name)
                .WithPrimaryPrivateIPAddressDynamic()
                .WithoutPrimaryPublicIPAddress()
                .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer14_04_Lts)
                .WithRootUsername(userName)
                .WithRootPassword("Abcdef.123456")
                .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"));

            vmDefinitions.Add(vm1);
            vmDefinitions.Add(vm2);
            vms.Create(vmDefinitions);
            var createdVMs2 = vms.Create(vmDefinitions);
            return createdVMs2;
        }

        // create a storage account
        IStorageAccount EnsureStorageAccount(String groupName)
        {
            return TestHelper.CreateStorageManager().StorageAccounts.Define(SdkContext.RandomResourceName("sa", 8))
                .WithRegion(REGION)
                .WithExistingResourceGroup(groupName)
                .Create();
        }

        void EnsureNetworkWatcherNotExists(INetworkWatchers networkWatchers)
        {
            var nwList = networkWatchers.List();
            foreach (INetworkWatcher nw in nwList)
            {
                if (REGION == nw.Region)
                {
                    networkWatchers.DeleteById(nw.Id);
                }
            }
        }
    }
}