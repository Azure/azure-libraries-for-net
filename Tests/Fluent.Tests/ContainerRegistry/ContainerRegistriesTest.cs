// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ContainerRegistry.Fluent;
using Azure.Tests;
using System.Linq;
using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;

namespace Fluent.Tests
{
    public class ContainerRegistry
    {
        [Fact]
        public void ContainerRegistryCRUD()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var regName = TestUtilities.GenerateName("acr");
                var regName1 = TestUtilities.GenerateName("acr") + "1";
                var regName2 = TestUtilities.GenerateName("acr") + "2";
                var rgName = "rg" + regName;
                var saName = "sa" + regName;
                var webhookName1 = "webhookbing1";
                var webhookName2 = "webhookbing2";
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();
                IRegistry registry1 = null;
                IRegistry registry2 = null;

                try
                {
                    registry1 = registryManager.ContainerRegistries.Define(regName1)
                            .WithRegion(Region.USWestCentral)
                            .WithNewResourceGroup(rgName)
                            .WithClassicSku()
                            .WithNewStorageAccount(saName)
                            .WithRegistryNameAsAdminUser()
                            .WithTag("tag1", "value1")
                            .Create();

                    Assert.True(registry1.AdminUserEnabled);
                    Assert.Equal(registry1.StorageAccountName, saName);

                    var regs = registryManager.ContainerRegistries.List();
                    Assert.True(regs.Count() > 0);

                    IRegistryCredentials registryCredentials1 = registry1.GetCredentials();
                    Assert.NotNull(registryCredentials1);
                    Assert.Equal(regName1, registryCredentials1.Username);
                    Assert.Equal(2, registryCredentials1.AccessKeys.Count);

                    Assert.Empty(registry1.Webhooks.List());

                    registry2 = registryManager.ContainerRegistries.Define(regName2)
                            .WithRegion(Region.USWestCentral)
                            .WithExistingResourceGroup(rgName)
                            .WithBasicSku()
                            .WithRegistryNameAsAdminUser()
                            .DefineWebhook(webhookName1)
                                .WithTriggerWhen(WebhookAction.Push, WebhookAction.Delete)
                                .WithServiceUri("https://www.bing.com")
                                .WithRepositoriesScope("")
                                .WithTag("tag", "value")
                                .WithCustomHeader("name", "value")
                                .Attach()
                            .DefineWebhook(webhookName2)
                                .WithTriggerWhen(WebhookAction.Push)
                                .WithServiceUri("https://www.bing.com")
                                .Enabled(false)
                                .WithRepositoriesScope("")
                                .WithTag("tag", "value")
                                .WithCustomHeader("name", "value")
                                .Attach()
                            .WithTag("tag1", "value1")
                            .Create();

                    Assert.True(registry2.AdminUserEnabled);

                    IRegistryCredentials registryCredentials2 = registry2.GetCredentials();
                    Assert.NotNull(registryCredentials2);

                    Assert.Equal(regName2, registryCredentials2.Username);
                    Assert.Equal(2, registryCredentials2.AccessKeys.Count);

                    Assert.True(registry2.Webhooks.List().Count() == 2);

                    IWebhook webhook = registry2.Webhooks.Get(webhookName1);
                    Assert.True(webhook.IsEnabled());
                    Assert.True(webhook.Tags.ContainsKey("tag"));
                    Assert.Equal("https://www.bing.com", webhook.ServiceUri());
                    Assert.Equal(2, webhook.Triggers().Count);

                    webhook = registryManager.ContainerRegistries.Webhooks.Get(rgName, regName2, webhookName2);
                    Assert.False(webhook.IsEnabled());
                    Assert.True(webhook.Tags.ContainsKey("tag"));
                    Assert.Equal("https://www.bing.com", webhook.ServiceUri());
                    Assert.Equal(1, webhook.Triggers().Count);
                    Assert.Equal(WebhookAction.Push, webhook.Triggers().First());

                    IRegistry registry3 = registryManager.ContainerRegistries.GetById(webhook.ParentId());

                    registry2 = registry3.Update()
                        .WithoutWebhook(webhookName1)
                        .DefineWebhook("webhookms")
                                .WithTriggerWhen(WebhookAction.Push, WebhookAction.Delete)
                                .WithServiceUri("https://www.microsoft.com")
                                .WithRepositoriesScope("")
                                .Enabled(true)
                                .Attach()
                        .UpdateWebhook(webhookName2)
                                .WithServiceUri("https://www.bing.com/maps")
                                .WithTriggerWhen(WebhookAction.Delete)
                                .WithCustomHeader("name", "value")
                                .WithoutTag("tag")
                                .WithTag("tag2", "value2")
                                .Parent()
                        .WithStandardSku()
                        .WithoutTag("tag1")
                        .WithTag("tag2", "value2")
                        .Apply();

                    Assert.True(registry2.Tags.ContainsKey("tag2"));
                    Assert.False(registry2.Tags.ContainsKey("tag1"));

                    webhook = registry2.Webhooks.Get(webhookName2);
                    Assert.False(webhook.IsEnabled());
                    Assert.False(webhook.Tags.ContainsKey("tag"));
                    Assert.True(webhook.Tags.ContainsKey("tag2"));
                    Assert.Equal("https://www.bing.com/maps", webhook.ServiceUri());
                    Assert.Equal(1, webhook.Triggers().Count);
                    Assert.Equal(WebhookAction.Delete, webhook.Triggers().First());

                    webhook.Refresh();
                    webhook.Enable();

                    webhook.Update()
                        .Enabled(false)
                        .WithServiceUri("https://www.msn.com")
                        .WithTriggerWhen(WebhookAction.Push)
                        .WithCustomHeader("header1", "value1")
                        .WithoutTag("tag2")
                        .WithTag("tag3", "value3")
                        .Apply();
                    
                    Assert.False(webhook.IsEnabled());
                    Assert.False(webhook.Tags.ContainsKey("tag2"));
                    Assert.True(webhook.Tags.ContainsKey("tag3"));
                    Assert.Equal("https://www.msn.com", webhook.ServiceUri());
                    Assert.Equal(1, webhook.Triggers().Count);
                    Assert.Equal(WebhookAction.Push, webhook.Triggers().First());

                    webhook.Ping();
                    Assert.NotEmpty(webhook.ListEvents());

                    registry2.Webhooks.Delete(webhookName2);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }

            }
        }
    }
}
