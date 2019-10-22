// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.Txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Eventhub.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using Xunit;

namespace Fluent.Tests.EventHub
{
    public class EventHub
    {
        [Fact]
        public void CanManage()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgns");
                var namespaceName = TestUtilities.GenerateName("ns111");
                var eventHubName1 = TestUtilities.GenerateName("eh");
                var eventHubName2 = TestUtilities.GenerateName("eh");
                var eventHubName3 = TestUtilities.GenerateName("eh");

                var azure = TestHelper.CreateRollupClient();
                try
                {


                    IEventHubNamespace ehNamespace = azure.EventHubNamespaces
                        .Define(namespaceName)
                            .WithRegion(region)
                            .WithNewResourceGroup(groupName)
                            .WithNewEventHub(eventHubName1)
                            .WithNewEventHub(eventHubName2)
                            .Create();

                    Assert.NotNull(ehNamespace);
                    Assert.NotNull(ehNamespace.Inner);

                    var hubs = ehNamespace.ListEventHubs();
                    HashSet<string> set = new HashSet<string>();
                    foreach (IEventHub hub in hubs) {
                        set.Add(hub.Name);
                    }
                    Assert.Contains(eventHubName1, set);
                    Assert.Contains(eventHubName2, set);

                    hubs = azure.EventHubNamespaces
                            .EventHubs
                            .ListByNamespace(ehNamespace.ResourceGroupName, ehNamespace.Name);

                    set.Clear();
                    foreach (IEventHub hub in hubs) {
                        set.Add(hub.Name);
                    }
                    Assert.Contains(eventHubName1, set);
                    Assert.Contains(eventHubName2, set);

                    azure.EventHubNamespaces
                            .EventHubs
                                .Define(eventHubName3)
                                .WithExistingNamespaceId(ehNamespace.Id)
                                .WithPartitionCount(5)
                                .WithRetentionPeriodInDays(6)
                                .Create();

                    hubs = ehNamespace.ListEventHubs();
                    set.Clear();
                    foreach (IEventHub hub in hubs) {
                        set.Add(hub.Name);
                    }
                    Assert.Contains(eventHubName1, set);
                    Assert.Contains(eventHubName2, set);
                    Assert.Contains(eventHubName3, set);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanManageConusmerGroups()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgns");
                var namespaceName = TestUtilities.GenerateName("ns111");
                var eventHubName = TestUtilities.GenerateName("eh");

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var namespaceCreatable = azure.EventHubNamespaces
                            .Define(namespaceName)
                                .WithRegion(region)
                                .WithNewResourceGroup(groupName);

                    IEventHub eventHub = azure.EventHubs
                            .Define(eventHubName)
                                .WithNewNamespace(namespaceCreatable)
                                .WithNewConsumerGroup("grp1")
                                .WithNewConsumerGroup("grp2", "metadata111")
                                .Create();

                    Assert.NotNull(eventHub);
                    Assert.NotNull(eventHub.Inner);

                    var cGroups = eventHub.ListConsumerGroups();
                    HashSet<string> set = new HashSet<string>();
                    foreach (IEventHubConsumerGroup grp in cGroups)
                    {
                        set.Add(grp.Name);
                    }
                    Assert.Contains("grp1", set);
                    Assert.Contains("grp2", set);

                     cGroups = azure.EventHubs
                            .ConsumerGroups
                            .ListByEventHub(eventHub.NamespaceResourceGroupName, 
                                    eventHub.NamespaceName, eventHub.Name);

                    set.Clear();
                    foreach (IEventHubConsumerGroup rule in cGroups)
                    {
                        set.Add(rule.Name);
                    }
                    Assert.Contains("grp1", set);
                    Assert.Contains("grp2", set);

                    azure.EventHubs
                            .ConsumerGroups
                                .Define("grp3")
                                .WithExistingEventHubId(eventHub.Id)
                                .WithUserMetadata("metadata222")
                                .Create();

                    cGroups = eventHub.ListConsumerGroups();
                    set.Clear();
                    foreach (IEventHubConsumerGroup grp in cGroups)
                    {
                        set.Add(grp.Name);
                    }
                    Assert.Contains("grp1", set);
                    Assert.Contains("grp2", set);
                    Assert.Contains("grp3", set);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanManageAuthorizationRules()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgns");
                var namespaceName = TestUtilities.GenerateName("ns111");
                var eventHubName = TestUtilities.GenerateName("eh");


                var azure = TestHelper.CreateRollupClient();
                try
                {
         
                    var namespaceCreatable = azure.EventHubNamespaces
                            .Define(namespaceName)
                                .WithRegion(region)
                                .WithNewResourceGroup(groupName);

                    IEventHub eventHub = azure.EventHubs
                            .Define(eventHubName)
                                .WithNewNamespace(namespaceCreatable)
                                .WithNewManageRule("mngRule1")
                                .WithNewSendRule("sndRule1")
                                .Create();

                    Assert.NotNull(eventHub);
                    Assert.NotNull(eventHub.Inner);

                    var rules = eventHub.ListAuthorizationRules();
                    HashSet<string> set = new HashSet<string>();
                    foreach (IEventHubAuthorizationRule rule in rules)
                    {
                        set.Add(rule.Name);
                    }
                    Assert.Contains("mngRule1", set);
                    Assert.Contains("sndRule1", set);

                    rules = azure.EventHubs
                            .AuthorizationRules
                            .ListByEventHub(eventHub.NamespaceResourceGroupName, eventHub.NamespaceName, eventHub.Name);

                    set.Clear();
                    foreach (IEventHubAuthorizationRule rule in rules)
                    {
                        set.Add(rule.Name);
                    }
                    Assert.Contains("mngRule1", set);
                    Assert.Contains("sndRule1", set);

                    azure.EventHubs
                            .AuthorizationRules
                            .Define("sndRule2")
                                .WithExistingEventHubId(eventHub.Id)
                                .WithSendAccess()
                                .Create();

                    rules = eventHub.ListAuthorizationRules();
                    set.Clear();
                    foreach (IEventHubAuthorizationRule rule in rules)
                    {
                        set.Add(rule.Name);
                    }
                    Assert.Contains("mngRule1", set);
                    Assert.Contains("sndRule1", set);
                    Assert.Contains("sndRule2", set);
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

        [Fact(Skip = "Test uses data plane storage api")]
        public void CanConfigureDataCapturing()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgns");
                var stgName = TestUtilities.GenerateName("stg");
                var namespaceName = TestUtilities.GenerateName("ns111");
                var eventHubName1 = TestUtilities.GenerateName("eh");
                var eventHubName2 = TestUtilities.GenerateName("eh");

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var storageAccountCreatable = azure.StorageAccounts
                            .Define(stgName)
                                .WithRegion(region)
                                .WithNewResourceGroup(groupName)
                                .WithSku(StorageAccountSkuType.Standard_LRS);

                    var namespaceCreatable = azure.EventHubNamespaces
                            .Define(namespaceName)
                                .WithRegion(region)
                                .WithNewResourceGroup(groupName);

                    var containerName1 = "eventsctr1";

                    IEventHub eventHub1 = azure.EventHubs
                            .Define(eventHubName1)
                                .WithNewNamespace(namespaceCreatable)
                                .WithNewStorageAccountForCapturedData(storageAccountCreatable, containerName1)
                                .WithDataCaptureEnabled()
                                // Window config is optional if not set service will choose default for it2
                                //
                                .WithDataCaptureWindowSizeInSeconds(120)
                                .WithDataCaptureWindowSizeInMB(300)
                                .WithDataCaptureSkipEmptyArchives(true)
                                .Create();

                    Assert.NotNull(eventHub1);
                    Assert.NotNull(eventHub1.Inner);

                    Assert.NotNull(eventHub1.Name);
                    Assert.Equal(eventHub1.Name, eventHubName1, ignoreCase: true);

                    Assert.NotNull(eventHub1.PartitionIds);

                    Assert.True(eventHub1.IsDataCaptureEnabled);
                    Assert.NotNull(eventHub1.CaptureDestination);
                    Assert.Contains("/storageAccounts/", eventHub1.CaptureDestination.StorageAccountResourceId);
                    Assert.Contains(stgName, eventHub1.CaptureDestination.StorageAccountResourceId);
                    Assert.Equal(eventHub1.CaptureDestination.BlobContainer, containerName1, ignoreCase: true);
                    Assert.True(eventHub1.DataCaptureSkipEmptyArchives);

                    // Create another event Hub in the same namespace with data capture uses the same storage account
                    //
                    var stgAccountId = eventHub1.CaptureDestination.StorageAccountResourceId;
                    var containerName2 = "eventsctr2";

                    IEventHub eventHub2 = azure.EventHubs
                            .Define(eventHubName2)
                                .WithNewNamespace(namespaceCreatable)
                                .WithExistingStorageAccountForCapturedData(stgAccountId, containerName2)
                                .WithDataCaptureEnabled()
                                .Create();

                    Assert.True(eventHub2.IsDataCaptureEnabled);
                    Assert.NotNull(eventHub2.CaptureDestination);
                    Assert.Contains("/storageAccounts/", eventHub2.CaptureDestination.StorageAccountResourceId);
                    Assert.Contains(stgName, eventHub2.CaptureDestination.StorageAccountResourceId);
                    Assert.Equal(eventHub2.CaptureDestination.BlobContainer, containerName2, ignoreCase: true);

                    eventHub2.Update()
                            .WithDataCaptureDisabled()
                            .Apply();

                    Assert.False(eventHub2.IsDataCaptureEnabled);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact(Skip = "Test uses data plane storage api")]
        public void CanEnableDataCaptureOnUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgns");

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var stgName = TestUtilities.GenerateName("stg");
                    var namespaceName = TestUtilities.GenerateName("ns111");
                    var eventHubName = TestUtilities.GenerateName("eh");

                    var namespaceCreatable = azure.EventHubNamespaces
                            .Define(namespaceName)
                                .WithRegion(region)
                                .WithNewResourceGroup(groupName);

                    IEventHub eventHub = azure.EventHubs
                            .Define(eventHubName)
                                .WithNewNamespace(namespaceCreatable)
                                .Create();

                    bool exceptionThrown = false;
                    try
                    {
                        eventHub.Update()
                                .WithDataCaptureEnabled()
                                .Apply();
                    }
                    catch
                    {
                        exceptionThrown = true;
                    }
                    Assert.True(exceptionThrown, "Expected IllegalStateException is not thrown");

                    eventHub = eventHub.Refresh();

                    var storageAccountCreatable = azure.StorageAccounts
                            .Define(stgName)
                            .WithRegion(region)
                            .WithNewResourceGroup(groupName)
                            .WithSku(StorageAccountSkuType.Standard_LRS);

                    eventHub.Update()
                            .WithDataCaptureEnabled()
                            .WithNewStorageAccountForCapturedData(storageAccountCreatable, "eventctr")
                            .Apply();

                    Assert.True(eventHub.IsDataCaptureEnabled);
                    Assert.NotNull(eventHub.CaptureDestination);
                    Assert.Contains("/storageAccounts/", eventHub.CaptureDestination.StorageAccountResourceId);
                    Assert.Contains(stgName, eventHub.CaptureDestination.StorageAccountResourceId);
                    Assert.Equal("eventctr", eventHub.CaptureDestination.BlobContainer, ignoreCase: true);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }
    }
}
