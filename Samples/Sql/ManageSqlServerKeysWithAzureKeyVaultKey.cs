// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.Sql.Fluent.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ManageSqlServerKeysWithAzureKeyVaultKey
{
    public class Program

    {
        private static string Azure_SP_ClientId;
        private static string Azure_SP_Secret;

        private static readonly string sqlServerName = SdkContext.RandomResourceName("sqlserver", 20);
        private static readonly string rgName = SdkContext.RandomResourceName("rgsql", 20);
        private static readonly string administratorLogin = "sqladmin3423";
        private static readonly string administratorPassword = Utilities.CreatePassword();
        private static readonly string vaultName = SdkContext.RandomResourceName("sqlkv", 20);
        private static readonly string keyName = SdkContext.RandomResourceName("sqlkey", 20);

        /**
         * Azure SQL sample for managing SQL secrets (Server Keys) using Azure Key Vault -
         *  - Create a SQL Server with "system assigned" managed service identity.
         *  - Create an Azure Key Vault with giving access to the SQL Server
         *  - Create, get, list and delete SQL Server Keys
         *  - Delete SQL Server
         */
        public static void RunSample(IAzure azure)
        {
            try
            {
                // ============================================================
                // Create a SQL Server with system assigned managed service identity.
                Utilities.Log("Creating a SQL Server with system assigned managed service identity");

                var sqlServer = azure.SqlServers.Define(sqlServerName)
                    .WithRegion(Region.USSouthCentral)
                    .WithNewResourceGroup(rgName)
                    .WithAdministratorLogin(administratorLogin)
                    .WithAdministratorPassword(administratorPassword)
                    .WithSystemAssignedManagedServiceIdentity()
                    .Create();

                Utilities.PrintSqlServer(sqlServer);

                // ============================================================
                // Create an Azure Key Vault and set the access policies.
                Utilities.Log("Creating an Azure Key Vault and set the access policies");
                InitializeCredentials(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));
                if (Azure_SP_ClientId == null || Azure_SP_Secret == null)
                {
                    throw new ArgumentNullException("Missing Client ID and Secret");
                }
                var vault = azure.Vaults.Define(vaultName)
                    .WithRegion(Region.USSouthCentral)
                    .WithExistingResourceGroup(rgName)
                    .DefineAccessPolicy()
                        .ForObjectId(sqlServer.SystemAssignedManagedServiceIdentityPrincipalId)
                        .AllowKeyPermissions(KeyPermissions.WrapKey, KeyPermissions.UnwrapKey, KeyPermissions.Get, KeyPermissions.List)
                        .Attach()
                    .DefineAccessPolicy()
                        .ForServicePrincipal(Azure_SP_ClientId)
                        .AllowKeyAllPermissions()
                        .Attach()
                    .Create();

                SdkContext.DelayProvider.Delay(3 * 60 * 1000);

                // ============================================================
                // Create a SQL server key with Azure Key Vault key.
                Utilities.Log("Creating a SQL server key with Azure Key Vault key");

                KeyVaultClient kvClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetToken));
                var keyBundle = kvClient.CreateKeyAsync(vault.VaultUri, keyName, Microsoft.Azure.KeyVault.WebKey.JsonWebKeyType.Rsa,
                    keyOps: Microsoft.Azure.KeyVault.WebKey.JsonWebKeyOperation.AllOperations).GetAwaiter().GetResult();

                string keyUri = keyBundle.Key.Kid;

                // Work around for SQL server key name must be formatted as "vault_key_version"
                string serverKeyName = $"{vaultName}_{keyName}_" +
                    keyUri.Substring(keyUri.LastIndexOf("/") + 1);

                var sqlServerKey = sqlServer.ServerKeys.Define()
                    .WithAzureKeyVaultKey(keyUri)
                    .Create();

                Utilities.PrintSqlServerKey(sqlServerKey);


                // Validate key exists by getting key
                Utilities.Log("Validating key exists by getting the key");

                sqlServerKey = sqlServer.ServerKeys.Get(serverKeyName);

                Utilities.PrintSqlServerKey(sqlServerKey);


                // Validate key exists by listing keys
                Utilities.Log("Validating key exists by listing keys");

                var serverKeys = sqlServer.ServerKeys.List();
                foreach (var item in serverKeys)
                {
                    Utilities.PrintSqlServerKey(item);
                }


                // Delete key
                Utilities.Log("Deleting the key");
                azure.SqlServers.ServerKeys.DeleteBySqlServer(rgName, sqlServerName, serverKeyName);


                // Delete the SQL Server.
                Utilities.Log("Deleting a Sql Server");
                azure.SqlServers.DeleteById(sqlServer.Id);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (Exception e)
                {
                    Utilities.Log(e);
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
                Utilities.Log(e.ToString());
            }
        }

        //the method that will be provided to the KeyVaultClient
        public static async Task<string> GetToken(string authority, string resource, string scope)
        {
            //=================================================================
            // Authenticate
            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(Azure_SP_ClientId, Azure_SP_Secret);
            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);

            if (result == null)
                throw new InvalidOperationException("Failed to obtain the JWT token");

            return result.AccessToken;
        }

        public static void InitializeCredentials(string authFile)
        {
            var config = new Dictionary<string, string>()
            {
                { "authurl", AzureEnvironment.AzureGlobalCloud.AuthenticationEndpoint },
                { "baseurl", AzureEnvironment.AzureGlobalCloud.ResourceManagerEndpoint },
                { "managementuri", AzureEnvironment.AzureGlobalCloud.ManagementEndpoint },
                { "graphurl", AzureEnvironment.AzureGlobalCloud.GraphEndpoint }
            };

            var lines = File.ReadLines(authFile);
            if (lines.First().Trim().StartsWith("{"))
            {
                string json = string.Join("", lines);
                AuthFile jsonConfig = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<AuthFile>(json);
                jsonConfig.GetType()
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .ToList()
                    .ForEach(info => config[info.Name] = (string)info.GetValue(jsonConfig));
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
                    config[keyVal[0].ToLowerInvariant()] = keyVal[1];
                    return true;
                });
            }
            Azure_SP_ClientId = config["client"];
            Azure_SP_Secret = config["key"];
        }
        private class AuthFile
        {
            [JsonProperty("clientId")]
            private string client;

            [JsonProperty("tenantId")]
            private string tenant;

            [JsonProperty("clientSecret")]
            private string key;

            [JsonProperty("clientCertificate")]
            private string certificate;

            [JsonProperty("clientCertificatePassword")]
            private string certificatepassword;

            [JsonProperty("subscriptionId")]
            private string subscription;

            [JsonProperty("activeDirectoryEndpointUrl")]
            private string authurl;

            [JsonProperty("resourceManagerEndpointUrl")]
            private string baseurl;

            [JsonProperty("managementEndpointUrl")]
            private string managementuri;

            [JsonProperty("activeDirectoryGraphResourceId")]
            private string graphurl;
        }

    }
}