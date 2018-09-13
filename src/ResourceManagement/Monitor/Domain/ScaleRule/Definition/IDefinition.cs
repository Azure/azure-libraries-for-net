// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using System;

    /// <summary>
    /// The stage of the definition which specifies what kind of statistics should be used to calculate autoscale trigger action.
    /// </summary>
    public interface IWithStatistic 
    {

        /// <summary>
        /// Sets statistics for autoscale trigger action.
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <param name="frequency">The granularity of metrics the rule monitors. Must be one of the predefined values returned from metric definitions for the metric. Must be between 12 hours and 1 minute.</param>
        /// <param name="statisticType">The metric statistic type. How the metrics from multiple instances are combined. Possible values include: 'Average', 'Min', 'Max', 'Sum'.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IWithCondition WithStatistic(TimeSpan duration, TimeSpan frequency, MetricStatisticType statisticType);

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 10 minutes for duration, 1 minute for frequency(time grain) and 'Average' for statistic type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IWithCondition WithStatistic();

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 1 minute for frequency(time grain) and 'Average' for statistic type.
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IWithCondition WithStatistic(TimeSpan duration);

        /// <summary>
        /// Sets statistics for autoscale trigger action with default values of 1 minute for frequency(time grain).
        /// </summary>
        /// <param name="duration">The range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.</param>
        /// <param name="statisticType">The metric statistic type. How the metrics from multiple instances are combined. Possible values include: 'Average', 'Min', 'Max', 'Sum'.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IWithCondition WithStatistic(TimeSpan duration, MetricStatisticType statisticType);
    }

    /// <summary>
    /// The stage of the definition which specifies metric alert condition.
    /// </summary>
    public interface IWithCondition 
    {

        /// <summary>
        /// Sets the condition to monitor for the current metric alert.
        /// </summary>
        /// <param name="condition">The operator that is used to compare the metric data and the threshold. Possible values include: 'Equals', 'NotEquals', 'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'.</param>
        /// <param name="timeAggregation">The time aggregation type. How the data that is collected should be combined over time. The default value is Average. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total', 'Count'.</param>
        /// <param name="threshold">The threshold of the metric that triggers the scale action.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IWithScaleAction WithCondition(TimeAggregationType timeAggregation, ComparisonOperationType condition, double threshold);
    }

    /// <summary>
    /// The stage of the definition which specifies action to take when the metric alert will be triggered.
    /// </summary>
    public interface IWithScaleAction 
    {

        /// <summary>
        /// Sets the action to be performed when the scale rule will be active.
        /// </summary>
        /// <param name="direction">The scale direction. Whether the scaling action increases or decreases the number of instances. Possible values include: 'None', 'Increase', 'Decrease'.</param>
        /// <param name="type">The type of action that should occur when the scale rule fires. Possible values include: 'ChangeCount', 'PercentChangeCount', 'ExactCount'.</param>
        /// <param name="instanceCountChange">The number of instances that are involved in the scaling action.</param>
        /// <param name="cooldown">The amount of time to wait since the last scaling action before this action occurs. It must be between 1 week and 1 minute in ISO 8601 format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IWithAttach WithScaleAction(ScaleDirection direction, ScaleType type, int instanceCountChange, TimeSpan cooldown);
    }

    /// <summary>
    /// The first stage of autoscale profile scale rule definition.
    /// </summary>
    public interface IBlank 
    {

        /// <summary>
        /// Sets the resource identifier of the resource the rule monitors.
        /// </summary>
        /// <param name="metricSourceResourceId">ResourceId of the resource.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IWithMetricName WithMetricSource(string metricSourceResourceId);
    }

    /// <summary>
    /// The stage of the definition which specifies metric name.
    /// </summary>
    public interface IWithMetricName 
    {

        /// <summary>
        /// Sets the name of the metric that defines what the rule monitors.
        /// </summary>
        /// <param name="metricName">Name of the metric.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IWithStatistic WithMetricName(string metricName);
    }

    /// <summary>
    /// The entirety of an autoscale profile scale rule definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IBlank,
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IWithMetricName,
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IWithStatistic,
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IWithCondition,
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IWithScaleAction,
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IWithAttach
    {

    }

    /// <summary>
    /// The final stage of the definition which attaches defined scale rule to the current Autoscale profile.
    /// </summary>
    public interface IWithAttach  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.Definition.IWithScaleRuleOptional>
    {

    }
}