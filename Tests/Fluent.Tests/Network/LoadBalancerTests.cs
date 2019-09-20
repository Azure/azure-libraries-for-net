// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Fluent.Tests.Network
{
    public partial class LoadBalancer
    {
        [Fact]
        public void CanCRUDProbe()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("rg");
                string lbName = TestUtilities.GenerateName("lb");
                string nwName = TestUtilities.GenerateName("nw");
                Region region = Region.USEast;

                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();

                    IResourceGroup resourceGroup = azure.ResourceGroups
                        .Define(rgName)
                        .WithRegion(region)
                        .Create();

                    INetwork network = azure.Networks
                        .Define(nwName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("172.18.0.0/28")
                        .WithSubnet(subnetName, "172.18.0.0/28")
                        .Create();

                    ILoadBalancer loadBalancer = CreateLoadBalancer(azure, resourceGroup, network, lbName);

                    // verify created probes
                    loadBalancer.Refresh();
                    Assert.Equal(2, loadBalancer.LoadBalancingRules.Count);
                    Assert.Empty(loadBalancer.TcpProbes);
                    Assert.Single(loadBalancer.HttpProbes);
                    Assert.Single(loadBalancer.HttpsProbes);
                    ILoadBalancerHttpProbe httpProbe = null;
                    Assert.True(loadBalancer.HttpProbes.TryGetValue(probeName1, out httpProbe));
                    Assert.Single(httpProbe.LoadBalancingRules);
                    ILoadBalancerHttpProbe httpsProbe = null;
                    Assert.True(loadBalancer.HttpsProbes.TryGetValue(probeName2, out httpsProbe));
                    Assert.Single(httpsProbe.LoadBalancingRules);
                    // verify https probe
                    Assert.Equal(ProbeProtocol.Https, httpsProbe.Protocol);
                    Assert.Equal(443, httpsProbe.Port);
                    Assert.Equal("/", httpsProbe.RequestPath);

                    // update probe
                    loadBalancer.Update()
                        .UpdateHttpsProbe(probeName2)
                        .WithIntervalInSeconds(60)
                        .WithRequestPath("/health")
                        .Parent().Apply();

                    // verify probe updated
                    loadBalancer.Refresh();
                    Assert.True(loadBalancer.HttpProbes.TryGetValue(probeName1, out httpProbe));
                    Assert.True(loadBalancer.HttpsProbes.TryGetValue(probeName2, out httpsProbe));
                    Assert.Single(httpsProbe.LoadBalancingRules);
                    Assert.Equal(ProbeProtocol.Https, httpsProbe.Protocol);
                    Assert.Equal(443, httpsProbe.Port);
                    Assert.Equal(60, httpsProbe.IntervalInSeconds);
                    Assert.Equal("/health", httpsProbe.RequestPath);

                    // delete probe
                    loadBalancer.Update()
                        .WithoutProbe(probeName2)
                        .Apply();

                    // verify probe deleted (and deref from rule)
                    loadBalancer.Refresh();
                    Assert.True(loadBalancer.HttpProbes.TryGetValue(probeName1, out httpProbe));
                    Assert.False(loadBalancer.HttpsProbes.TryGetValue(probeName2, out httpsProbe));
                    Assert.Null(loadBalancer.LoadBalancingRules[ruleName2].Probe);

                    // add probe
                    loadBalancer.Update()
                        .DefineHttpsProbe(probeName2)
                            .WithRequestPath("/")
                            .Attach()
                        .Apply();

                    // verify probe added
                    loadBalancer.Refresh();
                    Assert.True(loadBalancer.HttpProbes.TryGetValue(probeName1, out httpProbe));
                    Assert.True(loadBalancer.HttpsProbes.TryGetValue(probeName2, out httpsProbe));
                    Assert.Empty(httpsProbe.LoadBalancingRules);
                }
                finally
                {
                    try
                    {
                        azure?.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        static private string subnetName = "subnet1";
        static private string ruleName1 = "httpRule";
        static private string ruleName2 = "httpsRule";
        static private string probeName1 = "httpProbe";
        static private string probeName2 = "httpsProbe";

        private static ILoadBalancer CreateLoadBalancer(
            IAzure azure,
            IResourceGroup resourceGroup,
            INetwork network,
            string lbName)
        {
            string privateFrontEndName = lbName + "-FE1";
            string backendPoolName1 = lbName + "-BAP1";
            string backendPoolName2 = lbName + "-BAP2";
            string natPoolName1 = lbName + "-INP1";
            string natPoolName2 = lbName + "-INP2";

            ILoadBalancer loadBalancer = azure.LoadBalancers.Define(lbName)
                .WithRegion(resourceGroup.Region)
                .WithExistingResourceGroup(resourceGroup)
                // Add two rules that uses above backend and probe
                .DefineLoadBalancingRule(ruleName1)
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(privateFrontEndName)
                    .FromFrontendPort(1000)
                    .ToBackend(backendPoolName1)
                    .WithProbe(probeName1)
                    .Attach()
                .DefineLoadBalancingRule(ruleName2)
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(privateFrontEndName)
                    .FromFrontendPort(1001)
                    .ToBackend(backendPoolName2)
                    .WithProbe(probeName2)
                    .Attach()
                // Add two nat pools to enable direct VM connectivity to port 44 and 45
                .DefineInboundNatPool(natPoolName1)
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(privateFrontEndName)
                    .FromFrontendPortRange(8000, 8099)
                    .ToBackendPort(44)
                    .Attach()
                .DefineInboundNatPool(natPoolName2)
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(privateFrontEndName)
                    .FromFrontendPortRange(9000, 9099)
                    .ToBackendPort(45)
                    .Attach()
                // Explicitly define the frontend
                .DefinePrivateFrontend(privateFrontEndName)
                    .WithExistingSubnet(network, subnetName)
                    .Attach()
                // Add two probes one per rule
                .DefineHttpProbe(probeName1)
                    .WithRequestPath("/")
                    .Attach()
                .DefineHttpsProbe(probeName2)
                    .WithRequestPath("/")
                    .Attach()
                .WithSku(LoadBalancerSkuType.Standard)
                .Create();

            return loadBalancer;
        }
    }
}
