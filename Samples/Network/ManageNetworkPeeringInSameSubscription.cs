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

namespace ManageNetworkPeeringInSameSubscription
{
    public class Program
    {

        /**
         * Azure Network sample for enabling and updating network peering between two virtual networks
         *
         * Summary ...
         *
         * - This sample creates two virtual networks in the same subscription and then peers them, modifying various options on the peering.
         *
         * Details ...
         *
         * 1. Create two virtual networks, network "A" and network "B"...
         * - network A with two subnets
         * - network B with one subnet
         * - the networks' address spaces must not overlap
         * - the networks must be in the same region
         *
         * 2. Peer the networks...
         * - the peering will initially have default settings:
         *   - each network's IP address spaces will be accessible from the other network
         *   - no traffic forwarding will be enabled between the networks
         *   - no gateway transit between one network and the other will be enabled
         *
         * 3. Update the peering...
         * - disable IP address space between the networks
         * - enable traffic forwarding from network A to network B
         * 
         * 4. Delete the peering
         * - the removal of the peering takes place on both networks, as long as they are in the same subscription
         
         * Notes: 
         * - Once a peering is created, it cannot be pointed at another remote network later.
         * - The address spaces of the peered networks cannot be changed as long as the networks are peered.
         * - Gateway transit scenarios as well as peering networks in different subscriptions are possible but beyond the scope of this sample.
         * - Network peering in reality results in pairs of peering objects: one pointing from one network to the other,
         *   and the other peering object pointing the other way. For simplicity though, the SDK provides a unified way to
         *   manage the peering as a whole, in a single command flow, without the need to duplicate commands for both sides of the peering,
         *   while enforcing the required restrictions between the two peerings automatically, as this sample shows. But it is also possible
         *   to modify each peering separately, which becomes required when working with networks in different subscriptions.
         */
        public static void RunSample(IAzure azure)
        {
            Region region = Region.USEast;
            string resourceGroupName = SdkContext.RandomResourceName("rg", 15);
            string vnetAName = SdkContext.RandomResourceName("net", 15);
            string vnetBName = SdkContext.RandomResourceName("net", 15);
            string peeringABName = SdkContext.RandomResourceName("peer", 15);

            try
            {
                //=============================================================
                // Define two virtual networks to peer

                Utilities.Log("Creating two virtual networks in the same region and subscription...");

                ICreatable<INetwork> networkADefinition = azure.Networks.Define(vnetAName)
                        .WithRegion(region)
                        .WithNewResourceGroup(resourceGroupName)
                        .WithAddressSpace("10.0.0.0/27")
                        .WithSubnet("subnet1", "10.0.0.0/28")
                        .WithSubnet("subnet2", "10.0.0.16/28");

                ICreatable<INetwork> networkBDefinition = azure.Networks.Define(vnetBName)
                        .WithRegion(region)
                        .WithNewResourceGroup(resourceGroupName)
                        .WithAddressSpace("10.1.0.0/27")
                        .WithSubnet("subnet3", "10.1.0.0/27");

                // Create the networks in parallel for better performance
                var created = azure.Networks.Create(networkADefinition, networkBDefinition);

                // Print virtual network details
                foreach (INetwork network in created)
                {
                    Utilities.PrintVirtualNetwork(network);
                    Utilities.Log();
                }

                // Retrieve the created networks using their definition keys
                INetwork networkA = created.FirstOrDefault(n => n.Key == networkADefinition.Key);
                INetwork networkB = created.FirstOrDefault(n => n.Key == networkBDefinition.Key);

                //=============================================================
                // Peer the two networks using default settings

                Utilities.Log(
                        "Peering the networks using default settings...\n"
                        + "- Network access enabled\n"
                        + "- Traffic forwarding disabled\n"
                        + "- Gateway use (transit) by the peered network disabled");

                INetworkPeering peeringAB = networkA.Peerings.Define(peeringABName)
                        .WithRemoteNetwork(networkB)
                        .Create(); // This implicitly creates a matching peering object on network B as well, if both networks are in the same subscription

                // Print network details showing new peering
                Utilities.Log("Created a peering");
                Utilities.PrintVirtualNetwork(networkA);
                Utilities.PrintVirtualNetwork(networkB);

                //=============================================================
                // Update a the peering disallowing access from B to A but allowing traffic forwarding from B to A

                Utilities.Log("Updating the peering ...");
                peeringAB.Update()
                    .WithoutAccessFromEitherNetwork()
                    .WithTrafficForwardingFromRemoteNetwork()
                    .Apply();

                Utilities.Log("Updated the peering to disallow network access between B and A but allow traffic forwarding from B to A.");

                //=============================================================
                // Show the new network information

                Utilities.PrintVirtualNetwork(networkA);
                Utilities.PrintVirtualNetwork(networkB);

                //=============================================================
                // Remove the peering

                Utilities.Log("Deleting the peering from the networks...");
                networkA.Peerings.DeleteById(peeringAB.Id); // This deletes the peering from both networks, if they're in the same subscription
                Utilities.Log("Deleted the peering from both sides.");

                Utilities.PrintVirtualNetwork(networkA);
                Utilities.PrintVirtualNetwork(networkB);
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