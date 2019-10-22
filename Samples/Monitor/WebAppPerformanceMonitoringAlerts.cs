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
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Monitor.Fluent.Models;
using System.Collections.Generic;

namespace WebAppPerformanceMonitoringAlerts
{
    public class Program
    {
        /**
         * This sample shows examples of configuring Metric Alerts for WebApp instance performance monitoring through app service plan.
         *  - Create a App Service plan
         *  - Setup an action group to trigger a notification to the heavy performance alerts
         *  - Create auto-mitigated metric alerts for the App Service plan when
         *    - average CPUPercentage on any of Web App instance (where Instance = *) over the last 5 minutes is above 80%
         */
        public static void RunSample(IAzure azure)
        {
            string storageAccountName = SdkContext.RandomResourceName("saMonitor", 15);
            string rgName = SdkContext.RandomResourceName("rgMonitor", 15);

            try
            {
                // ============================================================
                // Create an App Service plan
                Utilities.Log("Creating App Service plan");

                var servicePlan = azure.AppServices.AppServicePlans.Define("HighlyAvailableWebApps")
                        .WithRegion(Region.USEast2)
                        .WithNewResourceGroup(rgName)
                        .WithPricingTier(PricingTier.PremiumP1)
                        .WithOperatingSystem(Microsoft.Azure.Management.AppService.Fluent.OperatingSystem.Windows)
                        .Create();

                Utilities.Log("App Service plan created:");
                Utilities.Print(servicePlan);

                // ============================================================
                // Create an action group to send notifications in case metric alert condition will be triggered
                var ag = azure.ActionGroups.Define("criticalPerformanceActionGroup")
                        .WithExistingResourceGroup(rgName)
                        .DefineReceiver("tierOne")
                            .WithPushNotification("ops_on_duty@performancemonitoring.com")
                            .WithEmail("ops_on_duty@performancemonitoring.com")
                            .WithSms("1", "4255655665")
                            .WithVoice("1", "2062066050")
                            .WithWebhook("https://www.weeneedmorepower.performancemonitoring.com")
                            .Attach()
                        .DefineReceiver("tierTwo")
                            .WithEmail("ceo@performancemonitoring.com")
                            .Attach()
                        .Create();
                Utilities.Print(ag);

                // ============================================================
                // Set a trigger to fire each time
                var ma = azure.AlertRules.MetricAlerts.Define("Critical performance alert")
                    .WithExistingResourceGroup(rgName)
                    .WithTargetResource(servicePlan.Id)
                    .WithPeriod(TimeSpan.FromMinutes(5))
                    .WithFrequency(TimeSpan.FromMinutes(1))
                    .WithAlertDetails(3, "This alert rule is for U5 - Single resource-multiple criteria - with dimensions - with star")
                    .WithActionGroups(ag.Id)
                    .DefineAlertCriteria("Metric1")
                            .WithMetricName("CPUPercentage", "Microsoft.Web/serverfarms")
                            .WithCondition(MetricAlertRuleTimeAggregation.Total, MetricAlertRuleCondition.GreaterThan, 80)
                            .WithDimension("Instance", "*")
                            .Attach()
                    .Create();

                Utilities.Print(ma);
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