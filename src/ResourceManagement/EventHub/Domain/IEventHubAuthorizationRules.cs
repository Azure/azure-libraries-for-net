// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to manage event hub authorization rules.
    /// </summary>
    public interface IEventHubAuthorizationRules  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<EventHubAuthorizationRule.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Management.EventHub.Fluent.IEventHubsOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Management.EventHub.Fluent.IEventHubManager>
    {
        /// <summary>
        /// Lists the authorization rules of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>List of authorization rules.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule> ListByEventHub(string resourceGroupName, string namespaceName, string eventHubName);

        /// <summary>
        /// Gets an authorization rule of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="name">Authorization rule name.</param>
        /// <return>The authorization rule.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule GetByName(string resourceGroupName, string namespaceName, string eventHubName, string name);

        /// <summary>
        /// Lists the authorization rules of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>Observable that emits the authorization rules.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule>> ListByEventHubAsync(string resourceGroupName, string namespaceName, string eventHubName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets an authorization rule of an event hub in a namespace in a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="name">Authorization rule name.</param>
        /// <return>Observable that emits the authorization rule.</return>
        Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule> GetByNameAsync(string resourceGroupName, string namespaceName, string eventHubName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes an authorization rule of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="name">Authorization rule name.</param>
        void DeleteByName(string resourceGroupName, string namespaceName, string eventHubName, string name);

        /// <summary>
        /// Deletes an authorization rule of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="name">Authorization rule name.</param>
        /// <return>The completable representing the task.</return>
        Task DeleteByNameAsync(string resourceGroupName, string namespaceName, string eventHubName, string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}