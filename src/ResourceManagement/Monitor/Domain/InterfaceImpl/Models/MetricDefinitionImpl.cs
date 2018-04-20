// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Azure.Management.Monitor.Fluent;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class MetricDefinitionImpl
    {
        /// <summary>
        /// Gets the name and the display name of the dimension, i.e. it is a localizable
        /// string.
        /// </summary>
        /// <summary>
        /// Gets the list of dimension values.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString> Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition.Dimensions
        {
            get
            {
                return this.Dimensions();
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
        /// Gets the isDimensionRequired value.
        /// </summary>
        /// <summary>
        /// Gets the isDimensionRequired value.
        /// </summary>
        bool Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition.IsDimensionRequired
        {
            get
            {
                return this.IsDimensionRequired();
            }
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        MonitorManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<MonitorManager>.Manager
        {
            get
            {
                return this.Manager();
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
                return this.MetricAvailabilities();
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
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the namespace value.
        /// </summary>
        /// <summary>
        /// Gets the namespace value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition.Namespace
        {
            get
            {
                return this.Namespace();
            }
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
        /// Gets the collection of what aggregation types are supported.
        /// </summary>
        /// <summary>
        /// Gets the list of supported aggregation type values.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.Models.AggregationType> Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition.SupportedAggregationTypes
        {
            get
            {
                return this.SupportedAggregationTypes();
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
        /// Begins a definition for a new resource Metric query.
        /// </summary>
        /// <return>The stage of start time filter definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricStartTimeFilter Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition.DefineQuery()
        {
            return this.DefineQuery();
        }

        /// <summary>
        /// Sets the end time for Metric query filter.
        /// </summary>
        /// <param name="endTime">Specifies end time of cut off filter.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithMetricEndFilter.EndsBefore(DateTime endTime)
        {
            return this.EndsBefore(endTime);
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <return>Metric collection received after query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.Models.IMetricCollection Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute.Execute()
        {
            return this.Execute();
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <return>A representation of the deferred computation of Metric collection query call.</return>
        async Task<Microsoft.Azure.Management.Monitor.Fluent.Models.IMetricCollection> Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await this.ExecuteAsync(cancellationToken);
        }

        /// <summary>
        /// Filters Metrics for a given namespace.
        /// </summary>
        /// <param name="namespaceName">Metric namespace to query metric definitions for.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute.FilterByNamespace(string namespaceName)
        {
            return this.FilterByNamespace(namespaceName);
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
            return this.OrderBy(orderBy);
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
            return this.SelectTop(top);
        }

        /// <summary>
        /// Sets the start time for Metric query filter.
        /// </summary>
        /// <param name="startTime">Specifies start time of cut off filter.</param>
        /// <return>The stage of end time filter definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricEndFilter Microsoft.Azure.Management.Monitor.Fluent.IWithMetricStartTimeFilter.StartingFrom(DateTime startTime)
        {
            return this.StartingFrom(startTime);
        }

        /// <summary>
        /// Sets the list of aggregation types to retrieve.
        /// </summary>
        /// <param name="aggregation">The list of aggregation types (comma separated) to retrieve.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute.WithAggregation(string aggregation)
        {
            return this.WithAggregation(aggregation);
        }

        /// <summary>
        /// Sets the interval of the query.
        /// </summary>
        /// <param name="interval">The interval of the query.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute.WithInterval(TimeSpan interval)
        {
            return this.WithInterval(interval);
        }

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
            return this.WithOdataFilter(odataFilter);
        }

        /// <summary>
        /// Reduces the set of data collected. The syntax allowed depends on the operation. See the operation's description for details. Possible values include: 'Data', 'Metadata'.
        /// </summary>
        /// <param name="resultType">The type of metric to retrieve.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute.WithResultType(ResultType resultType)
        {
            return this.WithResultType(resultType);
        }
    }
}