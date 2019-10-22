// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Fluent.Tests.Storage
{
    public class BlobServices
    {
        [Fact]
        public void CanCreateBlobServices()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string storageAccountName = TestUtilities.GenerateName("stgbnx");
                string resourceGroupName = TestUtilities.GenerateName("rgstg");
                try
                {
                    IStorageManager storageManager = TestHelper.CreateStorageManager();
                    IStorageAccount storageAccount = storageManager.StorageAccounts.Define(storageAccountName)
                            .WithRegion(Region.USEast2)
                            .WithNewResourceGroup(resourceGroupName)
                            .Create();

                    IBlobServices blobServices = storageManager.BlobServices;
                    IBlobServiceProperties blobService = blobServices.Define("blobServicesTest")
                        .WithExistingStorageAccount(storageAccount.ResourceGroupName, storageAccount.Name)
                        .WithDeleteRetentionPolicyEnabled(5)
                        .Create();
                    Assert.True(blobService.DeleteRetentionPolicy.Enabled);
                    Assert.Equal(5, blobService.DeleteRetentionPolicy.Days.Value);
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
        public void CanUpdateBlobServices()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string storageAccountName = TestUtilities.GenerateName("stgbnx");
                string resourceGroupName = TestUtilities.GenerateName("rgstg");
                try
                {
                    IStorageManager storageManager = TestHelper.CreateStorageManager();
                    IStorageAccount storageAccount = storageManager.StorageAccounts.Define(storageAccountName)
                            .WithRegion(Region.USEast2)
                            .WithNewResourceGroup(resourceGroupName)
                            .Create();

                    IBlobServices blobServices = storageManager.BlobServices;
                    IBlobServiceProperties blobService = blobServices.Define("blobServicesTest")
                        .WithExistingStorageAccount(storageAccount.ResourceGroupName, storageAccount.Name)
                        .WithDeleteRetentionPolicyEnabled(5)
                        .Create();

                    blobService.Update()
                        .WithDeleteRetentionPolicyDisabled()
                        .Apply();

                    Assert.False(blobService.DeleteRetentionPolicy.Enabled);
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
