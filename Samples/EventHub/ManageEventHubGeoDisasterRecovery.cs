// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Eventhub.Fluent;
using Microsoft.Azure.Management.EventHub.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageEventHubGeoDisasterRecovery
{
    public class Program
    {
        /**
         * Azure Event Hub sample for managing geo disaster recovery pairing -
         *   - Create two event hub namespaces
         *   - Create a pairing between two namespaces
         *   - Create an event hub in the primary namespace and retrieve it from the secondary namespace
         *   - Retrieve the pairing connection string
         *   - Fail over so that secondary namespace become primary.
         */
        public static void RunSample(IAzure azure)
        {
            Region region = Region.USEast;
            string rgName = SdkContext.RandomResourceName("rgeh", 15);
            string primaryNamespaceName = SdkContext.RandomResourceName("ns", 15);
            string secondaryNamespaceName = SdkContext.RandomResourceName("ns", 15);
            string geoDRName = SdkContext.RandomResourceName("geodr", 14);
            string eventHubName = SdkContext.RandomResourceName("eh", 14);
            bool isFailOverSucceeded = false;
            IEventHubDisasterRecoveryPairing pairing = null;

            try
            {
                //============================================================
                // Create resource group for the namespaces and recovery pairings
                //
                IResourceGroup resourceGroup = azure.ResourceGroups.Define(rgName)
                        .WithRegion(Region.USSouthCentral)
                        .Create();

                Utilities.Log($"Creating primary event hub namespace {primaryNamespaceName}");

                IEventHubNamespace primaryNamespace = azure.EventHubNamespaces
                    .Define(primaryNamespaceName)
                    .WithRegion(Region.USSouthCentral)
                    .WithExistingResourceGroup(resourceGroup)
                    .Create();

                Utilities.Log("Primary event hub namespace created");
                Utilities.Print(primaryNamespace);

                Utilities.Log($"Creating secondary event hub namespace {primaryNamespaceName}");

                IEventHubNamespace secondaryNamespace = azure.EventHubNamespaces
                        .Define(secondaryNamespaceName)
                        .WithRegion(Region.USNorthCentral)
                        .WithExistingResourceGroup(resourceGroup)
                        .Create();

                Utilities.Log("Secondary event hub namespace created");
                Utilities.Print(secondaryNamespace);

                //============================================================
                // Create primary and secondary namespaces and recovery pairing
                //

                Utilities.Log($"Creating geo-disaster recovery pairing {geoDRName}");

                pairing = azure.EventHubDisasterRecoveryPairings
                        .Define(geoDRName)
                        .WithExistingPrimaryNamespace(primaryNamespace)
                        .WithExistingSecondaryNamespace(secondaryNamespace)
                        .Create();

                while (pairing.ProvisioningState != ProvisioningStateDR.Succeeded)
                {
                    pairing = pairing.Refresh();
                    SdkContext.DelayProvider.Delay(15 * 1000);
                    if (pairing.ProvisioningState == ProvisioningStateDR.Failed)
                    {
                        throw new Exception("Provisioning state of the pairing is FAILED");
                    }
                }

                Utilities.Log($"Created geo-disaster recovery pairing {geoDRName}");
                Utilities.Print(pairing);

                //============================================================
                // Create an event hub and consumer group in primary namespace
                //

                Utilities.Log("Creating an event hub and consumer group in primary namespace");

                IEventHub eventHubInPrimaryNamespace = azure.EventHubs
                        .Define(eventHubName)
                        .WithExistingNamespace(primaryNamespace)
                        .WithNewConsumerGroup("consumerGrp1")
                        .Create();

                Utilities.Log("Created event hub and consumer group in primary namespace");
                Utilities.Print(eventHubInPrimaryNamespace);

                Utilities.Log("Waiting for 60 seconds to allow metadata to sync across primary and secondary");
                SdkContext.DelayProvider.Delay(60 * 1000); // Wait for syncing to finish

                Utilities.Log("Retrieving the event hubs in secondary namespace");

                IEventHub eventHubInSecondaryNamespace = azure.EventHubs.GetByName(rgName, secondaryNamespaceName, eventHubName);

                Utilities.Log("Retrieved the event hubs in secondary namespace");
                Utilities.Print(eventHubInSecondaryNamespace);

                //============================================================
                // Retrieving the connection string
                //
                var rules = pairing.ListAuthorizationRules();
                foreach (IDisasterRecoveryPairingAuthorizationRule rule in rules)
                {
                    IDisasterRecoveryPairingAuthorizationKey key = rule.GetKeys();
                    Utilities.Print(key);
                }

                Utilities.Log("Initiating fail over");

                pairing.FailOver();
                isFailOverSucceeded = true;

                Utilities.Log("Fail over initiated");
            }
            finally
            {
                try
                {
                    try
                    {
                        // It is necessary to break pairing before deleting resource group
                        //
                        if (pairing != null && !isFailOverSucceeded)
                        {
                            pairing.BreakPairing();
                        }
                    }
                    catch (Exception ex)
                    {
                        Utilities.Log("Pairing breaking failed:" + ex.Message);
                    }
                    azure.ResourceGroups.BeginDeleteByName(rgName);
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
