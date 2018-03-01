// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to manage event hub namespace authorization rules.
    /// </summary>
    public interface IEventHubNamespaceAuthorizationRules  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<EventHubNamespaceAuthorizationRule.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Management.EventHub.Fluent.INamespacesOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Management.EventHub.Fluent.IEventHubManager>
    {
        /// <summary>
        /// Lists the authorization rules under a namespace in a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <return>List of authorization rules.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule> ListByNamespace(string resourceGroupName, string namespaceName);

        /// <summary>
        /// Gets an authorization rule under a namespace in a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Authorization rule name.</param>
        /// <return>The authorization rule.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule GetByName(string resourceGroupName, string namespaceName, string name);

        /// <summary>
        /// Lists the authorization rules under a namespace in a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <return>Observable that emits the authorization rules.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule>> ListByNamespaceAsync(string resourceGroupName, string namespaceName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets an authorization rule under a namespace in a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Authorization rule name.</param>
        /// <return>Observable that emits the authorization rule.</return>
        Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule> GetByNameAsync(string resourceGroupName, string namespaceName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes an authorization rule under a namespace in a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Authorization rule name.</param>
        void DeleteByName(string resourceGroupName, string namespaceName, string name);

        /// <summary>
        /// Deletes an authorization rule under a namespace in a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Authorization rule name.</param>
        /// <return>The completable representing the task.</return>
        Task DeleteByNameAsync(string resourceGroupName, string namespaceName, string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}