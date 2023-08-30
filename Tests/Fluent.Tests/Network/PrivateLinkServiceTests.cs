// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.Linq;
using Xunit;

namespace Fluent.Tests.Network
{
    public class PrivateLinkService
    {
        private static Region REGION = Region.AsiaSouthEast;

        [Fact]
        public void CanCreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = SdkContext.RandomResourceName("rg", 10);
                var vnetName = SdkContext.RandomResourceName("vnet", 10);
                var subnetName = SdkContext.RandomResourceName("subnet", 10);
                var lbName = SdkContext.RandomResourceName("lb", 10);
                var plsName = SdkContext.RandomResourceName("pls", 10);

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    var resourceGroup = azure.ResourceGroups.Define(rgName)
                        .WithRegion(REGION)
                        .Create();

                    var vnet = azure.Networks.Define(vnetName)
                        .WithRegion(REGION)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("10.0.0.0/16")
                        .WithSubnet(subnetName, "10.0.0.0/24")
                        .Create();

                    var loadBalancer = azure.LoadBalancers.Define(lbName)
                        .WithRegion(REGION)
                        .WithExistingResourceGroup(resourceGroup)
                        .DefineLoadBalancingRule("myHttpRule")
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend("myFrontEnd")
                            .FromFrontendPort(80)
                            .ToBackend("myBackEnd")
                            .WithProbe("myProbe")
                            .Attach()
                        .DefinePrivateFrontend("myFrontEnd")
                            .WithExistingSubnet(vnet, subnetName)
                            .Attach()
                        .DefineBackend("myBackEnd")
                            .Attach()
                        .DefineHttpProbe("myProbe")
                            .WithRequestPath("/")
                            .WithPort(80)
                            .Attach()
                        .WithSku(LoadBalancerSkuType.Standard)
                        .Create();

                    vnet.Subnets[subnetName].Inner.PrivateLinkServiceNetworkPolicies = "Disabled";
                    vnet.Update()
                        .UpdateSubnet(subnetName)
                        .Parent()
                        .Apply();

                    ISubnet subnet = vnet.Subnets[subnetName];
                    ILoadBalancerFrontend lbFrontend = loadBalancer.Frontends["myFrontEnd"];

                    var privateLinkService = azure.PrivateLinkServices.Define(plsName)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithRegion(REGION)
                        .WithFrontendIpConfiguration(lbFrontend)
                        .DefinePrivateLinkServiceIpConfiguration("myPrivateIPConfig")
                            .SetAsPrimaryIpConfiguration()
                            .WithSubnet(subnet.Inner.Id)
                            .Attach()
                        .Create();

                    Assert.NotNull(privateLinkService);
                    Assert.NotNull(privateLinkService.IpConfigurations);
                    Assert.True(privateLinkService.IpConfigurations.Count == 1);
                    Assert.False(privateLinkService.IsProxyProtocolEnabled);
                    Assert.True(privateLinkService.LoadBalancerFrontendIpConfigurations.Count == 1);

                    privateLinkService = azure.PrivateLinkServices.GetByResourceGroup(rgName, plsName);
                    Assert.Equal("myFrontEnd", privateLinkService.LoadBalancerFrontendIpConfigurations.First().Name);
                    Assert.Equal("myHttpRule", privateLinkService.LoadBalancerFrontendIpConfigurations.First().LoadBalancingRules["myHttpRule"].Name);

                    privateLinkService = azure.PrivateLinkServices.GetByResourceGroup(rgName, plsName);
                    privateLinkService.Update()
                        .EnableProxyProtocol()
                        .UpdatePrivateLinkServiceIpConfiguration("myPrivateIPConfig")
                            .WithStaticPrivateIpAllocation()
                            .WithPrivateIpAddress("10.0.0.5")
                            .Attach()
                        .Apply();

                    Assert.True(privateLinkService.IsProxyProtocolEnabled);
                    Assert.Equal(IPAllocationMethod.Static, privateLinkService.IpConfigurations[0].PrivateIPAllocationMethod);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
