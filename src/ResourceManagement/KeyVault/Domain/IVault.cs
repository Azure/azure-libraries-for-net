// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure Key Vault.
    /// </summary>
    public interface IVault :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.KeyVault.Fluent.IKeyVaultManager, Microsoft.Azure.Management.KeyVault.Fluent.Models.VaultInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.KeyVault.Fluent.IVault>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Vault.Update.IUpdate>,
        Microsoft.Azure.Management.KeyVault.Fluent.IVaultBeta
    {
        /// <summary>
        /// Gets whether Azure Virtual Machines are permitted to
        /// retrieve certificates stored as secrets from the key vault.
        /// </summary>
        bool EnabledForDeployment { get; }

        /// <summary>
        /// Gets an array of 0 to 16 identities that have access to the key vault. All
        /// identities in the array must use the same tenant ID as the key vault's
        /// tenant ID.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.KeyVault.Fluent.IAccessPolicy> AccessPolicies { get; }

        /// <summary>
        /// Gets whether Azure Disk Encryption is permitted to
        /// retrieve secrets from the vault and unwrap keys.
        /// </summary>
        bool EnabledForDiskEncryption { get; }

        /// <summary>
        /// Gets whether Azure Resource Manager is permitted to
        /// retrieve secrets from the key vault.
        /// </summary>
        bool EnabledForTemplateDeployment { get; }

        /// <summary>
        /// Gets the Azure Active Directory tenant ID that should be used for
        /// authenticating requests to the key vault.
        /// </summary>
        string TenantId { get; }

        /// <summary>
        /// Gets the URI of the vault for performing operations on keys and secrets.
        /// </summary>
        string VaultUri { get; }

        /// <summary>
        /// Gets SKU details.
        /// </summary>
        Microsoft.Azure.Management.KeyVault.Fluent.Models.Sku Sku { get; }

    }
}