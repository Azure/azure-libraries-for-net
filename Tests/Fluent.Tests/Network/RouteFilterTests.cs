// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.Text;
using Xunit;
using Fluent.Tests.Common;
using Azure.Tests;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Fluent.Tests.Network
{
    public class RouteFilter
    {
        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string testId = SdkContext.RandomResourceName("", 9);
                string resourceGroupName = "rg" + testId;
                string routeTableName = "rt" + testId;
                string networkName = "net" + testId;
                Region region = Region.USEast;
                string[] routeNames = new string[] { "route1", "route2", "route3" };
                string rfName = SdkContext.RandomResourceName("rf", 15);

                var manager = TestHelper.CreateNetworkManager();
                var routeFilter = manager.RouteFilters.Define(rfName)
                    .WithRegion(Region.USSouthCentral)
                    .WithNewResourceGroup(resourceGroupName)
                    .WithTag("tag1", "value1")
                    .Create();
                Print(routeFilter);
                string tag1;
                Assert.True(routeFilter.Tags.TryGetValue("tag1", out tag1));
                Assert.Equal("value1", tag1);
                
                var rfList = manager.RouteFilters.List();
                Assert.True(rfList.Any());

                rfList = manager.RouteFilters.ListByResourceGroup(resourceGroupName);
                Assert.True(rfList.Any());

                manager.RouteFilters.DeleteById(routeFilter.Id);
                rfList = manager.RouteFilters.ListByResourceGroup(resourceGroupName);
                Assert.True(!rfList.Any());
            }
        }

        public void Print(IRouteFilter resource)
        {
            var info = new StringBuilder();
            info.Append("Route Filter: ").Append(resource.Id)
                .Append("Name: ").Append(resource.Name)
                .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                .Append("\n\tRegion: ").Append(resource.Region)
                .Append("\n\tTags: ").Append(resource.Tags);

            if (resource.Rules != null)
            {
            
                foreach (var rule in resource.Rules.Values)
                {
                    info.Append("\n\tRule: ").Append(rule.Name)
                        .Append("\n\t\tAccess: ").Append(rule.Access);
                }
            }

            TestHelper.WriteLine(info.ToString());
        }
    }
}
