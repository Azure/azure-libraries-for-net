// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;

namespace ManageVpnGatewaySite2SiteConnection
{
    public class Program
    {
        private static readonly Region region = Region.USWestCentral;

        /**
         * Azure Network sample for managing virtual network gateway.
         *  - Create virtual network with gateway subnet
         *  - Create VPN gateway
         *  - Create local network gateway
         *  - Create VPN Site-to-Site connection
         *  - List VPN Gateway connections for particular gateway
         *  - Reset virtual network gateway
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgNEMV", 24);
            string vnetName = SdkContext.RandomResourceName("vnet", 20);
            string vpnGatewayName = SdkContext.RandomResourceName("vngw", 20);
            string localGatewayName = SdkContext.RandomResourceName("lngw", 20);
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
                // Create VPN gateway
                Utilities.Log("Creating virtual network gateway...");
                IVirtualNetworkGateway vngw = azure.VirtualNetworkGateways.Define(vpnGatewayName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(rgName)
                    .WithExistingNetwork(network)
                    .WithRouteBasedVpn()
                    .WithSku(VirtualNetworkGatewaySkuName.VpnGw1)
                    .Create();
                Utilities.Log("Created virtual network gateway");

                //============================================================
                // Create local network gateway
                Utilities.Log("Creating virtual network gateway...");
                ILocalNetworkGateway lngw = azure.LocalNetworkGateways.Define(localGatewayName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(rgName)
                    .WithIPAddress("40.71.184.214")
                    .WithAddressSpace("192.168.3.0/24")
                    .Create();
                Utilities.Log("Created virtual network gateway");

                //============================================================
                // Create VPN Site-to-Site connection
                Utilities.Log("Creating virtual network gateway connection...");
                vngw.Connections
                    .Define(connectionName)
                    .WithSiteToSite()
                    .WithLocalNetworkGateway(lngw)
                    .WithSharedKey("MySecretKey")
                    .Create();
                Utilities.Log("Created virtual network gateway connection");

                //============================================================
                // List VPN Gateway connections for particular gateway
                var connections = vngw.ListConnections();
                foreach (var connection in connections)
                {
                    Utilities.Print(connection);
                }
                //============================================================
                // Reset virtual network gateway
                vngw.Reset();
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