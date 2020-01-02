// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.CosmosDB.Fluent;
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fluent.Tests
{
    public class CosmosDB
    {
        [Fact]
        public void CosmosDBCRUD()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var dbName = TestUtilities.GenerateName("db");
                var saName = TestUtilities.GenerateName("dbsa");
                var rgName = TestUtilities.GenerateName("ddbRg");
                var manager = TestHelper.CreateCosmosDB();
                var resourceManager = TestHelper.CreateResourceManager();
                ICosmosDBAccount databaseAccount = null;

                try
                {
                    databaseAccount = manager.CosmosDBAccounts.Define(dbName)
                            .WithRegion(Region.USWest)
                            .WithNewResourceGroup(rgName)
                            .WithKind(DatabaseAccountKind.GlobalDocumentDB)
                            .WithSessionConsistency()
                            .WithWriteReplication(Region.USWest)
                            .WithReadReplication(Region.USCentral)
                            .WithIpRangeFilter("")
                            .WithMultipleWriteLocationsEnabled(true)
                            .Create();

                    Assert.Equal(databaseAccount.Name, dbName.ToLower());
                    Assert.Equal(DatabaseAccountKind.GlobalDocumentDB.Value, databaseAccount.Kind);
                    Assert.Equal(2, databaseAccount.WritableReplications.Count);
                    Assert.Equal(2, databaseAccount.ReadableReplications.Count);
                    Assert.Equal(DefaultConsistencyLevel.Session, databaseAccount.DefaultConsistencyLevel);
                    Assert.True(databaseAccount.MultipleWriteLocationsEnabled);

                    databaseAccount = databaseAccount.Update()
                            .WithReadReplication(Region.AsiaSouthEast)
                            .WithoutReadReplication(Region.USEast)
                            .WithoutReadReplication(Region.USCentral)
                            .Apply();

                    databaseAccount = databaseAccount.Update()
                            .WithEventualConsistency()
                            .WithTag("tag2", "value2")
                            .WithTag("tag3", "value3")
                            .WithoutTag("tag1")
                            .Apply();
                    Assert.Equal(DefaultConsistencyLevel.Eventual, databaseAccount.DefaultConsistencyLevel);
                    Assert.True(databaseAccount.Tags.ContainsKey("tag2"));
                    Assert.True(!databaseAccount.Tags.ContainsKey("tag1"));
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }


        [Fact]
        public void CosmosDBBugfix()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var dbName = TestUtilities.GenerateName("db");
                var saName = TestUtilities.GenerateName("dbsa");
                var rgName = TestUtilities.GenerateName("ddbRg");
                var manager = TestHelper.CreateCosmosDB();
                var resourceManager = TestHelper.CreateResourceManager();
                ICosmosDBAccount databaseAccount = null;
                var azure = TestHelper.CreateRollupClient();

                try
                {
                    databaseAccount = manager.CosmosDBAccounts.Define(dbName)
                            .WithRegion(Region.USWest)
                            .WithNewResourceGroup(rgName)
                            .WithKind(DatabaseAccountKind.GlobalDocumentDB)
                            .WithSessionConsistency()
                            .WithWriteReplication(Region.USWest)
                            .WithReadReplication(Region.USCentral)
                            .WithIpRangeFilter("")
                            .Create();

                    // BUGFIX
                    var vn = azure.Networks.Define(dbName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithAddressSpace("192.168.0.0/16")
                        .DefineSubnet("subnet1")
                            .WithAddressPrefix("192.168.1.0/24")
                            .WithAccessFromService(ServiceEndpointType.MicrosoftAzureCosmosDB)
                            .Attach()
                        .DefineSubnet("subnet2")
                            .WithAddressPrefix("192.168.2.0/24")
                            .WithAccessFromService(ServiceEndpointType.MicrosoftAzureCosmosDB)
                            .Attach()
                        .Create();


                    databaseAccount.Update().WithVirtualNetwork(vn.Id, "Subnet1").Apply();
                    databaseAccount.Update().WithVirtualNetwork(vn.Id, "Subnet1").Apply();
                    databaseAccount.Update().WithVirtualNetwork(vn.Id, "Subnet1").Apply();
                    // END of BUGFIX
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateCassandraCosmosDB()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var dbName = TestUtilities.GenerateName("db");
                var rgName = TestUtilities.GenerateName("dbRg");
                var manager = TestHelper.CreateCosmosDB();
                var resourceManager = TestHelper.CreateResourceManager();
                ICosmosDBAccount databaseAccount = null;
                var azure = TestHelper.CreateRollupClient();

                try
                {
                    databaseAccount = manager.CosmosDBAccounts.Define(dbName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithDataModelCassandra()
                        .WithStrongConsistency()
                        .WithCassandraConnector(ConnectorOffer.Small)
                        .Create();

                    Assert.True(databaseAccount.CassandraConnectorEnabled);
                    Assert.Equal(ConnectorOffer.Small, databaseAccount.CassandraConnectorOffer);

                    databaseAccount = databaseAccount.Update()
                        .WithoutCassandraConnector()
                        .Apply();

                    Assert.False(databaseAccount.CassandraConnectorEnabled);
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateSqlPrivateEndpoint()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var dbName = SdkContext.RandomResourceName("cosmosdb", 22);
                var rgName = SdkContext.RandomResourceName("cosmosdbRg", 22);
                var networkName = SdkContext.RandomResourceName("network", 22);
                var subnetName = SdkContext.RandomResourceName("subnet", 22);
                var plsConnectionName = SdkContext.RandomResourceName("plsconnect", 22);
                var pedName = SdkContext.RandomResourceName("ped", 22);
                var region = Region.USWest;

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    azure.ResourceGroups.Define(rgName)
                        .WithRegion(region)
                        .Create();

                    var network = azure.Networks.Define(networkName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithAddressSpace("10.0.0.0/16")
                        .DefineSubnet(subnetName)
                            .WithAddressPrefix("10.0.0.0/24")
                            .WithAccessFromService(ServiceEndpointType.MicrosoftAzureCosmosDB)
                            .Attach()
                        .Create();

                    network.Subnets[subnetName].Inner.PrivateEndpointNetworkPolicies = "Disabled";
                    network.Subnets[subnetName].Inner.PrivateLinkServiceNetworkPolicies = "Disabled";

                    network.Update()
                        .UpdateSubnet(subnetName)
                        .Parent()
                        .Apply();

                    var databaseAccount = azure.CosmosDBAccounts.Define(dbName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithDataModelSql()
                        .WithStrongConsistency()
                        .WithDisableKeyBaseMetadataWriteAccess(true)
                        .Create();

                    Assert.True(databaseAccount.KeyBasedMetadataWriteAccessDisabled);

                    var privateLinkServiceConnection = new PrivateLinkServiceConnectionInner(null,
                        databaseAccount.Id,
                        new List<string> { "Sql" },
                        null,
                        new PrivateLinkServiceConnectionState("Approved"),
                        plsConnectionName);

                    var privateEndpoint = new PrivateEndpointInner(region.ToString(),
                        null,
                        pedName,
                        null,
                        null,
                        network.Subnets[subnetName].Inner,
                        null,
                        null,
                        new List<PrivateLinkServiceConnectionInner> { privateLinkServiceConnection },
                        null);

                    azure.Networks.Manager.Inner.PrivateEndpoints
                        .CreateOrUpdateWithHttpMessagesAsync(rgName, pedName, privateEndpoint).Wait();

                    Assert.Equal("Approved", databaseAccount.GetPrivateEndpointConnection(pedName).PrivateLinkServiceConnectionState.Status);

                    databaseAccount.Update()
                        .UpdatePrivateEndpointConnection(pedName)
                        .WithStatus("Rejected")
                        .WithDescription("Rej")
                        .Parent()
                        .Apply();

                    var connections = databaseAccount.ListPrivateEndpointConnection();
                    Assert.True(connections.ContainsKey(pedName));
                    Assert.Equal("Rejected", connections[pedName].PrivateLinkServiceConnectionState.Status);

                    Assert.Equal(1, databaseAccount.ListPrivateLinkResources().Count);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCRUDSqlContainer()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var dbName = SdkContext.RandomResourceName("cosmosdb", 22);
                var rgName = SdkContext.RandomResourceName("cosmosdbRg", 22);
                var sqlDbName = SdkContext.RandomResourceName("sqldb", 22);
                var sqlContainerName = SdkContext.RandomResourceName("sqlcontainer", 22);
                var region = Region.USWest;

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    azure.ResourceGroups.Define(rgName).WithRegion(region).Create();

                    var databaseAccount = azure.CosmosDBAccounts.Define(dbName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithDataModelSql()
                        .WithStrongConsistency()
                        .DefineNewSqlDatabase(sqlDbName)
                            .WithThroughput(1000)
                            .DefineNewSqlContainer(sqlContainerName)
                                .WithThroughput(400)
                                .DefineIndexingPolicy()
                                    .WithIndexingMode(IndexingMode.Consistent)
                                    .WithIncludedPath(new IncludedPath(path: "/*"))
                                    .WithExcludedPath(new ExcludedPath(path: "/myPathToNotIndex/*"))
                                    .Attach()
                                .WithPartitionKey(paths: new List<string>() { "/myPartitionKey" }, kind: PartitionKind.Hash, version: null)
                                .Attach()
                            .Attach()
                        .Create();

                    var sqldbs = databaseAccount.ListSqlDatabases().ToList();
                    Assert.Single(sqldbs);

                    var sqldb = sqldbs[0];
                    Assert.Equal(sqlDbName, sqldb.Name);
                    Assert.Equal(1000, sqldb.GetThroughputSettings().Throughput);

                    var containers = sqldb.ListSqlContainers().ToList();
                    Assert.Single(containers);

                    var container = containers[0];
                    Assert.Equal(sqlContainerName, container.Name);
                    Assert.Equal(400, container.GetThroughputSettings().Throughput);
                    Assert.Equal(IndexingMode.Consistent, container.IndexingPolicy.IndexingMode);
                    Assert.NotNull(container.IndexingPolicy.IncludedPaths.Single(element => element.Path == "/*"));
                    Assert.NotNull(container.IndexingPolicy.ExcludedPaths.Single(element => element.Path == "/myPathToNotIndex/*"));
                    Assert.True(container.PartitionKey.Paths.Contains("/myPartitionKey"));
                    Assert.Equal(PartitionKind.Hash, container.PartitionKey.Kind);

                    databaseAccount = databaseAccount.Update()
                        .UpdateSqlDatabase(sqlDbName)
                            .WithOption("throughput", "800")
                            .UpdateSqlContainer(sqlContainerName)
                                .WithOption("throughput", "600")
                                .Parent()
                            .Parent()
                        .Apply();

                    sqldb = databaseAccount.GetSqlDatabase(sqlDbName);
                    Assert.Equal(800, sqldb.GetThroughputSettings().Throughput);

                    container = sqldb.GetSqlContainer(sqlContainerName);
                    Assert.Equal(600, container.GetThroughputSettings().Throughput);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCRUDMongoDBCollection()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var dbName = SdkContext.RandomResourceName("cosmosdb", 22);
                var rgName = SdkContext.RandomResourceName("cosmosdbRg", 22);
                var mongoDBName = SdkContext.RandomResourceName("mongodb", 22);
                var mongoCollectionName = SdkContext.RandomResourceName("mongocollection", 22);
                var region = Region.USWest;

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    azure.ResourceGroups.Define(rgName).WithRegion(region).Create();
                    var databaseAccount = azure.CosmosDBAccounts.Define(dbName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithDataModelMongoDB()
                        .WithStrongConsistency()
                        .DefineNewMongoDB(mongoDBName)
                            .WithOption("throughput", "400")
                            .DefineNewCollection(mongoCollectionName)
                                .WithShardKey("test")
                                .Attach()
                            .Attach()
                        .Create();
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCRUDCassandraTable()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var dbName = SdkContext.RandomResourceName("cosmosdb", 22);
                var rgName = SdkContext.RandomResourceName("cosmosdbRg", 22);
                var cassandraName = SdkContext.RandomResourceName("cassandra", 22);
                var cassandraTableName = SdkContext.RandomResourceName("cassandratable", 22);
                var region = Region.USWest;

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    azure.ResourceGroups.Define(rgName).WithRegion(region).Create();
                    var databaseAccount = azure.CosmosDBAccounts.Define(dbName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithDataModelCassandra()
                        .WithStrongConsistency()
                        .DefineNewCassandraKeyspace(cassandraName)
                            .WithOption("throughput", "400")
                            .DefineNewCassandraTable(cassandraTableName)
                                .WithColumn("test", "boolean")
                                .Attach()
                            .Attach()
                        .Create();
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCRUDGremlinGraph()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var dbName = SdkContext.RandomResourceName("cosmosdb", 22);
                var rgName = SdkContext.RandomResourceName("cosmosdbRg", 22);
                var gremlinName = SdkContext.RandomResourceName("gremlin", 22);
                var gremlinGraphName = SdkContext.RandomResourceName("gremlingraph", 22);
                var region = Region.USWest;

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    azure.ResourceGroups.Define(rgName).WithRegion(region).Create();
                    var databaseAccount = azure.CosmosDBAccounts.Define(dbName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithDataModelGremlin()
                        .WithStrongConsistency()
                        .DefineNewGremlinDatabase(gremlinName)
                            .WithOption("throughput", "400")
                            .DefineNewGremlinGraph(gremlinGraphName)
                                .DefineIndexingPolicy()
                                    .WithIncludedPath(new IncludedPath(path: "/*"))
                                    .Attach()
                                .Attach()
                            .Attach()
                        .Create();
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCRUDTable()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var dbName = SdkContext.RandomResourceName("cosmosdb", 22);
                var rgName = SdkContext.RandomResourceName("cosmosdbRg", 22);
                var tableName = SdkContext.RandomResourceName("table", 22);
                var region = Region.USWest;

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    azure.ResourceGroups.Define(rgName).WithRegion(region).Create();
                    var databaseAccount = azure.CosmosDBAccounts.Define(dbName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithDataModelAzureTable()
                        .WithStrongConsistency()
                        .DefineNewTable(tableName)
                            .WithOption("throughput", "400")
                            .Attach()
                        .Create();
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }
    }
}