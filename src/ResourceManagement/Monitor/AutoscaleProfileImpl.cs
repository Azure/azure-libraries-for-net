// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for AutoscaleProfile.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uQXV0b3NjYWxlUHJvZmlsZUltcGw=
    internal partial class AutoscaleProfileImpl  :
        Wrapper<Models.AutoscaleProfileInner>,
        IAutoscaleProfile,
        AutoscaleProfile.Definition.IDefinition,
        AutoscaleProfile.UpdateDefinition.IUpdateDefinition,
        AutoscaleProfile.Update.IUpdate
    {
        private AutoscaleSettingImpl parent;

        ///GENMHASH:D4989F7A4A92D76A1C871AFBE1D9D79F:FAFFD0DC16CBE8A4A6B3BD60F65F7F8D
        internal AutoscaleProfileImpl(string name, AutoscaleProfileInner innerObject, AutoscaleSettingImpl parent)
            : base(innerObject)
        {
            this.Inner.Name = name;
            this.parent = parent;
            if (this.Inner.Capacity == null)
            {
                this.Inner.Capacity = new ScaleCapacity();
            }
            if (this.Inner.Rules == null)
            {
                this.Inner.Rules = new List<ScaleRuleInner>();
            }
        }

        ///GENMHASH:769DF9B385F13A7CB682A5CD874975E9:CF86B90665EDD6EE79E489D4092AF099
        internal AutoscaleProfileImpl AddNewScaleRule(ScaleRuleImpl scaleRule)
        {
            this.Inner.Rules.Add(scaleRule.Inner);
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:4F58A704FD6627BA34A522C2F93D28B9
        public AutoscaleSettingImpl Attach()
        {
            return parent.AddNewAutoscaleProfile(this);
        }

        ///GENMHASH:0197D3391202AB51EAC4BFEADF852130:A7A9CBBAB0C3D6660A4C5D79E49F55F6
        public int DefaultInstanceCount()
        {
            if (this.Inner.Capacity != null)
            {
                return int.Parse(this.Inner.Capacity.DefaultProperty);
            }
            return 0;
        }

        ///GENMHASH:717E57491C3BBF3CCFD8A86CF382A928:C74FF49BC27D6DEA0424CE076EAA0F25
        public ScaleRuleImpl DefineScaleRule()
        {
            return new ScaleRuleImpl(new ScaleRuleInner(), this);
        }

        ///GENMHASH:1C8013C51005F41D356CC8978238A7E7:79C400ABD35AF87BF969F9741733EF19
        public TimeWindow FixedDateSchedule()
        {
            return this.Inner.FixedDate;
        }

        ///GENMHASH:A14908CFB0C8C10351FE9C921CA38CB5:F38AF2F9D54311FC3D031E1A012A2EFF
        public int MaxInstanceCount()
        {
            if (this.Inner.Capacity != null)
            {
                return int.Parse(this.Inner.Capacity.Maximum);
            }
            return 0;
        }

        ///GENMHASH:9433A8E78A33F2C22D9B9B4FB60C5A90:4E76C23D9158781C718E751AB744587E
        public int MinInstanceCount()
        {
            if (this.Inner.Capacity != null)
            {
                return int.Parse(this.Inner.Capacity.Minimum);
            }
            return 0;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public AutoscaleSettingImpl Parent()
        {
            return parent;
        }

        ///GENMHASH:0D175CD19BD1252A2E3B43F5697F03B5:86C56A8A85938289465222377DE0F9BA
        public Recurrence RecurrentSchedule()
        {
            return this.Inner.Recurrence;
        }

        ///GENMHASH:72B8E1071F896522FFFEF85D9357CBCC:ED1629B484DE75BC24DEF8CDDB6D0508
        public IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.IScaleRule> Rules()
        {
            var rules = new List<IScaleRule>();
            if (this.Inner.Rules != null)
            {
                foreach (var ruleInner in this.Inner.Rules)
                {
                    rules.Add(new ScaleRuleImpl(ruleInner, this));
                }
            }
            return rules;
        }

        ///GENMHASH:9B01249F0D9948FF322CAEBEC8E306E9:68125AA640EF4353C99EFF4D568D962B
        public ScaleRuleImpl UpdateScaleRule(int ruleIndex)
        {
            var srToUpdate = new ScaleRuleImpl(this.Inner.Rules[ruleIndex], this);
            return srToUpdate;
        }

        ///GENMHASH:51EBC1299B3553C7A0E3F408CFBE5FF5:35441235090CF0443F8A2CFBDC8503A5
        public AutoscaleProfileImpl WithFixedDateSchedule(string timeZone, DateTime start, DateTime end)
        {
            this.Inner.FixedDate = new TimeWindow
                                    {
                                        TimeZone = timeZone,
                                        Start = start,
                                        End = end
                                    };
            if (this.Inner.Recurrence != null)
            {
                this.Inner.Recurrence = null;
            }
            return this;
        }

        ///GENMHASH:57EAA59DC1C7B7B13C168BFFF1965776:621B2AEE4AD9B87C4F17997EF87D63B8
        public AutoscaleProfileImpl WithFixedInstanceCount(int instanceCount)
        {
            this.WithMetricBasedScale(instanceCount, instanceCount, instanceCount);
            this.Inner.FixedDate = null;
            this.Inner.Recurrence = null;
            this.Inner.Rules = new List<ScaleRuleInner>();
            return this;
        }

        ///GENMHASH:1F63BCA530DA4BF968DF1AEC80F85B51:711AD3AF23830C19F54B32520DBC7C86
        public AutoscaleProfileImpl WithMetricBasedScale(int minimumInstanceCount, int maximumInstanceCount, int defaultInstanceCount)
        {
            this.Inner.Capacity.Minimum = minimumInstanceCount.ToString();
            this.Inner.Capacity.Maximum = maximumInstanceCount.ToString();
            this.Inner.Capacity.DefaultProperty = defaultInstanceCount.ToString();
            return this;
        }

        ///GENMHASH:07F409999E94D6AE16868B1B36B75DC0:7164D949048021E409BA36E559F8316B
        public AutoscaleProfileImpl WithoutScaleRule(int ruleIndex)
        {
            this.Inner.Rules.RemoveAt(ruleIndex);
            return this;
        }

        ///GENMHASH:38D86CCBCA0400A99A340974C03673E0:AE02C5BBFD9B05582189913EB1E00F81
        public AutoscaleProfileImpl WithRecurrentSchedule(string scheduleTimeZone, string startTime, params Models.DayOfWeek[] weekday)
        {
            if (string.IsNullOrEmpty(startTime) || 
                startTime.Length != 5 || 
                startTime[2] != ':' ||
                !char.IsDigit(startTime[0]) || 
                !char.IsDigit(startTime[1]) || 
                !char.IsDigit(startTime[3]) || 
                !char.IsDigit(startTime[4])) {
                throw new ArgumentException("Start time should have format of 'hh:mm' where hh is in 24-hour clock (AM/PM times are not supported).");
            }

            int hh = int.Parse(startTime.Substring(0, 2));
            int mm = int.Parse(startTime.Substring(3));
            if (hh > 23 || mm > 60)
            {
                throw new ArgumentException("Start time should have format of 'hh:mm' where hh is in 24-hour clock (AM/PM times are not supported).");
            }

            this.Inner.Recurrence = new Recurrence();
            this.Inner.Recurrence.Frequency = RecurrenceFrequency.Week;
            this.Inner.Recurrence.Schedule = new RecurrentSchedule();
            this.Inner.Recurrence.Schedule.TimeZone = scheduleTimeZone;
            this.Inner.Recurrence.Schedule.Hours = new List<int?>();
            this.Inner.Recurrence.Schedule.Minutes = new List<int?>();
            this.Inner.Recurrence.Schedule.Hours.Add(hh);
            this.Inner.Recurrence.Schedule.Minutes.Add(mm);
            this.Inner.Recurrence.Schedule.Days = new List<string>();

            foreach (var dof in weekday)
            {
                this.Inner.Recurrence.Schedule.Days.Add(dof.ToString());
            }

            this.Inner.FixedDate = null;
            return this;
        }

        ///GENMHASH:A6C449B81BF0CBA04FBC8114FFF88D3E:60757B60D97D0725373F4DAA4F8CC1D3
        public AutoscaleProfileImpl WithScheduleBasedScale(int instanceCount)
        {
            return this.WithMetricBasedScale(instanceCount, instanceCount, instanceCount);
        }
    }
}