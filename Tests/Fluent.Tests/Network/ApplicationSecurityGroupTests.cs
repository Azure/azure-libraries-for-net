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
    public class ApplicationSecurityGroup
    {
        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string testId = SdkContext.RandomResourceName("", 9);
                string resourceGroupName = "rg" + testId;
                string nsgName = "nsg" + testId;
                string nicName = "nic" + testId;
                string asgName = "asg" + testId;
                Region region = Region.USSouthCentral;

                var manager = TestHelper.CreateNetworkManager();
                try
                { 

                IApplicationSecurityGroup applicationSecurityGroup = manager.ApplicationSecurityGroups.Define(asgName)
                    .WithRegion(Region.USSouthCentral)
                    .WithNewResourceGroup(resourceGroupName)
                    .WithTag("tag1", "value1")
                    .Create();
                string tag1;
                Assert.True(applicationSecurityGroup.Tags.TryGetValue("tag1", out tag1));
                Assert.Equal("value1", tag1);

                var asgList = manager.ApplicationSecurityGroups.List();
                Assert.True(asgList.IsAny());

                asgList = manager.ApplicationSecurityGroups.ListByResourceGroup(resourceGroupName);
                Assert.True(asgList.IsAny());

                manager.ApplicationSecurityGroups.DeleteById(applicationSecurityGroup.Id);
                asgList = manager.ApplicationSecurityGroups.ListByResourceGroup(resourceGroupName);
                Assert.True(!asgList.IsAny());
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
