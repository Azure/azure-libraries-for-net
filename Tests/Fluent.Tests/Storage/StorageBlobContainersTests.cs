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
    public class BlobContainers
    {
        [Fact]
        public void CanCreateBlobContainers()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string storageAccountName = TestUtilities.GenerateName("stgbnx");
                string resourceGroupName = TestUtilities.GenerateName("rgstg");
                Dictionary<string, string> metadataTest = new Dictionary<string, string>();
                metadataTest.Add("a", "b");
                metadataTest.Add("c", "d");

                try
                {
                    IStorageManager storageManager = TestHelper.CreateStorageManager();
                    IStorageAccount storageAccount = storageManager.StorageAccounts
                        .Define(storageAccountName)
                        .WithRegion(Region.USEast2)
                        .WithNewResourceGroup(resourceGroupName)
                        .Create();

                    IBlobContainers blobContainers = storageManager.BlobContainers;
                    IBlobContainer blobContainer = blobContainers.DefineContainer("blob-test")
                        .WithExistingBlobService(resourceGroupName, storageAccountName)
                        .WithPublicAccess(Microsoft.Azure.Management.Storage.Fluent.Models.PublicAccess.Container)
                        .WithMetadata("a", "b")
                        .WithMetadata("c", "d")
                        .Create();

                    Assert.Equal("blob-test", blobContainer.Name);
                    Assert.Equal(Microsoft.Azure.Management.Storage.Fluent.Models.PublicAccess.Container, blobContainer.PublicAccess);
                    Assert.Equal(metadataTest, blobContainer.Metadata);
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
        public void CanUpdateBlobContainers()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string storageAccountName = TestUtilities.GenerateName("stgbnx");
                string resourceGroupName = TestUtilities.GenerateName("rgstg");

                Dictionary<string, string> metadataInitial = new Dictionary<string, string>();
                metadataInitial.Add("a", "b");

                Dictionary<string, string> metadataTest = new Dictionary<string, string>();
                metadataTest.Add("c", "d");
                metadataTest.Add("e", "f");

                try
                {
                    IStorageManager storageManager = TestHelper.CreateStorageManager();
                    IStorageAccount storageAccount = storageManager.StorageAccounts.Define(storageAccountName)
                            .WithRegion(Region.USEast2)
                            .WithNewResourceGroup(resourceGroupName)
                            .Create();

                    IBlobContainers blobContainers = storageManager.BlobContainers;
                    IBlobContainer blobContainer = blobContainers.DefineContainer("blob-test")
                        .WithExistingBlobService(resourceGroupName, storageAccountName)
                        .WithPublicAccess(Microsoft.Azure.Management.Storage.Fluent.Models.PublicAccess.Container)
                        .WithMetadata(metadataInitial)
                        .Create();

                    blobContainer.Update()
                        .WithPublicAccess(Microsoft.Azure.Management.Storage.Fluent.Models.PublicAccess.Blob)
                        .WithMetadata("c", "d")
                        .WithMetadata("e", "f")
                        .Apply();

                    Assert.Equal("blob-test", blobContainer.Name);
                    Assert.Equal(Microsoft.Azure.Management.Storage.Fluent.Models.PublicAccess.Blob, blobContainer.PublicAccess);
                    Assert.Equal(metadataTest, blobContainer.Metadata);
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
