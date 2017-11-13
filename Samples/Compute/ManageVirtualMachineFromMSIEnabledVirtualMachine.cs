// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageVirtualMachineFromMSIEnabledVirtualMachine
{
    public class Program
    {
        /**
         * Azure Compute sample for managing virtual machine from Managed Service Identity (MSI) enabled virtual machine -
         *   - Create a virtual machine using MSI credentials from MSI enabled VM
         *   - Delete the virtual machine using MSI credentials from MSI enabled VM.
         *   
         * Automation testing cannot be enabled for this sample since it can be run only from an Azure virtual machine 
         * with MSI enabled.
         */
        public static void Main(string[] args)
        {
            var rgName = "msi-rg-test";
            var region = Region.USWestCentral;

            // This sample required to be run from a MSI enabled virtual machine with role
            // based contributor access to the resource group with name "msi-rg-test". MSI
            // enabled VM can be created using service principal credentials as shown below.

            //var credFile = Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION");
            //IAzure azure = Azure.Authenticate(credFile).WithDefaultSubscription();

            //var virtualMachine = azure.VirtualMachines
            //    .Define("<vm-name>")
            //    .WithRegion(region)
            //    .WithNewResourceGroup(rgName)
            //    .WithNewPrimaryNetwork("10.0.0.0/28")
            //    .WithPrimaryPrivateIPAddressDynamic()
            //    .WithNewPrimaryPublicIPAddress(pipName)
            //    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
            //    .WithRootUsername("<user-name>")
            //    .WithRootPassword("<password>")
            //    .WithSize(VirtualMachineSizeTypes.StandardDS2V2)
            //    .WithOSDiskCaching(CachingTypes.ReadWrite)
            //    .WithManagedServiceIdentity()                                       // Enable MSI
            //    .WithRoleBasedAccessToCurrentResourceGroup(BuiltInRole.Contributor) // With MSI Role assignment to current resource group
            //    .Create();

            // Specify your subscription Id
            string subscriptionId = "<subscription-id>";
            var linuxVmName = Utilities.CreateRandomName("VM1");
            var userName = "tirekicker";
            var password = "12NewPA$$w0rd!";

            //=============================================================
            // MSI Authenticate

            AzureCredentials credentials = new AzureCredentials(new MSILoginInformation { Port = 50342 }, AzureEnvironment.AzureGlobalCloud);

            IAzure azure = Azure.Authenticate(credentials)
                .WithSubscription(subscriptionId);

            //=============================================================
            // Create a Linux VM using MSI credentials

            Console.WriteLine("Creating a Linux VM using MSI credentials");

            var virtualMachine = azure.VirtualMachines
                    .Define(linuxVmName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                    .WithRootUsername(userName)
                    .WithRootPassword(password)
                    .WithSize(VirtualMachineSizeTypes.StandardDS2V2)
                    .WithOSDiskCaching(CachingTypes.ReadWrite)
                    .Create();

            Console.WriteLine("Created virtual machine using MSI credentials");
            Utilities.PrintVirtualMachine(virtualMachine);

            //=============================================================
            // Delete the VM using MSI credentials

            Console.WriteLine("Deleting the virtual machine using MSI credentials");

            azure.VirtualMachines.DeleteById(virtualMachine.Id);

            Console.WriteLine("Deleted virtual machine");
        }
    }
}
