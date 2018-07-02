// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class WebhookEventInfoImpl
    {
        /// <summary>
        /// Gets the event request object.
        /// </summary>
        /// <summary>
        /// Gets the event request message value.
        /// </summary>
        Models.EventRequestMessage Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhookEventInfo.EventRequestMessage
        {
            get
            {
                return this.EventRequestMessage();
            }
        }

        /// <summary>
        /// Gets the event response object.
        /// </summary>
        /// <summary>
        /// Gets the event response message value.
        /// </summary>
        Models.EventResponseMessage Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhookEventInfo.EventResponseMessage
        {
            get
            {
                return this.EventResponseMessage();
            }
        }
    }
}