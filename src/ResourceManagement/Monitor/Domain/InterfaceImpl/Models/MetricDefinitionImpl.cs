// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Monitor.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System;

    internal partial class MetricDefinitionImpl
    {
        /// <summary>
        /// Sets the $filter that is used to reduce the set of metric data returned.
        /// &lt;br&gt;Example:&lt;br&gt;
        /// Metric contains metadata A, B and C.&lt;br&gt;
        /// - Return all time series of C where A = a1 and B = b1 or b2&lt;br&gt;
        /// $filter=A eq ‘a1’ and B eq ‘b1’ or B eq ‘b2’ and C eq ‘’&lt;br&gt;
        /// - Invalid variant:&lt;br&gt;
        /// $filter=A eq ‘a1’ and B eq ‘b1’ and C eq ‘’ or B = ‘b2’&lt;br&gt;
        /// This is invalid because the logical or operator cannot separate two different metadata names.&lt;br&gt;
        /// - Return all time series where A = a1, B = b1 and C = c1:&lt;br&gt;
        /// $filter=A eq ‘a1’ and B eq ‘b1’ and C eq ‘c1’&lt;br&gt;
        /// - Return all time series where A = a1&lt;br&gt;
        /// $filter=A eq ‘a1’ and B eq ‘’ and C eq ‘’.
        /// </summary>
        /// <param name="odataFilter">The $filter to reduce the set of the returned metric data.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute.WithOdataFilter(string odataFilter)
        {
            return this.WithOdataFilter(odataFilter) as Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute;
        }

        /// <summary>
        /// Sets the maximum number of records to retrieve.
        /// Valid only if $filter is specified.
        /// Defaults to 10.
        /// </summary>
        /// <param name="top">The maximum number of records to retrieve.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute.SelectTop(int top)
        {
            return this.SelectTop(top) as Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute;
        }

        /// <summary>
        /// Gets Executes the query.
        /// </summary>
        /// <summary>
        /// Gets Metric collection received after query execution.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.IMetricCollection Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute.Execute()
        {
            return this.Execute() as Microsoft.Azure.Management.Monitor.Fluent.Models.IMetricCollection;
        }

        /// <summary>
        /// Sets the interval of the query.
        /// </summary>
        /// <param name="interval">The interval of the query.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute.WithInterval(TimeSpan interval)
        {
            return this.WithInterval(interval) as Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute;
        }

        /// <summary>
        /// Reduces the set of data collected. The syntax allowed depends on the operation. See the operation's description for details. Possible values include: 'Data', 'Metadata'.
        /// </summary>
        /// <param name="resultType">The type of metric to retrieve.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute.WithResultType(ResultType resultType)
        {
            return this.WithResultType(resultType) as Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute;
        }

        /// <summary>
        /// Sets the aggregation to use for sorting results and the direction of the sort.
        /// Only one order can be specified.
        /// Examples: sum asc.
        /// </summary>
        /// <param name="orderBy">The aggregation to use for sorting results and the direction of the sort.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute.OrderBy(string orderBy)
        {
            return this.OrderBy(orderBy) as Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute;
        }

        /// <summary>
        /// Gets Executes the query.
        /// </summary>
        /// <summary>
        /// Gets a representation of the deferred computation of Metric collection query call.
        /// </summary>
        async Task<Microsoft.Azure.Management.Monitor.Fluent.Models.IMetricCollection> Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await this.ExecuteAsync(cancellationToken) as Microsoft.Azure.Management.Monitor.Fluent.Models.IMetricCollection;
        }

        /// <summary>
        /// Sets the list of aggregation types to retrieve.
        /// </summary>
        /// <param name="aggregation">The list of aggregation types (comma separated) to retrieve.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute.WithAggregation(string aggregation)
        {
            return this.WithAggregation(aggregation) as Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute;
        }

        /// <summary>
        /// Gets the primaryAggregationType value.
        /// </summary>
        /// <summary>
        /// Gets the primaryAggregationType value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.AggregationType Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition.PrimaryAggregationType
        {
            get
            {
                return this.PrimaryAggregationType();
            }
        }

        /// <summary>
        /// Gets Begins a definition for a new resource Metric query.
        /// </summary>
        /// <summary>
        /// Gets the stage of start time filter definition.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricStartTimeFilter Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition.DefineQuery
        {
            get
            {
                return this.DefineQuery() as Microsoft.Azure.Management.Monitor.Fluent.IWithMetricStartTimeFilter;
            }
        }

        /// <summary>
        /// Gets the resourceId value.
        /// </summary>
        /// <summary>
        /// Gets the resourceId value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition.ResourceId
        {
            get
            {
                return this.ResourceId();
            }
        }

        /// <summary>
        /// Gets the unit value.
        /// </summary>
        /// <summary>
        /// Gets the unit value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.Unit Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition.Unit
        {
            get
            {
                return this.Unit();
            }
        }

        /// <summary>
        /// Gets the id value.
        /// </summary>
        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the metricAvailabilities value.
        /// </summary>
        /// <summary>
        /// Gets the metricAvailabilities value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.Models.MetricAvailability> Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition.MetricAvailabilities
        {
            get
            {
                return this.MetricAvailabilities() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.Models.MetricAvailability>;
            }
        }

        /// <summary>
        /// Gets the name value.
        /// </summary>
        /// <summary>
        /// Gets the name value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition.Name
        {
            get
            {
                return this.Name() as Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString;
            }
        }

        /// <summary>
        /// Sets the start time for Metric query filter.
        /// </summary>
        /// <param name="startTime">Specifies start time of cut off filter.</param>
        /// <return>The stage of end time filter definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricEndFilter Microsoft.Azure.Management.Monitor.Fluent.IWithMetricStartTimeFilter.StartingFrom(DateTime startTime)
        {
            return this.StartingFrom(startTime) as Microsoft.Azure.Management.Monitor.Fluent.IWithMetricEndFilter;
        }

        /// <summary>
        /// Sets the end time for Metric query filter.
        /// </summary>
        /// <param name="endTime">Specifies end time of cut off filter.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithMetricEndFilter.EndsBefore(DateTime endTime)
        {
            return this.EndsBefore(endTime) as Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute;
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        MonitorManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<MonitorManager>.Manager
        {
            get
            {
                return this.Manager() as MonitorManager;
            }
        }
    }
}