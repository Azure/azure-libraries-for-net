// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Definition;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Update;
    using System;

    internal partial class EventHubConsumerGroupImpl 
    {
        /// <summary>
        /// Gets last modified time of the consumer group.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup.UpdatedAt
        {
            get
            {
                return this.UpdatedAt();
            }
        }

        /// <summary>
        /// Gets the resource group of the namespace where parent event hub resides.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup.NamespaceResourceGroupName
        {
            get
            {
                return this.NamespaceResourceGroupName();
            }
        }

        /// <summary>
        /// Gets creation time of the consumer group.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup.CreatedAt
        {
            get
            {
                return this.CreatedAt();
            }
        }

        /// <summary>
        /// Gets the namespace name of parent event hub.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup.NamespaceName
        {
            get
            {
                return this.NamespaceName();
            }
        }

        /// <summary>
        /// Gets the name of the parent event hub.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup.EventHubName
        {
            get
            {
                return this.EventHubName();
            }
        }

        /// <summary>
        /// Gets user metadata associated with the consumer group.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup.UserMetadata
        {
            get
            {
                return this.UserMetadata();
            }
        }

        /// <summary>
        /// Specifies the event hub for which consumer group needs to be created.
        /// </summary>
        /// <param name="eventHub">Event hub.</param>
        /// <return>Next stage of the consumer group definition.</return>
        EventHubConsumerGroup.Definition.IWithCreate EventHubConsumerGroup.Definition.IWithEventHub.WithExistingEventHub(IEventHub eventHub)
        {
            return this.WithExistingEventHub(eventHub);
        }

        /// <summary>
        /// Specifies the event hub for which consumer group needs to be created.
        /// </summary>
        /// <param name="eventHubId">ARM resource id of event hub.</param>
        /// <return>Next stage of the consumer group definition.</return>
        EventHubConsumerGroup.Definition.IWithCreate EventHubConsumerGroup.Definition.IWithEventHub.WithExistingEventHubId(string eventHubId)
        {
            return this.WithExistingEventHubId(eventHubId);
        }

        /// <summary>
        /// Specifies the event hub for which consumer group needs to be created.
        /// </summary>
        /// <param name="resourceGroupName">Event hub namespace resource group name.</param>
        /// <param name="namespaceName">Event hub namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>Next stage of the consumer group definition.</return>
        EventHubConsumerGroup.Definition.IWithCreate EventHubConsumerGroup.Definition.IWithEventHub.WithExistingEventHub(string resourceGroupName, string namespaceName, string eventHubName)
        {
            return this.WithExistingEventHub(resourceGroupName, namespaceName, eventHubName);
        }

        /// <summary>
        /// Specifies user metadata.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <return>Next stage of the consumer group update.</return>
        EventHubConsumerGroup.Update.IUpdate EventHubConsumerGroup.Update.IWithUserMetadata.WithUserMetadata(string metadata)
        {
            return this.WithUserMetadata(metadata);
        }

        /// <summary>
        /// Specifies user metadata.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <return>Next stage of the consumer group definition.</return>
        EventHubConsumerGroup.Definition.IWithCreate EventHubConsumerGroup.Definition.IWithUserMetadata.WithUserMetadata(string metadata)
        {
            return this.WithUserMetadata(metadata);
        }
    }
}