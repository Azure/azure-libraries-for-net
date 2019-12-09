// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;

namespace ManagePrivateDns
{
    public class Program
    {
        private const string CustomDomainName = "private.contoso.com";

        /**
         * Azure private DNS sample for managing DNS zones.
         *  - Creates a private DNS zone (private.contoso.com)
         *  - Creates a virtual network
         *  - Link a virtual network
         *  - Creates test virtual machines
         *  - Creates an additional DNS record
         *  - Test the private DNS zone
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgNEMV_", 24);
            string vnName = SdkContext.RandomResourceName("vnetwork1-", 24);
            string subnetName = SdkContext.RandomResourceName("subnet1-", 24);
            string linkName = SdkContext.RandomResourceName("vnlink1-", 24);
            string vm1Name = SdkContext.RandomResourceName("vm1-", 24);
            string vm2Name = SdkContext.RandomResourceName("vm2-", 24);
            string rsName = SdkContext.RandomResourceName("recordset1-", 24);

            try
            {
                var resourceGroup = azure.ResourceGroups.Define(rgName)
                    .WithRegion(Region.AsiaSouthEast)
                    .Create();

                //============================================================
                // Creates a private DNS zone

                Utilities.Log("Creating private DNS zone " + CustomDomainName + "...");
                var privateDnsZone = azure.PrivateDnsZones.Define(CustomDomainName)
                    .WithExistingResourceGroup(resourceGroup)
                    .Create();

                Utilities.Log("Created private DNS zone " + privateDnsZone.Name);
                Utilities.Print(privateDnsZone);

                //============================================================
                // Creates a virtual network

                Utilities.Log("Creating virtual network " + vnName + "...");
                INetwork virtualNetwork = azure.Networks.Define(vnName)
                    .WithRegion(Region.AsiaSouthEast)
                    .WithExistingResourceGroup(resourceGroup)
                    .WithAddressSpace("10.2.0.0/16")
                    .WithSubnet(subnetName, "10.2.0.0/24")
                    .Create();
                Utilities.Log("Created virtual network " + virtualNetwork.Name);

                //============================================================
                // Link a virtual network

                Utilities.Log("Creating virtual network link " + linkName + " within private zone " + privateDnsZone.Name + " ...");
                privateDnsZone.Update()
                    .DefineVirtualNetworkLink(linkName)
                        .EnableAutoRegistration()
                        .WithReferencedVirtualNetworkId(virtualNetwork.Id)
                        .WithETagCheck()
                        .Attach()
                    .Apply();
                Utilities.Log("Linked a virtual network " + virtualNetwork.Id);
                Utilities.Print(privateDnsZone);

                //============================================================
                // Creates test virtual machines

                Utilities.Log("Creating first virtual machine " + vm1Name + "...");
                var virtualMachine1 = azure.VirtualMachines.Define(vm1Name)
                    .WithRegion(Region.AsiaSouthEast)
                    .WithExistingResourceGroup(resourceGroup)
                    .WithExistingPrimaryNetwork(virtualNetwork)
                    .WithSubnet(subnetName)
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012Datacenter)
                    .WithAdminUsername("azureadmin")
                    .WithAdminPassword("Azure12345678")
                    .Create();
                Utilities.Log("Created first virtual machine " + virtualMachine1.Name);
                Utilities.Log("Starting first virtual machine " + virtualMachine1.Name + "...");
                virtualMachine1.Start();
                Utilities.Log("Started first virtual machine " + virtualMachine1.Name);

                Utilities.Log("Creating second virtual machine " + vm2Name + "...");
                var virtualMachine2 = azure.VirtualMachines.Define(vm2Name)
                    .WithRegion(Region.AsiaSouthEast)
                    .WithExistingResourceGroup(resourceGroup)
                    .WithExistingPrimaryNetwork(virtualNetwork)
                    .WithSubnet(subnetName)
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012Datacenter)
                    .WithAdminUsername("Foo12")
                    .WithAdminPassword("BaR@12!Foo")
                    .Create();
                Utilities.Log("Created second virtual machine " + virtualMachine2.Name);
                Utilities.Log("Starting second virtual machine " + virtualMachine2.Name + "...");
                virtualMachine2.Start();
                Utilities.Log("Started second virtual machine " + virtualMachine2.Name);

                //============================================================
                // Creates an additional DNS record
                Utilities.Log("Creating additional record set " + rsName + "...");
                privateDnsZone.Update()
                    .DefineARecordSet(rsName)
                        .WithIPv4Address(virtualMachine1.GetPrimaryNetworkInterface().PrimaryPrivateIP)
                        .Attach()
                    .Apply();
                Utilities.Log("Created additional record set " + rsName);
                Utilities.Print(privateDnsZone);

                //============================================================
                // Test the private DNS zone

                string script1 = "New-NetFirewallRule -DisplayName \"Allow ICMPv4-In\" -Protocol ICMPv4";
                Utilities.Log("Preparing first command: " + script1);
                string script2 = "ping " + virtualMachine1.ComputerName + "." + CustomDomainName;
                Utilities.Log("Preparing second command: " + script2);
                string script3 = "ping " + rsName + "." + CustomDomainName;
                Utilities.Log("Preparing third command: " + script1);

                Utilities.Log("Starting to run command...");
                var result = virtualMachine2.RunPowerShellScript(new List<string> { script1, script2, script3 }, new List<RunCommandInputParameter>());
                foreach (var info in result.Value)
                {
                    Utilities.Log(info.Message);
                }
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (Exception)
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
            catch (Exception e)
            {
                Utilities.Log(e);
            }
        }
    }
}
