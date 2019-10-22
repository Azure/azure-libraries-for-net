// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure metric alert criteria.
    /// </summary>
    public interface IMetricAlertCondition :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.MetricCriteria>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert>
    {

        /// <summary>
        /// Gets the criteria operator. Possible values include: 'Equals', 'NotEquals', 'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'.
        /// </summary>
        /// <summary>
        /// Gets the operator value.
        /// </summary>
        Models.MetricAlertRuleCondition Condition { get; }

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
        /// Gets the criteria threshold value that activates the alert.
        /// </summary>
        /// <summary>
        /// Gets the threshold value.
        /// </summary>
        double Threshold { get; }

        /// <summary>
        /// Gets the criteria time aggregation types. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total'.
        /// </summary>
        /// <summary>
        /// Gets the timeAggregation value.
        /// </summary>
        Models.MetricAlertRuleTimeAggregation TimeAggregation { get; }
    }
}