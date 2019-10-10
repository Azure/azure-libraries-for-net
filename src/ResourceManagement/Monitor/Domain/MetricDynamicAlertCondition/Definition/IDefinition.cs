// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.MetricDynamicAlertCondition.Definition
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;

    /// <summary>
    /// The first stage of a Metric Dynamic Alert condition definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Metric Alert definition to return to after attaching this definition.</typeparam>
    public interface IMetricName<ParentT>
    {

        /// <summary>
        /// Sets the name of the signal name to monitor.
        /// </summary>
        /// <param name="metricName">Metric name of the signal.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricDynamicAlertCondition.Definition.IWithCriteriaOperator<ParentT> WithMetricName(string metricName);

        /// <summary>
        /// Sets the name of the signal name to monitor.
        /// </summary>
        /// <param name="metricName">Metric name of the signal.</param>
        /// <param name="metricNamespace">The Namespace of the metric.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricDynamicAlertCondition.Definition.IWithCriteriaOperator<ParentT> WithMetricName(string metricName, string metricNamespace);
    }

    /// <summary>
    /// The stage of the definition which specifies metric alert condition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Metric Alert definition to return to after attaching this definition.</typeparam>
    public interface IWithCriteriaOperator<ParentT>
    {

        /// <summary>
        /// Sets the condition to monitor for the current metric alert.
        /// </summary>
        /// <param name="timeAggregation">The criteria time aggregation types. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total'.</param>
        /// <param name="condition">The criteria operator used to compare the metric value against the threshold.</param>
        /// <param name="alertSensitivity">The extent of deviation required to trigger an alert.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricDynamicAlertCondition.Definition.IWithFailingPeriods<ParentT> WithCondition(MetricAlertRuleTimeAggregation timeAggregation, DynamicThresholdOperator condition, DynamicThresholdSensitivity alertSensitivity);
    }

    /// <summary>
    /// The stage of the definition which specifies metric alert condition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Metric Alert definition to return to after attaching this definition.</typeparam>
    public interface IWithFailingPeriods<ParentT>
    {
        /// <summary>
        /// Sets the failing periods for triggering the alert.
        /// </summary>
        /// <param name="failingPeriods">The failing periods for triggering the alert.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        IWithConditionAttach<ParentT> WithFailingPeriods(DynamicThresholdFailingPeriods failingPeriods);
    }

    /// <summary>
    /// The stage of the definition which specifies metric alert additional filtering options.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Metric Alert definition to return to after attaching this definition.</typeparam>
    public interface IWithConditionAttach<ParentT>
    {

        /// <summary>
        /// Attaches the defined condition to the parent metric alert.
        /// </summary>
        /// <return>The next stage of metric alert definition.</return>
        ParentT Attach();

        /// <summary>
        /// Adds a metric dimension filter.
        /// </summary>
        /// <param name="dimensionName">The name of the dimension.</param>
        /// <param name="values">List of dimension values to alert on.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricDynamicAlertCondition.Definition.IWithConditionAttach<ParentT> WithDimension(string dimensionName, params string[] values);

        /// <summary>
        /// Sets the date from which to start learning the metric historical data and calculate the dynamic thresholds.
        /// </summary>
        /// <param name="dateTime">The date from which to start learning the metric historical data and calculate the dynamic thresholds.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        IWithConditionAttach<ParentT> WithIgnoreDataBefore(System.DateTime dateTime);
    }
}