using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.ServiceFabric.Fluent;
using Microsoft.Azure.Management.ServiceFabric.Fluent.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;


namespace Samples.ServiceFabric
{
    public class MinimalCluster
    {
        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                AzureCredentials credentials = SdkContext.AzureCredentialsFactory.FromFile(System.Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception e)
            {
                Utilities.Log(e);
            }
        }

        /**
         *  Mastering Azure Service Fabric with a simple basic installation, fully automated.
         *  - Create a key vault
         *      - Create a self-signed certificate
         *      - Upload the certificate
         *      - Install the certificate locally
         *  - Create a virtual network
         *  - Create a network security group
         *  - Create a public IP address
         *  - Create a load balancer 
         *      - Standard SKU
         *      - Create health probes
         *  - Create a virtual machine scale set
         *      - Use latest Windows Server Datacenter with Container image
         *      - Use SKU D3_v2
         *      - Instance count 5
         *  - Create VM extensions
         *      - Install Service Fabric extension
         *          - Configure durability Silver
         *      - Install IaaSAntimalware extension
         *      - Install IaaSDiagnostics extensions
         *  - Create a storage account for Service Fabric binaries
         *  - Create a storage account for Service Fabric diagnostic data
         *  - Create Service Fabric cluster
         *    - Latest runtime version
         *    - Durability Silver
         *    - Reliability Silver
         *    - Upgrade mode automatic
         *    - Cluster protection level EncryptAndSign
         *  - Test the cluster connection
         *  - Delete the whole resource group.
         */
        public async static void RunSample(IAzure azure)
        {
            Console.WriteLine("Quick Test");

            #region Parameters

            string deploymentName = "chrpap" + DateTime.Now.ToString("ddHHmm");
            string groupName = deploymentName;
            string vaultName = deploymentName + "kv";
            Region region = Region.USWest;
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
            string userName = "Christian";
            string password = GeneratePassword(12);

            string clusterName = deploymentName + "sf";
            string clusterCertificateName = deploymentName + "clustercert";
            string clientCertificateName = deploymentName + "clusterclientcert";
            string proxyCertificateName = deploymentName + "proxycert";
            string clusterDnsName = clusterName + "." + region.Name + ".cloudapp.azure.com";
            string primaryNodeTypeName = "primary";
            string subnetName = "frontend";

            #endregion

            #region Resource Group

            Utilities.Log("Creating a resource group with name: " + groupName);

            var resourceGroup = azure.ResourceGroups
                    .Define(groupName)
                    .WithRegion(region)
                    .Create();

            Utilities.Log("Created a resource group with name: " + groupName);

            #endregion

            #region Key Vault
            // ============================================================
            // Create the key vault instance
            //
            //

            Utilities.Log("Creating a key vault...");

            var vault1 = azure.Vaults
                    .Define(vaultName)
                    .WithRegion(region)
                    .WithNewResourceGroup(groupName)
                    .WithEmptyAccessPolicy()
                    .Create();

            Utilities.Log("Created key vault");
            Utilities.PrintVault(vault1);


            Utilities.Log("Authorizing the application associated with the current service principal...");
            var servicePrincipalInfo = ParseAuthFile(System.Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));
            vault1 = vault1.Update()
                    .WithDeploymentEnabled()
                    //.DefineAccessPolicy()
                    //        .ForServicePrincipal(servicePrincipalInfo.ClientId)
                    //        .AllowSecretAllPermissions()
                    //        .Attach()
                    .Apply();

