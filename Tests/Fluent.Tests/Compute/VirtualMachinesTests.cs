// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Fluent.Tests.Compute.VirtualMachine
{
    public class VirtualMachine
    {
        private const string Location = "southcentralus";
        private const string VMName = "chashvm";

        [Fact]
        public void CanCreateWithNetworking()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var GroupName = TestUtilities.GenerateName("rgfluentchash-");
                var NsgName = TestUtilities.GenerateName("nsg");
                var NetworkName = TestUtilities.GenerateName("net");
                var VMName = TestUtilities.GenerateName("vm");
                var computeManager = TestHelper.CreateComputeManager();
                var resourceManager = TestHelper.CreateResourceManager();
                var networkManager = TestHelper.CreateNetworkManager();

                try
                {
                    var nsg = networkManager.NetworkSecurityGroups.Define(NsgName)
                         .WithRegion(Location)
                         .WithNewResourceGroup(GroupName)
                         .DefineRule("rule1")
                             .AllowInbound()
                             .FromAnyAddress()
                             .FromPort(80)
                             .ToAnyAddress()
                             .ToPort(80)
                             .WithProtocol(SecurityRuleProtocol.Tcp)
                             .Attach()
                         .Create();

                    ICreatable<INetwork> networkDefinition = networkManager.Networks.Define(NetworkName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(GroupName)
                        .WithAddressSpace("10.0.0.0/28")
                        .DefineSubnet("subnet1")
                            .WithAddressPrefix("10.0.0.0/29")
                            .WithExistingNetworkSecurityGroup(nsg)
                            .Attach();

                    // Create  
                    IVirtualMachine vm = computeManager.VirtualMachines.Define(VMName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(GroupName)
                        .WithNewPrimaryNetwork(networkDefinition)
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("Foo12")
                        .WithRootPassword("abc!@#F0orL")
                        .Create();

                    var primaryNic = vm.GetPrimaryNetworkInterface();
                    Assert.NotNull(primaryNic);
                    var primaryIpConfig = primaryNic.PrimaryIPConfiguration;
                    Assert.NotNull(primaryIpConfig);

                    // Fetch the NSG the way before v1.2  
                    Assert.NotNull(primaryIpConfig.NetworkId);
                    var network = primaryIpConfig.GetNetwork();
                    Assert.NotNull(primaryIpConfig.SubnetName);
                    ISubnet subnet = null;
                    network.Subnets.TryGetValue(primaryIpConfig.SubnetName, out subnet);
                    Assert.NotNull(subnet);
                    nsg = subnet.GetNetworkSecurityGroup();
                    Assert.NotNull(nsg);
                    Assert.Equal(NsgName, nsg.Name);
                    Assert.Equal(1, nsg.SecurityRules.Count);

                    // Fetch the NSG the v1.2 way  
                    nsg = primaryIpConfig.GetNetworkSecurityGroup();
                    Assert.Equal(NsgName, nsg.Name);

                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.BeginDeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var GroupName = TestUtilities.GenerateName("rgfluentchash-");
                var computeManager = TestHelper.CreateComputeManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    // Create
                    var vm = computeManager.VirtualMachines
                        .Define(VMName)
                        .WithRegion(Location)
                        .WithNewResourceGroup(GroupName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012Datacenter)
                        .WithAdminUsername("Foo12")
                        .WithAdminPassword("BaR@12!Foo")
                        .WithUnmanagedDisks()
                        .WithOSDiskCaching(CachingTypes.ReadWrite)
                        .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                        .WithOSDiskName("javatest")
                        .Create();

                    var foundedVM = computeManager.VirtualMachines.ListByResourceGroup(GroupName)
                        .FirstOrDefault(v => v.Name.Equals(VMName, StringComparison.OrdinalIgnoreCase));

                    Assert.NotNull(foundedVM);
                    Assert.Equal(Location, foundedVM.RegionName);
                    // Get
                    foundedVM = computeManager.VirtualMachines.GetByResourceGroup(GroupName, VMName);
                    Assert.NotNull(foundedVM);
                    Assert.Equal(Location, foundedVM.RegionName);

                    // Fetch instance view
                    PowerState powerState = foundedVM.PowerState;
                    Assert.True(powerState == PowerState.Running);
                    VirtualMachineInstanceView instanceView = foundedVM.InstanceView;
                    Assert.NotNull(instanceView);
                    Assert.NotEmpty(instanceView.Statuses);

                    // Capture the VM [Requires VM to be Poweroff and generalized]
                    foundedVM.PowerOff();
                    foundedVM.Generalize();
                    var jsonResult = foundedVM.Capture("captured-vhds", "cpt", true);
                    Assert.NotNull(jsonResult);

                    // Delete VM
                    computeManager.VirtualMachines.DeleteById(foundedVM.Id);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateUpdatePriorityAndPrice()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var GroupName = TestUtilities.GenerateName("rgfluentchash-");
                var computeManager = TestHelper.CreateComputeManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    // Create
                    var vm = computeManager.VirtualMachines
                        .Define(VMName)
                        .WithRegion(Location)
                        .WithNewResourceGroup(GroupName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012Datacenter)
                        .WithAdminUsername("Foo12")
                        .WithAdminPassword("BaR@12!Foo")
                        .WithUnmanagedDisks()
                        .WithOSDiskCaching(CachingTypes.ReadWrite)
                        .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                        .WithOSDiskName("javatest")
                        .WithLowPriority(VirtualMachineEvictionPolicyTypes.Deallocate)
                        .WithMaxPrice(1000.0)
                        .Create();

                    var foundedVM = computeManager.VirtualMachines.ListByResourceGroup(GroupName)
                        .FirstOrDefault(v => v.Name.Equals(VMName, StringComparison.OrdinalIgnoreCase));

                    Assert.NotNull(foundedVM);
                    Assert.Equal(Location, foundedVM.RegionName);
                    // Get
                    foundedVM = computeManager.VirtualMachines.GetByResourceGroup(GroupName, VMName);
                    Assert.NotNull(foundedVM);
                    Assert.Equal(Location, foundedVM.RegionName);
                    Assert.Equal(1000.0, foundedVM.BillingProfile.MaxPrice);
                    Assert.Equal(VirtualMachineEvictionPolicyTypes.Deallocate, foundedVM.EvictionPolicy);
                    Assert.Equal(VirtualMachinePriorityTypes.Low, foundedVM.Priority);

                    // change max price
                    try
                    {
                        foundedVM.Update()
                            .WithMaxPrice(1500.0)
                            .Apply();
                        // not run to assert
                        Assert.Equal(1500.0, foundedVM.BillingProfile.MaxPrice);
                        Assert.True(false);
                    }
                    catch (CloudException) { } // cannot change max price when vm in running

                    foundedVM.Deallocate();
                    foundedVM.Update()
                        .WithMaxPrice(2000.0)
                        .Apply();
                    foundedVM.Start();

                    foundedVM.Refresh();
                    Assert.Equal(2000.0, foundedVM.BillingProfile.MaxPrice);

                    // change priority
                    foundedVM = foundedVM.Update()
                        .WithPriority(VirtualMachinePriorityTypes.Spot)
                        .Apply();
                    Assert.Equal(VirtualMachinePriorityTypes.Spot, foundedVM.Priority);

                    foundedVM = foundedVM.Update()
                        .WithPriority(VirtualMachinePriorityTypes.Low)
                        .Apply();
                    Assert.Equal(VirtualMachinePriorityTypes.Low, foundedVM.Priority);

                    try
                    {
                        foundedVM.Update()
                            .WithPriority(VirtualMachinePriorityTypes.Regular)
                            .Apply();
                        // not run to assert
                        Assert.Equal(VirtualMachinePriorityTypes.Regular, foundedVM.Priority);
                        Assert.True(false);
                    }
                    catch (CloudException) { } // cannot change priority from low to regular

                    // Delete VM
                    computeManager.VirtualMachines.DeleteById(foundedVM.Id);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CannotUpdateProximityPlacementGroupForVirtualMachine()
        {

            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var GroupName1 = TestUtilities.GenerateName("rgfluentchash-");
                var GroupName2 = TestUtilities.GenerateName("rgfluentchash-");
                var AvailName1 = TestUtilities.GenerateName("availset1");
                var AvailName2 = TestUtilities.GenerateName("availset2");
                var ProxyGroupName1 = TestUtilities.GenerateName("testproxgroup1");
                var ProxyGroupName2 = TestUtilities.GenerateName("testproxgroup1");

                var ProxyGroupType = ProximityPlacementGroupType.Standard;
                var RegionPPG1 = Region.USWestCentral;
                var RegionPPG2 = Region.USSouthCentral;

                var computeManager = TestHelper.CreateComputeManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {

                    var setCreated1 = computeManager.AvailabilitySets
                    .Define(AvailName1)
                    .WithRegion(RegionPPG1)
                    .WithNewResourceGroup(GroupName1)
                    .WithNewProximityPlacementGroup(ProxyGroupName1, ProxyGroupType)
                    .Create();

                    Assert.Equal(AvailName1, setCreated1.Name);
                    Assert.NotNull(setCreated1.ProximityPlacementGroup);
                    Assert.Equal(ProxyGroupType, setCreated1.ProximityPlacementGroup.ProximityPlacementGroupType);
                    Assert.NotNull(setCreated1.ProximityPlacementGroup.AvailabilitySetIds);
                    Assert.False(setCreated1.ProximityPlacementGroup.AvailabilitySetIds.Count == 0);
                    Assert.Equal(setCreated1.Id, setCreated1.ProximityPlacementGroup.AvailabilitySetIds[0], true);
                    Assert.Equal(setCreated1.RegionName, setCreated1.ProximityPlacementGroup.Location);


                    var setCreated2 = computeManager.AvailabilitySets
                            .Define(AvailName2)
                            .WithRegion(RegionPPG2)
                            .WithNewResourceGroup(GroupName2)
                            .WithNewProximityPlacementGroup(ProxyGroupName2, ProxyGroupType)
                            .Create();

                    Assert.Equal(AvailName2, setCreated2.Name);
                    Assert.NotNull(setCreated2.ProximityPlacementGroup);
                    Assert.Equal(ProxyGroupType, setCreated2.ProximityPlacementGroup.ProximityPlacementGroupType);
                    Assert.Equal(ProxyGroupType, setCreated2.ProximityPlacementGroup.ProximityPlacementGroupType);
                    Assert.NotNull(setCreated2.ProximityPlacementGroup.AvailabilitySetIds);
                    Assert.False(setCreated2.ProximityPlacementGroup.AvailabilitySetIds.Count == 0);
                    Assert.Equal(setCreated2.Id, setCreated2.ProximityPlacementGroup.AvailabilitySetIds[0], true);
                    Assert.Equal(setCreated2.RegionName, setCreated2.ProximityPlacementGroup.Location);

                    // Create
                    computeManager.VirtualMachines
                            .Define(VMName)
                            .WithRegion(RegionPPG1)
                            .WithExistingResourceGroup(GroupName1)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithProximityPlacementGroup(setCreated1.ProximityPlacementGroup.Id)
                            .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012Datacenter)
                            .WithAdminUsername("Foo12")
                            .WithAdminPassword("abc!@#F0orL")
                            .WithUnmanagedDisks()
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .WithOSDiskName("javatest")
                            .WithLicenseType("Windows_Server")
                            .Create();

                    IVirtualMachine foundVM = null;
                    var vms = computeManager.VirtualMachines.ListByResourceGroup(GroupName1);
                    foreach (IVirtualMachine vm1 in vms)
                    {
                        if (vm1.Name.Equals(VMName))
                        {
                            foundVM = vm1;
                            break;
                        }
                    }
                    Assert.NotNull(foundVM);
                    Assert.Equal(RegionPPG1, foundVM.Region);
                    // Get
                    foundVM = computeManager.VirtualMachines.GetByResourceGroup(GroupName1, VMName);
                    Assert.NotNull(foundVM);
                    Assert.Equal(RegionPPG1, foundVM.Region);
                    Assert.Equal("Windows_Server", foundVM.LicenseType);

                    // Fetch instance view
                    PowerState powerState = foundVM.PowerState;
                    Assert.Equal(powerState, PowerState.Running);
                    VirtualMachineInstanceView instanceView = foundVM.InstanceView;
                    Assert.NotNull(instanceView);
                    Assert.True(instanceView.Statuses.Count > 0);

                    Assert.NotNull(foundVM.ProximityPlacementGroup);
                    Assert.Equal(ProxyGroupType, foundVM.ProximityPlacementGroup.ProximityPlacementGroupType);
                    Assert.NotNull(foundVM.ProximityPlacementGroup.AvailabilitySetIds);
                    Assert.True(foundVM.ProximityPlacementGroup.AvailabilitySetIds.Count > 0);
                    Assert.Equal(setCreated1.Id, foundVM.ProximityPlacementGroup.AvailabilitySetIds[0], true);
                    Assert.NotNull(foundVM.ProximityPlacementGroup.VirtualMachineIds);
                    Assert.True(foundVM.ProximityPlacementGroup.VirtualMachineIds.Count > 0);
                    Assert.Equal(foundVM.Id, setCreated1.ProximityPlacementGroup.VirtualMachineIds[0], true);

                    try
                    {
                        //Update Vm to remove it from proximity placement group
                        IVirtualMachine updatedVm = foundVM.Update()
                                .WithProximityPlacementGroup(setCreated2.ProximityPlacementGroup.Id)
                                .Apply();
                    }
                    catch (Microsoft.Rest.Azure.CloudException clEx)
                    {
                        Assert.Equal("Updating proximity placement group of VM chashvm is not allowed while the VM is running. Please stop/deallocate the VM and retry the operation.", clEx.Message, true);
                    }

                    // Delete resources
                    computeManager.VirtualMachines.DeleteById(foundVM.Id);
                    computeManager.AvailabilitySets.DeleteById(setCreated1.Id);
                    computeManager.AvailabilitySets.DeleteById(setCreated2.Id);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(GroupName1);
                        resourceManager.ResourceGroups.DeleteByName(GroupName2);
                    }
                    catch { }
                }
            }
        }


        [Fact]
        public void CanCreateVirtualMachinesAndAvailabilitySetInSameProximityPlacementGroup()
        {

            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var RGName = TestUtilities.GenerateName("rgfluentchash-");
                var AvailName = TestUtilities.GenerateName("availset1");
                var ProxyGroupName = TestUtilities.GenerateName("testproxgroup1");
                var ProxyGroupType = ProximityPlacementGroupType.Standard;
                var RegionPPG = Region.USWestCentral;

                var computeManager = TestHelper.CreateComputeManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {

                    var setCreated = computeManager.AvailabilitySets
                        .Define(AvailName)
                        .WithRegion(RegionPPG)
                        .WithNewResourceGroup(RGName)
                        .WithNewProximityPlacementGroup(ProxyGroupName, ProxyGroupType)
                        .Create();

                    Assert.Equal(AvailName, setCreated.Name);
                    Assert.NotNull(setCreated.ProximityPlacementGroup);
                    Assert.Equal(ProxyGroupType, setCreated.ProximityPlacementGroup.ProximityPlacementGroupType);
                    Assert.NotNull(setCreated.ProximityPlacementGroup.AvailabilitySetIds);
                    Assert.True(setCreated.ProximityPlacementGroup.AvailabilitySetIds.Count > 0);
                    Assert.Equal(setCreated.Id, setCreated.ProximityPlacementGroup.AvailabilitySetIds[0], true);
                    Assert.Equal(setCreated.RegionName, setCreated.ProximityPlacementGroup.Location);

                    // Create
                    computeManager.VirtualMachines
                            .Define(VMName)
                            .WithRegion(RegionPPG)
                            .WithExistingResourceGroup(RGName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithProximityPlacementGroup(setCreated.ProximityPlacementGroup.Id)
                            .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012Datacenter)
                            .WithAdminUsername("Foo12")
                            .WithAdminPassword("abc!@#F0orL")
                            .WithUnmanagedDisks()
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .WithOSDiskName("javatest")
                            .WithLicenseType("Windows_Server")
                            .Create();

                    IVirtualMachine foundVM = null;
                    var vms = computeManager.VirtualMachines.ListByResourceGroup(RGName);
                    foreach (IVirtualMachine vm1 in vms)
                    {
                        if (vm1.Name.Equals(VMName))
                        {
                            foundVM = vm1;
                            break;
                        }
                    }
                    Assert.NotNull(foundVM);
                    Assert.Equal(RegionPPG, foundVM.Region);
                    // Get
                    foundVM = computeManager.VirtualMachines.GetByResourceGroup(RGName, VMName);
                    Assert.NotNull(foundVM);
                    Assert.Equal(RegionPPG, foundVM.Region);
                    Assert.Equal("Windows_Server", foundVM.LicenseType);

                    // Fetch instance view
                    PowerState powerState = foundVM.PowerState;
                    Assert.Equal(powerState, PowerState.Running);
                    VirtualMachineInstanceView instanceView = foundVM.InstanceView;
                    Assert.NotNull(instanceView);
                    Assert.True(instanceView.Statuses.Count > 0);

                    Assert.NotNull(foundVM.ProximityPlacementGroup);
                    Assert.Equal(ProxyGroupType, foundVM.ProximityPlacementGroup.ProximityPlacementGroupType);
                    Assert.NotNull(foundVM.ProximityPlacementGroup.AvailabilitySetIds);
                    Assert.True(foundVM.ProximityPlacementGroup.AvailabilitySetIds.Count > 0);
                    Assert.Equal(setCreated.Id, foundVM.ProximityPlacementGroup.AvailabilitySetIds[0], true);
                    Assert.NotNull(foundVM.ProximityPlacementGroup.VirtualMachineIds);
                    Assert.True(foundVM.ProximityPlacementGroup.VirtualMachineIds.Count > 0);
                    Assert.Equal(foundVM.Id, setCreated.ProximityPlacementGroup.VirtualMachineIds[0], true);

                    //Update Vm to remove it from proximity placement group
                    IVirtualMachine updatedVm = foundVM.Update()
                            .WithoutProximityPlacementGroup()
                            .Apply();

                    Assert.NotNull(updatedVm.ProximityPlacementGroup);
                    Assert.Equal(ProxyGroupType, updatedVm.ProximityPlacementGroup.ProximityPlacementGroupType);
                    Assert.NotNull(updatedVm.ProximityPlacementGroup.AvailabilitySetIds);
                    Assert.True(updatedVm.ProximityPlacementGroup.AvailabilitySetIds.Count > 0);
                    Assert.Equal(setCreated.Id, updatedVm.ProximityPlacementGroup.AvailabilitySetIds[0], true);

                    //TODO: this does not work... can not remove cvm from the placement group
                    //Assert.assertNull(foundVM.proximityPlacementGroup().virtualMachineIds());

                    // Delete VM
                    computeManager.VirtualMachines.DeleteById(foundVM.Id);
                    computeManager.AvailabilitySets.DeleteById(setCreated.Id);

                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(RGName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateWithRelatedResourcesInParallel()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var resourceGroupName = TestUtilities.GenerateName("rgvmtest-");
                var vmNamePrefix = "vmz";
                var publicIPNamePrefix = TestUtilities.GenerateName("pip-");
                var networkNamePrefix = TestUtilities.GenerateName("vnet-");

                var region = Region.USEast;
                int count = 5;

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var resourceGroupCreatable = azure.ResourceGroups
                    .Define(resourceGroupName)
                    .WithRegion(region);

                    var storageAccountCreatable = azure.StorageAccounts
                        .Define(TestUtilities.GenerateName("stg"))
                        .WithRegion(region)
                        .WithNewResourceGroup(resourceGroupCreatable);

                    var networkCreatableKeys = new List<string>();
                    var publicIPCreatableKeys = new List<string>();
                    var virtualMachineCreatables = new List<ICreatable<IVirtualMachine>>();
                    for (int i = 0; i < count; i++)
                    {
                        var networkCreatable = azure.Networks
                                .Define($"{networkNamePrefix}-{i}")
                                .WithRegion(region)
                                .WithNewResourceGroup(resourceGroupCreatable)
                                .WithAddressSpace("10.0.0.0/28");
                        networkCreatableKeys.Add(networkCreatable.Key);

                        var publicIPAddressCreatable = azure.PublicIPAddresses
                                .Define($"{publicIPNamePrefix}-{i}")
                                .WithRegion(region)
                                .WithNewResourceGroup(resourceGroupCreatable);
                        publicIPCreatableKeys.Add(publicIPAddressCreatable.Key);

                        var virtualMachineCreatable = azure.VirtualMachines
                                .Define($"{vmNamePrefix}-{i}")
                                .WithRegion(region)
                                .WithNewResourceGroup(resourceGroupCreatable)
                                .WithNewPrimaryNetwork(networkCreatable)
                                .WithPrimaryPrivateIPAddressDynamic()
                                .WithNewPrimaryPublicIPAddress(publicIPAddressCreatable)
                                .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                                .WithRootUsername("tirekicker")
                                .WithRootPassword("BaR@12!#")
                                .WithUnmanagedDisks()
                                .WithNewStorageAccount(storageAccountCreatable);
                        virtualMachineCreatables.Add(virtualMachineCreatable);
                    }

                    var createdVirtualMachines = azure.VirtualMachines.Create(virtualMachineCreatables.ToArray());
                    Assert.True(createdVirtualMachines.Count() == count);

                    HashSet<string> virtualMachineNames = new HashSet<string>();
                    for (int i = 0; i < count; i++)
                    {
                        virtualMachineNames.Add($"{vmNamePrefix}-{i}");
                    }

                    foreach (var virtualMachine in createdVirtualMachines)
                    {
                        Assert.Contains(virtualMachine.Name, virtualMachineNames);
                        Assert.NotNull(virtualMachine.Id);
                    }

                    var networkNames = new HashSet<string>();
                    for (int i = 0; i < count; i++)
                    {
                        networkNames.Add($"{networkNamePrefix}-{i}");
                    }

                    foreach (var networkCreatableKey in networkCreatableKeys)
                    {
                        var createdNetwork = (INetwork)createdVirtualMachines.CreatedRelatedResource(networkCreatableKey);
                        Assert.NotNull(createdNetwork);
                        Assert.Contains(createdNetwork.Name, networkNames);
                    }

                    HashSet<string> publicIPAddressNames = new HashSet<string>();
                    for (int i = 0; i < count; i++)
                    {
                        publicIPAddressNames.Add($"{publicIPNamePrefix}-{i}");
                    }

                    foreach (string publicIPCreatableKey in publicIPCreatableKeys)
                    {
                        var createdPublicIPAddress = (IPublicIPAddress)createdVirtualMachines.CreatedRelatedResource(publicIPCreatableKey);
                        Assert.NotNull(createdPublicIPAddress);
                        Assert.Contains(createdPublicIPAddress.Name, publicIPAddressNames);
                    }
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(resourceGroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateWithCustomData()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmName = TestUtilities.GenerateName("vm");
                var username = "testuser";
                var password = TestUtilities.GenerateName("Pa5$");
                var publicIPDnsLabel = TestUtilities.GenerateName("abc");
                var region = Region.USEast;
                var cloudInitEncodedString = Convert.ToBase64String(Encoding.ASCII.GetBytes("#cloud-config\r\npackages:\r\n - pwgen"));

                var azure = TestHelper.CreateRollupClient();
                string rgName = null;

                try
                {
                    var publicIPAddress = azure.PublicIPAddresses.Define(publicIPDnsLabel)
                        .WithRegion(region)
                        .WithNewResourceGroup()
                        .WithLeafDomainLabel(publicIPDnsLabel)
                        .Create();

                    rgName = publicIPAddress.ResourceGroupName;

                    var virtualMachine = azure.VirtualMachines.Define(vmName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(publicIPAddress.ResourceGroupName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithExistingPrimaryPublicIPAddress(publicIPAddress)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(username)
                        .WithRootPassword(password)
                        .WithUnmanagedDisks()
                        .WithCustomData(cloudInitEncodedString)
                        .Create();

                    publicIPAddress.Refresh();
                    Assert.True(publicIPAddress.HasAssignedNetworkInterface);
                    Assert.NotNull(publicIPAddress.Fqdn);

                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        var commandOutput = TestHelper.TrySsh(publicIPAddress.Fqdn, 22, username, password, "pwgen;");

                        Assert.DoesNotContain("the program 'pwgen' is currently not installed", commandOutput.ToLowerInvariant());
                    }
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanSShConnectToVirtualMachine()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rg");
                var vmName = TestUtilities.GenerateName("vm");
                var username = "testuser";
                var password = TestUtilities.GenerateName("Pa5$");
                var publicIPDnsLabel = TestUtilities.GenerateName("abc");
                var region = Region.USEast;

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var virtualMachine = azure.VirtualMachines.Define(vmName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(publicIPDnsLabel)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(username)
                        .WithRootPassword(password)
                        .WithUnmanagedDisks()
                        .Create();

                    var publicIPAddress = virtualMachine.GetPrimaryPublicIPAddress();
                    Assert.NotNull(publicIPAddress.Fqdn);

                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        TestHelper.TrySsh(publicIPAddress.Fqdn, 22, username, password, "pwgen;");
                    }
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanCreateWithExistingNetworkAndNewPIP()
        {
            // Test for https://github.com/Azure/azure-sdk-for-net/issues/3359
            //
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rg");
                var vnetName = TestUtilities.GenerateName("vnet");
                var vmName = TestUtilities.GenerateName("vm");
                var pipName = TestUtilities.GenerateName("pip");
                var username = "testuser";
                var password = TestUtilities.GenerateName("Pa5$");
                var publicIPDnsLabel = TestUtilities.GenerateName("abc");
                var region = Region.USEast;

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var network = azure.Networks.Define(vnetName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithAddressSpace("10.0.0.0/28")
                        .Create();

                    var subnet = network.Subnets.Values.FirstOrDefault();
                    Assert.NotNull(subnet);

                    var pipCreatable = azure.PublicIPAddresses.Define(pipName)
                                .WithRegion(region)
                                .WithExistingResourceGroup(rgName)
                                .WithDynamicIP()
                                .WithLeafDomainLabel(publicIPDnsLabel);

                    var virtualMachine = azure.VirtualMachines.Define(vmName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet(subnet.Name)
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(pipCreatable)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(username)
                        .WithRootPassword(password)
                        .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                        .Create();

                    var publicIPAddress = virtualMachine.GetPrimaryPublicIPAddress();
                    Assert.NotNull(publicIPAddress.Fqdn);
                    var nic = virtualMachine.GetPrimaryNetworkInterface();
                    Assert.NotNull(nic);
                    Assert.NotNull(nic.PrimaryIPConfiguration.NetworkId);
                    Assert.Equal(nic.PrimaryIPConfiguration.NetworkId, network.Id);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanSetStorageAccountForUnmanagedDisk()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var groupName = TestUtilities.GenerateName("rgfluentchash-");
                var storageName = TestUtilities.GenerateName("stg");
                var computeManager = TestHelper.CreateComputeManager();
                var resourceManager = TestHelper.CreateResourceManager();
                var storageManager = TestHelper.CreateStorageManager();

                try
                {
                    // Create a premium storage account for virtual machine data disk
                    //
                    var storageAccount = storageManager.StorageAccounts.Define(storageName)
                            .WithRegion(Location)
                            .WithNewResourceGroup(groupName)
                            .WithSku(StorageAccountSkuType.Premium_LRS)
                            .Create();

                    // Creates a virtual machine with an unmanaged data disk that gets stored in the above
                    // premium storage account
                    //
                    var virtualMachine = computeManager.VirtualMachines
                            .Define(VMName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(groupName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("Foo12")
                            .WithRootPassword("abc!@#F0orL")
                            .WithUnmanagedDisks()
                            .DefineUnmanagedDataDisk("disk1")
                                .WithNewVhd(100)
                                .WithLun(2)
                                .StoreAt(storageAccount.Name, "diskvhds", "datadisk1vhd.vhd")
                                .Attach()
                            .DefineUnmanagedDataDisk("disk2")
                                .WithNewVhd(100)
                                .WithLun(3)
                                .StoreAt(storageAccount.Name, "diskvhds", "datadisk2vhd.vhd")
                                .Attach()
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();

                    // Validate the unmanaged data disks
                    //
                    var unmanagedDataDisks = virtualMachine.UnmanagedDataDisks;
                    Assert.NotNull(unmanagedDataDisks);
                    Assert.Equal(2, unmanagedDataDisks.Count);
                    var firstUnmanagedDataDisk = unmanagedDataDisks[2];
                    Assert.NotNull(firstUnmanagedDataDisk);
                    var secondUnmanagedDataDisk = unmanagedDataDisks[3];
                    Assert.NotNull(secondUnmanagedDataDisk);
                    var createdVhdUri1 = firstUnmanagedDataDisk.VhdUri;
                    var createdVhdUri2 = secondUnmanagedDataDisk.VhdUri;
                    Assert.NotNull(createdVhdUri1);
                    Assert.NotNull(createdVhdUri2);

                    computeManager.VirtualMachines.DeleteById(virtualMachine.Id);
                    // Creates another virtual machine by attaching existing unmanaged data disk detached from the
                    // above virtual machine.
                    //
                    virtualMachine = computeManager.VirtualMachines
                            .Define(VMName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(groupName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("Foo12")
                            .WithRootPassword("abc!@#F0orL")
                            .WithUnmanagedDisks()
                            .WithExistingUnmanagedDataDisk(storageAccount.Name, "diskvhds", "datadisk1vhd.vhd")
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                            .Create();
                    // Gets the vm
                    //
                    virtualMachine = computeManager.VirtualMachines.GetById(virtualMachine.Id);
                    // Validate the unmanaged data disks
                    //
                    unmanagedDataDisks = virtualMachine.UnmanagedDataDisks;
                    Assert.NotNull(unmanagedDataDisks);
                    Assert.Equal(1, unmanagedDataDisks.Count);
                    firstUnmanagedDataDisk = unmanagedDataDisks.First().Value;
                    Assert.NotNull(firstUnmanagedDataDisk.VhdUri);
                    Assert.Equal(firstUnmanagedDataDisk.VhdUri, createdVhdUri1, ignoreCase: true);
                    // Update the VM by attaching another existing data disk
                    //
                    virtualMachine.Update()
                            .WithExistingUnmanagedDataDisk(storageAccount.Name, "diskvhds", "datadisk2vhd.vhd")
                            .Apply();
                    // Gets the vm
                    //
                    virtualMachine = computeManager.VirtualMachines.GetById(virtualMachine.Id);
                    // Validate the unmanaged data disks
                    //
                    unmanagedDataDisks = virtualMachine.UnmanagedDataDisks;
                    Assert.NotNull(unmanagedDataDisks);
                    Assert.Equal(2, unmanagedDataDisks.Count);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(groupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanRunScriptOnVM()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rg");
                var vnetName = TestUtilities.GenerateName("vnet");
                var vmName = TestUtilities.GenerateName("vm");
                var pipName = TestUtilities.GenerateName("pip");
                var publicIPDnsLabel = TestUtilities.GenerateName("abc");
                var region = Region.USEast;

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    // Create
                    var virtualMachine = azure.VirtualMachines.Define(vmName)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("firstuser")
                            .WithRootPassword("afh123RVS!")
                            .Create();

                    var installGit = new List<string>();
                    installGit.Add("sudo apt-get update");
                    installGit.Add("sudo apt-get install -y git");

                    var runResult = virtualMachine.RunShellScript(installGit, new List<RunCommandInputParameter>());
                    Assert.NotNull(runResult);
                    Assert.NotNull(runResult.Value);
                    Assert.True(runResult.Value.Count > 0);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanEncrypt()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rg");
                var vmName = TestUtilities.GenerateName("vm");
                var pipName = TestUtilities.GenerateName("pip");
                var vaultName = TestUtilities.GenerateName("vlt");
                var keyName = TestUtilities.GenerateName("key");
                var region = Region.USEast;
                var azure = TestHelper.CreateRollupClient();

                try
                {
                    azure.ResourceGroups.Define(rgName).WithRegion(region).Create();
                    var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                    // windows
                    var vault = azure.Vaults.Define(vaultName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .DefineAccessPolicy()
                            .ForServicePrincipal(credentials.ClientId)
                            .AllowCertificateAllPermissions()
                            .AllowKeyAllPermissions()
                            .AllowSecretAllPermissions()
                            .Attach()
                        .WithDiskEncryptionEnabled()
                        .Create();

                    var vm = azure.VirtualMachines.Define(vmName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/24")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(pipName)
                        .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2008R2_SP1)
                        .WithAdminUsername("Foo12")
                        .WithAdminPassword("abc!@#F0orL")
                        .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                        .Create();

                    vm.DiskEncryption.Enable(vault.Id);

                    Assert.Equal(EncryptionStatus.Encrypted, vm.DiskEncryption.GetMonitor().OSDiskStatus);

                    vm.DiskEncryption.Disable(DiskVolumeType.All);

                    Assert.Equal(EncryptionStatus.NotEncrypted, vm.DiskEncryption.GetMonitor().OSDiskStatus);

                    //linux                
                    vmName = TestUtilities.GenerateName("vm");
                    pipName = TestUtilities.GenerateName("pip");

                    vm = azure.VirtualMachines.Define(vmName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/24")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(pipName)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("Foo12")
                        .WithRootPassword("abc!@#F0orL")
                        .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                        .Create();

                    vm.DiskEncryption.Enable(vault.Id);

                    Assert.NotEqual(EncryptionStatus.NotEncrypted, vm.DiskEncryption.GetMonitor().OSDiskStatus);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch
                    { }
                }
            }
        }
    }
}