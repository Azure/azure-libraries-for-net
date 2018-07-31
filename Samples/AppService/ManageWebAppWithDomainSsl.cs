// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.TrafficManager.Fluent;
using System;
using System.IO;
using System.Net.Http;

namespace ManageWebAppWithDomainSsl
{
    public class Program
    {
        private const string CertificatePassword = "StrongPass!12";

        /**
         * Azure App Service sample for managing web apps.
         *  - app service plan, web app
         *    - Create 2 web apps under the same new app service plan
         *  - domain
         *    - Create a domain
         *  - certificate
         *    - Upload a self-signed wildcard certificate
         *    - update both web apps to use the domain and the created wildcard SSL certificate
         */
        public static void RunSample(IAzure azure)
        {
            string app1Name = SdkContext.RandomResourceName("webapp1-", 20);
            string app2Name = SdkContext.RandomResourceName("webapp2-", 20);
            string app3Name = SdkContext.RandomResourceName("webapp3-", 20);
            string trafficManagerName = SdkContext.RandomResourceName("tm-", 20);
            string rgName = SdkContext.RandomResourceName("rgNEMV_", 24);
            string domainName = "jianghaolu.com";
            string trafficManagerSubdomain = "tm";

            try
            {
                //============================================================
                // Create a web app with a new app service plan

                Utilities.Log("Creating web app " + app1Name + "...");

                var app1 = azure.WebApps
                        .Define(app1Name)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithNewWindowsPlan(PricingTier.StandardS1)
                        .Create();

                Utilities.Log("Created web app " + app1.Name);
                Utilities.Print(app1);

                var plan = azure.AppServices.AppServicePlans.GetById(app1.AppServicePlanId);

                Utilities.Log("Creating web app " + app2Name + "...");

                var app2 = azure.WebApps
                        .Define(app2Name)
                        .WithExistingWindowsPlan(plan)
                        .WithExistingResourceGroup(rgName)
                        .Create();

                Utilities.Log("Created web app " + app2.Name);
                Utilities.Print(app2);

                Utilities.Log("Creating web app " + app3Name + "...");

                var app3 = azure.WebApps
                        .Define(app3Name)
                        .WithExistingWindowsPlan(plan)
                        .WithExistingResourceGroup(rgName)
                        .Create();

                Utilities.Log("Created web app " + app3.Name);
                Utilities.Print(app3);

                //============================================================
                // Create a traffic manager

                Utilities.Log("Creating a traffic manager " + trafficManagerName + " for the web apps...");

                var trafficManager = azure.TrafficManagerProfiles
                        .Define(trafficManagerName)
                        .WithExistingResourceGroup(rgName)
                        .WithLeafDomainLabel(trafficManagerName)
                        .WithTrafficRoutingMethod(TrafficRoutingMethod.Weighted)
                        .DefineAzureTargetEndpoint("endpoint1")
                            .ToResourceId(app1.Id)
                            .Attach()
                        .Create();

                Utilities.Log("Created traffic manager " + trafficManager.Name);

                app1 = app1.Update()
                    .DefineHostnameBinding()
                        .WithThirdPartyDomain(domainName)
                        .WithSubDomain(trafficManagerSubdomain)
                        .WithDnsRecordType(CustomHostNameDnsRecordType.CName)
                        .Attach()
                    .Apply();

                app2 = app2.Update()
                    .DefineHostnameBinding()
                        .WithThirdPartyDomain(domainName)
                        .WithSubDomain(trafficManagerSubdomain)
                        .WithDnsRecordType(CustomHostNameDnsRecordType.CName)
                        .Attach()
                    .Apply();

                app3 = app3.Update()
                    .DefineHostnameBinding()
                        .WithThirdPartyDomain(domainName)
                        .WithSubDomain(trafficManagerSubdomain)
                        .WithDnsRecordType(CustomHostNameDnsRecordType.CName)
                        .Attach()
                    .Apply();

                //============================================================
                // Create a self-singed SSL certificate

                var pfxPath = domainName + ".pfx";

                Utilities.Log("Creating a self-signed certificate " + pfxPath + "...");

                Utilities.CreateCertificate(domainName, pfxPath, CertificatePassword);

                Utilities.Log("Created self-signed certificate " + pfxPath);

                //============================================================
                // Bind domain to web app 2 and turn on wild card SSL for both

                Utilities.Log("Binding https://" + app1Name + "." + domainName + " to web app " + app1Name + "...");

                app1 = app1.Update()
                                .DefineSslBinding()
                                    .ForHostname(trafficManagerSubdomain + "." + domainName)
                                    .WithPfxCertificateToUpload(Path.Combine(Utilities.ProjectPath, "Asset", pfxPath), CertificatePassword)
                                    .WithSniBasedSsl()
                                    .Attach()
                                .Apply();

                app2 = app2.Update()
                                .DefineSslBinding()
                                    .ForHostname(trafficManagerSubdomain + "." + domainName)
                                    .WithPfxCertificateToUpload(Path.Combine(Utilities.ProjectPath, "Asset", pfxPath), CertificatePassword)
                                    .WithSniBasedSsl()
                                    .Attach()
                                .Apply();

                app3 = app3.Update()
                                .DefineSslBinding()
                                    .ForHostname(trafficManagerSubdomain + "." + domainName)
                                    .WithPfxCertificateToUpload(Path.Combine(Utilities.ProjectPath, "Asset", pfxPath), CertificatePassword)
                                    .WithSniBasedSsl()
                                    .Attach()
                                .Apply();

                Utilities.Log("Finished binding https://" + app1Name + "." + domainName + " to web app " + app1Name);
                Utilities.Print(app1);


                //Utilities.Log("Binding https://" + app2Name + "." + domainName + " to web app " + app2Name + "...");

                //app2 = app2.Update()
                //                .WithManagedHostnameBindings(domain, app2Name)
                //                .DefineSslBinding()
                //                    .ForHostname(app2Name + "." + domainName)
                //                    .WithPfxCertificateToUpload(Path.Combine(Utilities.ProjectPath, "Asset", pfxPath), CertificatePassword)
                //                    .WithSniBasedSsl()
                //                    .Attach()
                //                .Apply();

                //Utilities.Log("Finished binding https://" + app2Name + "." + domainName + " to web app " + app2Name);
                //Utilities.Print(app2);
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