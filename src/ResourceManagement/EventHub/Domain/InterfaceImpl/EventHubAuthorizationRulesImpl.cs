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

    internal partial class EventHubAuthorizationRulesImpl 
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
        EventHubAuthorizationRule.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<EventHubAuthorizationRule.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule>.GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Deletes an authorization rule of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="name">Authorization rule name.</param>
        /// <return>The completable representing the task.</return>
        async Task Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRules.DeleteByNameAsync(string resourceGroupName, string namespaceName, string eventHubName, string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteByNameAsync(resourceGroupName, namespaceName, eventHubName, name, cancellationToken);
        }

        /// <summary>
        /// Deletes an authorization rule of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="name">Authorization rule name.</param>
        void Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRules.DeleteByName(string resourceGroupName, string namespaceName, string eventHubName, string name)
        {
 
            this.DeleteByName(resourceGroupName, namespaceName, eventHubName, name);
        }

        /// <summary>
        /// Gets an authorization rule of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="name">Authorization rule name.</param>
        /// <return>The authorization rule.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRules.GetByName(string resourceGroupName, string namespaceName, string eventHubName, string name)
        {
            return this.GetByName(resourceGroupName, namespaceName, eventHubName, name);
        }

        /// <summary>
        /// Gets an authorization rule of an event hub in a namespace in a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="name">Authorization rule name.</param>
        /// <return>Observable that emits the authorization rule.</return>
        async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule> Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRules.GetByNameAsync(string resourceGroupName, string namespaceName, string eventHubName, string name, CancellationToken cancellationToken)
        {
            return await this.GetByNameAsync(resourceGroupName, namespaceName, eventHubName, name, cancellationToken);
        }

        /// <summary>
        /// Lists the authorization rules of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>List of authorization rules.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule> Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRules.ListByEventHub(string resourceGroupName, string namespaceName, string eventHubName)
        {
            return this.ListByEventHub(resourceGroupName, namespaceName, eventHubName);
        }

        /// <summary>
        /// Lists the authorization rules of an event hub in a namespace under a resource group.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>Observable that emits the authorization rules.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule>> Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRules.ListByEventHubAsync(string resourceGroupName, string namespaceName, string eventHubName, CancellationToken cancellationToken)
        {
            return await this.ListByEventHubAsync(resourceGroupName, namespaceName, eventHubName, cancellationToken);
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
    }
}