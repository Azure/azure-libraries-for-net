// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Fluent.Tests.Compute.VirtualMachine;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Fluent.Tests.Compute.VirtualMachine
{
    public class ScaleSetBootDiagnosticsOperations
    {
        private readonly Region Location = Region.USEast;

        [Fact]
        public void CanEnableWithImplicitStorageOnManagedVMSSCreation()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmssName = SdkContext.RandomResourceName("vmss", 10);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var networkManager = TestHelper.CreateNetworkManager();
                var storageManager = TestHelper.CreateStorageManager();
                var rgName = TestUtilities.GenerateName("rgvmss-");

                try
                {
                    var resourceGroup = resourceManager.ResourceGroups
                                                    .Define(rgName)
                                                    .WithRegion(Location)
                                                    .Create();

                    var network = networkManager.Networks
                        .Define("vmssvnet")
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnet1", "10.0.0.0/28")
                        .Create();

                    var publicLoadBalancer = ScaleSet.CreateInternetFacingLoadBalancer(resourceManager,
                            resourceGroup,
                            "1",
                            LoadBalancerSkuType.Basic,
                            Location);

                    List<String> backends = new List<string>();
                    foreach (String backend in publicLoadBalancer.Backends.Keys)
                    {
                        backends.Add(backend);
                    }
                    Assert.True(backends.Count == 2);

                    var virtualMachineScaleSet = computeManager.VirtualMachineScaleSets
                        .Define(vmssName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithSku(VirtualMachineScaleSetSkuTypes.StandardA0)
                        .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                        .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                        .WithPrimaryInternetFacingLoadBalancerBackends(backends[0], backends[1])
                        .WithoutPrimaryInternalLoadBalancer()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("jvuser")
                        .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                        .WithBootDiagnostics()
                        .Create();

                    Assert.NotNull(virtualMachineScaleSet);
                    Assert.True(virtualMachineScaleSet.IsBootDiagnosticsEnabled);
                    Assert.NotNull(virtualMachineScaleSet.BootDiagnosticsStorageUri);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanEnableWithCreatableStorageOnManagedVMSSCreation()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmssName = SdkContext.RandomResourceName("vmss", 10);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var networkManager = TestHelper.CreateNetworkManager();
                var storageManager = TestHelper.CreateStorageManager();
                var rgName = TestUtilities.GenerateName("rgvmss-");
                var storageName = TestUtilities.GenerateName("stg");

                try
                {
                    var resourceGroup = resourceManager.ResourceGroups
                                .Define(rgName)
                                .WithRegion(Location)
                                .Create();

                    var network = networkManager.Networks
                        .Define("vmssvnet")
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnet1", "10.0.0.0/28")
                        .Create();

                    var publicLoadBalancer = ScaleSet.CreateInternetFacingLoadBalancer(resourceManager,
                            resourceGroup,
                            "1",
                            LoadBalancerSkuType.Basic,
                            Location);

                    List<String> backends = new List<string>();
                    foreach (String backend in publicLoadBalancer.Backends.Keys)
                    {
                        backends.Add(backend);
                    }
                    Assert.True(backends.Count == 2);

                    var creatableStorageAccount = storageManager.StorageAccounts
                        .Define(storageName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(rgName);

                    var virtualMachineScaleSet = computeManager.VirtualMachineScaleSets
                        .Define(vmssName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithSku(VirtualMachineScaleSetSkuTypes.StandardA0)
                        .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                        .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                        .WithPrimaryInternetFacingLoadBalancerBackends(backends[0], backends[1])
                        .WithoutPrimaryInternalLoadBalancer()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("jvuser")
                        .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                        .WithBootDiagnostics(creatableStorageAccount)
                        .Create();

                    Assert.NotNull(virtualMachineScaleSet);
                    Assert.True(virtualMachineScaleSet.IsBootDiagnosticsEnabled);
                    Assert.NotNull(virtualMachineScaleSet.BootDiagnosticsStorageUri);
                    Assert.Contains(storageName, virtualMachineScaleSet.BootDiagnosticsStorageUri);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanEnableBootDiagnosticsWithExplicitStorageOnManagedVMSSCreation()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmssName = SdkContext.RandomResourceName("vmss", 10);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var networkManager = TestHelper.CreateNetworkManager();
                var storageManager = TestHelper.CreateStorageManager();
                var rgName = TestUtilities.GenerateName("rgvmss-");
                var storageName = TestUtilities.GenerateName("stg");

                try
                {
                    var resourceGroup = resourceManager.ResourceGroups
                                .Define(rgName)
                                .WithRegion(Location)
                                .Create();

                    var network = networkManager.Networks
                        .Define("vmssvnet")
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnet1", "10.0.0.0/28")
                        .Create();

                    var publicLoadBalancer = ScaleSet.CreateInternetFacingLoadBalancer(resourceManager,
                            resourceGroup,
                            "1",
                            LoadBalancerSkuType.Basic,
                            Location);

                    List<String> backends = new List<string>();
                    foreach (String backend in publicLoadBalancer.Backends.Keys)
                    {
                        backends.Add(backend);
                    }
                    Assert.True(backends.Count == 2);

                    var storageAccount = storageManager.StorageAccounts
                        .Define(storageName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(rgName)
                        .Create();

                    var virtualMachineScaleSet = computeManager.VirtualMachineScaleSets
                        .Define(vmssName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithSku(VirtualMachineScaleSetSkuTypes.StandardA0)
                        .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                        .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                        .WithPrimaryInternetFacingLoadBalancerBackends(backends[0], backends[1])
                        .WithoutPrimaryInternalLoadBalancer()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("jvuser")
                        .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                        .WithBootDiagnostics(storageAccount)
                        .Create();

                    Assert.NotNull(virtualMachineScaleSet);
                    Assert.True(virtualMachineScaleSet.IsBootDiagnosticsEnabled);
                    Assert.NotNull(virtualMachineScaleSet.BootDiagnosticsStorageUri);
                    Assert.Contains(storageName, virtualMachineScaleSet.BootDiagnosticsStorageUri);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanDisable()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmssName = SdkContext.RandomResourceName("vmss", 10);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var networkManager = TestHelper.CreateNetworkManager();
                var rgName = TestUtilities.GenerateName("rgvmss-");

                try
                {
                    var resourceGroup = resourceManager.ResourceGroups
                                .Define(rgName)
                                .WithRegion(Location)
                                .Create();

                    var network = networkManager.Networks
                        .Define("vmssvnet")
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnet1", "10.0.0.0/28")
                        .Create();

                    var publicLoadBalancer = ScaleSet.CreateInternetFacingLoadBalancer(resourceManager,
                            resourceGroup,
                            "1",
                            LoadBalancerSkuType.Basic,
                            Location);

                    List<String> backends = new List<string>();
                    foreach (String backend in publicLoadBalancer.Backends.Keys)
                    {
                        backends.Add(backend);
                    }
                    Assert.True(backends.Count == 2);

                    var virtualMachineScaleSet = computeManager.VirtualMachineScaleSets
                        .Define(vmssName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithSku(VirtualMachineScaleSetSkuTypes.StandardA0)
                        .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                        .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                        .WithPrimaryInternetFacingLoadBalancerBackends(backends[0], backends[1])
                        .WithoutPrimaryInternalLoadBalancer()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("jvuser")
                        .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                        .WithBootDiagnostics()
                        .Create();

                    Assert.NotNull(virtualMachineScaleSet);
                    Assert.True(virtualMachineScaleSet.IsBootDiagnosticsEnabled);
                    Assert.NotNull(virtualMachineScaleSet.BootDiagnosticsStorageUri);

                    virtualMachineScaleSet.Update()
                        .WithoutBootDiagnostics()
                        .Apply();

                    Assert.False(virtualMachineScaleSet.IsBootDiagnosticsEnabled);
                    // Disabling boot diagnostics will not remove the storage uri from the vm payload.
                    Assert.NotNull(virtualMachineScaleSet.BootDiagnosticsStorageUri);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void ShouldUsesVMSSOSUnManagedDiskImplicitStorage()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmssName = SdkContext.RandomResourceName("vmss", 10);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var networkManager = TestHelper.CreateNetworkManager();
                var rgName = TestUtilities.GenerateName("rgvmss-");

                try
                {
                    var resourceGroup = resourceManager.ResourceGroups
            .Define(rgName)
            .WithRegion(Location)
            .Create();

                    var network = networkManager.Networks
                        .Define("vmssvnet")
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnet1", "10.0.0.0/28")
                        .Create();

                    var publicLoadBalancer = ScaleSet.CreateInternetFacingLoadBalancer(resourceManager,
                            resourceGroup,
                            "1",
                            LoadBalancerSkuType.Basic,
                            Location);

                    List<String> backends = new List<string>();
                    foreach (String backend in publicLoadBalancer.Backends.Keys)
                    {
                        backends.Add(backend);
                    }
                    Assert.True(backends.Count == 2);

                    var virtualMachineScaleSet = computeManager.VirtualMachineScaleSets
                        .Define(vmssName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithSku(VirtualMachineScaleSetSkuTypes.StandardA0)
                        .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                        .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                        .WithPrimaryInternetFacingLoadBalancerBackends(backends[0], backends[1])
                        .WithoutPrimaryInternalLoadBalancer()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("jvuser")
                        .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                        .WithUnmanagedDisks()
                        .WithBootDiagnostics()
                        .Create();

                    Assert.NotNull(virtualMachineScaleSet);
                    Assert.True(virtualMachineScaleSet.IsBootDiagnosticsEnabled);
                    Assert.NotNull(virtualMachineScaleSet.BootDiagnosticsStorageUri);

                    var inner = virtualMachineScaleSet.Inner;
                    Assert.NotNull(inner);
                    Assert.NotNull(inner.VirtualMachineProfile);
                    Assert.NotNull(inner.VirtualMachineProfile.StorageProfile);
                    Assert.NotNull(inner.VirtualMachineProfile.StorageProfile.OsDisk);
                    var containers = inner.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers;
                    Assert.False(containers.Count == 0);
                    // Boot diagnostics should share storage used for os/disk containers
                    bool found = containers.Any(containerStorageUri => containerStorageUri.StartsWith(virtualMachineScaleSet.BootDiagnosticsStorageUri, StringComparison.OrdinalIgnoreCase));
                    Assert.True(found);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void ShouldUseVMSSUnManagedDisksExplicitStorage()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmssName = SdkContext.RandomResourceName("vmss", 10);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var networkManager = TestHelper.CreateNetworkManager();
                var storageManager = TestHelper.CreateStorageManager();
                var rgName = TestUtilities.GenerateName("rgvmss-");
                var storageName = TestUtilities.GenerateName("stg");

                try
                {
                    var resourceGroup = resourceManager.ResourceGroups
                                .Define(rgName)
                                .WithRegion(Location)
                                .Create();

                    var network = networkManager.Networks
                        .Define("vmssvnet")
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnet1", "10.0.0.0/28")
                        .Create();

                    var publicLoadBalancer = ScaleSet.CreateInternetFacingLoadBalancer(resourceManager,
                            resourceGroup,
                            "1",
                            LoadBalancerSkuType.Basic,
                            Location);

                    List<String> backends = new List<string>();
                    foreach (String backend in publicLoadBalancer.Backends.Keys)
                    {
                        backends.Add(backend);
                    }
                    Assert.True(backends.Count == 2);

                    var storageAccount = storageManager.StorageAccounts
                        .Define(storageName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(rgName)
                        .Create();

                    var virtualMachineScaleSet = computeManager.VirtualMachineScaleSets
                        .Define(vmssName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithSku(VirtualMachineScaleSetSkuTypes.StandardA0)
                        .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                        .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                        .WithPrimaryInternetFacingLoadBalancerBackends(backends[0], backends[1])
                        .WithoutPrimaryInternalLoadBalancer()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("jvuser")
                        .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                        .WithUnmanagedDisks()
                        .WithBootDiagnostics()
                        .WithExistingStorageAccount(storageAccount)
                        .Create();

                    Assert.NotNull(virtualMachineScaleSet);
                    Assert.True(virtualMachineScaleSet.IsBootDiagnosticsEnabled);
                    Assert.NotNull(virtualMachineScaleSet.BootDiagnosticsStorageUri);
                    Assert.Contains(storageName, virtualMachineScaleSet.BootDiagnosticsStorageUri);

                    var inner = virtualMachineScaleSet.Inner;
                    Assert.NotNull(inner);
                    Assert.NotNull(inner.VirtualMachineProfile);
                    Assert.NotNull(inner.VirtualMachineProfile.StorageProfile);
                    Assert.NotNull(inner.VirtualMachineProfile.StorageProfile.OsDisk);
                    var containers = inner.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers;
                    Assert.False(containers.Count() == 0);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void  CanEnableWithCreatableStorageOnUnManagedVMSSCreation()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmssName = SdkContext.RandomResourceName("vmss", 10);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var networkManager = TestHelper.CreateNetworkManager();
                var storageManager = TestHelper.CreateStorageManager();
                var rgName = TestUtilities.GenerateName("rgvmss-");
                var storageName = TestUtilities.GenerateName("stg");

                try
                {
                    var resourceGroup = resourceManager.ResourceGroups
                                .Define(rgName)
                                .WithRegion(Location)
                                .Create();

                    var network = networkManager.Networks
                        .Define("vmssvnet")
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnet1", "10.0.0.0/28")
                        .Create();

                    var publicLoadBalancer = ScaleSet.CreateInternetFacingLoadBalancer(resourceManager,
                            resourceGroup,
                            "1",
                            LoadBalancerSkuType.Basic,
                            Location);

                    List<String> backends = new List<string>();
                    foreach (String backend in publicLoadBalancer.Backends.Keys)
                    {
                        backends.Add(backend);
                    }
                    Assert.True(backends.Count == 2);

                    var creatableStorageAccount = storageManager.StorageAccounts
                        .Define(storageName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(rgName);

                    var virtualMachineScaleSet = computeManager.VirtualMachineScaleSets
                        .Define(vmssName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithSku(VirtualMachineScaleSetSkuTypes.StandardA0)
                        .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                        .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                        .WithPrimaryInternetFacingLoadBalancerBackends(backends[0], backends[1])
                        .WithoutPrimaryInternalLoadBalancer()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("jvuser")
                        .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                        .WithUnmanagedDisks()
                        .WithBootDiagnostics(creatableStorageAccount) // This storage account should be used for BDiagnostics not OS disk storage account
                        .Create();

                    Assert.NotNull(virtualMachineScaleSet);
                    Assert.True(virtualMachineScaleSet.IsBootDiagnosticsEnabled);
                    Assert.NotNull(virtualMachineScaleSet.BootDiagnosticsStorageUri);
                    Assert.Contains(storageName, virtualMachineScaleSet.BootDiagnosticsStorageUri);


                    // There should be a different storage account created for VMSS OS Disk
                    var inner = virtualMachineScaleSet.Inner;
                    Assert.NotNull(inner);
                    Assert.NotNull(inner.VirtualMachineProfile);
                    Assert.NotNull(inner.VirtualMachineProfile.StorageProfile);
                    Assert.NotNull(inner.VirtualMachineProfile.StorageProfile.OsDisk);
                    var containers = inner.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers;
                    Assert.False(containers.Count() == 0);
                    bool notFound = true;
                    foreach (var containerStorageUri in containers)
                    {
                        if (containerStorageUri.StartsWith(virtualMachineScaleSet.BootDiagnosticsStorageUri, StringComparison.OrdinalIgnoreCase))
                        {
                            notFound = false;
                            break;
                        }
                    }
                    Assert.True(notFound);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }
    }
}
