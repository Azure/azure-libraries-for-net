﻿// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Monitor.Fluent;
using Microsoft.Azure.Management.Monitor.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using System;
using System.Linq;
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
                DateTime recordDateTime = new DateTime(2018, 01, 24, 00, 07, 40);
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
