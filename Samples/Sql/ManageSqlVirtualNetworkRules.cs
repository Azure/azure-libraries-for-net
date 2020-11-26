// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.Sql.Fluent.Models;
using System;

namespace ManageSqlVirtualNetworkRules
{
    public class Program
    {
        private static readonly string sqlServerName = SdkContext.RandomResourceName("sqlserver", 20);
        private static readonly string rgName = SdkContext.RandomResourceName("rgsql", 20);
        private static readonly string administratorLogin = "sqladmin3423";
        private static readonly string administratorPassword = Utilities.CreatePassword();
        private static readonly string  vnetName = SdkContext.RandomResourceName("vnetsql", 20);

        /**
         * Azure SQL sample for managing SQL Virtual Network Rules
         *  - Create a Virtual Network with two subnets.
         *  - Create a SQL Server along with one virtual network rule.
         *  - Add another virtual network rule in the SQL Server
         *  - Get a virtual network rule.
         *  - Update a virtual network rule.
         *  - List all virtual network rules.
         *  - Delete a virtual network.
         *  - Delete Sql Server
         */
        public static void RunSample(IAzure azure)
        {
            try
            {
                // ============================================================
                // Create a virtual network with two subnets.
                Utilities.Log("Create a virtual network with two subnets: subnet1 and subnet2");

                var virtualNetwork = azure.Networks.Define(vnetName)
                    .WithRegion(Region.AsiaSouthEast)
                    .WithNewResourceGroup(rgName)
                    .WithAddressSpace("192.168.0.0/16")
                    .DefineSubnet("subnet1")
                        .WithAddressPrefix("192.168.1.0/24")
                        .WithAccessFromService(ServiceEndpointType.MicrosoftSql)
                        .Attach()
                    .WithSubnet("subnet2", "192.168.2.0/24")
                    .Create();

                Utilities.Log("Created a virtual network");
                // Print the virtual network details
                Utilities.PrintVirtualNetwork(virtualNetwork);

                // ============================================================
                // Create a SQL Server, with one virtual network rule.
                Utilities.Log("Create a SQL server with one virtual network rule");

                var sqlServer = azure.SqlServers.Define(sqlServerName)
                    .WithRegion(Region.AsiaSouthEast)
                    .WithExistingResourceGroup(rgName)
                    .WithAdministratorLogin(administratorLogin)
                    .WithAdministratorPassword(administratorPassword)
                    .WithoutAccessFromAzureServices()
                    .DefineVirtualNetworkRule("virtualNetworkRule1")
                        .WithSubnet(virtualNetwork.Id, "subnet1")
                        .Attach()
                    .Create();

                Utilities.PrintSqlServer(sqlServer);


                // ============================================================
                // Get the virtual network rule created above.
                var virtualNetworkRule = azure.SqlServers.VirtualNetworkRules
                    .GetBySqlServer(rgName, sqlServerName, "virtualNetworkRule1");

                Utilities.PrintSqlVirtualNetworkRule(virtualNetworkRule);


                // ============================================================
                // Add new virtual network rules.
                Utilities.Log("adding another virtual network rule in existing SQL Server");
                virtualNetworkRule = sqlServer.VirtualNetworkRules
                    .Define("virtualNetworkRule2")
                    .WithSubnet(virtualNetwork.Id, "subnet2")
                    .IgnoreMissingSqlServiceEndpoint()
                    .Create();

                Utilities.PrintSqlVirtualNetworkRule(virtualNetworkRule);


                // ============================================================
                // Update a virtual network rules.
                Utilities.Log("Updating an existing virtual network rules in SQL Server.");
                virtualNetworkRule.Update()
                    .WithSubnet(virtualNetwork.Id, "subnet1")
                    .Apply();

                Utilities.PrintSqlVirtualNetworkRule(virtualNetworkRule);


                // ============================================================
                // List and delete all virtual network rules.
                Utilities.Log("Listing all virtual network rules in SQL Server.");

                var virtualNetworkRules = sqlServer.VirtualNetworkRules.List();
                foreach (var vnetRule in virtualNetworkRules)
                {
                    // Delete the virtual network rule.
                    Utilities.Log("Deleting a virtual network rule");
                    vnetRule.Delete();
                }


                // Delete the SQL Server.
                Utilities.Log("Deleting a Sql Server");
                azure.SqlServers.DeleteById(sqlServer.Id);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (Exception e)
                {
                    Utilities.Log(e);
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
                Utilities.Log(e.ToString());
            }
        }
    }
}