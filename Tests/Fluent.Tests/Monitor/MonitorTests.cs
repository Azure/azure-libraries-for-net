// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.Monitor.Fluent;
using Microsoft.Azure.Management.Monitor.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
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

                // Metric
                var metrics = mt.First().DefineQuery()
                        .StartingFrom(recordDateTime.AddDays(-30))
                        .EndsBefore(recordDateTime)
                        .WithResultType(ResultType.Data)
                        .Execute();

                Assert.NotNull(metrics);

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
    }
}
