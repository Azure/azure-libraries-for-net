// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using System.Linq;
using Xunit;
using Fluent.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Test.HttpRecorder;

namespace Fluent.Tests.Storage
{
    public class StorageAccounts
    {
        [Fact (Skip = "Skipping for now because of 503 error 'The service is not yet ready to process any requests. Please retry in a few moments.'")]
        public void CanCheckAvailabilityAndCreate()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgstg");
                var stgName = TestUtilities.GenerateName("stgbnx");
                try
                {
                    var storageManager = TestHelper.CreateStorageManager();

                    var availabilityResult = storageManager
                        .StorageAccounts
                        .CheckNameAvailability(stgName);
                    Assert.NotNull(availabilityResult);
                    Assert.True(availabilityResult.IsAvailable);

                    var storageAccount = storageManager.StorageAccounts.Define(stgName)
                        .WithRegion(Region.USEast2)
                        .WithNewResourceGroup(rgName)
                        .WithTag("aa", "aa")
                        .WithTag("bb", "bb")
                        .Create();

                    Assert.NotNull(storageAccount);
                    Assert.NotNull(storageAccount.Inner);

                    if (storageAccount.Inner.NetworkRuleSet != null)
                    {
                        if (storageAccount.Inner.NetworkRuleSet.VirtualNetworkRules != null)
                        {
                            Assert.Empty(storageAccount.Inner.NetworkRuleSet.VirtualNetworkRules);
                        }
                        if (storageAccount.Inner.NetworkRuleSet.IpRules != null)
                        {
                            Assert.Empty(storageAccount.Inner.NetworkRuleSet.IpRules);
                        }
                    bool isDefaultActionAllow = storageAccount.Inner.NetworkRuleSet.DefaultAction.Equals(DefaultAction.Allow);
                    Assert.True(isDefaultActionAllow);
                    }

                    // Check the defaults
                    //
                    Assert.Equal(SkuName.StandardGRS, storageAccount.SkuType.Name);
                    Assert.Equal(Kind.Storage, storageAccount.Kind);
                    //

                    Assert.NotNull(storageAccount.Tags);
                    Assert.Equal(2, storageAccount.Tags.Count());

                    Assert.NotNull(storageAccount);
                    Assert.NotNull(storageAccount.Inner);

                    availabilityResult = storageManager
                        .StorageAccounts
                        .CheckNameAvailability(stgName);

                    Assert.NotNull(availabilityResult);
                    Assert.False(availabilityResult.IsAvailable);
                    Assert.NotNull(availabilityResult.Reason);

                    // Get
                    storageAccount = storageManager.StorageAccounts.GetByResourceGroup(rgName, stgName);
                    Assert.NotNull(storageAccount);
                    Assert.NotNull(storageAccount.Inner);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateWithKindSkuAndUpdateAccessTier()
        {
            var customerTags = new Dictionary<string, string>
            {
                ["ID"] = "1234",
                ["Customer"] = "foo"
            };

            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgstg");
                var stgName = TestUtilities.GenerateName("stgbnt");
                try
                {
                    var storageManager = TestHelper.CreateStorageManager();

                    var storageAccount = storageManager.StorageAccounts.Define(stgName)
                        .WithRegion(Region.USEast2)
                        .WithNewResourceGroup(rgName)
                        .WithBlobStorageAccountKind()     // Override the default which is GeneralPurposeKind
                        .WithSku(StorageAccountSkuType.Standard_RAGRS)   // Override the default which is StandardGRS
                        .WithHnsEnabled(true)
                        .WithAzureFilesAadIntegrationEnabled(false)
                        .WithTags(customerTags)
                        .Create();

                    // Check the overridden settings
                    //
                    Assert.Equal(SkuName.StandardRAGRS, storageAccount.SkuType.Name);
                    Assert.Equal(Kind.BlobStorage, storageAccount.Kind);
                    Assert.Equal(AccessTier.Hot, storageAccount.AccessTier);    // Default access tier
                    Assert.True(storageAccount.HnsEnabled);
                    Assert.False(storageAccount.AzureFilesAadIntegration);
                    Assert.Equal(customerTags, storageAccount.Tags);

                    storageAccount = storageAccount.Update()
                        .WithAccessTier(AccessTier.Cool)
                        .Apply();

                    Assert.Equal(AccessTier.Cool, storageAccount.AccessTier);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateWithFileStorageKindSku()
        {
            var customerTags = new Dictionary<string, string>
            {
                ["ID"] = "1234",
                ["Customer"] = "foo"
            };

            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgstg");
                var stgName = TestUtilities.GenerateName("stgbnt");
                try
                {
                    var storageManager = TestHelper.CreateStorageManager();

                    var storageAccount = storageManager.StorageAccounts.Define(stgName)
                        .WithRegion(Region.USEast2)
                        .WithNewResourceGroup(rgName)
                        .WithFileStorageAccountKind()
                        .WithSku(StorageAccountSkuType.Premium_LRS)
                        .WithAzureFilesAadIntegrationEnabled(false)
                        .WithTags(customerTags)
                        .Create();

                    // Check the overridden settings
                    Assert.Equal(SkuName.PremiumLRS, storageAccount.SkuType.Name);
                    Assert.Equal(Kind.FileStorage, storageAccount.Kind);
                    Assert.False(storageAccount.AzureFilesAadIntegration);
                    Assert.Equal(customerTags, storageAccount.Tags);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanGetAndRegenerateKeys()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgstg");
                var stgName = TestUtilities.GenerateName("stgbnx");
                try
                {
                    var storageManager = TestHelper.CreateStorageManager();

                    var availabilityResult = storageManager
                        .StorageAccounts
                        .CheckNameAvailability(stgName);
                    Assert.NotNull(availabilityResult);
                    Assert.True(availabilityResult.IsAvailable);

                    var storageAccount = storageManager.StorageAccounts.Define(stgName)
                        .WithRegion(Region.USEast2)
                        .WithNewResourceGroup(rgName)
                        .Create();

                    var keys = storageAccount.GetKeys();
                    Assert.NotNull(keys);
                    Assert.True(keys.Count() > 0);
                    var firstKey = keys.First();

                    var updatedKeys = storageAccount.RegenerateKey(firstKey.KeyName);
                    Assert.NotNull(updatedKeys);
                    Assert.True(updatedKeys.Count() > 0);
                    var updatedFirstKey = updatedKeys.First(f => f.KeyName == firstKey.KeyName);
                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        Assert.False(firstKey.Value.Equals(updatedFirstKey.Value, StringComparison.OrdinalIgnoreCase));
                    }
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanEnableDisableEncryption()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgstg");
                var stgName = TestUtilities.GenerateName("stgbnx");
                try
                {
                    var storageManager = TestHelper.CreateStorageManager();

                    var storageAccount = storageManager.StorageAccounts.Define(stgName)
                        .WithRegion(Region.USEast2)
                        .WithNewResourceGroup(rgName)
                        .WithBlobEncryption()
                        .WithTag("aa", "aa")
                        .WithTag("bb", "bb")
                        .Create();

                    var statuses = storageAccount.EncryptionStatuses;
                    Assert.NotNull(statuses);
                    Assert.True(statuses.Count() > 0);
                    Assert.True(statuses.ContainsKey(StorageService.Blob));
                    var blobServiceEncryptionStatus = statuses[StorageService.Blob];
                    Assert.NotNull(blobServiceEncryptionStatus);
                    Assert.True(blobServiceEncryptionStatus.IsEnabled);
                    Assert.NotNull(blobServiceEncryptionStatus.LastEnabledTime);
                    Assert.NotNull(storageAccount.EncryptionKeySource);
                    Assert.True(storageAccount.EncryptionKeySource.Equals(StorageAccountEncryptionKeySource.Microsoft_Storage));
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }
    }
}
