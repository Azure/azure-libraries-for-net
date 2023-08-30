// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Storage.Fluent.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Linq;
using System.IO;

namespace QueryMetricsAndActivityLogs
{
    public class Program
    {
        /**
         * This sample shows examples of retrieving metrics and activity logs for Storage Account.
         *  - List all metric definitions available for a storage account
         *  - Retrieve and show metrics for the past 7 days for Transactions where
         *    - Api name was 'PutBlob' and
         *    - response type was 'Success' and
         *    - Geo type was 'Primary'
         *  -  Retrieve and show all activity logs for the past 7 days for the same Storage account.
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
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithBlobStorageAccountKind()
                        .WithAccessTier(AccessTier.Cool)
                        .Create();

                Utilities.Log("Created a Storage Account:");
                Utilities.PrintStorageAccount(storageAccount);

                var storageAccountKeys = storageAccount.GetKeys();
                var storageConnectionString = $"DefaultEndpointsProtocol=http;AccountName={storageAccount.Name};AccountKey={storageAccountKeys.First().Value}";

                // Add some blob transaction events
                AddBlobTransactions(storageConnectionString);

                DateTime recordDateTime = DateTime.Now.ToUniversalTime();
                // get metric definitions for storage account.
                foreach (var metricDefinition in azure.MetricDefinitions.ListByResource(storageAccount.Id))
                {
                    // find metric definition for Transactions
                    if (metricDefinition.Name.LocalizedValue.Equals("transactions", StringComparison.OrdinalIgnoreCase))
                    {
                        // get metric records
                        var metricCollection = metricDefinition.DefineQuery()
                                .StartingFrom(recordDateTime.AddDays(-7))
                                .EndsBefore(recordDateTime)
                                .WithAggregation("Average")
                                .WithInterval(TimeSpan.FromMinutes(5))
                                .WithOdataFilter("apiName eq 'PutBlob' and responseType eq 'Success' and geoType eq 'Primary'")
                                .Execute();

                        Utilities.Log("Metrics for '" + storageAccount.Id + "':");
                        Utilities.Log("Namespacse: " + metricCollection.Namespace);
                        Utilities.Log("Query time: " + metricCollection.Timespan);
                        Utilities.Log("Time Grain: " + metricCollection.Interval);
                        Utilities.Log("Cost: " + metricCollection.Cost);

                        foreach (var metric in metricCollection.Metrics)
                        {
                            Utilities.Log("\tMetric: " + metric.Name.LocalizedValue);
                            Utilities.Log("\tType: " + metric.Type);
                            Utilities.Log("\tUnit: " + metric.Unit);
                            Utilities.Log("\tTime Series: ");
                            foreach (var timeElement in metric.Timeseries)
                            {
                                Utilities.Log("\t\tMetadata: ");
                                foreach (var metadata in timeElement.Metadatavalues)
                                {
                                    Utilities.Log("\t\t\t" + metadata.Name.LocalizedValue + ": " + metadata.Value);
                                }
                                Utilities.Log("\t\tData: ");
                                foreach (var data in timeElement.Data)
                                {
                                    Utilities.Log("\t\t\t" + data.TimeStamp
                                            + " : (Min) " + data.Minimum
                                            + " : (Max) " + data.Maximum
                                            + " : (Avg) " + data.Average
                                            + " : (Total) " + data.Total
                                            + " : (Count) " + data.Count);
                                }
                            }
                        }
                        break;
                    }
                }

                // get activity logs for the same period.
                var logs = azure.ActivityLogs.DefineQuery()
                        .StartingFrom(recordDateTime.AddDays(-7))
                        .EndsBefore(recordDateTime)
                        .WithAllPropertiesInResponse()
                        .FilterByResource(storageAccount.Id)
                        .Execute();

                Utilities.Log("Activity logs for the Storage Account:");

                foreach (var eventData in logs)
                {
                    Utilities.Log("\tEvent: " + eventData.EventName?.LocalizedValue);
                    Utilities.Log("\tOperation: " + eventData.OperationName?.LocalizedValue);
                    Utilities.Log("\tCaller: " + eventData.Caller);
                    Utilities.Log("\tCorrelationId: " + eventData.CorrelationId);
                    Utilities.Log("\tSubscriptionId: " + eventData.SubscriptionId);
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

        private static void AddBlobTransactions(string storageConnectionString)
        {

            // Upload the script file as block blob
            //
            var account = CloudStorageAccount.Parse(storageConnectionString);
            var cloudBlobClient = account.CreateCloudBlobClient();
            var container = cloudBlobClient.GetContainerReference("scripts");
            container.CreateIfNotExistsAsync().GetAwaiter().GetResult();

            var serviceProps = cloudBlobClient.GetServicePropertiesAsync().GetAwaiter().GetResult();

            // configure Storage logging and metrics
            serviceProps.Logging = new LoggingProperties
                                    {
                                        LoggingOperations = LoggingOperations.All,
                                        RetentionDays = 2,
                                        Version = "1.0"
                                    };

            var metricProps = new MetricsProperties
                                {
                                    MetricsLevel = MetricsLevel.ServiceAndApi,
                                    RetentionDays = 2,
                                    Version = "1.0"
                                };

            serviceProps.HourMetrics = metricProps;
            serviceProps.MinuteMetrics = metricProps;

            // Set the default service version to be used for anonymous requests.
            serviceProps.DefaultServiceVersion = "2015-04-05";

            // Set the service properties.
            cloudBlobClient.SetServicePropertiesAsync(serviceProps).GetAwaiter().GetResult();
            var containerPermissions = new BlobContainerPermissions();
            // Include public access in the permissions object
            containerPermissions.PublicAccess = BlobContainerPublicAccessType.Container;
            // Set the permissions on the container
            container.SetPermissionsAsync(containerPermissions).GetAwaiter().GetResult();

            var blob = container.GetBlockBlobReference("install_apache.sh");
            blob.UploadFromFileAsync(Path.Combine(Utilities.ProjectPath, "Asset", "install_apache.sh")).GetAwaiter().GetResult();

            // give sometime for the infrastructure to process the records and fit into time grain.
            SdkContext.DelayProvider.Delay(6 * 60000);
        }
    }
}