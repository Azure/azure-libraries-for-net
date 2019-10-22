// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Monitor.Fluent.MetricDynamicAlertCondition.Definition;
    using Microsoft.Azure.Management.Monitor.Fluent.MetricDynamicAlertCondition.Update;
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class MetricDynamicAlertConditionImpl
    {
        DynamicThresholdOperator IMetricDynamicAlertCondition.Condition
        {
            get
            {
                return this.Condition();
            }
        }

        DynamicThresholdSensitivity IMetricDynamicAlertCondition.AlertSensitivity
        {
            get
            {
                return this.AlertSensitivity();
            }
        }

        DynamicThresholdFailingPeriods IMetricDynamicAlertCondition.FailingPeriods
        {
            get
            {
                return this.FailingPeriods();
            }
        }

        DateTime? IMetricDynamicAlertCondition.IgnoreDataBefore
        {
            get
            {
                return this.IgnoreDataBefore();
            }
        }

        IReadOnlyCollection<MetricDimension> IMetricDynamicAlertCondition.Dimensions
        {
            get
            {
                return this.Dimensions();
            }
        }

        string IMetricDynamicAlertCondition.MetricName
        {
            get
            {
                return this.MetricName();
            }
        }

        string IMetricDynamicAlertCondition.MetricNamespace
        {
            get
            {
                return this.MetricNamespace();
            }
        }

        string IMetricDynamicAlertCondition.Name
        {
            get
            {
                return this.Name();
            }
        }

        MetricAlertRuleTimeAggregation IMetricDynamicAlertCondition.TimeAggregation
        {
            get
            {
                return this.TimeAggregation();
            }
        }

        IMetricAlert IHasParent<IMetricAlert>.Parent
        {
            get
            {
                return this.Parent();
            }
        }

        MetricDynamicAlertCondition.Definition.IWithCriteriaOperator<MetricAlert.Definition.IWithCreateDynamicCondition> MetricDynamicAlertCondition.Definition.IMetricName<MetricAlert.Definition.IWithCreateDynamicCondition>.WithMetricName(string metricName)
        {
            return this.WithMetricName(metricName);
        }

        MetricDynamicAlertCondition.Definition.IWithCriteriaOperator<MetricAlert.Definition.IWithCreateDynamicCondition> MetricDynamicAlertCondition.Definition.IMetricName<MetricAlert.Definition.IWithCreateDynamicCondition>.WithMetricName(string metricName, string metricNamespace)
        {
            return this.WithMetricName(metricName, metricNamespace);
        }

        MetricDynamicAlertCondition.Definition.IWithFailingPeriods<MetricAlert.Definition.IWithCreateDynamicCondition> MetricDynamicAlertCondition.Definition.IWithCriteriaOperator<MetricAlert.Definition.IWithCreateDynamicCondition>.WithCondition(MetricAlertRuleTimeAggregation timeAggregation, DynamicThresholdOperator condition, DynamicThresholdSensitivity alertSensitivity)
        {
            return this.WithCondition(timeAggregation, condition, alertSensitivity);
        }

        IWithConditionAttach<MetricAlert.Definition.IWithCreateDynamicCondition> IWithFailingPeriods<MetricAlert.Definition.IWithCreateDynamicCondition>.WithFailingPeriods(DynamicThresholdFailingPeriods failingPeriods)
        {
            return this.WithFailingPeriods(failingPeriods);
        }

        MetricAlert.Definition.IWithCreateDynamicCondition MetricDynamicAlertCondition.Definition.IWithConditionAttach<MetricAlert.Definition.IWithCreateDynamicCondition>.Attach()
        {
            return this.Attach();
        }

        MetricDynamicAlertCondition.Definition.IWithConditionAttach<MetricAlert.Definition.IWithCreateDynamicCondition> MetricDynamicAlertCondition.Definition.IWithConditionAttach<MetricAlert.Definition.IWithCreateDynamicCondition>.WithDimension(string dimensionName, params string[] values)
        {
            return this.WithDimension(dimensionName, values);
        }

        MetricDynamicAlertCondition.Definition.IWithConditionAttach<MetricAlert.Definition.IWithCreateDynamicCondition> MetricDynamicAlertCondition.Definition.IWithConditionAttach<MetricAlert.Definition.IWithCreateDynamicCondition>.WithIgnoreDataBefore(DateTime dateTime)
        {
            return this.WithIgnoreDataBefore(dateTime);
        }

        IUpdateStages IUpdateStages.WithCondition(MetricAlertRuleTimeAggregation timeAggregation, DynamicThresholdOperator condition, DynamicThresholdSensitivity alertSensitivity)
        {
            return this.WithCondition(timeAggregation, condition, alertSensitivity);
        }

        IUpdateStages IUpdateStages.WithDimension(string dimensionName, params string[] values)
        {
            return this.WithDimension(dimensionName, values);
        }

        IUpdateStages IUpdateStages.WithoutDimension(string dimensionName)
        {
            return this.WithoutDimension(dimensionName);
        }

        IUpdateStages IUpdateStages.WithFailingPeriods(DynamicThresholdFailingPeriods failingPeriods)
        {
            return this.WithFailingPeriods(failingPeriods);
        }

        IUpdateStages IUpdateStages.WithIgnoreDataBefore(DateTime dateTime)
        {
            return this.WithIgnoreDataBefore(dateTime);
        }

        IUpdateStages IUpdateStages.WithoutIgnoreDataBefore()
        {
            return this.WithoutIgnoreDataBefore();
        }

        MetricAlert.Update.IUpdate IUpdateStages.Parent()
        {
            return this.Parent();
        }

        IWithCriteriaOperator<MetricAlert.Update.IUpdate> IMetricName<MetricAlert.Update.IUpdate>.WithMetricName(string metricName)
        {
            return this.WithMetricName(metricName);
        }

        IWithCriteriaOperator<MetricAlert.Update.IUpdate> IMetricName<MetricAlert.Update.IUpdate>.WithMetricName(string metricName, string metricNamespace)
        {
            return this.WithMetricName(metricName, metricNamespace);
        }

        IWithFailingPeriods<MetricAlert.Update.IUpdate> IWithCriteriaOperator<MetricAlert.Update.IUpdate>.WithCondition(MetricAlertRuleTimeAggregation timeAggregation, DynamicThresholdOperator condition, DynamicThresholdSensitivity alertSensitivity)
        {
            return this.WithCondition(timeAggregation, condition, alertSensitivity);
        }

        MetricAlert.Update.IUpdate IWithConditionAttach<MetricAlert.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }

        IWithConditionAttach<MetricAlert.Update.IUpdate> IWithConditionAttach<MetricAlert.Update.IUpdate>.WithDimension(string dimensionName, params string[] values)
        {
            return this.WithDimension(dimensionName, values);
        }

        IWithConditionAttach<MetricAlert.Update.IUpdate> IWithConditionAttach<MetricAlert.Update.IUpdate>.WithIgnoreDataBefore(DateTime dateTime)
        {
            return this.WithIgnoreDataBefore(dateTime);
        }

        IWithConditionAttach<MetricAlert.Update.IUpdate> IWithFailingPeriods<MetricAlert.Update.IUpdate>.WithFailingPeriods(DynamicThresholdFailingPeriods failingPeriods)
        {
            return this.WithFailingPeriods(failingPeriods);
        }
    }
}
