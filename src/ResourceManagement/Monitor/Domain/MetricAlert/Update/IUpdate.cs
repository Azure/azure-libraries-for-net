// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update
{
    using System;

    /// <summary>
    /// The stage of a metric alerts update allowing to modify settings.
    /// </summary>
    public interface IWithMetricUpdate
    {

        /// <summary>
        /// Starts definition of the metric alert condition.
        /// </summary>
        /// <param name="name">Sets the name of the condition.</param>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.UpdateDefinition.Blank.MetricName.IMetricName<Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate> DefineAlertCriteria(string name);

        /// <summary>
        /// Starts definition of the metric dynamic alert condition.
        /// </summary>
        /// <param name="name">Sets the name of the dynamic condition.</param>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricDynamicAlertCondition.Definition.IMetricName<Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate> DefineDynamicAlertCriteria(string name);

        /// <summary>
        /// Starts update of the previously defined metric alert condition.
        /// </summary>
        /// <param name="name">Name of the condition that should be updated.</param>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Update.IUpdateStages UpdateAlertCriteria(string name);

        /// <summary>
        /// Starts update of the previously defined metric dynamic alert condition.
        /// </summary>
        /// <param name="name">Name of the dynamic condition that should be updated.</param>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricDynamicAlertCondition.Update.IUpdateStages UpdateDynamicAlertCriteria(string name);

        /// <summary>
        /// Sets the actions that will activate when the condition is met.
        /// </summary>
        /// <param name="actionGroupId">Resource Ids of the  ActionGroup.</param>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate WithActionGroups(params string[] actionGroupId);

        /// <summary>
        /// Set the flag that indicates the alert should be auto resolved.
        /// </summary>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate WithAutoMitigation();

        /// <summary>
        /// Sets description for metric alert.
        /// </summary>
        /// <param name="description">Human readable text description of the metric alert.</param>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate WithDescription(string description);

        /// <summary>
        /// Set how often the metric alert is evaluated represented in ISO 8601 duration format.
        /// </summary>
        /// <param name="frequency">The evaluationFrequency value to set.</param>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate WithFrequency(TimeSpan frequency);

        /// <summary>
        /// Removes the specified action group from the actions list.
        /// </summary>
        /// <param name="actionGroupId">Resource Id of the  ActionGroup to remove.</param>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate WithoutActionGroup(string actionGroupId);

        /// <summary>
        /// Removes a condition from the previously defined metric alert conditions.
        /// </summary>
        /// <param name="name">Name of the condition that should be removed.</param>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate WithoutAlertCriteria(string name);

        /// <summary>
        /// Set the flag that indicates the alert should not be auto resolved.
        /// </summary>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate WithoutAutoMitigation();

        /// <summary>
        /// Sets the period of time (in ISO 8601 duration format) that is used to monitor alert activity based on the threshold.
        /// </summary>
        /// <param name="size">The windowSize value to set.</param>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate WithPeriod(TimeSpan size);

        /// <summary>
        /// Sets metric alert as disabled.
        /// </summary>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate WithRuleDisabled();

        /// <summary>
        /// Sets metric alert as enabled.
        /// </summary>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate WithRuleEnabled();

        /// <summary>
        /// Set alert severity {0, 1, 2, 3, 4}.
        /// </summary>
        /// <param name="severity">The severity value to set.</param>
        /// <return>The next stage of the metric alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate WithSeverity(int severity);
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert>,
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IWithMetricUpdate,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update.IUpdate>
    {

    }
}