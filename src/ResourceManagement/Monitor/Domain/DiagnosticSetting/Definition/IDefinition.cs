// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithDiagnosticLogRecipient,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting>
    {

        /// <summary>
        /// Adds a Log Setting to the list of Log Settings for the current Diagnostic Settings.
        /// </summary>
        /// <param name="category">Name of a Log category for a resource type this setting is applied to.</param>
        /// <param name="retentionDays">The number of days for the retention in days. A value of 0 will retain the events indefinitely.</param>
        /// <return>The stage of creating Diagnostic Settings.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate WithLog(string category, int retentionDays);

        /// <summary>
        /// Adds a Log and Metric Settings to the list Log and Metric Settings for the current Diagnostic Settings.
        /// </summary>
        /// <param name="categories">A list of diagnostic settings category.</param>
        /// <param name="timeGrain">The timegrain of the metric in ISO8601 format for all Metrics in the  categories list.</param>
        /// <param name="retentionDays">The number of days for the retention in days. A value of 0 will retain the events indefinitely.</param>
        /// <return>The stage of creating Diagnostic Settings.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate WithLogsAndMetrics(IEnumerable<Microsoft.Azure.Management.Monitor.Fluent.Models.IDiagnosticSettingsCategory> categories, TimeSpan timeGrain, int retentionDays);

        /// <summary>
        /// Adds a Metric Setting to the list of Metric Settings for the current Diagnostic Settings.
        /// </summary>
        /// <param name="category">Name of a Metric category for a resource type this setting is applied to.</param>
        /// <param name="timeGrain">The timegrain of the metric in ISO8601 format.</param>
        /// <param name="retentionDays">The number of days for the retention in days. A value of 0 will retain the events indefinitely.</param>
        /// <return>The stage of creating Diagnostic Settings.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate WithMetric(string category, TimeSpan timeGrain, int retentionDays);
    }

    /// <summary>
    /// The entirety of a diagnostic settings definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IBlank,
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithDiagnosticLogRecipient,
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate
    {

    }

    /// <summary>
    /// The first stage of a diagnostic setting definition.
    /// </summary>
    public interface IBlank
    {

        /// <summary>
        /// Sets the resource for which Diagnostic Settings will be created.
        /// </summary>
        /// <param name="resourceId">Of the resource.</param>
        /// <return>The stage of selecting data recipient.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithDiagnosticLogRecipient WithResource(string resourceId);
    }

    /// <summary>
    /// The stage of the definition which contains minimum required properties to be specified for
    /// Diagnostic Settings creation.
    /// </summary>
    public interface IWithDiagnosticLogRecipient
    {

        /// <summary>
        /// Sets EventHub Namespace Authorization Rule for data transfer.
        /// </summary>
        /// <param name="eventHubAuthorizationRuleId">
        /// Of EventHub namespace authorization rule that should exist in
        /// the same region as resource.
        /// </param>
        /// <return>The stage of creating Diagnostic Settings.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate WithEventHub(string eventHubAuthorizationRuleId);

        /// <summary>
        /// Sets EventHub Namespace Authorization Rule for data transfer.
        /// </summary>
        /// <param name="eventHubAuthorizationRuleId">
        /// Of EventHub namespace authorization rule that should exist in
        /// the same region as resource.
        /// </param>
        /// <param name="eventHubName">Name of the EventHub. If none is specified, the default EventHub will be selected.</param>
        /// <return>The stage of creating Diagnostic Settings.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate WithEventHub(string eventHubAuthorizationRuleId, string eventHubName);

        /// <summary>
        /// Sets Log Analytics workspace for data transfer.
        /// </summary>
        /// <param name="workspaceId">Of Log Analytics that should exist in the same region as resource.</param>
        /// <return>The stage of creating Diagnostic Settings.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate WithLogAnalytics(string workspaceId);

        /// <summary>
        /// Sets Storage Account for data transfer.
        /// </summary>
        /// <param name="storageAccountId">Of storage account that should exist in the same region as resource.</param>
        /// <return>The stage of creating Diagnostic Settings.</return>
        Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition.IWithCreate WithStorageAccount(string storageAccountId);
    }
}