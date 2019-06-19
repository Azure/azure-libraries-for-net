// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ContainerInstance.Fluent;
using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Net.Http;

namespace ManageWithAzureFileShareMount
{
    public class Program
    {
        private static readonly Region region = Region.USEast;


        /**
         * Azure Container Instance sample for managing container instances with Azure File Share mount.
         *    - Create an Azure container instance using Docker image "seanmckenna/aci-hellofiles" with a mount to a new file share
         *    - Retrieve container log content
         *    - Delete the container group resource
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgACI", 15);
            string aciName = SdkContext.RandomResourceName("acisample", 20);
            string shareName = SdkContext.RandomResourceName("fileshare", 20);
            string containerImageName = "seanmckenna/aci-hellofiles";
            string volumeMountName = "aci-helloshare";

            try
            {
                //=============================================================
                // Create a container group with one container instance of default CPU core count and memory size
                //   using public Docker image "seanmckenna/aci-hellofiles" which mounts the file share created previously
                //   as read/write shared container volume.

                IContainerGroup containerGroup = azure.ContainerGroups.Define(aciName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .WithLinux()
                    .WithPublicImageRegistryOnly()
                    .WithNewAzureFileShareVolume(volumeMountName, shareName)
                    .DefineContainerInstance(aciName)
                        .WithImage(containerImageName)
                        .WithExternalTcpPort(80)
                        .WithVolumeMountSetting(volumeMountName, "/aci/logs/")
                        .Attach()
                    .WithDnsPrefix(aciName)
                    .Create();

                Utilities.Print(containerGroup);

                SdkContext.DelayProvider.Delay(20000);
                Utilities.Log("Container instance IP address: " + containerGroup.IPAddress);

                //=============================================================
                // Check the container instance logs

                containerGroup = azure.ContainerGroups.GetByResourceGroup(rgName, aciName);
                string logContent = containerGroup.GetLogContent(aciName);
                Utilities.Log($"Logs for container instance: {aciName}\n{logContent}");

                //=============================================================
                // Remove the container group

                azure.ContainerGroups.DeleteById(containerGroup.Id);
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
