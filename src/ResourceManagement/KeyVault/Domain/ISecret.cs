// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure Key Vault secret.
    /// </summary>
    public interface ISecret :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.KeyVault.Models.SecretBundle>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Secret.Update.IUpdate>
    {
        /// <return>A list of individual secret versions with the same secret name.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.ISecret> ListVersions();

        /// <return>A list of individual secret versions with the same secret name.</return>
        Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<Microsoft.Azure.Management.KeyVault.Fluent.ISecret>> ListVersionsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets true if the secret's lifetime is managed by key vault. If this is a key
        /// backing a certificate, then managed will be true.
        /// </summary>
        bool Managed { get; }

        /// <summary>
        /// Gets the corresponding key backing the KV certificate if this is a
        /// secret backing a KV certificate.
        /// </summary>
        string Kid { get; }

        /// <summary>
        /// Gets the secret management attributes.
        /// </summary>
        Microsoft.Azure.KeyVault.Models.SecretAttributes Attributes { get; }

        /// <summary>
        /// Gets the secret value.
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Gets type of the secret value such as a password.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Gets application specific metadata in the form of key-value pairs.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get; }
    }
}