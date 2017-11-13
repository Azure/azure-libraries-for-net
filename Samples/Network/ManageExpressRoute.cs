// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;

namespace ManageExpressRoute
{
    public class Program
    {
        private static readonly Region region = Region.USWestCentral;

        /**
        * Azure Network sample for managing express route circuits.
         *  - Create Express Route circuit
         *  - Create Express Route circuit peering. Please note: express route circuit should be provisioned by connectivity provider before this step.
         *  - Adding authorization to express route circuit
         *  - Create virtual network to be associated with virtual network gateway
         *  - Create virtual network gateway
         *  - Create virtual network gateway connection
        */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rg", 20);
            string ercName = SdkContext.RandomResourceName("erc", 20);
            string vnetName = SdkContext.RandomResourceName("vnet", 20);
            string gatewayName = SdkContext.RandomResourceName("gtw", 20);
            string connectionName = SdkContext.RandomResourceName("con", 20);

            try
            {
                //============================================================
                // create Express Route Circuit
                Utilities.Log("Creating express route circuit...");
                IExpressRouteCircuit erc = azure.ExpressRouteCircuits.Define(ercName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .WithServiceProvider("Equinix")
                    .WithPeeringLocation("Silicon Valley")
                    .WithBandwidthInMbps(50)
                    .WithSku(ExpressRouteCircuitSkuType.PremiumMeteredData)
                    .Create();
                Utilities.Log("Created express route circuit");

                //============================================================
                // Create Express Route circuit peering. Please note: express route circuit should be provisioned by connectivity provider before this step.
                Utilities.Log("Creating express route circuit peering...");
                erc.Peerings.DefineAzurePrivatePeering()
                    .WithPrimaryPeerAddressPrefix("123.0.0.0/30")
                    .WithSecondaryPeerAddressPrefix("123.0.0.4/30")
                    .WithVlanId(200)
                    .WithPeerAsn(100)
                    .Create();
                Utilities.Log("Created express route circuit peering");

                //============================================================
                // Adding authorization to express route circuit
                erc.Update()
                    .WithAuthorization("myAuthorization")
                    .Apply();

                //============================================================
                // Create virtual network to be associated with virtual network gateway
                Utilities.Log("Creating virtual network...");
                INetwork network = azure.Networks.Define(vnetName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(rgName)
                    .WithAddressSpace("192.168.0.0/16")
                    .WithSubnet("GatewaySubnet", "192.168.200.0/26")
                    .WithSubnet("FrontEnd", "192.168.1.0/24")
                    .Create();

                //============================================================
                // Create virtual network gateway
                Utilities.Log("Creating virtual network gateway...");
                IVirtualNetworkGateway vngw1 = azure.VirtualNetworkGateways.Define(gatewayName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .WithExistingNetwork(network)
                    .WithExpressRoute()
                    .WithSku(VirtualNetworkGatewaySkuName.Standard)
                    .Create();
                Utilities.Log("Created virtual network gateway");

                //============================================================
                // Create virtual network gateway connection
                Utilities.Log("Creating virtual network gateway connection...");
                vngw1.Connections.Define(connectionName)
                    .WithExpressRoute(erc)
                    // Note: authorization key is required only in case express route circuit and virtual network gateway are in different subscriptions
                    // .WithAuthorization(erc.Inner.Authorizations.First().AuthorizationKey)
                    .Create();
                Utilities.Log("Created virtual network gateway connection");
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
