// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;

    /// <summary>
    /// Implementation for ScaleRule.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uU2NhbGVSdWxlSW1wbA==
    internal partial class ScaleRuleImpl  :
        Wrapper<Models.ScaleRuleInner>,
        IScaleRule,
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Definition.IDefinition,
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.ParentUpdateDefinition.IParentUpdateDefinition,
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.UpdateDefinition.IUpdateDefinition,
        Microsoft.Azure.Management.Monitor.Fluent.ScaleRule.Update.IUpdate
    {
        private AutoscaleProfileImpl parent;

        ///GENMHASH:A500018F3C27587F7A3CB038F02A534A:F0E0F7CC23E9DB4814F31FCFB33ED7BF
        internal ScaleRuleImpl(ScaleRuleInner innerObject, AutoscaleProfileImpl parent)
            : base(innerObject)
        {
            this.parent = parent;
            if (this.Inner.MetricTrigger == null)
            {
                this.Inner.MetricTrigger = new MetricTrigger();
            }
            if (this.Inner.ScaleAction == null)
            {
                this.Inner.ScaleAction = new ScaleAction();
            }
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:624BD8C8D5D4194A9CFD59BC2DA97C7E
        public AutoscaleProfileImpl Attach()
        {
            return this.parent.AddNewScaleRule(this);
        }

        ///GENMHASH:8244B442CD575E882C2B85C6AAF1D87B:FF051082977123618AB9EB60A51C00EA
        public ComparisonOperationType Condition()
        {
            if (this.Inner.MetricTrigger != null)
            {
                return this.Inner.MetricTrigger.OperatorProperty;
            }
            return default(ComparisonOperationType);
        }

        ///GENMHASH:7287862F6F19BC0173B6210D405D2D13:90F9D23017453D8E52D9EAFDCD519D1E
        public TimeSpan CoolDown()
        {
            if (this.Inner.ScaleAction != null)
            {
                return this.Inner.ScaleAction.Cooldown;
            }
            return default(TimeSpan);
        }

        ///GENMHASH:EDE99336A1BCB3ECB11087D6AAB260E1:E0998D3B2DA911E06F26A8A3FE30D769
        public TimeSpan Duration()
        {
            if (this.Inner.MetricTrigger != null)
            {
                return this.Inner.MetricTrigger.TimeWindow;
            }
            return default(TimeSpan);
        }

        ///GENMHASH:69595D9B0270570CF4E62A7738ADA395:D740D74C35DA3CFF6FF1FBADE6E08443
        public TimeSpan Frequency()
        {
            if (this.Inner.MetricTrigger != null)
            {
                return this.Inner.MetricTrigger.TimeGrain;
            }
            return default(TimeSpan);
        }

        ///GENMHASH:0CAD702B3667C654570C0748BB1D1D0D:1959E8EF9A08B975F665BC0A20C9DB29
        public MetricStatisticType FrequencyStatistic()
        {
            if (this.Inner.MetricTrigger != null)
            {
                return this.Inner.MetricTrigger.Statistic;
            }
            return default(MetricStatisticType);
        }

        ///GENMHASH:B2E154B44EABA68125B16BEABCE76616:C971719B4013D13685B18AFABB5DC8DF
        public string MetricName()
        {
            if (this.Inner.MetricTrigger != null)
            {
                return this.Inner.MetricTrigger.MetricName;
            }
            return null;
        }

        ///GENMHASH:FD4BA3EA5AD96B269626099A0E8D214D:DBE75857D63599038DC4CD3A0B22AD30
        public string MetricSource()
        {
            if (this.Inner.MetricTrigger != null)
            {
                return this.Inner.MetricTrigger.MetricResourceUri;
            }
            return null;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:34B202BFD32121B742CD9BCD647EC8B2
        public AutoscaleProfileImpl Parent()
        {
            // end of update
            return this.parent;
        }

        ///GENMHASH:CE3CE48124157B3597D327B6DC82085F:B3810C6A1BE41402212DC1F6D3D935BC
        public ScaleDirection ScaleDirection()
        {
            if (this.Inner.ScaleAction != null)
            {
                return this.Inner.ScaleAction.Direction;
            }
            return default(ScaleDirection);
        }

        ///GENMHASH:BB584B3B04A240D7269E89234FA93C3E:DF2CA3AA41E691CED04F07E3E40334F2
        public int ScaleInstanceCount()
        {
            if (this.Inner.ScaleAction != null)
            {
                return int.Parse(this.Inner.ScaleAction.Value);
            }
            return 0;
        }

        ///GENMHASH:E3CFF43C0B92F1C87C59A4633BFEAE8E:7DFB4AD4048CA211CF3CFEED6B96C494
        public ScaleType ScaleType()
        {
            if (this.Inner.ScaleAction != null)
            {
                return this.Inner.ScaleAction.Type;
            }
            return default(ScaleType);
        }

        ///GENMHASH:ED78A9622D05B9D35EB386F13B8A1F97:ECA5300F8EAE16D019C8F23AD20F1DA5
        public double Threshold()
        {
            if (this.Inner.MetricTrigger != null)
            {
                return this.Inner.MetricTrigger.Threshold;
            }
            return 0.0d;
        }

        ///GENMHASH:5636490A40EC03DD34FE49E4DC4B68A3:A2F2F7E77E3943CDBF6F1884713925B4
        public TimeAggregationType TimeAggregation()
        {
            if (this.Inner.MetricTrigger != null)
            {
                return this.Inner.MetricTrigger.TimeAggregation;
            }
            return default(TimeAggregationType);
        }

        ///GENMHASH:FC95CCD3CB209FAF943A69591F59FCD9:4FD477A1681957D72C07F5CB5F3EE87B
        public ScaleRuleImpl WithCondition(TimeAggregationType timeAggregation, ComparisonOperationType condition, double threshold)
        {
            this.Inner.MetricTrigger.OperatorProperty = condition;
            this.Inner.MetricTrigger.TimeAggregation = timeAggregation;
            this.Inner.MetricTrigger.Threshold = threshold;
            return this;
        }

        ///GENMHASH:70307A93690A699CEA966259D06A449B:18F5371299CF5641226A6143C19100E2
        public ScaleRuleImpl WithMetricName(string metricName)
        {
            this.Inner.MetricTrigger.MetricName = metricName;
            return this;
        }

        ///GENMHASH:218DE495B9FA17919BEBCB974D85C21D:35AC43F62EA963E0D4F224FC00BE0C70
        public ScaleRuleImpl WithMetricSource(string metricSourceResourceId)
        {
            this.Inner.MetricTrigger.MetricResourceUri = metricSourceResourceId;
            return this;
        }

        ///GENMHASH:65BBBF1ED2099A37B0AAE69EEF27057F:4EA1D3F6E50225A49A99B22221964FC1
        public ScaleRuleImpl WithScaleAction(ScaleDirection direction, ScaleType type, int instanceCountChange, TimeSpan cooldown)
        {
            this.Inner.ScaleAction.Direction = direction;
            this.Inner.ScaleAction.Type = type;
            this.Inner.ScaleAction.Value = instanceCountChange.ToString();
            this.Inner.ScaleAction.Cooldown = cooldown;
            return this;
        }

        ///GENMHASH:680066A5310B6D51053B6E9324843124:764AD6D9C9BFFEBA35D2F0506CA6C91F
        public ScaleRuleImpl WithStatistic(TimeSpan duration, TimeSpan frequency, MetricStatisticType statisticType)
        {
            this.Inner.MetricTrigger.Statistic = statisticType;
            this.Inner.MetricTrigger.TimeWindow = duration;
            this.Inner.MetricTrigger.TimeGrain = frequency;
            return this;
        }

        ///GENMHASH:3FAA430A35AB8C520790316B1BA574F3:968FD7C2DCCC81F1FB769AA1B9A174FA
        public ScaleRuleImpl WithStatistic()
        {
            return this.WithStatistic(TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(1), MetricStatisticType.Average);
        }

        ///GENMHASH:47F2D2D499DCE32C3CC6806453A72FCE:37DC10C6C78FDA3D552AF8769B2282FC
        public ScaleRuleImpl WithStatistic(TimeSpan duration)
        {
            return this.WithStatistic(duration, TimeSpan.FromMinutes(1), MetricStatisticType.Average);
        }

        ///GENMHASH:FF2A080FF12D83F694D1FBC9A0BF2CE0:CC5FA33537C949636ABCF5F9AEB86A73
        public ScaleRuleImpl WithStatistic(TimeSpan duration, MetricStatisticType statisticType)
        {
            return this.WithStatistic(duration, TimeSpan.FromMinutes(1), statisticType);
        }
    }
}