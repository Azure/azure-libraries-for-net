// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Fluent.Tests.Network
{
    public class AppGateway
    {
        public AppGateway(ITestOutputHelper output)
        {
            TestHelper.TestLogger = output;
        }

        [Fact]
        public void BackendHealthCheck()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var testId = TestUtilities.GenerateName("");
                Region region = Region.USSouthCentral;
                string name = "ag" + testId;
                var networkManager = TestHelper.CreateNetworkManager();
                var computeManager = TestHelper.CreateComputeManager();

                string password = SdkContext.RandomResourceName("Abc.123", 12);
                string vnetName = "net" + testId;
                string rgName = "rg" + testId;

                try
                {
                    // Create a vnet
                    INetwork network = networkManager.Networks.Define(vnetName)
                                .WithRegion(region)
                                .WithNewResourceGroup(rgName)
                                .WithAddressSpace("10.0.0.0/28")
                                .WithSubnet("subnet1", "10.0.0.0/29")
                                .WithSubnet("subnet2", "10.0.0.8/29")
                                .Create();

                    // Create VMs for the backend in the network to connect to
                    List<ICreatable<IVirtualMachine>> vmsDefinitions = new List<ICreatable<IVirtualMachine>>();
                    for (int i = 0; i < 2; i++)
                    {
                        vmsDefinitions.Add(computeManager.VirtualMachines.Define("vm" + i + testId)
                                .WithRegion(region)
                                .WithExistingResourceGroup(rgName)
                                .WithExistingPrimaryNetwork(network)
                                .WithSubnet("subnet2")
                                .WithPrimaryPrivateIPAddressDynamic()
                                .WithoutPrimaryPublicIPAddress()
                                .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                                .WithRootUsername("tester")
                                .WithRootPassword(password));
                    }

                    var createdVms = computeManager.VirtualMachines.Create(vmsDefinitions);
                    IVirtualMachine[] vms = new IVirtualMachine[createdVms.Count()];
                    for (int i = 0; i < vmsDefinitions.Count; i++)
                    {
                        vms[i] = createdVms.FirstOrDefault(o => o.Key == vmsDefinitions[i].Key);
                    }

                    string[] ipAddresses = new string[vms.Count()];
                    for (int i = 0; i < vms.Count(); i++)
                    {
                        ipAddresses[i] = vms[i].GetPrimaryNetworkInterface().PrimaryPrivateIP;
                    }

                    // Create the app gateway in the other subnet of the same vnet and point the backend at the VMs
                    IApplicationGateway appGateway = networkManager.ApplicationGateways.Define(name)
                            .WithRegion(region)
                            .WithExistingResourceGroup(rgName)
                            .DefineRequestRoutingRule("rule1")
                                .FromPrivateFrontend()
                                .FromFrontendHttpPort(80)
                                .ToBackendHttpPort(8080)
                                .ToBackendIPAddresses(ipAddresses) // Connect the VMs via IP addresses
                                .Attach()
                            .DefineRequestRoutingRule("rule2")
                                .FromPrivateFrontend()
                                .FromFrontendHttpPort(25)
                                .ToBackendHttpPort(22)
                                .ToBackend("nicBackend")
                                .Attach()
                            .WithExistingSubnet(network.Subnets["subnet1"]) // Backend for connecting the VMs via NICs
                            .Create();

                    // Connect the 1st VM via NIC IP config
                    var nic = vms[0].GetPrimaryNetworkInterface();
                    Assert.NotNull(nic);
                    var appGatewayBackend = appGateway.Backends["nicBackend"];
                    Assert.NotNull(appGatewayBackend);
                    nic.Update().UpdateIPConfiguration(nic.PrimaryIPConfiguration.Name)
                        .WithExistingApplicationGatewayBackend(appGateway, appGatewayBackend.Name)
                        .Parent()
                    .Apply();

                    // Get the health of the VMs
                    appGateway.Refresh();
                    var backendHealths = appGateway.CheckBackendHealth();

                    StringBuilder info = new StringBuilder();
                    info.Append("\nApplication gateway backend healths: ").Append(backendHealths.Count);
                    foreach (var backendHealth in backendHealths.Values)
                    {
                        info.Append("\n\tApplication gateway backend name: ").Append(backendHealth.Name)
                            .Append("\n\t\tHTTP configuration healths: ").Append(backendHealth.HttpConfigurationHealths.Count);
                        Assert.NotNull(backendHealth.Backend);
                        foreach (var backendConfigHealth in backendHealth.HttpConfigurationHealths.Values)
                        {
                            info.Append("\n\t\t\tHTTP configuration name: ").Append(backendConfigHealth.Name)
                                .Append("\n\t\t\tServers: ").Append(backendConfigHealth.Inner.Servers.Count);
                            Assert.NotNull(backendConfigHealth.BackendHttpConfiguration);
                            foreach (var sh in backendConfigHealth.ServerHealths.Values)
                            {
                                var ipConfig = sh.GetNetworkInterfaceIPConfiguration();
                                if (ipConfig != null)
                                {
                                    info.Append("\n\t\t\t\tServer NIC ID: ").Append(ipConfig.Parent.Id)
                                        .Append("\n\t\t\t\tIP Config name: ").Append(ipConfig.Name);
                                }
                                else
                                {
                                    info.Append("\n\t\t\t\tServer IP: " + sh.IPAddress);
                                }
                                info.Append("\n\t\t\t\tHealth status: ").Append(sh.Status.ToString());
                            }
                        }
                    }

                    TestHelper.WriteLine(info.ToString());

                    // Verify app gateway
                    Assert.Equal(2, appGateway.Backends.Count);
                    var rule1 = appGateway.RequestRoutingRules["rule1"];
                    var backend1 = rule1.Backend;
                    Assert.NotNull(backend1);
                    var rule2 = appGateway.RequestRoutingRules["rule2"];
                    var backend2 = rule2.Backend;
                    Assert.NotNull(backend2);

                    Assert.Equal(2, backendHealths.Count);

                    // Verify first backend (IP address-based)
                    var backendHealth1 = backendHealths[backend1.Name];
                    Assert.NotNull(backendHealth1.Backend);
                    for (int i = 0; i < ipAddresses.Length; i++)
                    {
                        Assert.True(backend1.ContainsIPAddress(ipAddresses[i]));
                    }

                    // Verify second backend (NIC based)
                    var backendHealth2 = backendHealths[backend2.Name];
                    Assert.NotNull(backendHealth2);
                    Assert.NotNull(backendHealth2.Backend);
                    Assert.Equal(backend2.Name, backendHealth2.Name, true);
                    Assert.Single(backendHealth2.HttpConfigurationHealths);
                    var httpConfigHealth2 = backendHealth2.HttpConfigurationHealths.Values.FirstOrDefault();
                    Assert.NotNull(httpConfigHealth2);
                    Assert.NotNull(httpConfigHealth2.BackendHttpConfiguration);
                    Assert.Single(httpConfigHealth2.ServerHealths);
                    var serverHealth = httpConfigHealth2.ServerHealths.Values.FirstOrDefault();
                    Assert.NotNull(serverHealth);
                    var ipConfig2 = serverHealth.GetNetworkInterfaceIPConfiguration();
                    Assert.Equal(nic.PrimaryIPConfiguration.Name, ipConfig2.Name, true);

                    // Cleanup
                    networkManager.ResourceManager.ResourceGroups.BeginDeleteByName(rgName);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void StartStop()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                string rgName = SdkContext.RandomResourceName("rg", 13);
                Region region = Region.USEast;
                string name = SdkContext.RandomResourceName("ag", 15);
                try
                {
                    IApplicationGateway appGateway = azure.ApplicationGateways.Define(name)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)

                    // Request routing rules
                    .DefineRequestRoutingRule("rule1")
                        .FromPrivateFrontend()
                        .FromFrontendHttpPort(80)
                        .ToBackendHttpPort(8080)
                        .ToBackendIPAddress("11.1.1.1")
                        .ToBackendIPAddress("11.1.1.2")
                        .Attach()
                    .Create();

                    // Test stop/start
                    appGateway.Stop();
                    Assert.Equal(ApplicationGatewayOperationalState.Stopped, appGateway.OperationalState);
                    appGateway.Start();
                    Assert.Equal(ApplicationGatewayOperationalState.Running, appGateway.OperationalState);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact(Skip = "Fails during playback only on Linux. Needs further investigation.")]
        public void InParallel()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                string rgName = SdkContext.RandomResourceName("rg", 13);
                Region region = Region.USEast;
                ICreatable<IResourceGroup> resourceGroup = azure.ResourceGroups.Define(rgName).WithRegion(region);
                List<ICreatable<IApplicationGateway>> agCreatables = new List<ICreatable<IApplicationGateway>>();

                try
                {
                    agCreatables.Add(azure.ApplicationGateways.Define(SdkContext.RandomResourceName("ag", 13))
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(resourceGroup)
                        .DefineRequestRoutingRule("rule1")
                            .FromPrivateFrontend()
                            .FromFrontendHttpPort(80)
                            .ToBackendHttpPort(8080)
                            .ToBackendIPAddress("10.0.0.1")
                            .ToBackendIPAddress("10.0.0.2")
                            .Attach());

                    agCreatables.Add(azure.ApplicationGateways.Define(SdkContext.RandomResourceName("ag", 13))
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(resourceGroup)
                        .DefineRequestRoutingRule("rule1")
                            .FromPrivateFrontend()
                            .FromFrontendHttpPort(80)
                            .ToBackendHttpPort(8080)
                            .ToBackendIPAddress("10.0.0.3")
                            .ToBackendIPAddress("10.0.0.4")
                            .Attach());

                    var created = azure.ApplicationGateways.Create(agCreatables);
                    var ags = new List<IApplicationGateway>();
                    var agIds = new List<string>();
                    foreach (var creatable in agCreatables)
                    {
                        var ag = (IApplicationGateway)created.CreatedRelatedResource(creatable.Key);
                        Assert.NotNull(ag);
                        ags.Add(ag);
                        agIds.Add(ag.Id);
                    }

                    azure.ApplicationGateways.Stop(agIds);

                    foreach (var ag in ags)
                    {
                        Assert.Equal(ApplicationGatewayOperationalState.Stopped, ag.Refresh().OperationalState);
                    }

                    azure.ApplicationGateways.Start(agIds);

                    foreach (var ag in ags)
                    {
                        Assert.Equal(ApplicationGatewayOperationalState.Running, ag.Refresh().OperationalState);
                    }

                    azure.ApplicationGateways.DeleteByIds(agIds);
                    foreach (var id in agIds)
                    {
                        Assert.Null(azure.ApplicationGateways.GetById(id));
                    }

                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact (Skip = "Need client id for key vault usage")]
        public void SslWithKeyVault()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                string rgName = SdkContext.RandomResourceName("rg", 13);
                Region region = Region.USEast;

                string appGatewayName = SdkContext.RandomResourceName("agwaf", 15);
                string appPublicIpName = SdkContext.RandomResourceName("pip", 15);
                string identityName = SdkContext.RandomResourceName("id", 10);

                try
                {
                    AzureCredentials credentials = SdkContext.AzureCredentialsFactory
                            .FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                    var identity = azure.Identities
                        .Define(identityName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .Create();

                    var secret1 = GenerateKeyVaultSecret(azure, region, rgName, credentials.ClientId, identity.PrincipalId);
                    var secret2 = GenerateKeyVaultSecret(azure, region, rgName, credentials.ClientId, identity.PrincipalId);

                    var userAssignedIdentities = new Dictionary<string, ManagedServiceIdentityUserAssignedIdentitiesValue>()
                    {
                        {identity.Id, new ManagedServiceIdentityUserAssignedIdentitiesValue(identity.PrincipalId, identity.ClientId)}
                    };

                    var serviceIdentity = new ManagedServiceIdentity(credentials.ClientId, credentials.TenantId, ResourceIdentityType.UserAssigned, userAssignedIdentities);

                    var pip = azure.PublicIPAddresses
                        .Define(appPublicIpName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithSku(PublicIPSkuType.Standard)
                        .WithStaticIP()
                        .Create();

                    // Create
                    var appGateway = azure.ApplicationGateways
                        .Define(appGatewayName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .DefineRequestRoutingRule("rule1")
                            .FromPublicFrontend()
                            .FromFrontendHttpsPort(443)
                            .WithSslCertificate("ssl1")
                            .ToBackendHttpPort(8080)
                            .ToBackendIPAddress("11.1.1.1")
                            .Attach()
                        .WithIdentity(serviceIdentity)
                        .DefineSslCertificate("ssl1")
                            .WithKeyVaultSecretId(secret1.Id)
                            .Attach()
                        .WithExistingPublicIPAddress(pip)
                        .WithTier(ApplicationGatewayTier.WAFV2)
                        .WithSize(ApplicationGatewaySkuName.WAFV2)
                        .WithAutoscale(2, 5)
                        .Create();

                    Assert.Equal(secret1.Id, appGateway.RequestRoutingRules["rule1"].SslCertificate.KeyVaultSecretId);

                    // Update
                    appGateway = appGateway.Update()
                        .UpdateRequestRoutingRule("rule1")
                            .WithSslCertificateFromKeyVaultSecretId(secret2.Id)
                            .Parent()
                        .Apply();

                    Assert.Equal(secret2.Id, appGateway.RequestRoutingRules["rule1"].SslCertificate.KeyVaultSecretId);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        private ISecret GenerateKeyVaultSecret(IAzure azure, Region region, string rgName, string servicePrincipal, string identityPrincipal)
        {
            string vaultName = SdkContext.RandomResourceName("vlt", 10);
            string secretName = SdkContext.RandomResourceName("srt", 10);
            string secretValue = File.ReadAllText(Path.Combine("Assets", "test.certificate"));

            var vault = azure.Vaults
                          .Define(vaultName)
                          .WithRegion(region)
                          .WithNewResourceGroup(rgName)
                          .DefineAccessPolicy()
                              .ForServicePrincipal(servicePrincipal)
                              .AllowSecretAllPermissions()
                              .Attach()
                          .DefineAccessPolicy()
                              .ForObjectId(identityPrincipal)
                              .AllowSecretAllPermissions()
                              .Attach()
                          .WithDeploymentEnabled()
                          .Create();

            // TODO: change inner to "with" method when ready
            vault.Inner.Properties.EnableSoftDelete = true;
            if (vault.Inner.Properties.NetworkAcls == null)
            {
                vault.Inner.Properties.NetworkAcls = new NetworkRuleSet();
            }
            vault.Inner.Properties.NetworkAcls.Bypass = NetworkRuleBypassOptions.AzureServices;
            vault = vault.Update().Apply();

            var secret = vault.Secrets
                .Define(secretName)
                .WithValue(secretValue)
                .Create();

            return secret;
        }

        [Fact]
        public void PrivateMinimal()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new ApplicationGateway.PrivateMinimal().RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }

        [Fact(Skip ="Fails during playback only on Linux. Needs further investigation.")]
        public void PublicMinimal()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new ApplicationGateway.PublicMinimal().RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }

        [Fact]
        public void PrivateComplex()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                new ApplicationGateway.PrivateComplex().RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }

        [Fact]
        public void PublicComplex()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new ApplicationGateway.PublicComplex().RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }


        [Fact]
        public void WebApplicationFirewall()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new ApplicationGateway.WebApplicationFirewall().RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }
    }

    public partial class LoadBalancer
    {
        public LoadBalancer(ITestOutputHelper output)
        {
            TestHelper.TestLogger = output;
        }

        [Fact]
        public void NatOnly()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new LoadBalancerHelpers.InternetNatOnly(azure.VirtualMachines.Manager)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact]
        public void NatRules()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new LoadBalancerHelpers.InternetWithNatRule(azure.VirtualMachines.Manager)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact]
        public void NatPools()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new LoadBalancerHelpers.InternetWithNatPool(azure.VirtualMachines.Manager)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact]
        public void InternetMinimum()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new LoadBalancerHelpers.InternetMinimal(azure.VirtualMachines.Manager)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact]
        public void InternalMinimum()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new LoadBalancerHelpers.InternalMinimal(azure.VirtualMachines.Manager)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }
    }
}