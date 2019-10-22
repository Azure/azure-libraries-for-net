// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point for Key Vault secrets API.
    /// </summary>
    public interface ISecrets :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Secret.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.KeyVault.Fluent.ISecret>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByNameAsync<Microsoft.Azure.Management.KeyVault.Fluent.ISecret>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.KeyVault.Fluent.ISecret>
    {
        /// <summary>
        /// Gets a Key Vault secret.
        /// </summary>
        /// <param name="name">the name of the secret</param>
        /// <param name="version">the version of the secret</param>
        /// <returns>the Key Vault secret</returns>
        Microsoft.Azure.Management.KeyVault.Fluent.ISecret GetByNameAndVersion(string name, string version);

        /// <summary>
        /// Gets a Key Vault secret.
        /// </summary>
        /// <param name="name">the name of the secret</param>
        /// <param name="version">the version of the secret</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>the Key Vault secret</returns>
        Task<Microsoft.Azure.Management.KeyVault.Fluent.ISecret> GetByNameAndVersionAsync(string name, string version, CancellationToken cancellationToken = default(CancellationToken));
    }
}