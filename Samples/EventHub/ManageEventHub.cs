// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Eventhub.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Storage.Fluent;
using System;

namespace ManageEventHub
{
    /**
     * Azure Event Hub sample for managing event hub -
     *   - Create an event hub namespace
     *   - Create an event hub in the namespace with data capture enabled along with a consumer group and rule
     *   - List consumer groups in the event hub
     *   - Create a second event hub in the namespace
     *   - Create a consumer group in the second event hub
     *   - List consumer groups in the second event hub
     *   - Create an event hub namespace along with event hub.
     */
    public class Program
    {
        public static void RunSample(IAzure azure)
        {
            Region region = Region.USEast;
            string rgName = SdkContext.RandomResourceName("rgeh", 15);
            string namespaceName1 = SdkContext.RandomResourceName("ns", 15);
            string namespaceName2 = SdkContext.RandomResourceName("ns", 15);
            string storageAccountName = SdkContext.RandomResourceName("stg", 14);
            string eventHubName1 = SdkContext.RandomResourceName("eh", 14);
            string eventHubName2 = SdkContext.RandomResourceName("eh", 14);

            try
            {
                //============================================================
                // Create an event hub namespace
                //
                Utilities.Log("Creating a namespace");

                IEventHubNamespace namespace1 = azure.EventHubNamespaces
                        .Define(namespaceName1)
                            .WithRegion(Region.USEast2)
                            .WithNewResourceGroup(rgName)
                            .Create();

                Utilities.Print(namespace1);
                Utilities.Log("Created a namespace");

                //============================================================
                // Create an event hub in the namespace with data capture enabled, with consumer group and auth rule
                //

                ICreatable<IStorageAccount> storageAccountCreatable = azure.StorageAccounts
                        .Define(storageAccountName)
                            .WithRegion(Region.USEast2)
                            .WithExistingResourceGroup(rgName)
                            .WithSku(StorageAccountSkuType.Standard_LRS);

                Utilities.Log("Creating an event hub with data capture enabled with a consumer group and rule in it");

                IEventHub eventHub1 = azure.EventHubs
                        .Define(eventHubName1)
                            .WithExistingNamespace(namespace1)
                            // Optional - configure data capture
                            .WithNewStorageAccountForCapturedData(storageAccountCreatable, "datacpt")
                            .WithDataCaptureEnabled()
                            // Optional - create one consumer group in event hub
                            .WithNewConsumerGroup("cg1", "sometadata")
                            // Optional - create an authorization rule for event hub
                            .WithNewListenRule("listenrule1")
                            .Create();

                Utilities.Log("Created an event hub with data capture enabled with a consumer group and rule in it");
                Utilities.Print(eventHub1);

                //============================================================
                // Retrieve consumer groups in the event hub
                //
                Utilities.Log("Retrieving consumer groups");

                var consumerGroups = eventHub1.ListConsumerGroups();

                Utilities.Log("Retrieved consumer groups");
                foreach (IEventHubConsumerGroup group in consumerGroups)
                {
                    Utilities.Print(group);
                }

                //============================================================
                // Create another event hub in the namespace using event hub accessor in namespace accessor
                //

                Utilities.Log("Creating another event hub in the namespace");

                IEventHub eventHub2 = azure.EventHubNamespaces
                        .EventHubs
                        .Define(eventHubName2)
                            .WithExistingNamespace(namespace1)
                            .Create();

                Utilities.Log("Created second event hub");
                Utilities.Print(eventHub2);

                //============================================================
                // Create a consumer group in the event hub using consumer group accessor in event hub accessor
                //

                Utilities.Log("Creating a consumer group in the second event hub");

                IEventHubConsumerGroup consumerGroup2 = azure.EventHubNamespaces
                        .EventHubs
                        .ConsumerGroups
                        .Define("cg2")
                            .WithExistingEventHub(eventHub2)
                            // Optional
                            .WithUserMetadata("sometadata")
                            .Create();

                Utilities.Log("Created a consumer group in the second event hub");
                Utilities.Print(consumerGroup2);

                //============================================================
                // Retrieve consumer groups in the event hub
                //
                Utilities.Log("Retrieving consumer groups in the second event hub");

                consumerGroups = eventHub2.ListConsumerGroups();

                Utilities.Log("Retrieved consumer groups in the seoond event hub");
                foreach (IEventHubConsumerGroup group in consumerGroups)
                {
                    Utilities.Print(group);
                }

                //============================================================
                // Create an event hub namespace with event hub
                //

                Utilities.Log("Creating an event hub namespace along with event hub");

                IEventHubNamespace namespace2 = azure.EventHubNamespaces
                        .Define(namespaceName2)
                            .WithRegion(Region.USEast2)
                            .WithExistingResourceGroup(rgName)
                            .WithNewEventHub(eventHubName2)
                            .Create();

                Utilities.Log("Created an event hub namespace along with event hub");
                Utilities.Print(namespace2);
                foreach (IEventHub eh in namespace2.ListEventHubs())
                {
                    Utilities.Print(eh);
                }
            }
            finally
            {
                try
                {
                    azure.ResourceGroups.DeleteByName(rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception ex)
                {
                    Utilities.Log(ex);
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

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
