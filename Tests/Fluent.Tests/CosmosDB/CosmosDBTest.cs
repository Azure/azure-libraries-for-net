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
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }
    }
}