// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Docker.DotNet;
using Microsoft.Azure.Management.ContainerRegistry.Fluent;
using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Linq;

namespace ManageContainerRegistryWithWebhooks
{
    public class Program
    {
        private static readonly Region Region = Region.USWestCentral;

        /**
         * Azure Container Registry sample for managing container registry with webhooks.
         *    - Create an Azure Container Registry and setup couple Webhooks to be triggered on registry related actions (push, delete)
         *  - If a local Docker engine cannot be found, create a Linux virtual machine that will host a Docker engine
         *      to be used for this sample
         *  - Use Docker DotNet to create a Docker client that will push/pull an image to/from Azure Container Registry
         *  - Pull a test image from the public Docker repo (hello-world:latest) to be used as a sample for pushing/pulling
         *      to/from an Azure Container Registry
         *    - List the container registry webhook event notifications after pushing a container image to the registry
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgACR", 15);
            string acrName = SdkContext.RandomResourceName("acrsample", 20);
            string saName = SdkContext.RandomResourceName("sa", 20);
            Region region = Region.USEast2;
            string dockerImageName = "hello-world";
            string dockerImageTag = "latest";
            string dockerContainerName = "sample-hello";
            string dockerImageRelPath = "samplesdotnet";
            string webhookName1 = "webhookbing1";
            string webhookName2 = "webhookbing2";
            string webhookServiceUri1 = "https://www.bing.com";
            string webhookServiceUri2 = "https://www.bing.com";

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
                        .DefineWebhook(webhookName1)
                            .WithTriggerWhen(WebhookAction.Push, WebhookAction.Delete)
                            .WithServiceUri(webhookServiceUri1)
                            .WithTag("tag", "value")
                            .WithCustomHeader("name", "value")
                            .Attach()
                        .DefineWebhook(webhookName2)
                            .WithTriggerWhen(WebhookAction.Push)
                            .WithServiceUri(webhookServiceUri2)
                            .Enabled(false)
                            .WithRepositoriesScope("")
                            .Attach()
                        .WithTag("tag1", "value1")
                        .Create();

                Utilities.Print(azureRegistry);

                //=============================================================
                // Ping the container registry webhook to validate it works as expected

                IWebhook webhook = azureRegistry.Webhooks.Get(webhookName1);
                webhook.Ping();
                var webhookEvents = webhook.ListEvents();
                Utilities.Log($"Found {webhookEvents.Count()} webhook events for: {webhook.Name} with container service: {azureRegistry.Name}/n");
                foreach (var webhookEventInfo in webhookEvents)
                {
                    Utilities.Log($"\t{webhookEventInfo.EventResponseMessage.Content}");
                }


                //=============================================================
                // Create a Docker client that will be used to push/pull images to/from the Azure Container Registry

                var acrCredentials = azureRegistry.GetCredentials();

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

                    string privateRepoUrl = azureRegistry.LoginServerUrl + "/" + dockerImageRelPath + "/" + dockerContainerName;
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
                    // Gets the container registry webhook after pushing a container image and lists the event notifications

                    webhook = azureRegistry.Webhooks.Get(webhookName1);
                    webhookEvents = webhook.ListEvents();
                    Utilities.Log($"Found {webhookEvents.Count()} webhook events for: {webhook.Name} with container service: {azureRegistry.Name}/n");
                    foreach (var webhookEventInfo in webhookEvents)
                    {
                        Utilities.Log($"\t{webhookEventInfo.EventResponseMessage.Content}");
                    }
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