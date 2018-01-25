// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the webhook definition allowing to specify the service URI for post notifications.
    /// </summary>
    public interface IWithServiceUri
    {
        /// <summary>
        /// Specifies the service URI for post notifications.
        /// </summary>
        /// <param name="serviceUri">The service URI for the post notifications.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update.IUpdate WithServiceUri(string serviceUri);
    }

    /// <summary>
    /// The stage of the webhook definition allowing to specify the scope of repositories where the event can be triggered.
    /// </summary>
    public interface IWithRepositoriesScope
    {
        /// <summary>
        /// Specifies the scope of repositories where the event can be triggered.
        /// For example, 'foo:' means events for all tags under repository 'foo'. 'foo:bar' means events for 'foo:bar' only.
        /// 'foo' is equivalent to 'foo:latest', empty means all events.
        /// </summary>
        /// <param name="repositoriesScope">The scope of repositories where the event can be triggered; empty means all events.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update.IUpdate WithRepositoriesScope(string repositoriesScope);
    }

    /// <summary>
    /// The stage of the webhook definition allowing to specify the default status of the webhook after being created.
    /// </summary>
    public interface IWithDefaultStatus
    {
        /// <summary>
        /// Specifies the default status of the webhook; default is "enabled".
        /// </summary>
        /// <param name="defaultStatus">Indicates whether the webhook is enabled or disabled after being created.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update.IUpdate Enabled(bool defaultStatus);
    }

    /// <summary>
    /// The entirety of a webhook update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update.IWithTriggerWhen,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update.IWithServiceUri,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update.IWithCustomHeaders,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update.IWithRepositoriesScope,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update.IWithDefaultStatus,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook>
    {
    }

    public interface IWithTriggerWhen
    {
        /// <summary>
        /// Specifies the actions that will trigger the webhook notifications.
        /// </summary>
        /// <param name="webhookActions">The webhook actions.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update.IUpdate WithTriggerWhen(params string[] webhookActions);
    }

    /// <summary>
    /// The stage of the webhook definition allowing to specify the custom headers that will be added to the notifications.
    /// </summary>
    public interface IWithCustomHeaders
    {
        /// <summary>
        /// Specifies custom headers that will be added to the notifications.
        /// </summary>
        /// <param name="customHeaders">The "Name=Value" custom headers.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update.IUpdate WithCustomHeaders(IDictionary<string, string> customHeaders);

        /// <summary>
        /// Specifies a custom header that will be added to notifications.
        /// Consecutive calls to this method will add additional headers.
        /// </summary>
        /// <param name="name">Of the optional header.</param>
        /// <param name="value">Of the optional header.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update.IUpdate WithCustomHeader(string name, string value);
    }
}