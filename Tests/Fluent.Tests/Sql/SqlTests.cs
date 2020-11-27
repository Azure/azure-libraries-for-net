// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.Sql.Fluent.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace Fluent.Tests
{
    public class Sql : IDisposable
    {
        private static string GroupName = null;
        private static string SqlServerName = null;
        private static readonly string SqlDatabaseName = "myTestDatabase2";
        private static readonly string Collation = "SQL_Latin1_General_CP1_CI_AS";
        private static readonly string SqlElasticPoolName = "testElasticPool";
        private static readonly string SqlFirewallRuleName = "firewallrule1";
        private static readonly string StartIPAddress = "10.102.1.10";
        private static readonly string EndIPAddress = "10.102.1.12";

        public Sql(ITestOutputHelper output)
        {
            //TestHelper.TestLogger = output;
            //ServiceClientTracing.IsEnabled = true;
            //ServiceClientTracing.AddTracingInterceptor(new XunitTracingInterceptor(output));
        }


        private static void GenerateNewRGAndSqlServerNameForTest([CallerMemberName] string methodName = "testframework_failed")
        {
            GroupName = TestUtilities.GenerateName("netsqlserver", methodName);
            SqlServerName = GroupName;
        }

        public void Dispose()
        {
            DeleteResourceGroup(GroupName);
        }

        private void DeleteResourceGroup(string resourceGroup)
        {
            var resourceManager = TestHelper.CreateResourceManager();
            try
            {
                resourceManager.ResourceGroups.DeleteByName(resourceGroup);
            }
            catch
            {
            }
        }

        [Fact]
        public void CanCRUDSqlSyncMember()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                GenerateNewRGAndSqlServerNameForTest();
                var rollUpClient = TestHelper.CreateRollupClient();
                string sqlServerName = SdkContext.RandomResourceName("sqlpri", 22);
                string dbName = SdkContext.RandomResourceName("dbSample", 15);
                string dbSyncName = SdkContext.RandomResourceName("dbSync", 15);
                string dbMemberName = SdkContext.RandomResourceName("dbMember", 15);
                string syncGroupName = SdkContext.RandomResourceName("groupName", 15);
                string syncMemberName = SdkContext.RandomResourceName("memberName", 15);
                string administratorLogin = "sqladmin";
                string administratorPassword = TestUtilities.GenerateName("Pa5$");

                try
                {
                    // Create
                    var sqlPrimaryServer = rollUpClient.SqlServers.Define(sqlServerName)
                        .WithRegion(Region.AsiaSouthEast)
                        .WithNewResourceGroup(GroupName)
                        .WithAdministratorLogin(administratorLogin)
                        .WithAdministratorPassword(administratorPassword)
                        .DefineDatabase(dbName)
                            .FromSample(SampleName.AdventureWorksLT)
                            .WithStandardEdition(SqlDatabaseStandardServiceObjective.S0)
                            .Attach()
                        .DefineDatabase(dbSyncName)
                            .WithStandardEdition(SqlDatabaseStandardServiceObjective.S0)
                            .Attach()
                        .DefineDatabase(dbMemberName)
                            .WithStandardEdition(SqlDatabaseStandardServiceObjective.S0)
                            .Attach()
                        .Create();

                    var dbSource = sqlPrimaryServer.Databases.Get(dbName);
                    var dbSync = sqlPrimaryServer.Databases.Get(dbSyncName);
                    var dbMember = sqlPrimaryServer.Databases.Get(dbMemberName);

                    var sqlSyncGroup = dbSync.SyncGroups.Define(syncGroupName)
                        .WithSyncDatabaseId(dbSource.Id)
                        .WithDatabaseUserName(administratorLogin)
                        .WithDatabasePassword(administratorPassword)
                        .WithConflictResolutionPolicyHubWins()
                        .WithInterval(-1)
                        .Create();
                    Assert.NotNull(sqlSyncGroup);

                    var sqlSyncMember = sqlSyncGroup.SyncMembers.Define(syncMemberName)
                        .WithMemberSqlDatabase(dbMember)
                        .WithMemberUserName(administratorLogin)
                        .WithMemberPassword(administratorPassword)
                        .WithMemberDatabaseType(SyncMemberDbType.AzureSqlDatabase)
                        .WithDatabaseType(SyncDirection.OneWayHubToMember)
                        .Create();
                    Assert.NotNull(sqlSyncMember);

                    sqlSyncMember.Update()
                        .WithDatabaseType(SyncDirection.Bidirectional)
                        .WithMemberUserName(administratorLogin)
                        .WithMemberPassword(administratorPassword)
                        .WithMemberDatabaseType(SyncMemberDbType.AzureSqlDatabase)
                        .Apply();

                    Assert.True(sqlSyncGroup.SyncMembers.List().Count() > 0);

                    sqlSyncMember = rollUpClient.SqlServers.SyncMembers.GetBySqlServer(GroupName, sqlServerName, dbSyncName, syncGroupName, syncMemberName);
                    Assert.NotNull(sqlSyncMember);

                    sqlSyncMember.Delete();

                    sqlSyncGroup.Delete();
                }
                finally
                {
                    try
                    {
                       rollUpClient.ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCRUDSqlSyncGroup()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                GenerateNewRGAndSqlServerNameForTest();
                var rollUpClient = TestHelper.CreateRollupClient();
                string sqlServerName = SdkContext.RandomResourceName("sqlpri", 22);
                string dbName = SdkContext.RandomResourceName("dbSample", 15);
                string dbSyncName = SdkContext.RandomResourceName("dbSync", 15);
                string syncGroupName = SdkContext.RandomResourceName("groupName", 15);
                string administratorLogin = "sqladmin";
                string administratorPassword = TestUtilities.GenerateName("Pa5$");
                Region region = Region.USEast2;

                try
                {
                    // Create
                    var sqlPrimaryServer = rollUpClient.SqlServers.Define(sqlServerName)
                    .WithRegion(region)
                    .WithNewResourceGroup(GroupName)
                    .WithAdministratorLogin(administratorLogin)
                    .WithAdministratorPassword(administratorPassword)
                    .DefineDatabase(dbName)
                        .FromSample(SampleName.AdventureWorksLT)
                        .WithStandardEdition(SqlDatabaseStandardServiceObjective.S0)
                        .Attach()
                    .DefineDatabase(dbSyncName)
                        .WithStandardEdition(SqlDatabaseStandardServiceObjective.S0)
                        .Attach()
                    .Create();

                    var dbSource = sqlPrimaryServer.Databases.Get(dbName);
                    var dbSync = sqlPrimaryServer.Databases.Get(dbSyncName);

                    var sqlSyncGroup = dbSync.SyncGroups.Define(syncGroupName)
                        .WithSyncDatabaseId(dbSource.Id)
                        .WithDatabaseUserName(administratorLogin)
                        .WithDatabasePassword(administratorPassword)
                        .WithConflictResolutionPolicyHubWins()
                        .WithInterval(-1)
                        .Create();

                    Assert.NotNull(sqlSyncGroup);

                    sqlSyncGroup.Update()
                        .WithInterval(600)
                        .WithConflictResolutionPolicyMemberWins()
                        .Apply();

                    Assert.True(rollUpClient.SqlServers.SyncGroups.ListSyncDatabaseIds(region).Count() > 0);
                    Assert.True(dbSync.SyncGroups.List().Count() > 0);

                    sqlSyncGroup = rollUpClient.SqlServers.SyncGroups.GetBySqlServer(GroupName, sqlServerName, dbSyncName, syncGroupName);
                    Assert.NotNull(sqlSyncGroup);

                    sqlSyncGroup.Delete();
                }
                finally
                {
                    try
                    {
                        rollUpClient.ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanOperateSqlFromRollUpClient()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                GenerateNewRGAndSqlServerNameForTest();
                var rollUpClient = TestHelper.CreateRollupClient();
                try
                {
                    var sqlServer = rollUpClient.SqlServers.Define(SqlServerName)
                            .WithRegion(Region.USEast2)
                            .WithNewResourceGroup(GroupName)
                            .WithAdministratorLogin("userName")
                            .WithAdministratorPassword("loepop77ejk~13@@")
                            .WithoutAccessFromAzureServices()
                            .Create();
                    Assert.NotNull(sqlServer.Databases.List());
                    rollUpClient.SqlServers.DeleteById(sqlServer.Id);

                    DeleteResourceGroup(GroupName);
                }
                finally
                {
                    try
                    {
                        rollUpClient.ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void canCRUDSqlFailoverGroup()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                GenerateNewRGAndSqlServerNameForTest();
                var rollUpClient = TestHelper.CreateRollupClient();
                try
                {
                    string rgName = GroupName;
                    string sqlPrimaryServerName = SdkContext.RandomResourceName("sqlpri", 22);
                    string sqlSecondaryServerName = SdkContext.RandomResourceName("sqlsec", 22);
                    string sqlOtherServerName = SdkContext.RandomResourceName("sql000", 22);
                    string failoverGroupName = SdkContext.RandomResourceName("fg", 22);
                    string failoverGroupName2 = SdkContext.RandomResourceName("fg2", 22);
                    string dbName = "dbSample";
                    string administratorLogin = "sqladmin";
                    string administratorPassword = TestUtilities.GenerateName("Pa5$");

                    // Create
                    var sqlPrimaryServer = rollUpClient.SqlServers.Define(sqlPrimaryServerName)
                        .WithRegion(Region.AsiaSouthEast)
                        .WithNewResourceGroup(rgName)
                        .WithAdministratorLogin(administratorLogin)
                        .WithAdministratorPassword(administratorPassword)
                        .DefineDatabase(dbName)
                            .FromSample(SampleName.AdventureWorksLT)
                            .WithStandardEdition(SqlDatabaseStandardServiceObjective.S0)
                            .Attach()
                        .Create();

                    var sqlSecondaryServer = rollUpClient.SqlServers.Define(sqlSecondaryServerName)
                        .WithRegion(Region.USEast2)
                        .WithExistingResourceGroup(rgName)
                        .WithAdministratorLogin(administratorLogin)
                        .WithAdministratorPassword(administratorPassword)
                        .Create();

                    var sqlOtherServer = rollUpClient.SqlServers.Define(sqlOtherServerName)
                        .WithRegion(Region.USWest2)
                        .WithExistingResourceGroup(rgName)
                        .WithAdministratorLogin(administratorLogin)
                        .WithAdministratorPassword(administratorPassword)
                        .Create();

                    var failoverGroup = sqlPrimaryServer.FailoverGroups.Define(failoverGroupName)
                        .WithManualReadWriteEndpointPolicy()
                        .WithPartnerServerId(sqlSecondaryServer.Id)
                        .WithReadOnlyEndpointPolicyDisabled()
                        .Create();

                    Assert.NotNull(failoverGroup);
                    Assert.Equal(failoverGroupName, failoverGroup.Name);
                    Assert.Equal(rgName, failoverGroup.ResourceGroupName);
                    Assert.Equal(sqlPrimaryServerName, failoverGroup.SqlServerName);
                    Assert.Equal(FailoverGroupReplicationRole.Primary, failoverGroup.ReplicationRole);
                    Assert.Equal(1, failoverGroup.PartnerServers.Count);
                    Assert.Equal(sqlSecondaryServer.Id, failoverGroup.PartnerServers[0].Id);
                    Assert.Equal(FailoverGroupReplicationRole.Secondary, failoverGroup.PartnerServers[0].ReplicationRole);
                    Assert.Equal(0, failoverGroup.Databases.Count);
                    Assert.Equal(0, failoverGroup.ReadWriteEndpointDataLossGracePeriodMinutes);
                    Assert.Equal(ReadWriteEndpointFailoverPolicy.Manual, failoverGroup.ReadWriteEndpointPolicy);
                    Assert.Equal(ReadOnlyEndpointFailoverPolicy.Disabled, failoverGroup.ReadOnlyEndpointPolicy);

                    var failoverGroupOnPartner = sqlSecondaryServer.FailoverGroups.Get(failoverGroup.Name);
                    Assert.Equal(failoverGroupName, failoverGroupOnPartner.Name);
                    Assert.Equal(rgName, failoverGroupOnPartner.ResourceGroupName);
                    Assert.Equal(sqlSecondaryServerName, failoverGroupOnPartner.SqlServerName);
                    Assert.Equal(FailoverGroupReplicationRole.Secondary, failoverGroupOnPartner.ReplicationRole);
                    Assert.Equal(1, failoverGroupOnPartner.PartnerServers.Count);
                    Assert.Equal(sqlPrimaryServer.Id, failoverGroupOnPartner.PartnerServers[0].Id);
                    Assert.Equal(FailoverGroupReplicationRole.Primary, failoverGroupOnPartner.PartnerServers[0].ReplicationRole);
                    Assert.Equal(0, failoverGroupOnPartner.Databases.Count);
                    Assert.Equal(0, failoverGroupOnPartner.ReadWriteEndpointDataLossGracePeriodMinutes);
                    Assert.Equal(ReadWriteEndpointFailoverPolicy.Manual, failoverGroupOnPartner.ReadWriteEndpointPolicy);
                    Assert.Equal(ReadOnlyEndpointFailoverPolicy.Disabled, failoverGroupOnPartner.ReadOnlyEndpointPolicy);

                    var failoverGroup2 = sqlPrimaryServer.FailoverGroups.Define(failoverGroupName2)
                        .WithAutomaticReadWriteEndpointPolicyAndDataLossGracePeriod(120)
                        .WithPartnerServerId(sqlOtherServer.Id)
                        .WithReadOnlyEndpointPolicyEnabled()
                        .Create();
                    Assert.NotNull(failoverGroup2);
                    Assert.Equal(failoverGroupName2, failoverGroup2.Name);
                    Assert.Equal(rgName, failoverGroup2.ResourceGroupName);
                    Assert.Equal(sqlPrimaryServerName, failoverGroup2.SqlServerName);
                    Assert.Equal(FailoverGroupReplicationRole.Primary, failoverGroup2.ReplicationRole);
                    Assert.Equal(1, failoverGroup2.PartnerServers.Count);
                    Assert.Equal(sqlOtherServer.Id, failoverGroup2.PartnerServers[0].Id);
                    Assert.Equal(FailoverGroupReplicationRole.Secondary, failoverGroup2.PartnerServers[0].ReplicationRole);
                    Assert.Equal(0, failoverGroup2.Databases.Count);
                    Assert.Equal(120, failoverGroup2.ReadWriteEndpointDataLossGracePeriodMinutes);
                    Assert.Equal(ReadWriteEndpointFailoverPolicy.Automatic, failoverGroup2.ReadWriteEndpointPolicy);
                    Assert.Equal(ReadOnlyEndpointFailoverPolicy.Enabled, failoverGroup2.ReadOnlyEndpointPolicy);

                    failoverGroup.Update()
                        .WithAutomaticReadWriteEndpointPolicyAndDataLossGracePeriod(120)
                        .WithReadOnlyEndpointPolicyEnabled()
                        .WithTag("tag1", "value1")
                        .Apply();
                    Assert.Equal(120, failoverGroup.ReadWriteEndpointDataLossGracePeriodMinutes);
                    Assert.Equal(ReadWriteEndpointFailoverPolicy.Automatic, failoverGroup.ReadWriteEndpointPolicy);
                    Assert.Equal(ReadOnlyEndpointFailoverPolicy.Enabled, failoverGroup.ReadOnlyEndpointPolicy);

                    var db = sqlPrimaryServer.Databases.Get(dbName);
                    failoverGroup.Update()
                        .WithManualReadWriteEndpointPolicy()
                        .WithReadOnlyEndpointPolicyDisabled()
                        .WithNewDatabaseId(db.Id)
                        .Apply();
                    Assert.Equal(1, failoverGroup.Databases.Count);
                    Assert.Equal(db.Id, failoverGroup.Databases[0]);
                    Assert.Equal(0, failoverGroup.ReadWriteEndpointDataLossGracePeriodMinutes);
                    Assert.Equal(ReadWriteEndpointFailoverPolicy.Manual, failoverGroup.ReadWriteEndpointPolicy);
                    Assert.Equal(ReadOnlyEndpointFailoverPolicy.Disabled, failoverGroup.ReadOnlyEndpointPolicy);

                    var failoverGroupsList = sqlPrimaryServer.FailoverGroups.List();
                    Assert.Equal(2, failoverGroupsList.Count);

                    failoverGroupsList = sqlSecondaryServer.FailoverGroups.List();
                    Assert.Equal(1, failoverGroupsList.Count);

                    sqlPrimaryServer.FailoverGroups.Delete(failoverGroup2.Name);

                    DeleteResourceGroup(GroupName);
                }
                finally
                {
                    try
                    {
                        rollUpClient.ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void canChangeSqlServerAndDatabaseAutomaticTuning()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                GenerateNewRGAndSqlServerNameForTest();
                var rollUpClient = TestHelper.CreateRollupClient();
                string rgName = GroupName;
                string sqlServerName = SqlServerName;
                string sqlServerAdminName = "sqladmin";
                string sqlServerAdminPassword = TestUtilities.GenerateName("Pa5$");
                string databaseName = "db-from-sample";

                try
                {
                    // Create
                    var sqlServer = rollUpClient
                        .SqlServers
                        .Define(sqlServerName)
                        .WithRegion(Region.AsiaSouthEast)
                        .WithNewResourceGroup(rgName)
                        .WithAdministratorLogin(sqlServerAdminName)
                        .WithAdministratorPassword(sqlServerAdminPassword)
                        .DefineDatabase(databaseName)
                            .FromSample(SampleName.AdventureWorksLT)
                            .WithBasicEdition()
                            .Attach()
                        .Create();
                    var dbFromSample = sqlServer.Databases.Get(databaseName);
                    Assert.NotNull(dbFromSample);
                    Assert.Equal(DatabaseEdition.Basic, dbFromSample.Edition);

                    var serverAutomaticTuning = sqlServer.GetServerAutomaticTuning();
                    Assert.Equal(AutomaticTuningServerMode.Unspecified, serverAutomaticTuning.DesiredState);
                    Assert.Equal(AutomaticTuningServerMode.Unspecified, serverAutomaticTuning.ActualState);
                    Assert.Equal(4, serverAutomaticTuning.TuningOptions.Count);

                    serverAutomaticTuning.Update()
                        .WithAutomaticTuningMode(AutomaticTuningServerMode.Auto)
                        .WithAutomaticTuningOption("createIndex", AutomaticTuningOptionModeDesired.Off)
                        .WithAutomaticTuningOption("dropIndex", AutomaticTuningOptionModeDesired.On)
                        .WithAutomaticTuningOption("forceLastGoodPlan", AutomaticTuningOptionModeDesired.Default)
                        .Apply();
                    Assert.Equal(AutomaticTuningServerMode.Auto, serverAutomaticTuning.DesiredState);
                    Assert.Equal(AutomaticTuningServerMode.Auto, serverAutomaticTuning.ActualState);
                    Assert.Equal(AutomaticTuningOptionModeDesired.Off, serverAutomaticTuning.TuningOptions["createIndex"].DesiredState);
                    Assert.Equal(AutomaticTuningOptionModeActual.Off, serverAutomaticTuning.TuningOptions["createIndex"].ActualState);
                    Assert.Equal(AutomaticTuningOptionModeDesired.On, serverAutomaticTuning.TuningOptions["dropIndex"].DesiredState);
                    Assert.Equal(AutomaticTuningOptionModeActual.On, serverAutomaticTuning.TuningOptions["dropIndex"].ActualState);
                    Assert.Equal(AutomaticTuningOptionModeDesired.Default, serverAutomaticTuning.TuningOptions["forceLastGoodPlan"].DesiredState);

                    var databaseAutomaticTuning = dbFromSample.GetDatabaseAutomaticTuning();
                    Assert.Equal(4, databaseAutomaticTuning.TuningOptions.Count);

                    // The following results in "InternalServerError" at the moment
                    databaseAutomaticTuning.Update()
                        .WithAutomaticTuningMode(AutomaticTuningMode.Auto)
                        .WithAutomaticTuningOption("createIndex", AutomaticTuningOptionModeDesired.Off)
                        .WithAutomaticTuningOption("dropIndex", AutomaticTuningOptionModeDesired.On)
                        .WithAutomaticTuningOption("forceLastGoodPlan", AutomaticTuningOptionModeDesired.Default)
                        .Apply();
                    Assert.Equal(AutomaticTuningMode.Auto, databaseAutomaticTuning.DesiredState);
                    Assert.Equal(AutomaticTuningMode.Auto, databaseAutomaticTuning.ActualState);
                    Assert.Equal(AutomaticTuningOptionModeDesired.Off, databaseAutomaticTuning.TuningOptions["createIndex"].DesiredState);
                    Assert.Equal(AutomaticTuningOptionModeActual.Off, databaseAutomaticTuning.TuningOptions["createIndex"].ActualState);
                    Assert.Equal(AutomaticTuningOptionModeDesired.On, databaseAutomaticTuning.TuningOptions["dropIndex"].DesiredState);
                    Assert.Equal(AutomaticTuningOptionModeActual.On, databaseAutomaticTuning.TuningOptions["dropIndex"].ActualState);
                    Assert.Equal(AutomaticTuningOptionModeDesired.Default, databaseAutomaticTuning.TuningOptions["forceLastGoodPlan"].DesiredState);

                    // cleanup
                    dbFromSample.Delete();
                    rollUpClient.SqlServers.DeleteByResourceGroup(rgName, sqlServerName);

                    DeleteResourceGroup(GroupName);
                }
                finally
                {
                    try
                    {
                        rollUpClient.ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void canCreateAndAquireServerDnsAlias()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                GenerateNewRGAndSqlServerNameForTest();
                var rollUpClient = TestHelper.CreateRollupClient();
                string rgName = GroupName;
                string sqlServerName1 = SqlServerName + "1";
                string sqlServerName2 = SqlServerName + "2";
                string sqlServerAdminName = "sqladmin";
                string sqlServerAdminPassword = TestUtilities.GenerateName("Pa5$");

                try
                {
                    // Create
                    var sqlServer1 = rollUpClient.SqlServers.Define(sqlServerName1)
                        .WithRegion(Region.AsiaSouthEast)
                        .WithNewResourceGroup(rgName)
                        .WithAdministratorLogin(sqlServerAdminName)
                        .WithAdministratorPassword(sqlServerAdminPassword)
                        .Create();
                    Assert.NotNull(sqlServer1);

                    var dnsAlias = sqlServer1.DnsAliases
                        .Define(SqlServerName)
                        .Create();

                    Assert.NotNull(dnsAlias);
                    Assert.Equal(rgName, dnsAlias.ResourceGroupName);
                    Assert.Equal(sqlServerName1, dnsAlias.SqlServerName);

                    dnsAlias = rollUpClient.SqlServers.DnsAliases
                        .GetBySqlServer(rgName, sqlServerName1, SqlServerName);
                    Assert.NotNull(dnsAlias);
                    Assert.Equal(rgName, dnsAlias.ResourceGroupName);
                    Assert.Equal(sqlServerName1, dnsAlias.SqlServerName);

                    Assert.Equal(1, sqlServer1.Databases.List().Count);

                    var sqlServer2 = rollUpClient.SqlServers.Define(sqlServerName2)
                        .WithRegion(Region.AsiaSouthEast)
                        .WithNewResourceGroup(rgName)
                        .WithAdministratorLogin(sqlServerAdminName)
                        .WithAdministratorPassword(sqlServerAdminPassword)
                        .Create();
                    Assert.NotNull(sqlServer2);

                    sqlServer2.DnsAliases.Acquire(SqlServerName, sqlServer1.Id);
                    SdkContext.DelayProvider.Delay(3 * 60 * 1000);

                    dnsAlias = sqlServer2.DnsAliases.Get(SqlServerName);
                    Assert.NotNull(dnsAlias);
                    Assert.Equal(rgName, dnsAlias.ResourceGroupName);
                    Assert.Equal(sqlServerName2, dnsAlias.SqlServerName);

                    // cleanup
                    dnsAlias.Delete();

                    DeleteResourceGroup(GroupName);
                }
                finally
                {
                    try
                    {
                        rollUpClient.ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void canGetSqlServerCapabilitiesAndCreateIdentity()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                GenerateNewRGAndSqlServerNameForTest();
                var rollUpClient = TestHelper.CreateRollupClient();

                try
                {
                    string rgName = GroupName;
                    string sqlServerName = SqlServerName;
                    string sqlServerAdminName = "sqladmin";
                    string sqlServerAdminPassword = TestUtilities.GenerateName("Pa5$");
                    string databaseName = "db-from-sample";

                    var regionCapabilities = rollUpClient.SqlServers.GetCapabilitiesByRegion(Region.USEast);
                    Assert.NotNull(regionCapabilities);
                    Assert.NotNull(regionCapabilities.SupportedCapabilitiesByServerVersion["12.0"]);
                    Assert.True(regionCapabilities.SupportedCapabilitiesByServerVersion["12.0"].SupportedEditions.Count > 0);
                    Assert.True(regionCapabilities.SupportedCapabilitiesByServerVersion["12.0"].SupportedElasticPoolEditions.Count > 0);

                    // Create
                    var sqlServer = rollUpClient.SqlServers
                        .Define(sqlServerName)
                        .WithRegion(Region.AsiaSouthEast)
                        .WithNewResourceGroup(rgName)
                        .WithAdministratorLogin(sqlServerAdminName)
                        .WithAdministratorPassword(sqlServerAdminPassword)
                        .WithSystemAssignedManagedServiceIdentity()
                        .DefineDatabase(databaseName)
                            .FromSample(SampleName.AdventureWorksLT)
                            .WithBasicEdition()
                            .Attach()
                        .Create();
                    var dbFromSample = sqlServer.Databases.Get(databaseName);
                    Assert.NotNull(dbFromSample);
                    Assert.Equal(DatabaseEdition.Basic, dbFromSample.Edition);

                    Assert.True(sqlServer.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(sqlServer.SystemAssignedManagedServiceIdentityTenantId);
                    Assert.NotNull(sqlServer.SystemAssignedManagedServiceIdentityPrincipalId);

                    sqlServer.Update()
                        .WithSystemAssignedManagedServiceIdentity()
                        .Apply();
                    Assert.True(sqlServer.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(sqlServer.SystemAssignedManagedServiceIdentityTenantId);
                    Assert.NotNull(sqlServer.SystemAssignedManagedServiceIdentityPrincipalId);


                    DeleteResourceGroup(GroupName);
                }
                finally
                {
                    try
                    {
                        rollUpClient.ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact(Skip = "Manual only: This test require existing SQL server so that there can be recommended elastic pools")]
        public void CanListRecommendedElasticPools()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();
                var sqlServer = sqlServerManager.SqlServers.GetByResourceGroup("ans", "ans-secondary");
                var usages = sqlServer.Databases.List().First().ListServiceTierAdvisors().Values.FirstOrDefault().ServiceLevelObjectiveUsageMetrics;
                var recommendedElasticPools = sqlServer.ListRecommendedElasticPools();
                Assert.NotNull(recommendedElasticPools);
                //Assert.NotNull(sqlServer.Databases.List().FirstOrDefault().GetUpgradeHint());
            }
        }

        [Fact]
        public void CanCRUDSqlServer()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                try
                {
                    // Create
                    var sqlServer = CreateSqlServer(sqlServerManager);

                    ValidateSqlServer(sqlServer);

                    var serviceObjectives = sqlServer.ListServiceObjectives();

                    Assert.NotEmpty(serviceObjectives);
                    Assert.NotNull(serviceObjectives.FirstOrDefault().Refresh());
                    Assert.NotNull(sqlServer.GetServiceObjective("d1737d22-a8ea-4de7-9bd0-33395d2a7419"));

                    sqlServer.Update().WithAdministratorPassword("loepop77ejk~13@@").Apply();

                    // List
                    var sqlServers = sqlServerManager.SqlServers.ListByResourceGroup(GroupName);
                    var found = false;
                    foreach (var server in sqlServers)
                    {
                        if (StringComparer.OrdinalIgnoreCase.Equals(server.Name, SqlServerName))
                        {
                            found = true;
                        }
                    }
                    Assert.True(found);
                    // Get
                    sqlServer = sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName);
                    Assert.NotNull(sqlServer);

                    sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                    ValidateSqlServerNotFound(sqlServerManager, sqlServer);
                    DeleteResourceGroup(sqlServer.ResourceGroupName);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanUseCoolShortcutsForResourceCreation()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                var database2Name = "database2";
                var database1InEPName = "database1InEP";
                var database2InEPName = "database2InEP";
                var elasticPool2Name = "elasticPool2";
                var elasticPool3Name = "elasticPool3";
                var elasticPool1Name = SqlElasticPoolName;

                try
                {
                    // Create
                    var sqlServer = sqlServerManager.SqlServers.Define(SqlServerName)
                        .WithRegion(Region.USEast2)
                        .WithNewResourceGroup(GroupName)
                        .WithAdministratorLogin("userName")
                        .WithAdministratorPassword("loepopfuejk~13@@")
                        .WithNewDatabase(SqlDatabaseName)
                        .WithNewDatabase(database2Name)
                        .WithNewElasticPool(elasticPool1Name, ElasticPoolEdition.Standard)
                        .WithNewElasticPool(elasticPool2Name, ElasticPoolEdition.Premium, database1InEPName, database2InEPName)
                        .WithNewElasticPool(elasticPool3Name, ElasticPoolEdition.Standard)
                        .WithNewFirewallRule(StartIPAddress, EndIPAddress, SqlFirewallRuleName)
                        .WithNewFirewallRule(StartIPAddress, EndIPAddress)
                        .WithNewFirewallRule(StartIPAddress)
                        .WithoutAccessFromAzureServices()
                        .Create();

                    ValidateMultiCreation(
                        sqlServerManager,
                        database2Name,
                        database1InEPName,
                        database2InEPName,
                        elasticPool1Name,
                        elasticPool2Name,
                        elasticPool3Name,
                        sqlServer,
                        false);
                    elasticPool1Name = SqlElasticPoolName + " U";
                    database2Name = "database2U";
                    database1InEPName = "database1InEPU";
                    database2InEPName = "database2InEPU";
                    elasticPool2Name = "elasticPool2U";
                    elasticPool3Name = "elasticPool3U";

                    // Update
                    sqlServer = sqlServer.Update()
                        .WithNewDatabase(SqlDatabaseName).WithNewDatabase(database2Name)
                        .WithNewElasticPool(elasticPool1Name, ElasticPoolEdition.Standard)
                        .WithNewElasticPool(elasticPool2Name, ElasticPoolEdition.Premium, database1InEPName, database2InEPName)
                        .WithNewElasticPool(elasticPool3Name, ElasticPoolEdition.Standard)
                        .WithNewFirewallRule(StartIPAddress, EndIPAddress, SqlFirewallRuleName)
                        .WithNewFirewallRule(StartIPAddress, EndIPAddress)
                        .WithNewFirewallRule(StartIPAddress)
                        .Apply();

                    ValidateMultiCreation(
                        sqlServerManager,
                        database2Name,
                        database1InEPName,
                        database2InEPName,
                        elasticPool1Name,
                        elasticPool2Name,
                        elasticPool3Name,
                        sqlServer,
                        true);

                    sqlServer.Refresh();
                    Assert.Empty(sqlServer.ElasticPools.List());

                    // List
                    var sqlServers = sqlServerManager.SqlServers.ListByResourceGroup(GroupName);
                    var found = false;
                    foreach (var server in sqlServers)
                    {
                        if (StringComparer.OrdinalIgnoreCase.Equals(server.Name, SqlServerName))
                        {
                            found = true;
                        }
                    }

                    Assert.True(found);
                    // Get
                    sqlServer = sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName);
                    Assert.NotNull(sqlServer);

                    sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                    ValidateSqlServerNotFound(sqlServerManager, sqlServer);
                    DeleteResourceGroup(sqlServer.ResourceGroupName);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        private static void ValidateMultiCreation(
                ISqlManager sqlServerManager,
                string database2Name,
                string database1InEPName,
                string database2InEPName,
                string elasticPool1Name,
                string elasticPool2Name,
                string elasticPool3Name,
                ISqlServer sqlServer,
                bool deleteUsingUpdate)
        {
            ValidateSqlServer(sqlServer);
            ValidateSqlServer(sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName));
            ValidateSqlDatabase(sqlServer.Databases.Get(SqlDatabaseName), SqlDatabaseName);
            ValidateSqlFirewallRule(sqlServer.FirewallRules.Get(SqlFirewallRuleName), SqlFirewallRuleName);

            var firewalls = sqlServer.FirewallRules.List();
            Assert.Equal(3, firewalls.Count());

            var startIPAddress = 0;
            var endIPAddress = 0;

            foreach (ISqlFirewallRule firewall in firewalls)
            {
                if (!StringComparer.OrdinalIgnoreCase.Equals(firewall.Name, SqlFirewallRuleName))
                {
                    Assert.Equal(firewall.StartIPAddress, StartIPAddress);
                    if (StringComparer.OrdinalIgnoreCase.Equals(firewall.EndIPAddress, StartIPAddress))
                    {
                        startIPAddress++;
                    }
                    else if (StringComparer.OrdinalIgnoreCase.Equals(firewall.EndIPAddress, EndIPAddress))
                    {
                        endIPAddress++;
                    }
                }
            }

            Assert.Equal(1, startIPAddress);
            Assert.Equal(1, endIPAddress);

            Assert.NotNull(sqlServer.Databases.Get(database2Name));
            Assert.NotNull(sqlServer.Databases.Get(database1InEPName));
            Assert.NotNull(sqlServer.Databases.Get(database2InEPName));

            var ep1 = sqlServer.ElasticPools.Get(elasticPool1Name);
            ValidateSqlElasticPool(ep1, elasticPool1Name);
            var ep2 = sqlServer.ElasticPools.Get(elasticPool2Name);

            Assert.NotNull(ep2);
            Assert.Equal(ep2.Edition, ElasticPoolEdition.Premium);
            Assert.Equal(2, ep2.ListDatabases().Count());
            Assert.NotNull(ep2.GetDatabase(database1InEPName));
            Assert.NotNull(ep2.GetDatabase(database2InEPName));

            var ep3 = sqlServer.ElasticPools.Get(elasticPool3Name);

            Assert.NotNull(ep3);
            Assert.Equal(ep3.Edition, ElasticPoolEdition.Standard);

            if (!deleteUsingUpdate)
            {
                sqlServer.Databases.Delete(database2Name);
                sqlServer.Databases.Delete(database1InEPName);
                sqlServer.Databases.Delete(database2InEPName);
                sqlServer.Databases.Delete(SqlDatabaseName);

                Assert.Empty(ep1.ListDatabases());
                Assert.Empty(ep2.ListDatabases());
                Assert.Empty(ep3.ListDatabases());

                sqlServer.ElasticPools.Delete(elasticPool1Name);
                sqlServer.ElasticPools.Delete(elasticPool2Name);
                sqlServer.ElasticPools.Delete(elasticPool3Name);

                firewalls = sqlServer.FirewallRules.List();

                foreach (ISqlFirewallRule firewallRule in firewalls)
                {
                    firewallRule.Delete();
                }
            }
            else
            {
                sqlServer.Update()
                        .WithoutDatabase(database2Name)
                        .WithoutElasticPool(elasticPool1Name)
                        .WithoutElasticPool(elasticPool2Name)
                        .WithoutElasticPool(elasticPool3Name)
                        .WithoutDatabase(database1InEPName)
                        .WithoutDatabase(SqlDatabaseName)
                        .WithoutDatabase(database2InEPName)
                        .WithoutFirewallRule(SqlFirewallRuleName)
                        .Apply();

                Assert.Empty(sqlServer.ElasticPools.List());

                firewalls = sqlServer.FirewallRules.List();
                Assert.Equal(2, firewalls.Count());
                foreach (ISqlFirewallRule firewallRule in firewalls)
                {
                    firewallRule.Delete();
                }
            }

            Assert.Empty(sqlServer.ElasticPools.List());
            // Only master database is remaining in the SQLServer.
            Assert.Single(sqlServer.Databases.List());
        }

        [Fact]
        public void CanCRUDSqlDatabase()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                try
                {
                    // Create
                    var sqlServer = CreateSqlServer(sqlServerManager);

                    var sqlDatabase = sqlServer.Databases
                        .Define(SqlDatabaseName)
                        .WithCollation(Collation)
                        .WithEdition(DatabaseEdition.Standard)
                        .WithTag("tag1", "value1")
                        .Create();

                    Assert.True(sqlServer.Databases.List().Count > 0);
                    ValidateSqlDatabase(sqlDatabase, SqlDatabaseName);

                    // Test transparent data encryption settings.
                    var transparentDataEncryption = sqlDatabase.GetTransparentDataEncryption();
                    var transparentDataEncryptionActivities = transparentDataEncryption.ListActivities();
                    Assert.NotNull(transparentDataEncryptionActivities);

                    transparentDataEncryption = transparentDataEncryption.UpdateStatus(TransparentDataEncryptionStatus.Enabled);
                    Assert.NotNull(transparentDataEncryption);
                    Assert.Equal(TransparentDataEncryptionStatus.Enabled, transparentDataEncryption.Status);

                    transparentDataEncryptionActivities = transparentDataEncryption.ListActivities();
                    Assert.NotNull(transparentDataEncryptionActivities);

                    TestHelper.Delay(10000);
                    transparentDataEncryption = sqlDatabase.GetTransparentDataEncryption().UpdateStatus(TransparentDataEncryptionStatus.Disabled);
                    Assert.NotNull(transparentDataEncryption);
                    Assert.Equal(TransparentDataEncryptionStatus.Disabled, transparentDataEncryption.Status);
                    Assert.Equal(transparentDataEncryption.SqlServerName, SqlServerName);
                    Assert.Equal(transparentDataEncryption.DatabaseName, SqlDatabaseName);
                    Assert.NotNull(transparentDataEncryption.Name);
                    Assert.NotNull(transparentDataEncryption.Id);
                    // Done testing with encryption settings.

                    // Assert.NotNull(sqlDatabase.GetUpgradeHint());

                    // Test Service tier advisors.
                    var serviceTierAdvisors = sqlDatabase.ListServiceTierAdvisors();
                    Assert.NotNull(serviceTierAdvisors);
                    Assert.NotNull(serviceTierAdvisors.Values.First().ServiceLevelObjectiveUsageMetrics);
                    Assert.NotEmpty(serviceTierAdvisors);

                    Assert.NotNull(serviceTierAdvisors.Values.First().Refresh());
                    Assert.NotNull(serviceTierAdvisors.Values.First().ServiceLevelObjectiveUsageMetrics);
                    // End of testing service tier advisors.

                    sqlServer = sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName);
                    ValidateSqlServer(sqlServer);

                    // Create another database with above created database as source database.
                    var sqlElasticPoolCreatable = sqlServer.ElasticPools
                        .Define(SqlElasticPoolName)
                        .WithEdition(ElasticPoolEdition.Standard);
                    var anotherDatabaseName = "anotherDatabase";
                    var anotherDatabase = sqlServer.Databases
                        .Define(anotherDatabaseName)
                        .WithNewElasticPool(sqlElasticPoolCreatable)
                        .WithSourceDatabase(sqlDatabase.Id)
                        .WithMode(CreateMode.Copy)
                        .Create();

                    ValidateSqlDatabaseWithElasticPool(anotherDatabase, anotherDatabaseName);
                    sqlServer.Databases.Delete(anotherDatabase.Name);

                    // Get
                    ValidateSqlDatabase(sqlServer.Databases.Get(SqlDatabaseName), SqlDatabaseName);

                    // List
                    ValidateListSqlDatabase(sqlServer.Databases.List());

                    // Delete
                    sqlServer.Databases.Delete(SqlDatabaseName);
                    ValidateSqlDatabaseNotFound(sqlServerManager, SqlDatabaseName);

                    // Add another database to the server
                    sqlDatabase = sqlServer.Databases
                            .Define("newDatabase")
                            .WithCollation(Collation)
                            .WithEdition(DatabaseEdition.Standard)
                            .Create();
                    sqlServer.Databases.Delete(sqlDatabase.Name);

                    sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                    ValidateSqlServerNotFound(sqlServerManager, sqlServer);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanManageReplicationLinks()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                try
                {
                    // Create
                    var anotherSqlServerName = SqlServerName + "another";
                    var sqlServer1 = CreateSqlServer(sqlServerManager);
                    var sqlServer2 = CreateSqlServer(sqlServerManager, anotherSqlServerName);

                    var databaseInServer1 = sqlServer1.Databases
                        .Define(SqlDatabaseName)
                        .WithCollation(Collation)
                        .WithEdition(DatabaseEdition.Standard)
                        .Create();

                    ValidateSqlDatabase(databaseInServer1, SqlDatabaseName);
                    var databaseInServer2 = sqlServer2.Databases
                        .Define(SqlDatabaseName)
                        .WithSourceDatabase(databaseInServer1.Id)
                        .WithMode(CreateMode.OnlineSecondary)
                        .Create();
                    TestHelper.Delay(2000);
                    var replicationLinksInDb1 = new List<IReplicationLink>(databaseInServer1.ListReplicationLinks().Values);

                    Assert.Single(replicationLinksInDb1);
                    Assert.Equal(replicationLinksInDb1.FirstOrDefault().PartnerDatabase, databaseInServer2.Name);
                    Assert.Equal(replicationLinksInDb1.FirstOrDefault().PartnerServer, databaseInServer2.SqlServerName);

                    var replicationLinksInDb2 = new List<IReplicationLink>(databaseInServer2.ListReplicationLinks().Values);

                    Assert.Single(replicationLinksInDb2);
                    Assert.Equal(replicationLinksInDb2.FirstOrDefault().PartnerDatabase, databaseInServer1.Name);
                    Assert.Equal(replicationLinksInDb2.FirstOrDefault().PartnerServer, databaseInServer1.SqlServerName);

                    Assert.NotNull(replicationLinksInDb1.FirstOrDefault().Refresh());

                    // Failover
                    replicationLinksInDb2.FirstOrDefault().Failover();
                    replicationLinksInDb2.FirstOrDefault().Refresh();
                    TestHelper.Delay(30000);
                    // Force failover
                    replicationLinksInDb1.FirstOrDefault().ForceFailoverAllowDataLoss();
                    replicationLinksInDb1.FirstOrDefault().Refresh();

                    TestHelper.Delay(30000);

                    replicationLinksInDb2.FirstOrDefault().Delete();
                    Assert.Empty(databaseInServer2.ListReplicationLinks());

                    sqlServer1.Databases.Delete(databaseInServer1.Name);
                    sqlServer2.Databases.Delete(databaseInServer2.Name);

                    sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer2.ResourceGroupName, sqlServer2.Name);
                    ValidateSqlServerNotFound(sqlServerManager, sqlServer2);
                    sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer1.ResourceGroupName, sqlServer1.Name);
                    ValidateSqlServerNotFound(sqlServerManager, sqlServer1);
                    DeleteResourceGroup(sqlServer1.ResourceGroupName);
                    DeleteResourceGroup(sqlServer2.ResourceGroupName);
                }

                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanDoOperationsOnDataWarehouse()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                try
                {
                    // Create
                    var sqlServer = CreateSqlServer(sqlServerManager);

                    ValidateSqlServer(sqlServer);

                    // List usages for the server.
                    Assert.NotNull(sqlServer.ListUsages());

                    var sqlDatabase = sqlServer.Databases
                            .Define(SqlDatabaseName)
                            .WithCollation(Collation)
                            .WithEdition(DatabaseEdition.DataWarehouse)
                            .WithServiceObjective(ServiceObjectiveName.DW1000c)
                            .Create();

                    sqlDatabase = sqlServer.Databases.Get(SqlDatabaseName);
                    Assert.NotNull(sqlDatabase);
                    Assert.True(sqlDatabase.IsDataWarehouse);

                    // Get
                    var dataWarehouse = sqlServer.Databases.Get(SqlDatabaseName).AsWarehouse();

                    Assert.NotNull(dataWarehouse);
                    Assert.Equal(dataWarehouse.Name, SqlDatabaseName);
                    Assert.Equal(dataWarehouse.Edition, DatabaseEdition.DataWarehouse);

                    // List Restore points.
                    Assert.NotNull(dataWarehouse.ListRestorePoints());
                    // Get usages.
                    Assert.NotNull(dataWarehouse.ListUsages());

                    // Pause warehouse
                    dataWarehouse.PauseDataWarehouse();

                    // Resume warehouse
                    dataWarehouse.ResumeDataWarehouse();

                    sqlServer.Databases.Delete(SqlDatabaseName);

                    sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                    ValidateSqlServerNotFound(sqlServerManager, sqlServer);
                    DeleteResourceGroup(sqlServer.ResourceGroupName);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCRUDSqlDatabaseWithElasticPool()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();
                var resourceManager = TestHelper.CreateResourceManager();

                GenerateNewRGAndSqlServerNameForTest();

                try
                {
                    // Create
                    var sqlServer = CreateSqlServer(sqlServerManager);

                    var sqlElasticPoolCreatable = sqlServer.ElasticPools
                            .Define(SqlElasticPoolName)
                            .WithEdition(ElasticPoolEdition.Standard);

                    var sqlDatabase = sqlServer.Databases
                            .Define(SqlDatabaseName)
                            .WithNewElasticPool(sqlElasticPoolCreatable)
                            .WithCollation(Collation)
                            .WithTag("key", "value")
                            .Create();
                    // Adding bugfix check. Database has Tags which should be settable
                    var withTags = sqlServer.Databases.GetById(sqlDatabase.Id);
                    Assert.NotNull(withTags);
                    Assert.NotNull(withTags.Tags);
                    Assert.Equal("value", withTags.Tags["key"]);
                    // End of bugfix
                    ValidateSqlDatabase(sqlDatabase, SqlDatabaseName);

                    sqlServer = sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName);
                    ValidateSqlServer(sqlServer);

                    // Get Elastic pool
                    var elasticPool = sqlServer.ElasticPools.Get(SqlElasticPoolName);
                    ValidateSqlElasticPool(elasticPool);

                    // Get
                    ValidateSqlDatabaseWithElasticPool(sqlServer.Databases.Get(SqlDatabaseName), SqlDatabaseName);

                    // List
                    ValidateListSqlDatabase(sqlServer.Databases.List());

                    // Remove database from elastic pools.
                    sqlDatabase.Update()
                            .WithoutElasticPool()
                            .WithEdition(DatabaseEdition.Standard)
                            .WithServiceObjective(ServiceObjectiveName.S3)
                        .Apply();
                    sqlDatabase = sqlServer.Databases.Get(SqlDatabaseName);
                    Assert.Null(sqlDatabase.ElasticPoolName);

                    // Update edition of the SQL database
                    sqlDatabase.Update()
                            .WithEdition(DatabaseEdition.Premium)
                            .WithServiceObjective(ServiceObjectiveName.P1)
                            .Apply();
                    sqlDatabase = sqlServer.Databases.Get(SqlDatabaseName);
                    Assert.Equal(sqlDatabase.Edition, DatabaseEdition.Premium);
                    Assert.Equal(sqlDatabase.ServiceLevelObjective, ServiceObjectiveName.P1);

                    // Update just the service level objective for database.
                    sqlDatabase.Update().WithServiceObjective(ServiceObjectiveName.P2).Apply();
                    sqlDatabase = sqlServer.Databases.Get(SqlDatabaseName);
                    Assert.Equal(sqlDatabase.ServiceLevelObjective, ServiceObjectiveName.P2);
                    Assert.Equal(sqlDatabase.RequestedServiceObjectiveName, ServiceObjectiveName.P2);

                    // Update max size bytes of the database.
                    sqlDatabase.Update()
                            .WithMaxSizeBytes(268435456000L)
                            .Apply();

                    sqlDatabase = sqlServer.Databases.Get(SqlDatabaseName);
                    Assert.Equal(268435456000L, sqlDatabase.MaxSizeBytes);

                    // Put the database back in elastic pool.
                    sqlDatabase.Update()
                            .WithExistingElasticPool(SqlElasticPoolName)
                            .Apply();

                    sqlDatabase = sqlServer.Databases.Get(SqlDatabaseName);
                    Assert.Equal(sqlDatabase.ElasticPoolName, SqlElasticPoolName);

                    // List Activity in elastic pool
                    Assert.NotNull(elasticPool.ListActivities());

                    // List Database activity in elastic pool.
                    Assert.NotNull(elasticPool.ListDatabaseActivities());

                    // List databases in elastic pool.
                    var databasesInElasticPool = elasticPool.ListDatabases();
                    Assert.NotNull(databasesInElasticPool);
                    Assert.Single(databasesInElasticPool);

                    // Get a particular database in elastic pool.
                    var databaseInElasticPool = elasticPool.GetDatabase(SqlDatabaseName);
                    ValidateSqlDatabase(databaseInElasticPool, SqlDatabaseName);

                    // Refresh works on the database got from elastic pool.
                    databaseInElasticPool.Refresh();

                    // Validate that trying to get an invalid database from elastic pool returns null.
                    try
                    {
                        elasticPool.GetDatabase("does_not_exist");
                        Assert.NotNull(null);
                    }
                    catch
                    {
                    }

                    // Delete
                    sqlServer.Databases.Delete(SqlDatabaseName);
                    ValidateSqlDatabaseNotFound(sqlServerManager, SqlDatabaseName);

                    var sqlElasticPool = sqlServer.ElasticPools.Get(SqlElasticPoolName);

                    // Add another database to the server and pool.
                    sqlDatabase = sqlServer.Databases
                            .Define("newDatabase")
                            .WithExistingElasticPool(sqlElasticPool)
                            .WithCollation(Collation)
                            .Create();
                    sqlServer.Databases.Delete(sqlDatabase.Name);
                    ValidateSqlDatabaseNotFound(sqlServerManager, "newDatabase");

                    sqlServer.ElasticPools.Delete(SqlElasticPoolName);
                    sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                    ValidateSqlServerNotFound(sqlServerManager, sqlServer);
                    DeleteResourceGroup(sqlServer.ResourceGroupName);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCRUDSqlElasticPool()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                try
                {
                    // Create
                    var sqlServer = CreateSqlServer(sqlServerManager);

                    sqlServer = sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName);
                    ValidateSqlServer(sqlServer);

                    var sqlElasticPool = sqlServer.ElasticPools
                            .Define(SqlElasticPoolName)
                            .WithEdition(ElasticPoolEdition.Standard)
                            .WithTag("tag1", "value1")
                            .Create();
                    ValidateSqlElasticPool(sqlElasticPool);
                    Assert.Empty(sqlElasticPool.ListDatabases());

                    sqlElasticPool = sqlElasticPool.Update()
                            .WithDtu(100)
                            .WithDatabaseDtuMax(20)
                            .WithDatabaseDtuMin(10)
                            .WithStorageCapacity(102400)
                            .WithNewDatabase(SqlDatabaseName)
                            .Apply();

                    ValidateSqlElasticPool(sqlElasticPool);
                    Assert.Single(sqlElasticPool.ListDatabases());

                    // Get
                    ValidateSqlElasticPool(sqlServer.ElasticPools.Get(SqlElasticPoolName));

                    // List
                    ValidateListSqlElasticPool(sqlServer.ElasticPools.List());

                    // Delete
                    sqlServer.Databases.Delete(SqlDatabaseName);
                    sqlServer.ElasticPools.Delete(SqlElasticPoolName);
                    ValidateSqlElasticPoolNotFound(sqlServer, SqlElasticPoolName);

                    // Add another database to the server
                    sqlElasticPool = sqlServer.ElasticPools
                            .Define("newElasticPool")
                            .WithEdition(ElasticPoolEdition.Standard)
                            .Create();

                    sqlServer.ElasticPools.Delete(sqlElasticPool.Name);
                    ValidateSqlElasticPoolNotFound(sqlServer, "newElasticPool");

                    sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                    ValidateSqlServerNotFound(sqlServerManager, sqlServer);
                    DeleteResourceGroup(sqlServer.ResourceGroupName);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCRUDSqlFirewallRule()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                try
                {
                    // Create
                    var sqlServer = CreateSqlServer(sqlServerManager);

                    sqlServer = sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName);
                    ValidateSqlServer(sqlServer);

                    var sqlFirewallRule = sqlServer.FirewallRules
                            .Define(SqlFirewallRuleName)
                            .WithIPAddressRange(StartIPAddress, EndIPAddress)
                            .Create();

                    ValidateSqlFirewallRule(sqlFirewallRule, SqlFirewallRuleName);
                    ValidateSqlFirewallRule(sqlServer.FirewallRules.Get(SqlFirewallRuleName), SqlFirewallRuleName);

                    var secondFirewallRuleName = "secondFireWallRule";
                    var secondFirewallRule = sqlServer.FirewallRules
                            .Define(secondFirewallRuleName)
                            .WithIPAddress(StartIPAddress)
                            .Create();

                    secondFirewallRule = sqlServer.FirewallRules.Get(secondFirewallRuleName);

                    Assert.NotNull(secondFirewallRule);
                    Assert.Equal(StartIPAddress, secondFirewallRule.EndIPAddress);

                    secondFirewallRule = secondFirewallRule.Update().WithEndIPAddress(EndIPAddress).Apply();

                    ValidateSqlFirewallRule(secondFirewallRule, secondFirewallRuleName);
                    sqlServer.FirewallRules.Delete(secondFirewallRuleName);
                    Assert.Null(sqlServer.FirewallRules.Get(secondFirewallRuleName));

                    // Get
                    sqlFirewallRule = sqlServer.FirewallRules.Get(SqlFirewallRuleName);
                    ValidateSqlFirewallRule(sqlFirewallRule, SqlFirewallRuleName);

                    // Update
                    // Making start and end IP address same.
                    sqlFirewallRule.Update().WithEndIPAddress(StartIPAddress).Apply();
                    sqlFirewallRule = sqlServer.FirewallRules.Get(SqlFirewallRuleName);
                    Assert.Equal(sqlFirewallRule.EndIPAddress, StartIPAddress);

                    // List
                    ValidateListSqlFirewallRule(sqlServer.FirewallRules.List());

                    // Delete
                    sqlServer.FirewallRules.Delete(sqlFirewallRule.Name);
                    ValidateSqlFirewallRuleNotFound(sqlServerManager);

                    // Delete server
                    sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                    ValidateSqlServerNotFound(sqlServerManager, sqlServer);
                    DeleteResourceGroup(sqlServer.ResourceGroupName);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        private static void ValidateSqlFirewallRuleNotFound(ISqlManager sqlServerManager)
        {
            Assert.Null(sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName).FirewallRules.Get(SqlFirewallRuleName));
        }

        private static void ValidateSqlElasticPoolNotFound(ISqlServer sqlServer, string elasticPoolName)
        {
            Assert.Null(sqlServer.ElasticPools.Get(elasticPoolName));
        }

        private static void ValidateSqlDatabaseNotFound(ISqlManager sqlServerManager, String newDatabase)
        {
            Assert.Null(sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName).Databases.Get(newDatabase));
        }

        private static void ValidateSqlServerNotFound(ISqlManager sqlServerManager, ISqlServer sqlServer)
        {
            Assert.Null(sqlServerManager.SqlServers.GetById(sqlServer.Id));
        }

        private static ISqlServer CreateSqlServer(ISqlManager sqlServerManager)
        {
            return CreateSqlServer(sqlServerManager, SqlServerName);
        }

        private static ISqlServer CreateSqlServer(ISqlManager sqlServerManager, string sqlServerName)
        {
            return sqlServerManager.SqlServers
                    .Define(sqlServerName)
                    .WithRegion(Region.USEast2)
                    .WithNewResourceGroup(GroupName)
                    .WithAdministratorLogin("userName")
                    .WithAdministratorPassword("loepopfuejk~13@@")
                    .Create();
        }

        private static void ValidateListSqlFirewallRule(IReadOnlyList<ISqlFirewallRule> sqlFirewallRules)
        {
            Assert.Contains(sqlFirewallRules, firewallRule => StringComparer.OrdinalIgnoreCase.Equals(firewallRule.Name, SqlFirewallRuleName));
        }

        private static void ValidateSqlFirewallRule(ISqlFirewallRule sqlFirewallRule, string firewallName)
        {
            Assert.NotNull(sqlFirewallRule);
            Assert.Equal(firewallName, sqlFirewallRule.Name);
            Assert.Equal(SqlServerName, sqlFirewallRule.SqlServerName);
            Assert.Equal(StartIPAddress, sqlFirewallRule.StartIPAddress);
            Assert.Equal(EndIPAddress, sqlFirewallRule.EndIPAddress);
            Assert.Equal(GroupName, sqlFirewallRule.ResourceGroupName);
            Assert.Equal(SqlServerName, sqlFirewallRule.SqlServerName);
            Assert.Equal(Region.USEast2, sqlFirewallRule.Region);
        }

        private static void ValidateListSqlElasticPool(IReadOnlyList<ISqlElasticPool> sqlElasticPools)
        {
            Assert.Contains(sqlElasticPools, elasticPool => StringComparer.OrdinalIgnoreCase.Equals(elasticPool.Name, SqlElasticPoolName));
        }

        private static void ValidateSqlElasticPool(ISqlElasticPool sqlElasticPool)
        {
            ValidateSqlElasticPool(sqlElasticPool, SqlElasticPoolName);
        }

        private static void ValidateSqlElasticPool(ISqlElasticPool sqlElasticPool, string elasticPoolName)
        {
            Assert.NotNull(sqlElasticPool);
            Assert.Equal(GroupName, sqlElasticPool.ResourceGroupName);
            Assert.Equal(elasticPoolName, sqlElasticPool.Name);
            Assert.Equal(SqlServerName, sqlElasticPool.SqlServerName);
            Assert.Equal(ElasticPoolEdition.Standard, sqlElasticPool.Edition);
            Assert.NotEqual(0, sqlElasticPool.DatabaseDtuMax);
            Assert.NotEqual(0, sqlElasticPool.Dtu);
        }

        private static void ValidateListSqlDatabase(IReadOnlyList<ISqlDatabase> sqlDatabases)
        {
            Assert.Contains(sqlDatabases, database => StringComparer.OrdinalIgnoreCase.Equals(database.Name, SqlDatabaseName));
        }

        private static void ValidateSqlServer(ISqlServer sqlServer)
        {
            Assert.NotNull(sqlServer);
            Assert.Equal(GroupName, sqlServer.ResourceGroupName);
            Assert.NotNull(sqlServer.FullyQualifiedDomainName);
            Assert.NotNull(sqlServer.Version);
            Assert.Equal("userName", sqlServer.AdministratorLogin);
        }

        private static void ValidateSqlDatabase(ISqlDatabase sqlDatabase, string databaseName)
        {
            Assert.NotNull(sqlDatabase);
            Assert.Equal(sqlDatabase.Name, databaseName);
            Assert.Equal(SqlServerName, sqlDatabase.SqlServerName);
            Assert.Equal(sqlDatabase.Collation, Collation);
            Assert.Equal(sqlDatabase.Edition, DatabaseEdition.Standard);
        }

        private static void ValidateSqlDatabaseWithElasticPool(ISqlDatabase sqlDatabase, string databaseName)
        {
            ValidateSqlDatabase(sqlDatabase, databaseName);
            Assert.Equal(SqlElasticPoolName, sqlDatabase.ElasticPoolName);
        }
    }
}