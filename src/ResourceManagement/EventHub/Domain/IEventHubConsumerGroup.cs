// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// Type representing consumer group of an event hub.
    /// </summary>
    public interface IEventHubConsumerGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.INestedResource,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Management.EventHub.Fluent.IEventHubManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Management.EventHub.Fluent.Models.ConsumerGroupInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<EventHubConsumerGroup.Update.IUpdate>
    {
        /// <summary>
        /// Gets the resource group of the namespace where parent event hub resides.
        /// </summary>
        string NamespaceResourceGroupName { get; }

        /// <summary>
        /// Gets creation time of the consumer group.
        /// </summary>
        System.DateTime? CreatedAt { get; }

        /// <summary>
        /// Gets the name of the parent event hub.
        /// </summary>
        string EventHubName { get; }

        /// <summary>
        /// Gets user metadata associated with the consumer group.
        /// </summary>
        string UserMetadata { get; }

        /// <summary>
        /// Gets the namespace name of parent event hub.
        /// </summary>
        string NamespaceName { get; }

        /// <summary>
        /// Gets last modified time of the consumer group.
        /// </summary>
        System.DateTime? UpdatedAt { get; }
    }
}