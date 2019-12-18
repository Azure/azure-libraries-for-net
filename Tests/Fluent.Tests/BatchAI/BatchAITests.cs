// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
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
using Microsoft.Rest;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;
using Xunit;
using Xunit.Abstractions;

namespace Fluent.Tests
{
    public class BatchAI
    {
        private static Region REGION = Region.USWest2;

        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string groupName = SdkContext.RandomResourceName("rg", 10);
                string workspaceName = SdkContext.RandomResourceName("ws", 10);
                string clusterName = SdkContext.RandomResourceName("cluster", 15);
                string vnetName = SdkContext.RandomResourceName("vnet", 10);
                string saName = SdkContext.RandomResourceName("sa", 15);
                string shareMountPath = "azurefileshare";
                string blobFileSystemPath = "myblobsystem";
                string containerName = "mycontainer";
                string userName = "tirekicker";
                string storageAccountKey = "dummy_key";
                string fileShareUri = "dummy_uri";
                string subnetName = "MySubnet";

                var manager = TestHelper.CreateBatchAIManager();
                var networkManager = TestHelper.CreateNetworkManager();

                try
                {
                    IBatchAIWorkspace workspace = manager.BatchAIWorkspaces.Define(workspaceName)
                        .WithRegion(REGION)
                        .WithNewResourceGroup(groupName)
                        .Create();

                    INetwork network = networkManager.Networks.Define(vnetName)
                        .WithRegion(REGION)
                        .WithExistingResourceGroup(groupName)
                        .WithAddressSpace("192.168.0.0/16")
                        .WithSubnet(subnetName, "192.168.200.0/24")
                        .Create();

                    IBatchAICluster cluster = workspace.Clusters.Define(clusterName)
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
                        .WithVirtualMachineImage("microsoft-ads", "linux-data-science-vm-ubuntu", "linuxdsvmubuntu")
                        .WithSubnet(network.Id, subnetName)
                        .WithAppInsightsComponentId("appinsightsId")
                        .WithInstrumentationKey("appInsightsKey")
                        .Create();
                    Assert.Equal(AllocationState.Resizing, cluster.AllocationState);
                    Assert.Equal(userName, cluster.AdminUserName);
                    Assert.Equal(VmPriority.Lowpriority, cluster.VMPriority);
                    Assert.Equal(1, cluster.NodeSetup.MountVolumes.AzureFileShares.Count);
                    Assert.Equal(shareMountPath,
                        cluster.NodeSetup.MountVolumes.AzureFileShares.ElementAt(0).RelativeMountPath);
                    Assert.Equal(1, cluster.NodeSetup.MountVolumes.AzureBlobFileSystems.Count);
                    Assert.Equal(blobFileSystemPath,
                        cluster.NodeSetup.MountVolumes.AzureBlobFileSystems.ElementAt(0).RelativeMountPath);
                    Assert.Equal(network.Id + "/subnets/" + subnetName, cluster.Subnet.Id);
                    Assert.Equal("appinsightsId",
                        cluster.NodeSetup.PerformanceCountersSettings.AppInsightsReference.Component.Id);
                    Assert.Equal("linux-data-science-vm-ubuntu",
                        cluster.VirtualMachineConfiguration.ImageReference.Offer);

                    cluster.Update()
                        .WithAutoScale(1, 2, 2)
                        .Apply();
                    Assert.Equal(2, cluster.ScaleSettings.AutoScale.MaximumNodeCount);
                }
                finally
                {
                    try
                    {
                        manager.ResourceManager.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateJob()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string groupName = SdkContext.RandomResourceName("rg", 10);
                string workspaceName = SdkContext.RandomResourceName("ws", 10);
                string experimentName = SdkContext.RandomResourceName("exp", 10);
                string clusterName = SdkContext.RandomResourceName("cluster", 15);
                string userName = "tirekicker";

                var manager = TestHelper.CreateBatchAIManager();

                try
                {
                    IBatchAIWorkspace workspace = manager.BatchAIWorkspaces.Define(workspaceName)
                        .WithRegion(REGION)
                        .WithNewResourceGroup(groupName)
                        .Create();
                    IBatchAIExperiment experiment = workspace.CreateExperiment(experimentName);

                    IBatchAICluster cluster = workspace.Clusters.Define(clusterName)
                        .WithVMSize(VirtualMachineSizeTypes.StandardD1V2.Value)
                        .WithUserName(userName)
                        .WithPassword("MyPassword")
                        .WithAutoScale(1, 1)
                        .Create();
                    Assert.Equal(AllocationState.Resizing, cluster.AllocationState);
                    Assert.Equal(userName, cluster.AdminUserName);
                    IBatchAIJob job = experiment.Jobs.Define("myJob")
                        .WithExistingClusterId(cluster.Id)
                        .WithNodeCount(1)
                        .WithStdOutErrPathPrefix("$AZ_BATCHAI_MOUNT_ROOT/azurefileshare")
                        .DefineCognitiveToolkit()
                        .WithPythonScriptFile("$AZ_BATCHAI_INPUT_SAMPLE/ConvNet_MNIST.py")
                        .WithCommandLineArgs("$AZ_BATCHAI_INPUT_SAMPLE $AZ_BATCHAI_OUTPUT_MODEL")
                        .Attach()
                        .WithInputDirectory("SAMPLE", "$AZ_BATCHAI_MOUNT_ROOT/azurefileshare/mnistcntksample")
                        .WithOutputDirectory("MODEL", "$AZ_BATCHAI_MOUNT_ROOT/azurefileshare/model")
                        .DefineOutputDirectory("OUTPUT")
                        .WithPathPrefix("$AZ_BATCHAI_MOUNT_ROOT/azurefileshare/output")
                        .WithPathSuffix("suffix")
                        .Attach()
                        .WithContainerImage("microsoft/cntk:2.1-gpu-python3.5-cuda8.0-cudnn6.0")
                        .Create();
                    Assert.Equal(2, job.OutputDirectories.Count);
                    OutputDirectory outputDirectory = null;
                    foreach (OutputDirectory directory in job.OutputDirectories)
                    {
                        if ("OUTPUT".Equals(directory.Id.ToUpper()))
                        {
                            outputDirectory = directory;
                            break;
                        }
                    }
                    Assert.NotNull(outputDirectory);
                    Assert.Equal("suffix", outputDirectory.PathSuffix.ToLower());

                    job.Refresh();
                }
                finally
                {
                    try
                    {
                        manager.ResourceManager.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch { }
                }
            }
        }

        [Fact(Skip ="ignore this as service retired")]
        public void CanCreateFileServer()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string groupName = SdkContext.RandomResourceName("rg", 10);
                string wsName = SdkContext.RandomResourceName("ws", 10);
                string vnetName = SdkContext.RandomResourceName("vnet", 10);
                string fsName = SdkContext.RandomResourceName("fs", 15);
                string userName = "tirekicker";
                string subnetName = "MySubnet";

                var manager = TestHelper.CreateBatchAIManager();
                var networkManager = TestHelper.CreateNetworkManager();
                try
                {
                    IBatchAIWorkspace workspace = manager.BatchAIWorkspaces.Define(wsName)
                        .WithRegion(REGION)
                        .WithNewResourceGroup(groupName)
                        .Create();
                    INetwork network = networkManager.Networks.Define(vnetName)
                        .WithRegion(REGION)
                        .WithExistingResourceGroup(groupName)
                        .WithAddressSpace("192.168.0.0/16")
                        .WithSubnet(subnetName, "192.168.200.0/24")
                        .Create();

                    IBatchAIFileServer fileServer = workspace.FileServers.Define(fsName)
                        .WithDataDisks(10, 2, Microsoft.Azure.Management.BatchAI.Fluent.Models.StorageAccountType.StandardLRS, CachingType.Readwrite)
                        .WithVMSize(VirtualMachineSizeTypes.StandardD1V2.Value)
                        .WithUserName(userName)
                        .WithPassword("MyPassword!")
                        .WithSubnet(network.Id, subnetName)
                        .Create();
                    Assert.Equal(network.Id + "/subnets/" + subnetName, fileServer.Subnet.Id);
                    Assert.Equal(CachingType.Readwrite, fileServer.DataDisks.CachingType);
                }
                finally
                {
                    try
                    {
                        manager.ResourceManager.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanListUsages()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var manager = TestHelper.CreateBatchAIManager();
                var usages = manager.BatchAIUsages.ListByRegion(Region.EuropeWest);
                Assert.NotNull(usages);
            }
        }
    }
}
