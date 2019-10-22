// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent.Key.Update
{
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithCreate;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithImport;
    using Microsoft.Azure.KeyVault.Models;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of a key update allowing to specify the key size.
    /// </summary>
    public interface IWithKeySize
    {
        /// <summary>
        /// Specifies the size of the key to create.
        /// </summary>
        /// <param name="size">The size of the key in integer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithCreate.IUpdateWithCreate WithKeySize(int size);
    }

    /// <summary>
    /// The template for a key update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.KeyVault.Fluent.IKey>,
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IWithKey,
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IWithKeyOperations,
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IWithAttributes,
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IWithTags
    {
    }

    /// <summary>
    /// The stage of a key update allowing to specify whether to store the key in
    /// hardware security modules.
    /// </summary>
    public interface IWithHsm
    {
        /// <summary>
        /// Specifies whether to store the key in hardware security modules.
        /// </summary>
        /// <param name="isHsm">Store in Hsm if true.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithImport.IUpdateWithImport WithHsm(bool isHsm);
    }

    /// <summary>
    /// The stage of a key update allowing to create a new version of the key.
    /// </summary>
    public interface IWithKey
    {
        /// <summary>
        /// Specifies a key type to create a new key version.
        /// </summary>
        /// <param name="keyType">The JWK type to create.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithCreate.IUpdateWithCreate WithKeyTypeToCreate(JsonWebKeyType keyType);

        /// <summary>
        /// Specifies an existing key to import as a new version.
        /// </summary>
        /// <param name="key">The existing JWK to import.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithImport.IUpdateWithImport WithLocalKeyToImport(Microsoft.Azure.KeyVault.WebKey.JsonWebKey key);
    }

    /// <summary>
    /// The stage of a key update allowing to specify the attributes of the key.
    /// </summary>
    public interface IWithAttributes
    {
        /// <summary>
        /// Specifies the attributes of the key.
        /// </summary>
        /// <param name="attributes">The object attributes managed by Key Vault service.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IUpdate WithAttributes(Attributes attributes);
    }

    /// <summary>
    /// The stage of a key update allowing to specify the allowed operations for the key.
    /// </summary>
    public interface IWithKeyOperations
    {
        /// <summary>
        /// Specifies the list of allowed key operations. By default all operations are allowed.
        /// </summary>
        /// <param name="keyOperations">The list of JWK operations.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IUpdate WithKeyOperations(IList<JsonWebKeyOperation> keyOperations);

        /// <summary>
        /// Specifies the list of allowed key operations. By default all operations are allowed.
        /// </summary>
        /// <param name="keyOperations">The list of JWK operations.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IUpdate WithKeyOperations(params JsonWebKeyOperation[] keyOperations);
    }

    /// <summary>
    /// The stage of a key update allowing to specify the tags of the key.
    /// </summary>
    public interface IWithTags
    {
        /// <summary>
        /// Specifies the tags on the key.
        /// </summary>
        /// <param name="tags">The key value pair of the tags.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IUpdate WithTags(IDictionary<string, string> tags);
    }
}