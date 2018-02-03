// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;

namespace ManageVpnGatewayPoint2SiteConnection
{
    public class Program
    {
        private static readonly Region region = Region.USWestCentral;

        /**
         * Azure Network sample for managing virtual network gateway.
         *  - Create a virtual network with subnets
         *  - Create virtual network gateway
         *  - Update virtual network gateway with Point-to-Site connection configuration
         *  - Generate and download VPN client configuration package. Now it can be used to create VPN connection to Azure.
         *  - Revoke a client certificate
         *
         *  Please note: in order to run this sample, you need to have:
         *   - pre-generated root certificate and public key exported to $CERT_PATH file
         *      For more details please see https://docs.microsoft.com/en-us/azure/vpn-gateway/vpn-gateway-certificates-point-to-site for PowerShell instructions
         *      and https://docs.microsoft.com/en-us/azure/vpn-gateway/vpn-gateway-certificates-point-to-site-makecert for Makecert instructions.
         *   - client certificate generated for this root certificate installed on your machine.
         *      Please see: https://docs.microsoft.com/en-us/azure/vpn-gateway/point-to-site-how-to-vpn-client-install-azure-cert
         *   - thumbprint for client certificate saved to $CLIENT_CERT_THUMBPRINT
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgNEMV", 24);
            string vnetName = SdkContext.RandomResourceName("vnet", 20);
            string vpnGatewayName = SdkContext.RandomResourceName("vngw", 20);
            string certPath = Environment.GetEnvironmentVariable("CERT_PATH");
            string clientCertThumbprint = Environment.GetEnvironmentVariable("CLIENT_CERT_THUMBPRINT");

            try
            {
                //============================================================
                // Create virtual network with address spaces 192.168.0.0/16 and 10.254.0.0/16 and 3 subnets
                Utilities.Log("Creating virtual network...");
                INetwork network = azure.Networks.Define(vnetName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .WithAddressSpace("192.168.0.0/16")
                    .WithAddressSpace("10.254.0.0/16")
                    .WithSubnet("GatewaySubnet", "192.168.200.0/24")
                    .WithSubnet("FrontEnd", "192.168.1.0/24")
                    .WithSubnet("BackEnd", "10.254.1.0/24")
                    .Create();
                Utilities.Log("Created network");
                // Print the virtual network
                Utilities.Log(network);

                //============================================================
                // Create virtual network gateway
                Utilities.Log("Creating virtual network gateway...");
                IVirtualNetworkGateway vngw1 = azure.VirtualNetworkGateways.Define(vpnGatewayName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(rgName)
                    .WithExistingNetwork(network)
                    .WithRouteBasedVpn()
                    .WithSku(VirtualNetworkGatewaySkuName.VpnGw1)
                    .Create();
                Utilities.Log("Created virtual network gateway");

                //============================================================
                // Update virtual network gateway with Point-to-Site connection configuration
                Utilities.Log("Creating Point-to-Site configuration...");
                vngw1.Update()
                    .DefinePointToSiteConfiguration()
                    .WithAddressPool("172.16.201.0/24")
                    .WithAzureCertificateFromFile("p2scert.cer", new FileInfo(certPath))
                    .Attach()
                    .Apply();
                Utilities.Log("Created Point-to-Site configuration");

                //============================================================
                // Generate and download VPN client configuration package. Now it can be used to create VPN connection to Azure.
                Utilities.Log("Generating VPN profile...");
                String profile = vngw1.GenerateVpnProfile();
                Utilities.Log(String.Format("Profile generation is done. Please download client package at: %s", profile));

                // At this point vpn client package can be downloaded from provided link. Unzip it and run the configuration corresponding to your OS.
                // For Windows machine, VPN client .exe can be run. For non-Windows, please use configuration from downloaded VpnSettings.xml

                //============================================================
                // Revoke a client certificate. After this command, you will no longer available to connect with the corresponding client certificate.
                Utilities.Log("Revoking client certificate...");
                vngw1.Update().UpdatePointToSiteConfiguration()
                    .WithRevokedCertificate("p2sclientcert.cer", clientCertThumbprint)
                    .Parent()
                    .Apply();
                Utilities.Log("Revoked client certificate");
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