// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition
{
    using Microsoft.Azure.Management.Monitor.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Monitor.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Monitor.Fluent;
    using Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Definition.Blank.MetricName;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Monitor.Fluent;
    using Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Definition.Blank.MetricName;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Monitor.Fluent;
    using Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Definition.Blank.MetricName;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Monitor.Fluent;
    using Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Definition.Blank.MetricName;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using Microsoft.Azure.Management.Monitor.Fluent;
    using Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Definition.Blank.MetricName;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using Microsoft.Azure.Management.Monitor.Fluent;
    using Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Definition.Blank.MetricName;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using Microsoft.Azure.Management.Monitor.Fluent;
    using Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Definition.Blank.MetricName;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using Microsoft.Azure.Management.Monitor.Fluent;
    using Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Definition.Blank.MetricName;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using Microsoft.Azure.Management.Monitor.Fluent;
    using Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Definition.Blank.MetricName;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithCreate>,
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithCriteriaDefinition
    {

        /// <summary>
        /// Set the flag that indicates the alert should be auto resolved.
        /// </summary>
        /// <return>The next stage of metric alert condition definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithCreate WithAutoMitigation();
    }

    /// <summary>
    /// The stage of the definition which specifies target resource for metric alert.
    /// </summary>
    public interface IWithScopes 
    {

        /// <summary>
        /// Sets specified resource as a target to alert on metric.
        /// </summary>
        /// <param name="resourceId">Resource Id string.</param>
        /// <return>The next stage of metric alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithWindowSize WithTargetResource(string resourceId);

        /// <summary>
        /// Sets specified resource as a target to alert on metric.
        /// </summary>
        /// <param name="resource">Resource type that is inherited from  HasId interface.</param>
        /// <return>The next stage of metric alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithWindowSize WithTargetResource(IHasId resource);
    }

    /// <summary>
    /// The stage of the definition which specifies condition that will cause this alert to activate.
    /// </summary>
    public interface IWithCriteriaDefinition 
    {

        /// <summary>
        /// Starts definition of the metric alert condition.
        /// </summary>
        /// <param name="name">Sets the name of the condition.</param>
        /// <return>The next stage of metric alert condition definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlertCondition.Definition.Blank.MetricName.IMetricName<Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithCreate> DefineAlertCriteria(string name);
    }

    /// <summary>
    /// The stage of the definition which specifies severity for metric alert.
    /// </summary>
    public interface IWithSeverity 
    {

        /// <summary>
        /// Set alert severity {0, 1, 2, 3, 4}.
        /// </summary>
        /// <param name="severity">The severity value to set.</param>
        /// <return>The next stage of metric alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithDescription WithSeverity(int severity);
    }

    /// <summary>
    /// The stage of the definition which specifies if the metric alert should be enabled upon creation.
    /// </summary>
    public interface IWithAlertEnabled 
    {

        /// <summary>
        /// Sets metric alert as disabled during the creation.
        /// </summary>
        /// <return>The next stage of metric alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithActionGroup WithRuleDisabled();

        /// <summary>
        /// Sets metric alert as enabled during the creation.
        /// </summary>
        /// <return>The next stage of metric alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithActionGroup WithRuleEnabled();
    }

    /// <summary>
    /// The stage of the definition which specifies monitoring window for metric alert.
    /// </summary>
    public interface IWithWindowSize 
    {

        /// <summary>
        /// Sets the period of time (in ISO 8601 duration format) that is used to monitor alert activity based on the threshold.
        /// </summary>
        /// <param name="size">The windowSize value to set.</param>
        /// <return>The next stage of metric alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithEvaluationFrequency WithWindowSize(TimeSpan size);
    }

    /// <summary>
    /// The first stage of a Metric Alert definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroupAndRegion<Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithScopes>
    {

    }

    /// <summary>
    /// The stage of the definition which specifies evaluation frequency for metric alert.
    /// </summary>
    public interface IWithEvaluationFrequency 
    {

        /// <summary>
        /// Set how often the metric alert is evaluated represented in ISO 8601 duration format.
        /// </summary>
        /// <param name="frequency">The evaluationFrequency value to set.</param>
        /// <return>The next stage of metric alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithSeverity WithEvaluationFrequency(TimeSpan frequency);
    }

    /// <summary>
    /// The stage of the definition which specifies actions that will be activated when the conditions are met in the metric alert rules.
    /// </summary>
    public interface IWithActionGroup 
    {

        /// <summary>
        /// Sets the actions that will activate when the condition is met.
        /// </summary>
        /// <param name="actionGroupId">Resource Ids of the  ActionGroup.</param>
        /// <return>The next stage of metric alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithCriteriaDefinition WithActionGroups(params string[] actionGroupId);
    }

    /// <summary>
    /// The stage of the definition which specifies description text for metric alert.
    /// </summary>
    public interface IWithDescription 
    {

        /// <summary>
        /// Sets description for metric alert.
        /// </summary>
        /// <param name="description">Human readable text description of the metric alert.</param>
        /// <return>The next stage of metric alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithAlertEnabled WithDescription(string description);
    }

    /// <summary>
    /// The entirety of a Metric Alert definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IBlank,
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithCreate,
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithScopes,
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithWindowSize,
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithEvaluationFrequency,
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithSeverity,
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithDescription,
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithAlertEnabled,
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithActionGroup,
        Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition.IWithCriteriaDefinition
    {

    }
}