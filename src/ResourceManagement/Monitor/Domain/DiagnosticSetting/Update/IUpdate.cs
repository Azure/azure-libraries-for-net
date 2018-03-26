// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of a Diagnostic Settings update allowing to modify EventHub settings.
    /// </summary>
    public interface IWithEventHub
    {

        /// <summary>
        /// Sets EventHub Namespace Authorization Rule for data transfer.
        /// </summary>
        /// <param name="eventHubAuthorizationRuleId">
        /// Of EventHub namespace authorization rule that should exist in
        /// the same region as resource.
        /// </param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate WithEventHub(string eventHubAuthorizationRuleId);

        /// <summary>
        /// Sets EventHub Namespace Authorization Rule for data transfer.
        /// </summary>
        /// <param name="eventHubAuthorizationRuleId">
        /// Of EventHub namespace authorization rule that should exist in
        /// the same region as resource.
        /// </param>
        /// <param name="eventHubName">Name of the EventHub. If none is specified, the default EventHub will be selected.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate WithEventHub(string eventHubAuthorizationRuleId, string eventHubName);

        /// <summary>
        /// Removes the EventHub from the Diagnostic Settings.
        /// </summary>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate WithoutEventHub();
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting>,
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithStorageAccount,
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithEventHub,
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithLogAnalytics,
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IWithMetricAndLogs
    {

    }

    public interface IWithMetricAndLogs
    {

        /// <summary>
        /// Adds a Log Setting to the list of Log Settings for the current Diagnostic Settings.
        /// </summary>
        /// <param name="category">Name of a Log category for a resource type this setting is applied to.</param>
        /// <param name="retentionDays">The number of days for the retention in days. A value of 0 will retain the events indefinitely.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate WithLog(string category, int retentionDays);

        /// <summary>
        /// Adds a Log and Metric Settings to the list Log and Metric Settings for the current Diagnostic Settings.
        /// </summary>
        /// <param name="categories">A list of diagnostic settings category.</param>
        /// <param name="timeGrain">The timegrain of the metric in ISO8601 format for all Metrics in the  categories list.</param>
        /// <param name="retentionDays">The number of days for the retention in days. A value of 0 will retain the events indefinitely.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate WithLogsAndMetrics(IEnumerable<Microsoft.Azure.Management.Monitor.Fluent.Models.IDiagnosticSettingsCategory> categories, TimeSpan timeGrain, int retentionDays);

        /// <summary>
        /// Adds a Metric Setting to the list of Metric Settings for the current Diagnostic Settings.
        /// </summary>
        /// <param name="category">Name of a Metric category for a resource type this setting is applied to.</param>
        /// <param name="timeGrain">The timegrain of the metric in ISO8601 format.</param>
        /// <param name="retentionDays">The number of days for the retention in days. A value of 0 will retain the events indefinitely.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate WithMetric(string category, TimeSpan timeGrain, int retentionDays);

        /// <summary>
        /// Removes the Log Setting from the Diagnostic Setting.
        /// </summary>
        /// <param name="category">Name of a Log category to remove.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate WithoutLog(string category);

        /// <summary>
        /// Removes all the Log Settings from the Diagnostic Setting.
        /// </summary>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate WithoutLogs();

        /// <summary>
        /// Removes the Metric Setting from the Diagnostic Setting.
        /// </summary>
        /// <param name="category">Name of a Metric category to remove.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate WithoutMetric(string category);

        /// <summary>
        /// Removes all the Metric Settings from the Diagnostic Setting.
        /// </summary>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate WithoutMetrics();
    }

    /// <summary>
    /// The stage of a Diagnostic Settings update allowing to modify Log Analytics settings.
    /// </summary>
    public interface IWithLogAnalytics
    {

        /// <summary>
        /// Sets Log Analytics workspace for data transfer.
        /// </summary>
        /// <param name="workspaceId">Of Log Analytics that should exist in the same region as resource.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate WithLogAnalytics(string workspaceId);

        /// <summary>
        /// Removes the Log Analytics from the Diagnostic Settings.
        /// </summary>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate WithoutLogAnalytics();
    }

    /// <summary>
    /// The stage of a Diagnostic Settings update allowing to modify Storage Account settings.
    /// </summary>
    public interface IWithStorageAccount
    {

        /// <summary>
        /// Removes the Storage Account from the Diagnostic Settings.
        /// </summary>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate WithoutStorageAccount();

        /// <summary>
        /// Sets Storage Account for data transfer.
        /// </summary>
        /// <param name="storageAccountId">Of storage account that should exist in the same region as resource.</param>
        /// <return>The next stage of the Diagnostic Settings update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update.IUpdate WithStorageAccount(string storageAccountId);
    }
}