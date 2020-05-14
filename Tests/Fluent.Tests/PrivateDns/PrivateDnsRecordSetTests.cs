// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Fluent.Tests.PrivateDns
{
    public class PrivateDnsRecordSet
    {
        [Fact]
        public void CanCreateWithDefaultETag()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.AsiaSouthEast;
                var groupName = TestUtilities.GenerateName("rgprdnshash");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var privateDnsZone = azure.PrivateDnsZones.Define(topLevelDomain)
                        .WithNewResourceGroup(groupName, region)
                        .DefineARecordSet("recordA")
                            .WithIPv4Address("23.96.104.40")
                            .WithIPv4Address("24.97.105.41")
                            .WithTimeToLive(7200)
                            .WithETagCheck()
                            .Attach()
                        .DefineAaaaRecordSet("recordAaaa")
                            .WithIPv6Address("2001:0db8:85a3:0000:0000:8a2e:0370:7334")
                            .WithIPv6Address("2002:0db9:85a4:0000:0000:8a2e:0371:7335")
                            .WithETagCheck()
                            .Attach()
                        .DefineCnameRecordSet("documents")
                            .WithAlias("doc.contoso.com")
                            .WithETagCheck()
                            .Attach()
                        .DefineCnameRecordSet("userguide")
                            .WithAlias("doc.contoso.com")
                            .WithETagCheck()
                            .Attach()
                        .Create();

                    //check A records
                    var aRecordSets = privateDnsZone.ARecordSets.List();
                    Assert.NotNull(aRecordSets);
                    Assert.True(aRecordSets.Count() == 1);
                    Assert.True(aRecordSets.ElementAt(0).TimeToLive == 7200);

                    //check Aaaa records
                    var aaaaRecordSets = privateDnsZone.AaaaRecordSets.List();
                    Assert.Single(aaaaRecordSets);
                    Assert.StartsWith("recordAaaa", aaaaRecordSets.ElementAt(0).Name, StringComparison.OrdinalIgnoreCase);
                    Assert.Equal(2, aaaaRecordSets.ElementAt(0).IPv6Addresses.Count());

                    //check Cname records
                    var cnameRecordSets = privateDnsZone.CnameRecordSets.List();
                    Assert.True(cnameRecordSets.Count() == 2);
                    //test list with optional page size
                    cnameRecordSets = privateDnsZone.CnameRecordSets.List(pageSize: 1);
                    Assert.True(cnameRecordSets.Count() == 1);

                    AggregateException compositeException = null;
                    try
                    {
                        //The requests of creation should fail because resources already exist
                        privateDnsZone = azure.PrivateDnsZones.Define(topLevelDomain)
                        .WithNewResourceGroup(groupName, region)
                        .DefineARecordSet("recordA")
                            .WithIPv4Address("23.96.104.40")
                            .WithIPv4Address("24.97.105.41")
                            .WithTimeToLive(7200)
                            .WithETagCheck()
                            .Attach()
                        .DefineAaaaRecordSet("recordAaaa")
                            .WithIPv6Address("2001:0db8:85a3:0000:0000:8a2e:0370:7334")
                            .WithIPv6Address("2002:0db9:85a4:0000:0000:8a2e:0371:7335")
                            .WithETagCheck()
                            .Attach()
                        .DefineCnameRecordSet("documents")
                            .WithAlias("doc.contoso.com")
                            .WithETagCheck()
                            .Attach()
                        .DefineCnameRecordSet("userguide")
                            .WithAlias("doc.contoso.com")
                            .WithETagCheck()
                            .Attach()
                        .Create();
                    }
                    catch (AggregateException exception)
                    {
                        compositeException = exception;
                    }
                    ValidateException(compositeException, 4);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(groupName);
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
                var groupName = TestUtilities.GenerateName("rgprdnshash");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var privateDnsZone = azure.PrivateDnsZones.Define(topLevelDomain)
                        .WithNewResourceGroup(groupName, region)
                        .DefineARecordSet("recordA")
                            .WithIPv4Address("23.96.104.40")
                            .WithIPv4Address("24.97.105.41")
                            .WithTimeToLive(7200)
                            .WithETagCheck()
                            .Attach()
                        .DefineAaaaRecordSet("recordAaaa")
                            .WithIPv6Address("2001:0db8:85a3:0000:0000:8a2e:0370:7334")
                            .WithIPv6Address("2002:0db9:85a4:0000:0000:8a2e:0371:7335")
                            .WithETagCheck()
                            .Attach()
                        .Create();

                    //check A records
                    var aRecordSets = privateDnsZone.ARecordSets.List();
                    Assert.NotNull(aRecordSets);
                    Assert.True(aRecordSets.Count() == 1);
                    var aRecordSet = aRecordSets.ElementAt(0);
                    Assert.NotNull(aRecordSet.ETag);

                    //check Aaaa records
                    var aaaaRecordSets = privateDnsZone.AaaaRecordSets.List();
                    Assert.Single(aaaaRecordSets);
                    var aaaaRecordSet = aaaaRecordSets.ElementAt(0);
                    Assert.NotNull(aaaaRecordSet.ETag);

                    AggregateException compositeException = null;
                    try
                    {
                        //The requests of update should fail because ETag mismatch
                        privateDnsZone.Update()
                            .UpdateARecordSet("recordA")
                                .WithETagCheck(aRecordSet.ETag + "-foo")
                                .Parent()
                            .UpdateAaaaRecordSet("recordAaaa")
                                .WithETagCheck(aaaaRecordSet.ETag + "-foo")
                                .Parent()
                            .Apply();
                    }
                    catch (AggregateException exception)
                    {
                        compositeException = exception;
                    }
                    ValidateException(compositeException, 2);

                    privateDnsZone.Update()
                        .UpdateARecordSet("recordA")
                            .WithIPv4Address("24.97.105.45")
                            .WithETagCheck(aRecordSet.ETag)
                            .Parent()
                        .UpdateAaaaRecordSet("recordAaaa")
                            .WithIPv6Address("2002:0db9:85a4:0000:0000:8a2e:0371:7336")
                            .WithETagCheck(aaaaRecordSet.ETag)
                            .Parent()
                        .Apply();

                    // Check A records
                    aRecordSets = privateDnsZone.ARecordSets.List();
                    Assert.True(aRecordSets.Count() == 1);
                    aRecordSet = aRecordSets.ElementAt(0);
                    Assert.NotNull(aRecordSet.ETag);
                    Assert.True(aRecordSet.IPv4Addresses.Count() == 3);

                    // Check Aaaa records
                    aaaaRecordSets = privateDnsZone.AaaaRecordSets.List();
                    Assert.True(aaaaRecordSets.Count() == 1);
                    aaaaRecordSet = aaaaRecordSets.ElementAt(0);
                    Assert.NotNull(aaaaRecordSet.ETag);
                    Assert.True(aaaaRecordSet.IPv6Addresses.Count() == 3);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(groupName);
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
                var groupName = TestUtilities.GenerateName("rgprdnshash");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var privateDnsZone = azure.PrivateDnsZones.Define(topLevelDomain)
                        .WithNewResourceGroup(groupName, region)
                        .DefineARecordSet("recordA")
                            .WithIPv4Address("23.96.104.40")
                            .WithIPv4Address("24.97.105.41")
                            .WithTimeToLive(7200)
                            .WithETagCheck()
                            .Attach()
                        .DefineAaaaRecordSet("recordAaaa")
                            .WithIPv6Address("2001:0db8:85a3:0000:0000:8a2e:0370:7334")
                            .WithIPv6Address("2002:0db9:85a4:0000:0000:8a2e:0371:7335")
                            .WithETagCheck()
                            .Attach()
                        .Create();

                    //check A records
                    var aRecordSets = privateDnsZone.ARecordSets.List();
                    Assert.NotNull(aRecordSets);
                    Assert.True(aRecordSets.Count() == 1);
                    var aRecordSet = aRecordSets.ElementAt(0);
                    Assert.NotNull(aRecordSet.ETag);

                    //check Aaaa records
                    var aaaaRecordSets = privateDnsZone.AaaaRecordSets.List();
                    Assert.Single(aaaaRecordSets);
                    var aaaaRecordSet = aaaaRecordSets.ElementAt(0);
                    Assert.NotNull(aaaaRecordSet.ETag);

                    AggregateException compositeException = null;
                    try
                    {
                        //The requests of deletion should fail because ETag mismatch
                        privateDnsZone.Update()
                            .WithoutARecordSet("recordA", aRecordSet.ETag + "-foo")
                            .WithoutAaaaRecordSet("recordAaaa", aaaaRecordSet.ETag + "-foo")
                            .Apply();
                    }
                    catch (AggregateException exception)
                    {
                        compositeException = exception;
                    }
                    ValidateException(compositeException, 2);

                    privateDnsZone.Update()
                        .WithoutARecordSet("recordA", aRecordSet.ETag)
                        .WithoutAaaaRecordSet("recordAaaa", aaaaRecordSet.ETag)
                        .Apply();

                    // Check A records
                    aRecordSets = privateDnsZone.ARecordSets.List();
                    Assert.True(aRecordSets.Count() == 0);

                    // Check Aaaa records
                    aaaaRecordSets = privateDnsZone.AaaaRecordSets.List();
                    Assert.True(aaaaRecordSets.Count() == 0);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(groupName);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void ValidateException(AggregateException aggregateException, int innerExceptionCount)
        {
            Assert.NotNull(aggregateException);
            Assert.NotNull(aggregateException.InnerExceptions);
            Assert.Equal(innerExceptionCount, aggregateException.InnerExceptions.Count);
            foreach (var exception in aggregateException.InnerExceptions)
            {
                Assert.True(exception is CloudException);
                CloudError cloudError = ((CloudException)exception).Body;
                Assert.NotNull(cloudError);
                Assert.NotNull(cloudError.Code);
                Assert.Contains("PreconditionFailed", cloudError.Code);
            }
        }
    }
}
