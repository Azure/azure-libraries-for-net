// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registries.WebhooksClient;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// Represents a webhook collection associated with a container registry.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLldlYmhvb2tzQ2xpZW50SW1wbA==
    internal partial class WebhooksClientImpl :
        IWebhooksClient
    {
        private IRegistryManager containerRegistryManager;
        private RegistryImpl containerRegistry;

        ///GENMHASH:CDAB2C7CC715005191421E1723AFA34B:07766DB5652046D840E62ECBE0F0FDCD
        internal WebhooksClientImpl(IRegistryManager containerRegistryManager, RegistryImpl containerRegistry)
        {
            this.containerRegistryManager = containerRegistryManager;
            this.containerRegistry = containerRegistry;
        }

        ///GENMHASH:B4DE4E5BA085FCF3F689DD80C333DEC9:4B663176F26172B67C57E6F09512717D
        public IWebhook Get(string resourceGroupName, string registryName, string webhookName)
        {
            return Extensions.Synchronize(() => this.GetAsync(resourceGroupName, registryName, webhookName));
        }

        ///GENMHASH:6D1A2C780BE8CE95C7C882306AEA5514:382B8CA255C0D129D8C065E6C9801354
        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> GetAsync(string resourceGroupName, string registryName, string webhookName, CancellationToken cancellationToken = default(CancellationToken))
        {
            WebhookImpl webhookImpl;
            var webhookInner = await this.containerRegistryManager.Inner.Webhooks.GetAsync(resourceGroupName, registryName, webhookName, cancellationToken);
            if (containerRegistry != null)
            {
                webhookImpl = new WebhookImpl(webhookName, this.containerRegistry, webhookInner, this.containerRegistryManager);
            }
            else
            {
                webhookImpl = new WebhookImpl(resourceGroupName, registryName, webhookName, webhookInner, this.containerRegistryManager);
            }

            return await webhookImpl.SetCallbackConfigAsync(cancellationToken);
        }

        ///GENMHASH:C73741244AF71C50A3CB0F7B14517950:1047C87FB26DE4E0D67A0498DB55743F
        public void Delete(string resourceGroupName, string registryName, string webhookName)
        {
            Extensions.Synchronize(() => this.DeleteAsync(resourceGroupName, registryName, webhookName));
        }

        ///GENMHASH:956078CCCB02CDB129D383BA12D9886F:18D8A9FADC236B488755DF02516D4F2B
        public async Task DeleteAsync(string resourceGroupName, string registryName, string webhookName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.containerRegistryManager.Inner.Webhooks.DeleteAsync(resourceGroupName, registryName, webhookName, cancellationToken);
        }

        ///GENMHASH:8A6D80F6F270494C39E9BA7A27626103:162DAF18D8EA836CCBC752D2F7559096
        public IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> List(string resourceGroupName, string registryName)
        {
            var webhooks = new List<IWebhook>();
            var webhooksResult = Extensions.Synchronize(() => this.ListAsync(resourceGroupName, registryName));
            if (webhooksResult != null)
            {
                foreach (var webhook in webhooksResult)
                {
                    webhooks.Add(webhook);
                }
            }
            return webhooks.AsReadOnly();
        }

        ///GENMHASH:04D22E8EB0595D779F54F42772D54010:BC657ACB9999414D5594C93B0EE0C86E
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IWebhook>> ListAsync(string resourceGroupName, string registryName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IWebhook, Models.WebhookInner>.LoadPageWithWrapModelAsync(async (cancellation) =>
            {
                return await this.containerRegistryManager.Inner.Webhooks.ListAsync(resourceGroupName, registryName, cancellationToken: cancellation);
            },
            this.containerRegistryManager.Inner.Webhooks.ListNextAsync,
            async (webhookInner, cancellation) => await WrapModelAsync(webhookInner, cancellationToken: cancellation),
            true, cancellationToken);
        }

        private async Task<IWebhook> WrapModelAsync(Models.WebhookInner webhookInner, CancellationToken cancellationToken)
        {
            WebhookImpl webhookImpl;
            if (containerRegistry != null)
            {
                webhookImpl = new WebhookImpl(webhookInner.Name, this.containerRegistry, webhookInner, this.containerRegistryManager);
            }
            else
            {
                string resourceGroupName = ResourceUtils.GroupFromResourceId(webhookInner.Id);
                string registryName = ResourceUtils.NameFromResourceId(ResourceUtils.ParentResourcePathFromResourceId(webhookInner.Id));
                webhookImpl = new WebhookImpl(resourceGroupName, registryName, webhookInner.Name, webhookInner, this.containerRegistryManager);
            }

            return await webhookImpl.SetCallbackConfigAsync(cancellationToken);
        }
    }
}