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

namespace ManageBatchAI
{
    public class Program
    {
        /**
         * Azure Batch AI sample.
         *  - Create Storage account and Azure file share
         *  - Upload sample data to Azure file share
         *  - Create Batch AI cluster that uses Azure file share to host the training data and scripts for the learning job
         *  - Create Microsoft Cognitive Toolkit job to run on the cluster
         *  - Wait for job to complete
         *  - Get output files
         *
         * Please note: in order to run this sample, please download and unzip sample package from here: https://batchaisamples.blob.core.windows.net/samples/BatchAIQuickStart.zip?st=2017-09-29T18%3A29%3A00Z&se=2099-12-31T08%3A00%3A00Z&sp=rl&sv=2016-05-31&sr=b&sig=hrAZfbZC%2BQ%2FKccFQZ7OC4b%2FXSzCF5Myi4Cj%2BW3sVZDo%3D
         * Export path to the content to $SAMPLE_DATA_PATH.
         */
        public static void RunSample(IAzure azure)
        {
            string saName = SdkContext.RandomResourceName("sa", 10);
            string rgName = SdkContext.RandomResourceName("rg", 10);
            string sampleDataPath = Environment.GetEnvironmentVariable("SAMPLE_DATA_PATH");
            Region region = Region.USWest2;
            string shareName = SdkContext.RandomResourceName("fs", 20);
            string clusterName = SdkContext.RandomResourceName("cluster", 15);
            string userName = "tirekicker";
            string sharePath = "mnistcntksample";

            try
            {
                //=============================================================
                // Create a new storage account and an Azure file share resource

                IStorageAccount storageAccount = azure.StorageAccounts.Define(saName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .Create();

                StorageAccountKey storageAccountKey = storageAccount.GetKeys().First();

                var cloudFileShare = CloudStorageAccount.Parse($"DefaultEndpointsProtocol=https;AccountName={saName};AccountKey={storageAccountKey.Value};EndpointSuffix=core.windows.net")
                    .CreateCloudFileClient()
                    .GetShareReference(shareName);
                cloudFileShare.CreateAsync().GetAwaiter().GetResult();

                //=============================================================
                // Upload sample data to Azure file share

                //Get a reference to the root directory for the share.
                CloudFileDirectory rootDir = cloudFileShare.GetRootDirectoryReference();

                //Get a reference to the sampledir directory
                CloudFileDirectory sampleDir = rootDir.GetDirectoryReference(sharePath);
                sampleDir.CreateAsync().GetAwaiter().GetResult();

                sampleDir.GetFileReference("Train-28x28_cntk_text.txt").UploadFromFileAsync(sampleDataPath + "/Train-28x28_cntk_text.txt").GetAwaiter().GetResult();
                sampleDir.GetFileReference("Test-28x28_cntk_text.txt").UploadFromFileAsync(sampleDataPath + "/Test-28x28_cntk_text.txt").GetAwaiter().GetResult();
                sampleDir.GetFileReference("ConvNet_MNIST.py").UploadFromFileAsync(sampleDataPath + "/ConvNet_MNIST.py").GetAwaiter().GetResult();

                //=============================================================
                // Create Batch AI cluster that uses Azure file share to host the training data and scripts for the learning job
                IBatchAICluster cluster = azure.BatchAIClusters.Define(clusterName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
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

                // =============================================================
                // Create Microsoft Cognitive Toolkit job to run on the cluster
                IBatchAIJob job = cluster.Jobs.Define("myJob")
                    .WithRegion(region)
                    .WithNodeCount(1)
                    .WithStdOutErrPathPrefix("$AZ_BATCHAI_MOUNT_ROOT/azurefileshare")
                    .DefineCognitiveToolkit()
                        .WithPythonScriptFile("$AZ_BATCHAI_INPUT_SAMPLE/ConvNet_MNIST.py")
                        .WithCommandLineArgs("$AZ_BATCHAI_INPUT_SAMPLE $AZ_BATCHAI_OUTPUT_MODEL")
                        .Attach()
                    .WithInputDirectory("SAMPLE", "$AZ_BATCHAI_MOUNT_ROOT/azurefileshare/" + sharePath)
                    .WithOutputDirectory("MODEL", "$AZ_BATCHAI_MOUNT_ROOT/azurefileshare/model")
                    .WithContainerImage("microsoft/cntk:2.1-gpu-python3.5-cuda8.0-cudnn6.0")
                    .Create();

                // =============================================================
                // Wait for job results

                // Wait for job to start running
                while (ExecutionState.Queued.Equals(job.ExecutionState))
                {
                    SdkContext.DelayProvider.Delay(5000);
                    job.Refresh();
                }

                // Wait for job to complete and job output to become available
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
