// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.CosmosDB.Fluent;
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CosmosDBTableWithVirtualNetworkRule
{
    public class Program
    {
        /**
         * Azure CosmosDB sample for using Virtual Network ACL rules.
         *  - Create a Virtual Network with two subnets.
         *  - Create an Azure Table CosmosDB account configured with a Virtual Network Rule
         *  - Add another virtual network rule in the CosmosDB account
         *  - List all virtual network rules.
         *  - Delete a virtual network.
         *  - Delete the CosmosDB.
         */
        public static void RunSample(IAzure azure)
        {
            string cosmosDBName = SdkContext.RandomResourceName("cosmosdb", 15);
            string rgName = SdkContext.RandomResourceName("rgcosmosdb", 24);
            string vnetName = SdkContext.RandomResourceName("vnetcosmosdb", 20);

            try
            {
                // ============================================================
                // Create a virtual network with two subnets.
                Console.WriteLine("Creating a CosmosDB...");

                var virtualNetwork = azure.Networks.Define(vnetName)
                    .WithRegion(Region.USEast)
                    .WithNewResourceGroup(rgName)
                    .WithAddressSpace("192.168.0.0/16")
                    .DefineSubnet("subnet1")
                        .WithAddressPrefix("192.168.1.0/24")
                        .WithAccessFromService(ServiceEndpointType.MicrosoftAzureCosmosDB)
                        .Attach()
                    .DefineSubnet("subnet2")
                        .WithAddressPrefix("192.168.2.0/24")
                        .WithAccessFromService(ServiceEndpointType.MicrosoftAzureCosmosDB)
                        .Attach()
                    .Create();

                Console.WriteLine("Created a virtual network");
                // Print the virtual network details
                Utilities.PrintVirtualNetwork(virtualNetwork);


                //============================================================
                // Create a CosmosDB
                Console.WriteLine("Creating a CosmosDB...");

                ICosmosDBAccount cosmosDBAccount = azure.CosmosDBAccounts.Define(cosmosDBName)
                        .WithRegion(Region.USWest)
                        .WithExistingResourceGroup(rgName)
                        .WithDataModelAzureTable()
                        .WithEventualConsistency()
                        .WithWriteReplication(Region.USEast)
                        .WithVirtualNetworkRule(virtualNetwork.Id, "subnet1")
                        .Create();

                Console.WriteLine("Created CosmosDB");
                Utilities.Print(cosmosDBAccount);

                // ============================================================
                // Get the virtual network rule created above.

                var vnetRules = cosmosDBAccount.VirtualNetworkRules;

                Console.WriteLine("CosmosDB Virtual Network Rules:");
                foreach (var vnetRule in vnetRules)
                {
                    Console.WriteLine("\t" + vnetRule.Id);
                }


                // ============================================================
                // Add new virtual network rules.

                cosmosDBAccount.Update()
                    .WithVirtualNetworkRule(virtualNetwork.Id, "subnet2")
                    .Apply();


                // ============================================================
                // List then remove all virtual network rules.
                Console.WriteLine("Listing all virtual network rules in CosmosDB account.");

                vnetRules = cosmosDBAccount.VirtualNetworkRules;

                Console.WriteLine("CosmosDB Virtual Network Rules:");
                foreach (var vnetRule in vnetRules)
                {
                    Console.WriteLine("\t" + vnetRule.Id);
                }

                cosmosDBAccount.Update()
                    .WithVirtualNetworkRules(null)
                    .Apply();

                azure.Networks.DeleteById(virtualNetwork.Id);

                //============================================================
                // Delete CosmosDB
                Console.WriteLine("Deleting the CosmosDB");

                // work around CosmosDB service issue returning 404 CloudException on delete operation
                try
                {
                    azure.CosmosDBAccounts.DeleteById(cosmosDBAccount.Id);
                }
                catch (CloudException)
                {
                }
                Console.WriteLine("Deleted the CosmosDB");
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting resource group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
                    Utilities.Log("Deleted resource group: " + rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception e)
                {
                    Utilities.Log(e.StackTrace);
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
                Utilities.Log(e.Message);
                Utilities.Log(e.StackTrace);
            }
        }
    }
}
