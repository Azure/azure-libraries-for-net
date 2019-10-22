// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition;
    using Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;

    internal partial class MetricAlertImpl
    {
        /// <summary>
        /// Gets the array of actions that are performed when the alert rule becomes active, and when an alert condition is resolved.
        /// </summary>
        /// <summary>
        /// Gets the actions value.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert.ActionGroupIds
        {
            get
            {
                return this.ActionGroupIds();
            }
        }

        /// <summary>
        /// Gets metric alert criterias, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Monitor.Fluent.IMetricAlertCondition> Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert.AlertCriterias
        {
            get
            {
                return this.AlertCriterias();
            }
        }

        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Monitor.Fluent.IMetricDynamicAlertCondition> Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert.DynamicAlertCriterias
        {
            get
            {
                return this.DynamicAlertCriterias();
            }
        }

        /// <summary>
        /// Gets the flag that indicates whether the alert should be auto resolved or not.
        /// </summary>
        /// <summary>
        /// Gets the autoMitigate value.
        /// </summary>
        bool Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert.AutoMitigate
        {
            get
            {
                return this.AutoMitigate();
            }
        }

        /// <summary>
        /// Gets the description of the metric alert that will be included in the alert email.
        /// </summary>
        /// <summary>
        /// Gets the description value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert.Description
        {
            get
            {
                return this.Description();
            }
        }

        /// <summary>
        /// Gets the flag that indicates whether the metric alert is enabled.
        /// </summary>
        /// <summary>
        /// Gets the enabled value.
        /// </summary>
        bool Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert.Enabled
        {
            get
            {
                return this.Enabled();
            }
        }

        /// <summary>
        /// Gets how often the metric alert is evaluated represented in ISO 8601 duration format.
        /// </summary>
        /// <summary>
        /// Gets the evaluationFrequency value.
        /// </summary>
        System.TimeSpan Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert.EvaluationFrequency
        {
            get
            {
                return this.EvaluationFrequency();
            }
        }

        /// <summary>
        /// Gets last time the rule was updated in ISO8601 format.
        /// </summary>
        /// <summary>
        /// Gets the lastUpdatedTime value.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert.LastUpdatedTime
        {
            get
            {
                return this.LastUpdatedTime();
            }
        }

        /// <summary>
        /// Gets the list of resource id's that this metric alert is scoped to.
        /// </summary>
        /// <summary>
        /// Gets the scopes value.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert.Scopes
        {
            get
            {
                return this.Scopes();
            }
        }

        /// <summary>
        /// Gets alert severity {0, 1, 2, 3, 4}.
        /// </summary>
        /// <summary>
        /// Gets the severity value.
        /// </summary>
        int Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert.Severity
        {
            get
            {
                return this.Severity();
            }
        }

        /// <summary>
        /// Gets the period of time (in ISO 8601 duration format) that is used to monitor alert activity based on the threshold.
        /// </summary>
        /// <summary>
        /// Gets the windowSize value.
        /// </summary>
        System.TimeSpan Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert.WindowSize
        {
            get
            {
                return this.WindowSize();
            }
        }

        /// <summary>
        /// Starts definition of the metric alert condition.
        /// </summary>
        /// <param name="name">Sets the name of the condition.</param>
        /// <return>The next stage of the metric alert update.</return>
        MetricAlertCondition.UpdateDefinition.Blank.MetricName.IMetricName<MetricAlert.Update.IUpdate> MetricAlert.Update.IWithMetricUpdate.DefineAlertCriteria(string name)
        {
            return this.DefineAlertCriteria(name);
        }

        /// <summary>
        /// Starts definition of the metric alert condition.
        /// </summary>
        /// <param name="name">Sets the name of the condition.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        MetricAlertCondition.Definition.Blank.MetricName.IMetricName<MetricAlert.Definition.IWithCreate> MetricAlert.Definition.IWithCriteriaDefinition.DefineAlertCriteria(string name)
        {
            return this.DefineAlertCriteria(name);
        }

        /// <summary>
        /// Starts update of the previously defined metric alert condition.
        /// </summary>
        /// <param name="name">Name of the condition that should be updated.</param>
        /// <return>The next stage of the metric alert update.</return>
        MetricAlertCondition.Update.IUpdateStages MetricAlert.Update.IWithMetricUpdate.UpdateAlertCriteria(string name)
        {
            return this.UpdateAlertCriteria(name);
        }

        /// <summary>
        /// Sets the actions that will activate when the condition is met.
        /// </summary>
        /// <param name="actionGroupId">Resource Ids of the  ActionGroup.</param>
        /// <return>The next stage of the metric alert update.</return>
        MetricAlert.Update.IUpdate MetricAlert.Update.IWithMetricUpdate.WithActionGroups(params string[] actionGroupId)
        {
            return this.WithActionGroups(actionGroupId);
        }

        /// <summary>
        /// Sets the actions that will activate when the condition is met.
        /// </summary>
        /// <param name="actionGroupId">Resource Ids of the  ActionGroup.</param>
        /// <return>The next stage of metric alert definition.</return>
        MetricAlert.Definition.IWithCriteriaDefinition MetricAlert.Definition.IWithActionGroup.WithActionGroups(params string[] actionGroupId)
        {
            return this.WithActionGroups(actionGroupId);
        }

        /// <summary>
        /// Set alert severity {0, 1, 2, 3, 4} and description.
        /// </summary>
        /// <param name="severity">The severity value to set.</param>
        /// <param name="description">Human readable text description of the metric alert.</param>
        /// <return>The next stage of metric alert definition.</return>
        MetricAlert.Definition.IWithActionGroup MetricAlert.Definition.IWithSeverity.WithAlertDetails(int severity, string description)
        {
            return this.WithAlertDetails(severity, description);
        }

        /// <summary>
        /// Set the flag that indicates the alert should be auto resolved.
        /// </summary>
        /// <return>The next stage of the metric alert update.</return>
        MetricAlert.Update.IUpdate MetricAlert.Update.IWithMetricUpdate.WithAutoMitigation()
        {
            return this.WithAutoMitigation();
        }

        /// <summary>
        /// Sets description for metric alert.
        /// </summary>
        /// <param name="description">Human readable text description of the metric alert.</param>
        /// <return>The next stage of the metric alert update.</return>
        MetricAlert.Update.IUpdate MetricAlert.Update.IWithMetricUpdate.WithDescription(string description)
        {
            return this.WithDescription(description);
        }

        /// <summary>
        /// Set how often the metric alert is evaluated represented in ISO 8601 duration format.
        /// </summary>
        /// <param name="frequency">The evaluationFrequency value to set.</param>
        /// <return>The next stage of the metric alert update.</return>
        MetricAlert.Update.IUpdate MetricAlert.Update.IWithMetricUpdate.WithFrequency(TimeSpan frequency)
        {
            return this.WithFrequency(frequency);
        }

        /// <summary>
        /// Set how often the metric alert is evaluated represented in ISO 8601 duration format.
        /// </summary>
        /// <param name="frequency">The evaluationFrequency value to set.</param>
        /// <return>The next stage of metric alert definition.</return>
        MetricAlert.Definition.IWithSeverity MetricAlert.Definition.IWithEvaluationFrequency.WithFrequency(TimeSpan frequency)
        {
            return this.WithFrequency(frequency);
        }

        /// <summary>
        /// Removes the specified action group from the actions list.
        /// </summary>
        /// <param name="actionGroupId">Resource Id of the  ActionGroup to remove.</param>
        /// <return>The next stage of the metric alert update.</return>
        MetricAlert.Update.IUpdate MetricAlert.Update.IWithMetricUpdate.WithoutActionGroup(string actionGroupId)
        {
            return this.WithoutActionGroup(actionGroupId);
        }

        /// <summary>
        /// Removes a condition from the previously defined metric alert conditions.
        /// </summary>
        /// <param name="name">Name of the condition that should be removed.</param>
        /// <return>The next stage of the metric alert update.</return>
        MetricAlert.Update.IUpdate MetricAlert.Update.IWithMetricUpdate.WithoutAlertCriteria(string name)
        {
            return this.WithoutAlertCriteria(name);
        }

        /// <summary>
        /// Set the flag that indicates the alert should not be auto resolved.
        /// </summary>
        /// <return>The next stage of the metric alert update.</return>
        MetricAlert.Update.IUpdate MetricAlert.Update.IWithMetricUpdate.WithoutAutoMitigation()
        {
            return this.WithoutAutoMitigation();
        }

        /// <summary>
        /// Set the flag that indicates the alert should not be auto resolved.
        /// </summary>
        /// <return>The next stage of metric alert condition definition.</return>
        MetricAlert.Definition.IWithCreate MetricAlert.Definition.IWithCreate.WithoutAutoMitigation()
        {
            return this.WithoutAutoMitigation();
        }

        /// <summary>
        /// Sets the period of time (in ISO 8601 duration format) that is used to monitor alert activity based on the threshold.
        /// </summary>
        /// <param name="size">The windowSize value to set.</param>
        /// <return>The next stage of the metric alert update.</return>
        MetricAlert.Update.IUpdate MetricAlert.Update.IWithMetricUpdate.WithPeriod(TimeSpan size)
        {
            return this.WithPeriod(size);
        }

        /// <summary>
        /// Sets the period of time (in ISO 8601 duration format) that is used to monitor alert activity based on the threshold.
        /// </summary>
        /// <param name="size">The windowSize value to set.</param>
        /// <return>The next stage of metric alert definition.</return>
        MetricAlert.Definition.IWithEvaluationFrequency MetricAlert.Definition.IWithWindowSize.WithPeriod(TimeSpan size)
        {
            return this.WithPeriod(size);
        }

        /// <summary>
        /// Sets metric alert as disabled.
        /// </summary>
        /// <return>The next stage of the metric alert update.</return>
        MetricAlert.Update.IUpdate MetricAlert.Update.IWithMetricUpdate.WithRuleDisabled()
        {
            return this.WithRuleDisabled();
        }

        /// <summary>
        /// Sets metric alert as disabled during the creation.
        /// </summary>
        /// <return>The next stage of metric alert definition.</return>
        MetricAlert.Definition.IWithActionGroup MetricAlert.Definition.IWithCreate.WithRuleDisabled()
        {
            return this.WithRuleDisabled();
        }

        /// <summary>
        /// Sets metric alert as enabled.
        /// </summary>
        /// <return>The next stage of the metric alert update.</return>
        MetricAlert.Update.IUpdate MetricAlert.Update.IWithMetricUpdate.WithRuleEnabled()
        {
            return this.WithRuleEnabled();
        }

        /// <summary>
        /// Set alert severity {0, 1, 2, 3, 4}.
        /// </summary>
        /// <param name="severity">The severity value to set.</param>
        /// <return>The next stage of the metric alert update.</return>
        MetricAlert.Update.IUpdate MetricAlert.Update.IWithMetricUpdate.WithSeverity(int severity)
        {
            return this.WithSeverity(severity);
        }

        /// <summary>
        /// Sets specified resource as a target to alert on metric.
        /// </summary>
        /// <param name="resourceId">Resource Id string.</param>
        /// <return>The next stage of metric alert definition.</return>
        MetricAlert.Definition.IWithWindowSize MetricAlert.Definition.IWithScopes.WithTargetResource(string resourceId)
        {
            return this.WithTargetResource(resourceId);
        }

        /// <summary>
        /// Sets specified resource as a target to alert on metric.
        /// </summary>
        /// <param name="resource">Resource type that is inherited from  HasId interface.</param>
        /// <return>The next stage of metric alert definition.</return>
        MetricAlert.Definition.IWithWindowSize MetricAlert.Definition.IWithScopes.WithTargetResource(IHasId resource)
        {
            return this.WithTargetResource(resource);
        }

        IWithWindowSizeMultipleResource IWithScopes.WithMultipleTargetResources(IEnumerable<string> resourceIds, string type, string regionName)
        {
            return this.WithMultipleTargetResources(resourceIds, type, regionName);
        }

        IWithWindowSizeMultipleResource IWithScopes.WithMultipleTargetResources(IEnumerable<IResource> resources)
        {
            return this.WithMultipleTargetResources(resources);
        }

        IWithEvaluationFrequency IWithWindowSizeMultipleResource.WithPeriod(TimeSpan size)
        {
            return this.WithPeriod(size);
        }

        IWithSeverity IWithEvaluationFrequencyMultipleResource.WithFrequency(TimeSpan frequency)
        {
            return this.WithFrequency(frequency);
        }

        IWithActionGroup IWithSeverityMultipleResource.WithAlertDetails(int severity, string description)
        {
            return this.WithAlertDetails(severity, description);
        }

        IWithCriteriaDefinition IWithActionGroupMultipleResource.WithActionGroups(params string[] actionGroupId)
        {
            return this.WithActionGroups(actionGroupId);
        }

        MetricAlertCondition.Definition.Blank.MetricName.IMetricName<IWithCreate> IWithDynamicCriteriaDefinition.DefineAlertCriteria(string name)
        {
            return this.DefineAlertCriteria(name);
        }

        MetricDynamicAlertCondition.Definition.IMetricName<IWithCreateDynamicCondition> IWithDynamicCriteriaDefinition.DefineDynamicAlertCriteria(string name)
        {
            return this.DefineDynamicAlertCriteria(name);
        }

        MetricDynamicAlertCondition.Definition.IMetricName<IUpdate> IWithMetricUpdate.DefineDynamicAlertCriteria(string name)
        {
            return this.DefineDynamicAlertCriteria(name);
        }

        MetricDynamicAlertCondition.Update.IUpdateStages IWithMetricUpdate.UpdateDynamicAlertCriteria(string name)
        {
            return this.DefineDynamicAlertCriteria(name);
        }

        IWithCreate IWithCreateDynamicCondition.WithoutAutoMitigation()
        {
            return this.WithoutAutoMitigation();
        }

        IWithActionGroup IWithCreateDynamicCondition.WithRuleDisabled()
        {
            return this.WithRuleDisabled();
        }

        IWithCreateDynamicCondition ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<IWithCreateDynamicCondition>.WithTags(IDictionary<string, string> tags)
        {
            return this.WithTags(tags);
        }

        IWithCreateDynamicCondition ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<IWithCreateDynamicCondition>.WithTag(string key, string value)
        {
            return this.WithTag(key, value);
        }
    }
}