// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update
{
    /// <summary>
    /// Grouping of autoscale setting update stages.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleSetting>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IUpdate>,
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IDefineAutoscaleSettingProfiles,
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IUpdateAutoscaleSettings
    {

    }

    /// <summary>
    /// The stage of the update which updates current autoscale setting.
    /// </summary>
    public interface IUpdateAutoscaleSettings 
    {

        /// <summary>
        /// Specifies that an email should be send to subscription administrator.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IUpdate WithAdminEmailNotification();

        /// <summary>
        /// Sets current autoscale setting to the disabled state.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IUpdate WithAutoscaleDisabled();

        /// <summary>
        /// Sets current autoscale setting to the enabled state.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IUpdate WithAutoscaleEnabled();

        /// <summary>
        /// Specifies that an email should be send to subscription co-administrator.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IUpdate WithCoAdminEmailNotification();

        /// <summary>
        /// Specifies that an email should be send to custom email addresses.
        /// </summary>
        /// <param name="customEmailAddresses">List of the emails that should receive the notification.</param>
        /// <return>The next stage of autoscale setting update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IUpdate WithCustomEmailsNotification(params string[] customEmailAddresses);

        /// <summary>
        /// Removes email notification to subscription administrator.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IUpdate WithoutAdminEmailNotification();

        /// <summary>
        /// Removes email notification to subscription co-administrator.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IUpdate WithoutCoAdminEmailNotification();

        /// <summary>
        /// Removes email notification to custom email addresses.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IUpdate WithoutCustomEmailsNotification();

        /// <summary>
        /// Removes service from autoscale notification.
        /// </summary>
        /// <return>The next stage of autoscale setting update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IUpdate WithoutWebhookNotification();

        /// <summary>
        /// Set the service address to receive the notification.
        /// </summary>
        /// <param name="serviceUri">The serviceUri value to set.</param>
        /// <return>The next stage of autoscale setting update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IUpdate WithWebhookNotification(string serviceUri);
    }

    /// <summary>
    /// The stage of the update which adds or updates autoscale profiles in the current setting.
    /// </summary>
    public interface IDefineAutoscaleSettingProfiles 
    {

        /// <summary>
        /// Starts definition of automatic scaling profiles that specify different scaling parameters for different time periods. A maximum of 20 profiles can be specified.
        /// </summary>
        /// <param name="name">Name of the profile.</param>
        /// <return>The next stage of autoscale setting update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.UpdateDefinition.IBlank DefineAutoscaleProfile(string name);

        /// <summary>
        /// Starts the update of automatic scaling profiles.
        /// </summary>
        /// <param name="name">Name of the profile.</param>
        /// <return>The next stage of autoscale setting update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.Update.IUpdate UpdateAutoscaleProfile(string name);

        /// <summary>
        /// Removes the specified profile from the current setting.
        /// </summary>
        /// <param name="name">Name of the profile.</param>
        /// <return>The next stage of autoscale setting update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IUpdate WithoutAutoscaleProfile(string name);
    }
}