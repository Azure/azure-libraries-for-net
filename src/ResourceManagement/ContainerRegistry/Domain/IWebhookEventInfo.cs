// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;

    /// <summary>
    /// Response containing the Webhook event details.
    /// </summary>
    public interface IWebhookEventInfo :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the event request object.
        /// </summary>
        /// <summary>
        /// Gets the event request message value.
        /// </summary>
        Models.EventRequestMessage EventRequestMessage { get; }

        /// <summary>
        /// Gets the event response object.
        /// </summary>
        /// <summary>
        /// Gets the event response message value.
        /// </summary>
        Models.EventResponseMessage EventResponseMessage { get; }
    }
}