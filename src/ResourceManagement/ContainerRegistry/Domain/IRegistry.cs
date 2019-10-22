// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure registry.
    /// </summary>
    public interface IRegistry :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryManager, Models.RegistryInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Registry.Update.IUpdate>
    {
        /// <summary>
        /// Gets the URL that can be used to log into the container registry.
        /// </summary>
        string LoginServerUrl { get; }

        /// <summary>
        /// Gets the ID of the storage account for the container registry; 'null' if container register SKU a managed tier.
        /// </summary>
        string StorageAccountId { get; }

        /// <summary>
        /// Lists the quota usages for the specified container registry.
        /// </summary>
        /// <return>The list of container registry's quota usages.</return>
        System.Collections.Generic.IReadOnlyCollection<Models.RegistryUsage> ListQuotaUsages();

        /// <return>A representation of the future computation of this call.</return>
        Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials> GetCredentialsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Regenerates one of the login credentials for the specified container registry.
        /// </summary>
        /// <param name="accessKeyType">The admin user access key name to regenerate the value for.</param>
        /// <return>The result of the regeneration.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials RegenerateCredential(AccessKeyType accessKeyType);

        /// <summary>
        /// Gets the name of the storage account for the container registry; 'null' if container register SKU a managed tier.
        /// </summary>
        string StorageAccountName { get; }

        /// <return>The login credentials for the specified container registry.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials GetCredentials();

        /// <summary>
        /// Regenerates one of the login credentials for the specified container registry.
        /// </summary>
        /// <param name="accessKeyType">The admin user access key name to regenerate the value for.</param>
        /// <return>A representation of the future computation of this call.</return>
        Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials> RegenerateCredentialAsync(AccessKeyType accessKeyType, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the creation date of the container registry in ISO8601 format.
        /// </summary>
        System.DateTime CreationDate { get; }

        /// <summary>
        /// Gets the value that indicates whether the admin user is enabled.
        /// </summary>
        bool AdminUserEnabled { get; }

        /// <summary>
        /// Returns entry point to schedule a run.
        /// </summary>
        RegistryTaskRun.Definition.IBlankFromRegistry ScheduleRun();

        /// <summary>
        /// Lists the quota usages for the specified container registry.
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        Task<IReadOnlyCollection<Models.RegistryUsage>> ListQuotaUsagesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>Returns the upload location for the user to be able to upload the source.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.ISourceUploadDefinition GetBuildSourceUploadUrl();

        /// <summary>
        /// Gets the upload location for the user to be able to upload the source asynchronously.
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.ISourceUploadDefinition> GetBuildSourceUploadUrlAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets returns entry point to manage container registry webhooks.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhookOperations Webhooks { get; }

        /// <summary>
        /// Gets the SKU of the container registry.
        /// </summary>
        Models.Sku Sku { get; }
    }
}