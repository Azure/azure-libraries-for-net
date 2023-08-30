// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class Network : Samples.Tests.TestBase
    {
        public Network(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageNetworkPeeringInSameSubscriptionTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageNetworkPeeringInSameSubscription.Program.RunSample);
        }

        [Fact(Skip = "Cannot pass because: Cannot create more than 1 network watchers for this subscription in this region. ")]
        [Trait("Samples", "Network")]
        public void VerifyNetworkPeeringWithNetworkWatcherTest()
        {
            RunSampleAsTest(
                GetType().FullName,
                VerifyNetworkPeeringWithNetworkWatcher.Program.RunSample);
        }

        [Fact(Skip = "Manual Only test.")]
        [Trait("Samples", "Network")]
        public void ManageApplicationGatewayTest()
        {
            RunSampleAsTest(
                GetType().FullName,
                ManageApplicationGateway.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageInternalLoadBalancerTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageInternalLoadBalancer.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void CreateSimpleInternetFacingLoadBalancerTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                CreateSimpleInternetFacingLoadBalancer.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageInternetFacingLoadBalancerTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageInternetFacingLoadBalancer.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageIPAddressTest()
        {            RunSampleAsTest(
                this.GetType().FullName,
                ManageIPAddress.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageNetworkInterfaceTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageNetworkInterface.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageNetworkSecurityGroupTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageNetworkSecurityGroup.Program.RunSample);
        }

        [Fact(Skip = "Fails during playback only on Linux. Needs further investigation.")]
        [Trait("Samples", "Network")]
        public void ManageSimpleApplicationGatewayTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageSimpleApplicationGateway.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageVirtualNetworkTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageVirtualNetwork.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageVirtualNetworkTestAsync()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                (azure) => ManageVirtualNetworkAsync.Program
                            .RunSampleAsync(azure)
                            .GetAwaiter()
                            .GetResult());
        }

        [Fact(Skip = "Cannot run because of service-side issue.")]
        [Trait("Samples", "Network")]
        public void ManageNetworkWatcherTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageNetworkWatcher.Program.RunSample);
        }

        [Fact (Skip = "Cannot pass because: Cannot create more than 1 network watchers for this subscription in this region. ")]
        [Trait("Samples", "Network")]
        public void ManageVpnGatewayVNet2VNetConnectionTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageVpnGatewayVNet2VNetConnection.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageVpnGatewaySite2SiteConnectionTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageVpnGatewaySite2SiteConnection.Program.RunSample);
        }
    }
}
