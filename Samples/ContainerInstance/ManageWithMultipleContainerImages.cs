// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ContainerInstance.Fluent;
using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageWithMultipleContainerImages
{
    public class Program
    {
        private static readonly Region region = Region.USEast;


        /**
         * Azure Container Instance sample for managing container instances.
         *    - Create an Azure container group with two container instances using Docker images "microsoft/aci-helloworld" and "microsoft/aci-tutorial-sidecar"
         *    - Retrieve container log content
         *    - Delete the container group resource
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgACI", 15);
            string aciName = SdkContext.RandomResourceName("acisample", 20);
            string containerImageName1 = "microsoft/aci-helloworld";
            string containerImageName2 = "microsoft/aci-tutorial-sidecar";

            try
            {
                //=============================================================
                // Create a container group with two container instances

                IContainerGroup containerGroup = azure.ContainerGroups.Define(aciName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .WithLinux()
                    .WithPublicImageRegistryOnly()
                    .WithoutVolume()
                    .DefineContainerInstance(aciName + "-1")
                        .WithImage(containerImageName1)
                        .WithExternalTcpPort(80)
                        .WithCpuCoreCount(.5)
                        .WithMemorySizeInGB(1)
                        .Attach()
                    .DefineContainerInstance(aciName + "-2")
                        .WithImage(containerImageName2)
                        .WithoutPorts()
                        .WithCpuCoreCount(.5)
                        .WithMemorySizeInGB(1)
                        .Attach()
                    .WithRestartPolicy(ContainerGroupRestartPolicy.Never)
                    .WithDnsPrefix(aciName)
                    .Create();

                Utilities.Print(containerGroup);

                SdkContext.DelayProvider.Delay(20000);
                Utilities.Log("Container instance IP address: " + containerGroup.IPAddress);

                //=============================================================
                // Check the container instance logs

                containerGroup = azure.ContainerGroups.GetByResourceGroup(rgName, aciName);
                string logContent = containerGroup.GetLogContent(aciName + "-1");
                Utilities.Log($"Logs for container instance: {aciName}-1\n{logContent}");
                logContent = containerGroup.GetLogContent(aciName + "-2");
                Utilities.Log($"Logs for container instance: {aciName}-2\n{logContent}");

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
