// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Fluent.Tests.PrivateDns
{
    public class PrivateDnsZone
    {
        [Fact]
        public void CanCreateWithDefaultETag()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.AsiaSouthEast;
                var groupName = TestUtilities.GenerateName("prdnsgp-");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";

                var azure = TestHelper.CreateRollupClient();
                var privateDnsZoneManager = TestHelper.CreatePrivateDnsZoneManager();
                try
                {
                    var privateDnsZone = azure.PrivateDnsZones.Define(topLevelDomain)
                        .WithNewResourceGroup(groupName, region)
                        .WithETagCheck()
                        .Create();

                    Assert.NotNull(privateDnsZone.ETag);

                    var target = privateDnsZoneManager.PrivateDnsZones.GetById(privateDnsZone.Id);
                    Assert.NotNull(target);

                    var found = false;
                    var privateDnsZoneList = privateDnsZoneManager.PrivateDnsZones.List();
                    foreach(var zone in privateDnsZoneList)
                    {
                        if(string.Equals(zone.Name, topLevelDomain, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                        }
                    }
                    Assert.True(found);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    {
                    }
                }
            }
        }

        [Fact]
        public void CanUpdateWithExplicitETag()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.AsiaSouthEast;
                var groupName = TestUtilities.GenerateName("prdnsgp-");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var resourceGroup = azure.ResourceGroups.Define(groupName)
                        .WithRegion(region)
                        .Create();

                    var privateDnsZone = azure.PrivateDnsZones.Define(topLevelDomain)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithETagCheck()
                        .Create();

                    Assert.NotNull(privateDnsZone.ETag);

                    EnsureETagExceptionIsThrown(() => 
                    {
                        //The request of update should fail because ETag mismatch
                        privateDnsZone.Update()
                            .WithEtagCheck(privateDnsZone.ETag + "-foo")
                            .Apply();
                    });

                    privateDnsZone.Update()
                            .WithEtagCheck(privateDnsZone.ETag)
                            .Apply();
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    {
                    }
                }
            }
        }

        [Fact]
        public void CanDeleteWithExplicitETag()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.AsiaSouthEast;
                var groupName = TestUtilities.GenerateName("prdnsgp-");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";

                var azure = TestHelper.CreateRollupClient();
                var privateDnsZoneManager = TestHelper.CreatePrivateDnsZoneManager();
                try
                {
                    var privateDnsZone = azure.PrivateDnsZones.Define(topLevelDomain)
                        .WithNewResourceGroup(groupName, region)
                        .WithETagCheck()
                        .Create();

                    Assert.NotNull(privateDnsZone.ETag);

                    EnsureETagExceptionIsThrown(() =>
                    {
                        //The request of deletion should fail because ETag mismatch
                        azure.PrivateDnsZones.DeleteById(privateDnsZone.Id, privateDnsZone.ETag + "-foo");
                    });

                    azure.PrivateDnsZones.DeleteById(privateDnsZone.Id, privateDnsZone.ETag);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void EnsureETagExceptionIsThrown(Action action)
        {
            var isCloudExceptionThrown = false;
            var isCloudErrorSet = false;
            var isCodeSet = false;
            var isPreconditionFailedCodeSet = false;
            try
            {
                action();
            }
            catch (CloudException exception)
            {
                isCloudExceptionThrown = true;
                CloudError cloudError = exception.Body;
                if (cloudError != null)
                {
                    isCloudErrorSet = true;
                    isCodeSet = cloudError.Code != null;
                    if (isCodeSet)
                    {
                        isPreconditionFailedCodeSet = cloudError.Code.Contains("PreconditionFailed");
                    }
                }
            }
            Assert.True(isCloudExceptionThrown, "Expected CloudException is not thrown");
            Assert.True(isCloudErrorSet, "Expected CloudError property is not set in CloudException");
            Assert.True(isCodeSet, "Expected CloudError.Code property is not set");
            Assert.True(isPreconditionFailedCodeSet, "Expected PreconditionFailed code is not set indicating ETag concurrency check failure");
        }
    }
}
