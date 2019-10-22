// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    /// <summary>
    /// An immutable client-side representation of a Metric Alert.
    /// </summary>
    public interface IMetricAlert :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<MonitorManager, Models.MetricAlertResourceInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<MetricAlert.Update.IUpdate>
    {

        /// <summary>
        /// Gets the array of actions that are performed when the alert rule becomes active, and when an alert condition is resolved.
        /// </summary>
        /// <summary>
        /// Gets the actions value.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> ActionGroupIds { get; }

        /// <summary>
        /// Gets metric alert criterias, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Monitor.Fluent.IMetricAlertCondition> AlertCriterias { get; }

        /// <summary>
        /// Gets metric dynamic alert criterias, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Monitor.Fluent.IMetricDynamicAlertCondition> DynamicAlertCriterias { get; }

        /// <summary>
        /// Gets the flag that indicates whether the alert should be auto resolved or not.
        /// </summary>
        /// <summary>
        /// Gets the autoMitigate value.
        /// </summary>
        bool AutoMitigate { get; }

        /// <summary>
        /// Gets the description of the metric alert that will be included in the alert email.
        /// </summary>
        /// <summary>
        /// Gets the description value.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the flag that indicates whether the metric alert is enabled.
        /// </summary>
        /// <summary>
        /// Gets the enabled value.
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// Gets how often the metric alert is evaluated represented in ISO 8601 duration format.
        /// </summary>
        /// <summary>
        /// Gets the evaluationFrequency value.
        /// </summary>
        System.TimeSpan EvaluationFrequency { get; }

        /// <summary>
        /// Gets last time the rule was updated in ISO8601 format.
        /// </summary>
        /// <summary>
        /// Gets the lastUpdatedTime value.
        /// </summary>
        System.DateTime? LastUpdatedTime { get; }

        /// <summary>
        /// Gets the list of resource id's that this metric alert is scoped to.
        /// </summary>
        /// <summary>
        /// Gets the scopes value.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> Scopes { get; }

        /// <summary>
        /// Gets alert severity {0, 1, 2, 3, 4}.
        /// </summary>
        /// <summary>
        /// Gets the severity value.
        /// </summary>
        int Severity { get; }

        /// <summary>
        /// Gets the period of time (in ISO 8601 duration format) that is used to monitor alert activity based on the threshold.
        /// </summary>
        /// <summary>
        /// Gets the windowSize value.
        /// </summary>
        System.TimeSpan WindowSize { get; }
    }
}