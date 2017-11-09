// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a webhook collection associated with a container registry.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLldlYmhvb2tPcGVyYXRpb25zSW1wbA==
    internal partial class WebhookOperationsImpl :
        IWebhookOperations
    {
        private RegistryImpl containerRegistry;
        private WebhooksClientImpl webhooksClient;
        ///GENMHASH:E7EF4818FCB5238BA8C15964B9D45DA8:A40E3B70909E8E38B28A47FB40E4072F
        internal WebhookOperationsImpl(RegistryImpl containerRegistry)
        {
            this.containerRegistry = containerRegistry;
            if (containerRegistry != null)
            {
                this.webhooksClient = new WebhooksClientImpl(containerRegistry.Manager, containerRegistry);
            }
            else
            {
                this.webhooksClient = null;
            }
        }

        ///GENMHASH:206E829E50B031B66F6EA9C7402231F9:3963EBA38D3E5DBAFC06111544E0EF1F
        public IWebhook Get(string webhookName)
        {
            if (this.containerRegistry == null)
            {
                return null;
            }
            return this.webhooksClient.Get(this.containerRegistry.ResourceGroupName, this.containerRegistry.Name, webhookName);
        }

        ///GENMHASH:AF8385463FD062B3C56A3F22F51DFEE4:4452DD9A2E8FECF97DD02D07F0606673
        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> GetAsync(string webhookName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.containerRegistry == null)
            {
                return null;
            }
            return await this.webhooksClient.GetAsync(this.containerRegistry.ResourceGroupName, this.containerRegistry.Name, webhookName, cancellationToken);
        }

        ///GENMHASH:184FEA122A400D19B34517FEF358ED78:0D6C052BB7CDB0392FA76A199EF811DA
        public void Delete(string webhookName)
        {
            if (this.containerRegistry == null)
            {
                return;
            }
            this.webhooksClient.Delete(this.containerRegistry.ResourceGroupName, this.containerRegistry.Name, webhookName);
        }

        ///GENMHASH:BEDEF34E57C25BFA34A4AB1C8430428E:9D310F1D53080BDB2BB223193D7F4857
        public async Task DeleteAsync(string webhookName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.containerRegistry == null)
            {
                return;
            }
            await this.webhooksClient.DeleteAsync(this.containerRegistry.ResourceGroupName, this.containerRegistry.Name, webhookName, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:D81D316A659842A3A055B83052CADF08
        public IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> List()
        {
            if (this.containerRegistry != null)
            {
                return this.webhooksClient.List(this.containerRegistry.ResourceGroupName, this.containerRegistry.Name);
            }
            else
            {
                return new List<IWebhook>().AsReadOnly();
            }
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:653839A0F5B936DE3781953080508EA4
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IWebhook>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.containerRegistry != null)
            {
                return await this.webhooksClient.ListAsync(this.containerRegistry.ResourceGroupName, this.containerRegistry.Name, cancellationToken);
            }
            else
            {
                var task = new Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IWebhook>>(() =>
                {
                    return PagedCollection<IWebhook, Models.WebhookInner>.CreateFromEnumerable(new List<IWebhook>());
                });
                task.Start();
                return await task;
            }
        }
    }
}