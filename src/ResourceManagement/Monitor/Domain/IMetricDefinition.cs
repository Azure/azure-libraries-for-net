// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The Azure metric definition entries are of type MetricDefinition.
    /// </summary>
    public interface IMetricDefinition :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<MonitorManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.MetricDefinitionInner>
    {

        /// <summary>
        /// Gets the name and the display name of the dimension, i.e. it is a localizable
        /// string.
        /// </summary>
        /// <summary>
        /// Gets the list of dimension values.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ILocalizableString> Dimensions { get; }

        /// <summary>
        /// Gets the id value.
        /// </summary>
        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the isDimensionRequired value.
        /// </summary>
        /// <summary>
        /// Gets the isDimensionRequired value.
        /// </summary>
        bool IsDimensionRequired { get; }

        /// <summary>
        /// Gets the metricAvailabilities value.
        /// </summary>
        /// <summary>
        /// Gets the metricAvailabilities value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.MetricAvailability> MetricAvailabilities { get; }

        /// <summary>
        /// Gets the name value.
        /// </summary>
        /// <summary>
        /// Gets the name value.
        /// </summary>
        Models.ILocalizableString Name { get; }

        /// <summary>
        /// Gets the namespace value.
        /// </summary>
        /// <summary>
        /// Gets the namespace value.
        /// </summary>
        string Namespace { get; }

        /// <summary>
        /// Gets the primaryAggregationType value.
        /// </summary>
        /// <summary>
        /// Gets the primaryAggregationType value.
        /// </summary>
        Models.AggregationType PrimaryAggregationType { get; }

        /// <summary>
        /// Gets the resourceId value.
        /// </summary>
        /// <summary>
        /// Gets the resourceId value.
        /// </summary>
        string ResourceId { get; }

        /// <summary>
        /// Gets the collection of what aggregation types are supported.
        /// </summary>
        /// <summary>
        /// Gets the list of supported aggregation type values.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.AggregationType> SupportedAggregationTypes { get; }

        /// <summary>
        /// Gets the unit value.
        /// </summary>
        /// <summary>
        /// Gets the unit value.
        /// </summary>
        Models.Unit Unit { get; }

        /// <summary>
        /// Begins a definition for a new resource Metric query.
        /// </summary>
        /// <return>The stage of start time filter definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricStartTimeFilter DefineQuery();
    }

    /// <summary>
    /// The stage of a Metric query allowing to specify end time filter.
    /// </summary>
    public interface IWithMetricEndFilter
    {

        /// <summary>
        /// Sets the end time for Metric query filter.
        /// </summary>
        /// <param name="endTime">Specifies end time of cut off filter.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute EndsBefore(DateTime endTime);
    }

    /// <summary>
    /// The entirety of a Metrics query definition.
    /// </summary>
    public interface IMetricsQueryDefinition :
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricStartTimeFilter,
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricEndFilter,
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute
    {

    }

    /// <summary>
    /// Grouping of Metric query stages.
    /// </summary>
    public interface IMetricsQueryDefinitionStages
    {

    }

    /// <summary>
    /// The stage of a Metric query allowing to specify optional filters and execute the query.
    /// </summary>
    public interface IWithMetricsQueryExecute
    {

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <return>Metric collection received after query execution.</return>
        Models.IMetricCollection Execute();

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <return>A representation of the deferred computation of Metric collection query call.</return>
        Task<Models.IMetricCollection> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Filters Metrics for a given namespace.
        /// </summary>
        /// <param name="namespaceName">Metric namespace to query metric definitions for.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute FilterByNamespace(string namespaceName);

        /// <summary>
        /// Sets the aggregation to use for sorting results and the direction of the sort.
        /// Only one order can be specified.
        /// Examples: sum asc.
        /// </summary>
        /// <param name="orderBy">The aggregation to use for sorting results and the direction of the sort.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute OrderBy(string orderBy);

        /// <summary>
        /// Sets the maximum number of records to retrieve.
        /// Valid only if $filter is specified.
        /// Defaults to 10.
        /// </summary>
        /// <param name="top">The maximum number of records to retrieve.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute SelectTop(int top);

        /// <summary>
        /// Sets the list of aggregation types to retrieve.
        /// </summary>
        /// <param name="aggregation">The list of aggregation types (comma separated) to retrieve.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute WithAggregation(string aggregation);

        /// <summary>
        /// Sets the interval of the query.
        /// </summary>
        /// <param name="interval">The interval of the query.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute WithInterval(TimeSpan interval);

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
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute WithOdataFilter(string odataFilter);

        /// <summary>
        /// Reduces the set of data collected. The syntax allowed depends on the operation. See the operation's description for details. Possible values include: 'Data', 'Metadata'.
        /// </summary>
        /// <param name="resultType">The type of metric to retrieve.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricsQueryExecute WithResultType(ResultType resultType);
    }

    /// <summary>
    /// The stage of a Metric query allowing to specify start time filter.
    /// </summary>
    public interface IWithMetricStartTimeFilter
    {

        /// <summary>
        /// Sets the start time for Metric query filter.
        /// </summary>
        /// <param name="startTime">Specifies start time of cut off filter.</param>
        /// <return>The stage of end time filter definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithMetricEndFilter StartingFrom(DateTime startTime);
    }
}