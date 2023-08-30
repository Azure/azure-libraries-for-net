// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Monitor.Fluent;
using Microsoft.Azure.Management.Monitor.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using System.Net;
using Xunit;
using DayOfWeek = Microsoft.Azure.Management.Monitor.Fluent.Models.DayOfWeek;

namespace Fluent.Tests
{
    public class Monitor
    {
        [Fact]
        public void CanListEventsAndMetrics()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                DateTime recordDateTime = new DateTime(2020, 4, 8, 00, 08, 00, DateTimeKind.Utc);
                var vm = azure.VirtualMachines.List().First();

                // Metric Definition
                var mt = azure.MetricDefinitions.ListByResource(vm.Id);

                Assert.NotNull(mt);
                var mDef = mt.First();
                Assert.NotNull(mDef.MetricAvailabilities);
                Assert.NotNull(mDef.Namespace);
                Assert.NotNull(mDef.SupportedAggregationTypes);

                // Metric
                var metrics = mt.First().DefineQuery()
                        .StartingFrom(recordDateTime.AddDays(-1))
                        .EndsBefore(recordDateTime)
                        .WithResultType(ResultType.Data)
                        .Execute();

                Assert.NotNull(metrics);
                Assert.NotNull(metrics.Namespace);
                Assert.NotNull(metrics.ResourceRegion);
                Assert.Equal("Microsoft.Compute/virtualMachines", metrics.Namespace);

                // Activity Logs
                var retVal = azure.ActivityLogs
                        .DefineQuery()
                        .StartingFrom(recordDateTime.AddDays(-1))
                        .EndsBefore(recordDateTime)
                        .WithResponseProperties(
                                EventDataPropertyName.ResourceId,
                                EventDataPropertyName.EventTimestamp,
                                EventDataPropertyName.OperationName,
                                EventDataPropertyName.EventName)
                        .FilterByResource(vm.Id)
                        .Execute();

                Assert.NotNull(retVal);
                foreach (var ev in retVal)
                {
                    Assert.Equal(vm.Id.ToLowerInvariant(), ev.ResourceId.ToLowerInvariant());
                    Assert.NotNull(ev.EventName.LocalizedValue);
                    Assert.NotNull(ev.OperationName.LocalizedValue);
                    Assert.NotNull(ev.EventTimestamp);

                    Assert.Null(ev.Category);
                    Assert.Null(ev.Authorization);
                    Assert.Null(ev.Caller);
                    Assert.Null(ev.CorrelationId);
                    Assert.Null(ev.Description);
                    Assert.Null(ev.EventDataId);
                    Assert.Null(ev.HttpRequest);
                    Assert.Null(ev.Level);
                }


                // List Event Categories
                var eventCategories = azure.ActivityLogs.ListEventCategories();
                Assert.NotNull(eventCategories);
                Assert.True(eventCategories.Any());

