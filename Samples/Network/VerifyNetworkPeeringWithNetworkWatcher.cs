// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace VerifyNetworkPeeringWithNetworkWatcher
{
    public class Program
    {
        /**
         * Azure Network sample for enabling and updating network peering between two virtual networks
         *
         * Summary ...
         *
         * - This sample uses Azure Network Watcher's connectivity check to verify connectivity between
         *   two peered virtual networks.
         *
         * Details ...
         *
         * 1. Define two virtual networks network "A" and network "B" with one subnet each
         *
         * 2. Create two virtual machines, each within a separate network
         *   - The virtual machines currently must use a special extension to support Network Watcher

         * 3. Peer the networks...
         *   - the peering will initially have default settings:
         *   - each network's IP address spaces will be accessible from the other network
         *   - no traffic forwarding will be enabled between the networks
         *   - no gateway transit between one network and the other will be enabled
         *
         * 4. Use Network Watcher to check connectivity between the virtual machines in different peering scenarios:
         *   - both virtual machines accessible to each other (bi-directional)
         *   - virtual machine A accessible to virtual machine B, but not the other way
         */

        public static void RunSample(IAzure azure)
        {
            Region region = Region.USEast;
            string resourceGroupName =  SdkContext.RandomResourceName("rg", 15);
            string vnetAName = SdkContext.RandomResourceName("net", 15);
            string vnetBName = SdkContext.RandomResourceName("net", 15);

            string[] vmNames = SdkContext.RandomResourceNames("vm", 15, 2);
            string[] vmIPAddresses = new String[] {
                /* within subnetA */ "10.0.0.8",
                /* within subnetB */ "10.1.0.8"
            };

            string peeringABName = SdkContext.RandomResourceName("peer", 15);
            string rootname = Utilities.CreateUsername();
            string password = SdkContext.RandomResourceName("pWd!", 15);
            string networkWatcherName = SdkContext.RandomResourceName("netwch", 20);

            try
            {
                //=============================================================
                // Define two virtual networks to peer and put the virtual machines in, at specific IP addresses

                List<ICreatable<INetwork>> networkDefinitions = new List<ICreatable<INetwork>>();
                networkDefinitions.Add(azure.Networks.Define(vnetAName)
                        .WithRegion(region)
                        .WithNewResourceGroup(resourceGroupName)
                        .WithAddressSpace("10.0.0.0/27")
                        .WithSubnet("subnetA", "10.0.0.0/27"));

                networkDefinitions.Add(azure.Networks.Define(vnetBName)
                        .WithRegion(region)
                        .WithNewResourceGroup(resourceGroupName)
                        .WithAddressSpace("10.1.0.0/27")
                        .WithSubnet("subnetB", "10.1.0.0/27"));

                //=============================================================
                // Define a couple of Windows VMs and place them in each of the networks

                List<ICreatable<IVirtualMachine>> vmDefinitions = new List<ICreatable<IVirtualMachine>>();

                for (int i = 0; i < networkDefinitions.Count; i++)
                {
                    vmDefinitions.Add(azure.VirtualMachines.Define(vmNames[i])
                        .WithRegion(region)
                        .WithExistingResourceGroup(resourceGroupName)
                        .WithNewPrimaryNetwork(networkDefinitions[i])
                        .WithPrimaryPrivateIPAddressStatic(vmIPAddresses[i])
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
                        .WithAdminUsername(rootname)
                        .WithAdminPassword(password)

                        // Extension currently needed for network watcher support
                        .DefineNewExtension("packetCapture")
                            .WithPublisher("Microsoft.Azure.NetworkWatcher")
                            .WithType("NetworkWatcherAgentWindows")
                            .WithVersion("1.4")
                            .Attach());
                }

                // Create the VMs in parallel for better performance
                Utilities.Log("Creating virtual machines and virtual networks...");
                var createdVMs = azure.VirtualMachines.Create(vmDefinitions);
                IVirtualMachine vmA = createdVMs.FirstOrDefault(vm => vm.Key == vmDefinitions[0].Key);
                IVirtualMachine vmB = createdVMs.FirstOrDefault(vm => vm.Key == vmDefinitions[1].Key);
                Utilities.Log("Created the virtual machines and networks.");

                //=============================================================
                // Peer the two networks using default settings

                INetwork networkA = vmA.GetPrimaryNetworkInterface().PrimaryIPConfiguration.GetNetwork();
                INetwork networkB = vmB.GetPrimaryNetworkInterface().PrimaryIPConfiguration.GetNetwork();

                Utilities.PrintVirtualNetwork(networkA);
                Utilities.PrintVirtualNetwork(networkB);

                Utilities.Log(
                        "Peering the networks using default settings...\n"
                        + "- Network access enabled\n"
                        + "- Traffic forwarding disabled\n"
                        + "- Gateway use (transit) by the remote network disabled");

                INetworkPeering peeringAB = networkA.Peerings.Define(peeringABName)
                        .WithRemoteNetwork(networkB)
                        .Create();

                Utilities.PrintVirtualNetwork(networkA);
                Utilities.PrintVirtualNetwork(networkB);

                //=============================================================
                // Check connectivity between the two VMs/networks using Network Watcher
                INetworkWatcher networkWatcher = azure.NetworkWatchers.Define(networkWatcherName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(resourceGroupName)
                        .Create();

                // Verify bi-directional connectivity between the VMs on port 22 (SSH enabled by default on Linux VMs)
                IExecutable<IConnectivityCheck> connectivityAtoB = networkWatcher.CheckConnectivity()
                    .ToDestinationAddress(vmIPAddresses[1])
                    .ToDestinationPort(22)
                    .FromSourceVirtualMachine(vmA);
                Utilities.Log("Connectivity from A to B: " + connectivityAtoB.Execute().ConnectionStatus);

                IExecutable<IConnectivityCheck> connectivityBtoA = networkWatcher.CheckConnectivity()
                    .ToDestinationAddress(vmIPAddresses[0])
                    .ToDestinationPort(22)
                    .FromSourceVirtualMachine(vmB);
                Utilities.Log("Connectivity from B to A: " + connectivityBtoA.Execute().ConnectionStatus);

                // Change the peering to allow access between A and B
                Utilities.Log("Changing the peering to disable access between A and B...");
                peeringAB.Update()
                    .WithoutAccessFromEitherNetwork()
                    .Apply();

                Utilities.PrintVirtualNetwork(networkA);
                Utilities.PrintVirtualNetwork(networkB);

                // Verify connectivity no longer possible between A and B
                Utilities.Log("Peering configuration changed.\nNow, A should be unreachable from B, and B should be unreachable from A...");
                Utilities.Log("Connectivity from A to B: " + connectivityAtoB.Execute().ConnectionStatus);
                Utilities.Log("Connectivity from B to A: " + connectivityBtoA.Execute().ConnectionStatus);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + resourceGroupName);
                    azure.ResourceGroups.BeginDeleteByName(resourceGroupName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception ex)
                {
                    Utilities.Log(ex);
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

                var azure = Azure.Configure()
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