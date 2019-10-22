// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure Key Vault.
    /// </summary>
    public interface IVaultBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the Key Vault key API entry point.
        /// </summary>
        Microsoft.Azure.Management.KeyVault.Fluent.IKeys Keys { get; }

        /// <summary>
        /// Gets an authenticated Key Vault data client.
        /// </summary>
        Microsoft.Azure.KeyVault.IKeyVaultClient Client { get; }

        /// <summary>
        /// Gets the Key Vault secret API entry point.
        /// </summary>
        Microsoft.Azure.Management.KeyVault.Fluent.ISecrets Secrets { get; }
    }
}