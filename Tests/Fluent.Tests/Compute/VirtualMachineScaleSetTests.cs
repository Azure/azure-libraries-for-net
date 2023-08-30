// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Runtime.CompilerServices;
using Azure.Tests;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Net;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.Storage.Fluent;

using ResourceIdentityType = Microsoft.Azure.Management.Compute.Fluent.Models.ResourceIdentityType;

namespace Fluent.Tests.Compute.VirtualMachine
{
    public class ScaleSet
    {
        private readonly Region Location = Region.USEast;

        [Fact]
        public void CanUpdateWithExtensionProtectedSettings()
        {
            // Test for https://github.com/Azure/azure-sdk-for-net/issues/2716
            //
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("javacsmrg");
                var vmssName = TestUtilities.GenerateName("vmss");
                var uname = "jvuser";
                var password = TestUtilities.GenerateName("Pa5$");

                var azure = TestHelper.CreateRollupClient();

                try
                { 
                    var resourceGroup = azure.ResourceGroups
                        .Define(rgName)
                        .WithRegion(Location)
                        .Create();

                    var storageAccount = azure.StorageAccounts
                        .Define(TestUtilities.GenerateName("stg"))
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .Create();

                    var keys = storageAccount.GetKeys();
                    Assert.NotNull(keys);
                    Assert.True(keys.Count() > 0);
                    var storageAccountKey = keys.First();
                    string uri = prepareCustomScriptStorageUri(storageAccount.Name, storageAccountKey.Value, "scripts");
                    List<string> fileUris = new List<string>();
                    fileUris.Add(uri);

                    var network = azure.Networks
                            .Define(TestUtilities.GenerateName("vmssvnet"))
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithSubnet("subnet1", "10.0.0.0/28")
                            .Create();

                    var virtualMachineScaleSet = azure.VirtualMachineScaleSets.Define(vmssName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithSku(VirtualMachineScaleSetSkuTypes.StandardDS3v2)
                            .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                            .WithoutPrimaryInternetFacingLoadBalancer()
                            .WithoutPrimaryInternalLoadBalancer()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername(uname)
                            .WithRootPassword(password)
                            .WithUnmanagedDisks()
                            .WithNewStorageAccount(TestUtilities.GenerateName("stg"))
                            .WithExistingStorageAccount(storageAccount)
                            .DefineNewExtension("CustomScriptForLinux")
                                .WithPublisher("Microsoft.OSTCExtensions")
                                .WithType("CustomScriptForLinux")
                                .WithVersion("1.4")
                                .WithMinorVersionAutoUpgrade()
                                .WithPublicSetting("fileUris", fileUris)
                                .WithProtectedSetting("commandToExecute", "bash install_apache.sh")
                                .WithProtectedSetting("storageAccountName", storageAccount.Name)
                                .WithProtectedSetting("storageAccountKey", storageAccountKey.Value)
                                .Attach()
                            .Create();
                    // Validate extensions after create
                    //
                    var extensions = virtualMachineScaleSet.Extensions;
                    Assert.NotNull(extensions);
                    Assert.Equal(1, extensions.Count);
                    Assert.True(extensions.ContainsKey("CustomScriptForLinux"));
                    var extension = extensions["CustomScriptForLinux"];
                    Assert.NotNull(extension.PublicSettings);
                    Assert.Equal(1, extension.PublicSettings.Count);
                    Assert.NotNull(extension.PublicSettingsAsJsonString);
                    // Retrieve scale set
                    var scaleSet = azure
                            .VirtualMachineScaleSets
                            .GetById(virtualMachineScaleSet.Id);
                    // Validate extensions after get
                    //
                    extensions = virtualMachineScaleSet.Extensions;
                    Assert.NotNull(extensions);
                    Assert.Equal(1, extensions.Count);
                    Assert.True(extensions.ContainsKey("CustomScriptForLinux"));
                    extension = extensions["CustomScriptForLinux"];
                    Assert.NotNull(extension.PublicSettings);
                    Assert.Equal(1, extension.PublicSettings.Count);
                    Assert.NotNull(extension.PublicSettingsAsJsonString);
                    // Update VMSS capacity
                    //
                    int newCapacity = (int)(scaleSet.Capacity + 1);
                    virtualMachineScaleSet.Update()
                            .WithCapacity(newCapacity)
                            .Apply();
                    // Validate updated capacity
                    //
                    Assert.Equal(newCapacity, virtualMachineScaleSet.Capacity);
                    // Validate extensions after update
                    //
                    extensions = virtualMachineScaleSet.Extensions;
                    Assert.NotNull(extensions);
                    Assert.Equal(1, extensions.Count);
                    Assert.True(extensions.ContainsKey("CustomScriptForLinux"));
                    extension = extensions["CustomScriptForLinux"];
                    Assert.NotNull(extension.PublicSettings);
                    Assert.Equal(1, extension.PublicSettings.Count);
                    Assert.NotNull(extension.PublicSettingsAsJsonString);
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
        public void CanUpdateExtensionPublicProtectedSettings()
        {
            // Test for https://github.com/Azure/azure-sdk-for-net/issues/3398
            //
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("javacsmrg");
                var vmssName = TestUtilities.GenerateName("vmss");
                var uname = "jvuser";
                var password = TestUtilities.GenerateName("Pa5$");

                var azure = TestHelper.CreateRollupClient();

                try
                { 
                    var resourceGroup = azure.ResourceGroups
                        .Define(rgName)
                        .WithRegion(Location)
                        .Create();

                    var storageAccount = azure.StorageAccounts
                        .Define(TestUtilities.GenerateName("stg"))
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .Create();

                    var keys = storageAccount.GetKeys();
                    Assert.NotNull(keys);
                    Assert.True(keys.Count() > 0);
                    var storageAccountKey = keys.First();
                    string uri = prepareCustomScriptStorageUri(storageAccount.Name, storageAccountKey.Value, "scripts");
                    List<string> fileUris = new List<string>();
                    fileUris.Add(uri);

                    var network = azure.Networks
                            .Define(TestUtilities.GenerateName("vmssvnet"))
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithSubnet("subnet1", "10.0.0.0/28")
                            .Create();

                    var virtualMachineScaleSet = azure.VirtualMachineScaleSets.Define(vmssName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithSku(VirtualMachineScaleSetSkuTypes.StandardDS3v2)
                            .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                            .WithoutPrimaryInternetFacingLoadBalancer()
                            .WithoutPrimaryInternalLoadBalancer()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername(uname)
                            .WithRootPassword(password)
                            .WithUnmanagedDisks()
                            .WithNewStorageAccount(TestUtilities.GenerateName("stg"))
                            .WithExistingStorageAccount(storageAccount)
                            .DefineNewExtension("CustomScriptForLinux")
                                .WithPublisher("Microsoft.OSTCExtensions")
                                .WithType("CustomScriptForLinux")
                                .WithVersion("1.4")
                                .WithMinorVersionAutoUpgrade()
                                .WithPublicSetting("fileUris", fileUris)
                                .WithProtectedSetting("commandToExecute", "bash install_apache.sh")
                                .WithProtectedSetting("storageAccountName", storageAccount.Name)
                                .WithProtectedSetting("storageAccountKey", storageAccountKey.Value)
                                .Attach()
                            .Create();
                    // Validate extensions after create
                    //
                    var extensions = virtualMachineScaleSet.Extensions;
                    Assert.NotNull(extensions);
                    Assert.Equal(1, extensions.Count);
                    Assert.True(extensions.ContainsKey("CustomScriptForLinux"));
                    var customScriptExtension = extensions["CustomScriptForLinux"];
                    Assert.NotNull(customScriptExtension);
                    Assert.Equal("Microsoft.OSTCExtensions", customScriptExtension.PublisherName);
                    Assert.Equal("CustomScriptForLinux", customScriptExtension.TypeName);
                    Assert.NotNull(customScriptExtension.PublicSettings);
                    Assert.Equal(1, customScriptExtension.PublicSettings.Count);
                    Assert.NotNull(customScriptExtension.PublicSettingsAsJsonString);
                    Assert.True(customScriptExtension.AutoUpgradeMinorVersionEnabled);

                    // Special check for C# implementation, seems runtime changed the actual type of public settings from 
                    // dictionary to Newtonsoft.Json.Linq.JObject. In future such changes needs to be catched before attemptting
                    // inner conversion hence the below special validation (not applicable for Java)
                    //
                    Assert.NotNull(customScriptExtension.Inner);
                    Assert.NotNull(customScriptExtension.Inner.Settings);
                    bool isJObject = customScriptExtension.Inner.Settings is JObject;
                    bool isDictionary = customScriptExtension.Inner.Settings is IDictionary<string, object>;
                    Assert.True(isJObject || isDictionary);

                    // Ensure the public settings are accessible, the protected settings won't be returned from the service.
                    //
                    var publicSettings = customScriptExtension.PublicSettings;
                    Assert.NotNull(publicSettings);
                    Assert.Equal(1, publicSettings.Count);
                    Assert.True(publicSettings.ContainsKey("fileUris"));
                    string fileUrisString = (publicSettings["fileUris"]).ToString();
                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        Assert.Contains(uri, fileUrisString);
                    }

                    /*** UPDATE THE EXTENSION WITH NEW PUBLIC AND PROTECTED SETTINGS **/

                    // Regenerate the storage account key
                    //
                    storageAccount.RegenerateKey(storageAccountKey.KeyName);
                    keys = storageAccount.GetKeys();
                    Assert.NotNull(keys);
                    Assert.True(keys.Count() > 0);
                    var updatedStorageAccountKey = keys.FirstOrDefault(key => key.KeyName.Equals(storageAccountKey.KeyName, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(updatedStorageAccountKey);
                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        Assert.NotEqual(updatedStorageAccountKey.Value, storageAccountKey.Value);
                    }

                    // Upload the script to a different container ("scripts2") in the same storage account
                    //
                    var uri2 = prepareCustomScriptStorageUri(storageAccount.Name, updatedStorageAccountKey.Value, "scripts2");
                    List<string> fileUris2 = new List<string>();
                    fileUris2.Add(uri2);
                    string commandToExecute2 = "bash install_apache.sh";

                    virtualMachineScaleSet.Update()
                        .UpdateExtension("CustomScriptForLinux")
                            .WithPublicSetting("fileUris", fileUris2)
                            .WithProtectedSetting("commandToExecute", commandToExecute2)
                            .WithProtectedSetting("storageAccountName", storageAccount.Name)
                            .WithProtectedSetting("storageAccountKey", updatedStorageAccountKey.Value)
                            .Parent()
                        .Apply();

                    extensions = virtualMachineScaleSet.Extensions;
                    Assert.NotNull(extensions);
                    Assert.Equal(1, extensions.Count);
                    Assert.True(extensions.ContainsKey("CustomScriptForLinux"));
                    var customScriptExtension2 = extensions["CustomScriptForLinux"];
                    Assert.NotNull(customScriptExtension2);
                    Assert.Equal("Microsoft.OSTCExtensions", customScriptExtension2.PublisherName);
                    Assert.Equal("CustomScriptForLinux", customScriptExtension2.TypeName);
                    Assert.True(customScriptExtension2.AutoUpgradeMinorVersionEnabled);

                    var publicSettings2 = customScriptExtension2.PublicSettings;
                    Assert.NotNull(publicSettings2);
                    Assert.Equal(1, publicSettings2.Count);
                    Assert.True(publicSettings2.ContainsKey("fileUris"));
                    string fileUris2String = (publicSettings2["fileUris"]).ToString();
                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        Assert.Contains(uri2, fileUris2String);
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
        public void CanCreateWithCustomScriptExtension()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("javacsmrg");
                string vmssName = TestUtilities.GenerateName("vmss");
                string apacheInstallScript = "https://raw.githubusercontent.com/Azure/azure-libraries-for-net/master/Tests/Fluent.Tests/Assets/install_apache.sh";
                string installCommand = "bash install_apache.sh Abc.123x(";
                List<string> fileUris = new List<string>();
                fileUris.Add(apacheInstallScript);

                var azure = TestHelper.CreateRollupClient();

                try
                { 
                    IResourceGroup resourceGroup = azure.ResourceGroups
                        .Define(rgName)
                        .WithRegion(Location)
                        .Create();

                    INetwork network = azure
                        .Networks
                        .Define(TestUtilities.GenerateName("vmssvnet"))
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnet1", "10.0.0.0/28")
                        .Create();

                    ILoadBalancer publicLoadBalancer = CreateHttpLoadBalancers(azure, resourceGroup, "1", Location);
                    IVirtualMachineScaleSet virtualMachineScaleSet = azure.VirtualMachineScaleSets
                            .Define(vmssName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithSku(VirtualMachineScaleSetSkuTypes.StandardDS3v2)
                            .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                            .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                            .WithoutPrimaryInternalLoadBalancer()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("jvuser")
                            .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                            .WithUnmanagedDisks()
                            .WithNewStorageAccount(TestUtilities.GenerateName("stg"))
                            .WithNewStorageAccount(TestUtilities.GenerateName("stg"))
                            .DefineNewExtension("CustomScriptForLinux")
                                .WithPublisher("Microsoft.OSTCExtensions")
                                .WithType("CustomScriptForLinux")
                                .WithVersion("1.4")
                                .WithMinorVersionAutoUpgrade()
                                .WithPublicSetting("fileUris", fileUris)
                                .WithPublicSetting("commandToExecute", installCommand)
                                .Attach()
                            .WithUpgradeMode(UpgradeMode.Manual)
                            .Create();

                    IReadOnlyList<string> publicIPAddressIds = virtualMachineScaleSet.PrimaryPublicIPAddressIds;
                    IPublicIPAddress publicIPAddress = azure.PublicIPAddresses
                            .GetById(publicIPAddressIds[0]);

                    string fqdn = publicIPAddress.Fqdn;
                    Assert.NotNull(fqdn);

                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        // Assert public load balancing connection
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri("http://" + fqdn);
                        HttpResponseMessage response = client.GetAsync("/").Result;
                        Assert.True(response.IsSuccessStatusCode);
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
        public void CanCreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string vmss_name = TestUtilities.GenerateName("vmss");
                string rgName = TestUtilities.GenerateName("javacsmrg");

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    IResourceGroup resourceGroup = azure.ResourceGroups
                        .Define(rgName)
                        .WithRegion(Location)
                        .Create();

                    INetwork network = azure
                        .Networks
                        .Define("vmssvnet")
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnet1", "10.0.0.0/28")
                        .Create();

                    ILoadBalancer publicLoadBalancer = CreateInternetFacingLoadBalancer(azure, resourceGroup, "1", LoadBalancerSkuType.Basic, Location);
                    List<string> backends = new List<string>();
                    foreach (string backend in publicLoadBalancer.Backends.Keys)
                    {
                        backends.Add(backend);
                    }
                    Assert.True(backends.Count() == 2);

                    IVirtualMachineScaleSet virtualMachineScaleSet = azure.VirtualMachineScaleSets
                        .Define(vmss_name)
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
                        .WithNewStorageAccount(TestUtilities.GenerateName("stg"))
                        .WithNewStorageAccount(TestUtilities.GenerateName("stg3"))
                        .WithUpgradeMode(UpgradeMode.Manual)
                        .Create();

                    Assert.Null(virtualMachineScaleSet.GetPrimaryInternalLoadBalancer());
                    Assert.True(virtualMachineScaleSet.ListPrimaryInternalLoadBalancerBackends().Count() == 0);
                    Assert.True(virtualMachineScaleSet.ListPrimaryInternalLoadBalancerInboundNatPools().Count() == 0);

                    Assert.NotNull(virtualMachineScaleSet.GetPrimaryInternetFacingLoadBalancer());
                    Assert.True(virtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerBackends().Count() == 2);
                    Assert.True(virtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerInboundNatPools().Count() == 2);

                    var primaryNetwork = virtualMachineScaleSet.GetPrimaryNetwork();
                    Assert.NotNull(primaryNetwork.Id);

                    var nics = virtualMachineScaleSet.ListNetworkInterfaces();
                    int nicCount = 0;
                    foreach (var nic in nics)
                    {
                        nicCount++;
                        Assert.NotNull(nic.Id);
                        Assert.StartsWith(virtualMachineScaleSet.Id.ToLower(), nic.VirtualMachineId.ToLower());
                        Assert.NotNull(nic.MacAddress);
                        Assert.NotNull(nic.DnsServers);
                        Assert.NotNull(nic.AppliedDnsServers);
                        var ipConfigs = nic.IPConfigurations;
                        Assert.Single(ipConfigs);
                        foreach (var ipConfig in ipConfigs.Values)
                        {
                            Assert.NotNull(ipConfig);
                            Assert.True(ipConfig.IsPrimary);
                            Assert.NotNull(ipConfig.SubnetName);
                            Assert.True(string.Compare(primaryNetwork.Id, ipConfig.NetworkId, true) == 0);
                            Assert.NotNull(ipConfig.PrivateIPAddress);
                            Assert.NotNull(ipConfig.PrivateIPAddressVersion);
                            Assert.NotNull(ipConfig.PrivateIPAllocationMethod);
                            var lbBackends = ipConfig.ListAssociatedLoadBalancerBackends();
                            // VMSS is created with a internet facing LB with two Backend pools so there will be two
                            // backends in ip-config as well
                            Assert.Equal(2, lbBackends.Count);
                            foreach (var lbBackend in lbBackends)
                            {
                                var lbRules = lbBackend.LoadBalancingRules;
                                Assert.Equal(1, lbRules.Count);
                                foreach (var rule in lbRules.Values)
                                {
                                    Assert.NotNull(rule);
                                    Assert.True((rule.FrontendPort == 80 && rule.BackendPort == 80) ||
                                                (rule.FrontendPort == 443 && rule.BackendPort == 443));
                                }
                            }
                            var lbNatRules = ipConfig.ListAssociatedLoadBalancerInboundNatRules();
                            // VMSS is created with a internet facing LB with two nat pools so there will be two
                            //  nat rules in ip-config as well
                            Assert.Equal(2, lbNatRules.Count);
                            foreach (var lbNatRule in lbNatRules)
                            {
                                Assert.True((lbNatRule.FrontendPort >= 5000 && lbNatRule.FrontendPort <= 5099) ||
                                            (lbNatRule.FrontendPort >= 6000 && lbNatRule.FrontendPort <= 6099));
                                Assert.True(lbNatRule.BackendPort == 22 || lbNatRule.BackendPort == 23);
                            }
                        }
                    }

                    Assert.True(nicCount > 0);

                    Assert.Equal(2, virtualMachineScaleSet.VhdContainers.Count());
                    Assert.Equal(virtualMachineScaleSet.Sku, VirtualMachineScaleSetSkuTypes.StandardA0);
                    // Check defaults
                    Assert.True(virtualMachineScaleSet.UpgradeModel == UpgradeMode.Manual);
                    Assert.Equal(2, virtualMachineScaleSet.Capacity);
                    // Fetch the primary Virtual network
                    primaryNetwork = virtualMachineScaleSet.GetPrimaryNetwork();

                    string inboundNatPoolToRemove = null;
                    foreach (string inboundNatPoolName in virtualMachineScaleSet
                                                            .ListPrimaryInternetFacingLoadBalancerInboundNatPools()
                                                            .Keys)
                    {
                        var pool = virtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerInboundNatPools()[inboundNatPoolName];
                        if (pool.FrontendPortRangeStart == 6000)
                        {
                            inboundNatPoolToRemove = inboundNatPoolName;
                            break;
                        }
                    }
                    Assert.True(inboundNatPoolToRemove != null, "Could not find nat pool entry with front endport start at 6000");

                    ILoadBalancer internalLoadBalancer = CreateInternalLoadBalancer(azure, resourceGroup,
                        primaryNetwork,
                        "1",
                        Location);

                    virtualMachineScaleSet
                        .Update()
                        .WithExistingPrimaryInternalLoadBalancer(internalLoadBalancer)
                        .WithoutPrimaryInternetFacingLoadBalancerNatPools(inboundNatPoolToRemove) // Remove one NatPool
                        .Apply();

                    virtualMachineScaleSet = azure
                        .VirtualMachineScaleSets
                        .GetByResourceGroup(rgName, vmss_name);

                    // Check LB after update 
                    //
                    Assert.NotNull(virtualMachineScaleSet.GetPrimaryInternetFacingLoadBalancer());
                    Assert.Equal(2, virtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerBackends().Count());
                    Assert.Single(virtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerInboundNatPools());

                    Assert.NotNull(virtualMachineScaleSet.GetPrimaryInternalLoadBalancer());
                    Assert.Equal(2, virtualMachineScaleSet.ListPrimaryInternalLoadBalancerBackends().Count());
                    Assert.Equal(2, virtualMachineScaleSet.ListPrimaryInternalLoadBalancerInboundNatPools().Count());

                    // Check NIC + IPConfig after update
                    //
                    nics = virtualMachineScaleSet.ListNetworkInterfaces();
                    nicCount = 0;
                    foreach (var nic in nics)
                    {
                        nicCount++;
                        var ipConfigs = nic.IPConfigurations;
                        Assert.Equal(1, ipConfigs.Count);
                        foreach (var ipConfig in ipConfigs.Values)
                        {
                            Assert.NotNull(ipConfig);
                            var lbBackends = ipConfig.ListAssociatedLoadBalancerBackends();
                            Assert.NotNull(lbBackends);
                            // Updated VMSS has a internet facing LB with two backend pools and a internal LB with two
                            // backend pools so there should be 4 backends in ip-config
                            // #1: But this is not always happening, it seems update is really happening only
                            // for subset of vms [TODO: Report this to network team]
                            // Assert.True(lbBackends.Count == 4);

                            foreach (var lbBackend in lbBackends)
                            {
                                var lbRules = lbBackend.LoadBalancingRules;
                                Assert.Equal(1, lbRules.Count);
                                foreach (var rule in lbRules.Values)
                                {
                                    Assert.NotNull(rule);
                                    Assert.True((rule.FrontendPort == 80 && rule.BackendPort == 80) ||
                                                (rule.FrontendPort == 443 && rule.BackendPort == 443) ||
                                                (rule.FrontendPort == 1000 && rule.BackendPort == 1000) ||
                                                (rule.FrontendPort == 1001 && rule.BackendPort == 1001));
                                }
                            }

                            var lbNatRules = ipConfig.ListAssociatedLoadBalancerInboundNatRules();
                            // Updated VMSS has a internet facing LB with one nat pool and a internal LB with two
                            // nat pools so there should be 3 nat rule in ip-config
                            // Same issue as above #1  
                            // But this is not always happening, it seems update is really happening only
                            // for subset of vms [TODO: Report this to network team]
                            // Assert.Equal(lbNatRules.Count(), 3);

                            foreach (var lbNatRule in lbNatRules)
                            {
                                // As mentioned above some chnages are not propgating to all VM instances 6000+ should be there
                                Assert.True((lbNatRule.FrontendPort >= 6000 && lbNatRule.FrontendPort <= 6099) ||
                                            (lbNatRule.FrontendPort >= 5000 && lbNatRule.FrontendPort <= 5099) ||
                                            (lbNatRule.FrontendPort >= 8000 && lbNatRule.FrontendPort <= 8099) ||
                                            (lbNatRule.FrontendPort >= 9000 && lbNatRule.FrontendPort <= 9099));

                                // Same as above
                                Assert.True(lbNatRule.BackendPort == 23 ||
                                            lbNatRule.BackendPort == 22 ||
                                            lbNatRule.BackendPort == 44 ||
                                            lbNatRule.BackendPort == 45);
                            }
                        }
                    }
                    Assert.True(nicCount > 0);
                    CheckVMInstances(virtualMachineScaleSet);
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
        public void CanCreateLowPriorityVMSSInstance()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string vmss_name = TestUtilities.GenerateName("vmss");
                string rgName = TestUtilities.GenerateName("javacsmrg");

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    IResourceGroup resourceGroup = azure.ResourceGroups
                        .Define(rgName)
                        .WithRegion(Location)
                        .Create();

                    INetwork network = azure
                        .Networks
                        .Define("vmssvnet")
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnet1", "10.0.0.0/28")
                        .Create();

                    ILoadBalancer publicLoadBalancer = CreateInternetFacingLoadBalancer(azure, resourceGroup, "1", LoadBalancerSkuType.Basic, Location);
                    List<string> backends = new List<string>();
                    foreach (string backend in publicLoadBalancer.Backends.Keys)
                    {
                        backends.Add(backend);
                    }
                    Assert.True(backends.Count() == 2);

                    IVirtualMachineScaleSet virtualMachineScaleSet = azure.VirtualMachineScaleSets
                        .Define(vmss_name)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithSku(VirtualMachineScaleSetSkuTypes.StandardD3v2)
                        .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                        .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                        .WithPrimaryInternetFacingLoadBalancerBackends(backends[0], backends[1])
                        .WithoutPrimaryInternalLoadBalancer()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("jvuser")
                        .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                        .WithUnmanagedDisks()
                        .WithNewStorageAccount(TestUtilities.GenerateName("stg"))
                        .WithNewStorageAccount(TestUtilities.GenerateName("stg3"))
                        .WithUpgradeMode(UpgradeMode.Manual)
                        .WithLowPriorityVirtualMachine(VirtualMachineEvictionPolicyTypes.Deallocate)
                        .WithMaxPrice(1000.0)
                        .WithSinglePlacementGroup()
                        .Create();

                    Assert.Equal(VirtualMachinePriorityTypes.Low, virtualMachineScaleSet.VirtualMachinePriority);
                    Assert.Equal(VirtualMachineEvictionPolicyTypes.Deallocate, virtualMachineScaleSet.VirtualMachineEvictionPolicy);
                    Assert.Equal(1000.0, virtualMachineScaleSet.BillingProfile.MaxPrice);

                    virtualMachineScaleSet.Update()
                        .WithMaxPrice(2000.0)
                        .Apply();

                    Assert.Equal(2000.0, virtualMachineScaleSet.BillingProfile.MaxPrice);
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
        public void CanEnableMSIWithoutRoleAssignment()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string vmss_name = TestUtilities.GenerateName("vmss");
                string groupName = TestUtilities.GenerateName("javacsmrg");
                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();
                    IResourceGroup resourceGroup = azure.ResourceGroups
                        .Define(groupName)
                        .WithRegion(Location)
                        .Create();

                    INetwork network = azure
                            .Networks
                            .Define("vmssvnet")
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithSubnet("subnet1", "10.0.0.0/28")
                            .Create();

                    ILoadBalancer publicLoadBalancer = CreateInternetFacingLoadBalancer(azure, resourceGroup, "1", LoadBalancerSkuType.Basic, Location);
                    List<string> backends = new List<string>();
                    foreach (string backend in publicLoadBalancer.Backends.Keys)
                    {
                        backends.Add(backend);
                    }
                    Assert.True(backends.Count() == 2);

                    IVirtualMachineScaleSet virtualMachineScaleSet = azure.VirtualMachineScaleSets
                        .Define(vmss_name)
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
                        .WithSystemAssignedManagedServiceIdentity()
                        .Create();

                    var authenticatedClient = TestHelper.CreateAuthenticatedClient();
                    // TODO: Renable the below code snippet: https://github.com/Azure/azure-libraries-for-net/issues/739
                    // 
                    //  Comment out since the below code need external tennat.
                    // 
                    ////
                    //IServicePrincipal servicePrincipal = authenticatedClient
                    //        .ServicePrincipals
                    //        .GetById(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId);

                    //Assert.NotNull(servicePrincipal);
                    //Assert.NotNull(servicePrincipal.Inner);


                    // Ensure no role assigned for resource group
                    //
                    var rgRoleAssignments = authenticatedClient.RoleAssignments.ListByScope(resourceGroup.Id);
                    Assert.NotNull(rgRoleAssignments);
                    bool found = false;
                    foreach (var roleAssignment in rgRoleAssignments)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.False(found, "Resource group should not have a role assignment with virtual machine scale set MSI principal");

                }
                finally
                {
                    try
                    {
                        if (azure != null)
                        {
                            azure.ResourceGroups.BeginDeleteByName(groupName);
                        }
                    }
                    catch { }
                }

            }
        }

        [Fact]
        public void CanEnableMSIWithMultipleRoleAssignment()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string vmss_name = TestUtilities.GenerateName("vmss");
                string groupName = TestUtilities.GenerateName("javacsmrg");
                var storageAccountName = TestUtilities.GenerateName("ja");
                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();
                    IResourceGroup resourceGroup = azure.ResourceGroups
                        .Define(groupName)
                        .WithRegion(Location)
                        .Create();

                    INetwork network = azure
                            .Networks
                            .Define("vmssvnet")
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithSubnet("subnet1", "10.0.0.0/28")
                            .Create();

                    ILoadBalancer publicLoadBalancer = CreateInternetFacingLoadBalancer(azure, resourceGroup, "1", LoadBalancerSkuType.Basic, Location);
                    List<string> backends = new List<string>();
                    foreach (string backend in publicLoadBalancer.Backends.Keys)
                    {
                        backends.Add(backend);
                    }
                    Assert.True(backends.Count() == 2);

                    IStorageAccount storageAccount = azure.StorageAccounts
                        .Define(storageAccountName)
                        .WithRegion(Location)
                        .WithNewResourceGroup(groupName)
                        .Create();

                    IVirtualMachineScaleSet virtualMachineScaleSet = azure.VirtualMachineScaleSets
                        .Define(vmss_name)
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
                        .WithSystemAssignedManagedServiceIdentity()
                        .WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole.Contributor)
                        .WithSystemAssignedIdentityBasedAccessTo(storageAccount.Id, BuiltInRole.Contributor)
                        .Create();

                    Assert.NotNull(virtualMachineScaleSet.ManagedServiceIdentityType);
                    Assert.True(virtualMachineScaleSet.ManagedServiceIdentityType.Equals(ResourceIdentityType.SystemAssigned));

                    var authenticatedClient = TestHelper.CreateAuthenticatedClient();

                    // TODO: Renable the below code snippet: https://github.com/Azure/azure-libraries-for-net/issues/739
                    // 
                    //  Comment out since the below code need external tennat.
                    // 
                    ////
                    //IServicePrincipal servicePrincipal = authenticatedClient
                    //        .ServicePrincipals
                    //        .GetById(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId);

                    //Assert.NotNull(servicePrincipal);
                    //Assert.NotNull(servicePrincipal.Inner);


                    // Ensure role assigned for resource group
                    //
                    var rgRoleAssignments = authenticatedClient.RoleAssignments.ListByScope(resourceGroup.Id);
                    Assert.NotNull(rgRoleAssignments);
                    bool found = false;
                    foreach (var roleAssignment in rgRoleAssignments)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found, "Resource group should have a role assignment with virtual machine scale set MSI principal");

                    // Ensure role assigned for storage account
                    //
                    var stgRoleAssignments = authenticatedClient.RoleAssignments.ListByScope(storageAccount.Id);
                    Assert.NotNull(stgRoleAssignments);
                    found = false;
                    foreach (var roleAssignment in stgRoleAssignments)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found, "Storage account should have a role assignment with virtual machine scale set MSI principal");

                }
                finally
                {
                    try
                    {
                        if (azure != null)
                        {
                            azure.ResourceGroups.BeginDeleteByName(groupName);
                        }
                    }
                    catch { }
                }

            }
        }

