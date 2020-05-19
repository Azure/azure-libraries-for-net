// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for MetricAlertCondition.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uTWV0cmljQWxlcnRDb25kaXRpb25JbXBs
    internal partial class MetricAlertConditionImpl :
        Wrapper<Models.MetricCriteria>,
        IMetricAlertCondition,
        MetricAlertCondition.Definition.Blank.MetricName.IMetricName<MetricAlert.Definition.IWithCreate>,
        MetricAlertCondition.Definition.IWithCriteriaOperator<MetricAlert.Definition.IWithCreate>,
        MetricAlertCondition.Definition.IWithConditionAttach<MetricAlert.Definition.IWithCreate>,
        MetricAlertCondition.UpdateDefinition.Blank.MetricName.IMetricName<MetricAlert.Update.IUpdate>,
        MetricAlertCondition.UpdateDefinition.IWithCriteriaOperator<MetricAlert.Update.IUpdate>,
        MetricAlertCondition.UpdateDefinition.IWithConditionAttach<MetricAlert.Update.IUpdate>,
        MetricAlertCondition.Update.IUpdateStages
    {
        private IDictionary<string, Models.MetricDimension> dimensions;
        private MetricAlertImpl parent;

        ///GENMHASH:E381A45ED049153522E82595CE5F86B2:72BCD000BF4EABB33CA6F6D35F7D248F
        internal MetricAlertConditionImpl(string name, MetricCriteria innerObject, MetricAlertImpl parent)
            : base(innerObject)
        {
            this.Inner.Name = name;
            this.parent = parent;
            this.dimensions = new Dictionary<string, Models.MetricDimension>();
            if (this.Inner.Dimensions != null)
            {
                foreach (var md in this.Inner.Dimensions)
                {
                    dimensions.Add(md.Name, md);
                }
            }
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:A53FC311CBA9C1AEF65CADE5A61C0421
        public MetricAlertImpl Attach()
        {
            this.Inner.Dimensions = new List<MetricDimension>(this.dimensions.Values);
            return this.parent.WithAlertCriteria(this);
        }

        ///GENMHASH:8244B442CD575E882C2B85C6AAF1D87B:562AEA9CCCAACFD5DB65DCDEE6471E19
        public MetricAlertRuleCondition Condition()
        {
            return MetricAlertRuleCondition.Parse(System.Convert.ToString(this.Inner.OperatorProperty));
        }

        ///GENMHASH:BDA8645F7DCB22FCB0D576272D4D7A80:744A5BC604442DC99431C6BAD8C64B30
        public IReadOnlyCollection<Models.MetricDimension> Dimensions()
        {
            return this.dimensions.Values.ToList();
        }

        ///GENMHASH:B2E154B44EABA68125B16BEABCE76616:FC507FA6241C8D9B7C133FB4D3AA423D
        public string MetricName()
        {
            return this.Inner.MetricName;
        }
        ///GENMHASH:D09AE837550E1C13CD24EC1395F3B29F:0FD90E1200CF024E769FBAC2692B9B48
        public string MetricNamespace()
        {
            return this.Inner.MetricNamespace;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:B8E07F914327C24625F333A268196FAD
        public MetricAlertImpl Parent()
        {
            this.Inner.Dimensions = new List<MetricDimension>(this.dimensions.Values);
            return this.parent;
        }

        ///GENMHASH:ED78A9622D05B9D35EB386F13B8A1F97:1ACDFB5A4AD08FB7DC1F397DB4F139A5
        public double Threshold()
        {
            return this.Inner.Threshold;
        }

        ///GENMHASH:5636490A40EC03DD34FE49E4DC4B68A3:950C986A6843B6B6B52C4F1945939B08
        public MetricAlertRuleTimeAggregation TimeAggregation()
        {
            return MetricAlertRuleTimeAggregation.Parse(System.Convert.ToString(this.Inner.TimeAggregation));
        }

        ///GENMHASH:16385B0F625BFE1280EAADD4C9A52F83:175426222378DAACFA1C214E2C05A68B
        public MetricAlertConditionImpl WithCondition(MetricAlertRuleTimeAggregation timeAggregation, MetricAlertRuleCondition condition, double threshold)
        {
            this.Inner.OperatorProperty = OperatorModel.Parse(condition.ToString());
            this.Inner.TimeAggregation = timeAggregation.ToString();
            this.Inner.Threshold = threshold;
            return this;
        }

        ///GENMHASH:64020DBB92F89D3AF6299208861B69D5:699F63E25F9B0B29EF53C7C4E377174F
        public MetricAlertConditionImpl WithDimension(string dimensionName, params string[] values)
        {
            if (this.dimensions.ContainsKey(dimensionName))
            {
                dimensions.Remove(dimensionName);
            }
            var md = new MetricDimension
            {
                Name = dimensionName,
                OperatorProperty = "Include",
                Values = values
            };
            dimensions.Add(dimensionName, md);

            return this;
        }

        ///GENMHASH:B9E2BF54ADA71F4E1490101F5B237DF2:F9B2A33185F48964C1B3E1838A11D64B
        public MetricAlertConditionImpl WithMetricName(string metricName, string metricNamespace)
        {
            this.Inner.MetricNamespace = metricNamespace;
            return this.WithMetricName(metricName);
        }

        ///GENMHASH:70307A93690A699CEA966259D06A449B:CEC6E8E09BD3412971871333315F4209
        public MetricAlertConditionImpl WithMetricName(string metricName)
        {
            this.Inner.MetricName = metricName;
            return this;
        }


        ///GENMHASH:7BF9E5A5A3A6A52D398E193378D1D38E:375524F3FE13EAFFE1CFFE28F1CE6FE8
        public MetricAlertConditionImpl WithoutDimension(string dimensionName)
        {
            if (this.dimensions.ContainsKey(dimensionName))
            {
                dimensions.Remove(dimensionName);
            }

            return this;
        }
    }
}