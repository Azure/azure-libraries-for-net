// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition
{
    /// <summary>
    /// The first stage of autoscale setting definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IWithGroup>
    {

    }

    /// <summary>
    /// The stage of the definition which specifies autoscale notifications.
    /// </summary>
    public interface IDefineAutoscaleSettingResourceNotifications 
    {

        /// <summary>
        /// Specifies that an email should be send to subscription administrator.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IWithCreate WithAdminEmailNotification();

        /// <summary>
        /// Specifies that an email should be send to subscription co-administrator.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IWithCreate WithCoAdminEmailNotification();

        /// <summary>
        /// Specifies that an email should be send to custom email addresses.
        /// </summary>
        /// <param name="customEmailAddresses">List of the emails that should receive the notification.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IWithCreate WithCustomEmailsNotification(params string[] customEmailAddresses);

        /// <summary>
        /// Set the service address to receive the notification.
        /// </summary>
        /// <param name="serviceUri">The serviceUri value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IWithCreate WithWebhookNotification(string serviceUri);
    }

    /// <summary>
    /// The stage of the definition which allows autoscale setting creation.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleSetting>,
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IDefineAutoscaleSettingResourceProfiles,
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IDefineAutoscaleSettingResourceNotifications,
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IWithAutoscaleSettingResourceEnabled
    {

    }

    /// <summary>
    /// The stage of the definition which specifies autoscale profile.
    /// </summary>
    public interface IDefineAutoscaleSettingResourceProfiles 
    {

        /// <summary>
        /// Starts the definition of automatic scaling profiles that specify different scaling parameters for different time periods. A maximum of 20 profiles can be specified.
        /// </summary>
        /// <param name="name">Name of the autoscale profile.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.Definition.IBlank DefineAutoscaleProfile(string name);
    }

    /// <summary>
    /// The stage of the definition which specifies if the current autoscale setting should be disabled upon creation.
    /// </summary>
    public interface IWithAutoscaleSettingResourceEnabled 
    {

        /// <summary>
        /// Set the current autoscale in the disabled state.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IWithCreate WithAutoscaleDisabled();
    }

    /// <summary>
    /// The entirety of an autoscale setting definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IBlank,
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IWithGroup,
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IWithCreate,
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IDefineAutoscaleSettingResourceProfiles,
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IWithAutoscaleSettingResourceTargetResourceUri,
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IWithAutoscaleSettingResourceEnabled
    {

    }

    /// <summary>
    /// The stage of the definition which selects resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IWithAutoscaleSettingResourceTargetResourceUri>
    {

    }

    /// <summary>
    /// The stage of the definition which selects target resource.
    /// </summary>
    public interface IWithAutoscaleSettingResourceTargetResourceUri 
    {

        /// <summary>
        /// Set the resource identifier of the resource that the autoscale setting should be added to.
        /// </summary>
        /// <param name="targetResourceId">The targetResourceUri value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition.IDefineAutoscaleSettingResourceProfiles WithTargetResource(string targetResourceId);
    }
}