// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Type representing an Azure EventHub.
    /// </summary>
    public interface IEventHub  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.INestedResource,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Management.EventHub.Fluent.IEventHubManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<EventHub.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Management.EventHub.Fluent.Models.EventhubInner>
    {
        /// <summary>
        /// Gets the format file name that stores captured data when capturing is enabled.
        /// </summary>
        string DataCaptureFileNameFormat { get; }

        /// <return>Consumer group in the event hub.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup> ListConsumerGroups();

        /// <summary>
        /// Gets configured window in MB to be used for event capturing when capturing is enabled.
        /// </summary>
        int DataCaptureWindowSizeInMB { get; }


        /// <summary>
        /// Gets whether to skip empty archives when capturing is enabled
        /// </summary>
        bool DataCaptureSkipEmptyArchives { get; }

        /// <summary>
        /// Gets description of the destination where captured data will be stored.
        /// </summary>
        Management.EventHub.Fluent.Models.Destination CaptureDestination { get; }

        /// <summary>
        /// Gets retention period of events in days.
        /// </summary>
        long MessageRetentionPeriodInDays { get; }

        /// <summary>
        /// Gets the partition identifiers.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> PartitionIds { get; }

        /// <summary>
        /// Gets the resource group of the parent namespace.
        /// </summary>
        string NamespaceResourceGroupName { get; }

        /// <summary>
        /// Gets configured window in seconds to be used for event capturing when capturing is enabled.
        /// </summary>
        int DataCaptureWindowSizeInSeconds { get; }

        /// <return>Authorization rules enabled for the event hub.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule> ListAuthorizationRules();

        /// <summary>
        /// Gets true if the data capture enabled for the event hub events, false otherwise.
        /// </summary>
        bool IsDataCaptureEnabled { get; }

        /// <return>Authorization rules enabled for the event hub.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule>> ListAuthorizationRulesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets name of the parent namespace.
        /// </summary>
        string NamespaceName { get; }

        /// <return>Consumer group in the event hub.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup>> ListConsumerGroupsAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}