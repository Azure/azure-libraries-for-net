// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Docker.DotNet;
using Microsoft.Azure.Management.ContainerInstance.Fluent;
using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
using Microsoft.Azure.Management.ContainerRegistry.Fluent;
using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageWithAzureContainerRegistry
{
    public class Program
    {
        private static readonly Region region = Region.USEast;

        /**
         * Azure Container Instance sample for managing container groups with private image repositories.
         *  - Create an Azure Container Registry to be used for holding the Docker images
         *  - If a local Docker engine cannot be found, create a Linux virtual machine that will host a Docker engine
         *      to be used for this sample
         *  - Use Docker DotNet to create a Docker client that will push an image to Azure Container Registry
         *  - Create a new container group with one container instance from the image that was pushed in the registry
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgACI", 15);
            string acrName = SdkContext.RandomResourceName("acr", 20);
            string aciName = SdkContext.RandomResourceName("acisample", 20);
            string saName = SdkContext.RandomResourceName("sa", 20);
            string dockerImageName = "microsoft/aci-helloworld";
            string dockerImageTag = "latest";
            string dockerContainerName = "sample-hello";

            try
            {
                //=============================================================
                // Create an Azure Container Registry to store and manage private Docker container images

                Utilities.Log("Creating an Azure Container Registry");

                IRegistry azureRegistry = azure.ContainerRegistries.Define(acrName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithBasicSku()
                        .WithRegistryNameAsAdminUser()
                        .Create();

                Utilities.Print(azureRegistry);

                var acrCredentials = azureRegistry.GetCredentials();

                //=============================================================
                // Create a Docker client that will be used to push/pull images to/from the Azure Container Registry

                using (DockerClient dockerClient = DockerUtils.CreateDockerClient(azure, rgName, region))
                {
                    var pullImgResult = dockerClient.Images.PullImage(
                        new Docker.DotNet.Models.ImagesPullParameters()
                        {
                            Parent = dockerImageName,
                            Tag = dockerImageTag
                        },
                        new Docker.DotNet.Models.AuthConfig());

                    Utilities.Log("List Docker images for: " + dockerClient.Configuration.EndpointBaseUri.AbsoluteUri);
                    var listImages = dockerClient.Images.ListImages(
                        new Docker.DotNet.Models.ImagesListParameters()
                        {
                            All = true
                        });
                    foreach (var img in listImages)
                    {
                        Utilities.Log("\tFound image " + img.RepoTags[0] + " (id:" + img.ID + ")");
                    }

                    var createContainerResult = dockerClient.Containers.CreateContainer(
                        new Docker.DotNet.Models.CreateContainerParameters()
                        {
                            Name = dockerContainerName,
                            Image = dockerImageName + ":" + dockerImageTag
                        });
                    Utilities.Log("List Docker containers for: " + dockerClient.Configuration.EndpointBaseUri.AbsoluteUri);
                    var listContainers = dockerClient.Containers.ListContainers(
                        new Docker.DotNet.Models.ContainersListParameters()
                        {
                            All = true
                        });
                    foreach (var container in listContainers)
                    {
                        Utilities.Log("\tFound container " + container.Names[0] + " (id:" + container.ID + ")");
                    }

                    //=============================================================
                    // Commit the new container

                    string privateRepoUrl = azureRegistry.LoginServerUrl + "/" + dockerContainerName;
                    Utilities.Log("Commiting image at: " + privateRepoUrl);

                    var commitContainerResult = dockerClient.Miscellaneous.CommitContainerChanges(
                        new Docker.DotNet.Models.CommitContainerChangesParameters()
                        {
                            ContainerID = dockerContainerName,
                            RepositoryName = privateRepoUrl,
                            Tag = dockerImageTag
                        });

                    //=============================================================
                    // Push the new Docker image to the Azure Container Registry

                    var pushImageResult = dockerClient.Images.PushImage(privateRepoUrl,
                        new Docker.DotNet.Models.ImagePushParameters()
                        {
                            ImageID = privateRepoUrl,
                            Tag = dockerImageTag
                        },
                        new Docker.DotNet.Models.AuthConfig()
                        {
                            Username = acrCredentials.Username,
                            Password = acrCredentials.AccessKeys[AccessKeyType.Primary],
                            ServerAddress = azureRegistry.LoginServerUrl
                        });

                    //=============================================================
                    // Create a container group with one container instance of default CPU core count and memory size
                    //   using public Docker image "microsoft/aci-helloworld" and mounts a new file share as read/write
                    //   shared container volume.

                    IContainerGroup containerGroup = azure.ContainerGroups.Define(aciName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithLinux()
                        .WithPrivateImageRegistry(azureRegistry.LoginServerUrl, acrCredentials.Username, acrCredentials.AccessKeys[AccessKeyType.Primary])
                        .WithoutVolume()
                        .DefineContainerInstance(aciName)
                            .WithImage(privateRepoUrl)
                            .WithExternalTcpPort(80)
                            .Attach()
                        .Create();

                    Utilities.Print(containerGroup);

                    //=============================================================
                    // Check the container instance logs

                    SdkContext.DelayProvider.Delay(15000);

                    string logContent = containerGroup.GetLogContent(aciName);
                    Utilities.Log($"Logs for container instance: {aciName}\n{logContent}");
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
