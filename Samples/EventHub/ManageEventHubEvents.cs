// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using Microsoft.Azure.Management.Eventhub.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Storage.Fluent;
using System;

namespace ManageEventHubEvents
{
    /**
     * Azure Event Hub sample for managing event hub models.
     *   - Create a DocumentDB instance
     *   - Creates a Event Hub namespace and an Event Hub in it
     *   - Retrieve the root namespace authorization rule
     *   - Enable diagnostics on a existing cosmosDB to stream events to event hub
     */
    public class Program
    {
        public static void RunSample(IAzure azure)
        {
            Region region = Region.USEast;
            string rgName = SdkContext.RandomResourceName("rgEvHb", 15);
            string namespaceName = SdkContext.RandomResourceName("ns", 15);
            string storageAccountName = SdkContext.RandomResourceName("stg", 15);
            string eventHubName = "FirstEventHub";
            string diagnosticSettingId = null;

            try
            {
                //=============================================================
                // Creates a Cosmos DB.
                //
                var docDb = azure.CosmosDBAccounts
                        .Define(namespaceName)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgName)
                            .WithKind(DatabaseAccountKind.MongoDB)
                            .WithEventualConsistency()
                            .WithWriteReplication(Region.USWest)
                            .WithReadReplication(Region.USCentral)
                        .Create();

                Utilities.Log("Created a DocumentDb instance.");
                Utilities.Print(docDb);
                //=============================================================
                // Creates a Event Hub namespace and an Event Hub in it.
                //

                Utilities.Log("Creating event hub namespace and event hub");

                var ehNamespace = azure.EventHubNamespaces
                    .Define(namespaceName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithNewEventHub(eventHubName)
                    .Create();

                Utilities.Log($"Created event hub namespace {ehNamespace.Name} and event hub {eventHubName}");
                Utilities.Print(ehNamespace);

                //=============================================================
                // Retrieve the root namespace authorization rule.
                //

                Utilities.Log("Retrieving the namespace authorization rule");

                var eventHubAuthRule = azure.EventHubNamespaces
                    .AuthorizationRules
                    .GetByName(ehNamespace.ResourceGroupName, ehNamespace.Name, "RootManageSharedAccessKey");

                Utilities.Log("Namespace authorization rule Retrieved");

                //=============================================================
                // Enable diagnostics on a cosmosDB to stream events to event hub
                //

                Utilities.Log("Enabling diagnostics events of a cosmosdb to stream to event hub");

                // Store Id of created Diagnostic settings only for clean-up
                var ds = azure.DiagnosticSettings
                        .Define("DiaEventHub")
                            .WithResource(docDb.Id)
                            .WithEventHub(eventHubAuthRule.Id, eventHubName)
                            .WithLog("DataPlaneRequests", 0)
                            .WithLog("MongoRequests", 0)
                            .WithMetric("AllMetrics", TimeSpan.FromMinutes(5), 0)
                        .Create();

                Utilities.Print(ds);
                diagnosticSettingId = ds.Id;

                Utilities.Log("Streaming of diagnostics events to event hub is enabled");

                //=============================================================
                // Listen for events from event hub using Event Hub dataplane APIs.
            }
            finally
            {
                try
                {
                    if (diagnosticSettingId != null)
                    {
                        Utilities.Log("Deleting Diagnostic Setting: " + diagnosticSettingId);
                        azure.DiagnosticSettings.DeleteById(diagnosticSettingId);
                    }
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
