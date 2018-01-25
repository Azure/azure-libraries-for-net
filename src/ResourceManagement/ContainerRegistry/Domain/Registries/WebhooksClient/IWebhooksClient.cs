// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Registries.WebhooksClient
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent;

    /// <summary>
    /// Grouping of registry webhook actions.
    /// </summary>
    public interface IWebhooksClient :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Registries.WebhooksClient.IWebhooksClientBeta
    {
    }

    /// <summary>
    /// Grouping of registry webhook actions.
    /// </summary>
    public interface IWebhooksClientBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the properties of the specified webhook.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="webhookName">The name of the webhook.</param>
        /// <return>The Webhook object if successful.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook Get(string resourceGroupName, string registryName, string webhookName);

        /// <summary>
        /// Deletes a webhook from the container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="webhookName">The name of the webhook.</param>
        /// <return>A representation of the future computation of this call.</return>
        Task DeleteAsync(string resourceGroupName, string registryName, string webhookName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the properties of the specified webhook.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="webhookName">The name of the webhook.</param>
        /// <return>A representation of the future computation of this call, returning the Webhook object.</return>
        Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> GetAsync(string resourceGroupName, string registryName, string webhookName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all the webhooks for the container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>The list of all the webhooks for the specified container registry.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> List(string resourceGroupName, string registryName);

        /// <summary>
        /// Deletes a webhook from the container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="webhookName">The name of the webhook.</param>
        void Delete(string resourceGroupName, string registryName, string webhookName);

        /// <summary>
        /// Lists all the webhooks for the container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>A representation of the future computation of this call, returning the list of all the webhooks for the specified container registry.</return>
        Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IWebhook>> ListAsync(string resourceGroupName, string registryName, CancellationToken cancellationToken = default(CancellationToken));
    }
}