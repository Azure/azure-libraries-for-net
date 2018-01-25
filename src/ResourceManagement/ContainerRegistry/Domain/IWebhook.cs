// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An object that represents a webhook for a container registry.
    /// </summary>
    public interface IWebhook :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook, Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.WebhookInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Webhook.Update.IUpdate>
    {
        /// <summary>
        /// Changes the status of the webhook to "disabled".
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        Task DisableAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The list of event info object.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhookEventInfo> ListEvents();

        /// <return>The service URI for the webhook to post notifications.</return>
        string ServiceUri();

        /// <return>The id on an event info resource.</return>
        string Ping();

        /// <return>The provisioning state of the webhook.</return>
        string ProvisioningState();

        /// <return>The list of actions that trigger the webhook to post notifications.</return>
        System.Collections.Generic.IReadOnlyCollection<string> Triggers();

        /// <return>A representation of the future computation of this call, returning the id on an event info resource.</return>
        Task<string> PingAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The webhook parent ID.</return>
        string ParentId();

        /// <summary>
        /// Changes the status of the webhook to "enabled".
        /// </summary>
        void Enable();

        /// <summary>
        /// Changes the status of the webhook to "disabled".
        /// </summary>
        void Disable();

        /// <return>The status of the webhook.</return>
        bool IsEnabled();

        /// <return>
        /// The scope of repositories where the event can be triggered
        /// For example:
        /// - 'foo:' means events for all tags under repository 'foo'
        /// - 'foo:bar' means events for 'foo:bar' only
        /// - 'foo' is equivalent to 'foo:latest'
        /// - empty means all events.
        /// </return>
        string Scope();

        /// <summary>
        /// Changes the status of the webhook to "enabled".
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        Task EnableAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>A representation of the future computation of this call, returning the list of event info object.</return>
        Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IWebhookEventInfo>> ListEventsAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The Custom headers that will be added to the webhook notifications.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, string> CustomHeaders();
    }
}