// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.Sql.Fluent.Models;
using System;

namespace ManageSqlServerKeysWithAzureKeyVaultKey
{
    public class Program
    {
        private static readonly string sqlServerName = SdkContext.RandomResourceName("sqlserver", 20);
        private static readonly string rgName = SdkContext.RandomResourceName("rgsql", 20);
        private static readonly string dbName = "dbSample";
        private static readonly string administratorLogin = "sqladmin3423";
        private static readonly string administratorPassword = "myS3cureP@ssword";
        private static readonly string vaultName = SdkContext.RandomResourceName("sqlkv", 20);
        private static readonly string keyName = SdkContext.RandomResourceName("sqlkey", 20);

        /**
         * Azure SQL sample for managing SQL secrets (Server Keys) using Azure Key Vault -
         *  - Create a SQL Server with "system assigned" managed service identity.
         *  - Create an Azure Key Vault with giving access to the SQL Server
         *  - Create, get, list and delete SQL Server Keys
         *  - Delete SQL Server
         */
        public static void RunSample(IAzure azure, string objectId)
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

                var vault = azure.Vaults.Define(vaultName)
                    .WithRegion(Region.USSouthCentral)
                    .WithExistingResourceGroup(rgName)
                    .DefineAccessPolicy()
                        .ForObjectId(sqlServer.SystemAssignedManagedServiceIdentityPrincipalId)
                        .AllowKeyPermissions(KeyPermissions.WrapKey, KeyPermissions.UnwrapKey, KeyPermissions.Get, KeyPermissions.List)
                        .Attach()
                    .DefineAccessPolicy()
                        .ForServicePrincipal(objectId)
                        .AllowKeyAllPermissions()
                        .Attach()
                    .Create();

                SdkContext.DelayProvider.Delay(3 * 60 * 1000);

                // Work around to Vault key APIs
                string keyUri = "https://YourVaultName.Vault.Azure.Net/keys/YourKeyName/01234567890123456789012345678901";
                
                //var keyBundle = vault.Keys.Define(keyName)
                //    .WithKeyTypeToCreate(JsonWebKeyType.Rsa)
                //    .WithKeyOperations(JsonWebKeyOperation.AllOperations)
                //    .Create();

                //// ============================================================
                //// Create a SQL server key with Azure Key Vault key.
                //Utilities.Log("Creating a SQL server key with Azure Key Vault key");

                //keyUri = keyBundle.JsonWebKey().kid();

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

                RunSample(azure, credentials.ClientId);
            }
            catch (Exception e)
            {
                Utilities.Log(e.ToString());
            }
        }
    }
}