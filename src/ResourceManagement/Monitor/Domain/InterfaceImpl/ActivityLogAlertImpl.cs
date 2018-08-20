// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class ActivityLogAlertImpl
    {
        /// <summary>
        /// Gets the actions that will activate when the condition is met.
        /// </summary>
        /// <summary>
        /// Gets the actions value.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> Microsoft.Azure.Management.Monitor.Fluent.IActivityLogAlert.ActionGroupIds
        {
            get
            {
                return this.ActionGroupIds();
            }
        }

        /// <summary>
        /// Gets a description of this activity log alert.
        /// </summary>
        /// <summary>
        /// Gets the description value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IActivityLogAlert.Description
        {
            get
            {
                return this.Description();
            }
        }

        /// <summary>
        /// Gets indicates whether this activity log alert is enabled. If an activity log alert is not enabled, then none of its actions will be activated.
        /// </summary>
        /// <summary>
        /// Gets the enabled value.
        /// </summary>
        bool Microsoft.Azure.Management.Monitor.Fluent.IActivityLogAlert.Enabled
        {
            get
            {
                return this.Enabled();
            }
        }

        /// <summary>
        /// Gets the condition that will cause this alert to activate.
        /// </summary>
        /// <summary>
        /// Gets the condition value.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Microsoft.Azure.Management.Monitor.Fluent.IActivityLogAlert.EqualsConditions
        {
            get
            {
                return this.EqualsConditions();
            }
        }

        /// <summary>
        /// Gets a list of resourceIds that will be used as prefixes. The alert will only apply to activityLogs with resourceIds that fall under one of these prefixes. This list must include at least one item.
        /// </summary>
        /// <summary>
        /// Gets the scopes value.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> Microsoft.Azure.Management.Monitor.Fluent.IActivityLogAlert.Scopes
        {
            get
            {
                return this.Scopes();
            }
        }

        /// <summary>
        /// Sets the actions that will activate when the condition is met.
        /// </summary>
        /// <param name="actionGroupId">Resource Ids of the  ActionGroup.</param>
        /// <return>The next stage of activity log alert definition.</return>
        ActivityLogAlert.Definition.IWithCriteriaDefinition ActivityLogAlert.Definition.IWithActionGroup.WithActionGroups(params string[] actionGroupId)
        {
            return this.WithActionGroups(actionGroupId);
        }

        /// <summary>
        /// Sets the actions that will activate when the condition is met.
        /// </summary>
        /// <param name="actionGroupId">Resource Ids of the  ActionGroup.</param>
        /// <return>The next stage of the activity log alert update.</return>
        ActivityLogAlert.Update.IUpdate ActivityLogAlert.Update.IWithActivityLogUpdate.WithActionGroups(params string[] actionGroupId)
        {
            return this.WithActionGroups(actionGroupId);
        }

        /// <summary>
        /// Sets description for activity log alert.
        /// </summary>
        /// <param name="description">Human readable text description of the activity log alert.</param>
        /// <return>The next stage of activity log alert definition.</return>
        ActivityLogAlert.Definition.IWithAlertEnabled ActivityLogAlert.Definition.IWithDescription.WithDescription(string description)
        {
            return this.WithDescription(description);
        }

        /// <summary>
        /// Sets description for activity log alert.
        /// </summary>
        /// <param name="description">Human readable text description of the activity log alert.</param>
        /// <return>The next stage of the activity log alert update.</return>
        ActivityLogAlert.Update.IUpdate ActivityLogAlert.Update.IWithActivityLogUpdate.WithDescription(string description)
        {
            return this.WithDescription(description);
        }

        /// <summary>
        /// Adds a condition that will cause this alert to activate.
        /// </summary>
        /// <param name="field">Set the name of the field that this condition will examine. The possible values for this field are (case-insensitive): 'resourceId', 'category', 'caller', 'level', 'operationName', 'resourceGroup', 'resourceProvider', 'status', 'subStatus', 'resourceType', or anything beginning with 'properties.'.</param>
        /// <param name="equals">Set the field value will be compared to this value (case-insensitive) to determine if the condition is met.</param>
        /// <return>The next stage of the activity log alert update.</return>
        ActivityLogAlert.Update.IUpdate ActivityLogAlert.Update.IWithActivityLogUpdate.WithEqualsCondition(string field, string equals)
        {
            return this.WithEqualsCondition(field, equals);
        }

        /// <summary>
        /// Adds a condition that will cause this alert to activate.
        /// </summary>
        /// <param name="field">Set the name of the field that this condition will examine. The possible values for this field are (case-insensitive): 'resourceId', 'category', 'caller', 'level', 'operationName', 'resourceGroup', 'resourceProvider', 'status', 'subStatus', 'resourceType', or anything beginning with 'properties.'.</param>
        /// <param name="equals">Set the field value will be compared to this value (case-insensitive) to determine if the condition is met.</param>
        /// <return>The next stage of activity log alert definition.</return>
        ActivityLogAlert.Definition.IWithCreate ActivityLogAlert.Definition.IWithCriteriaDefinition.WithEqualsCondition(string field, string equals)
        {
            return this.WithEqualsCondition(field, equals);
        }

        /// <summary>
        /// Sets all the conditions that will cause this alert to activate.
        /// </summary>
        /// <param name="fieldEqualsMap">Set the names of the field that this condition will examine and their values to be compared to.</param>
        /// <return>The next stage of the activity log alert update.</return>
        ActivityLogAlert.Update.IUpdate ActivityLogAlert.Update.IWithActivityLogUpdate.WithEqualsConditions(IDictionary<string, string> fieldEqualsMap)
        {
            return this.WithEqualsConditions(fieldEqualsMap);
        }

        /// <summary>
        /// Sets all the conditions that will cause this alert to activate.
        /// </summary>
        /// <param name="fieldEqualsMap">Set the names of the field that this condition will examine and their values to be compared to.</param>
        /// <return>The next stage of activity log alert definition.</return>
        ActivityLogAlert.Definition.IWithCreate ActivityLogAlert.Definition.IWithCriteriaDefinition.WithEqualsConditions(IDictionary<string, string> fieldEqualsMap)
        {
            return this.WithEqualsConditions(fieldEqualsMap);
        }

        /// <summary>
        /// Removes the specified action group from the actions list.
        /// </summary>
        /// <param name="actionGroupId">Resource Id of the  ActionGroup to remove.</param>
        /// <return>The next stage of the activity log alert update.</return>
        ActivityLogAlert.Update.IUpdate ActivityLogAlert.Update.IWithActivityLogUpdate.WithoutActionGroup(string actionGroupId)
        {
            return this.WithoutActionGroup(actionGroupId);
        }

        /// <summary>
        /// Removes a condition from the list of conditions.
        /// </summary>
        /// <param name="field">The name of the field that was used for condition examination.</param>
        /// <return>The next stage of the activity log alert update.</return>
        ActivityLogAlert.Update.IUpdate ActivityLogAlert.Update.IWithActivityLogUpdate.WithoutEqualsCondition(string field)
        {
            return this.WithoutEqualsCondition(field);
        }

        /// <summary>
        /// Sets activity log alert as disabled.
        /// </summary>
        /// <return>The next stage of the activity log alert update.</return>
        ActivityLogAlert.Update.IUpdate ActivityLogAlert.Update.IWithActivityLogUpdate.WithRuleDisabled()
        {
            return this.WithRuleDisabled();
        }

        /// <summary>
        /// Sets activity log alert as disabled during the creation.
        /// </summary>
        /// <return>The next stage of activity log alert definition.</return>
        ActivityLogAlert.Definition.IWithActionGroup ActivityLogAlert.Definition.IWithAlertEnabled.WithRuleDisabled()
        {
            return this.WithRuleDisabled();
        }

        /// <summary>
        /// Sets activity log alert as enabled.
        /// </summary>
        /// <return>The next stage of the activity log alert update.</return>
        ActivityLogAlert.Update.IUpdate ActivityLogAlert.Update.IWithActivityLogUpdate.WithRuleEnabled()
        {
            return this.WithRuleEnabled();
        }

        /// <summary>
        /// Sets activity log alert as enabled during the creation.
        /// </summary>
        /// <return>The next stage of activity log alert definition.</return>
        ActivityLogAlert.Definition.IWithActionGroup ActivityLogAlert.Definition.IWithAlertEnabled.WithRuleEnabled()
        {
            return this.WithRuleEnabled();
        }

        /// <summary>
        /// Sets specified resource as a target to alert on activity log.
        /// </summary>
        /// <param name="resourceId">Resource Id string.</param>
        /// <return>The next stage of activity log alert definition.</return>
        ActivityLogAlert.Definition.IWithDescription ActivityLogAlert.Definition.IWithScopes.WithTargetResource(string resourceId)
        {
            return this.WithTargetResource(resourceId);
        }

        /// <summary>
        /// Sets specified resource as a target to alert on activity log.
        /// </summary>
        /// <param name="resource">Resource type that is inherited from  HasId interface.</param>
        /// <return>The next stage of activity log alert definition.</return>
        ActivityLogAlert.Definition.IWithDescription ActivityLogAlert.Definition.IWithScopes.WithTargetResource(IHasId resource)
        {
            return this.WithTargetResource(resource);
        }

        /// <summary>
        /// Sets specified subscription as a target to alert on activity log.
        /// </summary>
        /// <param name="targetSubscriptionId">Subscription Id.</param>
        /// <return>The next stage of activity log alert definition.</return>
        ActivityLogAlert.Definition.IWithDescription ActivityLogAlert.Definition.IWithScopes.WithTargetSubscription(string targetSubscriptionId)
        {
            return this.WithTargetSubscription(targetSubscriptionId);
        }
    }
}