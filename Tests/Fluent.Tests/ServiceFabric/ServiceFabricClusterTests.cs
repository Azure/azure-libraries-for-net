// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using System.Linq;
using Xunit;
using Fluent.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.ServiceFabric.Fluent;
using Microsoft.Azure.Management.ServiceFabric.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Models;
using System.IO;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.Compute.Fluent;

namespace Fluent.Tests.Storage
{
    public class ServiceFabricClusterTests
    {
        [Fact]
        public void CanCreateWithMinimalSettings()
        {
            using (var mockContext = FluentMockContext.Start(this.GetType().FullName))
            {
                var region = Region.USEast2;
                string deploymentName = "fb" + DateTime.Now.ToString("ddHHmm");
                string resourceGroupName = deploymentName;
                string vaultName = deploymentName + "kv";
                string storageAccountName = deploymentName + "dg";
                string storageAccountName2 = deploymentName + "sf";
                string vnetName = deploymentName + "vnet";
                string publicIpName = deploymentName + "ip";
                string loadBalancerName1 = deploymentName + "lb1";
                string frontendName = loadBalancerName1 + "fe1";
                string backendPoolName1 = loadBalancerName1 + "bap1";
                string httpProbe = "httpProbe";
                string fabricGatewayProbe = "fabricGatewayProbe";
                string fabricHttpGatewayProbe = "fabricHttpGatewayProbe";
                string httpLoadBalancingRule = "httpRule";
                string fabricGatewayLoadBalancingRule = "fabricGatewayLoadBalancingRule";
                string fabricHttpGatewayLoadBalancingRule = "fabricHttpGatewayLoadBalancingRule";
                string vmssName = deploymentName + "vmss";
                string rdpNatPool = "rdpNatPool";
                string userName = "admin";
                string password = "nZ5#9Ux2Mn!6srTv.Zsq";

                string clusterName = deploymentName + "sf";
                string clusterCertificateName = deploymentName + "clustercert";
                string clientCertificateName = deploymentName + "clusterclientcert";
                string proxyCertificateName = deploymentName + "proxycert";
                string clusterDnsName = clusterName + "." + region.Name + ".cloudapp.azure.com";
                string nodeTypeName = "frontend";
                string subnetName = "frontend";

                try
                {
                    var azure = TestHelper.CreateRollupClient();
                    var resourceGroup = CreateResourceGroup(region, resourceGroupName, azure);
                    var vault1 = CreateKeyVault(region, vaultName, azure, resourceGroup);
                    var cert = CreateCertificate(clusterDnsName, azure, vault1);
                    var storageAccountDiagnostics = CreateStorageAccount("diag", region, azure, resourceGroup);
                    var storageVmDisks = CreateStorageAccount("vmdisks", region, azure, resourceGroup);
                    var nsg = CreateNSGs(region, resourceGroupName, azure, resourceGroup);
                    var network = CreateNetwork(region, vnetName, subnetName, azure, resourceGroup, nsg);
                    var publicIPAddress = CreatePip(region, publicIpName, azure, resourceGroup);
                    var loadBalancer1 = CreateLoadBalancer(region, loadBalancerName1, frontendName, backendPoolName1, httpProbe, fabricGatewayProbe, fabricHttpGatewayProbe, httpLoadBalancingRule, fabricGatewayLoadBalancingRule, fabricHttpGatewayLoadBalancingRule, rdpNatPool, azure, resourceGroup, publicIPAddress);
                    var scaleSet = CreateScaleSet(region, backendPoolName1, vmssName, rdpNatPool, userName, password, clusterDnsName, subnetName, azure, resourceGroup, storageAccountDiagnostics, network, loadBalancer1, cert.Thumbprint);

                    var serviceFabricCluster = azure.ServiceFabricClusters.Define(clusterName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithOsType(ServiceFabricOsType.Windows)
                        .WithReliability(ReliabilityLevel.Silver)
                        .WithOneCertificate(cert)
                        .WithStorageAccountVmDisks(storageAccountDiagnostics)
                        .WithStorageAccountDiagnostics(storageVmDisks)
                        .AddNodeType(nodeTypeName)
                        .WithScaleSet(scaleSet)
                        .Create();

                    // Check the overridden settings
                    Assert.Equal(ReliabilityLevel.Silver, serviceFabricCluster.ReliabilityLevel);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(resourceGroupName);
                    }
                    catch { }
                }
            }
        }