        [Fact]
        public void CanCreateTwoRegionalVMSSAndAssociateEachWithDifferentBackendPoolOfZoneResilientLoadBalancer()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string groupName = TestUtilities.GenerateName("javacsmrg");
                var storageAccountName = TestUtilities.GenerateName("ja");
                Region region = Region.USEast2;
                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();
                    IResourceGroup resourceGroup = azure.ResourceGroups
                        .Define(groupName)
                        .WithRegion(region)
                        .Create();

                    INetwork network = azure
                            .Networks
                            .Define("vmssvnet")
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithSubnet("subnet1", "10.0.0.0/28")
                            .Create();

                    // Creates a STANDARD LB with one public frontend ip configuration with two backend pools
                    // Each address pool of STANDARD LB can hold different VMSS resource.
                    //
                    ILoadBalancer publicLoadBalancer = CreateInternetFacingLoadBalancer(azure, resourceGroup, "1", LoadBalancerSkuType.Standard, region);

                    // With default LB SKU BASIC, an attempt to associate two different VMSS to different
                    // backend pool will cause below error (more accurately, while trying to put second VMSS)
                    // {
                    //        "startTime": "2017-09-06T14:27:22.1849435+00:00",
                    //        "endTime": "2017-09-06T14:27:45.8885142+00:00",
                    //        "status": "Failed",
                    //        "error": {
                    //            "code": "VmIsNotInSameAvailabilitySetAsLb",
                    //            "message": "Virtual Machine /subscriptions/<sub-id>/resourceGroups/<rg-name>/providers/Microsoft.Compute/virtualMachines/|providers|Microsoft.Compute|virtualMachineScaleSets|<vm-ss-name>|virtualMachines|<instance-id> is using different Availability Set than other Virtual Machines connected to the Load Balancer(s) <lb-name>."
                    //         },
                    //        "name": "97531d64-db37-4d21-a1cb-9c53aad7c342"
                    // }

