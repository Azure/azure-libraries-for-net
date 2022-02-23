// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Dns.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Fluent.Tests.Dns
{
    public class RecordSet
    {
        [Fact]
        public void CanCreateWithDefaultETag()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgdnschash");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var dnsZone = azure.DnsZones.Define(topLevelDomain)
                            .WithNewResourceGroup(groupName, region)
                            .WithPrivateAccess()
                            .DefineARecordSet("www")
                                .WithIPv4Address("23.96.104.40")
                                .WithIPv4Address("24.97.105.41")
                                .WithTimeToLive(7200)
                                .WithETagCheck()
                                .Attach()
                            .DefineAaaaRecordSet("www")
                                .WithIPv6Address("2001:0db8:85a3:0000:0000:8a2e:0370:7334")
                                .WithIPv6Address("2002:0db9:85a4:0000:0000:8a2e:0371:7335")
                                .WithETagCheck()
                                .Attach()
                            .DefineCaaRecordSet("caaName")
                                .WithRecord(4, "sometag", "someValue")
                                .Attach()
                            .DefineCNameRecordSet("documents")
                                .WithAlias("doc.contoso.com")
                                .WithETagCheck()
                                .Attach()
                            .DefineCNameRecordSet("userguide")
                                .WithAlias("doc.contoso.com")
                                .WithETagCheck()
                                .Attach()
                            .Create();

                    // Check A records
                    var aRecordSets = dnsZone.ARecordSets.List();
                    Assert.True(aRecordSets.Count() == 1);
                    Assert.True(aRecordSets.ElementAt(0).TimeToLive == 7200);

                    // Check AAAA records
                    var aaaaRecordSets = dnsZone.AaaaRecordSets.List();
                    Assert.Single(aaaaRecordSets);
                    Assert.StartsWith("www", aaaaRecordSets.ElementAt(0).Name);
                    Assert.Equal(2, aaaaRecordSets.ElementAt(0).IPv6Addresses.Count());

                    // Check CNAME records
                    var cnameRecordSets = dnsZone.CNameRecordSets.List();
                    Assert.True(cnameRecordSets.Count() == 2);

                    // Check Caa records
                    var caaRecordSets = dnsZone.CaaRecordSets.List();
                    Assert.Single(caaRecordSets);
                    Assert.StartsWith("caaname", caaRecordSets.First().Name);
                    Assert.Equal("someValue", caaRecordSets.First().Records.First().Value, ignoreCase: true);
                    Assert.Equal(4, caaRecordSets.First().Records.First().Flags);
                    Assert.StartsWith("caaname.www.contoso", caaRecordSets.First().Fqdn);

                    Assert.Equal(ZoneType.Private, dnsZone.AccessType);

                    AggregateException compositeException = null;
                    try
                    {
                        azure.DnsZones.Define(topLevelDomain)
                                .WithNewResourceGroup(groupName, region)
                                .WithPrivateAccess()
                                .DefineARecordSet("www")
                                    .WithIPv4Address("23.96.104.40")
                                    .WithIPv4Address("24.97.105.41")
                                    .WithTimeToLive(7200)
                                    .WithETagCheck()
                                    .Attach()
                                .DefineAaaaRecordSet("www")
                                    .WithIPv6Address("2001:0db8:85a3:0000:0000:8a2e:0370:7334")
                                    .WithIPv6Address("2002:0db9:85a4:0000:0000:8a2e:0371:7335")
                                    .WithETagCheck()
                                    .Attach()
                                .DefineCNameRecordSet("documents")
                                    .WithAlias("doc.contoso.com")
                                    .WithETagCheck()
                                    .Attach()
                                .DefineCNameRecordSet("userguide")
                                    .WithAlias("doc.contoso.com")
                                    .WithETagCheck()
                                    .Attach()
                                .Create();
                    }
                    catch (AggregateException exception)
                    {
                        compositeException = exception;
                    }
                    Assert.NotNull(compositeException);
                    Assert.NotNull(compositeException.InnerExceptions);
                    Assert.Equal(4, compositeException.InnerExceptions.Count);
                    foreach (var exception in compositeException.InnerExceptions)
                    {
                        Assert.True(exception is CloudException);
                        CloudError cloudError = ((CloudException)exception).Body;
                        Assert.NotNull(cloudError);
                        Assert.NotNull(cloudError.Code);
                        Assert.Contains("PreconditionFailed", cloudError.Code);
                    }
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanUpdateWithExplicitETag()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgdnschash");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var dnsZone = azure.DnsZones.Define(topLevelDomain)
                        .WithNewResourceGroup(groupName, region)
                        .DefineARecordSet("www")
                            .WithIPv4Address("23.96.104.40")
                            .WithIPv4Address("24.97.105.41")
                            .WithTimeToLive(7200)
                            .WithETagCheck()
                            .Attach()
                        .DefineAaaaRecordSet("www")
                            .WithIPv6Address("2001:0db8:85a3:0000:0000:8a2e:0370:7334")
                            .WithIPv6Address("2002:0db9:85a4:0000:0000:8a2e:0371:7335")
                            .WithETagCheck()
                            .Attach()
                        .Create();

                    // Check A records
                    var aRecordSets = dnsZone.ARecordSets.List();
                    Assert.True(aRecordSets.Count() == 1);
                    var aRecordSet = aRecordSets.ElementAt(0);
                    Assert.NotNull(aRecordSet.ETag);

                    // Check AAAA records
                    var aaaaRecordSets = dnsZone.AaaaRecordSets.List();
                    Assert.True(aaaaRecordSets.Count() == 1);
                    var aaaaRecordSet = aaaaRecordSets.ElementAt(0);
                    Assert.NotNull(aaaaRecordSet.ETag);

                    // by default zone access type should be public
                    Assert.Equal(ZoneType.Public, dnsZone.AccessType);

                    // Try updates with invalid eTag
                    //
                    AggregateException compositeException = null;
                    try
                    {
                        dnsZone.Update()
                            .UpdateARecordSet("www")
                                .WithETagCheck(aRecordSet.ETag + "-foo")
                                .Parent()
                            .UpdateAaaaRecordSet("www")
                                .WithETagCheck(aaaaRecordSet.ETag + "-foo")
                                .Parent()
                            .Apply();
                    }
                    catch (AggregateException exception)
                    {
                        compositeException = exception;
                    }
                    Assert.NotNull(compositeException);
                    Assert.Equal(2, compositeException.InnerExceptions.Count());
                    foreach (var exception in compositeException.InnerExceptions)
                    {
                        Assert.True(exception is CloudException);
                        CloudError cloudError = ((CloudException)exception).Body;
                        Assert.NotNull(cloudError);
                        Assert.NotNull(cloudError.Code);
                        Assert.Contains("PreconditionFailed", cloudError.Code);
                    }
                    // Try update with correct etags
                    dnsZone.Update()
                            .UpdateARecordSet("www")
                                .WithIPv4Address("24.97.105.45")
                                .WithETagCheck(aRecordSet.ETag)
                                .Parent()
                            .UpdateAaaaRecordSet("www")
                                .WithETagCheck(aaaaRecordSet.ETag)
                                .Parent()
                            .Apply();

                    // Check A records
                    aRecordSets = dnsZone.ARecordSets.List();
                    Assert.True(aRecordSets.Count() == 1);
                    aRecordSet = aRecordSets.ElementAt(0);
                    Assert.NotNull(aRecordSet.ETag);
                    Assert.True(aRecordSet.IPv4Addresses.Count() == 3);

                    // Check AAAA records
                    aaaaRecordSets = dnsZone.AaaaRecordSets.List();
                    Assert.True(aaaaRecordSets.Count() == 1);
                    aaaaRecordSet = aaaaRecordSets.ElementAt(0);
                    Assert.NotNull(aaaaRecordSet.ETag);
                }
                finally
                {
                    azure.ResourceGroups.BeginDeleteByName(groupName);
                }
            }
        }

        [Fact]
        public void CanDeleteWithExplicitETag()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgdnschash");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var dnsZone = azure.DnsZones.Define(topLevelDomain)
                        .WithNewResourceGroup(groupName, region)
                        .DefineARecordSet("www")
                            .WithIPv4Address("23.96.104.40")
                            .WithIPv4Address("24.97.105.41")
                            .WithTimeToLive(7200)
                            .WithETagCheck()
                            .Attach()
                        .DefineAaaaRecordSet("www")
                            .WithIPv6Address("2001:0db8:85a3:0000:0000:8a2e:0370:7334")
                            .WithIPv6Address("2002:0db9:85a4:0000:0000:8a2e:0371:7335")
                            .WithETagCheck()
                            .Attach()
                        .Create();

                    // Check A records
                    var aRecordSets = dnsZone.ARecordSets.List();
                    Assert.True(aRecordSets.Count() == 1);
                    var aRecordSet = aRecordSets.ElementAt(0);
                    Assert.NotNull(aRecordSet.ETag);

                    // Check AAAA records
                    var aaaaRecordSets = dnsZone.AaaaRecordSets.List();
                    Assert.True(aaaaRecordSets.Count() == 1);
                    var aaaaRecordSet = aaaaRecordSets.ElementAt(0);
                    Assert.NotNull(aaaaRecordSet.ETag);

                    // Try delete with invalid eTag
                    //
                    AggregateException compositeException = null;
                    try
                    {
                        dnsZone.Update()
                                .WithoutARecordSet("www", aRecordSet.ETag + "-foo")
                                .WithoutAaaaRecordSet("www", aaaaRecordSet.ETag + "-foo")
                                .Apply();
                    }
                    catch (AggregateException exception)
                    {
                        compositeException = exception;
                    }
                    Assert.NotNull(compositeException);
                    Assert.Equal(2, compositeException.InnerExceptions.Count());
                    foreach (var exception in compositeException.InnerExceptions)
                    {
                        Assert.True(exception is CloudException);
                        CloudError cloudError = ((CloudException)exception).Body;
                        Assert.NotNull(cloudError);
                        Assert.NotNull(cloudError.Code);
                        Assert.Contains("PreconditionFailed", cloudError.Code);
                    }

                    // Try delete with correct etags
                    dnsZone.Update()
                            .WithoutARecordSet("www", aRecordSet.ETag)
                            .WithoutAaaaRecordSet("www", aaaaRecordSet.ETag)
                            .Apply();

                    // Check A records
                    aRecordSets = dnsZone.ARecordSets.List();
                    Assert.True(aRecordSets.Count() == 0);

                    // Check AAAA records
                    aaaaRecordSets = dnsZone.AaaaRecordSets.List();
                    Assert.True(aaaaRecordSets.Count() == 0);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanUpdateCnameAndTxt()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgdnschash");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var dnsZone = azure.DnsZones.Define(topLevelDomain)
                        .WithNewResourceGroup(groupName, region)
                        .DefineCNameRecordSet("www")
                            .WithAlias("cname.contoso.com")
                            .Attach()
                        .Create();

                    Assert.Equal("cname.contoso.com", dnsZone.CNameRecordSets.GetByName("www").CanonicalName);

                    var sb = new StringBuilder();
                    sb.Append('a', 255);
                    sb.Append('b', 255);
                    sb.Append('c', 1);
                    var text = sb.ToString();

                    dnsZone.Update()
                        .UpdateCNameRecordSet("www")
                            .WithAlias("new.contoso.com")
                            .Parent()
                        .DefineTxtRecordSet("@")
                            .WithText(text)
                            .Attach()
                        .Apply();

                    Assert.Equal("new.contoso.com", dnsZone.CNameRecordSets.GetByName("www").CanonicalName);
                    var text2 = string.Join("", dnsZone.TxtRecordSets.GetByName("@").Records[0].Value);
                    Assert.Equal(text, text2);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    { }
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
