// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to manage disaster recovery pairing of event hub namespaces.
    /// </summary>
    public interface IEventHubDisasterRecoveryPairings  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<EventHubDisasterRecoveryPairing.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Management.EventHub.Fluent.IDisasterRecoveryConfigsOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Management.EventHub.Fluent.IEventHubManager>
    {
        /// <summary>
        /// Lists the disaster recovery pairings of a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <return>List of disaster recovery pairings.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing> ListByNamespace(string resourceGroupName, string namespaceName);

        /// <summary>
        /// Gets entry point to manage authorization rules of a disaster recovery pairing.
        /// </summary>
        Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRules AuthorizationRules { get; }

        /// <summary>
        /// Gets a disaster recovery pairings of a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Disaster recovery pairing name.</param>
        /// <return>The disaster recovery pairing.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing GetByName(string resourceGroupName, string namespaceName, string name);

        /// <summary>
        /// Lists the disaster recovery pairings of a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <return>Observable that emits disaster recovery pairings.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing>> ListByNamespaceAsync(string resourceGroupName, string namespaceName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a disaster recovery pairings of a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Disaster recovery pairing name.</param>
        /// <return>Observable that emits disaster recovery pairings.</return>
        Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing> GetByNameAsync(string resourceGroupName, string namespaceName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a disaster recovery pairings of a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Disaster recovery pairing.</param>
        void DeleteByName(string resourceGroupName, string namespaceName, string name);

        /// <summary>
        /// Deletes a disaster recovery pairings of a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Disaster recovery pairing name.</param>
        /// <return>The completable representing the task.</return>
        Task DeleteByNameAsync(string resourceGroupName, string namespaceName, string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}