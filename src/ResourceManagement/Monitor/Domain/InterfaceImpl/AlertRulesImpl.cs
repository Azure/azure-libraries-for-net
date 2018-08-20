// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class AlertRulesImpl
    {
        /// <summary>
        /// Gets the Azure Activity Log Alerts API entry point.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.IActivityLogAlerts Microsoft.Azure.Management.Monitor.Fluent.IAlertRules.ActivityLogAlerts
        {
            get
            {
                return this.ActivityLogAlerts();
            }
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        MonitorManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<MonitorManager>.Manager
        {
            get
            {
                return this.Manager();
            }
        }

        /// <summary>
        /// Gets the Azure Metric Alerts API entry point.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.IMetricAlerts Microsoft.Azure.Management.Monitor.Fluent.IAlertRules.MetricAlerts
        {
            get
            {
                return this.MetricAlerts();
            }
        }
    }
}