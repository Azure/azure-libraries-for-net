// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ManageFunctionAppLogs
{
    public class Program
    {
        /**
         * Azure App Service basic sample for managing function apps.
         *  - Create a function app under the same new app service plan:
         *    - Deploy to app using FTP
         *    - stream logs for 30 seconds
         */

        public static void RunSample(IAzure azure)
        {
            // New resources
            string suffix         = ".azurewebsites.net";
            string appName       = SdkContext.RandomResourceName("webapp1-", 20);
            string appUrl        = appName + suffix;
            string rgName         = SdkContext.RandomResourceName("rg1NEMV_", 24);

            try {


                //============================================================
                // Create a function app with a new app service plan

                Utilities.Log("Creating function app " + appName + " in resource group " + rgName + "...");

                IFunctionApp app = azure.AppServices.FunctionApps.Define(appName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .DefineDiagnosticLogsConfiguration()
                            .WithApplicationLogging()
                            .WithLogLevel(Microsoft.Azure.Management.AppService.Fluent.Models.LogLevel.Information)
                            .WithApplicationLogsStoredOnFileSystem()
                            .Attach()
                        .Create();

                Utilities.Log("Created function app " + app.Name);
                Utilities.Print(app);

                //============================================================
                // Deploy to app 1 through FTP

                Utilities.Log("Deploying a function app to " + appName + " through FTP...");

                IPublishingProfile profile = app.GetPublishingProfile();
                Utilities.UploadFileToFunctionApp(profile, Path.Combine(Utilities.ProjectPath, "Asset", "square-function-app", "host.json"));
                Utilities.UploadFileToFunctionApp(profile, Path.Combine(Utilities.ProjectPath, "Asset", "square-function-app", "square", "function.json"), "square/function.json");
                Utilities.UploadFileToFunctionApp(profile, Path.Combine(Utilities.ProjectPath, "Asset", "square-function-app", "square", "index.js"), "square/index.js");

                // sync triggers
                app.SyncTriggers();

                Utilities.Log("Deployment square app to web app " + app.Name + " completed");
                Utilities.Print(app);

                // warm up
                Utilities.Log("Warming up " + appUrl + "/api/square...");
                Utilities.PostAddress("http://" + appUrl + "/api/square", "625");
                SdkContext.DelayProvider.Delay(5000);
                Utilities.Log("CURLing " + appUrl + "/api/square...");
                Utilities.Log(Utilities.PostAddress("http://" + appUrl + "/api/square", "625"));

                //============================================================
                // Listen to logs synchronously for 30 seconds

                using (var stream = app.StreamApplicationLogs())
                {
                    var reader = new StreamReader(stream);
                    Utilities.Log("Streaming logs from function app " + appName + "...");
                    string line = reader.ReadLine();
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    Task.Factory.StartNew(() =>
                    {
                        Utilities.PostAddress("http://" + appUrl + "/api/square", "625");
                        SdkContext.DelayProvider.Delay(10000);
                        Utilities.PostAddress("http://" + appUrl + "/api/square", "725");
                        SdkContext.DelayProvider.Delay(10000);
                        Utilities.PostAddress("http://" + appUrl + "/api/square", "825");
                    });
                    while (line != null && stopWatch.ElapsedMilliseconds < 90000)
                    {
                        Utilities.Log(line);
                        line = reader.ReadLine();
                    }
                }
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception g)
                {
                    Utilities.Log(g);
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
            catch (Exception e)
            {
                Utilities.Log(e);
            }
        }
    }
}