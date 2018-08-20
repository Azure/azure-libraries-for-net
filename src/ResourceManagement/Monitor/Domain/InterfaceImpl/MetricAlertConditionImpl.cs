// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;

    internal partial class MetricAlertConditionImpl
    {
        /// <summary>
        /// Gets the criteria operator. Possible values include: 'Equals', 'NotEquals', 'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'.
        /// </summary>
        /// <summary>
        /// Gets the operator value.
        /// </summary>
        Models.MetricAlertRuleCondition Microsoft.Azure.Management.Monitor.Fluent.IMetricAlertCondition.Condition
        {
            get
            {
                return this.Condition();
            }
        }

        /// <summary>
        /// Gets list of dimension conditions.
        /// </summary>
        /// <summary>
        /// Gets the dimensions value.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Models.MetricDimension> Microsoft.Azure.Management.Monitor.Fluent.IMetricAlertCondition.Dimensions
        {
            get
            {
                return this.Dimensions();
            }
        }

        /// <summary>
        /// Gets namespace of the metric.
        /// </summary>
        /// <summary>
        /// Gets the metricNamespace value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IMetricAlertCondition.MetricNamespace
        {
            get
            {
                return this.MetricNamespace();
            }
        }

        /// <summary>
        /// Gets name of the criteria.
        /// </summary>
        /// <summary>
        /// Gets the name value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IMetricAlertCondition.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert>.Parent
        {
            get
            {
                return this.Parent();
            }
        }

        /// <summary>
        /// Gets name of the metric signal.
        /// </summary>
        /// <summary>
        /// Gets the metricName value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IMetricAlertCondition.SignalName
        {
            get
            {
                return this.SignalName();
            }
        }

        /// <summary>
        /// Gets the criteria threshold value that activates the alert.
        /// </summary>
        /// <summary>
        /// Gets the threshold value.
        /// </summary>
        double Microsoft.Azure.Management.Monitor.Fluent.IMetricAlertCondition.Threshold
        {
            get
            {
                return this.Threshold();
            }
        }

        /// <summary>
        /// Gets the criteria time aggregation types. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total'.
        /// </summary>
        /// <summary>
        /// Gets the timeAggregation value.
        /// </summary>
        Models.MetricAlertRuleTimeAggregation Microsoft.Azure.Management.Monitor.Fluent.IMetricAlertCondition.TimeAggregation
        {
            get
            {
                return this.TimeAggregation();
            }
        }

        /// <summary>
        /// Attaches the defined condition to the parent metric alert.
        /// </summary>
        /// <return>The next stage of metric alert definition.</return>
        MetricAlert.Update.IUpdate MetricAlertCondition.UpdateDefinition.IWithConditionAttach<MetricAlert.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Attaches the defined condition to the parent metric alert.
        /// </summary>
        /// <return>The next stage of metric alert definition.</return>
        MetricAlert.Definition.IWithCreate MetricAlertCondition.Definition.IWithConditionAttach<MetricAlert.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Returns back to the metric alert update flow.
        /// </summary>
        /// <return>The next stage of the metric alert update.</return>
        MetricAlert.Update.IUpdate MetricAlertCondition.Update.IUpdateStages.Parent()
        {
            return this.Parent();
        }

        /// <summary>
        /// Sets the condition to monitor for the current metric alert.
        /// </summary>
        /// <param name="condition">The criteria operator. Possible values include: 'Equals', 'NotEquals', 'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'.</param>
        /// <param name="timeAggregation">The criteria time aggregation types. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total'.</param>
        /// <param name="threshold">The criteria threshold value that activates the alert.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        MetricAlertCondition.UpdateDefinition.IWithConditionAttach<MetricAlert.Update.IUpdate> MetricAlertCondition.UpdateDefinition.IWithCriteriaOperator<MetricAlert.Update.IUpdate>.WithCondition(MetricAlertRuleCondition condition, MetricAlertRuleTimeAggregation timeAggregation, double threshold)
        {
            return this.WithCondition(condition, timeAggregation, threshold);
        }

        /// <summary>
        /// Sets the condition to monitor for the current metric alert.
        /// </summary>
        /// <param name="condition">The criteria operator. Possible values include: 'Equals', 'NotEquals', 'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'.</param>
        /// <param name="timeAggregation">The criteria time aggregation types. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total'.</param>
        /// <param name="threshold">The criteria threshold value that activates the alert.</param>
        /// <return>The next stage of the metric alert condition update.</return>
        MetricAlertCondition.Update.IUpdateStages MetricAlertCondition.Update.IUpdateStages.WithCondition(MetricAlertRuleCondition condition, MetricAlertRuleTimeAggregation timeAggregation, double threshold)
        {
            return this.WithCondition(condition, timeAggregation, threshold);
        }

        /// <summary>
        /// Sets the condition to monitor for the current metric alert.
        /// </summary>
        /// <param name="condition">The criteria operator. Possible values include: 'Equals', 'NotEquals', 'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'.</param>
        /// <param name="timeAggregation">The criteria time aggregation types. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total'.</param>
        /// <param name="threshold">The criteria threshold value that activates the alert.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        MetricAlertCondition.Definition.IWithConditionAttach<MetricAlert.Definition.IWithCreate> MetricAlertCondition.Definition.IWithCriteriaOperator<MetricAlert.Definition.IWithCreate>.WithCondition(MetricAlertRuleCondition condition, MetricAlertRuleTimeAggregation timeAggregation, double threshold)
        {
            return this.WithCondition(condition, timeAggregation, threshold);
        }

        /// <summary>
        /// Adds a metric dimension filter.
        /// </summary>
        /// <param name="dimensionName">The name of the dimension.</param>
        /// <param name="values">List of dimension values to alert on.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        MetricAlertCondition.UpdateDefinition.IWithConditionAttach<MetricAlert.Update.IUpdate> MetricAlertCondition.UpdateDefinition.IWithConditionAttach<MetricAlert.Update.IUpdate>.WithDimensionFilter(string dimensionName, params string[] values)
        {
            return this.WithDimensionFilter(dimensionName, values);
        }

        /// <summary>
        /// Adds a metric dimension filter.
        /// </summary>
        /// <param name="dimensionName">The name of the dimension.</param>
        /// <param name="values">List of dimension values to alert on.</param>
        /// <return>The next stage of the metric alert condition update.</return>
        MetricAlertCondition.Update.IUpdateStages MetricAlertCondition.Update.IUpdateStages.WithDimensionFilter(string dimensionName, params string[] values)
        {
            return this.WithDimensionFilter(dimensionName, values);
        }

        /// <summary>
        /// Adds a metric dimension filter.
        /// </summary>
        /// <param name="dimensionName">The name of the dimension.</param>
        /// <param name="values">List of dimension values to alert on.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        MetricAlertCondition.Definition.IWithConditionAttach<MetricAlert.Definition.IWithCreate> MetricAlertCondition.Definition.IWithConditionAttach<MetricAlert.Definition.IWithCreate>.WithDimensionFilter(string dimensionName, params string[] values)
        {
            return this.WithDimensionFilter(dimensionName, values);
        }

        /// <summary>
        /// Sets Namespace of the metric to filter.
        /// </summary>
        /// <param name="metricNamespace">The Namespace of the metric.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        MetricAlertCondition.UpdateDefinition.IWithConditionAttach<MetricAlert.Update.IUpdate> MetricAlertCondition.UpdateDefinition.IWithConditionAttach<MetricAlert.Update.IUpdate>.WithMetricNamespace(string metricNamespace)
        {
            return this.WithMetricNamespace(metricNamespace);
        }

        /// <summary>
        /// Sets Namespace of the metric to filter.
        /// </summary>
        /// <param name="metricNamespace">The Namespace of the metric.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        MetricAlertCondition.Definition.IWithConditionAttach<MetricAlert.Definition.IWithCreate> MetricAlertCondition.Definition.IWithConditionAttach<MetricAlert.Definition.IWithCreate>.WithMetricNamespace(string metricNamespace)
        {
            return this.WithMetricNamespace(metricNamespace);
        }

        /// <summary>
        /// Removes the specified dimension filter.
        /// </summary>
        /// <param name="dimensionName">DimensionName the name of the dimension.</param>
        /// <return>The next stage of the metric alert condition update.</return>
        MetricAlertCondition.Update.IUpdateStages MetricAlertCondition.Update.IUpdateStages.WithoutDimensionFilter(string dimensionName)
        {
            return this.WithoutDimensionFilter(dimensionName);
        }

        /// <summary>
        /// Sets the name of the signal name to monitor.
        /// </summary>
        /// <param name="metricName">Metric name of the signal.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        MetricAlertCondition.Definition.IWithCriteriaOperator<MetricAlert.Definition.IWithCreate> MetricAlertCondition.Definition.Blank.MetricName.IMetricName<MetricAlert.Definition.IWithCreate>.WithSignalName(string metricName)
        {
            return this.WithSignalName(metricName);
        }

        /// <summary>
        /// Sets the name of the signal name to monitor.
        /// </summary>
        /// <param name="metricName">Metric name of the signal.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        MetricAlertCondition.UpdateDefinition.IWithCriteriaOperator<MetricAlert.Update.IUpdate> MetricAlertCondition.UpdateDefinition.Blank.MetricName.IMetricName<MetricAlert.Update.IUpdate>.WithSignalName(string metricName)
        {
            return this.WithSignalName(metricName);
        }
    }
}