                    List<string> backends = new List<string>();
                    foreach (string backend in publicLoadBalancer.Backends.Keys)
                    {
                        backends.Add(backend);
                    }
                    Assert.True(backends.Count() == 2);

                    List<String> natpools = new List<string>();
                    foreach (String natPool in publicLoadBalancer.InboundNatPools.Keys)
                    {
                        natpools.Add(natPool);
                    }
                    Assert.True(natpools.Count() == 2);

                    var vmss_name1 = TestUtilities.GenerateName("vmss1");
                    // HTTP goes to this virtual machine scale set
                    //
                    var virtualMachineScaleSet1 = azure.VirtualMachineScaleSets
                            .Define(vmss_name1)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithSku(VirtualMachineScaleSetSkuTypes.StandardA0)
                            .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                            .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                            .WithPrimaryInternetFacingLoadBalancerBackends(backends.ElementAt(0)) // This VMSS in the first backend pool
                            .WithPrimaryInternetFacingLoadBalancerInboundNatPools(natpools.ElementAt(0))
                            .WithoutPrimaryInternalLoadBalancer()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("jvuser")
                            .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                            .Create();

                    var vmss_name2 = TestUtilities.GenerateName("vmss2");
                    // HTTPS goes to this virtual machine scale set
                    //
                    var virtualMachineScaleSet2 = azure.VirtualMachineScaleSets
                        .Define(vmss_name2)
                        .WithRegion(region)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithSku(VirtualMachineScaleSetSkuTypes.StandardA0)
                        .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                        .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                        .WithPrimaryInternetFacingLoadBalancerBackends(backends.ElementAt(1)) // This VMSS in the second backend pool
                        .WithPrimaryInternetFacingLoadBalancerInboundNatPools(natpools.ElementAt(1))
                        .WithoutPrimaryInternalLoadBalancer()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("jvuser")
                        .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                        .Create();

