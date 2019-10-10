// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public interface IMetricDynamicAlertCondition :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.DynamicMetricCriteria>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert>
    {
        /// <summary>
        /// Get the operator used to compare the metric value against the threshold.
        /// </summary>
        DynamicThresholdOperator Condition { get; }

        /// <summary>
        /// Get the extent of deviation required to trigger an alert. This will affect how tight the threshold is to the metric series pattern.
        /// </summary>
        DynamicThresholdSensitivity AlertSensitivity { get; }

        /// <summary>
        /// Get the minimum number of violations required within the selected lookback time window required to raise an alert.
        /// </summary>
        DynamicThresholdFailingPeriods FailingPeriods { get; }

        /// <summary>
        /// Get the date from which to start learning the metric historical data and calculate the dynamic thresholds (in ISO8601 format).
        /// </summary>
        System.DateTime? IgnoreDataBefore { get; }

        /// <summary>
        /// Gets list of dimension conditions.
        /// </summary>
        /// <summary>
        /// Gets the dimensions value.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Models.MetricDimension> Dimensions { get; }

        /// <summary>
        /// Gets name of the metric signal.
        /// </summary>
        /// <summary>
        /// Gets the metricName value.
        /// </summary>
        string MetricName { get; }

        /// <summary>
        /// Gets namespace of the metric.
        /// </summary>
        /// <summary>
        /// Gets the metricNamespace value.
        /// </summary>
        string MetricNamespace { get; }

        /// <summary>
        /// Gets name of the criteria.
        /// </summary>
        /// <summary>
        /// Gets the name value.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the criteria time aggregation types. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total'.
        /// </summary>
        /// <summary>
        /// Gets the timeAggregation value.
        /// </summary>
        MetricAlertRuleTimeAggregation TimeAggregation { get; }
    }
}
