// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Update
{
    using Microsoft.Azure.Management.Eventhub.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the consumer group update allowing to specify user metadata.
    /// </summary>
    public interface IWithUserMetadata  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies user metadata.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <return>Next stage of the consumer group update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Update.IUpdate WithUserMetadata(string metadata);
    }

    /// <summary>
    /// The template for a consumer group update operation, containing all the settings
    /// that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup>,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Update.IWithUserMetadata
    {
    }
}