                    //
                    Assert.Null(virtualMachineScaleSet1.GetPrimaryInternalLoadBalancer());
                    Assert.True(virtualMachineScaleSet1.ListPrimaryInternalLoadBalancerBackends().Count() == 0);
                    Assert.True(virtualMachineScaleSet1.ListPrimaryInternalLoadBalancerInboundNatPools().Count() == 0);

                    Assert.NotNull(virtualMachineScaleSet1.GetPrimaryInternetFacingLoadBalancer());
                    Assert.True(virtualMachineScaleSet1.ListPrimaryInternetFacingLoadBalancerBackends().Count() == 1);


                    Assert.Null(virtualMachineScaleSet2.GetPrimaryInternalLoadBalancer());
                    Assert.True(virtualMachineScaleSet2.ListPrimaryInternalLoadBalancerBackends().Count() == 0);
                    Assert.True(virtualMachineScaleSet2.ListPrimaryInternalLoadBalancerInboundNatPools().Count() == 0);

                    Assert.NotNull(virtualMachineScaleSet2.GetPrimaryInternetFacingLoadBalancer());
                    Assert.True(virtualMachineScaleSet2.ListPrimaryInternetFacingLoadBalancerBackends().Count() == 1);
                }
                finally
                {
                    try
                    {
                        if (azure != null)
                        {
                            azure.ResourceGroups.BeginDeleteByName(groupName);
                        }
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateZoneRedundantVirtualMachineScaleSetWithZoneResilientLoadBalancer()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string groupName = TestUtilities.GenerateName("javacsmrg");
                var storageAccountName = TestUtilities.GenerateName("ja");
                Region region = Region.USEast2;
                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();
                    IResourceGroup resourceGroup = azure.ResourceGroups
                        .Define(groupName)
                        .WithRegion(region)
                        .Create();

                    INetwork network = azure
                            .Networks
                            .Define("vmssvnet")
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithSubnet("subnet1", "10.0.0.0/28")
                            .Create();

                    // Zone redundant VMSS requires STANDARD LB
                    //
                    // Creates a STANDARD LB with one public frontend ip configuration with two backend pools
                    // Each address pool of STANDARD LB can hold different VMSS resource.
                    //
                    ILoadBalancer publicLoadBalancer = CreateInternetFacingLoadBalancer(azure,
                        resourceGroup,
                        "1",
                        LoadBalancerSkuType.Standard, region);

                    List<string> backends = new List<string>();
                    foreach (string backend in publicLoadBalancer.Backends.Keys)
                    {
                        backends.Add(backend);
                    }
                    Assert.True(backends.Count() == 2);

                    List<String> natpools = new List<string>();
                    foreach (String natPool in publicLoadBalancer.InboundNatPools.Keys)
                    {
                        natpools.Add(natPool);
                    }
                    Assert.True(natpools.Count() == 2);

                    var vmss_name = TestUtilities.GenerateName("vmss");
                    // HTTP & HTTPS traffic on port 80, 443 of Internet-facing LB goes to corresponding port in virtual machine scale set
                    //
                    var virtualMachineScaleSet = azure.VirtualMachineScaleSets
                            .Define(vmss_name)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithSku(VirtualMachineScaleSetSkuTypes.StandardD3v2)
                            .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                            .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                            .WithPrimaryInternetFacingLoadBalancerBackends(backends.ElementAt(0), backends.ElementAt(1))
                            .WithoutPrimaryInternalLoadBalancer()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("jvuser")
                            .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_1)  // Zone redundant - zone 1 + zone 2
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_2)
                            .Create();

                    // Check zones
                    //
                    Assert.NotNull(virtualMachineScaleSet.AvailabilityZones);
                    Assert.Equal(2, virtualMachineScaleSet.AvailabilityZones.Count);

                    // Validate Network specific properties (LB, VNet, NIC, IPConfig etc..)
                    //
                    Assert.Null(virtualMachineScaleSet.GetPrimaryInternalLoadBalancer());
                    Assert.True(virtualMachineScaleSet.ListPrimaryInternalLoadBalancerBackends().Count() == 0);
                    Assert.True(virtualMachineScaleSet.ListPrimaryInternalLoadBalancerInboundNatPools().Count() == 0);

                    Assert.NotNull(virtualMachineScaleSet.GetPrimaryInternetFacingLoadBalancer());
                    Assert.True(virtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerBackends().Count() == 2);
                    Assert.True(virtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerInboundNatPools().Count() == 2);

                    var primaryNetwork = virtualMachineScaleSet.GetPrimaryNetwork();
                    Assert.NotNull(primaryNetwork.Id);
                }
                finally
                {
                    try
                    {
                        if (azure != null)
                        {
                            azure.ResourceGroups.BeginDeleteByName(groupName);
                        }
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateVirtualMachineScaleSetWithOptionalNetworkSettings()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string vmss_name = TestUtilities.GenerateName("vmss");
                string groupName = TestUtilities.GenerateName("javacsmrg");
                string asgName = TestUtilities.GenerateName("asg");
                string nsgName = TestUtilities.GenerateName("nsg");
                string vmssVmDnsLabel = TestUtilities.GenerateName("pip");
                Region region = Region.USEast2;
                IAzure azure = null;

                try
                {
                    azure = TestHelper.CreateRollupClient();

                    var resourceGroup = azure.ResourceGroups.Define(groupName)
                        .WithRegion(region)
                        .Create();

                    var network = azure.Networks.Define("vmssvnet")
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithSubnet("subnet1", "10.0.0.0/28")
                            .Create();

                    var asg = azure.ApplicationSecurityGroups
                            .Define(asgName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .Create();

                    // Create VMSS with instance public ip
                    var virtualMachineScaleSet = azure.VirtualMachineScaleSets.Define(vmss_name)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithSku(VirtualMachineScaleSetSkuTypes.StandardDS3v2)
                            .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                            .WithoutPrimaryInternetFacingLoadBalancer()
                            .WithoutPrimaryInternalLoadBalancer()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("jvuser")
                            .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                            .WithVirtualMachinePublicIp(vmssVmDnsLabel)
                            .WithExistingApplicationSecurityGroup(asg)
                            .Create();

                    var currentIpConfig = virtualMachineScaleSet.VirtualMachinePublicIpConfig;

                    Assert.NotNull(currentIpConfig);
                    Assert.NotNull(currentIpConfig.DnsSettings);
                    Assert.NotNull(currentIpConfig.DnsSettings.DomainNameLabel);

                    currentIpConfig.IdleTimeoutInMinutes = 20;

                    virtualMachineScaleSet.Update()
                            .WithVirtualMachinePublicIp(currentIpConfig)
                            .Apply();

                    currentIpConfig = virtualMachineScaleSet.VirtualMachinePublicIpConfig;
                    Assert.NotNull(currentIpConfig);
                    Assert.NotNull(currentIpConfig.IdleTimeoutInMinutes);
                    Assert.Equal((long)20, (long)currentIpConfig.IdleTimeoutInMinutes);

                    virtualMachineScaleSet.Refresh();
                    currentIpConfig = virtualMachineScaleSet.VirtualMachinePublicIpConfig;
                    Assert.NotNull(currentIpConfig);
                    Assert.NotNull(currentIpConfig.IdleTimeoutInMinutes);
                    Assert.Equal((long)20, (long)currentIpConfig.IdleTimeoutInMinutes);

                    var asgIds = virtualMachineScaleSet.ApplicationSecurityGroupIds;
                    Assert.NotNull(asgIds);
                    Assert.Equal(1, asgIds.Count);

                    var nsg = azure.NetworkSecurityGroups.Define(nsgName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .DefineRule("rule1")
                                .AllowOutbound()
                                .FromAnyAddress()
                                .FromPort(80)
                                .ToAnyAddress()
                                .ToPort(80)
                                .WithProtocol(SecurityRuleProtocol.Tcp)
                                .Attach()
                            .Create();

                    virtualMachineScaleSet.Deallocate();
                    virtualMachineScaleSet.Update()
                            .WithIpForwarding()
                            .WithAcceleratedNetworking()
                            .WithExistingNetworkSecurityGroup(nsg)
                            .Apply();

                    Assert.True(virtualMachineScaleSet.IsIpForwardingEnabled);
                    Assert.True(virtualMachineScaleSet.IsAcceleratedNetworkingEnabled);
                    Assert.NotNull(virtualMachineScaleSet.NetworkSecurityGroupId);
                    //
                    virtualMachineScaleSet.Refresh();
                    //
                    Assert.True(virtualMachineScaleSet.IsIpForwardingEnabled);
                    Assert.True(virtualMachineScaleSet.IsAcceleratedNetworkingEnabled);
                    Assert.NotNull(virtualMachineScaleSet.NetworkSecurityGroupId);

                    virtualMachineScaleSet.Update()
                            .WithoutIpForwarding()
                            .WithoutAcceleratedNetworking()
                            .WithoutNetworkSecurityGroup()
                            .Apply();

                    Assert.False(virtualMachineScaleSet.IsIpForwardingEnabled);
                    Assert.False(virtualMachineScaleSet.IsAcceleratedNetworkingEnabled);
                    Assert.Null(virtualMachineScaleSet.NetworkSecurityGroupId);
                }
                finally
                {
                    try
                    {
                        if (azure != null)
                        {
                            azure.ResourceGroups.BeginDeleteByName(groupName);
                        }
                    }
                    catch { }
                }

            }
        }

        [Fact]
        public void CanGetSingleVMSSInstance()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string vmss_name = TestUtilities.GenerateName("vmss");
                string rgName = TestUtilities.GenerateName("javacsmrg");

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    IResourceGroup resourceGroup = azure.ResourceGroups
                        .Define(rgName)
                        .WithRegion(Location)
                        .Create();

                    INetwork network = azure
                        .Networks
                        .Define("vmssvnet")
                        .WithRegion(Location)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnet1", "10.0.0.0/28")
                        .Create();

                    ILoadBalancer publicLoadBalancer = CreateInternetFacingLoadBalancer(azure, resourceGroup, "1", LoadBalancerSkuType.Basic, Location);
                    List<string> backends = new List<string>();
                    foreach (string backend in publicLoadBalancer.Backends.Keys)
                    {
                        backends.Add(backend);
                    }

                    IVirtualMachineScaleSet virtualMachineScaleSet = azure.VirtualMachineScaleSets
                        .Define(vmss_name)
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
                        .WithNewStorageAccount(TestUtilities.GenerateName("stg"))
                        .WithNewStorageAccount(TestUtilities.GenerateName("stg3"))
                        .WithUpgradeMode(UpgradeMode.Manual)
                        .Create();

                    virtualMachineScaleSet = azure
                        .VirtualMachineScaleSets
                        .GetByResourceGroup(rgName, vmss_name);

                    var virtualMachineScaleSetVMs = virtualMachineScaleSet.VirtualMachines;
                    var firstVm = virtualMachineScaleSetVMs.List().First();
                    var fetchedVm = virtualMachineScaleSetVMs.GetInstance(firstVm.InstanceId);
                    this.CheckVMsEqual(firstVm, fetchedVm);
                    var fetchedAsyncVm = virtualMachineScaleSetVMs.GetInstanceAsync(firstVm.InstanceId).ConfigureAwait(false).GetAwaiter().GetResult();
                    this.CheckVMsEqual(firstVm, fetchedAsyncVm);
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

        private void CheckVMsEqual(IVirtualMachineScaleSetVM original, IVirtualMachineScaleSetVM fetched)
        {
            Assert.Equal(original.AdministratorUserName, fetched.AdministratorUserName);
            Assert.Equal(original.AvailabilitySetId, fetched.AvailabilitySetId);
            Assert.Equal(original.BootDiagnosticEnabled, fetched.BootDiagnosticEnabled);
            Assert.Equal(original.BootDiagnosticStorageAccountUri, fetched.BootDiagnosticStorageAccountUri);
            Assert.Equal(original.ComputerName, fetched.ComputerName);
            Assert.Equal(original.DataDisks.Count, fetched.DataDisks.Count);
            Assert.Equal(original.Extensions.Count, fetched.Extensions.Count);
            Assert.Equal(original.InstanceId, fetched.InstanceId);
            Assert.Equal(original.IsLatestScaleSetUpdateApplied, fetched.IsLatestScaleSetUpdateApplied);
            Assert.Equal(original.IsLinuxPasswordAuthenticationEnabled, fetched.IsLinuxPasswordAuthenticationEnabled);
            Assert.Equal(original.IsManagedDiskEnabled, fetched.IsManagedDiskEnabled);
            Assert.Equal(original.IsOSBasedOnCustomImage, fetched.IsOSBasedOnCustomImage);
            Assert.Equal(original.IsOSBasedOnPlatformImage, fetched.IsOSBasedOnPlatformImage);
            Assert.Equal(original.IsOSBasedOnStoredImage, fetched.IsOSBasedOnStoredImage);
            Assert.Equal(original.IsWindowsAutoUpdateEnabled, fetched.IsWindowsAutoUpdateEnabled);
            Assert.Equal(original.IsWindowsVMAgentProvisioned, original.IsWindowsVMAgentProvisioned);
            Assert.Equal(original.NetworkInterfaceIds.Count, fetched.NetworkInterfaceIds.Count);
            Assert.Equal(original.OSDiskCachingType, fetched.OSDiskCachingType);
            Assert.Equal(original.OSDiskId, fetched.OSDiskId);
            Assert.Equal(original.OSDiskName, fetched.OSDiskName);
            Assert.Equal(original.OSDiskSizeInGB, fetched.OSDiskSizeInGB);
            Assert.Equal(original.OSType, fetched.OSType);
            Assert.Equal(original.OSUnmanagedDiskVhdUri, fetched.OSUnmanagedDiskVhdUri);
            Assert.Equal(original.PowerState, fetched.PowerState);
            Assert.Equal(original.PrimaryNetworkInterfaceId, fetched.PrimaryNetworkInterfaceId);
            Assert.Equal(original.Size, fetched.Size);
            Assert.Equal(original.Sku.Name, fetched.Sku.Name);
            Assert.Equal(original.StoredImageUnmanagedVhdUri, fetched.StoredImageUnmanagedVhdUri);
            Assert.Equal(original.UnmanagedDataDisks.Count, fetched.UnmanagedDataDisks.Count);
            Assert.Equal(original.WindowsTimeZone, fetched.WindowsTimeZone);
        }

        private void CheckVMInstances(IVirtualMachineScaleSet vmScaleSet)
        {
            var virtualMachineScaleSetVMs = vmScaleSet.VirtualMachines;
            var virtualMachines = virtualMachineScaleSetVMs.List();
            Assert.Equal(virtualMachines.Count(), vmScaleSet.Capacity);
            Assert.True(virtualMachines.Count() > 0);
            virtualMachineScaleSetVMs.UpdateInstances(virtualMachines.First().InstanceId);

            foreach (var vm in virtualMachines)
            {
                Assert.NotNull(vm.Size);
                Assert.Equal(OperatingSystemTypes.Linux, vm.OSType);
                Assert.StartsWith(vmScaleSet.ComputerNamePrefix, vm.ComputerName);
                Assert.True(vm.IsLinuxPasswordAuthenticationEnabled);
                Assert.True(vm.IsOSBasedOnPlatformImage);
                Assert.Null(vm.StoredImageUnmanagedVhdUri);
                Assert.False(vm.IsWindowsAutoUpdateEnabled);
                Assert.False(vm.IsWindowsVMAgentProvisioned);
                Assert.Equal("jvuser", vm.AdministratorUserName, ignoreCase: true);
                var vmImage = vm.GetOSPlatformImage();
                Assert.NotNull(vmImage);
                Assert.Equal(vm.Extensions.Count(), vmScaleSet.Extensions.Count);
                Assert.NotNull(vm.PowerState);
                vm.RefreshInstanceView();
            }
            // Check actions
            var virtualMachineScaleSetVM = virtualMachines.FirstOrDefault();
            Assert.NotNull(virtualMachineScaleSetVM);
            virtualMachineScaleSetVM.Restart();
            virtualMachineScaleSetVM.PowerOff();
            virtualMachineScaleSetVM.RefreshInstanceView();
            Assert.Equal(virtualMachineScaleSetVM.PowerState, PowerState.Stopped);
            virtualMachineScaleSetVM.Start();

            // Check Instance NICs
            //
            foreach (var vm in virtualMachines)
            {
                var nics = vmScaleSet.ListNetworkInterfacesByInstanceId(vm.InstanceId);
                Assert.NotNull(nics);
                Assert.Single(nics);
                var nic = nics.First();
                Assert.NotNull(nic.VirtualMachineId);
                Assert.True(string.Compare(nic.VirtualMachineId, vm.Id, true) == 0);
                Assert.NotNull(vm.ListNetworkInterfaces());
            }
        }
        public static ILoadBalancer CreateInternetFacingLoadBalancer(IAzure azure,
            IResourceGroup resourceGroup,
            string id,
            LoadBalancerSkuType lbSkuType,
            Region location,
            [CallerMemberName] string methodName = "testframework_failed")
        {
            string loadBalancerName = TestUtilities.GenerateName("extlb" + id + "-", methodName);
            string publicIPName = "pip-" + loadBalancerName;
            string frontendName = loadBalancerName + "-FE1";
            string backendPoolName1 = loadBalancerName + "-BAP1";
            string backendPoolName2 = loadBalancerName + "-BAP2";
            string natPoolName1 = loadBalancerName + "-INP1";
            string natPoolName2 = loadBalancerName + "-INP2";

            // Sku of PublicIP and LoadBalancer must match
            //
            PublicIPSkuType publicIPSkuType = lbSkuType.Equals(LoadBalancerSkuType.Basic) ? PublicIPSkuType.Basic : PublicIPSkuType.Standard;

            IPublicIPAddress publicIPAddress = azure.PublicIPAddresses
                .Define(publicIPName)
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                .WithLeafDomainLabel(publicIPName)
                // Optionals
                .WithStaticIP()
                .WithSku(publicIPSkuType)
                // Create
                .Create();

            ILoadBalancer loadBalancer = azure.LoadBalancers.Define(loadBalancerName)
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                // Add two rules that uses above backend and probe
                .DefineLoadBalancingRule("httpRule")
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(frontendName)
                    .FromFrontendPort(80)
                    .ToBackend(backendPoolName1)
                    .WithProbe("httpProbe")
                    .Attach()
                .DefineLoadBalancingRule("httpsRule")
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(frontendName)
                    .FromFrontendPort(443)
                    .ToBackend(backendPoolName2)
                    .WithProbe("httpsProbe")
                    .Attach()
                // Add two nat pools to enable direct VM connectivity to port SSH and 23
                .DefineInboundNatPool(natPoolName1)
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(frontendName)
                    .FromFrontendPortRange(5000, 5099)
                    .ToBackendPort(22)
                    .Attach()
                .DefineInboundNatPool(natPoolName2)
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(frontendName)
                    .FromFrontendPortRange(6000, 6099)
                    .ToBackendPort(23)
                    .Attach()
                // Explicitly define the frontend
                .DefinePublicFrontend(frontendName)
                    .WithExistingPublicIPAddress(publicIPAddress)
                    .Attach()
                // Add two probes one per rule
                .DefineHttpProbe("httpProbe")
                    .WithRequestPath("/")
                    .Attach()
                .DefineHttpProbe("httpsProbe")
                    .WithRequestPath("/")
                    .Attach()
                 .WithSku(lbSkuType)
                .Create();

            loadBalancer = azure.LoadBalancers.GetByResourceGroup(resourceGroup.Name, loadBalancerName);

            Assert.True(loadBalancer.PublicIPAddressIds.Count() == 1);
            Assert.Equal(2, loadBalancer.HttpProbes.Count());
            ILoadBalancerHttpProbe httpProbe = null;
            Assert.True(loadBalancer.HttpProbes.TryGetValue("httpProbe", out httpProbe));
            Assert.Single(httpProbe.LoadBalancingRules);
            ILoadBalancerHttpProbe httpsProbe = null;
            Assert.True(loadBalancer.HttpProbes.TryGetValue("httpsProbe", out httpsProbe));
            Assert.Single(httpProbe.LoadBalancingRules);
            Assert.Equal(2, loadBalancer.InboundNatPools.Count());
            return loadBalancer;
        }

        public static ILoadBalancer CreateInternalLoadBalancer(
            IAzure azure,
            IResourceGroup resourceGroup,
            INetwork network,
            string id,
            Region location,
            [CallerMemberName] string methodName = "testframework_failed")
        {
            string loadBalancerName = TestUtilities.GenerateName("InternalLb" + id + "-", methodName);
            string privateFrontEndName = loadBalancerName + "-FE1";
            string backendPoolName1 = loadBalancerName + "-BAP1";
            string backendPoolName2 = loadBalancerName + "-BAP2";
            string natPoolName1 = loadBalancerName + "-INP1";
            string natPoolName2 = loadBalancerName + "-INP2";
            string subnetName = "subnet1";

            ILoadBalancer loadBalancer = azure.LoadBalancers.Define(loadBalancerName)
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                // Add two rules that uses above backend and probe
                .DefineLoadBalancingRule("httpRule")
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(privateFrontEndName)
                    .FromFrontendPort(1000)
                    .ToBackend(backendPoolName1)
                    .WithProbe("httpProbe")
                    .Attach()
                .DefineLoadBalancingRule("httpsRule")
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(privateFrontEndName)
                    .FromFrontendPort(1001)
                    .ToBackend(backendPoolName2)
                    .WithProbe("httpsProbe")
                    .Attach()
                // Add two nat pools to enable direct VM connectivity to port 44 and 45
                .DefineInboundNatPool(natPoolName1)
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(privateFrontEndName)
                    .FromFrontendPortRange(8000, 8099)
                    .ToBackendPort(44)
                    .Attach()
                .DefineInboundNatPool(natPoolName2)
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(privateFrontEndName)
                    .FromFrontendPortRange(9000, 9099)
                    .ToBackendPort(45)
                    .Attach()

                // Explicitly define the frontend
                .DefinePrivateFrontend(privateFrontEndName)
                    .WithExistingSubnet(network, subnetName)
                    .Attach()

                // Add two probes one per rule
                .DefineHttpProbe("httpProbe")
                    .WithRequestPath("/")
                    .Attach()
                .DefineHttpProbe("httpsProbe")
                    .WithRequestPath("/")
                    .Attach()
                .Create();

            loadBalancer = azure.LoadBalancers.GetByResourceGroup(resourceGroup.Name, loadBalancerName);

            Assert.Empty(loadBalancer.PublicIPAddressIds);
            Assert.Equal(2, loadBalancer.Backends.Count());
            ILoadBalancerBackend backend1 = null;
            Assert.True(loadBalancer.Backends.TryGetValue(backendPoolName1, out backend1));
            ILoadBalancerBackend backend2 = null;
            Assert.True(loadBalancer.Backends.TryGetValue(backendPoolName2, out backend2));
            ILoadBalancerHttpProbe httpProbe = null;
            Assert.True(loadBalancer.HttpProbes.TryGetValue("httpProbe", out httpProbe));
            Assert.Single(httpProbe.LoadBalancingRules);
            ILoadBalancerHttpProbe httpsProbe = null;
            Assert.True(loadBalancer.HttpProbes.TryGetValue("httpsProbe", out httpsProbe));
            Assert.Single(httpProbe.LoadBalancingRules);
            Assert.Equal(2, loadBalancer.InboundNatPools.Count());
            return loadBalancer;
        }

        public static ILoadBalancer CreateHttpLoadBalancers(
            IAzure azure,
            IResourceGroup resourceGroup,
            string id,
            Region location,
            [CallerMemberName] string methodName = "testframework_failed")
        {
            string loadBalancerName = TestUtilities.GenerateName("extlb" + id + "-", methodName);
            string publicIPName = "pip-" + loadBalancerName;
            string frontendName = loadBalancerName + "-FE1";
            string backendPoolName = loadBalancerName + "-BAP1";
            string natPoolName = loadBalancerName + "-INP1";

            var publicIPAddress = azure.PublicIPAddresses
                .Define(publicIPName)
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                .WithLeafDomainLabel(publicIPName)
                .Create();

            var loadBalancer = azure.LoadBalancers.Define(loadBalancerName)
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                // Add two rules that uses above backend and probe
                .DefineLoadBalancingRule("httpRule")
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(frontendName)
                    .FromFrontendPort(80)
                    .ToBackend(backendPoolName)
                    .WithProbe("httpProbe")
                    .Attach()
                .DefineInboundNatPool(natPoolName)
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(frontendName)
                    .FromFrontendPortRange(5000, 5099)
                    .ToBackendPort(22)
                    .Attach()
                .DefinePublicFrontend(frontendName)
                    .WithExistingPublicIPAddress(publicIPAddress)
                    .Attach()
                .DefineHttpProbe("httpProbe")
                    .WithRequestPath("/")
                    .Attach()
                .Create();

            loadBalancer = azure.LoadBalancers.GetByResourceGroup(resourceGroup.Name, loadBalancerName);

            Assert.True(loadBalancer.PublicIPAddressIds.Count() == 1);
            var httpProbe = loadBalancer.HttpProbes.Values.FirstOrDefault();
            Assert.NotNull(httpProbe);
            var rule = httpProbe.LoadBalancingRules.Values.FirstOrDefault();
            Assert.NotNull(rule);
            var natPool = loadBalancer.InboundNatPools.Values.FirstOrDefault();
            Assert.NotNull(natPool);
            return loadBalancer;
        }

        private string prepareCustomScriptStorageUri(string storageAccountName, string storageAccountKey, string containerName)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                return "http://nonexisting.blob.core.windows.net/scripts2/install_apache.sh";
            }
            var storageConnectionString = $"DefaultEndpointsProtocol=http;AccountName={storageAccountName};AccountKey={storageAccountKey}";
            CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient cloudBlobClient = account.CreateCloudBlobClient();
            CloudBlobContainer container = cloudBlobClient.GetContainerReference(containerName);
            bool createdNew = container.CreateIfNotExistsAsync().Result;
            CloudBlockBlob blob = container.GetBlockBlobReference("install_apache.sh");
            using (HttpClient client = new HttpClient())
            {
                blob.UploadFromStreamAsync(client.GetStreamAsync("https://raw.githubusercontent.com/Azure/azure-libraries-for-net/master/Samples/Asset/install_apache.sh").Result).Wait();
            }
            return blob.Uri.ToString();
        }
    }
}