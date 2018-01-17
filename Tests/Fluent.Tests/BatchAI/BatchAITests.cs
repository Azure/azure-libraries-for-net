using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.BatchAI.Fluent;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;
using Xunit;

namespace Fluent.Tests.BatchAI
{
    public class BatchAI
    {
        private static Region REGION = Region.USWest;

        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string groupName = SdkContext.RandomResourceName("rg", 10);
                string clusterName = SdkContext.RandomResourceName("cluster", 15);
                string saName = SdkContext.RandomResourceName("cluster", 15);
                string shareName = "myfileshare";
                string shareMountPath = "azurefileshare";
                string blobFileSystemPath = "myblobsystem";
                string containerName = "mycontainer";
                string userName = "tirekicker";
                string storageAccountKey = "dummy_key";
                string fileShareUri = "dummy_uri";

                var manager = TestHelper.CreateBatchAIManager();

                IBatchAICluster cluster = manager.BatchAIClusters.Define(clusterName)
                    .WithRegion(REGION)
                    .WithNewResourceGroup(groupName)
                    .WithVMSize(VirtualMachineSizeTypes.StandardD1V2.Value)
                    .WithUserName(userName)
                    .WithPassword("MyPassword")
                    .WithAutoScale(1, 1)
                    .WithLowPriority()
                    .DefineSetupTask()
                        .WithCommandLine("echo Hello World!")
                        .WithStdOutErrPath("./outputpath")
                        .Attach()
                    .DefineAzureFileShare()
                        .WithStorageAccountName(saName)
                        .WithAzureFileUrl(fileShareUri)
                        .WithRelativeMountPath(shareMountPath)
                        .WithAccountKey(storageAccountKey)
                        .Attach()
                    .DefineAzureBlobFileSystem()
                        .WithStorageAccountName(saName)
                        .WithContainerName(containerName)
                        .WithRelativeMountPath(blobFileSystemPath)
                        .WithAccountKey(storageAccountKey)
                        .Attach()
                    .WithTag("tag1", "value1")
                    .Create();
                Assert.Equal(AllocationState.Steady, cluster.AllocationState);
                Assert.Equal(userName, cluster.AdminUserName);
                Assert.Equal(VmPriority.Lowpriority, cluster.VMPriority);
                Assert.Equal(1, cluster.NodeSetup.MountVolumes.AzureFileShares.Count);
                Assert.Equal(shareMountPath, cluster.NodeSetup.MountVolumes.AzureFileShares.ElementAt(0).RelativeMountPath);
                Assert.Equal(1, cluster.NodeSetup.MountVolumes.AzureBlobFileSystems.Count);
                Assert.Equal(blobFileSystemPath, cluster.NodeSetup.MountVolumes.AzureBlobFileSystems.ElementAt(0).RelativeMountPath);

                cluster.Update()
                    .WithAutoScale(1, 2, 2)
                    .WithTag("tag1", "value2")
                    .Apply();
                Assert.Equal(2, cluster.ScaleSettings.AutoScale.MaximumNodeCount);
                string tag1;
                Assert.True(cluster.Tags.TryGetValue("tag1", out tag1));
                Assert.Equal("value2", tag1);

                manager.ResourceManager.ResourceGroups.DeleteByName(groupName);
            }
        }
    }
}
