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

namespace ManageWebAppLogs
{
    public class Program
    {
        /**
         * Azure App Service basic sample for managing web apps.
         *  - Create a web app under the same new app service plan:
         *    - Deploy to app using web deploy
         *    - stream logs for 120 seconds
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
                // Create a web app with a new app service plan

                Utilities.Log("Creating web app " + appName + " in resource group " + rgName + "...");

                IWebApp app = azure.AppServices.WebApps.Define(appName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithNewWindowsPlan(PricingTier.BasicB1)
                        .WithJavaVersion(JavaVersion.V8Newest)
                        .WithWebContainer(WebContainer.Tomcat8_0Newest)
                        .DefineDiagnosticLogsConfiguration()
                            .WithWebServerLogging()
                            .WithWebServerLogsStoredOnFileSystem()
                            .Attach()
                        .Create();

                Utilities.Log("Created web app " + app.Name);
                Utilities.Print(app);

                //============================================================
                // Listen to logs synchronously for 30 seconds

                using (var stream = app.StreamAllLogs())
                {
                    var reader = new StreamReader(stream);
                    Utilities.Log("Streaming logs from function app " + appName + "...");
                    string line = reader.ReadLine();
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    Task.Factory.StartNew(() =>
                    {
                        //============================================================
                        // Deploy to app 1 through zip deploy

                        SdkContext.DelayProvider.Delay(10000);
                        Utilities.Log("Deploying coffeeshop.war to " + appName + " through web deploy...");

                        app.Deploy()
                            .WithPackageUri("https://github.com/Azure/azure-libraries-for-java/raw/master/azure-samples/src/main/resources/coffeeshop.zip")
                            .WithExistingDeploymentsDeleted(false)
                            .Execute();

                        Utilities.Log("Deployments to web app " + app.Name + " completed");
                        Utilities.Print(app);

                        // warm up
                        Utilities.Log("Warming up " + appUrl + "/coffeeshop...");
                        Utilities.CheckAddress("http://" + appUrl + "/coffeeshop");

                        SdkContext.DelayProvider.Delay(5000);
                        Utilities.Log("CURLing " + appUrl + "/coffeeshop...");
                        Utilities.Log(Utilities.CheckAddress("http://" + appUrl + "/coffeeshop"));
                        SdkContext.DelayProvider.Delay(15000);
                        Utilities.Log("CURLing " + appUrl + "/coffeeshop...");
                        Utilities.Log(Utilities.CheckAddress("http://" + appUrl + "/coffeeshop"));
                        SdkContext.DelayProvider.Delay(25000);
                        Utilities.Log("CURLing " + appUrl + "/coffeeshop...");
                        Utilities.Log(Utilities.CheckAddress("http://" + appUrl + "/coffeeshop"));
                        SdkContext.DelayProvider.Delay(35000);
                        Utilities.Log("CURLing " + appUrl + "/coffeeshop...");
                        Utilities.Log(Utilities.CheckAddress("http://" + appUrl + "/coffeeshop"));
                    });
                    while (line != null && stopWatch.ElapsedMilliseconds < 120000)
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