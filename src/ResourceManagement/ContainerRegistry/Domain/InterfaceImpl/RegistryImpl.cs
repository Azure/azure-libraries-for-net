// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class RegistryImpl
    {
        /// <summary>
        /// The parameters of a storage account for the container registry.
        /// If specified, the storage account must be in the same physical location as the container registry.
        /// </summary>
        /// <param name="storageAccount">The storage account.</param>
        /// <return>The next stage.</return>
        Registry.Definition.IWithCreate Registry.Definition.IWithStorageAccount.WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            return this.WithExistingStorageAccount(storageAccount);
        }

        /// <summary>
        /// The ID of an existing storage account for the container registry.
        /// If specified, the storage account must be in the same physical location as the container registry.
        /// </summary>
        /// <param name="id">The resource ID of the storage account; must be in the same physical location as the container registry.</param>
        /// <return>The next stage.</return>
        Registry.Definition.IWithCreate Registry.Definition.IWithStorageAccountBeta.WithExistingStorageAccount(string id)
        {
            return this.WithExistingStorageAccount(id);
        }

        /// <summary>
        /// The parameters for a storage account for the container registry.
        /// A new storage account with default setting and specified name will be created.
        /// </summary>
        /// <param name="storageAccountName">The name of the storage account.</param>
        /// <return>The next stage.</return>
        Registry.Definition.IWithCreate Registry.Definition.IWithStorageAccountBeta.WithNewStorageAccount(string storageAccountName)
        {
            return this.WithNewStorageAccount(storageAccountName);
        }

        /// <summary>
        /// The parameters for a storage account for the container registry.
        /// If specified, the storage account must be in the same physical location as the container registry.
        /// </summary>
        /// <param name="creatable">The storage account to create.</param>
        /// <return>The next stage.</return>
        Registry.Definition.IWithCreate Registry.Definition.IWithStorageAccount.WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            return this.WithNewStorageAccount(creatable);
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        Registry.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Registry.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Begins the definition of a new webhook to be added to this container registry.
        /// </summary>
        /// <param name="name">The name of the new webhook.</param>
        /// <return>The first stage of the new webhook definition.</return>
        Webhook.Definition.IBlank<Registry.Definition.IWithCreate> Registry.Definition.IWithWebhook.DefineWebhook(string name)
        {
            return this.DefineWebhook(name);
        }

        /// <summary>
        /// Begins the definition of a new webhook to be added to this container registry.
        /// </summary>
        /// <param name="name">The name of the new webhook.</param>
        /// <return>The first stage of the new webhook definition.</return>
        Webhook.UpdateDefinition.IBlank<Registry.Update.IUpdate> Registry.Update.IWithWebhook.DefineWebhook(string name)
        {
            return this.DefineWebhook(name);
        }

        /// <summary>
        /// Begins the description of an update of an existing webhook of this container registry.
        /// </summary>
        /// <param name="name">The name of an existing webhook.</param>
        /// <return>The first stage of the webhook update description.</return>
        Webhook.UpdateResource.IBlank<Registry.Update.IUpdate> Registry.Update.IWithWebhook.UpdateWebhook(string name)
        {
            return this.UpdateWebhook(name);
        }

        /// <summary>
        /// Removes a webhook from the container registry.
        /// </summary>
        /// <param name="name">Name of the webhook to remove.</param>
        /// <return>The next stage of the container registry update.</return>
        Registry.Update.IUpdate Registry.Update.IWithWebhook.WithoutWebhook(string name)
        {
            return this.WithoutWebhook(name);
        }

        /// <summary>
        /// Enable admin user.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Registry.Definition.IWithCreate Registry.Definition.IWithAdminUserEnabled.WithRegistryNameAsAdminUser()
        {
            return this.WithRegistryNameAsAdminUser();
        }

        /// <summary>
        /// Enable admin user.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Registry.Update.IUpdate Registry.Update.IWithAdminUserEnabled.WithRegistryNameAsAdminUser()
        {
            return this.WithRegistryNameAsAdminUser();
        }

        /// <summary>
        /// Disable admin user.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Registry.Update.IUpdate Registry.Update.IWithAdminUserEnabled.WithoutRegistryNameAsAdminUser()
        {
            return this.WithoutRegistryNameAsAdminUser();
        }

        /// <summary>
        /// Lists the quota usages for the specified container registry.
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        async Task<IReadOnlyCollection<Models.RegistryUsage>> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.ListQuotaUsagesAsync(CancellationToken cancellationToken)
        {
            return await this.ListQuotaUsagesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the creation date of the container registry in ISO8601 format.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.CreationDate
        {
            get
            {
                return this.CreationDate();
            }
        }

        /// <summary>
        /// Gets the name of the storage account for the container registry; 'null' if container register SKU a managed tier.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.StorageAccountName
        {
            get
            {
                return this.StorageAccountName();
            }
        }

        /// <summary>
        /// Lists the quota usages for the specified container registry.
        /// </summary>
        /// <return>The list of container registry's quota usages.</return>
        System.Collections.Generic.IReadOnlyCollection<Models.RegistryUsage> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.ListQuotaUsages()
        {
            return this.ListQuotaUsages();
        }

        /// <summary>
        /// Gets the ID of the storage account for the container registry; 'null' if container register SKU a managed tier.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.StorageAccountId
        {
            get
            {
                return this.StorageAccountId();
            }
        }

        /// <summary>
        /// Gets the value that indicates whether the admin user is enabled.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.AdminUserEnabled
        {
            get
            {
                return this.AdminUserEnabled();
            }
        }

        /// <summary>
        /// Gets returns entry point to manage container registry webhooks.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhookOperations Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.Webhooks
        {
            get
            {
                return this.Webhooks();
            }
        }

        /// <summary>
        /// Gets the SKU of the container registry.
        /// </summary>
        Models.Sku Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.Sku
        {
            get
            {
                return this.Sku();
            }
        }

        /// <return>The login credentials for the specified container registry.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.GetCredentials()
        {
            return this.GetCredentials();
        }

        /// <summary>
        /// Gets the URL that can be used to log into the container registry.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.LoginServerUrl
        {
            get
            {
                return this.LoginServerUrl();
            }
        }

        /// <summary>
        /// Regenerates one of the login credentials for the specified container registry.
        /// </summary>
        /// <param name="accessKeyType">The admin user access key name to regenerate the value for.</param>
        /// <return>A representation of the future computation of this call.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.RegenerateCredentialAsync(AccessKeyType accessKeyType, CancellationToken cancellationToken)
        {
            return await this.RegenerateCredentialAsync(accessKeyType, cancellationToken);
        }

        /// <return>A representation of the future computation of this call.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.GetCredentialsAsync(CancellationToken cancellationToken)
        {
            return await this.GetCredentialsAsync(cancellationToken);
        }

        /// <summary>
        /// Regenerates one of the login credentials for the specified container registry.
        /// </summary>
        /// <param name="accessKeyType">The admin user access key name to regenerate the value for.</param>
        /// <return>The result of the regeneration.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.RegenerateCredential(AccessKeyType accessKeyType)
        {
            return this.RegenerateCredential(accessKeyType);
        }

        /// <summary>
        /// Creates a container registry with a 'Classic' SKU type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Registry.Definition.IWithStorageAccount Registry.Definition.IWithSkuBeta.WithClassicSku()
        {
            return this.WithClassicSku();
        }

        /// <summary>
        /// Creates a 'managed' registry with a 'Basic' SKU type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Registry.Definition.IWithCreate Registry.Definition.IWithSkuBeta.WithBasicSku()
        {
            return this.WithBasicSku();
        }

        /// <summary>
        /// Creates a 'managed' registry with a 'Standard' SKU type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Registry.Definition.IWithCreate Registry.Definition.IWithSkuBeta.WithStandardSku()
        {
            return this.WithStandardSku();
        }

        /// <summary>
        /// Creates a 'managed' registry with a 'Premium' SKU type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Registry.Definition.IWithCreate Registry.Definition.IWithSkuBeta.WithPremiumSku()
        {
            return this.WithPremiumSku();
        }

        /// <summary>
        /// Updates the current container registry to a 'managed' registry with a 'Basic' SKU type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Registry.Update.IUpdate Registry.Update.IWithSkuBeta.WithBasicSku()
        {
            return this.WithBasicSku();
        }

        /// <summary>
        /// Updates the current container registry to a 'managed' registry with a 'Standard' SKU type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Registry.Update.IUpdate Registry.Update.IWithSkuBeta.WithStandardSku()
        {
            return this.WithStandardSku();
        }

        /// <summary>
        /// Updates the current container registry to a 'managed' registry with a 'Premium' SKU type.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Registry.Update.IUpdate Registry.Update.IWithSkuBeta.WithPremiumSku()
        {
            return this.WithPremiumSku();
        }

        /// <summary>
        /// Gets returns entry point to manage the build tasks for the container registry.
        /// </summary>
        RegistryTaskRun.Definition.IBlankFromRegistry Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.ScheduleRun()
        {
            return this.ScheduleRun();
        }
    }
}