// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Response containing the webhook event info.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLldlYmhvb2tFdmVudEluZm9JbXBs
    internal partial class WebhookEventInfoImpl :
        Wrapper<Models.EventModel>,
        IWebhookEventInfo
    {
        ///GENMHASH:19A0860D0FE0F8C33BCE64F5A049327A:C0C35E00AF4E17F141675A2C05C7067B
        internal WebhookEventInfoImpl(EventModel innerObject) : base(innerObject)
        {
        }

        ///GENMHASH:DFF5777E6F0AB08F7CF525A91781280F:7146C7ED704C3C7314E2FBCB7D3B05C9
        public EventRequestMessage EventRequestMessage()
        {
            return this.Inner.EventRequestMessage;
        }

        ///GENMHASH:36A6262275B4E1FEB60F456B6E8A5B82:091361769E7F03A5701A5AC210A003CA
        public EventResponseMessage EventResponseMessage()
        {
            return this.Inner.EventResponseMessage;
        }
    }
}