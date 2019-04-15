// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using Xunit;

namespace Fluent.Tests.Storage
{
    public class ManagementPolicies
    {
        [Fact]
        public void CanCreateManagementPolicies()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string storageAccountName = TestUtilities.GenerateName("stgbnx");
                string resourceGroupName = TestUtilities.GenerateName("rgstg");
                List<string> blobTypesToFilterFor = new List<string>();
                blobTypesToFilterFor.Add("blockBlob");
                List<string> prefixesToFIlterFor = new List<string>();
                prefixesToFIlterFor.Add("container1/foo");

                try
                {
                    IStorageManager storageManager = TestHelper.CreateStorageManager();
                    IStorageAccount storageAccount = storageManager.StorageAccounts.Define(storageAccountName)
                            .WithRegion(Region.USEast2)
                            .WithNewResourceGroup(resourceGroupName)
                            .WithBlobStorageAccountKind()
                            .WithAccessTier(Microsoft.Azure.Management.Storage.Fluent.Models.AccessTier.Cool)
                            .Create();

                    IManagementPolicies managementPolicies = storageManager.ManagementPolicies;
                    IManagementPolicy managementPolicy = managementPolicies.Define("management-test")
                        .WithExistingStorageAccount(resourceGroupName, storageAccountName)
                        .DefineRule("rule1")
                            .WithLifecycleRuleType()
                            .WithBlobTypeToFilterFor(BlobTypes.BlockBlob)
                            .WithPrefixToFilterFor("container1/foo")
                            .WithTierToCoolActionOnBaseBlob(30)
                            .WithTierToArchiveActionOnBaseBlob(90)
                            .WithDeleteActionOnBaseBlob(2555)
                            .WithDeleteActionOnSnapShot(90)
                            .Attach()
                        .Create();

                    Assert.Equal("rule1", managementPolicy.Policy.Rules[0].Name);
                    Assert.Equal(blobTypesToFilterFor, managementPolicy.Policy.Rules[0].Definition.Filters.BlobTypes);
                    Assert.Equal(prefixesToFIlterFor, managementPolicy.Policy.Rules[0].Definition.Filters.PrefixMatch);
                    Assert.Equal(30, managementPolicy.Policy.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan);
                    Assert.Equal(90, managementPolicy.Policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan);
                    Assert.Equal(2555, managementPolicy.Policy.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan);
                    Assert.Equal(90, managementPolicy.Policy.Rules[0].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(resourceGroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void managementPolicyGetters()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string storageAccountName = TestUtilities.GenerateName("stgbnx");
                string resourceGroupName = TestUtilities.GenerateName("rgstg");
                List<BlobTypes> blobTypesToFilterFor = new List<BlobTypes>();
                blobTypesToFilterFor.Add(BlobTypes.BlockBlob);
                List<string> prefixesToFIlterFor = new List<string>();
                prefixesToFIlterFor.Add("container1/foo");

                try
                {
                    IStorageManager storageManager = TestHelper.CreateStorageManager();
                    IStorageAccount storageAccount = storageManager.StorageAccounts.Define(storageAccountName)
                            .WithRegion(Region.USEast2)
                            .WithNewResourceGroup(resourceGroupName)
                            .WithBlobStorageAccountKind()
                            .WithAccessTier(Microsoft.Azure.Management.Storage.Fluent.Models.AccessTier.Cool)
                            .Create();

                    IManagementPolicies managementPolicies = storageManager.ManagementPolicies;
                    IManagementPolicy managementPolicy = managementPolicies.Define("management-test")
                        .WithExistingStorageAccount(resourceGroupName, storageAccountName)
                        .DefineRule("rule1")
                            .WithLifecycleRuleType()
                            .WithBlobTypeToFilterFor(BlobTypes.BlockBlob)
                            .WithPrefixToFilterFor("container1/foo")
                            .WithTierToCoolActionOnBaseBlob(30)
                            .WithTierToArchiveActionOnBaseBlob(90)
                            .WithDeleteActionOnBaseBlob(2555)
                            .WithDeleteActionOnSnapShot(90)
                            .Attach()
                        .Create();

                    IReadOnlyList<IPolicyRule> rules = managementPolicy.Rules;
                    Assert.Equal("rule1", rules[0].Name);
                    Assert.Equal(blobTypesToFilterFor, rules[0].BlobTypesToFilterFor);
                    Assert.Equal(prefixesToFIlterFor, rules[0].PrefixesToFilterFor);
                    Assert.Equal(30, rules[0].DaysAfterBaseBlobModificationUntilCooling);
                    Assert.Equal(90, rules[0].DaysAfterBaseBlobModificationUntilArchiving);
                    Assert.Equal(2555, rules[0].DaysAfterBaseBlobModificationUntilDeleting);
                    Assert.True(rules[0].DeleteActionOnBaseBlobEnabled);
                    Assert.True(rules[0].DeleteActionOnSnapShotEnabled);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(resourceGroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanUpdateManagementPolicies()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string storageAccountName = TestUtilities.GenerateName("stgbnx");
                string resourceGroupName = TestUtilities.GenerateName("rgstg");
                List<BlobTypes> blobTypesToFilterFor = new List<BlobTypes>();
                blobTypesToFilterFor.Add(BlobTypes.BlockBlob);
                List<string> prefixesToFilterFor = new List<string>();
                prefixesToFilterFor.Add("container1/foo");

                try
                {
                    IStorageManager storageManager = TestHelper.CreateStorageManager();
                    IStorageAccount storageAccount = storageManager.StorageAccounts.Define(storageAccountName)
                            .WithRegion(Region.USEast2)
                            .WithNewResourceGroup(resourceGroupName)
                            .WithBlobStorageAccountKind()
                            .WithAccessTier(Microsoft.Azure.Management.Storage.Fluent.Models.AccessTier.Cool)
                            .Create();

                    IManagementPolicies managementPolicies = storageManager.ManagementPolicies;
                    IManagementPolicy managementPolicy = managementPolicies.Define("management-test")
                        .WithExistingStorageAccount(resourceGroupName, storageAccountName)
                        .DefineRule("rule1")
                            .WithLifecycleRuleType()
                            .WithBlobTypeToFilterFor(BlobTypes.BlockBlob)
                            .WithPrefixToFilterFor("asdf")
                            .WithDeleteActionOnSnapShot(100)
                            .Attach()
                        .DefineRule("rule2")
                            .WithLifecycleRuleType()
                            .WithBlobTypeToFilterFor(BlobTypes.BlockBlob)
                            .WithDeleteActionOnBaseBlob(30)
                            .Attach()
                        .Create();

                    managementPolicy.Update()
                        .UpdateRule("rule1")
                            .WithBlobTypeToFilterFor(BlobTypes.BlockBlob)
                            .WithPrefixesToFilterFor(prefixesToFilterFor)
                            .WithTierToCoolActionOnBaseBlob(30)
                            .WithTierToArchiveActionOnBaseBlob(90)
                            .WithDeleteActionOnBaseBlob(2555)
                            .WithDeleteActionOnSnapShot(90)
                            .Parent()
                        .WithoutRule("rule2")
                        .Apply();

                    IReadOnlyList<IPolicyRule> rules = managementPolicy.Rules;
                    Assert.Single(rules);
                    Assert.Equal("rule1", rules[0].Name);
                    Assert.Equal(blobTypesToFilterFor, rules[0].BlobTypesToFilterFor);
                    Assert.Equal(prefixesToFilterFor, rules[0].PrefixesToFilterFor);
                    Assert.Equal(30, rules[0].DaysAfterBaseBlobModificationUntilCooling);
                    Assert.Equal(90, rules[0].DaysAfterBaseBlobModificationUntilArchiving);
                    Assert.Equal(2555, rules[0].DaysAfterBaseBlobModificationUntilDeleting);
                    Assert.Equal(90, rules[0].DaysAfterSnapShotCreationUntilDeleting);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(resourceGroupName);
                    }
                    catch { }
                }
            }
        }
    }
}
