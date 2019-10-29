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
using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.ResourceManager.Fluent;

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
                            .WithStandardSku()
                            .WithRegistryNameAsAdminUser()
                            .WithTag("tag1", "value1")
                            .Create();

                    Assert.True(registry1.AdminUserEnabled);

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

        [Fact(Skip = "Needs personal tokens to run")]
        public void CanCreateFileTask()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string githubRepoUrl = "Replace with your github repository url, eg: https://github.com/Azure/acr.git";
                string githubBranch = "Replace with your github repositoty branch, eg: master";
                string githubPAT = "Replace with your github personal access token which should have the scopes: admin:repo_hook and repo";
                string taskFilePath = "Path to your task file that is relative to the githubRepoUrl to selected branch";
                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                        .WithRegion(Region.USWestCentral)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumSku()
                        .WithRegistryNameAsAdminUser()
                        .WithTag("tag1", "value1")
                        .Create();

                    string taskName = TestUtilities.GenerateName("ft");
                    IRegistryTask registryTask = registryManager.ContainerRegistryTasks.Define(taskName)
                            .WithExistingRegistry(rgName, acrName)
                            .WithLocation(Region.USWestCentral.Name)
                            .WithLinux(Architecture.Amd64)
                            .DefineFileTaskStep()
                                .WithTaskPath(taskFilePath)
                                .Attach()
                            .DefineSourceTrigger("SampleSourceTrigger")
                                .WithGithubAsSourceControl()
                                .WithSourceControlRepositoryUrl(githubRepoUrl)
                                .WithCommitTriggerEvent()
                                .WithPullTriggerEvent()
                                .WithRepositoryBranch(githubBranch)
                                .WithRepositoryAuthentication(TokenType.PAT, githubPAT)
                                .Attach()
                            .WithBaseImageTrigger("SampleBaseImageTrigger", BaseImageTriggerType.Runtime)
                            .WithCpuCount(2)
                            .Create();

                    IRegistryFileTaskStep registryFileTaskStep = (IRegistryFileTaskStep)registryTask.RegistryTaskStep;

                    //Assert the name of the registryTask is correct
                    Assert.Equal(taskName, registryTask.Name);

                    //Assert the resource group name is correct
                    Assert.Equal(rgName, registryTask.ResourceGroupName);

                    //Assert location is correct
                    Assert.Equal(Region.USWestCentral.Name, registryTask.RegionName);

                    //Assert OS is correct
                    Assert.Equal(OS.Linux, registryTask.Platform.Os);

                    //Assert architecture is correct
                    Assert.Equal(Architecture.Amd64.ToString(), registryTask.Platform.Architecture);

                    //Assert that the registryTask file path is correct
                    Assert.Equal(taskFilePath, registryFileTaskStep.TaskFilePath);

                    //Assert CPU count is correct
                    Assert.Equal(2, registryTask.CpuCount);

                    //Assert the length of the source triggers array list is correct
                    Assert.True(registryTask.Trigger.SourceTriggers.Count == 1);

                    //Assert source triggers are correct
                    Assert.Equal("SampleSourceTrigger", registryTask.Trigger.SourceTriggers[0].Name);

                    //Assert base image trigger is correct
                    Assert.Equal("SampleBaseImageTrigger", registryTask.Trigger.BaseImageTrigger.Name);
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

        [Fact(Skip = "Needs personal tokens to run")]
        public void CanUpdateFileTask()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string githubRepoUrl = "Replace with your github repository url, eg: https://github.com/Azure/acr.git";
                string githubBranch = "master";
                string githubPAT = "Replace with your github personal access token which should have the scopes: admin:repo_hook and repo";
                string taskFilePath = "Path to your task file that is relative to the githubRepoUrl to selected branch";
                string taskFileUpdatePath = "Path to your another task file that is relative to the githubRepoUrl to selected branch";
                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();
                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                        .WithRegion(Region.USWestCentral)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumSku()
                        .WithRegistryNameAsAdminUser()
                        .WithTag("tag1", "value1")
                        .Create();

                    string taskName = TestUtilities.GenerateName("ft");
                    IRegistryTask registryTask = registryManager.ContainerRegistryTasks.Define(taskName)
                            .WithExistingRegistry(rgName, acrName)
                            .WithLocation(Region.USWestCentral.Name)
                            .WithLinux(Architecture.Amd64)
                            .DefineFileTaskStep()
                                .WithTaskPath(taskFilePath)
                                .Attach()
                            .DefineSourceTrigger("SampleSourceTrigger")
                                .WithGithubAsSourceControl()
                                .WithSourceControlRepositoryUrl(githubRepoUrl)
                                .WithCommitTriggerEvent()
                                .WithPullTriggerEvent()
                                .WithRepositoryBranch(githubBranch)
                                .WithRepositoryAuthentication(TokenType.PAT, githubPAT)
                                .Attach()
                            .WithBaseImageTrigger("SampleBaseImageTrigger", BaseImageTriggerType.Runtime)
                            .WithCpuCount(2)
                            .Create();

                    registryTask.Update()
                            .UpdateFileTaskStep()
                                .WithTaskPath(taskFileUpdatePath)
                                .Parent()
                            .Apply();

                    IRegistryFileTaskStep registryFileTaskStep = (IRegistryFileTaskStep)registryTask.RegistryTaskStep;

                    //Assert the name of the registryTask is correct
                    Assert.Equal(taskName, registryTask.Name);

                    //Assert the resource group name is correct
                    Assert.Equal(rgName, registryTask.ResourceGroupName);

                    //Assert location is correct
                    Assert.Equal(Region.USWestCentral.Name, registryTask.RegionName);

                    //Assert OS is correct
                    Assert.Equal(OS.Linux.ToString(), registryTask.Platform.Os);

                    //Assert architecture is correct
                    Assert.Equal(Architecture.Amd64.ToString(), registryTask.Platform.Architecture);

                    //Assert CPU count is correct
                    Assert.Equal(2, registryTask.CpuCount);

                    //Assert the length of the source triggers array list is correct
                    Assert.True(registryTask.Trigger.SourceTriggers.Count == 1);

                    //Assert source triggers are correct
                    Assert.Equal("SampleSourceTrigger", registryTask.Trigger.SourceTriggers[0].Name);

                    //Assert base image trigger is correct
                    Assert.Equal("SampleBaseImageTrigger", registryTask.Trigger.BaseImageTrigger.Name);

                    //Checking to see whether file path name is updated correctly
                    Assert.Equal(taskFileUpdatePath, registryFileTaskStep.TaskFilePath);

                    bool errorRaised = false;
                    try
                    {
                        registryTask.Update()
                                .UpdateEncodedTaskStep()
                                .Parent()
                                .Apply();
                    }
                    catch (ArgumentException e)
                    {
                        errorRaised = true;
                    }

                    //Checking to see whether error is raised if update is called on the incorrect registryTask step type.
                    Assert.True(errorRaised);
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

        [Fact(Skip = "Needs personal tokens to run")]
        public void CanCreateEncodedTask()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string githubRepoUrl = "Replace with your github repository url, eg: https://github.com/Azure/acr.git";
                string githubBranch = "master";
                string githubPAT = "Replace with your github personal access token which should have the scopes: admin:repo_hook and repo";
                string encodedTaskContent = "Replace with encoded task content";
                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                        .WithRegion(Region.USWestCentral)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumSku()
                        .WithRegistryNameAsAdminUser()
                        .WithTag("tag1", "value1")
                        .Create();

                    string taskName = TestUtilities.GenerateName("ft");

                    IRegistryTask registryTask = registryManager.ContainerRegistryTasks.Define(taskName)
                            .WithExistingRegistry(rgName, acrName)
                            .WithLocation(Region.USWestCentral.Name)
                            .WithLinux(Architecture.Amd64)
                            .DefineEncodedTaskStep()
                                .WithBase64EncodedTaskContent(encodedTaskContent)
                                .Attach()
                            .DefineSourceTrigger("SampleSourceTrigger")
                                .WithGithubAsSourceControl()
                                .WithSourceControlRepositoryUrl(githubRepoUrl)
                                .WithCommitTriggerEvent()
                                .WithPullTriggerEvent()
                                .WithRepositoryBranch(githubBranch)
                                .WithRepositoryAuthentication(TokenType.PAT, githubPAT)
                                .Attach()
                            .WithBaseImageTrigger("SampleBaseImageTrigger", BaseImageTriggerType.Runtime)
                            .WithCpuCount(2)
                            .Create();

                    IRegistryEncodedTaskStep registryEncodedTaskStep = (IRegistryEncodedTaskStep)registryTask.RegistryTaskStep;

                    //Assert the name of the registryTask is correct
                    Assert.Equal(taskName, registryTask.Name);

                    //Assert the resource group name is correct
                    Assert.Equal(rgName, registryTask.ResourceGroupName);

                    //Assert location is correct
                    Assert.Equal(Region.USWestCentral.Name, registryTask.RegionName);

                    //Assert OS is correct
                    Assert.Equal(OS.Linux, registryTask.Platform.Os);

                    //Assert architecture is correct
                    Assert.Equal(Architecture.Amd64.ToString(), registryTask.Platform.Architecture);

                    //Assert that the registryTask file path is correct
                    Assert.Equal(encodedTaskContent, registryEncodedTaskStep.EncodedTaskContent);

                    //Assert CPU count is correct
                    Assert.Equal(2, registryTask.CpuCount);

                    //Assert the length of the source triggers array list is correct
                    Assert.True(registryTask.Trigger.SourceTriggers.Count == 1);

                    //Assert source triggers are correct
                    Assert.Equal("SampleSourceTrigger", registryTask.Trigger.SourceTriggers[0].Name);

                    //Assert base image trigger is correct
                    Assert.Equal("SampleBaseImageTrigger", registryTask.Trigger.BaseImageTrigger.Name);
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


        [Fact(Skip = "Needs personal tokens to run")]
        public void CanUpdateEncodedTask()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string githubRepoUrl = "Replace with your github repository url, eg: https://github.com/Azure/acr.git";
                string githubBranch = "master";
                string githubPAT = "Replace with your github personal access token which should have the scopes: admin:repo_hook and repo";
                string encodedTaskContent = "Replace with encoded task content";
                string encodedTaskContentUpdate = "Replace with updated encoded task content";
               //
               var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();


                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                        .WithRegion(Region.USWestCentral)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumSku()
                        .WithRegistryNameAsAdminUser()
                        .WithTag("tag1", "value1")
                        .Create();

                    string taskName = TestUtilities.GenerateName("ftmtrc");

                    IRegistryTask registryTask = registryManager.ContainerRegistryTasks.Define(taskName)
                            .WithExistingRegistry(rgName, acrName)
                            .WithLocation(Region.USWestCentral.Name)
                            .WithLinux(Architecture.Amd64)
                            .DefineEncodedTaskStep()
                                .WithBase64EncodedTaskContent(encodedTaskContent)
                                .Attach()
                            .DefineSourceTrigger("SampleSourceTrigger")
                                .WithGithubAsSourceControl()
                                .WithSourceControlRepositoryUrl(githubRepoUrl)
                                .WithCommitTriggerEvent()
                                .WithPullTriggerEvent()
                                .WithRepositoryBranch(githubBranch)
                                .WithRepositoryAuthentication(TokenType.PAT, githubPAT)
                                .Attach()
                            .WithBaseImageTrigger("SampleBaseImageTrigger", BaseImageTriggerType.Runtime)
                            .WithCpuCount(2)
                            .Create();


                    registryTask.Update()
                            .UpdateEncodedTaskStep()
                                .WithBase64EncodedTaskContent(encodedTaskContentUpdate)
                                .Parent()
                            .Apply();

                    IRegistryEncodedTaskStep registryEncodedTaskStep = (IRegistryEncodedTaskStep)registryTask.RegistryTaskStep;

                    //Assert the name of the registryTask is correct
                    Assert.Equal(taskName, registryTask.Name);

                    //Assert the resource group name is correct
                    Assert.Equal(rgName, registryTask.ResourceGroupName);

                    //Assert location is correct
                    Assert.Equal(Region.USWestCentral.Name, registryTask.RegionName);

                    //Assert OS is correct
                    Assert.Equal(OS.Linux, registryTask.Platform.Os);

                    //Assert architecture is correct
                    Assert.Equal(Architecture.Amd64.ToString(), registryTask.Platform.Architecture);

                    //Assert that the registryTask file path is correct
                    Assert.Equal(encodedTaskContentUpdate, registryEncodedTaskStep.EncodedTaskContent);

                    //Assert CPU count is correct
                    Assert.Equal(2, registryTask.CpuCount);

                    //Assert the length of the source triggers array list is correct
                    Assert.True(registryTask.Trigger.SourceTriggers.Count == 1);

                    //Assert source triggers are correct
                    Assert.Equal("SampleSourceTrigger", registryTask.Trigger.SourceTriggers[0].Name);

                    //Assert base image trigger is correct
                    Assert.Equal("SampleBaseImageTrigger", registryTask.Trigger.BaseImageTrigger.Name);

                    bool errorRaised = false;
                    try
                    {
                        registryTask.Update()
                                .UpdateDockerTaskStep()
                                .Parent()
                                .Apply();
                    }
                    catch (ArgumentException e)
                    {
                        errorRaised = true;
                    }

                    //Checking to see whether error is raised if update is called on the incorrect registryTask step type.
                    Assert.True(errorRaised);
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

        [Fact(Skip = "Needs personal tokens to run")]
        public void CanCreateDockerTask()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string githubRepoUrl = "Replace with your github repository url, eg: https://github.com/Azure/acr.git";
                string githubBranch = "Replace with your github repositoty branch, eg: master";
                string githubPAT = "Replace with your github personal access token which should have the scopes: admin:repo_hook and repo";
                string dockerFilePath = "Replace with your docker file path relative to githubContext, eg: Dockerfile";
                string imageName = "Replace with the name of your image.";
                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                        .WithRegion(Region.USWestCentral)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumSku()
                        .WithRegistryNameAsAdminUser()
                        .WithTag("tag1", "value1")
                        .Create();

                    string taskName = TestUtilities.GenerateName("ft");
                    IRegistryTask registryTask = registryManager.ContainerRegistryTasks.Define(taskName)

                            .WithExistingRegistry(rgName, acrName)
                            .WithLocation(Region.USWestCentral.Name)
                            .WithLinux(Architecture.Amd64)
                            .DefineDockerTaskStep()
                                .WithDockerFilePath(dockerFilePath)
                                .WithImageNames(new List<string>() { imageName })
                                .WithCacheEnabled(true)
                                .WithPushEnabled(true)
                                .Attach()
                            .DefineSourceTrigger("SampleSourceTrigger")
                                .WithGithubAsSourceControl()
                                .WithSourceControlRepositoryUrl(githubRepoUrl)
                                .WithCommitTriggerEvent()
                                .WithPullTriggerEvent()
                                .WithRepositoryBranch(githubBranch)
                                .WithRepositoryAuthentication(TokenType.PAT, githubPAT)
                                .Attach()
                            .WithBaseImageTrigger("SampleBaseImageTrigger", BaseImageTriggerType.Runtime)
                            .WithCpuCount(2)
                            .Create();

                    IRegistryDockerTaskStep registryDockerTaskStep = (IRegistryDockerTaskStep)registryTask.RegistryTaskStep;

                    //Assert the name of the registryTask is correct
                    Assert.Equal(taskName, registryTask.Name);

                    //Assert the resource group name is correct
                    Assert.Equal(rgName, registryTask.ResourceGroupName);

                    //Assert location is correct
                    Assert.Equal(Region.USWestCentral.Name, registryTask.RegionName);

                    //Assert OS is correct
                    Assert.Equal(OS.Linux, registryTask.Platform.Os);

                    //Assert architecture is correct
                    Assert.Equal(Architecture.Amd64.ToString(), registryTask.Platform.Architecture);

                    //Assert that the registryTask file path is correct
                    Assert.Equal(dockerFilePath, registryDockerTaskStep.DockerFilePath);

                    //Assert that the image name array is correct
                    Assert.Equal(imageName, registryDockerTaskStep.ImageNames[0]);

                    //Assert that with cache works
                    Assert.True(!registryDockerTaskStep.NoCache);

                    //Assert that push is enabled
                    Assert.True(registryDockerTaskStep.IsPushEnabled);

                    //Assert CPU count is correct
                    Assert.Equal(2, registryTask.CpuCount);

                    //Assert the length of the source triggers array list is correct
                    Assert.True(registryTask.Trigger.SourceTriggers.Count == 1);

                    //Assert source triggers are correct
                    Assert.Equal("SampleSourceTrigger", registryTask.Trigger.SourceTriggers[0].Name);

                    //Assert base image trigger is correct
                    Assert.Equal("SampleBaseImageTrigger", registryTask.Trigger.BaseImageTrigger.Name);

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

        [Fact(Skip = "Needs personal tokens to run")]
        public void CanUpdateDockerTask()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string githubRepoUrl = "Replace with your github repository url, eg: https://github.com/Azure/acr.git";
                string githubBranch = "Replace with your github repositoty branch, eg: master";
                string githubPAT = "Replace with your github personal access token which should have the scopes: admin:repo_hook and repo";
                string dockerFilePath = "Replace with your docker file path relative to githubContext, eg: Dockerfile";
                string dockerFilePathUpdate = "Replace this with your docker file path that you updated your registryTask to, if you did update your docker file path";
                string imageName = "Replace with the name of your image.";

                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                    .WithRegion(Region.USWestCentral)
                    .WithNewResourceGroup(rgName)
                    .WithPremiumSku()
                    .WithRegistryNameAsAdminUser()
                    .WithTag("tag1", "value1")
                    .Create();

                    string taskName = TestUtilities.GenerateName("ftere");
                    IRegistryTask registryTask = registryManager.ContainerRegistryTasks.Define(taskName)

                            .WithExistingRegistry(rgName, acrName)
                            .WithLocation(Region.USWestCentral.Name)
                            .WithLinux(Architecture.Amd64)
                            .DefineDockerTaskStep()
                                .WithDockerFilePath(dockerFilePath)
                                .WithImageNames(new List<string>() { imageName })
                                .WithCacheEnabled(true)
                                .WithPushEnabled(true)
                                .Attach()
                            .DefineSourceTrigger("SampleSourceTrigger")
                                .WithGithubAsSourceControl()
                                .WithSourceControlRepositoryUrl(githubRepoUrl)
                                .WithCommitTriggerEvent()
                                .WithPullTriggerEvent()
                                .WithRepositoryBranch(githubBranch)
                                .WithRepositoryAuthentication(TokenType.PAT, githubPAT)
                                .Attach()
                            .WithBaseImageTrigger("SampleBaseImageTrigger", BaseImageTriggerType.Runtime)
                            .WithCpuCount(2)
                            .Create();

                    registryTask.Update()
                            .UpdateDockerTaskStep()
                                .WithDockerFilePath(dockerFilePathUpdate)
                                .WithCacheEnabled(false)
                                .WithPushEnabled(false)
                                .Parent()
                            .Apply();

                    IRegistryDockerTaskStep registryDockerTaskStep = (IRegistryDockerTaskStep)registryTask.RegistryTaskStep;

                    //Assert the name of the registryTask is correct
                    Assert.Equal(taskName, registryTask.Name);

                    //Assert the resource group name is correct
                    Assert.Equal(rgName, registryTask.ResourceGroupName);

                    //Assert location is correct
                    Assert.Equal(Region.USWestCentral.Name, registryTask.RegionName);

                    //Assert OS is correct
                    Assert.Equal(OS.Linux.ToString(), registryTask.Platform.Os);

                    //Assert architecture is correct
                    Assert.Equal(Architecture.Amd64.ToString(), registryTask.Platform.Architecture);

                    //Assert that the registryTask file path is correct
                    Assert.Equal(dockerFilePathUpdate, registryDockerTaskStep.DockerFilePath);

                    //Assert that the image name array is correct
                    Assert.Equal(imageName, registryDockerTaskStep.ImageNames[0]);

                    //Assert that with no cache works
                    Assert.True(registryDockerTaskStep.NoCache);

                    //Assert that push is disabled
                    Assert.True(!registryDockerTaskStep.IsPushEnabled);

                    //Assert the length of the source triggers array list is correct
                    Assert.True(registryTask.Trigger.SourceTriggers.Count == 1);

                    //Assert source triggers are correct
                    Assert.Equal("SampleSourceTrigger", registryTask.Trigger.SourceTriggers[0].Name);

                    //Assert base image trigger is correct
                    Assert.Equal("SampleBaseImageTrigger", registryTask.Trigger.BaseImageTrigger.Name);

                    bool errorRaised = false;
                    try
                    {
                        registryTask.Update()
                                .UpdateFileTaskStep()
                                .Parent()
                                .Apply();
                    }
                    catch (ArgumentException e)
                    {
                        errorRaised = true;
                    }

                    //Checking to see whether error is raised if update is called on the incorrect registryTask step type.
                    Assert.True(errorRaised);
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

        [Fact(Skip = "Needs github repo with proper files to run")]
        public void CanCreateFileTaskRunRequestFromRegistry()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string sourceLocation = "URL of your source repository.";
                string taskFilePath = "Path to your file task that is relative to your source repository URL.";
                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                        .WithRegion(Region.USWestCentral)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumSku()
                        .WithRegistryNameAsAdminUser()
                        .WithTag("tag1", "value1")
                        .Create();

                    IRegistryTaskRun registryTaskRun = registry.ScheduleRun()
                            .WithWindows()
                            .WithFileTaskRunRequest()
                                .DefineFileTaskStep()
                                    .WithTaskPath(taskFilePath)
                                    .Attach()
                                .WithSourceLocation(sourceLocation)
                            .WithArchiveEnabled(true)
                            .Execute();

                    registryTaskRun.Refresh();
                    Assert.Equal(registry.ResourceGroupName, registryTaskRun.ResourceGroupName);
                    Assert.Equal(acrName, registryTaskRun.RegistryName);
                    Assert.True(registryTaskRun.IsArchiveEnabled);
                    Assert.Equal(OS.Windows, registryTaskRun.Platform.Os);

                    IEnumerable<IRegistryTaskRun> registryTaskRuns = registryManager.RegistryTaskRuns.ListByRegistry(rgName, acrName);
                    IRegistryTaskRun registryTaskRunFromList = registryTaskRuns.First<IRegistryTaskRun>();
                    Assert.True(registryTaskRunFromList.Status != null);
                    Assert.Equal("QuickRun", registryTaskRunFromList.RunType.ToString());
                    Assert.True(registryTaskRunFromList.IsArchiveEnabled);
                    Assert.Equal(OS.Windows, registryTaskRunFromList.Platform.Os);
                    Assert.Equal("Succeeded", registryTaskRunFromList.ProvisioningState.ToString());

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

        [Fact(Skip = "Needs github repo with proper files to run")]
        public void CanCreateFileTaskRunRequestFromRuns()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string sourceLocation = "URL of your source repository.";
                string taskFilePath = "Path to your file task that is relative to your source repository URL.";
                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                    .WithRegion(Region.USWestCentral)
                    .WithNewResourceGroup(rgName)
                    .WithPremiumSku()
                    .WithRegistryNameAsAdminUser()
                    .WithTag("tag1", "value1")
                    .Create();

                    IRegistryTaskRun registryTaskRun = registryManager.RegistryTaskRuns.ScheduleRun()
                            .WithExistingRegistry(rgName, acrName)
                            .WithLinux()
                            .WithFileTaskRunRequest()
                                .DefineFileTaskStep()
                                    .WithTaskPath(taskFilePath)
                                    .Attach()
                            .WithSourceLocation(sourceLocation)
                            .WithArchiveEnabled(true)
                            .Execute();

                    registryTaskRun.Refresh();
                    Assert.Equal(registry.ResourceGroupName, registryTaskRun.ResourceGroupName);
                    Assert.Equal(acrName, registryTaskRun.RegistryName);
                    Assert.True(registryTaskRun.IsArchiveEnabled);
                    Assert.Equal(OS.Linux, registryTaskRun.Platform.Os);

                    IEnumerable<IRegistryTaskRun> registryTaskRuns = registryManager.RegistryTaskRuns.ListByRegistry(rgName, acrName);
                    IRegistryTaskRun registryTaskRunFromList = registryTaskRuns.First<IRegistryTaskRun>();
                    Assert.True(registryTaskRunFromList.Status != null);
                    Assert.Equal("QuickRun", registryTaskRunFromList.RunType.ToString());
                    Assert.True(registryTaskRunFromList.IsArchiveEnabled);
                    Assert.Equal(OS.Linux, registryTaskRunFromList.Platform.Os);
                    Assert.Equal("Succeeded", registryTaskRunFromList.ProvisioningState.ToString());
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

        [Fact(Skip = "Needs github repo with proper files to run")]
        public void CanCreateEncodedTaskRunRequestFromRegistry()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string sourceLocation = "URL of your source repository.";
                string encodedTaskContent = "base 64 encoded task content";
                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                        .WithRegion(Region.USWestCentral)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumSku()
                        .WithRegistryNameAsAdminUser()
                        .WithTag("tag1", "value1")
                        .Create();

                    IRegistryTaskRun registryTaskRun = registry.ScheduleRun()
                            .WithLinux()
                            .WithEncodedTaskRunRequest()
                                .DefineEncodedTaskStep()
                                    .WithBase64EncodedTaskContent(encodedTaskContent)
                                    .Attach()
                                .WithSourceLocation(sourceLocation)
                            .WithArchiveEnabled(true)
                            .Execute();


                    registryTaskRun.Refresh();

                    Assert.Equal(registry.ResourceGroupName, registryTaskRun.ResourceGroupName);
                    Assert.Equal(acrName, registryTaskRun.RegistryName);
                    Assert.True(registryTaskRun.IsArchiveEnabled);
                    Assert.Equal(OS.Linux, registryTaskRun.Platform.Os);

                    IEnumerable<IRegistryTaskRun> registryTaskRuns = registryManager.RegistryTaskRuns.ListByRegistry(rgName, acrName);
                    IRegistryTaskRun registryTaskRunFromList = registryTaskRuns.First<IRegistryTaskRun>();
                    Assert.True(registryTaskRunFromList.Status != null);
                    Assert.Equal("QuickRun", registryTaskRunFromList.RunType.ToString());
                    Assert.True(registryTaskRunFromList.IsArchiveEnabled);
                    Assert.Equal(OS.Linux, registryTaskRunFromList.Platform.Os);
                    Assert.Equal("Succeeded", registryTaskRunFromList.ProvisioningState.ToString());
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

        [Fact(Skip = "Needs github repo with proper files to run")]
        public void CanCreateEncodedTaskRunRequestFromRuns()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string sourceLocation = "URL of your source repository.";
                string encodedTaskContent = "base 64 encoded task content";

                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                    .WithRegion(Region.USWestCentral)
                    .WithNewResourceGroup(rgName)
                    .WithPremiumSku()
                    .WithRegistryNameAsAdminUser()
                    .WithTag("tag1", "value1")
                    .Create();

                    IRegistryTaskRun registryTaskRun = registryManager.RegistryTaskRuns.ScheduleRun()
                            .WithExistingRegistry(rgName, acrName)
                            .WithLinux()
                            .WithEncodedTaskRunRequest()
                                .DefineEncodedTaskStep()
                                    .WithBase64EncodedTaskContent(encodedTaskContent)
                                    .Attach()
                            .WithSourceLocation(sourceLocation)
                            .WithArchiveEnabled(true)
                            .Execute();

                    registryTaskRun.Refresh();

                    Assert.Equal(registry.ResourceGroupName, registryTaskRun.ResourceGroupName);
                    Assert.Equal(acrName, registryTaskRun.RegistryName);
                    Assert.True(registryTaskRun.IsArchiveEnabled);
                    Assert.Equal(OS.Linux, registryTaskRun.Platform.Os);

                    IEnumerable<IRegistryTaskRun> registryTaskRuns = registryManager.RegistryTaskRuns.ListByRegistry(rgName, acrName);
                    IRegistryTaskRun registryTaskRunFromList = registryTaskRuns.First<IRegistryTaskRun>();
                    Assert.True(registryTaskRunFromList.Status != null);
                    Assert.Equal("QuickRun", registryTaskRunFromList.RunType.ToString());
                    Assert.True(registryTaskRunFromList.IsArchiveEnabled);
                    Assert.Equal(OS.Linux, registryTaskRunFromList.Platform.Os);
                    Assert.Equal("Succeeded", registryTaskRunFromList.ProvisioningState);
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

        [Fact(Skip = "Needs github repo with proper files to run")]
        public void CanCreateDockerTaskRunRequestFromRegistry()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string sourceLocation = "URL of your source repository.";
                string dockerFilePath = "Replace with your docker file path relative to githubContext, eg: Dockerfile";
                string imageName = "Replace with the name of your image.";

                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                        .WithRegion(Region.USWestCentral)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumSku()
                        .WithRegistryNameAsAdminUser()
                        .WithTag("tag1", "value1")
                        .Create();

                    IRegistryTaskRun registryTaskRun = registry.ScheduleRun()
                            .WithLinux()
                            .WithDockerTaskRunRequest()
                                .DefineDockerTaskStep()
                                    .WithDockerFilePath(dockerFilePath)
                                    .WithImageNames(new List<string>() { imageName })
                                    .WithCacheEnabled(true)
                                    .WithPushEnabled(true)
                                    .Attach()
                                .WithSourceLocation(sourceLocation)
                            .WithArchiveEnabled(true)
                            .Execute();

                    registryTaskRun.Refresh();
                    Assert.Equal(registry.ResourceGroupName, registryTaskRun.ResourceGroupName);
                    Assert.Equal(acrName, registryTaskRun.RegistryName);
                    Assert.True(registryTaskRun.IsArchiveEnabled);
                    Assert.Equal(OS.Linux, registryTaskRun.Platform.Os);

                    IEnumerable<IRegistryTaskRun> registryTaskRuns = registryManager.RegistryTaskRuns.ListByRegistry(rgName, acrName);
                    IRegistryTaskRun registryTaskRunFromList = registryTaskRuns.First<IRegistryTaskRun>();
                    Assert.True(registryTaskRunFromList.Status != null);
                    Assert.Equal("QuickRun", registryTaskRunFromList.RunType.ToString());
                    Assert.True(registryTaskRunFromList.IsArchiveEnabled);
                    Assert.Equal(OS.Linux, registryTaskRunFromList.Platform.Os);
                    Assert.Equal("Succeeded", registryTaskRunFromList.ProvisioningState.ToString());
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

        [Fact(Skip = "Needs github repo with proper files to run")]
        public void CanCreateDockerTaskRunRequestFromRuns()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string sourceLocation = "URL of your source repository.";
                string dockerFilePath = "Replace with your docker file path relative to githubContext, eg: Dockerfile";
                string imageName = "Replace with the name of your image.";

                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                        .WithRegion(Region.USWestCentral)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumSku()
                        .WithRegistryNameAsAdminUser()
                        .WithTag("tag1", "value1")
                        .Create();

                    IRegistryTaskRun registryTaskRun = registryManager.RegistryTaskRuns.ScheduleRun()
                            .WithExistingRegistry(rgName, acrName)
                            .WithLinux()
                            .WithDockerTaskRunRequest()
                                .DefineDockerTaskStep()
                                    .WithDockerFilePath(dockerFilePath)
                                    .WithImageNames(new List<string>() { imageName })
                                    .WithCacheEnabled(true)
                                    .WithPushEnabled(true)
                                    .Attach()
                            .WithSourceLocation(sourceLocation)
                            .WithArchiveEnabled(true)
                            .Execute();

                    registryTaskRun.Refresh();
                    Assert.Equal(registry.ResourceGroupName, registryTaskRun.ResourceGroupName);
                    Assert.Equal(acrName, registryTaskRun.RegistryName);

                    Assert.True(registryTaskRun.IsArchiveEnabled);
                    Assert.Equal(OS.Linux, registryTaskRun.Platform.Os);

                    IEnumerable<IRegistryTaskRun> registryTaskRuns = registryManager.RegistryTaskRuns.ListByRegistry(rgName, acrName);
                    IRegistryTaskRun registryTaskRunFromList = registryTaskRuns.First<IRegistryTaskRun>();
                    Assert.True(registryTaskRunFromList.Status != null);
                    Assert.Equal("QuickRun", registryTaskRunFromList.RunType.ToString());
                    Assert.True(registryTaskRunFromList.IsArchiveEnabled);
                    Assert.Equal(OS.Linux, registryTaskRunFromList.Platform.Os);
                    Assert.Equal("Succeeded", registryTaskRunFromList.ProvisioningState);

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

        [Fact(Skip = "Needs personal tokens to run")]
        public void CanCreateTaskRunRequestFromRegistry()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string taskName = TestUtilities.GenerateName("ft");
                string githubRepoUrl = "Replace with your github repository url, eg: https://github.com/Azure/acr.git";
                string githubBranch = "Replace with your github repositoty branch, eg: master";
                string dockerFilePath = "Replace with your docker file path relative to githubContext, eg: Dockerfile";
                string githubPAT = "Replace with your github personal access token which should have the scopes: admin:repo_hook and repo";
                string imageName = "Replace with the name of your image.";
                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                   .WithRegion(Region.USWestCentral)
                   .WithNewResourceGroup(rgName)
                   .WithPremiumSku()
                   .WithRegistryNameAsAdminUser()
                   .WithTag("tag1", "value1")
                   .Create();

                    IRegistryTask registryTask = registryManager.ContainerRegistryTasks.Define(taskName)

                            .WithExistingRegistry(rgName, acrName)
                            .WithLocation(Region.USWestCentral.Name)
                            .WithLinux(Architecture.Amd64)
                            .DefineDockerTaskStep()
                                .WithDockerFilePath(dockerFilePath)
                                .WithImageNames(new List<string>() { imageName })
                                .WithCacheEnabled(true)
                                .WithPushEnabled(true)
                                .Attach()
                            .DefineSourceTrigger("SampleSourceTrigger")
                                .WithGithubAsSourceControl()
                                .WithSourceControlRepositoryUrl(githubRepoUrl)
                                .WithCommitTriggerEvent()
                                .WithPullTriggerEvent()
                                .WithRepositoryBranch(githubBranch)
                                .WithRepositoryAuthentication(TokenType.PAT, githubPAT)
                                .Attach()
                            .WithBaseImageTrigger("SampleBaseImageTrigger", BaseImageTriggerType.Runtime)
                            .WithCpuCount(2)
                            .Create();

                    IRegistryTaskRun registryTaskRun = registry.ScheduleRun()
                            .WithTaskRunRequest(taskName)
                            .WithArchiveEnabled(true)
                            .Execute();

                    bool stillQueued = true;
                    while (stillQueued)
                    {
                        registryTaskRun.Refresh();
                        if (registryTaskRun.Status != RunStatus.Queued)
                        {
                            stillQueued = false;
                        }
                        if (registryTaskRun.Status == RunStatus.Failed)
                        {
                            Console.WriteLine(registryManager.RegistryTaskRuns.GetLogSasUrl(rgName, acrName, registryTaskRun.RunId));
                            stillQueued = false;
                        }
                        SdkContext.DelayProvider.Delay(10000);
                    }

                    Assert.Equal(registry.ResourceGroupName, registryTaskRun.ResourceGroupName);
                    Assert.Equal(acrName, registryTaskRun.RegistryName);
                    Assert.Equal(taskName, registryTaskRun.TaskName);
                    Assert.True(registryTaskRun.IsArchiveEnabled);
                    Assert.Equal(OS.Linux, registryTaskRun.Platform.Os);

                    IEnumerable<IRegistryTaskRun> registryTaskRuns = registryManager.RegistryTaskRuns.ListByRegistry(rgName, acrName);
                    IRegistryTaskRun registryTaskRunFromList = registryTaskRuns.First<IRegistryTaskRun>();
                    Assert.True(registryTaskRunFromList.Status != null);
                    Assert.Equal("QuickRun", registryTaskRunFromList.RunType.ToString());
                    Assert.True(registryTaskRunFromList.IsArchiveEnabled);
                    Assert.Equal(OS.Linux, registryTaskRunFromList.Platform.Os);
                    Assert.Equal("Succeeded", registryTaskRunFromList.ProvisioningState);
                    Assert.Equal(taskName, registryTaskRunFromList.TaskName);
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

        [Fact(Skip = "Needs personal tokens to run")]
        public void CanCreateTaksTaskRunRequestFromRuns()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string taskName = TestUtilities.GenerateName("ft");

                string githubRepoUrl = "Replace with your github repository url, eg: https://github.com/Azure/acr.git";
                string githubBranch = "Replace with your github repositoty branch, eg: master";
                string githubPAT = "Replace with your github personal access token which should have the scopes: admin:repo_hook and repo";
                string dockerFilePath = "Replace with your docker file path relative to githubContext, eg: Dockerfile";
                string imageName = "Replace with the name of your image.";
                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                        .WithRegion(Region.USWestCentral)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumSku()
                        .WithRegistryNameAsAdminUser()
                        .WithTag("tag1", "value1")
                        .Create();

                    IRegistryTask registryTask = registryManager.ContainerRegistryTasks.Define(taskName)
                            .WithExistingRegistry(rgName, acrName)
                            .WithLocation(Region.USWestCentral.Name)
                            .WithLinux(Architecture.Amd64)
                            .DefineDockerTaskStep()
                                .WithDockerFilePath(dockerFilePath)
                                .WithImageNames(new List<string> { imageName })
                                .WithCacheEnabled(true)
                                .WithPushEnabled(true)
                                .Attach()
                            .DefineSourceTrigger("SampleSourceTrigger")
                                .WithGithubAsSourceControl()
                                .WithSourceControlRepositoryUrl(githubRepoUrl)
                                .WithCommitTriggerEvent()
                                .WithPullTriggerEvent()
                                .WithRepositoryBranch(githubBranch)
                                .WithRepositoryAuthentication(TokenType.PAT, githubPAT)
                                .Attach()
                            .WithBaseImageTrigger("SampleBaseImageTrigger", BaseImageTriggerType.Runtime)
                            .WithCpuCount(2)
                            .Create();

                    IRegistryTaskRun registryTaskRun = registryManager.RegistryTaskRuns.ScheduleRun()
                            .WithExistingRegistry(rgName, acrName)
                            .WithTaskRunRequest(taskName)
                            .WithArchiveEnabled(true)
                            .Execute();

                    bool stillQueued = true;
                    while (stillQueued)
                    {
                        registryTaskRun.Refresh();
                        if (registryTaskRun.Status != RunStatus.Queued)
                        {
                            stillQueued = false;
                        }
                        if (registryTaskRun.Status == RunStatus.Failed)
                        {
                            Console.WriteLine(registryManager.RegistryTaskRuns.GetLogSasUrl(rgName, acrName, registryTaskRun.RunId));
                            stillQueued = false;
                        }
                        SdkContext.DelayProvider.Delay(10000);
                    }
                    Assert.Equal(registry.ResourceGroupName, registryTaskRun.ResourceGroupName);
                    Assert.Equal(acrName, registryTaskRun.RegistryName);
                    Assert.Equal(taskName, registryTaskRun.TaskName);
                    Assert.True(registryTaskRun.IsArchiveEnabled);
                    Assert.Equal(OS.Linux, registryTaskRun.Platform.Os);


                    IEnumerable<IRegistryTaskRun> registryTaskRuns = registryManager.RegistryTaskRuns.ListByRegistry(rgName, acrName);
                    IRegistryTaskRun registryTaskRunFromList = registryTaskRuns.First<IRegistryTaskRun>();
                    Assert.True(registryTaskRunFromList.Status != null);
                    Assert.Equal("QuickRun", registryTaskRunFromList.RunType.ToString());
                    Assert.True(registryTaskRunFromList.IsArchiveEnabled);
                    Assert.Equal(OS.Linux, registryTaskRunFromList.Platform.Os);
                    Assert.Equal("Succeeded", registryTaskRunFromList.ProvisioningState);
                    Assert.Equal(taskName, registryTaskRunFromList.TaskName);

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

        [Fact(Skip = "Needs personal tokens to run")]
        public void CanRetrieveBuildSourceUploadUrlFromRegistryAndRegistries()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                        .WithRegion(Region.USWestCentral)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumSku()
                        .WithRegistryNameAsAdminUser()
                        .WithTag("tag1", "value1")
                        .Create();

                    //Calling getBuildSourceUploadUrl from Registry
                    ISourceUploadDefinition buildSourceUploadUrlRegistry = registry.GetBuildSourceUploadUrl();
                    Assert.NotNull(buildSourceUploadUrlRegistry.RelativePath);
                    Assert.NotNull(buildSourceUploadUrlRegistry.UploadUrl);

                    //Calling getBuildSourceUploadUrl from Registries
                    ISourceUploadDefinition buildSourceUploadUrlRegistries = registryManager.ContainerRegistries.GetBuildSourceUploadUrl(rgName, acrName);
                    Assert.NotNull(buildSourceUploadUrlRegistries.RelativePath);
                    Assert.NotNull(buildSourceUploadUrlRegistries.UploadUrl);
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

        [Fact(Skip = "Needs personal tokens to run")]
        public void CanCancelAndDeleteRunsAndTasks()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string taskName = TestUtilities.GenerateName("ft");
                string githubRepoUrl = "Replace with your github repository url, eg: https://github.com/Azure/acr.git";
                string githubBranch = "Replace with your github repositoty branch, eg: master";
                string dockerFilePath = "Replace with your docker file path relative to githubContext, eg: Dockerfile";
                string githubPAT = "Replace with your github personal access token which should have the scopes: admin:repo_hook and repo";
                string imageName = "Replace with the name of your image.";

                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                        .WithRegion(Region.USWestCentral)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumSku()
                        .WithRegistryNameAsAdminUser()
                        .WithTag("tag1", "value1")
                        .Create();


                    IRegistryTask registryTask = registryManager.ContainerRegistryTasks.Define(taskName)

                            .WithExistingRegistry(rgName, acrName)
                            .WithLocation(Region.USWestCentral.Name)
                            .WithLinux(Architecture.Amd64)
                            .DefineDockerTaskStep()
                                .WithDockerFilePath(dockerFilePath)
                                .WithImageNames(new List<string> { imageName })
                                .WithCacheEnabled(true)
                                .WithPushEnabled(true)
                                .Attach()
                            .DefineSourceTrigger("SampleSourceTrigger")
                                .WithGithubAsSourceControl()
                                .WithSourceControlRepositoryUrl(githubRepoUrl)
                                .WithCommitTriggerEvent()
                                .WithPullTriggerEvent()
                                .WithRepositoryBranch(githubBranch)
                                .WithRepositoryAuthentication(TokenType.PAT, githubPAT)
                                .Attach()
                            .WithBaseImageTrigger("SampleBaseImageTrigger", BaseImageTriggerType.Runtime)
                            .WithCpuCount(2)
                            .Create();

                    IRegistryTaskRun registryTaskRun = registry.ScheduleRun()
                            .WithTaskRunRequest(taskName)
                            .WithArchiveEnabled(true)
                            .Execute();

                    bool stillQueued = true;
                    while (stillQueued)
                    {
                        registryTaskRun.Refresh();
                        if (registryTaskRun.Status != RunStatus.Queued)
                        {
                            stillQueued = false;
                        }
                        if (registryTaskRun.Status == RunStatus.Failed)
                        {
                            Console.WriteLine(registryManager.RegistryTaskRuns.GetLogSasUrl(rgName, acrName, registryTaskRun.RunId));
                            Assert.True(false, "Registry registryTask run failed");
                        }
                        SdkContext.DelayProvider.Delay(10000);
                    }

                    Assert.True(registryManager.RegistryTaskRuns.ListByRegistry(rgName, acrName).Count() == 1);

                    //cancelling the run we just created
                    registryManager.RegistryTaskRuns.Cancel(rgName, acrName, registryTaskRun.RunId);

                    bool notCanceled = true;
                    while (notCanceled)
                    {
                        registryTaskRun.Refresh();
                        if (registryTaskRun.Status == RunStatus.Canceled)
                        {
                            notCanceled = false;
                        }
                        if (registryTaskRun.Status == RunStatus.Failed)
                        {
                            Console.WriteLine(registryManager.RegistryTaskRuns.GetLogSasUrl(rgName, acrName, registryTaskRun.RunId));
                            Assert.True(false, "Registry registryTask run failed");
                        }
                        SdkContext.DelayProvider.Delay(10000);
                    }

                    IEnumerable<IRegistryTaskRun> registryTaskRuns = registryManager.RegistryTaskRuns.ListByRegistry(rgName, acrName);

                    foreach (IRegistryTaskRun rtr in registryTaskRuns)
                    {
                        Assert.True(rtr.Status == RunStatus.Canceled);
                    }

                    //deleting the run we just cancelled
                    foreach (IRegistryTaskRun rtr in registryTaskRuns)
                    {
                        registryManager.ContainerRegistryTasks.DeleteByRegistry(rgName, acrName, taskName);
                    }

                    registryTaskRuns = registryManager.RegistryTaskRuns.ListByRegistry(rgName, acrName);
                    //Test is set to 1 because there is a server side issue that results in task runs not actually being deleted.
                    //Test will fail once the server side issue is fixed.
                    Assert.True(registryManager.ContainerRegistryTasks.ListByRegistry(rgName, acrName).Count() == 1);

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

        [Fact(Skip = "Need a gitrepo with proper file structure to run")]
        public void CanRetrieveLogUrl()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string dockerFilePath = "Replace with your docker file path relative to githubContext, eg: Dockerfile";
                string imageName = "Replace with the name of your image.";
                string sourceLocation = "URL of your source repository.";

                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                            .WithRegion(Region.USWestCentral)
                            .WithNewResourceGroup(rgName)
                            .WithPremiumSku()
                            .WithRegistryNameAsAdminUser()
                            .WithTag("tag1", "value1")
                            .Create();

                    IRegistryTaskRun registryTaskRun = registryManager.RegistryTaskRuns.ScheduleRun()
                            .WithExistingRegistry(rgName, acrName)
                            .WithLinux()
                            .WithDockerTaskRunRequest()
                                .DefineDockerTaskStep()
                                    .WithDockerFilePath(dockerFilePath)
                                    .WithImageNames(new List<string>() { imageName })
                                    .WithCacheEnabled(true)
                                    .WithPushEnabled(true)
                                    .Attach()
                            .WithSourceLocation(sourceLocation)
                            .WithArchiveEnabled(true)
                            .Execute();

                    string sasUrl = registryManager.RegistryTaskRuns.GetLogSasUrl(rgName, acrName, registryTaskRun.RunId);
                    Assert.NotNull(sasUrl);
                    Assert.NotEqual("", sasUrl);
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

        [Fact(Skip = "Needs personal tokens to run")]
        public void CanUpdateTriggers()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string acrName = TestUtilities.GenerateName("acr");
                string rgName = TestUtilities.GenerateName("rgacr");
                string githubRepoUrl = "Replace with your github repository url, eg: https://github.com/Azure/acr.git";
                string githubBranch = "Replace with your github repositoty branch, eg: master";
                string githubPAT = "Replace with your github personal access token which should have the scopes: admin:repo_hook and repo";
                string taskFilePath = "Path to your task file that is relative to the githubRepoUrl";
                string githubRepoUrlUpdate = "Replace with your github repository url to update to, eg: https://github.com/Azure/acr.git";

                //
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    IRegistry registry = registryManager.ContainerRegistries.Define(acrName)
                    .WithRegion(Region.USWestCentral)
                    .WithNewResourceGroup(rgName)
                    .WithPremiumSku()
                    .WithRegistryNameAsAdminUser()
                    .WithTag("tag1", "value1")
                    .Create();

                    string taskName = TestUtilities.GenerateName("ft");
                    IRegistryTask registryTask = registryManager.ContainerRegistryTasks.Define(taskName)
                            .WithExistingRegistry(rgName, acrName)
                            .WithLocation(Region.USWestCentral.Name)
                            .WithLinux(Architecture.Amd64)
                            .DefineFileTaskStep()
                                .WithTaskPath(taskFilePath)
                                .Attach()
                            .DefineSourceTrigger("SampleSourceTrigger")
                                .WithGithubAsSourceControl()
                                .WithSourceControlRepositoryUrl(githubRepoUrl)
                                .WithCommitTriggerEvent()
                                .WithPullTriggerEvent()
                                .WithRepositoryBranch(githubBranch)
                                .WithRepositoryAuthentication(TokenType.PAT, githubPAT)
                                .WithTriggerStatusEnabled()
                                .Attach()
                            .WithBaseImageTrigger("SampleBaseImageTrigger", BaseImageTriggerType.Runtime)
                            .WithCpuCount(2)
                            .Create();

                    //Assert there is the correct number of source triggers
                    Assert.True(registryTask.Trigger.SourceTriggers.Count() == 1);


                    //Assert source control is correct
                    Assert.Equal(SourceControlType.Github.ToString(), registryTask.Trigger.SourceTriggers[0].SourceRepository.SourceControlType);

                    //Assert source control repository url is correct
                    Assert.Equal(githubRepoUrl, registryTask.Trigger.SourceTriggers[0].SourceRepository.RepositoryUrl);

                    //Ignore because of server-side error regarding pull request
                    //Assert source control source trigger event list is of correct size

                    //        Assert.True(registryTask.Trigger.SourceTriggers[0].SourceTriggerEvents.Count() == 2);
                    //
                    //Temporarily set size to 1 so when pull request functionality is added back, there is a test alert
                    Assert.True(registryTask.Trigger.SourceTriggers[0].SourceTriggerEvents.Count() == 1);

                    //Assert source trigger event list contains commit
                    Assert.True(registryTask.Trigger.SourceTriggers[0].SourceTriggerEvents.Contains(SourceTriggerEvent.Commit.ToString()));
                    //
                    //        //Assert source trigger event list contains pull request
                    //        Assert.True(registryTask.Trigger.SourceTriggers[0].SourceTriggerEvents.contains(SourceTriggerEvent.PULLREQUEST));

                    //Assert source control repository branch is correct
                    Assert.Equal(githubBranch, registryTask.Trigger.SourceTriggers[0].SourceRepository.Branch);

                    //Assert trigger status is correct
                    Assert.Equal(TriggerStatus.Enabled.ToString(), registryTask.Trigger.SourceTriggers[0].Status);

                    //Assert name of the base image trigger is correct
                    Assert.Equal("SampleBaseImageTrigger", registryTask.Trigger.BaseImageTrigger.Name);

                    //Assert that the base image trigger type is correct
                    Assert.Equal(BaseImageTriggerType.Runtime.ToString(), registryTask.Trigger.BaseImageTrigger.BaseImageTriggerType);

                    registryTask.Update()
                            .UpdateSourceTrigger("SampleSourceTrigger")
                                .WithGithubAsSourceControl()
                                .WithSourceControlRepositoryUrl(githubRepoUrlUpdate)
                                .WithCommitTriggerEvent()
                                .WithRepositoryAuthentication(TokenType.PAT, githubPAT)
                                .WithTriggerStatusDisabled()
                                .Parent()
                            .UpdateBaseImageTrigger("SampleBaseImageTriggerUpdate", BaseImageTriggerType.All)
                            .Apply();

                    //Assert source triggers are correct
                    Assert.Equal("SampleSourceTrigger", registryTask.Trigger.SourceTriggers[0].Name);

                    //Assert source control is correct
                    Assert.Equal(SourceControlType.Github.ToString(), registryTask.Trigger.SourceTriggers[0].SourceRepository.SourceControlType);

                    //Assert source control repository url is correct
                    Assert.Equal(githubRepoUrlUpdate, registryTask.Trigger.SourceTriggers[0].SourceRepository.RepositoryUrl);

                    //Assert source trigger has correct number of trigger events
                    Assert.True(registryTask.Trigger.SourceTriggers.Count == 1);

                    //Assert source trigger event list contains commit
                    Assert.True(registryTask.Trigger.SourceTriggers[0].SourceTriggerEvents.Contains(SourceTriggerEvent.Commit.ToString()));

                    //Assert trigger status is correct
                    Assert.Equal(TriggerStatus.Disabled.ToString(), registryTask.Trigger.SourceTriggers[0].Status);

                    //Assert name of the base image trigger is correct
                    Assert.Equal("SampleBaseImageTriggerUpdate", registryTask.Trigger.BaseImageTrigger.Name);

                    //Assert that the base image trigger type is correct
                    Assert.Equal(BaseImageTriggerType.All.ToString(), registryTask.Trigger.BaseImageTrigger.BaseImageTriggerType);

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
