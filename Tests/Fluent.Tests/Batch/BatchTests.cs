// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Azure.Management.Batch.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Fluent.Tests
{
    public partial class Batch
    {
        private string rgName = "rgstg158";
        private string batchAccountName = "batchaccount733";
        private string storageAccountName = "sa733";

        [Fact]
        public async Task CanCRUDBatchAccounts()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgstg");
                var batchAccountName = TestUtilities.GenerateName("batchaccount");
                var storageAccountName = TestUtilities.GenerateName("sa");
                try
                {
                    var batchManager = TestHelper.CreateBatchManager();
                    // Create
                    var batchAccount = await batchManager.BatchAccounts
                            .Define(batchAccountName)
                            .WithRegion(Region.AsiaEast)
                            .WithNewResourceGroup(rgName)
                            .CreateAsync();

                    Assert.Equal(rgName, batchAccount.ResourceGroupName);
                    Assert.Null(batchAccount.AutoStorage);
                    // List
                    var accounts = batchManager.BatchAccounts.ListByResourceGroup(rgName);
                    Assert.Contains(accounts, account => StringComparer.OrdinalIgnoreCase.Equals(account.Name, batchAccountName));
                    // Get
                    batchAccount = batchManager.BatchAccounts.GetByResourceGroup(rgName, batchAccountName);
                    Assert.NotNull(batchAccount);

                    // Get Keys
                    BatchAccountKeys keys = batchAccount.GetKeys();
                    Assert.NotNull(keys.Primary);
                    Assert.NotNull(keys.Secondary);

                    BatchAccountKeys newKeys = batchAccount.RegenerateKeys(AccountKeyType.Primary);
                    Assert.NotNull(newKeys.Primary);
                    Assert.NotNull(newKeys.Secondary);

                    Assert.NotEqual(newKeys.Primary, keys.Primary);
                    Assert.Equal(newKeys.Secondary, keys.Secondary);

                    batchAccount = batchAccount.Update()
                            .WithNewStorageAccount(storageAccountName)
                            .Apply();

                    Assert.NotNull(batchAccount.AutoStorage.StorageAccountId);
                    var lastSync = batchAccount.AutoStorage.LastKeySync;

                    batchAccount.SynchronizeAutoStorageKeys();
                    batchAccount.Refresh();

                    Assert.NotEqual(lastSync, batchAccount.AutoStorage.LastKeySync);

                    // Test applications.
                    var applicationId = "myApplication";
                    var applicationDisplayName = "displayName";
                    var applicationPackageName = "applicationPackage";

                    var updatesAllowed = true;

                    batchAccount.Update()
                            .DefineNewApplication(applicationId)
                                .DefineNewApplicationPackage(applicationPackageName)
                            .WithDisplayName(applicationDisplayName)
                            .WithAllowUpdates(updatesAllowed)
                            .Attach()
                            .Apply();
                    Assert.True(batchAccount.Applications.ContainsKey(applicationId));

                    // Refresh to fetch batch account and application again.
                    batchAccount.Refresh();
                    Assert.True(batchAccount.Applications.ContainsKey(applicationId));

                    var application = batchAccount.Applications[applicationId];
                    Assert.Equal(application.DisplayName, applicationDisplayName);
                    Assert.Equal(application.UpdatesAllowed, updatesAllowed);
                    Assert.Equal(1, application.ApplicationPackages.Count);
                    var applicationPackage = application.ApplicationPackages[applicationPackageName];
                    Assert.Equal(applicationPackage.Name, applicationPackageName);

                    // Delete application package directly.
                    applicationPackage.Delete();
                    batchAccount
                            .Update()
                            .WithoutApplication(applicationId)
                            .Apply();

                    batchAccount.Refresh();
                    Assert.False(batchAccount.Applications.ContainsKey(applicationId));

                    var applicationPackage1Name = "applicationPackage1";
                    var applicationPackage2Name = "applicationPackage2";
                    batchAccount.Update()
                            .DefineNewApplication(applicationId)
                                .DefineNewApplicationPackage(applicationPackage1Name)
                                .DefineNewApplicationPackage(applicationPackage2Name)
                            .WithDisplayName(applicationDisplayName)
                            .WithAllowUpdates(updatesAllowed)
                            .Attach()
                            .Apply();
                    Assert.True(batchAccount.Applications.ContainsKey(applicationId));
                    application.Refresh();
                    Assert.Equal(2, application.ApplicationPackages.Count);

                    var newApplicationDisplayName = "newApplicationDisplayName";
                    batchAccount
                            .Update()
                            .UpdateApplication(applicationId)
                                .WithoutApplicationPackage(applicationPackage2Name)
                            .WithDisplayName(newApplicationDisplayName)
                            .Parent()
                            .Apply();
                    application = batchAccount.Applications[applicationId];
                    Assert.Equal(application.DisplayName, newApplicationDisplayName);

                    batchAccount.Refresh();
                    application = batchAccount.Applications[applicationId];

                    Assert.Equal(application.DisplayName, newApplicationDisplayName);
                    Assert.Equal(1, application.ApplicationPackages.Count);

                    applicationPackage = application.ApplicationPackages[applicationPackage1Name];

                    Assert.NotNull(applicationPackage);
                    Assert.NotNull(applicationPackage.Id);
                    Assert.Equal(applicationPackage.Name, applicationPackage1Name);
                    Assert.Null(applicationPackage.Format);

                    batchAccount
                            .Update()
                            .UpdateApplication(applicationId)
                                .WithoutApplicationPackage(applicationPackage1Name)
                            .Parent()
                            .Apply();

                    try
                    {
                        await batchManager.BatchAccounts.DeleteByIdAsync(batchAccount.Id);
                    }
                    catch
                    {
                    }

                    var batchAccounts = batchManager.BatchAccounts.ListByResourceGroup(rgName);

                    Assert.Empty(batchAccounts);
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public async Task CanCreateBatchAccountWithApplication()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                try
                {
                    var applicationId = "myApplication";
                    var applicationDisplayName = "displayName";
                    var allowUpdates = true;

                    var batchManager = TestHelper.CreateBatchManager();

                    // Create
                    var batchAccount = await batchManager.BatchAccounts
                        .Define(batchAccountName)
                        .WithRegion(Region.AsiaSouthEast)
                        .WithNewResourceGroup(rgName)
                        .DefineNewApplication(applicationId)
                            .WithDisplayName(applicationDisplayName)
                            .WithAllowUpdates(allowUpdates)
                            .Attach()
                        .WithNewStorageAccount(storageAccountName)
                        .CreateAsync();
                    Assert.Equal(rgName, batchAccount.ResourceGroupName);
                    Assert.NotNull(batchAccount.AutoStorage);
                    Assert.Equal(ResourceUtils.NameFromResourceId(batchAccount.AutoStorage.StorageAccountId), storageAccountName);

                    // List
                    var accounts = batchManager.BatchAccounts.ListByResourceGroup(rgName);
                    Assert.Contains(accounts, account => StringComparer.OrdinalIgnoreCase.Equals(account.Name, batchAccountName));

                    // Get
                    batchAccount = batchManager.BatchAccounts.GetByResourceGroup(rgName, batchAccountName);
                    Assert.NotNull(batchAccount);

                    Assert.True(batchAccount.Applications.ContainsKey(applicationId));
                    var application = batchAccount.Applications[applicationId];

                    Assert.NotNull(application);
                    Assert.Equal(application.DisplayName, applicationDisplayName);
                    Assert.Equal(application.UpdatesAllowed, allowUpdates);

                    try
                    {
                        await batchManager.BatchAccounts.DeleteByResourceGroupAsync(batchAccount.ResourceGroupName, batchAccountName);
                    }
                    catch
                    {
                    }
                    var batchAccounts = batchManager.BatchAccounts.ListByResourceGroup(rgName);

                    Assert.Empty(batchAccounts);
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public async Task CanCreateBatchAccountWithPool()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                try
                {
                    var poolId = "testPool";
                    var poolDisplayName = "my-pool-name";
                    var vmSize = "STANDARD_D4";
                    var maxTasksPerNode = 13;
                    
                    //create task scheduling policy
                    var taskSchedulingPolicy = new TaskSchedulingPolicy();
                    taskSchedulingPolicy.NodeFillType = ComputeNodeFillType.Pack;

                    //create deployment configuration
                    var deploymentConfiguration = new DeploymentConfiguration();
                    deploymentConfiguration.CloudServiceConfiguration = new CloudServiceConfiguration();
                    deploymentConfiguration.CloudServiceConfiguration.OsFamily = "4";
                    deploymentConfiguration.CloudServiceConfiguration.OsVersion = "WA-GUEST-OS-4.45_201708-01";

                    //create scaling settings
                    var scalingSettings = new Microsoft.Azure.Management.Batch.Fluent.Models.ScaleSettings();
                    scalingSettings.FixedScale = new FixedScaleSettings();
                    scalingSettings.FixedScale.TargetDedicatedNodes = 6;
                    scalingSettings.FixedScale.NodeDeallocationOption = ComputeNodeDeallocationOption.TaskCompletion;

                    //create metadata
                    var metadata = new List<MetadataItem>();
                    metadata.Add(new MetadataItem("metadata-1", "value-1"));
                    metadata.Add(new MetadataItem("metadata-2", "value-2"));

                    //create start task
                    var startTask = new StartTask();
                    var cmdLine = "cmd /c SET";
                    var maxTaskRetryCount = 6;
                    startTask.CommandLine = cmdLine;
                    startTask.EnvironmentSettings = new List<EnvironmentSetting>();
                    startTask.EnvironmentSettings.Add(new EnvironmentSetting("MYSET", "1234"));
                    startTask.UserIdentity = new UserIdentity(default(string), new AutoUserSpecification(AutoUserScope.Pool, ElevationLevel.Admin));
                    startTask.MaxTaskRetryCount = maxTaskRetryCount;
                    startTask.WaitForSuccess = true;
                    startTask.ResourceFiles = new List<ResourceFile>();
                    startTask.ResourceFiles.Add(new ResourceFile(default(string), default(string), "https://testaccount.blob.core.windows.net/example-blob-file", default(string), "c:\\\\temp\\\\gohere", "777"));

                    //create user accounts
                    var userAccounts = new List<UserAccount>();
                    userAccounts.Add(new UserAccount("username1", "examplepassword", ElevationLevel.Admin, new LinuxUserConfiguration(1234, 4567, "sshprivatekeyvalue"), default(WindowsUserConfiguration)));

                    var batchManager = TestHelper.CreateBatchManager();

                    // Create
                    var batchAccount = await batchManager.BatchAccounts
                        .Define(batchAccountName)
                        .WithRegion(Region.AsiaSouthEast)
                        .WithNewResourceGroup(rgName)
                        .WithNewStorageAccount(storageAccountName)
                        .CreateAsync();

                    batchAccount.Update().DefineNewPool(poolId)
                            .WithDisplayName(poolDisplayName)
                            .WithVmSize(vmSize)
                            .WithInterNodeCommunication(InterNodeCommunicationState.Enabled)
                            .WithMaxTasksPerNode(maxTasksPerNode)
                            .WithTaskSchedulingPolicy(taskSchedulingPolicy)
                            .WithDeploymentConfiguration(deploymentConfiguration)
                            .WithScaleSettings(scalingSettings)
                            .WithMetadata(metadata)
                            .WithStartTask(startTask)
                            .WithUserAccount(userAccounts)
                            .Attach()
                            .Apply();

                    Assert.Equal(rgName, batchAccount.ResourceGroupName);
                    Assert.NotNull(batchAccount.AutoStorage);
                    Assert.Equal(ResourceUtils.NameFromResourceId(batchAccount.AutoStorage.StorageAccountId), storageAccountName);

                    // List
                    var accounts = batchManager.BatchAccounts.ListByResourceGroup(rgName);
                    Assert.Contains(accounts, account => StringComparer.OrdinalIgnoreCase.Equals(account.Name, batchAccountName));

                    // Get
                    batchAccount = batchManager.BatchAccounts.GetByResourceGroup(rgName, batchAccountName);
                    Assert.NotNull(batchAccount);

                    Assert.True(batchAccount.Pools.ContainsKey(poolId));
                    batchAccount.Refresh();

                    Assert.True(batchAccount.Pools.ContainsKey(poolId));
                    var pool = batchAccount.Pools[poolId];

                    Assert.NotNull(pool);
                    Assert.Equal(vmSize, pool.VmSize);
                    Assert.Null(pool.MountConfiguration);
                    Assert.NotNull(pool.StartTask);
                    Assert.Equal(cmdLine, pool.StartTask.CommandLine);
                    Assert.NotNull(pool.StartTask.MaxTaskRetryCount);
                    Assert.Equal(maxTaskRetryCount, pool.StartTask.MaxTaskRetryCount);
                    Assert.Equal(1, pool.UserAccounts.Count);

                    batchAccount.Update()
                        .WithoutPool(poolId)
                        .Apply();

                    Assert.False(batchAccount.Pools.ContainsKey(poolId));

                    try
                    {
                        await batchManager.BatchAccounts.DeleteByResourceGroupAsync(batchAccount.ResourceGroupName, batchAccountName);
                    }
                    catch
                    {
                    }
                    var batchAccounts = batchManager.BatchAccounts.ListByResourceGroup(rgName);

                    Assert.Empty(batchAccounts);
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }
    }
}