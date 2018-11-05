// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.Update;
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure Key Vault key.
    /// </summary>
    public interface IKey :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.KeyVault.Models.KeyBundle>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Key.Update.IUpdate>
    {
        /// <return>A backup of the specified key be downloaded to the client.</return>
        byte[] Backup();

        /// <return>A list of individual key versions with the same key name.</return>
        Task<Microsoft.Azure.Management.KeyVault.Fluent.IKey> ListVersionsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a signature from a digest.
        /// </summary>
        /// <param name="algorithm">The JWK signing algorithm.</param>
        /// <param name="digest">The content to be signed.</param>
        /// <return>The signature in a byte[] array.</return>
        Task<byte[]> SignAsync(JsonWebKeySignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Wraps a symmetric key using the specified algorithm.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="key">The symmetric key to wrap.</param>
        /// <return>The wrapped key.</return>
        Task<byte[]> WrapKeyAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Encrypts an arbitrary sequence of bytes using an encryption key that is stored in a key vault.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="content">The content to be encrypted.</param>
        /// <return>The encrypted value.</return>
        Task<byte[]> EncryptAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] content, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a signature from a digest.
        /// </summary>
        /// <param name="algorithm">The JWK signing algorithm.</param>
        /// <param name="digest">The content to be signed.</param>
        /// <return>The signature in a byte[] array.</return>
        byte[] Sign(JsonWebKeySignatureAlgorithm algorithm, params byte[] digest);

        /// <summary>
        /// Unwraps a symmetric key wrapped originally by this Key Vault key.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="key">The key to unwrap.</param>
        /// <return>The unwrapped symmetric key.</return>
        Task<byte[]> UnwrapKeyAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>A backup of the specified key be downloaded to the client.</return>
        Task<byte[]> BackupAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Decrypts a single block of encrypted data.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="content">The content to be decrypted.</param>
        /// <return>The decrypted value.</return>
        Task<byte[]> DecryptAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] content, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Wraps a symmetric key using the specified algorithm.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="key">The symmetric key to wrap.</param>
        /// <return>The wrapped key.</return>
        byte[] WrapKey(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] key);

        /// <summary>
        /// Gets application specific metadata in the form of key-value pairs.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get; }

        /// <return>A list of individual key versions with the same key name.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.IKey> ListVersions();

        /// <summary>
        /// Gets true if the key's lifetime is managed by key vault. If this is a key
        /// backing a certificate, then managed will be true.
        /// </summary>
        bool Managed { get; }

        /// <summary>
        /// Encrypts an arbitrary sequence of bytes using an encryption key that is stored in a key vault.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="content">The content to be encrypted.</param>
        /// <return>The encrypted value.</return>
        byte[] Encrypt(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] content);

        /// <summary>
        /// Verifies a signature from a digest.
        /// </summary>
        /// <param name="algorithm">The JWK signing algorithm.</param>
        /// <param name="digest">The content to be signed.</param>
        /// <param name="signature">The signature to verify.</param>
        /// <return>True if the signature is valid.</return>
        bool Verify(JsonWebKeySignatureAlgorithm algorithm, byte[] digest, params byte[] signature);

        /// <summary>
        /// Gets the Json web key.
        /// </summary>
        Microsoft.Azure.KeyVault.WebKey.JsonWebKey JsonWebKey { get; }

        /// <summary>
        /// Gets the key management attributes.
        /// </summary>
        Microsoft.Azure.KeyVault.Models.KeyAttributes Attributes { get; }

        /// <summary>
        /// Verifies a signature from a digest.
        /// </summary>
        /// <param name="algorithm">The JWK signing algorithm.</param>
        /// <param name="digest">The content to be signed.</param>
        /// <param name="signature">The signature to verify.</param>
        /// <return>True if the signature is valid.</return>
        Task<bool> VerifyAsync(JsonWebKeySignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Decrypts a single block of encrypted data.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="content">The content to be decrypted.</param>
        /// <return>The decrypted value.</return>
        byte[] Decrypt(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] content);

        /// <summary>
        /// Unwraps a symmetric key wrapped originally by this Key Vault key.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="key">The key to unwrap.</param>
        /// <return>The unwrapped symmetric key.</return>
        byte[] UnwrapKey(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] key);
    }
}