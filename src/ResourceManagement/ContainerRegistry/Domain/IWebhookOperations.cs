// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Grouping of container registry webhook actions.
    /// </summary>
    public interface IWebhookOperations :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the properties of the specified webhook.
        /// </summary>
        /// <param name="webhookName">The name of the webhook.</param>
        /// <return>The Webhook object if successful.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook Get(string webhookName);

        /// <summary>
        /// Deletes a webhook from the container registry.
        /// </summary>
        /// <param name="webhookName">The name of the webhook.</param>
        /// <return>A representation of the future computation of this call.</return>
        Task DeleteAsync(string webhookName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the properties of the specified webhook.
        /// </summary>
        /// <param name="webhookName">The name of the webhook.</param>
        /// <return>A representation of the future computation of this call, returning the Webhook object.</return>
        Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> GetAsync(string webhookName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all the webhooks for the container registry.
        /// </summary>
        /// <return>The list of all the webhooks for the specified container registry.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> List();

        /// <summary>
        /// Deletes a webhook from the container registry.
        /// </summary>
        /// <param name="webhookName">The name of the webhook.</param>
        void Delete(string webhookName);

        /// <summary>
        /// Lists all the webhooks for the container registry.
        /// </summary>
        /// <return>A representation of the future computation of this call, returning the list of all the webhooks for the specified container registry.</return>
        Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IWebhook>> ListAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}