                // List Activity logs at tenant level is not allowed for the current tenant 
                try
                {
                    azure.ActivityLogs
                            .DefineQuery()
                            .StartingFrom(recordDateTime.AddDays(-30))
                            .EndsBefore(recordDateTime)
                            .WithResponseProperties(
                                EventDataPropertyName.ResourceId,
                                EventDataPropertyName.EventTimestamp,
                                EventDataPropertyName.OperationName,
                                EventDataPropertyName.EventName)
                            .FilterByResource(vm.Id)
                            .FilterAtTenantLevel()
                            .Execute();
                }
                catch (ErrorResponseException er)
                {
                    // should throw "The client '...' with object id '...' does not have authorization to perform action
                    // 'microsoft.insights/eventtypes/values/read' over scope '/providers/microsoft.insights/eventtypes/management'.
                    Assert.Equal(HttpStatusCode.Forbidden, er.Response.StatusCode);
                }

            }
        }

        [Fact]
        public void CanCRUDDiagnosticSettings()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = SdkContext.RandomResourceName("jMonitor_", 18);
                var saName = SdkContext.RandomResourceName("jMonitorSa", 18);
                var dsName = SdkContext.RandomResourceName("jMonitorDs_", 18);
                var ehName = SdkContext.RandomResourceName("jMonitorEH", 18);
                var azure = TestHelper.CreateRollupClient();

                try
                {
                    var vm = azure.VirtualMachines.List().First();

                    // clean all diagnostic settings.
                    var dsList = azure.DiagnosticSettings.ListByResource(vm.Id);
                    foreach (var dsd in dsList)
                    {
                        azure.DiagnosticSettings.DeleteById(dsd.Id);
                    }

                    var sa = azure.StorageAccounts
                            .Define(saName)
                            // Storage Account should be in the same region as resource
                            .WithRegion(vm.Region)
                            .WithNewResourceGroup(rgName)
                            .WithTag("tag1", "value1")
                            .Create();

                    var ehNamespace = azure.EventHubNamespaces
                        .Define(ehName)
                        // EventHub should be in the same region as resource
                        .WithRegion(vm.Region)
                        .WithExistingResourceGroup(rgName)
                        .WithNewManageRule("mngRule1")
                        .WithNewSendRule("sndRule1")
                        .Create();
                    var evenHubNsRule = ehNamespace.ListAuthorizationRules().First();

                    var categories = azure.DiagnosticSettings.ListCategoriesByResource(vm.Id);

                    Assert.NotNull(categories);
                    Assert.True(categories.Any());

                    var setting = azure.DiagnosticSettings
                        .Define(dsName)
                        .WithResource(vm.Id)
                        .WithStorageAccount(sa.Id)
                        .WithEventHub(evenHubNsRule.Id)
                        .WithLogsAndMetrics(categories, TimeSpan.FromMinutes(5), 7)
                        .Create();

                    Assert.Equal(vm.Id, setting.ResourceId, ignoreCase: true);
                    Assert.Equal(sa.Id, setting.StorageAccountId, ignoreCase: true);
                    Assert.Equal(evenHubNsRule.Id, setting.EventHubAuthorizationRuleId, ignoreCase: true);
                    Assert.Null(setting.EventHubName);
                    Assert.Null(setting.WorkspaceId);
                    Assert.False(setting.Logs.Any());
                    Assert.True(setting.Metrics.Any());

                    setting.Update()
                            .WithoutStorageAccount()
                            .WithoutLogs()
                            .Apply();

                    Assert.Equal(vm.Id, setting.ResourceId, ignoreCase: true);
                    Assert.Equal(evenHubNsRule.Id, setting.EventHubAuthorizationRuleId, ignoreCase: true);
                    Assert.Null(setting.StorageAccountId);
                    Assert.Null(setting.EventHubName);
                    Assert.Null(setting.WorkspaceId);
                    Assert.False(setting.Logs.Any());
                    Assert.True(setting.Metrics.Any());

                    var ds1 = azure.DiagnosticSettings.Get(setting.ResourceId, setting.Name);
                    CheckDiagnosticSettingValues(setting, ds1);

                    var ds2 = azure.DiagnosticSettings.GetById(setting.Id);
                    CheckDiagnosticSettingValues(setting, ds2);

                    dsList = azure.DiagnosticSettings.ListByResource(vm.Id);
                    Assert.NotNull(dsList);
                    Assert.Single(dsList);

                    var ds3 = dsList.First();
                    CheckDiagnosticSettingValues(setting, ds3);

                    azure.DiagnosticSettings.DeleteById(setting.Id);

                    dsList = azure.DiagnosticSettings.ListByResource(vm.Id);
                    Assert.NotNull(dsList);
                    Assert.False(dsList.Any());
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
        public void CanCRUDActionGroups()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = SdkContext.RandomResourceName("jMonitor_", 18);
                var saName = SdkContext.RandomResourceName("jMonitorSa", 18);
                var dsName = SdkContext.RandomResourceName("jMonitorDs_", 18);
                var ehName = SdkContext.RandomResourceName("jMonitorEH", 18);
                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var ag = azure.ActionGroups.Define("simpleActionGroup")
                        .WithNewResourceGroup(rgName, Region.AustraliaSouthEast)
                        .DefineReceiver("first")
                            .WithPushNotification("azurepush@outlook.com")
                            .WithEmail("justemail@outlook.com")
                            .WithSms("1", "4255655665")
                            .WithVoice("1", "2062066050")
                            .WithWebhook("https://www.rate.am")
                            .Attach()
                        .DefineReceiver("second")
                            .WithEmail("secondemail@outlook.com")
                            .WithWebhook("https://www.spyur.am")
                            .Attach()
                        .Create();

                    Assert.NotNull(ag);
                    Assert.Equal("simpleAction", ag.ShortName);
                    Assert.NotNull(ag.PushNotificationReceivers);
                    Assert.Equal(1, ag.PushNotificationReceivers.Count);
                    Assert.NotNull(ag.SmsReceivers);
                    Assert.Equal(1, ag.SmsReceivers.Count);
                    Assert.NotNull(ag.VoiceReceivers);
                    Assert.Equal(1, ag.VoiceReceivers.Count);
                    Assert.NotNull(ag.EmailReceivers);
                    Assert.Equal(2, ag.EmailReceivers.Count);
                    Assert.NotNull(ag.WebhookReceivers);
                    Assert.Equal(2, ag.WebhookReceivers.Count);
                    Assert.StartsWith("first", ag.EmailReceivers[0].Name);
                    Assert.StartsWith("second", ag.EmailReceivers[1].Name);

                    ag.Update()
                            .DefineReceiver("third")
                                .WithWebhook("https://www.news.am")
                                .Attach()
                            .UpdateReceiver("first")
                                .WithoutSms()
                                .Parent()
                            .WithoutReceiver("second")
                            .Apply();


                    Assert.Equal(2, ag.WebhookReceivers.Count);
                    Assert.Equal(1, ag.EmailReceivers.Count);
                    Assert.Equal(0, ag.SmsReceivers.Count);

                    var agGet = azure.ActionGroups.GetById(ag.Id);
                    Assert.Equal("simpleAction", agGet.ShortName);
                    Assert.Equal(2, agGet.WebhookReceivers.Count);
                    Assert.Equal(1, agGet.EmailReceivers.Count);
                    Assert.Equal(0, agGet.SmsReceivers.Count);

                    azure.ActionGroups.EnableReceiver(agGet.ResourceGroupName, agGet.Name, agGet.EmailReceivers.First().Name);

                    var agListByRg = azure.ActionGroups.ListByResourceGroup(rgName);
                    Assert.NotNull(agListByRg);
                    Assert.Single(agListByRg);

                    var agList = azure.ActionGroups.List();
                    Assert.NotNull(agListByRg);
                    Assert.True(agListByRg.Count() > 0);

                    azure.ActionGroups.DeleteById(ag.Id);
                    agListByRg = azure.ActionGroups.ListByResourceGroup(rgName);
                    Assert.Empty(agListByRg);

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
        public void CanCRUDMetricAlerts()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = SdkContext.RandomResourceName("jMonitor_", 18);
                var saName = SdkContext.RandomResourceName("jMonitorSa", 18);
                var dsName = SdkContext.RandomResourceName("jMonitorDs_", 18);
                var ehName = SdkContext.RandomResourceName("jMonitorEH", 18);
                var azure = TestHelper.CreateRollupClient();

                try
                {
                    var sa = azure.StorageAccounts.Define(saName)
                            .WithRegion(Region.USEast2)
                            .WithNewResourceGroup(rgName)
                            .Create();

                    var ag = azure.ActionGroups.Define("simpleActionGroup")
                            .WithExistingResourceGroup(rgName)
                            .DefineReceiver("first")
                                .WithPushNotification("azurepush@outlook.com")
                                .WithEmail("justemail@outlook.com")
                                .WithSms("1", "4255655665")
                                .WithVoice("1", "2062066050")
                                .WithWebhook("https://www.rate.am")
                                .Attach()
                            .DefineReceiver("second")
                                .WithEmail("secondemail@outlook.com")
                                .WithWebhook("https://www.spyur.am")
                                .Attach()
                            .Create();

                    var ma = azure.AlertRules.MetricAlerts.Define("somename")
                            .WithExistingResourceGroup(rgName)
                            .WithTargetResource(sa.Id)
                            .WithPeriod(TimeSpan.FromMinutes(15))
                            .WithFrequency(TimeSpan.FromMinutes(1))
                            .WithAlertDetails(3, "This alert rule is for U3 - Single resource  multiple-criteria  with dimensions-single timeseries")
                            .WithActionGroups(ag.Id)
                            .DefineAlertCriteria("Metric1")
                                .WithMetricName("Transactions", "Microsoft.Storage/storageAccounts")
                                .WithCondition(MetricAlertRuleTimeAggregation.Total, MetricAlertRuleCondition.GreaterThan, 100)
                                .WithDimension("ResponseType", "Success")
                                .WithDimension("ApiName", "GetBlob")
                                .Attach()
                            .Create();

                    Assert.NotNull(ma);
                    Assert.Equal(1, ma.Scopes.Count);
                    Assert.Equal(sa.Id, ma.Scopes.First());
                    Assert.Equal("This alert rule is for U3 - Single resource  multiple-criteria  with dimensions-single timeseries", ma.Description);
                    Assert.Equal(TimeSpan.FromMinutes(15), ma.WindowSize);
                    Assert.Equal(TimeSpan.FromMinutes(1), ma.EvaluationFrequency);
                    Assert.Equal(3, ma.Severity);
                    Assert.True(ma.Enabled);
                    Assert.True(ma.AutoMitigate);
                    Assert.Equal(1, ma.ActionGroupIds.Count);
                    Assert.Equal(ag.Id, ma.ActionGroupIds.First());
                    Assert.Equal(1, ma.AlertCriterias.Count);

                    var ac1 = ma.AlertCriterias.Values.First();
                    Assert.Equal("Metric1", ac1.Name);
                    Assert.Equal("Transactions", ac1.MetricName);
                    Assert.Equal("Microsoft.Storage/storageAccounts", ac1.MetricNamespace);
                    Assert.Equal(MetricAlertRuleCondition.GreaterThan, ac1.Condition);
                    Assert.Equal(MetricAlertRuleTimeAggregation.Total, ac1.TimeAggregation);
                    Assert.Equal(100.0, ac1.Threshold, 4);
                    Assert.Equal(2, ac1.Dimensions.Count);

                    MetricDimension d1 = ac1.Dimensions.ElementAt(0);
                    MetricDimension d2 = ac1.Dimensions.ElementAt(1);
                    Assert.Equal("ResponseType", d1.Name);
                    Assert.Equal(1, d1.Values.Count);
                    Assert.Equal("Success", d1.Values.ElementAt(0));
                    Assert.Equal("ApiName", d2.Name);
                    Assert.Equal(1, d2.Values.Count);
                    Assert.Equal("GetBlob", d2.Values.ElementAt(0));

                    var maFromGet = azure.AlertRules.MetricAlerts.GetById(ma.Id);
                    Assert.NotNull(maFromGet);
                    Assert.Equal(ma.Scopes.Count, maFromGet.Scopes.Count);
                    Assert.Equal(ma.Scopes.First(), maFromGet.Scopes.First());
                    Assert.Equal(ma.Description, maFromGet.Description);
                    Assert.Equal(ma.WindowSize, maFromGet.WindowSize);
                    Assert.Equal(ma.EvaluationFrequency, maFromGet.EvaluationFrequency);
                    Assert.Equal(ma.Severity, maFromGet.Severity);
                    Assert.Equal(ma.Enabled, maFromGet.Enabled);
                    Assert.Equal(ma.AutoMitigate, maFromGet.AutoMitigate);
                    Assert.Equal(ma.ActionGroupIds.Count, maFromGet.ActionGroupIds.Count);
                    Assert.Equal(ma.ActionGroupIds.First(), maFromGet.ActionGroupIds.First());
                    Assert.Equal(ma.AlertCriterias.Count, maFromGet.AlertCriterias.Count);
                    ac1 = maFromGet.AlertCriterias.Values.First();
                    Assert.Equal("Metric1", ac1.Name);
                    Assert.Equal("Transactions", ac1.MetricName);
                    Assert.Equal("Microsoft.Storage/storageAccounts", ac1.MetricNamespace);
                    Assert.Equal(MetricAlertRuleCondition.GreaterThan, ac1.Condition);
                    Assert.Equal(MetricAlertRuleTimeAggregation.Total, ac1.TimeAggregation);
                    Assert.Equal(100.00, ac1.Threshold, 4);
                    Assert.Equal(2, ac1.Dimensions.Count);

                    d1 = ac1.Dimensions.ElementAt(0);
                    d2 = ac1.Dimensions.ElementAt(1);
                    Assert.Equal("ResponseType", d1.Name);
                    Assert.Equal(1, d1.Values.Count);
                    Assert.Equal("Success", d1.Values.First());
                    Assert.Equal("ApiName", d2.Name);
                    Assert.Equal(1, d2.Values.Count);
                    Assert.Equal("GetBlob", d2.Values.First());

                    ma.Update()
                            .WithRuleDisabled()
                            .UpdateAlertCriteria("Metric1")
                                .WithCondition(MetricAlertRuleTimeAggregation.Total, MetricAlertRuleCondition.GreaterThan, 99)
                                .Parent()
                            .DefineAlertCriteria("Metric2")
                                .WithMetricName("SuccessE2ELatency", "Microsoft.Storage/storageAccounts")
                                .WithCondition(MetricAlertRuleTimeAggregation.Average, MetricAlertRuleCondition.GreaterThan, 200)
                                .WithDimension("ApiName", "GetBlob")
                                .Attach()
                            .Apply();

                    Assert.NotNull(ma);
                    Assert.Equal(1, ma.Scopes.Count);
                    Assert.Equal(sa.Id, ma.Scopes.First());
                    Assert.Equal("This alert rule is for U3 - Single resource  multiple-criteria  with dimensions-single timeseries", ma.Description);
                    Assert.Equal(TimeSpan.FromMinutes(15), ma.WindowSize);
                    Assert.Equal(TimeSpan.FromMinutes(1), ma.EvaluationFrequency);
                    Assert.Equal(3, ma.Severity);
                    Assert.False(ma.Enabled);
                    Assert.True(ma.AutoMitigate);
                    Assert.Equal(1, ma.ActionGroupIds.Count);
                    Assert.Equal(ag.Id, ma.ActionGroupIds.First());
                    Assert.Equal(2, ma.AlertCriterias.Count);
                    ac1 = ma.AlertCriterias.Values.ElementAt(0);
                    var ac2 = ma.AlertCriterias.Values.ElementAt(1);
                    Assert.Equal("Metric1", ac1.Name);
                    Assert.Equal("Transactions", ac1.MetricName);
                    Assert.Equal(MetricAlertRuleCondition.GreaterThan, ac1.Condition);
                    Assert.Equal(MetricAlertRuleTimeAggregation.Total, ac1.TimeAggregation);
                    Assert.Equal(99.0, ac1.Threshold, 4);
                    Assert.Equal(2, ac1.Dimensions.Count);
                    d1 = ac1.Dimensions.ElementAt(0);
                    d2 = ac1.Dimensions.ElementAt(1);
                    Assert.Equal("ResponseType", d1.Name);
                    Assert.Equal(1, d1.Values.Count);
                    Assert.Equal("Success", d1.Values.First());
                    Assert.Equal("ApiName", d2.Name);
                    Assert.Equal(1, d2.Values.Count);
                    Assert.Equal("GetBlob", d2.Values.First());

                    Assert.Equal("Metric2", ac2.Name);
                    Assert.Equal("SuccessE2ELatency", ac2.MetricName);
                    Assert.Equal("Microsoft.Storage/storageAccounts", ac2.MetricNamespace);
                    Assert.Equal(MetricAlertRuleCondition.GreaterThan, ac2.Condition);
                    Assert.Equal(MetricAlertRuleTimeAggregation.Average, ac2.TimeAggregation);
                    Assert.Equal(200.0, ac2.Threshold, 4);
                    Assert.Equal(1, ac2.Dimensions.Count);
                    d1 = ac2.Dimensions.First();
                    Assert.Equal("ApiName", d1.Name);
                    Assert.Equal(1, d1.Values.Count);
                    Assert.Equal("GetBlob", d1.Values.First());

                    maFromGet = azure.AlertRules.MetricAlerts.GetById(ma.Id);

                    Assert.NotNull(maFromGet);
                    Assert.Equal(1, maFromGet.Scopes.Count);
                    Assert.Equal(sa.Id, maFromGet.Scopes.First());
                    Assert.Equal("This alert rule is for U3 - Single resource  multiple-criteria  with dimensions-single timeseries", ma.Description);
                    Assert.Equal(TimeSpan.FromMinutes(15), maFromGet.WindowSize);
                    Assert.Equal(TimeSpan.FromMinutes(1), maFromGet.EvaluationFrequency);
                    Assert.Equal(3, maFromGet.Severity);
                    Assert.False(maFromGet.Enabled);
                    Assert.True(maFromGet.AutoMitigate);
                    Assert.Equal(1, maFromGet.ActionGroupIds.Count);
                    Assert.Equal(ag.Id, maFromGet.ActionGroupIds.First());
                    Assert.Equal(2, maFromGet.AlertCriterias.Count);

                    ac1 = maFromGet.AlertCriterias.Values.ElementAt(0);
                    ac2 = maFromGet.AlertCriterias.Values.ElementAt(1);
                    Assert.Equal("Metric1", ac1.Name);
                    Assert.Equal("Transactions", ac1.MetricName);
                    Assert.Equal(MetricAlertRuleCondition.GreaterThan, ac1.Condition);
                    Assert.Equal(MetricAlertRuleTimeAggregation.Total, ac1.TimeAggregation);
                    Assert.Equal(99.0, ac1.Threshold, 4);
                    Assert.Equal(2, ac1.Dimensions.Count);

                    d1 = ac1.Dimensions.ElementAt(0);
                    d2 = ac1.Dimensions.ElementAt(1);
                    Assert.Equal("ResponseType", d1.Name);
                    Assert.Equal(1, d1.Values.Count);
                    Assert.Equal("Success", d1.Values.First());
                    Assert.Equal("ApiName", d2.Name);
                    Assert.Equal(1, d2.Values.Count);
                    Assert.Equal("GetBlob", d2.Values.First());

                    Assert.Equal("Metric2", ac2.Name);
                    Assert.Equal("SuccessE2ELatency", ac2.MetricName);
                    Assert.Equal("Microsoft.Storage/storageAccounts", ac2.MetricNamespace);
                    Assert.Equal(MetricAlertRuleCondition.GreaterThan, ac2.Condition);
                    Assert.Equal(MetricAlertRuleTimeAggregation.Average, ac2.TimeAggregation);
                    Assert.Equal(200.0, ac2.Threshold, 4);
                    Assert.Equal(1, ac2.Dimensions.Count);
                    d1 = ac2.Dimensions.ElementAt(0);
                    Assert.Equal("ApiName", d1.Name);
                    Assert.Equal(1, d1.Values.Count);
                    Assert.Equal("GetBlob", d1.Values.First());

                    var alertsInRg = azure.AlertRules.MetricAlerts.ListByResourceGroup(rgName);

                    Assert.Single(alertsInRg);
                    maFromGet = alertsInRg.First();

                    Assert.NotNull(maFromGet);
                    Assert.Equal(1, maFromGet.Scopes.Count);
                    Assert.Equal(sa.Id, maFromGet.Scopes.First());
                    Assert.Equal("This alert rule is for U3 - Single resource  multiple-criteria  with dimensions-single timeseries", ma.Description);
                    Assert.Equal(TimeSpan.FromMinutes(15), maFromGet.WindowSize);
                    Assert.Equal(TimeSpan.FromMinutes(1), maFromGet.EvaluationFrequency);
                    Assert.Equal(3, maFromGet.Severity);
                    Assert.False(maFromGet.Enabled);
                    Assert.True(maFromGet.AutoMitigate);
                    Assert.Equal(1, maFromGet.ActionGroupIds.Count);
                    Assert.Equal(ag.Id, maFromGet.ActionGroupIds.First());
                    Assert.Equal(2, maFromGet.AlertCriterias.Count);

                    ac1 = maFromGet.AlertCriterias.Values.ElementAt(0);
                    ac2 = maFromGet.AlertCriterias.Values.ElementAt(1);
                    Assert.Equal("Metric1", ac1.Name);
                    Assert.Equal("Transactions", ac1.MetricName);
                    Assert.Equal(MetricAlertRuleCondition.GreaterThan, ac1.Condition);
                    Assert.Equal(MetricAlertRuleTimeAggregation.Total, ac1.TimeAggregation);
                    Assert.Equal(99.0, ac1.Threshold, 4);
                    Assert.Equal(2, ac1.Dimensions.Count);
                    d1 = ac1.Dimensions.ElementAt(0);
                    d2 = ac1.Dimensions.ElementAt(1);
                    Assert.Equal("ResponseType", d1.Name);
                    Assert.Equal(1, d1.Values.Count);
                    Assert.Equal("Success", d1.Values.First());
                    Assert.Equal("ApiName", d2.Name);
                    Assert.Equal(1, d2.Values.Count);
                    Assert.Equal("GetBlob", d2.Values.First());

                    Assert.Equal("Metric2", ac2.Name);
                    Assert.Equal("SuccessE2ELatency", ac2.MetricName);
                    Assert.Equal("Microsoft.Storage/storageAccounts", ac2.MetricNamespace);
                    Assert.Equal(MetricAlertRuleCondition.GreaterThan, ac2.Condition);
                    Assert.Equal(MetricAlertRuleTimeAggregation.Average, ac2.TimeAggregation);
                    Assert.Equal(200.0, ac2.Threshold, 4);
                    Assert.Equal(1, ac2.Dimensions.Count);
                    d1 = ac2.Dimensions.First();
                    Assert.Equal("ApiName", d1.Name);
                    Assert.Equal(1, d1.Values.Count);
                    Assert.Equal("GetBlob", d1.Values.First());

                    azure.AlertRules.MetricAlerts.DeleteById(ma.Id);
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
        public void CanCRUDMultipleResourceMetricAlerts()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string userName = "tirekicker";
                string password = TestUtilities.GenerateName("Pa5$");

                var rgName = SdkContext.RandomResourceName("jMonitor_", 18);
                var alertName = SdkContext.RandomResourceName("jMonitorMA", 18);
                var vmName1 = SdkContext.RandomResourceName("jMonitorVM1", 18);
                var vmName2 = SdkContext.RandomResourceName("jMonitorVM2", 18);
                var azure = TestHelper.CreateRollupClient();

                try
                {
                    var vm1 = azure.VirtualMachines.Define(vmName1)
                        .WithRegion(Region.USEast2)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(userName)
                        .WithRootPassword(password)
                        .Create();

                    var vm2 = azure.VirtualMachines.Define(vmName2)
                        .WithRegion(Region.USEast2)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(userName)
                        .WithRootPassword(password)
                        .Create();

                    var ma = azure.AlertRules.MetricAlerts.Define(alertName)
                        .WithExistingResourceGroup(rgName)
                        .WithMultipleTargetResources(new IVirtualMachine[] { vm1, vm2 })
                        .WithPeriod(TimeSpan.FromMinutes(15))
                        .WithFrequency(TimeSpan.FromMinutes(15))
                        .WithAlertDetails(3, "This alert rule is for U3 - Multiple resource, static criteria")
                        .WithActionGroups()
                        .DefineAlertCriteria("Metric1")
                            .WithMetricName("Percentage CPU", vm1.Type)
                            .WithCondition(MetricAlertRuleTimeAggregation.Average, MetricAlertRuleCondition.GreaterThan, 80)
                            .Attach()
                        .Create();

                    ma.Refresh();
                    Assert.Equal(2, ma.Scopes.Count);
                    Assert.Equal(vm1.Type, ma.Inner.TargetResourceType);
                    Assert.Equal(vm1.RegionName, ma.Inner.TargetResourceRegion);
                    Assert.Single(ma.AlertCriterias);
                    Assert.Empty(ma.DynamicAlertCriterias);
                    Assert.Equal("Percentage CPU", ma.AlertCriterias["Metric1"].MetricName);

                    DateTime time30MinBefore = DateTime.Now.AddMinutes(-30);
                    ma.Update()
                        .WithDescription("This alert rule is for U3 - Multiple resource, dynamic criteria")
                        .WithoutAlertCriteria("Metric1")
                        .DefineDynamicAlertCriteria("Metric2")
                            .WithMetricName("Percentage CPU", vm1.Type)
                            .WithCondition(MetricAlertRuleTimeAggregation.Average, DynamicThresholdOperator.GreaterThan, DynamicThresholdSensitivity.High)
                            .WithFailingPeriods(new DynamicThresholdFailingPeriods() { NumberOfEvaluationPeriods = 4, MinFailingPeriodsToAlert = 2 })
                            .WithIgnoreDataBefore(time30MinBefore)
                            .Attach()
                        .Apply();

                    ma.Refresh();
                    Assert.Equal(2, ma.Scopes.Count);
                    Assert.Equal(vm1.Type, ma.Inner.TargetResourceType);
                    Assert.Equal(vm1.RegionName, ma.Inner.TargetResourceRegion);
                    Assert.Empty(ma.AlertCriterias);
                    Assert.Single(ma.DynamicAlertCriterias);
                    var condition = ma.DynamicAlertCriterias["Metric2"];
                    Assert.Equal("Percentage CPU", condition.MetricName);
                    Assert.Equal(MetricAlertRuleTimeAggregation.Average, condition.TimeAggregation);
                    Assert.Equal(DynamicThresholdOperator.GreaterThan, condition.Condition);
                    Assert.Equal(DynamicThresholdSensitivity.High, condition.AlertSensitivity);
                    Assert.Equal(4, (int)condition.FailingPeriods.NumberOfEvaluationPeriods);
                    Assert.Equal(2, (int)condition.FailingPeriods.MinFailingPeriodsToAlert);
                    Assert.Equal(time30MinBefore, condition.IgnoreDataBefore);

                    azure.AlertRules.MetricAlerts.DeleteById(ma.Id);
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
        public void CanCRUDActivityLogAlerts()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = SdkContext.RandomResourceName("jMonitor_", 18);
                var saName = SdkContext.RandomResourceName("jMonitorSa", 18);
                var dsName = SdkContext.RandomResourceName("jMonitorDs_", 18);
                var ehName = SdkContext.RandomResourceName("jMonitorEH", 18);
                var azure = TestHelper.CreateRollupClient();

                try
                {
                    var ag = azure.ActionGroups.Define("simpleActionGroup")
                            .WithNewResourceGroup(rgName, Region.USEast2)
                            .DefineReceiver("first")
                                .WithPushNotification("azurepush@outlook.com")
                                .WithEmail("justemail@outlook.com")
                                .WithSms("1", "4255655665")
                                .WithVoice("1", "2062066050")
                                .WithWebhook("https://www.rate.am")
                                .Attach()
                            .DefineReceiver("second")
                                .WithEmail("secondemail@outlook.com")
                                .WithWebhook("https://www.spyur.am")
                                .Attach()
                            .Create();

                    var justAvm = azure.VirtualMachines.List().First();

                    var ala = azure.AlertRules.ActivityLogAlerts.Define("somename")
                            .WithExistingResourceGroup(rgName)
                            .WithTargetSubscription(azure.SubscriptionId)
                            .WithDescription("AutoScale-VM-Creation-Failed")
                            .WithRuleEnabled()
                            .WithActionGroups(ag.Id)
                            .WithEqualsCondition("category", "Administrative")
                            .WithEqualsCondition("resourceId", justAvm.Id)
                            .WithEqualsCondition("operationName", "Microsoft.Compute/virtualMachines/delete")
                            .Create();

                    Assert.NotNull(ala);
                    Assert.Equal(1, ala.Scopes.Count);
                    Assert.Equal("/subscriptions/" + azure.SubscriptionId, ala.Scopes.First());
                    Assert.Equal("AutoScale-VM-Creation-Failed", ala.Description);
                    Assert.True(ala.Enabled);
                    Assert.Equal(1, ala.ActionGroupIds.Count);
                    Assert.Equal(ag.Id, ala.ActionGroupIds.First());
                    Assert.Equal(3, ala.EqualsConditions.Count);
                    Assert.Equal("Administrative", ala.EqualsConditions["category"]);
                    Assert.Equal(justAvm.Id, ala.EqualsConditions["resourceId"]);
                    Assert.Equal("Microsoft.Compute/virtualMachines/delete", ala.EqualsConditions["operationName"]);

                    var alaFromGet = azure.AlertRules.ActivityLogAlerts.GetById(ala.Id);

                    Assert.Equal(ala.Scopes.Count, alaFromGet.Scopes.Count);
                    Assert.Equal(ala.Scopes.First(), alaFromGet.Scopes.First());
                    Assert.Equal(ala.Description, alaFromGet.Description);
                    Assert.Equal(ala.Enabled, alaFromGet.Enabled);
                    Assert.Equal(ala.ActionGroupIds.Count, alaFromGet.ActionGroupIds.Count);
                    Assert.Equal(ala.ActionGroupIds.First(), alaFromGet.ActionGroupIds.First());
                    Assert.Equal(ala.EqualsConditions.Count, alaFromGet.EqualsConditions.Count);
                    Assert.Equal(ala.EqualsConditions["category"], alaFromGet.EqualsConditions["category"]);
                    Assert.Equal(ala.EqualsConditions["resourceId"], alaFromGet.EqualsConditions["resourceId"]);
                    Assert.Equal(ala.EqualsConditions["operationName"], alaFromGet.EqualsConditions["operationName"]);

                    ala.Update()
                            .WithRuleDisabled()
                            .WithoutEqualsCondition("operationName")
                            .WithEqualsCondition("status", "Failed")
                            .Apply();

                    Assert.Equal(1, ala.Scopes.Count);
                    Assert.Equal("/subscriptions/" + azure.SubscriptionId, ala.Scopes.First());
                    Assert.Equal("AutoScale-VM-Creation-Failed", ala.Description);
                    Assert.False(ala.Enabled);
                    Assert.Equal(1, ala.ActionGroupIds.Count);
                    Assert.Equal(ag.Id, ala.ActionGroupIds.First());
                    Assert.Equal(3, ala.EqualsConditions.Count);
                    Assert.Equal("Administrative", ala.EqualsConditions["category"]);
                    Assert.Equal(justAvm.Id, ala.EqualsConditions["resourceId"]);
                    Assert.Equal("Failed", ala.EqualsConditions["status"]);
                    Assert.False(ala.EqualsConditions.ContainsKey("operationName"));

                    var alertsInRg = azure.AlertRules.ActivityLogAlerts.ListByResourceGroup(rgName);

                    Assert.Single(alertsInRg);
                    alaFromGet = alertsInRg.First();

                    Assert.Equal(ala.Scopes.Count, alaFromGet.Scopes.Count);
                    Assert.Equal(ala.Scopes.First(), alaFromGet.Scopes.First());
                    Assert.Equal(ala.Description, alaFromGet.Description);
                    Assert.Equal(ala.Enabled, alaFromGet.Enabled);
                    Assert.Equal(ala.ActionGroupIds.Count, alaFromGet.ActionGroupIds.Count);
                    Assert.Equal(ala.ActionGroupIds.First(), alaFromGet.ActionGroupIds.First());
                    Assert.Equal(ala.EqualsConditions.Count, alaFromGet.EqualsConditions.Count);
                    Assert.Equal(ala.EqualsConditions["category"], alaFromGet.EqualsConditions["category"]);
                    Assert.Equal(ala.EqualsConditions["resourceId"], alaFromGet.EqualsConditions["resourceId"]);
                    Assert.Equal(ala.EqualsConditions["status"], alaFromGet.EqualsConditions["status"]);
                    Assert.Equal(ala.EqualsConditions.ContainsKey("operationName"), alaFromGet.EqualsConditions.ContainsKey("operationName"));

                    azure.AlertRules.ActivityLogAlerts.DeleteById(ala.Id);
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
        public void CanCRUDAutoscale()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = SdkContext.RandomResourceName("jMonitor_", 18);
                var saName = SdkContext.RandomResourceName("jMonitorSa", 18);
                var dsName = SdkContext.RandomResourceName("jMonitorDs_", 18);
                var ehName = SdkContext.RandomResourceName("jMonitorEH", 18);

                var azure = TestHelper.CreateRollupClient();
                var appServiceManager = TestHelper.CreateAppServiceManager();

                try
                {
                    azure.ResourceGroups.Define(rgName)
                            .WithRegion(Region.USEast2)
                            .WithTag("type", "autoscale")
                            .WithTag("tagname", "tagvalue")
                            .Create();

                    var servicePlan = appServiceManager.AppServicePlans.Define("HighlyAvailableWebApps")
                            .WithRegion(Region.USEast2)
                            .WithExistingResourceGroup(rgName)
                            .WithPricingTier(PricingTier.PremiumP1)
                            .WithOperatingSystem(Microsoft.Azure.Management.AppService.Fluent.OperatingSystem.Windows)
                            .Create();

                    var setting = azure.AutoscaleSettings
                            .Define("somesettingZ")
                            .WithRegion(Region.USEast2)
                            .WithExistingResourceGroup(rgName)
                            .WithTargetResource(servicePlan.Id)

                            .DefineAutoscaleProfile("Default")
                                .WithScheduleBasedScale(3)
                                .WithRecurrentSchedule("UTC", "18:00", DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Saturday)
                                .Attach()

                            .DefineAutoscaleProfile("AutoScaleProfile1")
                                .WithMetricBasedScale(1, 10, 1)
                                .DefineScaleRule()
                                    .WithMetricSource(servicePlan.Id)
                                    // current swagger does not support namespace selection
                                    //.withMetricName("CPUPercentage", "Microsoft.Web/serverfarms")
                                    .WithMetricName("CPUPercentage")
                                    .WithStatistic(TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(1), MetricStatisticType.Average)
                                    .WithCondition(TimeAggregationType.Average, ComparisonOperationType.GreaterThan, 70)
                                    .WithScaleAction(ScaleDirection.Increase, ScaleType.ExactCount, 10, TimeSpan.FromHours(12))
                                    .Attach()
                                .WithFixedDateSchedule("UTC", DateTime.Parse("2050-10-12T20:15:10Z"), DateTime.Parse("2051-09-11T16:08:04Z"))
                                .Attach()

                            .DefineAutoscaleProfile("AutoScaleProfile2")
                                .WithMetricBasedScale(1, 5, 3)
                                .DefineScaleRule()
                                    .WithMetricSource(servicePlan.Id)
                                    .WithMetricName("CPUPercentage")
                                    .WithStatistic(TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(1), MetricStatisticType.Average)
                                    .WithCondition(TimeAggregationType.Average, ComparisonOperationType.LessThan, 20)
                                    .WithScaleAction(ScaleDirection.Decrease, ScaleType.ExactCount, 1, TimeSpan.FromHours(3))
                                    .Attach()
                                .WithRecurrentSchedule("UTC", "12:13", DayOfWeek.Friday)
                                .Attach()

                            .WithAdminEmailNotification()
                            .WithCoAdminEmailNotification()
                            .WithCustomEmailsNotification("me@mycorp.com", "you@mycorp.com", "him@mycorp.com")
                            .WithAutoscaleDisabled()
                            .Create();

                    Assert.NotNull(setting);
                    Assert.Equal("somesettingZ", setting.Name);
                    Assert.Equal(servicePlan.Id, setting.TargetResourceId);
                    Assert.True(setting.AdminEmailNotificationEnabled);
                    Assert.True(setting.CoAdminEmailNotificationEnabled);
                    Assert.False(setting.AutoscaleEnabled);
                    Assert.Equal(3, setting.CustomEmailsNotification.Count);
                    Assert.Equal("me@mycorp.com", setting.CustomEmailsNotification[0]);
                    Assert.Equal("you@mycorp.com", setting.CustomEmailsNotification[1]);
                    Assert.Equal("him@mycorp.com", setting.CustomEmailsNotification[2]);

                    Assert.Equal(3, setting.Profiles.Count);

                    var tempProfile = setting.Profiles["Default"];
                    Assert.NotNull(tempProfile);
                    Assert.Equal("Default", tempProfile.Name);
                    Assert.Equal(3, tempProfile.DefaultInstanceCount);
                    Assert.Equal(3, tempProfile.MaxInstanceCount);
                    Assert.Equal(3, tempProfile.MinInstanceCount);
                    Assert.Null(tempProfile.FixedDateSchedule);
                    Assert.NotNull(tempProfile.Rules);
                    Assert.Equal(0, tempProfile.Rules.Count);
                    Assert.NotNull(tempProfile.RecurrentSchedule);
                    Assert.Equal(RecurrenceFrequency.Week, tempProfile.RecurrentSchedule.Frequency);
                    Assert.NotNull(tempProfile.RecurrentSchedule.Schedule);
                    Assert.Equal(3, tempProfile.RecurrentSchedule.Schedule.Days.Count);
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Days.Contains(DayOfWeek.Monday.ToString()));
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Days.Contains(DayOfWeek.Tuesday.ToString()));
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Days.Contains(DayOfWeek.Saturday.ToString()));
                    Assert.Equal(1, tempProfile.RecurrentSchedule.Schedule.Hours.Count);
                    Assert.Equal(1, tempProfile.RecurrentSchedule.Schedule.Minutes.Count);
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Hours.Contains(18));
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Minutes.Contains(0));
                    Assert.Equal("UTC", tempProfile.RecurrentSchedule.Schedule.TimeZone, ignoreCase: true);

                    tempProfile = setting.Profiles["AutoScaleProfile1"];
                    Assert.NotNull(tempProfile);
                    Assert.Equal("AutoScaleProfile1", tempProfile.Name);
                    Assert.Equal(1, tempProfile.DefaultInstanceCount);
                    Assert.Equal(10, tempProfile.MaxInstanceCount);
                    Assert.Equal(1, tempProfile.MinInstanceCount);
                    Assert.NotNull(tempProfile.FixedDateSchedule);
                    Assert.Equal("UTC", tempProfile.FixedDateSchedule.TimeZone, ignoreCase: true);
                    Assert.Null(tempProfile.RecurrentSchedule);
                    Assert.NotNull(tempProfile.Rules);
                    Assert.Equal(1, tempProfile.Rules.Count);
                    var rule = tempProfile.Rules[0];
                    Assert.Equal(servicePlan.Id, rule.MetricSource);
                    Assert.Equal("CPUPercentage", rule.MetricName);
                    Assert.Equal(TimeSpan.FromMinutes(10), rule.Duration);
                    Assert.Equal(TimeSpan.FromMinutes(1), rule.Frequency);
                    Assert.Equal(MetricStatisticType.Average, rule.FrequencyStatistic);
                    Assert.Equal(ComparisonOperationType.GreaterThan, rule.Condition);
                    Assert.Equal(TimeAggregationType.Average, rule.TimeAggregation);
                    Assert.Equal(70d, rule.Threshold, 4);
                    Assert.Equal(ScaleDirection.Increase, rule.ScaleDirection);
                    Assert.Equal(ScaleType.ExactCount, rule.ScaleType);
                    Assert.Equal(10, rule.ScaleInstanceCount);
                    Assert.Equal(TimeSpan.FromHours(12), rule.CoolDown);

                    tempProfile = setting.Profiles["AutoScaleProfile2"];
                    Assert.NotNull(tempProfile);
                    Assert.Equal("AutoScaleProfile2", tempProfile.Name);
                    Assert.Equal(3, tempProfile.DefaultInstanceCount);
                    Assert.Equal(5, tempProfile.MaxInstanceCount);
                    Assert.Equal(1, tempProfile.MinInstanceCount);
                    Assert.Null(tempProfile.FixedDateSchedule);
                    Assert.NotNull(tempProfile.RecurrentSchedule.Schedule);
                    Assert.Equal(1, tempProfile.RecurrentSchedule.Schedule.Days.Count);
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Days.Contains(DayOfWeek.Friday.ToString()));
                    Assert.Equal(1, tempProfile.RecurrentSchedule.Schedule.Hours.Count);
                    Assert.Equal(1, tempProfile.RecurrentSchedule.Schedule.Minutes.Count);
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Hours.Contains(12));
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Minutes.Contains(13));
                    Assert.Equal("UTC", tempProfile.RecurrentSchedule.Schedule.TimeZone, ignoreCase: true);

                    Assert.NotNull(tempProfile.Rules);
                    Assert.Equal(1, tempProfile.Rules.Count);
                    rule = tempProfile.Rules[0];
                    Assert.Equal(servicePlan.Id, rule.MetricSource);
                    Assert.Equal("CPUPercentage", rule.MetricName);
                    Assert.Equal(TimeSpan.FromMinutes(10), rule.Duration);
                    Assert.Equal(TimeSpan.FromMinutes(1), rule.Frequency);
                    Assert.Equal(MetricStatisticType.Average, rule.FrequencyStatistic);
                    Assert.Equal(ComparisonOperationType.LessThan, rule.Condition);
                    Assert.Equal(TimeAggregationType.Average, rule.TimeAggregation);
                    Assert.Equal(20d, rule.Threshold, 4);
                    Assert.Equal(ScaleDirection.Decrease, rule.ScaleDirection);
                    Assert.Equal(ScaleType.ExactCount, rule.ScaleType);
                    Assert.Equal(1, rule.ScaleInstanceCount);
                    Assert.Equal(TimeSpan.FromHours(3), rule.CoolDown);

                    // GET Autoscale settings and compare
                    var settingFromGet = azure.AutoscaleSettings.GetById(setting.Id);
                    Assert.NotNull(settingFromGet);
                    Assert.Equal("somesettingZ", settingFromGet.Name);
                    Assert.Equal(servicePlan.Id, settingFromGet.TargetResourceId);
                    Assert.True(settingFromGet.AdminEmailNotificationEnabled);
                    Assert.True(settingFromGet.CoAdminEmailNotificationEnabled);
                    Assert.False(settingFromGet.AutoscaleEnabled);
                    Assert.Equal(3, settingFromGet.CustomEmailsNotification.Count);
                    Assert.Equal("me@mycorp.com", settingFromGet.CustomEmailsNotification[0]);
                    Assert.Equal("you@mycorp.com", settingFromGet.CustomEmailsNotification[1]);
                    Assert.Equal("him@mycorp.com", settingFromGet.CustomEmailsNotification[2]);

                    Assert.Equal(3, settingFromGet.Profiles.Count);

                    tempProfile = settingFromGet.Profiles["Default"];
                    Assert.NotNull(tempProfile);
                    Assert.Equal("Default", tempProfile.Name);
                    Assert.Equal(3, tempProfile.DefaultInstanceCount);
                    Assert.Equal(3, tempProfile.MaxInstanceCount);
                    Assert.Equal(3, tempProfile.MinInstanceCount);
                    Assert.Null(tempProfile.FixedDateSchedule);
                    Assert.NotNull(tempProfile.Rules);
                    Assert.Equal(0, tempProfile.Rules.Count);
                    Assert.NotNull(tempProfile.RecurrentSchedule);
                    Assert.Equal(RecurrenceFrequency.Week, tempProfile.RecurrentSchedule.Frequency);
                    Assert.NotNull(tempProfile.RecurrentSchedule.Schedule);
                    Assert.Equal(3, tempProfile.RecurrentSchedule.Schedule.Days.Count);
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Days.Contains(DayOfWeek.Monday.ToString()));
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Days.Contains(DayOfWeek.Tuesday.ToString()));
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Days.Contains(DayOfWeek.Saturday.ToString()));
                    Assert.Equal(1, tempProfile.RecurrentSchedule.Schedule.Hours.Count);
                    Assert.Equal(1, tempProfile.RecurrentSchedule.Schedule.Minutes.Count);
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Hours.Contains(18));
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Minutes.Contains(0));
                    Assert.Equal("UTC", tempProfile.RecurrentSchedule.Schedule.TimeZone, ignoreCase: true);

                    tempProfile = settingFromGet.Profiles["AutoScaleProfile1"];
                    Assert.NotNull(tempProfile);
                    Assert.Equal("AutoScaleProfile1", tempProfile.Name);
                    Assert.Equal(1, tempProfile.DefaultInstanceCount);
                    Assert.Equal(10, tempProfile.MaxInstanceCount);
                    Assert.Equal(1, tempProfile.MinInstanceCount);
                    Assert.NotNull(tempProfile.FixedDateSchedule);
                    Assert.Equal("UTC", tempProfile.FixedDateSchedule.TimeZone, ignoreCase: true);
                    Assert.Null(tempProfile.RecurrentSchedule);
                    Assert.NotNull(tempProfile.Rules);
                    Assert.Equal(1, tempProfile.Rules.Count);
                    rule = tempProfile.Rules[0];
                    Assert.Equal(servicePlan.Id, rule.MetricSource);
                    Assert.Equal("CPUPercentage", rule.MetricName);
                    Assert.Equal(TimeSpan.FromMinutes(10), rule.Duration);
                    Assert.Equal(TimeSpan.FromMinutes(1), rule.Frequency);
                    Assert.Equal(MetricStatisticType.Average, rule.FrequencyStatistic);
                    Assert.Equal(ComparisonOperationType.GreaterThan, rule.Condition);
                    Assert.Equal(TimeAggregationType.Average, rule.TimeAggregation);
                    Assert.Equal(70d, rule.Threshold, 4);
                    Assert.Equal(ScaleDirection.Increase, rule.ScaleDirection);
                    Assert.Equal(ScaleType.ExactCount, rule.ScaleType);
                    Assert.Equal(10, rule.ScaleInstanceCount);
                    Assert.Equal(TimeSpan.FromHours(12), rule.CoolDown);

                    tempProfile = settingFromGet.Profiles["AutoScaleProfile2"];
                    Assert.NotNull(tempProfile);
                    Assert.Equal("AutoScaleProfile2", tempProfile.Name);
                    Assert.Equal(3, tempProfile.DefaultInstanceCount);
                    Assert.Equal(5, tempProfile.MaxInstanceCount);
                    Assert.Equal(1, tempProfile.MinInstanceCount);
                    Assert.Null(tempProfile.FixedDateSchedule);
                    Assert.NotNull(tempProfile.RecurrentSchedule.Schedule);
                    Assert.Equal(1, tempProfile.RecurrentSchedule.Schedule.Days.Count);
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Days.Contains(DayOfWeek.Friday.ToString()));
                    Assert.Equal(1, tempProfile.RecurrentSchedule.Schedule.Hours.Count);
                    Assert.Equal(1, tempProfile.RecurrentSchedule.Schedule.Minutes.Count);
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Hours.Contains(12));
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Minutes.Contains(13));
                    Assert.Equal("UTC", tempProfile.RecurrentSchedule.Schedule.TimeZone, ignoreCase: true);

                    Assert.NotNull(tempProfile.Rules);
                    Assert.Equal(1, tempProfile.Rules.Count);
                    rule = tempProfile.Rules[0];
                    Assert.Equal(servicePlan.Id, rule.MetricSource);
                    Assert.Equal("CPUPercentage", rule.MetricName);
                    Assert.Equal(TimeSpan.FromMinutes(10), rule.Duration);
                    Assert.Equal(TimeSpan.FromMinutes(1), rule.Frequency);
                    Assert.Equal(MetricStatisticType.Average, rule.FrequencyStatistic);
                    Assert.Equal(ComparisonOperationType.LessThan, rule.Condition);
                    Assert.Equal(TimeAggregationType.Average, rule.TimeAggregation);
                    Assert.Equal(20d, rule.Threshold, 4);
                    Assert.Equal(ScaleDirection.Decrease, rule.ScaleDirection);
                    Assert.Equal(ScaleType.ExactCount, rule.ScaleType);
                    Assert.Equal(1, rule.ScaleInstanceCount);
                    Assert.Equal(TimeSpan.FromHours(3), rule.CoolDown);

                    // Update
                    setting.Update()
                            .DefineAutoscaleProfile("very new profile")
                                .WithScheduleBasedScale(10)
                                .WithFixedDateSchedule("UTC", DateTime.Parse("2030-02-12T20:15:10Z"), DateTime.Parse("2030-02-12T20:45:10Z"))
                                .Attach()

                            .DefineAutoscaleProfile("a new profile")
                                .WithMetricBasedScale(5, 7, 6)
                                .DefineScaleRule()
                                    .WithMetricSource(servicePlan.Id)
                                    .WithMetricName("CPUPercentage")
                                    .WithStatistic(TimeSpan.FromHours(10), TimeSpan.FromHours(1), MetricStatisticType.Average)
                                    .WithCondition(TimeAggregationType.Total, ComparisonOperationType.LessThan, 6)
                                    .WithScaleAction(ScaleDirection.Decrease, ScaleType.PercentChangeCount, 10, TimeSpan.FromHours(10))
                                    .Attach()
                                .Attach()

                            .UpdateAutoscaleProfile("AutoScaleProfile2")
                                .UpdateScaleRule(0)
                                    .WithStatistic(TimeSpan.FromMinutes(15), TimeSpan.FromMinutes(1), MetricStatisticType.Average)
                                    .Parent()
                                .WithFixedDateSchedule("UTC", DateTime.Parse("2025-02-02T02:02:02Z"), DateTime.Parse("2025-02-02T03:03:03Z"))
                                .DefineScaleRule()
                                    .WithMetricSource(servicePlan.Id)
                                    .WithMetricName("CPUPercentage")
                                    .WithStatistic(TimeSpan.FromHours(5), TimeSpan.FromHours(3), MetricStatisticType.Average)
                                    .WithCondition(TimeAggregationType.Total, ComparisonOperationType.LessThan, 50)
                                    .WithScaleAction(ScaleDirection.Decrease, ScaleType.PercentChangeCount, 25, TimeSpan.FromHours(2))
                                    .Attach()
                                .WithoutScaleRule(1)
                                .Parent()

                            .WithoutAutoscaleProfile("AutoScaleProfile1")

                            .WithAutoscaleEnabled()
                            .WithoutCoAdminEmailNotification()
                            .Apply();

                    Assert.NotNull(setting);
                    Assert.Equal("somesettingZ", setting.Name);
                    Assert.Equal(servicePlan.Id, setting.TargetResourceId);
                    Assert.True(setting.AdminEmailNotificationEnabled);
                    Assert.False(setting.CoAdminEmailNotificationEnabled);
                    Assert.True(setting.AutoscaleEnabled);
                    Assert.Equal(3, setting.CustomEmailsNotification.Count);
                    Assert.Equal("me@mycorp.com", setting.CustomEmailsNotification[0]);
                    Assert.Equal("you@mycorp.com", setting.CustomEmailsNotification[1]);
                    Assert.Equal("him@mycorp.com", setting.CustomEmailsNotification[2]);

                    Assert.Equal(4, setting.Profiles.Count);

                    Assert.False(setting.Profiles.ContainsKey("AutoScaleProfile1"));

                    tempProfile = setting.Profiles["Default"];
                    Assert.NotNull(tempProfile);
                    Assert.Equal("Default", tempProfile.Name);
                    Assert.Equal(3, tempProfile.DefaultInstanceCount);
                    Assert.Equal(3, tempProfile.MaxInstanceCount);
                    Assert.Equal(3, tempProfile.MinInstanceCount);
                    Assert.Null(tempProfile.FixedDateSchedule);
                    Assert.NotNull(tempProfile.Rules);
                    Assert.Equal(0, tempProfile.Rules.Count);
                    Assert.NotNull(tempProfile.RecurrentSchedule);
                    Assert.Equal(RecurrenceFrequency.Week, tempProfile.RecurrentSchedule.Frequency);
                    Assert.NotNull(tempProfile.RecurrentSchedule.Schedule);
                    Assert.Equal(3, tempProfile.RecurrentSchedule.Schedule.Days.Count);
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Days.Contains(DayOfWeek.Monday.ToString()));
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Days.Contains(DayOfWeek.Tuesday.ToString()));
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Days.Contains(DayOfWeek.Saturday.ToString()));
                    Assert.Equal(1, tempProfile.RecurrentSchedule.Schedule.Hours.Count);
                    Assert.Equal(1, tempProfile.RecurrentSchedule.Schedule.Minutes.Count);
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Hours.Contains(18));
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Minutes.Contains(0));
                    Assert.Equal("UTC", tempProfile.RecurrentSchedule.Schedule.TimeZone, ignoreCase: true);

                    tempProfile = setting.Profiles["very new profile"];
                    Assert.NotNull(tempProfile);
                    Assert.Equal("very new profile", tempProfile.Name);
                    Assert.Equal(10, tempProfile.DefaultInstanceCount);
                    Assert.Equal(10, tempProfile.MaxInstanceCount);
                    Assert.Equal(10, tempProfile.MinInstanceCount);
                    Assert.Null(tempProfile.RecurrentSchedule);
                    Assert.NotNull(tempProfile.FixedDateSchedule);
                    Assert.Equal("UTC", tempProfile.FixedDateSchedule.TimeZone, ignoreCase: true);

                    tempProfile = setting.Profiles["a new profile"];
                    Assert.NotNull(tempProfile);
                    Assert.Equal("a new profile", tempProfile.Name);
                    Assert.Equal(6, tempProfile.DefaultInstanceCount);
                    Assert.Equal(7, tempProfile.MaxInstanceCount);
                    Assert.Equal(5, tempProfile.MinInstanceCount);
                    Assert.Null(tempProfile.FixedDateSchedule);
                    Assert.Null(tempProfile.RecurrentSchedule);
                    Assert.NotNull(tempProfile.Rules);
                    Assert.Equal(1, tempProfile.Rules.Count);
                    rule = tempProfile.Rules[0];
                    Assert.Equal(servicePlan.Id, rule.MetricSource);
                    Assert.Equal("CPUPercentage", rule.MetricName);
                    Assert.Equal(TimeSpan.FromHours(10), rule.Duration);
                    Assert.Equal(TimeSpan.FromHours(1), rule.Frequency);
                    Assert.Equal(MetricStatisticType.Average, rule.FrequencyStatistic);
                    Assert.Equal(ComparisonOperationType.LessThan, rule.Condition);
                    Assert.Equal(TimeAggregationType.Total, rule.TimeAggregation);
                    Assert.Equal(6d, rule.Threshold, 4);
                    Assert.Equal(ScaleDirection.Decrease, rule.ScaleDirection);
                    Assert.Equal(ScaleType.PercentChangeCount, rule.ScaleType);
                    Assert.Equal(10, rule.ScaleInstanceCount);
                    Assert.Equal(TimeSpan.FromHours(10), rule.CoolDown);

                    tempProfile = setting.Profiles["AutoScaleProfile2"];
                    Assert.NotNull(tempProfile);
                    Assert.Equal("AutoScaleProfile2", tempProfile.Name);
                    Assert.Equal(3, tempProfile.DefaultInstanceCount);
                    Assert.Equal(5, tempProfile.MaxInstanceCount);
                    Assert.Equal(1, tempProfile.MinInstanceCount);
                    Assert.Null(tempProfile.RecurrentSchedule);
                    Assert.NotNull(tempProfile.FixedDateSchedule);
                    Assert.Equal("UTC", tempProfile.FixedDateSchedule.TimeZone, ignoreCase: true);

                    Assert.NotNull(tempProfile.Rules);
                    Assert.Equal(1, tempProfile.Rules.Count);
                    rule = tempProfile.Rules[0];
                    Assert.Equal(servicePlan.Id, rule.MetricSource);
                    Assert.Equal("CPUPercentage", rule.MetricName);
                    Assert.Equal(TimeSpan.FromMinutes(15), rule.Duration);
                    Assert.Equal(TimeSpan.FromMinutes(1), rule.Frequency);
                    Assert.Equal(MetricStatisticType.Average, rule.FrequencyStatistic);
                    Assert.Equal(ComparisonOperationType.LessThan, rule.Condition);
                    Assert.Equal(TimeAggregationType.Average, rule.TimeAggregation);
                    Assert.Equal(20d, rule.Threshold, 4);
                    Assert.Equal(ScaleDirection.Decrease, rule.ScaleDirection);
                    Assert.Equal(ScaleType.ExactCount, rule.ScaleType);
                    Assert.Equal(1, rule.ScaleInstanceCount);
                    Assert.Equal(TimeSpan.FromHours(3), rule.CoolDown);

                    // List
                    settingFromGet = azure.AutoscaleSettings.ListByResourceGroup(rgName).First();

                    Assert.NotNull(settingFromGet);
                    Assert.Equal("somesettingZ", settingFromGet.Name);
                    Assert.Equal(servicePlan.Id, settingFromGet.TargetResourceId);
                    Assert.True(settingFromGet.AdminEmailNotificationEnabled);
                    Assert.False(settingFromGet.CoAdminEmailNotificationEnabled);
                    Assert.True(settingFromGet.AutoscaleEnabled);
                    Assert.Equal(3, settingFromGet.CustomEmailsNotification.Count);
                    Assert.Equal("me@mycorp.com", settingFromGet.CustomEmailsNotification[0]);
                    Assert.Equal("you@mycorp.com", settingFromGet.CustomEmailsNotification[1]);
                    Assert.Equal("him@mycorp.com", settingFromGet.CustomEmailsNotification[2]);

                    Assert.Equal(4, settingFromGet.Profiles.Count);

                    Assert.False(settingFromGet.Profiles.ContainsKey("AutoScaleProfile1"));

                    tempProfile = settingFromGet.Profiles["Default"];
                    Assert.NotNull(tempProfile);
                    Assert.Equal("Default", tempProfile.Name);
                    Assert.Equal(3, tempProfile.DefaultInstanceCount);
                    Assert.Equal(3, tempProfile.MaxInstanceCount);
                    Assert.Equal(3, tempProfile.MinInstanceCount);
                    Assert.Null(tempProfile.FixedDateSchedule);
                    Assert.NotNull(tempProfile.Rules);
                    Assert.Equal(0, tempProfile.Rules.Count);
                    Assert.NotNull(tempProfile.RecurrentSchedule);
                    Assert.Equal(RecurrenceFrequency.Week, tempProfile.RecurrentSchedule.Frequency);
                    Assert.NotNull(tempProfile.RecurrentSchedule.Schedule);
                    Assert.Equal(3, tempProfile.RecurrentSchedule.Schedule.Days.Count);
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Days.Contains(DayOfWeek.Monday.ToString()));
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Days.Contains(DayOfWeek.Tuesday.ToString()));
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Days.Contains(DayOfWeek.Saturday.ToString()));
                    Assert.Equal(1, tempProfile.RecurrentSchedule.Schedule.Hours.Count);
                    Assert.Equal(1, tempProfile.RecurrentSchedule.Schedule.Minutes.Count);
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Hours.Contains(18));
                    Assert.True(tempProfile.RecurrentSchedule.Schedule.Minutes.Contains(0));
                    Assert.Equal("UTC", tempProfile.RecurrentSchedule.Schedule.TimeZone, ignoreCase: true);

                    tempProfile = settingFromGet.Profiles["very new profile"];
                    Assert.NotNull(tempProfile);
                    Assert.Equal("very new profile", tempProfile.Name);
                    Assert.Equal(10, tempProfile.DefaultInstanceCount);
                    Assert.Equal(10, tempProfile.MaxInstanceCount);
                    Assert.Equal(10, tempProfile.MinInstanceCount);
                    Assert.Null(tempProfile.RecurrentSchedule);
                    Assert.NotNull(tempProfile.FixedDateSchedule);
                    Assert.Equal("UTC", tempProfile.FixedDateSchedule.TimeZone, ignoreCase: true);

                    tempProfile = settingFromGet.Profiles["a new profile"];
                    Assert.NotNull(tempProfile);
                    Assert.Equal("a new profile", tempProfile.Name);
                    Assert.Equal(6, tempProfile.DefaultInstanceCount);
                    Assert.Equal(7, tempProfile.MaxInstanceCount);
                    Assert.Equal(5, tempProfile.MinInstanceCount);
                    Assert.Null(tempProfile.FixedDateSchedule);
                    Assert.Null(tempProfile.RecurrentSchedule);
                    Assert.NotNull(tempProfile.Rules);
                    Assert.Equal(1, tempProfile.Rules.Count);
                    rule = tempProfile.Rules[0];
                    Assert.Equal(servicePlan.Id, rule.MetricSource);
                    Assert.Equal("CPUPercentage", rule.MetricName);
                    Assert.Equal(TimeSpan.FromHours(10), rule.Duration);
                    Assert.Equal(TimeSpan.FromHours(1), rule.Frequency);
                    Assert.Equal(MetricStatisticType.Average, rule.FrequencyStatistic);
                    Assert.Equal(ComparisonOperationType.LessThan, rule.Condition);
                    Assert.Equal(TimeAggregationType.Total, rule.TimeAggregation);
                    Assert.Equal(6d, rule.Threshold, 4);
                    Assert.Equal(ScaleDirection.Decrease, rule.ScaleDirection);
                    Assert.Equal(ScaleType.PercentChangeCount, rule.ScaleType);
                    Assert.Equal(10, rule.ScaleInstanceCount);
                    Assert.Equal(TimeSpan.FromHours(10), rule.CoolDown);

                    tempProfile = settingFromGet.Profiles["AutoScaleProfile2"];
                    Assert.NotNull(tempProfile);
                    Assert.Equal("AutoScaleProfile2", tempProfile.Name);
                    Assert.Equal(3, tempProfile.DefaultInstanceCount);
                    Assert.Equal(5, tempProfile.MaxInstanceCount);
                    Assert.Equal(1, tempProfile.MinInstanceCount);
                    Assert.Null(tempProfile.RecurrentSchedule);
                    Assert.NotNull(tempProfile.FixedDateSchedule);
                    Assert.Equal("UTC", tempProfile.FixedDateSchedule.TimeZone, ignoreCase: true);

                    Assert.NotNull(tempProfile.Rules);
                    Assert.Equal(1, tempProfile.Rules.Count);
                    rule = tempProfile.Rules[0];
                    Assert.Equal(servicePlan.Id, rule.MetricSource);
                    Assert.Equal("CPUPercentage", rule.MetricName);
                    Assert.Equal(TimeSpan.FromMinutes(15), rule.Duration);
                    Assert.Equal(TimeSpan.FromMinutes(1), rule.Frequency);
                    Assert.Equal(MetricStatisticType.Average, rule.FrequencyStatistic);
                    Assert.Equal(ComparisonOperationType.LessThan, rule.Condition);
                    Assert.Equal(TimeAggregationType.Average, rule.TimeAggregation);
                    Assert.Equal(20d, rule.Threshold, 4);
                    Assert.Equal(ScaleDirection.Decrease, rule.ScaleDirection);
                    Assert.Equal(ScaleType.ExactCount, rule.ScaleType);
                    Assert.Equal(1, rule.ScaleInstanceCount);
                    Assert.Equal(TimeSpan.FromHours(3), rule.CoolDown);

                    // Delete
                    azure.AutoscaleSettings.DeleteById(settingFromGet.Id);

                    var emptyList = azure.AutoscaleSettings.ListByResourceGroup(rgName);
                    Assert.Empty(emptyList);
                }
                finally
                {
                    azure.ResourceGroups.BeginDeleteByName(rgName);
                }
            }
        }


        private void CheckDiagnosticSettingValues(IDiagnosticSetting expected, IDiagnosticSetting actual)
        {
            Assert.Equal(expected.ResourceId, actual.ResourceId, ignoreCase: true);
            Assert.Equal(expected.Name, actual.Name, ignoreCase: true);

            if (expected.WorkspaceId == null)
            {
                Assert.Null(actual.WorkspaceId);
            }
            else
            {
                Assert.Equal(expected.WorkspaceId, actual.WorkspaceId, ignoreCase: true);
            }
            if (expected.StorageAccountId == null)
            {
                Assert.Null(actual.StorageAccountId);
            }
            else
            {
                Assert.Equal(expected.StorageAccountId, actual.StorageAccountId, ignoreCase: true);
            }
            if (expected.EventHubAuthorizationRuleId == null)
            {
                Assert.Null(actual.EventHubAuthorizationRuleId);
            }
            else
            {
                Assert.Equal(expected.EventHubAuthorizationRuleId, actual.EventHubAuthorizationRuleId, ignoreCase: true);
            }
            if (expected.EventHubName == null)
            {
                Assert.Null(actual.EventHubName);
            }
            else
            {
                Assert.Equal(expected.EventHubName, actual.EventHubName, ignoreCase: true);
            }
            // arrays
            if (expected.Logs == null)
            {
                Assert.Null(actual.Logs);
            }
            else
            {
                Assert.Equal(expected.Logs.Count, actual.Logs.Count);
            }
            if (expected.Metrics == null)
            {
                Assert.Null(actual.Metrics);
            }
            else
            {
                Assert.Equal(expected.Metrics.Count, actual.Metrics.Count);
            }
        }
    }
}
