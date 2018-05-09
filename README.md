[![Build Status](https://travis-ci.org/Azure/azure-libraries-for-net.svg?style=flat-square&label=build&branch=master)](https://travis-ci.org/Azure/azure-libraries-for-net)

# Azure Management Libraries for .NET

This README is based on the released stable version (1.10). If you are looking for other releases, see [More Information](#more-information)

The Azure Management Libraries for .NET is a higher-level, object-oriented API for managing Azure resources. Libraries are built on the lower-level, request-response style [auto generated clients](https://github.com/Azure/azure-sdk-for-net/tree/AutoRest) and can run side-by-side with [auto generated clients](https://github.com/Azure/azure-sdk-for-net/tree/AutoRest).

## Table of contents
* [Feature availability and road map](#feature-availability-and-road-map)
* [Code snippets and samples](#code-snippets-and-samples)
  * [Virtual machines](#virtual-machines)
  * [Networking](#networking)
  * [Application services](#application-services)
  * [Databases and storage](#databases-and-storage)
  * [Others...](#other-code-samples)
* [Download](#download)
* [Prerequisites](#prerequisites)
* [Updgrading from older versions](#upgrading-from-older-versions)
* [Help and issues](#help-and-issues)
* [Contribute code](#contribute-code)
* [More information](#more-information)

## Feature Availability and Road Map
:triangular_flag_on_post: *as of Version 1.10*

<table>
  <tr>
    <th align="left">Service | feature</th>
    <th align="left">Available as GA</th>
    <th align="left">Available as Preview</th>
    <th align="left">Coming soon</th>
  </tr>
  <tr>
    <td>Compute</td>
    <td>Virtual machines and VM extensions<br>Virtual machine scale sets<br>Managed disks</td>
    <td valign="top">Azure container service (AKS) + registry + instances<br>Availability Zones</td>
    <td valign="top">More Availability Zones and MSI features</td>
  </tr>
  <tr>
    <td>Storage</td>
    <td>Storage accounts<br>Encryption (<i>deprecated</i>)</td>
    <td>Encryption (Blob)<br>Encryption (File)</td>
    <td></td>
  </tr>
  <tr>
    <td>SQL Database</td>
    <td>Databases<br>Firewalls and virtual network<br>Elastic pools<br>Import, export, recover and restore dbs<br>Failover groups and replication links<br>DNS aliasing and metrics<br>Sync groups<br>Encryption protectors</td>
    <td></td>
    <td valign="top">More features</td>
  </tr>
  <tr>
    <td>Networking</td>
    <td>Virtual networks<br>Network interfaces<br>IP addresses<br>Routing table<br>Network security groups<br>Load balancers<br>Application gateways<br>DNS<br>Traffic managers</td>
    <td valign="top">Network peering<br>Virtual Network Gateway<br>Network watchers<br>Express Route</td>
    <td valign="top">VPN<br>More application gateway features</td>
  </tr>
  <tr>
    <td>More services</td>
    <td>Resource Manager<br>Key Vault<br>Redis<br>CDN<br>Batch<br>Service bus</td>
    <td valign="top">Web apps<br>Function Apps<br>Graph RBAC<br>Cosmos DB<br>Monitor<br>Batch AI<br>Search<br>Event Hub</td>
    <td valign="top">Data Lake<br>More Monitor features<br>Logic Apps<br>Event Grid</td>
  </tr>
  <tr>
    <td>Fundamentals</td>
    <td>Authentication - core<br>Async methods<br>Managed Service Identity</td>
    <td></td>
    <td valign="top"></td>
  </tr>
</table>

> *Preview* features are flagged in documentation comments in libraries. These features are subject to change. They can be modified in any way, or even removed, in the future.

## Code snippets and samples

### Azure Authentication

The `Azure` class is the simplest entry point for creating and interacting with Azure resources.

```csharp
IAzure azure = Azure.Authenticate(credFile).WithDefaultSubscription();
``` 
To learn more about authentication in the Azure Libraries for .Net, see [AUTH.md](AUTH.md).

### Virtual Machines

#### Create a Virtual Machine

You can create a virtual machine instance by using a `Define() … Create()` method chain.

```csharp
Console.WriteLine("Creating a Windows VM");

var windowsVM = azure.VirtualMachines.Define("myWindowsVM")
    .WithRegion(Region.USEast)
    .WithNewResourceGroup(rgName)
    .WithNewPrimaryNetwork("10.0.0.0/28")
    .WithPrimaryPrivateIPAddressDynamic()
    .WithNewPrimaryPublicIPAddress("mywindowsvmdns")
    .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
    .WithAdminUsername("tirekicker")
    .WithAdminPassword(password)
    .WithSize(VirtualMachineSizeTypes.StandardD3V2)
    .Create();
	
Console.WriteLine("Created a Windows VM: " + windowsVM.Id);
```

#### Update a Virtual Machine

You can update a virtual machine instance by using an `Update() … Apply()` method chain.

```csharp
windowsVM.Update()
    .WithNewDataDisk(20, lun, CachingTypes.ReadWrite)
    .Apply();
```
#### Create a Virtual Machine Scale Set

You can create a virtual machine scale set instance by using another `Define() … Create()` method chain.

```csharp
var virtualMachineScaleSet = azure.VirtualMachineScaleSets.Define(vmssName)
    .WithRegion(Region.USEast)
    .WithExistingResourceGroup(rgName)
    .WithSku(VirtualMachineScaleSetSkuTypes.StandardD3v2)
    .WithExistingPrimaryNetworkSubnet(network, "Front-end")
    .WithPrimaryInternetFacingLoadBalancer(loadBalancer1)
    .WithPrimaryInternetFacingLoadBalancerBackends(backendPoolName1, backendPoolName2)
    .WithPrimaryInternetFacingLoadBalancerInboundNatPools(natPool50XXto22, natPool60XXto23)
    .WithoutPrimaryInternalLoadBalancer()
    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
    .WithRootUsername(userName)
    .WithSsh(sshKey)
    .WithNewDataDisk(100)
    .WithNewDataDisk(100, 1, CachingTypes.ReadWrite)
    .WithNewDataDisk(100, 2, CachingTypes.ReadWrite, StorageAccountTypes.StandardLRS)
    .WithCapacity(3)
    .Create();
```

#### Ready-to-run code samples for virtual machines

<table>
  <tr>
    <th>Service</th>
    <th>Management Scenario</th>
  </tr>
  <tr>
    <td>Virtual Machines</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-vm">Manage virtual machines</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-vm-async">Manage virtual machines asynchronously</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-availability-sets"> Manage availability set</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-list-vm-images">List virtual machine images</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-virtual-machine-using-vm-extensions">Manage virtual machines using VM extensions</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-list-vm-extension-images">List virtual machine extension images</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-create-virtual-machines-from-generalized-image-or-specialized-vhd">Create virtual machines from generalized image or specialized VHD</a></li>
<li><a href="https://github.com/Azure-Samples/managed-disk-dotnet-create-virtual-machine-using-custom-image">Create virtual machine using custom image from virtual machine</a></li>
<li><a href="https://github.com/Azure-Samples/managed-disk-dotnet-create-virtual-machine-using-custom-image-from-VHD">Create virtual machine using custom image from VHD</a></li>
<li><a href="https://github.com/Azure-Samples/managed-disk-dotnet-create-virtual-machine-using-specialized-disk-from-VHD">Create virtual machine by importing a specialized operating system disk VHD</a></li>
<li><a href="https://github.com/Azure-Samples/managed-disk-dotnet-create-virtual-machine-using-specialized-disk-from-snapshot">Create virtual machine using specialized VHD from snapshot</a></li>
<li><a href="https://github.com/Azure-Samples/managed-disk-dotnet-convert-existing-virtual-machines-to-use-managed-disks">Convert virtual machines to use managed disks</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-virtual-machine-with-unmanaged-disks">Manage virtual machine with unmanaged disks</a></li>
<li><a href="https://github.com/Azure-Samples/aad-dotnet-manage-resources-from-vm-with-msi">Manage Azure resources from a virtual machine with system assigned managed service identity (MSI)</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-vm-from-vm-with-msi-credentials">Manage Azure resources from a virtual machine with managed service identity (MSI) credentials</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-user-assigned-msi-enabled-virtual-machine">Manage Azure resources from a virtual machine with system assigned managed service identity (MSI)</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-vms-in-availability-zones">Manage virtual machines in availability zones</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-vmss-in-availability-zones">Manage virtual machine scale sets in availability zones</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-list-compute-skus">List compute SKUs</a></li>
</ul></td>
  </tr>
  <tr>
    <td>Virtual Machines - parallel execution</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/azure-samples/compute-dotnet-manage-virtual-machines-in-parallel">Create multiple virtual machines in parallel</a></li>
<li><a href="https://github.com/azure-samples/compute-dotnet-manage-virtual-machines-with-network-in-parallel">Create multiple virtual machines with network in parallel</a></li>
<li><a href="https://github.com/azure-samples/compute-dotnet-create-virtual-machines-across-regions-in-parallel">Create multiple virtual machines across regions in parallel</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-create-vms-async-tracking-related-resources">Create multiple virtual machines in parallel and track related resources</li>
</ul></td>
  </tr>
  <tr>
    <td>Virtual Machine Scale Sets</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-virtual-machine-scale-sets">Manage virtual machine scale sets (behind an Internet facing load balancer)</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-virtual-machine-scale-sets-async">Manage virtual machine scale sets (behind an Internet facing load balancer) asynchronously</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-virtual-machine-scale-set-with-unmanaged-disks">Manage virtual machine scale sets with unmanaged disks</a></li>
</ul></td>
  </tr>	
</table>

### Networking 

#### Create a virtual network

You can create a virtual network by using a `define() … create()` method chain.

```csharp
var network = networks.Define("mynetwork")
	.WithRegion(Region.USEast)
	.WithNewResourceGroup()
	.WithAddressSpace("10.0.0.0/28")
	.WithSubnet("subnet1", "10.0.0.0/29")
	.WithSubnet("subnet2", "10.0.0.8/29")
	.Create();
```

#### Create a Network Security Group

You can create a network security group instance by using another `Define() … Create()` method chain.

```csharp
var frontEndNSG = azure.NetworkSecurityGroups.Define(frontEndNSGName)
    .WithRegion(Region.USEast)
    .WithNewResourceGroup(rgName)
    .DefineRule("ALLOW-SSH")
        .AllowInbound()
        .FromAnyAddress()
        .FromAnyPort()
        .ToAnyAddress()
        .ToPort(22)
        .WithProtocol(SecurityRuleProtocol.Tcp)
        .WithPriority(100)
        .WithDescription("Allow SSH")
        .Attach()
    .DefineRule("ALLOW-HTTP")
        .AllowInbound()
        .FromAnyAddress()
        .FromAnyPort()
        .ToAnyAddress()
        .ToPort(80)
        .WithProtocol(SecurityRuleProtocol.Tcp)
        .WithPriority(101)
        .WithDescription("Allow HTTP")
        .Attach()
    .Create();
```

#### Create an Application Gateway

You can create a application gateway instance by using another `define() … create()` method chain.

```csharp
var applicationGateway = azure.ApplicationGateways.Define("myFirstAppGateway")
    .WithRegion(Region.USEast)
    .WithExistingResourceGroup(resourceGroup)
    // Request routing rule for HTTP from public 80 to public 8080
    .DefineRequestRoutingRule("HTTP-80-to-8080")
        .FromPublicFrontend()
        .FromFrontendHttpPort(80)
        .ToBackendHttpPort(8080)
        .ToBackendIPAddress("11.1.1.1")
        .ToBackendIPAddress("11.1.1.2")
        .ToBackendIPAddress("11.1.1.3")
        .ToBackendIPAddress("11.1.1.4")
        .Attach()
    .WithExistingPublicIPAddress(publicIpAddress)
    .Create();
```

#### Ready-to-run code samples for networking

<table>
  <tr>
    <th>Service</th>
    <th>Management Scenario</th>
  </tr>
  <tr>
    <td>Networking</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-virtual-network">Manage virtual network</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-virtual-network-async">Manage virtual network asynchronously</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-network-interface">Manage network interface</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-network-security-group">Manage network security group</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-ip-address">Manage IP address</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-internet-facing-load-balancers">Manage Internet facing load balancers</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-internal-load-balancers">Manage internal load balancers</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-create-simple-internet-facing-load-balancer">Create simple Internet facing load balancer</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-use-new-watcher">Use net watcher</a>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-network-peering">Manage network peering between two virtual networks</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-use-network-watcher-to-check-connectivity">Use network watcher to check connectivity between virtual machines in peered networks</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-virtual-network-with-site-to-site-vpn-connection">Manage virtual network with site-to-site VPN connection</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-virtual-network-to-virtual-network-vpn-connection">Manage virtual network to virtual network VPN connection</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-vpn-client-connection">Manage client to virtual network VPN connection</a></li>
</ul>
</td>
  </tr>
  <tr>
    <td>DNS</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/dns-dotnet-host-and-manage-your-domains">Host and manage domains</a></li>
</ul></td>
  </tr>
  <tr>
    <td>Traffic Manager</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/traffic-manager-dotnet-manage-profiles">Manage traffic manager profiles</a></li>
</ul></td>
  </tr>
  <tr>
    <td>Application Gateway</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/application-gateway-dotnet-manage-simple-application-gateways">Manage application gateways</a></li>
<li><a href="https://github.com/Azure-Samples/application-gateway-dotnet-manage-application-gateways">Manage application gateways with backend pools</a></li>
</ul></td>
  </tr>
  <tr>
    <td>Express Route</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-express-route">Create and configure Express Route</a></li>
</ul></td>
  </tr>
</table>  

### Application Services

#### Create a Web App

You can create a Web App instance by using another `define() … create()` method chain.

```csharp
var webApp = azure.WebApps.Define(appName)
    .WithRegion(Region.USWest)
    .WithNewResourceGroup(rgName)
    .WithNewWindowsPlan(PricingTier.StandardS1)
    .Create();
```

#### Ready-to-run code samples for Application Services

<table>
  <tr>
    <th>Service</th>
    <th>Management Scenario</th>
  </tr>
  <tr>
    <td>Web Apps on <b>Windows</b></td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-web-apps">Manage Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-web-apps-with-custom-domains">Manage Web apps with custom domains</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-configure-deployment-sources-for-web-apps">Configure deployment sources for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-configure-deployment-sources-for-web-apps-async">Configure deployment sources for Web apps asynchronously</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-staging-and-production-slots-for-web-apps">Manage staging and production slots for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-scale-web-apps">Scale Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-storage-connections-for-web-apps">Manage storage connections for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-data-connections-for-web-apps">Manage data connections (such as SQL database and Redis cache) for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-authentication-for-web-apps">Manage authentication for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-access-key-vault-by-msi-for-web-apps">Safegaurd Web app secrets in Key Vault</a></li>
</ul></td>
  </tr>
  <tr>
    <td> Web Apps on <b>Linux</b></td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-web-apps-on-linux">Manage Web apps</a></li>
<!-- <li><a href="https://github.com/Azure-Samples/app-service-dotnet-deploy-image-from-acr-to-linux">Deploy a container image from Azure Container Registry to Linux containers</a></li> -->
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-web-apps-on-linux-with-custom-domains">Manage Web apps with custom domains</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-configure-deployment-sources-for-web-apps-on-linux">Configure deployment sources for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-scale-web-apps-on-linux">Scale Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-storage-connections-for-web-apps-on-linux">Manage storage connections for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-data-connections-for-web-apps-on-linux">Manage data connections (such as SQL database and Redis cache) for Web apps</a></li>
</ul></td>
  </tr>
  <tr>
    <td>Functions</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-functions">Manage functions</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-functions-with-custom-domains">Manage functions with custom domains</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-configure-deployment-sources-for-functions">Configure deployment sources for functions</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-authentication-for-functions">Manage authentication for functions</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-logs-for-function-apps">Get function logs</a></li>
</ul></td>
  </tr>
</table>  

### Databases and Storage

#### Create a Cosmos DB with CosmosDB Programming Model

You can create a Cosmos DB account by using a `define() … create()` method chain.

```csharp
var documentDBAccount = azure.CosmosDBAccounts.Define(cosmosDBName)
    .WithRegion(Region.USEast)
    .WithNewResourceGroup(rgName)
    .WithKind(DatabaseAccountKind.GlobalDocumentDB)
    .WithSessionConsistency()
    .WithWriteReplication(Region.USWest)
    .WithReadReplication(Region.USCentral)
    .Create();
```

#### Create a SQL Database

You can create a SQL server instance by using another `define() … create()` method chain.

```csharp
var sqlServer = azure.SqlServers.Define(sqlServerName)
    .WithRegion(Region.USEast)
    .WithNewResourceGroup(rgName)
    .WithAdministratorLogin(administratorLogin)
    .WithAdministratorPassword(administratorPassword)
    .WithNewFirewallRule(firewallRuleIpAddress)
    .WithNewFirewallRule(firewallRuleStartIpAddress, firewallRuleEndIpAddress)
    .Create();
```

Then, you can create a SQL database instance by using another `define() … create()` method chain.

```csharp
var database = sqlServer.Databases.Define(databaseName)
    .Create();
```

#### Ready-to-run code samples for databases

<table>
  <tr>
    <th>Service</th>
    <th>Management Scenario</th>
  </tr>
  <tr>
    <td>Storage</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/storage-dotnet-manage-storage-accounts">Manage storage accounts</a></li>
<li><a href="https://github.com/Azure-Samples/storage-dotnet-manage-storage-accounts-async">Manage storage accounts asynchronously</a></li>
<li><a href="https://github.com/Azure-Samples/storage-dotnet-manage-storage-account-network-rules">Manage network rules of a storage account</a></li>
</ul></td>
  </tr>
  <tr>
    <td>SQL Database</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-manage-db">Manage SQL databases</a></li>
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-manage-sql-dbs-in-elastic-pool">Manage SQL databases in elastic pools</a></li>
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-manage-firewalls-for-sql-databases">Manage firewalls for SQL databases</a></li>
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-manage-sql-databases-across-regions">Manage SQL databases across regions</a></li>
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-manage-import-export-db">Import and export SQL databases</a></li>
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-manage-recover-restore-db">Restore and recover SQL databases</a></li>
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-get-sql-metrics">Get SQL Database metrics</a></li>
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-manage-failover-groups">Manage SQL Database Failover Groups</a></li>
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-manage-sql-server-dns-aliases">Manage SQL Server DNL aliases</a></li>
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-manage-sql-secrets-in-key-vault">Manage SQL secrets (Server Keys) in Azure Key Vault</a></li>
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-manage-virtual-network-rules">Manage SQL Virtual Network Rules</a></li>
</ul></td>
  </tr>
<tr>
    <td>Cosmos DB</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/cosmosdb-dotnet-create-documentdb-and-configure-for-high-availability">Create a CosmosDB and configure it for high availability</a></li>
<li><a href="https://github.com/Azure-Samples/cosmosdb-dotnet-create-documentdb-and-configure-for-eventual-consistency">Create a CosmosDB and configure it with eventual consistency</a></li>
<li><a href="https://github.com/Azure-Samples/cosmosdb-dotnet-create-documentdb-and-configure-firewall">Create a CosmosDB, configure it for high availability and create a firewall to limit access from an approved set of IP addresses</li>
<li><a href="https://github.com/Azure-Samples/cosmosdb-dotnet-create-documentdb-and-get-mongodb-connection-string">Create a CosmosDB and get MongoDB connection string</li>
</ul></td>
  </tr>
</table>  

### Other code samples

<table>
  <tr>
    <th>Service</th>
    <th>Management Scenario</th>
  </tr>

  <tr>
    <td>Active Directory</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/aad-dotnet-manage-service-principals">Manage service principals using Java</a></li>
<li><a href="https://github.com/Azure-Samples/aad-dotnet-manage-users-groups-and-roles">Manage users and groups and manage their roles</a></li>
<li><a href="https://github.com/Azure-Samples/aad-dotnet-manage-passwords">Manage passwords</li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-resources-from-vm-with-msi-in-aad-group">Manage Azure resources from a managed service identity (MSI) enabled virtual machine that belongs to an Azure Active Directory (AAD) security group</a></li>	
</ul></td>
  </tr>
<tr>
    <td>Container Service<br>Container Registry and <br>Container Instances</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/acr-dotnet-manage-azure-container-registry">Manage container registry</a></li>
<li><a href="https://github.com/Azure-Samples/acr-dotnet-manage-azure-container-registry-with-webhooks">Manage container registry with Web hooks</a></li>
<li><a href="https://github.com/Azure-Samples/aks-dotnet-manage-kubernetes-cluster">Manage Kubernetes cluster (AKS)</a></li>
<li><a href="https://github.com/Azure-Samples/acs-dotnet-manage-azure-container-service-with-kubernetes-orchestrator">Manage container service with Kubernetes orchestration</li>
<li><a href="https://github.com/Azure-Samples/acs-dotnet-manage-azure-container-service-with-docker-swarm-orchestrator">Manage container service with Docker Swarm orchestration</li>
<li><a href="https://github.com/Azure-Samples/aci-dotnet-create-container-groups-using-private-registry">Create Container Group using images from a private registry</li>
<li><a href="https://github.com/Azure-Samples/aci-dotnet-manage-container-instances-1">Manage Azure Container Instances with new Azure File Share</li>
<li><a href="https://github.com/Azure-Samples/aci-dotnet-manage-container-instances-2">Manage Azure Container Instances with an existing Azure File Share</li>
<li><a href="https://github.com/Azure-Samples/aci-dotnet-create-container-groups">Create Container Group with multiple instances and container images</li>
</ul></td>
  </tr>

  <tr>
    <td>Service Bus</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/service-bus-dotnet-manage-queue-with-basic-features">Manage queues with basic features</a></li>
<li><a href="https://github.com/Azure-Samples/service-bus-dotnet-manage-publish-subscribe-with-basic-features">Manage publish-subscribe with basic features</a></li>
<li><a href="https://github.com/Azure-Samples/service-bus-dotnet-manage-with-claims-based-authorization">Manage queues and publish-subcribe with cliams based authorization</a></li>
<li><a href="https://github.com/Azure-Samples/service-bus-dotnet-manage-publish-subscribe-with-advanced-features">Manage publish-subscribe with advanced features - sessions, dead-lettering, de-duplication and auto-deletion of idle entries</a></li>
<li><a href="https://github.com/Azure-Samples/service-bus-dotnet-manage-queue-with-advanced-features">Manage queues with advanced features - sessions, dead-lettering, de-duplication and auto-deletion of idle entries</a></li>
</ul></td>
  </tr>

  <tr>
    <td>Resource Groups</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/resources-dotnet-manage-resource-group">Manage resource groups</a></li>
<li><a href="https://github.com/Azure-Samples/resources-dotnet-manage-resource">Manage resources</a></li>
<li><a href="https://github.com/Azure-Samples/locks-dotnet-manage-locks">Manage resource locks</a></li>
<li><a href="https://github.com/Azure-Samples/resources-dotnet-deploy-using-arm-template">Deploy resources with ARM templates</a></li>
<li><a href="https://github.com/Azure-Samples/resources-dotnet-deploy-using-arm-template-with-progress">Deploy resources with ARM templates (with progress)</a></li>
<li><a href="https://github.com/Azure-Samples/resources-dotnet-deploy-virtual-machine-with-managed-disks-using-arm-template">Deploy a virtual machine with managed disks using an ARM template</a></li>
</ul></td>
  </tr>

  <tr>
    <td>Redis Cache</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/redis-cache-dotnet-manage-cache">Manage Redis Cache</a></li>
</ul></td>
</tr>

  <tr>
    <td>Key Vault</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/key-vault-dotnet-manage-key-vaults">Manage key vaults</a></li>
</ul></td>
  </tr>

  <tr>
    <td>Monitor</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/monitor-dotnet-query-metrics-activitylogs">Get metrics and activity logs for a resource</a></li>
<li><a href="https://github.com/Azure-Samples/eventhub-dotnet-manage-event-hub-events">Stream Azure Service Logs and Metrics for consumption through Event Hub</a></li>
</ul></td>
  </tr>

  <tr>
    <td>CDN</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/cdn-dotnet-manage-cdn">Manage CDNs</a></li>
</ul></td>
  </tr>

  <tr>
    <td>Batch</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/batch-dotnet-manage-batch-accounts">Manage batch accounts</a></li>
</ul></td>
  </tr>
  <tr>
    <td>Batch AI</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/batchai-dotnet-run-batchai-job">Create Batch AI cluster and execute AI job</a></li>
</ul></td>
  </tr>

  <tr>
    <td>Search</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/search-dotnet-manage-search-service">Manage Azure search</a></li>
</ul></td>
  </tr>  
  
  <tr>
    <td>Event Hub</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/eventhub-dotnet-manage-event-hub">Manage event hub and associated resources</a></li>
<li><a href="https://github.com/Azure-Samples/eventhub-dotnet-manage-event-hub-geo-disaster-recovery">Manage event hub geo-disaster recovery</a></li>
<li><a href="https://github.com/Azure-Samples/eventhub-dotnet-manage-event-hub-events">Stream Azure Service Logs and Metrics for consumption through Event Hub</a></li>
</ul></td>
  </tr>
  
</table>

## Download

### Latest stable release

**1.10** release builds are available on NuGet:

|Azure Management Library                     | Package name                                        | Stable                 |
|---------------------------------------------|-----------------------------------------------------|------------------------|
|Azure Management Client (wrapper package)    | `Microsoft.Azure.Management.Fluent`                 | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Fluent/) |
|App Service (Web Apps and Functions)         | `Microsoft.Azure.Management.AppService.Fluent`      | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.AppService.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.AppService.Fluent/) |
|Batch                                        | `Microsoft.Azure.Management.Batch.Fluent`           | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Batch.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Batch.Fluent/) |
|Batch AI                                     | `Microsoft.Azure.Management.BatchAI.Fluent`         | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.BatchAI.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.BatchAI.Fluent/) |
|CDN                                          | `Microsoft.Azure.Management.Cdn.Fluent`             | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Cdn.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Cdn.Fluent/) |
|Virtual Machines, Virtual Machine Scale Sets, Azure Container Services| `Microsoft.Azure.Management.Compute.Fluent`         | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Compute.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Compute.Fluent/) |
|Container Instance                           | `Microsoft.Azure.Management.ContainerInstance.Fluent`| [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.ContainerInstance.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.ContainerInstance.Fluent/) |
|Container Registry                           | `Microsoft.Azure.Management.ContainerRegistry.Fluent`| [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.ContainerRegistry.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.ContainerRegistry.Fluent/) |
|Container Service                            | `Microsoft.Azure.Management.ContainerService.Fluent `| [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.ContainerService.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.ContainerService.Fluent/) |
|Cosmos DB                                    | `Microsoft.Azure.Management.CosmosDB.Fluent`        | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.CosmosDB.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.CosmosDB.Fluent/) |
|DNS                                          | `Microsoft.Azure.Management.Dns.Fluent`             | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Dns.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Dns.Fluent/) |
|EventHub                                     | `Microsoft.Azure.Management.EventHub.Fluent`        | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.EventHub.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.EventHub.Fluent/) |
|Graph RBAC                                   | `Microsoft.Azure.Management.Graph.RBAC.Fluent`      | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Graph.RBAC.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Graph.RBAC.Fluent/) |
|Key Vault                                    | `Microsoft.Azure.Management.KeyVault.Fluent`        | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.KeyVault.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.KeyVault.Fluent/) |
|Locks                                        | `Microsoft.Azure.Management.Locks.Fluent`           | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Locks.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Locks.Fluent/) |
|Monitor                                      | `Microsoft.Azure.Management.Monitor.Fluent`         | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Monitor.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Monitor.Fluent/) |
|Msi                                          | `Microsoft.Azure.Management.Msi.Fluent`             | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Msi.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Msi.Fluent/) |
|Networking                                   | `Microsoft.Azure.Management.Network.Fluent`         | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Network.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Network.Fluent/) |
|Redis Cache                                  | `Microsoft.Azure.Management.Redis.Fluent`           | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Redis.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Redis.Fluent/) |
|Resource Manager                             | `Microsoft.Azure.Management.ResourceManager.Fluent` | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.ResourceManager.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.ResourceManager.Fluent/) |
|Search                                       | `Microsoft.Azure.Management.Search.Fluent`          | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Search.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Search.Fluent/) |
|Service Bus                                  | `Microsoft.Azure.Management.ServiceBus.Fluent`      | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.ServiceBus.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.ServiceBus.Fluent/) |
|SQL Database                                 | `Microsoft.Azure.Management.Sql.Fluent`             | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Sql.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Sql.Fluent/) |
|Storage                                      | `Microsoft.Azure.Management.Storage.Fluent`         | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Storage.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Storage.Fluent/) |
|Traffic Manager                              | `Microsoft.Azure.Management.TrafficManager.Fluent`  | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.TrafficManager.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.TrafficManager.Fluent/) |

