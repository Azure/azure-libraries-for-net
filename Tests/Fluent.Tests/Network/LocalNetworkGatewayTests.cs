// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.Text;
using Xunit;
using Fluent.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Rest;
using Xunit.Abstractions;

namespace Fluent.Tests.Network
{
    public class LocalNetworkGateway
    {
        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string testId = SdkContext.RandomResourceName("", 9);
                string resourceGroupName = "rg" + testId;
                string lngwName = "lngw" + testId;
                Region region = Region.USSouthCentral;

                var manager = TestHelper.CreateNetworkManager();

                try
                { 
                ILocalNetworkGateway gateway = manager.LocalNetworkGateways.Define(lngwName)
                    .WithRegion(region)
                    .WithNewResourceGroup(resourceGroupName)
                    .WithIPAddress("40.71.184.214")
                    .WithAddressSpace("192.168.3.0/24")
                    .WithAddressSpace("192.168.4.0/27")
                    .Create();
                Assert.Equal("40.71.184.214", gateway.IPAddress);
                Assert.Equal(2, gateway.AddressSpaces.Count);
                Assert.True(gateway.AddressSpaces.Contains("192.168.4.0/27"));

                gateway.Update()
                    .WithoutAddressSpace("192.168.3.0/24")
                    .WithIPAddress("40.71.184.216")
                    .WithTag("tag2", "value2")
                    .WithoutTag("tag1")
                    .Apply();
                Assert.False(gateway.AddressSpaces.Contains("192.168.3.0/24"));
                Assert.Equal("40.71.184.216", gateway.IPAddress);
                Assert.True(gateway.Tags.ContainsKey("tag2"));
                Assert.False(gateway.Tags.ContainsKey("tag1"));
                gateway.UpdateTags()
                    .WithoutTag("tag2")
                    .WithTag("tag3", "value3")
                    .ApplyTags();
                Assert.False(gateway.Tags.ContainsKey("tag2"));
                string value3;
                gateway.Tags.TryGetValue("tag3", out value3);
                Assert.Equal("value3", value3);

                manager.LocalNetworkGateways.DeleteById(gateway.Id);
                manager.ResourceManager.ResourceGroups.DeleteByName(gateway.ResourceGroupName);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(resourceGroupName);
                    }
                    catch { }
                }
            }
        }
    }
}
