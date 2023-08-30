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
         *   - Create a virtual machine using MSI credentials from System assigned or User Assigned MSI enabled VM.
         */
        public static void Main(string[] args)
        {
            // This sample required to be run from a MSI (User Assigned or System Assigned) enabled virtual machine with role
            // based contributor access to the resource group specified as the second command line argument.
            //
            // see https://github.com/Azure-Samples/compute-dotnet-manage-user-assigned-msi-enabled-virtual-machine.git
            //
            string usage = "Usage: dotnet run <subscription-id> <rg-name> [<client-id>]";
            if (args.Length < 2)
            {
                throw new ArgumentException(usage);
            }

            string subscriptionId = args[0];
            string resourceGroupName = args[1];
            string clientId = args.Length > 2 ? args[2] : null;
            Region region = Region.USWestCentral;
            string linuxVMName = SdkContext.RandomResourceName("vm", 30);
            string userName = Utilities.CreateUsername();
            string password = Utilities.CreatePassword();

            //=============================================================
            // MSI Authenticate

            AzureCredentials msiCredentails = new AzureCredentials(new MSILoginInformation(MSIResourceType.VirtualMachine)
            {
                UserAssignedIdentityClientId = clientId
            }, AzureEnvironment.AzureGlobalCloud);

            var azure = Azure
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                .Authenticate(msiCredentails)
                .WithDefaultSubscription();

            Console.WriteLine("Selected subscription: " + azure.SubscriptionId);

            //=============================================================
            // Create a Linux VM using MSI credentials

            Console.WriteLine("Creating a Linux VM using MSI credentials");

            var virtualMachine = azure.VirtualMachines
                    .Define(linuxVMName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(resourceGroupName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                    .WithRootUsername(userName)
                    .WithRootPassword(password)
                    .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                    .Create();

            Console.WriteLine($"Created virtual machine using MSI credentials: {virtualMachine.Id}");
        }
    }
}
