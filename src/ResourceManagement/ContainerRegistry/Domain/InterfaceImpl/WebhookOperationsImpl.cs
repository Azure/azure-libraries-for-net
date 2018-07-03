// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    internal partial class WebhookOperationsImpl
    {
        /// <summary>
        /// Gets the properties of the specified webhook.
        /// </summary>
        /// <param name="webhookName">The name of the webhook.</param>
        /// <return>A representation of the future computation of this call, returning the Webhook object.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhookOperations.GetAsync(string webhookName, CancellationToken cancellationToken)
        {
            return await this.GetAsync(webhookName, cancellationToken);
        }

        /// <summary>
        /// Gets the properties of the specified webhook.
        /// </summary>
        /// <param name="webhookName">The name of the webhook.</param>
        /// <return>The Webhook object if successful.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhookOperations.Get(string webhookName)
        {
            return this.Get(webhookName);
        }

        /// <summary>
        /// Deletes a webhook from the container registry.
        /// </summary>
        /// <param name="webhookName">The name of the webhook.</param>
        /// <return>A representation of the future computation of this call.</return>
        async Task Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhookOperations.DeleteAsync(string webhookName, CancellationToken cancellationToken)
        {

            await this.DeleteAsync(webhookName, cancellationToken);
        }

        /// <summary>
        /// Lists all the webhooks for the container registry.
        /// </summary>
        /// <return>The list of all the webhooks for the specified container registry.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhookOperations.List()
        {
            return this.List();
        }

        /// <summary>
        /// Deletes a webhook from the container registry.
        /// </summary>
        /// <param name="webhookName">The name of the webhook.</param>
        void Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhookOperations.Delete(string webhookName)
        {

            this.Delete(webhookName);
        }

        /// <summary>
        /// Lists all the webhooks for the container registry.
        /// </summary>
        /// <return>A representation of the future computation of this call, returning the list of all the webhooks for the specified container registry.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IWebhook>> Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhookOperations.ListAsync(CancellationToken cancellationToken)
        {
            return await this.ListAsync(cancellationToken);
        }
    }
}