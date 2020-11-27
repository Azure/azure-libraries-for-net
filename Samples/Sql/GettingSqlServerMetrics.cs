// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.Sql.Fluent.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingSqlServerMetrics
{
    public class Program
    {
        private static readonly string sqlServerName = SdkContext.RandomResourceName("sqlserver", 20);
        private static readonly string rgName = SdkContext.RandomResourceName("rgsql", 20);
        private static readonly string administratorLogin = "sqladmin3423";
        private static readonly string administratorPassword = Utilities.CreatePassword();
        private static readonly string storageName = SdkContext.RandomResourceName("sqlserver", 20);
        private static readonly string dbName = "dbSample";
        private static readonly string epName = "epSample";

        /**
         * Azure SQL sample for getting SQL Server and Databases metrics
         *  - Create a primary SQL Server with a sample database.
         *  - Run some queries on the sample database.
         *  - Create a new table and insert some values into the database.
         *  - List the SQL subscription usage metrics, the database usage metrics and the other database metrics
         *  - Use the Monitor Service Fluent APIs to list the SQL Server metrics and the SQL Database metrics
         *  - Delete Sql Server
         */
        public static void RunSample(IAzure azure)
        {
            string sqlServerName = SdkContext.RandomResourceName("sqlserver", 20);
            string rgName = SdkContext.RandomResourceName("rgsql", 20);
            Region region = Region.USSouthCentral;
            DateTime startTime = DateTime.Now.ToUniversalTime().Subtract(new TimeSpan(1, 0, 0, 0));

            try
            {
                // ============================================================
                // Create a SQL Server with one database from a sample.
                var sqlServer = azure.SqlServers.Define(sqlServerName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .WithAdministratorLogin(administratorLogin)
                    .WithAdministratorPassword(administratorPassword)
                    .DefineFirewallRule("allowAll")
                        .WithIPAddressRange("0.0.0.1", "255.255.255.255")
                        .Attach()
                    .DefineElasticPool(epName)
                        .WithStandardPool()
                        .Attach()
                    .DefineDatabase(dbName)
                        .WithExistingElasticPool(epName)
                        .FromSample(SampleName.AdventureWorksLT)
                        .Attach()
                    .Create();
                Utilities.PrintSqlServer(sqlServer);

                var connectionString = $"user id={administratorLogin};" +
                                       $"password={administratorPassword};" +
                                       $"server={sqlServer.FullyQualifiedDomainName};" +
                                       $"database={dbName}; " +
                                       "Trusted_Connection=False;" +
                                       "Encrypt=True;" +
                                       "connection timeout=30";
                // ============================================================
                // Create a connection to the SQL Server.
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    // ============================================================
                    // Create and execute a "select" SQL statement on the sample database.
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader myReader = null;
                        SqlCommand myCommand = new SqlCommand("SELECT TOP 10 Title, FirstName, LastName from SalesLT.Customer",
                                                                 sqlConnection);
                        myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            Utilities.Log(myReader["Title"].ToString() + " " +
                                myReader["FirstName"].ToString() + " " +
                                myReader["LastName"].ToString());
                        }

                        // ============================================================
                        // Create and execute an "INSERT" SQL statement on the sample database.
                        string insertSql = "INSERT INTO SalesLT.Product (Name, ProductNumber, Color, StandardCost, ListPrice, SellStartDate) VALUES "
                            + "('Bike', 'B1', 'Blue', 50, 120, '2016-01-01');";

                        SqlCommand prepsInsertProduct = new SqlCommand(insertSql, sqlConnection);
                        prepsInsertProduct.ExecuteNonQuery();

                        // ============================================================
                        // Create a new table into the SQL Server database and insert one value.
                        Utilities.Log("Creating a new table into the SQL Server database and insert one value");
                        string sqlCreateTableCommand = "CREATE TABLE [Sample_Test] ([Name] [varchar](30) NOT NULL)";
                        SqlCommand createTable = new SqlCommand(sqlCreateTableCommand, sqlConnection);
                        createTable.ExecuteNonQuery();
                        string sqlInsertCommand = "INSERT INTO Sample_Test VALUES ('Test')";
                        SqlCommand insertValue = new SqlCommand(sqlInsertCommand, sqlConnection);
                        createTable.ExecuteNonQuery();

                        // ============================================================
                        // Run a "select" query for the new table.
                        Utilities.Log("Running a \"SELECT\" query for the new table");

                        string sqlSelectNewTableCommand = "SELECT * FROM Sample_Test;";
                        SqlCommand selectCommand = new SqlCommand(sqlSelectNewTableCommand, sqlConnection);
                        myReader = selectCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            Utilities.Log(myReader["Name"].ToString());
                        }

                        SdkContext.DelayProvider.Delay(6 * 60 * 1000);

                        // ============================================================
                        // List the SQL subscription usage metrics for the current selected region.
                        Utilities.Log("Listing the SQL subscription usage metrics for the current selected region");


                        var subscriptionUsageMetrics = azure.SqlServers.ListUsageByRegion(region);
                        foreach (var usageMetric in subscriptionUsageMetrics)
                        {
                            Utilities.PrintSqlMetric(usageMetric);
                        }

                        // ============================================================
                        // List the SQL database usage metrics for the sample database.
                        Utilities.Log("Listing the SQL database usage metrics for the sample database");

                        var db = sqlServer.Databases.Get(dbName);

                        var databaseUsageMetrics = db.ListUsageMetrics();
                        foreach (var usageMetric in databaseUsageMetrics)
                        {
                            Utilities.PrintSqlMetric(usageMetric);
                        }

                        // ============================================================
                        // List the SQL database CPU metrics for the sample database.
                        Utilities.Log("Listing the SQL database CPU metrics for the sample database");

                        DateTime endTime = DateTime.Now.ToUniversalTime();
                        string filter = $"name/value eq 'cpu_percent' and startTime eq '{startTime}' and endTime eq '{endTime}'";
                        var dbMetrics = db.ListMetrics(filter);

                        foreach (var metric in dbMetrics)
                        {
                            Utilities.PrintSqlMetric(metric);
                        }

                        // ============================================================
                        // List the SQL database metrics for the sample database.
                        Utilities.Log("Listing the SQL database metrics for the sample database");
                        filter = $"startTime eq '{startTime}' and endTime eq '{endTime}'";
                        dbMetrics = db.ListMetrics(filter);

                        foreach (var metric in dbMetrics)
                        {
                            Utilities.PrintSqlMetric(metric);
                        }


                        // ============================================================
                        // Use Monitor Service to list the SQL server metrics.
                        Utilities.Log("Using Monitor Service to list the SQL server metrics");
                        var metricDefinitions = azure.MetricDefinitions.ListByResource(sqlServer.Id);

                        var ep = sqlServer.ElasticPools.Get(epName);

                        foreach (var metricDefinition in metricDefinitions)
                        {
                            // find metric definition for "DTU used" and "Storage used"
                            if (metricDefinition.Name.LocalizedValue.Equals("dtu used", StringComparison.OrdinalIgnoreCase)
                                || metricDefinition.Name.LocalizedValue.Equals("storage used", StringComparison.OrdinalIgnoreCase))
                            {
                                // get metric records
                                var metricCollection = metricDefinition.DefineQuery()
                                    .StartingFrom(startTime)
                                    .EndsBefore(endTime)
                                    .WithAggregation("Average")
                                    .WithInterval(TimeSpan.FromMinutes(5))
                                    .WithOdataFilter($"ElasticPoolResourceId eq '{ep.Id}'")
                                    .Execute();

                                Utilities.Log($"SQL server \"{sqlServer.Name}\" {metricDefinition.Name.LocalizedValue} metrics\n");
                                Utilities.Log("\tNamespacse: " + metricCollection.Namespace);
                                Utilities.Log("\tQuery time: " + metricCollection.Timespan);
                                Utilities.Log("\tTime Grain: " + metricCollection.Interval);
                                Utilities.Log("\tCost: " + metricCollection.Cost);

                                foreach (var metric in metricCollection.Metrics)
                                {
                                    Utilities.Log("\tMetric: " + metric.Name.LocalizedValue);
                                    Utilities.Log("\tType: " + metric.Type);
                                    Utilities.Log("\tUnit: " + metric.Unit);
                                    Utilities.Log("\tTime Series: ");
                                    foreach (var timeElement in metric.Timeseries)
                                    {
                                        Utilities.Log("\t\tMetadata: ");
                                        foreach (var metadata in timeElement.Metadatavalues)
                                        {
                                            Utilities.Log("\t\t\t" + metadata.Name.LocalizedValue + ": " + metadata.Value);
                                        }
                                        Utilities.Log("\t\tData: ");
                                        foreach (var data in timeElement.Data)
                                        {
                                            Utilities.Log("\t\t\t" + data.TimeStamp
                                                    + " : (Min) " + data.Minimum
                                                    + " : (Max) " + data.Maximum
                                                    + " : (Avg) " + data.Average
                                                    + " : (Total) " + data.Total
                                                    + " : (Count) " + data.Count);
                                        }
                                    }
                                }
                            }
                        }

                        // ============================================================
                        // Use Monitor Service to list the SQL Database metrics.
                        Utilities.Log("Using Monitor Service to list the SQL Database metrics");
                        metricDefinitions = azure.MetricDefinitions.ListByResource(db.Id);

                        foreach (var metricDefinition in metricDefinitions)
                        {
                            // find metric definition for "dtu used", "cpu used" and "storage"
                            if (metricDefinition.Name.LocalizedValue.Equals("dtu used", StringComparison.OrdinalIgnoreCase)
                                || metricDefinition.Name.LocalizedValue.Equals("cpu used", StringComparison.OrdinalIgnoreCase)
                                || metricDefinition.Name.LocalizedValue.Equals("storage used", StringComparison.OrdinalIgnoreCase))
                            {
                                // get metric records
                                var metricCollection = metricDefinition.DefineQuery()
                                    .StartingFrom(startTime)
                                    .EndsBefore(endTime)
                                    .Execute();

                                Utilities.Log("Metrics for '" + db.Id + "':");
                                Utilities.Log("\tNamespacse: " + metricCollection.Namespace);
                                Utilities.Log("\tQuery time: " + metricCollection.Timespan);
                                Utilities.Log("\tTime Grain: " + metricCollection.Interval);
                                Utilities.Log("\tCost: " + metricCollection.Cost);

                                foreach (var metric in metricCollection.Metrics)
                                {
                                    Utilities.Log("\tMetric: " + metric.Name.LocalizedValue);
                                    Utilities.Log("\tType: " + metric.Type);
                                    Utilities.Log("\tUnit: " + metric.Unit);
                                    Utilities.Log("\tTime Series: ");
                                    foreach (var timeElement in metric.Timeseries)
                                    {
                                        Utilities.Log("\t\tMetadata: ");
                                        foreach (var metadata in timeElement.Metadatavalues)
                                        {
                                            Utilities.Log("\t\t\t" + metadata.Name.LocalizedValue + ": " + metadata.Value);
                                        }
                                        Utilities.Log("\t\tData: ");
                                        foreach (var data in timeElement.Data)
                                        {
                                            Utilities.Log("\t\t\t" + data.TimeStamp
                                                    + " : (Min) " + data.Minimum
                                                    + " : (Max) " + data.Maximum
                                                    + " : (Avg) " + data.Average
                                                    + " : (Total) " + data.Total
                                                    + " : (Count) " + data.Count);
                                        }
                                    }
                                }
                            }
                        }

                        sqlConnection.Close();
                    }
                    catch (Exception e)
                    {
                        Utilities.Log(e.ToString());
                    }
                }

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