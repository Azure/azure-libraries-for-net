// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    internal partial class AutoscaleSettingImpl 
    {
        /// <summary>
        /// Gets a value indicating whether to send email to subscription administrator.
        /// </summary>
        /// <summary>
        /// Gets the sendToSubscriptionAdministrator value.
        /// </summary>
        bool Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleSetting.AdminEmailNotificationEnabled
        {
            get
            {
                return this.AdminEmailNotificationEnabled();
            }
        }

        /// <summary>
        /// Gets the enabled flag. Specifies whether automatic scaling is enabled for the resource. The default value is 'true'.
        /// </summary>
        /// <summary>
        /// Gets the enabled value.
        /// </summary>
        bool Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleSetting.AutoscaleEnabled
        {
            get
            {
                return this.AutoscaleEnabled();
            }
        }

        /// <summary>
        /// Gets a value indicating whether to send email to subscription co-administrators.
        /// </summary>
        /// <summary>
        /// Gets the sendToSubscriptionCoAdministrators value.
        /// </summary>
        bool Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleSetting.CoAdminEmailNotificationEnabled
        {
            get
            {
                return this.CoAdminEmailNotificationEnabled();
            }
        }

        /// <summary>
        /// Gets the custom e-mails list. This value can be null or empty, in which case this attribute will be ignored.
        /// </summary>
        /// <summary>
        /// Gets the customEmails value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleSetting.CustomEmailsNotification
        {
            get
            {
                return this.CustomEmailsNotification();
            }
        }

        /// <summary>
        /// Gets the autoscale profiles in the current autoscale setting.
        /// </summary>
        /// <summary>
        /// Gets autoscale profiles in the current autoscale setting, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleProfile> Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleSetting.Profiles
        {
            get
            {
                return this.Profiles();
            }
        }

        /// <summary>
        /// Gets the resource identifier of the resource that the autoscale setting should be added to.
        /// </summary>
        /// <summary>
        /// Gets the targetResourceUri value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleSetting.TargetResourceId
        {
            get
            {
                return this.TargetResourceId();
            }
        }

        /// <summary>
        /// Gets the service address to receive the notification.
        /// </summary>
        /// <summary>
        /// Gets the serviceUri value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleSetting.WebhookNotification
        {
            get
            {
                return this.WebhookNotification();
            }
        }

        /// <summary>
        /// Starts the definition of automatic scaling profiles that specify different scaling parameters for different time periods. A maximum of 20 profiles can be specified.
        /// </summary>
        /// <param name="name">Name of the autoscale profile.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleProfile.Definition.IBlank AutoscaleSetting.Definition.IDefineAutoscaleSettingResourceProfiles.DefineAutoscaleProfile(string name)
        {
            return this.DefineAutoscaleProfile(name);
        }

        /// <summary>
        /// Starts definition of automatic scaling profiles that specify different scaling parameters for different time periods. A maximum of 20 profiles can be specified.
        /// </summary>
        /// <param name="name">Name of the profile.</param>
        /// <return>The next stage of autoscale setting update.</return>
        AutoscaleProfile.UpdateDefinition.IBlank AutoscaleSetting.Update.IDefineAutoscaleSettingProfiles.DefineAutoscaleProfile(string name)
        {
            return this.DefineAutoscaleProfile(name);
        }

        /// <summary>
        /// Starts the update of automatic scaling profiles.
        /// </summary>
        /// <param name="name">Name of the profile.</param>
        /// <return>The next stage of autoscale setting update.</return>
        AutoscaleProfile.Update.IUpdate AutoscaleSetting.Update.IDefineAutoscaleSettingProfiles.UpdateAutoscaleProfile(string name)
        {
            return this.UpdateAutoscaleProfile(name);
        }

        /// <summary>
        /// Specifies that an email should be send to subscription administrator.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        AutoscaleSetting.Definition.IWithCreate AutoscaleSetting.Definition.IDefineAutoscaleSettingResourceNotifications.WithAdminEmailNotification()
        {
            return this.WithAdminEmailNotification();
        }

        /// <summary>
        /// Specifies that an email should be send to subscription administrator.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        AutoscaleSetting.Update.IUpdate AutoscaleSetting.Update.IUpdateAutoscaleSettings.WithAdminEmailNotification()
        {
            return this.WithAdminEmailNotification();
        }

        /// <summary>
        /// Sets current autoscale setting to the disabled state.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        AutoscaleSetting.Update.IUpdate AutoscaleSetting.Update.IUpdateAutoscaleSettings.WithAutoscaleDisabled()
        {
            return this.WithAutoscaleDisabled();
        }

        /// <summary>
        /// Set the current autoscale in the disabled state.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        AutoscaleSetting.Definition.IWithCreate AutoscaleSetting.Definition.IWithAutoscaleSettingResourceEnabled.WithAutoscaleDisabled()
        {
            return this.WithAutoscaleDisabled();
        }

        /// <summary>
        /// Sets current autoscale setting to the enabled state.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        AutoscaleSetting.Update.IUpdate AutoscaleSetting.Update.IUpdateAutoscaleSettings.WithAutoscaleEnabled()
        {
            return this.WithAutoscaleEnabled();
        }

        /// <summary>
        /// Specifies that an email should be send to subscription co-administrator.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        AutoscaleSetting.Definition.IWithCreate AutoscaleSetting.Definition.IDefineAutoscaleSettingResourceNotifications.WithCoAdminEmailNotification()
        {
            return this.WithCoAdminEmailNotification();
        }

        /// <summary>
        /// Specifies that an email should be send to subscription co-administrator.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        AutoscaleSetting.Update.IUpdate AutoscaleSetting.Update.IUpdateAutoscaleSettings.WithCoAdminEmailNotification()
        {
            return this.WithCoAdminEmailNotification();
        }

        /// <summary>
        /// Specifies that an email should be send to custom email addresses.
        /// </summary>
        /// <param name="customEmailAddresses">List of the emails that should receive the notification.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleSetting.Definition.IWithCreate AutoscaleSetting.Definition.IDefineAutoscaleSettingResourceNotifications.WithCustomEmailsNotification(params string[] customEmailAddresses)
        {
            return this.WithCustomEmailsNotification(customEmailAddresses);
        }

        /// <summary>
        /// Specifies that an email should be send to custom email addresses.
        /// </summary>
        /// <param name="customEmailAddresses">List of the emails that should receive the notification.</param>
        /// <return>The next stage of autoscale setting update.</return>
        AutoscaleSetting.Update.IUpdate AutoscaleSetting.Update.IUpdateAutoscaleSettings.WithCustomEmailsNotification(params string[] customEmailAddresses)
        {
            return this.WithCustomEmailsNotification(customEmailAddresses);
        }

        /// <summary>
        /// Removes email notification to subscription administrator.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        AutoscaleSetting.Update.IUpdate AutoscaleSetting.Update.IUpdateAutoscaleSettings.WithoutAdminEmailNotification()
        {
            return this.WithoutAdminEmailNotification();
        }

        /// <summary>
        /// Removes the specified profile from the current setting.
        /// </summary>
        /// <param name="name">Name of the profile.</param>
        /// <return>The next stage of autoscale setting update.</return>
        AutoscaleSetting.Update.IUpdate AutoscaleSetting.Update.IDefineAutoscaleSettingProfiles.WithoutAutoscaleProfile(string name)
        {
            return this.WithoutAutoscaleProfile(name);
        }

        /// <summary>
        /// Removes email notification to subscription co-administrator.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        AutoscaleSetting.Update.IUpdate AutoscaleSetting.Update.IUpdateAutoscaleSettings.WithoutCoAdminEmailNotification()
        {
            return this.WithoutCoAdminEmailNotification();
        }

        /// <summary>
        /// Removes email notification to custom email addresses.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        AutoscaleSetting.Update.IUpdate AutoscaleSetting.Update.IUpdateAutoscaleSettings.WithoutCustomEmailsNotification()
        {
            return this.WithoutCustomEmailsNotification();
        }

        /// <summary>
        /// Removes service from autoscale notification.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        AutoscaleSetting.Update.IUpdate AutoscaleSetting.Update.IUpdateAutoscaleSettings.WithoutWebhookNotification()
        {
            return this.WithoutWebhookNotification();
        }

        /// <summary>
        /// Set the resource identifier of the resource that the autoscale setting should be added to.
        /// </summary>
        /// <param name="targetResourceId">The targetResourceUri value to set.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleSetting.Definition.IDefineAutoscaleSettingResourceProfiles AutoscaleSetting.Definition.IWithAutoscaleSettingResourceTargetResourceUri.WithTargetResource(string targetResourceId)
        {
            return this.WithTargetResource(targetResourceId);
        }

        /// <summary>
        /// Set the service address to receive the notification.
        /// </summary>
        /// <param name="serviceUri">The serviceUri value to set.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleSetting.Definition.IWithCreate AutoscaleSetting.Definition.IDefineAutoscaleSettingResourceNotifications.WithWebhookNotification(string serviceUri)
        {
            return this.WithWebhookNotification(serviceUri);
        }

        /// <summary>
        /// Set the service address to receive the notification.
        /// </summary>
        /// <param name="serviceUri">The serviceUri value to set.</param>
        /// <return>The next stage of autoscale setting update.</return>
        AutoscaleSetting.Update.IUpdate AutoscaleSetting.Update.IUpdateAutoscaleSettings.WithWebhookNotification(string serviceUri)
        {
            return this.WithWebhookNotification(serviceUri);
        }
    }
}