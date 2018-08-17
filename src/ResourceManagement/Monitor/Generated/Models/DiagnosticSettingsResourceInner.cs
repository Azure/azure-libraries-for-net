// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The diagnostic setting resource.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class DiagnosticSettingsResourceInner : ProxyOnlyResource
    {
        /// <summary>
        /// Initializes a new instance of the DiagnosticSettingsResourceInner
        /// class.
        /// </summary>
        public DiagnosticSettingsResourceInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DiagnosticSettingsResourceInner
        /// class.
        /// </summary>
        /// <param name="id">Azure resource Id</param>
        /// <param name="name">Azure resource name</param>
        /// <param name="type">Azure resource type</param>
        /// <param name="storageAccountId">The resource ID of the storage
        /// account to which you would like to send Diagnostic Logs.</param>
        /// <param name="serviceBusRuleId">The service bus rule Id of the
        /// diagnostic setting. This is here to maintain backwards
        /// compatibility.</param>
        /// <param name="eventHubAuthorizationRuleId">The resource Id for the
        /// event hub authorization rule.</param>
        /// <param name="eventHubName">The name of the event hub. If none is
        /// specified, the default event hub will be selected.</param>
        /// <param name="metrics">the list of metric settings.</param>
        /// <param name="logs">the list of logs settings.</param>
        /// <param name="workspaceId">The workspace ID (resource ID of a Log
        /// Analytics workspace) for a Log Analytics workspace to which you
        /// would like to send Diagnostic Logs. Example:
        /// /subscriptions/4b9e8510-67ab-4e9a-95a9-e2f1e570ea9c/resourceGroups/insights-integration/providers/Microsoft.OperationalInsights/workspaces/viruela2</param>
        public DiagnosticSettingsResourceInner(string id = default(string), string name = default(string), string type = default(string), string storageAccountId = default(string), string serviceBusRuleId = default(string), string eventHubAuthorizationRuleId = default(string), string eventHubName = default(string), IList<MetricSettings> metrics = default(IList<MetricSettings>), IList<LogSettings> logs = default(IList<LogSettings>), string workspaceId = default(string))
            : base(id, name, type)
        {
            StorageAccountId = storageAccountId;
            ServiceBusRuleId = serviceBusRuleId;
            EventHubAuthorizationRuleId = eventHubAuthorizationRuleId;
            EventHubName = eventHubName;
            Metrics = metrics;
            Logs = logs;
            WorkspaceId = workspaceId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the resource ID of the storage account to which you
        /// would like to send Diagnostic Logs.
        /// </summary>
        [JsonProperty(PropertyName = "properties.storageAccountId")]
        public string StorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the service bus rule Id of the diagnostic setting.
        /// This is here to maintain backwards compatibility.
        /// </summary>
        [JsonProperty(PropertyName = "properties.serviceBusRuleId")]
        public string ServiceBusRuleId { get; set; }

        /// <summary>
        /// Gets or sets the resource Id for the event hub authorization rule.
        /// </summary>
        [JsonProperty(PropertyName = "properties.eventHubAuthorizationRuleId")]
        public string EventHubAuthorizationRuleId { get; set; }

        /// <summary>
        /// Gets or sets the name of the event hub. If none is specified, the
        /// default event hub will be selected.
        /// </summary>
        [JsonProperty(PropertyName = "properties.eventHubName")]
        public string EventHubName { get; set; }

        /// <summary>
        /// Gets or sets the list of metric settings.
        /// </summary>
        [JsonProperty(PropertyName = "properties.metrics")]
        public IList<MetricSettings> Metrics { get; set; }

        /// <summary>
        /// Gets or sets the list of logs settings.
        /// </summary>
        [JsonProperty(PropertyName = "properties.logs")]
        public IList<LogSettings> Logs { get; set; }

        /// <summary>
        /// Gets or sets the workspace ID (resource ID of a Log Analytics
        /// workspace) for a Log Analytics workspace to which you would like to
        /// send Diagnostic Logs. Example:
        /// /subscriptions/4b9e8510-67ab-4e9a-95a9-e2f1e570ea9c/resourceGroups/insights-integration/providers/Microsoft.OperationalInsights/workspaces/viruela2
        /// </summary>
        [JsonProperty(PropertyName = "properties.workspaceId")]
        public string WorkspaceId { get; set; }

    }
}
