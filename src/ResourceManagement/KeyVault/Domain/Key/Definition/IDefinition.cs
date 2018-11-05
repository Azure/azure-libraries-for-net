// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition
{
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using Microsoft.Azure.KeyVault.Models;

    /// <summary>
    /// The first stage of a key definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithKey
    {
    }

    /// <summary>
    /// The stage of a key definition allowing to specify whether to store the key in
    /// hardware security modules.
    /// </summary>
    public interface IWithHsm
    {
        /// <summary>
        /// Specifies whether to store the key in hardware security modules.
        /// </summary>
        /// <param name="isHsm">Store in Hsm if true.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithImport WithHsm(bool isHsm);
    }

    /// <summary>
    /// Container interface for all the definitions.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IBlank,
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithKey,
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithImport,
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of a key definition allowing to specify whether
    /// to create a key or to import a key.
    /// </summary>
    public interface IWithKey
    {
        /// <summary>
        /// Specifies a key type to create a new key.
        /// </summary>
        /// <param name="keyType">The JWK type to create.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate WithKeyTypeToCreate(JsonWebKeyType keyType);

        /// <summary>
        /// Specifies an existing key to import.
        /// </summary>
        /// <param name="key">The existing JWK to import.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithImport WithLocalKeyToImport(Microsoft.Azure.KeyVault.WebKey.JsonWebKey key);
    }

    /// <summary>
    /// The stage of a key definition allowing to specify the key size.
    /// </summary>
    public interface IWithKeySize
    {
        /// <summary>
        /// Specifies the size of the key to create.
        /// </summary>
        /// <param name="size">The size of the key in integer.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate WithKeySize(int size);
    }

    /// <summary>
    /// The base stage of the key definition allowing for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreateBase :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.KeyVault.Fluent.IKey>,
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithAttributes,
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithTags
    {
    }

    /// <summary>
    /// The stage of a key definition allowing to specify the tags of the key.
    /// </summary>
    public interface IWithTags
    {
        /// <summary>
        /// Specifies the tags on the key.
        /// </summary>
        /// <param name="tags">The key value pair of the tags.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate WithTags(IDictionary<string, string> tags);
    }

    /// <summary>
    /// The stage of a key definition allowing to specify the attributes of the key.
    /// </summary>
    public interface IWithAttributes
    {
        /// <summary>
        /// Specifies the attributes of the key.
        /// </summary>
        /// <param name="attributes">The object attributes managed by Key Vault service.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate WithAttributes(Attributes attributes);
    }

    /// <summary>
    /// The stage of a key definition allowing to specify the allowed operations for the key.
    /// </summary>
    public interface IWithKeyOperations
    {
        /// <summary>
        /// Specifies the list of allowed key operations. By default all operations are allowed.
        /// </summary>
        /// <param name="keyOperations">The list of JWK operations.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate WithKeyOperations(IList<JsonWebKeyOperation> keyOperations);

        /// <summary>
        /// Specifies the list of allowed key operations. By default all operations are allowed.
        /// </summary>
        /// <param name="keyOperations">The list of JWK operations.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreate WithKeyOperations(params JsonWebKeyOperation[] keyOperations);
    }

    /// <summary>
    /// The stage of the key definition which contains all the minimum required inputs for
    /// the key to be created but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithKeyOperations,
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithKeySize,
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreateBase
    {
    }

    /// <summary>
    /// The stage of the key definition which contains all the minimum required inputs for
    /// the key to be imported but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithImport :
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithHsm,
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IWithCreateBase
    {
    }
}