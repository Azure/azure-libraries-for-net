// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Definition
{
    using Microsoft.Azure.Management.Eventhub.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the consumer group definition allowing to specify the event
    /// hub to be associated with it.
    /// </summary>
    public interface IWithEventHub  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the event hub for which consumer group needs to be created.
        /// </summary>
        /// <param name="eventHub">Event hub.</param>
        /// <return>Next stage of the consumer group definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Definition.IWithCreate WithExistingEventHub(IEventHub eventHub);

        /// <summary>
        /// Specifies the event hub for which consumer group needs to be created.
        /// </summary>
        /// <param name="eventHubId">ARM resource id of event hub.</param>
        /// <return>Next stage of the consumer group definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Definition.IWithCreate WithExistingEventHubId(string eventHubId);

        /// <summary>
        /// Specifies the event hub for which consumer group needs to be created.
        /// </summary>
        /// <param name="resourceGroupName">Event hub namespace resource group name.</param>
        /// <param name="namespaceName">Event hub namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>Next stage of the consumer group definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Definition.IWithCreate WithExistingEventHub(string resourceGroupName, string namespaceName, string eventHubName);
    }

    /// <summary>
    /// The entirety of the consumer group definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Definition.IBlank,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Definition.IWithEventHub,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Definition.IWithUserMetadata,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The first stage of a event hub definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Definition.IWithEventHub
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup>,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Definition.IWithUserMetadata
    {
    }

    /// <summary>
    /// The stage of the consumer group definition allowing to specify user metadata.
    /// </summary>
    public interface IWithUserMetadata  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies user metadata.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <return>Next stage of the consumer group definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Definition.IWithCreate WithUserMetadata(string metadata);
    }
}