            Utilities.Log("Updated key vault for deployment");
            Utilities.PrintVault(vault1);
           
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(async (authority, resource, scope) =>
            {
                var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
                var result = await context.AcquireTokenAsync(resource, new ClientCredential(servicePrincipalInfo.ClientId, servicePrincipalInfo.ClientSecret));
                return result.AccessToken;
            }), ((KeyVaultManagementClient)azure.Vaults.Manager.Inner).HttpClient);

            var cert = CreateCertificateInKeyVaultAsync(keyVaultClient, vault1.VaultUri, "clustercert", clusterDnsName).Result;

            #endregion

            #region Storage

            // ============================================================
            // Create storage account
            //
            //

            Utilities.Log("Creating a Storage Account");

            var storageAccount = azure.StorageAccounts.Define(storageAccountName)
                    .WithRegion(region)
                    .WithNewResourceGroup(groupName)
                    .Create();

            Utilities.Log("Created a Storage Account:");
            Utilities.PrintStorageAccount(storageAccount);

            // ============================================================
            // Create another storage account
            //
            //

            Utilities.Log("Creating a 2nd Storage Account");

            var storageAccount2 = azure.StorageAccounts.Define(storageAccountName2)
                    .WithRegion(region)
                    .WithNewResourceGroup(groupName)
                    .Create();

            Utilities.Log("Created a Storage Account:");
            Utilities.PrintStorageAccount(storageAccount2);

            #endregion

            #region Network

            //=============================================================
            // Create a virtual network with a frontend subnet
            //
            //

            Utilities.Log("Creating a security group for the front end - allows SSH and HTTP");

            var nsg = azure.NetworkSecurityGroups.Define(groupName + "nsg")
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

            Utilities.Log("Created a security group for the front end: " + nsg.Id);
            Utilities.PrintNetworkSecurityGroup(nsg);

            Utilities.Log("Creating virtual network with a frontend subnet ...");
            Utilities.Log("Creating a public IP address...");

            INetwork network = null;
            IPublicIPAddress publicIPAddress = null;

            await Task.WhenAll(
                azure.Networks.Define(vnetName)
                    .WithRegion(region)
                    .WithNewResourceGroup(groupName)
                    .WithAddressSpace("10.0.0.0/24")
                    .DefineSubnet(subnetName)
                    .WithAddressPrefix("10.0.0.0/24")
                    .WithExistingNetworkSecurityGroup(nsg)
                    .Attach()
                    .CreateAsync()
                    .ContinueWith(n =>
                    {
                        network = n.Result;
                        Utilities.Log("Created a virtual network");
                        // Print the virtual network details
                        Utilities.PrintVirtualNetwork(network);
                        return network;
                    }),
                azure.PublicIPAddresses.Define(publicIpName)
                    .WithRegion(region)
                    .WithNewResourceGroup(groupName)
                    .WithLeafDomainLabel(publicIpName)
                    .CreateAsync()
                    .ContinueWith(pip =>
                    {
                        publicIPAddress = pip.Result;
                        Utilities.Log("Created a public IP address");
                        // Print the virtual network details
                        Utilities.PrintIPAddress(publicIPAddress);
                        return pip;
                    }
            )
         );

            //=============================================================
            // Create an Internet facing load balancer with
            // One frontend IP address
            // Two backend address pools which contain network interfaces for the virtual
            //  machines to receive HTTP and HTTPS network traffic from the load balancer
            // Two load balancing rules for HTTP and HTTPS to map public ports on the load
            //  balancer to ports in the backend address pool
            // Two probes which contain HTTP and HTTPS health probes used to check availability
            //  of virtual machines in the backend address pool
            // Three inbound NAT rules which contain rules that map a public port on the load
            //  balancer to a port for a specific virtual machine in the backend address pool
            //  - this provides direct VM connectivity for SSH to port 22 and TELNET to port 23
            //
            //

            Utilities.Log("Creating a Internet facing load balancer with ...");
            Utilities.Log("- A frontend IP address");
            Utilities.Log("- Two backend address pools which contain network interfaces for the virtual\n"
                    + "  machines to receive HTTP and HTTPS network traffic from the load balancer");
            Utilities.Log("- Two load balancing rules for HTTP and HTTPS to map public ports on the load\n"
                    + "  balancer to ports in the backend address pool");
            Utilities.Log("- Two probes which contain HTTP and HTTPS health probes used to check availability\n"
                    + "  of virtual machines in the backend address pool");
            Utilities.Log("- Two inbound NAT rules which contain rules that map a public port on the load\n"
                    + "  balancer to a port for a specific virtual machine in the backend address pool\n"
                    + "  - this provides direct VM connectivity for SSH to port 22 and TELNET to port 23");

            var loadBalancer1 = await azure.LoadBalancers.Define(loadBalancerName1)
                    .WithRegion(region)
                    .WithExistingResourceGroup(groupName)
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
                    .CreateAsync();

            // Print load balancer details
            Utilities.Log("Created a load balancer");
            Utilities.PrintLoadBalancer(loadBalancer1);

            #endregion

            #region Virtual Machine Scale Set

            //=============================================================
            // Create a virtual machine scale set with three virtual machines
            // And, install Apache Web servers on them
            //
            //

            Utilities.Log("Creating virtual machine scale set with three virtual machines"
                    + "in the frontend subnet ...");

            var t1 = new DateTime();

            IVirtualMachineScaleSet virtualMachineScaleSet = null;
            var certificateSettings = new Dictionary<string, string>()
            {
                { "thumbprint", cert.Thumbprint },
                { "x509StoreName", "My" }
            };

            var scaleSet = await azure.VirtualMachineScaleSets.Define(vmssName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(groupName)
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
                        .WithProtectedSetting("StorageAccountKey1", storageAccount.Key)
                        .WithProtectedSetting("StorageAccountKey2", storageAccount2.Key)
                        .WithPublicSetting("clusterEndpoint", clusterDnsName)
                        .WithPublicSetting("nodeTypeRef", "node1")
                        .WithPublicSetting("dataPath", "D:\\\\SvcFab")
                        .WithPublicSetting("durabilityLevel", "Silver")
                        .WithPublicSetting("enableParallelJobs", true)
                        .WithPublicSetting("nicPrefixOverride", network.Subnets[subnetName].AddressPrefix)
                        .WithPublicSetting("certificate", certificateSettings)
                        .Attach()
                    .CreateAsync()
                    .ContinueWith(vmss =>
                    {
                        virtualMachineScaleSet = vmss.Result;
                        var t2 = new DateTime();
                        Utilities.Log("Created a virtual machine scale set with "
                                + "5 Windows VMs with Service Fabric extension on them: (took "
                                + (t2 - t1).TotalSeconds + " seconds) ");
                        Utilities.Log();
                        return virtualMachineScaleSet;
                    });

            #endregion

            #region Service Fabric
            // ============================================================
            // Create the cluster
            //
            //

            var azureActiveDirectory = new AzureActiveDirectory();
            var clusterCertificate = vault1.Secrets.GetByName(clusterCertificateName);

            await azure.ServiceFabricClusters.Define(clusterName)
                .WithRegion(region)
                .WithExistingResourceGroup(groupName)
                .WithOsType(ServiceFabricOsType.Windows)
                .WithReliability(ReliabilityLevel.Silver)
                .WithOneCertificate(cert)
                .WithStorageAccountVmDisks(storageAccount)
                .WithStorageAccountDiagnostics(storageAccount2)
                .AddNodeType(primaryNodeTypeName)
                    .WithScaleSet(scaleSet)
                .CreateAsync();

            #endregion

        }

        private static string GeneratePassword(int length)
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
