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
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Rest;
    using Microsoft.Azure.Management.EventHub.Fluent;

    internal partial class EventHubsImpl 
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        EventHub.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<EventHub.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub>.GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHub Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub>.GetById(string id)
        {
            return this.GetById(id);
        }

        /// <summary>
        /// Gets entry point to manage consumer group of event hubs.
        /// </summary>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroups Microsoft.Azure.Management.Eventhub.Fluent.IEventHubs.ConsumerGroups
        {
            get
            {
                return this.ConsumerGroups();
            }
        }

        /// <summary>
        /// Deletes an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Event hub name.</param>
        /// <return>The completable representing the task.</return>
        async Task Microsoft.Azure.Management.Eventhub.Fluent.IEventHubs.DeleteByNameAsync(string resourceGroupName, string namespaceName, string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteByNameAsync(resourceGroupName, namespaceName, name, cancellationToken);
        }

        /// <summary>
        /// Gets entry point to manage authorization rules of event hubs.
        /// </summary>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRules Microsoft.Azure.Management.Eventhub.Fluent.IEventHubs.AuthorizationRules
        {
            get
            {
                return this.AuthorizationRules();
            }
        }

        /// <summary>
        /// Deletes an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Event hub name.</param>
        void Microsoft.Azure.Management.Eventhub.Fluent.IEventHubs.DeleteByName(string resourceGroupName, string namespaceName, string name)
        {
 
            this.DeleteByName(resourceGroupName, namespaceName, name);
        }

        /// <summary>
        /// Gets an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Event hub name.</param>
        /// <return>The event hubs.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHub Microsoft.Azure.Management.Eventhub.Fluent.IEventHubs.GetByName(string resourceGroupName, string namespaceName, string name)
        {
            return this.GetByName(resourceGroupName, namespaceName, name);
        }

        /// <summary>
        /// Lists the event hubs in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <return>Observable that emits the event hubs.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub>> Microsoft.Azure.Management.Eventhub.Fluent.IEventHubs.ListByNamespaceAsync(string resourceGroupName, string namespaceName, CancellationToken cancellationToken)
        {
            return await this.ListByNamespaceAsync(resourceGroupName, namespaceName, cancellationToken);
        }

        /// <summary>
        /// Gets an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <param name="name">Event hub name.</param>
        /// <return>Observable that emits the event hubs.</return>
        async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub> Microsoft.Azure.Management.Eventhub.Fluent.IEventHubs.GetByNameAsync(string resourceGroupName, string namespaceName, string name, CancellationToken cancellationToken)
        {
            return await this.GetByNameAsync(resourceGroupName, namespaceName, name, cancellationToken);
        }

        /// <summary>
        /// Lists the event hubs in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <return>List of event hubs.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub> Microsoft.Azure.Management.Eventhub.Fluent.IEventHubs.ListByNamespace(string resourceGroupName, string namespaceName)
        {
            return this.ListByNamespace(resourceGroupName, namespaceName);
        }

        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById.DeleteByIdAsync(string id, CancellationToken cancellationToken)
        {
 
            await this.DeleteByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        void Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById.DeleteById(string id)
        {
 
            this.DeleteById(id);
        }
    }
}