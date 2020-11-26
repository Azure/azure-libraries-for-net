// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageZonalVirtualMachine
{
    public class Program
    {
        /**
         * Azure Compute sample for managing virtual machines -
         *  - Create a zonal virtual machine with implicitly zoned related resources (PublicIP, Disk)
         *  - Creates a zonal PublicIP address
         *  - Creates a zonal managed data disk
         *  - Create a zonal virtual machine and associate explicitly created zonal PublicIP and data disk.
         */
        public static void RunSample(IAzure azure)
        {
            var region = Region.USEast2;
            var rgName = Utilities.CreateRandomName("rgCOMV");
            var vmName1 = Utilities.CreateRandomName("lVM1");
            var vmName2 = Utilities.CreateRandomName("lVM2");
            var pipName1 = Utilities.CreateRandomName("pip1");
            var pipName2 = Utilities.CreateRandomName("pip2");
            var diskName = Utilities.CreateRandomName("ds");
            var userName = Utilities.CreateUsername();
            var password = Utilities.CreatePassword();
            
            try
            {
                //=============================================================
                // Create a Linux VM in an availability zone

                Utilities.Log("Creating a zonal VM with implicitly zoned related resources (PublicIP, Disk)");

                var virtualMachine1 = azure.VirtualMachines
                        .Define(vmName1)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithNewPrimaryPublicIPAddress(pipName1)
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername(userName)
                            .WithRootPassword(password)
                            // Optional
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_1)
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                            // Create VM
                            .Create();

                Utilities.Log("Created a zonal virtual machine: " + virtualMachine1.Id);

                //=============================================================
                // Create a zonal PublicIP address

                Utilities.Log("Creating a zonal public ip address");

                var publicIPAddress = azure.PublicIPAddresses
                        .Define(pipName2)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        // Optional
                        .WithAvailabilityZone(AvailabilityZoneId.Zone_1)
                        .WithStaticIP()
                        .WithSku(PublicIPSkuType.Standard)
                        // Create PIP
                        .Create();

                Utilities.Log("Created a zonal public ip address: " + publicIPAddress.Id);

                //=============================================================
                // Create a zonal managed data disk

                Utilities.Log("Creating a zonal data disk");

                var dataDisk = azure.Disks
                        .Define(diskName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(rgName)
                            .WithData()
                            .WithSizeInGB(100)
                            // Optional
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_1)
                            // Create Disk
                            .Create();

                Utilities.Log("Created a zoned managed data disk: " + dataDisk.Id);

                //=============================================================
                // Create a zonal virtual machine with zonal public ip and data disk

                Utilities.Log("Creating a zonal VM with implicitly zoned related resources (PublicIP, Disk)");

                var virtualMachine2 = azure.VirtualMachines
                        .Define(vmName2)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithExistingPrimaryPublicIPAddress(publicIPAddress)
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername(userName)
                            .WithRootPassword(password)
                            // Optional
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_1)
                            .WithExistingDataDisk(dataDisk)
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                            // Create VM
                            .Create();

                Utilities.Log("Created a zoned virtual machine: " + virtualMachine2.Id);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception g)
                {
                    Utilities.Log(g);
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=============================================================
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
