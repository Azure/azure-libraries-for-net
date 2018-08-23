// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    /// <summary>
    /// An immutable client-side representation of an Azure Activity Log Alert.
    /// </summary>
    public interface IActivityLogAlert :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<MonitorManager, Models.ActivityLogAlertResourceInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Monitor.Fluent.IActivityLogAlert>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ActivityLogAlert.Update.IUpdate>
    {

        /// <summary>
        /// Gets the actions that will activate when the condition is met.
        /// </summary>
        /// <summary>
        /// Gets the actions value.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> ActionGroupIds { get; }

        /// <summary>
        /// Gets a description of this activity log alert.
        /// </summary>
        /// <summary>
        /// Gets the description value.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets indicates whether this activity log alert is enabled. If an activity log alert is not enabled, then none of its actions will be activated.
        /// </summary>
        /// <summary>
        /// Gets the enabled value.
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// Gets the condition that will cause this alert to activate.
        /// </summary>
        /// <summary>
        /// Gets the condition value.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, string> EqualsConditions { get; }

        /// <summary>
        /// Gets a list of resourceIds that will be used as prefixes. The alert will only apply to activityLogs with resourceIds that fall under one of these prefixes. This list must include at least one item.
        /// </summary>
        /// <summary>
        /// Gets the scopes value.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> Scopes { get; }
    }
}