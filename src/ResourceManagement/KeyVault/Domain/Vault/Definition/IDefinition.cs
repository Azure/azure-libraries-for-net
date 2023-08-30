// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition
{
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;

    /// <summary>
    /// A key vault definition allowing various configurations to be set.
    /// </summary>
    public interface IWithConfigurations
    {
        /// <summary>
        /// Enable Azure Virtual Machines to retrieve certificates stored as secrets from the key vault.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate WithDeploymentEnabled();

        /// <summary>
        /// Enable Azure Disk Encryption to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate WithDiskEncryptionEnabled();

        /// <summary>
        /// Enable Azure Resource Manager to retrieve secrets from the key vault.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate WithTemplateDeploymentEnabled();

        /// <summary>
        /// Disable Azure Virtual Machines to retrieve certificates stored as secrets from the key vault.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate WithDeploymentDisabled();

        /// <summary>
        /// Disable Azure Disk Encryption to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate WithDiskEncryptionDisabled();

        /// <summary>
        /// Disable Azure Resource Manager to retrieve secrets from the key vault.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate WithTemplateDeploymentDisabled();

        /// <summary>
        /// Enable soft delete for the key vault.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate WithSoftDeleteEnabled();
    }
    /// <summary>
    /// A key vault definition allowing the sku to be set.
    /// </summary>
    public interface IWithSku
    {
        /// <summary>
        /// Specifies the sku of the key vault.
        /// </summary>
        /// <param name="skuName">The sku.</param>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate WithSku(SkuName skuName);
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IBlank,
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithGroup,
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithAccessPolicy,
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate
    {
    }
    /// <summary>
    /// A key vault definition allowing access policies to be attached.
    /// </summary>
    public interface IWithAccessPolicy
    {
        /// <summary>
        /// Attach no access policy.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate WithEmptyAccessPolicy();

        /// <summary>
        /// Attach an existing access policy.
        /// </summary>
        /// <param name="accessPolicy">The existing access policy.</param>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate WithAccessPolicy(IAccessPolicy accessPolicy);

        /// <summary>
        /// Begins the definition of a new access policy to be added to this key vault.
        /// </summary>
        /// <return>The first stage of the access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IBlank<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> DefineAccessPolicy();
    }
    /// <summary>
    /// The first stage of the key vault definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithGroup>
    {
    }
    /// <summary>
    /// A key vault definition allowing resource group to be set.
    /// </summary>
    public interface IWithGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithAccessPolicy>
    {
    }
    /// <summary>
    /// A key vault definition with sufficient inputs to create a new
    /// storage account in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.KeyVault.Fluent.IVault>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>,
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithSku,
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithConfigurations,
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithAccessPolicy
    {
    }
}