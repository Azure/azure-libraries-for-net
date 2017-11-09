// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Represents a webhook collection associated with a container registry.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLldlYmhvb2tzSW1wbA==
    internal partial class WebhooksImpl :
        ExternalChildResourcesNonCached<Microsoft.Azure.Management.ContainerRegistry.Fluent.WebhookImpl,
            Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook,
            Models.WebhookInner,
            Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry,
            Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryImpl>
    {
        /// <summary>
        /// Creates a new ExternalNonInlineChildResourcesImpl.
        /// </summary>
        /// <param name="parent">The parent Azure resource.</param>
        /// <param name="childResourceName">The child resource name.</param>
        ///GENMHASH:66F142811FEC393F5229A40A1C8A9E02:2AAABE23545481CB3D64F1514FD722EB
        internal WebhooksImpl(RegistryImpl parent, string childResourceName) : base(parent, childResourceName)
        {
        }

        ///GENMHASH:1FAD99B53D32CA4EAADFD2A40B2ECBE8:BE1DBDC691222556217F3059A3B70E43
        internal WebhookImpl DefineWebhook(string name)
        {
            return PrepareDefine(new WebhookImpl(name, this.Parent, new WebhookInner(), this.Parent.Manager)).SetCreateMode(true);
        }

        ///GENMHASH:0A63DA53100999E7C2D128BF82427B20:F24DF11C9A55FDCA5702691EAF3A837E
        internal WebhookImpl UpdateWebhook(string name)
        {
            return PrepareUpdate(new WebhookImpl(name, this.Parent, new WebhookInner(), this.Parent.Manager)).SetCreateMode(false);
        }

        ///GENMHASH:79DBD9E75BB562E15605F68076AB0D69:6AD0B497771959F74FCF4268931A8817
        internal void WithoutWebhook(string name)
        {
            PrepareRemove(new WebhookImpl(name, this.Parent, new WebhookInner(), this.Parent.Manager));
        }
    }
}