        private static INetworkSecurityGroup CreateNSGs(Region region, string resourceGroupName, IAzure azure, IResourceGroup resourceGroup)
        {
            var frontEndNSG = azure.NetworkSecurityGroups.Define(resourceGroupName + "nsg")
                                .WithRegion(region)
                                .WithExistingResourceGroup(resourceGroup)
                                .DefineRule("Gateway")
                                    .AllowInbound()
                                    .FromAddress("Internet")
                                    .FromPort(19000)
                                    .ToAddress("VirtualNetwork")
                                    .ToPort(19000)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3900)
                                    .WithDescription("Allow Service Fabric Gateway.")
                                    .Attach()
                                .DefineRule("HttpGateway")
                                    .AllowInbound()
                                    .FromAddress("Internet")
                                    .FromPort(19080)
                                    .ToAddress("VirtualNetwork")
                                    .ToPort(19080)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3910)
                                    .WithDescription("Allow Service Fabric HTTP Gateway.")
                                    .Attach()
                                .DefineRule("Lease")
                                    .AllowInbound()
                                    .FromAddress("VirtualNetwork")
                                    .FromPortRange(1025, 1027)
                                    .ToAddress("VirtualNetwork")
                                    .ToPortRange(1025, 1027)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3920)
                                    .WithDescription("Allow lease layer for Service Fabric.")
                                    .Attach()
                                .DefineRule("Ephemeral")
                                    .AllowInbound()
                                    .FromAddress("VirtualNetwork")
                                    .FromPortRange(49152, 65534)
                                    .ToAddress("VirtualNetwork")
                                    .ToPortRange(49152, 65534)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3930)
                                    .WithDescription("Allow ephemeral ports for Service Fabric.")
                                    .Attach()
                                .DefineRule("Application")
                                    .AllowInbound()
                                    .FromAddress("VirtualNetwork")
                                    .FromPortRange(20000, 30000)
                                    .ToAddress("VirtualNetwork")
                                    .ToPortRange(20000, 30000)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3940)
                                    .WithDescription("Allow application ports between nodes.")
                                    .Attach()
                                .DefineRule("SMB")
                                    .AllowInbound()
                                    .FromAddress("VirtualNetwork")
                                    .FromPort(445)
                                    .ToAddress("VirtualNetwork")
                                    .ToPort(445)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3950)
                                    .WithDescription("Allow SMB for ImageStore service between nodes.")
                                    .Attach()
                                .DefineRule("RDP")
                                    .AllowInbound()
                                    .FromAddress("Internet")
                                    .FromPortRange(3389, 3488)
                                    .ToAddress("VirtualNetwork")
                                    .ToPortRange(3389, 3488)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3960)
                                    .WithDescription("Allow RDP to nodes.")
                                    .Attach()
                                .DefineRule("HttpEndpoint")
                                    .AllowInbound()
                                    .FromAddress("Internet")
                                    .FromPort(80)
                                    .ToAddress("VirtualNetwork")
                                    .ToPort(80)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3980)
                                    .WithDescription("Allow HTTP traffic for custom endpoint.")
                                    .Attach()
                                .DefineRule("Network")
                                    .AllowOutbound()
                                    .FromAddress("VirtualNetwork")
                                    .FromAnyPort()
                                    .ToAddress("VirtualNetwork")
                                    .ToAnyPort()
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3900)
                                    .WithDescription("Allow SMB for ImageStore service between nodes.")
                                    .Attach()
                                .DefineRule("ResourceProvider")
                                    .AllowOutbound()
                                    .FromAddress("VirtualNetwork")
                                    .FromPort(443)
                                    .ToAddress("Internet")
                                    .ToPort(443)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3910)
                                    .WithDescription("Allow to connect to the Service Fabric Resource Provider.")
                                    .Attach()
                                .DefineRule("Upgrade")
                                    .AllowOutbound()
                                    .FromAddress("VirtualNetwork")
                                    .FromPort(443)
                                    .ToAddress("Internet")
                                    .ToPort(443)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3920)
                                    .WithDescription("Allow Service Fabric to download new runtime versions.")
                                    .Attach()
                                .Create();

            return frontEndNSG;
        }

        private static INetwork CreateNetwork(Region region, string vnetName, string subnetName, IAzure azure, IResourceGroup resourceGroup, INetworkSecurityGroup nsg)
        {
            return azure.Networks.Define(vnetName)
                                        .WithRegion(region)
                                        .WithExistingResourceGroup(resourceGroup)
                                        .WithAddressSpace("10.0.0.0/24")
                                        .DefineSubnet(subnetName)
                                        .WithAddressPrefix("10.0.0.0/24")
                                        .WithExistingNetworkSecurityGroup(nsg)
                                        .Attach()
                                        .Create();
        }

        private static IPublicIPAddress CreatePip(Region region, string publicIpName, IAzure azure, IResourceGroup resourceGroup)
        {
            return azure.PublicIPAddresses.Define(publicIpName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(resourceGroup)
                    .WithLeafDomainLabel(publicIpName)
                    .Create();
        }

        private static ILoadBalancer CreateLoadBalancer(Region region, string loadBalancerName1, string frontendName, string backendPoolName1, string httpProbe, string fabricGatewayProbe, string fabricHttpGatewayProbe, string httpLoadBalancingRule, string fabricGatewayLoadBalancingRule, string fabricHttpGatewayLoadBalancingRule, string rdpNatPool, IAzure azure, IResourceGroup resourceGroup, IPublicIPAddress publicIPAddress)
        {
            var loadBalancer1 = azure.LoadBalancers.Define(loadBalancerName1)
                                        .WithRegion(region)
                                        .WithExistingResourceGroup(resourceGroup)
                                        // Explicitly define the frontend
                                        // Add two rules that uses above backend and probe
                                        .DefineLoadBalancingRule(httpLoadBalancingRule)
                                            .WithProtocol(TransportProtocol.Tcp)
                                            .FromFrontend(frontendName)
                                            .FromFrontendPort(80)
                                            .ToBackend(backendPoolName1)
                                            .WithProbe(httpProbe)
                                            .Attach()
                                        .DefineLoadBalancingRule(fabricGatewayLoadBalancingRule)
                                            .WithProtocol(TransportProtocol.Tcp)
                                            .FromFrontend(frontendName)
                                            .FromFrontendPort(19000)
                                            .ToBackend(backendPoolName1)
                                            .WithProbe(fabricGatewayProbe)
                                            .Attach()
                                        .DefineLoadBalancingRule(fabricHttpGatewayLoadBalancingRule)
                                            .WithProtocol(TransportProtocol.Tcp)
                                            .FromFrontend(frontendName)
                                            .FromFrontendPort(19080)
                                            .ToBackend(backendPoolName1)
                                            .WithProbe(fabricHttpGatewayProbe)
                                            .Attach()
                                        // Add nat pools to enable direct VM connectivity for
                                        // RDP to port 3989 
                                        .DefineInboundNatPool(rdpNatPool)
                                            .WithProtocol(TransportProtocol.Tcp)
                                            .FromFrontend(frontendName)
                                            .FromFrontendPortRange(3989, 4088)
                                            .ToBackendPort(3989)
                                            .Attach()
                                        // Add two probes one per rule
                                        .DefineHttpProbe(httpProbe)
                                            .WithRequestPath("/")
                                            .WithPort(80)
                                            .Attach()
                                        .DefineHttpProbe(fabricGatewayProbe)
                                            .WithRequestPath("/")
                                            .WithPort(19000)
                                            .Attach()
                                        .DefineHttpProbe(fabricHttpGatewayProbe)
                                            .WithRequestPath("/")
                                            .WithPort(19080)
                                            .Attach()
                                        .DefinePublicFrontend(frontendName)
                                            .WithExistingPublicIPAddress(publicIPAddress)
                                            .Attach()
                                        .WithSku(LoadBalancerSkuType.Standard)
                                        .Create();
            return loadBalancer1;
        }

        private static IVirtualMachineScaleSet CreateScaleSet(Region region, string backendPoolName1, string vmssName, string rdpNatPool, string userName, string password, string clusterDnsName, string subnetName, IAzure azure, IResourceGroup resourceGroup, IStorageAccount storageAccountDiagnostics, INetwork network, ILoadBalancer loadBalancer1, string thumbprint)
        {
            var certificateSettings = new Dictionary<string, string>()
            {
                { "thumbprint", thumbprint },
                { "x509StoreName", "My" }
            };

            var scaleSet = azure.VirtualMachineScaleSets.Define(vmssName)
                                    .WithRegion(region)
                                    .WithExistingResourceGroup(resourceGroup)
                                    .WithSku(VirtualMachineScaleSetSkuTypes.StandardD3v2)
                                    .WithExistingPrimaryNetworkSubnet(network, subnetName)
                                    .WithExistingPrimaryInternetFacingLoadBalancer(loadBalancer1)
                                    .WithPrimaryInternetFacingLoadBalancerBackends(backendPoolName1)
                                    .WithPrimaryInternetFacingLoadBalancerInboundNatPools(rdpNatPool)
                                    .WithoutPrimaryInternalLoadBalancer()
                                    .WithLatestWindowsImage("MicrosoftWindowsServer", "WindowsServer", "2019-Datacenter-with-Containers")
                                    .WithAdminUsername(userName)
                                    .WithAdminPassword(password)
                                    .WithComputerNamePrefix("node1")
                                    .WithOverProvision(false)
                                    .WithUpgradeMode(Microsoft.Azure.Management.Compute.Fluent.Models.UpgradeMode.Automatic)
                                    .WithCapacity(5)
                                    // Use a VM extension to install Service Fabric
                                    .DefineNewExtension("Service Fabric")
                                        .WithPublisher("Microsoft.Azure.ServiceFabric")
                                        .WithType("ServiceFabricNode")
                                        .WithVersion("1.1")
                                        .WithMinorVersionAutoUpgrade()
                                        .WithProtectedSetting("StorageAccountKey1", storageAccountDiagnostics.GetKeys()[0])
                                        .WithProtectedSetting("StorageAccountKey2", storageAccountDiagnostics.GetKeys()[1])
                                        .WithPublicSetting("clusterEndpoint", clusterDnsName)
                                        .WithPublicSetting("nodeTypeRef", "node1")
                                        .WithPublicSetting("dataPath", "D:\\\\SvcFab")
                                        .WithPublicSetting("durabilityLevel", "Silver")
                                        .WithPublicSetting("enableParallelJobs", true)
                                        .WithPublicSetting("nicPrefixOverride", network.Subnets[subnetName].AddressPrefix)
                                        .WithPublicSetting("certificate", certificateSettings)
                                        .Attach()
                                    .Create();
            return scaleSet;
        }

        private static IStorageAccount CreateStorageAccount(string name, Region region, IAzure azure, IResourceGroup resourceGroup)
        {
            return azure.StorageAccounts.Define(name)
                .WithRegion(region)
                .WithExistingResourceGroup(resourceGroup)
                .WithSku(StorageAccountSkuType.Standard_LRS)
                .Create();
        }

        private static X509Certificate2 CreateCertificate(string clusterDnsName, IAzure azure, IVault vault1)
        {
            var servicePrincipalInfo = ParseAuthFile(System.Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(async (authority, resource, scope) =>
            {
                var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
                var result = await context.AcquireTokenAsync(resource, new ClientCredential(servicePrincipalInfo.ClientId, servicePrincipalInfo.ClientSecret));
                return result.AccessToken;
            }), ((KeyVaultManagementClient)azure.Vaults.Manager.Inner).HttpClient);

            var cert = CreateCertificateInKeyVaultAsync(keyVaultClient, vault1.VaultUri, "clustercert", clusterDnsName).Result;
            return cert;
        }

        private static IVault CreateKeyVault(Region region, string vaultName, IAzure azure, IResourceGroup resourceGroup)
        {
            var vault1 = azure.Vaults
                                    .Define(vaultName)
                                    .WithRegion(region)
                                    .WithExistingResourceGroup(resourceGroup)
                                    .WithEmptyAccessPolicy()
                                    .Create();

            vault1 = vault1.Update()
                    .WithDeploymentEnabled()
                    .Apply();
            return vault1;
        }

        private static IResourceGroup CreateResourceGroup(Region region, string resourceGroupName, IAzure azure)
        {
            return azure.ResourceGroups
                                    .Define(resourceGroupName)
                                    .WithRegion(region)
                                    .Create();
        }

        private static ServicePrincipalLoginInformation ParseAuthFile(string authFile)
        {
            var info = new ServicePrincipalLoginInformation();

            var lines = File.ReadLines(authFile);
            if (lines.First().Trim().StartsWith("{"))
            {
                string json = string.Join("", lines);
                var jsonConfig = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                info.ClientId = jsonConfig["clientId"];
                if (jsonConfig.ContainsKey("clientSecret"))
                {
                    info.ClientSecret = jsonConfig["clientSecret"];
                }
            }
            else
            {
                lines.All(line =>
                {
                    if (line.Trim().StartsWith("#"))
                        return true; // Ignore comments
                    var keyVal = line.Trim().Split(new char[] { '=' }, 2);
                    if (keyVal.Length < 2)
                        return true; // Ignore lines that don't look like $$$=$$$
                    if (keyVal[0].Equals("client", StringComparison.OrdinalIgnoreCase))
                    {
                        info.ClientId = keyVal[1];
                    }
                    if (keyVal[0].Equals("key", StringComparison.OrdinalIgnoreCase))
                    {
                        info.ClientSecret = keyVal[1];
                    }
                    return true;
                });
            }

            return info;
        }

        private static async Task<X509Certificate2> CreateCertificateInKeyVaultAsync(KeyVaultClient client, string vaultUrl, string certName, string commonName)
        {
            var certificateOperation = await client.CreateCertificateAsync(
                vaultUrl,
                certName,
                new CertificatePolicy(
                    keyProperties: new KeyProperties(false, "RSA", 2048, false),
                    x509CertificateProperties: new X509CertificateProperties(
                        "CN=" + commonName,
                        keyUsage: new List<string> { X509KeyUsageFlags.KeyCertSign.ToString() },
                        ekus: new List<string> { "1.3.6.1.5.5.7.3.2", "1.3.6.1.5.5.7.3.1" }),
                    issuerParameters: new IssuerParameters("Self")));

            while (certificateOperation.Status == "inProgress")
            {
                Console.WriteLine($"Creation of certificate '{certName}' is in progress");
                await Task.Delay(1000);
                certificateOperation = await client.GetCertificateOperationAsync(vaultUrl, certName);
            }

            Console.WriteLine($"Creation of certificate '{certName}' is in status '{certificateOperation.Status}'");

            var certificate = await client.GetCertificateAsync(vaultUrl, certName);
            return new X509Certificate2(certificate.Cer);
        }

    }
}
