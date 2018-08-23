// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to Alert Rules management API.
    /// </summary>
    public interface IAlertRules :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<MonitorManager>
    {

        /// <summary>
        /// Gets the Azure Activity Log Alerts API entry point.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.IActivityLogAlerts ActivityLogAlerts { get; }

        /// <summary>
        /// Gets the Azure Metric Alerts API entry point.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.IMetricAlerts MetricAlerts { get; }
    }
}