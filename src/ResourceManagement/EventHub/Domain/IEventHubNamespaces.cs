// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to manage EventHub namespaces.
    /// </summary>
    public interface IEventHubNamespaces  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<EventHubNamespace.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Management.EventHub.Fluent.IEventHubManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Management.EventHub.Fluent.INamespacesOperations>
    {
        /// <summary>
        /// Gets entry point to manage event hubs of event hub namespaces.
        /// </summary>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubs EventHubs { get; }

        /// <summary>
        /// Gets entry point to manage authorization rules of event hub namespaces.
        /// </summary>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRules AuthorizationRules { get; }
    }
}