// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registries.WebhooksClient;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent;

    internal partial class RegistriesImpl
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        Registry.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Registry.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        async Task<IPagedCollection<IRegistry>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>.ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListByResourceGroupAsync(resourceGroupName, loadAllPages, cancellationToken);
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>.ListByResourceGroup(string resourceGroupName)
        {
            return this.ListByResourceGroup(resourceGroupName);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IRegistry>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>.List()
        {
            return this.List();
        }

        /// <summary>
        /// Lists the quota usages for the specified container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>A representation of the future computation of this call, returning the list of container registry's quota usages.</return>
        async Task<IReadOnlyCollection<Models.RegistryUsage>> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.ListQuotaUsagesAsync(string resourceGroupName, string registryName, CancellationToken cancellationToken)
        {
            return await this.ListQuotaUsagesAsync(resourceGroupName, registryName, cancellationToken);
        }

        /// <summary>
        /// Checks if container registry name is valid and is not in use asynchronously.
        /// </summary>
        /// <param name="name">The container registry name to check.</param>
        /// <return>A representation of the future computation of this call, returning whether the name is available or other info if not.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.ICheckNameAvailabilityResult> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken)
        {
            return await this.CheckNameAvailabilityAsync(name, cancellationToken);
        }

        /// <summary>
        /// Lists the quota usages for the specified container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>The list of container registry's quota usages.</return>
        System.Collections.Generic.IReadOnlyCollection<Models.RegistryUsage> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.ListQuotaUsages(string resourceGroupName, string registryName)
        {
            return this.ListQuotaUsages(resourceGroupName, registryName);
        }

        /// <summary>
        /// Checks if the specified container registry name is valid and available.
        /// </summary>
        /// <param name="name">The container registry name to check.</param>
        /// <return>Whether the name is available and other info if not.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.ICheckNameAvailabilityResult Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.CheckNameAvailability(string name)
        {
            return this.CheckNameAvailability(name);
        }

        /// <summary>
        /// Gets returns entry point to manage container registry webhooks.
        /// </summary>
        Registries.WebhooksClient.IWebhooksClient Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.Webhooks
        {
            get
            {
                return this.Webhooks();
            }
        }

        /// <summary>
        /// Gets the login credentials for the specified container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>The container registry's login credentials.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.GetCredentials(string resourceGroupName, string registryName)
        {
            return this.GetCredentials(resourceGroupName, registryName);
        }

        /// <summary>
        /// Regenerates the value for one of the admin user access key for the specified container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="accessKeyType">The admin user access key name to regenerate the value for.</param>
        /// <return>A representation of the future computation of this call, returning the container registry's login credentials.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.RegenerateCredentialAsync(string resourceGroupName, string registryName, AccessKeyType accessKeyType, CancellationToken cancellationToken)
        {
            return await this.RegenerateCredentialAsync(resourceGroupName, registryName, accessKeyType, cancellationToken);
        }

        /// <summary>
        /// Gets the login credentials for the specified container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>A representation of the future computation of this call, returning the container registry's login credentials.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.GetCredentialsAsync(string resourceGroupName, string registryName, CancellationToken cancellationToken)
        {
            return await this.GetCredentialsAsync(resourceGroupName, registryName, cancellationToken);
        }

        /// <summary>
        /// Regenerates the value for one of the admin user access key for the specified container registry.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="accessKeyType">The admin user access key name to regenerate the value for.</param>
        /// <return>The container registry's login credentials.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.RegenerateCredential(string resourceGroupName, string registryName, AccessKeyType accessKeyType)
        {
            return this.RegenerateCredential(resourceGroupName, registryName, accessKeyType);
        }


        /// <summary>
        /// The function that gets the URL of the build source upload.
        /// </summary>
        /// <param name="rgName">The name of the resource group.</param>
        /// <param name="acrName">The name of the container.</param>
        /// <return>The URL of the build source upload.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.ISourceUploadDefinition Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.GetBuildSourceUploadUrl(string rgName, string acrName)
        {
            return this.GetBuildSourceUploadUrl(rgName, acrName);
        }

        /// <summary>
        /// The function that gets the URL of the build source upload ashnchronously.
        /// </summary>
        /// <param name="rgName">The name of the resource group.</param>
        /// <param name="acrName">The name of the container.</param>
        /// <return>The URL of the build source upload.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.ISourceUploadDefinition> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.GetBuildSourceUploadUrlAsync(string rgName, string acrName, CancellationToken cancellationToken)
        {
            return await this.GetBuildSourceUploadUrlAsync(rgName, acrName, cancellationToken);
        }
    }
}