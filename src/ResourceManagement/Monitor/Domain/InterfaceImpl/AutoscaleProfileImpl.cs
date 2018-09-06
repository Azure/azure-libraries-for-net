// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.Definition;
    using Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.Update;
    using Microsoft.Azure.Management.Monitor.Fluent.AutoscaleProfile.UpdateDefinition;
    using Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Definition;
    using Microsoft.Azure.Management.Monitor.Fluent.AutoscaleSetting.Update;
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition;
    using Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.ParentUpdateDefinition;
    using Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Update;
    using Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using System;
    using System.Collections.Generic;

    internal partial class AutoscaleProfileImpl 
    {
        /// <summary>
        /// Gets the number of instances that will be set if metrics are not available for evaluation. The default is only used if the current instance count is lower than the default.
        /// </summary>
        /// <summary>
        /// Gets the defaultProperty value.
        /// </summary>
        int Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleProfile.DefaultInstanceCount
        {
            get
            {
                return this.DefaultInstanceCount();
            }
        }

        /// <summary>
        /// Gets the specific date-time for the profile. This element is not used if the Recurrence element is used.
        /// </summary>
        /// <summary>
        /// Gets the fixedDate value.
        /// </summary>
        Models.TimeWindow Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleProfile.FixedDateSchedule
        {
            get
            {
                return this.FixedDateSchedule();
            }
        }

        /// <summary>
        /// Gets the maximum number of instances for the resource. The actual maximum number of instances is limited by the cores that are available in the subscription.
        /// </summary>
        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        int Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleProfile.MaxInstanceCount
        {
            get
            {
                return this.MaxInstanceCount();
            }
        }

        /// <summary>
        /// Gets the minimum number of instances for the resource.
        /// </summary>
        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        int Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleProfile.MinInstanceCount
        {
            get
            {
                return this.MinInstanceCount();
            }
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleSetting Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleSetting>.Parent
        {
            get
            {
                return this.Parent();
            }
        }

        /// <summary>
        /// Gets the repeating times at which this profile begins. This element is not used if the FixedDate element is used.
        /// </summary>
        /// <summary>
        /// Gets the recurrence value.
        /// </summary>
        Models.Recurrence Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleProfile.RecurrentSchedule
        {
            get
            {
                return this.RecurrentSchedule();
            }
        }

        /// <summary>
        /// Gets the collection of rules that provide the triggers and parameters for the scaling action. A maximum of 10 rules can be specified.
        /// </summary>
        /// <summary>
        /// Gets the rules value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.IScaleRule> Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleProfile.Rules
        {
            get
            {
                return this.Rules();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        AutoscaleSetting.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<AutoscaleSetting.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        AutoscaleSetting.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<AutoscaleSetting.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Starts the definition of scale rule for the current autoscale profile.
        /// </summary>
        /// <return>The next stage of the autoscale profile update.</return>
        ScaleRule.UpdateDefinition.IBlank AutoscaleProfile.Update.IUpdate.DefineScaleRule()
        {
            return this.DefineScaleRule();
        }

        /// <summary>
        /// Starts the definition of scale rule for the current autoscale profile.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ScaleRule.ParentUpdateDefinition.IBlank AutoscaleProfile.UpdateDefinition.IWithScaleRuleOptional.DefineScaleRule()
        {
            return this.DefineScaleRule();
        }

        /// <summary>
        /// Starts the definition of scale rule for the current autoscale profile.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ScaleRule.Definition.IBlank AutoscaleProfile.Definition.IWithScaleRuleOptional.DefineScaleRule()
        {
            return this.DefineScaleRule();
        }

        /// <summary>
        /// Starts the definition of scale rule for the current autoscale profile.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ScaleRule.ParentUpdateDefinition.IBlank AutoscaleProfile.UpdateDefinition.IWithScaleRule.DefineScaleRule()
        {
            return this.DefineScaleRule();
        }

        /// <summary>
        /// Starts the definition of scale rule for the current autoscale profile.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ScaleRule.Definition.IBlank AutoscaleProfile.Definition.IWithScaleRule.DefineScaleRule()
        {
            return this.DefineScaleRule();
        }

        /// <summary>
        /// Begins an update for a child resource.
        /// This is the beginning of the builder pattern used to update child resources
        /// The final method completing the update and continue
        /// the actual parent resource update process in Azure is  Settable.parent().
        /// </summary>
        /// <return>The stage of  parent resource update.</return>
        AutoscaleSetting.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<AutoscaleSetting.Update.IUpdate>.Parent()
        {
            return this.Parent();
        }

        /// <summary>
        /// Starts the update of the scale rule for the current autoscale profile.
        /// </summary>
        /// <param name="ruleIndex">The index of the scale rule in the current autoscale profile. The index represents the order at which rules were added to the current profile.</param>
        /// <return>The next stage of the autoscale profile update.</return>
        ScaleRule.Update.IUpdate AutoscaleProfile.Update.IUpdate.UpdateScaleRule(int ruleIndex)
        {
            return this.UpdateScaleRule(ruleIndex);
        }

        /// <summary>
        /// Specifies fixed date schedule for autoscale profile.
        /// </summary>
        /// <param name="timeZone">Time zone for the schedule.</param>
        /// <param name="start">Start time.</param>
        /// <param name="end">End time.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleProfile.UpdateDefinition.IWithAttach AutoscaleProfile.UpdateDefinition.IWithScaleSchedule.WithFixedDateSchedule(string timeZone, DateTime start, DateTime end)
        {
            return this.WithFixedDateSchedule(timeZone, start, end);
        }

        /// <summary>
        /// Specifies fixed date schedule for autoscale profile.
        /// </summary>
        /// <param name="timeZone">Time zone for the schedule.</param>
        /// <param name="start">Start time.</param>
        /// <param name="end">End time.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleProfile.Definition.IWithAttach AutoscaleProfile.Definition.IWithScaleSchedule.WithFixedDateSchedule(string timeZone, DateTime start, DateTime end)
        {
            return this.WithFixedDateSchedule(timeZone, start, end);
        }

        /// <summary>
        /// Updates fixed date schedule for autoscale profile.
        /// </summary>
        /// <param name="timeZone">Time zone for the schedule.</param>
        /// <param name="start">Start time.</param>
        /// <param name="end">End time.</param>
        /// <return>The next stage of the autoscale profile update.</return>
        AutoscaleProfile.Update.IUpdate AutoscaleProfile.Update.IUpdate.WithFixedDateSchedule(string timeZone, DateTime start, DateTime end)
        {
            return this.WithFixedDateSchedule(timeZone, start, end);
        }

        /// <summary>
        /// Specifies fixed date schedule for autoscale profile.
        /// </summary>
        /// <param name="timeZone">Time zone for the schedule.</param>
        /// <param name="start">Start time.</param>
        /// <param name="end">End time.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleProfile.UpdateDefinition.IWithScaleRuleOptional AutoscaleProfile.UpdateDefinition.IWithScaleRuleOptional.WithFixedDateSchedule(string timeZone, DateTime start, DateTime end)
        {
            return this.WithFixedDateSchedule(timeZone, start, end);
        }

        /// <summary>
        /// Specifies fixed date schedule for autoscale profile.
        /// </summary>
        /// <param name="timeZone">Time zone for the schedule.</param>
        /// <param name="start">Start time.</param>
        /// <param name="end">End time.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleProfile.Definition.IWithScaleRuleOptional AutoscaleProfile.Definition.IWithScaleRuleOptional.WithFixedDateSchedule(string timeZone, DateTime start, DateTime end)
        {
            return this.WithFixedDateSchedule(timeZone, start, end);
        }

        /// <summary>
        /// Selects a specific instance count for the current Default profile.
        /// </summary>
        /// <param name="instanceCount">The number of instances that will be set during specified schedule. The actual number of instances is limited by the cores that are available in the subscription.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleProfile.Definition.IWithAttach AutoscaleProfile.Definition.IBlank.WithFixedInstanceCount(int instanceCount)
        {
            return this.WithFixedInstanceCount(instanceCount);
        }

        /// <summary>
        /// Updates metric based autoscale profile.
        /// </summary>
        /// <param name="minimumInstanceCount">The minimum number of instances for the resource.</param>
        /// <param name="maximumInstanceCount">The maximum number of instances for the resource. The actual maximum number of instances is limited by the cores that are available in the subscription.</param>
        /// <param name="defaultInstanceCount">The number of instances that will be set if metrics are not available for evaluation. The default is only used if the current instance count is lower than the default.</param>
        /// <return>The next stage of the autoscale profile update.</return>
        AutoscaleProfile.Update.IUpdate AutoscaleProfile.Update.IUpdate.WithMetricBasedScale(int minimumInstanceCount, int maximumInstanceCount, int defaultInstanceCount)
        {
            return this.WithMetricBasedScale(minimumInstanceCount, maximumInstanceCount, defaultInstanceCount);
        }

        /// <summary>
        /// Selects metric based autoscale profile.
        /// </summary>
        /// <param name="minimumInstanceCount">The minimum number of instances for the resource.</param>
        /// <param name="maximumInstanceCount">The maximum number of instances for the resource. The actual maximum number of instances is limited by the cores that are available in the subscription.</param>
        /// <param name="defaultInstanceCount">The number of instances that will be set if metrics are not available for evaluation. The default is only used if the current instance count is lower than the default.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleProfile.UpdateDefinition.IWithScaleRule AutoscaleProfile.UpdateDefinition.IBlank.WithMetricBasedScale(int minimumInstanceCount, int maximumInstanceCount, int defaultInstanceCount)
        {
            return this.WithMetricBasedScale(minimumInstanceCount, maximumInstanceCount, defaultInstanceCount);
        }

        /// <summary>
        /// Selects metric based autoscale profile.
        /// </summary>
        /// <param name="minimumInstanceCount">The minimum number of instances for the resource.</param>
        /// <param name="maximumInstanceCount">The maximum number of instances for the resource. The actual maximum number of instances is limited by the cores that are available in the subscription.</param>
        /// <param name="defaultInstanceCount">The number of instances that will be set if metrics are not available for evaluation. The default is only used if the current instance count is lower than the default.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleProfile.Definition.IWithScaleRule AutoscaleProfile.Definition.IBlank.WithMetricBasedScale(int minimumInstanceCount, int maximumInstanceCount, int defaultInstanceCount)
        {
            return this.WithMetricBasedScale(minimumInstanceCount, maximumInstanceCount, defaultInstanceCount);
        }

        /// <summary>
        /// Removes scale rule from the current autoscale profile.
        /// </summary>
        /// <param name="ruleIndex">The index of the scale rule in the current autoscale profile.</param>
        /// <return>The next stage of the autoscale profile update.</return>
        AutoscaleProfile.Update.IUpdate AutoscaleProfile.Update.IUpdate.WithoutScaleRule(int ruleIndex)
        {
            return this.WithoutScaleRule(ruleIndex);
        }

        /// <summary>
        /// Specifies recurrent schedule for autoscale profile.
        /// </summary>
        /// <param name="scheduleTimeZone">Time zone for the schedule. Some examples of valid timezones are: Dateline Standard Time, UTC-11, Hawaiian Standard Time, Alaskan Standard Time, Pacific Standard Time (Mexico), Pacific Standard Time, US Mountain Standard Time, Mountain Standard Time (Mexico), Mountain Standard Time, Central America Standard Time, Central Standard Time, Central Standard Time (Mexico), Canada Central Standard Time, SA Pacific Standard Time, Eastern Standard Time, US Eastern Standard Time, Venezuela Standard Time, Paraguay Standard Time, Atlantic Standard Time, Central Brazilian Standard Time, SA Western Standard Time, Pacific SA Standard Time, Newfoundland Standard Time, E. South America Standard Time, Argentina Standard Time, SA Eastern Standard Time, Greenland Standard Time, Montevideo Standard Time, Bahia Standard Time, UTC-02, Mid-Atlantic Standard Time, Azores Standard Time, Cape Verde Standard Time, Morocco Standard Time, UTC, GMT Standard Time, Greenwich Standard Time, W. Europe Standard Time, Central Europe Standard Time, Romance Standard Time, Central European Standard Time, W. Central Africa Standard Time, Namibia Standard Time, Jordan Standard Time, GTB Standard Time, Middle East Standard Time, Egypt Standard Time, Syria Standard Time, E. Europe Standard Time, South Africa Standard Time, FLE Standard Time, Turkey Standard Time, Israel Standard Time, Kaliningrad Standard Time, Libya Standard Time, Arabic Standard Time, Arab Standard Time, Belarus Standard Time, Russian Standard Time, E. Africa Standard Time, Iran Standard Time, Arabian Standard Time, Azerbaijan Standard Time, Russia Time Zone 3, Mauritius Standard Time, Georgian Standard Time, Caucasus Standard Time, Afghanistan Standard Time, West Asia Standard Time, Ekaterinburg Standard Time, Pakistan Standard Time, India Standard Time, Sri Lanka Standard Time, Nepal Standard Time, Central Asia Standard Time, Bangladesh Standard Time, N. Central Asia Standard Time, Myanmar Standard Time, SE Asia Standard Time, North Asia Standard Time, China Standard Time, North Asia East Standard Time, Singapore Standard Time, W. Australia Standard Time, Taipei Standard Time, Ulaanbaatar Standard Time, Tokyo Standard Time, Korea Standard Time, Yakutsk Standard Time, Cen. Australia Standard Time, AUS Central Standard Time, E. Australia Standard Time, AUS Eastern Standard Time, West Pacific Standard Time, Tasmania Standard Time, Magadan Standard Time, Vladivostok Standard Time, Russia Time Zone 10, Central Pacific Standard Time, Russia Time Zone 11, New Zealand Standard Time, UTC+12, Fiji Standard Time, Kamchatka Standard Time, Tonga Standard Time, Samoa Standard Time, Line Islands Standard Time.</param>
        /// <param name="startTime">Start time in hh:mm format.</param>
        /// <param name="weekday">List of week days when the schedule should be active.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleProfile.UpdateDefinition.IWithAttach AutoscaleProfile.UpdateDefinition.IWithScaleSchedule.WithRecurrentSchedule(string scheduleTimeZone, string startTime, params Models.DayOfWeek[] weekday)
        {
            return this.WithRecurrentSchedule(scheduleTimeZone, startTime, weekday);
        }

        /// <summary>
        /// Specifies recurrent schedule for autoscale profile.
        /// </summary>
        /// <param name="scheduleTimeZone">Time zone for the schedule. Some examples of valid timezones are: Dateline Standard Time, UTC-11, Hawaiian Standard Time, Alaskan Standard Time, Pacific Standard Time (Mexico), Pacific Standard Time, US Mountain Standard Time, Mountain Standard Time (Mexico), Mountain Standard Time, Central America Standard Time, Central Standard Time, Central Standard Time (Mexico), Canada Central Standard Time, SA Pacific Standard Time, Eastern Standard Time, US Eastern Standard Time, Venezuela Standard Time, Paraguay Standard Time, Atlantic Standard Time, Central Brazilian Standard Time, SA Western Standard Time, Pacific SA Standard Time, Newfoundland Standard Time, E. South America Standard Time, Argentina Standard Time, SA Eastern Standard Time, Greenland Standard Time, Montevideo Standard Time, Bahia Standard Time, UTC-02, Mid-Atlantic Standard Time, Azores Standard Time, Cape Verde Standard Time, Morocco Standard Time, UTC, GMT Standard Time, Greenwich Standard Time, W. Europe Standard Time, Central Europe Standard Time, Romance Standard Time, Central European Standard Time, W. Central Africa Standard Time, Namibia Standard Time, Jordan Standard Time, GTB Standard Time, Middle East Standard Time, Egypt Standard Time, Syria Standard Time, E. Europe Standard Time, South Africa Standard Time, FLE Standard Time, Turkey Standard Time, Israel Standard Time, Kaliningrad Standard Time, Libya Standard Time, Arabic Standard Time, Arab Standard Time, Belarus Standard Time, Russian Standard Time, E. Africa Standard Time, Iran Standard Time, Arabian Standard Time, Azerbaijan Standard Time, Russia Time Zone 3, Mauritius Standard Time, Georgian Standard Time, Caucasus Standard Time, Afghanistan Standard Time, West Asia Standard Time, Ekaterinburg Standard Time, Pakistan Standard Time, India Standard Time, Sri Lanka Standard Time, Nepal Standard Time, Central Asia Standard Time, Bangladesh Standard Time, N. Central Asia Standard Time, Myanmar Standard Time, SE Asia Standard Time, North Asia Standard Time, China Standard Time, North Asia East Standard Time, Singapore Standard Time, W. Australia Standard Time, Taipei Standard Time, Ulaanbaatar Standard Time, Tokyo Standard Time, Korea Standard Time, Yakutsk Standard Time, Cen. Australia Standard Time, AUS Central Standard Time, E. Australia Standard Time, AUS Eastern Standard Time, West Pacific Standard Time, Tasmania Standard Time, Magadan Standard Time, Vladivostok Standard Time, Russia Time Zone 10, Central Pacific Standard Time, Russia Time Zone 11, New Zealand Standard Time, UTC+12, Fiji Standard Time, Kamchatka Standard Time, Tonga Standard Time, Samoa Standard Time, Line Islands Standard Time.</param>
        /// <param name="startTime">Start time in hh:mm format.</param>
        /// <param name="weekday">List of week days when the schedule should be active.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleProfile.Definition.IWithAttach AutoscaleProfile.Definition.IWithScaleSchedule.WithRecurrentSchedule(string scheduleTimeZone, string startTime, params Models.DayOfWeek[] weekday)
        {
            return this.WithRecurrentSchedule(scheduleTimeZone, startTime, weekday);
        }

        /// <summary>
        /// Updates recurrent schedule for autoscale profile.
        /// </summary>
        /// <param name="scheduleTimeZone">Time zone for the schedule. Some examples of valid timezones are: Dateline Standard Time, UTC-11, Hawaiian Standard Time, Alaskan Standard Time, Pacific Standard Time (Mexico), Pacific Standard Time, US Mountain Standard Time, Mountain Standard Time (Mexico), Mountain Standard Time, Central America Standard Time, Central Standard Time, Central Standard Time (Mexico), Canada Central Standard Time, SA Pacific Standard Time, Eastern Standard Time, US Eastern Standard Time, Venezuela Standard Time, Paraguay Standard Time, Atlantic Standard Time, Central Brazilian Standard Time, SA Western Standard Time, Pacific SA Standard Time, Newfoundland Standard Time, E. South America Standard Time, Argentina Standard Time, SA Eastern Standard Time, Greenland Standard Time, Montevideo Standard Time, Bahia Standard Time, UTC-02, Mid-Atlantic Standard Time, Azores Standard Time, Cape Verde Standard Time, Morocco Standard Time, UTC, GMT Standard Time, Greenwich Standard Time, W. Europe Standard Time, Central Europe Standard Time, Romance Standard Time, Central European Standard Time, W. Central Africa Standard Time, Namibia Standard Time, Jordan Standard Time, GTB Standard Time, Middle East Standard Time, Egypt Standard Time, Syria Standard Time, E. Europe Standard Time, South Africa Standard Time, FLE Standard Time, Turkey Standard Time, Israel Standard Time, Kaliningrad Standard Time, Libya Standard Time, Arabic Standard Time, Arab Standard Time, Belarus Standard Time, Russian Standard Time, E. Africa Standard Time, Iran Standard Time, Arabian Standard Time, Azerbaijan Standard Time, Russia Time Zone 3, Mauritius Standard Time, Georgian Standard Time, Caucasus Standard Time, Afghanistan Standard Time, West Asia Standard Time, Ekaterinburg Standard Time, Pakistan Standard Time, India Standard Time, Sri Lanka Standard Time, Nepal Standard Time, Central Asia Standard Time, Bangladesh Standard Time, N. Central Asia Standard Time, Myanmar Standard Time, SE Asia Standard Time, North Asia Standard Time, China Standard Time, North Asia East Standard Time, Singapore Standard Time, W. Australia Standard Time, Taipei Standard Time, Ulaanbaatar Standard Time, Tokyo Standard Time, Korea Standard Time, Yakutsk Standard Time, Cen. Australia Standard Time, AUS Central Standard Time, E. Australia Standard Time, AUS Eastern Standard Time, West Pacific Standard Time, Tasmania Standard Time, Magadan Standard Time, Vladivostok Standard Time, Russia Time Zone 10, Central Pacific Standard Time, Russia Time Zone 11, New Zealand Standard Time, UTC+12, Fiji Standard Time, Kamchatka Standard Time, Tonga Standard Time, Samoa Standard Time, Line Islands Standard Time.</param>
        /// <param name="startTime">Start time in hh:mm format.</param>
        /// <param name="weekday">List of week days when the schedule should be active.</param>
        /// <return>The next stage of the autoscale profile update.</return>
        AutoscaleProfile.Update.IUpdate AutoscaleProfile.Update.IUpdate.WithRecurrentSchedule(string scheduleTimeZone, string startTime, params Models.DayOfWeek[] weekday)
        {
            return this.WithRecurrentSchedule(scheduleTimeZone, startTime, weekday);
        }

        /// <summary>
        /// Specifies recurrent schedule for autoscale profile.
        /// </summary>
        /// <param name="scheduleTimeZone">Time zone for the schedule. Some examples of valid timezones are: Dateline Standard Time, UTC-11, Hawaiian Standard Time, Alaskan Standard Time, Pacific Standard Time (Mexico), Pacific Standard Time, US Mountain Standard Time, Mountain Standard Time (Mexico), Mountain Standard Time, Central America Standard Time, Central Standard Time, Central Standard Time (Mexico), Canada Central Standard Time, SA Pacific Standard Time, Eastern Standard Time, US Eastern Standard Time, Venezuela Standard Time, Paraguay Standard Time, Atlantic Standard Time, Central Brazilian Standard Time, SA Western Standard Time, Pacific SA Standard Time, Newfoundland Standard Time, E. South America Standard Time, Argentina Standard Time, SA Eastern Standard Time, Greenland Standard Time, Montevideo Standard Time, Bahia Standard Time, UTC-02, Mid-Atlantic Standard Time, Azores Standard Time, Cape Verde Standard Time, Morocco Standard Time, UTC, GMT Standard Time, Greenwich Standard Time, W. Europe Standard Time, Central Europe Standard Time, Romance Standard Time, Central European Standard Time, W. Central Africa Standard Time, Namibia Standard Time, Jordan Standard Time, GTB Standard Time, Middle East Standard Time, Egypt Standard Time, Syria Standard Time, E. Europe Standard Time, South Africa Standard Time, FLE Standard Time, Turkey Standard Time, Israel Standard Time, Kaliningrad Standard Time, Libya Standard Time, Arabic Standard Time, Arab Standard Time, Belarus Standard Time, Russian Standard Time, E. Africa Standard Time, Iran Standard Time, Arabian Standard Time, Azerbaijan Standard Time, Russia Time Zone 3, Mauritius Standard Time, Georgian Standard Time, Caucasus Standard Time, Afghanistan Standard Time, West Asia Standard Time, Ekaterinburg Standard Time, Pakistan Standard Time, India Standard Time, Sri Lanka Standard Time, Nepal Standard Time, Central Asia Standard Time, Bangladesh Standard Time, N. Central Asia Standard Time, Myanmar Standard Time, SE Asia Standard Time, North Asia Standard Time, China Standard Time, North Asia East Standard Time, Singapore Standard Time, W. Australia Standard Time, Taipei Standard Time, Ulaanbaatar Standard Time, Tokyo Standard Time, Korea Standard Time, Yakutsk Standard Time, Cen. Australia Standard Time, AUS Central Standard Time, E. Australia Standard Time, AUS Eastern Standard Time, West Pacific Standard Time, Tasmania Standard Time, Magadan Standard Time, Vladivostok Standard Time, Russia Time Zone 10, Central Pacific Standard Time, Russia Time Zone 11, New Zealand Standard Time, UTC+12, Fiji Standard Time, Kamchatka Standard Time, Tonga Standard Time, Samoa Standard Time, Line Islands Standard Time.</param>
        /// <param name="startTime">Start time in hh:mm format.</param>
        /// <param name="weekday">List of week days when the schedule should be active.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleProfile.UpdateDefinition.IWithScaleRuleOptional AutoscaleProfile.UpdateDefinition.IWithScaleRuleOptional.WithRecurrentSchedule(string scheduleTimeZone, string startTime, params Models.DayOfWeek[] weekday)
        {
            return this.WithRecurrentSchedule(scheduleTimeZone, startTime, weekday);
        }

        /// <summary>
        /// Specifies recurrent schedule for autoscale profile.
        /// </summary>
        /// <param name="scheduleTimeZone">Time zone for the schedule. Some examples of valid timezones are: Dateline Standard Time, UTC-11, Hawaiian Standard Time, Alaskan Standard Time, Pacific Standard Time (Mexico), Pacific Standard Time, US Mountain Standard Time, Mountain Standard Time (Mexico), Mountain Standard Time, Central America Standard Time, Central Standard Time, Central Standard Time (Mexico), Canada Central Standard Time, SA Pacific Standard Time, Eastern Standard Time, US Eastern Standard Time, Venezuela Standard Time, Paraguay Standard Time, Atlantic Standard Time, Central Brazilian Standard Time, SA Western Standard Time, Pacific SA Standard Time, Newfoundland Standard Time, E. South America Standard Time, Argentina Standard Time, SA Eastern Standard Time, Greenland Standard Time, Montevideo Standard Time, Bahia Standard Time, UTC-02, Mid-Atlantic Standard Time, Azores Standard Time, Cape Verde Standard Time, Morocco Standard Time, UTC, GMT Standard Time, Greenwich Standard Time, W. Europe Standard Time, Central Europe Standard Time, Romance Standard Time, Central European Standard Time, W. Central Africa Standard Time, Namibia Standard Time, Jordan Standard Time, GTB Standard Time, Middle East Standard Time, Egypt Standard Time, Syria Standard Time, E. Europe Standard Time, South Africa Standard Time, FLE Standard Time, Turkey Standard Time, Israel Standard Time, Kaliningrad Standard Time, Libya Standard Time, Arabic Standard Time, Arab Standard Time, Belarus Standard Time, Russian Standard Time, E. Africa Standard Time, Iran Standard Time, Arabian Standard Time, Azerbaijan Standard Time, Russia Time Zone 3, Mauritius Standard Time, Georgian Standard Time, Caucasus Standard Time, Afghanistan Standard Time, West Asia Standard Time, Ekaterinburg Standard Time, Pakistan Standard Time, India Standard Time, Sri Lanka Standard Time, Nepal Standard Time, Central Asia Standard Time, Bangladesh Standard Time, N. Central Asia Standard Time, Myanmar Standard Time, SE Asia Standard Time, North Asia Standard Time, China Standard Time, North Asia East Standard Time, Singapore Standard Time, W. Australia Standard Time, Taipei Standard Time, Ulaanbaatar Standard Time, Tokyo Standard Time, Korea Standard Time, Yakutsk Standard Time, Cen. Australia Standard Time, AUS Central Standard Time, E. Australia Standard Time, AUS Eastern Standard Time, West Pacific Standard Time, Tasmania Standard Time, Magadan Standard Time, Vladivostok Standard Time, Russia Time Zone 10, Central Pacific Standard Time, Russia Time Zone 11, New Zealand Standard Time, UTC+12, Fiji Standard Time, Kamchatka Standard Time, Tonga Standard Time, Samoa Standard Time, Line Islands Standard Time.</param>
        /// <param name="startTime">Start time in hh:mm format.</param>
        /// <param name="weekday">List of week days when the schedule should be active.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleProfile.Definition.IWithScaleRuleOptional AutoscaleProfile.Definition.IWithScaleRuleOptional.WithRecurrentSchedule(string scheduleTimeZone, string startTime, params Models.DayOfWeek[] weekday)
        {
            return this.WithRecurrentSchedule(scheduleTimeZone, startTime, weekday);
        }

        /// <summary>
        /// Updates schedule based autoscale profile.
        /// </summary>
        /// <param name="instanceCount">InstanceCount the number of instances that will be set during specified schedule. The actual number of instances is limited by the cores that are available in the subscription.</param>
        /// <return>The next stage of the autoscale profile update.</return>
        AutoscaleProfile.Update.IUpdate AutoscaleProfile.Update.IUpdate.WithScheduleBasedScale(int instanceCount)
        {
            return this.WithScheduleBasedScale(instanceCount);
        }

        /// <summary>
        /// Selects schedule based autoscale profile.
        /// </summary>
        /// <param name="instanceCount">The number of instances that will be set during specified schedule. The actual number of instances is limited by the cores that are available in the subscription.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleProfile.UpdateDefinition.IWithScaleSchedule AutoscaleProfile.UpdateDefinition.IBlank.WithScheduleBasedScale(int instanceCount)
        {
            return this.WithScheduleBasedScale(instanceCount);
        }

        /// <summary>
        /// Selects schedule based autoscale profile.
        /// </summary>
        /// <param name="instanceCount">The number of instances that will be set during specified schedule. The actual number of instances is limited by the cores that are available in the subscription.</param>
        /// <return>The next stage of the definition.</return>
        AutoscaleProfile.Definition.IWithScaleSchedule AutoscaleProfile.Definition.IBlank.WithScheduleBasedScale(int instanceCount)
        {
            return this.WithScheduleBasedScale(instanceCount);
        }
    }
}