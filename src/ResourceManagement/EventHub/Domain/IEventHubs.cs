// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to manage event hubs.
    /// </summary>
    public interface IEventHubs  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<EventHub.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Management.EventHub.Fluent.IEventHubsOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Management.EventHub.Fluent.IEventHubManager>
    {
        /// <summary>
        /// Gets entry point to manage consumer group of event hubs.
        /// </summary>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroups ConsumerGroups { get; }

        /// <summary>
        /// Lists the event hubs in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <return>List of event hubs.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub> ListByNamespace(string resourceGroupName, string namespaceName);

        /// <summary>
        /// Gets entry point to manage authorization rules of event hubs.
        /// </summary>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRules AuthorizationRules { get; }

        /// <summary>
        /// Gets an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Event hub name.</param>
        /// <return>The event hubs.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHub GetByName(string resourceGroupName, string namespaceName, string name);

        /// <summary>
        /// Lists the event hubs in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <return>Observable that emits the event hubs.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub>> ListByNamespaceAsync(string resourceGroupName, string namespaceName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Event hub name.</param>
        /// <return>Observable that emits the event hubs.</return>
        Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub> GetByNameAsync(string resourceGroupName, string namespaceName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Event hub name.</param>
        void DeleteByName(string resourceGroupName, string namespaceName, string name);

        /// <summary>
        /// Deletes an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Event hub name.</param>
        /// <return>The completable representing the task.</return>
        Task DeleteByNameAsync(string resourceGroupName, string namespaceName, string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}