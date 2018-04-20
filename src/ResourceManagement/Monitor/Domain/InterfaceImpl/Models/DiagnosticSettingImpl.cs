// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Azure.Management.Monitor.Fluent;
    using System;
    using System.Collections.Generic;

    internal partial class DiagnosticSettingImpl
    {
        /// <summary>
        /// Gets the eventHubAuthorizationRuleId value.
        /// </summary>
        /// <summary>
        /// Gets the eventHubAuthorizationRuleId value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting.EventHubAuthorizationRuleId
        {
            get
            {
                return this.EventHubAuthorizationRuleId();
            }
        }

        /// <summary>
        /// Gets the eventHubName value.
        /// </summary>
        /// <summary>
        /// Gets the eventHubName value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting.EventHubName
        {
            get
            {
                return this.EventHubName();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the logs value.
        /// </summary>
        /// <summary>
        /// Gets the logs value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.Models.LogSettings> Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting.Logs
        {
            get
            {
                return this.Logs();
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
        /// Gets the metrics value.
        /// </summary>
        /// <summary>
        /// Gets the metrics value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.Models.MetricSettings> Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting.Metrics
        {
            get
            {
                return this.Metrics();
            }
        }

        /// <summary>
        /// Gets the associated resource Id value.
        /// </summary>
        /// <summary>
        /// Gets the associated resource Id value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting.ResourceId
        {
            get
            {
                return this.ResourceId();
            }
        }

        /// <summary>
        /// Gets the storageAccountId value.
        /// </summary>
        /// <summary>
        /// Gets the storageAccountId value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting.StorageAccountId
        {
            get
            {
                return this.StorageAccountId();
            }
        }

        /// <summary>
        /// Gets the workspaceId value.
        /// </summary>
        /// <summary>
        /// Gets the workspaceId value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting.WorkspaceId
        {
            get
            {
                return this.WorkspaceId();
            }
        }

        /// <summary>
        /// Sets EventHub Namespace Authorization Rule for data transfer.
        /// </summary>
        /// <param name="eventHubAuthorizationRuleId">
        /// Of EventHub namespace authorization rule that should exist in
        /// the same region as resource.
        /// </param>
        /// <return>The stage of creating Diagnostic Settings.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithDiagnosticLogRecipient.WithEventHub(string eventHubAuthorizationRuleId)
        {
            return this.WithEventHub(eventHubAuthorizationRuleId);
        }

        /// <summary>
        /// Sets EventHub Namespace Authorization Rule for data transfer.
        /// </summary>
        /// <param name="eventHubAuthorizationRuleId">
        /// Of EventHub namespace authorization rule that should exist in
        /// the same region as resource.
        /// </param>
        /// <param name="eventHubName">Name of the EventHub. If none is specified, the default EventHub will be selected.</param>
        /// <return>The stage of creating Diagnostic Settings.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithDiagnosticLogRecipient.WithEventHub(string eventHubAuthorizationRuleId, string eventHubName)
        {
            return this.WithEventHub(eventHubAuthorizationRuleId, eventHubName);
        }

        /// <summary>
        /// Sets EventHub Namespace Authorization Rule for data transfer.
        /// </summary>
        /// <param name="eventHubAuthorizationRuleId">
        /// Of EventHub namespace authorization rule that should exist in
        /// the same region as resource.
        /// </param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithEventHub.WithEventHub(string eventHubAuthorizationRuleId)
        {
            return this.WithEventHub(eventHubAuthorizationRuleId);
        }

        /// <summary>
        /// Sets EventHub Namespace Authorization Rule for data transfer.
        /// </summary>
        /// <param name="eventHubAuthorizationRuleId">
        /// Of EventHub namespace authorization rule that should exist in
        /// the same region as resource.
        /// </param>
        /// <param name="eventHubName">Name of the EventHub. If none is specified, the default EventHub will be selected.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithEventHub.WithEventHub(string eventHubAuthorizationRuleId, string eventHubName)
        {
            return this.WithEventHub(eventHubAuthorizationRuleId, eventHubName);
        }

        /// <summary>
        /// Adds a Log Setting to the list of Log Settings for the current Diagnostic Settings.
        /// </summary>
        /// <param name="category">Name of a Log category for a resource type this setting is applied to.</param>
        /// <param name="retentionDays">The number of days for the retention in days. A value of 0 will retain the events indefinitely.</param>
        /// <return>The stage of creating Diagnostic Settings.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate.WithLog(string category, int retentionDays)
        {
            return this.WithLog(category, retentionDays);
        }

        /// <summary>
        /// Adds a Log Setting to the list of Log Settings for the current Diagnostic Settings.
        /// </summary>
        /// <param name="category">Name of a Log category for a resource type this setting is applied to.</param>
        /// <param name="retentionDays">The number of days for the retention in days. A value of 0 will retain the events indefinitely.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithMetricAndLogs.WithLog(string category, int retentionDays)
        {
            return this.WithLog(category, retentionDays);
        }

        /// <summary>
        /// Sets Log Analytics workspace for data transfer.
        /// </summary>
        /// <param name="workspaceId">Of Log Analytics that should exist in the same region as resource.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithLogAnalytics.WithLogAnalytics(string workspaceId)
        {
            return this.WithLogAnalytics(workspaceId);
        }

        /// <summary>
        /// Sets Log Analytics workspace for data transfer.
        /// </summary>
        /// <param name="workspaceId">Of Log Analytics that should exist in the same region as resource.</param>
        /// <return>The stage of creating Diagnostic Settings.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithDiagnosticLogRecipient.WithLogAnalytics(string workspaceId)
        {
            return this.WithLogAnalytics(workspaceId);
        }

        /// <summary>
        /// Adds a Log and Metric Settings to the list Log and Metric Settings for the current Diagnostic Settings.
        /// </summary>
        /// <param name="categories">A list of diagnostic settings category.</param>
        /// <param name="timeGrain">The timegrain of the metric in ISO8601 format for all Metrics in the  categories list.</param>
        /// <param name="retentionDays">The number of days for the retention in days. A value of 0 will retain the events indefinitely.</param>
        /// <return>The stage of creating Diagnostic Settings.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate.WithLogsAndMetrics(IEnumerable<Microsoft.Azure.Management.Monitor.Fluent.Models.IDiagnosticSettingsCategory> categories, TimeSpan timeGrain, int retentionDays)
        {
            return this.WithLogsAndMetrics(categories, timeGrain, retentionDays);
        }

        /// <summary>
        /// Adds a Log and Metric Settings to the list Log and Metric Settings for the current Diagnostic Settings.
        /// </summary>
        /// <param name="categories">A list of diagnostic settings category.</param>
        /// <param name="timeGrain">The timegrain of the metric in ISO8601 format for all Metrics in the  categories list.</param>
        /// <param name="retentionDays">The number of days for the retention in days. A value of 0 will retain the events indefinitely.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithMetricAndLogs.WithLogsAndMetrics(IEnumerable<Microsoft.Azure.Management.Monitor.Fluent.Models.IDiagnosticSettingsCategory> categories, TimeSpan timeGrain, int retentionDays)
        {
            return this.WithLogsAndMetrics(categories, timeGrain, retentionDays);
        }

        /// <summary>
        /// Adds a Metric Setting to the list of Metric Settings for the current Diagnostic Settings.
        /// </summary>
        /// <param name="category">Name of a Metric category for a resource type this setting is applied to.</param>
        /// <param name="timeGrain">The timegrain of the metric in ISO8601 format.</param>
        /// <param name="retentionDays">The number of days for the retention in days. A value of 0 will retain the events indefinitely.</param>
        /// <return>The stage of creating Diagnostic Settings.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate.WithMetric(string category, TimeSpan timeGrain, int retentionDays)
        {
            return this.WithMetric(category, timeGrain, retentionDays);
        }

        /// <summary>
        /// Adds a Metric Setting to the list of Metric Settings for the current Diagnostic Settings.
        /// </summary>
        /// <param name="category">Name of a Metric category for a resource type this setting is applied to.</param>
        /// <param name="timeGrain">The timegrain of the metric in ISO8601 format.</param>
        /// <param name="retentionDays">The number of days for the retention in days. A value of 0 will retain the events indefinitely.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithMetricAndLogs.WithMetric(string category, TimeSpan timeGrain, int retentionDays)
        {
            return this.WithMetric(category, timeGrain, retentionDays);
        }

        /// <summary>
        /// Removes the EventHub from the Diagnostic Settings.
        /// </summary>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithEventHub.WithoutEventHub()
        {
            return this.WithoutEventHub();
        }

        /// <summary>
        /// Removes the Log Setting from the Diagnostic Setting.
        /// </summary>
        /// <param name="category">Name of a Log category to remove.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithMetricAndLogs.WithoutLog(string category)
        {
            return this.WithoutLog(category);
        }

        /// <summary>
        /// Removes the Log Analytics from the Diagnostic Settings.
        /// </summary>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithLogAnalytics.WithoutLogAnalytics()
        {
            return this.WithoutLogAnalytics();
        }

        /// <summary>
        /// Removes all the Log Settings from the Diagnostic Setting.
        /// </summary>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithMetricAndLogs.WithoutLogs()
        {
            return this.WithoutLogs();
        }

        /// <summary>
        /// Removes the Metric Setting from the Diagnostic Setting.
        /// </summary>
        /// <param name="category">Name of a Metric category to remove.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithMetricAndLogs.WithoutMetric(string category)
        {
            return this.WithoutMetric(category);
        }

        /// <summary>
        /// Removes all the Metric Settings from the Diagnostic Setting.
        /// </summary>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithMetricAndLogs.WithoutMetrics()
        {
            return this.WithoutMetrics();
        }

        /// <summary>
        /// Removes the Storage Account from the Diagnostic Settings.
        /// </summary>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithStorageAccount.WithoutStorageAccount()
        {
            return this.WithoutStorageAccount();
        }

        /// <summary>
        /// Sets the resource for which Diagnostic Settings will be created.
        /// </summary>
        /// <param name="resourceId">Of the resource.</param>
        /// <return>The stage of selecting data recipient.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithDiagnosticLogRecipient Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IBlank.WithResource(string resourceId)
        {
            return this.WithResource(resourceId);
        }

        /// <summary>
        /// Sets Storage Account for data transfer.
        /// </summary>
        /// <param name="storageAccountId">Of storage account that should exist in the same region as resource.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithStorageAccount.WithStorageAccount(string storageAccountId)
        {
            return this.WithStorageAccount(storageAccountId);
        }

        /// <summary>
        /// Sets Storage Account for data transfer.
        /// </summary>
        /// <param name="storageAccountId">Of storage account that should exist in the same region as resource.</param>
        /// <return>The stage of creating Diagnostic Settings.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithDiagnosticLogRecipient.WithStorageAccount(string storageAccountId)
        {
            return this.WithStorageAccount(storageAccountId);
        }
    }
}