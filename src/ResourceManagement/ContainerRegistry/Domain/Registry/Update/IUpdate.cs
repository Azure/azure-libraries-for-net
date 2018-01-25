// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateResource;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the container registry update allowing to add or remove a webhook.
    /// </summary>
    public interface IWithWebhook
    {
        /// <summary>
        /// Begins the definition of a new webhook to be added to this container registry.
        /// </summary>
        /// <param name="name">The name of the new webhook.</param>
        /// <return>The first stage of the new webhook definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition.IBlank<Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IUpdate> DefineWebhook(string name);

        /// <summary>
        /// Begins the description of an update of an existing webhook of this container registry.
        /// </summary>
        /// <param name="name">The name of an existing webhook.</param>
        /// <return>The first stage of the webhook update description.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateResource.IBlank<Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IUpdate> UpdateWebhook(string name);

        /// <summary>
        /// Removes a webhook from the container registry.
        /// </summary>
        /// <param name="name">Name of the webhook to remove.</param>
        /// <return>The next stage of the container registry update.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IUpdate WithoutWebhook(string name);
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IWithAdminUserEnabled,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IWithSku,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IWithWebhook
    {
    }

    /// <summary>
    /// The stage of the registry update allowing to enable admin user.
    /// </summary>
    public interface IWithAdminUserEnabled
    {
        /// <summary>
        /// Disable admin user.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IUpdate WithoutRegistryNameAsAdminUser();

        /// <summary>
        /// Enable admin user.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IUpdate WithRegistryNameAsAdminUser();
    }

    /// <summary>
    /// The stage of the registry definition allowing to specify the SKU type.
    /// </summary>
    public interface IWithSku :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IWithSkuBeta
    {
    }

    /// <summary>
    /// The stage of the registry definition allowing to specify the SKU type.
    /// </summary>
    public interface IWithSkuBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Updates the current container registry to a 'managed' registry with a 'Premium' SKU type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IUpdate WithPremiumSku();

        /// <summary>
        /// Updates the current container registry to a 'managed' registry with a 'Basic' SKU type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IUpdate WithBasicSku();

        /// <summary>
        /// Updates the current container registry to a 'managed' registry with a 'Standard' SKU type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IUpdate WithStandardSku();
    }
}