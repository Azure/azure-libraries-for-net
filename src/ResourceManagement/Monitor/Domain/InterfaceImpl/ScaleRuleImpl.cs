// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.Definition;
    using Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.Update;
    using Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.UpdateDefinition;
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition;
    using Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.ParentUpdateDefinition;
    using Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Update;
    using Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using System;

    internal partial class ScaleRuleImpl 
    {
        /// <summary>
        /// Gets the operator that is used to compare the metric data and the threshold. Possible values include: 'Equals', 'NotEquals', 'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'.
        /// </summary>
        /// <summary>
        /// Gets the operator value.
        /// </summary>
        Models.ComparisonOperationType Microsoft.Azure.Management.Monitor.Fluent.IScaleRule.Condition
        {
            get
            {
                return this.Condition();
            }
        }

        /// <summary>
        /// Gets the amount of time to wait since the last scaling action before this action occurs. It must be between 1 week and 1 minute in ISO 8601 format.
        /// </summary>
        /// <summary>
        /// Gets the cooldown value.
        /// </summary>
        System.TimeSpan Microsoft.Azure.Management.Monitor.Fluent.IScaleRule.CoolDown
        {
            get
            {
                return this.CoolDown();
            }
        }

        /// <summary>
        /// Gets the range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.
        /// </summary>
        /// <summary>
        /// Gets the timeWindow value.
        /// </summary>
        System.TimeSpan Microsoft.Azure.Management.Monitor.Fluent.IScaleRule.Duration
        {
            get
            {
                return this.Duration();
            }
        }

        /// <summary>
        /// Gets the granularity of metrics the rule monitors. Must be one of the predefined values returned from metric definitions for the metric. Must be between 12 hours and 1 minute.
        /// </summary>
        /// <summary>
        /// Gets the timeGrain value.
        /// </summary>
        System.TimeSpan Microsoft.Azure.Management.Monitor.Fluent.IScaleRule.Frequency
        {
            get
            {
                return this.Frequency();
            }
        }

        /// <summary>
        /// Gets the metric statistic type. How the metrics from multiple instances are combined. Possible values include: 'Average', 'Min', 'Max', 'Sum'.
        /// </summary>
        /// <summary>
        /// Gets the statistic value.
        /// </summary>
        Models.MetricStatisticType Microsoft.Azure.Management.Monitor.Fluent.IScaleRule.FrequencyStatistic
        {
            get
            {
                return this.FrequencyStatistic();
            }
        }

        /// <summary>
        /// Gets the name of the metric that defines what the rule monitors.
        /// </summary>
        /// <summary>
        /// Gets the metricName value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IScaleRule.MetricName
        {
            get
            {
                return this.MetricName();
            }
        }

        /// <summary>
        /// Gets the resource identifier of the resource the rule monitors.
        /// </summary>
        /// <summary>
        /// Gets the metricResourceUri value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IScaleRule.MetricSource
        {
            get
            {
                return this.MetricSource();
            }
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleProfile Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleProfile>.Parent
        {
            get
            {
                return this.Parent();
            }
        }

        /// <summary>
        /// Gets the scale direction. Whether the scaling action increases or decreases the number of instances. Possible values include: 'None', 'Increase', 'Decrease'.
        /// </summary>
        /// <summary>
        /// Gets the direction value.
        /// </summary>
        Models.ScaleDirection Microsoft.Azure.Management.Monitor.Fluent.IScaleRule.ScaleDirection
        {
            get
            {
                return this.ScaleDirection();
            }
        }

        /// <summary>
        /// Gets the number of instances that are involved in the scaling action.
        /// </summary>
        /// <summary>
        /// Gets the value value.
        /// </summary>
        int Microsoft.Azure.Management.Monitor.Fluent.IScaleRule.ScaleInstanceCount
        {
            get
            {
                return this.ScaleInstanceCount();
            }
        }

        /// <summary>
        /// Gets the type of action that should occur when the scale rule fires. Possible values include: 'ChangeCount', 'PercentChangeCount', 'ExactCount'.
        /// </summary>
        /// <summary>
        /// Gets the type value.
        /// </summary>
        Models.ScaleType Microsoft.Azure.Management.Monitor.Fluent.IScaleRule.ScaleType
        {
            get
            {
                return this.ScaleType();
            }
        }

        /// <summary>
        /// Gets the threshold of the metric that triggers the scale action.
        /// </summary>
        /// <summary>
        /// Gets the threshold value.
        /// </summary>
        double Microsoft.Azure.Management.Monitor.Fluent.IScaleRule.Threshold
        {
            get
            {
                return this.Threshold();
            }
        }

        /// <summary>
        /// Gets the time aggregation type. How the data that is collected should be combined over time. The default value is Average. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total', 'Count'.
        /// </summary>
        /// <summary>
        /// Gets the timeAggregation value.
        /// </summary>
        Models.TimeAggregationType Microsoft.Azure.Management.Monitor.Fluent.IScaleRule.TimeAggregation
        {
            get
            {
                return this.TimeAggregation();
            }
        }

        /// <summary>
        /// Attaches sclae rule to the new autoscale profile in the autoscale update definition stage.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        AutoscaleProfile.UpdateDefinition.IWithScaleRuleOptional ScaleRule.ParentUpdateDefinition.IWithAttach.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        AutoscaleProfile.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<AutoscaleProfile.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        AutoscaleProfile.Definition.IWithScaleRuleOptional Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<AutoscaleProfile.Definition.IWithScaleRuleOptional>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Begins an update for a child resource.
        /// This is the beginning of the builder pattern used to update child resources
        /// The final method completing the update and continue
        /// the actual parent resource update process in Azure is  Settable.parent().
        /// </summary>
        /// <return>The stage of  parent resource update.</return>
        AutoscaleProfile.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<AutoscaleProfile.Update.IUpdate>.Parent()
        {
            return this.Parent();
        }

        /// <summary>
        /// Updates the condition to monitor for the current metric alert.
        /// </summary>
        /// <param name="condition">The operator that is used to compare the metric data and the threshold. Possible values include: 'Equals', 'NotEquals', 'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'.</param>
        /// <param name="timeAggregation">The time aggregation type. How the data that is collected should be combined over time. The default value is Average. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total', 'Count'.</param>
        /// <param name="threshold">The threshold of the metric that triggers the scale action.</param>
        /// <return>The next stage of the scale rule update.</return>
        ScaleRule.Update.IUpdate ScaleRule.Update.IUpdate.WithCondition(TimeAggregationType timeAggregation, ComparisonOperationType condition, double threshold)
        {
            return this.WithCondition(timeAggregation, condition, threshold);
        }

        /// <summary>
        /// Sets the condition to monitor for the current metric alert.
        /// </summary>
        /// <param name="condition">The operator that is used to compare the metric data and the threshold. Possible values include: 'Equals', 'NotEquals', 'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'.</param>
        /// <param name="timeAggregation">The time aggregation type. How the data that is collected should be combined over time. The default value is Average. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total', 'Count'.</param>
        /// <param name="threshold">The threshold of the metric that triggers the scale action.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.ParentUpdateDefinition.IWithScaleAction ScaleRule.ParentUpdateDefinition.IWithCondition.WithCondition(TimeAggregationType timeAggregation, ComparisonOperationType condition, double threshold)
        {
            return this.WithCondition(timeAggregation, condition, threshold);
        }

        /// <summary>
        /// Sets the condition to monitor for the current metric alert.
        /// </summary>
        /// <param name="condition">The operator that is used to compare the metric data and the threshold. Possible values include: 'Equals', 'NotEquals', 'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'.</param>
        /// <param name="timeAggregation">The time aggregation type. How the data that is collected should be combined over time. The default value is Average. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total', 'Count'.</param>
        /// <param name="threshold">The threshold of the metric that triggers the scale action.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.UpdateDefinition.IWithScaleAction ScaleRule.UpdateDefinition.IWithCondition.WithCondition(TimeAggregationType timeAggregation, ComparisonOperationType condition, double threshold)
        {
            return this.WithCondition(timeAggregation, condition, threshold);
        }

        /// <summary>
        /// Sets the condition to monitor for the current metric alert.
        /// </summary>
        /// <param name="condition">The operator that is used to compare the metric data and the threshold. Possible values include: 'Equals', 'NotEquals', 'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'.</param>
        /// <param name="timeAggregation">The time aggregation type. How the data that is collected should be combined over time. The default value is Average. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total', 'Count'.</param>
        /// <param name="threshold">The threshold of the metric that triggers the scale action.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.Definition.IWithScaleAction ScaleRule.Definition.IWithCondition.WithCondition(TimeAggregationType timeAggregation, ComparisonOperationType condition, double threshold)
        {
            return this.WithCondition(timeAggregation, condition, threshold);
        }

        /// <summary>
        /// The name of the metric that defines what the rule monitors.
        /// </summary>
        /// <param name="metricName">MetricName name of the metric.</param>
        /// <return>The next stage of the scale rule update.</return>
        ScaleRule.Update.IUpdate ScaleRule.Update.IUpdate.WithMetricName(string metricName)
        {
            return this.WithMetricName(metricName);
        }

        /// <summary>
        /// Sets the name of the metric that defines what the rule monitors.
        /// </summary>
        /// <param name="metricName">Name of the metric.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.ParentUpdateDefinition.IWithStatistic ScaleRule.ParentUpdateDefinition.IWithMetricName.WithMetricName(string metricName)
        {
            return this.WithMetricName(metricName);
        }

        /// <summary>
        /// Sets the name of the metric that defines what the rule monitors.
        /// </summary>
        /// <param name="metricName">Name of the metric.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.UpdateDefinition.IWithStatistic ScaleRule.UpdateDefinition.IWithMetricName.WithMetricName(string metricName)
        {
            return this.WithMetricName(metricName);
        }

        /// <summary>
        /// Sets the name of the metric that defines what the rule monitors.
        /// </summary>
        /// <param name="metricName">Name of the metric.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.Definition.IWithStatistic ScaleRule.Definition.IWithMetricName.WithMetricName(string metricName)
        {
            return this.WithMetricName(metricName);
        }

        /// <summary>
        /// Updates the resource identifier of the resource the rule monitors.
        /// </summary>
        /// <param name="metricSourceResourceId">ResourceId of the resource.</param>
        /// <return>The next stage of the scale rule update.</return>
        ScaleRule.Update.IUpdate ScaleRule.Update.IUpdate.WithMetricSource(string metricSourceResourceId)
        {
            return this.WithMetricSource(metricSourceResourceId);
        }

        /// <summary>
        /// Sets the resource identifier of the resource the rule monitors.
        /// </summary>
        /// <param name="metricSourceResourceId">ResourceId of the resource.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.ParentUpdateDefinition.IWithMetricName ScaleRule.ParentUpdateDefinition.IBlank.WithMetricSource(string metricSourceResourceId)
        {
            return this.WithMetricSource(metricSourceResourceId);
        }

        /// <summary>
        /// Sets the resource identifier of the resource the rule monitors.
        /// </summary>
        /// <param name="metricSourceResourceId">ResourceId of the resource.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.UpdateDefinition.IWithMetricName ScaleRule.UpdateDefinition.IBlank.WithMetricSource(string metricSourceResourceId)
        {
            return this.WithMetricSource(metricSourceResourceId);
        }

        /// <summary>
        /// Sets the resource identifier of the resource the rule monitors.
        /// </summary>
        /// <param name="metricSourceResourceId">ResourceId of the resource.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.Definition.IWithMetricName ScaleRule.Definition.IBlank.WithMetricSource(string metricSourceResourceId)
        {
            return this.WithMetricSource(metricSourceResourceId);
        }

        /// <summary>
        /// Updates the action to be performed when the scale rule will be active.
        /// </summary>
        /// <param name="direction">The scale direction. Whether the scaling action increases or decreases the number of instances. Possible values include: 'None', 'Increase', 'Decrease'.</param>
        /// <param name="type">The type of action that should occur when the scale rule fires. Possible values include: 'ChangeCount', 'PercentChangeCount', 'ExactCount'.</param>
        /// <param name="instanceCountChange">The number of instances that are involved in the scaling action.</param>
        /// <param name="cooldown">The amount of time to wait since the last scaling action before this action occurs. It must be between 1 week and 1 minute in ISO 8601 format.</param>
        /// <return>The next stage of the scale rule update.</return>
        ScaleRule.Update.IUpdate ScaleRule.Update.IUpdate.WithScaleAction(ScaleDirection direction, ScaleType type, int instanceCountChange, TimeSpan cooldown)
        {
            return this.WithScaleAction(direction, type, instanceCountChange, cooldown);
        }

        /// <summary>
        /// Sets the action to be performed when the scale rule will be active.
        /// </summary>
        /// <param name="direction">The scale direction. Whether the scaling action increases or decreases the number of instances. Possible values include: 'None', 'Increase', 'Decrease'.</param>
        /// <param name="type">The type of action that should occur when the scale rule fires. Possible values include: 'ChangeCount', 'PercentChangeCount', 'ExactCount'.</param>
        /// <param name="instanceCountChange">The number of instances that are involved in the scaling action.</param>
        /// <param name="cooldown">The amount of time to wait since the last scaling action before this action occurs. It must be between 1 week and 1 minute in ISO 8601 format.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.ParentUpdateDefinition.IWithAttach ScaleRule.ParentUpdateDefinition.IWithScaleAction.WithScaleAction(ScaleDirection direction, ScaleType type, int instanceCountChange, TimeSpan cooldown)
        {
            return this.WithScaleAction(direction, type, instanceCountChange, cooldown);
        }

        /// <summary>
        /// Sets the action to be performed when the scale rule will be active.
        /// </summary>
        /// <param name="direction">The scale direction. Whether the scaling action increases or decreases the number of instances. Possible values include: 'None', 'Increase', 'Decrease'.</param>
        /// <param name="type">The type of action that should occur when the scale rule fires. Possible values include: 'ChangeCount', 'PercentChangeCount', 'ExactCount'.</param>
        /// <param name="instanceCountChange">The number of instances that are involved in the scaling action.</param>
        /// <param name="cooldown">The amount of time to wait since the last scaling action before this action occurs. It must be between 1 week and 1 minute in ISO 8601 format.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.UpdateDefinition.IWithAttach ScaleRule.UpdateDefinition.IWithScaleAction.WithScaleAction(ScaleDirection direction, ScaleType type, int instanceCountChange, TimeSpan cooldown)
        {
            return this.WithScaleAction(direction, type, instanceCountChange, cooldown);
        }

        /// <summary>
        /// Sets the action to be performed when the scale rule will be active.
        /// </summary>
        /// <param name="direction">The scale direction. Whether the scaling action increases or decreases the number of instances. Possible values include: 'None', 'Increase', 'Decrease'.</param>
        /// <param name="type">The type of action that should occur when the scale rule fires. Possible values include: 'ChangeCount', 'PercentChangeCount', 'ExactCount'.</param>
        /// <param name="instanceCountChange">The number of instances that are involved in the scaling action.</param>
        /// <param name="cooldown">The amount of time to wait since the last scaling action before this action occurs. It must be between 1 week and 1 minute in ISO 8601 format.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.Definition.IWithAttach ScaleRule.Definition.IWithScaleAction.WithScaleAction(ScaleDirection direction, ScaleType type, int instanceCountChange, TimeSpan cooldown)
        {
            return this.WithScaleAction(direction, type, instanceCountChange, cooldown);
        }

        /// <summary>
        /// Updates the statistics for autoscale trigger action.
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <param name="frequency">The granularity of metrics the rule monitors. Must be one of the predefined values returned from metric definitions for the metric. Must be between 12 hours and 1 minute.</param>
        /// <param name="statisticType">The metric statistic type. How the metrics from multiple instances are combined. Possible values include: 'Average', 'Min', 'Max', 'Sum'.</param>
        /// <return>The next stage of the scale rule update.</return>
        ScaleRule.Update.IUpdate ScaleRule.Update.IUpdate.WithStatistic(TimeSpan duration, TimeSpan frequency, MetricStatisticType statisticType)
        {
            return this.WithStatistic(duration, frequency, statisticType);
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 10 minutes for duration, 1 minute for frequency(time grain) and 'Average' for statistic type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ScaleRule.Update.IUpdate ScaleRule.Update.IUpdate.WithStatistic()
        {
            return this.WithStatistic();
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 1 minute for frequency(time grain) and 'Average' for statistic type.
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.Update.IUpdate ScaleRule.Update.IUpdate.WithStatistic(TimeSpan duration)
        {
            return this.WithStatistic(duration);
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 1 minute for frequency(time grain).
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <param name="statisticType">The metric statistic type. How the metrics from multiple instances are combined. Possible values include: 'Average', 'Min', 'Max', 'Sum'.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.Update.IUpdate ScaleRule.Update.IUpdate.WithStatistic(TimeSpan duration, MetricStatisticType statisticType)
        {
            return this.WithStatistic(duration, statisticType);
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action.
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <param name="frequency">The granularity of metrics the rule monitors. Must be one of the predefined values returned from metric definitions for the metric. Must be between 12 hours and 1 minute.</param>
        /// <param name="statisticType">The metric statistic type. How the metrics from multiple instances are combined. Possible values include: 'Average', 'Min', 'Max', 'Sum'.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.ParentUpdateDefinition.IWithCondition ScaleRule.ParentUpdateDefinition.IWithStatistic.WithStatistic(TimeSpan duration, TimeSpan frequency, MetricStatisticType statisticType)
        {
            return this.WithStatistic(duration, frequency, statisticType);
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 10 minutes for duration, 1 minute for frequency(time grain) and 'Average' for statistic type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ScaleRule.ParentUpdateDefinition.IWithCondition ScaleRule.ParentUpdateDefinition.IWithStatistic.WithStatistic()
        {
            return this.WithStatistic();
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 1 minute for frequency(time grain) and 'Average' for statistic type.
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.ParentUpdateDefinition.IWithCondition ScaleRule.ParentUpdateDefinition.IWithStatistic.WithStatistic(TimeSpan duration)
        {
            return this.WithStatistic(duration);
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 1 minute for frequency(time grain).
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <param name="statisticType">The metric statistic type. How the metrics from multiple instances are combined. Possible values include: 'Average', 'Min', 'Max', 'Sum'.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.ParentUpdateDefinition.IWithCondition ScaleRule.ParentUpdateDefinition.IWithStatistic.WithStatistic(TimeSpan duration, MetricStatisticType statisticType)
        {
            return this.WithStatistic(duration, statisticType);
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action.
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <param name="frequency">The granularity of metrics the rule monitors. Must be one of the predefined values returned from metric definitions for the metric. Must be between 12 hours and 1 minute.</param>
        /// <param name="statisticType">The metric statistic type. How the metrics from multiple instances are combined. Possible values include: 'Average', 'Min', 'Max', 'Sum'.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.UpdateDefinition.IWithCondition ScaleRule.UpdateDefinition.IWithStatistic.WithStatistic(TimeSpan duration, TimeSpan frequency, MetricStatisticType statisticType)
        {
            return this.WithStatistic(duration, frequency, statisticType);
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 10 minutes for duration, 1 minute for frequency(time grain) and 'Average' for statistic type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ScaleRule.UpdateDefinition.IWithCondition ScaleRule.UpdateDefinition.IWithStatistic.WithStatistic()
        {
            return this.WithStatistic();
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 1 minute for frequency(time grain) and 'Average' for statistic type.
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.UpdateDefinition.IWithCondition ScaleRule.UpdateDefinition.IWithStatistic.WithStatistic(TimeSpan duration)
        {
            return this.WithStatistic(duration);
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 1 minute for frequency(time grain).
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <param name="statisticType">The metric statistic type. How the metrics from multiple instances are combined. Possible values include: 'Average', 'Min', 'Max', 'Sum'.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.UpdateDefinition.IWithCondition ScaleRule.UpdateDefinition.IWithStatistic.WithStatistic(TimeSpan duration, MetricStatisticType statisticType)
        {
            return this.WithStatistic(duration, statisticType);
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action.
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <param name="frequency">The granularity of metrics the rule monitors. Must be one of the predefined values returned from metric definitions for the metric. Must be between 12 hours and 1 minute.</param>
        /// <param name="statisticType">The metric statistic type. How the metrics from multiple instances are combined. Possible values include: 'Average', 'Min', 'Max', 'Sum'.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.Definition.IWithCondition ScaleRule.Definition.IWithStatistic.WithStatistic(TimeSpan duration, TimeSpan frequency, MetricStatisticType statisticType)
        {
            return this.WithStatistic(duration, frequency, statisticType);
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 10 minutes for duration, 1 minute for frequency(time grain) and 'Average' for statistic type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ScaleRule.Definition.IWithCondition ScaleRule.Definition.IWithStatistic.WithStatistic()
        {
            return this.WithStatistic();
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 1 minute for frequency(time grain) and 'Average' for statistic type.
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.Definition.IWithCondition ScaleRule.Definition.IWithStatistic.WithStatistic(TimeSpan duration)
        {
            return this.WithStatistic(duration);
        }

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 1 minute for frequency(time grain).
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <param name="statisticType">The metric statistic type. How the metrics from multiple instances are combined. Possible values include: 'Average', 'Min', 'Max', 'Sum'.</param>
        /// <return>The next stage of the definition.</return>
        ScaleRule.Definition.IWithCondition ScaleRule.Definition.IWithStatistic.WithStatistic(TimeSpan duration, MetricStatisticType statisticType)
        {
            return this.WithStatistic(duration, statisticType);
        }
    }
}