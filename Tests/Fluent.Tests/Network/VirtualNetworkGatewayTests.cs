// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Tests;
using Fluent.Tests.Common;
using Fluent.Tests.Compute;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Xunit.Abstractions;

namespace Fluent.Tests.Network
{
    public class VirtualNetworkGatewayTest
    {
        private static Region REGION = Region.USWest;
        public VirtualNetworkGatewayTest(ITestOutputHelper output)
        {
             TestHelper.TestLogger = output;
             ServiceClientTracing.IsEnabled = true;
             ServiceClientTracing.AddTracingInterceptor(new XunitTracingInterceptor(output));
        }

        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string gatewayName = SdkContext.RandomResourceName("vngw", 10);
                var groupName = SdkContext.RandomResourceName("rg", 6);
                var manager = TestHelper.CreateNetworkManager();

                // Create network watcher
                IVirtualNetworkGateway vngw = manager.VirtualNetworkGateways.Define(gatewayName)
                    .WithRegion(REGION)
                    .WithNewResourceGroup(groupName)
                    .WithNewNetwork("10.0.0.0/25", "10.0.0.0/27")
                    .WithRouteBasedVpn()
                    .WithSku(VirtualNetworkGatewaySkuName.VpnGw1)
                    .WithTag("tag1", "value1")
                    .Create();
                var resource = manager.VirtualNetworkGateways.GetByResourceGroup(groupName, gatewayName);
                resource = resource.Update()
                    .WithTag("tag2", "value2")
                    .WithoutTag("tag1")
                    .Apply();
                Assert.True(resource.Tags.ContainsKey("tag2"));
                Assert.True(!resource.Tags.ContainsKey("tag1"));
                manager.NetworkWatchers.DeleteById(resource.Id);
                manager.ResourceManager.ResourceGroups.DeleteByName(groupName);
            }
        }
    }
}