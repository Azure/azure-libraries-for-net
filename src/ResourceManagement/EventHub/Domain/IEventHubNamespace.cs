// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// Type representing an Azure EventHub namespace.
    /// </summary>
    public interface IEventHubNamespace  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Management.EventHub.Fluent.IEventHubManager, Management.EventHub.Fluent.Models.EHNamespaceInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<EventHubNamespace.Update.IUpdate>
    {
        /// <summary>
        /// Gets the service bus endpoint associated with the namespace.
        /// </summary>
        string ServiceBusEndpoint { get; }

        /// <summary>
        /// Gets maximum throughput unit that auto-scalar is allowed to set.
        /// </summary>
        int ThroughputUnitsUpperLimit { get; }

        /// <return>The event hubs in the namespace.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub>> ListEventHubsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>List of event hubs in the namespace.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub> ListEventHubs();

        /// <summary>
        /// Gets provisioning state of the namespace.
        /// </summary>
        string ProvisioningState { get; }

        /// <summary>
        /// Gets true if auto-scale is enabled for the namespace, false otherwise.
        /// </summary>
        bool IsAutoScaleEnabled { get; }

        /// <summary>
        /// Gets current throughput units set for the namespace.
        /// </summary>
        int CurrentThroughputUnits { get; }

        /// <summary>
        /// Gets namespace created time.
        /// </summary>
        System.DateTime? CreatedAt { get; }

        /// <return>List of authorization rules for the event hub namespace.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule> ListAuthorizationRules();

        /// <summary>
        /// Gets resource id of the Azure Insights metrics associated with the namespace.
        /// </summary>
        string AzureInsightMetricId { get; }

        /// <summary>
        /// Gets namespace sku.
        /// </summary>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceSkuType Sku { get; }

        /// <return>The authorization rules for the event hub namespace.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule>> ListAuthorizationRulesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets namespace last modified time.
        /// </summary>
        System.DateTime? UpdatedAt { get; }
    }
}