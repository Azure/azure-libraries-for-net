// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.Update;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithCreate;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithImport;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class KeyImpl
    {
        /// <summary>
        /// Specifies the list of allowed key operations. By default all operations are allowed.
        /// </summary>
        /// <param name="keyOperations">The list of JWK operations.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IWithKeyOperations.WithKeyOperations(IList<JsonWebKeyOperation> keyOperations)
        {
            return this.WithKeyOperations(keyOperations) as Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the list of allowed key operations. By default all operations are allowed.
        /// </summary>
        /// <param name="keyOperations">The list of JWK operations.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IWithKeyOperations.WithKeyOperations(params JsonWebKeyOperation[] keyOperations)
        {
            return this.WithKeyOperations(keyOperations) as Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the list of allowed key operations. By default all operations are allowed.
        /// </summary>
        /// <param name="keyOperations">The list of JWK operations.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithKeyOperations.WithKeyOperations(IList<JsonWebKeyOperation> keyOperations)
        {
            return this.WithKeyOperations(keyOperations) as Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the list of allowed key operations. By default all operations are allowed.
        /// </summary>
        /// <param name="keyOperations">The list of JWK operations.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithKeyOperations.WithKeyOperations(params JsonWebKeyOperation[] keyOperations)
        {
            return this.WithKeyOperations(keyOperations) as Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate;
        }

        /// <summary>
        /// Verifies a signature from a digest.
        /// </summary>
        /// <param name="algorithm">The JWK signing algorithm.</param>
        /// <param name="digest">The content to be signed.</param>
        /// <param name="signature">The signature to verify.</param>
        /// <return>True if the signature is valid.</return>
        bool Microsoft.Azure.Management.KeyVault.Fluent.IKey.Verify(JsonWebKeySignatureAlgorithm algorithm, byte[] digest, params byte[] signature)
        {
            return this.Verify(algorithm, digest, signature);
        }

        /// <summary>
        /// Decrypts a single block of encrypted data.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="content">The content to be decrypted.</param>
        /// <return>The decrypted value.</return>
        byte[] Microsoft.Azure.Management.KeyVault.Fluent.IKey.Decrypt(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] content)
        {
            return this.Decrypt(algorithm, content);
        }

        /// <return>A list of individual key versions with the same key name.</return>
        async Task<Microsoft.Azure.Management.KeyVault.Fluent.IKey> Microsoft.Azure.Management.KeyVault.Fluent.IKey.ListVersionsAsync(CancellationToken cancellationToken)
        {
            return await this.ListVersionsAsync(cancellationToken) as Microsoft.Azure.Management.KeyVault.Fluent.IKey;
        }

        /// <return>A backup of the specified key be downloaded to the client.</return>
        byte[] Microsoft.Azure.Management.KeyVault.Fluent.IKey.Backup()
        {
            return this.Backup();
        }

        /// <summary>
        /// Gets the Json web key.
        /// </summary>
        Microsoft.Azure.KeyVault.WebKey.JsonWebKey Microsoft.Azure.Management.KeyVault.Fluent.IKey.JsonWebKey
        {
            get
            {
                return this.JsonWebKey() as Microsoft.Azure.KeyVault.WebKey.JsonWebKey;
            }
        }

        /// <summary>
        /// Gets the key management attributes.
        /// </summary>
        Microsoft.Azure.KeyVault.Models.KeyAttributes Microsoft.Azure.Management.KeyVault.Fluent.IKey.Attributes
        {
            get
            {
                return this.Attributes() as Microsoft.Azure.KeyVault.Models.KeyAttributes;
            }
        }

        /// <summary>
        /// Verifies a signature from a digest.
        /// </summary>
        /// <param name="algorithm">The JWK signing algorithm.</param>
        /// <param name="digest">The content to be signed.</param>
        /// <param name="signature">The signature to verify.</param>
        /// <return>True if the signature is valid.</return>
        async Task<bool> Microsoft.Azure.Management.KeyVault.Fluent.IKey.VerifyAsync(JsonWebKeySignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken)
        {
            return await this.VerifyAsync(algorithm, digest, signature, cancellationToken);
        }

        /// <summary>
        /// Gets application specific metadata in the form of key-value pairs.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Microsoft.Azure.Management.KeyVault.Fluent.IKey.Tags
        {
            get
            {
                return this.Tags() as System.Collections.Generic.IReadOnlyDictionary<string, string>;
            }
        }

        /// <summary>
        /// Creates a signature from a digest.
        /// </summary>
        /// <param name="algorithm">The JWK signing algorithm.</param>
        /// <param name="digest">The content to be signed.</param>
        /// <return>The signature in a byte[] array.</return>
        async Task<byte[]> Microsoft.Azure.Management.KeyVault.Fluent.IKey.SignAsync(JsonWebKeySignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken)
        {
            return await this.SignAsync(algorithm, digest, cancellationToken);
        }

        /// <summary>
        /// Wraps a symmetric key using the specified algorithm.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="key">The symmetric key to wrap.</param>
        /// <return>The wrapped key.</return>
        async Task<byte[]> Microsoft.Azure.Management.KeyVault.Fluent.IKey.WrapKeyAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] key, CancellationToken cancellationToken)
        {
            return await this.WrapKeyAsync(algorithm, key, cancellationToken);
        }

        /// <summary>
        /// Encrypts an arbitrary sequence of bytes using an encryption key that is stored in a key vault.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="content">The content to be encrypted.</param>
        /// <return>The encrypted value.</return>
        byte[] Microsoft.Azure.Management.KeyVault.Fluent.IKey.Encrypt(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] content)
        {
            return this.Encrypt(algorithm, content);
        }

        /// <summary>
        /// Wraps a symmetric key using the specified algorithm.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="key">The symmetric key to wrap.</param>
        /// <return>The wrapped key.</return>
        byte[] Microsoft.Azure.Management.KeyVault.Fluent.IKey.WrapKey(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] key)
        {
            return this.WrapKey(algorithm, key);
        }

        /// <summary>
        /// Encrypts an arbitrary sequence of bytes using an encryption key that is stored in a key vault.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="content">The content to be encrypted.</param>
        /// <return>The encrypted value.</return>
        async Task<byte[]> Microsoft.Azure.Management.KeyVault.Fluent.IKey.EncryptAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] content, CancellationToken cancellationToken)
        {
            return await this.EncryptAsync(algorithm, content, cancellationToken);
        }

        /// <summary>
        /// Unwraps a symmetric key wrapped originally by this Key Vault key.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="key">The key to unwrap.</param>
        /// <return>The unwrapped symmetric key.</return>
        async Task<byte[]> Microsoft.Azure.Management.KeyVault.Fluent.IKey.UnwrapKeyAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] key, CancellationToken cancellationToken)
        {
            return await this.UnwrapKeyAsync(algorithm, key, cancellationToken);
        }

        /// <return>A backup of the specified key be downloaded to the client.</return>
        async Task<byte[]> Microsoft.Azure.Management.KeyVault.Fluent.IKey.BackupAsync(CancellationToken cancellationToken)
        {
            return await this.BackupAsync(cancellationToken);
        }

        /// <summary>
        /// Gets true if the key's lifetime is managed by key vault. If this is a key
        /// backing a certificate, then managed will be true.
        /// </summary>
        bool Microsoft.Azure.Management.KeyVault.Fluent.IKey.Managed
        {
            get
            {
                return this.Managed();
            }
        }

        /// <summary>
        /// Unwraps a symmetric key wrapped originally by this Key Vault key.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="key">The key to unwrap.</param>
        /// <return>The unwrapped symmetric key.</return>
        byte[] Microsoft.Azure.Management.KeyVault.Fluent.IKey.UnwrapKey(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] key)
        {
            return this.UnwrapKey(algorithm, key);
        }

        /// <summary>
        /// Creates a signature from a digest.
        /// </summary>
        /// <param name="algorithm">The JWK signing algorithm.</param>
        /// <param name="digest">The content to be signed.</param>
        /// <return>The signature in a byte[] array.</return>
        byte[] Microsoft.Azure.Management.KeyVault.Fluent.IKey.Sign(JsonWebKeySignatureAlgorithm algorithm, params byte[] digest)
        {
            return this.Sign(algorithm, digest);
        }

        /// <summary>
        /// Decrypts a single block of encrypted data.
        /// </summary>
        /// <param name="algorithm">The JWK encryption algorithm.</param>
        /// <param name="content">The content to be decrypted.</param>
        /// <return>The decrypted value.</return>
        async Task<byte[]> Microsoft.Azure.Management.KeyVault.Fluent.IKey.DecryptAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] content, CancellationToken cancellationToken)
        {
            return await this.DecryptAsync(algorithm, content, cancellationToken);
        }

        /// <return>A list of individual key versions with the same key name.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.IKey> Microsoft.Azure.Management.KeyVault.Fluent.IKey.ListVersions()
        {
            return this.ListVersions() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.IKey>;
        }

        /// <summary>
        /// Specifies the size of the key to create.
        /// </summary>
        /// <param name="size">The size of the key in integer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithCreate.IUpdateWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IWithKeySize.WithKeySize(int size)
        {
            return this.WithKeySize(size) as Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithCreate.IUpdateWithCreate;
        }

        /// <summary>
        /// Specifies the size of the key to create.
        /// </summary>
        /// <param name="size">The size of the key in integer.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithKeySize.WithKeySize(int size)
        {
            return this.WithKeySize(size) as Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies whether to store the key in hardware security modules.
        /// </summary>
        /// <param name="isHsm">Store in Hsm if true.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithImport.IUpdateWithImport Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IWithHsm.WithHsm(bool isHsm)
        {
            return this.WithHsm(isHsm) as Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithImport.IUpdateWithImport;
        }

        /// <summary>
        /// Specifies whether to store the key in hardware security modules.
        /// </summary>
        /// <param name="isHsm">Store in Hsm if true.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithImport Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithHsm.WithHsm(bool isHsm)
        {
            return this.WithHsm(isHsm) as Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithImport;
        }

        /// <summary>
        /// Specifies the attributes of the key.
        /// </summary>
        /// <param name="attributes">The object attributes managed by Key Vault service.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IWithAttributes.WithAttributes(Attributes attributes)
        {
            return this.WithAttributes(attributes) as Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the attributes of the key.
        /// </summary>
        /// <param name="attributes">The object attributes managed by Key Vault service.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithAttributes.WithAttributes(Attributes attributes)
        {
            return this.WithAttributes(attributes) as Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies an existing key to import as a new version.
        /// </summary>
        /// <param name="key">The existing JWK to import.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithImport.IUpdateWithImport Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IWithKey.WithLocalKeyToImport(Microsoft.Azure.KeyVault.WebKey.JsonWebKey key)
        {
            return this.WithLocalKeyToImport(key) as Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithImport.IUpdateWithImport;
        }

        /// <summary>
        /// Specifies a key type to create a new key version.
        /// </summary>
        /// <param name="keyType">The JWK type to create.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithCreate.IUpdateWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IWithKey.WithKeyTypeToCreate(JsonWebKeyType keyType)
        {
            return this.WithKeyTypeToCreate(keyType) as Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithCreate.IUpdateWithCreate;
        }

        /// <summary>
        /// Specifies an existing key to import.
        /// </summary>
        /// <param name="key">The existing JWK to import.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithImport Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithKey.WithLocalKeyToImport(Microsoft.Azure.KeyVault.WebKey.JsonWebKey key)
        {
            return this.WithLocalKeyToImport(key) as Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithImport;
        }

        /// <summary>
        /// Specifies a key type to create a new key.
        /// </summary>
        /// <param name="keyType">The JWK type to create.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithKey.WithKeyTypeToCreate(JsonWebKeyType keyType)
        {
            return this.WithKeyTypeToCreate(keyType) as Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Specifies the tags on the key.
        /// </summary>
        /// <param name="tags">The key value pair of the tags.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IWithTags.WithTags(IDictionary<string, string> tags)
        {
            return this.WithTags(tags) as Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the tags on the key.
        /// </summary>
        /// <param name="tags">The key value pair of the tags.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithTags.WithTags(IDictionary<string, string> tags)
        {
            return this.WithTags(tags) as Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate;
        }
    }
}