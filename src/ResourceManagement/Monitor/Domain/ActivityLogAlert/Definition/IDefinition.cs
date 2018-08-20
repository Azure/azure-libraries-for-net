// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The entirety of a activity log alerts definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IBlank,
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithCreate,
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithScopes,
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithDescription,
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithAlertEnabled,
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithActionGroup,
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithCriteriaDefinition
    {

    }

    /// <summary>
    /// The stage of the definition which specifies actions that will be activated when the conditions are met in the activity log alert rules.
    /// </summary>
    public interface IWithActionGroup
    {

        /// <summary>
        /// Sets the actions that will activate when the condition is met.
        /// </summary>
        /// <param name="actionGroupId">Resource Ids of the  ActionGroup.</param>
        /// <return>The next stage of activity log alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithCriteriaDefinition WithActionGroups(params string[] actionGroupId);
    }

    /// <summary>
    /// The stage of the definition which specifies description text for activity log alert.
    /// </summary>
    public interface IWithDescription
    {

        /// <summary>
        /// Sets description for activity log alert.
        /// </summary>
        /// <param name="description">Human readable text description of the activity log alert.</param>
        /// <return>The next stage of activity log alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithAlertEnabled WithDescription(string description);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Monitor.Fluent.IActivityLogAlert>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithCreate>,
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithCriteriaDefinition
    {

    }

    /// <summary>
    /// The stage of the definition which specifies if the activity log alert should be enabled upon creation.
    /// </summary>
    public interface IWithAlertEnabled
    {

        /// <summary>
        /// Sets activity log alert as disabled during the creation.
        /// </summary>
        /// <return>The next stage of activity log alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithActionGroup WithRuleDisabled();

        /// <summary>
        /// Sets activity log alert as enabled during the creation.
        /// </summary>
        /// <return>The next stage of activity log alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithActionGroup WithRuleEnabled();
    }

    /// <summary>
    /// The stage of the definition which specifies condition that will cause this alert to activate.
    /// </summary>
    public interface IWithCriteriaDefinition
    {

        /// <summary>
        /// Adds a condition that will cause this alert to activate.
        /// </summary>
        /// <param name="field">Set the name of the field that this condition will examine. The possible values for this field are (case-insensitive): 'resourceId', 'category', 'caller', 'level', 'operationName', 'resourceGroup', 'resourceProvider', 'status', 'subStatus', 'resourceType', or anything beginning with 'properties.'.</param>
        /// <param name="equals">Set the field value will be compared to this value (case-insensitive) to determine if the condition is met.</param>
        /// <return>The next stage of activity log alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithCreate WithEqualsCondition(string field, string equals);

        /// <summary>
        /// Sets all the conditions that will cause this alert to activate.
        /// </summary>
        /// <param name="fieldEqualsMap">Set the names of the field that this condition will examine and their values to be compared to.</param>
        /// <return>The next stage of activity log alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithCreate WithEqualsConditions(IDictionary<string, string> fieldEqualsMap);
    }

    /// <summary>
    /// The first stage of a activity log alert definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroupAndRegion<Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithScopes>
    {

    }

    /// <summary>
    /// The stage of the definition which specifies target resource or subscription for activity log alert.
    /// </summary>
    public interface IWithScopes
    {

        /// <summary>
        /// Sets specified resource as a target to alert on activity log.
        /// </summary>
        /// <param name="resourceId">Resource Id string.</param>
        /// <return>The next stage of activity log alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithDescription WithTargetResource(string resourceId);

        /// <summary>
        /// Sets specified resource as a target to alert on activity log.
        /// </summary>
        /// <param name="resource">Resource type that is inherited from  HasId interface.</param>
        /// <return>The next stage of activity log alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithDescription WithTargetResource(IHasId resource);

        /// <summary>
        /// Sets specified subscription as a target to alert on activity log.
        /// </summary>
        /// <param name="targetSubscriptionId">Subscription Id.</param>
        /// <return>The next stage of activity log alert definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition.IWithDescription WithTargetSubscription(string targetSubscriptionId);
    }
}