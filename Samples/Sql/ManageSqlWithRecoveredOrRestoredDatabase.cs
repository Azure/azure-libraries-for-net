// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.Sql.Fluent.Models;
using System;

namespace ManageSqlWithRecoveredOrRestoredDatabase
{
    public class Program
    {
        private static readonly string sqlServerName = SdkContext.RandomResourceName("sqlserver", 20);
        private static readonly string rgName = SdkContext.RandomResourceName("rgsql", 20);
        private static readonly string administratorLogin = "sqladmin3423";
        private static readonly string administratorPassword = "myS3cureP@ssword";
        private static readonly string dbToDeleteName = "db-to-delete";
        private static readonly string dbToRestoreName = "db-to-restore";

        /**
         * Azure SQL sample for managing point in time restore and recover a deleted SQL Database -
         *  - Create a SQL Server with two database from a pre-existing sample.
         *  - Create a new database from a point in time restore
         *  - Delete a database then restore it from a recoverable dropped database automatic backup
         *  - Delete databases and SQL Server
         */
        public static void RunSample(IAzure azure)
        {
            try
            {
                // ============================================================
                // Create a SQL Server with two databases from a sample.
                Utilities.Log("Creating a SQL Server with two databases from a sample.");
                var sqlServer = azure.SqlServers.Define(sqlServerName)
                    .WithRegion(Region.USWest2)
                    .WithNewResourceGroup(rgName)
                    .WithAdministratorLogin(administratorLogin)
                    .WithAdministratorPassword(administratorPassword)
                    .DefineDatabase(dbToDeleteName)
                        .FromSample(SampleName.AdventureWorksLT)
                        .WithStandardEdition(SqlDatabaseStandardServiceObjective.S0)
                        .Attach()
                    .DefineDatabase(dbToRestoreName)
                        .FromSample(SampleName.AdventureWorksLT)
                        .WithStandardEdition(SqlDatabaseStandardServiceObjective.S0)
                        .Attach()
                    .Create();
                Utilities.PrintSqlServer(sqlServer);

                // Sleep for 5 minutes to allow for the service to be aware of the new server and databases
                SdkContext.DelayProvider.Delay(5 * 60 * 1000);

                var dbToBeDeleted = sqlServer.Databases
                    .Get(dbToDeleteName);
                Utilities.PrintDatabase(dbToBeDeleted);
                var dbToRestore = sqlServer.Databases
                    .Get(dbToRestoreName);
                Utilities.PrintDatabase(dbToRestore);

                // ============================================================
                // Loop until a point in time restore is available.
                Utilities.Log("Loop until a point in time restore is available.");

                int retries = 50;
                while (retries > 0 && dbToRestore.ListRestorePoints().Count == 0)
                {
                    retries--;
                    // Sleep for about 3 minutes
                    SdkContext.DelayProvider.Delay(3 * 60 * 1000);
                }
                if (retries == 0)
                {
                    return;
                }

                var restorePointInTime = dbToRestore.ListRestorePoints()[0];
                // Restore point might not be ready right away and we will have to wait for it.
                long waitForRestoreToBeReady = (long) ((System.TimeSpan)restorePointInTime.EarliestRestoreDate.GetValueOrDefault().Subtract(DateTime.Now.ToUniversalTime())).TotalMilliseconds;
                if (waitForRestoreToBeReady > 0)
                {
                    SdkContext.DelayProvider.Delay((int)waitForRestoreToBeReady);
                }

                var dbRestorePointInTime = sqlServer.Databases
                    .Define("db-restore-pit")
                    .FromRestorePoint(restorePointInTime)
                    .Create();
                Utilities.PrintDatabase(dbRestorePointInTime);
                dbRestorePointInTime.Delete();

                // ============================================================
                // Delete the database than loop until the restorable dropped database backup is available.
                Utilities.Log("Deleting the database than loop until the restorable dropped database backup is available.");

                dbToBeDeleted.Delete();
                retries = 24;
                while (retries > 0 && sqlServer.ListRestorableDroppedDatabases().Count == 0)
                {
                    retries--;
                    // Sleep for about 5 minutes
                    SdkContext.DelayProvider.Delay(5 * 60 * 1000);
                }
                var restorableDroppedDatabase = sqlServer.ListRestorableDroppedDatabases()[0];
                var dbRestoreDeleted = sqlServer.Databases
                    .Define("db-restore-deleted")
                    .FromRestorableDroppedDatabase(restorableDroppedDatabase)
                    .Create();
                Utilities.PrintDatabase(dbRestoreDeleted);

                // Delete databases
                dbToRestore.Delete();
                dbRestoreDeleted.Delete();

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
