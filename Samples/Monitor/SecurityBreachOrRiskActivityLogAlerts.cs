// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Storage.Fluent.Models;
using System;

namespace SecurityBreachOrRiskActivityLogAlerts
{
    public class Program
    {
        /**
         * This sample shows examples of configuring Activity Log Alerts for potential security breach or risk notifications.
         *  - Create a storage account
         *  - Setup an action group to trigger a notification to the security teams
         *  - Create an activity log alerts for storage account access key retrievals
         *  - List Storage account keys to trigger an alert.
         *  - Retrieve and show all activity logs that contains "List Storage Account Keys" operation name in the resource group for the past 7 days for the same Storage account.
         */
        public static void RunSample(IAzure azure)
        {
            string storageAccountName = SdkContext.RandomResourceName("saMonitor", 15);
            string rgName = SdkContext.RandomResourceName("rgMonitor", 15);

            try
            {
                // ============================================================
                // Create a storage account
                Utilities.Log("Creating a Storage Account");

                var storageAccount = azure.StorageAccounts.Define(storageAccountName)
                        .WithRegion(Region.USEast2)
                        .WithNewResourceGroup(rgName)
                        .WithBlobStorageAccountKind()
                        .WithAccessTier(AccessTier.Cool)
                        .Create();

                Utilities.Log("Created a Storage Account:");
                Utilities.PrintStorageAccount(storageAccount);

                // ============================================================
                // Create an action group to send notifications in case activity log alert condition will be triggered
                var ag = azure.ActionGroups.Define("securityBreachActionGroup")
                        .WithExistingResourceGroup(rgName)
                        .DefineReceiver("tierOne")
                            .WithPushNotification("security_on_duty@securecorporation.com")
                            .WithEmail("security_guards@securecorporation.com")
                            .WithSms("1", "4255655665")
                            .WithVoice("1", "2062066050")
                            .WithWebhook("https://www.weseemstobehacked.securecorporation.com")
                            .Attach()
                        .DefineReceiver("tierTwo")
                            .WithEmail("ceo@securecorporation.com")
                            .Attach()
                        .Create();
                Utilities.Print(ag);

                // ============================================================
                // Set a trigger to fire each time
                var ala = azure.AlertRules.ActivityLogAlerts
                        .Define("Potential security breach alert")
                        .WithExistingResourceGroup(rgName)
                        .WithTargetSubscription(azure.SubscriptionId)
                        .WithDescription("Security StorageAccounts ListAccountKeys trigger")
                        .WithRuleEnabled()
                        .WithActionGroups(ag.Id)
                        // fire an alert when all the conditions below will be true
                        .WithEqualsCondition("category", "Security")
                        .WithEqualsCondition("resourceId", storageAccount.Id)
                        .WithEqualsCondition("operationName", "Microsoft.Storage/storageAccounts/listkeys/action")
                        .Create();
                Utilities.Print(ala);

                // this should trigger an action
                var storageAccountKeys = storageAccount.GetKeys();

                // give sometime for the infrastructure to process the records and fit into time grain.
                // Note: Activity Log alerts could also be configured to route the logs to EventHubs through Monitor diagnostic Settings configuration
                // for near real time monitoring.
                SdkContext.DelayProvider.Delay(6 * 60000);

                DateTime recordDateTime = DateTime.Now.ToUniversalTime();
                // get activity logs for the same period.
                var logs = azure.ActivityLogs.DefineQuery()
                        .StartingFrom(recordDateTime.AddDays(-7))
                        .EndsBefore(recordDateTime)
                        .WithAllPropertiesInResponse()
                        .FilterByResource(ala.Id)
                        .Execute();

                Utilities.Log("Activity logs for the Storage Account:");

                foreach (var eventLog in logs)
                {
                    if (!eventLog.OperationName.LocalizedValue.Equals("List Storage Account Keys", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                    if (eventLog.EventName != null)
                    {
                        Utilities.Log("\tEvent: " + eventLog.EventName.LocalizedValue);
                    }

                    if (eventLog.OperationName != null)
                    {
                        Utilities.Log("\tOperation: " + eventLog.OperationName.LocalizedValue);
                    }
                    Utilities.Log("\tCaller: " + eventLog.Caller);
                    Utilities.Log("\tCorrelationId: " + eventLog.CorrelationId);
                    Utilities.Log("\tSubscriptionId: " + eventLog.SubscriptionId);
                }
            }
            finally
            {
                if (azure.ResourceGroups.GetByName(rgName) != null)
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                else
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