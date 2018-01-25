// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// Grouping of the container registry's webhook update definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ParentT> :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithTriggerWhen<ParentT>,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithServiceUri<ParentT>,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the webhook definition allowing to specify the tags.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithTags<ParentT>
    {
        /// <summary>
        /// Adds a tag to the webhook.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithAttach<ParentT> WithTag(string key, string value);

        /// <summary>
        /// Specifies tags for the webhook.
        /// </summary>
        /// <param name="tags">A  Map of tags.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithAttach<ParentT> WithTags(IDictionary<string, string> tags);
    }

    /// <summary>
    /// The first stage of the webhook definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithTriggerWhen<ParentT>
    {
    }

    /// <summary>
    /// The stage of the webhook definition allowing to specify the default status of the webhook after being created.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDefaultStatus<ParentT>
    {
        /// <summary>
        /// Specifies the default status of the webhook; default is "enabled".
        /// </summary>
        /// <param name="defaultStatus">Indicates whether the webhook is enabled or disabled after being created.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithAttach<ParentT> Enabled(bool defaultStatus);
    }

    /// <summary>
    /// The stage of the webhook definition allowing to specify the actions that will trigger the webhook notifications.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithTriggerWhen<ParentT>
    {
        /// <summary>
        /// Specifies the actions that will trigger the webhook notifications.
        /// </summary>
        /// <param name="webhookActions">The webhook actions.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithServiceUri<ParentT> WithTriggerWhen(params string[] webhookActions);
    }

    /// <summary>
    /// The stage of the webhook definition allowing to specify the custom headers that will be added to the notifications.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCustomHeaders<ParentT>
    {
        /// <summary>
        /// Specifies the custom headers that will be added to the notifications.
        /// </summary>
        /// <param name="customHeaders">The "Name=Value" custom headers.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithAttach<ParentT> WithCustomHeaders(IDictionary<string, string> customHeaders);

        /// <summary>
        /// Specifies a custom header that will be added to notifications.
        /// Consecutive calls to this method will add additional headers.
        /// </summary>
        /// <param name="name">Of the optional header.</param>
        /// <param name="value">Of the optional header.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithAttach<ParentT> WithCustomHeader(string name, string value);
    }

    /// <summary>
    /// The final stage of the webhook definition.
    /// At this stage, any remaining optional settings can be specified, or the webhook definition
    /// can be attached to the parent container group definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithCustomHeaders<ParentT>,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithRepositoriesScope<ParentT>,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithDefaultStatus<ParentT>,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithTags<ParentT>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>
    {
    }

    /// <summary>
    /// The stage of the webhook definition allowing to specify the scope of repositories where the event can be triggered.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithRepositoriesScope<ParentT>
    {
        /// <summary>
        /// Specifies the scope of repositories where the event can be triggered.
        /// For example, 'foo:' means events for all tags under repository 'foo'. 'foo:bar' means events for 'foo:bar' only.
        /// 'foo' is equivalent to 'foo:latest', empty means all events.
        /// </summary>
        /// <param name="repositoriesScope">The scope of repositories where the event can be triggered; empty means all events.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithAttach<ParentT> WithRepositoriesScope(string repositoriesScope);
    }

    /// <summary>
    /// The stage of the webhook definition allowing to specify the service URI for post notifications.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithServiceUri<ParentT>
    {
        /// <summary>
        /// Specifies the service URI for post notifications.
        /// </summary>
        /// <param name="serviceUri">The service URI for the post notifications.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IWithAttach<ParentT> WithServiceUri(string serviceUri);
    }
}