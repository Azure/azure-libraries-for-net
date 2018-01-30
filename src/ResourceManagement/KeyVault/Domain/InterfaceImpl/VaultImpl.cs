// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Keyvault.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition;
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Collections.Generic;

    internal partial class VaultImpl 
    {
        /// <summary>
        /// Gets the Azure Active Directory tenant ID that should be used for
        /// authenticating requests to the key vault.
        /// </summary>
        string Microsoft.Azure.Management.KeyVault.Fluent.IVault.TenantId
        {
            get
            {
                return this.TenantId();
            }
        }

        /// <summary>
        /// Gets whether Azure Resource Manager is permitted to
        /// retrieve secrets from the key vault.
        /// </summary>
        bool Microsoft.Azure.Management.KeyVault.Fluent.IVault.EnabledForTemplateDeployment
        {
            get
            {
                return this.EnabledForTemplateDeployment();
            }
        }

        /// <summary>
        /// Gets whether Azure Disk Encryption is permitted to
        /// retrieve secrets from the vault and unwrap keys.
        /// </summary>
        bool Microsoft.Azure.Management.KeyVault.Fluent.IVault.EnabledForDiskEncryption
        {
            get
            {
                return this.EnabledForDiskEncryption();
            }
        }

        /// <summary>
        /// Gets the URI of the vault for performing operations on keys and secrets.
        /// </summary>
        string Microsoft.Azure.Management.KeyVault.Fluent.IVault.VaultUri
        {
            get
            {
                return this.VaultUri();
            }
        }

        /// <summary>
        /// Gets SKU details.
        /// </summary>
        Microsoft.Azure.Management.KeyVault.Fluent.Models.Sku Microsoft.Azure.Management.KeyVault.Fluent.IVault.Sku
        {
            get
            {
                return this.Sku() as Microsoft.Azure.Management.KeyVault.Fluent.Models.Sku;
            }
        }

        /// <summary>
        /// Gets whether Azure Virtual Machines are permitted to
        /// retrieve certificates stored as secrets from the key vault.
        /// </summary>
        bool Microsoft.Azure.Management.KeyVault.Fluent.IVault.EnabledForDeployment
        {
            get
            {
                return this.EnabledForDeployment();
            }
        }

        /// <summary>
        /// Gets an array of 0 to 16 identities that have access to the key vault. All
        /// identities in the array must use the same tenant ID as the key vault's
        /// tenant ID.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.KeyVault.Fluent.IAccessPolicy> Microsoft.Azure.Management.KeyVault.Fluent.IVault.AccessPolicies
        {
            get
            {
                return this.AccessPolicies() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.KeyVault.Fluent.IAccessPolicy>;
            }
        }

        /// <summary>
        /// Enable Azure Disk Encryption to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithConfigurations.WithDiskEncryptionEnabled()
        {
            return this.WithDiskEncryptionEnabled() as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate;
        }

        /// <summary>
        /// Enable Azure Resource Manager to retrieve secrets from the key vault.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithConfigurations.WithTemplateDeploymentEnabled()
        {
            return this.WithTemplateDeploymentEnabled() as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate;
        }

        /// <summary>
        /// Enable Azure Virtual Machines to retrieve certificates stored as secrets from the key vault.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithConfigurations.WithDeploymentEnabled()
        {
            return this.WithDeploymentEnabled() as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate;
        }

        /// <summary>
        /// Disable Azure Virtual Machines to retrieve certificates stored as secrets from the key vault.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithConfigurations.WithDeploymentDisabled()
        {
            return this.WithDeploymentDisabled() as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate;
        }

        /// <summary>
        /// Disable Azure Resource Manager to retrieve secrets from the key vault.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithConfigurations.WithTemplateDeploymentDisabled()
        {
            return this.WithTemplateDeploymentDisabled() as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate;
        }

        /// <summary>
        /// Disable Azure Disk Encryption to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithConfigurations.WithDiskEncryptionDisabled()
        {
            return this.WithDiskEncryptionDisabled() as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate;
        }

        /// <summary>
        /// Enable Azure Disk Encryption to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IWithConfigurations.WithDiskEncryptionEnabled()
        {
            return this.WithDiskEncryptionEnabled() as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate;
        }

        /// <summary>
        /// Enable Azure Resource Manager to retrieve secrets from the key vault.
        /// </summary>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IWithConfigurations.WithTemplateDeploymentEnabled()
        {
            return this.WithTemplateDeploymentEnabled() as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate;
        }

        /// <summary>
        /// Enable Azure Virtual Machines to retrieve certificates stored as secrets from the key vault.
        /// </summary>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IWithConfigurations.WithDeploymentEnabled()
        {
            return this.WithDeploymentEnabled() as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate;
        }

        /// <summary>
        /// Disable Azure Virtual Machines to retrieve certificates stored as secrets from the key vault.
        /// </summary>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IWithConfigurations.WithDeploymentDisabled()
        {
            return this.WithDeploymentDisabled() as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate;
        }

        /// <summary>
        /// Disable Azure Resource Manager to retrieve secrets from the key vault.
        /// </summary>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IWithConfigurations.WithTemplateDeploymentDisabled()
        {
            return this.WithTemplateDeploymentDisabled() as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate;
        }

        /// <summary>
        /// Disable Azure Disk Encryption to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IWithConfigurations.WithDiskEncryptionDisabled()
        {
            return this.WithDiskEncryptionDisabled() as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate;
        }

        /// <summary>
        /// Attach no access policy.
        /// </summary>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithAccessPolicy.WithEmptyAccessPolicy()
        {
            return this.WithEmptyAccessPolicy() as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins the definition of a new access policy to be added to this key vault.
        /// </summary>
        /// <return>The first stage of the access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IBlank<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithAccessPolicy.DefineAccessPolicy()
        {
            return this.DefineAccessPolicy() as Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IBlank<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attach an existing access policy.
        /// </summary>
        /// <param name="accessPolicy">The existing access policy.</param>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithAccessPolicy.WithAccessPolicy(IAccessPolicy accessPolicy)
        {
            return this.WithAccessPolicy(accessPolicy) as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate;
        }

        /// <summary>
        /// Remove an access policy from the access policy list.
        /// </summary>
        /// <param name="objectId">The object ID of the Active Directory identity the access policy is for.</param>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IWithAccessPolicy.WithoutAccessPolicy(string objectId)
        {
            return this.WithoutAccessPolicy(objectId) as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new access policy to be added to this key vault.
        /// </summary>
        /// <return>The first stage of the access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IBlank<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IWithAccessPolicy.DefineAccessPolicy()
        {
            return this.DefineAccessPolicy() as Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IBlank<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the update of an existing access policy attached to this key vault.
        /// </summary>
        /// <param name="objectId">The object ID of the Active Directory identity the access policy is for.</param>
        /// <return>The update stage of the access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IWithAccessPolicy.UpdateAccessPolicy(string objectId)
        {
            return this.UpdateAccessPolicy(objectId) as Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate;
        }

        /// <summary>
        /// Attach an existing access policy.
        /// </summary>
        /// <param name="accessPolicy">The existing access policy.</param>
        /// <return>The key vault update stage.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IWithAccessPolicy.WithAccessPolicy(IAccessPolicy accessPolicy)
        {
            return this.WithAccessPolicy(accessPolicy) as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the sku of the key vault.
        /// </summary>
        /// <param name="skuName">The sku.</param>
        /// <return>The next stage of key vault definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithSku.WithSku(SkuName skuName)
        {
            return this.WithSku(skuName) as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate;
        }
    }
}