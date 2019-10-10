// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.MetricDynamicAlertCondition.Update
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;

    /// <summary>
    /// Grouping of metric alert condition update stages.
    /// </summary>
    public interface IUpdateStages
    {
        /// <summary>
        /// Sets the condition to monitor for the current metric alert.
        /// </summary>
        /// <param name="timeAggregation">The criteria time aggregation types. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total'.</param>
        /// <param name="condition">The criteria operator used to compare the metric value against the threshold.</param>
        /// <param name="alertSensitivity">The extent of deviation required to trigger an alert.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        IUpdateStages WithCondition(MetricAlertRuleTimeAggregation timeAggregation, DynamicThresholdOperator condition, DynamicThresholdSensitivity alertSensitivity);

        /// <summary>
        /// Adds a metric dimension filter.
        /// </summary>
        /// <param name="dimensionName">The name of the dimension.</param>
        /// <param name="values">List of dimension values to alert on.</param>
        /// <returns>The next stage of the metric alert condition update.</returns>
        IUpdateStages WithDimension(string dimensionName, params string[] values);

        /// <summary>
        /// Removes the specified dimension filter.
        /// </summary>
        /// <param name="dimensionName">DimensionName the name of the dimension.</param>
        /// <returns>The next stage of the metric alert condition update.</returns>
        IUpdateStages WithoutDimension(string dimensionName);

        /// <summary>
        /// Sets the failing periods for triggering the alert.
        /// </summary>
        /// <param name="failingPeriods">The failing periods for triggering the alert.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        IUpdateStages WithFailingPeriods(DynamicThresholdFailingPeriods failingPeriods);

        /// <summary>
        /// Sets the date from which to start learning the metric historical data and calculate the dynamic thresholds.
        /// </summary>
        /// <param name="dateTime">The date from which to start learning the metric historical data and calculate the dynamic thresholds.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        IUpdateStages WithIgnoreDataBefore(System.DateTime dateTime);

        /// <summary>
        /// Removes the date from which to start learning the metric historical data and calculate the dynamic thresholds.
        /// </summary>
        /// <return>The next stage of metric alert condition definition.</return>
        IUpdateStages WithoutIgnoreDataBefore();

        /// <summary>
        /// Returns back to the metric alert update flow.
        /// </summary>
        /// <returns>The next stage of the metric alert update.</returns>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate Parent();
    }
}