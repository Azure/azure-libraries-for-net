// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    /// <summary>
    /// An immutable client-side representation of an Azure diagnostic settings.
    /// </summary>
    public interface IDiagnosticSetting :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<MonitorManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.DiagnosticSettingsResourceInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<DiagnosticSetting.Update.IUpdate>
    {

        /// <summary>
        /// Gets the eventHubAuthorizationRuleId value.
        /// </summary>
        /// <summary>
        /// Gets the eventHubAuthorizationRuleId value.
        /// </summary>
        string EventHubAuthorizationRuleId { get; }

        /// <summary>
        /// Gets the eventHubName value.
        /// </summary>
        /// <summary>
        /// Gets the eventHubName value.
        /// </summary>
        string EventHubName { get; }

        /// <summary>
        /// Gets the logs value.
        /// </summary>
        /// <summary>
        /// Gets the logs value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.LogSettings> Logs { get; }

        /// <summary>
        /// Gets the metrics value.
        /// </summary>
        /// <summary>
        /// Gets the metrics value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.MetricSettings> Metrics { get; }

        /// <summary>
        /// Gets the associated resource Id value.
        /// </summary>
        /// <summary>
        /// Gets the associated resource Id value.
        /// </summary>
        string ResourceId { get; }

        /// <summary>
        /// Gets the storageAccountId value.
        /// </summary>
        /// <summary>
        /// Gets the storageAccountId value.
        /// </summary>
        string StorageAccountId { get; }

        /// <summary>
        /// Gets the workspaceId value.
        /// </summary>
        /// <summary>
        /// Gets the workspaceId value.
        /// </summary>
        string WorkspaceId { get; }
    }
}