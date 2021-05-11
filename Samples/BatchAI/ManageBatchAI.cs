// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.BatchAI.Fluent;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Management.Storage.Fluent.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using ExecutionState = Microsoft.Azure.Management.BatchAI.Fluent.Models.ExecutionState;

namespace ManageBatchAI
{
    public class Program
    {
        /**
         * Azure Batch AI sample.
         *  - Create Storage account and Azure file share
         *  - Upload sample data to Azure file share
         *  - Create a workspace and experiment
         *  - Create Batch AI cluster that uses Azure file share to host the training data and scripts for the learning job
         *  - Create Microsoft Cognitive Toolkit job to run on the cluster
         *  - Wait for job to complete
         *  - Get output files
         */
        public static void RunSample(IAzure azure)
        {
            string saName = SdkContext.RandomResourceName("sa", 10);
            string rgName = SdkContext.RandomResourceName("rg", 10);
            string workspaceName = SdkContext.RandomResourceName("ws", 10);
            string experimentName = SdkContext.RandomResourceName("exp", 10);
            string sampleDataPath = Environment.GetEnvironmentVariable("SAMPLE_DATA_PATH");
            Region region = Region.USWest2;
            string shareName = SdkContext.RandomResourceName("fs", 20);
            string clusterName = SdkContext.RandomResourceName("cluster", 15);
            string userName = Utilities.CreateUsername();
            string sharePath = "mnistcntksample";

            try
            {
                //=============================================================
                // Create a new storage account and an Azure file share resource
                Utilities.Log("Creating a storage account...");
                IStorageAccount storageAccount = azure.StorageAccounts.Define(saName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .Create();
                Utilities.Log("Created storage account.");
                Utilities.PrintStorageAccount(storageAccount);

                StorageAccountKey storageAccountKey = storageAccount.GetKeys().First();

                Utilities.Log("Creating Azure File share...");
                var cloudFileShare = CloudStorageAccount.Parse($"DefaultEndpointsProtocol=https;AccountName={saName};AccountKey={storageAccountKey.Value};EndpointSuffix=core.windows.net")
                    .CreateCloudFileClient()
                    .GetShareReference(shareName);
                cloudFileShare.CreateAsync().GetAwaiter().GetResult();
                Utilities.Log("Created Azure File share.");

                //=============================================================
                // Upload sample data to Azure file share

                //Get a reference to the root directory for the share.
                CloudFileDirectory rootDir = cloudFileShare.GetRootDirectoryReference();

                //Get a reference to the sampledir directory
                Utilities.Log("Creating directory and uploading data files...");
                CloudFileDirectory sampleDir = rootDir.GetDirectoryReference(sharePath);
                sampleDir.CreateAsync().GetAwaiter().GetResult();

                rootDir.GetFileReference("Train-28x28_cntk_text.txt").UploadFromFileAsync(sampleDataPath + "/Train-28x28_cntk_text.txt").GetAwaiter().GetResult();
                rootDir.GetFileReference("Test-28x28_cntk_text.txt").UploadFromFileAsync(sampleDataPath + "/Test-28x28_cntk_text.txt").GetAwaiter().GetResult();
                rootDir.GetFileReference("ConvNet_MNIST.py").UploadFromFileAsync(sampleDataPath + "/ConvNet_MNIST.py").GetAwaiter().GetResult();
                Utilities.Log("Data files uploaded.");
                //=============================================================
                // Create a workspace and experiment
                IBatchAIWorkspace workspace = azure.BatchAIWorkspaces.Define(workspaceName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .Create();
                IBatchAIExperiment experiment = workspace.CreateExperiment(experimentName);


                //=============================================================
                // Create Batch AI cluster that uses Azure file share to host the training data and scripts for the learning job
                Utilities.Log("Creating Batch AI cluster...");
                IBatchAICluster cluster = workspace.Clusters.Define(clusterName)
                    .WithVMSize(VirtualMachineSizeTypes.StandardNC6.Value)
                    .WithUserName(userName)
                    .WithPassword("MyPassword")
                    .WithAutoScale(0, 2)
                    .DefineAzureFileShare()
                        .WithStorageAccountName(saName)
                        .WithAzureFileUrl(cloudFileShare.Uri.ToString())
                        .WithRelativeMountPath("azurefileshare")
                        .WithAccountKey(storageAccountKey.Value)
                        .Attach()
                    .Create();
                Utilities.Log("Created Batch AI cluster.");
                Utilities.Print(cluster);

                // =============================================================
                // Create Microsoft Cognitive Toolkit job to run on the cluster
                Utilities.Log("Creating Batch AI job...");
                IBatchAIJob job = experiment.Jobs.Define("myJob")
                    .WithExistingCluster(cluster)
                    .WithNodeCount(1)
                    .WithStdOutErrPathPrefix("$AZ_BATCHAI_MOUNT_ROOT/azurefileshare")
                    .DefineCognitiveToolkit()
                        .WithPythonScriptFile("$AZ_BATCHAI_MOUNT_ROOT/azurefileshare/ConvNet_MNIST.py")
                        .WithCommandLineArgs("$AZ_BATCHAI_MOUNT_ROOT/azurefileshare $AZ_BATCHAI_OUTPUT_MODEL")
                        .Attach()
                    .WithOutputDirectory("MODEL", "$AZ_BATCHAI_MOUNT_ROOT/azurefileshare/model")
                    .WithContainerImage("microsoft/cntk:2.1-gpu-python3.5-cuda8.0-cudnn6.0")
                    .Create();
                Utilities.Log("Created Batch AI job.");
                Utilities.Print(job);

                // =============================================================
                // Wait for job results

                // Wait for job to start running
                Utilities.Log("Waiting for Batch AI job to start running...");
                while (ExecutionState.Queued.Equals(job.ExecutionState))
                {
                    SdkContext.DelayProvider.Delay(5000);
                    job.Refresh();
                }

                // Wait for job to complete and job output to become available
                Utilities.Log("Waiting for Batch AI job to complete...");
                while (!(ExecutionState.Succeeded.Equals(job.ExecutionState) || ExecutionState.Failed.Equals(job.ExecutionState)))
                {
                    SdkContext.DelayProvider.Delay(5000);
                    job.Refresh();
                }

                // =============================================================
                // Get output files

                // Print stdout and stderr
                foreach (var outputFile in job.ListFiles("stdouterr"))
                {
                    Utilities.Log(Utilities.CheckAddress(outputFile.DownloadUrl));
                }
                // List model output files
                foreach (var outputFile in job.ListFiles("MODEL"))
                {
                    Utilities.Log(outputFile.DownloadUrl);
                }
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (Exception)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                AzureCredentials credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}
