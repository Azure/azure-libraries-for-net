// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to manage event hub consumer groups.
    /// </summary>
    public interface IEventHubConsumerGroups  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<EventHubConsumerGroup.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Management.EventHub.Fluent.IConsumerGroupsOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Management.EventHub.Fluent.IEventHubManager>
    {
        /// <summary>
        /// Lists the consumer groups of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>List of consumer groups.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup> ListByEventHub(string resourceGroupName, string namespaceName, string eventHubName);

        /// <summary>
        /// Gets a consumer group of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="name">Consumer group name.</param>
        /// <return>The consumer group.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup GetByName(string resourceGroupName, string namespaceName, string eventHubName, string name);

        /// <summary>
        /// Lists the consumer groups of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>Observable that emits the consumer groups.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup>> ListByEventHubAsync(string resourceGroupName, string namespaceName, string eventHubName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a consumer group of an event hub in a namespace in a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="name">Consumer group name.</param>
        /// <return>Observable that emits the consumer group.</return>
        Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup> GetByNameAsync(string resourceGroupName, string namespaceName, string eventHubName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a consumer group of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="name">Consumer group name.</param>
        void DeleteByName(string resourceGroupName, string namespaceName, string eventHubName, string name);

        /// <summary>
        /// Deletes a consumer group of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="name">Consumer group name.</param>
        /// <return>The completable representing the task.</return>
        Task DeleteByNameAsync(string resourceGroupName, string namespaceName, string eventHubName, string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}