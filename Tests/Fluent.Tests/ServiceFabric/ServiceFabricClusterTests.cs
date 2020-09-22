// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using System.Linq;
using Xunit;
using Fluent.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.ServiceFabric.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
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
using System.Text;
using Microsoft.Azure.Test.HttpRecorder;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Net;

using Environment = Microsoft.Azure.Management.ServiceFabric.Fluent.Models.Environment;


namespace Fluent.Tests
{
    public class ServiceFabric
    {
        [Fact]
        public void CanCreateBasicCluster()
        {
            using (var mockContext = FluentMockContext.Start(this.GetType().FullName))
            {
                #region Parameters

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
                string userName = "FabricMonkey";
                string password = "Corp123!Corp123!"; // GeneratePassword(12);

                string clusterName = deploymentName + "sf";
                string clusterCertificateName = deploymentName + "clustercert";
                string clientCertificateName = deploymentName + "clusterclientcert";
                string proxyCertificateName = deploymentName + "proxycert";
                string clusterDnsName = clusterName + "." + region.Name + ".cloudapp.azure.com";
                string nodeTypeName = "frontend";
                string subnetName = "frontend";
                
                #endregion

                try
                {
                    var resourceManager = TestHelper.CreateResourceManager();
                    var keyVaultManager = TestHelper.CreateKeyVaultManager();
                    var storageManager = TestHelper.CreateStorageManager();
                    var networkManager = TestHelper.CreateNetworkManager();
                    var computeManager = TestHelper.CreateComputeManager();
                    var serviceFabricManager = TestHelper.CreateServiceFabricManager();

                    var resourceGroup = CreateResourceGroup(region, resourceGroupName, resourceManager);
                    var vault1 = CreateKeyVault(region, vaultName, keyVaultManager, resourceGroup);

                    //var certificate = CreateSelfSignedServerCertificate(clusterDnsName, password);
                    var certificateBytes = CreateSelfSignedServerCertificate(clusterCertificateName, password, clusterDnsName);
                    var clusterCertificate = new X509Certificate2(certificateBytes, password);
                    string rawCertData = Convert.ToBase64String(certificateBytes, 0, certificateBytes.Length);
                    var secretJson = new CertificateSecretObject() { Data = rawCertData, DataType = "pfx", Password = password };
                    var stringMessage = JsonConvert.SerializeObject(secretJson, Formatting.Indented);
                    var bytes = Encoding.UTF8.GetBytes(stringMessage);
                    string secretValue = Convert.ToBase64String(bytes, 0, bytes.Length);

                    if (HttpMockServer.Mode == HttpRecorderMode.Record) SdkContext.DelayProvider.Delay(10000);
                    var secret = vault1.Secrets.Define(clusterCertificateName)
                            .WithValue(secretValue)
                            .Create();

                    var storageAccountDiagnostics = CreateStorageAccount(storageAccountName, region, storageManager, resourceGroup);
                    var storageVmDisks = CreateStorageAccount(storageAccountName2, region, storageManager, resourceGroup);
                    var nsg = CreateNSGs(region, resourceGroupName, networkManager, resourceGroup);
                    var network = CreateNetwork(region, vnetName, subnetName, networkManager, resourceGroup, nsg);
                    var publicIPAddress = CreatePip(region, publicIpName, networkManager, resourceGroup);
                    var loadBalancer1 = CreateLoadBalancer(region, loadBalancerName1, frontendName, backendPoolName1, httpProbe, fabricGatewayProbe, fabricHttpGatewayProbe, httpLoadBalancingRule, fabricGatewayLoadBalancingRule, fabricHttpGatewayLoadBalancingRule, rdpNatPool, networkManager, resourceGroup, publicIPAddress);


                    var serviceFabricCluster2 = serviceFabricManager.ServiceFabricClusters.Define(clusterName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithVmImage(Environment.Windows)
                        .WithReliability(ReliabilityLevel.Silver)
                        .WithOneCertificate(clusterCertificate)
                        .WithStorageAccountVmDisks(storageAccountDiagnostics)
                        .WithStorageAccountDiagnostics(storageVmDisks)
                        .AddNodeType(nodeTypeName)
                        .Create();

                    var serviceFabricCluster = serviceFabricManager.ServiceFabricClusters.Define(clusterName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithParameters()
                            .WithVmImage(Environment.Windows)
                            .WithReliability(ReliabilityLevel.Silver)
                            .WithOneCertificate(clusterCertificate)
                            .WithStorageAccountVmDisks(storageAccountDiagnostics)
                            .WithStorageAccountDiagnostics(storageVmDisks)
                            .AddNodeType(nodeTypeName)
                        .Create();


                    var scaleSet = CreateScaleSet(region, backendPoolName1, vmssName, rdpNatPool, userName, password, clusterDnsName, subnetName, computeManager, resourceGroup, storageAccountDiagnostics, network, loadBalancer1, clusterCertificate.Thumbprint, vault1, secret.Id);



                    //    "certificateCommonName": {
                    //        "value": "myclustername.southcentralus.cloudapp.azure.com"
                    //    },

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

        //private void CreateAsync()
        //{

        //    await Task.WhenAll(
        //        storageManager.StorageAccounts.Define(storageAccount1Name)
        //        .WithRegion(region)
        //        .WithExistingResourceGroup(resourceGroup)
        //        .WithSku(StorageAccountSkuType.Standard_LRS)
        //        .CreateAsync();
        //        .ContinueWith(s =>
        //        {
        //            storageAccount1 = s.Result;
        //            return storageAccount1;
        //        }),
        //        storageManager.StorageAccounts.Define(storageAccount2Name)
        //        .WithRegion(region)
        //        .WithExistingResourceGroup(resourceGroup)
        //        .WithSku(StorageAccountSkuType.Standard_LRS)
        //        .CreateAsync();
        //        .ContinueWith(s =>
        //         {
        //             storageAccount2 = s.Result;
        //             return storageAccount2;
        //         }),

        //    );
        //}


        private X509Certificate2 CreateSelfSignedServerCertificate(string commonName, string password)
        {
            var sanBuilder = new SubjectAlternativeNameBuilder();
            sanBuilder.AddDnsName(commonName);

            var distinguishedName = new X500DistinguishedName($"CN={commonName}");

            using (RSA rsa = new RSACryptoServiceProvider(4096, new CspParameters(24, "Microsoft Enhanced RSA and AES Cryptographic Provider", Guid.NewGuid().ToString())))
            {
                var request = new CertificateRequest(distinguishedName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyEncipherment | X509KeyUsageFlags.DigitalSignature, false));
                request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection { new Oid("1.3.6.1.5.5.7.3.2"), new Oid("1.3.6.1.5.5.7.3.1") }, false));
                request.CertificateExtensions.Add(sanBuilder.Build());

                var certificate = request.CreateSelfSigned(new DateTimeOffset(DateTime.UtcNow.AddDays(-1)), new DateTimeOffset(DateTime.UtcNow.AddDays(3650)));
                certificate.FriendlyName = commonName;

                return new X509Certificate2(certificate.Export(X509ContentType.Pfx, password), password, X509KeyStorageFlags.Exportable);
            }
        }

        private byte[] CreateSelfSignedServerCertificate(string certificateName, string password, string commonName)
        {
            SubjectAlternativeNameBuilder sanBuilder = new SubjectAlternativeNameBuilder();
            sanBuilder.AddIpAddress(IPAddress.Loopback);
            sanBuilder.AddIpAddress(IPAddress.IPv6Loopback);
            sanBuilder.AddDnsName(commonName);

            X500DistinguishedName distinguishedName = new X500DistinguishedName($"CN={commonName}");

            using (RSA rsa = new RSACryptoServiceProvider(4096, new CspParameters(24, "Microsoft Enhanced RSA and AES Cryptographic Provider", Guid.NewGuid().ToString())))
            {
                //rsa.PersistKeyInCsp = false;

                var certificateRequest = new CertificateRequest(distinguishedName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                certificateRequest.CertificateExtensions.Add(sanBuilder.Build());
                certificateRequest.CertificateExtensions.Add(
                    new X509KeyUsageExtension(X509KeyUsageFlags.DataEncipherment | X509KeyUsageFlags.KeyEncipherment | X509KeyUsageFlags.DigitalSignature, false));
                certificateRequest.CertificateExtensions.Add(
                   new X509EnhancedKeyUsageExtension(
                       new OidCollection { new Oid("1.3.6.1.5.5.7.3.1"), new Oid("1.3.6.1.5.5.7.3.2") }, false));

                using (X509Certificate2 certificate = certificateRequest.CreateSelfSigned(new DateTimeOffset(DateTime.UtcNow.AddDays(-1)), new DateTimeOffset(DateTime.UtcNow.AddDays(3650))))
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        certificate.FriendlyName = certificateName;

                    // At this line the persisted key still exists so it reports its name and CSP/KSP into the PFX.
                    return certificate.Export(X509ContentType.Pkcs12, password);
                }
                //return new X509Certificate2(certificate.Export(X509ContentType.Pfx, password), password, X509KeyStorageFlags.MachineKeySet);
            }
        }

        private string GeneratePassword(int length)
        {
            var password = new StringBuilder();
            Random random = new Random();
            bool digit = false;
            bool lowercase = false;
            bool uppercase = false;
            bool nonAlphanumeric = false;

            while (password.Length < length)
            {
                char c = (char)random.Next(32, 126);

                password.Append(c);

                if (char.IsDigit(c))
                    digit = false;
                else if (char.IsLower(c))
                    lowercase = false;
                else if (char.IsUpper(c))
                    uppercase = false;
                else if (!char.IsLetterOrDigit(c))
                    nonAlphanumeric = false;
            }

            if (nonAlphanumeric)
                password.Append((char)random.Next(33, 48));
            if (digit)
                password.Append((char)random.Next(48, 58));
            if (lowercase)
                password.Append((char)random.Next(97, 123));
            if (uppercase)
                password.Append((char)random.Next(65, 91));

            return password.ToString();
        }

        private static INetworkSecurityGroup CreateNSGs(Region region, string resourceGroupName, INetworkManager manager, IResourceGroup resourceGroup)
        {
            var frontEndNSG = manager.NetworkSecurityGroups.Define(resourceGroupName + "nsg")
                                .WithRegion(region)
                                .WithExistingResourceGroup(resourceGroup)
                                .DefineRule("Gateway")
                                    .AllowInbound()
                                    .FromAddress("Internet")
                                    .FromAnyPort()
                                    .ToAddress("VirtualNetwork")
                                    .ToPort(19000)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3900)
                                    .WithDescription("Allow Service Fabric Gateway.")
                                    .Attach()
                                .DefineRule("HttpGateway")
                                    .AllowInbound()
                                    .FromAddress("Internet")
                                    .FromAnyPort()
                                    .ToAddress("VirtualNetwork")
                                    .ToPort(19080)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3910)
                                    .WithDescription("Allow Service Fabric HTTP Gateway.")
                                    .Attach()
                                .DefineRule("Lease")
                                    .AllowInbound()
                                    .FromAddress("VirtualNetwork")
                                    .FromAnyPort()
                                    .ToAddress("VirtualNetwork")
                                    .ToPortRange(1025, 1027)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3920)
                                    .WithDescription("Allow lease layer for Service Fabric.")
                                    .Attach()
                                .DefineRule("Ephemeral")
                                    .AllowInbound()
                                    .FromAddress("VirtualNetwork")
                                    .FromAnyPort()
                                    .ToAddress("VirtualNetwork")
                                    .ToPortRange(49152, 65534)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3930)
                                    .WithDescription("Allow ephemeral ports for Service Fabric.")
                                    .Attach()
                                .DefineRule("Application")
                                    .AllowInbound()
                                    .FromAddress("VirtualNetwork")
                                    .FromAnyPort()
                                    .ToAddress("VirtualNetwork")
                                    .ToPortRange(20000, 30000)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3940)
                                    .WithDescription("Allow application ports between nodes.")
                                    .Attach()
                                .DefineRule("SMB")
                                    .AllowInbound()
                                    .FromAddress("VirtualNetwork")
                                    .FromAnyPort()
                                    .ToAddress("VirtualNetwork")
                                    .ToPort(445)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3950)
                                    .WithDescription("Allow SMB for ImageStore service between nodes.")
                                    .Attach()
                                .DefineRule("RDP")
                                    .AllowInbound()
                                    .FromAddress("Internet")
                                    .FromAnyPort()
                                    .ToAddress("VirtualNetwork")
                                    .ToPortRange(3389, 3488)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3960)
                                    .WithDescription("Allow RDP to nodes.")
                                    .Attach()
                                .DefineRule("HttpEndpoint")
                                    .AllowInbound()
                                    .FromAddress("Internet")
                                    .FromAnyPort()
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
                                    .FromAnyPort()
                                    .ToAddress("Internet")
                                    .ToPort(443)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3910)
                                    .WithDescription("Allow to connect to the Service Fabric Resource Provider.")
                                    .Attach()
                                .DefineRule("Upgrade")
                                    .AllowOutbound()
                                    .FromAddress("VirtualNetwork")
                                    .FromAnyPort()
                                    .ToAddress("Internet")
                                    .ToPort(443)
                                    .WithProtocol(SecurityRuleProtocol.Tcp)
                                    .WithPriority(3920)
                                    .WithDescription("Allow Service Fabric to download new runtime versions.")
                                    .Attach()
                                .Create();

            return frontEndNSG;
        }

        private static INetwork CreateNetwork(Region region, string vnetName, string subnetName, INetworkManager manager, IResourceGroup resourceGroup, INetworkSecurityGroup nsg)
        {
            return manager.Networks.Define(vnetName)
                                        .WithRegion(region)
                                        .WithExistingResourceGroup(resourceGroup)
                                        .WithAddressSpace("10.0.0.0/16")
                                        .DefineSubnet(subnetName)
                                        .WithAddressPrefix("10.0.0.0/16")
                                        .WithExistingNetworkSecurityGroup(nsg)
                                        .Attach()
                                        .Create();
        }

        private static IPublicIPAddress CreatePip(Region region, string publicIpName, INetworkManager networkManager, IResourceGroup resourceGroup)
        {
            return networkManager.PublicIPAddresses.Define(publicIpName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(resourceGroup)
                    .WithLeafDomainLabel(publicIpName)
                    .WithSku(PublicIPSkuType.Standard)
                    .WithStaticIP()
                    .Create();
        }

        private static ILoadBalancer CreateLoadBalancer(Region region, string loadBalancerName1, string frontendName, string backendPoolName1, string httpProbe, string fabricGatewayProbe, string fabricHttpGatewayProbe, string httpLoadBalancingRule, string fabricGatewayLoadBalancingRule, string fabricHttpGatewayLoadBalancingRule, string rdpNatPool, INetworkManager networkManager, IResourceGroup resourceGroup, IPublicIPAddress publicIPAddress)
        {
            var loadBalancer1 = networkManager.LoadBalancers.Define(loadBalancerName1)
                                        .WithRegion(region)
                                        .WithExistingResourceGroup(resourceGroup)
                                        //.DefineInboundNatPool(rdpNatPool)
                                        //    .WithProtocol(TransportProtocol.Tcp)
                                        //    .FromExistingPublicIPAddress(publicIPAddress)
                                        //    .FromFrontendPortRange(3389, 4600)
                                        //    .ToBackendPort(3389)
                                        //    .Attach()
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

        private static IVirtualMachineScaleSet CreateScaleSet(Region region, string backendPoolName1, string vmssName, string rdpNatPool, string userName, string password, string clusterDnsName, string subnetName, IComputeManager computeManager, IResourceGroup resourceGroup, IStorageAccount storageAccountDiagnostics, INetwork network, ILoadBalancer loadBalancer1, string thumbprint, IVault vault, string secretIdentifier)
        {
            var certificateSettings = new Dictionary<string, string>()
            {
                { "thumbprint", thumbprint },
                { "x509StoreName", "My" }
            };

            //  "commonNames": [
            //      "[parameters('certificateCommonName')]"
            //  ],
            //  "x509StoreName": "[parameters('certificateStoreValue')]"

            var scaleSet = computeManager.VirtualMachineScaleSets.Define(vmssName)
                                    .WithRegion(region)
                                    .WithExistingResourceGroup(resourceGroup)
                                    .WithSku(VirtualMachineScaleSetSkuTypes.StandardD2v2)
                                    .WithExistingPrimaryNetworkSubnet(network, subnetName)
                                    .WithExistingPrimaryInternetFacingLoadBalancer(loadBalancer1)
                                    .WithPrimaryInternetFacingLoadBalancerBackends(backendPoolName1)
                                    .WithPrimaryInternetFacingLoadBalancerInboundNatPools(rdpNatPool)
                                    .WithoutPrimaryInternalLoadBalancer()
                                    .WithLatestWindowsImage("MicrosoftWindowsServer", "WindowsServer", "2019-Datacenter-with-Containers")
                                    .WithAdminUsername(userName)
                                    .WithAdminPassword(password)
                                    .WithComputerNamePrefix("node1")
                                    .WithVaultSecret(vault.Id, secretIdentifier, "My")
                                    .WithOverProvision(false)
                                    .WithUpgradeMode(Microsoft.Azure.Management.Compute.Fluent.Models.UpgradeMode.Automatic)
                                    .WithCapacity(5)
                                    // Use a VM extension to install Service Fabric
                                    .DefineNewExtension("ServiceFabric")
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

        private static IStorageAccount CreateStorageAccount(string name, Region region, IStorageManager storageManager, IResourceGroup resourceGroup)
        {
            return storageManager.StorageAccounts.Define(name)
                .WithRegion(region)
                .WithExistingResourceGroup(resourceGroup)
                .WithSku(StorageAccountSkuType.Standard_LRS)
                .Create();
        }

        private static CertificateBundle CreateCertificate(string clusterDnsName, IKeyVaultManager keyVaultManager, IVault vault1)
        {
            var servicePrincipalInfo = ParseAuthFile(System.Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(async (authority, resource, scope) =>
            {
                var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
                var result = await context.AcquireTokenAsync(resource, new ClientCredential(servicePrincipalInfo.ClientId, servicePrincipalInfo.ClientSecret));
                return result.AccessToken;
            }), ((KeyVaultManagementClient)keyVaultManager.Vaults.Manager.Inner).HttpClient);

            var certificateBundle = CreateCertificateInKeyVaultAsync(keyVaultClient, vault1.VaultUri, "clustercert", clusterDnsName).Result;

            //  var secret = vault1.Secrets
            //    .Define(secretName)
            //    .WithValue(secretValue)
            //    .Create();

            return certificateBundle;
        }

        private static IVault CreateKeyVault(Region region, string vaultName, IKeyVaultManager keyVaultManager, IResourceGroup resourceGroup)
        {
            var spnCredentialsClientId = HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey];

            var vault1 = keyVaultManager.Vaults
                                    .Define(vaultName)
                                    .WithRegion(region)
                                    .WithExistingResourceGroup(resourceGroup)
                                    .DefineAccessPolicy()
                                        .ForServicePrincipal(spnCredentialsClientId)
                                        .AllowKeyAllPermissions()
                                        .AllowSecretAllPermissions()
                                        .Attach()
                                    .WithDeploymentEnabled()
                                    .Create();

            return vault1;
        }

        private static IResourceGroup CreateResourceGroup(Region region, string resourceGroupName, IResourceManager resourceManager)
        {
            return resourceManager.ResourceGroups
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

        private static async Task<CertificateBundle> CreateCertificateInKeyVaultAsync(KeyVaultClient client, string vaultUrl, string certName, string commonName)
        {
            var certificateOperation = await client.CreateCertificateAsync(
                vaultUrl,
                certName,
                new CertificatePolicy(
                    keyProperties: new KeyProperties(false, "RSA", 2048, false),
                    x509CertificateProperties: new X509CertificateProperties(
                        "CN=" + commonName,
                        keyUsage: new List<string> { X509KeyUsageFlags.KeyCertSign.ToString(), X509KeyUsageFlags.DigitalSignature.ToString() }, 
                        ekus: new List<string> { "1.3.6.1.5.5.7.3.2", "1.3.6.1.5.5.7.3.1" }),
                    issuerParameters: new IssuerParameters("Self")));

            while (certificateOperation.Status == "inProgress")
            {
                Console.WriteLine($"Creation of certificate '{certName}' is in progress");
                await Task.Delay(1000);
                certificateOperation = await client.GetCertificateOperationAsync(vaultUrl, certName);
            }

            Console.WriteLine($"Creation of certificate '{certName}' is in status '{certificateOperation.Status}'");
            
            return await client.GetCertificateAsync(vaultUrl, certName); ;
        }
    }

    [JsonObject]
    public class CertificateSecretObject
    {
        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }

        [JsonProperty(PropertyName = "dataType")]
        public string DataType { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
