// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure autoscale profile scale rule.
    /// </summary>
    public interface IScaleRule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ScaleRuleInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleProfile>
    {

        /// <summary>
        /// Gets the operator that is used to compare the metric data and the threshold. Possible values include: 'Equals', 'NotEquals', 'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'.
        /// </summary>
        /// <summary>
        /// Gets the operator value.
        /// </summary>
        Models.ComparisonOperationType Condition { get; }

        /// <summary>
        /// Gets the amount of time to wait since the last scaling action before this action occurs. It must be between 1 week and 1 minute in ISO 8601 format.
        /// </summary>
        /// <summary>
        /// Gets the cooldown value.
        /// </summary>
        System.TimeSpan CoolDown { get; }

        /// <summary>
        /// Gets the range of time in which instance data is collected. This value must be greater than the delay in metric collection, which can vary from resource-to-resource. Must be between 12 hours and 5 minutes.
        /// </summary>
        /// <summary>
        /// Gets the timeWindow value.
        /// </summary>
        System.TimeSpan Duration { get; }

        /// <summary>
        /// Gets the granularity of metrics the rule monitors. Must be one of the predefined values returned from metric definitions for the metric. Must be between 12 hours and 1 minute.
        /// </summary>
        /// <summary>
        /// Gets the timeGrain value.
        /// </summary>
        System.TimeSpan Frequency { get; }

        /// <summary>
        /// Gets the metric statistic type. How the metrics from multiple instances are combined. Possible values include: 'Average', 'Min', 'Max', 'Sum'.
        /// </summary>
        /// <summary>
        /// Gets the statistic value.
        /// </summary>
        Models.MetricStatisticType FrequencyStatistic { get; }

        /// <summary>
        /// Gets the name of the metric that defines what the rule monitors.
        /// </summary>
        /// <summary>
        /// Gets the metricName value.
        /// </summary>
        string MetricName { get; }

        /// <summary>
        /// Gets the resource identifier of the resource the rule monitors.
        /// </summary>
        /// <summary>
        /// Gets the metricResourceUri value.
        /// </summary>
        string MetricSource { get; }

        /// <summary>
        /// Gets the scale direction. Whether the scaling action increases or decreases the number of instances. Possible values include: 'None', 'Increase', 'Decrease'.
        /// </summary>
        /// <summary>
        /// Gets the direction value.
        /// </summary>
        Models.ScaleDirection ScaleDirection { get; }

        /// <summary>
        /// Gets the number of instances that are involved in the scaling action.
        /// </summary>
        /// <summary>
        /// Gets the value value.
        /// </summary>
        int ScaleInstanceCount { get; }

        /// <summary>
        /// Gets the type of action that should occur when the scale rule fires. Possible values include: 'ChangeCount', 'PercentChangeCount', 'ExactCount'.
        /// </summary>
        /// <summary>
        /// Gets the type value.
        /// </summary>
        Models.ScaleType ScaleType { get; }

        /// <summary>
        /// Gets the threshold of the metric that triggers the scale action.
        /// </summary>
        /// <summary>
        /// Gets the threshold value.
        /// </summary>
        double Threshold { get; }

        /// <summary>
        /// Gets the time aggregation type. How the data that is collected should be combined over time. The default value is Average. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total', 'Count'.
        /// </summary>
        /// <summary>
        /// Gets the timeAggregation value.
        /// </summary>
        Models.TimeAggregationType TimeAggregation { get; }
    }
}