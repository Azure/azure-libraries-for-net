// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Storage.Fluent;
using System;

namespace ManageStorageAccountNetworkRules
{
    /**
     * Azure Storage sample for managing storage account network rules -
     *  - Create a virtual network and subnet with storage service subnet access enabled
     *  - Create a storage account with access allowed only from the subnet
     *  - Create a public IP address
     *  - Create a virtual machine and associate the public IP address
     *  - Update the storage account with access also allowed from the public IP address
     *  - Update the storage account to restrict incoming traffic to HTTPS.
     */
    public class Program
    {
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgSTMS", 20);
            string networkName = SdkContext.RandomResourceName("nw", 20);
            string subnetName = "subnetA";
            string storageAccountName = SdkContext.RandomResourceName("sa", 15);
            string publicIpName = SdkContext.RandomResourceName("pip", 20);
            string vmName = SdkContext.RandomResourceName("vm", 10);

            try
            {
                // ============================================================
                // Create a virtual network and a subnet with storage service subnet access enabled

                Utilities.Log("Creating a Virtual network and subnet with storage service subnet access enabled:");

                INetwork network = azure.Networks.Define(networkName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithAddressSpace("10.0.0.0/28")
                        .DefineSubnet(subnetName)
                            .WithAddressPrefix("10.0.0.8/29")
                            .WithAccessFromService(ServiceEndpointType.MicrosoftStorage)
                            .Attach()
                        .Create();

                Utilities.Log("Created a Virtual network with subnet:");
                Utilities.PrintVirtualNetwork(network);

                // ============================================================
                // Create a storage account with access to it allowed only from a specific subnet

                var subnetId = $"{network.Id}/subnets/{subnetName}";

                Utilities.Log($"Creating a storage account with access allowed only from the subnet{subnetId}");

                IStorageAccount storageAccount = azure.StorageAccounts.Define(storageAccountName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithAccessFromSelectedNetworks()
                        .WithAccessFromNetworkSubnet(subnetId)
                        .Create();

                Utilities.Log("Created storage account:");
                Utilities.PrintStorageAccount(storageAccount);


                // ============================================================
                // Create a public IP address

                Utilities.Log("Creating a Public IP address");

                IPublicIPAddress publicIPAddress = azure.PublicIPAddresses
                        .Define(publicIpName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithLeafDomainLabel(publicIpName)
                        .Create();

                Utilities.Log("Created Public IP address:");
                Utilities.PrintIPAddress(publicIPAddress);

                // ============================================================
                // Create a virtual machine and associate the public IP address

                Utilities.Log("Creating a VM with the Public IP address");

                IVirtualMachine linuxVM = azure.VirtualMachines
                        .Define(vmName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.1.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithExistingPrimaryPublicIPAddress(publicIPAddress)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(Utilities.CreateUsername())
                        .WithRootPassword(Utilities.CreatePassword())
                        .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                        .Create();

                Utilities.Log($"Created the VM: {linuxVM.Id}");
                Utilities.PrintVirtualMachine(linuxVM);

                publicIPAddress.Refresh();  // Refresh public IP resource to populate the assigned IPv4 address

                // ============================================================
                // Update the storage account so that it can also be accessed from the PublicIP address

                Utilities.Log($"Updating storage account with access also allowed from publicIP{publicIPAddress.IPAddress}");

                storageAccount.Update()
                        .WithAccessFromIpAddress(publicIPAddress.IPAddress)
                        .Apply();

                Utilities.Log("Updated storage account:");
                Utilities.PrintStorageAccount(storageAccount);

                // ============================================================
                //  Update the storage account to restrict incoming traffic to HTTPS

                Utilities.Log("Restricting access to storage account only via HTTPS");

                storageAccount.Update()
                        .WithOnlyHttpsTraffic()
                        .Apply();

                Utilities.Log("Updated the storage account:");
                Utilities.PrintStorageAccount(storageAccount);
            }
            finally
            {
                if (azure.ResourceGroups.GetByName(rgName) != null)
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                else
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}
