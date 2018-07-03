// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Update;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateResource;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.WebhookDefinition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Rest;

    internal partial class WebhookImpl
    {
        /// <return>The webhook parent ID.</return>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.ParentId()
        {
            return this.ParentId();
        }

        /// <summary>
        /// Changes the status of the webhook to "disabled".
        /// </summary>
        void Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.Disable()
        {

            this.Disable();
        }

        /// <return>A representation of the future computation of this call, returning the list of event info object.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IWebhookEventInfo>> Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.ListEventsAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListEventsAsync(loadAllPages, cancellationToken);
        }

        /// <summary>
        /// Changes the status of the webhook to "enabled".
        /// </summary>
        void Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.Enable()
        {

            this.Enable();
        }

        /// <return>The Custom headers that will be added to the webhook notifications.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.CustomHeaders()
        {
            return this.CustomHeaders();
        }

        /// <return>The list of event info object.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhookEventInfo> Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.ListEvents()
        {
            return this.ListEvents();
        }

        /// <summary>
        /// Changes the status of the webhook to "disabled".
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        async Task Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.DisableAsync(CancellationToken cancellationToken)
        {

            await this.DisableAsync(cancellationToken);
        }

        /// <return>The provisioning state of the webhook.</return>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.ProvisioningState()
        {
            return this.ProvisioningState();
        }

        /// <return>The list of actions that trigger the webhook to post notifications.</return>
        System.Collections.Generic.IReadOnlyCollection<string> Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.Triggers()
        {
            return this.Triggers();
        }

        /// <return>The service URI for the webhook to post notifications.</return>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.ServiceUri()
        {
            return this.ServiceUri();
        }

        /// <return>
        /// The scope of repositories where the event can be triggered
        /// For example:
        /// - 'foo:' means events for all tags under repository 'foo'
        /// - 'foo:bar' means events for 'foo:bar' only
        /// - 'foo' is equivalent to 'foo:latest'
        /// - empty means all events.
        /// </return>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.Scope()
        {
            return this.Scope();
        }

        /// <summary>
        /// Changes the status of the webhook to "enabled".
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        async Task Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.EnableAsync(CancellationToken cancellationToken)
        {

            await this.EnableAsync(cancellationToken);
        }

        /// <return>A representation of the future computation of this call, returning the id on an event info resource.</return>
        async Task<string> Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.PingAsync(CancellationToken cancellationToken)
        {
            return await this.PingAsync(cancellationToken);
        }

        /// <return>The status of the webhook.</return>
        bool Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.IsEnabled()
        {
            return this.IsEnabled();
        }

        /// <return>The id on an event info resource.</return>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook.Ping()
        {
            return this.Ping();
        }

        /// <summary>
        /// Specifies the scope of repositories where the event can be triggered.
        /// For example, 'foo:' means events for all tags under repository 'foo'. 'foo:bar' means events for 'foo:bar' only.
        /// 'foo' is equivalent to 'foo:latest', empty means all events.
        /// </summary>
        /// <param name="repositoriesScope">The scope of repositories where the event can be triggered; empty means all events.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.UpdateDefinition.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateDefinition.IWithRepositoriesScope<Registry.Update.IUpdate>.WithRepositoriesScope(string repositoriesScope)
        {
            return this.WithRepositoriesScope(repositoriesScope);
        }

        /// <summary>
        /// Specifies the scope of repositories where the event can be triggered.
        /// For example, 'foo:' means events for all tags under repository 'foo'. 'foo:bar' means events for 'foo:bar' only.
        /// 'foo' is equivalent to 'foo:latest', empty means all events.
        /// </summary>
        /// <param name="repositoriesScope">The scope of repositories where the event can be triggered; empty means all events.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.Definition.IWithAttach<Registry.Definition.IWithCreate> Webhook.Definition.IWithRepositoriesScope<Registry.Definition.IWithCreate>.WithRepositoriesScope(string repositoriesScope)
        {
            return this.WithRepositoriesScope(repositoriesScope);
        }

        /// <summary>
        /// Updates the scope of repositories where the event can be triggered.
        /// For example, 'foo:' means events for all tags under repository 'foo'. 'foo:bar' means events for 'foo:bar' only.
        /// 'foo' is equivalent to 'foo:latest', empty means all events.
        /// </summary>
        /// <param name="repositoriesScope">The scope of repositories where the event can be triggered; empty means all events.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.UpdateResource.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateResource.IWithRepositoriesScope<Registry.Update.IUpdate>.WithRepositoriesScope(string repositoriesScope)
        {
            return this.WithRepositoriesScope(repositoriesScope);
        }

        /// <summary>
        /// Gets the name of the region the resource is in.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.RegionName
        {
            get
            {
                return this.RegionName();
            }
        }

        /// <summary>
        /// Gets the tags for the resource.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Tags
        {
            get
            {
                return this.Tags();
            }
        }

        /// <summary>
        /// Gets the region the resource is in.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Region
        {
            get
            {
                return this.Region();
            }
        }

        /// <summary>
        /// Gets the type of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Specifies a custom header that will be added to notifications.
        /// Consecutive calls to this method will add additional headers.
        /// </summary>
        /// <param name="name">Of the optional header.</param>
        /// <param name="value">Of the optional header.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.Update.IUpdate Webhook.Update.IWithCustomHeaders.WithCustomHeader(string name, string value)
        {
            return this.WithCustomHeader(name, value);
        }

        /// <summary>
        /// Specifies custom headers that will be added to the notifications.
        /// </summary>
        /// <param name="customHeaders">The "Name=Value" custom headers.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.Update.IUpdate Webhook.Update.IWithCustomHeaders.WithCustomHeaders(IDictionary<string, string> customHeaders)
        {
            return this.WithCustomHeaders(customHeaders);
        }

        /// <summary>
        /// Removes a tag from the resource.
        /// </summary>
        /// <param name="key">The key of the tag to remove.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Webhook.Update.IUpdate>.WithoutTag(string key)
        {
            return this.WithoutTag(key);
        }

        /// <summary>
        /// Specifies tags for the resource as a  Map.
        /// </summary>
        /// <param name="tags">A  Map of tags.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Webhook.Update.IUpdate>.WithTags(IDictionary<string, string> tags)
        {
            return this.WithTags(tags);
        }

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Webhook.Update.IUpdate>.WithTag(string key, string value)
        {
            return this.WithTag(key, value);
        }

        /// <summary>
        /// Specifies the actions that will trigger the webhook notifications.
        /// </summary>
        /// <param name="webhookActions">The webhook actions.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.Update.IUpdate Webhook.Update.IWithTriggerWhen.WithTriggerWhen(params string[] webhookActions)
        {
            return this.WithTriggerWhen(webhookActions);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        Registry.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<Registry.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Specifies tags for the webhook.
        /// </summary>
        /// <param name="tags">A  Map of tags.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.UpdateDefinition.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateDefinition.IWithTags<Registry.Update.IUpdate>.WithTags(IDictionary<string, string> tags)
        {
            return this.WithTags(tags);
        }

        /// <summary>
        /// Adds a tag to the webhook.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.UpdateDefinition.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateDefinition.IWithTags<Registry.Update.IUpdate>.WithTag(string key, string value)
        {
            return this.WithTag(key, value);
        }

        /// <summary>
        /// Removes a tag from the resource.
        /// </summary>
        /// <param name="key">The key of the tag to remove.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.UpdateResource.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateResource.IWithOrWithoutTags<Registry.Update.IUpdate>.WithoutTag(string key)
        {
            return this.WithoutTag(key);
        }

        /// <summary>
        /// Specifies tags for the webhook.
        /// </summary>
        /// <param name="tags">A  Map of tags.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.UpdateResource.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateResource.IWithOrWithoutTags<Registry.Update.IUpdate>.WithTags(IDictionary<string, string> tags)
        {
            return this.WithTags(tags);
        }

        /// <summary>
        /// Adds a tag to the webhook.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.UpdateResource.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateResource.IWithOrWithoutTags<Registry.Update.IUpdate>.WithTag(string key, string value)
        {
            return this.WithTag(key, value);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        Registry.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<Registry.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Specifies a custom header that will be added to notifications.
        /// Consecutive calls to this method will add additional headers.
        /// </summary>
        /// <param name="name">Of the optional header.</param>
        /// <param name="value">Of the optional header.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.UpdateDefinition.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateDefinition.IWithCustomHeaders<Registry.Update.IUpdate>.WithCustomHeader(string name, string value)
        {
            return this.WithCustomHeader(name, value);
        }

        /// <summary>
        /// Specifies the custom headers that will be added to the notifications.
        /// </summary>
        /// <param name="customHeaders">The "Name=Value" custom headers.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.UpdateDefinition.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateDefinition.IWithCustomHeaders<Registry.Update.IUpdate>.WithCustomHeaders(IDictionary<string, string> customHeaders)
        {
            return this.WithCustomHeaders(customHeaders);
        }

        /// <summary>
        /// Specifies a custom header that will be added to notifications.
        /// Consecutive calls to this method will add additional headers.
        /// </summary>
        /// <param name="name">Of the optional header.</param>
        /// <param name="value">Of the optional header.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.Definition.IWithAttach<Registry.Definition.IWithCreate> Webhook.Definition.IWithCustomHeaders<Registry.Definition.IWithCreate>.WithCustomHeader(string name, string value)
        {
            return this.WithCustomHeader(name, value);
        }

        /// <summary>
        /// Specifies the custom headers that will be added to the notifications.
        /// </summary>
        /// <param name="customHeaders">The "Name=Value" custom headers.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.Definition.IWithAttach<Registry.Definition.IWithCreate> Webhook.Definition.IWithCustomHeaders<Registry.Definition.IWithCreate>.WithCustomHeaders(IDictionary<string, string> customHeaders)
        {
            return this.WithCustomHeaders(customHeaders);
        }

        /// <summary>
        /// Specifies a custom header that will be added to notifications.
        /// Consecutive calls to this method will add additional headers.
        /// </summary>
        /// <param name="name">Of the optional header.</param>
        /// <param name="value">Of the optional header.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.UpdateResource.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateResource.IWithCustomHeaders<Registry.Update.IUpdate>.WithCustomHeader(string name, string value)
        {
            return this.WithCustomHeader(name, value);
        }

        /// <summary>
        /// Specifies the custom headers that will be added to the notifications.
        /// </summary>
        /// <param name="customHeaders">The "Name=Value" custom headers.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.UpdateResource.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateResource.IWithCustomHeaders<Registry.Update.IUpdate>.WithCustomHeaders(IDictionary<string, string> customHeaders)
        {
            return this.WithCustomHeaders(customHeaders);
        }

        /// <summary>
        /// Specifies the scope of repositories where the event can be triggered.
        /// For example, 'foo:' means events for all tags under repository 'foo'. 'foo:bar' means events for 'foo:bar' only.
        /// 'foo' is equivalent to 'foo:latest', empty means all events.
        /// </summary>
        /// <param name="repositoriesScope">The scope of repositories where the event can be triggered; empty means all events.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.Update.IUpdate Webhook.Update.IWithRepositoriesScope.WithRepositoriesScope(string repositoriesScope)
        {
            return this.WithRepositoriesScope(repositoriesScope);
        }

        /// <summary>
        /// Specifies the service URI for post notifications.
        /// </summary>
        /// <param name="serviceUri">The service URI for the post notifications.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.UpdateDefinition.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateDefinition.IWithServiceUri<Registry.Update.IUpdate>.WithServiceUri(string serviceUri)
        {
            return this.WithServiceUri(serviceUri);
        }

        /// <summary>
        /// Specifies the service URI for post notifications.
        /// </summary>
        /// <param name="serviceUri">The service URI for the post notifications.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.Definition.IWithAttach<Registry.Definition.IWithCreate> Webhook.Definition.IWithServiceUri<Registry.Definition.IWithCreate>.WithServiceUri(string serviceUri)
        {
            return this.WithServiceUri(serviceUri);
        }

        /// <summary>
        /// Specifies the service URI for post notifications.
        /// </summary>
        /// <param name="serviceUri">The service URI for the post notifications.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.UpdateResource.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateResource.IWithServiceUri<Registry.Update.IUpdate>.WithServiceUri(string serviceUri)
        {
            return this.WithServiceUri(serviceUri);
        }

        /// <summary>
        /// Specifies the default status of the webhook; default is "enabled".
        /// </summary>
        /// <param name="defaultStatus">Indicates whether the webhook is enabled or disabled after being created.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.UpdateDefinition.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateDefinition.IWithDefaultStatus<Registry.Update.IUpdate>.Enabled(bool defaultStatus)
        {
            return this.Enabled(defaultStatus);
        }

        /// <summary>
        /// Specifies the default status of the webhook; default is "enabled".
        /// </summary>
        /// <param name="defaultStatus">Indicates whether the webhook is enabled or disabled after being created.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.Definition.IWithAttach<Registry.Definition.IWithCreate> Webhook.Definition.IWithDefaultStatus<Registry.Definition.IWithCreate>.Enabled(bool defaultStatus)
        {
            return this.Enabled(defaultStatus);
        }

        /// <summary>
        /// Updates the default status of the webhook.
        /// </summary>
        /// <param name="defaultStatus">Indicates whether the webhook is enabled or disabled after being created.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.UpdateResource.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateResource.IWithDefaultStatus<Registry.Update.IUpdate>.Enabled(bool defaultStatus)
        {
            return this.Enabled(defaultStatus);
        }

        /// <summary>
        /// Execute the update request asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook>.ApplyAsync(CancellationToken cancellationToken, bool multiThreaded = true)
        {
            return await this.ApplyAsync(cancellationToken);
        }

        /// <summary>
        /// Execute the update request.
        /// </summary>
        /// <return>The updated resource.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook>.Apply()
        {
            return this.Apply();
        }

        /// <summary>
        /// Specifies the service URI for post notifications.
        /// </summary>
        /// <param name="serviceUri">The service URI for the post notifications.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.Update.IUpdate Webhook.Update.IWithServiceUri.WithServiceUri(string serviceUri)
        {
            return this.WithServiceUri(serviceUri);
        }

        /// <summary>
        /// Specifies the default status of the webhook; default is "enabled".
        /// </summary>
        /// <param name="defaultStatus">Indicates whether the webhook is enabled or disabled after being created.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.Update.IUpdate Webhook.Update.IWithDefaultStatus.Enabled(bool defaultStatus)
        {
            return this.Enabled(defaultStatus);
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        Webhook.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Webhook.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Specifies the actions that will trigger the webhook notifications.
        /// </summary>
        /// <param name="webhookActions">The webhook actions.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.UpdateDefinition.IWithServiceUri<Registry.Update.IUpdate> Webhook.UpdateDefinition.IWithTriggerWhen<Registry.Update.IUpdate>.WithTriggerWhen(params string[] webhookActions)
        {
            return this.WithTriggerWhen(webhookActions);
        }

        /// <summary>
        /// Specifies the actions that will trigger the webhook notifications.
        /// </summary>
        /// <param name="webhookActions">The webhook actions.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.Definition.IWithServiceUri<Registry.Definition.IWithCreate> Webhook.Definition.IWithTriggerWhen<Registry.Definition.IWithCreate>.WithTriggerWhen(params string[] webhookActions)
        {
            return this.WithTriggerWhen(webhookActions);
        }

        /// <summary>
        /// Specifies the actions that will trigger the webhook notifications.
        /// </summary>
        /// <param name="webhookActions">The webhook actions.</param>
        /// <return>The next stage of the resource update.</return>
        Webhook.UpdateResource.IWithAttach<Registry.Update.IUpdate> Webhook.UpdateResource.IWithTriggerWhen<Registry.Update.IUpdate>.WithTriggerWhen(params string[] webhookActions)
        {
            return this.WithTriggerWhen(webhookActions);
        }

        /// <summary>
        /// Specifies tags for the resource as a  Map.
        /// </summary>
        /// <param name="tags">A  Map of tags.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.Definition.IWithAttach<Registry.Definition.IWithCreate> Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Webhook.Definition.IWithAttach<Registry.Definition.IWithCreate>>.WithTags(IDictionary<string, string> tags)
        {
            return this.WithTags(tags);
        }

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the definition.</return>
        Webhook.Definition.IWithAttach<Registry.Definition.IWithCreate> Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Webhook.Definition.IWithAttach<Registry.Definition.IWithCreate>>.WithTag(string key, string value)
        {
            return this.WithTag(key, value);
        }
    }
}