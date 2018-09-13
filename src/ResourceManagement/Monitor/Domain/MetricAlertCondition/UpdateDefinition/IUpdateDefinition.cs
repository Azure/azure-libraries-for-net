// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.UpdateDefinition
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;

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
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.UpdateDefinition.IWithConditionAttach<ParentT> WithDimension(string dimensionName, params string[] values);
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
        /// <param name="condition">The criteria operator. Possible values include: 'Equals', 'NotEquals', 'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'.</param>
        /// <param name="timeAggregation">The criteria time aggregation types. Possible values include: 'Average', 'Minimum', 'Maximum', 'Total'.</param>
        /// <param name="threshold">The criteria threshold value that activates the alert.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.UpdateDefinition.IWithConditionAttach<ParentT> WithCondition(MetricAlertRuleTimeAggregation timeAggregation, MetricAlertRuleCondition condition, double threshold);
    }

    /// <summary>
    /// The first stage of a Metric Alert condition definition.
    /// </summary>
    public interface IBlank
    {

    }
}