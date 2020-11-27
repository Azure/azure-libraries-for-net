// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Redis.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Fluent.Tests
{
    public class Redis
    {

        [Fact]
        public void CanCRUDRedisCache()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var GroupName = TestUtilities.GenerateName("javacsmrg");
                var GroupName2 = GroupName + "Second";
                var CacheName = TestUtilities.GenerateName("javacsmrc");
                var CacheName2 = CacheName + "Second";
                var CacheName3 = CacheName + "Third";
                var storageAccountName = TestUtilities.GenerateName("javacsmsa");

                try
                {
                    var redisManager = TestHelper.CreateRedisManager();
                    
                    // Create
                    var resourceGroup = redisManager.ResourceManager.ResourceGroups
                                            .Define(GroupName2)
                                            .WithRegion(Region.USCentral)
                                            .Create();

                    var redisCacheDefinition1 = redisManager.RedisCaches
                            .Define(CacheName)
                            .WithRegion(Region.AsiaEast)
                            .WithNewResourceGroup(GroupName)
                            .WithBasicSku()
                            .Create();

                    var redisCacheDefinition2 = redisManager.RedisCaches
                            .Define(CacheName2)
                            .WithRegion(Region.USCentral)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithPremiumSku()
                            .WithShardCount(10)
                            .WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek.Sunday, 10, TimeSpan.FromMinutes(302))
                            .Create();

                    var redisCacheDefinition3 = redisManager.RedisCaches
                            .Define(CacheName3)
                            .WithRegion(Region.USCentral)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithPremiumSku(2)
                            .WithRedisConfiguration("maxclients", "2")
                            .WithNonSslPort()
                            .WithFirewallRule("rule1", "192.168.0.1", "192.168.0.4")
                            .WithFirewallRule("rule2", "192.168.0.10", "192.168.0.40")
                            // Server throws "The 'minimumTlsVersion' property is not yet supported." exception. Uncomment when fixed.
                            //.WithMinimumTlsVersion(TlsVersion.OneFullStopOne)
                            .Create();

                    var redisCache = redisCacheDefinition1;
                    var redisCachePremium = redisCacheDefinition3;
                    Assert.Equal(GroupName, redisCache.ResourceGroupName);
                    Assert.Equal(SkuName.Basic, redisCache.Sku.Name);

                    // List by Resource Group
                    var redisCaches = redisManager.RedisCaches.ListByResourceGroup(GroupName);

                    if (!redisCaches.Any(r => r.Name.Equals(CacheName, StringComparison.OrdinalIgnoreCase)))
                    {
                        Assert.True(false);
                    }
                    Assert.Single(redisCaches);

                    // List all Redis resources
                    redisCaches = redisManager.RedisCaches.List();

                    if (!redisCaches.Any(r => r.Name.Equals(CacheName, StringComparison.OrdinalIgnoreCase)))
                    {
                        Assert.True(false);
                    }

                    // Get
                    var redisCacheGet = redisManager.RedisCaches.GetByResourceGroup(GroupName, CacheName);
                    Assert.NotNull(redisCacheGet);
                    Assert.Equal(redisCache.Id, redisCacheGet.Id);
                    Assert.Equal(redisCache.ProvisioningState, redisCacheGet.ProvisioningState);

                    // Get Keys
                    var redisKeys = redisCache.GetKeys();
                    Assert.NotNull(redisKeys);
                    Assert.NotNull(redisKeys.PrimaryKey);
                    Assert.NotNull(redisKeys.SecondaryKey);

                    // Regen key
                    var oldKeys = redisCache.RefreshKeys();
                    var updatedPrimaryKey = redisCache.RegenerateKey(RedisKeyType.Primary);
                    var updatedSecondaryKey = redisCache.RegenerateKey(RedisKeyType.Secondary);
                    Assert.NotNull(oldKeys);
                    Assert.NotNull(updatedPrimaryKey);
                    Assert.NotNull(updatedSecondaryKey);
                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        Assert.NotEqual(oldKeys.PrimaryKey, updatedPrimaryKey.PrimaryKey);
                        Assert.Equal(oldKeys.SecondaryKey, updatedPrimaryKey.SecondaryKey);
                        Assert.NotEqual(oldKeys.SecondaryKey, updatedSecondaryKey.SecondaryKey);
                        Assert.NotEqual(updatedPrimaryKey.SecondaryKey, updatedSecondaryKey.SecondaryKey);
                        Assert.Equal(updatedPrimaryKey.PrimaryKey, updatedSecondaryKey.PrimaryKey);
                    }

                    // Update to STANDARD Sku from BASIC SKU
                    redisCache = redisCache.Update()
                            .WithStandardSku()
                            .Apply();
                    Assert.Equal(SkuName.Standard, redisCache.Sku.Name);
                    Assert.Equal(SkuFamily.C, redisCache.Sku.Family);

                    try
                    {
                        redisCache.Update()
                                .WithBasicSku(1)
                                .Apply();
                        Assert.False(true);
                    }
                    catch (CloudException)
                    {
                        // expected since Sku downgrade is not supported
                    }
                    catch (AggregateException ex)
                    {
                        if (ex.InnerException == null ||
                            ex.InnerException == null ||
                            !(ex.InnerException is CloudException))
                        {
                            // expected since Sku downgrade is not supported and the inner exception
                            // should be of type CloudException
                            Assert.False(true);
                        }
                    }

                    // Refresh
                    redisCache.Refresh();

                    // delete
                    redisManager.RedisCaches.DeleteById(redisCache.Id);

                    // Premium SKU Functionality
                    var premiumCache = redisCachePremium.AsPremium();
                    Assert.Equal(SkuFamily.P, premiumCache.Sku.Family);
                    Assert.Equal(2, premiumCache.FirewallRules.Count);
                    Assert.True(premiumCache.FirewallRules.ContainsKey("rule1"));
                    Assert.True(premiumCache.FirewallRules.ContainsKey("rule2"));

                    // Redis configuration update
                    premiumCache.Update()
                            .WithRedisConfiguration("maxclients", "3")
                            .WithoutFirewallRule("rule1")
                            .WithFirewallRule("rule3", "192.168.0.10", "192.168.0.104")
                            .WithoutMinimumTlsVersion()
                            .Apply();

                    Assert.Equal(2, premiumCache.FirewallRules.Count);
                    Assert.True(premiumCache.FirewallRules.ContainsKey("rule2"));
                    Assert.True(premiumCache.FirewallRules.ContainsKey("rule3"));
                    Assert.False(premiumCache.FirewallRules.ContainsKey("rule1"));

                    premiumCache.Update()
                            .WithoutRedisConfiguration("maxclients")
                            .Apply();

                    premiumCache.Update()
                            .WithoutRedisConfiguration()
                            .Apply();

                    Assert.Equal(0, premiumCache.PatchSchedules.Count);
                    premiumCache.Update()
                            .WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek.Monday, 1)
                            .WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek.Tuesday, 5)
                            .Apply();

                    Assert.Equal(2, premiumCache.PatchSchedules.Count);
                    // Reboot
                    premiumCache.ForceReboot(RebootType.AllNodes);

                    // Patch Schedule
                    var patchSchedule = premiumCache.ListPatchSchedules();
                    Assert.Equal(2, patchSchedule.Count());

                    premiumCache.DeletePatchSchedule();

                    patchSchedule = redisManager.RedisCaches
                                                .GetById(premiumCache.Id)
                                                .AsPremium()
                                                .ListPatchSchedules();
                    Assert.Null(patchSchedule);

                    // currently throws because SAS url of the container should be provided as
                    // {"error":{
                    //      "code":"InvalidRequestBody",
                    //      "message": "One of the SAS URIs provided could not be used for the following reason:
                    //                  The SAS token is poorly formatted.\r\nRequestID=ed105089-b93b-427e-9cbb-d78ed80d23b0",
                    //      "target":null}}
                    // com.microsoft.azure.CloudException: One of the SAS URIs provided could not be used for the following reason: The SAS token is poorly formatted.
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(GroupName);
                    }
                    catch
                    { }
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(GroupName2);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanCRUDLinkedServers()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var GroupName = TestUtilities.GenerateName("javacsmrg");
                var GroupName2 = GroupName + "Second";
                var CacheName = TestUtilities.GenerateName("javacsmrc");
                var CacheName2 = CacheName + "Second";
                var CacheName3 = CacheName + "Third";
                var storageAccountName = TestUtilities.GenerateName("javacsmsa");

                try
                {
                    var redisManager = TestHelper.CreateRedisManager();

                    var rgg = redisManager.RedisCaches
                            .Define(CacheName3)
                            .WithRegion(Region.USCentral)
                            .WithNewResourceGroup(GroupName2)
                            .WithPremiumSku(2)
                            .WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek.Sunday, 5, TimeSpan.FromHours(5))
                            .WithRedisConfiguration("maxclients", "2")
                            .WithNonSslPort()
                            .WithFirewallRule("rule1", "192.168.0.1", "192.168.0.4")
                            .WithFirewallRule("rule2", "192.168.0.10", "192.168.0.40")
                            .Create();

                    var rggLinked = redisManager.RedisCaches
                            .Define(CacheName2)
                            .WithRegion(Region.USEast2)
                            .WithExistingResourceGroup(GroupName2)
                            .WithPremiumSku(2)
                            .Create();

                    Assert.NotNull(rgg);
                    Assert.NotNull(rggLinked);

                    var premiumRgg = rgg.AsPremium();

                    var llName = premiumRgg.AddLinkedServer(rggLinked.Id, rggLinked.RegionName, ReplicationRole.Primary);

                    Assert.Equal(ResourceUtils.NameFromResourceId(rggLinked.Id), llName);

                    var linkedServers = premiumRgg.ListLinkedServers();
                    Assert.Equal(1, linkedServers.Count);
                    Assert.Contains(llName, linkedServers.Keys);
                    Assert.Equal(ReplicationRole.Primary, linkedServers[llName]);

                    var repRole = premiumRgg.GetLinkedServerRole(llName);
                    Assert.Equal(ReplicationRole.Primary, repRole);

                    premiumRgg.RemoveLinkedServer(llName);

                    rgg.Update()
                            .WithoutPatchSchedule()
                            .Apply();

                    rggLinked.Update()
                            .WithFirewallRule("rulesmhule", "192.168.1.10", "192.168.1.20")
                            .Apply();

                    linkedServers = premiumRgg.ListLinkedServers();
                    Assert.Equal(0, linkedServers.Count);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(GroupName);
                    }
                    catch
                    { }
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(GroupName2);
                    }
                    catch
                    { }
                }
            }
        }
    }
}
