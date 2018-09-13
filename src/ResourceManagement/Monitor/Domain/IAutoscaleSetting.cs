// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    /// <summary>
    /// An immutable client-side representation of an Azure autoscale setting.
    /// </summary>
    public interface IAutoscaleSetting  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<IMonitorManager, Models.AutoscaleSettingResourceInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleSetting>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<AutoscaleSetting.Update.IUpdate>
    {

        /// <summary>
        /// Gets a value indicating whether to send email to subscription administrator.
        /// </summary>
        /// <summary>
        /// Gets the sendToSubscriptionAdministrator value.
        /// </summary>
        bool AdminEmailNotificationEnabled { get; }

        /// <summary>
        /// Gets the enabled flag. Specifies whether automatic scaling is enabled for the resource. The default value is 'true'.
        /// </summary>
        /// <summary>
        /// Gets the enabled value.
        /// </summary>
        bool AutoscaleEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether to send email to subscription co-administrators.
        /// </summary>
        /// <summary>
        /// Gets the sendToSubscriptionCoAdministrators value.
        /// </summary>
        bool CoAdminEmailNotificationEnabled { get; }

        /// <summary>
        /// Gets the custom e-mails list. This value can be null or empty, in which case this attribute will be ignored.
        /// </summary>
        /// <summary>
        /// Gets the customEmails value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> CustomEmailsNotification { get; }

        /// <summary>
        /// Gets the autoscale profiles in the current autoscale setting.
        /// </summary>
        /// <summary>
        /// Gets autoscale profiles in the current autoscale setting, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleProfile> Profiles { get; }

        /// <summary>
        /// Gets the resource identifier of the resource that the autoscale setting should be added to.
        /// </summary>
        /// <summary>
        /// Gets the targetResourceUri value.
        /// </summary>
        string TargetResourceId { get; }

        /// <summary>
        /// Gets the service address to receive the notification.
        /// </summary>
        /// <summary>
        /// Gets the serviceUri value.
        /// </summary>
        string WebhookNotification { get; }
    }
}