---

## Prerequisites

- [.NET Core](https://www.microsoft.com/net/core) 
- Azure Service Principal - see [how to create authentication info](./AUTH.md).

## Upgrading from older versions

If you are migrating your code from 1.9.x to 1.10.x, you can use these release notes for [preparing your code for 1.10 from 1.9](./notes/prepare-for-1.10.md).

In general, Azure Libraries for .Net follow [semantic versioning](http://semver.org/), so user code should continue working in a compatible fashion between minor versions of the same major version release train, with the following caveats:

* methods and types that inherit from `IBeta` interface are not considered "generally available" and their design and functionality may change arbitrarily (including removal) in any future *minor* release of the libraries. To help identify such `IBeta` breaking changes from one minor release to the next and see how to mitigate them, see the above mentioned release notes for each release.

* occasionally the naming and structure of "fluent" interface definitions (i.e. the ones whose names start with `With*`) may change between minor versions, as long as that change does not affect the fluent "flow" (the chaining of the methods in a definition or update chain).

* the `*Inner` types and their methods may occasionally change their naming and structure between minor versions in breaking ways. User code should generally avoid making a reference to those types though, unless their functionality is not yet exposed by the "fluent" API.


## Help and Issues

If you encounter any bugs with these libraries, please file issues via [Issues](https://github.com/Azure/azure-libraries-for-net/issues) or checkout [StackOverflow for Azure Management Libraries for .NET](http://stackoverflow.com/questions/tagged/azure-sdk).

To enable Http message tracing in your code please check [this article](https://github.com/Azure/autorest/blob/master/docs/client/tracing.md#tracing).

## Contribute Code

If you would like to become an active contributor to this project please follow the instructions provided in [Microsoft Azure Projects Contribution Guidelines](http://azure.github.io/guidelines.html).

1. Fork it
2. Create your feature branch (`git checkout -b my-new-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin my-new-feature`)
5. Create new Pull Request

## More Information
* [https://azure.microsoft.com/en-us/develop/net/](https://azure.microsoft.com/en-us/develop/net/)
* If you don't have a Microsoft Azure subscription you can get a FREE trial account [here](http://go.microsoft.com/fwlink/?LinkId=330212).

### Previous Releases and Corresponding Repo Branches

| Version           | SHA1                                                                                      | Remarks                                               |
|-------------------|-------------------------------------------------------------------------------------------|-------------------------------------------------------|
| 1.10              | [1.10](https://github.com/Azure/azure-libraries-for-net/releases/tag/Fluent-v1.10)          | Tagged release for 1.10 version of Azure management libraries |
| 1.9               | [1.9](https://github.com/Azure/azure-libraries-for-net/releases/tag/Fluent-v1.9)          | Tagged release for 1.9 version of Azure management libraries |
| 1.8               | [1.8](https://github.com/Azure/azure-libraries-for-net/releases/tag/Fluent-v1.8)          | Tagged release for 1.8 version of Azure management libraries |
| 1.7               | [1.7](https://github.com/Azure/azure-libraries-for-net/releases/tag/Fluent-v1.7)          | Tagged release for 1.7 version of Azure management libraries |
| 1.6               | [1.6](https://github.com/Azure/azure-libraries-for-net/releases/tag/Fluent-v1.6)          | Tagged release for 1.6 version of Azure management libraries |
| 1.4               | [1.4](https://github.com/Azure/azure-libraries-for-net/releases/tag/Fluent-v1.4)          | Tagged release for 1.4 version of Azure management libraries |
| 1.3               | [1.3](https://github.com/Azure/azure-libraries-for-net/releases/tag/Fluent-v1.3)          | Tagged release for 1.3 version of Azure management libraries |
| 1.2               | [1.2](https://github.com/Azure/azure-sdk-for-net/releases/tag/Fluent-v1.2)                | Tagged release for 1.2 version of Azure management libraries |
| 1.1               | [1.1](https://github.com/Azure/azure-sdk-for-net/releases/tag/Fluent-v1.1)                | Tagged release for 1.1 version of Azure management libraries |
| 1.0               | [1.0](https://github.com/Azure/azure-sdk-for-net/releases/tag/Fluent-v1.0.0-stable)           | Tagged release for 1.0 version of Azure management libraries |
| 1.0.0-beta5       | [1.0.0-beta5](https://github.com/Azure/azure-sdk-for-net/releases/tag/Fluent-v1.0.0-beta5)           | Tagged release for 1.0.0-beta5 version of Azure management libraries |
| 1.0.0-beta4       | [1.0.0-beta4](https://github.com/Azure/azure-sdk-for-net/releases/tag/Fluent-v1.0.0-beta4)           | Tagged release for 1.0.0-beta4 version of Azure management libraries |
| 1.0.0-beta3       | [1.0.0-beta3](https://github.com/Azure/azure-sdk-for-net/releases/tag/Fluent-v1.0.0-beta3)           | Tagged release for 1.0.0-beta3 version of Azure management libraries |
| AutoRest       | [AutoRest](https://github.com/Azure/azure-sdk-for-net/tree/AutoRest)               | Main branch for AutoRest generated raw clients |

---

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
