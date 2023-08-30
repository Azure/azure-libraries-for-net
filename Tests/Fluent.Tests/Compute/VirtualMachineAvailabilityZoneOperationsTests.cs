// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Fluent.Tests.Compute.VirtuaMachine
{
    public class AvailabilityZones
    {
        [Fact]
        public void CanCreateZonedVMWithImplicitZonedRelatedResources()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("rgzoned");
                string proxyGroupName = TestUtilities.GenerateName("plg1Test");
                try
                {
                    var region = Region.USEast2;
                    string vmName = "javavm";
                    string pipDnsLabel = TestUtilities.GenerateName("pip");

                    var azure = TestHelper.CreateRollupClient();
                    var virtualMachine = azure.VirtualMachines
                        .Define(vmName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(pipDnsLabel)
                        .WithNewProximityPlacementGroup(proxyGroupName, ProximityPlacementGroupType.Standard)
                        .WithPopularLinuxImage(Microsoft.Azure.Management.Compute.Fluent.KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("Foo12")
                        .WithRootPassword("abc!@#F0orL")
                        // Optionals
                        .WithAvailabilityZone(AvailabilityZoneId.Zone_1)
                        .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                        .WithOSDiskCaching(CachingTypes.ReadWrite)
                        // Create VM
                        .Create();

                    // Check the zone assigned to the virual machine
                    Assert.NotNull(virtualMachine.AvailabilityZones);
                    Assert.False(virtualMachine.AvailabilityZones.Count == 0);
                    Assert.True(virtualMachine.AvailabilityZones.Contains(AvailabilityZoneId.Zone_1));

                    //Check the proximity placement group information
                    Assert.NotNull(virtualMachine.ProximityPlacementGroup);
                    Assert.Equal(ProximityPlacementGroupType.Standard, virtualMachine.ProximityPlacementGroup.ProximityPlacementGroupType);
                    Assert.NotNull(virtualMachine.ProximityPlacementGroup.VirtualMachineIds);
                    Assert.Equal(virtualMachine.Id, virtualMachine.ProximityPlacementGroup.VirtualMachineIds[0], true);

                    // Check the zone assigned to the implcitly created publicip addres
                    // Impliclity created public ip with BASIC sku
                    IPublicIPAddress publicIPAddress = virtualMachine.GetPrimaryPublicIPAddress();
                    Assert.NotNull(publicIPAddress.AvailabilityZones);
                    Assert.False(publicIPAddress.AvailabilityZones.Count == 0);
                    Assert.True(publicIPAddress.AvailabilityZones.Contains(AvailabilityZoneId.Zone_1));
                    // Check the zone assigned to the implictly created managed os disk
                    //
                    var osDiskId = virtualMachine.OSDiskId;
                    Assert.NotNull(osDiskId);
                    Assert.NotEmpty(osDiskId);
                    var osDisk = azure.Disks.GetById(osDiskId);
                    Assert.NotNull(osDisk);
                    // Check the zone assigned to the implicilty created managed OS disk
                    //
                    Assert.NotNull(osDisk.AvailabilityZones);
                    Assert.False(osDisk.AvailabilityZones.Count == 0);
                    Assert.True(osDisk.AvailabilityZones.Contains(AvailabilityZoneId.Zone_1));
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateZonedVMWithExplicitZoneForRelatedResources()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("rgzoned");
                try
                {
                    var region = Region.USEast2;
                    string vmName = "javavm";
                    string pipDnsLabel = TestUtilities.GenerateName("pip");

                    var azure = TestHelper.CreateRollupClient();
                    // Create zoned public IP for the virtual machine
                    //
                    IPublicIPAddress publicIPAddress = azure.PublicIPAddresses
                            .Define(pipDnsLabel)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgName)
                            .WithStaticIP()
                            // Optionals
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_1)  // since the SKU is BASIC and VM is zoned, PIP must be zoned
                            .WithSku(PublicIPSkuType.Basic)                   // Basic sku is never zone resilient, so if you want it zoned, specify explicitly as above.
                                                                              // Create PIP
                            .Create();

                    // Create a zoned data disk for the virtual machine
                    //
                    var diskName = TestUtilities.GenerateName("dsk");
                    var dataDisk = azure.Disks
                            .Define(diskName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(rgName)
                            .WithData()
                            .WithSizeInGB(100)
                            // Optionals
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_1)
                            // Create Disk
                            .Create();

                    // Create a zoned virtual machine
                    //
                    var virtualMachine = azure.VirtualMachines
                            .Define(vmName)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithExistingPrimaryPublicIPAddress(publicIPAddress)
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("Foo12")
                            .WithRootPassword("abc!@#F0orL")
                            // Optionals
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_1)
                            .WithExistingDataDisk(dataDisk)
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                            // Create VM
                            .Create();

                    // Checks the zone assigned to the virtual machine
                    //
                    Assert.NotNull(virtualMachine.AvailabilityZones);
                    Assert.False(virtualMachine.AvailabilityZones.Count == 0);
                    Assert.True(virtualMachine.AvailabilityZones.Contains(AvailabilityZoneId.Zone_1));
                    // Checks the zone assigned to the explicitly created public IP address.
                    //
                    publicIPAddress = virtualMachine.GetPrimaryPublicIPAddress();
                    Assert.NotNull(publicIPAddress.Sku);
                    Assert.True(publicIPAddress.Sku.Equals(PublicIPSkuType.Basic));
                    Assert.NotNull(publicIPAddress.AvailabilityZones);
                    Assert.False(publicIPAddress.AvailabilityZones.Count == 0);
                    Assert.True(publicIPAddress.AvailabilityZones.Contains(AvailabilityZoneId.Zone_1));
                    // Check the zone assigned to the explicitly created data disk
                    //
                    var dataDisks = virtualMachine.DataDisks;
                    Assert.NotNull(dataDisks);
                    Assert.True(dataDisks.IsAny());
                    var dataDisk1 = dataDisks.Values.First();
                    Assert.NotNull(dataDisk1.Id);
                    dataDisk = azure.Disks.GetById(dataDisk1.Id);
                    Assert.NotNull(dataDisk);
                    Assert.NotNull(dataDisk.AvailabilityZones);
                    Assert.False(dataDisk.AvailabilityZones.Count == 0);
                    Assert.True(dataDisk.AvailabilityZones.Contains(AvailabilityZoneId.Zone_1));
                    // Checks the zone assigned to the implicitly created managed OS disk.
                    //
                    String osDiskId = virtualMachine.OSDiskId;    // Only VM based on managed disk can have zone assigned
                    Assert.NotNull(osDiskId);
                    Assert.NotEmpty(osDiskId);
                    var osDisk = azure.Disks.GetById(osDiskId);
                    Assert.NotNull(osDisk);
                    // Checks the zone assigned to the implicitly created managed OS disk.
                    //
                    Assert.NotNull(osDisk.AvailabilityZones);
                    Assert.False(osDisk.AvailabilityZones.Count == 0);
                    Assert.True(osDisk.AvailabilityZones.Contains(AvailabilityZoneId.Zone_1));
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateZonedVMWithZoneResilientPublicIP()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("rgzoned");
                try
                {
                    var region = Region.USEast2;
                    string vmName = "javavm";
                    string pipDnsLabel = TestUtilities.GenerateName("pip");

                    var azure = TestHelper.CreateRollupClient();
                    IPublicIPAddress publicIPAddress = azure.PublicIPAddresses
                        .Define(pipDnsLabel)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithStaticIP()
                        // Optionals
                        .WithSku(PublicIPSkuType.Standard)  // No zone selected, STANDARD SKU is zone resilient [zone resilient: resources deployed in all zones by the service and it will be served by all AZs all the time]
                                                            // Create PIP
                        .Create();
                    // Create a zoned virtual machine
                    //
                    var virtualMachine = azure.VirtualMachines
                            .Define(vmName)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithExistingPrimaryPublicIPAddress(publicIPAddress)
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("Foo12")
                            .WithRootPassword("abc!@#F0orL")
                            // Optionals
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_1)
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                            // Create VM
                            .Create();
                    // Checks the zone assigned to the virtual machine
                    //
                    Assert.NotNull(virtualMachine.AvailabilityZones);
                    Assert.False(virtualMachine.AvailabilityZones.Count == 0);
                    Assert.True(virtualMachine.AvailabilityZones.Contains(AvailabilityZoneId.Zone_1));
                    // Check the zone resilient PIP
                    //
                    publicIPAddress = virtualMachine.GetPrimaryPublicIPAddress();
                    Assert.NotNull(publicIPAddress.Sku);
                    Assert.True(publicIPAddress.Sku.Equals(PublicIPSkuType.Standard));
                    Assert.NotNull(publicIPAddress.AvailabilityZones);  // Though zone-resilient, this property won't be populated by the service.
                    Assert.True(publicIPAddress.AvailabilityZones.Count == 0);
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact(Skip = "Cannot be run because of NRP bug.")]
        // This test put multiple non-zonal (regional) & non-availability set virtual machine's NIC into backend pool of a zone-redundant load balancer.
        // There is a bug in the service, where such an attempt will fail with error
        // "error": {
        //    "code": "NetworkInterfaceAndLoadBalancerAreInDifferentAvailabilitySets",
        //    "message": "Network interface /subscriptions/<sub-id>/resourceGroups/<rg-name>/providers/Microsoft.Network/networkInterfaces/<nic-name> uses load balancer /subscriptions/<sub-id>/resourceGroups/<rg-name>/providers/Microsoft.Compute/virtualMachines/<vm-name>).",
        //    "details": []
        // }
        // Enable this test once it is fixed. 
        //
        public void CanCreateRegionalNonAvailSetVMsAndAssociateThemWithSingleBackendPoolOfZoneResilientLB()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("rgzoned");
                try
                {
                    var region = Region.USEast2;
                    string networkName = TestUtilities.GenerateName("net");

                    var azure = TestHelper.CreateRollupClient();
                    var network = azure.Networks.Define(networkName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnet1", "10.0.0.0/29")
                        .WithSubnet("subnet2", "10.0.0.8/29")
                        .Create();

                    string pipDnsLabel = TestUtilities.GenerateName("pip");

                    var subnets = network.Subnets.Values.GetEnumerator();
                    // Define first regional virtual machine
                    //
                    subnets.MoveNext();
                    var creatableVM1 = azure.VirtualMachines
                            .Define(TestUtilities.GenerateName("vm1"))
                            .WithRegion(region)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetwork(network)
                            .WithSubnet(subnets.Current.Name)      // Put VM in first subnet
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("Foo12")
                            .WithRootPassword("abc!@#F0orL")
                            // Optionals
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"));

                    subnets.MoveNext();
                    var creatableVM2 = azure.VirtualMachines
                            .Define(TestUtilities.GenerateName("vm2"))
                            .WithRegion(region)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetwork(network)
                            .WithSubnet(subnets.Current.Name)      // Put VM in second subnet
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("Foo12")
                            .WithRootPassword("abc!@#F0orL")
                            // Optionals
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"));

                    ICreatedResources<IVirtualMachine> createdVMs = azure.VirtualMachines.Create(creatableVM1, creatableVM2);

                    var itr = createdVMs.GetEnumerator();
                    itr.MoveNext();
                    IVirtualMachine firstVirtualMachine = itr.Current;
                    itr.MoveNext();
                    IVirtualMachine secondVirtualMachine = itr.Current;

                    var publicIPAddress = azure.PublicIPAddresses
                        .Define(pipDnsLabel)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithStaticIP()
                        // Optionals
                        .WithSku(PublicIPSkuType.Standard)  //  STANDARD LB requires STANDARD PIP
                                                            // Create PIP
                        .Create();

                    // Creates a Internet-Facing LoadBalancer with one front-end IP configuration and
                    // two backend pool associated with this IP Config
                    //
                    var lbName = TestUtilities.GenerateName("lb");
                    ILoadBalancer lb = azure.LoadBalancers
                            .Define(lbName)
                                .WithRegion(region)
                                .WithExistingResourceGroup(rgName)
                                .DefineLoadBalancingRule("rule-1")
                                    .WithProtocol(TransportProtocol.Tcp)
                                    .FromFrontend("front-end-1")
                                    .FromFrontendPort(80)
                                    .ToExistingVirtualMachines(firstVirtualMachine, secondVirtualMachine)
                                    .WithProbe("tcpProbe-1")
                                    .Attach()
                                .DefinePublicFrontend("front-end-1") // Define the frontend IP configuration used by the LB rule
                                    .WithExistingPublicIPAddress(publicIPAddress)
                                    .Attach()
                                .DefineTcpProbe("tcpProbe-1") // Define the Probe used by the LB rule
                                    .WithPort(25)
                                    .WithIntervalInSeconds(15)
                                    .WithNumberOfProbes(5)
                                    .Attach()
                                .WithSku(LoadBalancerSkuType.Standard)  // "zone-resilient LB" which don't have the constraint that all VMs needs to be in the same availability set
                                .Create();

                    // Zone resilient LB does not care VMs are zoned or regional, in the above cases VMs are regional.
                    //
                    // rx.Completable.merge(firstVirtualMachine.startAsync(), secondVirtualMachine.startAsync()).await();

                    // Verify frontends
                    Assert.Equal(1, lb.Frontends.Count);
                    Assert.Equal(1, lb.PublicFrontends.Count);
                    Assert.Equal(0, lb.PrivateFrontends.Count);
                    ILoadBalancerFrontend frontend = lb.Frontends.Values.First();
                    Assert.True(frontend.IsPublic);
                    ILoadBalancerPublicFrontend publicFrontend = (ILoadBalancerPublicFrontend)frontend;
                    Assert.Equal(publicIPAddress.Id, publicFrontend.PublicIPAddressId, ignoreCase: true);

                    // Verify backends
                    Assert.Equal(1, lb.Backends.Count);

                    // Verify probes
                    Assert.Equal(1, lb.TcpProbes.Count);
                    Assert.True(lb.TcpProbes.ContainsKey("tcpProbe-1"));

                    // Verify rules
                    Assert.Equal(1, lb.LoadBalancingRules.Count);
                    Assert.True(lb.LoadBalancingRules.ContainsKey("rule-1"));
                    ILoadBalancingRule rule = lb.LoadBalancingRules["rule-1"];
                    Assert.NotNull(rule.Backend);
                    Assert.Equal("tcpProbe-1", rule.Probe.Name, ignoreCase: true);

                    // Note that above configuration is not possible for BASIC LB, BASIC LB has following limitation
                    // It supports VMs only in a single availability Set in a backend pool, though multiple backend pool
                    // can be associated with VMs in the single availability set, you cannot create a set of VMs in another
                    // availability set and put it in a different backend pool.
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact(Skip = "Cannot be run because of NRP bug.")]
        // This test put multiple zonal virtual machine's NIC into backend pool of a zone-redundant load balancer.
        // There is a bug in the service, where such an attempt will fail with error
        // "error": {
        //    "code": "NetworkInterfaceAndLoadBalancerAreInDifferentAvailabilitySets",
        //    "message": "Network interface /subscriptions/<sub-id>/resourceGroups/<rg-name>/providers/Microsoft.Network/networkInterfaces/<nic-name> uses load balancer /subscriptions/<sub-id>/resourceGroups/<rg-name>/providers/Microsoft.Compute/virtualMachines/<vm-name>).",
        //    "details": []
        // }
        // Enable this test once it is fixed. 
        //
        public void CanCreateZonedVMsAndAssociateThemWithSingleBackendPoolOfZoneResilientLB()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("rgzoned");
                try
                {
                    var region = Region.USEast2;
                    string networkName = TestUtilities.GenerateName("net");

                    var azure = TestHelper.CreateRollupClient();
                    var network = azure.Networks.Define(networkName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnet1", "10.0.0.0/29")
                        .WithSubnet("subnet2", "10.0.0.8/29")
                        .Create();

                    string pipDnsLabel = TestUtilities.GenerateName("pip");

                    var subnets = network.Subnets.Values.GetEnumerator();
                    // Define first regional virtual machine
                    //
                    subnets.MoveNext();
                    var creatableVM1 = azure.VirtualMachines
                            .Define(TestUtilities.GenerateName("vm1"))
                            .WithRegion(region)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetwork(network)
                            .WithSubnet(subnets.Current.Name)      // Put VM in first subnet
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("Foo12")
                            .WithRootPassword("abc!@#F0orL")
                            // Optionals
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_1)
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"));

                    subnets.MoveNext();
                    var creatableVM2 = azure.VirtualMachines
                            .Define(TestUtilities.GenerateName("vm2"))
                            .WithRegion(region)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetwork(network)
                            .WithSubnet(subnets.Current.Name)      // Put VM in second subnet
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("Foo12")
                            .WithRootPassword("abc!@#F0orL")
                            // Optionals
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_1)
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"));

                    ICreatedResources<IVirtualMachine> createdVMs = azure.VirtualMachines.Create(creatableVM1, creatableVM2);

                    var itr = createdVMs.GetEnumerator();
                    itr.MoveNext();
                    IVirtualMachine firstVirtualMachine = itr.Current;
                    itr.MoveNext();
                    IVirtualMachine secondVirtualMachine = itr.Current;

                    var publicIPAddress = azure.PublicIPAddresses
                        .Define(pipDnsLabel)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithStaticIP()
                        // Optionals
                        .WithSku(PublicIPSkuType.Standard)  //  STANDARD LB requires STANDARD PIP
                                                            // Create PIP
                        .Create();

                    // Creates a Internet-Facing LoadBalancer with one front-end IP configuration and
                    // two backend pool associated with this IP Config
                    //
                    var lbName = TestUtilities.GenerateName("lb");
                    ILoadBalancer lb = azure.LoadBalancers
                            .Define(lbName)
                                .WithRegion(region)
                                .WithExistingResourceGroup(rgName)
                                .DefineLoadBalancingRule("rule-1")
                                    .WithProtocol(TransportProtocol.Tcp)
                                    .FromFrontend("front-end-1")
                                    .FromFrontendPort(80)
                                    .ToExistingVirtualMachines(firstVirtualMachine, secondVirtualMachine)
                                    .WithProbe("tcpProbe-1")
                                    .Attach()
                                .DefinePublicFrontend("front-end-1") // Define the frontend IP configuration used by the LB rule
                                    .WithExistingPublicIPAddress(publicIPAddress)
                                    .Attach()
                                .DefineTcpProbe("tcpProbe-1") // Define the Probe used by the LB rule
                                    .WithPort(25)
                                    .WithIntervalInSeconds(15)
                                    .WithNumberOfProbes(5)
                                    .Attach()
                                .WithSku(LoadBalancerSkuType.Standard)  // "zone-resilient LB" which don't have the constraint that all VMs needs to be in the same availability set
                                .Create();

                    // Zone resilient LB does not care VMs are zoned or regional, in the above cases VMs are regional.
                    //
                    // rx.Completable.merge(firstVirtualMachine.startAsync(), secondVirtualMachine.startAsync()).await();

                    // Verify frontends
                    Assert.Equal(1, lb.Frontends.Count);
                    Assert.Equal(1, lb.PublicFrontends.Count);
                    Assert.Equal(0, lb.PrivateFrontends.Count);
                    ILoadBalancerFrontend frontend = lb.Frontends.Values.First();
                    Assert.True(frontend.IsPublic);
                    ILoadBalancerPublicFrontend publicFrontend = (ILoadBalancerPublicFrontend)frontend;
                    Assert.Equal(publicIPAddress.Id, publicFrontend.PublicIPAddressId, ignoreCase: true);

                    // Verify backends
                    Assert.Equal(1, lb.Backends.Count);

                    // Verify probes
                    Assert.Equal(1, lb.TcpProbes.Count);
                    Assert.True(lb.TcpProbes.ContainsKey("tcpProbe-1"));

                    // Verify rules
                    Assert.Equal(1, lb.LoadBalancingRules.Count);
                    Assert.True(lb.LoadBalancingRules.ContainsKey("rule-1"));
                    ILoadBalancingRule rule = lb.LoadBalancingRules["rule-1"];
                    Assert.NotNull(rule.Backend);
                    Assert.Equal("tcpProbe-1", rule.Probe.Name, ignoreCase: true);
                    // Zone resilient LB does not care VMs are zoned or regional, in the above cases VMs are zoned.
                    //

                    // Note that above configuration is not possible for BASIC LB, BASIC LB has following limitation
                    // It supports VMs only in a single availability Set in a backend pool, though multiple backend pool
                    // can be associated with VMs in the single availability set, you cannot create a set of VMs in another
                    // availability set and put it in a different backend pool.
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }
    }
}