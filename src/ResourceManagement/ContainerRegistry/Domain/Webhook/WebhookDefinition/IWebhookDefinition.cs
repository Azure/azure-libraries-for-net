// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.WebhookDefinition
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Definition;

    /// <summary>
    /// Grouping of the container register webhook definitions.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWebhookDefinition<ParentT> :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Definition.IWithTriggerWhen<ParentT>,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Definition.IWithServiceUri<ParentT>,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.Definition.IWithAttach<ParentT>
    {
    }
}