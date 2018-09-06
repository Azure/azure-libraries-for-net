// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.Update
{
    using System;

    /// <summary>
    /// Grouping of autoscale profile update stages.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update.IUpdate>
    {

        /// <summary>
        /// Starts the definition of scale rule for the current autoscale profile.
        /// </summary>
        /// <return>The next stage of the autoscale profile update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.UpdateDefinition.IBlank DefineScaleRule();

        /// <summary>
        /// Starts the update of the scale rule for the current autoscale profile.
        /// </summary>
        /// <param name="ruleIndex">The index of the scale rule in the current autoscale profile. The index represents the order at which rules were added to the current profile.</param>
        /// <return>The next stage of the autoscale profile update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Update.IUpdate UpdateScaleRule(int ruleIndex);

        /// <summary>
        /// Updates fixed date schedule for autoscale profile.
        /// </summary>
        /// <param name="timeZone">Time zone for the schedule.</param>
        /// <param name="start">Start time.</param>
        /// <param name="end">End time.</param>
        /// <return>The next stage of the autoscale profile update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.Update.IUpdate WithFixedDateSchedule(string timeZone, DateTime start, DateTime end);

        /// <summary>
        /// Updates metric based autoscale profile.
        /// </summary>
        /// <param name="minimumInstanceCount">The minimum number of instances for the resource.</param>
        /// <param name="maximumInstanceCount">The maximum number of instances for the resource. The actual maximum number of instances is limited by the cores that are available in the subscription.</param>
        /// <param name="defaultInstanceCount">The number of instances that will be set if metrics are not available for evaluation. The default is only used if the current instance count is lower than the default.</param>
        /// <return>The next stage of the autoscale profile update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.Update.IUpdate WithMetricBasedScale(int minimumInstanceCount, int maximumInstanceCount, int defaultInstanceCount);

        /// <summary>
        /// Removes scale rule from the current autoscale profile.
        /// </summary>
        /// <param name="ruleIndex">The index of the scale rule in the current autoscale profile.</param>
        /// <return>The next stage of the autoscale profile update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.Update.IUpdate WithoutScaleRule(int ruleIndex);

        /// <summary>
        /// Updates recurrent schedule for autoscale profile.
        /// </summary>
        /// <param name="scheduleTimeZone">Time zone for the schedule. Some examples of valid timezones are: Dateline Standard Time, UTC-11, Hawaiian Standard Time, Alaskan Standard Time, Pacific Standard Time (Mexico), Pacific Standard Time, US Mountain Standard Time, Mountain Standard Time (Mexico), Mountain Standard Time, Central America Standard Time, Central Standard Time, Central Standard Time (Mexico), Canada Central Standard Time, SA Pacific Standard Time, Eastern Standard Time, US Eastern Standard Time, Venezuela Standard Time, Paraguay Standard Time, Atlantic Standard Time, Central Brazilian Standard Time, SA Western Standard Time, Pacific SA Standard Time, Newfoundland Standard Time, E. South America Standard Time, Argentina Standard Time, SA Eastern Standard Time, Greenland Standard Time, Montevideo Standard Time, Bahia Standard Time, UTC-02, Mid-Atlantic Standard Time, Azores Standard Time, Cape Verde Standard Time, Morocco Standard Time, UTC, GMT Standard Time, Greenwich Standard Time, W. Europe Standard Time, Central Europe Standard Time, Romance Standard Time, Central European Standard Time, W. Central Africa Standard Time, Namibia Standard Time, Jordan Standard Time, GTB Standard Time, Middle East Standard Time, Egypt Standard Time, Syria Standard Time, E. Europe Standard Time, South Africa Standard Time, FLE Standard Time, Turkey Standard Time, Israel Standard Time, Kaliningrad Standard Time, Libya Standard Time, Arabic Standard Time, Arab Standard Time, Belarus Standard Time, Russian Standard Time, E. Africa Standard Time, Iran Standard Time, Arabian Standard Time, Azerbaijan Standard Time, Russia Time Zone 3, Mauritius Standard Time, Georgian Standard Time, Caucasus Standard Time, Afghanistan Standard Time, West Asia Standard Time, Ekaterinburg Standard Time, Pakistan Standard Time, India Standard Time, Sri Lanka Standard Time, Nepal Standard Time, Central Asia Standard Time, Bangladesh Standard Time, N. Central Asia Standard Time, Myanmar Standard Time, SE Asia Standard Time, North Asia Standard Time, China Standard Time, North Asia East Standard Time, Singapore Standard Time, W. Australia Standard Time, Taipei Standard Time, Ulaanbaatar Standard Time, Tokyo Standard Time, Korea Standard Time, Yakutsk Standard Time, Cen. Australia Standard Time, AUS Central Standard Time, E. Australia Standard Time, AUS Eastern Standard Time, West Pacific Standard Time, Tasmania Standard Time, Magadan Standard Time, Vladivostok Standard Time, Russia Time Zone 10, Central Pacific Standard Time, Russia Time Zone 11, New Zealand Standard Time, UTC+12, Fiji Standard Time, Kamchatka Standard Time, Tonga Standard Time, Samoa Standard Time, Line Islands Standard Time.</param>
        /// <param name="startTime">Start time in hh:mm format.</param>
        /// <param name="weekday">List of week days when the schedule should be active.</param>
        /// <return>The next stage of the autoscale profile update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.Update.IUpdate WithRecurrentSchedule(string scheduleTimeZone, string startTime, params Models.DayOfWeek[] weekday);

        /// <summary>
        /// Updates schedule based autoscale profile.
        /// </summary>
        /// <param name="instanceCount">InstanceCount the number of instances that will be set during specified schedule. The actual number of instances is limited by the cores that are available in the subscription.</param>
        /// <return>The next stage of the autoscale profile update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.Update.IUpdate WithScheduleBasedScale(int instanceCount);
    }
}