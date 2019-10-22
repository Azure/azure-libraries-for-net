// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Linq;
using System.IO;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Monitor.Fluent.Models;
using DayOfWeek = Microsoft.Azure.Management.Monitor.Fluent.Models.DayOfWeek;

namespace AutoscaleSettingsBasedOnPerformanceOrSchedule
{
    public class Program
    {
        /**
         * This sample shows how to programmatically implement scenario described <a href="https://docs.microsoft.com/en-us/azure/monitoring-and-diagnostics/monitor-tutorial-autoscale-performance-schedule">here</a>.
         *  - Create a Web App and App Service Plan
         *  - Configure autoscale rules for scale-in and scale out based on the number of requests a Web App receives
         *  - Trigger a scale-out action and watch the number of instances increase
         *  - Trigger a scale-in action and watch the number of instances decrease
         *  - Clean up your resources
         */
        public static void RunSample(IAzure azure)
        {

            string webappName = SdkContext.RandomResourceName("MyTestScaleWebApp", 25);
            string autoscaleSettingsName = SdkContext.RandomResourceName("autoscalename1", 20);
            string rgName = SdkContext.RandomResourceName("rgMonitor", 15);

            try
            {
                // ============================================================
                // Create a Web App and App Service Plan
                Utilities.Log("Creating a web app and service plan");

                var webapp = azure.WebApps.Define(webappName)
                    .WithRegion(Region.USSouthCentral)
                    .WithNewResourceGroup(rgName)
                    .WithNewWindowsPlan(PricingTier.PremiumP1)
                    .Create();

                Utilities.Log("Created a web app:");
                Utilities.Print(webapp);

                // ============================================================
                // Configure autoscale rules for scale-in and scale out based on the number of requests a Web App receives
                var scaleSettings = azure.AutoscaleSettings.Define(autoscaleSettingsName)
                        .WithRegion(Region.USSouthCentral)
                        .WithExistingResourceGroup(rgName)
                        .WithTargetResource(webapp.AppServicePlanId)
                        // defining Default profile. Note: first created profile is always the default one.
                        .DefineAutoscaleProfile("Default profile")
                            .WithFixedInstanceCount(1)
                            .Attach()
                        // defining Monday to Friday profile
                        .DefineAutoscaleProfile("Monday to Friday")
                            .WithMetricBasedScale(1, 2, 1)
                            // Create a scale-out rule
                            .DefineScaleRule()
                                .WithMetricSource(webapp.Id)
                                .WithMetricName("Requests")
                                .WithStatistic(TimeSpan.FromMinutes(5), MetricStatisticType.Sum)
                                .WithCondition(TimeAggregationType.Total, ComparisonOperationType.GreaterThan, 10)
                                .WithScaleAction(ScaleDirection.Increase, ScaleType.ChangeCount, 1, TimeSpan.FromMinutes(5))
                                .Attach()
                            // Create a scale-in rule
                            .DefineScaleRule()
                                .WithMetricSource(webapp.Id)
                                .WithMetricName("Requests")
                                .WithStatistic(TimeSpan.FromMinutes(10), MetricStatisticType.Average)
                                .WithCondition(TimeAggregationType.Total, ComparisonOperationType.LessThan, 5)
                                .WithScaleAction(ScaleDirection.Decrease, ScaleType.ChangeCount, 1, TimeSpan.FromMinutes(5))
                                .Attach()
                            // Create profile schedule
                            .WithRecurrentSchedule("Pacific Standard Time", "09:00", DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday)
                            .Attach()
                        // define end time for the "Monday to Friday" profile specified above
                        .DefineAutoscaleProfile("{\"name\":\"Default\",\"for\":\"Monday to Friday\"}")
                            .WithScheduleBasedScale(1)
                            .WithRecurrentSchedule("Pacific Standard Time", "18:30", DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday)
                            .Attach()
                        .Create();

                var deployedWebAppUrl = "https://" + webapp.HostNames.First() + "/";
                // Trigger scale-out action
                for (int i = 0; i < 11; i++)
                {
                    SdkContext.DelayProvider.Delay(5000);
                    Utilities.CheckAddress(deployedWebAppUrl);
                }

                // Now you can browse the history of autoscale form the azure portal
                // 1. Open the App Service Plan.
                // 2. From the left-hand navigation pane, select the Monitor option. Once the page loads select the Autoscale tab.
                // 3. From the list, select the App Service Plan used throughout this tutorial.
                // 4. On the autoscale setting, click the Run history tab.
                // 5. You see a chart reflecting the instance count of the App Service Plan over time.
                // 6. In a few minutes, the instance count should rise from 1, to 2.
                // 7. Under the chart, you see the activity log entries for each scale action taken by this autoscale setting.
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