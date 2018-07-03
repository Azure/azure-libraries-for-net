// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registries.WebhooksClient;

    internal partial class WebhooksClientImpl
    {
        /// <summary>
        /// Gets the properties of the specified webhook.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="webhookName">The name of the webhook.</param>
        /// <return>A representation of the future computation of this call, returning the Webhook object.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> Registries.WebhooksClient.IWebhooksClientBeta.GetAsync(string resourceGroupName, string registryName, string webhookName, CancellationToken cancellationToken)
        {
            return await this.GetAsync(resourceGroupName, registryName, webhookName, cancellationToken);
        }

        /// <summary>
        /// Gets the properties of the specified webhook.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="webhookName">The name of the webhook.</param>
        /// <return>The Webhook object if successful.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook Registries.WebhooksClient.IWebhooksClientBeta.Get(string resourceGroupName, string registryName, string webhookName)
        {
            return this.Get(resourceGroupName, registryName, webhookName);
        }

        /// <summary>
        /// Deletes a webhook from the container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="webhookName">The name of the webhook.</param>
        /// <return>A representation of the future computation of this call.</return>
        async Task Registries.WebhooksClient.IWebhooksClientBeta.DeleteAsync(string resourceGroupName, string registryName, string webhookName, CancellationToken cancellationToken)
        {

            await this.DeleteAsync(resourceGroupName, registryName, webhookName, cancellationToken);
        }

        /// <summary>
        /// Lists all the webhooks for the container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>The list of all the webhooks for the specified container registry.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> Registries.WebhooksClient.IWebhooksClientBeta.List(string resourceGroupName, string registryName)
        {
            return this.List(resourceGroupName, registryName);
        }

        /// <summary>
        /// Deletes a webhook from the container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="webhookName">The name of the webhook.</param>
        void Registries.WebhooksClient.IWebhooksClientBeta.Delete(string resourceGroupName, string registryName, string webhookName)
        {

            this.Delete(resourceGroupName, registryName, webhookName);
        }

        /// <summary>
        /// Lists all the webhooks for the container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>A representation of the future computation of this call, returning the list of all the webhooks for the specified container registry.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IWebhook>> Registries.WebhooksClient.IWebhooksClientBeta.ListAsync(string resourceGroupName, string registryName, CancellationToken cancellationToken)
        {
            return await this.ListAsync(resourceGroupName, registryName, cancellationToken);
        }
    }
}