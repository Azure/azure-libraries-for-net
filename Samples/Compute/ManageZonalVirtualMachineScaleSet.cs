// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageZonalVirtualMachineScaleSet
{
    public class Program
    {
        /**
         * Azure Compute sample for managing virtual machine scale set -
         *  - Create a zone resilient public ip address
         *  - Create a zone resilient load balancer with
         *         - the existing zone resilient ip address
         *         - two load balancing rule which is applied to two different backend pools
         *  - Create two zone redundant virtual machine scale set each associated with one backend pool
         *  - Update the virtual machine scale set by appending new zone.
         */
        public static void RunSample(IAzure azure)
        {
            var region = Region.USEast2;
            var rgName = Utilities.CreateRandomName("rgCOMV");
            var loadBalancerName = Utilities.CreateRandomName("extlb");
            var publicIPName = "pip-" + loadBalancerName;
            var frontendName = loadBalancerName + "-FE1";
            var backendPoolName1 = loadBalancerName + "-BAP1";
            var backendPoolName2 = loadBalancerName + "-BAP2";
            var natPoolName1 = loadBalancerName + "-INP1";
            var natPoolName2 = loadBalancerName + "-INP2";
            var vmssName1 = Utilities.CreateRandomName("vmss1");
            var vmssName2 = Utilities.CreateRandomName("vmss2");
            var userName = Utilities.CreateUsername();
            var password = Utilities.CreatePassword();

            try
            {
                var resourceGroup = azure.ResourceGroups
                    .Define(rgName)
                    .WithRegion(region)
                    .Create();


                //=============================================================
                // Create a zone resilient PublicIP address

                Utilities.Log("Creating a zone resilient public ip address");

                var publicIPAddress = azure.PublicIPAddresses
                        .Define(publicIPName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithLeafDomainLabel(publicIPName)
                            // Optionals
                            .WithStaticIP()
                            .WithSku(PublicIPSkuType.Standard)
                            // Create PublicIP
                            .Create();

                Utilities.Log("Created a zone resilient public ip address: " + publicIPAddress.Id);

                //=============================================================
                // Create a zone resilient load balancer

                Utilities.Log("Creating a zone resilient load balancer");

                var loadBalancer = azure.LoadBalancers
                        .Define(loadBalancerName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)

                            // Add two rules that uses above backend and probe
                            .DefineLoadBalancingRule("httpRule")
                                .WithProtocol(TransportProtocol.Tcp)
                                .FromFrontend(frontendName)
                                .FromFrontendPort(80)
                                .ToBackend(backendPoolName1)
                                .WithProbe("httpProbe")
                                .Attach()
                            .DefineLoadBalancingRule("httpsRule")
                                .WithProtocol(TransportProtocol.Tcp)
                                .FromFrontend(frontendName)
                                .FromFrontendPort(443)
                                .ToBackend(backendPoolName2)
                                .WithProbe("httpsProbe")
                                .Attach()
                            // Add two nat pools to enable direct VMSS connectivity to port SSH and 23
                            .DefineInboundNatPool(natPoolName1)
                                .WithProtocol(TransportProtocol.Tcp)
                                .FromFrontend(frontendName)
                                .FromFrontendPortRange(5000, 5099)
                                .ToBackendPort(22)
                                .Attach()
                            .DefineInboundNatPool(natPoolName2)
                                .WithProtocol(TransportProtocol.Tcp)
                                .FromFrontend(frontendName)
                                .FromFrontendPortRange(6000, 6099)
                                .ToBackendPort(23)
                                .Attach()
                            // Explicitly define the frontend
                            .DefinePublicFrontend(frontendName)
                                .WithExistingPublicIPAddress(publicIPAddress)   // Frontend with PIP means internet-facing load-balancer
                                .Attach()
                            // Add two probes one per rule
                            .DefineHttpProbe("httpProbe")
                                .WithRequestPath("/")
                                .Attach()
                            .DefineHttpProbe("httpsProbe")
                                .WithRequestPath("/")
                                .Attach()
                            .WithSku(LoadBalancerSkuType.Standard)
                        .Create();

                Utilities.Log("Created a zone resilient load balancer: " + loadBalancer.Id);

                var backends = new List<string>();
                foreach (var backend in loadBalancer.Backends.Keys)
                {
                    backends.Add(backend);
                }
                var natpools = new List<string>();
                foreach (var natPool in loadBalancer.InboundNatPools.Keys)
                {
                    natpools.Add(natPool);
                }

                Utilities.Log("Creating network for virtual machine scale sets");

                var network = azure.Networks
                        .Define("vmssvnet")
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithSubnet("subnet1", "10.0.0.0/28")
                            .Create();

                Utilities.Log("Created network for virtual machine scale sets");

                //=============================================================
                // Create a zone redundant virtual machine scale set

                Utilities.Log("Creating a zone redundant virtual machine scale set");

                // HTTP goes to this virtual machine scale set
                //
                var virtualMachineScaleSet1 = azure.VirtualMachineScaleSets
                        .Define(vmssName1)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithSku(VirtualMachineScaleSetSkuTypes.StandardD3v2)
                            .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                            .WithExistingPrimaryInternetFacingLoadBalancer(loadBalancer)
                            .WithPrimaryInternetFacingLoadBalancerBackends(backends[0])
                            .WithPrimaryInternetFacingLoadBalancerInboundNatPools(natpools[0])
                            .WithoutPrimaryInternalLoadBalancer()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername(userName)
                            .WithRootPassword(password)
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_1)
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_2)
                            .Create();

                Utilities.Log("Created first zone redundant virtual machine scale set");

                //=============================================================
                // Create a zone redundant virtual machine scale set

                Utilities.Log("Creating second zone redundant virtual machine scale set");

                // HTTPS goes to this virtual machine scale set
                //
                var virtualMachineScaleSet2 = azure.VirtualMachineScaleSets
                        .Define(vmssName2)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithSku(VirtualMachineScaleSetSkuTypes.StandardD3v2)
                            .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                            .WithExistingPrimaryInternetFacingLoadBalancer(loadBalancer)
                            .WithPrimaryInternetFacingLoadBalancerBackends(backends[1])
                            .WithPrimaryInternetFacingLoadBalancerInboundNatPools(natpools[1])
                            .WithoutPrimaryInternalLoadBalancer()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername(userName)
                            .WithRootPassword(password)
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_1)
                            .WithAvailabilityZone(AvailabilityZoneId.Zone_2)
                            .Create();

                Utilities.Log("Created second zone redundant virtual machine scale set");
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception g)
                {
                    Utilities.Log(g);
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=============================================================
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
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}
