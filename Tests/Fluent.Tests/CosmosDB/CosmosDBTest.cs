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
using Newtonsoft.Json.Linq;
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
                            .WithDefaultWriteReplication()
                            .WithReadReplication(Region.USCentral, true)
                            .WithIpRangeFilter("")
                            .WithMultipleWriteLocationsEnabled(true)
                            .Create();

                    Assert.Equal(databaseAccount.Name, dbName.ToLower());
                    Assert.Equal(DatabaseAccountKind.GlobalDocumentDB.Value, databaseAccount.Kind);
                    Assert.Equal(2, databaseAccount.WritableReplications.Count);
                    Assert.Equal(2, databaseAccount.ReadableReplications.Count);
                    Assert.True(databaseAccount.ReadableReplications.First(l => l.LocationName.ToLower().Replace(" ", "") == Region.USCentral.ToString()).IsZoneRedundant);
                    Assert.Equal(DefaultConsistencyLevel.Session, databaseAccount.DefaultConsistencyLevel);
                    Assert.True(databaseAccount.MultipleWriteLocationsEnabled);

                    databaseAccount = databaseAccount.Update()
                            .WithoutAllReplications()
                            .WithWriteReplication(Region.USWest)
                            .WithReadReplication(Region.USEast)
                            .Apply();

                    Assert.Equal(Region.USEast.ToString(), databaseAccount.WritableReplications.First(l => l.FailoverPriority == 1).LocationName.ToLower().Replace(" ", ""));

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


                    databaseAccount.Update().WithVirtualNetworkRule(vn.Id, "Subnet1").Apply();
                    databaseAccount.Update().WithVirtualNetworkRule(vn.Id, "Subnet1").Apply();
                    databaseAccount.Update().WithVirtualNetworkRule(vn.Id, "Subnet1").Apply();
                    // END of BUGFIX

                    Assert.True(databaseAccount.VirtualNetoworkFilterEnabled);
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

                    var privateLinkServiceConnection = new PrivateLinkServiceConnectionInner(name: plsConnectionName)
                    {
                        PrivateLinkServiceId = databaseAccount.Id,
                        GroupIds = new List<string> { "Sql" },
                        PrivateLinkServiceConnectionState = new PrivateLinkServiceConnectionState("Approved"),
                    };

                    var privateEndpoint = new PrivateEndpointInner(name: pedName)
                    {
                        Location = region.ToString(),
                        Subnet = network.Subnets[subnetName].Inner,
                        PrivateLinkServiceConnections = new List<PrivateLinkServiceConnectionInner> { privateLinkServiceConnection },
                    };

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
                        azure.ResourceGroups.BeginDeleteByName(rgName);
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
                        .WithAutomaticFailoverEnabled(true)
                        .DefineNewSqlDatabase(sqlDbName)
                            .WithThroughput(1000)
                            .DefineNewSqlContainer(sqlContainerName)
                                .WithThroughput(400)
                                .DefineIndexingPolicy()
                                    .WithIndexingMode(IndexingMode.Consistent)
                                    .WithIncludedPath("/*")
                                    .WithExcludedPath("/myPathToNotIndex/*")
                                    .WithNewCompositeIndexList()
                                        .WithCompositePath("/myOrderByPath1", CompositePathSortOrder.Ascending)
                                        .WithCompositePath("/myOrderByPath2", CompositePathSortOrder.Descending)
                                        .Attach()
                                    .Attach()
                                .WithPartitionKey(PartitionKind.Hash, null)
                                .WithPartitionKeyPath("/myPartitionKey")
                                .WithStoredProcedure("test", "function test(){}")
                                .WithUserDefinedFunction("test",  "function test(){}")
                                .WithTrigger("test", "function test(){}", TriggerType.Pre, TriggerOperation.All)
                                .Attach()
                            .Attach()
                        .Create();

                    Assert.True(databaseAccount.AutomaticFailoverEnabled);

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
                    Assert.Equal(1, container.IndexingPolicy.CompositeIndexes.Count);
                    Assert.Equal(2, container.IndexingPolicy.CompositeIndexes[0].Count);
                    Assert.True(container.PartitionKey.Paths.Contains("/myPartitionKey"));
                    Assert.Equal(PartitionKind.Hash, container.PartitionKey.Kind);
                    Assert.NotNull(container.GetStoredProcedure("test"));
                    Assert.NotNull(container.GetUserDefinedFunction("test"));
                    Assert.NotNull(container.GetTrigger("test"));

                    databaseAccount = databaseAccount.Update()
                        .WithAutomaticFailoverEnabled(false)
                        .UpdateSqlDatabase(sqlDbName)
                            .WithThroughput(800)
                            .UpdateSqlContainer(sqlContainerName)
                                .WithThroughput(600)
                                .UpdateIndexingPolicy()
                                    .WithoutExcludedPath("/myPathToNotIndex/*")
                                    .Parent()
                                .Parent()
                            .Parent()
                        .Apply();
                    Assert.False(databaseAccount.AutomaticFailoverEnabled);

                    sqldb = databaseAccount.GetSqlDatabase(sqlDbName);
                    Assert.Equal(800, sqldb.GetThroughputSettings().Throughput);

                    container = sqldb.GetSqlContainer(sqlContainerName);
                    Assert.Equal(600, container.GetThroughputSettings().Throughput);
                    Assert.Null(container.IndexingPolicy.ExcludedPaths.SingleOrDefault(element => element.Path == "/myPathToNotIndex/*"));
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(rgName);
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
                            .WithThroughput(400)
                            .DefineNewCollection(mongoCollectionName)
                                .WithThroughput(600)
                                .WithShardKey("test")
                                .Attach()
                            .Attach()
                        .Create();

                    var mongodbs = databaseAccount.ListMongoDBs().ToList();
                    Assert.Single(mongodbs);

                    var mongodb = mongodbs[0];
                    Assert.Equal(mongoDBName, mongodb.Name);
                    Assert.Equal(400, mongodb.GetThroughputSettings().Throughput);

                    var collections = mongodb.ListCollections().ToList();
                    Assert.Single(collections);

                    var collection = collections[0];
                    Assert.Equal(mongoCollectionName, collection.Name);
                    Assert.Equal(600, collection.GetThroughputSettings().Throughput);
                    Assert.Equal("Hash", collection.ShardKey.GetValueOrDefault("test", "empty"));

                    databaseAccount = databaseAccount.Update()
                        .UpdateMongoDB(mongoDBName)
                            .UpdateCollection(mongoCollectionName)
                                .WithThroughput(500)
                                .Parent()
                            .WithThroughput(800)
                            .Parent()
                        .Apply();

                    mongodb = databaseAccount.GetMongoDB(mongoDBName);
                    Assert.Equal(800, mongodb.GetThroughputSettings().Throughput);

                    collection = mongodb.GetCollection(mongoCollectionName);
                    Assert.Equal(500, collection.GetThroughputSettings().Throughput);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(rgName);
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
                            .WithThroughput(400)
                            .DefineNewCassandraTable(cassandraTableName)
                                .WithThroughput(600)
                                .WithColumn("id", "int")
                                .WithColumn("name", "text")
                                .WithColumn("test", "boolean")
                                .WithPartitionKey("id")
                                .Attach()
                            .Attach()
                        .Create();

                    var cassandras = databaseAccount.ListCassandraKeyspaces().ToList();
                    Assert.Single(cassandras);

                    var cassandra = cassandras[0];
                    Assert.Equal(cassandraName, cassandra.Name);
                    Assert.Equal(400, cassandra.GetThroughputSettings().Throughput);

                    var tables = cassandra.ListCassandraTables().ToList();
                    Assert.Single(tables);

                    var table = tables[0];
                    Assert.Equal(cassandraTableName, table.Name);
                    Assert.Equal(600, table.GetThroughputSettings().Throughput);
                    Assert.Equal(3, table.Schema.Columns.Count);
                    Assert.Equal(1, table.Schema.PartitionKeys.Count);
                    Assert.Equal("id", table.Schema.PartitionKeys[0].Name);

                    databaseAccount = databaseAccount.Update()
                        .UpdateCassandraKeyspace(cassandraName)
                            .UpdateCassandraTable(cassandraTableName)
                                .WithThroughput(500)
                                .WithoutColumn("test")
                                .Parent()
                            .WithThroughput(800)
                            .Parent()
                        .Apply();

                    cassandra = databaseAccount.GetCassandraKeyspace(cassandraName);
                    Assert.Equal(800, cassandra.GetThroughputSettings().Throughput);

                    table = cassandra.GetCassandraTable(cassandraTableName);
                    Assert.Equal(500, table.GetThroughputSettings().Throughput);
                    Assert.Equal(2, table.Schema.Columns.Count);
                    Assert.Null(table.Schema.Columns.SingleOrDefault(element => element.Name == "test"));
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(rgName);
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
                            .WithThroughput(1000)
                            .DefineNewGremlinGraph(gremlinGraphName)
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

                    var gremlins = databaseAccount.ListGremlinDatabases().ToList();
                    Assert.Single(gremlins);

                    var gremlin = gremlins[0];
                    Assert.Equal(gremlinName, gremlin.Name);
                    Assert.Equal(1000, gremlin.GetThroughputSettings().Throughput);

                    var graphs = gremlin.ListGremlinGraphs().ToList();
                    Assert.Single(graphs);

                    var graph = graphs[0];
                    Assert.Equal(gremlinGraphName, graph.Name);
                    Assert.Equal(400, graph.GetThroughputSettings().Throughput);
                    Assert.Equal(IndexingMode.Consistent, graph.IndexingPolicy.IndexingMode);
                    Assert.NotNull(graph.IndexingPolicy.IncludedPaths.Single(element => element.Path == "/*"));
                    Assert.NotNull(graph.IndexingPolicy.ExcludedPaths.Single(element => element.Path == "/myPathToNotIndex/*"));
                    Assert.True(graph.PartitionKey.Paths.Contains("/myPartitionKey"));
                    Assert.Equal(PartitionKind.Hash, graph.PartitionKey.Kind);

                    databaseAccount = databaseAccount.Update()
                        .UpdateGremlinDatabase(gremlinName)
                            .WithThroughput(800)
                            .UpdateGremlinGraph(gremlinGraphName)
                                .WithThroughput(600)
                                .Parent()
                            .Parent()
                        .Apply();

                    gremlin = databaseAccount.GetGremlinDatabase(gremlinName);
                    Assert.Equal(800, gremlin.GetThroughputSettings().Throughput);

                    graph = gremlin.GetGremlinGraph(gremlinGraphName);
                    Assert.Equal(600, graph.GetThroughputSettings().Throughput);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(rgName);
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
                            .WithThroughput(400)
                            .Attach()
                        .Create();

                    var tables = databaseAccount.ListTables().ToList();
                    Assert.Single(tables);

                    var table = tables[0];
                    Assert.Equal(tableName, table.Name);
                    Assert.Equal(400, table.GetThroughputSettings().Throughput);

                    databaseAccount = databaseAccount.Update()
                        .UpdateTable(tableName)
                            .WithOption("throughput", "800")
                            .Parent()
                        .Apply();

                    table = databaseAccount.GetTable(tableName);
                    Assert.Equal(800, table.GetThroughputSettings().Throughput);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }
    }
}