// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;

namespace ManageVpnGatewayVNet2VNetConnection
{
    public class Program
    {
        private static readonly Region region = Region.USWestCentral;

        /**
        * Azure Network sample for managing virtual network gateway.
        *  - Create 2 virtual network with subnets
        *  - Create first VPN gateway
        *  - Create second VPN gateway
        *  - Create VPN VNet-to-VNet connection
        *  - List VPN Gateway connections for the first gateway
        */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgNEMV", 24);
            string vnetName = SdkContext.RandomResourceName("vnet", 20);
            string vpnGatewayName = SdkContext.RandomResourceName("vngw", 20);
            string vpnGateway2Name = SdkContext.RandomResourceName("vngw2", 20);
            string connectionName = SdkContext.RandomResourceName("con", 20);

            try
            {
                //============================================================
                // Create virtual network
                Utilities.Log("Creating virtual network...");
                INetwork network = azure.Networks.Define(vnetName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .WithAddressSpace("10.11.0.0/16")
                    .WithSubnet("GatewaySubnet", "10.11.255.0/27")
                    .Create();
                Utilities.Log("Created network");
                // Print the virtual network
                Utilities.PrintVirtualNetwork(network);

                //============================================================
                // Create virtual network gateway
                Utilities.Log("Creating virtual network gateway...");
                IVirtualNetworkGateway vngw1 = azure.VirtualNetworkGateways.Define(vpnGatewayName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .WithNewNetwork("10.11.0.0/16", "10.11.255.0/27")
                    .WithRouteBasedVpn()
                    .WithSku(VirtualNetworkGatewaySkuName.VpnGw1)
                    .Create();
                Utilities.Log("Created virtual network gateway");

                //============================================================
                // Create second virtual network gateway
                Utilities.Log("Creating second virtual network gateway...");
                IVirtualNetworkGateway vngw2 = azure.VirtualNetworkGateways.Define(vpnGateway2Name)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .WithNewNetwork("10.41.0.0/16", "10.41.255.0/27")
                    .WithRouteBasedVpn()
                    .WithSku(VirtualNetworkGatewaySkuName.VpnGw1)
                    .Create();
                Utilities.Log("Created second virtual network gateway");

                //============================================================
                // Create virtual network gateway connection
                Utilities.Log("Creating virtual network gateway connection...");
                vngw1.Connections
                    .Define(connectionName)
                    .WithVNetToVNet()
                    .WithSecondVirtualNetworkGateway(vngw2)
                    .WithSharedKey("MySecretKey")
                    .Create();
                vngw2.Connections
                    .Define(connectionName + "2")
                    .WithVNetToVNet()
                    .WithSecondVirtualNetworkGateway(vngw1)
                    .WithSharedKey("MySecretKey")
                    .Create();

                Utilities.Log("Created virtual network gateway connection");

                //============================================================
                // List VPN Gateway connections for particular gateway
                var connections = vngw1.ListConnections();
                foreach (var connection in connections)
                {
                    Utilities.Print(connection);    
                }
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
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
                var credentials =
                    SdkContext.AzureCredentialsFactory.FromFile(
                        Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

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