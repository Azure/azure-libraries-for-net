// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Update
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
        /// <param name="condition">The criteria operator. Possible values include: 'Equals', 'NotEquals', 'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'.</param>
        /// <param name="timeAggregation">The criteria time aggregation types. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total'.</param>
        /// <param name="threshold">The criteria threshold value that activates the alert.</param>
        /// <returns>The next stage of the metric alert condition update.</returns>
        IUpdateStages WithCondition(MetricAlertRuleTimeAggregation timeAggregation, MetricAlertRuleCondition condition, double threshold);

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
        /// Returns back to the metric alert update flow.
        /// </summary>
        /// <returns>The next stage of the metric alert update.</returns>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate Parent();
    }
}