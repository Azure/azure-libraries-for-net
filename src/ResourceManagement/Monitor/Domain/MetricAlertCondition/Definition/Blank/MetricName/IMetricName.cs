// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Definition.Blank.MetricName
{
    using Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Definition;

    /// <summary>
    /// The stage of the definition which specifies metric signal name.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Metric Alert definition to return to after attaching this definition.</typeparam>
    public interface IMetricName<ParentT>
    {

        /// <summary>
        /// Sets the name of the signal name to monitor.
        /// </summary>
        /// <param name="metricName">Metric name of the signal.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Definition.IWithCriteriaOperator<ParentT> WithMetricName(string metricName);

        /// <summary>
        /// Sets the name of the signal name to monitor.
        /// </summary>
        /// <param name="metricName">Metric name of the signal.</param>
        /// <param name="metricNamespace">The Namespace of the metric.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Definition.IWithCriteriaOperator<ParentT> WithMetricName(string metricName, string metricNamespace);
    }
}