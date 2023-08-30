// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.Sql.Fluent.Models;
using System;
using System.Data.SqlClient;

namespace ManageSqlServerDnsAliases
{
    public class Program
    {
        private static readonly string sqlServerForTestName = SdkContext.RandomResourceName("sqltest", 20);
        private static readonly string sqlServerForProdName = SdkContext.RandomResourceName("sqlprod", 20);
        private static readonly string sqlServerDnsAlias = SdkContext.RandomResourceName("sqlserver", 20);
        private static readonly string rgName = SdkContext.RandomResourceName("rgsql", 20);
        private static readonly string dbName = "dbSample";
        private static readonly string administratorLogin = "sqladmin3423";
        private static readonly string administratorPassword = Utilities.CreatePassword();

        /**
         * Azure SQL sample for managing SQL Server DNS Aliases.
         *  - Create two SQL Servers "test" and "production", each with an empty database.
         *  - Create a new table and insert some expected values into each database.
         *  - Create a SQL Server DNS Alias to the "test" SQL database.
         *  - Query the "test" SQL database via the DNS alias and print the result.
         *  - Use the SQL Server DNS alias to acquire the "production" SQL database.
         *  - Query the "production" SQL database via the DNS alias and print the result.
         *  - Delete the SQL Servers
         */
        public static void RunSample(IAzure azure)
        {
            try
            {
                // ============================================================
                // Create a "test" SQL Server.
                Utilities.Log("Creating a SQL server for test related activities");

                var sqlServerForTest = azure.SqlServers.Define(sqlServerForTestName)
                    .WithRegion(Region.USSouthCentral)
                    .WithNewResourceGroup(rgName)
                    .WithAdministratorLogin(administratorLogin)
                    .WithAdministratorPassword(administratorPassword)
                    .DefineFirewallRule("allowAll")
                        .WithIPAddressRange("0.0.0.1", "255.255.255.255")
                        .Attach()
                    .DefineDatabase(dbName)
                        .WithBasicEdition()
                        .Attach()
                    .Create();

                Utilities.PrintSqlServer(sqlServerForTest);

                // ============================================================
                // Create a connection to the "test" SQL Server.
                Utilities.Log("Creating a connection to the \"test\" SQL Server");
                var connectionToSqlTestUrl = $"user id={administratorLogin};" +
                                       $"password={administratorPassword};" +
                                       $"server={sqlServerForTest.FullyQualifiedDomainName};" +
                                       $"database={dbName}; " +
                                       "Trusted_Connection=False;" +
                                       "Encrypt=True;" +
                                       "connection timeout=30";


                // Create a connection to the SQL Server.
                using (SqlConnection conTest = new SqlConnection(connectionToSqlTestUrl))
                {
                    conTest.Open();

                    // ============================================================
                    // Create a new table into the "test" SQL Server database and insert one value.
                    Utilities.Log("Creating a new table into the \"test\" SQL Server database and insert one value");

                    string sqlCreateTableCommand = "CREATE TABLE [Dns_Alias_Sample_Test] ([Name] [varchar](30) NOT NULL)";
                    SqlCommand createTable = new SqlCommand(sqlCreateTableCommand, conTest);
                    createTable.ExecuteNonQuery();
                    string sqlInsertCommand = "INSERT INTO Dns_Alias_Sample_Test VALUES ('Test')";
                    SqlCommand insertValue = new SqlCommand(sqlInsertCommand, conTest);
                    insertValue.ExecuteNonQuery();

                    // Close the connection to the "test" database
                    conTest.Close();
                }

                // ============================================================
                // Create a "production" SQL Server.
                Utilities.Log("Creating a SQL server for production related activities");

                var sqlServerForProd = azure.SqlServers.Define(sqlServerForProdName)
                    .WithRegion(Region.USNorthCentral)
                    .WithExistingResourceGroup(rgName)
                    .WithAdministratorLogin(administratorLogin)
                    .WithAdministratorPassword(administratorPassword)
                    .DefineFirewallRule("allowAll")
                        .WithIPAddressRange("0.0.0.1", "255.255.255.255")
                        .Attach()
                    .DefineDatabase(dbName)
                        .WithBasicEdition()
                        .Attach()
                    .Create();

                Utilities.PrintSqlServer(sqlServerForProd);

                // ============================================================
                // Create a connection to the "production" SQL Server.
                Utilities.Log("Creating a connection to the \"production\" SQL Server");

                var connectionToSqlProdUrl = $"user id={administratorLogin};" +
                                       $"password={administratorPassword};" +
                                       $"server={sqlServerForProd.FullyQualifiedDomainName};" +
                                       $"database={dbName}; " +
                                       "Trusted_Connection=False;" +
                                       "Encrypt=True;" +
                                       "connection timeout=30";
                // Create a connection to the SQL Server.
                using (SqlConnection conProd = new SqlConnection(connectionToSqlProdUrl))
                {
                    conProd.Open();

                    // ============================================================
                    // Create a new table into the "production" SQL Server database and insert one value.
                    Utilities.Log("Creating a new table into the \"production\" SQL Server database and insert one value");

                    string sqlCreateTableCommand = "CREATE TABLE [Dns_Alias_Sample_Prod] ([Name] [varchar](30) NOT NULL)";
                    SqlCommand createTable = new SqlCommand(sqlCreateTableCommand, conProd);
                    createTable.ExecuteNonQuery();
                    string sqlInsertCommand = "INSERT INTO Dns_Alias_Sample_Prod VALUES ('Production')";
                    SqlCommand insertValue = new SqlCommand(sqlInsertCommand, conProd);
                    insertValue.ExecuteNonQuery();

                    // Close the connection to the "prod" database
                    conProd.Close();
                }

                // ============================================================
                // Create a SQL Server DNS alias and use it to query the "test" database.
                Utilities.Log("Creating a SQL Server DNS alias and use it to query the \"test\" database");

                var dnsAlias = sqlServerForTest.DnsAliases
                    .Define(sqlServerDnsAlias)
                    .Create();
                SdkContext.DelayProvider.Delay(5 * 60 * 1000);

                var connectionUrl = $"user id={administratorLogin};" +
                                       $"password={administratorPassword};" +
                                       $"server={dnsAlias.AzureDnsRecord};" +
                                       $"database={dbName}; " +
                                       "Trusted_Connection=False;" +
                                       "Encrypt=True;" +
                                       "connection timeout=30";

                // Create a connection to the SQL DNS alias.
                using (SqlConnection conDnsAlias = new SqlConnection(connectionUrl))
                {
                    conDnsAlias.Open();

                    // ============================================================
                    // Create a SQL Server DNS alias and use it to query the "test" database.
                    Utilities.Log("Creating a SQL Server DNS alias and use it to query the \"test\" database");

                    string sqlCommand = "SELECT * FROM Dns_Alias_Sample_Test;";
                    SqlCommand selectCommand = new SqlCommand(sqlCommand, conDnsAlias);
                    var myReader = selectCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        Utilities.Log(myReader["Name"].ToString());
                    }
                    conDnsAlias.Close();
                }

                // ============================================================
                // Use the "production" SQL Server to acquire the SQL Server DNS Alias and use it to query the "production" database.
                Utilities.Log("Using the \"production\" SQL Server to acquire the SQL Server DNS Alias and use it to query the \"production\" database");

                sqlServerForProd.DnsAliases
                    .Acquire(sqlServerDnsAlias, sqlServerForTest.Id);

                // It takes some time for the DNS alias to reflect the new Server connection
                SdkContext.DelayProvider.Delay(10 * 60 * 1000);

                // Re-establish the connection.
                using (SqlConnection conDnsAlias = new SqlConnection(connectionUrl))
                {
                    conDnsAlias.Open();

                    // ============================================================
                    // Create a SQL Server DNS alias and use it to query the "production" database.
                    Utilities.Log("Creating a SQL Server DNS alias and use it to query the \"production\" database");

                    string sqlCommand = "SELECT * FROM Dns_Alias_Sample_Prod;";
                    SqlCommand selectCommand = new SqlCommand(sqlCommand, conDnsAlias);
                    var myReader = selectCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        Utilities.Log(myReader["Name"].ToString());
                    }
                    conDnsAlias.Close();
                }

                // Delete the SQL Servers.
                Utilities.Log("Deleting the Sql Servers");
                azure.SqlServers.DeleteById(sqlServerForTest.Id);
                azure.SqlServers.DeleteById(sqlServerForProd.Id);
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