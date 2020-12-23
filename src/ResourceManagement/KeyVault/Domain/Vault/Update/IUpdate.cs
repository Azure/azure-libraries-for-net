// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update
{
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition;

    /// <summary>
    /// A key vault update allowing various configurations to be set.
    /// </summary>
    public interface IWithConfigurations
    {
        /// <summary>
        /// Enable Azure Virtual Machines to retrieve certificates stored as secrets from the key vault.
        /// </summary>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate WithDeploymentEnabled();

        /// <summary>
        /// Enable Azure Disk Encryption to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate WithDiskEncryptionEnabled();

        /// <summary>
        /// Enable Azure Resource Manager to retrieve secrets from the key vault.
        /// </summary>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate WithTemplateDeploymentEnabled();

        /// <summary>
        /// Disable Azure Virtual Machines to retrieve certificates stored as secrets from the key vault.
        /// </summary>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate WithDeploymentDisabled();

        /// <summary>
        /// Disable Azure Disk Encryption to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate WithDiskEncryptionDisabled();

        /// <summary>
        /// Disable Azure Resource Manager to retrieve secrets from the key vault.
        /// </summary>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate WithTemplateDeploymentDisabled();

        /// <summary>
        /// Enable soft delete for the key vault.
        /// </summary>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate WithSoftDeleteEnabled();
    }

    /// <summary>
    /// The template for a key vault update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.KeyVault.Fluent.IVault>,
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IWithAccessPolicy,
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IWithConfigurations
    {
    }

    /// <summary>
    /// A key vault update allowing access policies to be modified, attached, or removed.
    /// </summary>
    public interface IWithAccessPolicy
    {
        /// <summary>
        /// Remove an access policy from the access policy list.
        /// </summary>
        /// <param name="objectId">The object ID of the Active Directory identity the access policy is for.</param>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate WithoutAccessPolicy(string objectId);

        /// <summary>
        /// Attach an existing access policy.
        /// </summary>
        /// <param name="accessPolicy">The existing access policy.</param>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate WithAccessPolicy(IAccessPolicy accessPolicy);

        /// <summary>
        /// Begins the definition of a new access policy to be added to this key vault.
        /// </summary>
        /// <return>The first stage of the access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IBlank<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> DefineAccessPolicy();

        /// <summary>
        /// Begins the update of an existing access policy attached to this key vault.
        /// </summary>
        /// <param name="objectId">The object ID of the Active Directory identity the access policy is for.</param>
        /// <return>The update stage of the access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate UpdateAccessPolicy(string objectId);
    }
}