// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registries.WebhooksClient;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point to the registry management API.
    /// </summary>
    public interface IRegistries :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Registry.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistriesOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>
    {
        /// <summary>
        /// Checks if container registry name is valid and is not in use asynchronously.
        /// </summary>
        /// <param name="name">The container registry name to check.</param>
        /// <return>A representation of the future computation of this call, returning whether the name is available or other info if not.</return>
        Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.ICheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists the quota usages for the specified container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>A representation of the future computation of this call, returning the list of container registry's quota usages.</return>
        Task<IReadOnlyCollection<Models.RegistryUsage>> ListQuotaUsagesAsync(string resourceGroupName, string registryName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists the quota usages for the specified container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>The list of container registry's quota usages.</return>
        System.Collections.Generic.IReadOnlyCollection<Models.RegistryUsage> ListQuotaUsages(string resourceGroupName, string registryName);

        /// <summary>
        /// Gets the login credentials for the specified container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>A representation of the future computation of this call, returning the container registry's login credentials.</return>
        Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials> GetCredentialsAsync(string resourceGroupName, string registryName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets returns entry point to manage container registry webhooks.
        /// </summary>
        Registries.WebhooksClient.IWebhooksClient Webhooks { get; }

        /// <summary>
        /// Checks if the specified container registry name is valid and available.
        /// </summary>
        /// <param name="name">The container registry name to check.</param>
        /// <return>Whether the name is available and other info if not.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.ICheckNameAvailabilityResult CheckNameAvailability(string name);

        /// <summary>
        /// Regenerates the value for one of the admin user access key for the specified container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="accessKeyType">The admin user access key name to regenerate the value for.</param>
        /// <return>The container registry's login credentials.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials RegenerateCredential(string resourceGroupName, string registryName, AccessKeyType accessKeyType);

        /// <summary>
        /// Gets the login credentials for the specified container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>The container registry's login credentials.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials GetCredentials(string resourceGroupName, string registryName);

        /// <summary>
        /// Regenerates the value for one of the admin user access key for the specified container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="accessKeyType">The admin user access key name to regenerate the value for.</param>
        /// <return>A representation of the future computation of this call, returning the container registry's login credentials.</return>
        Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials> RegenerateCredentialAsync(string resourceGroupName, string registryName, AccessKeyType accessKeyType, CancellationToken cancellationToken = default(CancellationToken));
    }
}