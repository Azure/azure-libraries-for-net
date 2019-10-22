// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Update
{
    using System.Collections.Generic;

    /// <summary>
    /// The stage of a activity log alerts update allowing to modify settings.
    /// </summary>
    public interface IWithActivityLogUpdate
    {

        /// <summary>
        /// Sets the actions that will activate when the condition is met.
        /// </summary>
        /// <param name="actionGroupId">Resource Ids of the  ActionGroup.</param>
        /// <return>The next stage of the activity log alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Update.IUpdate WithActionGroups(params string[] actionGroupId);

        /// <summary>
        /// Sets description for activity log alert.
        /// </summary>
        /// <param name="description">Human readable text description of the activity log alert.</param>
        /// <return>The next stage of the activity log alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Update.IUpdate WithDescription(string description);

        /// <summary>
        /// Adds a condition that will cause this alert to activate.
        /// </summary>
        /// <param name="field">Set the name of the field that this condition will examine. The possible values for this field are (case-insensitive): 'resourceId', 'category', 'caller', 'level', 'operationName', 'resourceGroup', 'resourceProvider', 'status', 'subStatus', 'resourceType', or anything beginning with 'properties.'.</param>
        /// <param name="equals">Set the field value will be compared to this value (case-insensitive) to determine if the condition is met.</param>
        /// <return>The next stage of the activity log alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Update.IUpdate WithEqualsCondition(string field, string equals);

        /// <summary>
        /// Sets all the conditions that will cause this alert to activate.
        /// </summary>
        /// <param name="fieldEqualsMap">Set the names of the field that this condition will examine and their values to be compared to.</param>
        /// <return>The next stage of the activity log alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Update.IUpdate WithEqualsConditions(IDictionary<string, string> fieldEqualsMap);

        /// <summary>
        /// Removes the specified action group from the actions list.
        /// </summary>
        /// <param name="actionGroupId">Resource Id of the  ActionGroup to remove.</param>
        /// <return>The next stage of the activity log alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Update.IUpdate WithoutActionGroup(string actionGroupId);

        /// <summary>
        /// Removes a condition from the list of conditions.
        /// </summary>
        /// <param name="field">The name of the field that was used for condition examination.</param>
        /// <return>The next stage of the activity log alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Update.IUpdate WithoutEqualsCondition(string field);

        /// <summary>
        /// Sets activity log alert as disabled.
        /// </summary>
        /// <return>The next stage of the activity log alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Update.IUpdate WithRuleDisabled();

        /// <summary>
        /// Sets activity log alert as enabled.
        /// </summary>
        /// <return>The next stage of the activity log alert update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Update.IUpdate WithRuleEnabled();
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Monitor.Fluent.IActivityLogAlert>,
        Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Update.IWithActivityLogUpdate,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Update.IUpdate>
    {

    }
}