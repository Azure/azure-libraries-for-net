// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.Sql.Fluent.Models;
using System;

namespace ManageSqlFailoverGroups
{
    public class Program
    {
        private static readonly string sqlPrimaryServerName = SdkContext.RandomResourceName("sqlserver", 20);
        private static readonly string sqlSecondaryServerName = SdkContext.RandomResourceName("sqlserver", 20);
        private static readonly string rgName = SdkContext.RandomResourceName("rgsql", 20);
        private static readonly string dbName = "dbSample";
        private static readonly string administratorLogin = "sqladmin3423";
        private static readonly string administratorPassword = Utilities.CreatePassword();

        /**
         * Azure SQL sample for managing SQL Failover Groups
         *  - Create a primary SQL Server with a sample database and a secondary SQL Server.
         *  - Get a failover group from the primary SQL server to the secondary SQL server.
         *  - Update a failover group.
         *  - List all failover groups.
         *  - Delete a failover group.
         *  - Delete Sql Server
         */
        public static void RunSample(IAzure azure)
        {
            try
            {
                // ============================================================
                // Create a primary SQL Server with a sample database.
                Utilities.Log("Creating a primary SQL Server with a sample database");

                var sqlPrimaryServer = azure.SqlServers.Define(sqlPrimaryServerName)
                    .WithRegion(Region.AsiaSouthEast)
                    .WithNewResourceGroup(rgName)
                    .WithAdministratorLogin(administratorLogin)
                    .WithAdministratorPassword(administratorPassword)
                    .DefineDatabase(dbName)
                        .FromSample(SampleName.AdventureWorksLT)
                        .WithStandardEdition(SqlDatabaseStandardServiceObjective.S0)
                        .Attach()
                    .Create();

                Utilities.PrintSqlServer(sqlPrimaryServer);

                // ============================================================
                // Create a secondary SQL Server with a sample database.
                Utilities.Log("Creating a secondary SQL Server with a sample database");

                var sqlSecondaryServer = azure.SqlServers.Define(sqlSecondaryServerName)
                    .WithRegion(Region.USEast2)
                    .WithExistingResourceGroup(rgName)
                    .WithAdministratorLogin(administratorLogin)
                    .WithAdministratorPassword(administratorPassword)
                    .Create();

                Utilities.PrintSqlServer(sqlSecondaryServer);


                // ============================================================
                // Create a Failover Group from the primary SQL server to the secondary SQL server.
                Utilities.Log("Creating a Failover Group from the primary SQL server to the secondary SQL server");

                string failoverGroupName = SdkContext.RandomResourceName("my-other-failover-group", 25);
                var failoverGroup = sqlPrimaryServer.FailoverGroups.Define(failoverGroupName)
                    .WithManualReadWriteEndpointPolicy()
                    .WithPartnerServerId(sqlSecondaryServer.Id)
                    .WithReadOnlyEndpointPolicyDisabled()
                    .Create();

                Utilities.PrintSqlFailoverGroup(failoverGroup);

                // ============================================================
                // Get the Failover Group from the secondary SQL server.
                Utilities.Log("Getting the Failover Group from the secondary SQL server");

                var failoverGroupOnPartner = sqlSecondaryServer.FailoverGroups.Get(failoverGroup.Name);

                Utilities.PrintSqlFailoverGroup(failoverGroup);


                // ============================================================
                // Update the Failover Group Endpoint policies and tags.
                Utilities.Log("Updating the Failover Group Endpoint policies and tags");

                failoverGroup.Update()
                    .WithAutomaticReadWriteEndpointPolicyAndDataLossGracePeriod(120)
                    .WithReadOnlyEndpointPolicyEnabled()
                    .WithTag("tag1", "value1")
                    .Apply();

                Utilities.PrintSqlFailoverGroup(failoverGroup);


                // ============================================================
                // Update the Failover Group to add database and change read-write endpoint's failover policy.
                Utilities.Log("Updating the Failover Group to add database and change read-write endpoint's failover policy");

                var db = sqlPrimaryServer.Databases.Get(dbName);

                Utilities.PrintDatabase(db);

                failoverGroup.Update()
                    .WithManualReadWriteEndpointPolicy()
                    .WithReadOnlyEndpointPolicyDisabled()
                    .WithNewDatabaseId(db.Id)
                    .Apply();

                Utilities.PrintSqlFailoverGroup(failoverGroup);


                // ============================================================
                // List the Failover Group on the secondary server.
                Utilities.Log("Listing the Failover Group on the secondary server");

                foreach (var item in sqlSecondaryServer.FailoverGroups.List())
                {
                    Utilities.PrintSqlFailoverGroup(item);
                }

                // ============================================================
                // Get the database from the secondary SQL server.
                Utilities.Log("Getting the database from the secondary server");
                SdkContext.DelayProvider.Delay(3 * 60 * 1000);

                db = sqlSecondaryServer.Databases.Get(dbName);

                Utilities.PrintDatabase(db);

                // ============================================================
                // Delete the Failover Group.
                Utilities.Log("Deleting the Failover Group");

                sqlPrimaryServer.FailoverGroups.Delete(failoverGroup.Name);


                // Delete the SQL Servers.
                Utilities.Log("Deleting the Sql Servers");
                azure.SqlServers.DeleteById(sqlPrimaryServer.Id);
                azure.SqlServers.DeleteById(sqlSecondaryServer.Id);
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