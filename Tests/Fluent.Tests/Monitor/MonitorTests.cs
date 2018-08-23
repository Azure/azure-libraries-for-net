// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Monitor.Fluent;
using Microsoft.Azure.Management.Monitor.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;
using System.Net;
using Xunit;

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
                DateTime recordDateTime = new DateTime(2018, 06, 26, 00, 07, 40);
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
                        .StartingFrom(recordDateTime.AddDays(-30))
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
                        .StartingFrom(recordDateTime.AddDays(-30))
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
                            .WithAzureAppPush("azurepush@outlook.com")
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
                    Assert.NotNull(ag.AzureAppPushReceivers);
                    Assert.Equal(1, ag.AzureAppPushReceivers.Count);
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
                                .WithAzureAppPush("azurepush@outlook.com")
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
                            .WithWindowSize(TimeSpan.FromMinutes(15))
                            .WithEvaluationFrequency(TimeSpan.FromMinutes(1))
                            .WithSeverity(3)
                            .WithDescription("This alert rule is for U3 - Single resource  multiple-criteria  with dimensions-single timeseries")
                            .WithRuleEnabled()
                            .WithActionGroups(ag.Id)
                            .DefineAlertCriteria("Metric1")
                                .WithSignalName("Transactions")
                                .WithCondition(MetricAlertRuleCondition.GreaterThan, MetricAlertRuleTimeAggregation.Total, 100)
                                .WithDimensionFilter("ResponseType", "Success")
                                .WithDimensionFilter("ApiName", "GetBlob")
                                .WithMetricNamespace("Microsoft.Storage/storageAccounts")
                                .Attach()
                            .WithAutoMitigation()
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
                    Assert.Equal("Transactions", ac1.SignalName);
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
                    Assert.Equal("Transactions", ac1.SignalName);
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
                                .WithCondition(MetricAlertRuleCondition.GreaterThan, MetricAlertRuleTimeAggregation.Total, 99)
                                .Parent()
                            .DefineAlertCriteria("Metric2")
                                .WithSignalName("SuccessE2ELatency")
                                .WithCondition(MetricAlertRuleCondition.GreaterThan, MetricAlertRuleTimeAggregation.Average, 200)
                                .WithDimensionFilter("ApiName", "GetBlob")
                                .WithMetricNamespace("Microsoft.Storage/storageAccounts")
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
                    Assert.Equal("Transactions", ac1.SignalName);
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
                    Assert.Equal("SuccessE2ELatency", ac2.SignalName);
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
                    Assert.Equal("Transactions", ac1.SignalName);
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
                    Assert.Equal("SuccessE2ELatency", ac2.SignalName);
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
                    Assert.Equal("Transactions", ac1.SignalName);
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
                    Assert.Equal("SuccessE2ELatency", ac2.SignalName);
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
                                .WithAzureAppPush("azurepush@outlook.com")
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
