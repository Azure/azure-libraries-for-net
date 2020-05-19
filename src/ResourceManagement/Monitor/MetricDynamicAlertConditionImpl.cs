// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class MetricDynamicAlertConditionImpl :
        Wrapper<DynamicMetricCriteria>,
        IMetricDynamicAlertCondition,
        MetricDynamicAlertCondition.Definition.IMetricName<MetricAlert.Definition.IWithCreateDynamicCondition>,
        MetricDynamicAlertCondition.Definition.IWithCriteriaOperator<MetricAlert.Definition.IWithCreateDynamicCondition>,
        MetricDynamicAlertCondition.Definition.IWithFailingPeriods<MetricAlert.Definition.IWithCreateDynamicCondition>,
        MetricDynamicAlertCondition.Definition.IWithConditionAttach<MetricAlert.Definition.IWithCreateDynamicCondition>,
        MetricDynamicAlertCondition.Update.IUpdateStages,
        MetricDynamicAlertCondition.Definition.IMetricName<MetricAlert.Update.IUpdate>,
        MetricDynamicAlertCondition.Definition.IWithCriteriaOperator<MetricAlert.Update.IUpdate>,
        MetricDynamicAlertCondition.Definition.IWithFailingPeriods<MetricAlert.Update.IUpdate>,
        MetricDynamicAlertCondition.Definition.IWithConditionAttach<MetricAlert.Update.IUpdate>
    {
        private IDictionary<string, Models.MetricDimension> dimensions;
        private readonly MetricAlertImpl parent;

        internal MetricDynamicAlertConditionImpl(string name, DynamicMetricCriteria innerObject, MetricAlertImpl parent)
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

        public DynamicThresholdOperator Condition()
        {
            return DynamicThresholdOperator.Parse(System.Convert.ToString(Inner.OperatorProperty));
        }

        public DynamicThresholdSensitivity AlertSensitivity()
        {
            return DynamicThresholdSensitivity.Parse(System.Convert.ToString(Inner.AlertSensitivity));
        }

        public DynamicThresholdFailingPeriods FailingPeriods()
        {
            return Inner.FailingPeriods;
        }

        public DateTime? IgnoreDataBefore()
        {
            return Inner.IgnoreDataBefore;
        }

        public IReadOnlyCollection<MetricDimension> Dimensions()
        {
            return this.dimensions.Values.ToList();
        }

        public string MetricName()
        {
            return Inner.MetricName;
        }

        public string MetricNamespace()
        {
            return Inner.MetricNamespace;
        }

        public string Name()
        {
            return Inner.Name;
        }

        public MetricAlertRuleTimeAggregation TimeAggregation()
        {
            return MetricAlertRuleTimeAggregation.Parse(System.Convert.ToString(Inner.TimeAggregation));
        }

        public MetricAlertImpl Parent()
        {
            this.Inner.Dimensions = new List<MetricDimension>(dimensions.Values);
            return this.parent;
        }

        public MetricAlertImpl Attach()
        {
            this.Inner.Dimensions = new List<MetricDimension>(dimensions.Values);
            return this.parent.WithDynamicAlertCriteria(this);
        }

        public MetricDynamicAlertConditionImpl WithDimension(string dimensionName, params string[] values)
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

        public MetricDynamicAlertConditionImpl WithMetricName(string metricName, string metricNamespace)
        {
            this.Inner.MetricNamespace = metricNamespace;
            return this.WithMetricName(metricName);
        }

        public MetricDynamicAlertConditionImpl WithMetricName(string metricName)
        {
            this.Inner.MetricName = metricName;
            return this;
        }

        public MetricDynamicAlertConditionImpl WithoutDimension(string dimensionName)
        {
            if (this.dimensions.ContainsKey(dimensionName))
            {
                dimensions.Remove(dimensionName);
            }

            return this;
        }

        public MetricDynamicAlertConditionImpl WithCondition(MetricAlertRuleTimeAggregation timeAggregation, DynamicThresholdOperator condition, DynamicThresholdSensitivity alertSensitivity)
        {
            this.Inner.OperatorProperty = condition;
            this.Inner.TimeAggregation = timeAggregation.ToString();
            this.Inner.AlertSensitivity = alertSensitivity;
            return this;
        }

        public MetricDynamicAlertConditionImpl WithIgnoreDataBefore(DateTime dateTime)
        {
            this.Inner.IgnoreDataBefore = dateTime;
            return this;
        }

        public MetricDynamicAlertConditionImpl WithFailingPeriods(DynamicThresholdFailingPeriods failingPeriods)
        {
            this.Inner.FailingPeriods = failingPeriods;
            return this;
        }

        public MetricDynamicAlertConditionImpl WithoutIgnoreDataBefore()
        {
            this.Inner.IgnoreDataBefore = null;
            return this;
        }
    }
}
