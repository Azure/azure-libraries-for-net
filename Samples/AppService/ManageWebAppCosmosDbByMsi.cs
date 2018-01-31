// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.CosmosDB.Fluent;
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.Azure.Authentication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace ManageWebAppCosmosDbByMsi
{
    public class Program
    {
        /**
         * Azure App Service basic sample for managing web apps.
         *  - Create a Cosmos DB with credentials stored in a Key Vault
         *  - Create a web app which interacts with the Cosmos DB by first
         *      reading the secrets from the Key Vault.
         *
         *      The source code of the web app is located at Asset/documentdb-dotnet-todo-app
         */

        public static void RunSample(IAzure azure)
        {
            Region region = Region.USWest;
            string appName = SdkContext.RandomResourceName("webapp-", 20);
            string rgName = SdkContext.RandomResourceName("rg1NEMV_", 24);
            string vaultName = SdkContext.RandomResourceName("vault", 20);
            string cosmosName = SdkContext.RandomResourceName("cosmosdb", 20);
            string appUrl = appName + ".azurewebsites.net";
            try
            {
                //============================================================
                // Create a CosmosDB

                Utilities.Log("Creating a CosmosDB...");
                ICosmosDBAccount cosmosDBAccount = azure.CosmosDBAccounts.Define(cosmosName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithKind(DatabaseAccountKind.GlobalDocumentDB)
                        .WithEventualConsistency()
                        .WithWriteReplication(Region.USEast)
                        .WithReadReplication(Region.USCentral)
                        .Create();

                Utilities.Log("Created CosmosDB");
                Utilities.Log(cosmosDBAccount);

                //============================================================
                // Create a key vault

                var servicePrincipalInfo = ParseAuthFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                IVault vault = azure.Vaults
                        .Define(vaultName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .DefineAccessPolicy()
                            .ForServicePrincipal(servicePrincipalInfo.ClientId)
                            .AllowSecretAllPermissions()
                            .Attach()
                        .Create();

                SdkContext.DelayProvider.Delay(10000);

                //============================================================
                // Store Cosmos DB credentials in Key Vault

                IKeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(async (authority, resource, scope) =>
                {
                    var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
                    var result = await context.AcquireTokenAsync(resource, new ClientCredential(servicePrincipalInfo.ClientId, servicePrincipalInfo.ClientSecret));
                    return result.AccessToken;
                }), ((KeyVaultManagementClient)azure.Vaults.Manager.Inner).HttpClient);
                keyVaultClient.SetSecretAsync(vault.VaultUri, "azure-documentdb-uri", cosmosDBAccount.DocumentEndpoint).GetAwaiter().GetResult();
                keyVaultClient.SetSecretAsync(vault.VaultUri, "azure-documentdb-key", cosmosDBAccount.ListKeys().PrimaryMasterKey).GetAwaiter().GetResult();
                keyVaultClient.SetSecretAsync(vault.VaultUri, "azure-documentdb-database", "tododb").GetAwaiter().GetResult();

                //============================================================
                // Create a web app with a new app service plan

                Utilities.Log("Creating web app " + appName + " in resource group " + rgName + "...");

                IWebApp app = azure.WebApps
                        .Define(appName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithNewWindowsPlan(PricingTier.StandardS1)
                        .WithNetFrameworkVersion(NetFrameworkVersion.V4_6)
                        .WithAppSetting("AZURE_KEYVAULT_URI", vault.VaultUri)
                        .WithSystemAssignedManagedServiceIdentity()
                        .Create();

                Utilities.Log("Created web app " + app.Name);
                Utilities.Log(app);

                //============================================================
                // Update vault to allow the web app to access

                vault.Update()
                        .DefineAccessPolicy()
                            .ForObjectId(app.SystemAssignedManagedServiceIdentityPrincipalId)
                            .AllowSecretAllPermissions()
                            .Attach()
                        .Apply();

                //============================================================
                // Deploy to web app through local Git

                Utilities.Log("Deploying a local asp.net application to " + appName + " through Git...");

                var profile = app.GetPublishingProfile();
                Utilities.DeployByGit(profile, "documentdb-dotnet-todo-app");

                Utilities.Log("Deployment to web app " + app.Name + " completed");
                Utilities.Print(app);

                // warm up
                Utilities.Log("Warming up " + appUrl + "...");
                Utilities.CheckAddress("http://" + appUrl);
                SdkContext.DelayProvider.Delay(5000);
                Utilities.Log("CURLing " + appUrl + "...");
                Utilities.Log(Utilities.CheckAddress("http://" + appUrl));
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

        private static ServicePrincipalLoginInformation ParseAuthFile(string authFile)
        {
            var info = new ServicePrincipalLoginInformation();

            var lines = File.ReadLines(authFile);
            if (lines.First().Trim().StartsWith("{"))
            {
                string json = string.Join("", lines);
                var jsonConfig = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                info.ClientId = jsonConfig["clientId"];
                if (jsonConfig.ContainsKey("clientSecret"))
                {
                    info.ClientSecret = jsonConfig["clientSecret"];
                }
            }
            else
            {
                lines.All(line =>
                {
                    if (line.Trim().StartsWith("#"))
                        return true; // Ignore comments
                    var keyVal = line.Trim().Split(new char[] { '=' }, 2);
                    if (keyVal.Length < 2)
                        return true; // Ignore lines that don't look like $$$=$$$
                    if (keyVal[0].Equals("client", StringComparison.OrdinalIgnoreCase))
                    {
                        info.ClientId = keyVal[1];
                    }
                    if (keyVal[0].Equals("key", StringComparison.OrdinalIgnoreCase))
                    {
                        info.ClientSecret = keyVal[1];
                    }
                    return true;
                });
            }

            return info;
        }
    }
}