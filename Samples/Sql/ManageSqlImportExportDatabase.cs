// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.Sql.Fluent.Models;
using System;

namespace ManageSqlImportExportDatabase
{
    public class Program
    {
        private static readonly string sqlServerName = SdkContext.RandomResourceName("sqlserver", 20);
        private static readonly string rgName = SdkContext.RandomResourceName("rgsql", 20);
        private static readonly string administratorLogin = "sqladmin3423";
        private static readonly string administratorPassword = Utilities.CreatePassword();
        private static readonly string storageName = SdkContext.RandomResourceName("sqlserver", 20);
        private static readonly string dbFromSampleName = "db-from-sample";

        /**
         * Azure SQL sample for managing import/export SQL Database -
         *  - Create a SQL Server with one database from a pre-existing sample.
         *  - Create a storage account and export a database
         *  - Create a new database from a backup using the import functionality
         *  - Update an empty database with a backup database using the import functionality
         *  - Delete storage account, databases and SQL Server
         */
        public static void RunSample(IAzure azure)
        {
            string sqlServerName = SdkContext.RandomResourceName("sqlserver", 20);
            string rgName = SdkContext.RandomResourceName("rgRSDSI", 20);

            try
            {
                // ============================================================
                // Create a SQL Server with one database from a sample.
                var sqlServer = azure.SqlServers.Define(sqlServerName)
                    .WithRegion(Region.USWest)
                    .WithNewResourceGroup(rgName)
                    .WithAdministratorLogin(administratorLogin)
                    .WithAdministratorPassword(administratorPassword)
                    .DefineDatabase(dbFromSampleName)
                        .FromSample(SampleName.AdventureWorksLT)
                        .WithBasicEdition()
                        .Attach()
                    .Create();
                Utilities.PrintSqlServer(sqlServer);

                var dbFromSample = sqlServer.Databases
                    .Get(dbFromSampleName);
                Utilities.PrintDatabase(dbFromSample);

                // ============================================================
                // Export a database from a SQL server created above to a new storage account within the same resource group.
                Utilities.Log("Exporting a database from a SQL server created above to a new storage account within the same resource group.");

                ISqlDatabaseImportExportResponse exportedDB;
                var storageAccount = azure.StorageAccounts.GetByResourceGroup(sqlServer.ResourceGroupName, storageName);
                if (storageAccount == null)
                {
                    var storageAccountCreatable = azure.StorageAccounts
                        .Define(storageName)
                        .WithRegion(sqlServer.RegionName)
                        .WithExistingResourceGroup(sqlServer.ResourceGroupName);

                    exportedDB = dbFromSample.ExportTo(storageAccountCreatable, "from-sample", "dbfromsample.bacpac")
                        .WithSqlAdministratorLoginAndPassword(administratorLogin, administratorPassword)
                        .Execute();
                    storageAccount = azure.StorageAccounts.GetByResourceGroup(sqlServer.ResourceGroupName, storageName);
                }
                else
                {
                    exportedDB = dbFromSample.ExportTo(storageAccount, "from-sample", "dbfromsample.bacpac")
                        .WithSqlAdministratorLoginAndPassword(administratorLogin, administratorPassword)
                        .Execute();
                }

                // ============================================================
                // Import a database within a new elastic pool from a storage account container created above.
                Utilities.Log("Importing a database within a new elastic pool from a storage account container created above.");

                var dbFromImport = sqlServer.Databases
                    .Define("db-from-import1")
                        .DefineElasticPool("epi")
                            .WithStandardPool()
                            .Attach()
                        .ImportFrom(storageAccount, "from-sample", "dbfromsample.bacpac")
                            .WithSqlAdministratorLoginAndPassword(administratorLogin, administratorPassword)
                        .Create();
                Utilities.PrintDatabase(dbFromImport);

                // Delete the database.
                Utilities.Log("Deleting a database");
                dbFromImport.Delete();

                // ============================================================
                // Create an empty database within an elastic pool.
                var dbEmpty = sqlServer.Databases
                    .Define("db-from-import2")
                    .WithExistingElasticPool("epi")
                    .Create();

                // ============================================================
                // Import data from a BACPAC to an empty database within an elastic pool.
                Utilities.Log("Importing data from a BACPAC to an empty database within an elastic pool.");

                dbEmpty
                    .ImportBacpac(storageAccount, "from-sample", "dbfromsample.bacpac")
                    .WithSqlAdministratorLoginAndPassword(administratorLogin, administratorPassword)
                    .Execute();
                Utilities.PrintDatabase(dbEmpty);

                // Delete the storage account.
                Utilities.Log("Deleting the storage account");
                azure.StorageAccounts.DeleteById(storageAccount.Id);

                // Delete the databases.
                Utilities.Log("Deleting the databases");
                dbEmpty.Delete();
                dbFromSample.Delete();

                // Delete the elastic pool.
                Utilities.Log("Deleting the elastic pool");
                sqlServer.ElasticPools.Delete("epi");

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
    }
}